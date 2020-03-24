using ITBCP.ServiceSIGES.Domain.Entities;
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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchArticuloByAfiliacion : ContentPage
    {
        private bool Cargado = false;
        private ContextoFindArticuloByAfiliacion Contexto;
        private string vPrefijo;
        public delegate void ArticuloResponse(List<TS_BEArticulo> Articulo);
        public event ArticuloResponse Respuesta;
        public delegate void OneArticuloResponse(TS_BEArticulo Articulo);
        public event OneArticuloResponse RespuestaArticulo;
        private bool IsEvent;
        public SearchArticuloByAfiliacion(string prefijo, bool IsEvent)
        {
            vPrefijo = prefijo;
            Contexto = new ContextoFindArticuloByAfiliacion();
            InitializeComponent();
            this.BindingContext = Contexto;
            this.IsEvent = IsEvent;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) return;
            this.txtCodigoProducto.Focus();
            ListaArticulos();
        }
        public async void ListaArticulos()
        {
            SalesEstado resultado = SalesEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TSSalesApp.ObtenerArticulosPrefijos += _ObtenerArticulosPrefijos;
                resultado = TSSalesApp._ObtenerArticulosPrefijos(vPrefijo).Result;
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

        private void _ObtenerArticulosPrefijos(TSSales respuesta)
        {
            TSSalesApp.ObtenerArticulosPrefijos -= _ObtenerArticulosPrefijos;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == SalesEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema de comunicación con el servidor, por favor intente después.", "Aceptar");
                }
                if (respuesta.EstadoRespuesta == SalesEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", respuesta.vMensaje.mensaje, "Aceptar");
                }
                if (respuesta.EstadoRespuesta == SalesEstado.InformacionObtenida)
                {
                    if (IsEvent)
                    {
                        Respuesta(respuesta.vArticulosPrefijo.Articulos.ToList());
                    }
                    else
                    {
                        respuesta.vArticulosPrefijo.Articulos.ToList().ForEach((Item) =>
                        {
                            this.Contexto.Articulos.Add(Item);
                        });
                    }
                }
            });
        }

        #region Eventos
        private void _TextChanged(object sender, TextChangedEventArgs e)
        {
            string texto = (((Entry)sender).Text ?? "").Trim();
            if (texto.Length <= 0) { return; }
            //  BuscarProductos(texto);
        }


        private async void ListService_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            RespuestaArticulo(e.Item as TS_BEArticulo);
            await Navigation.PopAsync();
        }

        #endregion

    }
    internal class ContextoFindArticuloByAfiliacion : INotifyPropertyChanged
    {
        private string _Codigo;
        public ObservableCollection<TS_BEArticulo> Articulos { get; set; }
        public ContextoFindArticuloByAfiliacion()
        {
            this._Codigo = "";
            this.Articulos = new ObservableCollection<TS_BEArticulo>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Codigo
        {
            get { return _Codigo; }
            set
            {
                _Codigo = value;
                OnPropertyChanged();
            }
        }
    }

}
