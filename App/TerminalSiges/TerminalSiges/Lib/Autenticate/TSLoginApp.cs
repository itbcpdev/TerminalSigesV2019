using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Include;

namespace TerminalSiges.Lib.Autenticate
{

    public class TSLoginApp
    {

        public static string Serie;
        public static string UserName;
        public static string NroPos;
        public static string Password;
        public static string UserNameVenderdor;
        public static string PasswordVenderdor;
        public static string UserFull;
        public static TSLogin CurrentResultado;

        public static TS_BEEmpresaUser CurrentEmpresa { get; internal set; }
        public static event LoginAuthorizeDelegado LoginAuthorize;
        public static event LoginDepositoDelegado DepositoAuthorize;
        public static event LoginConfigCaraDelegado ConfigCaraAuthorize;
        public static event LoginCambioTurnoDelegado LoginCambioTurno;
        public static event LoginConfiguracionLadoDelegado LogiConfiguracionLado;

        public delegate void LoginConfiguracionLadoDelegado(TSLogin respuesta);
        public delegate void LoginAuthorizeDelegado(TSLogin respuesta);
        public delegate void LoginDepositoDelegado(TSLogin respuesta);
        public delegate void LoginConfigCaraDelegado(TSLogin respuesta);
        public delegate void LoginCambioTurnoDelegado(TSLogin respuesta);

