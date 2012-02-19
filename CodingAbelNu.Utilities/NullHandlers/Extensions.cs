using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CodingAbelNu.Utilities.NullHandlers
{
    public static class Extensions
    {
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> sequence)
        {
            return sequence ?? Enumerable.Empty<T>();
        }

        /// <summary>
        /// Returns the value if attribute is not null, otherwise the specified
        /// default string.
        /// </summary>
        /// <param name="attribute">Attribute whos value should be returned if
        /// <paramref name="attribute"/> is not null.</param>
        /// <param name="defaultValue">Value to return if <paramref name="attribute"/>
        /// is null.</param>
        /// <returns>String value.</returns>
        public static string GetValueOrDefault(this XAttribute attribute, string defaultValue = null)
        {
            if (attribute == null)
                return defaultValue;
            else
                return attribute.Value;
        }

        /// <summary>
        /// Returns the attribute value if the element is not null, and the element
        /// has the specified attribute, otherwise the default string.
        /// </summary>
        /// <param name="element">XML element with attribute. May be null.</param>
        /// <param name="attributeName">Name of attribute.</param>
        /// <param name="defaultValue">default value.</param>
        /// <returns>String value.</returns>
        public static string GetAttributeValueOrDefault(this XElement element,
            string attributeName, string defaultValue = null)
        {
            if (element == null)
                return defaultValue;
            else
                return element.Attribute(attributeName).GetValueOrDefault(defaultValue);
        }

    }
}
