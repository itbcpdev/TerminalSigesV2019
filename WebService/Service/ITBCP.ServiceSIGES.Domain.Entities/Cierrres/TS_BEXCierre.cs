using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain.Entities.Cierrres.XObjetos;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cierrres
{
    [DataContract]
    public class TS_BEXCierre
    {

        [DataMember]
        public TS_BECCierre cCabecera { get; set; }
        [DataMember]
        public List<TS_BEXGrupo> cGrupo01 { get; set; }
        [DataMember]
        public List<TS_BEXGrupo> cGrupo02 { get; set; }
        [DataMember]
        public List<TS_BEXGrupo> cGrupo03 { get; set; }
        [DataMember]
        public List<TS_BEXGrupo> cGrupo04 { get; set; }
        [DataMember]
        public List<TS_BEXGrupo> cGrupo05 { get; set; }
        [DataMember]
        public List<TS_BEXGrupoProductos> cVentasPorProducto { get; set; }
        [DataMember]
        public List<TS_BEXCara> cVentasPorCara { get; set; }
        [DataMember]
        public List<TS_BEXVendedor> cVentasPorVendedor { get; set; }
        [DataMember]
        public List<TS_BEXVendedor> cVentasPorUsuario { get; set; }
        [DataMember]
        public TS_BEXDocumentos cVentasPorDocumentos { get; set; }
        [DataMember]
        public TS_BEXTipoPago cVentasPorTipoPago { get; set; }
        [DataMember]
        public decimal cTotalCanjes { get; set; }
        [DataMember]
        public List<TS_BEXDepositosVendedor> cDepositos { get; set; }
        [DataMember]
        public TS_BEXTotales cTotales { get; set; }
        [DataMember]
        public List<TS_BEXArticuloStock> cStockNegativos { get; set; }
        [DataMember]
        public TS_BECierre cParametros { get; set; }
        [DataMember]
        public TS_BEFormato cFormato { get; set; }
        [DataMember]
        public TS_BEMensaje Mensaje { get; set; }
        

    }
}
