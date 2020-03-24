using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Facturacion
{
    public class TS_BEFacturacion
    {
        [DataMember]
        public TS_BECambio TipoCambio { get; set; }
        [DataMember]
        public TS_BEMoneda Moneda { get; set; }
        [DataMember]
        public TS_BETipo_Igv Igv { get; set; }
        [DataMember]
        public TS_BETipopago TipoPago { get; set; }
        [DataMember]
        public TS_BECierre Cierre { get; set; }
        [DataMember]
        public TS_BECara Caras { get; set; }
        [DataMember]
        public TS_BETarjeta tarjeta { get; set; }
        [DataMember]
        public TS_BETerminal Terminal { get; set; }
        [DataMember]
        public TS_BEParameters Parametros { get; set; }
        [DataMember]
        public DateTime FechaServidor { get; set; }
        [DataMember]
        public TS_BEAlmacen Almacen { get; set; }
    }
}
