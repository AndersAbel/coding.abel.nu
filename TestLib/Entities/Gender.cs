using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLib.Entities
{
    public class Gender
    {
        public byte GenderId { get; set; }
        public string Description { get; set; }

        public const byte UnSpecified = 0;
        public const byte Male = 1;
        public const byte Female = 2;

        public ICollection<Person> People { get; private set; }
    }
}
