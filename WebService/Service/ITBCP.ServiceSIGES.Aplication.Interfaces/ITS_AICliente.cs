using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Aplication.Interfaces
{
    public interface ITS_AICliente
    {
        TS_BESaldoclid ObtenerSaldoClientTarjeta(TS_BEClienteSearch input);
        List<TS_BESaldoclid> ListarSaldoClientTarjeta(TS_BEClienteSearch input);
        TS_BEClienteOutput ObtenerClienteByCodigo(TS_BEClienteSearch input);
        TS_BESaldoclic ObtenerSaldoClientebyCodigo(TS_BEClienteSearch input);
        TS_BEClienteOutput ObtenerClientebyTarjeta(TS_BEClienteSearch input);
        List<TS_BEClienteOutput> ListarClienteByCodigo(TS_BEClienteSearch input);
        List<TS_BEClienteLista> ListarClientes();
        TS_BEGestionFlotaC ObtenerGestionFlotaC(TS_BEGestionFlotaC input);
        TS_BEGestionFlotaD ObtenerGestionFlotaD(TS_BEGestionFlotaD input);
        List<TS_BEDepartamento> ListarDepartamentos();
        TS_BEClienteCreditoOutput OBTENER_CLIENTE_CREDITO(TS_BEParametro parametros,string nrotarjeta);
        List<TS_BEPTarjeta> LISTA_TARJETA_PREFIJOS();
        List<TS_BEClienteLista> ListarClientesByName(string rscliente);
        List<TS_BEClienteLista> ListarClientesByPlaca(string placa);
    }
}
