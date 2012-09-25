using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace CodingAbelNu.Utilities.ToSelectListItems
{
    public static class SelectListItemExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItems<TSource, TData>(
            this IEnumerable<TSource> source,
            Func<TSource, TData> dataField,
            Func<TSource, string> textField)
        { 
            return source.Select(s => new SelectListItem()
            {
                Value = dataField(s).ToString(),
                Text = textField(s)
            });
        }
    }
}
