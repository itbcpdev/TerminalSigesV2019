using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cierrres.XObjetos
{
    [DataContract]
    public class TS_BEXDepositosVendedor
    {
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public decimal soles { get; set; }
        [DataMember]
        public decimal dolares { get; set; }
        [DataMember]
        public string sobres { get; set; }
        [DataMember]
        public decimal efectivo { get; set; }
        [DataMember]
        public string tipo_cambio { get; set; }
        [DataMember]
        public string mensaje { get; set; }
        [DataMember]
        public bool ok { get; set; }
    }
}
