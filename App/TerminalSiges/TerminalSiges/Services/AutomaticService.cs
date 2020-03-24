using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using Matcha.BackgroundService;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerminalSiges.Lib.Sales;
using TerminalSiges.Views.Pages.Invoce;
using Xamarin.Forms;

namespace TerminalSiges.Services
{
    public class AutomaticService : IPeriodicTask
    {
        private bool Terminado;
        private bool NeedSearch;
        private DateTime LastSeach;

        public AutomaticService(int milliseconds)
        {
            Terminado = false;
            Interval = TimeSpan.FromMilliseconds(milliseconds);
            NeedSearch = true;
            LastSeach = DateTime.Now;
        }

        public TimeSpan Interval { get; set; }

        public async Task<bool> StartJob()
        {
            if(TSSalesApp.vTerminal != null)
            {
                if ((TSSalesApp.vTerminal.flgautomatica ?? false) == false && (TSSalesApp.vParemetros.flg_facturacion_automatica ?? false) == true)
                {
                    if (NeedSearch)
                    {
                        try
                        {
                            Type Tipo1 = App.Current.MainPage.Navigation.NavigationStack[0].GetType();
                            Type Tipo2 = typeof(SemiAutomatic);
                            if (Tipo1 == Tipo2)
                            {
                                try
                                {
                                    SemiAutomatic Page = (SemiAutomatic)App.Current.MainPage.Navigation.NavigationStack[0];
                                    if ( await Page.IsWaiting())
                                    {
                                        NeedSearch = false;
                                        App.Current.MainPage = App.Current.MainPage = new NavigationPage(new SaleAutomatic(false));
                                        LastSeach = DateTime.Now;
                                    }
                                    else
                                    {
                                        await Task.Delay(10000);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    string mensaje = ex.Message;
                                }
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        TimeSpan Tiempo = DateTime.Now.Subtract(LastSeach);
                        if (Tiempo.TotalMinutes >= Convert.ToDouble(TSSalesApp.vParemetros.minutosxtktbol))
                        {
                            NeedSearch = true;
                        }
                    }
                    return true;
                }
            }
            if(TSSalesApp.AutomaticContext == null) { return true; }
            foreach (TerminalSIGES.Models.Lado lado in TSSalesApp.AutomaticContext.Productos)
            {
                if (lado.Estado.estado)
                {
                    lado.Image = "pause.png";
                }
                else
                {
                    lado.Image = "play.png";
                }
            }

            foreach (TerminalSIGES.Models.Lado lado in TSSalesApp.AutomaticContext.Productos)
            {
                if (lado.Estado.estado)
                {
                    await Start_Automatic(lado);
                }
            }

            return true; //return false when you want to stop or trigger only once
        }



        public async Task Start_Automatic(TerminalSIGES.Models.Lado Lado)
        {

            /** COMIENZA REVISION DE VENTAS PENDIENTES **/
            await Task.Run(() =>
            {
                if(Convert.ToBoolean(TSSalesApp.vTerminal.conexion_dispensador ?? 0) == false || Convert.ToBoolean(TSSalesApp.vParemetros.conexiondispensador ?? false) == false)
                {
                    Lado.Mensaje = "CONEXION A DISPENSADOR CERRADA";
                    return;
                }
                string codigo = Lado.Documento == TerminalSIGES.Models.EDocumento.NotaDespacho         ? Lado.Tarjeta  :
                                Lado.Documento == TerminalSIGES.Models.EDocumento.TranferenciaGratuita ? "XXXXXXXXXXX" :
                                Lado.Documento == TerminalSIGES.Models.EDocumento.Serafin              ? "XXXXXXXXXXX" :
                                Lado.Codigo;

                TS_BECabeceraOutPut vTransaccion = TSSalesApp.SynchronizedGetOPTransaction(Lado.Cara, codigo,true);
                if (vTransaccion.Ok)
                {
                    if (vTransaccion.cDetalleOutPut.Length > 0)
                    {
                        Lado.Mensaje = "ENVIANDO VENTA";
                        var Venta = new TS_BEArticulo()
                        {
                            item = vTransaccion.cDetalleOutPut[0].item,
                            dsarticulo = (vTransaccion.cDetalleOutPut[0].dsarticulo1 ?? "").Trim(),
                            precio = vTransaccion.cDetalleOutPut[0].precio,
                            cantidad = vTransaccion.cDetalleOutPut[0].cantidad,
                            cdarticulo = vTransaccion.cDetalleOutPut[0].cdarticulo,
                            cara = vTransaccion.cDetalleOutPut[0].cara,
                            hora = vTransaccion.cDetalleOutPut[0].hora,
                            subtotal = vTransaccion.cDetalleOutPut[0].subtotal,
                            tipo = vTransaccion.cDetalleOutPut[0].tipo,
                            mtoimpuesto = vTransaccion.cDetalleOutPut[0].mtoimpuesto,
                            total = vTransaccion.cDetalleOutPut[0].total,
                            nrogasboy = vTransaccion.cDetalleOutPut[0].nrogasboy.Trim(),
                            cdarticulosunat = vTransaccion.cDetalleOutPut[0].cdarticulosunat,
                            mtodscto = 0,
                            cdunimed = vTransaccion.cDetalleOutPut[0].cdunimed,
                            precio_orig = vTransaccion.cDetalleOutPut[0].precio_orig,
                            redondea_indecopi = vTransaccion.cDetalleOutPut[0].redondea_indecopi,
                            tpformula = vTransaccion.cDetalleOutPut[0].tpformula,
                            impuesto = vTransaccion.cDetalleOutPut[0].impuesto,
                            moverstock = vTransaccion.cDetalleOutPut[0].moverstock,
                            costo = vTransaccion.cDetalleOutPut[0].costo,
                            trfgratuita = vTransaccion.cDetalleOutPut[0].trfgratuita,
                            total_display = vTransaccion.cDetalleOutPut[0].total_display,
                            impuesto_plastico = vTransaccion.cDetalleOutPut[0].impuesto_plastico
                        };

                        TS_BEMensaje respuesta = TSSalesApp.SynchronizedSetSale(Lado, Venta);
                        if (respuesta.Ok)
                        {
                            Lado.Codigo = "";
                            Lado.Ruc = "";
                            Lado.RazonSocial = "";
                            Lado.Correo = "";
                            Lado.Direccion = "";
                            Lado.Placa = "";
                            Lado.Odometro = "";
                            Lado.Chofer = "";
                            Lado.Tarjeta_afiliacion = "";
                            Lado.Pago = "";
                            Lado.Tarjeta = "";
                            Lado.Fecha_Nacimiento = null;
                            Lado.Telefono = "";
                            Lado.Marca = "";
                            Lado.Modelo = "";
                            Lado.Mensaje = "";
                            Lado.Pago = "EFECTIVO";
                            Lado.Pagos.Clear();
                            Lado.Documento = TerminalSIGES.Models.EDocumento.BoletaFactura;
                        }
                        else
                        {
                            Lado.Estado.estado = false;
                            Lado.Mensaje = respuesta.mensaje;
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
                    if(vTransaccion.Estado == 4)
                    {
                        
                        Lado.Mensaje = "SIN TRANSACCIONES";
                        return;
                    }
                    Lado.Estado.estado = false;
                    Lado.Mensaje = vTransaccion.Mensaje;
                }
            });

            /** TERMINA REVISION DE VENTAS PENDIENTES **/
        }
    }
}


