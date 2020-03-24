using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TerminalSiges.Helpers;
using TerminalSiges.Lib.Customer;
using TerminalSiges.Lib.Include;
using TerminalSiges.Lib.Sales;
using TerminalSiges.ViewModels;
using TerminalSiges.Views.Pages.Payment;
using TerminalSiges.Views.Pages.PopUp;
using TerminalSIGES.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Customer
{
    public partial class SearchCustomerAutomatic : ContentPage
    {
        public event OnSave SaveEvent;
        public delegate void OnSave(Lado respuesta);

        public Lado Lado;
        public BindingProgressCustomers contexto;

        public SearchCustomerAutomatic()
        {
            contexto = new BindingProgressCustomers();
            this.Lado = new Lado();
            this.Lado.Pago = "EFECTIVO";
            this.Lado.Pagos.Clear();
            this.Lado.Pagos.Add(new Pago() { Codigo = "00001"});
            this.BindingContext = contexto;

            TSCustomerApp.vCodigoBloqueado = new List<string>();
            TSCustomerApp.vTarjetasBuscadas = new List<string>();
            TSCustomerApp.vTarjetasBloqueadas = new List<string>();

            InitializeComponent();

        }
        public async void LoadConfiguration()
        {
            if(Lado.Documento == EDocumento.BoletaFactura)
            {
                return;
            }
            if(Lado.Documento == EDocumento.TranferenciaGratuita)
            {
                FormPagos.IsVisible = false;
                return;
            }
            if(Lado.Documento == EDocumento.Canje)
            {
                FormPagos.IsVisible = false;
                return;
            }
            else
            {
                await DisplayAlert("Aviso","Documento invalido","Aceptar");
                await Navigation.PopModalAsync();
                return;
            }
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
            contexto.Razon_social_cliente = respuesta.rscliente;
            contexto.Codigo_cliente = respuesta.cdcliente;
            contexto.Ruc_cliente = respuesta.ruccliente;
            contexto.Direccion_cliente = respuesta.drcliente;
            contexto.Placa = (respuesta.placa ?? "").Trim();
        }
        private async void search_tarjeta_click(object sender, EventArgs e)
        {
            TSCustomerApp.Ruc = this.txtCodigo.Text;
            TSCustomerApp.CdCliente = this.txtCodigo.Text;
            TSCustomerApp.afiliacionTarj = this.txtTarjetaAfiliacion.Text;

            if (String.IsNullOrEmpty(TSCustomerApp.afiliacionTarj))
            {
                await DisplayAlert("Aviso", "Ingrese el numero de tarjeta.", "Aceptar");
                return;
            }

            CustomerEstado resultado = CustomerEstado.ErrorSistema;

            await Task.Run(() =>
            {
                contexto.IsSearch = true;
                TSCustomerApp.ClientSearch += TSSalesApp_ClientSearch;
                resultado = TSCustomerApp.ObtenerClienteByTarjeta().Result;
            });
            if (resultado != CustomerEstado.EsperandoRespuesta)
            {

                switch (resultado)
                {
                    case CustomerEstado.ErrorInternet:
                        await DisplayAlert("Aviso", "Su dispositivo no cuenta con internet en estos momentos.", "Aceptar");
                        contexto.IsSearch = false;
                        break;
                    case CustomerEstado.ErrorSistema:
                        await DisplayAlert("Aviso", "Hubo un problema de comunicación con el servidor, por favor intente después.", "Aceptar");
                        contexto.IsSearch = false;
                        break;
                }
            }
        }

        private async void search_Cliente_click(object sender, EventArgs e)
        {
      
            TSCustomerApp.Ruc = this.txtCodigo.Text;
            TSCustomerApp.CdCliente = this.txtCodigo.Text;
            TSCustomerApp.afiliacionTarj = "";

            CustomerEstado resultado = CustomerEstado.ErrorSistema;
            await Task.Run(() =>
            {
                contexto.IsSearch = true;
                TSCustomerApp.ClientSearch += TSSalesApp_ClientSearch;
                resultado = TSCustomerApp.ObtenerClienteByRuc().Result;
            });
            if (resultado != CustomerEstado.EsperandoRespuesta)
            {
                switch (resultado)
                {
                    case CustomerEstado.ErrorInternet:
                        await DisplayAlert("Aviso", "Su dispositivo no cuenta con internet en estos momentos.", "Aceptar");
                        contexto.IsSearch = false;
                        break;
                    case CustomerEstado.ErrorSistema:
                        await DisplayAlert("Aviso", "Hubo un problema de comunicación con el servidor, por favor intente después.", "Aceptar");
                        contexto.IsSearch = false;
                        break;
                }
            }
        }

        private void TSSalesApp_ClientSearch(TSCustomer respuesta)
        {
            TSCustomerApp.ClientSearch -= TSSalesApp_ClientSearch;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == CustomerEstado.InformacionObtenida)
                {
                    TS_BEClienteOutput cliente = respuesta.vClientOuput;

                    if (cliente.Saldos != null)
                    {
                        TSCustomerApp.vCodigoBloqueado.Add(TSCustomerApp.ClientOuput.Saldos.nrotarjeta);
                        await DisplayAlert("Aviso", "No se puede ingresar una tarjeta de creditos en ventas al contado", "Aceptar");
                        contexto.IsSearch = false;
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
                            contexto.IsSearch = false;
                            return;
                        }
                        if (cliente.baja)
                        {
                            TSCustomerApp.vTarjetasBloqueadas.Add(txtTarjetaAfiliacion.Text);
                            await DisplayAlert("Aviso", "La tarjeta descrita esta dada de baja por lo cual no puede acumular puntos", "Aceptar");
                            contexto.IsSearch = false;
                            return;
                        }
                        TSCustomerApp.vTarjetasBuscadas.Add(txtTarjetaAfiliacion.Text);
                    }
                    if (cliente.Saldos != null)
                    {
                        await DisplayAlert("Aviso", "No se puede ingresar una tarjeta de creditos en ventas al contado", "Aceptar");
                        contexto.IsSearch = false;
                        return;
                    }

                    if (!String.IsNullOrEmpty(cliente.cdcliente))
                    {
                        contexto.Codigo_cliente = (cliente.cdcliente ?? "").Trim();
                    }
                    contexto.Ruc_cliente = (cliente.ruccliente ?? "").Trim();
                    contexto.Razon_social_cliente = (cliente.rscliente ?? "").Trim();
                    contexto.Direccion_cliente = (cliente.drcliente ?? "").Trim();
                    contexto.IsSearch = false;
                }
                if (respuesta.EstadoRespuesta == CustomerEstado.InformacionNoObtenida)
                {
                    await DisplayAlert("Aviso", respuesta.vClientOuput.Mensaje, "Aceptar");
                    contexto.IsSearch = false;
                    return;
                }
                if (respuesta.EstadoRespuesta == CustomerEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    contexto.IsSearch = false;
                    return;
                }
            });
        }

        public void OnContViewQuestion4(object sender, EventArgs e)
        {
            ContViewQuestion4.IsVisible = !ContViewQuestion4.IsVisible;
            if (ContViewQuestion4.IsVisible)
            {
                img4.Source = "iconCollapseOut.png";
            }
            else
            {
                img4.Source = "iconCollapse.png";
            }
        }

        #region EventosPagos
        private void OnCash(object sender,EventArgs e)
        {
            Lado.Pagos.Clear();
            Lado.Pagos.Add(new Pago() { Codigo = "00001", Tipo = "" });
            this.txtDetalleTipoPago.Text = "EFECTIVO";
        }
 
        private void OnCard(object sender, EventArgs e)
        {
            VisaPopUpCompleted Vista = new VisaPopUpCompleted();
            Vista.OnResponse += OnCardResponse;
            PopupNavigation.Instance.PushAsync(Vista);
        }

        private void OnCardResponse(bool approve, string reftarjeta, string cdtptarjeta)
        {
            if (approve)
            {
                Lado.Pagos.Clear();
                Lado.Pagos.Add(new Pago() { Codigo="00002",Tipo= cdtptarjeta,Referencia = reftarjeta });
                if (cdtptarjeta.Equals("01"))
                {
                    this.txtDetalleTipoPago.Text = "VISA - " + reftarjeta;
                    return;
                }
                if (cdtptarjeta.Equals("02"))
                {
                    this.txtDetalleTipoPago.Text = "MASTERCARD - " + reftarjeta;
                    return;
                }
                else
                {
                    this.txtDetalleTipoPago.Text = "TARJETA - " + reftarjeta;
                    return;
                }
            }
        }

        private void OnMixedPay(object sender, EventArgs e)
        {
            PaymentStart Vista = new PaymentStart(true);
            Vista.OnReponse += OnMixedPayResponse;
            Navigation.PushAsync(Vista);
        }

        private void OnMixedPayResponse(List<Pago> pagos)
        {
            Lado.Pagos.Clear();
            foreach (Pago pago in pagos)
            {
                Lado.Pagos.Add(pago);
            }
            this.txtDetalleTipoPago.Text = "PAGO MIXTO";
        }
        #endregion

        private void OnAceptar(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(TSSalesApp.vParemetros.flg_pideplacatb ?? false) && String.IsNullOrEmpty(contexto.Placa))
            {
                DisplayAlert("Aviso", "La placa es obligatoria", "Aceptar");
                return;
            }


            if ((contexto.Tarjeta_afiliacion_cliente ?? "").Length > 0)
            {
                if (TSCustomerApp.vTarjetasBuscadas.Count == 0)
                {
                    DisplayAlert("Aviso", "Debe buscar la tarjeta seleccionada", "Aceptar");
                    return;
                }
                else
                {
                    foreach (string tarjeta in TSCustomerApp.vTarjetasBloqueadas)
                    {
                        if (tarjeta.Equals(txtTarjetaAfiliacion.Text))
                        {
                            DisplayAlert("Aviso", "La tarjeta descrita en la busqueda esta bloqueada", "Aceptar");
                            return;
                        }
                    }
                    bool isbuscado = false;
                    foreach (string tarjeta in TSCustomerApp.vTarjetasBuscadas)
                    {
                        if ((tarjeta ?? "").Trim().Equals((txtTarjetaAfiliacion.Text ?? "").Trim()))
                        {
                            isbuscado = true;
                        }
                    }
                    if (isbuscado == false)
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
                if (validacion.Ok == false)
                {
                    DisplayAlert("Aviso", validacion.mensaje, "Aceptar");
                    return;
                }
                if (String.IsNullOrEmpty(contexto.Placa))
                {
                    DisplayAlert("Aviso", "La placa es obligatoria", "Aceptar");
                    return;
                }
            }
            else if ((this.txtCodigo.Text ?? "").Trim().Length != 11 && (this.txtRuc.Text ?? "").Trim().Length != 11)
            {
                TS_BEMensaje validacion = validateBoleta();
                if (validacion.Ok == false)
                {
                    DisplayAlert("Aviso", validacion.mensaje, "Aceptar");
                    return;
                }
            }

            /** FIN DE VALIDACIONES DE TIPO DE DOCUMENTO **/
            /** INICIO DE VALIDACIONES DE TARJETA CREDITO EN CLIENTES **/
            if (TSCustomerApp.vCodigoBloqueado.Count > 0)
            {
                foreach (string tarjeta in TSCustomerApp.vCodigoBloqueado)
                {
                    if (tarjeta.Equals((this.txtCodigo.Text ?? "").Trim()))
                    {
                        DisplayAlert("Aviso", "No puede utilizar una tarjeta credito en pagos al contado", "Aceptar");
                        return;
                    }
                }
            }
            var varVerificaCodigo = (txtCodigo.Text ?? "").Trim();
            if (varVerificaCodigo.Length > 0)
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

            if (Lado.Documento == EDocumento.BoletaFactura)
            {
                Lado.Placa = String.IsNullOrEmpty(this.txtPlaca.Text) ? this.txtPlaca2.Text : this.txtPlaca.Text;
                Lado.Codigo = this.txtCodigo.Text;
                Lado.Tarjeta_afiliacion = this.txtTarjetaAfiliacion.Text;
                Lado.Ruc = this.txtRuc.Text;
                Lado.RazonSocial = this.txtRscliente.Text;
                Lado.Direccion = this.txtDireccion.Text;
                Lado.Correo = this.txtEmail.Text;
                Lado.Telefono = this.txtTelefono.Text;
                Lado.Odometro = this.txtOdometro.Text;
                Lado.Marca = this.txtMarca.Text;
                Lado.Modelo = this.txtModelo.Text;
                Lado.Fecha_Nacimiento = this.txtfecNac.Date;
                Lado.Pago = this.txtDetalleTipoPago.Text;
            }
            if(Lado.Documento == EDocumento.Canje)
            {
                Lado.Placa = String.IsNullOrEmpty(this.txtPlaca.Text) ? this.txtPlaca2.Text : this.txtPlaca.Text;
                Lado.Codigo = this.txtCodigo.Text;
                Lado.Tarjeta_afiliacion = this.txtTarjetaAfiliacion.Text;
                Lado.Ruc = this.txtRuc.Text;
                Lado.RazonSocial = this.txtRscliente.Text;
                Lado.Direccion = this.txtDireccion.Text;
                Lado.Correo = this.txtEmail.Text;
                Lado.Telefono = this.txtTelefono.Text;
                Lado.Odometro = this.txtOdometro.Text;
                Lado.Marca = this.txtMarca.Text;
                Lado.Modelo = this.txtModelo.Text;
                Lado.Fecha_Nacimiento = this.txtfecNac.Date;
                Lado.Pago = "CANJE DE PROD.";
                Lado.Pagos.Clear();
                Lado.Pagos.Add(new Pago() { Codigo = "00001" });
            }
            if(Lado.Documento == EDocumento.TranferenciaGratuita)
            {
                Lado.Placa = String.IsNullOrEmpty(this.txtPlaca.Text) ? this.txtPlaca2.Text : this.txtPlaca.Text;
                Lado.Codigo = this.txtCodigo.Text;
                Lado.Tarjeta_afiliacion = this.txtTarjetaAfiliacion.Text;
                Lado.Ruc = this.txtRuc.Text;
                Lado.RazonSocial = this.txtRscliente.Text;
                Lado.Direccion = this.txtDireccion.Text;
                Lado.Correo = this.txtEmail.Text;
                Lado.Telefono = this.txtTelefono.Text;
                Lado.Odometro = this.txtOdometro.Text;
                Lado.Marca = this.txtMarca.Text;
                Lado.Modelo = this.txtModelo.Text;
                Lado.Fecha_Nacimiento = this.txtfecNac.Date;
                Lado.Pago = "TRANF. GRATUITA";
                Lado.Pagos.Clear();
                Lado.Pagos.Add(new Pago() { Codigo = "00001" });
            }

            SaveEvent(Lado);
            Navigation.PopModalAsync();
        }
        private async void OnCancelar(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private TS_BEMensaje validateFactura()
        {
            string razonSocial = (contexto.Razon_social_cliente ?? "").Trim();
            string drcliente = (contexto.Direccion_cliente ?? "").Trim();
            string ruc = (contexto.Ruc_cliente ?? "").Trim();
            string cdcliente = (contexto.Codigo_cliente ?? "").Trim();
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
            if ((Helper.IsRucValido((ruc ?? "").Trim())) == false)
            {
                iserror = true;
                errores += "El ruc descrito es inválido \n";
            }
            if (String.IsNullOrEmpty(cdcliente))
            {
                iserror = true;
                errores += "El código de cliente no puede estar vacío\n";
            }

            return new TS_BEMensaje() { mensaje = errores, Ok = !iserror };
        }
        public TS_BEMensaje validateBoleta()
        {
            string razonSocial = (contexto .Razon_social_cliente?? "").Trim();
            string drcliente = (contexto.Direccion_cliente ?? "").Trim();
            string ruc = (contexto.Ruc_cliente ?? "").Trim();
            string cdcliente = (contexto.Codigo_cliente ?? "").Trim();
            string errores = "";
            bool iserror = false;

            if (ruc.Length != 0)
            {
                iserror = true;
                errores += "Para ventas con DNI solo se debe ingresar el DNI en código\n";
            }
            if (String.IsNullOrEmpty(cdcliente) && razonSocial.Length != 0)
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
    }
}