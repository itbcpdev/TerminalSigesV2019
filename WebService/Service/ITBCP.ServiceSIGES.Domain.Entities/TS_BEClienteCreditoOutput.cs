
using System.Runtime.Serialization;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]

    public class TS_BEClienteCreditoOutput
    {
        [DataMember]
        public string cdcliente { get; set; }
        [DataMember]
        public string nrotarjeta { get; set; }
        [DataMember]
        public string cdgrupo02 { get; set; }
        [DataMember]
        public string cdarticulo { get; set; }
        [DataMember]
        public decimal limitemto { get; set; }
        [DataMember]
        public decimal consumto { get; set; }
        [DataMember]
        public string nrobonus { get; set; }
        [DataMember]
        public string nroplaca { get; set; }
        [DataMember]
        public bool  flgilimit { get; set; }
        [DataMember]
        public bool  flgbloquea { get; set; }
        [DataMember]
        public string nrocontrato { get; set; }
        [DataMember]
        public string tpsaldo { get; set; }
        [DataMember]
        public decimal consumtoC { get; set; }
        [DataMember]
        public bool flgbloqueaC { get; set; }
        [DataMember]
        public decimal limitemtoC { get; set; }
        [DataMember]
        public bool flgilimitC { get; set; }
        [DataMember]
        public string ruc { get; set; }
        [DataMember]
        public string razonsocial { get; set; }
        [DataMember]
        public string direccion { get; set; }
        [DataMember]
        public string nrocontrato1 { get; set; }
        [DataMember]
        public string tipodespacho { get; set; }
        [DataMember]
        public TS_BEMensaje Mensaje { get; set; }

        public string tipocli { get; set; }
    }
}