        public static async Task<LoginEstado> Authorize()
        {
            LoginEstado Respuesta = LoginEstado.ErrorSistema;

            await Task.Run(() => {
                TS_SIAutenticationClient cliente = null;
                TS_BELogin  input = new TS_BELogin()
                {
                    cdusuario = UserName,
                    password = Password
                };
                try
                {
                    cliente = new TS_SIAutenticationClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Autenticate));
                    _LoginCompleted(cliente.Login(input));
                    Respuesta = LoginEstado.EsperandoRespuesta;
                    
                }
                catch
                {
                    Respuesta = LoginEstado.ErrorSistema;
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
        public static async Task<LoginEstado> Authorize(string usuario,string clave)
        {
            LoginEstado Respuesta = LoginEstado.ErrorSistema;

            await Task.Run(() => {
                TS_SIAutenticationClient cliente = null;
                TS_BELogin input = new TS_BELogin()
                {
                    cdusuario = usuario,
                    password = clave
                };
                try
                {
                    cliente = new TS_SIAutenticationClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Autenticate));
                    _LoginCompleted(cliente.Login(input));
                    Respuesta = LoginEstado.EsperandoRespuesta;

                }
                catch
                {
                    Respuesta = LoginEstado.ErrorSistema;
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
        private static void _LoginCompleted(TS_BELoginOutPut Result)
        {
            if (Result == null)
            {
                LoginAuthorize(new TSLogin(LoginEstado.ErrorSistema));
                return;
            }

            if (Result.Mensaje == null && Result.Ok == false)
            {
                LoginAuthorize(new TSLogin(LoginEstado.ErrorSistema));
                return;

            }

            if (Result.Mensaje != null && Result.Ok == false)
            {
                LoginAuthorize(new TSLogin(LoginEstado.SinAutorizacion, Result));
                return;
            }

            if (Result.Ok == true)
            {
                LoginAuthorize(new TSLogin(LoginEstado.Autorizacion, Result));
                return;
            }
        }

        public static async Task<LoginEstado> AutenticateConfigCara()
        {
            LoginEstado respuesta = LoginEstado.ErrorSistema;
            await Task.Run(() => {
                TS_BELoginVendedor input = new TS_BELoginVendedor()
                {
                    cdempresa = TSLoginApp.CurrentEmpresa.cdempresa,
                    usuario = UserNameVenderdor,
                    clave = PasswordVenderdor
                };

                TS_SIImpresionClient cliente = null;

                try
                {
                    cliente = new TS_SIImpresionClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Impresion));
                    _AUTENTICAR_GRIFERO_LADOSCompleted(cliente.AUTENTICAR_GRIFERO_LADOS(input));
                    respuesta = LoginEstado.EsperandoRespuesta;
                }
                catch
                {
                    respuesta = LoginEstado.ErrorSistema;
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
           
            return respuesta;
        }

        private static void _AUTENTICAR_GRIFERO_LADOSCompleted(TS_BEMensaje Result)
        {
            if (Result == null)
            {
                ConfigCaraAuthorize(new TSLogin(LoginEstado.ErrorSistema));
                return;
            }

            if (Result.mensaje == null && Result.Ok == false)
            {
                ConfigCaraAuthorize(new TSLogin(LoginEstado.ErrorSistema));
                return;
            }

            if (Result.Ok == false)
            {
                CurrentResultado = (new TSLogin(LoginEstado.SinAutorizacion, Result));
                ConfigCaraAuthorize(CurrentResultado);
                return;
            }

            if (Result.Ok == true)
            {
                CurrentResultado = new TSLogin(LoginEstado.Autorizacion);
                ConfigCaraAuthorize(CurrentResultado);
                return;
            }
        }

        public static async Task<LoginEstado> AutorizeLoginConfiguracionLados(string usuario,string clave)
        {
            LoginEstado respuesta = LoginEstado.ErrorSistema;
            await Task.Run(() => {
                TS_BELoginVendedor input = new TS_BELoginVendedor()
                {
                    cdempresa = TSLoginApp.CurrentEmpresa.cdempresa,
                    usuario = usuario,
                    clave = clave
                };

                TS_SIImpresionClient cliente = null;

                try
                {
                    cliente = new TS_SIImpresionClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Impresion));
                    _AUTENTICAR_CONFIGURACION_LADOSCompleted(cliente.AUTENTICAR_CONFIGURACION_LADOS(input));
                    respuesta = LoginEstado.EsperandoRespuesta;
                }
                catch
                {
                    respuesta = LoginEstado.ErrorSistema;
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

            return respuesta;
        }

        private static void _AUTENTICAR_CONFIGURACION_LADOSCompleted(TS_BEMensaje Result)
        {
            if (Result == null)
            {
                LogiConfiguracionLado(new TSLogin(LoginEstado.ErrorSistema));
                return;
            }

            if (Result.mensaje == null && Result.Ok == false)
            {
                LogiConfiguracionLado(new TSLogin(LoginEstado.ErrorSistema));
                return;
            }

            if (Result.Ok == false)
            {
                LogiConfiguracionLado(new TSLogin(LoginEstado.SinAutorizacion, Result));
                return;
            }

            if (Result.Ok == true)
            {
                LogiConfiguracionLado(new TSLogin(LoginEstado.Autorizacion));
                return;
            }
        }

        public static async Task<LoginEstado> AutenticateDeposito()
        {
            LoginEstado Respuesta = LoginEstado.ErrorSistema;

            await Task.Run(() => {

                TS_BELoginVendedor input = new TS_BELoginVendedor()
                {
                    cdempresa = TSLoginApp.CurrentEmpresa.cdempresa,
                    usuario = UserNameVenderdor,
                    clave = PasswordVenderdor
                };

                TS_SIImpresionClient cliente = null;
                try
                {
                    cliente = new TS_SIImpresionClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Impresion));
                    _AUTENTICAR_DEPOSITO_GRIFEROCompleted(cliente.AUTENTICAR_DEPOSITO_GRIFERO(input));
                    Respuesta = LoginEstado.EsperandoRespuesta;
                }
                catch
                {              
                    Respuesta = LoginEstado.ErrorSistema;
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

        private static void _AUTENTICAR_DEPOSITO_GRIFEROCompleted(TS_BEMensaje Result)
        {

            if (Result == null)
            {
                DepositoAuthorize(new TSLogin(LoginEstado.ErrorSistema));
                return;
            }

            if (Result.mensaje == null && Result.Ok == false)
            {
                DepositoAuthorize(new TSLogin(LoginEstado.ErrorSistema));
                return;
            }

            if (Result.Ok == false)
            {
                CurrentResultado = (new TSLogin(LoginEstado.SinAutorizacion, Result));
                DepositoAuthorize(CurrentResultado);
                return;
            }

            if (Result.Ok == true)
            {
                CurrentResultado = new TSLogin(LoginEstado.Autorizacion);
                DepositoAuthorize(CurrentResultado);
                return;
            }
        }

        public static async void GetEmpresaAuthorize(TS_BELogin vLoginRequest)
        {
            await Task.Run(() => {
                TS_SIAutenticationClient cliente = null;
                try
                {
                    cliente = new TS_SIAutenticationClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Autenticate));
                    GetEmpresaUserCompleted(cliente.Login(vLoginRequest));
                }
                catch
                {

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


        }
        
        private static void GetEmpresaUserCompleted(TS_BELoginOutPut Result)
        {
            CurrentResultado.EmpresaConsultado = true;
            if (Result == null)
            {
                LoginAuthorize(new TSLogin(LoginEstado.ErrorSistema));
                return;
            }

            CurrentResultado = new TSLogin(LoginEstado.InformacionObtenida, Result);
            CurrentResultado.vEmpresa = Result.Empresas;
            LoginAuthorize(CurrentResultado);
        }
        




        public static async Task<LoginEstado> AuthorizeCambioTurno(string usuario, string clave)
        {
            LoginEstado Respuesta = LoginEstado.ErrorSistema;

            await Task.Run(() => {

                TS_BELoginTurno input = new TS_BELoginTurno()
                {
                    cdusuario = usuario,
                    password = clave,
                    cdempresa = CurrentEmpresa.cdempresa
                };

                TS_SIAutenticationClient cliente = null;
                try
                {
                    cliente = new TS_SIAutenticationClient(Helper.ServicioSoapBinding(), new EndpointAddress(Config.Services.Autenticate));
                    _LoginTurnoCompleted(cliente.LoginTurno(input));
                    Respuesta = LoginEstado.EsperandoRespuesta;
                }
                catch
                {

                    Respuesta = LoginEstado.ErrorSistema;
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
        
        private static void _LoginTurnoCompleted(TS_BELoginTurnoOutPut Result)
        {
            if (Result == null)
            {
                LoginCambioTurno(new TSLogin(LoginEstado.ErrorSistema));
                return;
            }

            if (Result.Mensaje == null)
            {
                LoginCambioTurno(new TSLogin(LoginEstado.ErrorSistema));
                return;
            }

            if (Result.Mensaje != null)
            {
                LoginCambioTurno(new TSLogin(LoginEstado.InformacionObtenida,Result));
                return;
            }
        }
        


        private static void RevisarEstadoConsulta()
        {
            if (CurrentResultado == null)
            {
                return;
            }
            if (CurrentResultado.EmpresaConsultado)
            {
                LoginAuthorize(CurrentResultado);
            }
        }
    }
}
