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
        /// <summary>
        /// Converts a sequence to a SelectList, with typesafe lambdas for member identification.
        /// </summary>
        /// <typeparam name="TSource">The type in the source enumeration.</typeparam>
        /// <typeparam name="TValue">The type of the value field.</typeparam>
        /// <typeparam name="TText">Thye type of the text field.</typeparam>
        /// <param name="source">Source IEnumerable.</param>
        /// <param name="dataValueField">Lambda expression selecting the value field.</param>
        /// <param name="dataTextField">Lambda expression selecting the text field.</param>
        /// <returns>A generated SelectList.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static SelectList ToSelectList<TSource, TValue, TText>(this IEnumerable<TSource> source,
            Expression<Func<TSource, TValue>> dataValueField, Expression<Func<TSource, TText>> dataTextField)
        {
            string dataName = ExpressionHelper.GetExpressionText(dataValueField);
            string textName = ExpressionHelper.GetExpressionText(dataTextField);
            return new SelectList(source, dataName, textName);
        }

        /// <summary>
        /// Converts a sequence to a SelectList, with the value being set to the index in the list and
        /// the text field selected by a type safe lambda expression.
        /// </summary>
        /// <typeparam name="TSource">The type in the source enumeration.</typeparam>
        /// <typeparam name="TText">The type of the text field.</typeparam>
        /// <param name="source">Source IEnumerable.</param>
        /// <param name="dataTextField">Lambda expression selecting the text field.</param>
        /// <returns>A generated SelectList.</returns>
        public static SelectList ToSelectList<TSource, TText>(this IEnumerable<TSource> source,
            Func<TSource, TText> dataTextField)
        {
            var indexedSource = source.Select((s, i) => new
            {
                Index = i,
                Text = dataTextField(s)
            });
            return ToSelectList(indexedSource, s => s.Index, s => s.Text);
        }
    }
}
