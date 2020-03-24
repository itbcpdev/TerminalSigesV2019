using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Prints;
using TerminalSiges.Lib.Sales;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Invoce
{

    public partial class ReImpresion : ContentPage
    {
        private BindingContextReimpresion contexto;
        public bool IsEvent = false;
        public ReImpresion()
        {
            contexto = new BindingContextReimpresion();
            InitializeComponent();
            BindingContext = contexto;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (contexto.IsLoaded) return;
            contexto.IsLoaded = true;

            TSPrintApp.imprimir = true;
            TSPrintApp.NroPos = TSSalesApp.vTerminal.nropos;

            PrintEstado resultado = PrintEstado.ErrorSistema;
            await Task.Run(()=>
            {
                TSPrintApp.UltimoDocumento += _ImprimirUltimoDoc;
                resultado = TSPrintApp.ProcesaReImpresionUltimoDocumento().Result;
            });
            if (resultado != PrintEstado.EsperandoRespuesta)
            {

                switch (resultado)
                {
                    case PrintEstado.ErrorInternet:
                        contexto.IsSearchEnd("Su dispositivo no cuenta con internet en estos momentos.");
                        break;
                    case PrintEstado.ErrorSistema:
                        contexto.IsSearchEnd("Hubo un problema de comunicación con el servidor, por favor intente después.");
                        break;
                }
            }

        }
        private void _ImprimirUltimoDoc(TSPrint respuesta)
        {
            TSPrintApp.UltimoDocumento -= _ImprimirUltimoDoc;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == PrintEstado.ImpresionIncorrecto)
                {
                    contexto.IsSearchEnd("Ocurrio un error al imprimir");
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.ErrorSistema)
                {
                    contexto.IsSearchEnd("Hubo un problema en la comunicación con el servidor, por favor intente después.");
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.ImpresionCorrecto)
                {
                    if (IsEvent) { await Navigation.PopAsync(); return; }
                    App.Current.MainPage = new NavigationPage(new SemiAutomatic());
                    return;
                }

            });
        }
        public async void IrAlInicio(object sender, EventArgs e)
        {
            if (IsEvent) { await Navigation.PopAsync(); return; }
            App.Current.MainPage = new NavigationPage(new SemiAutomatic());
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            if (IsEvent) { Navigation.PopAsync(); return true; }
            App.Current.MainPage = new NavigationPage(new SemiAutomatic());
            return true;
        }
    }
    public class BindingContextReimpresion : INotifyPropertyChanged
    {
        private bool isComplete;
        private string message;
        private bool isLoading;
        private bool isLoaded;

        public BindingContextReimpresion()
        {
            isComplete = false;
            message = "";
            isLoading = true;
            isLoaded = false;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public bool IsComplete
        {
            get { return isComplete; }
            set
            {
                isComplete = value;
                OnPropertyChanged();
            }
        }

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }

        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                isLoading = value;
                OnPropertyChanged();
            }
        }
        public bool IsLoaded
        {
            get { return isLoaded; }
            set
            {
                isLoaded = value;
                OnPropertyChanged();
            }
        }
        public void IsSearchEnd(string message)
        {
            IsLoading = false;
            IsComplete = true;
            Message = message;
        }
    }
}