using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Helpers;
using TerminalSiges.Lib.Customer;
using TerminalSiges.Lib.Sales;
using TerminalSiges.Views.Pages.Articulo;
using TerminalSiges.Views.Pages.Customer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Afiliacion
{
    public partial class AfiliacionClientes : ContentPage
    {
        private TS_BEArticulo itemIndex = null;
        private bool IsCargado = false;
        private BindingContextAfiliacionClientes Contexto;

        public AfiliacionClientes()
        {
            Contexto = new BindingContextAfiliacionClientes();
            InitializeComponent();
            this.BindingContext = Contexto;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (IsCargado) { return; }
            IsCargado = true;
            SalesEstado resultado = SalesEstado.ErrorSistema;
            await Task.Run(() => 
            {
                TSSalesApp.ObtenerPrefijos += _ObtenerPrefijos;
                resultado = TSSalesApp._ObtenerPrefijos().Result;
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

        private void _ObtenerPrefijos(TSSales respuesta)
        {
            TSSalesApp.ObtenerPrefijos -= _ObtenerPrefijos;
            Device.BeginInvokeOnMainThread(async ()=>
            { 
                if(respuesta.EstadoRespuesta == SalesEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Su dispositivo no cuenta con internet en estos momentos.", "Aceptar");
                }
                else
                {
                    respuesta.vPrefijos.ToList().ForEach((Item) => { Contexto.Prefijos.Add(Item); });
                }
            });
        }


        private void Delete()
        {
            if (itemIndex != null)
            {
                Contexto.ArticulosTarjeta.Remove(itemIndex);
            }
            this.ListView.ResetSwipe();
        }
        public async void OnSave(object sender,EventArgs e)
        {
            if (String.IsNullOrEmpty(Contexto.CodigoCliente))
            {
                await DisplayAlert("Aviso", "Ingrese el codigo del cliente", "Aceptar");
                return;
            }
            if (String.IsNullOrEmpty(Contexto.RazonSocial))
            {
                await DisplayAlert("Aviso", "Ingrese el nombre del cliente", "Aceptar");
                return;
            }
            Contexto.IsSave = true;
            Contexto.IsVisiblePanelEdicion = false;
            Contexto.IsBusy = true;
            Contexto.TituloBusqueda = "Guardando registros";

            TS_BEClienteInput Cliente = new TS_BEClienteInput()
            {
                cdcliente = Contexto.CodigoCliente,
                ruccliente = Contexto.Ruc,
                rscliente = Contexto.RazonSocial,
                drcliente = Contexto.Direccion,
                estado_afiliacion = Contexto.SelectedItem.Equals("Baja definitiva"),
                bloqueado_afiliacion = Contexto.SelectedItem.Equals("Bloqueado"),
                cdusuario = TSSalesApp.vVendedor.cdusuario,
                tarjAfiliacion = Contexto.Tarjeta
            };

            List<TS_BEArticulo> Articulos = Contexto.ArticulosTarjeta.ToList();

            TS_BETipoTarjetaRegistro Tipo = Contexto.SelectedItemTipoOperacion.Equals("Nueva tarjeta") ? TS_BETipoTarjetaRegistro.NUEVO_REGISTRO :
                                            Contexto.SelectedItemTipoOperacion.Equals("Edición de información") ? TS_BETipoTarjetaRegistro.ACTUALIZACION_REGISTRO :
                                            TS_BETipoTarjetaRegistro.TRASPASO_REGISTRO;

            SalesEstado resultado = SalesEstado.ErrorSistema;

            await Task.Run(() =>
            {
                TSSalesApp.GrabarTransaccionPrefijos += _GrabarTransaccionPrefijos;
                resultado = TSSalesApp.GrabarTransaccionPrefijo(Cliente,Articulos,Tipo).Result;
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

        private void _GrabarTransaccionPrefijos(TSSales respuesta)
        {
            TSSalesApp.GrabarTransaccionPrefijos -= _GrabarTransaccionPrefijos;
            Device.BeginInvokeOnMainThread(async() => 
            {
                Contexto.IsSave = false;
                Contexto.IsVisiblePanelEdicion = true;
                Contexto.IsBusy = false;
                if (respuesta.EstadoRespuesta == SalesEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema de comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if(respuesta.EstadoRespuesta == SalesEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", "!Ups, tenemos un problema" + respuesta.vMensaje.mensaje, "Aceptar");
                    return;
                }
                else
                {
                    await DisplayAlert("Aviso", "Se realizaron las solicitudes correctamente", "Aceptar");
                    ClearData(null, null);
                    return;
                }
            });
        }

        public async void OnAddAll(object sender, EventArgs e)
        {
            try
            {
                SearchArticuloByAfiliacion Articulos = new SearchArticuloByAfiliacion(((TS_BEPTarjeta)this.cmboPrefij.SelectedItem).prefijo, true);
                Articulos.Respuesta += Articulos_Respuesta;
                Articulos.ListaArticulos();
            }
            catch(Exception ex)
            {
                await DisplayAlert("Aviso", ex.Message.ToString(), "");
            }

        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void Articulos_Respuesta(List<TS_BEArticulo> Articulo)
        {
            Contexto.ArticulosTarjeta.Clear();
            Articulo.ForEach((Item) => Contexto.ArticulosTarjeta.Add(Item));
        }

        public async void OnSearchItem(object sender, EventArgs e)
        {
            try
            {
                SearchArticuloByAfiliacion Articulos = new SearchArticuloByAfiliacion(((TS_BEPTarjeta)this.cmboPrefij.SelectedItem).prefijo, false);
                Articulos.RespuestaArticulo += Articulos_RespuestaArticulo;
                await Navigation.PushAsync(Articulos);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Aviso", ex.Message.ToString(), "");
            }
        }

        private void Articulos_RespuestaArticulo(TS_BEArticulo Articulo)
        {
            if(Contexto.ArticulosTarjeta.Count == 0)
            {
                Contexto.ArticulosTarjeta.Add(Articulo);
            }
            else
            {
                if(Contexto.ArticulosTarjeta.Any(Item => (Item.cdarticulo ?? "").Trim().Equals((Articulo.cdarticulo ?? "").Trim())) == false)
                {
                    Contexto.ArticulosTarjeta.Add(Articulo);
                }
            }
            
        }

        public void OnSalir(object sender, EventArgs e)
        {
            App.Current.MainPage = new Home();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        private void TSSalesApp_ClientSearch(TSCustomer respuesta)
        {
            TSCustomerApp.ClientSearch -= TSSalesApp_ClientSearch;
            Device.BeginInvokeOnMainThread(async () =>
            {
                Contexto.IsSearch = false;
                Contexto.IsBusy = false;
                if (respuesta.EstadoRespuesta == CustomerEstado.InformacionObtenida)
                {
                    Contexto.Cliente = respuesta.vClientOuput;

                    if (Contexto.SelectedItemTipoOperacion.Equals("Nueva tarjeta"))
                    {
                        await DisplayAlert("Aviso", "La tarjeta ya existe debe usar un código diferente", "Aceptar");
                        return;
                    }
                    if (Contexto.SelectedItemTipoOperacion.Equals("Traspaso de tarjeta"))
                    {

                    }
                    if (Contexto.SelectedItemTipoOperacion.Equals("Edición de información"))
                    {

                        if (Contexto.Cliente.Saldos != null)
                        {
                            await DisplayAlert("Aviso", "No se puede ingresar una tarjeta de creditos en ventas al contado", "Aceptar");
                            return;
                        }
                        if (Contexto.Cliente.isafiliacion)
                        {
                            if (Contexto.Cliente.baja)
                            {
                                await DisplayAlert("Aviso", "La tarjeta descrita esta dada de baja por lo cual no puede acumular puntos, solo desde oficina pueden realizar cambios", "Aceptar");
                                return;
                            }
                            if (Contexto.Cliente.bloqueado)
                            {
                                await DisplayAlert("Aviso", "La tarjeta descrita esta bloqueada, tenga en cuenta que cualquier cambio que realize quedara registrado", "Aceptar");
                                this.Contexto.SelectedItem = "Bloqueado";
                                this.Contexto.DesactivarEstado = true;

                            }
                            else if (!Contexto.Cliente.bloqueado)
                            {
                                this.Contexto.DesactivarEstado = false;
                                this.Contexto.SelectedItem = "Activo";
                            }
                            Contexto.Puntos = Contexto.Cliente.puntos.ToString();
                            Contexto.Acumulado = Contexto.Cliente.valoracumula.ToString();
                            Contexto.Tarjeta = (Contexto.Cliente.tarjafiliacion ?? "").Trim();
                            Contexto.CodigoCliente = (Contexto.Cliente.cdcliente ?? "").Trim();
                            Contexto.Ruc = (Contexto.Cliente.ruccliente ?? "").Trim();
                            Contexto.RazonSocial = (Contexto.Cliente.rscliente ?? "").Trim();
                            Contexto.Direccion = (Contexto.Cliente.drcliente ?? "").Trim();
                            Contexto.Correo = (Contexto.Cliente.emcliente ?? "").Trim();
                            if (Contexto.Cliente.ArticulosTarjeta != null)
                            {
                                Contexto.ArticulosTarjeta.Clear();
                                Contexto.Cliente.ArticulosTarjeta.ToList().ForEach((Item) => Contexto.ArticulosTarjeta.Add(Item));
                            }
                            if (Contexto.Cliente.ArticulosPrefijo != null)
                            {
                                Contexto.ArticulosPrefijo.Clear();
                                Contexto.Cliente.ArticulosPrefijo.ToList().ForEach((Item) => Contexto.ArticulosPrefijo.Add(Item));
                            }
                            Contexto.IsVisiblePanelEdicion = true;
                        }

                    }
                }
                if (respuesta.EstadoRespuesta == CustomerEstado.InformacionNoObtenida)
                {
                    if (Contexto.SelectedItemTipoOperacion.Equals("Nueva tarjeta"))
                    {
                        Contexto.CodigoCliente = "";
                        Contexto.Tarjeta = Contexto.Codigo;
                        Contexto.Ruc = "";
                        Contexto.RazonSocial = "";
                        Contexto.Direccion = "";
                        Contexto.Puntos = "0.00";
                        Contexto.Acumulado = "0.00";
                        Contexto.SelectedItem = "Activo";
                        Contexto.ArticulosPrefijo.Clear();
                        Contexto.ArticulosTarjeta.Clear();
                        Contexto.IsVisiblePanelEdicion = true;
                    }
                    else
                    {
                        await DisplayAlert("Aviso", respuesta.vClientOuput == null ? "La tarjeta no existe" : respuesta.vClientOuput.Mensaje, "Aceptar");
                        return;
                    }

                }
                if (respuesta.EstadoRespuesta == CustomerEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
            });
        }
       
        private async void search_rscliente_click(object sender, EventArgs e)
        {
            SearchCustomerByName View = new SearchCustomerByName();
            View.ClientSelected += _ClientSelected;
            await Navigation.PushAsync(View);
        }

        private void _ClientSelected(TS_BEClienteLista respuesta)
        {
            Contexto.CodigoCliente = (respuesta.cdcliente ?? "").Trim();
            Contexto.Ruc = (respuesta.ruccliente ?? "").Trim();
            Contexto.RazonSocial = (respuesta.rscliente ?? "").Trim();
            Contexto.Direccion = (respuesta.drcliente ?? "").Trim();
        }
        
        public async void OnSearch(object sender, EventArgs e)
        {
            if(this.cmboPrefij.SelectedValue == null)
            {
                await DisplayAlert("Aviso", "Seleccione el prefijo antes de realizar la búsqueda", "Aceptar");
                return;
            }
            if(this.cmboTipoOperacion.SelectedValue == null)
            {
                await DisplayAlert("Aviso", "Seleccione el tipo de operación antes de realizar la búsqueda", "Aceptar");
                return;
            }
            if(Contexto.Codigo.Length <= this.cmboPrefij.SelectedValue.ToString().Length)
            {
                await DisplayAlert("Aviso", "Seleccione el prefijo correcto y ingrese el código completo de la tarjeta antes de realizar la búsqueda", "Aceptar");
                return;
            }
            if (Contexto.Codigo.Substring(0, this.cmboPrefij.SelectedValue.ToString().Length).Equals(this.cmboPrefij.SelectedValue.ToString()) == false)
            {
                await DisplayAlert("Aviso", "Seleccione el prefijo correcto antes de realizar la búsqueda", "Aceptar");
                return;
            }
            Contexto.IsVisiblePanelEdicion = false;
            Contexto.IsSearch = true;
            Contexto.IsBusy = true;
            Contexto.TituloBusqueda = "Cargando ...";
            TSCustomerApp.Ruc = "";
            TSCustomerApp.CdCliente = "";
            TSCustomerApp.afiliacionTarj = Contexto.Codigo;
            TSCustomerApp.prefijo = this.cmboPrefij.SelectedValue.ToString();
            TSCustomerApp.IsArticulo = true;

            if (String.IsNullOrEmpty(TSCustomerApp.afiliacionTarj))
            {
                await DisplayAlert("Aviso", "Ingrese el numero de tarjeta.", "Aceptar");
                Contexto.IsSearch = false;
                return;
            }

            CustomerEstado resultado = CustomerEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TSCustomerApp.ClientSearch += TSSalesApp_ClientSearch;
                resultado = TSCustomerApp.ObtenerClienteByTarjeta().Result;
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
                Contexto.IsSearch = false;
            }
        }

        #region MetodosDeLaLista
        private void rightImage_BindingContextChanged(object sender, EventArgs e)
        {
            Image rightImage = sender as Image;
            rightImage.Source = "Delete.png";
            (rightImage.Parent as View).GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Delete) });
            
        }
        private void ListView_SwipeStarted(object sender, Syncfusion.ListView.XForms.SwipeStartedEventArgs e)
        {
            itemIndex = null;
        }
        private void ListView_SwipeEnded(object sender, Syncfusion.ListView.XForms.SwipeEndedEventArgs e)
        {
            itemIndex = (TS_BEArticulo)e.ItemData;
        }
       
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            //Vertical
            if (height > width)
            {
                Grid.SetColumn(StackOrientationOne, 0);
                Grid.SetRow(StackOrientationOne, 1);

                Grid.SetColumn(StackOrientationThree, 0);
                Grid.SetRow(StackOrientationThree, 2);

                Grid.SetColumnSpan(StackOrientationTwo, 2);
                Grid.SetColumnSpan(StackOrientationThree, 2);
            }
            //Horizontal
            else
            {
                Grid.SetColumn(StackOrientationOne, 1);
                Grid.SetRow(StackOrientationOne, 0);

                Grid.SetColumn(StackOrientationThree, 1);
                Grid.SetRow(StackOrientationThree, 1);

                Grid.SetColumnSpan(StackOrientationTwo, 1);
                Grid.SetColumnSpan(StackOrientationThree, 1);
            }
        }
        #endregion
        
        private void ClearData(object sender, Object e)
        {
            Contexto.CodigoCliente = "";
            Contexto.Tarjeta = "";
            Contexto.Ruc = "";
            Contexto.RazonSocial = "";
            Contexto.Direccion = "";
            Contexto.SelectedItem = "Activo";
            Contexto.ArticulosPrefijo.Clear();
            Contexto.ArticulosTarjeta.Clear();
            Contexto.IsVisiblePanelEdicion = false;
        }
    }
    internal class BindingContextAfiliacionClientes : INotifyPropertyChanged
    {
        public ObservableCollection<TS_BEPTarjeta> Prefijos { get; set; }
        public ObservableCollection<TS_BEArticulo> ArticulosTarjeta { get; set; }
        public ObservableCollection<TS_BEArticulo> ArticulosPrefijo { get; set; }
        public ObservableCollection<string> Operaciones { get; set; }
        public ObservableCollection<string> Estados { get; set; }
        public ObservableCollection<string> Header { get; set; }
        public TS_BEClienteOutput Cliente { get; set; }

        private bool _IsSave;
        private bool _DesactivarEstado;
        private string _TituloBusqueda;
        private string _selectedItem;
        private string _selectedItemTipoOperacion;
        private bool _IsSearch;
        private string _Codigo;
        private bool _IsBusy;
        private string _CodigoCliente;
        private string _Ruc;
        private string _RazonSocial;
        private string _Direccion;
        private string _Correo;
        private string _Puntos;
        private string _Acumulado;
        private string _Tarjeta;
        private bool _IsVisiblePanelEdicion;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    
    public BindingContextAfiliacionClientes()
        {
            IsSearch = false;
            _Puntos = "0.00";
            _Acumulado = "0.00";
            _Codigo = "";
            IsBusy = false;
            _IsSave = true;
            _TituloBusqueda = "Cargando...";
            Prefijos = new ObservableCollection<TS_BEPTarjeta>();
            Estados = new ObservableCollection<string>();
            Header = new ObservableCollection<string>();
            Operaciones = new ObservableCollection<string>();
            ArticulosTarjeta = new ObservableCollection<TS_BEArticulo>();
            ArticulosPrefijo = new ObservableCollection<TS_BEArticulo>();

            Operaciones.Add("Nueva tarjeta");
           /* Operaciones.Add("Traspaso de tarjeta");*/
            Operaciones.Add("Edición de información");

            Estados.Add("Activo");
            Estados.Add("Bloqueado");
            Estados.Add("Baja definitiva");
            _IsVisiblePanelEdicion = false;
            SelectedItem = "";
        }
        public string Puntos
        {
            get { return _Puntos; }
            set
            {
                _Puntos = value;
                OnPropertyChanged();
            }
        }
        public string Acumulado
        {
            get { return _Acumulado; }
            set
            {
                _Acumulado = value;
                OnPropertyChanged();
            }
        }
        public bool DesactivarEstado
        {
            get { return _DesactivarEstado; }
            set
            {
                _DesactivarEstado = !value;
                OnPropertyChanged();
            }
        }
        public bool IsSave
        {
            get { return _IsSave; }
            set
            {
                _IsSave = !value;
                OnPropertyChanged();
            }
        }
        public string TituloBusqueda
        {
            get { return _TituloBusqueda; }
            set
            {
                _TituloBusqueda = value;
                OnPropertyChanged();
            }
        }
        public bool IsSearch
        {
            get { return _IsSearch; }
            set
            {
                _IsSearch = !value;
                OnPropertyChanged();
            }
        }
        public bool IsVisiblePanelEdicion
        {
            get { return _IsVisiblePanelEdicion; }
            set
            {
                _IsVisiblePanelEdicion = value;
                OnPropertyChanged();
            }
        }
        public  bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }
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
        public string CodigoCliente
        {
            get { return _CodigoCliente; }
            set
            {
                _CodigoCliente = RegexExpresion.OnTextChange(value, RegexType.Codigo, MaxLength.cliente_codigo);
                OnPropertyChanged();
            }
        }
        public string Ruc
        {
            get { return _Ruc; }
            set
            {
                _Ruc = RegexExpresion.OnTextChange(value, RegexType.Numerico, MaxLength.cliente_ruc); 
                OnPropertyChanged();
            }
        }
        public string Tarjeta
        {
            get { return _Tarjeta; }
            set
            {
                _Tarjeta = RegexExpresion.OnTextChange(value, RegexType.Tarjeta, MaxLength.cliente_tarjeta_afiliacion); 
                OnPropertyChanged();
            }
        }
        public string RazonSocial
        {
            get { return _RazonSocial; }
            set
            {
                _RazonSocial = RegexExpresion.OnTextChange(value, RegexType.None, MaxLength.cliente_razon_social);
                OnPropertyChanged();
            }
        }
        public string Direccion
        {
            get { return _Direccion; }
            set
            {
                _Direccion = RegexExpresion.OnTextChange(value, RegexType.None, MaxLength.cliente_direccion); 
                OnPropertyChanged();
            }
        }
        public string Correo
        {
            get { return _Correo; }
            set
            {
                _Correo = RegexExpresion.OnTextChange(value, RegexType.Correo, MaxLength.cliente_correo);
                OnPropertyChanged();
            }
        }

        public string SelectedItem
        {
            get { return _selectedItem; }

            set 
            { 
                _selectedItem = value; 
                OnPropertyChanged(); 
            }
        }

        public string SelectedItemTipoOperacion
        {
            get { return _selectedItemTipoOperacion; }

            set
            {
                _selectedItemTipoOperacion = value;
                OnPropertyChanged();
            }
        }


    }

}