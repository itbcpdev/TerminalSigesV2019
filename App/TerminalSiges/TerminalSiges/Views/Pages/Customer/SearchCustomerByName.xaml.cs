using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Customer;
using TerminalSiges.Views.Lib;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Customer
{

    public partial class SearchCustomerByName : ContentPage
    {
        private readonly Object myLock = new Object();
        private BindingContextFindByName contexto;
        public event SelectClientDelegado ClientSelected;
        public delegate void SelectClientDelegado(TS_BEClienteLista respuesta);

        public SearchCustomerByName()
        {
            contexto = new BindingContextFindByName();
            InitializeComponent();
            BindingContext = contexto;
            TSCustomerApp.ClienteAlls += _ClienteAlls;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            txtRsCliente.Focus();
        }
        private void _TextChanged(object sender, TextChangedEventArgs e)
        {
            string texto = (((Entry)sender).Text ?? "").Trim();
            if (texto.Length <= 0) { return; }
            ClienteAlls(texto);
        }
        private void ListService_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ClientSelected((TS_BEClienteLista)e.Item);
            Navigation.PopAsync();
        }

        protected async void ClienteAlls(string rscliente)
        {
            CustomerEstado resultado = CustomerEstado.ErrorSistema;
            await Task.Delay(1000);
            if(rscliente.Equals(contexto.Nombre) == false)
            {
                return;
            }
            await Task.Run(() =>
            {
                resultado = TSCustomerApp.LoadClientByName((rscliente ?? "").Trim()).Result;
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
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void _ClienteAlls(TSCustomer respuesta)
        {

            Device.BeginInvokeOnMainThread(async () =>
            {

                if (respuesta.EstadoRespuesta == CustomerEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", respuesta.vSales.Mensaje, "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == CustomerEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == CustomerEstado.InformacionObtenida)
                {
                    InsertItems(respuesta.vClient);
                }
            });
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void InsertItems(TS_BEClienteLista[] items)
        {
            lock (myLock)
            {
                contexto.vClientes.Clear();

                lock (contexto.vClientes)
                {
                    contexto.vClientes.Clear();
                    foreach (var item in items)
                    {
                        item.cdcliente = item.cdcliente == null ? "" : item.cdcliente.Trim();
                        item.ruccliente = item.ruccliente == null ? "" : item.ruccliente.Trim();
                        item.rscliente = item.rscliente == null ? "" : item.rscliente.Trim();
                        item.drcliente = item.drcliente == null ? "" : item.drcliente.Trim();
                        contexto.vClientes.Add(item);
                    }
                }

            }
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            //Vertical
            if (height > width)
            {
 
            }
            //Horizontal
            else
            {

            }

        }
    }
    public class BindingContextFindByName : INotifyPropertyChanged
    {
        public SynchronizedObservableCollection<TS_BEClienteLista> vClientes { get; set; }
        public bool isBusy { get; set; }
        private string cNombre { get; set; }
        public BindingContextFindByName()
        {
            vClientes = new SynchronizedObservableCollection<TS_BEClienteLista>();
            isBusy = false;
        }
        public string Nombre
        {
            get { return cNombre; }
            set
            {
                cNombre = value;
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