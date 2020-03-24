using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Reimpresion
{
    [DataContract]
    public class TS_BEReimpresionL
    {
        [DataMember]
        public string nroseriemaq { get; set; }
        [DataMember]
        public string cdtipodoc { get; set; }
        [DataMember]
        public string tipodoc { get; set; }
        [DataMember]
        public string nrodocumento { get; set; }
        [DataMember]
        public DateTime fecdocumento { get; set; }
        [DataMember]
        public string fecha { get; set; }
        [DataMember]
        public string nropos { get; set; }
        [DataMember]
        public string cdcliente { get; set; }
        [DataMember]
        public string rscliente { get; set; }
        [DataMember]
        public string estado { get; set; }
        [DataMember]
        public bool anulado { get; set; } 
    }
}
