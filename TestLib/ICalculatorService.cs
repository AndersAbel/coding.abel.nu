using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TestLib
{
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        int Add(int term1, int term2);
    }
}
