using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cliente
{
    public class TS_BEClienteLista
    {
        [DataMember]
        public string cdcliente { get; set; }
        [DataMember]
        public string ruccliente { get; set; }
        [DataMember]
        public string rscliente { get; set; }
        [DataMember]
        public string drcliente { get; set; }
        [DataMember]
        public string placa { get; set; }
    }
}
