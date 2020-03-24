using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract] 
    public class TS_BECemisor
    {
        [DataMember]
        public string detallesEmpresa { get; set; }
        [DataMember]
        public string rucempresa { get; set; }
        [DataMember]
        public string impresora { get; set; }
    }
}
