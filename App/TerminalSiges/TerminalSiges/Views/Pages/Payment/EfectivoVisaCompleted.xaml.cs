using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TerminalSiges.Helpers;
using TerminalSiges.Lib.Customer;
using TerminalSiges.Lib.Sales;
using TerminalSiges.Views.Pages.Invoce;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalSiges.Views.Pages.Payment
{

    public partial class EfectivoVisaCompleted : ContentPage
    {
        public bool Cargado = false;
        private bool tarjeta  = false;
        private string tptarjeta = "";
        private string reftarjeta = "";

        public EfectivoVisaCompleted(bool tarjeta, string tptarjeta, string reftarjeta)
        {
            InitializeComponent();
            this.tarjeta = tarjeta;
            this.tptarjeta = String.IsNullOrEmpty(tptarjeta) ? "" : tptarjeta;
            this.reftarjeta = String.IsNullOrEmpty(reftarjeta) ? "" : reftarjeta;
        }
        public EfectivoVisaCompleted()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) return;
            Cargado = true;
            IndicadorDeCarga.IsVisible = false;
            var flag = TSSalesApp.vParemetros.flg_pideplacatb ?? false;
            if (TSCustomerApp.TipoComprobante.Nombre == TSSalesInput.Factura().Nombre || flag)
            {
                if (string.IsNullOrEmpty(TSSalesApp.vCabecera.nroplaca))
                {
                    await RegexExpresion.SolicitarPlaca(this.Navigation);
                    if (string.IsNullOrEmpty(TSSalesApp.vCabecera.nroplaca) || string.IsNullOrEmpty(TSSalesApp.vCabecera.odometro))
                    {
                        await Navigation.PopAsync();
                        return;
                    }
                }

            }

            List<TS_BEPagoInput> cPago = ObtenerPago();
            TSSalesApp.cPagoInput = new TS_BEPagoInput[] { };
            TSSalesApp.cPagoInput = cPago.ToArray();
            TSSalesApp.TipoVenta = "";
            IndicadorDeCarga.IsVisible = true;
            SalesEstado resultado = SalesEstado.ErrorSistema;
            await Task.Run(delegate
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
            decimal efectivoSolesVenta = Convert.ToDecimal(TSSalesApp.vCabecera.mtototal);
            if (tarjeta)
            {
                cPago.Add(new TS_BEPagoInput()
                {
                    cdtppago = "00002",
                    mtopagosol = efectivoSolesVenta,
                    mtopagodol = 0,
                    nrocheque = "",
                    nrocuenta = "",
                    nrotarjeta = tptarjeta,
                    cdbanco = "",
                    cdtarjeta = reftarjeta

                });
            }
            else
            {
                cPago.Add(new TS_BEPagoInput()
                {
                    cdtppago = "00001",
                    mtopagosol = efectivoSolesVenta,
                    mtopagodol = 0,
                    nrocheque = "",
                    nrocuenta = "",
                    nrotarjeta = "",
                    cdbanco = "",
                    cdtarjeta = ""

                });
            }
            return cPago;
        }
        public void IrAlInicio(object sender, EventArgs e)
        {

        }
        private void _SalesGrabarVenta(TSSales respuesta)
        {
            TSSalesApp.SalesGrabarVenta -= _SalesGrabarVenta;
            Device.BeginInvokeOnMainThread(async () =>
            {
               
                if (respuesta.EstadoRespuesta == SalesEstado.VentaNoRegistrada)
                {
                    await DisplayAlert("Aviso", respuesta.Respuesta, "Aceptar");
                    await Navigation.PopAsync();
                    return;
                }
                if (respuesta.EstadoRespuesta == SalesEstado.ErrorSistema)
                {
                    await DisplayAlert("Aviso", "Hubo un problema en la comunicación con el servidor, por favor intente después.", "Aceptar");
                    return;
                }
                if (respuesta.EstadoRespuesta == SalesEstado.VentaRegistrada)
                {
                    TSSalesApp.vCabecera.nroplaca = "";
                    App.Current.MainPage = new NavigationPage(new SemiAutomatic());
                    return;
                }
            });
        }

    }
}