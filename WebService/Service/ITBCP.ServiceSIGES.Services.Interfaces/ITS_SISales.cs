using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Articulo;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;

namespace ITBCP.ServiceSIGES.Services.Interfaces
{
    [ServiceContract]
    public interface ITS_SISales
    {
        //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
        //Metodo         : Loading
        //Creado por     : Teófilo Chambilla Aquino (27/02/2019)
        //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
        ///<summary>Permite recuperar datos de la Tabla =  [varios] </summary>
        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BESales Loading(TS_BELoadInput input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        List<TS_BECara> OBTENER_CARAS(string seriehd);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEClienteOutput ObtenerClientByRuc(TS_BEClienteSearch input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEClienteOutput ObternerClienteByCodigo(TS_BEClienteSearch input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEClienteOutput ObtenerClienteByTarjeta(TS_BEClienteSearch input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        List<TS_BEClienteLista> ListarClientes();

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        List<TS_BEClienteLista> ListarClientesByName(string rscliente);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        List<TS_BEClienteLista> ListarClientesByPlaca(string placa);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BESaldoclid ObtenerSaldoClientTarjeta(TS_BEClienteSearch input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BECabeceraOutPut ObtenerOpTransaccion(TS_BEOpTransInput input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BERetornoTransaccion GrabarTransaccion(List<TS_BEDetalleInput> cdetalle, TS_BECabeceraInput cCabecera, List<TS_BEPagoInput> cPago, TS_BEClienteInput cCliente, TS_BELoadInput cLoading, TS_BEGrabarConfig cConfiguracion);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BESaldos ValidaSaldos(TS_BEClienteSearch cCliente);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BECorrelativoOutput ObtenerCorrelativo(TS_BECorrelativoInput input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEArticuloOutput ObtenerListaArticulos(string cdgrupo02);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEArticuloOutput ListarArticuloPrecios(string glosa);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEMensaje ANULAR_DOCUMENTO(TS_BEDAnulaInput input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        List<TS_BENropos> LISTAR_NROPOS();

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEMensaje REGISTRAR_LADO(string nropos, string lado);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEMensaje ELIMINAR_LADO(string lado);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BELados OBTENER_LADOS();

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEArticuloOutput OBTENER_ARTICULOS_POR_PREFIJO(string prefijo);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        List<TS_BEPTarjeta> OBTENER_PREFIJOS_AFILIACION();

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEMensaje REGISTRAR_AFILIACION(TS_BEClienteInput cCliente, List<TS_BEArticulo> Articulos, TS_BETipoTarjetaRegistro Tipo);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEArticlePromotion VERIFICAR_PROMOCION(TS_BEPromotionInput input);
    }
}
