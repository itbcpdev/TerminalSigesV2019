using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Autenticate;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Lados
{

    public partial class LoginLados : ContentPage
    {
        private bool login = false;
        public LoginLados(bool _login)
        {
            InitializeComponent();
            login = _login;
            this.txtUsername.Completed += TxtUsername_Completed;
            this.txtPassword.Completed += TxtPassword_Completed;
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
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (login)
            {
                stackConfirma.IsVisible = true;
                stacklogin.IsVisible = false;
  
            };
        }
        async void OnLoginStart(object sender, EventArgs e)
        {

        }
        async void OnLogin(object sender, EventArgs e)
        {
            circleBtnLogin.IsEnabled = false;
            string usuario = this.txtUsername.Text;
            string clave = this.txtPassword.Text;
            LoginEstado resultado = LoginEstado.ErrorSistema;
            busyindicator.IsVisible = true;
            await Task.Run(() =>
            {
                TSLoginApp.LogiConfiguracionLado += LoginAuthorize;
                resultado = TSLoginApp.AutorizeLoginConfiguracionLados(usuario,clave).Result;
            });
            if (resultado != LoginEstado.EsperandoRespuesta)
            {
                busyindicator.IsVisible = false;
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
            TSLoginApp.LogiConfiguracionLado -= LoginAuthorize;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == LoginEstado.SinAutorizacion)
                {
                    busyindicator.IsVisible = false;
                    stacklogin.IsVisible = true;
                    circleBtnLogin.IsEnabled = true;
                    await DisplayAlert("Aviso", respuesta.vMensaje.mensaje, "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == LoginEstado.Autorizacion)
                {
                    stackConfirma.IsVisible = true;
                    stacklogin.IsVisible = false;
                }
                if (respuesta.EstadoRespuesta == LoginEstado.ErrorSistema)
                {
                    busyindicator.IsVisible = false;
                    stacklogin.IsVisible = true;
                    circleBtnLogin.IsEnabled = true;
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
            });
        }
        async void OnRegistrar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrarLados());

        }
        async void OnReportes(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReporteLados());
        }

        private void OnCancelar(object sender, EventArgs e)
        {
            App.Current.MainPage = (new Home());
        }

        public void OnSalir(object sender, EventArgs e)
        {
            App.Current.MainPage = new Home();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}