using ITBCP.ServiceSIGES.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Autenticate;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Afiliacion
{
    public partial class AfiliacionLogin : ContentPage
    {
        public AfiliacionLogin()
        {
            InitializeComponent();
        }
        public async void OnLogin(object sender, EventArgs e)
        {
            LoginEstado resultado = LoginEstado.ErrorSistema;
            this.circleBtnLogin.IsVisible = false;
            this.busyindicator.IsVisible = true;
            await Task.Run(() =>
            {
                TSLoginApp.LoginAuthorize += LoginAuthorize; ;
                resultado = TSLoginApp.Authorize().Result;
            });
            if (resultado != LoginEstado.EsperandoRespuesta)
            {
                this.busyindicator.IsVisible = false;
                this.circleBtnLogin.IsVisible = true;
                switch (resultado)
                {
                    case LoginEstado.ErrorInternet:
                        await DisplayAlert("Aviso", "Su dispositivo no cuenta con internet en estos momentos.", "Aceptar");
                        break;
                    case LoginEstado.ErrorSistema:
                        await DisplayAlert("Aviso", "Hubo un problema de comunicación con el servidor, por favor intente después.", "Aceptar");
                        break;
                }
            }
        }
        private void LoginAuthorize(TSLogin respuesta)
        {
            TSLoginApp.LoginAuthorize -= LoginAuthorize;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == LoginEstado.SinAutorizacion)
                {
                    await DisplayAlert("Aviso", respuesta.vLoginOutput.Mensaje, "Aceptar");
                }
                if (respuesta.EstadoRespuesta == LoginEstado.Autorizacion)
                {

                    if (respuesta.vLoginOutput.Empresas.Length > 0)
                    {
                        int Validado = 0;
                        int Permiso  = 0;
                        foreach (TS_BEEmpresaUser Empresa in respuesta.vLoginOutput.Empresas)
                        {
                            /*Coincide el codigo de la empresa actual con el obtenido del servicio*/
                            if ((TSLoginApp.CurrentEmpresa.cdempresa ?? "").Equals(Empresa.cdempresa ?? ""))
                            {
                                Validado++;
                                Permiso = respuesta.vLoginOutput.Usuario == null ? 0 : respuesta.vLoginOutput.Usuario.flganular ? 1 : 0;
                            }
                        }

                        if(Validado > 0)
                        {
                            if(Permiso > 0)
                            {
                                App.Current.MainPage = new NavigationPage(new AfiliacionClientes());
                                return;
                            }
                            else
                            {
                                await DisplayAlert("Aviso", "Usted no posee los permisos necesarios para acceder al modulo", "Aceptar");
                            }
                        }
                        else
                        {
                            await DisplayAlert("Aviso", "Usted no se encuentra relacionado a la empresa a la cual intenta acceder", "Aceptar");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Aviso", "Usted no posee ninguna empresa relacionada", "Aceptar");

                    }

                }
                if (respuesta.EstadoRespuesta == LoginEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                }
                this.busyindicator.IsVisible = false;
                this.circleBtnLogin.IsVisible = true;
            });
        }
        private void TxtPassword_Completed(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty((this.txtUsername.Text ?? "").Trim()))
            {
                this.txtUsername.Focus();
                return;
            }
        }

        private void TxtUsername_Completed(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty((this.txtPassword.Text ?? "").Trim()))
            {
                this.txtPassword.Focus();
                return;
            }
        }
        public void OnSalir(object sender, EventArgs e)
        {
            App.Current.MainPage = new Home();
        }
    }
}