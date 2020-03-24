using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cliente
{
    [DataContract]
    public class TS_BEOpTransInput
    {
        [DataMember]
        public string cara { get; set; }
        [DataMember]
        public string Serie { get; set; }
        [DataMember]
        public string cdcliente { get; set; }
        [DataMember]
        public string tipocliente { get; set; }
        [DataMember]
        public bool automatic { get; set; }
        
        public bool isCredito { get; set; }
    }
}
