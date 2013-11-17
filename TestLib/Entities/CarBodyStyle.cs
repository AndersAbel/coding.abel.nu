using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TestLib.Entities
{
    public enum CarBodyStyle
    { 
        [Description("Not Defined")]
        NotDefined = 0,

        Sedan = 1,

        [Description("Station Wagon")]
        StationWagon = 2,
        
        Hatchback = 3
    }
}
