using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestLib.Entities
{
    [Table("Squares")]
    public class Square : Shape
    {
        [Required]
        public int SideLength { get; set; }
    }
}
