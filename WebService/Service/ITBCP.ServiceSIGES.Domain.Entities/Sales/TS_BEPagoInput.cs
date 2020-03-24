using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Sales
{
    [DataContract]
    public class TS_BEPagoInput
    {
        [DataMember]
        public string cdtppago { get; set; }
        [DataMember]
        public string cdbanco { get; set; }
        [DataMember]
        public string nrocuenta { get; set; }
        [DataMember]
        public string nrocheque { get; set; }
        [DataMember]
        public string cdtarjeta { get; set; }
        [DataMember]
        public string nrotarjeta { get; set; }
        [DataMember]
        public decimal? mtopagosol { get; set; }
        [DataMember]
        public decimal? mtopagodol { get; set; }
    }
}
