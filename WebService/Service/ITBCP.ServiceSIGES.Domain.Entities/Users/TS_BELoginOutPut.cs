using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Users
{
    [DataContract]
    public class TS_BELoginOutPut
    {
        [DataMember]
        public int RetVal { get; set; }
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public bool Ok { get; set; }   
        [DataMember]
        public string Mensaje { get; set; }
        [DataMember]
        public List<TS_BEEmpresaUser> Empresas { get; set; }
        [DataMember]
        public TS_BEUsers Usuario { get; set; }
        [DataMember]
        public string JSONToken { get; set; }
    }
}
