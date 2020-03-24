using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TerminalSiges.Helpers;
using TerminalSiges.Lib.Customer;
using TerminalSiges.Lib.Include;
using TerminalSiges.Lib.Sales;
using Xamarin.Forms;
using TerminalSiges.ViewModels;
using System.Runtime.CompilerServices;

namespace TerminalSiges.Views.Pages.Customer
{

    public partial class SearchCustomer : ContentPage
    {

        private TS_BEClienteOutput cliente;
        private BindingProgressCustomers ContextBinding;
        private bool isBuscado = false;
        private bool Cargado = false;

        public SearchCustomer()
        {
            ContextBinding = new BindingProgressCustomers();
            BindingContext = ContextBinding;
            TSCustomerApp.vCodigoBloqueado = new List<string>();
            cliente = new TS_BEClienteOutput();
            InitializeComponent();
            TSCustomerApp.FlagSearch = false;
            TSCustomerApp.vTarjetasBuscadas = new List<string>();
            TSCustomerApp.vTarjetasBloqueadas = new List<string>();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) { return; }
            this.txtCodigo.Focus();
            Cargado = true;
        }

        private async void search_placa_click(object sender, EventArgs e)
        {
            SearchCustomerByPlaca View = new SearchCustomerByPlaca();
            View.ClientSelected += _ClientSelected;
            await Navigation.PushAsync(View);
        }

        private async void search_rscliente_click(object sender, EventArgs e)
        {
            SearchCustomerByName View = new SearchCustomerByName();
            View.ClientSelected += _ClientSelected;
            await Navigation.PushAsync(View);
        }

        private void _ClientSelected(TS_BEClienteLista respuesta)
        {
            ContextBinding.Codigo_cliente = (respuesta.cdcliente ?? "").Trim();
            ContextBinding.Ruc_cliente = (respuesta.ruccliente ?? "").Trim();
            ContextBinding.Razon_social_cliente = (respuesta.rscliente ?? "").Trim();
            ContextBinding.Direccion_cliente = (respuesta.drcliente ?? "").Trim();
            ContextBinding.Placa = (respuesta.placa ?? "").Trim();
            ContextBinding.IsSearch = false;
        }

