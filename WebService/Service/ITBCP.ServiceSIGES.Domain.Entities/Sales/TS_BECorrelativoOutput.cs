using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Sales
{
    public class TS_BECorrelativoOutput
    {
        [DataMember]
        public string nropos { get; set; }
        [DataMember]
        public string factura { get; set; }
        [DataMember]
        public string boleta { get; set; }
        [DataMember]
        public string ticket { get; set; }
        [DataMember]
        public string nventa { get; set; }
        [DataMember]
        public string promocion { get; set; }
        [DataMember]
        public string ncredito { get; set; }
        [DataMember]
        public string ndebito { get; set; }
        [DataMember]
        public bool Ok { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
    }
}
