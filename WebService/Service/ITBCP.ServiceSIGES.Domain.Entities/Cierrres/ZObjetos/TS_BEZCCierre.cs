using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cierrres.ZObjetos
{
    [DataContract]
    public class TS_BEZCCierre
    {
        [DataMember]
        public string nroseriemaq { get; set; }
        [DataMember]
        public string nropos { get; set; }
        [DataMember]
        public string fecha { get; set; }
        [DataMember]
        public string hora { get; set; }
        [DataMember]
        public string turno { get; set; }
        [DataMember]
        public string usuario { get; set; }
        [DataMember]
        public string cantidad_transacciones { get; set; }
        [DataMember]
        public string subtotal { get; set; }
        [DataMember]
        public string igv { get; set; }
        [DataMember]
        public string total { get; set; }
        [DataMember]
        public string factura_inicial { get; set; }
        [DataMember]
        public string factura_final { get; set; }
        [DataMember]
        public string boleta_inicial { get; set; }
        [DataMember]
        public string boleta_final { get; set; }
        [DataMember]
        public string cantidad_z { get; set; }
        [DataMember]
        public string total_z { get; set; }
        [DataMember]
        public string cantidad_documentos_anulados { get; set; }
        [DataMember]
        public string total_anulados { get; set; }
        [DataMember]
        public string tipo_cambio { get; set; }
        [DataMember]
        public string redondeo { get; set; }

    }
}
