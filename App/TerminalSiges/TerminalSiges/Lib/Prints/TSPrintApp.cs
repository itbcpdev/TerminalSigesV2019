using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cierrres;
using ITBCP.ServiceSIGES.Domain.Entities.Reimpresion;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Autenticate;
using TerminalSiges.Lib.Include;
using TerminalSiges.Lib.Sales;

namespace TerminalSiges.Lib.Prints
{
    public class TSPrintApp
    {
        public static event SalesImprimirCierreXDelegado ImprimirCierreX;
        public delegate void SalesImprimirCierreXDelegado(TSPrint respuesta);

        public static event SalesImprimirCierreZDelegado ImprimirCierreZ;
        public delegate void SalesImprimirCierreZDelegado(TSPrint respuesta);

        public static event SalesObtenerCierreXDelegado ObtenerCierreX;
        public delegate void SalesObtenerCierreXDelegado(TSPrint respuesta);

        public static event SalesObtenerCierreZDelegado ObtenerCierreZ;
        public delegate void SalesObtenerCierreZDelegado(TSPrint respuesta);

        public static event SalesCambioTurnoDelegado ObtenerCambioTurno;
        public delegate void SalesCambioTurnoDelegado(TSPrint respuesta);

        public static event SalesInicioDiaDelegado ObtenerInicioDia;
        public delegate void SalesInicioDiaDelegado(TSPrint respuesta);

        public static event SalesObtenerDepositoDelegado ObtenerDepositos;
        public delegate void SalesObtenerDepositoDelegado(TSPrint respuesta);
        public static event SalesRegistraDepositoDelegado RegistraDepositos;
        public delegate void SalesRegistraDepositoDelegado(TSPrint respuesta);

        public static event SalesEliminaDepositoDelegado EliminaDepositos;
        public delegate void SalesEliminaDepositoDelegado(TSPrint respuesta);

        public static event SalesObtenerGriferoDelegado ObtenerGrifero;
        public delegate void SalesObtenerGriferoDelegado(TSPrint respuesta);

        public static event SalesRegistraGriferoCaraDelegado RegistraGriferoCara;
        public delegate void SalesRegistraGriferoCaraDelegado(TSPrint respuesta);

        public static event SalesObtenerGriferoCaraDelegado ObtenerGriferoCara;
        public delegate void SalesObtenerGriferoCaraDelegado(TSPrint respuesta);

        public static event SalesEliminaGriferoCaraDelegado EliminarGriferoCara;
        public delegate void SalesEliminaGriferoCaraDelegado(TSPrint respuesta);

        public static event SalesObtenerDocumentosDelegado ListarDocumentos;
        public delegate void SalesObtenerDocumentosDelegado(TSPrint respuesta);

        public static event SalesReimpresionDocumentosDelegado ReimprimirDocumentos;
        public delegate void SalesReimpresionDocumentosDelegado(TSPrint respuesta);

        public static event SalesUltimoDocumentosDelegado UltimoDocumento;
        public delegate void SalesUltimoDocumentosDelegado(TSPrint respuesta);

        public static event SalesVentasPendientesDelegado VentasPendientes;
        public delegate void SalesVentasPendientesDelegado(bool respuesta);

        public static TSPrint CurrentResultado;

        public static bool CTurnoEnviar;
        public static bool CTurnoOmitirBloquePlaya;
        public static string NroSerie;
        public static string CdUsuario;
        public static string NroPos;
        public static string CdVendedor;
        public static string Lado;
        public static string Nrodocumento;
        public static string Cdtipodoc;
        public static string cdtppago;
        public static string turno;
        public static string nroDeposito;
        public static decimal mtodolares;
        public static decimal mtosoles;
        public static int nrosobres;
        public static string cdempresa;
        public static bool ig_bloque_playa = false;
        public static bool imprimir = false;
        public static string NroSerieMaq;
        public static string fecha;
        public static bool TurnoAnterior = false;



