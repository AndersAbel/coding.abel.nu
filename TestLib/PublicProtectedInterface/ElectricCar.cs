using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;

namespace TestLib.PublicProtectedInterface
{
class ElectricCar : Car
{
    protected override void StartEngine(Key key)
    {
        if (!IsKeyApproved(key))
        {
            throw new SecurityException("Invalid key");
        }
    }
}
}
