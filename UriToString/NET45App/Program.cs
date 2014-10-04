using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NET45App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var u = new Uri("http://Localhost?p1=Value&p2=A%20B%26p3%3DFooled!");
            Console.WriteLine(u.ToString());

#if NET45
            var regex = new Regex(".*");
            Console.WriteLine("Default Regex.MatchTimeout: " + regex.MatchTimeout);
#endif
        }
    }
}
