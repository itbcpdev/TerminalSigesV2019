using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using Syncfusion.SfNumericTextBox.XForms;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TerminalSiges.Lib.Customer;
using TerminalSiges.Lib.Sales;
using TerminalSiges.Views.Pages.Invoce;
using TerminalSIGES.Services;
using Xamarin.Forms;
using Syncfusion.XForms.TextInputLayout;
using FocusEventArgs = Xamarin.Forms.FocusEventArgs;
using System.Windows.Input;
using TerminalSiges.Helpers;

namespace TerminalSiges.Views.Pages.Payment
{

    public partial class PaymentStart : ContentPage
    {
        public event OnEvent OnReponse;
        public delegate void OnEvent(List<TerminalSIGES.Models.Pago> pagos);

        private bool IsEvent;
        public bool Cargado = false;
        private bool flagPlaca = false;
        private int contador = 0;
        private int contadortarjeta = 0;
        IFeatureService FeatureService;
        private ToolbarItem ItemGuardar;

        public PaymentStart(bool IsEvent)
        {
            InitializeComponent();
            this.IsEvent = IsEvent;
            InitialiteToolBar();
        }
        public PaymentStart()
        {
            FeatureService = DependencyService.Get<IFeatureService>();
            InitializeComponent();
            IsEvent = false;
            InitialiteToolBar();
        }
        private void InitialiteToolBar()
        {
            ItemGuardar = new ToolbarItem() { Text = "Guardar", Order = ToolbarItemOrder.Primary, Priority = 0 };
            ItemGuardar.Clicked += BtnSaveEfectivo_Clicked;
            this.ToolbarItems.Add(ItemGuardar);
            this.ConIgv.IsVisible = Convert.ToBoolean(TSSalesApp.vParemetros.conigv ?? false);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) return;
            if (flagPlaca) return;
            cboTarjeta1.DataSource = TSSalesApp.vTarjetas;
            cboTarjeta2.DataSource = TSSalesApp.vTarjetas;
            cboTarjeta3.DataSource = TSSalesApp.vTarjetas;


            this.txtEfectivoSolesVenta.Focus();
            this.txtTipoCambio.Text = TSSalesApp.TipoCambio.ToString();
            /** SI ES LLAMADO DESDE MODO AUTOMATICO**/
            if (IsEvent)
            {
                this.txtMonTotalSoles.Text = "";
                this.txtEfectivoSolesVenta.Value = "";
                this.txtMonTotalDolar.Text = "";
                this.txtMonTotalVueltoVenta.Text = "";
            }
            else
            {
                this.txtMonTotalSoles.Text = TSSalesApp.vCabecera.mtototal.ToString();
                this.txtEfectivoSolesVenta.Value = TSSalesApp.vCabecera.mtototal.ToString();
                this.txtMonTotalDolar.Text = (Math.Round((TSSalesApp.vCabecera.mtototal / TSSalesApp.TipoCambio), 2)).ToString();
                this.txtMonTotalVueltoVenta.Text = TSSalesApp.vCabecera.mtovueltosol.ToString();
            }


            ClearSalesTarget();
        }

