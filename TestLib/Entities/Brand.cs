using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TestLib.Entities
{
public class Brand
{
    public int BrandId { get; private set; }
        
    [Required]
    [StringLength(20)]
    public string Name { get; set; }

    public ICollection<Car> Cars { get; set; }
}
}
