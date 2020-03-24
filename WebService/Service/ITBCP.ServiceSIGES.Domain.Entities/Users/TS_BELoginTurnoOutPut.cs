using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Users
{
    [DataContract]
    public class TS_BELoginTurnoOutPut
    {
        [DataMember]
        public bool Ok { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
    }
}
