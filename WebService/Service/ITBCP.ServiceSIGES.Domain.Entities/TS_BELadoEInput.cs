using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]
    public class TS_BELadoEInput
    {
        [DataMember]
        public string nropos { get; set; }
        [DataMember]
        public string lado { get; set; }

        public DateTime? fecproceso;
        public string turno;
    }
}
