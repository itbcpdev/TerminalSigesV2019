using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Articulo;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Customer;
using TerminalSiges.Lib.Loading;
using TerminalSiges.Lib.Sales;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Articulo
{
   
    public partial class SearchArticulo : ContentPage
    {
        public BindingContextArticle vContexto;
        public bool Cargado = false;
        private object myLock = new object();
        public SearchArticulo()
        {
            InitializeComponent();
            TSSalesApp.vArticuloSeleccionado = new TS_BEArticulo();
            vContexto = new BindingContextArticle();
            BindingContext = vContexto;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) return;
            this.txtCodigoProducto.Focus();
            TSLoadApp.ArticuloPrecio += _LoadArticuloPrecio;
        }

        private async void BuscarProductos(string texto)
        {
            LoadEstado resultado = LoadEstado.ErrorSistema;
            await Task.Delay(1000);
            if(texto.Equals(vContexto.Codigo) == false)
            {
                return;
            }
            await Task.Run(() =>
            {
                resultado = TSLoadApp.ListaProductoPrecio(texto).Result;
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

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void _LoadArticuloPrecio(TSSales respuesta)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
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
                    foreach (var item in respuesta.vArticulos)
                    {
                        item.dsarticulo = item.dsarticulo == null ? "" : item.dsarticulo.Trim();
                        item.dsarticulo1 = item.dsarticulo1 == null ? "" : item.dsarticulo1.Trim();
                    }
                    InsertItems(respuesta.vArticulos);
                }
            });
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        private void InsertItems(TS_BEArticulo[] items)
        {
            lock (myLock)
            {
                vContexto.vArticulos.Clear();

                lock (vContexto.vArticulos)
                {
                    foreach (var item in items)
                    {
                        vContexto.vArticulos.Add(item);
                    }
                }

            }
        }
 
        private void ListService_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            BackgroundColor = Color.FromHex("#a9cae0");
            popupbuscarProducto.IsVisible = true;
            principal.IsVisible = false;
            var detalle = e.Item as TS_BEArticulo;
            TSSalesApp.vArticuloSeleccionado = detalle;
            this.txtCodigoArticulo.InputView = new Entry() { Text = detalle.cdarticulo, FontSize = 26 };
            this.txtDescripcionArticulo.InputView = new Entry() { Text = detalle.dsarticulo, FontSize = 26 };
            this.txtUnidadMedidaArticulo.InputView = new Entry() { Text = detalle.cdunimed, FontSize = 26 };
            this.txtPrecioArticulo.InputView = new Entry() { Text = detalle.precio.ToString(), FontSize = 26 };

        }
        private void BtnCancelarProducto_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            string texto = (((Entry)sender).Text ?? "").Trim();
            if (texto.Length <= 0) { return; }
            BuscarProductos(texto);
        }

        private void BtnCancelarInfo_OnClicked(object sender, EventArgs e)
        {
            BackgroundColor = Color.FromHex("#ffffff");
            popupbuscarProducto.IsVisible = false;
            principal.IsVisible = true;
        }
        private async void BtnSaveArticulo_Clicked(object sender, EventArgs e)
        {
            var dato = (Entry)txtCantidadArticulo.InputView;
            if (!(string.IsNullOrEmpty(dato.Text)))
            {
                if (isInt32(dato.Text))
                {
                    var cant = Convert.ToInt32(dato.Text);
                    if (cant > 0)
                    {
                        TSSalesApp.CantidadProducto = Convert.ToInt32(dato.Text);
                        var detal = new TS_BEArticulo()
                        {
                            item = 0,
                            dsarticulo = TSSalesApp.vArticuloSeleccionado.dsarticulo.Trim(),
                            precio = (decimal)TSSalesApp.vArticuloSeleccionado.precio,
                            cantidad = TSSalesApp.CantidadProducto,
                            cdarticulo = TSSalesApp.vArticuloSeleccionado.cdarticulo,
                            hora = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString(),
                            trfgratuita = TSSalesApp.vArticuloSeleccionado.trfgratuita,
                            tipo = "PRODUCTO",
                            total = Math.Round(TSSalesApp.CantidadProducto * (decimal)TSSalesApp.vArticuloSeleccionado.precio, 2),
                            cara = "",//TSSalesApp.vArticuloSeleccionado.cara,
                            mtoimpuesto = TSSalesApp.vArticuloSeleccionado.mtoimpuesto,
                            nrogasboy = "",//TSSalesApp.vArticuloSeleccionado.nrogasboy.Trim(),
                            cdarticulosunat = TSSalesApp.vArticuloSeleccionado.cdarticulosunat,
                            mtodscto = TSSalesApp.vArticuloSeleccionado.mtodscto,
                            cdunimed = TSSalesApp.vArticuloSeleccionado.cdunimed,
                            precio_orig = TSSalesApp.vArticuloSeleccionado.precio_orig,
                            redondea_indecopi = TSSalesApp.vArticuloSeleccionado.redondea_indecopi,
                            tpformula = TSSalesApp.vArticuloSeleccionado.tpformula ?? "",
                            costo = Convert.ToDecimal(TSSalesApp.vArticuloSeleccionado.costo),
                            impuesto = TSSalesApp.vArticuloSeleccionado.impuesto,
                            moverstock = TSSalesApp.vArticuloSeleccionado.moverstock,
                            impuesto_plastico = TSSalesApp.vArticuloSeleccionado.impuesto_plastico,
                            valorconversion = TSSalesApp.vArticuloSeleccionado.valorconversion,
                            cdmedequiv = TSSalesApp.vArticuloSeleccionado.cdmedequiv,
                            tpconversion = TSSalesApp.vArticuloSeleccionado.tpconversion

                        };
                        detal.mtoimpuesto = detal.impuesto <= 0 ? 0 : Math.Round((detal.total / (100 + detal.impuesto)) * detal.impuesto,2);
                        detal.subtotal = detal.impuesto <= 0 ? detal.total : Math.Round(detal.total-detal.mtoimpuesto,2);

                        var index = TSSalesApp.Detalles.Count();
                        var indexDisplay = TSSalesApp.DetallesDisplay.Count();
                        TSSalesApp.Detalles.Insert(index, detal);
                        TSSalesApp.DetallesDisplay.Insert(indexDisplay, detal);

                    }
                    else
                    {
                        await DisplayAlert("Aviso", "Ingrese Cantidad, por favor", "Aceptar");
                    }
                }
                else
                {
                    await DisplayAlert("Aviso", "Ingrese Cantidad, por favor", "Aceptar");
                }

            }
            else
            {
                await DisplayAlert("Aviso", "Ingrese Cantidad, por favor", "Aceptar");
            }
        await     Navigation.PopAsync();
            //await Navigation.PopModalAsync();//
        }

        public bool isInt32(String num)
        {
            try
            {
                Int32.Parse(num);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public class BindingContextArticle : INotifyPropertyChanged
    {
        public ObservableCollection<TS_BEArticulo> vArticulos { get; set; }
        private string cCodigo { get; set; }
        public BindingContextArticle()
        {
            vArticulos = new ObservableCollection<TS_BEArticulo>();
        }

        public string Codigo
        {
            get { return cCodigo; }
            set
            {
                cCodigo = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }


}