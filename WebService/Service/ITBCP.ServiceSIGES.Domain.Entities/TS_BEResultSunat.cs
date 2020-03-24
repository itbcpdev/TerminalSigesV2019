using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    public class TS_BEResultSunat
    {
        [DataMember]
        public string ruc { get; set; }
        [DataMember]
        public string razonSocial { get; set; }
        [DataMember]
        public string direccion { get; set; }
        [DataMember]
        public bool Ok { get; set; }
        [DataMember]
        public string Mensaje { get; set; }

    }
}
