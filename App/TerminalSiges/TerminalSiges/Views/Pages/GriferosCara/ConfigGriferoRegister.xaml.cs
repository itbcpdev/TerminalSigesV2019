using ITBCP.ServiceSIGES.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Include;
using TerminalSiges.Lib.Prints;
using TerminalSiges.Lib.Sales;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.GriferosCara
{
    public partial class ConfigGriferoRegister : ContentPage
    {
        public bool Cargado = false;
        public ConfigGriferoRegister()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) return;
            PrintEstado resultado = PrintEstado.ErrorSistema;
            await Task.Run(delegate
            {
                TSPrintApp.ObtenerGrifero += TSPrintApp_ObtenerGrifero; ;
                resultado = TSPrintApp.ReporteGrifero().Result;
            });
            if (resultado != PrintEstado.EsperandoRespuesta)
            {

                switch (resultado)
                {
                    case PrintEstado.ErrorInternet:
                        await DisplayAlert("Aviso", "Su dispositivo no cuenta con internet en estos momentos.", "Aceptar");
                        break;
                    case PrintEstado.ErrorSistema:
                        await DisplayAlert("Aviso", "Hubo un problema de comunicación con el servidor, por favor intente después.", "Aceptar");
                        break;
                }
            }
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        private void TSPrintApp_ObtenerGrifero(TSPrint respuesta)
        {
            TSPrintApp.ObtenerGrifero -= TSPrintApp_ObtenerGrifero;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", String.IsNullOrEmpty(( (respuesta.vVendedores.Mensaje == null ? "" : respuesta.vVendedores.Mensaje.mensaje) ?? "").Trim()) ? "No hay vendedores registrados" : respuesta.vVendedores.Mensaje.mensaje, "Aceptar") ;
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionObtenida)
                {
                    cboVendedor.DataSource = respuesta.vVendedores.cVendedores;
                    ObtenerListNroPos();
                    return;
                }

            });
        }

        private async void ObtenerListNroPos()
        {
            SalesEstado resultado = SalesEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TSSalesApp.ObtenerNroPOS += TSPrintApp_ObtenerNroPost;
                resultado = TSSalesApp.ListNroPos().Result;
            });
            if (resultado != SalesEstado.EsperandoRespuesta)
            {

                switch (resultado)
                {
                    case SalesEstado.ErrorInternet:
                        await DisplayAlert("Aviso", "Su dispositivo no cuenta con internet en estos momentos.", "Aceptar");
                        break;
                    case SalesEstado.ErrorSistema:
                        await DisplayAlert("Aviso", "Hubo un problema de comunicación con el servidor, por favor intente después.", "Aceptar");
                        break;
                }
            }
        }

        private void TSPrintApp_ObtenerNroPost(TSSales respuesta)
        {
            TSSalesApp.ObtenerNroPOS -= TSPrintApp_ObtenerNroPost;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta != SalesEstado.InformacionObtenida)
                {
                    await DisplayAlert("Aviso", "Ocurrió un error al cargar Nro de Pos", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == SalesEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == SalesEstado.InformacionObtenida)
                {
                    cboLado.DataSource = respuesta.vNroPos;
                    return;
                }

            });
        }
        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            if (cboVendedor.SelectedIndex < 0)
            {
                await DisplayAlert("Aviso", "Seleccione el vendedor.", "Aceptar");
                return;
            }
            if (cboLado.SelectedIndex < 0)
            {
                await DisplayAlert("Aviso", "Seleccione el Nro de POS.", "Aceptar");
                return;
            }

            if (txtLado.Text != null)
            {
                if (Helper.IsNumero(txtLado.Text))
                {
                    decimal lado = Convert.ToInt32(txtLado.Text);
                    if (lado <= 0)
                    {
                        await DisplayAlert("Aviso", "Ingrese número de lado.", "Aceptar");
                    }
                }
                else
                {
                    await DisplayAlert("Aviso", "Ingrese número de lado válido.", "Aceptar");
                    return;
                }
            }
            else
            {
                await DisplayAlert("Aviso", "Ingrese número de lado.", "Aceptar");
                return;
            }

            TSPrintApp.Lado = this.txtLado.Text;
            TSPrintApp.NroPos = ((TS_BENropos)this.cboLado.SelectedItem).nropos;
            TSPrintApp.CdVendedor = ((TS_BEVendedor)this.cboVendedor.SelectedItem).cdusuario;
            ConfigGriferoCaraCompleted Vista = new ConfigGriferoCaraCompleted();
            Vista.Guardado += Vista_Guardado;
            await Navigation.PushAsync(Vista);

        }

        private async void Vista_Guardado()
        {
            await Navigation.PopAsync();
        }
    }
}