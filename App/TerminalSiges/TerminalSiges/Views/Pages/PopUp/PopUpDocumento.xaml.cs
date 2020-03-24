using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Autenticate;
using TerminalSiges.Lib.Sales;
using TerminalSIGES.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.PopUp
{

    public partial class PopUpDocumento : PopupPage
    {
        public event OnSave SaveEvent;
        public delegate void OnSave(EDocumento respuesta,string lado);

        private string lado { get; set; }
        public PopUpDocumento(string lado)
        {
            InitializeComponent();

            this.lado = lado;
            int cdnivel;
            try
            {
                cdnivel = TSLoginApp.CurrentEmpresa.cdnivel == null ? 0 : Convert.ToInt32(TSLoginApp.CurrentEmpresa.cdnivel.Trim());
            }
            catch
            {
                cdnivel = -1;
            }

            this.btnTranfGrat.IsVisible = cdnivel == 1 || cdnivel == 2 ? true : false;
            this.btnSerafin.IsVisible = cdnivel == 1 || cdnivel == 2 ? true : false;
        }

        private async void OnFacturaBoleta(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
            SaveEvent(EDocumento.BoletaFactura, lado);
        }
        private async void OnNotaDespacho(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
            SaveEvent(EDocumento.NotaDespacho, lado);
        }
        private async void OnSerafin(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
            SaveEvent(EDocumento.Serafin, lado);
        }
        private async void OnTranferenciaGratuita(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
            SaveEvent(EDocumento.TranferenciaGratuita, lado);
        }
        private async void OnCanje(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
            SaveEvent(EDocumento.Canje, lado);
        }
    }
}