        private void TxtEfectivoDolarVenta_FocusChanged(object sender, Syncfusion.SfNumericTextBox.XForms.FocusEventArgs e)
        {

            if (contador == 0)
            {
                this.txtEfectivoDolarVenta.Value = this.txtMonTotalDolar.Text;
                this.txtEfectivoSolesVenta.Value = "";
                contador += 1;
            }

            if (e.HasFocus == false)
            {
                if (IsEvent)
                {
                    this.txtMtoTarjeta01.IsEnabled = true;
                    this.txtMtoTarjeta01.IsVisible = true;
                    this.txtNroOperacion1.IsEnabled = true;
                    this.txtNroOperacion1.IsVisible = true;
                    this.cboTarjeta1.IsEnabled = true;
                    this.cboTarjeta1.IsVisible = true;
                    this.sfTxtMtoTarjeta01.IsVisible = true;
                    this.sfTxtMtoTarjeta01.IsEnabled = true;
                    this.imgDeletePago1.IsVisible = true;
                    this.txtMtoTarjeta01.Text = (0.00).ToString();
                }
                decimal efectivoDolarVenta = Convert.ToDecimal(this.txtEfectivoDolarVenta.Value == null ? "0" :
                                             this.txtEfectivoDolarVenta.Value.GetType() == typeof(string) ? (String.IsNullOrEmpty(Convert.ToString(this.txtEfectivoDolarVenta.Value)) ? "0" : this.txtEfectivoDolarVenta.Value) :
                                             this.txtEfectivoDolarVenta.Value) * Convert.ToDecimal(this.txtTipoCambio.Text);
                decimal efectivoSolesVenta = Convert.ToDecimal(this.txtEfectivoSolesVenta.Value == null ? "0" :
                                             this.txtEfectivoSolesVenta.Value.GetType() == typeof(string) ? (String.IsNullOrEmpty(Convert.ToString(this.txtEfectivoSolesVenta.Value)) ? "0" : this.txtEfectivoSolesVenta.Value) :
                                             this.txtEfectivoSolesVenta.Value);

                decimal Monto = Math.Round(efectivoDolarVenta + efectivoSolesVenta, 2);

                decimal TotalAPagar = Math.Round(Convert.ToDecimal(this.txtMonTotalSoles.Text), 2);
                if (Monto < TotalAPagar)
                {
                    this.txtMtoTarjeta01.IsEnabled = true;
                    this.txtMtoTarjeta01.IsVisible = true;
                    this.txtNroOperacion1.IsEnabled = true;
                    this.txtNroOperacion1.IsVisible = true;
                    this.cboTarjeta1.IsEnabled = true;
                    this.cboTarjeta1.IsVisible = true;
                    this.sfTxtMtoTarjeta01.IsVisible = true;
                    this.sfTxtMtoTarjeta01.IsEnabled = true;
                    this.imgDeletePago1.IsVisible = true;
                    this.txtMtoTarjeta01.Text = (TotalAPagar - Monto).ToString();
                }

                else
                {
                    ClearSalesTarget();
                }
                this.CalcularTotales();
            }
        }

        private void TxtEfectivoSolesVenta_FocusChanged(object sender, Syncfusion.SfNumericTextBox.XForms.FocusEventArgs e)
        {

            if (e.HasFocus == false)
            {
                if (IsEvent)
                {
                    this.txtMtoTarjeta01.IsEnabled = true;
                    this.txtMtoTarjeta01.IsVisible = true;
                    this.txtNroOperacion1.IsEnabled = true;
                    this.txtNroOperacion1.IsVisible = true;
                    this.cboTarjeta1.IsEnabled = true;
                    this.cboTarjeta1.IsVisible = true;
                    this.sfTxtMtoTarjeta01.IsVisible = true;
                    this.sfTxtMtoTarjeta01.IsEnabled = true;
                    this.imgDeletePago1.IsVisible = true;
                    this.txtMtoTarjeta01.Text = (0.00).ToString();
                    return;
                }

                decimal efectivoDolarVenta = Convert.ToDecimal(this.txtEfectivoDolarVenta.Value == null ? "0" :
                                             this.txtEfectivoDolarVenta.Value.GetType() == typeof(string) ? (String.IsNullOrEmpty(Convert.ToString(this.txtEfectivoDolarVenta.Value)) ? "0" : this.txtEfectivoDolarVenta.Value) :
                                             this.txtEfectivoDolarVenta.Value) * Convert.ToDecimal(this.txtTipoCambio.Text);
                decimal efectivoSolesVenta = Convert.ToDecimal(this.txtEfectivoSolesVenta.Value == null ? "0" :
                                             this.txtEfectivoSolesVenta.Value.GetType() == typeof(string) ? (String.IsNullOrEmpty(Convert.ToString(this.txtEfectivoSolesVenta.Value)) ? "0" : this.txtEfectivoSolesVenta.Value) :
                                             this.txtEfectivoSolesVenta.Value);

                decimal Monto = Math.Round(efectivoDolarVenta + efectivoSolesVenta, 2);

                decimal TotalAPagar = Math.Round(Convert.ToDecimal(this.txtMonTotalSoles.Text), 2);
                if (Monto < TotalAPagar)
                {
                    this.txtMtoTarjeta01.IsEnabled = true;
                    this.txtMtoTarjeta01.IsVisible = true;
                    this.txtNroOperacion1.IsEnabled = true;
                    this.txtNroOperacion1.IsVisible = true;
                    this.cboTarjeta1.IsEnabled = true;
                    this.cboTarjeta1.IsVisible = true;
                    this.sfTxtMtoTarjeta01.IsVisible = true;
                    this.sfTxtMtoTarjeta01.IsEnabled = true;
                    this.imgDeletePago1.IsVisible = true;
                    this.txtMtoTarjeta01.Text = (TotalAPagar - Monto).ToString();
                }
                else
                {
                    ClearSalesTarget();
                }
                this.CalcularTotales();
            }
        }

