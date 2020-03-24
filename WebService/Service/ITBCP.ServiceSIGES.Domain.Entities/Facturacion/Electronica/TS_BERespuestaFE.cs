using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Facturacion.Electronica
{
    [DataContract]
    public class TS_BERespuestaFE
    {
        [DataMember]
        public bool OK { get; set; }
        [DataMember]
        public string Hash { get; set; }
        [DataMember]
        public string PDF417 { get; set; }
        [DataMember]
        public string Respuesta { get; set; }
        [DataMember]
        public string website { get; set; }

    }
}
