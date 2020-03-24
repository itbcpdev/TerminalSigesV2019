using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Prints;
using TerminalSiges.Lib.Sales;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Print
{

    public partial class InicioDeDiaCompleted : ContentPage
    {
        public bool Cargado = false;
        private string cdusuario { get; set; }
        public InicioDeDiaCompleted(string cdusuario)
        {
            InitializeComponent();
            this.cdusuario = cdusuario;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (Cargado) return;
            Cargado = true;
            PrintEstado resultado = PrintEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TSPrintApp.ObtenerInicioDia += TSPrintApp_ObtenerInicioDia;
                resultado = TSPrintApp.ProcesaIncioDia(cdusuario).Result;
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



        private void TSPrintApp_ObtenerInicioDia(TSPrint respuesta)
        {
            TSPrintApp.ObtenerInicioDia -= TSPrintApp_ObtenerInicioDia;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == PrintEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionObtenida)
                {
                    if (respuesta.vInicioDia.Mensaje.Ok == false)
                    {
                        await DisplayAlert("Aviso", respuesta.vInicioDia.Mensaje.mensaje, "Aceptar");
                        App.Current.MainPage = new Home();
                        return;
                    }
                    else
                    {
                        IndicadorDeCarga.IsVisible = false;
                        Grilla.IsVisible = true;
                        TSSalesApp.vTerminal = respuesta.vInicioDia.vTerminal;
                    }


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