        private void ClearSalesTarget()
        {
            this.txtMtoTarjeta01.IsEnabled = false;
            this.txtMtoTarjeta01.IsVisible = false;
            this.txtMtoTarjeta01.Text = String.Empty;
            this.sfTxtMtoTarjeta01.IsVisible = false;
            this.sfTxtMtoTarjeta01.IsEnabled = false;
            this.txtNroOperacion1.IsEnabled = false;
            this.txtNroOperacion1.IsVisible = false;
            this.txtNroTarjeta01.Text = "";
            this.cboTarjeta1.IsEnabled = false;
            this.cboTarjeta1.IsVisible = false;
            this.cboTarjeta1.SelectedValue = null;
            this.imgDeletePago1.IsVisible = false;

            this.txtMtoTarjeta02.IsEnabled = false;
            this.txtMtoTarjeta02.IsVisible = false;
            this.txtNroOperacion2.IsEnabled = false;
            this.txtNroOperacion2.IsVisible = false;
            this.cboTarjeta2.IsEnabled = false;
            this.cboTarjeta2.IsVisible = false;
            this.txtMtoTarjeta02.Text = String.Empty;
            this.sfTxtMtoTarjeta02.IsVisible = false;
            this.sfTxtMtoTarjeta02.IsEnabled = false;
            this.imgDeletePago2.IsVisible = false;

            this.txtMtoTarjeta03.IsEnabled = false;
            this.txtMtoTarjeta03.IsVisible = false;
            this.txtNroOperacion3.IsEnabled = false;
            this.txtNroOperacion3.IsVisible = false;
            this.sfTxtMtoTarjeta03.IsVisible = false;
            this.sfTxtMtoTarjeta03.IsEnabled = false;
            this.cboTarjeta3.IsEnabled = false;
            this.cboTarjeta3.IsVisible = false;
            this.txtMtoTarjeta03.Text = String.Empty;
            this.imgDeletePago3.IsVisible = false;

        }

