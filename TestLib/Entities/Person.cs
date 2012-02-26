using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.ComponentModel;

namespace TestLib.Entities
{
    [Table("People")]
    public class Person
    {
        public virtual int PersonId { get; set; }

        private int birthYear;

        [Required]
        public virtual int BirthYear
        {
            get
            {
                //Debug.WriteLine(string.Format("Getting BirthYear of person {0}", PersonId));
                return birthYear;
            }
            set
            {
                //Debug.WriteLine(string.Format("Setting BirthYear of person {0} to {1}",
                //    PersonId, value));
                birthYear = value;
            }
        }

        [ForeignKey("Gender")]
        public virtual byte GenderId { get; set; }

        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }
    }
}
