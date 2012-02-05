using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TestLib
{
    public class CalculatorService : ICalculatorService
    {
        public int Add(int term1, int term2)
        {
            return term1 + term2;
        }
    }
}
