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

    public partial class PrintCierreZCompleted : ContentPage
    {
        public bool Cargado = false;
        public PrintCierreZCompleted()
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
                TSPrintApp.ObtenerCierreZ += _ObtenerCierreZ;
                resultado = TSPrintApp.ObtenerReporteCierreZ().Result;
            });
            if (resultado != PrintEstado.EsperandoRespuesta)
            {

                switch (resultado)
                {
                    case PrintEstado.ErrorInternet:
                        await DisplayAlert("Aviso", "Su dispositivo no cuenta con internet en estos momentos.", "Aceptar");
                        App.Current.MainPage = new NavigationPage(new ReporteCierreZ());
                        break;
                    case PrintEstado.ErrorSistema:
                        await DisplayAlert("Aviso", "Hubo un problema de comunicación con el servidor, por favor intente después.", "Aceptar");
                        App.Current.MainPage = new NavigationPage(new ReporteCierreZ());
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
                    await DisplayAlert("Aviso", respuesta.vRespuesta.respuesta, "Aceptar");
                    App.Current.MainPage = new NavigationPage(new ReporteCierreZ());
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    App.Current.MainPage = new NavigationPage(new ReporteCierreZ());
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionObtenida)
                {
                    App.Current.MainPage = new NavigationPage(new ReporteCierreZ());
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
            App.Current.MainPage = new NavigationPage(new ReporteCierreZ());
            return true;
        }
    }
}