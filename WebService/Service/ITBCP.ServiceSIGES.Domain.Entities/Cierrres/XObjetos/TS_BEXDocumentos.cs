using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cierrres.XObjetos
{
    [DataContract]
    public class TS_BEXDocumentos
    {
        [DataMember]
        public string cantidad_facturas { get; set; }
        [DataMember]
        public decimal total_facturas { get; set; }
        [DataMember]
        public string cantidad_boletas { get; set; }
        [DataMember]
        public decimal total_boletas { get; set; }
        [DataMember]
        public string cantidad_notadespacho { get; set; }
        [DataMember]
        public decimal total_notadespacho { get; set; }
    }
}
