using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestLib.Entities
{
    [ComplexType]
    public class Point
    {
        [Required]
        public int XPosition { get; set; }

        [Required]
        public int YPosition { get; set; }
    }
}
