using System.Runtime.Serialization;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]
    public class TS_BEVendedor
    {
        [DataMember]
        public string cdusuario { get; set; }
        [DataMember]
        public string dsvendedor { get; set; }

    }
}
