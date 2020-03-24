using ITBCP.ServiceSIGES.Domain.Entities.Reimpresion;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using TerminalSiges.Lib.Autenticate;
using TerminalSiges.Lib.Prints;
using TerminalSiges.Lib.Sales;
using TerminalSiges.Views.Pages.PopUp;
using TerminalSiges.Views.Pages.Print;
using Xamarin.Forms;

namespace TerminalSiges.Views.Pages.Invoce
{

    public partial class ConsultaDocuments : ContentPage
    {
        public bool Cargado = false;
        public bool IsEvent = false;

        TS_BEReimpresionL itemIndex = null;
        Image leftImage;
        Image rightImage;
        public ConsultaDocuments()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) return;
            cboDocuments.DataSource = TSSalesApp.vTipoDocuments;
        }
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private async void getDocuments()
        {
            TSPrintApp.NroPos = TSSalesApp.vTerminal.nropos;
            TSPrintApp.Cdtipodoc = ((TipoComprobate)this.cboDocuments.SelectedItem).Nro;
            TSPrintApp.Nrodocumento = this.txtCodigoDescription.Text;
            PrintEstado resultado = PrintEstado.ErrorSistema;
            busyindicator.IsVisible = true;
            await Task.Run(() =>
            {
                TSPrintApp.ListarDocumentos += TSPrintApp_ListarDocumentos;
                resultado = TSPrintApp.ObtenerListarDocumentos().Result;
            });
            if (resultado != PrintEstado.EsperandoRespuesta)
            {
                busyindicator.IsVisible = false;
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
        private async void BtnSearcDocuments_Clicked(object sender, EventArgs e)
        {
            if (txtCodigoDescription.Text == null)
            {
                await DisplayAlert("Aviso", "Ingrese número de documento.", "Aceptar");
                return;
            }
            if (this.cboDocuments.SelectedItem == null)
            {
                await DisplayAlert("Aviso", "Debe seleccionar el tipo de documento", "Aceptar");
                return;
            }
            getDocuments();

        }

        private void TSPrintApp_ListarDocumentos(TSPrint respuesta)
        {
            TSPrintApp.ListarDocumentos -= TSPrintApp_ListarDocumentos;
            Device.BeginInvokeOnMainThread(async () =>
            {

                busyindicator.IsVisible = false;
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionObtenida)
                {
                    this.listView.ItemsSource = respuesta.vReImpresion.Documentos;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", respuesta.vReImpresion.Mensaje.mensaje, "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == PrintEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
            });
        }
        private async void Delete()
        {
            if (itemIndex != null)
            {
                if (itemIndex.anulado)
                {
                    await DisplayAlert("Aviso", "Documento ya se encuentra anulado.", "Aceptar");
                    return;
                }
                if (TSSalesApp.vUsuarioActual == null)
                {
                    await DisplayAlert("Aviso", "Error en la validacion de permisos de usuario, por favor intente mas tarde", "Aceptar");
                    return;
                }
                if (TSSalesApp.vUsuarioActual.flganular == false)
                {
                    var Respuesta = await DisplayAlert("Aviso", "Usted no posee permisos suficientes para anular este documento\nDebe iniciar sesión", "Iniciar Sesión", "Salir");
                    if (Respuesta)
                    {
                        LoginPopUp Vista = new LoginPopUp();
                        Vista.LoginResponseEvent += Vista_LoginResponse;
                        await PopupNavigation.Instance.PushAsync(Vista);
                    }
                    return;
                }
                AnularDocumento(false);
            }
        }

        private void Vista_LoginResponse(LoginEstado respuesta, bool PermisoAnular)
        {
            Device.BeginInvokeOnMainThread(async () => {

                if (respuesta == LoginEstado.Autorizacion)
                {
                    if (PermisoAnular)
                    {
                        AnularDocumento(true);
                    }
                    else
                    {
                        await DisplayAlert("Aviso", "Usted no posee permisos para anular", "Aceptar");
                    }

                }
                else
                {
                    await DisplayAlert("Aviso", "No se pudo verificar la identidad del usuario intente mas tarde", "Aceptar");
                }
            });

        }

        private async void AnularDocumento(bool IsAnularLoginPopUp)
        {
            var result = await DisplayAlert("Aviso", "¿Desea anular el documento?", "Si", "No");
            if (result)
            {
                if (itemIndex == null)
                {
                    await DisplayAlert("Aviso", "Hubo un error al realizar la busqueda del documento a anular por favor intente mas tarde", "Aceptar");
                    return;
                }
                TSSalesApp.TipoDocumento = itemIndex.cdtipodoc;
                TSSalesApp.NroDocumento = itemIndex.nrodocumento;
                TSSalesApp.NroPos = itemIndex.nropos;
                TSSalesApp.fact_electronica = Convert.ToBoolean(1);
                TSSalesApp.NroSerieMaq = itemIndex.nroseriemaq;
                busyindicator.IsVisible = true;
                SalesEstado resultado = SalesEstado.ErrorSistema;
                await Task.Run(() =>
                {
                    TSSalesApp.EliminarDocumentos += TSSalesApp_EliminarDocumentos;
                    resultado = TSSalesApp.ProcesarEliminarDocumento().Result;
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
            else
            {
                return;
            }
        }
        private void TSSalesApp_EliminarDocumentos(TSSales respuesta)
        {
            TSSalesApp.EliminarDocumentos -= TSSalesApp_EliminarDocumentos;
            Device.BeginInvokeOnMainThread(async () =>
            {
                busyindicator.IsVisible = false;
                if (respuesta.EstadoRespuesta == SalesEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == SalesEstado.RegistroEliminado)
                {
                    getDocuments();
                    await DisplayAlert("Aviso", "Se anuló satisfactoriamente el documento.", "Aceptar");

                    return;

                }
                if (respuesta.EstadoRespuesta == SalesEstado.RegistroNoEliminado)
                {
                    await DisplayAlert("Aviso", "Ocurrio un problema al eliminar.", "Aceptar");
                    return;
                }

            });
        }
        private async void Print()
        {
            if (itemIndex != null)
            {
                TS_BEDocumentoInput documento = new TS_BEDocumentoInput();
                documento.nroseriemaq = itemIndex.nroseriemaq;
                documento.cdtipodoc = itemIndex.cdtipodoc;
                documento.nrodocumento = itemIndex.nrodocumento;
                documento.nropos = itemIndex.nropos;
                documento.fecha = itemIndex.fecha;
                documento.imprimir = true;
                await Navigation.PushAsync(new ReImpresionCompleted(documento));
            }
        }



        private void ListView_SwipeStarted(object sender, Syncfusion.ListView.XForms.SwipeStartedEventArgs e)
        {
            itemIndex = null;
        }

        private void ListView_SwipeEnded(object sender, Syncfusion.ListView.XForms.SwipeEndedEventArgs e)
        {
            itemIndex = (TS_BEReimpresionL)e.ItemData;
        }

        private void leftImage_BindingContextChanged(object sender, EventArgs e)
        {
            if (leftImage == null)
            {
                leftImage = sender as Image;
                (leftImage.Parent as View).GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Print) });
                leftImage.Source = "printer.png";
            }
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
        private void ListService_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
        }

    }
}