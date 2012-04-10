using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using TestLib;

namespace TestLibTests
{
    [TestClass]
    public class DynamicOverloadsTests
    {
        [TestMethod]
        public void TestSimple()
        {
            Elephant elephant = new Elephant() { Name = "Hanibal" };
            
            Debug.WriteLine("Transporting an elephant with SimpleTransportation...");
            new SimpleTransportation().TransportAnimal(elephant);

            Debug.WriteLine("Transporting an elephant with FlexibleTransportation...");
            new FlexibleTransportation().TransportAnimal(elephant);
        }
    }
}
