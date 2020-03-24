using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Articulo;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Users;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TerminalSiges.Lib.Autenticate;
using TerminalSiges.Lib.Customer;
using TerminalSiges.Lib.Loading;
using TerminalSiges.Lib.Sales;
using TerminalSiges.Views.Pages.Users;
using Xamarin.Forms;

namespace TerminalSiges.Views.Pages.Invoce
{
 
    public partial class LoadingSales : ContentPage
    {
        public bool Cargado = false;
        public LoadingSales()
        {
            TSSalesApp.vCaras = new ObservableCollection<TS_BECara>();
            TSSalesApp.vListArticulos = new ObservableCollection<TS_BEArticulo>();
            TSSalesApp.vTarjetas = new ObservableCollection<TS_BETarjeta>();
            TSSalesApp.vTipoPagos = new ObservableCollection<TS_BETipopago>();
            TSSalesApp.vTipoDocuments = new ObservableCollection<TipoComprobate>();
            TSSalesApp.vCabeceraInput = new TS_BECabeceraInput();
            TSSalesApp.vTerminal = new TS_BETerminal();
            TSSalesApp.vParemetros = new TS_BEParametro();
            TSSalesApp.vVendedor = new TS_BEVendedor();
            TSSalesApp.vUsuarioActual = new TS_BEUsers();
            TSSalesApp.AutomaticContext = new ViewModels.BindingAutomatic();
            TSCustomerApp.ClientOuput = new TS_BEClienteOutput();
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) return;
            TSSalesApp.Serie = TSLoginApp.Serie;
            LoadEstado resultado = LoadEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TSLoadApp.SalesLoading += SalesLoading;
                resultado = TSLoadApp.Loading().Result;
            });
            if (resultado != LoadEstado.EsperandoRespuesta)
            {
                switch (resultado)
                {
                    case LoadEstado.ErrorInternet:
                        await DisplayAlert("Aviso", "Su dispositivo no cuenta con internet en estos momentos.", "Aceptar");
                        break;
                    case LoadEstado.ErrorSistema:
                        await DisplayAlert("Aviso", "Hubo un problema de comunicación con el servidor, por favor intente después.", "Aceptar");
                        break;
                }
            }


        }
        private async void LoadClientAlls()
        {
            CustomerEstado resultado = CustomerEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TSCustomerApp.ClienteAlls += _ClienteAlls;
                resultado = TSCustomerApp.LoadClientesAll().Result;
            });
            if (resultado != CustomerEstado.EsperandoRespuesta)
            {
                switch (resultado)
                {
                    case CustomerEstado.ErrorInternet:
                        await DisplayAlert("Aviso", "Su dispositivo no cuenta con internet en estos momentos.", "Aceptar");
                        break;
                    case CustomerEstado.ErrorSistema:
                        await DisplayAlert("Aviso", "Hubo un problema de comunicación con el servidor, por favor intente después.", "Aceptar");
                        break;
                }
            }
        }

        private void _ClienteAlls(TSCustomer respuesta)
        {
            TSCustomerApp.ClienteAlls -= _ClienteAlls;
            Device.BeginInvokeOnMainThread(async () =>
            {               
                if (respuesta.EstadoRespuesta == CustomerEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == CustomerEstado.InformacionObtenida)
                {
                    foreach (var item in respuesta.vClient)
                        TSCustomerApp.vListClientes.Add(item);
                }
            });
        }
        private void LoadDocumentos()
        {
            TSSalesApp.vTipoDocuments = new ObservableCollection<TipoComprobate>
            {
                new TipoComprobate()
                {
                    Nombre=TSSalesInput.Boleta().Nombre,
                    Nro = TSSalesInput.Boleta().Nro
                },
                new TipoComprobate()
                {
                    Nombre=TSSalesInput.Factura().Nombre,
                    Nro = TSSalesInput.Factura().Nro
                },
                new TipoComprobate()
                {
                    Nombre=TSSalesInput.NotaDeDespacho().Nombre,
                    Nro = TSSalesInput.NotaDeDespacho().Nro
                },
                new TipoComprobate()
                {
                    Nombre=TSSalesInput.Serafin().Nombre,
                    Nro = TSSalesInput.Serafin().Nro
                },
            };
        }
        
        private void SalesLoading(TSLoad respuesta)
        {
            TSLoadApp.SalesLoading -= SalesLoading;
            Device.BeginInvokeOnMainThread(async () =>
            {          
                if (respuesta.EstadoRespuesta == LoadEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", respuesta.vSales.Mensaje, "Aceptar");
                    App.Current.MainPage = new NavigationPage(new Login());
                    return;
                }
                if (respuesta.EstadoRespuesta == LoadEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    App.Current.MainPage = new NavigationPage(new Login());
                    return;
                }
                if (respuesta.EstadoRespuesta == LoadEstado.InformacionObtenida)
                {
                    TSSalesApp.FechaServidor = respuesta.vSales.FechaServidor;
                    TSSalesApp.TipoCambio = respuesta.vSales.TipoCambio;
                    TSSalesApp.Igv = respuesta.vSales.Igv;
                    TSSalesApp.vCabecera = respuesta.vSales.Cabecera;
                    TSSalesApp.vTerminal = respuesta.vSales.Terminal;
                    TSSalesApp.vParemetros = respuesta.vSales.Parametros;
                    TSSalesApp.vVendedor = respuesta.vSales.Vendedor;
                    TSSalesApp.vUsuarioActual = respuesta.vSales.Usuario;
                    foreach (var item in respuesta.vSales.Caras)
                    {
                        var caras = new TS_BECara()
                        {
                            cara = item.cara,
                            nropos = item.nropos
                        };
                        var colecction = new SfSegmentItem() {
                            Text = item.cara
                        };

                        var index = TSSalesApp.vCaras.Count();
                        TSSalesApp.vCaras.Insert(index, caras);
                    }
                    foreach (var item in respuesta.vSales.Tarjetas)
                    {
                        var tarjeta = new TS_BETarjeta()
                        {
                            cdtarjeta = item.cdtarjeta,
                            c_cuenta = item.c_cuenta,
                            dstarjeta = item.dstarjeta
                        };
                        var index = TSSalesApp.vTarjetas.Count();
                        TSSalesApp.vTarjetas.Insert(index, tarjeta);
                    }
                    foreach (var item in respuesta.vSales.TipoPago)
                    {
                        var tpago = new TS_BETipopago()
                        {
                            cdtppago = item.cdtppago,
                            dstppago = item.dstppago,
                            flgpago = item.flgpago,
                            flgsistema = item.flgsistema
                        };
                        var index = TSSalesApp.vTipoPagos.Count();
                        TSSalesApp.vTipoPagos.Insert(index, tpago);
                    }
                    LoadDocumentos();
                    App.Current.MainPage = (new Home());
                }
            });
        }
    }
}