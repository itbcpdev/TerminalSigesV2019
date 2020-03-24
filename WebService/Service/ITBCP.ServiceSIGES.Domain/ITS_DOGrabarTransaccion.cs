using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOGrabarTransaccion
    {
        TS_BEMensaje InsertVenta(TS_BEDocumento cDocumento);
        TS_BEMensaje ANULAR_DOCUMENTO(SqlTransaction oSqlTransaction,TS_BEDocumento input);
        TS_BEMensaje PROCESAR_ANULAR_DOCUMENTO(TS_BEDocumento input);
        TS_BEMensaje REGISTRAR_AFILIACION(TS_BEClienteInput cCliente, List<TS_BEArticulo> Articulos, TS_BETipoTarjetaRegistro Tipo);
        TS_BEMensaje REGISTRAR_TRASPASO_AFILIACION(TS_BEClienteInput cCliente, List<TS_BEArticulo> Articulos, TS_BETipoTarjetaRegistro Tipo);
    }
}

