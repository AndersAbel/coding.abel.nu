using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TestLib.ExceptionSafety
{
    public class PreciousResource : IDisposable
    {
        public PreciousResource()
        {
            Debug.WriteLine("Allocated precious resource.");
        }

        public void Dispose()
        {
            Debug.WriteLine("Disposed precious resource.");
        }

        public void Open()
        {
            throw new InvalidOperationException("Failed opening!");
        }
    }
}
