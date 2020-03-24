using ITBCP.ServiceSIGES.Domain.Entities;
using System;
using System.Threading.Tasks;
using TerminalSiges.Helpers;
using TerminalSiges.Lib.Sales;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Lados
{
 
    public partial class RegistrarLados : ContentPage
    {
        private bool Cargado = false;
        public RegistrarLados()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) return;
            Cargado = true;
            SalesEstado resultado = SalesEstado.ErrorSistema;
            await Task.Run(delegate
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
                    cboPuntoVenta.DataSource = respuesta.vNroPos;
                    return;
                }

            });
        }



        public async void BtnSave_Clicked(object sender, EventArgs e)
        {
            string lado = txtLado.Text;
            string nropos = cboPuntoVenta.SelectedItem == null ? null : ((TS_BENropos)cboPuntoVenta.SelectedItem).nropos;
            if (nropos == null)
            {
                await DisplayAlert("Aviso", "Seleccione el punto de venta asociado", "Aceptar");
                return;
            }
            RegistrarLadoCompleted Vista = new RegistrarLadoCompleted(lado, nropos);
            Vista.Guardado += Vista_Guardado;
            await Navigation.PushAsync(Vista);
        }

        private async void Vista_Guardado()
        {
            await Navigation.PopAsync();
        }
    }
}