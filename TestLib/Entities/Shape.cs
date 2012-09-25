using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TestLib.Entities
{
    public abstract class Shape
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Point Position { get; set; }
    }
}
