using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Campos
{
    [DataContract]
    public class TS_BEField
    {
        [DataMember]
        public bool visible { get; set; }
        [DataMember]
        public bool disabled { get; set; }
    }
}
