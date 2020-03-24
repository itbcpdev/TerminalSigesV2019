using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Reimpresion
{
    [DataContract]
    public class TS_BEVentagInput
    {
        [DataMember]
        public string cdtipodoc { get; set; }
        [DataMember]
        public string nrodocumento { get; set; }
        [DataMember]
        public string nropos { get; set; }
    }
}
