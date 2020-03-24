using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Views.Pages.Payment;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.PopUp
{
   
    public partial class VisaPopUpCompleted : PopupPage
    {
        public ObservableCollection<Tarjeta> Items { get; set; }
        private bool approve { get; set; }
        private string cdtptarjeta { get; set; }
        private string reftarjeta { get; set; }
        public event RespuestaVentaDelegado OnResponse;
        public delegate void RespuestaVentaDelegado(bool approve,string cdtptarjeta,string reftarjeta);

        public VisaPopUpCompleted()
        {
            this.approve = false;
            Items = new ObservableCollection<Tarjeta>();
            InitializeComponent();
            Items.Add(new Tarjeta("01", "Visa"));
            Items.Add(new Tarjeta("02", "MasterCard"));
            comboBox.DataSource = Items;
            btnAceptar.Clicked += BtnAceptar_Clicked;
            this.approve = approve;
            this.cdtptarjeta = cdtptarjeta;
            this.reftarjeta = reftarjeta;
        }

        private async void BtnAceptar_Clicked(object sender, EventArgs e)
        {
            btnAceptar.IsEnabled = false;

            if (String.IsNullOrEmpty(refTarjeta.Text))
            {
                await DisplayAlert("Aviso", "Ingrese la referencia de la transacción", "Aceptar");
                btnAceptar.IsEnabled = true;
                return;
            }
            this.approve = true;
            this.reftarjeta = refTarjeta.Text;
            this.cdtptarjeta = ((Tarjeta)comboBox.SelectedItem).tipo;

            await PopupNavigation.Instance.PopAsync();
            OnResponse(approve, reftarjeta, cdtptarjeta);
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            refTarjeta.Focus();
            comboBox.SelectedItem = Items[0];
        }
        public class Tarjeta
        {
            public string tipo { get; set; }
            public string nombre { get; set; }
            public Tarjeta() { }
            public Tarjeta(string tipo,string nombre) { this.tipo = tipo; this.nombre = nombre; }
        }
    }
}