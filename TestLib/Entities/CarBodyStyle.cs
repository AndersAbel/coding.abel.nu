using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLib.Entities
{
    public enum CarBodyStyle
    { 
        // Start at 1 to avoid 0 which is int's default value.
        Sedan = 1,
        StationWagon,
        HatchBack
    }
}
