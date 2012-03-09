using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace TestLib.Entities
{
    public class PhoneBookEntry
    {
        public virtual int PhoneBookEntryId { get; set; }

        [Required]
        [StringLength(20)]
        public virtual string Name { get; set; }

        private string phoneNumber;

        [Required]
        [StringLength(20)]
        public virtual string PhoneNumber
        {
            get
            {
                Debug.WriteLine("Getting number {0} for {1}", phoneNumber, Name);
                return phoneNumber;
            }
            set
            {
                Debug.WriteLine("Setting number {0} for {1}", value, Name);
                phoneNumber = value;
            }
        }
    }
}
