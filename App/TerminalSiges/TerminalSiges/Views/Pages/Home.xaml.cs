using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Autenticate;
using TerminalSiges.Lib.Loading;
using TerminalSiges.Lib.Sales;
using TerminalSiges.Views.Pages.Afiliacion;
using TerminalSiges.Views.Pages.Articulo;
using TerminalSiges.Views.Pages.CambioTurno;
using TerminalSiges.Views.Pages.Depositos;
using TerminalSiges.Views.Pages.GriferosCara;
using TerminalSiges.Views.Pages.Invoce;
using TerminalSiges.Views.Pages.Lados;
using TerminalSiges.Views.Pages.Print;
using TerminalSiges.Views.Pages.Users;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages
{

    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            UserName.Text = TSLoginApp.UserName;
            UserNameFull.Text = TSLoginApp.UserFull.Trim();
            Empresa.Text = TSLoginApp.CurrentEmpresa.dsempresa.Trim();
            txtNroPos.Text = TSSalesApp.vTerminal.nropos;
            txtFechaServer.Text = TSSalesApp.FechaServidor;

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                Device.BeginInvokeOnMainThread(() => txtFechaServer.Text = TSSalesApp.FechaServidor.Substring(0,10) + " - " + DateTime.Now.ToString().Substring(10));
                return true;
            });
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ProcDisableControlls(true);
        }
        private void ProcDisableControlls(bool status)
        {
            this.btnFacturacion.IsEnabled = status;
            this.btnCambioTurno.IsEnabled = status;
            this.btnTienda.IsEnabled = false;
            this.btnLados.IsEnabled = status;
            this.btnAfiliacionTarj.IsEnabled = status;
            this.btnCierrex.IsEnabled = status;
            this.btnCierrez.IsEnabled = status;
            this.btnIniciodia.IsEnabled = status;
            this.btnCambioTurno.IsEnabled = status;
            this.btnDeposito.IsEnabled = status;
            this.btnConfig.IsEnabled = status;
            this.btnSalir.IsEnabled = status;

            if (!TSSalesApp.vUsuarioActual.flgCierreX)
                btnCierrex.IsEnabled = false;
            if (!TSSalesApp.vUsuarioActual.flgCierreZ)
                btnCierrez.IsEnabled = false;
        }

        public void IrAConsultas(object sender, EventArgs e)
        {

        }

        public async void BtnGriferoCara_Clicked(object sender, EventArgs e)
        {
            int cdnivel = 0;
            ProcDisableControlls(false);
            try
            {
                cdnivel = TSLoginApp.CurrentEmpresa.cdnivel == null ? 0 : Convert.ToInt32(TSLoginApp.CurrentEmpresa.cdnivel.Trim());
            }
            catch
            {
                cdnivel = -1;
            }

            if ((cdnivel == 1) || (cdnivel == 2) || (cdnivel == 4)  || (cdnivel == 8))
            {
                App.Current.MainPage = new NavigationPage(new ConfigGriferoCaraLogin(false));
                return;
            }
            if (cdnivel == -1)
            {
                await DisplayAlert("Aviso", "El nivel de usuario no es reconocido por el sistema", "Aceptar");
                ProcDisableControlls(true);
                return;
            }
            else
            {
                await DisplayAlert("Aviso", "El usuario no tiene permisos para acceder a esta opción", "Aceptar");
                ProcDisableControlls(true);
                return;
            }

            
        }
        private async void BtnFacturacion_Clicked(object sender, EventArgs e)
        {
            int cdnivel = 0;
            ProcDisableControlls(false);
            try
            {
                cdnivel = TSLoginApp.CurrentEmpresa.cdnivel == null ?  0 : Convert.ToInt32(TSLoginApp.CurrentEmpresa.cdnivel.Trim()); 
            }
            catch
            {
                cdnivel = -1;
            }

            if ((cdnivel == 8) || (cdnivel == 1) || (cdnivel == 2))
            {
                bool vIntefaz = Convert.ToBoolean(TSSalesApp.vTerminal.flgautomatica ?? false);
                if (vIntefaz)
                {
                    await Task.Run(() => 
                    {
                        NavigationPage Page = new NavigationPage(new Automatic());
                        Page.BarBackgroundColor = App.Color;
                        App.Current.MainPage = Page;
                    });
                    return;
                }
                else
                {
                    await Task.Run(() => { App.Current.MainPage = new NavigationPage(new SemiAutomatic()); });
                    return;
                }
            }
           if(cdnivel == -1)
            {
                await DisplayAlert("Aviso", "El nivel de usuario no es reconocido por el sistema", "Aceptar");
                ProcDisableControlls(true);
                return;
            }
            else
            {
                await DisplayAlert("Aviso", "El usuario no tiene permisos para acceder a esta opción", "Aceptar");
                ProcDisableControlls(true);
                return;
            }
        }
        private void BtnCierreX_Clicked(object sender, EventArgs e)
        {
            ProcDisableControlls(false);
            App.Current.MainPage = new NavigationPage(new ReporteCierreX());
        }
        private void BtnCierreZ_Clicked(object sender, EventArgs e)
        {
            ProcDisableControlls(false);
            App.Current.MainPage = new NavigationPage(new ReporteCierreZ());
        }
        private void BtnIniciodia_Clicked(object sender, EventArgs e)
        {
            ProcDisableControlls(false);
            App.Current.MainPage = new NavigationPage(new InicioDeDia());
        }
        private void BtnCambioTurno_Clicked(object sender, EventArgs e)
        {
            ProcDisableControlls(false);
            App.Current.MainPage = new NavigationPage(new CambioTurnoRegister());
        }
        private async void BtnDepositos_Clicked(object sender, EventArgs e)
        {
            int cdnivel = 0;
            ProcDisableControlls(false);
            try
            {
                cdnivel = TSLoginApp.CurrentEmpresa.cdnivel == null ? 0 : Convert.ToInt32(TSLoginApp.CurrentEmpresa.cdnivel.Trim());
            }
            catch
            {
                cdnivel = -1;
            }

            if ((cdnivel == 8) || (cdnivel == 1) || (cdnivel == 2))
            {
                App.Current.MainPage = new NavigationPage(new DepositoLogin(false));
                return;
            }
            if (cdnivel == -1)
            {
                await DisplayAlert("Aviso", "El nivel de usuario no es reconocido por el sistema", "Aceptar");
                ProcDisableControlls(true);
                return;
            }
            else
            {
                await DisplayAlert("Aviso", "El usuario no tiene permisos para acceder a esta opción", "Aceptar");
                ProcDisableControlls(true);
                return;
            }
        }
        private void BtnLados_Clicked(object sender, EventArgs e)
        {
            ProcDisableControlls(false);
            App.Current.MainPage = new NavigationPage(new LoginLados(false));
            return;
        }
        private void BtnAfiliacion_Clicked(object sender, EventArgs e)
        {
            int cdnivel = 0;
            ProcDisableControlls(false);
            try
            {
                cdnivel = TSLoginApp.CurrentEmpresa.cdnivel == null ? 0 : Convert.ToInt32(TSLoginApp.CurrentEmpresa.cdnivel.Trim());
            }
            catch
            {
                cdnivel = -1;
            }
            if(cdnivel == 2 ||cdnivel == 1 || TSSalesApp.vUsuarioActual.flganular)
            {
                App.Current.MainPage = new NavigationPage(new AfiliacionClientes());
            }
            else
            {
                App.Current.MainPage = new NavigationPage(new AfiliacionLogin());
            }
           
            
          
        }

        private void BtnCerrarSession_Clicked(object sender, EventArgs e)
        {
            Task<bool> action = DisplayAlert("Aviso", "¿Desea ir al inicio de sesión?", "Si", "No");
            action.ContinueWith(task =>
            {
                if (task.Result)
                {
                    App.Current.MainPage = new NavigationPage(new Login());
                }
            });
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

    }
}