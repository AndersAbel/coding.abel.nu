using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace CodingAbelNu.Utilities
{
/// <summary>
/// Class for Merge extension methods.
/// </summary>
public static class LinqSelectMergeExtension
{
    /// <summary>
    /// Merges the member initialization list of two lambda expressions into one.
    /// </summary>
    /// <typeparam name="TSource">Source type.</typeparam>
    /// <typeparam name="TBaseDest">Resulting type of the base mapping expression. TBaseDest is typically
    /// a super class of TExtendedDest</typeparam>
    /// <typeparam name="TExtendedDest">Resulting type of the extended mapping expression.</typeparam>
    /// <param name="baseExpression">The base mapping expression, containing a member 
    /// initialization expression.</param>
    /// <param name="mergeExpression">The extended mapping expression to be merged into the
    /// base member initialization expression.</param>
    /// <returns>Resulting expression, after the merged select expression has been applied.</returns>
    public static Expression<Func<TSource, TExtendedDest>> Merge<TSource, TBaseDest, TExtendedDest>(
        this Expression<Func<TSource, TBaseDest>> baseExpression,
        Expression<Func<TSource, TExtendedDest>> mergeExpression)
    {
        // Use an expression visitor to perform the merge of the select expressions.
        var visitor = new MergingVisitor<TSource, TBaseDest, TExtendedDest>(baseExpression);

        return (Expression<Func<TSource, TExtendedDest>>)visitor.Visit(mergeExpression);
    }

    /// <summary>
    /// The merging visitor doing the actual merging work.
    /// </summary>
    /// <typeparam name="TSource">Source data type.</typeparam>
    /// <typeparam name="TBaseDest">Resulting type of the base query.</typeparam>
    /// <typeparam name="TExtendedDest">Resulting type of the merged expression.</typeparam>
    private class MergingVisitor<TSource, TBaseDest, TExtendedDest> : ExpressionVisitor
    {
        /// <summary>
        /// Internal helper, that rebinds the lambda of the base init expression. The
        /// reason for this is that the member initialization list of the base expression
        /// is bound to the range variable in the base expression. To be able to merge those
        /// into the extended expression, all those references have to be rebound to the
        /// range variable of the extended expression. That rebinding is done by this helper.
        /// </summary>
        private class LambdaRebindingVisitor : ExpressionVisitor
        {
            private ParameterExpression newParameter;
            private ParameterExpression oldParameter;

            /// <summary>
            /// Ctor.
            /// </summary>
            /// <param name="newParameter">The range vaiable of the extended expression.</param>
            /// <param name="oldParameter">The range variable of the base expression.</param>
            public LambdaRebindingVisitor(ParameterExpression newParameter,
                ParameterExpression oldParameter)
            {
                this.newParameter = newParameter;
                this.oldParameter = oldParameter;
            }

            /// <summary>
            /// Whenever a memberaccess is done that access the old parameter, rewrite
            /// it to access the new parameter instead.
            /// </summary>
            /// <param name="node">Member expression to visit.</param>
            /// <returns>Possibly rewritten member access node.</returns>
            protected override Expression VisitMember(MemberExpression node)
            {
                if (node.Expression == oldParameter)
                {
                    return Expression.MakeMemberAccess(newParameter, node.Member);
                }
                return base.VisitMember(node);
            }
        }

        private MemberInitExpression baseInit;
        private ParameterExpression baseParameter;
        private ParameterExpression newParameter;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="baseExpression">The base expression to merge
        /// into the member init list of the extended expression.</param>
        public MergingVisitor(Expression<Func<TSource, TBaseDest>> baseExpression)
        {
            var lambda = (LambdaExpression)baseExpression;
            baseInit = (MemberInitExpression)lambda.Body;

            baseParameter = lambda.Parameters[0];
        }

        /// <summary>
        /// Pick up the extended expressions range variable.
        /// </summary>
        /// <typeparam name="T">Not used</typeparam>
        /// <param name="node">Lambda expression node</param>
        /// <returns>Unmodified expression tree</returns>
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            if (newParameter == null)
            {
                newParameter = node.Parameters[0];
            }
            return base.VisitLambda<T>(node);
        }

        /// <summary>
        /// Visit the member init expression of the extended expression. Merge the base 
        /// expression into it.
        /// </summary>
        /// <param name="node">Member init expression node.</param>
        /// <returns>Merged member init expression.</returns>
        protected override Expression VisitMemberInit(MemberInitExpression node)
        {
            LambdaRebindingVisitor rebindVisitor =
                new LambdaRebindingVisitor(newParameter, baseParameter);

            var reboundBaseInit = (MemberInitExpression)rebindVisitor.Visit(baseInit);

            var mergedInitList = node.Bindings.Concat(reboundBaseInit.Bindings);

            return Expression.MemberInit(Expression.New(typeof(TExtendedDest)),
                mergedInitList);
        }
    }
}
}
