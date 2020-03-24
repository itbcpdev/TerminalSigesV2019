using System;
using System.Runtime.Serialization;

namespace ITBCP.ServiceSIGES.Domain.Entities.Reimpresion
{
    [DataContract]
    public class TS_BEReimpresionLInput
    {
        [DataMember]
        public string nrodocumento { get; set; }
        [DataMember]
        public string cdtipodoc { get; set; }
        [DataMember]
        public string nropos { get; set; }

    }
}
