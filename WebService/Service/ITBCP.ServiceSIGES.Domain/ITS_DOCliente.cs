using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOCliente
    {
        TS_BESaldoclid ObtenerSaldoClientTarjeta(TS_BEClienteSearch input);        
        List<TS_BESaldoclid> ListarSaldoClientTarjeta(TS_BEClienteSearch input);
        TS_BEClienteOutput ObtenerClienteByCodigo(TS_BEClienteSearch input);
        TS_BESaldoclic ObtenerSaldoClientebyCodigo(TS_BEClienteSearch input);
        List<TS_BEClienteOutput> ListarClienteByCodigo(TS_BEClienteSearch input);
        List<TS_BEClienteLista> ListarClientes();
        TS_BEGestionFlotaC ObtenerGestionFlotaC(TS_BEGestionFlotaC input);
        TS_BEGestionFlotaD ObtenerGestionFlotaD(TS_BEGestionFlotaD input);
        List<TS_BEDepartamento> ListarDepartamentos();
        TS_BEMensaje InsertTransCliente(TS_BEClienteInput input, SqlTransaction pSqlTransaction);
        TS_BEMensaje InsertTransClientePlaca(TS_BEClienteInput cCliente, TS_BECabecera cCabecera, SqlTransaction pSqlTransaction); 
        TS_BEClienteCreditoOutput OBTENER_CLIENTE_CREDITO_LOCAL(string nrotarjeta);
        bool UPDATE_SALDO_CLIENTE_LOCAL(TS_BECabecera cCabecera, TS_BEClienteInput cCliente, SqlTransaction pSqlTransaction, Decimal cantidad);
        TS_BEClienteOutput ObtenerClienteByTarjeta(TS_BEClienteSearch input);
        List<TS_BEPTarjeta> LISTA_TARJETA_PREFIJOS();
        List<TS_BEClienteLista> ListarClientesByName(string rscliente);
        List<TS_BEClienteLista> ListarClientesByPlaca(string placa);
    }
}
