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

    public partial class PrintReporteCierreX : ContentPage
    {
        public bool Cargado = false;
        public PrintReporteCierreX()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (Cargado) return;
            Cargado = true;
            TSPrintApp.ig_bloque_playa = Convert.ToBoolean(1); ;
            TSPrintApp.imprimir = Convert.ToBoolean(0);
            PrintEstado resultado = PrintEstado.ErrorSistema;
            await Task.Run(delegate
            {
                TSPrintApp.ObtenerCierreX += _ObtenerCierreX;
                resultado = TSPrintApp.ObtenerReporteCierreX().Result;
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
        void PrevenirSeleccion(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event 
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
        private void _ObtenerCierreX(TSPrint respuesta)
        {
            TSPrintApp.ObtenerCierreX -= _ObtenerCierreX;
            Device.BeginInvokeOnMainThread(async () =>
            {

                if (respuesta.EstadoRespuesta == PrintEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", "No se encontró cierre X", "Aceptar");
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

                        string URL = await DependencyService.Get<IFeatureService>().SaveFile("ReporteX", base64encodepdf);
                        PdfDocView.Uri = URL;
                        busyindicator.IsVisible = false;
                    }

                }

            });
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (this.Width > 0)
            {
                pdfStack.HeightRequest = this.Height;

            }
        }
        private void IrAlInicio(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new ReporteCierreX());
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            App.Current.MainPage = new NavigationPage(new ReporteCierreX());
            return true;
        }
    }
}