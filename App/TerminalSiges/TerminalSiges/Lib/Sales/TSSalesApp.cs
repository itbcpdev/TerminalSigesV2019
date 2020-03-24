using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Articulo;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using ITBCP.ServiceSIGES.Domain.Entities.Users;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Autenticate;
using TerminalSiges.Lib.Customer;
using TerminalSiges.Lib.Include;
using TerminalSiges.Services;
using TerminalSiges.ViewModels;

namespace TerminalSiges.Lib.Sales
{
    public class TSSalesApp
    {
        public static event SalesGrabarVentaDelegado SalesGrabarVenta;
        public delegate void SalesGrabarVentaDelegado(TSSales respuesta);

        public static event SalesOpTransaccionDelegado SalesDetalle;
        public delegate void SalesOpTransaccionDelegado(TSSales respuesta);

        public static event SalesObtenerArticulosDelegado SalesArticulos;
        public delegate void SalesObtenerArticulosDelegado(TSSales respuesta);

        public static event SalesObtenerCorrelativoDelegado SalesCorrelativo;
        public delegate void SalesObtenerCorrelativoDelegado(TSSales respuesta);


        public static event SalesEliminarDocumentosDelegado EliminarDocumentos;
        public delegate void SalesEliminarDocumentosDelegado(TSSales respuesta);

        public static event SalesObtenerNroPosDelegado ObtenerNroPOS;
        public delegate void SalesObtenerNroPosDelegado(TSSales respuesta);

        public static event SalesObtenerCarasDelegado SalesCaras;
        public delegate void SalesObtenerCarasDelegado(TSSales respuesta);

        public static event SalesRegistrarLadoDelegado RegistrarLado;
        public delegate void SalesRegistrarLadoDelegado(TSSales respuesta);

        public static event SalesEliminarLadoDelegado EliminarLado;
        public delegate void SalesEliminarLadoDelegado(TSSales respuesta);

        public static event SalesObtenerLadosDelegado ObtenerLados;
        public delegate void SalesObtenerLadosDelegado(TSSales respuesta);

        public static event SalesObtenerPrefijoAfiliacionDelegado ObtenerPrefijos;
        public delegate void SalesObtenerPrefijoAfiliacionDelegado(TSSales respuesta);

        public static event SalesObtenerArticulosPrefijoAfiliacionDelegado ObtenerArticulosPrefijos;
        public delegate void SalesObtenerArticulosPrefijoAfiliacionDelegado(TSSales respuesta);

        public static event SalesGrabarAfiliacionDelegado GrabarTransaccionPrefijos;
        public delegate void SalesGrabarAfiliacionDelegado(TSSales respuesta);

        public static TS_BEParametro vParemetros;
        public static TS_BETerminal vTerminal;
        public static TSSales CurrentResultado;
        public static TS_BEOpTransInput vOpTranInput;
        public static TS_BECabeceraInput vCabeceraInput;
        public static TS_BEVendedor vVendedor;
        public static TS_BECabecera vCabecera;
        public static TS_BEGrabarConfig vConfiguracion;
        public static TS_BEArticulo vArticuloInput;
        public static TS_BEUsers vUsuarioActual;
        public static BindingAutomatic AutomaticContext;
        //Input venta  .  . .
        public static TS_BEDetalleInput[] cDetalleInput;
        public static TS_BECabeceraInput cCabeceraInput;
        public static TS_BEPagoInput[] cPagoInput;
        public static TS_BEClienteInput cClienteInput;
        public static TS_BEDAnulaInput cDocAnulaInput;
        public static TS_BELoadInput cLoadingInput;
        public static TS_BECorrelativoInput cCorrelativoInput;
        public static TS_BEArticulo vArticuloSeleccionado;
        public static ObservableCollection<TS_BECara> vCaras { get; set; }
        public static ObservableCollection<TS_BEArticulo> Detalles { get; set; }
        public static ObservableCollection<TS_BEArticulo> DetallesDisplay { get; set; }
        public static ObservableCollection<TS_BEArticulo> vListArticulos { get; set; }
        public static ObservableCollection<TS_BETarjeta> vTarjetas { get; set; }
        public static ObservableCollection<TS_BETipopago> vTipoPagos { get; set; }
        public static ObservableCollection<TipoComprobate> vTipoDocuments { get; set; }

