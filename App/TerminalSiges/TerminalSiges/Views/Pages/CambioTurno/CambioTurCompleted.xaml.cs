using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Prints;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.CambioTurno
{
    public partial class CambioTurCompleted : ContentPage
    {
        public bool Cargado = false;
        public CambioTurCompleted()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (Cargado) return;
            Cargado = true;
            PrintEstado resultado = PrintEstado.ErrorSistema;
            await Task.Run(delegate
            {
                TSPrintApp.ObtenerCambioTurno += _TSPrintApp_ObtenerCambioTurno;
                resultado = TSPrintApp.ProcesaCambioTurno().Result;
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

        private void _TSPrintApp_ObtenerCambioTurno(TSPrint respuesta)
        {
            TSPrintApp.ObtenerCambioTurno -= _TSPrintApp_ObtenerCambioTurno;
            Device.BeginInvokeOnMainThread(async () =>
            {

                if (respuesta.EstadoRespuesta == PrintEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionObtenida)
                {
                    this.IndicadorDeCarga.IsVisible = false;
                    this.Grilla.IsVisible = true;

                }
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", respuesta.vMensaje.mensaje, "Aceptar");
                    App.Current.MainPage = new Home();
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
            App.Current.MainPage = (new Home());
            return true;
        }
    }
}