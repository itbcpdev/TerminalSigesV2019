using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOAfiliacionTarjeta
    {
        bool INSERT_AFILIACION_PUNTOS(TS_BECabecera cCabecera, TS_BEArticulo cDetalles, TS_BEClienteInput cCliente, SqlTransaction oSqlTransaction);

        TS_BEMensaje OBTENER_PUNTOS_POR_PRODUCTO(TS_BECabecera cCabecera,TS_BEClienteInput cCliente, TS_BEArticulo Producto, SqlTransaction oSqlTransaction);

        bool UPDATE_AFILIACION_PUNTOS(TS_BECabecera cCabecera, TS_BEArticulo cDetalles, SqlTransaction oSqlTransaction);

        bool INSERT_AFILIACION_PUNTOS_CANJE(TS_BECabecera cCabecera, TS_BEArticulo cDetalles, TS_BEClienteInput cCliente, SqlTransaction oSqlTransaction);


        bool INSERT_AFILIACION_TARJETA(TS_BEClienteInput cCliente, SqlTransaction oSqlTransaction);

        bool INSERT_AFILIACION_TARJETA_CONCEPTOS(TS_BEClienteInput cCliente, TS_BEArticulo Articulo, SqlTransaction oSqlTransaction);
    }
}
