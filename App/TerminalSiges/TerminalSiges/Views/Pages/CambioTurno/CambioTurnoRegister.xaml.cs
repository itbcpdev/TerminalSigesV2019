using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Autenticate;
using TerminalSiges.Lib.Sales;
using TerminalSiges.Views.Pages.Invoce;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.CambioTurno
{

    public partial class CambioTurnoRegister : ContentPage
    {
        public CambioTurnoRegister()
        {
            InitializeComponent();
        }
        private void OnLoginStart(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new LoadingSales());
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
        async void OnLogin(object sender, EventArgs e)
        {
            string usuario = this.txtUsername.Text;
            string clave = this.txtPassword.Text;
            LoginEstado resultado = LoginEstado.ErrorSistema;
            this.busyindicator.IsVisible = true;
            this.circleBtnLogin.IsEnabled = false;
            await Task.Run(() =>
            {
                TSLoginApp.LoginCambioTurno += LoginAuthorizeCambioTurno;
                resultado = TSLoginApp.AuthorizeCambioTurno(usuario, clave).Result;
            });
            if (resultado != LoginEstado.EsperandoRespuesta)
            {
                this.busyindicator.IsVisible = false;
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

        private void LoginAuthorizeCambioTurno(TSLogin respuesta)
        {
            TSLoginApp.LoginCambioTurno -= LoginAuthorizeCambioTurno;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == LoginEstado.InformacionObtenida)
                {
                    if (respuesta.vRespuestaTurno.Ok == false)
                    {
                        this.busyindicator.IsVisible = false;
                        await DisplayAlert("Aviso", respuesta.vRespuestaTurno.Mensaje, "Aceptar");
                        this.circleBtnLogin.IsEnabled = true;
                        return;
                    }
                    else
                    {
                        TSSalesApp.vTerminal.turno = TSSalesApp.vTerminal.turno + 1;
                        this.stackConfirma.IsVisible = true;
                        this.stacklogin.IsVisible = false;
                    }

                }
                if (respuesta.EstadoRespuesta == LoginEstado.ErrorSistema)
                {
                    this.busyindicator.IsVisible = false;
                    this.stacklogin.IsVisible = true;
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
            });
        }
        private void OnSi(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new CambioTurCompleted());

        }

        private void OnNo(object sender, EventArgs e)
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