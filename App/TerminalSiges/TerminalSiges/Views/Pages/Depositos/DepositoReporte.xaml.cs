using ITBCP.ServiceSIGES.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Prints;
using TerminalSiges.Lib.Sales;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace TerminalSiges.Views.Pages.Depositos
{
    public partial class DepositoReporte : ContentPage
    {
        public bool Cargado = false;
        private TS_BEDeposito itemIndex = null;
        private Image rightImage;

        public DepositoReporte()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) return;
            ObtenerReportesDepositos();

        }
        private async void ObtenerReportesDepositos()
        {
            PrintEstado resultado = PrintEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TSPrintApp.ObtenerDepositos += _TSPrintApp_ObtenerDepositos;
                resultado = TSPrintApp.ObtenerReporteDepositos().Result;
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
            TSPrintApp.ObtenerDepositos -= _TSPrintApp_ObtenerDepositos;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == PrintEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionObtenida)
                {
                    if (respuesta.vDepositos.cDepositos.Length > 0)
                    {

                        this.listView.ItemsSource = respuesta.vDepositos.cDepositos;
                        this.listView.HeightRequest = respuesta.vDepositos.cDepositos.Count() * (this.listView.ItemSize + 1);
                        decimal soles = 0;
                        decimal dolares = 0;
                        foreach (var item in respuesta.vDepositos.cDepositos)
                        {
                            soles += item.mtosoles;
                            dolares += item.mtodolares;
                        }

                        this.txtTotalSoles.Text = soles.ToString();
                        this.txtTotalDolares.Text = dolares.ToString();
                        this.gridSinDepositos.IsVisible = false;
                        this.gridConDepositos.IsVisible = true;
                        this.frmlista.IsVisible = true;
                    }
                    else
                    {

                        this.txtTotalSoles.Text = "0.00";
                        this.txtTotalDolares.Text = "0.00";
                        this.gridSinDepositos.IsVisible = true;
                        this.gridConDepositos.IsVisible = false;
                        this.frmlista.IsVisible = false;

                    }
                    this.busyindicator.IsVisible = false;
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

                TSPrintApp.nroDeposito = itemIndex.nrodeposito;
                TSPrintApp.turno = itemIndex.turno.ToString();
                TSPrintApp.NroPos = itemIndex.nropos;
                this.busyindicator.IsVisible = true;
                PrintEstado resultado = PrintEstado.ErrorSistema;
                await Task.Run(()=>
                {
                    TSPrintApp.EliminaDepositos += TSPrintApp_EliminaDepositos;
                    resultado = TSPrintApp.ProcesaEliminarDeposito().Result;
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

        private void TSPrintApp_EliminaDepositos(TSPrint respuesta)
        {
            TSPrintApp.EliminaDepositos -= TSPrintApp_EliminaDepositos;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == PrintEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionObtenida)
                {

                    ObtenerReportesDepositos();
                    this.busyindicator.IsVisible = false;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", respuesta.vMensaje.mensaje, "Aceptar");
                    App.Current.MainPage = new Home();
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
            itemIndex = (TS_BEDeposito)e.ItemData;
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