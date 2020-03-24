using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Prints;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Print
{

    public partial class PrintCierreXCompleted : ContentPage
    {
        public bool Cargado = false;
        public PrintCierreXCompleted()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) return;

            Cargado = true;
            TSPrintApp.ig_bloque_playa = false;
            TSPrintApp.imprimir = true;
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
                        App.Current.MainPage = new NavigationPage(new ReporteCierreX());
                        break;
                    case PrintEstado.ErrorSistema:
                        await DisplayAlert("Aviso", "Hubo un problema de comunicación con el servidor, por favor intente después.", "Aceptar");
                        App.Current.MainPage = new NavigationPage(new ReporteCierreX());
                        break;
                }
            }

        }
        private void _ObtenerCierreX(TSPrint respuesta)
        {
            TSPrintApp.ObtenerCierreX -= _ObtenerCierreX;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", respuesta.vRespuesta.respuesta, "Aceptar");
                    App.Current.MainPage = new NavigationPage(new ReporteCierreX());
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    App.Current.MainPage = new NavigationPage(new ReporteCierreX());
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionObtenida)
                {
                    App.Current.MainPage = new NavigationPage(new ReporteCierreX());
                    return;
                }

            });
        }
        private void IrAlInicio(object sender, EventArgs e)
        {
            App.Current.MainPage = (new Home());
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            App.Current.MainPage = new NavigationPage(new ReporteCierreX());
            return true;
        }
    }
}