using System.Collections.Generic;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cierrres;
using ITBCP.ServiceSIGES.Domain.Entities.Cierrres.XObjetos;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOXCierre
    {
        TS_BECCierre OBTENER_CABECERA_CIERRE_X(TS_BEParametro Parametros, TS_BETerminal Terminal);
        List<TS_BEXGrupo> OBTENER_GRUPO(TS_BEParametro Parametros, TS_BETerminal Terminal, string grupo);
        List<TS_BEXGrupoProductos> OBTENER_VENTAS_POR_PRODUCTO(TS_BEParametro Parametros, TS_BETerminal Terminal);
        List<TS_BEXCara> OBTENER_VENTAS_POR_CARA(TS_BEParametro Parametros, TS_BETerminal Terminal);
        List<TS_BEXVendedor> OBTENER_VENTAS_USUARIO_VENDEDOR(TS_BEParametro Parametros, TS_BETerminal Terminal, string grupo);
        TS_BEXDocumentos OBTENER_VENTAS_POR_DOCUMENTO(TS_BEParametro Parametros, TS_BETerminal Terminal);
        TS_BEXTipoPago OBTENER_TIPOS_PAGO(TS_BEParametro Parametros, TS_BETerminal Terminal);
        decimal OBTENER_TOTAL_CANJES(TS_BEParametro Parametros, TS_BETerminal Terminal);
        List<TS_BEXDepositosVendedor> OBTENER_DEPOSITOS(TS_BEXCierre Cierre, TS_BEParametro Parametros, TS_BETerminal Terminal);
        TS_BEXTotales OBTENER_TOTALIZADOS(TS_BEParametro Parametros, TS_BETerminal Terminal);
        List<TS_BEXArticuloStock> OBTENER_ARTICULOS_VENDIDOS_STOCK_NEGATIVO(TS_BEParametro Parametros, TS_BETerminal Terminal);

    }
}
