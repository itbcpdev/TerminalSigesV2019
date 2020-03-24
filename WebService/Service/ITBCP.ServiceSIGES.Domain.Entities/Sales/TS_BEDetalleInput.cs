using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Sales
{
    [DataContract]
    public  class TS_BEDetalleInput
    {
        [DataMember]
        public int item { get; set; }
        [DataMember]
        public string cdarticulo { get; set; }
        [DataMember]
        public string dsarticulo { get; set; }
        [DataMember]
        public decimal precio { get; set; }
        [DataMember]
        public decimal cantidad { get; set; }
        [DataMember]
        public decimal total { get; set; }
        [DataMember]
        public decimal impuesto { get; set; }
        [DataMember]
        public decimal mtodscto { get; set; }
        [DataMember]
        public decimal mtoimpuesto { get; set; }
        [DataMember]
        public decimal subtotal { get; set; }
        [DataMember]
        public string tpformula { get; set; }
        [DataMember]
        public bool moverstock { get; set; }
        [DataMember]
        public string cara { get; set; }
        [DataMember]
        public string nrogasboy { get; set; }
        [DataMember]
        public decimal costo { get; set; }
        [DataMember]
        public string cdunimed { get; set; }
        [DataMember]
        public decimal precio_orig { get; set; }
        [DataMember]
        public decimal redondea_indecopi { get; set; }
        [DataMember]
        public string cdarticulosunat { get; set; }
        [DataMember]
        public bool impuesto_plastico { get; set; }
        [DataMember]
        public decimal monto_impuesto_plastico { get; set; }

        public string config { get; set; }
        public decimal valor_puntos { get; set; }
        public decimal valor_acumulado { get; set; }
    }
}
