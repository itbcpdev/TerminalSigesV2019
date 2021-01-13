using ITBCP.ServiceSIGES.Domain.Entities.Users;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TerminalSiges.Lib.Autenticate;
using TerminalSiges.Views.Pages.Invoce;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TerminalSiges.Lib.Include;
using TerminalSiges.Views.Pages.PopUp;
using Rg.Plugins.Popup.Services;
using TerminalSIGES.Services;

namespace TerminalSiges.Views.Pages.Users
{

    public partial class Login : ContentPage
    {

        public ObservableCollection<TS_BEEmpresaUser> Empresas { get; set; }
        public bool Cargado = false;
        private IFeatureService _featureService;

        public Login()
        {
            InitializeComponent();
            Empresas = new ObservableCollection<TS_BEEmpresaUser>();
            BindingContext = this;
            txtUsuario.Completed += TxtUsuario_Completed;
            _featureService = DependencyService.Get<IFeatureService>();
            FooterLabel.Text = "SIGES - 2019 V." + _featureService.GetVersionNumber();
        }

        private void TxtClave_Completed(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty((this.txtUsuario.Text ?? "").Trim()))
            {
                this.txtUsuario.Focus();
                return;
            }
        }

        private void TxtUsuario_Completed(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty((txtClave.Text ?? "").Trim()))
            {
                txtClave.Focus();
                return;
            }
        }

        private async void OnLogin(object sender, EventArgs e)
        {

            if(_featureService.GetGeneralSetting(Config.Services.ServiceUrlKey) == "" || _featureService.GetGeneralSetting(Config.Services.SerieHdKey) == "")
            {
                await DisplayAlert("Aviso", "Debe configurar las rutas de acceso al sistema.", "Aceptar");
                return;
            }

            Config.Services.Autenticate = _featureService.GetGeneralSetting(Config.Services.ServiceUrlKey) + Config.Services.AutenticateName;
            Config.Services.Impresion = _featureService.GetGeneralSetting(Config.Services.ServiceUrlKey)  + Config.Services.ImpresionName;
            Config.Services.Sales = _featureService.GetGeneralSetting(Config.Services.ServiceUrlKey) + Config.Services.SalesName;
            Config.Services.PrintAvaliable = _featureService.GetGeneralSetting(Config.Services.PrintKey).Equals("T");

            TSLoginApp.Serie = _featureService.GetGeneralSetting(Config.Services.SerieHdKey);
            TSLoginApp.UserName = txtUsuario.Text;
            TSLoginApp.Password = txtClave.Text;

            LoginEstado resultado = LoginEstado.ErrorSistema;
            circleBtnLogin.IsVisible = false;
            busyindicator.IsVisible = true;

            await Task.Run(() =>
            {
                TSLoginApp.LoginAuthorize += LoginAuthorize;
                resultado = TSLoginApp.Authorize().Result;
            });
            if (resultado != LoginEstado.EsperandoRespuesta)
            {
                busyindicator.IsVisible = false;
                circleBtnLogin.IsVisible = true;

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

        private async void OnLoginMultiple(object sender,EventArgs e)
        {
            TS_BEEmpresaUser empresa = (TS_BEEmpresaUser)this.cboEmpresas.SelectedItem;
            if(empresa == null)
            {
                await DisplayAlert("Aviso","Debe seleccionar una empresa","Aceptar");
                return;
            }
            else
            {
                TSLoginApp.UserFull = this.txtUsuario.Text;
                TSLoginApp.CurrentEmpresa = new TS_BEEmpresaUser();
                TSLoginApp.CurrentEmpresa.dsempresa = empresa.dsempresa;
                TSLoginApp.CurrentEmpresa.cdempresa = empresa.cdempresa;
                TSLoginApp.CurrentEmpresa.drempresa = empresa.drempresa;
                TSLoginApp.CurrentEmpresa.facturacion_electronica = empresa.facturacion_electronica;
                TSLoginApp.CurrentEmpresa.cdnivel = empresa.cdnivel;
                TSLoginApp.CurrentEmpresa.rucempresa = empresa.rucempresa;

                App.Current.MainPage = new NavigationPage(new LoadingSales());
            }

        }
        private void LoginAuthorize(TSLogin respuesta)
        {
            TSLoginApp.LoginAuthorize -= LoginAuthorize;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == LoginEstado.SinAutorizacion)
                {
                    this.busyindicator.IsVisible = false;
                    this.circleBtnLogin.IsVisible = true;
                    Cargado = false;
                    await DisplayAlert("Aviso", respuesta.vLoginOutput.Mensaje, "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == LoginEstado.Autorizacion)
                {

                    if (respuesta.vLoginOutput.Empresas.Length > 1)
                    {
                        foreach (var item in respuesta.vLoginOutput.Empresas)
                        {
                            Empresas.Add(new TS_BEEmpresaUser()
                            {
                                cdempresa = item.cdempresa,
                                dsempresa = item.dsempresa,
                                rucempresa = item.rucempresa,
                                cdnivel = item.cdnivel,
                                facturacion_electronica = item.facturacion_electronica,
                                drempresa = item.drempresa

                            });
                        }
                        TSLoginApp.UserFull = respuesta.vLoginOutput.Codigo;
                        this.busyindicator.IsVisible = false;
                        this.cboEmpresas.IsVisible = true;
                        this.txtClave.IsEnabled = false;
                        this.txtClave.IsEnabled = false;
                        this.circleBtnLoginMultiple.IsVisible = true;

                    }
                    else
                    {
                        TSLoginApp.UserFull = respuesta.vLoginOutput.Codigo;
                        TSLoginApp.CurrentEmpresa = new TS_BEEmpresaUser();
                        TSLoginApp.CurrentEmpresa.dsempresa = respuesta.vLoginOutput.Empresas[0].dsempresa;
                        TSLoginApp.CurrentEmpresa.cdempresa = respuesta.vLoginOutput.Empresas[0].cdempresa;
                        TSLoginApp.CurrentEmpresa.drempresa = respuesta.vLoginOutput.Empresas[0].drempresa;
                        TSLoginApp.CurrentEmpresa.facturacion_electronica = respuesta.vLoginOutput.Empresas[0].facturacion_electronica;
                        TSLoginApp.CurrentEmpresa.cdnivel = respuesta.vLoginOutput.Empresas[0].cdnivel;
                        TSLoginApp.CurrentEmpresa.rucempresa = respuesta.vLoginOutput.Empresas[0].rucempresa;

                        App.Current.MainPage = new NavigationPage(new LoadingSales());
                    }

                }
                if (respuesta.EstadoRespuesta == LoginEstado.ErrorSistema)
                {
                    this.busyindicator.IsVisible = false;
                    this.circleBtnLogin.IsVisible = true;
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    App.Current.MainPage = new NavigationPage(new Login());
                    return;
                }
            });
        }

        private void CboEmpresas_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }
            var empresa = (TS_BEEmpresaUser)e.Value;
            TSLoginApp.CurrentEmpresa = new TS_BEEmpresaUser();
            TSLoginApp.CurrentEmpresa.dsempresa = empresa.dsempresa;
            TSLoginApp.CurrentEmpresa.cdempresa = empresa.cdempresa;
            TSLoginApp.CurrentEmpresa.drempresa = empresa.drempresa;
            TSLoginApp.CurrentEmpresa.facturacion_electronica = empresa.facturacion_electronica;
            TSLoginApp.CurrentEmpresa.cdnivel = empresa.cdnivel;
            TSLoginApp.CurrentEmpresa.rucempresa = empresa.rucempresa;

        }
        private void OnSetting (object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            Task<bool> action = DisplayAlert("Aviso", "¿Desea salir de la aplicación?", "Si", " No");
            action.ContinueWith(task =>
            {
                if (task.Result)
                {
#if __ANDROID__
                    Java.Lang.JavaSystem.Exit(0);
#elif __IOS__
                        throw new Exception();
#endif

                }
            });
            return true;
        }
    }
}