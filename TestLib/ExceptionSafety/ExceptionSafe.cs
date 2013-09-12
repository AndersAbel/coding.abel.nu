using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLib.ExceptionSafety
{
public class ExceptionSafe : IDisposable
{
    private readonly PreciousResource resource1, resource2;

    public ExceptionSafe()
    {
        PreciousResource tmp1 = null, tmp2 = null;
        try
        {
            tmp1 = new PreciousResource();
            tmp1.Open();
            tmp2 = new PreciousResource();
            tmp2.Open();

            // Commit point, no exception risk any more.
            resource1 = tmp1;
            tmp1 = null;
            resource2 = tmp2;
            tmp2 = null;
        }
        finally
        {
            if (tmp1 != null)
            {
                tmp1.Dispose();
            }

            if (tmp2 != null)
            {
                tmp2.Dispose();
            }
        }
    }

    public void Dispose()
    {
        resource1.Dispose();
        resource2.Dispose();
    }
}
}
