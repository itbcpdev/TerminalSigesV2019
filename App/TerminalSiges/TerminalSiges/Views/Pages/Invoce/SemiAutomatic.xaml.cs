using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using Syncfusion.SfNumericTextBox.XForms;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain.Entities;
using TerminalSiges.Lib.Customer;
using TerminalSiges.Lib.Sales;
using TerminalSiges.Views.Pages.Articulo;
using TerminalSiges.Views.Pages.Customer;
using TerminalSiges.Views.Pages.Payment;
using TerminalSIGES.Models;
using TerminalSIGES.Services;
using TerminalSIGES.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SelectionChangedEventArgs = Syncfusion.XForms.ComboBox.SelectionChangedEventArgs;
using System.Globalization;
using TerminalSiges.Lib.Autenticate;
using Rg.Plugins.Popup.Services;
using TerminalSiges.Views.Pages.PopUp;
using static TerminalSiges.Views.Pages.PopUp.VisaPopUpCompleted;
using TerminalSiges.Views.Lib;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TerminalSIGES.Views.Lib;
using TerminalSiges.Lib.Prints;

namespace TerminalSiges.Views.Pages.Invoce
{
   
    public partial class SemiAutomatic : ContentPage
    {
        public static Random _random = new Random();
        MainViewModel viewModels = new MainViewModel();
        private bool isCarasSearch = false;
        Image leftImage;
        Image rightImage;
        TS_BEArticulo itemIndex = null;
        int _order = _random.Next(500);
        private int heightRowsList = 15;
        public bool Cargado = false;
        public bool flagCliente = false;
        public bool flagArticulo = false;      
        private bool flagbtnInferior = false;
        private bool flagbtnCaras = false;
        private ButtonStateContext btnCaraContext;

