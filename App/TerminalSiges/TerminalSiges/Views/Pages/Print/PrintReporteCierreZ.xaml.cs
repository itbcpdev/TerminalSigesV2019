using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Prints;
using TerminalSIGES.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Print
{

    public partial class PrintReporteCierreZ : ContentPage
    {
        public bool Cargado = false;
        public PrintReporteCierreZ()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (this.Width > 0)
            {
                pdfStack.HeightRequest = this.Height;

            }
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (Cargado) return;
            Cargado = true;
            TSPrintApp.ig_bloque_playa = Convert.ToBoolean(1); ;
            TSPrintApp.imprimir = Convert.ToBoolean(0);
            PrintEstado resultado = PrintEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TSPrintApp.ObtenerCierreZ += _ObtenerCierreZ;
                resultado = TSPrintApp.ObtenerReporteCierreZ().Result;
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

        private void _ObtenerCierreZ(TSPrint respuesta)
        {
            TSPrintApp.ObtenerCierreZ -= _ObtenerCierreZ;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", respuesta.vMensaje.mensaje, "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionObtenida)
                {
                    var result = respuesta.vRespuesta;

                    var base64encodepdf = Convert.FromBase64String(result.base64encodepdf);
                    if (base64encodepdf != null)
                    {

                        string URL = await DependencyService.Get<IFeatureService>().SaveFile("ReporteZ", base64encodepdf);
                        PdfDocView.Uri = URL;
                        busyindicator.IsVisible = false;
                    }
                }

            });
        }

        void PrevenirSeleccion(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event 
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
        private void IrAlInicio(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new ReporteCierreZ());
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            App.Current.MainPage = new NavigationPage(new ReporteCierreZ());
            return true;
        }
    }
}