using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]
    public class TS_BEDepositoEInput
    {
        [DataMember]
        public string nrodeposito { get; set; }
        [DataMember]
        public string nropos { get; set; }
        [DataMember]
        public string turno { get; set; }
        [DataMember]
        public DateTime fecproceso { get; set; }

    }
}
