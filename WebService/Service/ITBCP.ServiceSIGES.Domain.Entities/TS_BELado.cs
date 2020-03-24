using System;
using System.Runtime.Serialization;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]
    public class TS_BELado
    {
        [DataMember]
        public string lado;       
        [DataMember]
        public string cdvendedor;
        [DataMember]
        public string dsvendedor;
        [DataMember]
        public string nropos;

        public string cdlocal;
        public DateTime? fecproceso;
        public string turno;
    }
}
