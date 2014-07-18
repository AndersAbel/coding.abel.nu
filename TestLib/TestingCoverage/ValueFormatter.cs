using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib.TestingCoverage
{
    public static class ValueFormatter
    {
        public static string Format(int? value)
        {
            const int defaultValue = 42;

            if(!value.HasValue)
            {
                value = defaultValue;
            }

            return "The value is " + defaultValue + ".";
        }
    }
}
