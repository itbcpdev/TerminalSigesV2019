using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    public class TS_BEDepartamento
    {
        [DataMember]
        public string cddepartamento { get; set; }        
        [DataMember]
        public string dsdepartamento { get; set; }
        [DataMember]
        public bool FlgAfecto { get; set; }
        [DataMember]
        public bool Ok { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
    }
}
