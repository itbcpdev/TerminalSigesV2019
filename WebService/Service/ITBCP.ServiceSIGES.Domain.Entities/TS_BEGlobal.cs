using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]
    public class TS_BEGlobal
    {
        [DataMember]
        public decimal op_gravada { get; set; }
        [DataMember]
        public decimal op_gratuita { get; set; }
        [DataMember]
        public decimal op_exonerada { get; set; }
        [DataMember]
        public decimal op_inafecta { get; set; }
        [DataMember]
        public decimal monto_igv { get; set; }
        [DataMember]
        public decimal monto_descuentos { get; set; }
        [DataMember]
        public decimal monto_total { get; set; }
    }
}
