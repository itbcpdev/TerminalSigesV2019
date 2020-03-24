using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Infraestructure.DataAcces
{
    public class TS_DAGrabarTransaccion : ITS_DOGrabarTransaccion
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        private readonly ITS_DOIgv _ITS_DOIgv;
        private readonly ITS_DOServer _ITS_DOServer;
        private readonly ITS_DOCara _ITS_DOCara;
        private readonly ITS_DOParametro _ITS_DOParametro;
        private readonly ITS_DOTarjeta _ITS_DOTarjeta;
        private readonly ITS_DOTipoCambio _ITS_DOTipoCambio;
        private readonly ITS_DOTipoPago _ITS_DOTipoPago;
        private readonly ITS_DOVendedor _ITS_DOVendedor;
        private readonly ITS_DOTerminal _ITS_DOTerminal;
        private readonly ITS_DOCliente _ITS_DOCliente;
        private readonly ITS_DOArticulo _ITS_DOArticulo;
        private readonly ITS_DOBackOffice _ITS_DOBackOffice;
        private readonly ITS_DOOpTransaction _ITS_DOOpTransaction;
        private readonly ITS_DOCierre _ITS_DOCierre;
        private readonly ITS_DODetalleVenta _ITS_DODetalleVenta;
        private readonly ITS_DOCabeceraVenta _ITS_DOCabeceraVenta;
        private readonly ITS_DOPagoVenta _ITS_DOPagoVenta;
        private readonly ITS_DOStock _ITS_DOStock;
        private readonly ITS_DOHvale _ITS_DOHvale;
        private readonly ITS_DOCredclienteVenta _ITS_DOCredclienteVenta;
        private readonly ITS_DOColaImpresion _ITS_DOColaImpresion;
        private readonly ITS_AIUtilities _ITS_AIUtilities;
        private readonly ITS_AICliente _ITS_AICliente;
        private readonly ITS_DOAfiliacionTarjeta _ITS_DOAfiliacionTarjeta;

        public TS_DAGrabarTransaccion(ITS_DOIgv ITS_DOIgv,
            ITS_DOServer ITS_DOServer,
            ITS_DOCara ITS_DOCara,
            ITS_DOParametro ITS_DOParametro,
            ITS_DOTarjeta ITS_DOTarjeta,
            ITS_DOTipoCambio ITS_DOTipoCambio,
            ITS_DOTipoPago ITS_DOTipoPago,
            ITS_DOVendedor ITS_DOVendedor,
            ITS_DOTerminal ITS_DOTerminal,
            ITS_DOCliente ITS_DOCliente,
            ITS_DOCierre ITS_Cierre,
            ITS_DOBackOffice ITS_DOBackOffice, 
            ITS_DOOpTransaction ITS_DOOpTransaction, 
            ITS_DOArticulo ITS_DOArticulo, 
            ITS_DODetalleVenta ITS_DODetalleVenta,
            ITS_DOCabeceraVenta ITS_DOCabeceraVenta,
            ITS_DOPagoVenta ITS_DOPagoVenta,
            ITS_DOStock ITS_DOStock,
            ITS_DOHvale ITS_DOHvale,
            ITS_DOCredclienteVenta ITS_DOCredclienteVenta,
            ITS_DOColaImpresion ITS_DOColaImpresion,
            ITS_AIUtilities ITS_AIUtilities,
            ITS_AICliente ITS_AICliente,
            ITS_DOAfiliacionTarjeta ITS_DOAfiliacionTarjeta)
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
            _ITS_DOCliente = ITS_DOCliente;
            _ITS_DOBackOffice = ITS_DOBackOffice;
            _ITS_DOOpTransaction = ITS_DOOpTransaction;
            _ITS_DOArticulo = ITS_DOArticulo;
            _ITS_DOCierre = ITS_Cierre;
            _ITS_DODetalleVenta = ITS_DODetalleVenta;
            _ITS_DOCabeceraVenta = ITS_DOCabeceraVenta;
            _ITS_DOPagoVenta = ITS_DOPagoVenta;
            _ITS_DOStock = ITS_DOStock;
            _ITS_DOHvale = ITS_DOHvale;
            _ITS_DOCredclienteVenta = ITS_DOCredclienteVenta;
            _ITS_DOColaImpresion = ITS_DOColaImpresion;
            _ITS_AIUtilities = ITS_AIUtilities;
            _ITS_AICliente = ITS_AICliente;
            _ITS_DOAfiliacionTarjeta = ITS_DOAfiliacionTarjeta;
        }

        //string lExtension, List<TS_BEDetalle> cDetalle, TS_BEVentag cVentag, TS_BEVentar cVentar, TS_BECabecera cCabecera, List<TS_BEPago> cPago,TS_BEClienteInput cCliente, TS_BEParametro cParametro, TS_BEParameters cTab00S0, TS_BETerminal cTerminal, TS_BELoadInput cLoading, string lTrama, TS
        public TS_BEMensaje InsertVenta(TS_BEDocumento cDocumento)
        {
            TS_BEMensaje Respuesta = new TS_BEMensaje();
            SqlConnection connection = null;
            SqlTransaction oSqlTransaction = null;
            List<TS_BEControlDBF> gasboys = new List<TS_BEControlDBF>();
            string str2 = string.Empty;
            try
            {
                connection = new SqlConnection(stringBackOffice);
                connection.Open();
                oSqlTransaction = connection.BeginTransaction();

                if (cDocumento.cCliente != null)
                {
                    
                    Respuesta = _ITS_DOCliente.InsertTransCliente(cDocumento.cCliente, oSqlTransaction);
                    if (Respuesta.Ok)
                    {
                        if(String.IsNullOrEmpty((cDocumento.cCabecera.nroplaca ?? "").Trim()) == false)
                        {
                            Respuesta = _ITS_DOCliente.InsertTransClientePlaca(cDocumento.cCliente, cDocumento.cCabecera, oSqlTransaction);
                        }  
                    }
                    if (Respuesta.Ok)
                    {
                        if ((String.IsNullOrEmpty(cDocumento.cCabecera.nrobonus)) == false)
                        {
                            if (cDocumento.cCliente.iscanje)
                            {
                                int CantAfiliacion = 0;
                                int CantAfiliacionProc = 0;
                                int CantAfiliacionUpdate = 0;

                                cDocumento.cDetalles.ForEach((TS_BEArticulo oDetalle) =>
                                {
                                    CantAfiliacion++;
                                    if (_ITS_DOAfiliacionTarjeta.INSERT_AFILIACION_PUNTOS_CANJE(cDocumento.cCabecera, oDetalle, cDocumento.cCliente, oSqlTransaction))
                                    {
                                        CantAfiliacionProc++;
                                    }
                                    if(_ITS_DOBackOffice.SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA(cDocumento.cCabecera.nrobonus, oDetalle.valor_puntos * oDetalle.cantidad, oDetalle.valor_acumulado * oDetalle.cantidad))
                                    {
                                        CantAfiliacionUpdate++;
                                    }
                                    cDocumento.cFormato.puntos_canjeados += oDetalle.valor_puntos * oDetalle.cantidad;
                                    cDocumento.cFormato.valor_canjeados += oDetalle.valor_acumulado * oDetalle.cantidad;
                                });
                                Respuesta.Ok = (CantAfiliacion == CantAfiliacionProc && CantAfiliacion == CantAfiliacionUpdate);
                                Respuesta.mensaje = Respuesta.Ok ? "" : "Error al Actualizar los puntos del cliente";
                            }
                            else
                            {
                                int onError = 0;
                                foreach (TS_BEArticulo detalle in cDocumento.cDetalles)
                                {
                                    Respuesta = _ITS_DOAfiliacionTarjeta.OBTENER_PUNTOS_POR_PRODUCTO(cDocumento.cCabecera, cDocumento.cCliente, detalle, oSqlTransaction);
                                    if (Respuesta.Ok == false)
                                    {
                                        onError++;
                                        break;
                                    }
                                }
                                Respuesta.Ok = (onError == 0);
                            }
                        }

                        if (Respuesta.Ok)
                        {
                            Respuesta.Ok = _ITS_DODetalleVenta.InsertTransVentaG(cDocumento.cVentag, oSqlTransaction);
                            Respuesta.mensaje = Respuesta.Ok ? "" : "Error al insertar VENTAG";
                            if (Respuesta.Ok)
                            {
                                Respuesta.Ok = _ITS_DODetalleVenta.InsertTransVentaR(cDocumento.cVentar, oSqlTransaction);
                                Respuesta.mensaje = Respuesta.Ok ? "" : "Error al insertar VENTAR";
                                if (Respuesta.Ok)
                                {
                                    Respuesta.Ok = _ITS_DOCabeceraVenta.InsertTransVentaCabecera(cDocumento.cCabecera, oSqlTransaction);
                                    Respuesta.mensaje = Respuesta.Ok ? "" : "Error al insertar VENTA";
                                    if (Respuesta.Ok)
                                    {
                                        Respuesta.Ok = _ITS_DOCabeceraVenta.InsertTransVentaCabeceraMes(cDocumento.lextension, cDocumento.cCabecera, oSqlTransaction);
                                        Respuesta.mensaje = Respuesta.Ok ? "" : "Error al insertar VENTAMES";

                                        if (Respuesta.Ok)
                                        {
                                            int CantPago = 0;
                                            int CantPagoMes = 0;
                                            cDocumento.cPagos.ForEach(delegate (TS_BEPago oPago)
                                            {
                                                if (_ITS_DOPagoVenta.InsertTransVentaPago(oPago, oSqlTransaction))
                                                {
                                                    CantPago++;
                                                }

                                                if (_ITS_DOPagoVenta.InsertTransVentaPagoMes(cDocumento.lextension, oPago, oSqlTransaction))
                                                {
                                                    CantPagoMes++;
                                                }
                                            });
                                            Respuesta.Ok = (CantPago + CantPagoMes == (cDocumento.cPagos.Count * 2));
                                            Respuesta.mensaje = Respuesta.Ok ? "" : "Error al insertar PAGOS";

                                            if (Respuesta.Ok)
                                            {
                                                int CantDetalle = 0;
                                                int CantDetalleMes = 0;
                                                cDocumento.cDetalles.ForEach(delegate (TS_BEArticulo oDetalle)
                                                {
                                                    if (_ITS_DODetalleVenta.InsertTransVentaDetalle(oDetalle, cDocumento.cCabecera, oSqlTransaction))
                                                    {
                                                        CantDetalle++;
                                                    }

                                                    if (_ITS_DODetalleVenta.InsertTransVentaDetalleMes(cDocumento.lextension, oDetalle, cDocumento.cCabecera, oSqlTransaction))
                                                    {
                                                        CantDetalleMes++;
                                                    }
                                                });
                                                Respuesta.Ok = (CantDetalle + CantDetalleMes == (cDocumento.cDetalles.Count * 2));
                                                Respuesta.mensaje = Respuesta.Ok ? "" : "Error al insertar DETALLES";
                                                if (Respuesta.Ok)
                                                {
                                                    int CantStock = 0;
                                                    int CantStockActu = 0;

                                                    int CantPtos = 0;
                                                    int CantPtosGanados = 0;
                                                    int CantPtosUpdate = 0;
                                                    if (cDocumento.cCabecera.cdtipodoc != "99998")
                                                    {
                                                        cDocumento.cDetalles.ForEach(delegate (TS_BEArticulo oDetalle)
                                                        {
                                                            if (oDetalle.moverstock == true && oDetalle.tpformula != "A")
                                                            {
                                                                CantStock++;
                                                                if (_ITS_DOStock.UpdateStock(cDocumento.cParametro, oDetalle.cdarticulo, oDetalle.cantidad, cDocumento.cCabecera, cDocumento.cLoading, oSqlTransaction))
                                                                {
                                                                    CantStockActu++;
                                                                }
                                                            }

                                                            if (oDetalle.ptosganados > 0 || oDetalle.valoracumula > 0 && cDocumento.cCliente.iscanje == false)
                                                            {
                                                                CantPtos++;
                                                                if (_ITS_DOAfiliacionTarjeta.INSERT_AFILIACION_PUNTOS(cDocumento.cCabecera, oDetalle, cDocumento.cCliente, oSqlTransaction))
                                                                {
                                                                    CantPtosGanados++;
                                                                }
                                                                if (_ITS_DOAfiliacionTarjeta.UPDATE_AFILIACION_PUNTOS(cDocumento.cCabecera, oDetalle, oSqlTransaction))
                                                                {
                                                                    CantPtosUpdate++;
                                                                }
                                                            }
                                                        });
                                                    }

                                                    Respuesta.Ok = (CantStock == CantStockActu) && (CantPtos == CantPtosGanados) && (CantPtos == CantPtosUpdate);
                                                    Respuesta.mensaje = Respuesta.Ok ? "" : "ERROR AL ACTUALIZAR STOCK";
                                                    if (Respuesta.Ok)
                                                    {
                                                        if (Respuesta.Ok)
                                                        {

                                                            string lTipoDoc = cDocumento.cCabecera.cdtipodoc;
                                                            string NroDocumento = cDocumento.cCabecera.nrodocumento;

                                                            switch (lTipoDoc)
                                                            {
                                                                case "00001":
                                                                    Respuesta.Ok = _ITS_DOTerminal.UpdateCorrelativo("factura", NroDocumento, cDocumento.cTerminal.seriehd, oSqlTransaction);
                                                                    break;
                                                                case "00003":
                                                                    Respuesta.Ok = _ITS_DOTerminal.UpdateCorrelativo("boleta", NroDocumento, cDocumento.cTerminal.seriehd, oSqlTransaction);
                                                                    break;
                                                                case "99999":
                                                                    Respuesta.Ok = _ITS_DOTerminal.UpdateCorrelativo("nventa", NroDocumento, cDocumento.cTerminal.seriehd, oSqlTransaction);
                                                                    break;
                                                                case "99998":
                                                                    Respuesta.Ok = _ITS_DOTerminal.UpdateCorrelativo("promocion", NroDocumento, cDocumento.cTerminal.seriehd, oSqlTransaction);
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            Respuesta.mensaje = Respuesta.Ok ? "" : "ERROR AL ACTUALIZAR EL CORRELATIVO";
                                                            if (Respuesta.Ok)
                                                            {
                                                                int CantTran = 0;
                                                                int CantTranActu = 0;
                                                                cDocumento.cDetalles.ForEach(delegate (TS_BEArticulo oDetalle)
                                                                {
                                                                    string gasboy = (oDetalle.nrogasboy ?? "").Trim();

                                                                    if (!string.IsNullOrEmpty(gasboy))
                                                                    {
                                                                        /** COMIENZA REVISION OP_TRAN **/
                                                                        if
                                                                        ( 
                                                                            ((cDocumento.cParametro.activasawa == null ? false          : Convert.ToBoolean(cDocumento.cParametro.activasawa) ) == true )
                                                                         && ((cDocumento.cParametro.conexiondispensador == null ? false : Convert.ToBoolean(cDocumento.cParametro.conexiondispensador) ) == true)
                                                                         && ((cDocumento.cTerminal.conexion_dispensador == null ? true  : Convert.ToBoolean(cDocumento.cTerminal.conexion_dispensador) ) == true)
                                                                        )
                                                                        {
                                                                            CantTran++;
                                                                            string tipoDocumento = cDocumento.cCabecera.cdtipodoc;
                                                                            string nroDocumento = cDocumento.cCabecera.nrodocumento;
                                                                            DateTime? fecProceso = cDocumento.cCabecera.fecproceso;
                                                                            if (Respuesta.Ok = _ITS_DOOpTransaction.UpdateTransOpTransaction(gasboy, tipoDocumento, nroDocumento, fecProceso, oSqlTransaction))
                                                                            {
                                                                                CantTranActu++;
                                                                            }
                                                                        }
                                                                        /** TERMINA REVISION OP_TRAN **/

                                                                        /** COMIENZA REVISION DBF    **/
                                                                        if
                                                                        (
                                                                            ((cDocumento.cParametro.activasawa == null ? false : Convert.ToBoolean(cDocumento.cParametro.activasawa)) == false)
                                                                        &&  ((cDocumento.cParametro.conexiondispensador == null ? false : Convert.ToBoolean(cDocumento.cParametro.conexiondispensador)) == true)
                                                                        &&  ((cDocumento.cTerminal.conexion_dispensador == null ? true : Convert.ToBoolean(cDocumento.cTerminal.conexion_dispensador)) == true)
                                                                        )
                                                                        {
                                                                            CantTran++;
                                                                            string tipoDocumento = cDocumento.cCabecera.cdtipodoc;
                                                                            string nroDocumento = cDocumento.cCabecera.nrodocumento;
                                                                            DateTime? fecProceso = cDocumento.cCabecera.fecproceso;
                                                                            string cara = (oDetalle.cara ?? "").Trim();

                                                                            if (Respuesta.Ok = _ITS_AIUtilities.ACTUALIZAR_DBF_VENTA(cDocumento.cTab0S00.path_gasboy,oDetalle.cara, cDocumento.cCabecera.cdtipodoc, cDocumento.cCabecera.nrodocumento, gasboy))
                                                                            {
                                                                                gasboys.Add(new TS_BEControlDBF() { gasboy = gasboy,cara = cara });
                                                                                CantTranActu++;
                                                                            }
                                                                        }
                                                                        /** TERMINA REVISION DBF    **/

                                                                    }
                                                                });
                                                                Respuesta.Ok = (CantTran == CantTranActu);
                                                                Respuesta.mensaje = Respuesta.Ok ? "" : "ERROR AL ACTUALIZAR EL LA TRANSACCION";

                                                                if (Respuesta.Ok)
                                                                {
                                                                    string formato = "";
                                                                    string impresora = "";
                                                                    switch (cDocumento.cCabecera.cdtipodoc)
                                                                    {
                                                                        case "00001":
                                                                            formato = cDocumento.cTerminal.facturafmt;
                                                                            impresora = cDocumento.cTerminal.facturaimpre;
                                                                            break;
                                                                        case "00003":
                                                                            formato = cDocumento.cTerminal.boletafmt;
                                                                            impresora = cDocumento.cTerminal.boletaimpre;
                                                                            break;
                                                                        case "00007":
                                                                            formato = cDocumento.cTerminal.ncreditofmt;
                                                                            impresora = cDocumento.cTerminal.ncreditoimpre;
                                                                            break;
                                                                        case "00008":
                                                                            formato = cDocumento.cTerminal.ndebitofmt;
                                                                            impresora = cDocumento.cTerminal.ndebitoimpre;
                                                                            break;
                                                                        case "80001":
                                                                            formato = cDocumento.cTerminal.cierrexfmt;
                                                                            impresora = cDocumento.cTerminal.ticketimpre;
                                                                            break;
                                                                        case "80002":
                                                                            formato = cDocumento.cTerminal.cierrezfmt;
                                                                            impresora = cDocumento.cTerminal.ticketimpre;
                                                                            break;
                                                                        case "80003":
                                                                            formato = cDocumento.cTerminal.depositofmt;
                                                                            impresora = cDocumento.cTerminal.ticketimpre;
                                                                            break;
                                                                        case "99999":
                                                                            formato = cDocumento.cTerminal.nventafmt;
                                                                            impresora = cDocumento.cTerminal.nventaimpre;
                                                                            break;
                                                                        case "99998":
                                                                            formato = cDocumento.cTerminal.serafinfmt;
                                                                            impresora = cDocumento.cTerminal.ticketimpre.Trim();
                                                                            break;
                                                                        default:
                                                                            formato = "";
                                                                            break;
                                                                    }
                                                                    string lJson = JsonConvert.SerializeObject(cDocumento);

                                                                    Respuesta.Ok = _ITS_DOColaImpresion.InsertColaImpresion(cDocumento.cCabecera,cDocumento.cConfig, impresora, cDocumento.ltrama, lJson, oSqlTransaction, formato);
                                                                    Respuesta.mensaje = Respuesta.Ok ? "" : "ERROR AL INSERTAR EN COLA DE IMPRESION";
                                                                    if (Respuesta.Ok)
                                                                    {
                                                                        if (cDocumento.cCabecera.cdtipodoc == "99999")
                                                                        {
                                                                            Respuesta.Ok = _ITS_DOHvale.InsertTransVentaHvale(cDocumento.cCabecera, oSqlTransaction);
                                                                            Respuesta.mensaje = Respuesta.Ok ? "" : "ERROR AL INSERTAR HVALE";
                                                                            if (Respuesta.Ok)
                                                                            {
                                                                                Respuesta.Ok = _ITS_DOCredclienteVenta.InsertTransVentaCredcliente(cDocumento.cCabecera, oSqlTransaction);
                                                                                Respuesta.mensaje = Respuesta.Ok ? "" : "ERROR AL INSERTAR CREDCLIENTE";
                                                                            }
                                                                            if (Respuesta.Ok)
                                                                            {
                                                                                Decimal cantidad = 0;
                                                                                foreach (TS_BEArticulo Producto in cDocumento.cDetalles)
                                                                                {
                                                                                    cantidad = cantidad + Producto.cantidad;
                                                                                }
                                                                                if (cantidad <= 0) { Respuesta.Ok = false; }
                                                                                if (cDocumento.cCabecera.mtototal <= 0) { Respuesta.Ok = false; }
                                                                                if (Respuesta.Ok)
                                                                                {
                                                                                    if (cDocumento.cCliente.tipocli.Equals("L") || cDocumento.cCliente.tipocli.Equals("C") || cDocumento.cCliente.tipocli.Equals("F"))
                                                                                    {
                                                                                        if (cDocumento.cCliente.tipocli.Equals("L"))
                                                                                        {
                                                                                            Respuesta.Ok = _ITS_DOCliente.UPDATE_SALDO_CLIENTE_LOCAL(cDocumento.cCabecera, cDocumento.cCliente, oSqlTransaction, cantidad);
                                                                                            Respuesta.mensaje = Respuesta.Ok ? "" : "ERROR AL ACTUALIZAR EL SALDO DEL CLIENTE LOCAL";
                                                                                        }
                                                                                        if (cDocumento.cCliente.tipocli.Equals("C"))
                                                                                        {
                                                                                            Respuesta = _ITS_AIUtilities.ACTUALIZAR_SALDO_CLIENTE_CREDITO_COORPORATIVO_WS(new TS_BESaldoWS(cDocumento.cCliente, cDocumento.cParametro, cDocumento.cTerminal, cDocumento.cCabecera));
                                                                                        }
                                                                                        if (cDocumento.cCliente.tipocli.Equals("F"))
                                                                                        {

                                                                                        }
                                                                                     
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        Respuesta.Ok = false;
                                                                                        Respuesta.mensaje = Respuesta.Ok ? "" : "TIPO DE CLIENTE DE CREDITO NO RECONOCIDO";
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (Respuesta.Ok)
                {
                    oSqlTransaction.Commit();
                }
                else
                {
                    oSqlTransaction.Rollback();
                    if (   ((cDocumento.cParametro.activasawa == null ? false          : Convert.ToBoolean(cDocumento.cParametro.activasawa)) == false)
                        && ((cDocumento.cParametro.conexiondispensador == null ? false : Convert.ToBoolean(cDocumento.cParametro.conexiondispensador)) == true)
                        && ((cDocumento.cTerminal.conexion_dispensador == null ? true  : Convert.ToBoolean(cDocumento.cTerminal.conexion_dispensador)) == true) 
                        && ((gasboys.Count>0)) 
                        )
                    {
                        foreach(TS_BEControlDBF gasboy in gasboys)
                        {
                            _ITS_AIUtilities.RETORNAR_DBF_VENTA(cDocumento.cTab0S00.path_gasboy, gasboy.cara, cDocumento.cCabecera.cdtipodoc, cDocumento.cCabecera.nrodocumento);
                        }  
                    }
                }
            }
            catch (Exception exception)
            {
                oSqlTransaction.Rollback();
                if (((cDocumento.cParametro.activasawa == null ? false : Convert.ToBoolean(cDocumento.cParametro.activasawa)) == false)
                        && ((cDocumento.cParametro.conexiondispensador == null ? false : Convert.ToBoolean(cDocumento.cParametro.conexiondispensador)) == true)
                        && ((cDocumento.cTerminal.conexion_dispensador == null ? true : Convert.ToBoolean(cDocumento.cTerminal.conexion_dispensador)) == true)
                        && ((gasboys.Count > 0))
                        )
                {
                    foreach (TS_BEControlDBF gasboy in gasboys)
                    {
                        _ITS_AIUtilities.RETORNAR_DBF_VENTA(cDocumento.cTab0S00.path_gasboy, gasboy.cara, cDocumento.cCabecera.cdtipodoc, cDocumento.cCabecera.nrodocumento);
                    }
                }
                throw exception;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return Respuesta;
        }
        public TS_BEMensaje ANULAR_DOCUMENTO(SqlTransaction oSqlTransaction, TS_BEDocumento input)
        {
            TS_BEMensaje Mensaje = new TS_BEMensaje("", false);
            SqlCommand cmd = new SqlCommand("SP_ITBCP_ANULAR_DOCUMENTO")
            {
                CommandType = CommandType.StoredProcedure,
                Connection = oSqlTransaction.Connection,
                Transaction = oSqlTransaction
            };
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CDTIPODOC", SqlDbType.VarChar, 5).Value = input.cCabecera.cdtipodoc.Trim();
            cmd.Parameters.Add("@NRODOCUMENTO", SqlDbType.VarChar, 10).Value = input.cCabecera.nrodocumento.Trim();
            cmd.Parameters.Add("@NROSERIEMAQ", SqlDbType.VarChar, 20).Value = input.cCabecera.nroseriemaq.Trim();
            cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 20).Value = input.cCabecera.fecdocumento;
            cmd.Parameters.Add("@CDUSUARIO", SqlDbType.VarChar, 20).Value = input.cCabecera.cdusuario.Trim();

            using (SqlDataReader drd = cmd.ExecuteReader())
            {
                while (drd.Read())
                {
                    Mensaje.mensaje = (drd.HasColumn("MENSAJE") ? drd["MENSAJE"] == DBNull.Value ? "" : drd["MENSAJE"].ToString() : "").Trim();
                    Mensaje.Ok = drd.HasColumn("OK") ? drd["OK"] == DBNull.Value ? false : !Convert.ToBoolean(drd["OK"]) : false;
                }
                cmd.Dispose();
            }
            return Mensaje;
        }

        public TS_BEMensaje PROCESAR_ANULAR_DOCUMENTO(TS_BEDocumento input)
        {
            SqlConnection connection = null;
            SqlTransaction oSqlTransaction = null;
            TS_BEClienteCreditoOutput cliente = null;
            try
            {
                if ((input.cCabecera.cdtipodoc ?? "").Trim().Equals("99999"))
                {
                    cliente = _ITS_AICliente.OBTENER_CLIENTE_CREDITO(_ITS_DOParametro.ObtenerParametros(), input.cCabecera.nrotarjeta);
                }
                    
                connection = new SqlConnection(stringBackOffice);
                connection.Open();
                oSqlTransaction = connection.BeginTransaction();
                TS_BEMensaje respuesta = ANULAR_DOCUMENTO(oSqlTransaction, input);
                if (respuesta.Ok)
                {
                    if ((input.cParametro.conexiondispensador ?? false) && (input.cParametro.activasawa ?? false) == false)
                    {
                        input.cDetalles.ForEach((Detalle) => {
                            if (String.IsNullOrEmpty((Detalle.cara ?? "").Trim()) == false)
                            {
                                _ITS_AIUtilities.RETORNAR_DBF_VENTA(rutaTran: input.cTab0S00.path_gasboy, cara: Detalle.cara, cdtipodoc: input.cCabecera.cdtipodoc, nrodocumento: input.cCabecera.nrodocumento);
                            }
                        });

                    }

                    if ( (input.cCabecera.cdtipodoc ?? "").Trim().Equals("99999"))
                    {
                        if (cliente.Mensaje.Ok)
                        {
                            if (cliente.tipocli.Equals("C"))
                            {
                                respuesta = _ITS_AIUtilities.ANULAR_DOCUMENTO_CREDITO_COORPORATIVO(input);

                                if (respuesta.Ok)
                                {
                                    oSqlTransaction.Commit();
                                }
                                else
                                {
                                    oSqlTransaction.Rollback();
                                }
                                return respuesta;
                            }
                            else
                            {
                                oSqlTransaction.Commit();
                                return respuesta;
                            }
                        }
                        else
                        {
                            return cliente.Mensaje;
                        }
                    }
                    else
                    {
                        oSqlTransaction.Commit();
                        return respuesta;
                    }
                }
                else
                {
                    oSqlTransaction.Rollback();
                    return respuesta;
                }
            }
            catch(Exception ex)
            {
                if (oSqlTransaction != null) { oSqlTransaction.Rollback(); }
                return new TS_BEMensaje("Hubo una excepcion al procesar la anulación del documento", false);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public TS_BEMensaje REGISTRAR_AFILIACION(TS_BEClienteInput cCliente, List<TS_BEArticulo> Articulos, TS_BETipoTarjetaRegistro Tipo)
        {
            TS_BEMensaje Respuesta = new TS_BEMensaje("", false);
            SqlConnection connection = null;
            SqlTransaction oSqlTransaction = null;
            try
            {
                connection = new SqlConnection(stringBackOffice);
                connection.Open();
                oSqlTransaction = connection.BeginTransaction();

                Respuesta = _ITS_DOCliente.InsertTransCliente(cCliente, oSqlTransaction);

                if (Respuesta.Ok)
                {
                    Respuesta.Ok = _ITS_DOAfiliacionTarjeta.INSERT_AFILIACION_TARJETA(cCliente,oSqlTransaction);
                    Respuesta.mensaje = "ERROR INSERTAR AFILIACION TARJETA";
                    if (Respuesta.Ok)
                    {
                        int Enviados = 0;
                        int Intentos = 0;
                        foreach(TS_BEArticulo Item in Articulos)
                        {
                            Enviados++;
                            if (_ITS_DOAfiliacionTarjeta.INSERT_AFILIACION_TARJETA_CONCEPTOS(cCliente, Item, oSqlTransaction))
                            {
                                Intentos++;
                            }
                        }
                        Respuesta.Ok = Enviados == Intentos;
                        Respuesta.mensaje = "ERROR INSERTAR TARJETA CONCEPTOS";
                    }
                }
                if (Respuesta.Ok)
                {
                    Respuesta.mensaje = "";
                    oSqlTransaction.Commit();
                }
                else if(Respuesta.Ok == false)
                {
                    oSqlTransaction.Rollback();
                }
            }           
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return Respuesta;
        }

        public TS_BEMensaje REGISTRAR_TRASPASO_AFILIACION(TS_BEClienteInput cCliente, List<TS_BEArticulo> Articulos, TS_BETipoTarjetaRegistro Tipo)
        {
            throw new NotImplementedException();
        }
    }
}
