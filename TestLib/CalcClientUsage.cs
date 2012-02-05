using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace TestLib
{
    public class CalcClientUsage
    {
        public int CalcAdd(int term1, int term2)
        {
            using (CalculatorClient.CalculatorClient client =
                new CalculatorClient.CalculatorClient())
            {
                return client.Add(term1, term2);
            }
        }
    }
}
