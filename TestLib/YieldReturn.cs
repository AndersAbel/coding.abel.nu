using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TestLib
{
    public static class YieldReturn
    {
        public static IEnumerable<int> Numbers(int max)
        {
            for (int i = 0; i < max; i++)
            {
                Console.WriteLine("Returning {0}", i);
                yield return i;
            }
        }

        public static void RunNumbers()
        {
            foreach (int i in Numbers(10).Take(3))
            {
                Console.WriteLine("Number {0}", i);
            }
        }
    }
}
