using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestLib.Entities
{
    [Table("Circles")]
    class Circle : Shape
    {
        [Required]
        public int Radius { get; set; }
    }
}
