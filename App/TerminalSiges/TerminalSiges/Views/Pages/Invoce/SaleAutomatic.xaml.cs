using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TerminalSiges.Lib.Customer;
using TerminalSiges.Lib.Sales;
using TerminalSiges.ViewModels;
using TerminalSIGES.Models;
using Xamarin.Forms;

namespace TerminalSiges.Views.Pages.Invoce
{
    public partial class SaleAutomatic : ContentPage
    {
        private BindingProgressAutomatic Contexto;
        private bool IsButtonAutomatic;
        private bool Cargado;

        public SaleAutomatic(bool IsButtonAutomatic)
        {
            InitializeComponent();
            Contexto = new BindingProgressAutomatic();
            this.BindingContext = Contexto;
            this.IsButtonAutomatic = IsButtonAutomatic;
            this.Cargado = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Cargado) { return; }
            Cargado = true;
            Start_Automatic();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        public async void Start_Automatic()
        {
            Contexto.Mensaje = "Estamos procesando las ventas pendientes espere por favor.";

            foreach (TS_BECara cara in TSSalesApp.vCaras)
            {
                string TipoDocumento = (TSSalesApp.vParemetros.cdtipodocautomatico ?? "").Trim().Equals("99999") ? "99999" : "00003";
                bool NoImprimir = App.Current.Properties.ContainsKey("IMPRIMIR") ? App.Current.Properties["IMPRIMIR"].ToString().Equals("T") : false;

                Lado lado = new Lado();
                lado.Cara = (cara.cara ?? "").Trim();
                lado.Codigo = (TSSalesApp.vParemetros.cdclienteautomatico ?? "").Trim();
                lado.Ruc = "";
                lado.RazonSocial = (TSSalesApp.vParemetros.rscliente_automatico ?? "").Trim();
                lado.Correo = "";
                lado.Direccion = "";
                lado.Placa = "";
                lado.Odometro = "";
                lado.Chofer = "";
                lado.Tarjeta_afiliacion = "";
                lado.Pago = "";
                lado.Tarjeta = TipoDocumento.Equals("99999") ? (TSSalesApp.vParemetros.prefcredlocal ?? "").Trim() + (TSSalesApp.vParemetros.cdclienteautomatico ?? "").Trim() : "";
                lado.Fecha_Nacimiento = null;
                lado.Telefono = "";
                lado.Marca = "";
                lado.Modelo = "";
                lado.Mensaje = "";
                lado.Pago = "EFECTIVO";
                lado.Pagos.Clear();
                lado.IsImprimir = NoImprimir;
                lado.Documento = TipoDocumento.Equals("99999") ? TerminalSIGES.Models.EDocumento.NotaDespacho : TerminalSIGES.Models.EDocumento.BoletaFactura;

                await Start_Automatic(lado);
             
            }
            App.Current.MainPage = new NavigationPage(new SemiAutomatic());
        }

        public async Task Start_Automatic(Lado Lado)
        {

            /** COMIENZA REVISION DE VENTAS PENDIENTES **/
            await Task.Run(() =>
            {
                if (Convert.ToBoolean(TSSalesApp.vTerminal.conexion_dispensador ?? 0) == false || Convert.ToBoolean(TSSalesApp.vParemetros.conexiondispensador ?? false) == false)
                {
                    Contexto.Progreso = "CONEXION A DISPENSADOR CERRADA";
                    return;
                }

                string codigo = "XXXXXXXXXXX";

                TS_BECabeceraOutPut vTransaccion = TSSalesApp.SynchronizedGetOPTransaction(Lado.Cara, codigo,false);
                if (vTransaccion.Ok)
                {
                    if (vTransaccion.cDetalleOutPut.Length > 0)
                    {
                        List<TS_BEArticulo> Lista = new List<TS_BEArticulo>(vTransaccion.cDetalleOutPut);
                        if(IsButtonAutomatic == false)
                        {
                            Lista.RemoveAt(Lista.Count - 1);
                        }
                        int Progreso = 0;

                        foreach(TS_BEArticulo Producto in Lista) { 
               
                            Contexto.Mensaje = "ENVIANDO VENTA";
                            Contexto.Progreso = "PROCESANDO CARA: " + Lado.Cara +"\nPROCESADO " + Progreso + " de " + Lista.Count;
                            var Venta = new TS_BEArticulo()
                            {
                                item = Producto.item,
                                dsarticulo = (Producto.dsarticulo1 ?? "").Trim(),
                                precio = Producto.precio,
                                cantidad = Producto.cantidad,
                                cdarticulo = Producto.cdarticulo,
                                cara = Producto.cara,
                                hora = Producto.hora,
                                subtotal = Producto.subtotal,
                                tipo = Producto.tipo,
                                mtoimpuesto = Producto.mtoimpuesto,
                                total = Producto.total,
                                nrogasboy = Producto.nrogasboy.Trim(),
                                cdarticulosunat = Producto.cdarticulosunat,
                                mtodscto = Producto.mtodscto,
                                cdunimed = Producto.cdunimed,
                                precio_orig = Producto.precio_orig,
                                redondea_indecopi = Producto.redondea_indecopi,
                                tpformula = Producto.tpformula,
                                impuesto = Producto.impuesto,
                                moverstock = Producto.moverstock,
                                costo = Producto.costo,
                                trfgratuita = Producto.trfgratuita,
                                total_display = Producto.total_display,
                                impuesto_plastico = Producto.impuesto_plastico,
                                valorconversion = Producto.valorconversion,
                                cdmedequiv = Producto.cdmedequiv,
                                tpconversion = Producto.tpconversion
                            };
                            TS_BEMensaje respuesta = TSSalesApp.SynchronizedSetSale(Lado, Venta);
                            if (respuesta.Ok)
                            {
                                try
                                {
                                    string[] mensaje = respuesta.mensaje.Split('|');
                                    BindingDocument Item = new BindingDocument() { Documento = mensaje[0], Estado = mensaje[1], Respuesta = mensaje[2] };
                                    Device.BeginInvokeOnMainThread(() => { Contexto.Documentos.Add(Item); });
                                   
                                }
                                catch(Exception ex)
                                {
                                }

                            }
                            Progreso++;

                        }
                    }
                }
                else
                {
                    /** 
                     * 1 ERROR GENERAL
                     * 2 ERROR DESCUENTOS 
                     * 3 ERROR TABLAS DBF
                     * 4 SIN TRANSACCIONES
                     * 5 SIN CONEXION DISPENSADO
                     * 6 TERMINAL SIN CONEXION DISPENSADOR
                    **/
                    if (vTransaccion.Estado == 4)
                    {
                        Contexto.Progreso = "SIN TRANSACCIONES";
                        return;
                    }
                }
            });
        }
    }
}