using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TestLib.Extensions
{
public static class Extensions
{
    public static bool IsEmail(this string str)
    {
        // Regex from http://www.regular-expressions.info/email.html
        return Regex.IsMatch(str, "^[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}$", 
            RegexOptions.IgnoreCase);
    }

public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Func<T, bool> filter)
{
    foreach (T t in source)
    {
        if (filter(t))
        {
            yield return t;
        }
    }
}
}
}
