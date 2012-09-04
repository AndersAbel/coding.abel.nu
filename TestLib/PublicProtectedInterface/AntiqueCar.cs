using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TestLib.PublicProtectedInterface
{
class AntiqueCar : Car
{
    protected override void StartEngine(Key key)
    {
        Debug.WriteLine("Hand cranking car to start");
    }

    protected override void CheckMirrors()
    {
        Debug.WriteLine("Ignoring mirror check - there are no mirrors.");
    }
}
}
