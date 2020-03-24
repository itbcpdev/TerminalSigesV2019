using System.Runtime.Serialization;

namespace ITBCP.ServiceSIGES.Domain.Entities.Users
{
    [DataContract]
    public class TS_BELoginVendedor
    {
        [DataMember]
        public string usuario { get; set; }
        [DataMember]
        public string clave { get; set; }
        [DataMember]
        public string cdempresa { get; set; }
    }
}
