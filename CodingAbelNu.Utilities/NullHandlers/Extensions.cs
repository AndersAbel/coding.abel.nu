using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingAbelNu.Utilities.NullHandlers
{
    public static class Extensions
    {
public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> sequence)
{
    return sequence ?? Enumerable.Empty<T>();
}
    }
}
