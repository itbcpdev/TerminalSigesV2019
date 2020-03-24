using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]
    public class TS_BEDepositoInput
    {
        [DataMember]
        public string nropos { get; set; }
        [DataMember]
        public string cdvendedor { get; set; }
        [DataMember]
        public string dsvendedor { get; set; }
        [DataMember]
        public string cdtppago { get; set; }
        [DataMember]
        public decimal mtosoles { get; set; }
        [DataMember]
        public decimal mtodolares { get; set; }
        [DataMember]
        public int nrosobres { get; set; }
        [DataMember]
        public bool turno_anterior { get; set; }

    }
}
