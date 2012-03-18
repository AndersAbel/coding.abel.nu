using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using My32BitLib;

namespace TestService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults =true)]
    public class Calculator : ICalculator
    {
        public int Add(int term1, int term2)
        {
            return term1 + term2;
        }

        public int AddFromDto(AddTerms terms)
        {
            return terms.Term1 + terms.Term2;
        }

        public int Multiply(int factor1, int factor2)
        {
            return Multiplier.Multiply(factor1, factor2);
        }
    }
}