        public SemiAutomatic()
        {
            
            btnCaraContext = new ButtonStateContext();
            TSSalesApp.Detalles = new ObservableCollection<TS_BEArticulo>();
            TSSalesApp.DetallesDisplay = new ObservableCollection<TS_BEArticulo>();
            TSCustomerApp.ClientOuput = new TS_BEClienteOutput();
            TSCustomerApp.TipoComprobante = TSSalesInput.Boleta();
            InitializeComponent();
            ProcDisableControllStart(false);
        }
        public void EvaluarPermisos()
        {
            
        }  
        private void ProcDisableControllStart(bool status)
        {
            bool tranfGrat = TSSalesApp.vParemetros.boton_transfer_gratuita == null ? false : Convert.ToBoolean(TSSalesApp.vParemetros.boton_transfer_gratuita);
            int cdnivel;
            try
            {
                cdnivel = TSLoginApp.CurrentEmpresa.cdnivel == null ? 0 : Convert.ToInt32(TSLoginApp.CurrentEmpresa.cdnivel.Trim());
            }
            catch
            {
                cdnivel = -1;
            }

            btnCliente.IsEnabled = status;
            btnProducto.IsEnabled = status;
            btnAutomatic.IsEnabled = status;
            btnNuevo.IsEnabled = !status;
            btnDeshacer.IsEnabled = status;
            btnCredito.IsEnabled = status;
            btnDocument.IsEnabled = !status; 
            btnPagos.IsEnabled = status;
            btnReImpresion.IsEnabled = !status;
            btnEfectivo.IsEnabled = status;
            btnTarjeta.IsEnabled = status;
            btnTranfGrat.IsEnabled = tranfGrat == true ? status : false;
            btnSerafin.IsEnabled = cdnivel == 1 || cdnivel == 2 ? status : false;
            btnCajear.IsEnabled = status;
            btnTranfGrat.IsVisible = tranfGrat == true ? true : false;
            btnSerafin.IsVisible = cdnivel == 1 || cdnivel == 2 ? true : false;
            txtPuntosDisponible.Text = "0";
            txtValorAcumulado.Text = "0.00";
            btnCaraContext.IsBusy = status;

        }
        private void ProcDisableControllNuevo(bool status)
        {
            btnCaraContext.IsBusy = status;
            btnCliente.IsEnabled = status;
            btnProducto.IsEnabled = status;
            btnAutomatic.IsEnabled = status;
            btnNuevo.IsEnabled = !status;     
          
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.labelRuc.Text = "Ruc";
            this.Title = ("FACTURACIÓN -  " + (TSSalesApp.vTerminal.nropos ?? "").Trim() + ", Turno: " + TSSalesApp.vTerminal.turno + ", VENDEDOR:" + (TSSalesApp.vVendedor.dsvendedor ?? "").Trim()).ToUpper();
            if (TSCustomerApp.TipoComprobante != null)
            {
                txtTipoComprobante.Text = TSCustomerApp.TipoComprobante.Nombre;
            }
            else
            {
                txtTipoComprobante.Text = TSSalesInput.Boleta().Nombre;
                TSCustomerApp.TipoComprobante = TSSalesInput.Boleta();
            }
            if (TSCustomerApp.FlagSearch)
            {
                if (!TSCustomerApp.FlagArticuloSearch)
                {
                    ClearDetalles();
                }
                if (TSCustomerApp.ClientOuput != null)
                {
                    if (TSCustomerApp.ClientOuput.isafiliacion)
                    {
                        txtPuntosDisponible.Text = TSCustomerApp.ClientOuput.puntos.ToString();
                        txtValorAcumulado.Text = TSCustomerApp.ClientOuput.valoracumula.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
                    }
                    if (TSCustomerApp.ClientOuput.Saldos == null) { btnAutomatic.IsEnabled = false;btnCredito.IsEnabled = false; btnCliente.IsEnabled = false; btnSerafin.IsEnabled = false; btnEfectivo.IsEnabled = true; btnTarjeta.IsEnabled = true; }
                    if (TSCustomerApp.ClientOuput.Saldos != null) { btnAutomatic.IsEnabled = false;btnCredito.IsEnabled = false; btnCliente.IsEnabled = false; btnTranfGrat.IsEnabled = false; btnSerafin.IsEnabled = false; btnEfectivo.IsEnabled = false; btnTarjeta.IsEnabled = false; }
                }
                if(TSCustomerApp.TipoComprobante == TSSalesInput.NotaDeDespacho()){
                    this.labelRuc.Text = "Código";
                }
                if(TSCustomerApp.TipoComprobante != TSSalesInput.NotaDeDespacho())
                {
                    this.labelRuc.Text = (TSCustomerApp.ClientOuput.ruccliente ?? "").Trim().Length == 11 ? "Ruc" : "Código";
                }


            }
            if (flagArticulo)
            {
                PrintTotales();
                flagArticulo = false;
            }
            if (TSSalesApp.ArticleAdd)
            {
                PrintTotales();
                TSSalesApp.ArticleAdd = false;
            }

            txtRuc.Text = (TSCustomerApp.ClientOuput.ruccliente ?? "").Trim().Length == 11 ? (TSCustomerApp.ClientOuput.ruccliente ?? "").Trim() : (TSCustomerApp.ClientOuput.cdcliente ?? "" ).Trim();
            txtRazonSocial.Text = (TSCustomerApp.ClientOuput.rscliente ?? "").Trim();
            flagCliente = false;
            flagbtnInferior = false;
            flagbtnCaras = false;
            TSCustomerApp.FlagArticuloSearch = false;
            TSCustomerApp.FlagSearch = false;
            SalesCaras();
            isCarasSearch = true;
            if (Cargado) return;
            SalesCorrelativo();
            PrintTotales();
            
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
                    TSSalesApp.vCaras = new ObservableCollection<TS_BECara>();
                    if (respuesta.vCaras == null) { return; }
                    foreach(TS_BECara cara in respuesta.vCaras)
                    {
                        TSSalesApp.vCaras.Add(cara);
                        Label _label = new Label
                        {
                            Text = cara.cara,
                            TextColor = Color.White,
                            FontSize = 36,
                            ClassId = "_label",
                            BackgroundColor = Color.Transparent,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontFamily = Estilos.FuenteBold,

                        };
                        
                        Image _image = new Image { Source = "lado.png" };

                        _label.LineBreakMode = LineBreakMode.WordWrap;

                        AbsoluteLayout _absoluteLayout = new AbsoluteLayout
                        {
                            WidthRequest = 200,
                            HeightRequest = 70,
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                            Children = {
                            _label,
                            _image
                        }

                        };
                        AbsoluteLayout.SetLayoutBounds(_label, new Xamarin.Forms.Rectangle(.75, .35, 100, 70));
                        AbsoluteLayout.SetLayoutFlags(_label, AbsoluteLayoutFlags.PositionProportional);
                        AbsoluteLayout.SetLayoutBounds(_image, new Xamarin.Forms.Rectangle(.15, .35, 100, 45));
                        AbsoluteLayout.SetLayoutFlags(_image, AbsoluteLayoutFlags.PositionProportional);

                        SfButton sfButton = new SfButton()
                        {
                            HeightRequest = 70,
                            WidthRequest = 200,
                            CornerRadius = 5,
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center,
                            BackgroundColor = Color.FromHex("#005797"),
                            BorderColor = Color.FromHex("#005797"),
                            Content = new StackLayout()
                            {
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    _absoluteLayout
                                }
                            }
                           
                        };

                        Binding binding = new Binding("IsBusy");
                        binding.Source = btnCaraContext;
                        sfButton.SetBinding(SfButton.IsEnabledProperty, binding);
                        sfButton.Clicked += SegControlCara_SelectionChanged;
                        stCaras.Children.Add(sfButton);
                    }
                }
            });
        }
        private async void SalesCorrelativo()
        {
            SalesEstado resultado = SalesEstado.ErrorSistema;
            await Task.Run(()=>
            {
                TSSalesApp.SalesCorrelativo += _SalesCorrelativo;
                resultado = TSSalesApp.ObtenerCorrelativo().Result;
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
        private void _SalesCorrelativo(TSSales respuesta)
        {
            TSSalesApp.SalesCorrelativo -= _SalesCorrelativo;
            Device.BeginInvokeOnMainThread(async () =>
            {
                busyindicator.IsVisible = false;

                if (respuesta.EstadoRespuesta == SalesEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", respuesta.vSales.Mensaje, "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == SalesEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == SalesEstado.InformacionObtenida)
                {

                    if (TSCustomerApp.TipoComprobante.Nombre == TSSalesInput.Boleta().Nombre)
                    {
                        lblNroComprobante.Text = respuesta.vCorrelativo.boleta;
                        TSSalesApp.Correlativo = respuesta.vCorrelativo.boleta;
                    }
                    if (TSCustomerApp.TipoComprobante.Nombre == TSSalesInput.Factura().Nombre)
                    {
                        lblNroComprobante.Text = respuesta.vCorrelativo.factura;
                        TSSalesApp.Correlativo = respuesta.vCorrelativo.factura;
                    }


                }

            });
        } 
        void ResetSfSegmentedSelectedCaras()
        {
            //segmentedControlCara.SelectedIndex = 0;
        }
        private void ListService_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vm = BindingContext as MainViewModel;
            var detalle = e.Item as Detalle;
            vm?.HideOrShowProducto(detalle);

        }
        private void BtnAceptarTrans_OnClicked(object sender, EventArgs e)
        {
            BackgroundColor = Color.FromHex("#ffffff");
            popupTransPendiente.IsVisible = false;
        }
        private void BtnCliente_OnCliked(object sender, EventArgs e)
        {

            if (flagCliente) return;
            flagCliente = true;
            Navigation.PushAsync(new SearchCustomer());
        }
        private void BtnAgregar_OnCliked(object sender, EventArgs e)
        {
            if (flagArticulo) return;
            TSCustomerApp.FlagArticuloSearch = true;
            Navigation.PushAsync(new SearchArticulo());

        }
        private void BtnNuevo_Clicked(object sender, EventArgs e)
        {
            ProcDisableControllStart(true);
            TSCustomerApp.TipoComprobante = TSSalesInput.Boleta();
            txtTipoComprobante.Text = TSSalesInput.Boleta().Nombre;
            TSSalesApp.Detalles.Clear();
            TSSalesApp.DetallesDisplay.Clear();
            SalesCorrelativo();
        }
        private void BtnAutomatic_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage( new SaleAutomatic(true));
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        private async void SegControlCara_SelectionChanged(object sender, EventArgs e)
        {
            
            // segmentedControlCara.IsEnabled = false;
            string cara = "";

            SfButton sfButton = (SfButton)sender;
            StackLayout stackLayout = (StackLayout)sfButton.Content;
            AbsoluteLayout view = (AbsoluteLayout)stackLayout.Children[0];
            foreach (View i in (view).Children.Where(x => x.GetType() == typeof(Label)))
            {
                cara = ((Label)i).Text;
            }
            TSSalesApp.Cara = cara;


            if (TSSalesFunctions.IsExistCombustible())
            {
                await DisplayAlert("Aviso", "Ud. ya  realizó esta operación, puede continuar con la venta.", "Aceptar");
                return;
            };


            if(Convert.ToBoolean(TSSalesApp.vParemetros.conexiondispensador ?? false) == false || Convert.ToBoolean(TSSalesApp.vTerminal.conexion_dispensador ?? 0) == false)
            {
                SearchCombustible Vista = new SearchCombustible();
                Vista.Cara = cara;
                Vista.SaveEvent += OnSaveEvent;
                await Navigation.PushAsync(Vista);
                return;
            }

            btnCaraContext.IsBusy = false;
            this.txtNroCara.Text = "CARA No " + cara.ToString();
            this.listaProductos.Text = "Lista de Productos .::CARA " + cara.ToString() + "::.";
            busyindicator.IsVisible = true;
            SalesEstado resultado = SalesEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TSSalesApp.SalesDetalle += _SalesDetalle;
                resultado = TSSalesApp.ObtenerOpTransaccion().Result;
            });
            if (resultado != SalesEstado.EsperandoRespuesta)
            {
                busyindicator.IsVisible = false;
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
            ResetSfSegmentedSelectedCaras();
        }

        private void OnSaveEvent(TS_BEArticulo Producto, string Cara)
        {
                        
            var detal = new TS_BEArticulo()
            {
                item = 1,
                dsarticulo = Producto.dsarticulo1,
                precio = Producto.precio,
                cantidad = Producto.cantidad,
                cdarticulo = Producto.cdarticulo,
                cara = Cara,
                hora = DateTime.Now.ToString("hh:mm:ss tt"),
                subtotal = Producto.impuesto > 0 ? Math.Round( (Producto.total / (Producto.impuesto + 100)) * 100,2) : Producto.total,
                tipo = "COMBUSTIBLE",
                mtoimpuesto = Producto.impuesto > 0 ? Math.Round((Producto.total / (Producto.impuesto + 100)) * Producto.impuesto, 2) : 0,
                total = Math.Round(Producto.total, 2),
                nrogasboy = "",
                cdarticulosunat = Producto.cdarticulosunat,
                mtodscto = Producto.precio == Producto.precio_orig ? 0 : (Producto.precio_orig - Producto.precio) * Producto.cantidad,
                cdunimed = Producto.cdunimed,
                precio_orig = Producto.precio_orig,
                redondea_indecopi = Producto.redondea_indecopi,
                tpformula = Producto.tpformula,
                impuesto = Producto.impuesto,
                moverstock = Producto.moverstock,
                costo = Producto.costo,
                trfgratuita = Producto.trfgratuita,
                total_display = Math.Round(Producto.total,2),
                impuesto_plastico = Producto.impuesto_plastico,
                valorconversion = Producto.valorconversion,
                cdmedequiv = Producto.cdmedequiv,
                tpconversion = Producto.tpconversion
            };

            var index = TSSalesApp.Detalles.Count();
            var indexDisplay = TSSalesApp.DetallesDisplay.Count();
            TSSalesApp.Detalles.Insert(index, detal);
            TSSalesApp.DetallesDisplay.Insert(indexDisplay, detal);
            PrintTotales();
            btnCaraContext.IsBusy = false;

        }
        private void _SalesDetalle(TSSales respuesta)
        {
            TSSalesApp.SalesDetalle -= _SalesDetalle;
            Device.BeginInvokeOnMainThread(async () =>
            {
      
                busyindicator.IsVisible = false;

                if (respuesta.EstadoRespuesta == SalesEstado.InformacionNoObtenida)
                {
                    btnCaraContext.IsBusy = true;
                    // segmentedControlCara.IsEnabled = true;
                    await DisplayAlert("Aviso", "No hay transaccion disponible", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == SalesEstado.ErrorSistema)
                {
                    btnCaraContext.IsBusy = true;
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == SalesEstado.InformacionObtenida)
                {
                    btnAutomatic.IsEnabled = false;
                    btnCredito.IsEnabled = false;
                    btnCliente.IsEnabled = false;
                    var vDetalleOutput = respuesta.vTransaccion.cDetalleOutPut;
                    if (vDetalleOutput.Length == 1)
                    {
                        var detal = new TS_BEArticulo()
                        {
                            item = vDetalleOutput[0].item,
                            dsarticulo = vDetalleOutput[0].dsarticulo1 != null ? vDetalleOutput[0].dsarticulo1.Trim() : vDetalleOutput[0].dsarticulo1,
                            precio = vDetalleOutput[0].precio,
                            cantidad = vDetalleOutput[0].cantidad,
                            cdarticulo = vDetalleOutput[0].cdarticulo,
                            cara = vDetalleOutput[0].cara,
                            hora = vDetalleOutput[0].hora,
                            subtotal = vDetalleOutput[0].impuesto > 0 ? vDetalleOutput[0].subtotal : vDetalleOutput[0].total,
                            tipo = vDetalleOutput[0].tipo,
                            mtoimpuesto = vDetalleOutput[0].impuesto > 0 ? vDetalleOutput[0].mtoimpuesto : 0,
                            total = vDetalleOutput[0].total,
                            nrogasboy = vDetalleOutput[0].nrogasboy.Trim(),
                            cdarticulosunat = vDetalleOutput[0].cdarticulosunat,
                            mtodscto = vDetalleOutput[0].mtodscto,
                            cdunimed = vDetalleOutput[0].cdunimed,
                            precio_orig = vDetalleOutput[0].precio_orig,
                            redondea_indecopi = vDetalleOutput[0].redondea_indecopi,
                            tpformula = vDetalleOutput[0].tpformula,
                            impuesto = vDetalleOutput[0].impuesto,
                            moverstock = vDetalleOutput[0].moverstock,
                            costo = vDetalleOutput[0].costo,
                            trfgratuita = vDetalleOutput[0].trfgratuita,
                            total_display = vDetalleOutput[0].total_display,
                            impuesto_plastico = vDetalleOutput[0].impuesto_plastico,
                            valorconversion = vDetalleOutput[0].valorconversion,
                            cdmedequiv = vDetalleOutput[0].cdmedequiv,
                            tpconversion = vDetalleOutput[0].tpconversion
                        };

                        var index = TSSalesApp.Detalles.Count();
                        var indexDisplay = TSSalesApp.DetallesDisplay.Count();
                        TSSalesApp.Detalles.Insert(index, detal);
                        TSSalesApp.DetallesDisplay.Insert(indexDisplay, detal);
                        PrintTotales();
                    }
                    else
                    {
                        popupTransPendiente.IsVisible = true;
                        transactionPendiente.ItemsSource = respuesta.vTransaccion.cDetalleOutPut;
                        transactionPendiente.HeightRequest = transactionPendiente.HeightRequest + (respuesta.vTransaccion.cDetalleOutPut.Count() * 30);

                    }
                }

            });
        }
        private void ListService_OnItemTransaction(object sender, ItemTappedEventArgs e)
        {
            var vDetalleOutput = e.Item as TS_BEArticulo;
            var detal = new TS_BEArticulo()
            {
                item = vDetalleOutput.item,
                dsarticulo = vDetalleOutput.dsarticulo1 != null ? vDetalleOutput.dsarticulo1.Trim() : vDetalleOutput.dsarticulo1,
                precio = vDetalleOutput.precio,
                cantidad = vDetalleOutput.cantidad,
                cdarticulo = vDetalleOutput.cdarticulo,
                cara = vDetalleOutput.cara,
                hora = vDetalleOutput.hora,
                subtotal = vDetalleOutput.impuesto > 0 ? vDetalleOutput.subtotal : vDetalleOutput.total,
                tipo = vDetalleOutput.tipo,
                mtoimpuesto = vDetalleOutput.impuesto > 0 ? vDetalleOutput.mtoimpuesto : 0,
                impuesto = vDetalleOutput.impuesto,
                total = vDetalleOutput.total,
                nrogasboy = vDetalleOutput.nrogasboy.Trim(),
                cdarticulosunat = vDetalleOutput.cdarticulosunat,
                mtodscto = vDetalleOutput.mtodscto,
                cdunimed = vDetalleOutput.cdunimed,
                precio_orig = vDetalleOutput.precio_orig,
                redondea_indecopi = vDetalleOutput.redondea_indecopi,
                tpformula = vDetalleOutput.tpformula,
                costo = vDetalleOutput.costo,
                trfgratuita = vDetalleOutput.trfgratuita,
                moverstock = vDetalleOutput.moverstock  ,
                impuesto_plastico = vDetalleOutput.impuesto_plastico,
                valorconversion = vDetalleOutput.valorconversion,
                cdmedequiv = vDetalleOutput.cdmedequiv,
                tpconversion = vDetalleOutput.tpconversion
            };
            var index = TSSalesApp.Detalles.Count();
            var indexDisplay = TSSalesApp.DetallesDisplay.Count();
            TSSalesApp.Detalles.Insert(index, detal);
            TSSalesApp.DetallesDisplay.Insert(indexDisplay, detal);
            PrintTotales();
            popupTransPendiente.IsVisible = false;
        }
        private void BtnCancel_Clicked(object sender, EventArgs e)
        {
            btnAutomatic.IsEnabled = true;
            btnCredito.IsEnabled = true;
            btnCliente.IsEnabled = true;

            btnCaraContext.IsBusy = true;
            popupTransPendiente.IsVisible = false;
        }
        private void ClearDetalles()
        {
            TSSalesApp.Detalles.Clear();
            TSSalesApp.DetallesDisplay.Clear();
            PrintTotales();
            btnCaraContext.IsBusy = true;
            this.txtNroCara.Text = "CARA No " ;
            this.listaProductos.Text = "Lista de Productos ";
        }
        private void PrintTotales()
        {
            TSSalesFunctions.PreCalculaTotales();
            listView.ItemsSource = TSSalesApp.Detalles;
            this.txtSubTotal.Text = TSSalesApp.vCabecera.mtosubtotal.ToString();
            this.txtTotal.Text = TSSalesApp.vCabecera.mtototal.ToString();
            this.txtIGV.Text = TSSalesApp.vCabecera.mtoimpuesto.ToString();

        }
        #region Private Methods 

        private void Delete()
        {
            if (itemIndex != null)
            {
                TSSalesApp.Detalles.Remove(itemIndex);
                TSSalesApp.DetallesDisplay.Remove(itemIndex);
                PrintTotales();
            }
            if (!TSSalesFunctions.IsExistCombustible())
            {
                btnCaraContext.IsBusy = true;
            };
            this.listView.ResetSwipe();
        }

        #endregion
        private void ListView_SwipeStarted(object sender, Syncfusion.ListView.XForms.SwipeStartedEventArgs e)
        {
            itemIndex = null;
        }
        private void ListView_SwipeEnded(object sender, Syncfusion.ListView.XForms.SwipeEndedEventArgs e)
        {
            itemIndex = (TS_BEArticulo)e.ItemData;
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
        private async void BtnCredito_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreditSales());
        }
        private async void BtnEfectivo_OnClicked(object sender, EventArgs e)
        {
            if (TSSalesFunctions.IsNoExistVenta())
            {
                await DisplayAlert("Aviso", "Ingrese una venta para continuar...", "Aceptar");
                return;
            }
            if (TSSalesApp.Detalles.Count > 0)
            {
                if (TSCustomerApp.ClientOuput.Saldos != null)
                {
                    await DisplayAlert("Aviso", "No se pueden procesar ventas de credito en este modulo..", "Aceptar");
                    return;
                }
                if (TSCustomerApp.ClientOuput.Saldos == null)
                {
                    await Navigation.PushAsync(new EfectivoVisaCompleted());
                }
            }
        }
        private async void BtnTarjeta_OnClicked(object sender, EventArgs e)
        {
            if (TSSalesFunctions.IsNoExistVenta())
            {
                await DisplayAlert("Aviso", "Ingrese una venta para continuar...", "Aceptar");
                return;
            }
            if (TSSalesApp.Detalles.Count > 0)
            {
                if (TSCustomerApp.ClientOuput.Saldos != null)
                {
                    await DisplayAlert("Aviso", "No se pueden procesar ventas de credito en este modulo..", "Aceptar");
                    return;
                }
                if (TSCustomerApp.ClientOuput.Saldos == null)
                {
                    VisaPopUpCompleted Vista = new VisaPopUpCompleted();
                    Vista.OnResponse += Vista_OnResponse;
                    await PopupNavigation.Instance.PushAsync(Vista);

                }
            }
            
        }
        private async void Vista_OnResponse(bool approve, string cdtptarjeta, string reftarjeta)
        {
            if (approve)
            {
                await Navigation.PushAsync(new EfectivoVisaCompleted(true,cdtptarjeta,reftarjeta));
            }
           
        }
        private async void BtnDocument_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConsultaDocuments());
        }
        private async void BtnPagos_OnClicked(object sender, EventArgs e)
        {
            if (TSSalesFunctions.IsNoExistVenta())
            {
                await DisplayAlert("Aviso", "Ingrese una venta para continuar...", "Aceptar");
                return;
            }
            if (TSSalesApp.Detalles.Count > 0)
            {
               
                if (TSCustomerApp.ClientOuput.Saldos != null)
                {
                    if (TSCustomerApp.ClientOuput.mtodisponible >= 0)
                    {
                        var action = await DisplayAlert("Aviso", "¿Desea realizar una venta al crédito?", "Si", "No");
                        if (action)
                        {
                            await Navigation.PushAsync(new CreditoCompleted());
                        }
                        else
                        {
                            return;
                        }

                    }
                    else
                    {
                        await Navigation.PushAsync(new PaymentStart());
                    }

                }
                else
                {
                    await Navigation.PushAsync(new PaymentStart());
                }

            }
            else
            {
                await DisplayAlert("Aviso", "No existe ventas, por favor ingrese alguna venta.", "Aceptar");
            }
        }
        private void BtnReImpresion_OnClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new ReImpresion());
        }
        private async void BtnTranfGrat_OnClicked(object sender, EventArgs e)
        {
            if (TSSalesFunctions.IsNoExistVenta())
            {
                await DisplayAlert("Aviso", "Ingrese una venta para continuar...", "Aceptar");
                return;
            }

            if (TSSalesFunctions.IsTransfGratuita())
            {

                App.Current.MainPage = new NavigationPage(new TranfGratuitaCompleted());
            }
            else
            {
                await DisplayAlert("Aviso", "Operación no permitida, elija nuevos articulos", "Aceptar");
                return;
            };
        }
        private async void BtnSerafin_OnClicked(object sender, EventArgs e)
        {
            if (TSSalesFunctions.IsNoExistVenta())
            {
                await DisplayAlert("Aviso", "Ingrese una venta para continuar...", "Aceptar");
                return;
            }
            if (TSSalesFunctions.IsCombustible())
            {

                App.Current.MainPage = new NavigationPage(new SerafinCompleted());
            }
            else
            {
                await DisplayAlert("Aviso", "Operación no permitida, elija nuevos articulos", "Aceptar");
                return;
            };
        }
        private void BtnDeshacer_OnClicked(object sender, EventArgs e)
        {
            ProcDisableControllStart(false);
            TSCustomerApp.TipoComprobante = TSSalesInput.Boleta();
            txtTipoComprobante.Text = TSSalesInput.Boleta().Nombre;
            TSSalesApp.Detalles.Clear();
            TSSalesApp.DetallesDisplay.Clear();
            SalesCorrelativo();
            TSCustomerApp.ClientOuput.rscliente = "";
            TSCustomerApp.ClientOuput.drcliente = "";
            TSCustomerApp.ClientOuput.ruccliente = "";
            TSCustomerApp.ClientOuput.emcliente = "";
            TSCustomerApp.ClientOuput.cdcliente = "";
            TSCustomerApp.ClientOuput.tarjafiliacion = "";
            TSCustomerApp.ClientOuput.Saldos = null;
            txtRuc.Text = "";
            txtRazonSocial.Text = "";
            PrintTotales();

        }
        private async void CboCaras_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Value != null)
            { 
                var caras = (TS_BECara)e.Value;
                TSSalesApp.Cara = caras.cara;

                if (TSSalesFunctions.IsExistCombustible())
                {
                    await DisplayAlert("Aviso", "Ud. ya  realizó esta operación, puede continuar con la venta.", "Aceptar");
                    return;
                };
                this.txtNroCara.Text = "CARA No " + caras.cara.ToString();
                busyindicator.IsVisible = true;
                SalesEstado resultado = SalesEstado.ErrorSistema;
                await Task.Run(() =>
                {
                    TSSalesApp.SalesDetalle += _SalesDetalle;
                    resultado = TSSalesApp.ObtenerOpTransaccion().Result;
                });
                if (resultado != SalesEstado.EsperandoRespuesta)
                {
                    busyindicator.IsVisible = false;
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
        }
        public void isCodigo(bool estado)
        {
            if (estado) { this.labelRuc.Text = "Código"; }
            else { this.labelRuc.Text = "Ruc"; }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            //Vertical
            if (height > width)
            {

                this.StackOrientationTwo.Orientation = StackOrientation.Horizontal;
                this.StackOrientationThree.Orientation = StackOrientation.Horizontal;
                this.ScrollOrientationOne.Orientation = ScrollOrientation.Horizontal;
                this.MiscelaneosGridRow.Height = new GridLength(90);
                this.MiscelaneosGridColumn1.Width = new GridLength(1, GridUnitType.Auto);
                this.MiscelaneosBotonesStackOne.Orientation = StackOrientation.Vertical;
                this.MiscelaneosBotonesStackTwo.Orientation = StackOrientation.Vertical;
                Grid.SetRowSpan(MiscelaneosBotones, 3);
                Grid.SetColumn(MiscelaneosDatosCli, 1);
                Grid.SetRow(MiscelaneosPuntos, 2);

                this.Fila.Height = new GridLength(100);
                this.Columna.Width = new GridLength(0);

                Grid.SetColumn(StackOrientationTwo, 0);
                Grid.SetRow(StackOrientationTwo, 1);
            }
            //Horizontal
            else
            {
    
                this.StackOrientationTwo.Orientation = StackOrientation.Vertical;
                this.StackOrientationThree.Orientation = StackOrientation.Vertical;
                this.ScrollOrientationOne.Orientation = ScrollOrientation.Vertical;
                this.MiscelaneosGridRow.Height = new GridLength(0);
                this.MiscelaneosGridColumn1.Width = new GridLength(1, GridUnitType.Star);
                this.MiscelaneosBotonesStackOne.Orientation = StackOrientation.Horizontal;
                this.MiscelaneosBotonesStackTwo.Orientation = StackOrientation.Horizontal;
                Grid.SetRowSpan(MiscelaneosBotones, 1);
                Grid.SetColumn(MiscelaneosDatosCli, 0);
                Grid.SetRow(MiscelaneosPuntos, 1);

                this.Fila.Height = new GridLength(0);
                this.Columna.Width = new GridLength(100);

                Grid.SetColumn(StackOrientationTwo, 1);
                Grid.SetRow(StackOrientationTwo, 0);


            }

        }

        public class ButtonStateContext : INotifyPropertyChanged
        {
            private bool isBusy = false;
            public event PropertyChangedEventHandler PropertyChanged;

            void OnPropertyChanged([CallerMemberName] string name = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }

            public bool IsBusy
            {
                get { return isBusy; }
                set
                {
                    isBusy = value;
                    OnPropertyChanged();
                }
            }
        }

        private async void btnCajear_Clicked(object sender, EventArgs e)
        {
            if (TSSalesFunctions.IsNoExistVenta())
            {
                await DisplayAlert("Aviso", "Ingrese una venta para continuar...", "Aceptar");
                return;
            }
            if (String.IsNullOrEmpty(TSCustomerApp.ClientOuput.tarjafiliacion))
            {
                await DisplayAlert("Aviso", "Debe buscar una tarjeta de afiliación para continuar...", "Aceptar");
                return;
            }
            if (TSSalesApp.vUsuarioActual.flganular == false)
            {
                var Respuesta = await DisplayAlert("Aviso", "Usted no posee permisos suficientes para realizar canjes.\nDebe iniciar sesión", "Iniciar Sesión", "Salir");
                if (Respuesta)
                {
                    LoginPopUp Vista = new LoginPopUp();
                    Vista.LoginResponseEvent += Vista_LoginResponse;
                    await PopupNavigation.Instance.PushAsync(Vista);
                }
                return;
            }

            ((SfButton)sender).IsEnabled = false;
            await Navigation.PushAsync(new CanjeCompleted());
            ((SfButton)sender).IsEnabled = true;
        }
        private void Vista_LoginResponse(LoginEstado respuesta, bool PermisoAnular)
        {
            Device.BeginInvokeOnMainThread(async () => {

                if (respuesta == LoginEstado.Autorizacion)
                {
                    if (PermisoAnular)
                    {
                        await Navigation.PushAsync(new CanjeCompleted());
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
        public void OnSalir(object sender, EventArgs e)
        {
            App.Current.MainPage = new Home();
        }

        public async Task<bool> IsWaiting()
        {
            if (TSPrintApp.ObtenerVentasPendientes().Result)
            {
                bool Estado1 = this.btnNuevo.IsEnabled;
                await Task.Delay(3000);
                bool Estado2 = this.btnNuevo.IsEnabled;
                return Estado1 == true && Estado2 == true;
            }
            else
            {
                return false;
            }

        }
    }
}