        private async void search_Cliente_click(object sender, EventArgs e)
        {
            ContextBinding.IsSearch = true;
            TSCustomerApp.Ruc = this.txtCodigo.Text;
            TSCustomerApp.CdCliente = this.txtCodigo.Text;
            TSCustomerApp.afiliacionTarj = "";

            CustomerEstado resultado = CustomerEstado.ErrorSistema;
            busyindicator.IsVisible = true;
            await Task.Run(() =>
            {
                TSCustomerApp.ClientSearch += TSSalesApp_ClientSearch; 
                resultado = TSCustomerApp.ObtenerClienteByRuc().Result;
            });
            if (resultado != CustomerEstado.EsperandoRespuesta)
            {
                busyindicator.IsVisible = false;
                ContextBinding.IsSearch = false;
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

        private void TSSalesApp_ClientSearch(TSCustomer respuesta)
        {
            TSCustomerApp.ClientSearch -= TSSalesApp_ClientSearch;
            Device.BeginInvokeOnMainThread(async () =>
            {

                busyindicator.IsVisible = false;
                ContextBinding.IsSearch = false;

                if (respuesta.EstadoRespuesta == CustomerEstado.InformacionObtenida)
                {
                    cliente = respuesta.vClientOuput;

                    if (cliente.Saldos != null)
                    {
                        TSCustomerApp.vCodigoBloqueado.Add(TSCustomerApp.ClientOuput.Saldos.nrotarjeta);
                        await DisplayAlert("Aviso", "No se puede ingresar una tarjeta de creditos en ventas al contado", "Aceptar");
                        return;
                    }
                    if (cliente.isafiliacion)
                    {
                        TSCustomerApp.vTarjetasBloqueadas.Clear();
                        TSCustomerApp.vTarjetasBuscadas.Clear();
                        if (cliente.bloqueado)
                        {

                            TSCustomerApp.vTarjetasBloqueadas.Add(txtTarjetaAfiliacion.Text);
                            await DisplayAlert("Aviso", "La tarjeta descrita esta bloqueada", "Aceptar");
                            return;
                        }
                        if (cliente.baja)
                        {
                            TSCustomerApp.vTarjetasBloqueadas.Add(txtTarjetaAfiliacion.Text);
                            await DisplayAlert("Aviso", "La tarjeta descrita esta dada de baja por lo cual no puede acumular puntos", "Aceptar");
                            return;
                        }
                        TSCustomerApp.vTarjetasBuscadas.Add(txtTarjetaAfiliacion.Text);
                    }
                    if (cliente.Saldos != null)
                    {
                        await DisplayAlert("Aviso", "No se puede ingresar una tarjeta de creditos en ventas al contado", "Aceptar");
                        return;
                    }

                    if (!String.IsNullOrEmpty(cliente.cdcliente))
                    {
                        ContextBinding.Codigo_cliente = (cliente.cdcliente ?? "").Trim();
                    }
                    ContextBinding.Ruc_cliente = (cliente.ruccliente ?? "").Trim();
                    ContextBinding.Razon_social_cliente = (cliente.rscliente ?? "").Trim(); 
                    ContextBinding.Direccion_cliente = (cliente.drcliente ?? "").Trim();
                }
                if (respuesta.EstadoRespuesta == CustomerEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", respuesta.vClientOuput == null ? "La tarjeta no existe" : respuesta.vClientOuput.Mensaje, "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == CustomerEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
            });
        }

        private  void BtnSave_Clicked(object sender, EventArgs e)
        {
            /** INICIO DE VALIDACIONES DE TARJETAS DE ACUMULACION DE PUNTOS **/
            if((this.txtTarjetaAfiliacion.Text ?? "").Length > 0)
            {
                if (TSCustomerApp.vTarjetasBuscadas.Count == 0)
                {
                    DisplayAlert("Aviso", "Debe buscar la tarjeta seleccionada","Aceptar");
                    return;
                }
                else
                {
                    foreach(string tarjeta in TSCustomerApp.vTarjetasBloqueadas)
                    {
                        if (tarjeta.Equals(txtTarjetaAfiliacion.Text))
                        {
                            DisplayAlert("Aviso", "La tarjeta descrita en la busqueda esta bloqueada", "Aceptar");
                            return;
                        }
                    }
                    bool isbuscado = false;
                    foreach(string tarjeta in TSCustomerApp.vTarjetasBuscadas)
                    {
                        if ((tarjeta ?? "").Trim().Equals( (txtTarjetaAfiliacion.Text ?? "" ).Trim()))
                        {
                            isbuscado = true;
                        }
                    }
                    if(isbuscado == false)
                    {
                        DisplayAlert("Aviso", "Debe buscar la tarjeta descrita", "Aceptar");
                        return;
                    }
                }
            }
            /**FIN VALIDACIONES DE TARJETAS DE PUNTOS**/

            /** INICIO DE VALIDACIONES DE TIPO DE DOCUMENTO**/

            if ((this.txtCodigo.Text ?? "").Trim().Length == 11 || (this.txtRuc.Text ?? "").Trim().Length == 11)
            {
                TS_BEMensaje validacion = validateFactura();
                if (validacion.Ok)
                {
                    TSCustomerApp.TipoComprobante = TSSalesInput.Factura();
                }
                else
                {
                    DisplayAlert("Aviso", validacion.mensaje, "Aceptar");
                    return;
                }
            }
            else if((this.txtCodigo.Text ?? "").Trim().Length !=11 && (this.txtRuc.Text ?? "").Trim().Length != 11)
            {
                TS_BEMensaje validacion = validateBoleta();
                if (validacion.Ok)
                {
                    TSCustomerApp.TipoComprobante = TSSalesInput.Boleta();
                }
                else
                {
                    DisplayAlert("Aviso", validacion.mensaje, "Aceptar");
                    return;
                }
                
            }

            /** FIN DE VALIDACIONES DE TIPO DE DOCUMENTO **/
            /** INICIO DE VALIDACIONES DE TARJETA CREDITO EN CLIENTES **/
            if(TSCustomerApp.vCodigoBloqueado.Count > 0)
            {
                foreach(string tarjeta in TSCustomerApp.vCodigoBloqueado)
                {
                    if(tarjeta.Equals((this.txtCodigo.Text ?? "").Trim()))
                    {
                        DisplayAlert("Aviso", "No puede utilizar una tarjeta credito en pagos al contado", "Aceptar");
                        return;
                    }
                }
            }
            var varVerificaCodigo = (txtCodigo.Text ?? "").Trim(); 
            if (varVerificaCodigo.Length>0)
            {
                string creditoCorp = (TSSalesApp.vParemetros.prefcredcorp ?? "").Trim();
                string creditoLocal = (TSSalesApp.vParemetros.prefcredlocal ?? "").Trim();
                string creditoFlot = (TSSalesApp.vParemetros.prefflotlocal ?? "").Trim();
                if (varVerificaCodigo.Length >= creditoCorp.Length)
                {
                    if (varVerificaCodigo.Substring(0, creditoCorp.Length).Equals(creditoCorp))
                    {
                        DisplayAlert("Aviso", "No puede pasar una tarjeta coorporativa en ventas al contado", "Aceptar");
                        return;
                    }
                }
                if (varVerificaCodigo.Length >= creditoLocal.Length)
                {
                    if (varVerificaCodigo.Substring(0, creditoLocal.Length).Equals(creditoLocal))
                    {
                        DisplayAlert("Aviso", "No puede pasar una tarjeta de credito local en ventas al contado", "Aceptar");
                        return;
                    }
                }
                if (varVerificaCodigo.Length >= creditoFlot.Length)
                {
                    if (varVerificaCodigo.Substring(0, creditoFlot.Length).Equals(creditoFlot))
                    {
                        DisplayAlert("Aviso", "No puede pasar una tarjeta de flota en ventas al contado", "Aceptar");
                        return;
                    }
                }
            }
            /** FIN DE VALIDACIONES DE TARJETA CREDITO EN CLIENTES **/

            TSCustomerApp.ClientOuput.rscliente = this.txtRscliente.Text;
            TSCustomerApp.ClientOuput.drcliente = this.txtDireccion.Text;
            TSCustomerApp.ClientOuput.ruccliente = this.txtRuc.Text;
            TSCustomerApp.ClientOuput.emcliente = this.txtEmail.Text;
            TSCustomerApp.ClientOuput.cdcliente = this.txtCodigo.Text;
            TSCustomerApp.ClientOuput.tarjafiliacion = this.txtTarjetaAfiliacion.Text;
            TSCustomerApp.ClientOuput.puntos = (this.txtTarjetaAfiliacion.Text ?? "").Equals((cliente.tarjafiliacion ?? "").Trim()) ? cliente.puntos : 0;
            TSCustomerApp.ClientOuput.valoracumula = (this.txtTarjetaAfiliacion.Text ?? "").Equals((cliente.tarjafiliacion ?? "").Trim()) ? cliente.valoracumula : 0;
            TSCustomerApp.ClientOuput.isafiliacion = (this.txtTarjetaAfiliacion.Text ?? "").Equals((cliente.tarjafiliacion ?? "").Trim());
            TSSalesApp.vCabecera.nroplaca = this.txtPlaca.Text;
            TSCustomerApp.FlagSearch = true;
            Navigation.PopAsync();
        }

        private void Codigo_LayoutChanged(object sender, EventArgs e)
        {
            var t = e;
        }

        private void TxtCodigo_TextChanged(object sender, TextChangedEventArgs e)
        {


            var te = e.NewTextValue;

        }

        private void TxtCodigo_Completed(object sender, EventArgs e)
        {
            var t = e;
        }

        public TS_BEMensaje validateFactura()
        {
            string razonSocial = (this.txtRscliente.Text ?? "").Trim();
            string drcliente = (this.txtDireccion.Text ?? "").Trim();
            string ruc = (this.txtRuc.Text ?? "").Trim();
            string cdcliente = (this.txtCodigo.Text ?? "").Trim();
            string errores = "";
            bool iserror = false;

            if (String.IsNullOrEmpty(razonSocial))
            {
                iserror = true;
                errores += "La razon social no puede ir en blanco \n";
            }
            if (String.IsNullOrEmpty(drcliente))
            {
                iserror = true;
                errores += "La dirección en facturas es obligatoria \n";
            }
            if( (Helper.IsRucValido((ruc ?? "").Trim())) == false)
            {
                iserror = true;
                errores += "El ruc descrito es inválido \n";
            }
            if (String.IsNullOrEmpty(cdcliente))
            {
                iserror = true;
                errores += "El código de cliente no puede estar vacío\n";
            }

            return new TS_BEMensaje() { mensaje = errores , Ok = !iserror};
        }
        public TS_BEMensaje validateBoleta()
        {
            string razonSocial = (this.txtRscliente.Text ?? "").Trim();
            string drcliente = (this.txtDireccion.Text ?? "").Trim();
            string ruc = (this.txtRuc.Text ?? "").Trim();
            string cdcliente = (this.txtCodigo.Text ?? "").Trim();
            string errores = "";
            bool iserror = false;

            if (ruc.Length != 0)
            {
                iserror = true;
                errores += "Para ventas con DNI solo se debe ingresar el DNI en código\n";
            }
            if (String.IsNullOrEmpty(cdcliente) && razonSocial.Length!=0)
            {
                iserror = true;
                errores += "El codigo es obligatoria si se desea colocar la razon social\n";
            }
            if (cdcliente.Length == 8 && String.IsNullOrEmpty(razonSocial))
            {
                iserror = true;
                errores += "Para ventas con DNI el nombre es obligatorio\n";
            }
            return new TS_BEMensaje() { mensaje = errores, Ok = !iserror };
        }
        
        private async void search_tarjeta_click(object sender, EventArgs e)
        {
            ContextBinding.IsSearch = true;
            TSCustomerApp.Ruc = this.txtCodigo.Text;
            TSCustomerApp.CdCliente = this.txtCodigo.Text;
            TSCustomerApp.afiliacionTarj = this.txtTarjetaAfiliacion.Text;
            TSCustomerApp.prefijo = "";
            TSCustomerApp.IsArticulo = false;
            if (String.IsNullOrEmpty(TSCustomerApp.afiliacionTarj))
             {
                busyindicator.IsVisible = false;
                ContextBinding.IsSearch = false;
                await DisplayAlert("Aviso", "Ingrese el numero de tarjeta.", "Aceptar");
                return;
             }

             CustomerEstado resultado = CustomerEstado.ErrorSistema;
             busyindicator.IsVisible = true;
             await Task.Run(() =>
             {
                 TSCustomerApp.ClientSearch += TSSalesApp_ClientSearch;
                 resultado = TSCustomerApp.ObtenerClienteByTarjeta().Result;
             });
             if (resultado != CustomerEstado.EsperandoRespuesta)
             {
                busyindicator.IsVisible = false;
                ContextBinding.IsSearch = false;
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
                Grid.SetRow(OrientationStackOne, 1);
                Grid.SetColumn(OrientationStackOne, 0);
                Grid.SetColumnSpan(OrientationStackOne, 2);
                this.OrientationGridColumn1.Width = new GridLength(0.00);

                this.OrientationStackTwo.Orientation = StackOrientation.Vertical;
            }
            //Horizontal
            else
            {
                Grid.SetRow(OrientationStackOne, 0);
                Grid.SetColumn(OrientationStackOne, 2);
                Grid.SetColumnSpan(OrientationStackOne, 1);
                this.OrientationGridColumn1.Width = new GridLength(1, GridUnitType.Star);

                this.OrientationStackTwo.Orientation = StackOrientation.Horizontal;
            }

        }
    }
}