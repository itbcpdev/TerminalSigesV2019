using ITBCP.ServiceSIGES.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Include;
using TerminalSiges.Lib.Prints;
using TerminalSiges.Lib.Sales;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Depositos
{
    public partial class DepositoRegistra : ContentPage
    {
        public bool Cargado = false;
        public DepositoRegistra()
        {
            InitializeComponent();
            this.cboTurno.DataSource = new List<string>() {"Actual","Anterior" };
            this.cboTurno.SelectedItem = "Actual";
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var cPagos = new ObservableCollection<TS_BETipopago>();
            foreach(var cPago in TSSalesApp.vTipoPagos)
            {
                cPagos.Add(cPago);
            }
            this.cboTipoPagos.DataSource = cPagos;
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            App.Current.MainPage = (new DepositoLogin(true));
            return true;
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            if (this.cboTipoPagos.SelectedIndex < 0)
            {
                await DisplayAlert("Aviso", "Seleccione el tipo de pago.", "Aceptar");
                return;
            }

            if (this.txtSobre.Text != null)
            {
                if (Helper.IsNumero(this.txtSobre.Text))
                {
                    decimal monto = Convert.ToInt32(this.txtSobre.Text);
                    if (monto <= 0)
                    {
                        await DisplayAlert("Aviso", "Ingrese número de sobre.", "Aceptar");
                    }
                }
                else
                {
                    await DisplayAlert("Aviso", "Ingrese número de sobre válido", "Aceptar");
                    return;
                }
            }
            else
            {
                await DisplayAlert("Aviso", "Ingrese número de sobre.", "Aceptar");
                return;
            }

            TSPrintApp.cdtppago = ((TS_BETipopago)this.cboTipoPagos.SelectedItem).cdtppago;
            TSPrintApp.mtodolares = Convert.ToDecimal(this.txtMontoDolarVenta.Value);
            TSPrintApp.mtosoles = Convert.ToDecimal(this.txtMontoSolesVenta.Value);
            TSPrintApp.nrosobres = Convert.ToInt32(this.txtSobre.Text);
            TSPrintApp.TurnoAnterior = (cboTurno.SelectedItem.ToString() ?? "").Trim().Equals("Anterior");
            DepositoRegistraCompleted Vista = new DepositoRegistraCompleted();
            Vista.Grabado += Vista_Grabado;
            await Navigation.PushAsync(Vista);

        }

        private async void Vista_Grabado()
        {
            await Navigation.PopAsync();
        }
    }
}