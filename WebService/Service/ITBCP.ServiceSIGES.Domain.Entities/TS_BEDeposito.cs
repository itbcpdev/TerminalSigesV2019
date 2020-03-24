

using System;
using System.Runtime.Serialization;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]
    public class TS_BEDeposito
    {
        [DataMember]
        public string nropos { get; set; }
        [DataMember]
        public int turno { get; set; }
        [DataMember]
        public string nrodeposito { get; set; }
        [DataMember]
        public string cdvendedor { get; set; }
        [DataMember]
        public string cdtppago { get; set; }
        [DataMember]
        public string dstppago { get; set; }
        [DataMember]
        public decimal mtosoles { get; set; }
        [DataMember]
        public decimal mtodolares { get; set; }
        [DataMember]
        public int nrosobres { get; set; }
        [DataMember]
        public TS_BEFormato cFormato { get; set; }
        [DataMember]
        public string nrodocumento { get; set; }
        [DataMember]
        public string nroseriemaq { get; set; }
        [DataMember]
        public DateTime fecdocumento { get; set; }
        [DataMember]
        public string fecha { get; set; }
        [DataMember]
        public string info { get; set; }
        [DataMember]
        public string dsvendedor { get; set; }
        [DataMember]
        public bool turno_anterior { get; set; }
    }
}
