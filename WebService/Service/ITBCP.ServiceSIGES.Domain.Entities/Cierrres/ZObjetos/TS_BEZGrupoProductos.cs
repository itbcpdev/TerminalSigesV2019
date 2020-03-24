using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cierrres.ZObjetos
{
    [DataContract]
    public class TS_BEZGrupoProductos
    {
        [DataMember]
        public string codigo { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public decimal cantidad { get; set; }
        [DataMember]
        public decimal descuento { get; set; }
        [DataMember]
        public decimal total { get; set; }
        [DataMember]
        public decimal gratuito { get; set; }
    }
}
