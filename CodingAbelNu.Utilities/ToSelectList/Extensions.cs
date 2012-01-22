using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace CodingAbelNu.Utilities.ToSelectList
{
    /// <summary>
    /// Extension methods for enumerable.
    /// </summary>
    public static class Extensions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "MemberAccess")]
        private static string ExtractFieldName<TSource, TMember>(Expression<Func<TSource, TMember>> expression)
        {
            // Make sure that we have a lambda expression in the right format
            var lambda = (LambdaExpression)expression;
            if (lambda.Body.NodeType != ExpressionType.MemberAccess)
            {
                throw new InvalidOperationException("Expression must be a MemberAccess expression.");
            }

            var memberAccess = (MemberExpression)lambda.Body;

            return memberAccess.Member.Name;
        }

        /// <summary>
        /// Converts a sequence to a SelectList, with typesafe lambdas for member identification.
        /// </summary>
        /// <typeparam name="TSource">The type in the source enumeration.</typeparam>
        /// <param name="source">Source IEnumerable.</param>
        /// <param name="dataValueField">Lambda expression pointing out the value field.</param>
        /// <param name="dataTextField">Lambda expression pointing out the text field.</param>
        /// <returns>A generated SelectList.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static SelectList ToSelectList<TSource, TValue, TText>(this IEnumerable<TSource> source,
            Expression<Func<TSource, TValue>> dataValueField, Expression<Func<TSource, TText>> dataTextField)
        {
            return new SelectList(source, ExtractFieldName(dataValueField), ExtractFieldName(dataTextField));
        }
    }
}
