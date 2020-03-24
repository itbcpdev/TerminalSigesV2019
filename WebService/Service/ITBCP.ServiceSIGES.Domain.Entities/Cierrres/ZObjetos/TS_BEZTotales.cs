using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cierrres.ZObjetos
{
    [DataContract]
    public class TS_BEZTotales
    {
        [DataMember]
        public decimal incrementro { get; set; }
        [DataMember]
        public decimal descuentos { get; set; }
        [DataMember]
        public decimal total_sin_decuentos { get; set; }
        [DataMember]
        public decimal total_con_decuentos { get; set; }
    }
}
