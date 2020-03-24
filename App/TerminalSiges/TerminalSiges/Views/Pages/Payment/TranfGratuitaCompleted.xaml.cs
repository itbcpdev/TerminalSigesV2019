using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalSiges.Lib.Customer;
using TerminalSiges.Lib.Sales;
using TerminalSiges.Views.Pages.Invoce;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Payment
{
 
    public partial class TranfGratuitaCompleted : ContentPage
    {
        public bool Cargado = false;
        public TranfGratuitaCompleted()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) return;

            List<TS_BEPagoInput> cPago = ObtenerPago();
            TSSalesApp.cPagoInput = new TS_BEPagoInput[] { };
            TSSalesApp.cPagoInput = cPago.ToArray();
            TSSalesApp.TipoVenta = "T";
            IndicadorDeCarga.IsVisible = true;
            SalesEstado resultado = SalesEstado.ErrorSistema;
            await Task.Run(() =>
            {
                TSSalesApp.SalesGrabarVenta += _SalesGrabarVenta; ;
                resultado = TSSalesApp.GrabarVenta(false,false,false).Result;
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
        private List<TS_BEPagoInput> ObtenerPago()
        {
            List<TS_BEPagoInput> cPago = new List<TS_BEPagoInput>();
            decimal efectivoDolarVenta = 0;
            decimal efectivoSolesVenta = Convert.ToDecimal(TSSalesApp.vCabecera.mtototal);


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


            return cPago;
        }
        private void _SalesGrabarVenta(TSSales respuesta)
        {
            TSSalesApp.SalesGrabarVenta -= _SalesGrabarVenta;
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (respuesta.EstadoRespuesta == SalesEstado.VentaNoRegistrada)
                {
                    await DisplayAlert("Aviso", "No se proceso la venta, intente nuevamente.", "Aceptar");
                    App.Current.MainPage = new NavigationPage(new SemiAutomatic());
                    return;
                }
                if (respuesta.EstadoRespuesta == SalesEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == SalesEstado.VentaRegistrada)
                {
                    App.Current.MainPage = new NavigationPage(new SemiAutomatic());
                    return;
                }
            });
        }
        public  void  IrAlInicio(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new SemiAutomatic());
        }
    }
}