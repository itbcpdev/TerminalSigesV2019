
using System.Runtime.Serialization;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]
    public class TS_BERespuesta
    {
        [DataMember]
        public string respuesta { get; set; }
        [DataMember]
        public bool ok { get; set; }
        [DataMember]
        public string base64encodepdf { get; set; }
        [DataMember]
        public string base64encodehtml { get; set; }
    }
}
