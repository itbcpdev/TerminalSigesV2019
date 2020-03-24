using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]
    public class TS_BEVendedores
    {
        [DataMember]
        public List<TS_BEVendedor> cVendedores { get; set; }
        [DataMember]
        public TS_BEMensaje Mensaje { get; set; }
    }
}
