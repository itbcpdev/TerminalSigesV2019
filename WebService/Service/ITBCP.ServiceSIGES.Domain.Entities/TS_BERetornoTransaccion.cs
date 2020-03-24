using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]
    public class TS_BERetornoTransaccion
    {
        
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Numero { get; set; }
        [DataMember]
        public string Valido { get; set; }
        [DataMember]
        public bool Ok { get; set; }
        [DataMember]
        public int NoMensaje { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
    }
}
