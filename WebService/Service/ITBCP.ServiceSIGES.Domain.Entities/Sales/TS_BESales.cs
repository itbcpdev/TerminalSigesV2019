using ITBCP.ServiceSIGES.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Sales
{
    public class TS_BESales
    {
        [DataMember]
        public decimal TipoCambio { get; set; }
        [DataMember]
        public string Igv { get; set; }
        [DataMember]
        public string FechaServidor { get; set; }
        [DataMember]
        public List<TS_BETipopago> TipoPago { get; set; }
        [DataMember]
        public List<TS_BECara> Caras { get; set; }
        [DataMember]
        public List<TS_BETarjeta> Tarjetas { get; set; }
        [DataMember]
        public TS_BETerminal Terminal { get; set; }
        [DataMember]
        public TS_BEParametro Parametros { get; set; }
        [DataMember]
        public TS_BECabecera Cabecera { get; set; }
        [DataMember]
        public TS_BEVendedor Vendedor {get;set;}
        [DataMember]
        public TS_BEUsers Usuario { get; set; }

        [DataMember]
        public bool Ok { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
    }
}
