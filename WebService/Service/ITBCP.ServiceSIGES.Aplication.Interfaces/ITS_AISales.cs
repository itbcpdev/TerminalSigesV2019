using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;

namespace ITBCP.ServiceSIGES.Aplication.Interfaces
{
    public interface  ITS_AISales
    {
        //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
        //Metodo         : Loading
        //Creado por     : Teófilo Chambilla Aquino (27/02/2019)
        //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
        ///<summary>Permite recuperar datos de la Tabla =  [varios] </summary>
        ///   
        TS_BESaldoclid ObtenerSaldoClientTarjeta(TS_BEClienteSearch input);
        TS_BESales Loading(TS_BELoadInput input);
        TS_BEClienteOutput ObtenerClientByRuc(TS_BEClienteSearch input);
        TS_BEClienteOutput ObternerClienteByCodigo(TS_BEClienteSearch input);
        TS_BEClienteOutput ObtenerClienteByTarjeta(TS_BEClienteSearch input);
        List<TS_BEClienteLista> ListarClientes();
        TS_BECabeceraOutPut ObtenerOpTransaccion(TS_BEOpTransInput input);
        TS_BERetornoTransaccion GrabarTransaccion(List<TS_BEDetalleInput> cdetalle, TS_BECabeceraInput cCabecera, List<TS_BEPagoInput> cPago, TS_BEClienteInput cCliente, TS_BELoadInput cLoading, TS_BEGrabarConfig Configuracion);
        TS_BESaldos ValidaSaldos(TS_BEClienteSearch cCliente);
        TS_BECorrelativoOutput ObtenerCorrelativo(TS_BECorrelativoInput input);
        TS_BEMensaje ANULAR_DOCUMENTO(TS_BEDAnulaInput input);
        List<TS_BECara> OBTENER_CARAS(string seriehd);
        TS_BEMensaje REGISTRAR_AFILIACION(TS_BEClienteInput cCliente, List<TS_BEArticulo> Articulos, TS_BETipoTarjetaRegistro Tipo);

    }
}
