using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using TerminalSiges.Lib.Autenticate;
using TerminalSiges.Lib.Include;
using System.ServiceModel;
using TerminalSiges.Lib.Sales;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain.Entities.Articulo;

namespace TerminalSiges.Lib.Loading
{
    class TSLoadApp
    {

        public static TS_BELoadInput vLoading;
        public static TS_BEArticulo vArticuloInput;
        public static TSLoad CurrentResultado;
        public static TSSales CurrentResultadoSales;


        public static event LoadingDelegado SalesLoading;
        public delegate void LoadingDelegado(TSLoad respuesta);
        public static event SalesAuthorizeDelegado SalesAuthorize;
        public delegate void SalesAuthorizeDelegado(TSLoad respuesta);
        public static event ArticuloPrecioDelegado ArticuloPrecio;
        public delegate void ArticuloPrecioDelegado(TSSales respuesta);
        
        
        public static async Task<LoadEstado> Loading()
        {
            LoadEstado Respuesta = LoadEstado.ErrorSistema;
            await Task.Run(() => {
                TS_BELoadInput input = new TS_BELoadInput()
                {
                    Serie = TSLoginApp.Serie,
                    cdempresa = TSLoginApp.CurrentEmpresa.cdempresa,
                    cdnivel = TSLoginApp.CurrentEmpresa.cdnivel,
                    cdusuario = TSLoginApp.UserName
                };

                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    _LoadingCompleted(cliente.Loading(input));
                    Respuesta = LoadEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = LoadEstado.ErrorSistema;
                }
                finally
                {
                    if (cliente != null)
                    {
                        if (cliente.State == CommunicationState.Opened)
                        {
                            cliente.Close();
                        }
                    }
                }
            });
            return Respuesta;
        }

        public static async Task<LoadEstado> Loading(string cdempresa,string cdnivel,string cdusuario)
        {
            LoadEstado Respuesta = LoadEstado.ErrorSistema;
            await Task.Run(() => {
                TS_BELoadInput input = new TS_BELoadInput()
                {
                    Serie = TSLoginApp.Serie,
                    cdempresa = cdempresa,
                    cdnivel = cdnivel,
                    cdusuario = cdusuario
                };

                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    _LoadingCompleted(cliente.Loading(input));
                    Respuesta = LoadEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = LoadEstado.ErrorSistema;
                }
                finally
                {
                    if (cliente != null)
                    {
                        if (cliente.State == CommunicationState.Opened)
                        {
                            cliente.Close();
                        }
                    }
                }
            });
            return Respuesta;
        }

        private static void _LoadingCompleted(TS_BESales Result)
        {

            if (Result ==  null)
            {
                SalesLoading(new TSLoad(LoadEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje == null && Result.Ok == false)
            {
                SalesLoading(new TSLoad(LoadEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje != null && Result.Ok == false)
            {
                SalesLoading(new TSLoad(LoadEstado.InformacionNoObtenida, Result));
                return;
            }
            if (Result.Ok == true)
            {
                SalesLoading(new TSLoad(LoadEstado.InformacionObtenida, Result));
                return;
            }
        }

        public static async Task<LoadEstado> ListaProductoPrecio(string glosa)
        {
            LoadEstado Respuesta = LoadEstado.ErrorSistema;
            await Task.Run(() => {

                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    _ListarArticuloPreciosCompleted(cliente.ListarArticuloPrecios(glosa));
                    Respuesta = LoadEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = LoadEstado.ErrorSistema;
                }
                finally
                {
                    if (cliente != null)
                    {
                        if (cliente.State == CommunicationState.Opened)
                        {
                            cliente.Close();
                        }
                    }
                }
            });
            return Respuesta;
        }

        private static void _ListarArticuloPreciosCompleted(TS_BEArticuloOutput Result)
        {

            if (Result == null)
            {
                ArticuloPrecio(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            else
            {
                var list = Result.Articulos;
                ArticuloPrecio(new TSSales(SalesEstado.InformacionObtenida, list));
                return;
            }
        }
    }
}
