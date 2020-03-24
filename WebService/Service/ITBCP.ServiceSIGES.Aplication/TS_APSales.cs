using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

using ITBCP.ServiceSIGES.Aplication.Helper;
using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Articulo;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Facturacion.Electronica;
using ITBCP.ServiceSIGES.Domain.Entities.Reimpresion;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using Newtonsoft.Json;

namespace ITBCP.ServiceSIGES.Aplication
{
    public class TS_APSales : ITS_AISales
    {

        private readonly ITS_DOIgv _ITS_DOIgv;
        private readonly ITS_DOServer _ITS_DOServer;
        private readonly ITS_DOCara _ITS_DOCara;
        private readonly ITS_DOParametro _ITS_DOParametro;
        private readonly ITS_DOTarjeta _ITS_DOTarjeta;
        private readonly ITS_DOTipoCambio _ITS_DOTipoCambio;
        private readonly ITS_DOTipoPago _ITS_DOTipoPago;
        private readonly ITS_DOVendedor _ITS_DOVendedor;
        private readonly ITS_DOTerminal _ITS_DOTerminal;
        private readonly ITS_AIUtilities _ITS_AIUtilities;
        private readonly ITS_AICliente _ITS_AICliente;
        private readonly ITS_AIArticulo _ITS_AIArticulo;
        private readonly ITS_DOBackOffice _ITS_DOBackOffice;
        private readonly ITS_DOOpTransaction _ITS_DOOpTransaction;
        private readonly ITS_DOCierre _ITS_DOCierre;
        private readonly ITS_DOGrabarTransaccion _ITS_DOGrabarTransaccion;
        private readonly ITS_DOCorrelativo _ITS_DOCorrelativo;
        private readonly ITS_AIFacturacionE _ITS_AIFacturacionE;
        private readonly ITS_DOEmisor _ITS_DOEmisor;
        private readonly ITS_AIImpresion _ITS_Impresion;
        private readonly ITS_DOReimpresion _ITS_DOReimpresion;
        private readonly ITS_DODeposito _ITS_DODeposito;
        private readonly ITS_AITarjeta _ITS_AITarjeta;

        public TS_APSales(ITS_DOIgv ITS_DOIgv,
            ITS_DOServer ITS_DOServer,
            ITS_DOCara ITS_DOCara,
            ITS_DOParametro ITS_DOParametro,
            ITS_DOTarjeta ITS_DOTarjeta,
            ITS_DOTipoCambio ITS_DOTipoCambio,
            ITS_DOTipoPago ITS_DOTipoPago,
            ITS_DOVendedor ITS_DOVendedor,
            ITS_DOTerminal ITS_DOTerminal,
            ITS_AIUtilities ITS_AIUtilities,
            ITS_AICliente ITS_AICliente,
            ITS_DOCierre ITS_Cierre,
            ITS_DOBackOffice ITS_DOBackOffice,
            ITS_DOOpTransaction ITS_DOOpTransaction,
            ITS_AIArticulo ITS_AIArticulo,
            ITS_DOGrabarTransaccion ITS_DOGrabarTransaccion,
            ITS_DOCorrelativo ITS_DOCorrelativo,
            ITS_AIFacturacionE ITS_AIFacturacionE,
            ITS_DOEmisor ITS_DOEmisor,
            ITS_AIImpresion ITS_Impresion,
            ITS_DOReimpresion ITS_DOReimpresion,
            ITS_DODeposito ITS_DODeposito,
            ITS_AITarjeta ITS_AITarjeta)
        {
            _ITS_DOTerminal = ITS_DOTerminal;
            _ITS_DOIgv = ITS_DOIgv;
            _ITS_DOServer = ITS_DOServer;
            _ITS_DOCara = ITS_DOCara;
            _ITS_DOParametro = ITS_DOParametro;
            _ITS_DOTarjeta = ITS_DOTarjeta;
            _ITS_DOTipoCambio = ITS_DOTipoCambio;
            _ITS_DOTipoPago = ITS_DOTipoPago;
            _ITS_DOVendedor = ITS_DOVendedor;
            _ITS_AIUtilities = ITS_AIUtilities;
            _ITS_AICliente = ITS_AICliente;
            _ITS_DOBackOffice = ITS_DOBackOffice;
            _ITS_DOOpTransaction = ITS_DOOpTransaction;
            _ITS_AIArticulo = ITS_AIArticulo;
            _ITS_DOCierre = ITS_Cierre;
            _ITS_DOGrabarTransaccion = ITS_DOGrabarTransaccion;
            _ITS_DOCorrelativo = ITS_DOCorrelativo;
            _ITS_AIFacturacionE = ITS_AIFacturacionE;
            _ITS_DOEmisor = ITS_DOEmisor;
            _ITS_Impresion = ITS_Impresion;
            _ITS_DOReimpresion = ITS_DOReimpresion;
            _ITS_DODeposito = ITS_DODeposito;
            _ITS_AITarjeta = ITS_AITarjeta;
        }

