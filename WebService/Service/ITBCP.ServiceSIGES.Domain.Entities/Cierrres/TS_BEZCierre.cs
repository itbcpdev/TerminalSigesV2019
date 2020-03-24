using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain.Entities.Cierrres.ZObjetos;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cierrres
{
    [DataContract]
    public class TS_BEZCierre
    {

        [DataMember]
        public TS_BEZCCierre cCabecera { get; set; }
        [DataMember]
        public List<TS_BEZGrupo> cGrupo01 { get; set; }
        [DataMember]
        public List<TS_BEZGrupo> cGrupo02 { get; set; }
        [DataMember]
        public List<TS_BEZGrupo> cGrupo03 { get; set; }
        [DataMember]
        public List<TS_BEZGrupo> cGrupo04 { get; set; }
        [DataMember]
        public List<TS_BEZGrupo> cGrupo05 { get; set; }
        [DataMember]
        public List<TS_BEZGrupoProductos> cVentasPorProducto { get; set; }
        [DataMember]
        public List<TS_BEZCara> cVentasPorCara { get; set; }
        [DataMember]
        public List<TS_BEZVendedor> cVentasPorVendedor { get; set; }
        [DataMember]
        public List<TS_BEZVendedor> cVentasPorUsuario { get; set; }
        [DataMember]
        public TS_BEZDocumentos cVentasPorDocumentos { get; set; }
        [DataMember]
        public TS_BEZTipoPago cVentasPorTipoPago { get; set; }
        [DataMember]
        public decimal cTotalCanjes { get; set; }
        [DataMember]
        public List<TS_BEZDepositosVendedor> cDepositos { get; set; }
        [DataMember]
        public TS_BEZTotales cTotales { get; set; }
        [DataMember]
        public List<TS_BEZArticuloStock> cStockNegativos { get; set; }
        [DataMember]
        public TS_BECierre cParametros { get; set; }
        [DataMember]
        public TS_BEFormato cFormato { get; set; }
        [DataMember]
        public TS_BEMensaje Mensaje { get; set; }
        

    }
}