        private void TxtEfectivoSolesVenta_Completed(object sender, EventArgs e)
        {
            var te = (SfNumericTextBox)sender;

        }
        private void TxtEfectivoDolarVenta_ValueChanged(object sender, ValueEventArgs e)
        {


        }
        private void TxtEfectivoSolesVenta_ValueChanged(object sender, ValueEventArgs e)
        {

        }
        private void CboTarjeta1_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            if (e.Value != null)
            {
                txtNroOperacion1.IsEnabled = true;
                txtMtoTarjeta01.IsEnabled = true;
                imgDeletePago1.IsVisible = true;
            }
            else
            {
                txtNroOperacion1.IsEnabled = false;
                txtMtoTarjeta01.IsEnabled = false;
                imgDeletePago1.IsVisible = true;
            }
        }
        private void CboTarjeta2_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            if (e.Value != null)
            {
                txtNroOperacion2.IsEnabled = true;
                txtMtoTarjeta02.IsEnabled = true;
                imgDeletePago2.IsVisible = true;
            }
            else
            {
                txtNroOperacion2.IsEnabled = false;
                txtMtoTarjeta02.IsEnabled = false;
                imgDeletePago2.IsVisible = false;
            }
        }
        private void CboTarjeta3_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            if (e.Value != null)
            {
                txtNroOperacion3.IsEnabled = true;
                txtMtoTarjeta03.IsEnabled = true;
                imgDeletePago3.IsVisible = true;
            }
            else
            {
                txtNroOperacion3.IsEnabled = false;
                txtMtoTarjeta03.IsEnabled = false;
                imgDeletePago3.IsVisible = false;
            }
        }
        private void TxtMtoTarjeta01_OnFocused(object sender, FocusEventArgs e)
        {
            var value = this.txtMtoTarjeta01.Text;
            if (value != "")
            {
                decimal monto = Convert.ToDecimal(value);
                if (monto > 0)
                {
                    if (IsEvent)
                    {
                        this.cboTarjeta2.IsEnabled = true;
                        this.cboTarjeta2.IsVisible = true;
                        this.txtNroOperacion2.IsVisible = true;
                        this.txtMtoTarjeta02.IsVisible = true;
                        this.sfTxtMtoTarjeta02.IsVisible = true;
                        this.imgDeletePago2.IsVisible = true;
                        this.txtMtoTarjeta02.Text = "0";
                        return;
                    }
                    this.CalcularTotales();
                    if (TSSalesApp.vCabecera.mtototal > TSSalesApp.vCabecera.mtorecaudo)
                    {
                        this.cboTarjeta2.IsEnabled = true;
                        this.cboTarjeta2.IsVisible = true;
                        this.txtNroOperacion2.IsVisible = true;
                        this.txtMtoTarjeta02.IsVisible = true;
                        this.sfTxtMtoTarjeta02.IsVisible = true;
                        this.imgDeletePago2.IsVisible = true;
                        this.txtMtoTarjeta02.Text = Math.Round(TSSalesApp.vCabecera.mtototal - TSSalesApp.vCabecera.mtorecaudo, 2).ToString();

                    }
                    else
                    {
                        this.cboTarjeta2.IsEnabled = false;
                        this.txtMtoTarjeta02.Text = "";
                        this.cboTarjeta2.IsVisible = false;
                        this.txtNroOperacion2.IsVisible = false;
                        this.sfTxtMtoTarjeta02.IsVisible = false;
                        this.txtMtoTarjeta02.IsVisible = false;
                        this.imgDeletePago2.IsVisible = false;
                    }
                }
            }
        }
    
        private void TxtMtoTarjeta02_OnFocused(object sender, FocusEventArgs e)
        {
            var value = this.txtMtoTarjeta02.Text;
            if (value != "")
            {
                decimal monto = Convert.ToDecimal(value);

                if (monto > 0)
                {
                    if (IsEvent)
                    {
                        this.cboTarjeta3.IsEnabled = true;
                        this.cboTarjeta3.IsVisible = true;
                        this.txtNroOperacion3.IsVisible = true;
                        this.txtMtoTarjeta03.IsVisible = true;
                        this.imgDeletePago3.IsVisible = true;
                        this.sfTxtMtoTarjeta03.IsVisible = true;
                        this.txtMtoTarjeta03.Text = "";
                        return;
                    }
                    this.CalcularTotales();
                    if (TSSalesApp.vCabecera.mtototal > TSSalesApp.vCabecera.mtorecaudo)
                    {
                        this.cboTarjeta3.IsEnabled = true;
                        this.cboTarjeta3.IsVisible = true;
                        this.txtNroOperacion3.IsVisible = true;
                        this.txtMtoTarjeta03.IsVisible = true;
                        this.imgDeletePago3.IsVisible = true;
                        this.sfTxtMtoTarjeta03.IsVisible = true;
                        this.txtMtoTarjeta03.Text = Math.Round(TSSalesApp.vCabecera.mtototal - TSSalesApp.vCabecera.mtorecaudo, 2).ToString();

                    }
                    else
                    {
                        this.cboTarjeta3.IsEnabled = false;
                        this.cboTarjeta3.IsVisible = false;
                        this.txtNroOperacion3.IsVisible = false;
                        this.txtMtoTarjeta03.IsVisible = false;
                        this.imgDeletePago3.IsVisible = false;
                        this.sfTxtMtoTarjeta03.IsVisible = false;
                        this.txtMtoTarjeta03.Text = "";
                    }
                }


            }
        }
        private void TxtMtoTarjeta03_OnFocused(object sender, FocusEventArgs e)
        {
            var value = this.txtMtoTarjeta03.Text;
            if (value != "")
            {
                decimal monto = Convert.ToDecimal(value);
                if (monto > 0)
                {
                    if(IsEvent == false)
                    {
                        this.CalcularTotales();
                    }
                    
                }
            }
        }

        private async void BtnSaveEfectivo_Clicked(object sender, EventArgs e)
        {
            if (IsEvent)
            {
                List<TS_BEPagoInput> cPagos = ObtenerPago();
                if(cPagos.Count == 0)
                {
                    await DisplayAlert("Aviso", "Debe seleccionar al menos un pago", "Aceptar");
                    return;
                }
                List<TerminalSIGES.Models.Pago> pagos = new List<TerminalSIGES.Models.Pago>();
                
                foreach (TS_BEPagoInput item in cPagos)
                {
                    pagos.Add(new TerminalSIGES.Models.Pago() 
                    { 
                        Codigo = item.cdtppago, 
                        Tipo = item.cdtppago, 
                        Referencia = item.nrotarjeta, 
                        Soles = Convert.ToDecimal(item.mtopagosol), 
                        Dolares = Convert.ToDecimal(item.mtopagodol) 
                    });
                }
                
                OnReponse(pagos);
                await Navigation.PopAsync();
                return;
            }

            CalcularTotales();
            var flag = TSSalesApp.vParemetros.flg_pideplacatb ?? false;
            if (TSCustomerApp.TipoComprobante.Nombre == TSSalesInput.Factura().Nombre || flag)
            {

                flagPlaca = true;
                string result = await RegexExpresion.SolicitarPlaca(this.Navigation);

                if (string.IsNullOrEmpty(TSSalesApp.vCabecera.nroplaca) || string.IsNullOrEmpty(TSSalesApp.vCabecera.odometro))
                {
                    await DisplayAlert("Aviso", "Ingrese placa y odómetro", "ok");
                    return;
                }
            }

            List<TS_BEPagoInput> cPago = ObtenerPago();
            TSSalesApp.cPagoInput = new TS_BEPagoInput[] { };

            if (cPago == null)
            {
                //await DisplayAlert("Aviso", "Por favor, ingresar el monto pagado", "Aceptar");
                return;
            }
            TSSalesApp.cPagoInput = cPago.ToArray();
            if (cPago.Count <= 0)
            {
                await DisplayAlert("Aviso", "Por favor, ingresar el monto pagado", "Aceptar");
                return;
            }
            if (TSSalesApp.vCabecera.mtototal > TSSalesApp.vCabecera.mtorecaudo)
            {
                await DisplayAlert("Aviso", "Por favor, falta completar el monto a pagar", "Aceptar");
                return;
            }

            TSSalesApp.TipoVenta = "";
            busyindicator.IsVisible = true;
            ToolBarItems(false);
            SalesEstado resultado = SalesEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TSSalesApp.SalesGrabarVenta += _SalesGrabarVenta; ;
                resultado = TSSalesApp.GrabarVenta(Convert.ToBoolean(this.ConIgv.IsChecked ?? false),false,false).Result;
            });
            if (resultado != SalesEstado.EsperandoRespuesta)
            {
                busyindicator.IsVisible = false;
                ToolBarItems(true);
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

        private void CalcularTotales()
        {

            decimal efectivoDolarVenta = Convert.ToDecimal(this.txtEfectivoDolarVenta.Value == null ? "0" :
            this.txtEfectivoDolarVenta.Value.GetType() == typeof(string) ? (String.IsNullOrEmpty(Convert.ToString(this.txtEfectivoDolarVenta.Value)) ? "0" : this.txtEfectivoDolarVenta.Value) :
            this.txtEfectivoDolarVenta.Value) * Convert.ToDecimal(this.txtTipoCambio.Text);
            decimal efectivoSolesVenta = Convert.ToDecimal(this.txtEfectivoSolesVenta.Value == null ? "0" :
            this.txtEfectivoSolesVenta.Value.GetType() == typeof(string) ? (String.IsNullOrEmpty(Convert.ToString(this.txtEfectivoSolesVenta.Value)) ? "0" : this.txtEfectivoSolesVenta.Value) :
            this.txtEfectivoSolesVenta.Value);

            
            decimal efectivoSolesTarjeta1 = Convert.ToDecimal(this.txtMtoTarjeta01.Text.Equals("") ? "0" : this.txtMtoTarjeta01.Text);
            decimal efectivoSolesTarjeta2 = Convert.ToDecimal(this.txtMtoTarjeta02.Text.Equals("") ? "0" : this.txtMtoTarjeta02.Text);
            decimal efectivoSolesTarjeta3 = Convert.ToDecimal(this.txtMtoTarjeta03.Text.Equals("") ? "0" : this.txtMtoTarjeta03.Text);


            TSSalesApp.vCabecera.mtorecaudo = efectivoSolesVenta + efectivoSolesTarjeta1 + efectivoSolesTarjeta2 + efectivoSolesTarjeta3 + efectivoDolarVenta;
            TSSalesApp.vCabecera.mtovueltosol = TSSalesApp.vCabecera.mtorecaudo - TSSalesApp.vCabecera.mtototal;
            this.txtMonTotalVueltoVenta.Text = Math.Round(TSSalesApp.vCabecera.mtovueltosol < 0 ? 0 : TSSalesApp.vCabecera.mtovueltosol, 2).ToString();
        }
        private List<TS_BEPagoInput> ObtenerPago()
        {
            List<TS_BEPagoInput> cPago = new List<TS_BEPagoInput>();
            decimal efectivoDolarVenta = Convert.ToDecimal(this.txtEfectivoDolarVenta.Value == null ? "0" :
                                             this.txtEfectivoDolarVenta.Value.GetType() == typeof(string) ? (String.IsNullOrEmpty(Convert.ToString(this.txtEfectivoDolarVenta.Value)) ? "0" : this.txtEfectivoDolarVenta.Value) :
                                             this.txtEfectivoDolarVenta.Value);
            decimal efectivoSolesVenta = Convert.ToDecimal(this.txtEfectivoSolesVenta.Value == null ? "0" :
                                         this.txtEfectivoSolesVenta.Value.GetType() == typeof(string) ? (String.IsNullOrEmpty(Convert.ToString(this.txtEfectivoSolesVenta.Value)) ? "0" : this.txtEfectivoSolesVenta.Value) :
                                         this.txtEfectivoSolesVenta.Value);
            if (efectivoSolesVenta > 0 || efectivoDolarVenta > 0)
            {
                cPago.Add(new TS_BEPagoInput()
                {
                    cdtppago = "00001",
                    mtopagosol = efectivoSolesVenta,
                    mtopagodol = efectivoDolarVenta,
                    nrocheque = "",
                    nrocuenta = "",
                    nrotarjeta = "",
                    cdbanco = "",
                    cdtarjeta = ""

                });
            }
            if (this.txtMtoTarjeta01.Text == null || this.txtMtoTarjeta01.Text == "")
            {
                this.txtMtoTarjeta01.Text = "0";
            }
            if (this.txtMtoTarjeta02.Text == null || this.txtMtoTarjeta02.Text == "")
            {
                this.txtMtoTarjeta02.Text = "0";
            }
            if (this.txtMtoTarjeta03.Text == null || this.txtMtoTarjeta03.Text == "")
            {
                this.txtMtoTarjeta03.Text = "0";
            }
            decimal mtoTarjeta1 = Convert.ToDecimal(this.txtMtoTarjeta01.Text);
            decimal mtoTarjeta2 = Convert.ToDecimal(this.txtMtoTarjeta02.Text);
            decimal mtoTarjeta3 = Convert.ToDecimal(this.txtMtoTarjeta03.Text);
            if (mtoTarjeta1 > 0)
            {
                if (this.cboTarjeta1.SelectedValue == null)
                {
                    DisplayAlert("Aviso", "Seleccione tipo de Tarjeta", "Aceptar");
                    return null;
                }
                cPago.Add(new TS_BEPagoInput()
                {
                    cdtppago = "00002",
                    cdtarjeta = ((TS_BETarjeta)cboTarjeta1.SelectedItem).cdtarjeta,
                    mtopagosol = mtoTarjeta1,
                    nrocheque = "",
                    nrocuenta = "",
                    nrotarjeta = ((Entry)txtNroOperacion1.InputView).Text,
                    cdbanco = "",
                });
            }
            if (mtoTarjeta2 > 0)
            {
                if (this.cboTarjeta2.SelectedValue == null)
                {
                    DisplayAlert("Aviso", "Seleccione tipo de Tarjeta", "Aceptar");
                    return null;
                }
                cPago.Add(new TS_BEPagoInput()
                {
                    cdtppago = "00002",
                    cdtarjeta = ((TS_BETarjeta)cboTarjeta2.SelectedItem).cdtarjeta,
                    mtopagosol = mtoTarjeta2,
                    nrocheque = "",
                    nrocuenta = "",
                    nrotarjeta = ((Entry)txtNroOperacion2.InputView).Text,
                    cdbanco = "",
                });
            }
            if (mtoTarjeta3 > 0)
            {
                if (this.cboTarjeta3.SelectedValue == null)
                {
                    DisplayAlert("Aviso", "Seleccione tipo de Tarjeta", "Aceptar");
                    return null;
                }
                cPago.Add(new TS_BEPagoInput()
                {
                    cdtppago = "00002",
                    cdtarjeta = ((TS_BETarjeta)cboTarjeta3.SelectedItem).cdtarjeta,
                    mtopagosol = mtoTarjeta3,
                    nrocheque = "",
                    nrocuenta = "",
                    nrotarjeta = ((Entry)txtNroOperacion3.InputView).Text,
                    cdbanco = "",
                });
            }

            return cPago;
        }
        private void _SalesGrabarVenta(TSSales respuesta)
        {
            TSSalesApp.SalesGrabarVenta -= _SalesGrabarVenta;
            Device.BeginInvokeOnMainThread(async () =>
            {
                busyindicator.IsVisible = false;
                
                if (respuesta.EstadoRespuesta == SalesEstado.VentaNoRegistrada)
                {
                    ToolBarItems(true);
                    await DisplayAlert("Aviso", "No se proceso la venta, intente nuevamente.\nIncidencias detectadas: \n" + (respuesta.Respuesta ?? "") + "", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == SalesEstado.ErrorSistema)
                {
                    ToolBarItems(true);
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == SalesEstado.VentaRegistrada)
                {
                    TSSalesApp.vCabecera.nroplaca = "";
                    TSSalesApp.vCabecera.odometro = "";
                    App.Current.MainPage = new NavigationPage(new SemiAutomatic());
                    return;
                }
            });
        }
        private void TxtMtoTarjeta1_OnFocused(object sender, FocusEventArgs e)
        {
            //if (contadortarjeta == 0)
            //{
            //    this.txtEfectivoDolarVenta.Value = "";
            //    this.txtEfectivoSolesVenta.Value = "";
            //    this.txtMtoTarjeta1.Value = this.txtMonTotalSoles.Text;
            //    contadortarjeta += 1;
            //}
        }
        private void OnImgDeletePago1_Tapped(object sender, EventArgs e)
        {
            this.txtMtoTarjeta01.Text = "";
            this.txtNroTarjeta01.Text = "";
            this.cboTarjeta1.SelectedValue = null;
            this.imgDeletePago1.IsVisible = false;
            this.cboTarjeta1.DataSource = TSSalesApp.vTarjetas;
            ClearSalesTarget();
            if (IsEvent) { return; }

            decimal efectivoDolarVenta = Convert.ToDecimal(this.txtEfectivoDolarVenta.Value == null ? "0" :
                                             this.txtEfectivoDolarVenta.Value.GetType() == typeof(string) ? (String.IsNullOrEmpty(Convert.ToString(this.txtEfectivoDolarVenta.Value)) ? "0" : this.txtEfectivoDolarVenta.Value) :
                                             this.txtEfectivoDolarVenta.Value) * Convert.ToDecimal(this.txtTipoCambio.Text);

            this.txtEfectivoSolesVenta.Value = Convert.ToDecimal(txtMonTotalSoles.Text) - efectivoDolarVenta;
            CalcularTotales();
        }
        private void OnImgDeletePago2_Tapped(object sender, EventArgs e)
        {
            OnImgDeletePago3_Tapped(sender, e);
            if (this.txtMtoTarjeta01.Text == null || this.txtMtoTarjeta01.Text == "")
            {
                this.txtMtoTarjeta01.Text = "0";
            }
            if (this.txtMtoTarjeta02.Text == null || this.txtMtoTarjeta02.Text == "")
            {
                this.txtMtoTarjeta02.Text = "0";
            }
            if (this.txtMtoTarjeta03.Text == null || this.txtMtoTarjeta03.Text == "")
            {
                this.txtMtoTarjeta03.Text = "0";
            }
            this.cboTarjeta2.IsEnabled = false;
            this.cboTarjeta2.IsVisible = false;
            this.txtNroOperacion2.IsVisible = false;
            this.txtMtoTarjeta02.IsVisible = false;
            this.imgDeletePago2.IsVisible = false;
            this.sfTxtMtoTarjeta02.IsVisible = false;
            this.txtMtoTarjeta02.Text = "";
            ((Entry)txtNroOperacion2.InputView).Text = "";

            if (IsEvent) { return; }

            var monto01 = Convert.ToDecimal(String.IsNullOrEmpty(txtMtoTarjeta01.Text) ? "0" : txtMtoTarjeta01.Text);
            var monto02 = Convert.ToDecimal(String.IsNullOrEmpty(txtMtoTarjeta02.Text) ? "0" : txtMtoTarjeta02.Text);
            var monto03 = Convert.ToDecimal(String.IsNullOrEmpty(txtMtoTarjeta03.Text) ? "0" : txtMtoTarjeta03.Text);
            this.txtMtoTarjeta01.Text = Math.Round(monto01 + monto02 + monto03, 2).ToString();
            
            cboTarjeta2.SelectedValue = null;
            cboTarjeta2.DataSource = TSSalesApp.vTarjetas;
            

            
            CalcularTotales();
        }
        private void OnImgDeletePago3_Tapped(object sender, EventArgs e)
        {
 

            if (this.txtMtoTarjeta02.Text == null || this.txtMtoTarjeta02.Text == "")
            {
                this.txtMtoTarjeta02.Text = "0";
            }
            if (this.txtMtoTarjeta03.Text == null || this.txtMtoTarjeta03.Text == "")
            {
                this.txtMtoTarjeta03.Text = "0";
            }

            this.cboTarjeta3.IsEnabled = false;
            this.cboTarjeta3.IsVisible = false;
            this.txtNroOperacion3.IsVisible = false;
            this.txtMtoTarjeta03.IsVisible = false;
            this.imgDeletePago3.IsVisible = false;
            this.sfTxtMtoTarjeta03.IsVisible = false;
            this.txtMtoTarjeta03.Text = "";
            ((Entry)txtNroOperacion3.InputView).Text = "";

            if (IsEvent) { return; }

            var monto02 = Convert.ToDecimal(String.IsNullOrEmpty(txtMtoTarjeta02.Text) ? "0" : txtMtoTarjeta02.Text);
            var monto03 = Convert.ToDecimal(String.IsNullOrEmpty(txtMtoTarjeta03.Text) ? "0" : txtMtoTarjeta03.Text);
            this.txtMtoTarjeta02.Text = Math.Round(monto02 + monto03, 2).ToString();
            cboTarjeta3.SelectedValue = null;
            cboTarjeta3.DataSource = TSSalesApp.vTarjetas;

            CalcularTotales();
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            //Vertical
            if (height > width)
            {
                #region ConfiguracionTituloPagos
                this.OrientationGridColumn1.Width = new GridLength(0);
                this.OrientationLineGrid.IsVisible = true;
                Grid.SetRow(txtMontoVueltoNombre, 4); Grid.SetColumn(txtMontoVueltoNombre, 0);
                Grid.SetColumnSpan(OrientationLineGridTwo, 3);
                Grid.SetColumnSpan(OrientationLineGridThree, 3); 
                Grid.SetRow(txtMonTotalVueltoVenta, 4); Grid.SetColumn(txtMonTotalVueltoVenta, 1); Grid.SetColumnSpan(txtMonTotalVueltoVenta, 2);
                #endregion

                #region ConfiguracionPagosSolesDolares
                this.OrientationGridColumnPayOne.Width = new GridLength(0);
                Grid.SetRow(OrientationStackOne, 0); Grid.SetColumn(OrientationStackOne, 0);
                Grid.SetRow(OrientationStackTwo, 1);Grid.SetColumn(OrientationStackTwo, 0);
                #endregion

                #region ConfiguracionPagosTarjetas
                #endregion
            }
            //Horizontal
            else
            {
                #region ConfiguracionTituloPagos
                this.OrientationGridColumn1.Width = new GridLength(1, GridUnitType.Star);
                this.OrientationLineGrid.IsVisible = false;
                Grid.SetRow(txtMontoVueltoNombre, 1); Grid.SetColumn(txtMontoVueltoNombre, 3);
                Grid.SetColumnSpan(OrientationLineGridTwo, 4);
                Grid.SetColumnSpan(OrientationLineGridThree, 4);
                Grid.SetRow(txtMonTotalVueltoVenta, 2); Grid.SetColumn(txtMonTotalVueltoVenta, 3); Grid.SetColumnSpan(txtMonTotalVueltoVenta, 1);
                #endregion

                #region ConfiguracionPagosSolesDolares
                this.OrientationGridColumnPayOne.Width = new GridLength(1,GridUnitType.Star);
                Grid.SetRow(OrientationStackOne, 0); Grid.SetColumn(OrientationStackOne, 1);
                Grid.SetRow(OrientationStackTwo, 0); Grid.SetColumn(OrientationStackTwo, 0);
                #endregion

                #region ConfiguracionPagosTarjetas
                #endregion

            }

        }
        private void ToolBarItems(bool IsVisible)
        {
            this.PrincipalPane.IsVisible = IsVisible;

            if (IsVisible)
            {
                this.ToolbarItems.Add(ItemGuardar);
            }
            else
            {
                this.ToolbarItems.Clear();
            } 
        }
    }
}