        public TS_BESales Loading(TS_BELoadInput input)
        {
            TS_BESales output = new TS_BESales();
            TS_BECabecera cCabecera = new TS_BECabecera();
            output.Parametros = _ITS_DOParametro.ObtenerParametros();
            if (string.IsNullOrEmpty(input.Serie))
            {
                output.Ok = false;
                output.Mensaje = "El número de serie no puede ser vacio";
                return output;
            }
            //if (string.IsNullOrEmpty(input.cdlocal))
            //{
            //    output.Ok = false;
            //    output.Mensaje = "Codigo Localno puede ser vacio";
            //    return output;
            //}

            var cParameters = _ITS_DOParametro.ObtenerParameters();
            if (cParameters.id == null)
            {
                output.Ok = false;
                output.Mensaje = "Error al cargar parameters";
                return output;
            }
            TS_BELocal clocal = new TS_BELocal();
            var cLocal = _ITS_DOBackOffice.SP_ITBCP_OBTENER_LOCAL(new TS_BELocal()
            {
                cdlocal = output.Parametros.cdlocal
            });

            if (cLocal.cdlocal == null)
            {
                output.Ok = false;
                output.Mensaje = "Error al cargar datos de local";
                return output;
            }

            try
            {
                output.FechaServidor = _ITS_DOServer.OBTENER_FECHA_SERVIDOR();
                if (string.IsNullOrEmpty(output.FechaServidor))
                {
                    output.Ok = false;
                    output.Mensaje = "Error en obtener fecha servidor";
                }

                var cIgv = _ITS_DOIgv.OBTENER_IGV(new TS_BETipo_Igv());
                if (cIgv.Count <= 0)
                {
                    output.Ok = false;
                    output.Mensaje = "Error en obtener IGV";
                    return output;
                }
                else
                {
                    if (string.IsNullOrEmpty(cIgv[0].igv))
                    {
                        output.Ok = false;
                        output.Mensaje = "Error en obtener IGV";
                        return output;
                    }
                    else
                    {
                        output.Igv = cIgv[0].igv;
                    }
                }

                output.Terminal = _ITS_DOTerminal.OBTENER_TERMINAL_POR_SERIEHD(new TS_BETerminal() { seriehd = input.Serie });
                if (output.Terminal.cdusuario == null)
                {
                    output.Ok = false;
                    output.Mensaje = "Error en obtener Terminal";
                    return output;
                }

                

                output.Tarjetas = _ITS_DOTarjeta.Obtener_Tarjetas();
                if (output.Tarjetas.Count <= 0)
                {
                    output.Ok = false;
                    output.Mensaje = "Error en obtener Tarjetas";
                    return output;
                }
                output.TipoCambio = Convert.ToDecimal(_ITS_DOTipoCambio.OBTENER_TIPOCAMBIO().cambio);
                if (output.TipoCambio <= 0)
                {
                    output.Ok = false;
                    output.Mensaje = "Error en obtener Tipo de Cambio";
                    return output;
                }

                output.TipoPago = _ITS_DOTipoPago.LISTAR_TIPO_PAGOS(new TS_BETipopago());
                if (output.TipoPago.Count <= 0)
                {
                    output.Ok = false;
                    output.Mensaje = "Error en obtener Tipo de Pago";
                    return output;
                }



                cCabecera.pordsctoeq = 0;
                cCabecera.flgmanual = false;
                cCabecera.drpartida = clocal.drlocal;
                cCabecera.cdalmacen = output.Terminal.cdalmacen;
                cCabecera.cdprecio = output.Terminal.cdprecio;
                // cCabecera.fecha = DateTime.Now;
                cCabecera.fecproceso = output.Terminal.fecproceso == null ? DateTime.Now : Convert.ToDateTime(output.Terminal.fecproceso);
                cCabecera.tcambio = output.TipoCambio;
                // cCabecera.FECVENCIM = DateTime.Now;
                cCabecera.cdmoneda = cParameters.monpais;
                cCabecera.codes = "";
                cCabecera.codeID = "";
                cCabecera.mensaje1 = "";
                cCabecera.mensaje2 = "";
                output.Cabecera = cCabecera;
                output.Ok = true;
                output.Mensaje = "Datos obtenidos desde el servidor correctamente";
                // tab01 la empresa donde esta falg factturacion electronica true=envia tramma

                //almance lo tengo en terminal  
                output.Caras = _ITS_DOCara.LISTAR_CARA_POR_POSICION(new TS_BECara() { nropos = output.Terminal.nropos });
                output.Vendedor = _ITS_DODeposito.OBTENER_VENDEDOR(input.cdusuario ?? "");
                output.Usuario = _ITS_DOServer.OBTENER_USUARIO(input.cdusuario ?? "");


            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }

            return output;

        }
        public TS_BEClienteOutput ObtenerClientByRuc(TS_BEClienteSearch input)
        {
            TS_BEClienteOutput output = new TS_BEClienteOutput();
           
            try
            {
                if (input.Codigo == null)
                {
                    output.Ok = false;
                    output.Mensaje = "Valor del ruc no puede ser vacio";
                    return output;
                }
                if (_ITS_AIUtilities.Valruc(input.Codigo))
                {
                    if (input.flagBusquedaSunat)
                    {
                        if (_ITS_AIUtilities.CheckForInternetConnection())
                        {
                            var resultoutput = _ITS_AIUtilities.ConsultaRuc(input.Codigo);
                            if(resultoutput == null)
                            {
                                return ObternerClienteByCodigo(new TS_BEClienteSearch() { Codigo = input.Codigo });
                            }
                            if (resultoutput.ruc != null)
                            {
                                output.rscliente = resultoutput.razonSocial;
                                output.drcliente = resultoutput.direccion;
                                output.ruccliente = resultoutput.ruc;
                                output.Ok = true;
                                output.Mensaje = "Datos obtenidos correctamente";
                            }
                        }
                        else
                        {
                            output.Ok = false;
                            output.Mensaje = "Para la busqueda de RUC en sunat, se necesita conexión a INTERNET";
                            output = ObternerClienteByCodigo(new TS_BEClienteSearch() { Codigo = input.Codigo });
                        }
                    }
                    //var cTerminal = _ITS_DOTerminal.OBTENER_TERMINAL_POR_SERIEHD(new TS_BETerminal() { seriehd = input.Serie });
                    //var cParametros = _ITS_DOParametro.ObtenerParametros();
                    //var cParameters = _ITS_DOParametro.ObtenerParameters();
                    //if (cTerminal.tktfactura==true)
                    //{
                    //    output.lbl_documento = "TICKET FACTURA";

                    //    if (cParametros.correlativos2_ticket ==true)
                    //    {
                    //        cCabecera.cdtipodoc = cParameters.tpticketfac;
                    //        nroDoc = Convert.ToInt32(cTerminal.ticketfactura) + 1;

                    //    }
                    //    else
                    //    {
                    //        cCabecera.cdtipodoc = cParameters.tpticket;
                    //        nroDoc = Convert.ToInt32(cTerminal.ticket) + 1;
                    //    }
                    //}
                    //else
                    //{
                    //    cCabecera.cdtipodoc = cParameters.tpfactura;

                    //}



                }
                else
                {
                    return this.ObternerClienteByCodigo(input);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }

            return output;
        }
        public TS_BEClienteOutput ObtenerClienteByTarjeta(TS_BEClienteSearch input)
        {
            try
            {
                if (String.IsNullOrEmpty(input.NroTarjeta))
                {
                    return new TS_BEClienteOutput() { Mensaje = "Numero de tarjeta incorrecto", Ok = false };
                }
                else
                {
                    TS_BEClienteOutput Tarjeta = _ITS_AICliente.ObtenerClientebyTarjeta(input);
                    if (Tarjeta.Ok && input.IsArticulo)
                    {
                        TS_BEArticuloOutput Articulos = _ITS_AITarjeta.OBTENER_ARTICULOS_POR_TARJETA(input.NroTarjeta);
                        TS_BEArticuloOutput ArticulosAfiliacion = _ITS_AITarjeta.OBTENER_ARTICULOS_POR_PREFIJO(input.PrefijoAfiliacion);
                        Tarjeta.ArticulosTarjeta = Articulos.Articulos;
                        Tarjeta.ArticulosPrefijo = Articulos.Articulos;
                    }
                    return Tarjeta;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }
        public TS_BESaldoclid ObtenerSaldoClientTarjeta(TS_BEClienteSearch input)
        {
            TS_BESaldoclid output = new TS_BESaldoclid();
            try
            {
                if (input.Codigo == null)
                {
                    output.Ok = false;
                    output.Mensaje = "El tarjeta del cliente no puede ser vacio";

                    return output;
                }
                output = _ITS_AICliente.ObtenerSaldoClientTarjeta(input);
                if (string.IsNullOrEmpty(output.cdcliente))
                {
                    output.Ok = false;
                    output.Mensaje = "CLIENTE NO EXISTE EN LA BASE DE DATOS";
                    return output;
                }
                else
                {
                    output.Ok = true;
                    output.Mensaje = "Datos encontrados";
                    return output;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }


        }
        public TS_BEClienteOutput ObternerClienteByCodigo(TS_BEClienteSearch input)
        {
            string cdCliente = input.Codigo ?? "";
            string tipocli = "";

            if (String.IsNullOrEmpty(cdCliente))
            {
                return new TS_BEClienteOutput("El codigo del cliente no puede estar vacio", false, false);
            }
            TS_BEParametro parametro = _ITS_DOParametro.ObtenerParametros();

            string prefCredLocal = parametro.prefcredlocal.Trim();
            string prefCredCorp = parametro.prefcredcorp.Trim();
            string prefFlotLocal = parametro.prefflotlocal.Trim();

            if (cdCliente.Substring(0, prefCredLocal.Length) == prefCredLocal)
            {
                tipocli = "L";
            }
            else if (cdCliente.Substring(0, prefCredCorp.Length) == prefCredCorp)
            {
                tipocli = "C";
            }
            else if (cdCliente.Substring(0, prefFlotLocal.Length) == prefFlotLocal)
            {
                tipocli = "F";
            }


            if (String.IsNullOrEmpty(tipocli))
            {
                TS_BEClienteOutput output = _ITS_AICliente.ObtenerClienteByCodigo(input);

                if (string.IsNullOrEmpty(output.rscliente))
                {
                    output.Ok = false;
                    output.Mensaje = "Cliente no existe en la base de datos";
                }
                else
                {
                    output.Ok = true;
                    output.Mensaje = "Datos obtenidos correctamente";
                }

                return output;
            }
            else
            {

                TS_BEClienteCreditoOutput cRegSalC = _ITS_AICliente.OBTENER_CLIENTE_CREDITO(parametro, cdCliente);

                if (cRegSalC.Mensaje.Ok)
                {
                    if (cRegSalC.tpsaldo.Equals("T") || cRegSalC.tpsaldo.Equals("C"))
                    {
                        if (cRegSalC.tpsaldo.Equals("T"))
                        {
                            if (cRegSalC.flgilimit || cRegSalC.flgilimitC)
                            {
                                cRegSalC.consumtoC = 0;
                                cRegSalC.limitemtoC = 1000;
                                cRegSalC.consumto = 0;
                                cRegSalC.limitemto = 1000;
                            }
                            if (cRegSalC.flgbloquea || cRegSalC.flgbloqueaC)
                            {
                                return new TS_BEClienteOutput("Cliente con tarjeata bloqueada", false, true);
                            }
                            if (cRegSalC.consumto >= cRegSalC.limitemto)
                            {
                                return new TS_BEClienteOutput("Saldo de tarjeta excedido", false, true);
                            }
                        }
                        if (cRegSalC.tpsaldo.Equals("C"))
                        {
                            if (cRegSalC.flgilimit || cRegSalC.flgilimitC)
                            {
                                cRegSalC.consumtoC = 0;
                                cRegSalC.limitemtoC = 1000;
                                cRegSalC.consumto = 0;
                                cRegSalC.limitemto = 1000;
                            }
                            if (cRegSalC.flgbloquea || cRegSalC.flgbloqueaC)
                            {
                                return new TS_BEClienteOutput("Cliente con credito bloqueado", false, true);
                            }
                            if (cRegSalC.consumtoC >= cRegSalC.limitemtoC)
                            {
                                return new TS_BEClienteOutput("Saldo de cliente excedido", false, true);
                            }
                        }
                       
                        return new TS_BEClienteOutput(cRegSalC,new TS_BEMensaje("", true), tipocli);
                    }
                    else
                    {
                        return new TS_BEClienteOutput("Tipo de saldo de cliente incorrecto", false, true);
                    }
                }
                else
                {
                    return new TS_BEClienteOutput(cRegSalC.Mensaje.mensaje, cRegSalC.Mensaje.Ok, true);
                }
            }
        }
        public List<TS_BEClienteLista> ListarClientes()
        {
            List<TS_BEClienteLista> query = new List<TS_BEClienteLista>();
            TS_BEClienteLista output = new TS_BEClienteLista();
            try
            {
                query = _ITS_AICliente.ListarClientes();

            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return query;
        }
        public TS_BECabeceraOutPut ObtenerOpTransaccion(TS_BEOpTransInput input)
        {

            TS_BECabeceraOutPut cCabeceraOutPut = new TS_BECabeceraOutPut();
            TS_BEParametro Parametros = _ITS_DOParametro.ObtenerParametros();
            TS_BEParameters TAB00S0 = _ITS_DOParametro.ObtenerParameters();
            TS_BETerminal Terminal = _ITS_DOTerminal.OBTENER_TERMINAL_POR_SERIEHD(new TS_BETerminal() { seriehd = input.Serie });

            //** VALIDACIONES
            if (string.IsNullOrEmpty(input.Serie))
            {
                cCabeceraOutPut.Ok = false;
                cCabeceraOutPut.Estado = 1;
                cCabeceraOutPut.Mensaje = "El número de serie debe tener algún valor";
                return cCabeceraOutPut;
            }

            if (string.IsNullOrEmpty(input.cara))
            {
                cCabeceraOutPut.Ok = false;
                cCabeceraOutPut.Estado = 1;
                cCabeceraOutPut.Mensaje = "La cara debe tener algún valor";
                return cCabeceraOutPut;
            }

            if (String.IsNullOrEmpty(Terminal.nropos))
            {
                cCabeceraOutPut.Ok = false;
                cCabeceraOutPut.Estado = 1;
                cCabeceraOutPut.Mensaje = "No existe el punto de venta relacionado";
                return cCabeceraOutPut;
            }

            if (Parametros.bloqventaplaya == true)
            {
                cCabeceraOutPut.Ok = false;
                cCabeceraOutPut.Estado = 1;
                cCabeceraOutPut.Mensaje = "No se puede realizar ventas mientras se realiza el cambio de turno";
                return cCabeceraOutPut;
            }

            //** FIN VALIDACIONES
            //** INICIO DE BUSQUEDA DE VENTAS PENDIENTES
            if (Convert.ToBoolean(Terminal.conexion_dispensador) && Convert.ToBoolean(Parametros.conexiondispensador))
            {
                if (Convert.ToBoolean(Parametros.activasawa))
                {
                    if (input.automatic)
                    {
                        cCabeceraOutPut.cDetalleOutPut = _ITS_DOOpTransaction.LISTAR_TRANSACTION(new TS_BEOp_Tran() { cara = input.cara });
                    }
                    if (input.automatic == false)
                    {
                        cCabeceraOutPut.cDetalleOutPut = _ITS_DOOpTransaction.LISTAR_TRANSACTIONS(new TS_BEOp_Tran() { cara = input.cara });
                    }


                    if (cCabeceraOutPut.cDetalleOutPut.Count == 0)
                    {
                        cCabeceraOutPut.Ok = false;
                        cCabeceraOutPut.Estado = 4;
                        cCabeceraOutPut.Mensaje = "No existen transacciones pendientes";
                        return cCabeceraOutPut;
                    }
                }
                else
                {
                    var cAlias = TAB00S0.path_gasboy.Trim() + "tran" + input.cara + ".DBF";
                    if (!File.Exists(cAlias))
                    {
                        cCabeceraOutPut.Ok = false;
                        cCabeceraOutPut.Estado = 3;
                        cCabeceraOutPut.Mensaje = " La Tabla " + cAlias + " No Existe";
                        return cCabeceraOutPut;
                    }

                    if (input.automatic)
                    {
                        cCabeceraOutPut.cDetalleOutPut = _ITS_AIUtilities.ReadTopOneFileDbf(cAlias, input.cara);
                    }
                    if (input.automatic == false)
                    {
                        cCabeceraOutPut.cDetalleOutPut = _ITS_AIUtilities.ReadAllFileDbf(cAlias, input.cara);
                    }

                    if (cCabeceraOutPut.cDetalleOutPut.Count == 0)
                    {
                        cCabeceraOutPut.Ok = false;
                        cCabeceraOutPut.Estado = 4;
                        cCabeceraOutPut.Mensaje = "No existen transacciones pendientes";
                        return cCabeceraOutPut;
                    }
                }

            }
            if(Convert.ToBoolean(Terminal.conexion_dispensador) == false ||  Convert.ToBoolean(Parametros.conexiondispensador) == false)
            {
                cCabeceraOutPut.cDetalleOutPut = _ITS_DOOpTransaction.LISTAR_TRANSACTION_MANUAL();
            }

            foreach (var item in cCabeceraOutPut.cDetalleOutPut)
            {
                var carticulo = _ITS_AIArticulo.ObtenerArticulByCodigo(cdarticulo: item.cdarticulo );
                if (carticulo.Ok)
                {
                    item.impuesto = Convert.ToDecimal(carticulo.impuesto);
                    item.dsarticulo = carticulo.dsarticulo;
                    item.moverstock = Convert.ToBoolean(carticulo.moverstock);
                    item.dsarticulo1 = carticulo.dsarticulo1;
                    item.cdunimed = carticulo.cdunimed;
                    item.porcpercepcion = Convert.ToDecimal(carticulo.porcpercepcion);
                    item.cdgrupo01 = carticulo.cdgrupo01;
                    item.costo = Convert.ToDecimal(carticulo.ctoreposicion);
                    item.trfgratuita = Convert.ToBoolean(carticulo.trfgratuita);
                    item.cdarticulosunat = carticulo.cdarticulosunat;
                    item.impuesto_plastico = carticulo.impuesto_plastico;
                }
            }

            //** FINAL DE BUSQUEDA DE VENTAS PENDIENTES

            TS_BEClienteCreditoOutput cliente = _ITS_AICliente.OBTENER_CLIENTE_CREDITO(Parametros, input.cdcliente);
            if (cliente.Mensaje.Ok)
            {
                input.cdcliente = cliente.cdcliente;
                input.isCredito = true;
            }
            else
            {
                input.isCredito = false;
            }

            if((Convert.ToBoolean(Parametros.flg_noaplica_desc_tarj ?? false) == true) && (input.isCredito == true))
            {
                cCabeceraOutPut.Mensaje = "";
                cCabeceraOutPut.Ok = true;
                return cCabeceraOutPut;
            }
            TS_BEMensaje respuesta = new TS_BEMensaje("", true);

            /** SI ES SERAFIN O TRANFERENCIA GRATUITA EN AUTOMATICO **/
            if ((input.cdcliente ?? "").Trim().Equals("XXXXXXXXXXX") == false)
            {
                respuesta = _ITS_DOBackOffice.SP_ITBCP_APLICAR_DESCUENTO(cCabeceraOutPut, input);
            }
            if ((input.cdcliente ?? "").Trim().Equals("XXXXXXXXXXX"))
            {
                foreach (var item in cCabeceraOutPut.cDetalleOutPut)
                {
                    item.precio_orig = item.precio;
                }
            }



            foreach (var item in cCabeceraOutPut.cDetalleOutPut)
            {

                if (Parametros.galones_decimales == 0)
                {
                    item.cantidad_orig = item.cantidad;
                    item.cantidad = Math.Round(item.cantidad, 3);
                   
                }

                else
                {
                    item.cantidad_orig = item.cantidad;
                    item.cantidad = Math.Round(item.cantidad, Parametros.galones_decimales);
                }

                item.tipo = "COMBUSTIBLE";
                item.total = Math.Round(item.cantidad * item.precio, 2, MidpointRounding.AwayFromZero);
                if (item.precio == item.precio_orig)
                {
                    item.total = item.total_display;
                }
                decimal MtoSubTot = item.total / ((100 + item.impuesto) / 100);
                item.subtotal = Math.Round(MtoSubTot, 2, MidpointRounding.AwayFromZero);
                item.mtoimpuesto = Math.Round(item.total - MtoSubTot, 2, MidpointRounding.AwayFromZero);
                item.mtodscto = Math.Round((item.precio_orig - item.precio) * item.cantidad, 2, MidpointRounding.AwayFromZero);
               

            }

            cCabeceraOutPut.Mensaje = respuesta.mensaje;
            cCabeceraOutPut.Ok = respuesta.Ok;
            return cCabeceraOutPut;
        }
        public TS_BERetornoTransaccion GrabarTransaccion(List<TS_BEDetalleInput> cDetalleInput, TS_BECabeceraInput cCabeceraInput, List<TS_BEPagoInput> cPagoInput, TS_BEClienteInput cCliente,TS_BELoadInput cLoading,TS_BEGrabarConfig cConfiguracion)
        {
            TS_BEDocumento cDocumento = null ;
            TS_BERetornoTransaccion retorno = new TS_BERetornoTransaccion();
            TS_BEMensaje SaleResponse = null;
            TS_BETerminal cTerminal = _ITS_DOTerminal.OBTENER_TERMINAL_POR_SERIEHD(new TS_BETerminal() { seriehd = cLoading.Serie });
            try
            {

                if (cCliente.iscanje)
                {
                    TS_BERespuestaCanje Respuesta = _ITS_AITarjeta.VALIDAR_CANJE(cCliente: cCliente, cDetalle: cDetalleInput);
                    if(Respuesta.Mensaje.Ok == false)
                    {
                        retorno.Mensaje = Respuesta.Mensaje.mensaje;
                        retorno.Ok = Respuesta.Mensaje.Ok;
                        return retorno;
                    }
                }

                TS_BEParameters cTab00S0 = _ITS_DOParametro.ObtenerParameters();
                TS_BEParametro cParametro = _ITS_DOParametro.ObtenerParametros();
                TS_BECambio cTipoCambio = _ITS_DOTipoCambio.OBTENER_TIPOCAMBIO();
                TS_BEEmisor cEmisor = _ITS_DOEmisor.OBTENER_EMISOR_POR_EMPRESA(new TS_BEEmisor() { cdempresa = cLoading.cdempresa });
                TS_BELocal cLocal = _ITS_DOBackOffice.SP_ITBCP_OBTENER_LOCAL(new TS_BELocal() { cdlocal = cLoading.cdlocal });

                TS_BECabecera cCabecera = new TS_BECabecera();
                List<TS_BEArticulo> cDetalle = new List<TS_BEArticulo>();
                List<TS_BEPago> cPago = new List<TS_BEPago>();
                TS_BEVentag cVentag = new TS_BEVentag();
                TS_BEVentar cVentar = new TS_BEVentar();
                TS_BETicket cTicket = new TS_BETicket();

                cCliente = DATAInputSample.InputCliente(cCliente);
                cCabecera = DATAInputSample.InputcCabeceraApp(cCliente,cCabeceraInput, cTerminal, cParametro, cTipoCambio, cDetalleInput);
                cDetalle = DATAInputSample.InputcDetalleApp(cDetalleInput, cCabecera);
                cPago = DATAInputSample.InputcPagoApp(cPagoInput, cCabecera);
                cVentag = DATAInputSample.InputVengaG(cCabecera);
                cVentar = DATAInputSample.InputVentaR(cCabecera);

                //Obtención de formato de impresión para ticket según tipo de documento

                string lTipoDoc = cCabecera.cdtipodoc;

                switch (lTipoDoc)
                {
                    case "00001":
                        cTicket = _ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_TICKET();
                        break;
                    case "00003":
                        cTicket = _ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_TICKET();
                        break;
                    case "99999":
                        cTicket = _ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_NOTA_VENTA();
                        break;
                    case "99998":
                        cTicket = _ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_SERAFIN();
                        break;
                    default:
                        break;
                }

                TS_BEFormato cFormato = new TS_BEFormato(cTicket.cabecera,cTicket.pie);

                //De la lista se convierte a cadena y se agrega \n despues de cada línea

                if (cCabecera.flgmanual)
                {
                    //cCabecera.fecproceso = cCabecera.fecha;
                    //cCabecera.fecdocumento = cCabecera.fecha;
                }
                else
                {
                    if (cTerminal.modfecha == true)
                    {
                        //  cCabecera.fecproceso = cCabecera.fecha;
                        //  cCabecera.fecdocumento = cCabecera.fecha;
                    }
                    else
                    {
                        if (cParametro.flg_fecsrv == true)
                        {
                            string fecha = _ITS_DOServer.OBTENER_FECHA_SERVIDOR();
                            cCabecera.fecdocumento = DateTime.Parse(fecha);
                        }
                        else
                        {
                            cCabecera.fecdocumento = DateTime.Now;
                        }
                    }

                    cCabecera.fecproceso = (DateTime)cTerminal.fecproceso;
                }

                cCabecera.turno = ((int)cTerminal.turno).ToString();

                List<TS_BECierres> cCierres = _ITS_DOCierre.SP_ITBCP_LISTAR_ULTIMO_CIERRE(null);

                if (cCierres != null && cCierres.Count > 0)
                {
                    TS_BECierres cCierre = cCierres[0];

                  /*  if (cCabecera.fecproceso < cCierre.fecha)
                    {
                        // mensaje de validacion 
                        retorno.Ok = false;
                        retorno.Mensaje = "La Fecha Debe Ser Mayor A  - Ya Se Realizo El Cierre De Mes  ";

                        return retorno;
                    }*/

                    if (cCabecera.tcambio <= 0)
                    {
                        retorno.Ok = false;
                        retorno.Mensaje = "Actualice El Tipo De Cambio";
                        return retorno;
                    }

                }
                int cFormu = 1;
                foreach (var item in cDetalle)
                {
                    if (item.tpformula == "A")
                    {
                        cFormu++;
                    }

                }
                if (cDetalle.Count <= 0)
                {
                    retorno.Ok = false;
                    retorno.Mensaje = "No existe ventas para procesar...";
                    return retorno;
                }

                cCabecera.fecdocumento = DateTime.Now;
                if (cFormu > 0)
                {

                    string xInsumois = "Insumois" + cCabecera.fecdocumento.Year + (cCabecera.fecdocumento.Month.ToString().Length == 1 ? "0" + cCabecera.fecdocumento.Month.ToString() : cCabecera.fecdocumento.Month.ToString());

                    if (!_ITS_DOServer.EXISTE_TABLA(xInsumois))
                    {
                        _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_INSUMOIS(xInsumois);
                    }
                }
                string lExtension = cCabecera.fecdocumento.Year + (cCabecera.fecdocumento.Month.ToString().Length == 1 ? "0" + cCabecera.fecdocumento.Month.ToString() : cCabecera.fecdocumento.Month.ToString());
                string nameVenta = "Venta" + lExtension;
                if (!_ITS_DOServer.EXISTE_TABLA(nameVenta))
                {
                    _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_VENTA(nameVenta);
                }
                string nameVentaD = "VentaD" + lExtension;
                if (!_ITS_DOServer.EXISTE_TABLA(nameVentaD))
                {
                    _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_VENTAD(nameVentaD);
                }
                string nameVentaP = "VentaP" + lExtension;
                if (!_ITS_DOServer.EXISTE_TABLA(nameVentaP))
                {
                    _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_VENTAP(nameVentaP);
                }

               
                if (cCabeceraInput.cdtipodoc.Equals("99999"))
                {
                    TS_BEClienteCreditoOutput cClienteOutput = _ITS_AICliente.OBTENER_CLIENTE_CREDITO(cParametro, cCliente.nroTarjeta ?? "");
                    TS_BEClienteOutput vCliente = _ITS_AICliente.ObtenerClienteByCodigo(new TS_BEClienteSearch() { Codigo = cClienteOutput.cdcliente, flagBusquedaSunat = false, NroTarjeta = "", Ruc = "" });
                    if (cClienteOutput.Mensaje.Ok)
                    {
                        if (cClienteOutput.tpsaldo.Equals("T") || cClienteOutput.tpsaldo.Equals("C"))
                        {
                            if (cClienteOutput.flgilimit || cClienteOutput.flgilimitC)
                            {
                                cClienteOutput.limitemto = 1000;
                                cClienteOutput.limitemtoC = 1000;
                                cClienteOutput.consumto = 0;
                                cClienteOutput.consumtoC = 0;
                            }

                            if (cClienteOutput.tpsaldo.Equals("T"))
                            {
                                if (cClienteOutput.consumto >= cClienteOutput.limitemto)
                                {
                                    retorno.Ok = false;
                                    retorno.Mensaje = "Saldo de cliente excedido";
                                    return retorno;
                                }
                                if(cClienteOutput.flgbloqueaC || cClienteOutput.flgbloquea)
                                {
                                    retorno.Ok = false;
                                    retorno.Mensaje = "Tarjeta Bloqueada";
                                    return retorno;
                                }
                                cCabecera.saldo_disponible =Math.Round(cClienteOutput.limitemto - cClienteOutput.consumto , 2);
                            }
                            if (cClienteOutput.tpsaldo.Equals("C"))
                            {
                                
                                if (cClienteOutput.consumtoC >= cClienteOutput.limitemtoC)
                                {
                                    retorno.Ok = false;
                                    retorno.Mensaje = "Saldo de cliente excedido";
                                    return retorno;
                                }
                                if (cClienteOutput.flgbloqueaC || cClienteOutput.flgbloquea)
                                {
                                    retorno.Ok = false;
                                    retorno.Mensaje = "Tarjeta Bloqueada";
                                    return retorno;
                                }
                                cCabecera.saldo_disponible = Math.Round(cClienteOutput.limitemtoC - cClienteOutput.consumtoC, 2);
                            }
                        }
                        else
                        {
                            retorno.Ok = false;
                            retorno.Mensaje = "Tipo de saldo de cliente incorrecto";
                            return retorno;
                        }

                        
                        cCliente.flgpreciond = Convert.ToBoolean(vCliente.flgpreciond);
                        cCliente.flgtotalnd  = Convert.ToBoolean(vCliente.flgtotalnd);
                        cCliente.flgmostrarsaldo = vCliente.flgmostrarsaldo;

                    }
                    else
                    {
                        retorno.Ok = false;
                        retorno.Mensaje = cClienteOutput.Mensaje.mensaje;
                        return retorno;
                    }
                    cCliente.cdcliente = cClienteOutput.cdcliente;
                    cCliente.nroTarjeta = cClienteOutput.nrotarjeta;
                    cCliente.rscliente = cClienteOutput.razonsocial;
                    cCliente.drcliente = cClienteOutput.direccion;
                    cCliente.tipocli = cClienteOutput.tipocli;

                    cCabecera.cdcliente = cClienteOutput.cdcliente;
                    cCabecera.nrotarjeta = cClienteOutput.nrotarjeta;
                    cCabecera.rscliente = cClienteOutput.razonsocial;
                    cCabecera.drcliente = cClienteOutput.direccion;

                }

                if(String.IsNullOrEmpty(cCliente.tarjAfiliacion) == false)
                {
                    List<TS_BEPTarjeta> prefijos = _ITS_AICliente.LISTA_TARJETA_PREFIJOS();
                    if(prefijos.Count > 0)
                    {
                        int validate = 0;
                        foreach(TS_BEPTarjeta prefijo in prefijos)
                        {
                            if(cCliente.tarjAfiliacion.Length> prefijo.prefijo.Length)
                            {
                                if (cCliente.tarjAfiliacion.Substring(0, prefijo.prefijo.Length).Equals((prefijo.prefijo ?? "").Trim()))
                                {
                                    TS_BEClienteOutput cClienteAfiliacion = _ITS_AICliente.ObtenerClientebyTarjeta(new TS_BEClienteSearch() { NroTarjeta = cCliente.tarjAfiliacion });

                                    if(cClienteAfiliacion.Ok == false)
                                    {
                                        retorno.Ok = false;
                                        retorno.Mensaje = cClienteAfiliacion.Mensaje;
                                        return retorno;
                                    }
                                    if (cClienteAfiliacion.baja)
                                    {
                                        retorno.Ok = false;
                                        retorno.Mensaje = "No se pueden procesar las ventas debido a que la tarjeta de acumulación de puntos esta dada de baja, por favor intente nuevamente realizar la venta sin la tarjeta asignada";
                                        return retorno;

                                    }
                                    if (cClienteAfiliacion.bloqueado)
                                    {
                                        retorno.Ok = false;
                                        retorno.Mensaje = "No se pueden procesar las ventas debido a que la tarjeta de acumulación de puntos esta bloqueada, por favor intente nuevamente realizar la venta sin la tarjeta asignada";
                                        return retorno;
                                    }
                                    validate++;
                                    cCliente.mtodisponible = cClienteAfiliacion.puntos;
                                }
                            }
                        }
                        if(validate == 0)
                        {
                            retorno.Ok = false;
                            retorno.Mensaje = "Se ha indicado un numero de tarjeta con un prefijo que no esta configurado actualmente, revise la configuración de los prefijos asignados";
                            return retorno;
                        }
                        cCabecera.nrobonus = cCliente.tarjAfiliacion.Trim();
                        
                    }
                    else
                    {
                        retorno.Ok = false;
                        retorno.Mensaje = "Se ha indicado una tarjeta bonus en la transacción, pero debido a que no cuenta con prefijos no se puede procesar dicha venta, intente nuevamente la venta sin enviar la tarjeta bonus";
                        return retorno;
                    }
                }
            
                if(cParametro.flg_round_indecopi_1_9 == null ? false: Convert.ToBoolean(cParametro.flg_round_indecopi_1_9))
                {
                    if(    ((cCabecera.tipoventa ?? "").Trim().Equals("T") == false)
                        && ( ( ((cCabecera.cdtipodoc ?? "").Trim().Equals("00001")) || ((cCabecera.cdtipodoc ?? "").Trim().Equals("00003")) ) == true)
                        && ((cPago.Count == 1 ? (cPago[0].cdtppago ?? "").Trim().Equals("00001") : false) == true)
                        )
                    {
                        cCabecera.redondea_indecopi = _ITS_AIUtilities.RoundIndecopi(cCabecera.mtototal);
                        if (cCabecera.mtovueltosol > 0)
                        {
                            cCabecera.mtovueltosol += cCabecera.redondea_indecopi;
                        }
                      
                    }
                    
                }

                cDocumento = new TS_BEDocumento()
                {
                    cCabecera = cCabecera,
                    cDetalles = cDetalle,
                    cPagos = cPago,
                    cTerminal = cTerminal,
                    cParametro = cParametro,
                    cTipoCambio = cTipoCambio,
                    cTab0S00 = cTab00S0,
                    cCliente = cCliente,
                    cEmisor = cEmisor,
                    cLocal = cLocal,
                    cFormato = cFormato,
                    lextension = lExtension,
                    cVentag = cVentag,
                    cVentar = cVentar,
                    cLoading = cLoading,
                    cConfig = cConfiguracion
                };

                _ITS_AIUtilities.genera_globales(cDocumento);

                if (cCabecera.cdtipodoc.Equals("00001") || cCabecera.cdtipodoc.Equals("00003"))
                 {
                     TS_BERespuestaFE Respuesta = _ITS_AIFacturacionE.OBTENER_RESPUESTA(cDocumento);

                     if (Respuesta.OK == false)
                     {
                         retorno.Ok = false;
                         retorno.Mensaje = Respuesta.Respuesta;
                         return retorno;
                     }
                    cDocumento.ltrama = Respuesta.Respuesta;
                 }


                //lExtension, cDetalle, cVentag, cVentar, cCabecera, cPago, cCliente, cParametro, cTab00S0, cTerminal, cLoading, lTrama, lJson

                SaleResponse = _ITS_DOGrabarTransaccion.InsertVenta(cDocumento);
                 
            }
            catch (Exception ex)
            {
                TS_APUtilities.Log_Consumo(ex.ToString() + " _ITS_DOGrabarTransaccion");
            }

            TS_BEMensaje Mensaje = _ITS_Impresion.NOTIFICAR_IMPRESION(cTerminal);

            if (cDocumento != null)
            {
                string nombre = (cDocumento.cCabecera.cdtipodoc.Substring(3, 2).Equals("01") ? "F" :
                cDocumento.cCabecera.cdtipodoc.Substring(3, 2).Equals("03") ? "B" :
                cDocumento.cCabecera.cdtipodoc.Substring(3, 2).Equals("99") ? "ND" :
                cDocumento.cCabecera.cdtipodoc.Substring(3, 2).Equals("98") ? "SE" :
                "0") +
                cDocumento.cCabecera.nrodocumento.Substring(0, 3) + "-" +
               (cDocumento.cCabecera.cdtipodoc.Substring(3, 2).Equals("01") ? "0" :
                cDocumento.cCabecera.cdtipodoc.Substring(3, 2).Equals("03") ? "0" :
                "") +
            cDocumento.cCabecera.nrodocumento.Substring(3) + "|" + "PROCESADO" + "|" + (Mensaje.Ok ? "ENVIADO" : "ERROR AL ENVIAR A PRINT SERVER");

                retorno.Codigo = nombre;
            }
            else
            {
                retorno.Codigo = "";
            }

            if (SaleResponse.Ok)
            {

                retorno.Ok = true;
                retorno.Mensaje = "Grabado satisfactoriamente";
                
            }
            else
            {
                retorno.Ok = false;
                retorno.Mensaje = SaleResponse.mensaje;
            }

            return retorno;
        }
        public TS_BESaldos ValidaSaldos(TS_BEClienteSearch input)
        {

            TS_BESaldos cSaldos = new TS_BESaldos();
            var cCliente = ObternerClienteByCodigo(input);
            cSaldos = cCliente.Saldos;
            return cSaldos;
        }
        public TS_BECorrelativoOutput ObtenerCorrelativo(TS_BECorrelativoInput input)
        {
            TS_BECorrelativoOutput output = new TS_BECorrelativoOutput();
            try
            {
                if (string.IsNullOrEmpty(input.seriehd))
                {
                    output.Ok = false;
                    output.Mensaje = "El número de serie debe tener algún valor";
                    return output;
                }

                output = _ITS_DOCorrelativo.ObtenerCorrelativo(input);
                if (string.IsNullOrEmpty(output.nropos))
                {
                    output.Ok = false;
                    output.Mensaje = "El punto de venta no está registrado";
                    return output;
                }
                else
                {
                    output.Ok = true;
                    output.Mensaje = "Datos encontrados";
                    return output;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }
        public TS_BEMensaje ANULAR_DOCUMENTO(TS_BEDAnulaInput input)
        {
            /*falta anular web service acepta*/
   
            /*falta * venta pec*/
            if (String.IsNullOrEmpty(input.nrodocumento))
            {
                return new TS_BEMensaje("El numero de documento es obligatorio", false);
            }
            if (String.IsNullOrEmpty(input.cdtipodoc))
            {
                return new TS_BEMensaje("El tipo de documento es obligatorio", false);
            }
            if (input.nroseriemaq == null)
            {
                return new TS_BEMensaje("El numero de serie de maquina del documento es obligatorio", false);
            }
            else
            {
                string nropos = input.nropos;
                input = _ITS_DOReimpresion.OBTENER_VENTAG_ESPECIFICO(input);
                
                if(!input.exists)
                {
                    return new TS_BEMensaje("El documento especificado no existe", false);
                }

                TS_BEDocumento Documento = _ITS_Impresion.OBTENER_DOCUMENTO(input);
                Documento.cParametro = _ITS_DOParametro.ObtenerParametros();
                Documento.cTab0S00 = _ITS_DOParametro.ObtenerParameters();

                if (!(nropos ?? "").Trim().Equals( (input.nropos ?? "").Trim()))
                {
                    return new TS_BEMensaje("El documento solo puede ser anulado desde su punto de venta", false);
                }
                if (input.anulado)
                {
                    return new TS_BEMensaje("El documento ya esta anulado", false);
                }
                if (input.cerrado)
                {
                    return new TS_BEMensaje("El parte diario del documento ya esta cerrado", false);
                }

                foreach (TS_BEArticulo detalle in Documento.cDetalles)
                {
                    if (detalle.is_easytaxi)
                    {
                        return new TS_BEMensaje("Articulos registrados en Easy Taxi no se pueden anular", false);
                    }
                }
                if (input.fact_electronica)
                {
                   return _ITS_DOGrabarTransaccion.PROCESAR_ANULAR_DOCUMENTO(Documento);
                }
                else
                {
                    return _ITS_DOGrabarTransaccion.PROCESAR_ANULAR_DOCUMENTO(Documento);
                }
            }
        }
        public List<TS_BECara> OBTENER_CARAS(string seriehd)
        {
            TS_BETerminal cTerminal = _ITS_DOTerminal.OBTENER_TERMINAL_POR_SERIEHD(new TS_BETerminal() { seriehd = seriehd });
            if (String.IsNullOrEmpty(cTerminal.nropos))
            {
                return new List<TS_BECara>();
            }
            else
            {
                return _ITS_DOCara.LISTAR_CARA_POR_POSICION(new TS_BECara() { nropos = cTerminal.nropos });
            }
        }
    
        public TS_BEMensaje REGISTRAR_AFILIACION(TS_BEClienteInput cCliente,List<TS_BEArticulo> Articulos, TS_BETipoTarjetaRegistro Tipo)
        {
            if (cCliente == null)
            {
                return new TS_BEMensaje("El cliente es obligatorio", false);
            }
            if (Articulos == null)
            {
                return new TS_BEMensaje("Los articulos son obligatorios", false);
            }

            if (Tipo == TS_BETipoTarjetaRegistro.NUEVO_REGISTRO || Tipo == TS_BETipoTarjetaRegistro.ACTUALIZACION_REGISTRO)
            {
                return _ITS_DOGrabarTransaccion.REGISTRAR_AFILIACION(cCliente, Articulos, Tipo);
            }
            if(Tipo == TS_BETipoTarjetaRegistro.TRASPASO_REGISTRO)
            {
                return _ITS_DOGrabarTransaccion.REGISTRAR_TRASPASO_AFILIACION(cCliente, Articulos, Tipo);
            }
            else
            {
                return new TS_BEMensaje("No se reconocio el tipo de registro", false);
            }
        }
    }
}
