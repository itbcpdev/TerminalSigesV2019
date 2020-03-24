using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]
    public class TS_BEDepositos
    {
        [DataMember]
        public List<TS_BEDeposito> cDepositos { get; set; }
        [DataMember]
        public TS_BEMensaje cMensaje { get; set; }
    }
}
