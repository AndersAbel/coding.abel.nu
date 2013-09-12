using CodingAbelNu.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLib.ExceptionSafety
{
public class NotExceptionSafe : IDisposable
{
    private readonly PreciousResource resource;

    public NotExceptionSafe()
    {
        resource = new PreciousResource();
        resource.Open();
    }

    public void Dispose()
    {
        resource.Dispose();
    }
}
}
