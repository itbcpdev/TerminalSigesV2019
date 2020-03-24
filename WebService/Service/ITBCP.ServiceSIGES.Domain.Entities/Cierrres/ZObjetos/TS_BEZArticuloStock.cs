 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cierrres.ZObjetos
{
    [DataContract]
    public class TS_BEZArticuloStock
    {
        [DataMember]
        public string codigo { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public decimal stock { get; set; }
    }
}
