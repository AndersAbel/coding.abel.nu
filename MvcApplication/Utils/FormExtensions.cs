using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MvcApplication.Utils
{
/// <summary>
/// Helper methods for form creation
/// </summary>
public static class FormExtensions
{
    /// <summary>
    /// Creates an entry in a form, complete with label, input and validation message.
    /// </summary>
    /// <typeparam name="TModel">Type of the model.</typeparam>
    /// <typeparam name="TValue">Type of the field.</typeparam>
    /// <param name="html">Html helper.</param>
    /// <param name="expression">An expression that identifies the field of the model to render an editor entry for</param>
    /// <returns>MvchHtmlString</returns>
    public static MvcHtmlString EditorEntryFor<TModel, TValue>(
        this HtmlHelper<TModel> html,
        Expression<Func<TModel, TValue>> expression)
    {
        return BuildFormEntry(html.LabelFor(expression), 
            html.EditorFor(expression), html.ValidationMessageFor(expression));
    }

    private static MvcHtmlString BuildFormEntry(
        MvcHtmlString label, MvcHtmlString input, MvcHtmlString validation)
    {
        return new MvcHtmlString("<div class=\"editor-label\">" + label + "</div>\n" +
        "<div class=\"editor-field\">" + input + validation + "</div>\n\n");
    }
}
}
