using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Include;
using TerminalSiges.Lib.Sales;

namespace TerminalSiges.Lib.Customer
{
    public class TSCustomerApp
    {
        public static TSCustomer CurrentResultado;
        public static string Ruc;
        public static string CdCliente;
        public static bool FlagSearch;
        public static bool FlagArticuloSearch;
        public static string afiliacionTarj;
        public static string respuesta;
        public static string prefijo;
        public static bool IsArticulo;

        public static TipoComprobate TipoComprobante;
        public static TS_BEClienteOutput ClientOuput;
        public static List<string> vTarjetasBloqueadas;
        public static List<string> vTarjetasBuscadas;
        public static List<string> vCodigoBloqueado;
        public static bool IsCanje;
        public static ObservableCollection<TS_BEClienteLista> vListClientes { get; set; }
        public static event ClientesObteneAll ClienteAlls;
        public delegate void ClientesObteneAll(TSCustomer respuesta);
        public static event ClienteObtenerByRucDelegado ClienteByRuc;
        public delegate void ClienteObtenerByRucDelegado(TSCustomer respuesta);
        public static event ClienteObtenerByTarjetaDelegado ClienteByTarjeta;
        public delegate void ClienteObtenerByTarjetaDelegado(TSCustomer respuesta);
        public static event ClientSearchDelegado ClientSearch;
        public delegate void ClientSearchDelegado(TSCustomer respuesta);
        public static event ClienteObtenerByCodigoDelegado ClienteByCodigo;
        public delegate void ClienteObtenerByCodigoDelegado(TSCustomer respuesta);

