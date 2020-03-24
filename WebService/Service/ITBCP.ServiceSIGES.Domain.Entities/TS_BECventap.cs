using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]
    public class TS_BECventap
    {
        /*Para impresion de documento*/
        [DataMember]
        public string tipopago { get; set; }
        [DataMember]
        public string sol { get; set; }
        [DataMember]
        public string dol { get; set; }
        [DataMember]
        public string cdtarjeta { get; set; }
        [DataMember]
        public string nrotarjeta { get; set; }
        [DataMember]
        public string cambio { get; set; }
    }
}
