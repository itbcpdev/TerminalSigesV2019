using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TerminalSiges.Helpers;
using TerminalSiges.Lib.Customer;
using TerminalSiges.Lib.Sales;
using TerminalSiges.ViewModels;
using TerminalSiges.Views.Pages.Customer;
using TerminalSIGES.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Payment
{

	public partial class CreditSales : ContentPage
    {

        public event OnSaveEvent SaveEvent;
        public delegate void OnSaveEvent(Lado respuesta);
        public bool IsEvent = false;
        public string Cara = "";


        private bool Cargado = false;
        private List<string> TarjetasBuscadas;
        private BindingProgressCustomers contexto;

        public CreditSales ()
		{
            contexto = new BindingProgressCustomers();
            InitializeComponent ();
            cmboPrefij.SelectedItem = contexto.Prefijos[0];
            BindingContext = contexto;
            TSCustomerApp.FlagSearch = false;
            TarjetasBuscadas = new List<string>();
            this.txtChofer.Completed += TxtChofer_Completed;
        }
        private async void search_rscliente_click(object sender, EventArgs e)
        {
            SearchCustomerByName View = new SearchCustomerByName();
            View.ClientSelected += _ClientSelected;
            await Navigation.PushAsync(View);
        }

        private void _ClientSelected(TS_BEClienteLista respuesta)
        {
            contexto.cTextTarjetaCreditoBusqueda = (respuesta.cdcliente ?? "").Trim();
            contexto.Codigo_cliente = (respuesta.cdcliente ?? "").Trim();
            contexto.Tarjeta = (respuesta.cdcliente ?? "").Trim(); 
            contexto.Razon_social_cliente = (respuesta.rscliente ?? "").Trim();

        }

        private void TxtChofer_Completed(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(contexto.Placa)) { this.txtPlaca.Focus(); }
            else { this.txtOdoMetro.Focus(); }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) return;
            this.txtTarjetaCliente.Focus();
            contexto.IsClosed = false;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            contexto.IsClosed = true;
        }
        private async void search_Cliente_click(object sender, EventArgs e)
        {
            string prefijo = (string)cmboPrefij.SelectedValue;
            if (String.IsNullOrEmpty(prefijo)) { await DisplayAlert("Aviso", "Debe seleccionar el tipo de prefijo", "Aceptar");return; }
            contexto.IsSearch = true;
            TSCustomerApp.CdCliente = prefijo + this.txtTarjetaCliente.Text;
            TSCustomerApp.ClientOuput.nroTarjeta = this.txtTarjetaCliente.Text;
       
            CustomerEstado resultado = CustomerEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TSCustomerApp.ClienteByCodigo += TSSalesApp_ClientSearch;
                resultado = TSCustomerApp.ObtenerClienteByCodigo().Result;
            });
            if (resultado != CustomerEstado.EsperandoRespuesta)
            {
                
                switch (resultado)
                {
                    case CustomerEstado.ErrorInternet:
                        contexto.IsSearch = false;
                        await DisplayAlert("Aviso", "Su dispositivo no cuenta con internet en estos momentos.", "Aceptar");
                        break;
                    case CustomerEstado.ErrorSistema:
                        contexto.IsSearch = false;
                        await DisplayAlert("Aviso", "Hubo un problema de comunicación con el servidor, por favor intente después.", "Aceptar");
                        break;
                }
            }
        }
        private void TSSalesApp_ClientSearch(TSCustomer respuesta)
        {
            TSCustomerApp.ClienteByCodigo -= TSSalesApp_ClientSearch;
            Device.BeginInvokeOnMainThread(async () =>
            {
                contexto.IsSearch = false;
                if (respuesta.EstadoRespuesta == CustomerEstado.ClienteConSaldo)
                {
                    if(respuesta.vClientOuput.Saldos == null)
                    {
                        await DisplayAlert("Aviso", "El código descrito no es un cliente de credito", "Aceptar");
                        return;
                    }

                    TarjetasBuscadas.Add(respuesta.vClientOuput.Saldos.cdcliente);
                    TSCustomerApp.ClientOuput = respuesta.vClientOuput;
                    TSCustomerApp.ClientOuput.mtodisponible = (TSCustomerApp.ClientOuput.Saldos.limitemto - TSCustomerApp.ClientOuput.Saldos.consumto);
                    contexto.Tarjeta = TSCustomerApp.ClientOuput.Saldos.nrotarjeta;
                    contexto.Codigo_cliente = TSCustomerApp.ClientOuput.Saldos.cdcliente;
                    contexto.Razon_social_cliente = TSCustomerApp.ClientOuput.rscliente;
                    contexto.Placa = TSCustomerApp.ClientOuput.Saldos.nroplaca;
                    contexto.Saldo = "S/. " + (Math.Round(Convert.ToDouble(TSCustomerApp.ClientOuput.Saldos.limitemto - TSCustomerApp.ClientOuput.Saldos.consumto), 2)).ToString();
                    contexto.IsChoferVisible = respuesta.vClientOuput.Saldos.campos.chofer.visible;
                    contexto.IsChoferEnabled = respuesta.vClientOuput.Saldos.campos.chofer.disabled;
                    contexto.IsPlacaVisible = respuesta.vClientOuput.Saldos.campos.placa.visible;
                    contexto.IsPlacaEnabled = respuesta.vClientOuput.Saldos.campos.placa.disabled;
                    contexto.IsOdometroEnabled = respuesta.vClientOuput.Saldos.campos.odometro.disabled;
                    contexto.IsOdometroVisible = respuesta.vClientOuput.Saldos.campos.odometro.visible;
                    contexto.Odometro = "0";

                    if(contexto.IsClosed == false)
                    {
                        this.txtChofer.Focus();
                    }
                }
                if (respuesta.EstadoRespuesta == CustomerEstado.ClienteSinSaldo)
                {
                    await DisplayAlert("Aviso", respuesta.vClientOuput.Mensaje, "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == CustomerEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
            });
        }

        private async void BtnCancelCredito_Clicked(object sender, EventArgs e)
        {
            TSCustomerApp.ClientOuput = new TS_BEClienteOutput(); 
            await Navigation.PopAsync();
        }

        private async void BtnSaveCredito_Clicked(object sender, EventArgs e)
        {
            int isBuscada = 0;
            foreach (string tarjeta in TarjetasBuscadas)
            {
                if ((tarjeta ?? "").Trim().Equals((contexto.Codigo_cliente ?? "").Trim()))
                {
                    isBuscada++;
                }
            }
            if (isBuscada == 0)
            {
                await DisplayAlert("Aviso", "Por favor debe procesar la busqueda de la tarjeta seleccionada correctamente, verifique que no este bloqueada o sin saldo", "Aceptar");
                return;
            }

            if (TSCustomerApp.ClientOuput.mtodisponible <= 0 || TSCustomerApp.ClientOuput.mtodisponible==null)
            {
                await DisplayAlert("Aviso", "Cliente no tiene saldo, no puede continuar la venta.", "Aceptar");
                return;
            }

            if (String.IsNullOrEmpty(contexto.Chofer))
            {
                await DisplayAlert("Aviso", "Ingrese datos del chofer.", "Aceptar");
                return;
            }
            if (String.IsNullOrEmpty(contexto.Placa))
            {
                await DisplayAlert("Aviso", "Ingrese número de placa.", "Aceptar");
                return;
            }
            if (String.IsNullOrEmpty(contexto.Odometro))
            {
                await DisplayAlert("Aviso", "Ingrese datos del Odómetro.", "Aceptar");
                return;
            }
            if (IsEvent)
            {
                SaveEvent(new Lado() {
                    Cara = this.Cara,
                    Placa = this.txtPlaca.Text,
                    Chofer = this.txtChofer.Text,
                    Codigo = this.txtCodigoCliente.Text,
                    Tarjeta_afiliacion  = "",
                    Ruc ="",                    
                    RazonSocial = contexto.Razon_social_cliente,
                    Direccion="",
                    Correo ="",
                    Tarjeta = contexto.Tarjeta,
                    Telefono = "",
                    Odometro = this.txtOdoMetro.Text,
                    Marca = "",
                    Modelo = "",
                    Fecha_Nacimiento = null,
                    Pago = "NOTA DESPACHO",
                    Documento = EDocumento.NotaDespacho,
                    
                });
                await Navigation.PopAsync();
                return;
            }
            TSSalesApp.vCabecera.nroplaca = contexto.Placa;
            TSSalesApp.vCabecera.chofer = contexto.Chofer;
            TSSalesApp.vCabecera.odometro = contexto.Odometro;
            TSSalesApp.vCabecera.nrotarjeta = contexto.Tarjeta;
            TSCustomerApp.ClientOuput.nroTarjeta = contexto.Tarjeta;
            TSCustomerApp.CdCliente = contexto.Codigo_cliente;
            TSCustomerApp.ClientOuput.tipocli = "";
            TSCustomerApp.TipoComprobante = TSSalesInput.NotaDeDespacho();
            TSCustomerApp.FlagSearch = true;

            await Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
              return true;
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            //Vertical
            if (height > width)
            {
                this.OrientationGridColumn1.Width = new GridLength(0);
                Grid.SetRow(OrientationStackTarjetaCliente, 0); Grid.SetColumn(OrientationStackTarjetaCliente, 0);
                Grid.SetRow(OrientationStackCodigoCliente, 1);  Grid.SetColumn(OrientationStackCodigoCliente, 0);
                Grid.SetRow(OrientationStackRazonSocial, 2);    Grid.SetColumn(OrientationStackRazonSocial, 0);
                Grid.SetRow(OrientationStackChofer, 3);         Grid.SetColumn(OrientationStackChofer, 0);
                Grid.SetRow(OrientationStackPlacaOdometro, 4);  Grid.SetColumn(OrientationStackPlacaOdometro, 0); Grid.SetColumnSpan(OrientationStackPlacaOdometro, 1);

            }
            //Horizontal
            else
            {
                this.OrientationGridColumn1.Width = new GridLength(1, GridUnitType.Star);
                Grid.SetRow(OrientationStackTarjetaCliente, 0); Grid.SetColumn(OrientationStackTarjetaCliente, 0);
                Grid.SetRow(OrientationStackCodigoCliente,0);   Grid.SetColumn(OrientationStackCodigoCliente, 1);
                Grid.SetRow(OrientationStackRazonSocial, 1);    Grid.SetColumn(OrientationStackRazonSocial, 0);
                Grid.SetRow(OrientationStackChofer, 1);         Grid.SetColumn(OrientationStackChofer, 1);
                Grid.SetRow(OrientationStackPlacaOdometro, 2);  Grid.SetColumn(OrientationStackPlacaOdometro, 0); Grid.SetColumnSpan(OrientationStackPlacaOdometro, 2);
            }

        }
    }
}