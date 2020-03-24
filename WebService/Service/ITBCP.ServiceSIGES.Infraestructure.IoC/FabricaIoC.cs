using ITBCP.ServiceSIGES.Aplication;
using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Infraestructure.DataAcces;
using ITBCP.ServiceSIGES.Infraestructure.DataAcces.FacturacionE;
using Microsoft.Practices.Unity;

namespace ITBCP.ServiceSIGES.Infraestructure.IoC
{
    public class FabricaIoC
    {
        private static readonly FabricaIoC _contenedor = new FabricaIoC();
        private readonly IUnityContainer _unityContainer;
        private FabricaIoC()
        {
            _unityContainer = new UnityContainer();
            // Registrar los tipos utilizados en la aplicacion.
            // Especificamente con una nueva tecnologia de acceso a datos.
            #region Cliente
             _unityContainer.RegisterType<ITS_DOCliente, TS_DACliente>();
            _unityContainer.RegisterType<ITS_AICliente, TS_APCliente>();
            #endregion
            #region Parameters
            _unityContainer.RegisterType<ITS_DOParametro, TS_DAParametros>();
            _unityContainer.RegisterType<ITS_AIParametro, TS_APParametro>();
            _unityContainer.RegisterType<ITS_AIUtilities, TS_APUtilities>();
            #endregion
            #region Autentication
            _unityContainer.RegisterType<ITS_DOAutentication , TS_DAAutentication>();
            _unityContainer.RegisterType<ITS_AIAutentication , TS_APAutentication>();

            _unityContainer.RegisterType<ITS_DOTerminal, TS_DATerminal>();
            //_unityContainer.RegisterType<ITS_AITerminal, TS_APTerminal>();


            #endregion
            #region Sales
            _unityContainer.RegisterType<ITS_AIArticulo, TS_APArticulo>();
            _unityContainer.RegisterType<ITS_DOArticulo, TS_DAArticulo>();
            _unityContainer.RegisterType<ITS_DOTarjeta, TS_DATarjeta>();
            _unityContainer.RegisterType<ITS_DOOpTransaction, TS_DAOpTransaction>();
            _unityContainer.RegisterType<ITS_DOOpTransaction, TS_DAOpTransaction>();
            _unityContainer.RegisterType<ITS_DOCierre, TS_DACierre>();
            _unityContainer.RegisterType<ITS_AICierre, TS_APCierre>();
            // _unityContainer.RegisterType<ITS_DOSales, TS_DASales>();
            _unityContainer.RegisterType<ITS_AISales, TS_APSales>();

            _unityContainer.RegisterType<ITS_DOTerminal, TS_DATerminal>();
            // _unityContainer.RegisterType<ITS_AITerminal, TS_APTerminal>();
              _unityContainer.RegisterType<ITS_DOCara, TS_DACara>();
            //_unityContainer.RegisterType<ITS_AICara, TS_APCara>();

            _unityContainer.RegisterType<ITS_DOIgv, TS_DAIgv>();
            //           _unityContainer.RegisterType<ITS_AIIgv, TS_APIgv>();

            _unityContainer.RegisterType<ITS_DOMoneda, TS_DAMoneda>();
            //_unityContainer.RegisterType<ITS_AIMoneda, TS_APMoneda>();

            _unityContainer.RegisterType<ITS_DOServer, TS_DAServer>();
            //_unityContainer.RegisterType<ITS_AIServer, TS_APServer>();

            _unityContainer.RegisterType<ITS_DOTarjeta, TS_DATarjeta>();
            _unityContainer.RegisterType<ITS_AITarjeta, TS_APTarjeta>();

            _unityContainer.RegisterType<ITS_DOTipoCambio, TS_DATipoCambio>();
            _unityContainer.RegisterType<ITS_AITipoCambio, TS_APTipoCambio>();

            _unityContainer.RegisterType<ITS_DOTipoPago, TS_DATipoPago>();
            _unityContainer.RegisterType<ITS_AITipoPago, TS_APTipoPago>();

            _unityContainer.RegisterType<ITS_DOVendedor, TS_DAVendedor>();
            //            _unityContainer.RegisterType<ITS_AIVendedor, TS_APVendedor>();
            _unityContainer.RegisterType<ITS_DOCabeceraVenta, TS_DACabeceraVenta>();
            _unityContainer.RegisterType<ITS_DOPagoVenta, TS_DAPagoVenta>();
            _unityContainer.RegisterType<ITS_DODetalleVenta, TS_DADetalleVenta>();
            _unityContainer.RegisterType<ITS_DOStock, TS_DAStock>();
            _unityContainer.RegisterType<ITS_DOHvale, TS_DAHvale>();
            _unityContainer.RegisterType<ITS_DOCredclienteVenta, TS_DACredclienteVenta>();
            _unityContainer.RegisterType<ITS_DOGrabarTransaccion, TS_DAGrabarTransaccion>();
            _unityContainer.RegisterType<ITS_DOEmisor, TS_DAEmisor>();
            _unityContainer.RegisterType<ITS_DOColaImpresion, TS_DAColaImpresion>();
            #endregion
            #region BackOffice
            _unityContainer.RegisterType<ITS_DOBackOffice, TS_DABackOffice>();
            _unityContainer.RegisterType<ITS_AIBackOffice, TS_APBackOffice>();
            #endregion
            #region BackOffice
            _unityContainer.RegisterType<ITS_DOBackOffice, TS_DABackOffice>();
            _unityContainer.RegisterType<ITS_AIBackOffice, TS_APBackOffice>();
            #endregion
            #region Reimpresion
            _unityContainer.RegisterType<ITS_AIImpresion, TS_APImpresion>();
            _unityContainer.RegisterType<ITS_DOReimpresion, TS_DAReimpresion>();
            _unityContainer.RegisterType<ITS_DOTurno, TS_DATurno>();
            _unityContainer.RegisterType<ITS_DOInicioDia, TS_DAInicioDia>();
            _unityContainer.RegisterType<ITS_DOXCierre, TS_DAXCierre>();
            _unityContainer.RegisterType<ITS_DOZCierre, TS_DAZCierre>();
            #endregion
            #region FacturacionElectronica
            _unityContainer.RegisterType<ITS_AIFacturacionE, TS_APFacturacionE>();
            _unityContainer.RegisterType<ITS_DOAceptaFE, TS_DAAcepta>();
            #endregion
            #region Correlativo
            _unityContainer.RegisterType<ITS_DOCorrelativo, TS_DACorrelativo>();
            #endregion
            #region Depositos
            _unityContainer.RegisterType<ITS_DODeposito, TS_DADeposito>();
            #endregion
            #region AcumulacionPuntosAfiliacion
            _unityContainer.RegisterType<ITS_DOAfiliacionTarjeta, TS_DAAfiliacionTarjeta>();
            #endregion
            #region Lados
            _unityContainer.RegisterType<ITS_AILados, TS_APLados>();
            _unityContainer.RegisterType<ITS_DOLados, TS_DALados>();
            #endregion
        }
        public static FabricaIoC Contenedor
        {
            get { return _contenedor; }
        }
        /// <summary>
        ///   Crear una instancia de un objeto que implemente un tipo TServicio.
        /// </summary>
        /// <typeparam name = "TServicio">Tipo de servicio que deseamos resolver</typeparam>
        /// <returns></returns>
        public TServicio Resolver<TServicio>() where TServicio : class
        {
            return _unityContainer.Resolve<TServicio>();
        }
    }
}
