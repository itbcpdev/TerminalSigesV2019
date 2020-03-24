using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Autenticate;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Print
{

    public partial class InicioDeDia : ContentPage
    {
        private string cdusuario { get; set; }
        public InicioDeDia()
        {
            InitializeComponent();
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
        private void OnLoginStart(object sender, EventArgs e)
        {
        }
        private async void OnLogin(object sender, EventArgs e)
        {
            string usuario = this.txtUsername.Text;
            string clave = this.txtPassword.Text;
            LoginEstado resultado = LoginEstado.ErrorSistema;
            busyindicator.IsVisible = true;
            circleBtnLogin.IsEnabled = false;
            await Task.Run(() =>
            {
                TSLoginApp.LoginCambioTurno += LoginCambioTurnoAuthorize;
                resultado = TSLoginApp.AuthorizeCambioTurno(usuario, clave).Result;
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

        private void LoginCambioTurnoAuthorize(TSLogin respuesta)
        {
            TSLoginApp.LoginAuthorize -= LoginCambioTurnoAuthorize;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == LoginEstado.InformacionObtenida)
                {
                    if (respuesta.vRespuestaTurno.Ok == false)
                    {
                        busyindicator.IsVisible = false;
                        circleBtnLogin.IsEnabled = true;
                        await DisplayAlert("Aviso", respuesta.vRespuestaTurno.Mensaje, "Aceptar");
                        return;

                    }
                    else
                    {
                        stackConfirma.IsVisible = true;
                        stacklogin.IsVisible = false;
                        this.cdusuario = this.txtUsername.Text;
                    }
                }
                if (respuesta.EstadoRespuesta == LoginEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
            });
        }
        private void OnSi(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new InicioDeDiaCompleted(cdusuario));

        }
        private void OnNo(object sender, EventArgs e)
        {

            App.Current.MainPage = new Home();
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