        public static string Ruc;
        public static string Codigo;
        public static string Tarjeta;
        public static string Cara;
        public static string CdCliente;
        public static string Serie;
        public static decimal TipoCambio;
        public static string Igv;
        public static string FechaServidor;
        public static int CantidadProducto;
        public static string Correlativo;
        public static string TipoVenta = "";
        public static string TipoDocumento;
        public static string NroPos;
        public static string CdUsuario;
        public static bool fact_electronica;
        public static string NroDocumento;
        public static string NroSerieMaq;
        public static bool FactElectronica;

        public static async Task<SalesEstado> ListNroPos()
        {
            SalesEstado Respuesta = SalesEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    _LISTAR_NROPOSCompleted(cliente.LISTAR_NROPOS());
                    Respuesta = SalesEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = SalesEstado.ErrorSistema;
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

        private static void _LISTAR_NROPOSCompleted(TS_BENropos[] Result)
        {
            if (Result == null)
            {
                ObtenerNroPOS(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            else
            {
                CurrentResultado = new TSSales(SalesEstado.InformacionObtenida, Result);
                ObtenerNroPOS(CurrentResultado);
                return;
            }

        }
       
        public static async Task<SalesEstado> ProcesarEliminarDocumento()
        {
            SalesEstado Respuesta = SalesEstado.ErrorSistema;

            await Task.Run(() => {

                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    TS_BEDAnulaInput input = new TS_BEDAnulaInput()
                    {
                        cdtipodoc = TipoDocumento,
                        cdusuario = TSLoginApp.UserName,
                        fact_electronica = FactElectronica,
                        nrodocumento = NroDocumento,
                        nropos = NroPos,
                        nroseriemaq = NroSerieMaq
                    };
                    _ANULAR_DOCUMENTOCompleted(cliente.ANULAR_DOCUMENTO(input));
                    Respuesta = SalesEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = SalesEstado.ErrorSistema;
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

        private static void _ANULAR_DOCUMENTOCompleted(TS_BEMensaje Result)
        {
            if (Result == null)
            {
                EliminarDocumentos(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result.mensaje == null && Result.Ok == false)
            {
                EliminarDocumentos(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result.mensaje != null && Result.Ok == false)
            {
                EliminarDocumentos(new TSSales(SalesEstado.RegistroNoEliminado));

                return;
            }
            if (Result.Ok == true)
            {
                EliminarDocumentos(new TSSales(SalesEstado.RegistroEliminado));
                return;
            }
        }

        public static SalesEstado ObtenerDocumentos()
        {
            return SalesEstado.Autorizacion;
        }

        public static async Task<SalesEstado> ObtenerCorrelativo()
        {
            SalesEstado Respuesta = SalesEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    TS_BECorrelativoInput input = new TS_BECorrelativoInput() { seriehd = TSLoginApp.Serie };
                    _ObtenerCorrelativoCompleted( cliente.ObtenerCorrelativo(input));
                    Respuesta = SalesEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = SalesEstado.ErrorSistema;
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
        private static void _ObtenerCorrelativoCompleted(TS_BECorrelativoOutput Result)
        {
            if (Result == null)
            {
                SalesCorrelativo(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje == null && Result.Ok == false)
            {
                SalesCorrelativo(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje != null && Result.Ok == false)
            {
                CurrentResultado = new TSSales(SalesEstado.InformacionNoObtenida, Result);
                SalesCorrelativo(CurrentResultado);
                return;
            }
            if (Result.Ok == true)
            {
                CurrentResultado = new TSSales(SalesEstado.InformacionObtenida, Result);
                SalesCorrelativo(CurrentResultado);
                return;
            }
        }
        public static async Task<SalesEstado> GrabarVenta(bool ConIgv,bool IsCanje,bool IsNoImprimir)
        {
            SalesEstado Respuesta = SalesEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    TSCustomerApp.IsCanje = IsCanje;
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    cDetalleInput = new TS_BEDetalleInput[] { };
                    cCabeceraInput = new TS_BECabeceraInput();
                    cClienteInput = new TS_BEClienteInput();
                    cCabeceraInput = TSSalesInput.InputcCabecera();
                    cClienteInput = TSSalesInput.InputcCliente();
                    cDetalleInput = TSSalesInput.Inputcdetalle(cCabeceraInput).ToArray();
                    cLoadingInput = new TS_BELoadInput();
                    cLoadingInput = TSSalesInput.LoadInput();
                    vConfiguracion = new TS_BEGrabarConfig() {IsNotPrint = IsNoImprimir };

                    if (ConIgv)
                    {
                        TSSalesInput.RecalcularIGV(cDetalleInput);
                    }

                    _GrabarTransaccionCompleted( cliente.GrabarTransaccion(cDetalleInput, cCabeceraInput, cPagoInput, cClienteInput, cLoadingInput, vConfiguracion));
                    Respuesta = SalesEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = SalesEstado.ErrorSistema;
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
        private static void _GrabarTransaccionCompleted(TS_BERetornoTransaccion Result)
        {

            if (Result == null)
            {
                SalesGrabarVenta(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje == null && Result.Ok == false)
            {
                SalesGrabarVenta(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje != null && Result.Ok == false)
            {
                SalesGrabarVenta(new TSSales(SalesEstado.VentaNoRegistrada, Result.Mensaje));

                return;
            }
            if (Result.Ok == true)
            {
                CurrentResultado = new TSSales(SalesEstado.VentaRegistrada, Result);
                SalesGrabarVenta(CurrentResultado);
                return;
            }
        }
        public static async Task<SalesEstado> ObtenerOpTransaccion()
        {
            SalesEstado Respuesta = SalesEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    TS_BEOpTransInput input = new TS_BEOpTransInput()
                    {
                        cara = Cara,
                        Serie = TSLoginApp.Serie,
                        cdcliente = TSCustomerApp.TipoComprobante.Nombre.Equals(TSSalesInput.NotaDeDespacho().Nombre) ? TSCustomerApp.ClientOuput.nroTarjeta : TSCustomerApp.ClientOuput.cdcliente,
                        tipocliente = "",
                        automatic = false
                    };

                    _ObtenerOpTransaccionCompleted(cliente.ObtenerOpTransaccion(input));
                    Respuesta = SalesEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = SalesEstado.ErrorSistema;
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
        private static void _ObtenerOpTransaccionCompleted(TS_BECabeceraOutPut Result)
        {

            if (Result == null)
            {
                SalesDetalle(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje == null && Result.Ok == false)
            {
                SalesDetalle(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje != null && Result.Ok == false)
            {
                CurrentResultado = new TSSales(SalesEstado.InformacionNoObtenida, Result);
                SalesDetalle(CurrentResultado);
                return;
            }
            if (Result.Ok == true)
            {
                CurrentResultado = new TSSales(SalesEstado.InformacionObtenida, Result);
                SalesDetalle(CurrentResultado);
                return;
            }
        }
        public static async Task<SalesEstado> ObtenerListaArticulos()
        {
            SalesEstado Respuesta = SalesEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    ObtenerListaArticulosCompleted(cliente.ObtenerListaArticulos(cdgrupo02: "00020"));
                    Respuesta = SalesEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = SalesEstado.ErrorSistema;
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
        private static void ObtenerListaArticulosCompleted(TS_BEArticuloOutput Result)
        {
            if (Result == null)
            {
                SalesArticulos(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje == null && Result.Ok == false)
            {
                SalesArticulos(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje != null && Result.Ok == false)
            {
                CurrentResultado = new TSSales(SalesEstado.InformacionNoObtenida);
                SalesArticulos(CurrentResultado);
                return;
            }
            if (Result.Ok == true)
            {
                SalesArticulos(CurrentResultado);
                return;
            }
        }

        public static async Task<SalesEstado> ObtenerCaras()
        {

            SalesEstado Respuesta = SalesEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    _OBTENER_CARASCompleted(cliente.OBTENER_CARAS(TSLoginApp.Serie));
                    Respuesta = SalesEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = SalesEstado.ErrorSistema;
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

        private static void _OBTENER_CARASCompleted(TS_BECara[] Result)
        {
            if (Result == null)
            {
                SalesCaras(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result != null)
            {
                SalesCaras(new TSSales(SalesEstado.InformacionObtenida, Result));
                return;
            }
        }

        public static async Task<SalesEstado> _RegistrarLado(string nropos, string lado)
        {
            SalesEstado Respuesta = SalesEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    _REGISTRAR_LADOCompleted( cliente.REGISTRAR_LADO(nropos, lado));
                    Respuesta = SalesEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = SalesEstado.ErrorSistema;
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

        private static void _REGISTRAR_LADOCompleted(TS_BEMensaje Result)
        {
            if (Result == null)
            {
                RegistrarLado(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result == null)
            {
                RegistrarLado(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result != null)
            {
                RegistrarLado(new TSSales(SalesEstado.InformacionObtenida, Result));
                return;
            }
        }

        public static async Task<SalesEstado> _EliminarLado(string lado)
        {
            SalesEstado Respuesta = SalesEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    _ELIMINAR_LADOCompleted(cliente.ELIMINAR_LADO(lado));
                    Respuesta = SalesEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = SalesEstado.ErrorSistema;
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

        private static void _ELIMINAR_LADOCompleted(TS_BEMensaje Result)
        {
            if (Result == null)
            {
                EliminarLado(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result == null)
            {
                EliminarLado(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result != null)
            {
                EliminarLado(new TSSales(SalesEstado.InformacionObtenida, Result));
                return;
            }
        }

        public static async Task<SalesEstado> _ObtenerLados()
        {
            SalesEstado Respuesta = SalesEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    _OBTENER_LADOSCompleted(cliente.OBTENER_LADOS());
                    Respuesta = SalesEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = SalesEstado.ErrorSistema;
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

        private static void _OBTENER_LADOSCompleted(TS_BELados Result)
        {
            if (Result == null)
            {
                ObtenerLados(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result == null)
            {
                ObtenerLados(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result != null)
            {
                ObtenerLados(new TSSales(SalesEstado.InformacionObtenida, Result));
                return;
            }

        }


        public static TS_BECabeceraOutPut SynchronizedGetOPTransaction(string cara, String cdcliente,bool automatic)
        {
            TS_BEOpTransInput Input = new TS_BEOpTransInput()
            {
                cara = cara,
                Serie = TSLoginApp.Serie,
                cdcliente = cdcliente,
                tipocliente = "",
                automatic = automatic
            };

            TS_SISalesClient client = null;
            try
            {
                client = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));

                return client.ObtenerOpTransaccion(Input);
            }
            catch (Exception exception)
            {
                if (client != null)
                {
                    if (client.State == CommunicationState.Opened)
                    {
                        client.Close();
                    }
                }

                return new TS_BECabeceraOutPut() { Mensaje = exception.Message, Ok = false };
            }
        }

        public static TS_BEMensaje SynchronizedSetSale(TerminalSIGES.Models.Lado Cara, TS_BEArticulo Transaccion)
        {
            TS_BELoadInput cLoadingInput = TSSalesInput.LoadInput();
            TS_BEClienteInput cClienteInput = TSSalesInput.InputClienteAutomaticMethod(Cara);
            TS_BECabeceraInput cCabeceraInput = TSSalesInput.InputCabeceraAutomaticMethod(Cara);
            TS_BEDetalleInput[] cDetalleInput = TSSalesInput.InputDetalleAutomaticMethod(Transaccion).ToArray();
            List<TS_BEPagoInput> vPagos = TSSalesInput.InputPagosAutomaticMethod(Cara, Transaccion);
            TS_BEGrabarConfig vConfiguracion = new TS_BEGrabarConfig() { IsNotPrint = Cara.IsImprimir };

            if (vPagos == null)
            {
                return new TS_BEMensaje() { mensaje = "EL MONTO TOTAL NO COINCIDE CON LOS PAGOS DE LA VENTA", Ok = false };
            }

            TS_BEPagoInput[] cPagoInput = vPagos.ToArray();

            TSSalesInput.InputMoneyAutomaticMethod(Cara, cCabeceraInput, cDetalleInput, cPagoInput);
            TS_SISalesClient client = null;
            try
            {
                client = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                TS_BERetornoTransaccion respuesta = client.GrabarTransaccion(cDetalleInput, cCabeceraInput, cPagoInput, cClienteInput, cLoadingInput, vConfiguracion);
                if (respuesta.Ok)
                {
                    return new TS_BEMensaje() { mensaje = respuesta.Codigo , Ok = true };
                }
                else
                {
                    return new TS_BEMensaje() { mensaje = respuesta.Mensaje, Ok = false };
                }
            }
            catch (Exception e)
            {
                if (client != null)
                {
                    if (client.State == CommunicationState.Opened)
                    {
                        client.Close();
                    }
                }
                return new TS_BEMensaje() { mensaje = e.Message, Ok = false };
            }
        }

        public static async Task<SalesEstado> _ObtenerPrefijos()
        {
            SalesEstado Respuesta = SalesEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    _ObtenerPrefijosCompleted(cliente.OBTENER_PREFIJOS_AFILIACION());
                    Respuesta = SalesEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = SalesEstado.ErrorSistema;
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

        private static void _ObtenerPrefijosCompleted(TS_BEPTarjeta[] Result)
        {
            if (Result == null)
            {
                ObtenerPrefijos(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result != null)
            {
                ObtenerPrefijos(new TSSales(SalesEstado.InformacionObtenida, Result));
                return;
            }

        }
        public static async Task<SalesEstado> _ObtenerArticulosPrefijos(string prefijo)
        {
            SalesEstado Respuesta = SalesEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    _ObtenerArticulosPrefijosCompleted(cliente.OBTENER_ARTICULOS_POR_PREFIJO(prefijo));
                    Respuesta = SalesEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = SalesEstado.ErrorSistema;
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

        private static void _ObtenerArticulosPrefijosCompleted(TS_BEArticuloOutput Result)
        {
            if (Result == null)
            {
                ObtenerArticulosPrefijos(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if(Result.Ok == false)
            {
                ObtenerArticulosPrefijos(new TSSales(SalesEstado.InformacionNoObtenida, new TS_BEMensaje() {mensaje = Result.Mensaje,Ok = Result.Ok }));
                return;
            }
            if (Result.Ok)
            {
                ObtenerArticulosPrefijos(new TSSales(SalesEstado.InformacionObtenida, Result));
                return;
            }

        }

        public static async Task<SalesEstado> GrabarTransaccionPrefijo(TS_BEClienteInput Cliente,List<TS_BEArticulo> Articulos, TS_BETipoTarjetaRegistro Tipo)
        {
            SalesEstado Respuesta = SalesEstado.ErrorSistema;
            await Task.Run(() => {
                TS_SISalesClient cliente = null;
                try
                {
                    cliente = new TS_SISalesClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Sales));
                    GrabarTransaccionPrefijoCompleted(cliente.REGISTRAR_AFILIACION(cCliente: Cliente, Articulos: Articulos.ToArray(), Tipo: Tipo));
                    Respuesta = SalesEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = SalesEstado.ErrorSistema;
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

        private static void GrabarTransaccionPrefijoCompleted(TS_BEMensaje Result)
        {
            if (Result == null)
            {
                GrabarTransaccionPrefijos(new TSSales(SalesEstado.ErrorSistema));
                return;
            }
            if (Result.Ok == false)
            {
                GrabarTransaccionPrefijos(new TSSales(SalesEstado.InformacionNoObtenida, new TS_BEMensaje() { mensaje = Result.mensaje, Ok = Result.Ok }));
                return;
            }
            if (Result.Ok)
            {
                GrabarTransaccionPrefijos(new TSSales(SalesEstado.InformacionObtenida, Result));
                return;
            }

        }
    }


}
