using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Sales
{
    [DataContract]
    public class TS_BEDAnulaInput
    {
        [DataMember]
        public string cdtipodoc { get; set; }
        [DataMember]
        public string nrodocumento { get; set; }
        [DataMember]
        public string nroseriemaq { get; set; }
        [DataMember]
        public string nropos { get; set; }
        [DataMember]
        public bool fact_electronica { get; set; }
        [DataMember]
        public string cdusuario { get; set; }

        /*Manejo interno*/
        public string fecha { get; set; }
        public DateTime fecdocumento { get; set; }
        public DateTime fecproceso { get; set; }
        public bool anulado { get; set; }
        public bool cerrado { get; set; }
        public string cdlocal { get; set; }
        public bool exists { get; set; }
    }
}
