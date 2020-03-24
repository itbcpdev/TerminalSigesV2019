using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cierrres;
using ITBCP.ServiceSIGES.Domain.Entities.Cierrres.ZObjetos;
using System.Collections.Generic;


namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOZCierre
    {
        TS_BEZCCierre OBTENER_CABECERA_CIERRE_Z(TS_BEParametro Parametros, TS_BETerminal Terminal);
        List<TS_BEZGrupo> OBTENER_GRUPO(TS_BEParametro Parametros, TS_BETerminal Terminal, string grupo);
        List<TS_BEZGrupoProductos> OBTENER_VENTAS_POR_PRODUCTO(TS_BEParametro Parametros, TS_BETerminal Terminal);
        List<TS_BEZCara> OBTENER_VENTAS_POR_CARA(TS_BEParametro Parametros, TS_BETerminal Terminal);
        List<TS_BEZVendedor> OBTENER_VENTAS_USUARIO_VENDEDOR(TS_BEParametro Parametros, TS_BETerminal Terminal, string grupo);
        TS_BEZDocumentos OBTENER_VENTAS_POR_DOCUMENTO(TS_BEParametro Parametros, TS_BETerminal Terminal);
        TS_BEZTipoPago OBTENER_TIPOS_PAGO(TS_BEParametro Parametros, TS_BETerminal Terminal);
        decimal OBTENER_TOTAL_CANJES(TS_BEParametro Parametros, TS_BETerminal Terminal);
        List<TS_BEZDepositosVendedor> OBTENER_DEPOSITOS(TS_BEZCierre Cierre, TS_BEParametro Parametros, TS_BETerminal Terminal);
        TS_BEZTotales OBTENER_TOTALIZADOS(TS_BEParametro Parametros, TS_BETerminal Terminal);
        List<TS_BEZArticuloStock> OBTENER_ARTICULOS_VENDIDOS_STOCK_NEGATIVO(TS_BEParametro Parametros, TS_BETerminal Terminal);

    }
}
