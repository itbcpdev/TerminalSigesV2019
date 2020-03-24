using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    public class TS_BEEncripta
    {
        [DataMember]
        public string texto { get; set; }
        [DataMember]
        public string key { get; set; }
    }
}
