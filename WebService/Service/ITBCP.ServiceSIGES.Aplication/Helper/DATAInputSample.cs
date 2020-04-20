using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Aplication.Helper
{
    public static class DATAInputSample
    {
        public static TS_BECabecera InputcCabeceraApp(TS_BEClienteInput cCliente,TS_BECabeceraInput cCabeceraInput, TS_BETerminal cTerminal, TS_BEParametro cParametro, TS_BECambio cTipoCambio, List<TS_BEDetalleInput> cDetalle)
        {
            decimal _SubTotal = 0;
            decimal _Igv = 0;
            decimal _Total = 0;
            decimal _Descuentos = 0;
            decimal _ImpuestoBolsa = 0;
            string _cara = "";

            foreach (var item in cDetalle)
            {
                _SubTotal += item.subtotal;
                _Igv += item.mtoimpuesto;
                _Total += item.total;
                _Descuentos += item.mtodscto;
                _ImpuestoBolsa += item.monto_impuesto_plastico;
                if (!String.IsNullOrEmpty(item.cara))
                {
                    _cara = item.cara;
                }
            }

            string tipoDocumento = cCabeceraInput.cdtipodoc.Trim();
            string nroDocumento = "";

            switch (tipoDocumento)
            {
                case "00001":
                    nroDocumento = Convert.ToString(Int64.Parse(cTerminal.factura) + 1).PadLeft(10, '0');
                    break;
                case "00003":
                    nroDocumento = Convert.ToString(Int64.Parse(cTerminal.boleta) + 1).PadLeft(10, '0');
                    break;
                case "99999":
                    nroDocumento = Convert.ToString(Int64.Parse(cTerminal.nventa) + 1).PadLeft(10, '0');
                    break;
                case "99998":
                    nroDocumento = Convert.ToString(Int64.Parse(cTerminal.promocion) + 1).PadLeft(10, '0');
                    break;
            }

            TS_BECabecera cCabecera = new TS_BECabecera();

            cCabecera.cdlocal = cParametro.cdlocal ?? "";
            cCabecera.nroseriemaq = cTerminal.nroseriemaq ?? "";
            cCabecera.cdtipodoc = cCabeceraInput.cdtipodoc ?? "";
            cCabecera.nrodocumento = nroDocumento ?? "";
            cCabecera.fecdocumento = DateTime.Now;
            cCabecera.fecproceso = cTerminal.fecproceso;
            cCabecera.fecsistema = DateTime.Now;
            cCabecera.nropos = cTerminal.nropos ?? "";
            cCabecera.mtovueltosol = cCabeceraInput.mtovueltosol;
            cCabecera.mtovueltodol = cCabeceraInput.mtovueltodol;
            cCabecera.cdalmacen = cTerminal.cdalmacen ?? "";
            cCabecera.cdcliente = cCabeceraInput.cdcliente ?? "";
            cCabecera.ruccliente = cCabeceraInput.ruccliente ?? "";
            cCabecera.rscliente = cCabeceraInput.rscliente ?? "";
            cCabecera.nroproforma = "";
            cCabecera.cdprecio = "";
            cCabecera.cdmoneda = cCabeceraInput.cdmoneda ?? "";
            cCabecera.porservicio = 0;
            cCabecera.pordscto1 = 0;
            cCabecera.pordscto2 = 0;
            cCabecera.pordscto3 = 0;
            cCabecera.pordsctoeq = 0;
            cCabecera.mtonoafecto = 0;
            cCabecera.valorvta = _SubTotal;
            cCabecera.mtodscto = (cCabecera.tipoventa ?? "" ).Trim().Equals("T") || (cCabecera.cdtipodoc ?? "").Trim().Equals("99998") ? 0 : _Descuentos;
            cCabecera.mtosubtotal = _SubTotal;
            cCabecera.mtoservicio = 0;
            cCabecera.mtoimpuesto = _Igv;
            cCabecera.mtototal = _Total;
            cCabecera.cdtranspor = "";
            cCabecera.ructranspor = null;
            cCabecera.nroplaca = cCabeceraInput.nroplaca ?? "";
            cCabecera.drpartida = "";
            cCabecera.marcavehic = "";
            cCabecera.drdestino = "";
            cCabecera.cdusuario = cCabeceraInput.cdusuario ?? "";
            cCabecera.cdvendedor = cCabeceraInput.cdvendedor ?? "";
            cCabecera.cdusuanula = null;
            cCabecera.fecanula = null;
            cCabecera.fecanulasis = null;
            cCabecera.tipofactura = "";
            cCabecera.flgmanual = false;
            cCabecera.tcambio = cTipoCambio.cambio;
            cCabecera.nroocompra = "";
            cCabecera.flgcierrez = false;
            cCabecera.observacion = (cCabeceraInput.observacion ?? "");
            cCabecera.flgmovimiento = true;
            cCabecera.referencia = cCliente.iscanje ? "CANJE TARJ.PROM" : "";
            cCabecera.nroserie1 = "";
            cCabecera.nroserie2 = "";
            cCabecera.turno = cTerminal.turno.ToString() ?? "";
            cCabecera.nrobonus = "";
            cCabecera.nrotarjeta = cCabeceraInput.nrotarjeta ?? "";
            cCabecera.odometro = cCabeceraInput.odometro ?? "";
            cCabecera.archturno = null;
            cCabecera.mtorecaudo = 0;
            cCabecera.inscripcion = "";
            cCabecera.chofer = cCabeceraInput.chofer ?? "";
            cCabecera.nrolicencia = "";
            cCabecera.chkespecial = false;
            cCabecera.tipoventa = cCabeceraInput.TipoVenta ?? "";
            cCabecera.nrocelular = "";
            cCabecera.ptosganados = 0;
            cCabecera.TipoAcumula = "";
            cCabecera.valoracumula = 0;
            cCabecera.c_centralizacion = "";
            cCabecera.cantcupon = 0;
            cCabecera.mtocanje = 0;
            cCabecera.MtoPercepcion = 0;
            cCabecera.cdruta = "";
            cCabecera.codes = "";
            cCabecera.codeID = "";
            cCabecera.mensaje1 = "";
            cCabecera.mensaje2 = "";
            cCabecera.pdf417 = "";
            cCabecera.cdhash = "";
            cCabecera.scop = "";
            cCabecera.nroguia = "";
            cCabecera.mtodetraccion = 0;
            cCabecera.porcdetraccion = 0;
            cCabecera.ctadetraccion = "";
            cCabecera.fact_elect = true;
            cCabecera.redondea_indecopi = cCabeceraInput.redondea_indecopi;
            cCabecera.cdmedio_pago = "";
            cCabecera.dsusuario = (cCabeceraInput.dsusuario ?? "");
            cCabecera.lado = _cara ?? "";

            return cCabecera;

        }
        public static List<TS_BEArticulo> InputcDetalleApp(List<TS_BEDetalleInput> cDetalleInput, TS_BECabecera cCabecera)
        {
            List<TS_BEArticulo> cDetalle = new List<TS_BEArticulo>();
            int nroitem = 1;
            foreach (var item in cDetalleInput)
            {
                cDetalle.Add(new TS_BEArticulo()
                {
                    cdlocal = cCabecera.cdlocal,
                    nroseriemaq = cCabecera.nroseriemaq,
                    cdtipodoc = cCabecera.cdtipodoc,
                    nrodocumento = cCabecera.nrodocumento,
                    cdalterna = "",
                    cdvendedor = "",
                    flgcierrez = false,
                    archturno = false,
                    item = nroitem,
                    hora = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString(),
                    tipo = "",
                    cdarticulo = item.cdarticulo ?? "",
                    dsarticulo = item.dsarticulo ?? "",
                    precio = item.precio,
                    cantidad = item.cantidad,
                    total = item.total,
                    talla = "",
                    pordsctoeq = 0,
                    mtodscto = (cCabecera.tipoventa ?? "").Equals("T") || (cCabecera.cdtipodoc ?? "").Trim().Equals("99998") ? 0 : item.mtodscto,
                    pordscto1 = 0,
                    pordscto2 = 0,
                    pordscto3 = 0,
                    cdtalla = "",
                    mtonoafecto = 0,
                    valorvta = item.subtotal,
                    impuesto = item.impuesto,
                    mtoservicio = 0,
                    mtoimpuesto = item.mtoimpuesto,
                    subtotal = item.subtotal,
                    tpformula = item.tpformula,
                    moverstock = item.moverstock,
                    vtaxmonto = true,
                    dsarticulo1 = "",
                    cara = item.cara,
                    manguera = "",
                    nrogasboy = item.nrogasboy,
                    cdgrupo01 = "",
                    movimiento = true,
                    glosa = item.dsarticulo ?? "",
                    costo = item.costo,
                    cantidad2 = 0,
                    precio2 = 0,
                    cdunimed = item.cdunimed ?? "",
                    usadecimales = true,
                    trfgratuita = false,
                    origsoles = 0,
                    precio_orig = item.precio_orig,
                    ptosganados = 0,
                    tipoacumula = "",
                    valoracumula = 0,
                    tiposuma = "",
                    costo_venta = 0,
                    precioafiliacion = 0,
                    rev_promo = false,
                    porcpercepcion = 0,
                    flgpromocion = false,
                    mtopercepcion = 0,
                    cdpack = "",
                    mtodetraccion = 0,
                    porcdetraccion = 0,
                    cantidad_orig = 0,
                    redondea_indecopi = item.redondea_indecopi,
                    cdarticulosunat = item.cdarticulosunat ?? "",
                    turno = cCabecera.turno ?? "",
                    valor_acumulado = item.valor_acumulado,
                    valor_puntos = item.valor_puntos,
                    config = item.config,
                    impuesto_plastico = item.impuesto_plastico,     
                    monto_impuesto_plastico = item.monto_impuesto_plastico,
                    cdmedequiv = item.cdmedequiv,
                    valorconversion = item.valorconversion,
                    tpconversion = item.tpconversion
                });
                nroitem++;
            }
        
            return cDetalle;

        }
        public static List<TS_BEPago> InputcPagoApp(List<TS_BEPagoInput> cPagoInput, TS_BECabecera cCabecera)
        {
            List<TS_BEPago> cPago = new List<TS_BEPago>();

            foreach (var item in cPagoInput)
            {
                cPago.Add(new TS_BEPago()
                {
                    cdlocal = cCabecera.cdlocal,
                    nroseriemaq = cCabecera.nroseriemaq,
                    nropos = cCabecera.nropos,
                    cdtipodoc = cCabecera.cdtipodoc,
                    nrodocumento = cCabecera.nrodocumento,
                    cdtppago = item.cdtppago,
                    fecdocumento = cCabecera.fecdocumento,
                    fecproceso = cCabecera.fecproceso,
                    cdbanco = item.cdbanco,
                    nrocuenta = item.nrocuenta ?? "",
                    nrocheque = item.nrocheque ?? "",
                    cdtarjeta = item.cdtarjeta ?? "",
                    nrotarjeta = item.nrotarjeta ?? "",
                    mtopagosol = item.mtopagosol ?? 0,
                    mtopagodol = item.mtopagodol ?? 0,
                    flgcierrez = false,
                    turno = cCabecera.turno ?? "",
                    nroncredito = "",
                    valoracumula = 0
                });
            }

            return cPago;
        } 
        public static TS_BEClienteInput InputcCliente()
        {
            TS_BEClienteInput cCliente = new TS_BEClienteInput();
            var _ITS_AIUtilities = new TS_APUtilities();
            Random random = new Random();
            cCliente.cdcliente = random.Next(1, 500).ToString();
            cCliente.ruccliente = random.Next(1000, 5000).ToString();
            cCliente.drcliente = _ITS_AIUtilities.RandomString(10, true);
            cCliente.rscliente = _ITS_AIUtilities.RandomString(20, true);
            cCliente.tipocli = "G";
            return cCliente;
        }
        public static TS_BEVentag InputVengaG(TS_BECabecera cCabecera)
        {
            TS_BEVentag cVentag = new TS_BEVentag();

            cVentag.cdlocal = cCabecera.cdlocal;
            cVentag.nroseriemaq = cCabecera.nroseriemaq;
            cVentag.cdtipodoc = cCabecera.cdtipodoc;
            cVentag.nrodocumento = cCabecera.nrodocumento;
            cVentag.fecdocumento = cCabecera.fecdocumento;
            cVentag.fecproceso = cCabecera.fecproceso;
            cVentag.fecanula = null;
            cVentag.fecanulasis = null;
            cVentag.nropos = cCabecera.nropos;
            cVentag.cdcliente = cCabecera.cdcliente;
            cVentag.declarado = null;
            cVentag.anulado = null;
            return cVentag;
        }
        public static TS_BEVentar InputVentaR(TS_BECabecera cCabecera)
        {
            TS_BEVentar cVentar = new TS_BEVentar();

            cVentar.cdlocal = cCabecera.cdlocal;
            cVentar.fecdocumento = cCabecera.fecdocumento.Date;
            cVentar.fecproceso = cCabecera.fecproceso;
            return cVentar;
        }
        public static TS_BEClienteInput InputCliente(TS_BEClienteInput cCliente)
        {
            if(String.IsNullOrEmpty(cCliente.cdcliente))
            {
                cCliente.cdcliente = "";
            }
            if (String.IsNullOrEmpty(cCliente.ruccliente))
            {
                cCliente.ruccliente = "";
            }
            if (String.IsNullOrEmpty(cCliente.rscliente))
            {
                cCliente.rscliente = "";
            }
            if (String.IsNullOrEmpty(cCliente.drcliente))
            {
                cCliente.drcliente = "";
            }
            if (String.IsNullOrEmpty(cCliente.correoelectronico))
            {
                cCliente.correoelectronico = "";
            }
            if (String.IsNullOrEmpty(cCliente.emcliente))
            {
                cCliente.emcliente = "";
            }
            return cCliente;
        }
    }

}
