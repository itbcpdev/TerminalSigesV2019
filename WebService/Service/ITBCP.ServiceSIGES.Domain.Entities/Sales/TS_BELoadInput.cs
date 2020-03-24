using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Sales
{
    [DataContract]
    public class TS_BELoadInput
    {
        [DataMember]
        public string cdusuario { get; set; }
        [DataMember]
        public string Serie { get; set; }
        [DataMember]
        public string cdempresa { get; set; }
        [DataMember]
        public string cdnivel { get; set; }
        [DataMember]
        public string cdlocal { get; set; }
    }
}
