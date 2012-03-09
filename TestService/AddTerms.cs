using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TestService
{
    [DataContract]
    public class AddTerms
    {
        [DataMember]
        public int Term1 { get; set; }

        [DataMember]
        public int Term2 { get; set; }
    }
}
