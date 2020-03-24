using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]
    public class TS_BEArticuloInput
    {
        [DataMember]
        public string glosa { get; set; }
        [DataMember]
        public string cdarticulo { get; set; }
        [DataMember]
        public string cdgrupo02 { get; set; }
    }
}
