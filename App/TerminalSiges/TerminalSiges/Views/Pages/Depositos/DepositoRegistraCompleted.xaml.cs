using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Prints;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Depositos
{
    public partial class DepositoRegistraCompleted : ContentPage
    {
        public bool Cargado = false;
        public delegate void Completed();
        public event Completed Grabado;
        public DepositoRegistraCompleted()
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
                TSPrintApp.RegistraDepositos += TSPrintApp_RegistraDepositos; ;
                resultado = TSPrintApp.ProcesaRegistra().Result;
            });
            if (resultado != PrintEstado.EsperandoRespuesta)
            {

                switch (resultado)
                {
                    case PrintEstado.ErrorInternet:
                        await DisplayAlert("Aviso", "Su dispositivo no cuenta con internet en estos momentos.", "Aceptar");
                        await Navigation.PopAsync();
                        break;
                    case PrintEstado.ErrorSistema:
                        await DisplayAlert("Aviso", "Hubo un problema de comunicación con el servidor, por favor intente después.", "Aceptar");
                        await Navigation.PopAsync();
                        break;
                }
            }
        }

        private void TSPrintApp_RegistraDepositos(TSPrint respuesta)
        {
            TSPrintApp.RegistraDepositos -= TSPrintApp_RegistraDepositos;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == PrintEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    await Navigation.PopAsync();
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionObtenida)
                {
                    await DisplayAlert("Aviso", "Se guardaron los cambios correctamente", "Aceptar");
                    await Navigation.PopAsync();
                    Grabado();
                    return;

                }
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", respuesta.vMensaje.mensaje, "Aceptar");
                    await Navigation.PopAsync();
                    return;
                }

            });
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }
    }
}