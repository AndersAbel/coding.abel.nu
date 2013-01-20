using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CodingAbelNu.Utilities
{
    /// <summary>
    /// Class for Merge extension methods.
    /// </summary>
    public static class LinqSelectMergeExtension
    {
        /// <summary>
        /// Merges the member initialization list of two Select expresion into one.
        /// </summary>
        /// <typeparam name="TSource">Source type, must be the same for both expressions.</typeparam>
        /// <typeparam name="TBaseDest">Resulting type of the base query.</typeparam>
        /// <typeparam name="TExtendedDest">Resulting type of the merged expression.</typeparam>
        /// <param name="source">Source data</param>
        /// <param name="baseSelect">Base select expression. Only analyzed, data is not used 
        /// from this expression.</param>
        /// <param name="mergeExpression">The member initialization expression to merge
        /// with the expression found somewhere within the base select.</param>
        /// <returns>Resulting query, after the merged select expression has been applied.</returns>
        public static IQueryable<TExtendedDest> Merge<TSource, TBaseDest, TExtendedDest>(
            this IQueryable<TSource> source,
            IQueryable<TBaseDest> baseSelect,
            Expression<Func<TSource, TExtendedDest>> mergeExpression)
        {
            // Use an expression visitor to perform the merge of the select expressions.
            var visitor = new MergingVisitor<TSource, TBaseDest, TExtendedDest>(baseSelect);

            var mergedExpression = (Expression<Func<TSource, TExtendedDest>>)
                visitor.Visit(mergeExpression);

            return source.Select(mergedExpression);
        }

        /// <summary>
        /// The merging visitor doing the heavy work.
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
            /// <param name="baseSelect">The base select expression to merge
            /// into the member init list of the extended expression.</param>
            public MergingVisitor(IQueryable<TBaseDest> baseSelect)
            {
                var selectCall = (MethodCallExpression)baseSelect.Expression;
                var unaryExpression = (UnaryExpression)selectCall.Arguments[1];
                var lambda = (LambdaExpression)unaryExpression.Operand;
                baseInit = (MemberInitExpression)lambda.Body;

                baseParameter = lambda.Parameters[0];
            }

            protected override Expression VisitLambda<T>(Expression<T> node)
            {
                if (newParameter == null)
                {
                    newParameter = node.Parameters[0];
                }
                return base.VisitLambda<T>(node);
            }

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
