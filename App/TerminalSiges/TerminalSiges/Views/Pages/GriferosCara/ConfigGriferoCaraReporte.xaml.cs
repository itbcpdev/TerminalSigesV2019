using ITBCP.ServiceSIGES.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Prints;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.GriferosCara
{
    public partial class ConfigGriferoCaraReporte : ContentPage
    {
        public bool Cargado = false;
        Image rightImage;
        TS_BELado itemIndex = null;
        public ConfigGriferoCaraReporte()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) return;
            ObtenerReporteGriferoCara();

        }
        private async void ObtenerReporteGriferoCara()
        {
            PrintEstado resultado = PrintEstado.ErrorSistema;
            await Task.Run(delegate
            {
                TSPrintApp.ObtenerGriferoCara += _TSPrintApp_ObtenerDepositos;
                resultado = TSPrintApp.ReporteGriferoCara().Result;
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
        private void _TSPrintApp_ObtenerDepositos(TSPrint respuesta)
        {
            TSPrintApp.ObtenerGriferoCara -= _TSPrintApp_ObtenerDepositos;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == PrintEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionObtenida)
                {
                    if (respuesta.vGriferoCara.cLados.Length > 0)
                    {
                        this.listView.ItemsSource = respuesta.vGriferoCara.cLados;
                        listView.HeightRequest = respuesta.vGriferoCara.cLados.Count() * (listView.ItemSize + 1);

                        gridSinDepositos.IsVisible = false;
                        gridConDepositos.IsVisible = true;
                        frmlista.IsVisible = true;
                    }
                    else
                    {


                        gridSinDepositos.IsVisible = true;
                        gridConDepositos.IsVisible = false;
                        frmlista.IsVisible = false;

                    }
                    busyindicator.IsVisible = false;
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", respuesta.vDepositos.cMensaje.mensaje, "Aceptar");
                    return;
                }

            });
        }
        private async void Delete()
        {
            if (itemIndex != null)
            {
                TSPrintApp.Lado = itemIndex.lado;
                TSPrintApp.NroPos = itemIndex.nropos;
                busyindicator.IsVisible = true;
                PrintEstado resultado = PrintEstado.ErrorSistema;
                await Task.Run(delegate
                {
                    TSPrintApp.EliminarGriferoCara += TSPrintApp_EliminarGriferoCara;
                    resultado = TSPrintApp.ProcesaEliminarGriferoCara().Result;
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
            this.listView.ResetSwipe();
        }

        private void TSPrintApp_EliminarGriferoCara(TSPrint respuesta)
        {
            TSPrintApp.EliminarGriferoCara -= TSPrintApp_EliminarGriferoCara;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == PrintEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionObtenida)
                {
                    ObtenerReporteGriferoCara();
                    busyindicator.IsVisible = false;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", respuesta.vMensaje.mensaje, "Aceptar");
                    return;
                }

            });
        }

        private void ListView_SwipeStarted(object sender, Syncfusion.ListView.XForms.SwipeStartedEventArgs e)
        {
            itemIndex = null;
        }

        private void ListView_SwipeEnded(object sender, Syncfusion.ListView.XForms.SwipeEndedEventArgs e)
        {
            itemIndex = (TS_BELado)e.ItemData;
        }
        private void rightImage_BindingContextChanged(object sender, EventArgs e)
        {
            if (rightImage == null)
            {
                rightImage = sender as Image;
                (rightImage.Parent as View).GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Delete) });
                rightImage.Source = "Delete.png";
            }
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

    }
}