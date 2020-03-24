using ITBCP.ServiceSIGES.Domain.Entities;
using Matcha.BackgroundService;
using Rg.Plugins.Popup.Services;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TerminalSiges.Lib.Sales;
using TerminalSiges.Views.Pages.Customer;
using TerminalSiges.Views.Pages.Payment;
using TerminalSiges.Views.Pages.PopUp;
using TerminalSIGES.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Invoce
{

    public partial class Automatic : ContentPage
    {
        private bool OnPlay = false;
        private bool isCarasSearch = false;
        private Image leftImage;
        private Image rightImage;
        private Lado itemIndex = null;
        private string titulo;
        public Automatic()
        {
            InitializeComponent();
            
            this.ImageSourceButton.Source = "play.png";
            this.BindingContext = TSSalesApp.AutomaticContext;
       

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            TSSalesApp.AutomaticContext.Titulo = ("FACTURACIÓN -  " + (TSSalesApp.vTerminal.nropos ?? "").Trim() + ", Turno: " + TSSalesApp.vTerminal.turno + ", VENDEDOR:" + (TSSalesApp.vVendedor.dsvendedor ?? "").Trim()).ToUpper();
            SalesCaras();
            isCarasSearch = true; 
        }
        private void PlayAndPause(object sender, EventArgs e)
        {
            var Button = (SfButton)sender;
            Estado value = (Estado)Button.CommandParameter;
            TSSalesApp.AutomaticContext.AutomaticChangeStatus(value.cara);
        }
        private async void AddItem(object sender, EventArgs e)
        {
            var Button = (SfButton)sender;
            Button.IsEnabled = false;
            var value = (Estado)Button.CommandParameter;

            TSSalesApp.AutomaticContext.AutomaticStopped(value.cara);
            
            PopUpDocumento Vista = new PopUpDocumento(value.cara);
            Vista.SaveEvent += OnDocumentSelect;
            await PopupNavigation.Instance.PushAsync(Vista);

            Button.IsEnabled = true;
        }

        private async void OnDocumentSelect(EDocumento respuesta, string lado)
        {
            Lado SCara = null;

            foreach (Lado Cara in TSSalesApp.AutomaticContext.Productos)
            {
                if (Cara.Cara.Equals(lado))
                {
                    SCara = Cara;
                }
            }

            if (respuesta == EDocumento.BoletaFactura)
            {
                SearchCustomerAutomatic Busqueda = new SearchCustomerAutomatic();
                Busqueda.SaveEvent += Busqueda_SaveEvent;
                Busqueda.Lado.Cara = lado;
                Busqueda.Lado.Documento = EDocumento.BoletaFactura;
                Busqueda.LoadConfiguration();
                
                if(SCara != null)
                {
                    Busqueda.contexto.Codigo_cliente = SCara.Codigo;
                    Busqueda.contexto.Placa = SCara.Placa;
                    Busqueda.contexto.Razon_social_cliente = SCara.RazonSocial;
                    Busqueda.contexto.Correo = SCara.Correo;
                    Busqueda.contexto.Tarjeta_afiliacion_cliente = SCara.Tarjeta_afiliacion;
                    Busqueda.contexto.Direccion_cliente = SCara.Direccion;
                }


                await Navigation.PushModalAsync(new NavigationPage(Busqueda));
                return;
            }
            if (respuesta == EDocumento.NotaDespacho)
            {
                CreditSales Credito = new CreditSales();
                Credito.IsEvent = true;
                Credito.Cara = lado;
                Credito.SaveEvent += Credito_SaveEvent;
                await Navigation.PushAsync(Credito);
                return;
            }
            if (respuesta == EDocumento.Serafin)
            {
                Busqueda_SaveEvent(new Lado()
                {
                    Cara = lado,
                    Codigo = "",
                    Ruc = "",
                    RazonSocial = "",
                    Correo = "",
                    Direccion = "",
                    Placa = "",
                    Odometro = "",
                    Chofer = "",
                    Tarjeta_afiliacion = "",
                    Tarjeta = "",
                    Pago = "SERAFIN",
                    Pagos = new ObservableCollection<Pago>(),
                    Telefono = "",
                    Marca = "",
                    Modelo = "",
                    Fecha_Nacimiento = null,
                    Documento = EDocumento.Serafin
                });
                return;
            }
            if (respuesta == EDocumento.TranferenciaGratuita)
            {
                SearchCustomerAutomatic Busqueda = new SearchCustomerAutomatic();
                Busqueda.SaveEvent += Busqueda_SaveEvent;
                Busqueda.Lado.Cara = lado;
                Busqueda.Lado.Documento = EDocumento.TranferenciaGratuita;
                Busqueda.LoadConfiguration();
                if (SCara != null)
                {
                    Busqueda.contexto.Codigo_cliente = SCara.Codigo;
                    Busqueda.contexto.Placa = SCara.Placa;
                    Busqueda.contexto.Razon_social_cliente = SCara.RazonSocial;
                    Busqueda.contexto.Correo = SCara.Correo;
                    Busqueda.contexto.Tarjeta_afiliacion_cliente = SCara.Tarjeta_afiliacion;
                    Busqueda.contexto.Direccion_cliente = SCara.Direccion;
                }

                await Navigation.PushModalAsync(new NavigationPage(Busqueda));
                return;
            }
            if (respuesta == EDocumento.Canje)
            {
                SearchCustomerAutomatic Busqueda = new SearchCustomerAutomatic();
                Busqueda.SaveEvent += Busqueda_SaveEvent;
                Busqueda.Lado.Cara = lado;
                Busqueda.Lado.Documento = EDocumento.Canje;
                Busqueda.LoadConfiguration();
                if (SCara != null)
                {
                    Busqueda.contexto.Codigo_cliente = SCara.Codigo;
                    Busqueda.contexto.Placa = SCara.Placa;
                    Busqueda.contexto.Razon_social_cliente = SCara.RazonSocial;
                    Busqueda.contexto.Correo = SCara.Correo;
                    Busqueda.contexto.Tarjeta_afiliacion_cliente = SCara.Tarjeta_afiliacion;
                    Busqueda.contexto.Direccion_cliente = SCara.Direccion;
                }

                await Navigation.PushModalAsync(new NavigationPage(Busqueda));
                return;
            }

        }

        private void Credito_SaveEvent(Lado respuesta)
        {
            foreach (Lado lado in TSSalesApp.AutomaticContext.Productos)
            {
                if (lado.Cara.Equals(respuesta.Cara))
                {
                    lado.Codigo = respuesta.Codigo;
                    lado.Ruc = respuesta.Ruc;
                    lado.RazonSocial = respuesta.RazonSocial;
                    lado.Correo = respuesta.Correo;
                    lado.Direccion = respuesta.Direccion;
                    lado.Placa = respuesta.Placa;
                    lado.Odometro = respuesta.Odometro;
                    lado.Chofer = respuesta.Chofer;
                    lado.Tarjeta_afiliacion = respuesta.Tarjeta_afiliacion;
                    lado.Tarjeta = respuesta.Tarjeta;
                    lado.Pago = respuesta.Pago;
                    lado.Pagos.Clear();
                    lado.Telefono = respuesta.Telefono;
                    lado.Marca = respuesta.Marca;
                    lado.Modelo = respuesta.Modelo;
                    lado.Fecha_Nacimiento = respuesta.Fecha_Nacimiento;
                    lado.Documento = respuesta.Documento;
                }
            }
        }

        private void Busqueda_SaveEvent(Lado respuesta)
        {
            foreach(Lado lado in TSSalesApp.AutomaticContext.Productos)
            {
                if (lado.Cara.Equals(respuesta.Cara))
                {
                    lado.Codigo = respuesta.Codigo;
                    lado.Ruc = respuesta.Ruc;
                    lado.RazonSocial = respuesta.RazonSocial;
                    lado.Correo = respuesta.Correo;
                    lado.Direccion = respuesta.Direccion;
                    lado.Placa = respuesta.Placa;
                    lado.Odometro = respuesta.Odometro;
                    lado.Chofer = respuesta.Chofer;
                    lado.Tarjeta_afiliacion = respuesta.Tarjeta_afiliacion;
                    lado.Pago = respuesta.Pago;
                    lado.Pagos = respuesta.Pagos;
                    lado.Telefono = respuesta.Telefono;
                    lado.Tarjeta = "";
                    lado.Marca = respuesta.Marca;
                    lado.Modelo = respuesta.Modelo;
                    lado.Fecha_Nacimiento = respuesta.Fecha_Nacimiento;
                    lado.Documento = respuesta.Documento;
                }
            }
        }

        private void OnPlayStart(object sender,EventArgs e)
        {
            if (OnPlay)
            {
                OnPlay = false;
                TSSalesApp.AutomaticContext.AutomaticAllStop();
                this.ImageSourceButton.Source = "play.png";
            }
            else
            {
                OnPlay = true;
                TSSalesApp.AutomaticContext.AutomaticAllStart();
                this.ImageSourceButton.Source = "pause.png"; 
            }
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            //Vertical
            if (height > width)
            {
                HElement1.Orientation = StackOrientation.Vertical;
            }
            //Horizontal
            else
            {
                HElement1.Orientation = StackOrientation.Horizontal;
            }

        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new NavigationPage(new Home());
            return true;
        }

        public async void SalesCaras()
        {
            if (isCarasSearch) { return; }
            SalesEstado resultado = SalesEstado.ErrorSistema;
            await Task.Run(()=>
            {
                TSSalesApp.SalesCaras += _SalesCaras;
                resultado = TSSalesApp.ObtenerCaras().Result;
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

        private void _SalesCaras(TSSales respuesta)
        {
            TSSalesApp.SalesCaras -= _SalesCaras;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == SalesEstado.ErrorSistema || respuesta.EstadoRespuesta == SalesEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == SalesEstado.InformacionObtenida)
                {
                    if (respuesta.vCaras == null) { return; }
                    TSSalesApp.AutomaticContext.Productos.Clear();
                    foreach (TS_BECara cara in respuesta.vCaras)
                    {
                        TSSalesApp.AutomaticContext.Productos.Add(new Lado() {
                            Cara = cara.cara,
                            Codigo = "",
                            Ruc = "",
                            RazonSocial = "",
                            Correo = "",
                            Direccion = "",
                            Placa = "",
                            Odometro = "",
                            Chofer = "",
                            Tarjeta_afiliacion = "",
                            Documento = EDocumento.BoletaFactura,
                            Pago = "EFECTIVO",
                            Mensaje="",
                            Pagos = new ObservableCollection<Pago>(),
                            Estado = new Estado(cara.cara, false)
                        }); 
                    }
                }
            });
        }
        public void SendPrueba(object Sender,EventArgs e)
        {
            foreach (Lado lado in TSSalesApp.AutomaticContext.Productos)
            {

                    lado.Mensaje = "PRUEBA DE ERROR EL LADO: " + lado.Cara;

                
            }
        }

        private async void BtnDocument_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConsultaDocuments() { IsEvent = true});
        }
        private async void BtnReImpresion_OnClicked(object sender, EventArgs e)
        {
            await ScrollCliente.ScrollToAsync(0, 0, false);
            TSSalesApp.AutomaticContext.MostrarTituloCliente();
            /*await Navigation.PushAsync(new ReImpresion() { IsEvent = true }); */
        }
        private async void CloseWindows(object sender, EventArgs e)
        {
            TSSalesApp.AutomaticContext.MostrarTituloFacturacion();
            /*await Navigation.PushAsync(new ReImpresion() { IsEvent = true }); */
        }
        private void OnSalir(object sender, EventArgs e)
        {
            App.Current.MainPage = new Home();
        }

        #region MetodosLista

        private void Delete()
        {
            if (itemIndex != null)
            {
                foreach(Lado Cara in TSSalesApp.AutomaticContext.Productos)
                {
                    if (Cara.Cara.Equals(itemIndex.Cara))
                    {
                        Cara.Codigo = "";
                        Cara.Ruc = "";
                        Cara.RazonSocial = "";
                        Cara.Correo = "";
                        Cara.Direccion = "";
                        Cara.Placa = "";
                        Cara.Odometro = "";
                        Cara.Chofer = "";
                        Cara.Tarjeta_afiliacion = "";
                        Cara.Pago = "EFECTIVO";
                        Cara.Pagos.Clear();
                        Cara.Telefono = "";
                        Cara.Tarjeta = "";
                        Cara.Marca = "";
                        Cara.Modelo = "";
                        Cara.Fecha_Nacimiento = null;
                        Cara.Documento = EDocumento.BoletaFactura;
                        this.listView.ResetSwipe();
                    }
                }
            }
        }

        private void ListView_SwipeStarted(object sender, Syncfusion.ListView.XForms.SwipeStartedEventArgs e)
        {
            itemIndex = null;
        }

        private void ListView_SwipeEnded(object sender, Syncfusion.ListView.XForms.SwipeEndedEventArgs e)
        {
            itemIndex = (Lado)e.ItemData;
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
        #endregion
    }
}