        public static async Task<PrintEstado> ProcesaReImprimirDocumento()
        {
            PrintEstado Respuesta = PrintEstado.ErrorSistema;
            await Task.Run(() => {
                TS_BEDocumentoInput input = new TS_BEDocumentoInput()
                {
                    cdtipodoc = Cdtipodoc,
                    nrodocumento = Nrodocumento,
                    nropos = NroPos,
                    nroseriemaq = NroSerieMaq,
                    imprimir = imprimir,
                    fecha = fecha
                };

                TS_SIImpresionClient cliente = null;
                try
                {
                    cliente = new TS_SIImpresionClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Impresion));
                    _OBTENER_DOCUMENTO_IMPRESOCompleted(cliente.OBTENER_DOCUMENTO_IMPRESO(input));
                    Respuesta = PrintEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = PrintEstado.ErrorSistema;
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

        private static void _OBTENER_DOCUMENTO_IMPRESOCompleted(TS_BEMensaje Result)
        {
            if (Result == null)
            {
                ReimprimirDocumentos(new TSPrint(PrintEstado.ErrorSistema));
                return;
            }
            if (Result.mensaje == null && Result.Ok == false)
            {
                ReimprimirDocumentos(new TSPrint(PrintEstado.ErrorSistema));
                return;
            }
            if (Result.mensaje != null && Result.Ok == false)
            {
                ReimprimirDocumentos(new TSPrint(PrintEstado.ImpresionIncorrecto));

                return;
            }
            if (Result.Ok == true)
            {
                ReimprimirDocumentos(new TSPrint(PrintEstado.ImpresionCorrecto));
                return;
            }
        }

        public static async Task<PrintEstado> ProcesaReImpresionUltimoDocumento()
        {
            PrintEstado Respuesta = PrintEstado.ErrorSistema;
            await Task.Run(() => {
                TS_BEUltimoDocumentoInput input = new TS_BEUltimoDocumentoInput()
                {
                    nropos = NroPos,
                    imprimir = true
                };

                TS_SIImpresionClient cliente = null;
                try
                {
                    cliente = new TS_SIImpresionClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Impresion));
                    _OBTENER_ULTIMO_DOCUMENTO_IMPRESOCompleted(cliente.OBTENER_ULTIMO_DOCUMENTO_IMPRESO(input));
                    Respuesta = PrintEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = PrintEstado.ErrorSistema;
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

        private static void _OBTENER_ULTIMO_DOCUMENTO_IMPRESOCompleted(TS_BEMensaje Result)
        {
            if (Result == null)
            {
                UltimoDocumento(new TSPrint(PrintEstado.ErrorSistema));
                return;
            }
            if (Result.mensaje == null && Result.Ok == false)
            {
                UltimoDocumento(new TSPrint(PrintEstado.ErrorSistema));
                return;
            }
            if (Result.mensaje != null && Result.Ok == false)
            {
                UltimoDocumento(new TSPrint(PrintEstado.ImpresionIncorrecto));

                return;
            }
            if (Result.Ok == true)
            {
                UltimoDocumento(new TSPrint(PrintEstado.ImpresionCorrecto));
                return;
            }
        }

        public static async Task<PrintEstado> ObtenerListarDocumentos()
        {
            PrintEstado Respuesta = PrintEstado.ErrorSistema;
            await Task.Run(()=> {
                TS_BEReimpresionLInput input = new TS_BEReimpresionLInput()
                {
                    nropos = NroPos,
                    nrodocumento = Nrodocumento,
                    cdtipodoc = Cdtipodoc
                };

                TS_SIImpresionClient cliente = null;
                try
                {
                    cliente = new TS_SIImpresionClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Impresion));
                    _LISTAR_DOCUMENTOS_REIMPRESIONCompleted(cliente.LISTAR_DOCUMENTOS_REIMPRESION(input));
                    Respuesta = PrintEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respuesta = PrintEstado.ErrorSistema;
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

        private static void _LISTAR_DOCUMENTOS_REIMPRESIONCompleted(TS_BEReimpresionLOutput Result)
        {
            if (Result == null)
            {
                ListarDocumentos(new TSPrint(PrintEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje.Ok == true)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionObtenida, Result);
                ListarDocumentos(CurrentResultado);
                return;
            }

            if (Result.Mensaje.Ok == false)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionNoObtenida, Result);
                ListarDocumentos(CurrentResultado);
                return;
            }
        }

        public static async Task<PrintEstado> ProcesaEliminarGriferoCara()
        {
            PrintEstado Respueta = PrintEstado.ErrorSistema;
            await Task.Run(() => {

                TS_BELadoEInput input = new TS_BELadoEInput()
                {
                    lado = Lado,
                    nropos = NroPos
                };

                TS_SIImpresionClient cliente = null;
                try
                {
                    cliente = new TS_SIImpresionClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Impresion));
                    _ELIMINAR_GRIFERO_LADOSCompleted(cliente.ELIMINAR_GRIFERO_LADOS(input));
                    Respueta = PrintEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respueta=  PrintEstado.ErrorSistema;
                }
                finally
                {
                    if(cliente != null)
                    {
                        if (cliente.State == CommunicationState.Opened)
                        {
                            cliente.Close();
                        }
                    }
                }
            });
            return Respueta;
        }

        private static void _ELIMINAR_GRIFERO_LADOSCompleted(TS_BEMensaje Result)
        {
            if (Result == null)
            {
                EliminarGriferoCara(new TSPrint(PrintEstado.ErrorSistema));
                return;
            }
            if (Result.Ok == true)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionObtenida);
                EliminarGriferoCara(CurrentResultado);
                return;
            }

            if (Result.Ok == false)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionNoObtenida, Result);
                EliminarGriferoCara(CurrentResultado);
                return;
            }
        }

        public static async Task<PrintEstado> ProcesaEliminarDeposito()
        {
            PrintEstado Respueta = PrintEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TS_BEDepositoEInput input = new TS_BEDepositoEInput()
                {
                    nrodeposito = nroDeposito,
                    turno = turno,
                    nropos = NroPos,
                };

                TS_SIImpresionClient cliente = null;
                try
                {
                    cliente = new TS_SIImpresionClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Impresion));
                    _ELIMINAR_DEPOSITOCompleted(cliente.ELIMINAR_DEPOSITO(input));
                    Respueta = PrintEstado.EsperandoRespuesta;
                }
                catch
                {
                  
                    Respueta =  PrintEstado.ErrorSistema;
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
            return Respueta;
        }

        private static void _ELIMINAR_DEPOSITOCompleted(TS_BEMensaje Result)
        {
            if (Result == null)
            {
                EliminaDepositos(new TSPrint(PrintEstado.ErrorSistema));
                return;
            }
            if (Result.Ok == true)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionObtenida);
                EliminaDepositos(CurrentResultado);
                return;
            }

            if (Result.Ok == false)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionNoObtenida, Result);
                EliminaDepositos(CurrentResultado);
                return;
            }
        }

        public static async Task<PrintEstado> ReporteGriferoCara()
        {
            PrintEstado Respueta = PrintEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TS_SIImpresionClient cliente = null;
                try
                {
                    cliente = new TS_SIImpresionClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Impresion));
                    _OBTENER_GRIFERO_LADOSCompleted( cliente.OBTENER_GRIFERO_LADOS((TSSalesApp.vTerminal.nropos ?? "")));
                    Respueta = PrintEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respueta = PrintEstado.ErrorSistema;
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
            return Respueta;
        }

        private static void _OBTENER_GRIFERO_LADOSCompleted(TS_BELados Result)
        {
            if (Result == null)
            {
                ObtenerGriferoCara(new TSPrint(PrintEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje.Ok == true)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionObtenida, Result);
                ObtenerGriferoCara(CurrentResultado);
                return;
            }

            if (Result.Mensaje.Ok == false)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionNoObtenida, Result);
                ObtenerGriferoCara(CurrentResultado);
                return;
            }
        }

        public static async Task< PrintEstado> ProcesaRegistraGriferoCara()
        {
            PrintEstado Respueta = PrintEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TS_BELado input = new TS_BELado()
                {
                    cdvendedor = CdVendedor,
                    lado = Lado,
                    nropos = NroPos
                };

                TS_SIImpresionClient cliente = null;
                try
                {
                    cliente = new TS_SIImpresionClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Impresion));
                    _REGISTRAR_GRIFERO_LADOSCompleted(cliente.REGISTRAR_GRIFERO_LADOS(input));
                    Respueta = PrintEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respueta = PrintEstado.ErrorSistema;
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
            return Respueta;
        }

        private static void _REGISTRAR_GRIFERO_LADOSCompleted(TS_BEMensaje Result)
        {
            if (Result == null)
            {
                RegistraGriferoCara(new TSPrint(PrintEstado.ErrorSistema));
                return;
            }
            if (Result.Ok == true)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionObtenida);
                RegistraGriferoCara(CurrentResultado);
                return;
            }

            if (Result.Ok == false)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionNoObtenida, Result);
                RegistraGriferoCara(CurrentResultado);
                return;
            }
        }

        public static async Task<PrintEstado> ReporteGrifero()
        {
            PrintEstado Respueta = PrintEstado.ErrorSistema;
            await Task.Run(() =>
            {

                TS_SIImpresionClient cliente = null;
                try
                {
                    cliente = new TS_SIImpresionClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Impresion));
                    _OBTENER_VENDEDORESCompleted(cliente.OBTENER_VENDEDORES((TSLoginApp.CurrentEmpresa.cdempresa ?? "")));
                    Respueta = PrintEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respueta = PrintEstado.ErrorSistema;
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
            return Respueta;
        }

        private static void _OBTENER_VENDEDORESCompleted(TS_BEVendedores Result)
        {
            if (Result == null)
            {
                ObtenerGrifero(new TSPrint(PrintEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje.Ok == true)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionObtenida, Result);
                ObtenerGrifero(CurrentResultado);
                return;
            }

            if (Result.Mensaje.Ok == false)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionNoObtenida, Result);
                ObtenerGrifero(CurrentResultado);
                return;
            }
        }

        public static async Task<PrintEstado> ProcesaRegistra()
        {
            PrintEstado Respueta = PrintEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TS_BEDepositoInput input = new TS_BEDepositoInput()
                {
                    cdtppago = cdtppago,
                    mtodolares = mtodolares,
                    mtosoles = mtosoles,
                    nrosobres = nrosobres,
                    cdvendedor = TSLoginApp.UserNameVenderdor,
                    nropos = TSSalesApp.vTerminal.nropos,
                    turno_anterior = TurnoAnterior
                };

                TS_SIImpresionClient cliente = null;
                try
                {
                    cliente =new TS_SIImpresionClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Impresion));
                    _REGISTRAR_DEPOSITOCompleted(cliente.REGISTRAR_DEPOSITO(input));
                    Respueta = PrintEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respueta = PrintEstado.ErrorSistema;
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
            return Respueta;
        }

        private static void _REGISTRAR_DEPOSITOCompleted(TS_BEMensaje Result)
        {
            if (Result == null)
            {
                RegistraDepositos(new TSPrint(PrintEstado.ErrorSistema));
                return;
            }
            if (Result.Ok == true)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionObtenida);
                RegistraDepositos(CurrentResultado);
                return;
            }

            if (Result.Ok == false)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionNoObtenida, Result);
                RegistraDepositos(CurrentResultado);
                return;
            }
        }

        public static async Task<PrintEstado> ObtenerReporteDepositos()
        {
            PrintEstado Respueta = PrintEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TS_SIImpresionClient cliente = null;
                try
                {
                    cliente = new TS_SIImpresionClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Impresion));
                    _CONSULTAR_DEPOSITOSCompleted(cliente.CONSULTAR_DEPOSITOS((TSSalesApp.vTerminal.nropos ?? ""), (TSLoginApp.UserNameVenderdor ?? "")));
                    Respueta = PrintEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respueta = PrintEstado.ErrorSistema;
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
            return Respueta;
        }

        private static void _CONSULTAR_DEPOSITOSCompleted(TS_BEDepositos Result)
        {
            if (Result == null)
            {
                ObtenerDepositos(new TSPrint(PrintEstado.ErrorSistema));
                return;
            }
            if (Result.cMensaje.Ok == false)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionNoObtenida, Result);
                ObtenerDepositos(CurrentResultado);
                return;
            }
            if (Result.cMensaje.Ok == true)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionObtenida, Result);
                ObtenerDepositos(CurrentResultado);
                return;
            }
        }

        public static async Task<PrintEstado> ProcesaCambioTurno()
        {
            PrintEstado Respueta = PrintEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TS_SIImpresionClient cliente = null;
                try
                {
                    cliente = new TS_SIImpresionClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Impresion));
                    _OBTENER_CAMBIO_TURNOCompleted(cliente.OBTENER_CAMBIO_TURNO(true, false));
                    Respueta = PrintEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respueta = PrintEstado.ErrorSistema;
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
            return Respueta;
        }

        private static void _OBTENER_CAMBIO_TURNOCompleted(TS_BEMensaje Result)
        {
            if (Result == null)
            {
                ObtenerCambioTurno(new TSPrint(PrintEstado.ErrorSistema));
                return;
            }
            if (Result.Ok == true)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionObtenida);
                ObtenerCambioTurno(CurrentResultado);
                return;
            }

            if (Result.Ok == false)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionNoObtenida, Result);
                ObtenerCambioTurno(CurrentResultado);
                return;
            }

        }

        public static async Task<PrintEstado> ProcesaIncioDia(string cdusuario)
        {
            PrintEstado Respueta = PrintEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TS_SIImpresionClient cliente = null;
                try
                {
                    cliente = new TS_SIImpresionClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Impresion));
                    _OBTENER_INICIO_DIACompleted(cliente.OBTENER_INICIO_DIA((TSLoginApp.Serie ?? ""), (cdusuario ?? "")));
                    Respueta = PrintEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respueta = PrintEstado.ErrorSistema;
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
            return Respueta;
        }

        private static void _OBTENER_INICIO_DIACompleted(TS_BEInicioDiaOutput Result)
        {
            if (Result == null)
            {
                ObtenerInicioDia(new TSPrint(PrintEstado.ErrorSistema));
                return;
            }
            if (Result.Mensaje == null)
            {
                CurrentResultado = new TSPrint(PrintEstado.ErrorSistema);
                ObtenerInicioDia(CurrentResultado);
                return;
            }

            if (Result.Mensaje != null)
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionObtenida, Result);
                ObtenerInicioDia(CurrentResultado);
                return;
            }
        }

        public static async Task<PrintEstado> ObtenerReporteCierreZ()
        {
            PrintEstado Respueta = PrintEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TS_BEZCierreInput input = new TS_BEZCierreInput()
                {
                    ignorar_bloqueo_playa = ig_bloque_playa,
                    imprimir = imprimir,
                    nropos = TSSalesApp.vTerminal.nropos,
                    usuario = TSLoginApp.UserFull,
                };

                TS_SIImpresionClient cliente = null;
                try
                {
                    cliente = new TS_SIImpresionClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Impresion));
                    _OBTENER_CIERRE_ZCompleted(cliente.OBTENER_CIERRE_Z(input));
                    Respueta = PrintEstado.EsperandoRespuesta;
                }
                catch
                {
                    Respueta = PrintEstado.ErrorSistema;
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
            return Respueta;
        }

        private static void _OBTENER_CIERRE_ZCompleted(TS_BERespuesta Result)
        {
            if (Result == null)
            {
                ObtenerCierreZ(new TSPrint(PrintEstado.ErrorSistema));
                return;
            }
            if (Result.respuesta == "OK")
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionObtenida, Result);
                ObtenerCierreZ(CurrentResultado);
                return;
            }
            if (Result.respuesta != "OK")
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionNoObtenida, Result);
                ObtenerCierreZ(CurrentResultado);
                return;
            }
        }

        public static async Task<PrintEstado> ObtenerReporteCierreX()
        {
            PrintEstado Respueta = PrintEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TS_BEXCierreInput input = new TS_BEXCierreInput()
                {
                    ignorar_bloqueo_playa = ig_bloque_playa,
                    imprimir = imprimir,
                    nropos = TSSalesApp.vTerminal.nropos,
                    usuario = TSLoginApp.UserFull
                };

                TS_SIImpresionClient cliente = null;
                try
                {
                    cliente = new TS_SIImpresionClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Impresion));
                    _OBTENER_CIERRE_XCompleted(cliente.OBTENER_CIERRE_X(input));
                    Respueta = PrintEstado.EsperandoRespuesta;
                }
                catch(Exception ex)
                {
                    Respueta = PrintEstado.ErrorSistema;
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
            return Respueta;
        }

        private static void _OBTENER_CIERRE_XCompleted(TS_BERespuesta Result)
        {
            if (Result == null)
            {
                ObtenerCierreX(new TSPrint(PrintEstado.ErrorSistema));
                return;
            }
            if (Result.respuesta == "OK")
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionObtenida, Result);
                ObtenerCierreX(CurrentResultado);
                return;
            }
            if (Result.respuesta != "OK")
            {
                CurrentResultado = new TSPrint(PrintEstado.InformacionNoObtenida, Result);
                ObtenerCierreX(CurrentResultado);
                return;
            }
        }


        public static async Task<bool> ObtenerVentasPendientes()
        {
            bool Respueta = false;
            await Task.Run(() =>
            {

                TS_SIImpresionClient cliente = null;
                try
                {
                    cliente = new TS_SIImpresionClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Impresion));
                    Respueta = cliente.OBTENER_VENTAS_PENDIENTES_POR_TERMINAL_SEMI_AUTOMATIC(TSSalesApp.vTerminal.nropos);
                }
                catch (Exception ex)
                {
                    Respueta = false;
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
            return Respueta;
        }
    }
}

