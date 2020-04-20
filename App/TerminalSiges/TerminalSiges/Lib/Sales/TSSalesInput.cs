using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using TerminalSiges.Lib.Autenticate;
using TerminalSiges.Lib.Customer;

namespace TerminalSiges.Lib.Sales
{
    public class TipoComprobate
    {
        public string Nombre { get; set; }
        public string Nro { get; set; }
    }
    public static class TSSalesInput
    {
        public static object TTSSalesApp { get; private set; }
        public static TipoComprobate Factura()
        {
            TipoComprobate td = new TipoComprobate()
            {
                Nombre = "Factura",
                Nro = "00001"
            };
            return td;
        }
        public static void RecalcularIGV(TS_BEDetalleInput[] Detalles)
        {
            foreach(TS_BEDetalleInput Detalle in Detalles)
            {
                if(Detalle.impuesto == 0)
                {
                    Detalle.impuesto = 18;
                    Detalle.mtoimpuesto = Detalle.impuesto <= 0 ? 0 : Math.Round((Detalle.total / (100 + Detalle.impuesto)) * Detalle.impuesto, 2);
                    Detalle.subtotal = Detalle.impuesto <= 0 ? Detalle.total : Math.Round(Detalle.total - Detalle.mtoimpuesto, 2);
                }
            }
        }
        public static TipoComprobate Boleta()
        {
            TipoComprobate td = new TipoComprobate()
            {
                Nombre = "Boleta",
                Nro = "00003"
            };
            return td;
        }
        public static TipoComprobate Serafin()
        {
            TipoComprobate td = new TipoComprobate()
            {
                Nombre = "Serafin",
                Nro = "99998"
            };
            return td;
        }
        public static TipoComprobate NotaDeDespacho()
        {
            TipoComprobate td = new TipoComprobate()
            {
                Nombre = "Nota de despacho ",
                Nro = "99999"
            };
            return td;
        }
        public static TS_BECabeceraInput InputcCabecera()
        {
            TS_BECabeceraInput cCabecera = new TS_BECabeceraInput();
            cCabecera.TipoVenta = TSSalesApp.TipoVenta;
            cCabecera.cdcliente = TSCustomerApp.ClientOuput.cdcliente;
            cCabecera.cdmoneda = "S";
            cCabecera.cdtipodoc = TSCustomerApp.TipoComprobante.Nro;
            cCabecera.cdusuario = TSLoginApp.UserName;
            cCabecera.cdvendedor = "";
            cCabecera.chofer = TSSalesApp.vCabecera.chofer;
            cCabecera.mtovueltodol = TSSalesApp.vCabecera.mtovueltodol;
            cCabecera.mtovueltosol = TSSalesApp.vCabecera.mtovueltosol;
            cCabecera.nroplaca = TSSalesApp.vCabecera.nroplaca;
            cCabecera.nrotarjeta = TSSalesApp.vCabecera.nrotarjeta;
            cCabecera.observacion = "";
            cCabecera.odometro = TSSalesApp.vCabecera.odometro;
            cCabecera.redondea_indecopi = 0;
            cCabecera.rscliente = TSCustomerApp.ClientOuput.rscliente;
            cCabecera.ruccliente = TSCustomerApp.ClientOuput.ruccliente;
            cCabecera.dsusuario = TSLoginApp.UserFull;
            return cCabecera;

        }
        public static TS_BEClienteInput InputcCliente()
        {
            TS_BEClienteInput cCliente = new TS_BEClienteInput();
            cCliente.cdcliente = TSCustomerApp.ClientOuput.cdcliente;
            cCliente.ruccliente = TSCustomerApp.ClientOuput.ruccliente;
            cCliente.drcliente = TSCustomerApp.ClientOuput.drcliente;
            cCliente.rscliente = TSCustomerApp.ClientOuput.rscliente;
            cCliente.tipocli = TSCustomerApp.ClientOuput.tipocli;
            cCliente.nroTarjeta = TSCustomerApp.ClientOuput.nroTarjeta;
            cCliente.tarjAfiliacion = TSCustomerApp.ClientOuput.tarjafiliacion ?? "";
            cCliente.emcliente = TSCustomerApp.ClientOuput.emcliente ?? "";
            cCliente.iscanje = TSCustomerApp.IsCanje;
            return cCliente;
        }
        public static List<TS_BEDetalleInput> Inputcdetalle(TS_BECabeceraInput cCabecera)
        {
            List<TS_BEDetalleInput> cDetalleTodo = new List<TS_BEDetalleInput>();
            foreach (var item in TSSalesApp.Detalles)
            {
                cDetalleTodo.Add(new TS_BEDetalleInput()
                {
                    item = item.item,
                    cdarticulo = item.cdarticulo,
                    cdarticulosunat = item.cdarticulosunat,
                    dsarticulo = item.dsarticulo,
                    precio = item.precio,
                    cantidad = item.cantidad,
                    total = item.total,
                    impuesto = item.impuesto,
                    mtodscto = item.mtodscto,
                    mtoimpuesto = item.mtoimpuesto,
                    subtotal = item.subtotal,
                    moverstock = item.moverstock,
                    cara = item.cara,
                    costo = item.costo,
                    cdunimed = item.cdunimed,
                    nrogasboy = item.nrogasboy,
                    precio_orig = item.precio_orig,
                    //  redondea_indecopi = item.redondea_indecopi,
                    tpformula = item.tpformula,
                    impuesto_plastico = item.impuesto_plastico,
                    valorconversion = item.valorconversion,
                    cdmedequiv = item.cdmedequiv,
                    tpconversion = item.tpconversion

                });

            }
            return cDetalleTodo;

        }
        public static TS_BELoadInput LoadInput()
        {
            TS_BELoadInput cLoadingInput = new TS_BELoadInput();
            cLoadingInput.Serie = TSLoginApp.Serie;
            cLoadingInput.cdempresa = TSLoginApp.CurrentEmpresa.cdempresa;
            cLoadingInput.cdlocal = TSSalesApp.vParemetros.cdlocal;
            cLoadingInput.cdnivel = TSLoginApp.CurrentEmpresa.cdnivel ;
            cLoadingInput.cdusuario = TSLoginApp.UserName;
            return cLoadingInput;
        }
        public static TS_BEPagoInput InputcPago(TS_BECabeceraInput cCabecera)

