using ITBCP.ServiceSIGES.Domain.Entities.Reimpresion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Prints;
using TerminalSiges.Lib.Sales;
using TerminalSiges.Views.Pages.Invoce;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Print
{

    public partial class ReImpresionCompleted : ContentPage
    {
        public bool Cargado = false;
        private TS_BEDocumentoInput DocumentoInput;
        public ReImpresionCompleted(TS_BEDocumentoInput input)
        {
            DocumentoInput = input;
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) return;
            Cargado = true;
            TSPrintApp.Cdtipodoc = DocumentoInput.cdtipodoc;
            TSPrintApp.Nrodocumento = DocumentoInput.nrodocumento;
            TSPrintApp.NroSerieMaq = DocumentoInput.nroseriemaq;
            TSPrintApp.NroPos = DocumentoInput.nropos;
            TSPrintApp.imprimir = DocumentoInput.imprimir;
            TSPrintApp.fecha = DocumentoInput.fecha;
            PrintEstado resultado = PrintEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TSPrintApp.ReimprimirDocumentos += _ReImprimirDocumento;
                resultado = TSPrintApp.ProcesaReImprimirDocumento().Result;
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
        private void _ReImprimirDocumento(TSPrint respuesta)
        {
            TSPrintApp.ReimprimirDocumentos -= _ReImprimirDocumento;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == PrintEstado.ImpresionIncorrecto)
                {
                    await DisplayAlert("Aviso", "Ocurrio un error al imprimir", "Aceptar");
                    await Navigation.PopAsync();
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    await Navigation.PopAsync();
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.ImpresionCorrecto)
                {
                    await Navigation.PopAsync();
                    return;
                }

            });
        }
        public async void IrAlInicio(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            Navigation.PopAsync();
            return true;
        }
    }
}