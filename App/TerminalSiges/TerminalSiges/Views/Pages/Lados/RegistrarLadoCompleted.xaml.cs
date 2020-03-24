using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Sales;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Lados
{

    public partial class RegistrarLadoCompleted : ContentPage
    {
        private bool Cargado = false;
        private string lado;
        private string nropos;

        public delegate void Completado();
        public event Completado Guardado;
        public RegistrarLadoCompleted(string lado,string nropos)
        {
            this.lado = lado;
            this.nropos = nropos;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) { return; }
            Cargado = true;
            RegistrarLadoInicio(lado, nropos);
        }

        public async void RegistrarLadoInicio(string lado, string nropos)
        {

            SalesEstado resultado = SalesEstado.ErrorSistema;
            await Task.Run(delegate
            {
                TSSalesApp.RegistrarLado += _RegistrarLado;
                resultado = TSSalesApp._RegistrarLado(nropos, lado).Result;
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

        private void _RegistrarLado(TSSales respuesta)
        {
            TSSalesApp.RegistrarLado -= _RegistrarLado;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta != SalesEstado.InformacionObtenida)
                {
                    await DisplayAlert("Aviso", "Ocurrió un error al cargar Nro de Pos", "Aceptar");
                    await Navigation.PopAsync();
                    return;
                }
                if (respuesta.EstadoRespuesta == SalesEstado.InformacionObtenida)
                {
                    await DisplayAlert("Aviso", "Se guardó correctamente los cambios", "Aceptar");
                    await Navigation.PopAsync();
                    Guardado();
                }
                if (respuesta.EstadoRespuesta == SalesEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", respuesta.vMensaje.mensaje, "Aceptar");
                    await Navigation.PopAsync();
                    return;
                }

            });
        }
        private void OnReportes(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new ReporteLados());
        }
        private async void IrAlInicio(object sender, EventArgs e)
        {
            App.Current.MainPage = (new LoginLados(true));
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            App.Current.MainPage = (new LoginLados(true));
            return true;
        }
    }
}