        {
            TS_BEPagoInput cPago = new TS_BEPagoInput();
            cPago.cdbanco = "";
            cPago.cdtarjeta = "";
            cPago.cdtppago = "";
            cPago.mtopagodol = 0;
            cPago.mtopagosol = 0;//TSSalesApp.;
            cPago.nrocheque = "";
            cPago.nrocuenta = "";
            cPago.nrotarjeta = "";

            return cPago;

        }


        public static TS_BEClienteInput InputClienteAutomaticMethod(TerminalSIGES.Models.Lado Cara)
        {
            return  new TS_BEClienteInput()
            {
                cdcliente = Cara.Codigo,
                ruccliente = Cara.Ruc,
                drcliente = Cara.Direccion,
                rscliente = Cara.RazonSocial,
                tipocli = "",
                nroTarjeta = Cara.Tarjeta,
                tarjAfiliacion = Cara.Tarjeta_afiliacion,
                emcliente = Cara.Correo,
            };
         
        }
        public static TS_BECabeceraInput InputCabeceraAutomaticMethod(TerminalSIGES.Models.Lado Cara)
        {
            string TipoDocumento = "00003";

            if(Cara.Documento == TerminalSIGES.Models.EDocumento.BoletaFactura)
            {
                if (String.IsNullOrEmpty(Cara.Ruc))
                {
                    TipoDocumento = "00003";
                }
                else
                {
                    TipoDocumento = "00001";
                }
            }
            if(Cara.Documento == TerminalSIGES.Models.EDocumento.NotaDespacho)
            {
                TipoDocumento = "99999";
            }
            if(Cara.Documento == TerminalSIGES.Models.EDocumento.Serafin)
            {
                TipoDocumento = "99998";
            }
            if (Cara.Documento == TerminalSIGES.Models.EDocumento.TranferenciaGratuita)
            {
                if (String.IsNullOrEmpty(Cara.Ruc))
                {
                    TipoDocumento = "00003";
                }
                else
                {
                    TipoDocumento = "00001";
                }
            }

            return new TS_BECabeceraInput()
            {
                TipoVenta = (Cara.Documento == TerminalSIGES.Models.EDocumento.TranferenciaGratuita) ? "T" : "",
                cdcliente = Cara.Codigo,
                cdmoneda = "S",
                cdtipodoc = TipoDocumento,
                cdusuario = TSLoginApp.UserName,
                cdvendedor = "",
                chofer = Cara.Chofer,
                mtovueltodol = Convert.ToDecimal(0),
                mtovueltosol = Convert.ToDecimal(0),
                nroplaca = Cara.Placa,
                nrotarjeta = (Cara.Documento == TerminalSIGES.Models.EDocumento.NotaDespacho) ? Cara.Tarjeta : Cara.Tarjeta_afiliacion,
                observacion = "",
                odometro = String.IsNullOrEmpty(Cara.Odometro) ? "0" : Cara.Odometro,
                redondea_indecopi = 0,
                rscliente = Cara.RazonSocial,
                ruccliente = Cara.Ruc,
                dsusuario = TSLoginApp.UserFull,
            };
        }
        public static List<TS_BEDetalleInput> InputDetalleAutomaticMethod(TS_BEArticulo item)
        {
            return new List<TS_BEDetalleInput>() {
                    new TS_BEDetalleInput()
                    {
                        item = 1,
                        cdarticulo = item.cdarticulo,
                        cdarticulosunat = item.cdarticulosunat,
                        dsarticulo = item.dsarticulo,
                        precio = item.precio,
                        cantidad = item.cantidad,
                        total = item.total,
                        impuesto = item.impuesto,
                        mtodscto = item.mtodscto,
                        mtoimpuesto = item.mtoimpuesto,
                        subtotal = item.subtotal,
                        moverstock = item.moverstock,
                        cara = item.cara,
                        costo = item.costo,
                        cdunimed = item.cdunimed,
                        nrogasboy = item.nrogasboy,
                        precio_orig = item.precio_orig,
                        tpformula = item.tpformula,
                        impuesto_plastico = item.impuesto_plastico,
                        valorconversion = item.valorconversion,
                        cdmedequiv = item.cdmedequiv,
                        tpconversion = item.tpconversion

                    }
            };
        }
        public static List<TS_BEPagoInput> InputPagosAutomaticMethod(TerminalSIGES.Models.Lado Cara, TS_BEArticulo Transaccion)
        {


            if (Cara.Documento == TerminalSIGES.Models.EDocumento.BoletaFactura)
            {
                if (Cara.Pagos.Count > 1)
                {
                    decimal TotalProducto = Transaccion.total;
                    decimal TotalPagos = 0;

                    List<TS_BEPagoInput> Pagos = new List<TS_BEPagoInput>();

                    foreach (TerminalSIGES.Models.Pago Pago in Cara.Pagos)
                    {
                        TotalPagos += (Pago.Dolares * TSSalesApp.TipoCambio) + (Pago.Soles);
                        Pagos.Add(new TS_BEPagoInput()
                        {
                            cdtppago = Pago.Codigo,
                            cdbanco = "",
                            nrocuenta = "",
                            nrocheque = "",
                            nrotarjeta = Pago.Referencia,
                            cdtarjeta = Pago.Tipo,
                            mtopagosol = Pago.Soles,
                            mtopagodol = Pago.Dolares
                        });
                    }

                    if(TotalProducto > TotalPagos)
                    {
                        return null;
                    }

                    return Pagos;

                }

                if(Cara.Pagos.Count == 1)
                {
                    if (Cara.Pagos[0].Dolares > 0)
                    {
                        if (Transaccion.total > (Cara.Pagos[0].Dolares * TSSalesApp.TipoCambio) + (Cara.Pagos[0].Soles))
                        {
                            return null;
                        }
                    }
                    else
                    {
                        Cara.Pagos[0].Soles = Transaccion.total;
                    }
                    
                    return new List<TS_BEPagoInput>()
                    {
                        new TS_BEPagoInput(){
                            cdtppago= Cara.Pagos[0].Codigo,
                            cdbanco="",
                            nrocuenta="",
                            nrocheque ="",
                            nrotarjeta = Cara.Pagos[0].Referencia,
                            cdtarjeta = Cara.Pagos[0].Tipo,
                            mtopagosol = Cara.Pagos[0].Soles,
                            mtopagodol = Cara.Pagos[0].Dolares
                        }
                    };
                }
                else 
                {
                    return new List<TS_BEPagoInput>()
                    {
                        new TS_BEPagoInput(){
                            cdtppago="00001",
                            cdbanco="",
                            nrocuenta="",
                            nrocheque ="",
                            nrotarjeta ="",
                            cdtarjeta ="",
                            mtopagosol = Transaccion.total,
                            mtopagodol = 0
                        }
                    };
                }
            }
            if (Cara.Documento == TerminalSIGES.Models.EDocumento.NotaDespacho)
            {
                return new List<TS_BEPagoInput>()
                {
                    new TS_BEPagoInput(){
                        cdtppago="00004",
                        cdbanco="",
                        nrocuenta="",
                        nrotarjeta ="",
                        nrocheque ="",
                        cdtarjeta ="",
                        mtopagosol = Transaccion.total,
                        mtopagodol = 0
                    }
                };
            }

            return new List<TS_BEPagoInput>()
            {
                    new TS_BEPagoInput(){
                        cdtppago="00001",
                        cdbanco="",
                        nrocuenta="",
                        nrotarjeta ="",
                        nrocheque ="",
                        cdtarjeta ="",
                        mtopagosol = Transaccion.total,
                        mtopagodol = 0
                    }
            };



        }
        public static void InputMoneyAutomaticMethod(TerminalSIGES.Models.Lado Cara, TS_BECabeceraInput cCabecera, TS_BEDetalleInput[] cDetalles, TS_BEPagoInput[] cPagos)
        {
            if (Cara.Documento == TerminalSIGES.Models.EDocumento.Canje || Cara.Documento == TerminalSIGES.Models.EDocumento.NotaDespacho ||
               Cara.Documento == TerminalSIGES.Models.EDocumento.TranferenciaGratuita)
            {
                return;
            }

            decimal TotalProducto = 0;
            decimal TotalPagos = 0;

            foreach (TS_BEDetalleInput item in cDetalles)
            {
                TotalProducto += item.total;

            }
            foreach (TerminalSIGES.Models.Pago Pago in Cara.Pagos)
            {
                TotalPagos += (Pago.Dolares * TSSalesApp.TipoCambio) + (Pago.Soles);

            }

            cCabecera.mtovueltosol = TotalPagos > TotalProducto ? TotalPagos - TotalProducto : 0;

        }
    }
}
