using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Autenticate;
using TerminalSiges.Lib.Loading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.PopUp
{
    public partial class LoginPopUp : PopupPage
    {
        public event OnResponse LoginResponseEvent;
        public delegate void OnResponse(LoginEstado respuesta, bool PermisoAnular);
        public LoginPopUp()
        {
            InitializeComponent();
            this.txtClave.Completed += TxtClave_Completed;
            this.txtUser.Completed += TxtUser_Completed;
            this.btnAceptar.Clicked += BtnAceptar_Clicked;
        }

        private async void LoginResponse(LoginEstado respuesta, bool PermisoAnular)
        {
            LoginResponseEvent(respuesta, PermisoAnular);
            await PopupNavigation.Instance.PopAsync();
        }
        private void BtnAceptar_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty((this.txtClave.Text ?? "").Trim()))
            {
                this.txtUser.Focus();
                return;
            }
            if (String.IsNullOrEmpty((this.txtUser.Text ?? "").Trim()))
            {
                this.txtClave.Focus();
                return;
            }
            OnLogin((this.txtUser.Text ?? "").Trim(), (this.txtClave.Text ?? "").Trim());
        }

        private void TxtUser_Completed(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty((this.txtUser.Text ?? "").Trim()))
            {
                this.txtClave.Focus();
            }
        }

        private void TxtClave_Completed(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty((this.txtClave.Text ?? "").Trim()))
            {
                this.txtUser.Focus();
            }
        }

        private async void OnLogin(string usuario, string clave)
        {
            LoginEstado resultado = LoginEstado.ErrorSistema;
            this.txtClave.IsEnabled = false;
            this.txtUser.IsEnabled = false;
            this.busyindicator.IsVisible = true;
            this.btnAceptar.IsVisible = false;
            await Task.Run(() =>
            {
                TSLoginApp.LoginAuthorize += LoginAuthorize; ;
                resultado = TSLoginApp.Authorize(usuario, clave).Result;
            });
            if (resultado != LoginEstado.EsperandoRespuesta)
            {
                switch (resultado)
                {
                    case LoginEstado.ErrorInternet:
                        LoginResponse(resultado, false);
                        break;
                    case LoginEstado.ErrorSistema:
                        LoginResponse(resultado, false);
                        break;
                }
            }

        }

        private void LoginAuthorize(TSLogin respuesta)
        {
            TSLoginApp.LoginAuthorize -= LoginAuthorize;
            Device.BeginInvokeOnMainThread(() =>
            {
                if (respuesta.EstadoRespuesta == LoginEstado.Autorizacion)
                {
                    foreach (var item in respuesta.vLoginOutput.Empresas)
                    {
                        if (((item.cdempresa ?? "").Trim()).Equals((TSLoginApp.CurrentEmpresa.cdempresa ?? "").Trim()))
                        {
                            if( (item.cdnivel ?? "").Trim().Equals("01") || (item.cdnivel ?? "").Trim().Equals("02"))
                            {
                                LoginResponse(LoginEstado.Autorizacion, true);
                                return;
                            }
                            else
                            {
                                LoadingUser((TSLoginApp.CurrentEmpresa.cdempresa ?? "").Trim(), (TSLoginApp.CurrentEmpresa.cdnivel ?? "").Trim(), (this.txtUser.Text ?? "").Trim());
                                return;
                            }
                        }
                    }
                    LoginResponse(LoginEstado.SinAutorizacion, false);
                    return;
                }
                else
                {
                    LoginResponse(LoginEstado.SinAutorizacion, false);
                    return;
                }
            });
        }

        public async void LoadingUser(string cdempresa, string cdnivel, string cdusuario)
        {
            LoadEstado resultado = LoadEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TSLoadApp.SalesLoading += SalesLoading;
                resultado = TSLoadApp.Loading(cdempresa, cdnivel, cdusuario).Result;
            });
            if (resultado != LoadEstado.EsperandoRespuesta)
            {
                switch (resultado)
                {
                    case LoadEstado.ErrorInternet:
                        LoginResponse(LoginEstado.SinAutorizacion, false);
                        break;
                    case LoadEstado.ErrorSistema:
                        LoginResponse(LoginEstado.SinAutorizacion, false);
                        break;
                }
            }
        }
        private void SalesLoading(TSLoad respuesta)
        {
            TSLoadApp.SalesLoading -= SalesLoading;
            Device.BeginInvokeOnMainThread(() =>
            {
                if (respuesta.EstadoRespuesta == LoadEstado.InformacionNoObtenida)
                {
                    LoginResponse(LoginEstado.SinAutorizacion, false);
                    return;
                }
                if (respuesta.EstadoRespuesta == LoadEstado.ErrorSistema)
                {
                    LoginResponse(LoginEstado.SinAutorizacion, false);
                    return;
                }
                if (respuesta.EstadoRespuesta == LoadEstado.InformacionObtenida)
                {
                    bool Evaluado = respuesta == null ? false : (respuesta.vSales == null ? false : (respuesta.vSales.Usuario == null ? false : true) );

                    if (Evaluado)
                    {
                        if (respuesta.vSales.Usuario.flganular)
                        {
                            LoginResponse(LoginEstado.Autorizacion, true);
                            return;
                        }
                        else
                        {
                            LoginResponse(LoginEstado.Autorizacion, false);
                            return;
                        }
                    }
                    else
                    {
                        LoginResponse(LoginEstado.SinAutorizacion, false);
                        return;
                    }
                }
            });
        }
    }
}