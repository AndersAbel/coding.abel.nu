using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace TestLib.Entities
{
    public class Brand
    {
        public int BrandId { get; private set; }

        private string name;

        [Required]
        [StringLength(20)]
        public string Name
        {
            get
            {
                Debug.WriteLine(string.Format("Getting name for {0}.", name), "Brand");
                return name;
            }
            set
            {
                Debug.WriteLine(string.Format("Setting name to {0}.", value), "Brand");
                name = value;
            }
        }

        public ICollection<Car> Cars { get; set; }
    }
}
