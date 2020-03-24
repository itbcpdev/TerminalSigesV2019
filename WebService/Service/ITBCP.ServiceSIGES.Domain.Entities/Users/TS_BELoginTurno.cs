using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Users
{
    [DataContract]
    public class TS_BELoginTurno
    {
        [DataMember]
        public string cdusuario { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string cdempresa { get; set; }
    }
}