        public static async Task<CustomerEstado> LoadClientesAll()
        {
            CustomerEstado Respuesta = CustomerEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    _ListarClientesCompleted(cliente.ListarClientes());
                    Respuesta = CustomerEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = CustomerEstado.ErrorSistema;
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

        private static void _ListarClientesCompleted(TS_BEClienteLista[] Result)
        {
            if (Result == null)
            {
                ClienteAlls(new TSCustomer(CustomerEstado.ErrorSistema));
                return;
            }
            else
            {
                CurrentResultado = (new TSCustomer(CustomerEstado.InformacionObtenida, Result));
                ClienteAlls(CurrentResultado);
                return;
            }

        }

        public static async Task<CustomerEstado> LoadClientByName(string rscliente)
        {
            CustomerEstado Respuesta = CustomerEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    _ListarClientesByNameCompleted(cliente.ListarClientesByName((rscliente ?? "")));
                    Respuesta = CustomerEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = CustomerEstado.ErrorSistema;
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

        private static void _ListarClientesByNameCompleted(TS_BEClienteLista[] Result)
        {
            if (Result == null)
            {
                ClienteAlls(new TSCustomer(CustomerEstado.ErrorSistema));
                return;
            }

            else 
            {
                CurrentResultado = (new TSCustomer(CustomerEstado.InformacionObtenida, Result));
                ClienteAlls(CurrentResultado);
                return;
            }

        }

        public static async Task<CustomerEstado> LoadClientByPlaca(string placa)
        {
            CustomerEstado Respuesta = CustomerEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    _ListarClientesByPlacaCompleted(cliente.ListarClientesByPlaca(placa));
                    Respuesta = CustomerEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = CustomerEstado.ErrorSistema;
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

        private static void _ListarClientesByPlacaCompleted(TS_BEClienteLista[] Result)
        {
            if (Result == null)
            {
                ClienteAlls(new TSCustomer(CustomerEstado.ErrorSistema));
                return;
            }

            else
            {
                CurrentResultado = (new TSCustomer(CustomerEstado.InformacionObtenida, Result));
                ClienteAlls(CurrentResultado);
                return;
            }
        }

        public static async Task<CustomerEstado> ObtenerClienteByRuc()
        {
            CustomerEstado Respuesta = CustomerEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    TS_BEClienteSearch input = new TS_BEClienteSearch()
                    {
                        Codigo = Ruc,
                        NroTarjeta = "",
                        flagBusquedaSunat = true
                    };

                    _ObtenerClientByRucCompleted(cliente.ObtenerClientByRuc(input));
                    Respuesta = CustomerEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = CustomerEstado.ErrorSistema;
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
        
        private static void _ObtenerClientByRucCompleted(TS_BEClienteOutput Result)
        {
            if (Result == null)
            {
                ClientSearch(new TSCustomer(CustomerEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje == null && Result.Ok == false)
            {
                ClientSearch(new TSCustomer(CustomerEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje != null && Result.Ok == false)
            {
                CurrentResultado = new TSCustomer(CustomerEstado.InformacionNoObtenida, Result);
                ClientSearch(CurrentResultado);
                return;
            }
            if (Result.Ok == true)
            {
                CurrentResultado = new TSCustomer(CustomerEstado.InformacionObtenida, Result);
                ClientSearch(CurrentResultado);
                return;
            }
        }

        public static async Task<CustomerEstado> ObtenerClienteTarjeta()
        {
            CustomerEstado Respuesta = CustomerEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    TS_BEClienteSearch input = new TS_BEClienteSearch()
                    {
                        Codigo = Ruc
                    };

                    _ObtenerSaldoClientTarjetaCompleted(cliente.ObtenerClientByRuc(input));
                    Respuesta = CustomerEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = CustomerEstado.ErrorSistema;
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

        private static void _ObtenerSaldoClientTarjetaCompleted(TS_BEClienteOutput Result)
        {
            if (Result == null)
            {
                ClientSearch(new TSCustomer(CustomerEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje == null && Result.Ok == false)
            {
                ClientSearch(new TSCustomer(CustomerEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje != null && Result.Ok == false)
            {
                CurrentResultado = new TSCustomer(CustomerEstado.InformacionNoObtenida);
                ClientSearch(CurrentResultado);
                return;
            }
            if (Result.Ok == true)
            {
                CurrentResultado = new TSCustomer(CustomerEstado.InformacionObtenida,Result);
                ClientSearch(CurrentResultado);
                return;
            }
        }

        public static async Task<CustomerEstado> ObtenerClienteByCodigo()
        {
            CustomerEstado Respuesta = CustomerEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    TS_BEClienteSearch input = new TS_BEClienteSearch()
                    {
                        Codigo = CdCliente
                    };

                    _ObternerClienteByCodigoCompleted(cliente.ObternerClienteByCodigo(input));
                    Respuesta = CustomerEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = CustomerEstado.ErrorSistema;
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

        private static void _ObternerClienteByCodigoCompleted(TS_BEClienteOutput Result)
        {
            if (Result == null)
            {
                ClienteByCodigo(new TSCustomer(CustomerEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje == null && Result.Ok == false)
            {
                ClienteByCodigo(new TSCustomer(CustomerEstado.ErrorSistema));
                return;
            }
            if (Result.Ok == false)
            {
                ClienteByCodigo(new TSCustomer(CustomerEstado.ClienteSinSaldo, Result));

                return;
            }
            if (Result.Ok == true)
            {
                CurrentResultado = new TSCustomer(CustomerEstado.ClienteConSaldo, Result);
                ClienteByCodigo(CurrentResultado);
                return;
            }
        }

        public static async Task<CustomerEstado> ObtenerClienteByTarjeta()
        {
            CustomerEstado Respuesta = CustomerEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    TS_BEClienteSearch input = new TS_BEClienteSearch() 
                    {
                        Codigo = CdCliente,
                        NroTarjeta = afiliacionTarj,
                        PrefijoAfiliacion = prefijo ,
                        IsArticulo = IsArticulo
                };

                    _ObtenerClienteByTarjetaCompleted(cliente.ObtenerClienteByTarjeta(input));
                    Respuesta = CustomerEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = CustomerEstado.ErrorSistema;
                }
                finally
                {
                    if (cliente != null)
                    {
                        if (cliente.State == CommunicationState.Opened)
                        {
                            try
                            {
                                cliente.Close();
                            }
                            catch
                            {

                            }
                        }
                    }
                }
            });
            return Respuesta;
        }

        private static void _ObtenerClienteByTarjetaCompleted(TS_BEClienteOutput Result)
        {
            if (Result == null)
            {
                ClientSearch(new TSCustomer(CustomerEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje == null && Result.Ok == false)
            {
                ClientSearch(new TSCustomer(CustomerEstado.ErrorSistema));
                return;
            }
            if (Result.Ok == false)
            {
                ClientSearch(new TSCustomer(CustomerEstado.InformacionNoObtenida));

                return;
            }
            if (Result.Ok == true)
            {
                ClientSearch(new TSCustomer(CustomerEstado.InformacionObtenida, Result));
                return;
            }
        }

    }

}
