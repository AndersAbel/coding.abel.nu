using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace TestLib.Entities
{
    public class Car
    {
        public int CarId { get; private set; }

        private Brand brand;

        [ForeignKey("Car_Brand")]
        public virtual Brand Brand
        {
            get
            {
                Debug.WriteLine(string.Format("Getting Brand for {0}.", RegistrationNumber), "Car");
                return brand;
            }
            set
            {
                Debug.WriteLine(string.Format("Setting Brand to \"{0}\" for {1}.", value.Name, RegistrationNumber), "Car");
                brand = value;
            }
        }

        [ForeignKey("Brand")]
        public int BrandId { get; private set; }

        [Required]
        [StringLength(6)]
        public string RegistrationNumber { get; set; }

        //[Column("BodyStyle", TypeName="int")]
        //public CarBodyStyle BodyStyle { get; set; }

        private int? topSpeed;

        public int? TopSpeed
        {
            get
            {
                Debug.WriteLine(string.Format("Getting TopSpeed for {0}.", RegistrationNumber), "Car");
                return topSpeed;
            }
            set
            {
                Debug.WriteLine("Setting TopSpeed to {0} for {1}.", value, RegistrationNumber, "Car");
                topSpeed = value;
            }
        }

        [Required]
        [StringLength(20)]
        public string Color { get; set; }
    }
}
