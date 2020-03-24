using System.Runtime.Serialization;

namespace ITBCP.ServiceSIGES.Domain.Entities.Reimpresion
{
    [DataContract]
    public class TS_BEDocumentoInput
    { 
        [DataMember(IsRequired = true)]
        public string cdtipodoc { get; set; }
        [DataMember(IsRequired = true)]
        public string nrodocumento { get; set; }
        [DataMember(IsRequired = true)]
        public string nroseriemaq { get; set; }
        [DataMember(IsRequired = true)]
        public string fecha { get; set; }
        [DataMember(IsRequired = true)]
        public string nropos { get; set; }
        [DataMember(IsRequired = true)]
        public bool imprimir { get; set; }

    }
}
