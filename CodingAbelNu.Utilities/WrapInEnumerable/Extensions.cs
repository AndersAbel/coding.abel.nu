using System.Collections.Generic;

namespace CodingAbelNu.Utilities.WrapInEnumerable
{
    public static class Extensions
    {
        /// <summary>
        /// Wraps an object in an IEnumerable.
        /// </summary>
        /// <typeparam name="T">Type of the object to wrap</typeparam>
        /// <param name="wrappedObject">The object that should be wrapped.</param>
        /// <returns>An IEnumerable containing only one element, the object the method is called on.</returns>
        public static IEnumerable<T> WrapInEnumerable<T>(this T wrappedObject)
        {
            yield return wrappedObject;
        }
    }
}
