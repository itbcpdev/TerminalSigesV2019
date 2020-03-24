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
using TerminalSiges.Lib.Loading;
using TerminalSiges.Lib.Sales;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Articulo
{
   
    public partial class SearchCombustible : ContentPage
    {
        public event OnSave SaveEvent;
        public delegate void OnSave(TS_BEArticulo Producto, string Cara);

        public string Cara { get; set; }

        private BindingContextCombustible Contexto;
        
        public SearchCombustible()
        {
            Contexto = new BindingContextCombustible();
            InitializeComponent();
            this.BindingContext = Contexto;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (Contexto.IsLoaded) return;
            Contexto.IsLoaded = true;
            SalesEstado resultado = SalesEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TSSalesApp.SalesDetalle += _SalesDetalle;
                resultado = TSSalesApp.ObtenerOpTransaccion().Result;
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

        private void _SalesDetalle(TSSales respuesta)
        {
            TSSalesApp.SalesDetalle -= _SalesDetalle;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == SalesEstado.ErrorSistema || respuesta.EstadoRespuesta == SalesEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }

                if (respuesta.EstadoRespuesta == SalesEstado.InformacionObtenida)
                {
                    
                    foreach (var item in respuesta.vTransaccion.cDetalleOutPut)
                    {
                        Contexto.Productos.Add(item);
                    }
                }

            });
        }


        private void OnCalculateCantidad(object sender, FocusEventArgs e)
        {
            if (e.IsFocused == false)
            {
                Contexto.Total = Math.Round(Contexto.Cantidad * Contexto.Precio, 2);
            }
        }
        private void OnCalculateTotal(object sender, FocusEventArgs e)
        {
            if(e.IsFocused == false)
            {
                Contexto.Cantidad = Math.Round(Contexto.Total / Contexto.Precio,4);
            }
        }
        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Contexto.IsSelected = true;
            Contexto.Articulo = e.Item as TS_BEArticulo;
            Contexto.Codigo = Contexto.Articulo.cdarticulo;
            Contexto.Cantidad = 1;
            Contexto.Precio = Contexto.Articulo.precio;
            Contexto.Nombre = Contexto.Articulo.dsarticulo;
            Contexto.Unidad = Contexto.Articulo.cdunimed;
            Contexto.Total = Math.Round(Contexto.Cantidad * Contexto.Precio, 2);
            this.txtTotal.Focus();

        }
        private void OnCancelar(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        private void OnCancelarPopUp(object sender, EventArgs e)
        {
            Contexto.IsSelected = false;
        }
        private void OnAceptarPopUp(object sender, EventArgs e)
        {
            Contexto.IsSelected = false;
            Contexto.Articulo.cantidad = Contexto.Cantidad;
            Contexto.Articulo.total = Contexto.Total;
            SaveEvent(Contexto.Articulo, Cara);
            Navigation.PopAsync();
        }

    }
    public class BindingContextCombustible : INotifyPropertyChanged
    {
        public ObservableCollection<TS_BEArticulo> Productos { get; set; }
        public TS_BEArticulo Articulo { get; set; }
        private bool cIsSearch;
        private bool cIsSelected;
        private bool cIsLoaded;
        private string cCodigo;
        private string cNombre;
        private string cUnidad;
        private decimal cPrecio;
        private decimal cCantidad;
        private decimal cTotal;
        

        public BindingContextCombustible()
        {
            this.Productos = new ObservableCollection<TS_BEArticulo>();
            this.cIsSearch = true;
            this.cIsLoaded = false;
            this.cIsSelected = false;
            this.cCodigo = "";
            this.cNombre = "";
            this.cUnidad = "";
            this.cPrecio = 0;
            this.cCantidad = 0;
            this.cTotal = 0;
           
        }
        public bool IsSearch
        {
            get 
            { 
                return cIsSearch; 
            }
            set 
            {
                cIsSearch = value; 
                OnPropertyChanged(); 
            }
        }
        public bool IsLoaded
        {
            get
            {
                return cIsLoaded;
            }
            set
            {
                cIsLoaded = value;
                OnPropertyChanged();
            }
        }
        public bool IsSelected
        {
            get
            {
                return cIsSelected;
            }
            set
            {
                cIsSelected = value;
                OnPropertyChanged();
            }
        }

        public string Codigo
        {
            get
            {
                return cCodigo;
            }
            set
            {
                cCodigo = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }

        public string Nombre
        {
            get
            {
                return cNombre;
            }
            set
            {
                cNombre = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }

        public string Unidad
        {
            get
            {
                return cUnidad;
            }
            set
            {
                cUnidad = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(value));
            }
        }

        public decimal Precio
        {
            get
            {
                return cPrecio;
            }
            set
            {
                cPrecio = value;
                OnPropertyChanged();
            }
        }

        public decimal Cantidad
        {
            get
            {
                return cCantidad;
            }
            set
            {
                cCantidad = value;
                OnPropertyChanged();
            }
        }

        public decimal Total
        {
            get
            {
                return cTotal;
            }
            set
            {
                cTotal = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = ""){PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));}
    }
}