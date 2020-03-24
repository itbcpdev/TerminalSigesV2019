using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cierrres.ZObjetos
{
    [DataContract]
    public class TS_BEZTipoPago
    {
        [DataMember]
        public decimal efectivo { get; set; }
        [DataMember]
        public decimal tarjeta { get; set; }
        [DataMember]
        public decimal cheque { get; set; }
        [DataMember]
        public decimal credito { get; set; }
        [DataMember]
        public decimal gratuito { get; set; }
        [DataMember]
        public decimal viatico { get; set; }
        [DataMember]
        public decimal serafin { get; set; }
        [DataMember]
        public decimal totalneto { get; set; }
        [DataMember]
        public decimal total { get; set; }
    }
}
