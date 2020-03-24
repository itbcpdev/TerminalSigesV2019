using System.Runtime.Serialization;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cierrres
{

    [DataContract]
    public class TS_BEZCierreInput
    {

        [DataMember(IsRequired = true)]
        public string nropos { get; set; }
        [DataMember(IsRequired = true)]
        public bool ignorar_bloqueo_playa { get; set; }
        [DataMember(IsRequired = true)]
        public string usuario { get; set; }
        [DataMember(IsRequired = true)]
        public bool imprimir { get; set; }


    }
}
