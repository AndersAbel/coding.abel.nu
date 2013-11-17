using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestLib.Entities
{
    // Keep this class non-compatible with change tracking proxies.
    public class Car
    {
        public int CarId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        [Required]
        [StringLength(6)]
        [Display(Name="Registration Number")]
        public string RegistrationNumber { get; set; }

        public CarBodyStyle BodyStyle { get; set; }

        [Display(Name="Top Speed")]
        public int? TopSpeed { get; set; }

        [Required]
        [StringLength(20)]
        public string Color { get; set; }

        [Display(Name="Number of Seats")]
        public int Seats { get; set; }
    }
}
