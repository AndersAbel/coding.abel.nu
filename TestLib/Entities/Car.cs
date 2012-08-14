using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TestLib.Entities
{
    // Keep this class non-compatible with change tracking proxies.
    public class Car
    {
        public int CarId { get; private set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        [Required]
        [StringLength(6)]
        public string RegistrationNumber { get; set; }

        [Column("BodyStyle", TypeName = "int")]
        public CarBodyStyle BodyStyle { get; set; }

        public int? TopSpeed { get; set; }

        [Required]
        [StringLength(20)]
        public string Color { get; set; }

        public int Seats { get; set; }
    }
}
