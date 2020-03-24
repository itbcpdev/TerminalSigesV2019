using ITBCP.ServiceSIGES.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cierrres;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System.IO;
using System.Data.OleDb;
using ITBCP.ServiceSIGES.Domain.Entities.Cierrres.XObjetos;


namespace ITBCP.ServiceSIGES.Infraestructure.DataAcces
{
    public class TS_DAXCierre : ITS_DOXCierre
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;


        public TS_BECCierre OBTENER_CABECERA_CIERRE_X(TS_BEParametro Parametros, TS_BETerminal Terminal)
        {
            TS_BECCierre Cabecera = new TS_BECCierre(); ;

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CIERRE_X", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDLOCAL", SqlDbType.VarChar, 5).Value = Parametros.cdlocal;
                    cmd.Parameters.Add("@CDALMACEN", SqlDbType.VarChar, 5).Value = Terminal.cdalmacen;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 20).Value = Terminal.fecproceso;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 10).Value = Terminal.nropos;
                    cmd.Parameters.Add("@TURNO", SqlDbType.VarChar, 10).Value = Terminal.turno;
                    cmd.Parameters.Add("@NROSERIMAQ", SqlDbType.VarChar, 20).Value = Terminal.nroseriemaq;
                    cmd.Parameters.Add("@CDUSUARIO", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@NROZETA", SqlDbType.VarChar, 10).Value = Terminal.nrozeta;
                    cmd.Parameters.Add("@MTOZETA", SqlDbType.VarChar, 20).Value = Terminal.mtozeta;
                    cmd.Parameters.Add("@CDVENDEDOR", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 2).Value = "CA";
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            Cabecera.nroseriemaq = (drd.HasColumn("NROSERIQMAQ") ? drd["NROSERIQMAQ"] == DBNull.Value ? "" : drd["NROSERIQMAQ"].ToString() : "").Trim();
                            Cabecera.nropos = (drd.HasColumn("NROPOS") ? drd["NROPOS"] == DBNull.Value ? "" : drd["NROPOS"].ToString() : "").Trim();
                            Cabecera.fecha = (drd.HasColumn("FECHA") ? drd["FECHA"] == DBNull.Value ? "" : drd["FECHA"].ToString() : "").Trim();
                            Cabecera.hora = (drd.HasColumn("HORA") ? drd["HORA"] == DBNull.Value ? "" : drd["HORA"].ToString() : "").Trim();
                            Cabecera.turno = (drd.HasColumn("TURNO") ? drd["TURNO"] == DBNull.Value ? "" : drd["TURNO"].ToString() : "").Trim();
                            Cabecera.usuario = (drd.HasColumn("USUARIO") ? drd["USUARIO"] == DBNull.Value ? "" : drd["USUARIO"].ToString() : "").Trim();
                            Cabecera.cantidad_transacciones = (drd.HasColumn("TRANSACCIONES") ? drd["TRANSACCIONES"] == DBNull.Value ? "" : drd["TRANSACCIONES"].ToString() : "").Trim();
                            Cabecera.subtotal = (drd.HasColumn("SUBTOTAL") ? drd["SUBTOTAL"] == DBNull.Value ? "" : drd["SUBTOTAL"].ToString() : "").Trim();
                            Cabecera.igv = (drd.HasColumn("IGV") ? drd["IGV"] == DBNull.Value ? "" : drd["IGV"].ToString() : "").Trim();
                            Cabecera.total = (drd.HasColumn("TOTAL") ? drd["TOTAL"] == DBNull.Value ? "" : drd["TOTAL"].ToString() : "").Trim();
                            Cabecera.factura_inicial = (drd.HasColumn("FACTURAINICIAL") ? drd["FACTURAINICIAL"] == DBNull.Value ? "" : drd["FACTURAINICIAL"].ToString() : "").Trim();
                            Cabecera.factura_final = (drd.HasColumn("FACTURAFINAL") ? drd["FACTURAFINAL"] == DBNull.Value ? "" : drd["FACTURAFINAL"].ToString() : "").Trim();
                            Cabecera.boleta_inicial = (drd.HasColumn("BOLETAINICIAL") ? drd["BOLETAINICIAL"] == DBNull.Value ? "" : drd["BOLETAINICIAL"].ToString() : "").Trim();
                            Cabecera.boleta_final = (drd.HasColumn("BOLETAFINAL") ? drd["BOLETAFINAL"] == DBNull.Value ? "" : drd["BOLETAFINAL"].ToString() : "").Trim();
                            Cabecera.cantidad_z = (drd.HasColumn("NROZETA") ? drd["NROZETA"] == DBNull.Value ? "" : drd["NROZETA"].ToString() : "").Trim();
                            Cabecera.total_z = (drd.HasColumn("MTOZETA") ? drd["MTOZETA"] == DBNull.Value ? "" : drd["MTOZETA"].ToString() : "").Trim();
                            Cabecera.cantidad_documentos_anulados = (drd.HasColumn("DOCUMENTOSANULADOS") ? drd["DOCUMENTOSANULADOS"] == DBNull.Value ? "" : drd["DOCUMENTOSANULADOS"].ToString() : "").Trim();
                            Cabecera.total_anulados = (drd.HasColumn("TOTALANULADOS") ? drd["TOTALANULADOS"] == DBNull.Value ? "" : drd["TOTALANULADOS"].ToString() : "").Trim();
                            Cabecera.tipo_cambio = (drd.HasColumn("TIPOCAMBIO") ? drd["TIPOCAMBIO"] == DBNull.Value ? "" : drd["TIPOCAMBIO"].ToString() : "").Trim();
                            Cabecera.redondeo = (drd.HasColumn("redondeo") ? drd["redondeo"] == DBNull.Value ? "" : drd["redondeo"].ToString() : "").Trim();
                        }
                    }
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con != null) { con.Dispose(); }
                }
            }

            return Cabecera;
        }
        public List<TS_BEXGrupo> OBTENER_GRUPO(TS_BEParametro Parametros, TS_BETerminal Terminal, string grupo)
        {
            List<TS_BEXGrupo> ListaGRUPO = new List<TS_BEXGrupo>(); ;

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CIERRE_X", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDLOCAL", SqlDbType.VarChar, 5).Value = Parametros.cdlocal;
                    cmd.Parameters.Add("@CDALMACEN", SqlDbType.VarChar, 5).Value = Terminal.cdalmacen;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 20).Value = Terminal.fecproceso;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 10).Value = Terminal.nropos;
                    cmd.Parameters.Add("@TURNO", SqlDbType.VarChar, 10).Value = Terminal.turno;
                    cmd.Parameters.Add("@NROSERIMAQ", SqlDbType.VarChar, 20).Value = Terminal.nroseriemaq;
                    cmd.Parameters.Add("@CDUSUARIO", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@NROZETA", SqlDbType.VarChar, 10).Value = Terminal.nrozeta;
                    cmd.Parameters.Add("@MTOZETA", SqlDbType.VarChar, 20).Value = Terminal.mtozeta;
                    cmd.Parameters.Add("@CDVENDEDOR", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 2).Value = grupo;
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BEXGrupo Item = new TS_BEXGrupo();
                            Item.codigo = (drd.HasColumn("CODIGO") ? drd["CODIGO"] == DBNull.Value ? "" : drd["CODIGO"].ToString() : "").Trim();
                            Item.nombre = (drd.HasColumn("GRUPO") ? drd["GRUPO"] == DBNull.Value ? "" : drd["GRUPO"].ToString() : "").Trim();
                            Item.total = drd.HasColumn("TOTAL") ? drd["TOTAL"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["TOTAL"]) : 0;
                            ListaGRUPO.Add(Item);
                        }

                    }
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con != null) { con.Dispose(); }
                }
            }

            return ListaGRUPO;
        }
        public List<TS_BEXGrupoProductos> OBTENER_VENTAS_POR_PRODUCTO(TS_BEParametro Parametros, TS_BETerminal Terminal)
        {
            List<TS_BEXGrupoProductos> ListaGRUPO = new List<TS_BEXGrupoProductos>(); ;

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CIERRE_X", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDLOCAL", SqlDbType.VarChar, 5).Value = Parametros.cdlocal;
                    cmd.Parameters.Add("@CDALMACEN", SqlDbType.VarChar, 5).Value = Terminal.cdalmacen;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 20).Value = Terminal.fecproceso;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 10).Value = Terminal.nropos;
                    cmd.Parameters.Add("@TURNO", SqlDbType.VarChar, 10).Value = Terminal.turno;
                    cmd.Parameters.Add("@NROSERIMAQ", SqlDbType.VarChar, 20).Value = Terminal.nroseriemaq;
                    cmd.Parameters.Add("@CDUSUARIO", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@NROZETA", SqlDbType.VarChar, 10).Value = Terminal.nrozeta;
                    cmd.Parameters.Add("@MTOZETA", SqlDbType.VarChar, 20).Value = Terminal.mtozeta;
                    cmd.Parameters.Add("@CDVENDEDOR", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 2).Value = "VP";/*VENTAS POR PRODUCTO*/
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BEXGrupoProductos Item = new TS_BEXGrupoProductos();
                            Item.codigo = (drd.HasColumn("CODIGO") ? drd["CODIGO"] == DBNull.Value ? "" : drd["CODIGO"].ToString() : "").Trim();
                            Item.nombre = (drd.HasColumn("NOMBRE") ? drd["NOMBRE"] == DBNull.Value ? "" : drd["NOMBRE"].ToString() : "").Trim();
                            Item.cantidad = drd.HasColumn("CANTIDAD") ? drd["CANTIDAD"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["CANTIDAD"]) : 0;
                            Item.descuento = drd.HasColumn("DESCUENTO") ? drd["DESCUENTO"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["DESCUENTO"]) : 0;
                            Item.total = drd.HasColumn("TOTAL") ? drd["TOTAL"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["TOTAL"]) : 0;
                            Item.gratuito = drd.HasColumn("GRATUITO") ? drd["GRATUITO"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["GRATUITO"]) : 0;
                            ListaGRUPO.Add(Item);
                        }


                    }
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con != null) { con.Dispose(); }
                }
            }

            return ListaGRUPO;
        }
        public List<TS_BEXCara> OBTENER_VENTAS_POR_CARA(TS_BEParametro Parametros, TS_BETerminal Terminal)
        {
            List<TS_BEXCara> ListaGRUPO = new List<TS_BEXCara>(); ;

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CIERRE_X", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDLOCAL", SqlDbType.VarChar, 5).Value = Parametros.cdlocal;
                    cmd.Parameters.Add("@CDALMACEN", SqlDbType.VarChar, 5).Value = Terminal.cdalmacen;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 20).Value = Terminal.fecproceso;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 10).Value = Terminal.nropos;
                    cmd.Parameters.Add("@TURNO", SqlDbType.VarChar, 10).Value = Terminal.turno;
                    cmd.Parameters.Add("@NROSERIMAQ", SqlDbType.VarChar, 20).Value = Terminal.nroseriemaq;
                    cmd.Parameters.Add("@CDUSUARIO", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@NROZETA", SqlDbType.VarChar, 10).Value = Terminal.nrozeta;
                    cmd.Parameters.Add("@MTOZETA", SqlDbType.VarChar, 20).Value = Terminal.mtozeta;
                    cmd.Parameters.Add("@CDVENDEDOR", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 2).Value = "VC";/*VENTAS POR CARA*/
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BEXCara Item = new TS_BEXCara();
                            Item.cara = (drd.HasColumn("CARA") ? drd["CARA"] == DBNull.Value ? "" : drd["CARA"].ToString() : "").Trim();
                            Item.descuentos = drd.HasColumn("DESCUENTOS") ? drd["DESCUENTOS"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["DESCUENTOS"]) : 0;
                            Item.gratuito = drd.HasColumn("GRATUITO") ? drd["GRATUITO"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["GRATUITO"]) : 0;
                            Item.total = drd.HasColumn("TOTAL") ? drd["TOTAL"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["TOTAL"]) : 0;
                            ListaGRUPO.Add(Item);
                        }
                    }
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con != null) { con.Dispose(); }
                }
            }

            return ListaGRUPO;
        }
        public List<TS_BEXVendedor> OBTENER_VENTAS_USUARIO_VENDEDOR(TS_BEParametro Parametros, TS_BETerminal Terminal, string grupo)
        {
            List<TS_BEXVendedor> ListaGRUPO = new List<TS_BEXVendedor>(); ;

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CIERRE_X", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDLOCAL", SqlDbType.VarChar, 5).Value = Parametros.cdlocal;
                    cmd.Parameters.Add("@CDALMACEN", SqlDbType.VarChar, 5).Value = Terminal.cdalmacen;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 20).Value = Terminal.fecproceso;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 10).Value = Terminal.nropos;
                    cmd.Parameters.Add("@TURNO", SqlDbType.VarChar, 10).Value = Terminal.turno;
                    cmd.Parameters.Add("@NROSERIMAQ", SqlDbType.VarChar, 20).Value = Terminal.nroseriemaq;
                    cmd.Parameters.Add("@CDUSUARIO", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@NROZETA", SqlDbType.VarChar, 10).Value = Terminal.nrozeta;
                    cmd.Parameters.Add("@MTOZETA", SqlDbType.VarChar, 20).Value = Terminal.mtozeta;
                    cmd.Parameters.Add("@CDVENDEDOR", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 2).Value = grupo;/*VENTAS POR VENDEDOR VV O USUARIO VU*/
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BEXVendedor Item = new TS_BEXVendedor();
                            Item.nombre = (drd.HasColumn("NOMBRE") ? drd["NOMBRE"] == DBNull.Value ? "" : drd["NOMBRE"].ToString() : "").Trim();
                            Item.descuentos = drd.HasColumn("DESCUENTOS") ? drd["DESCUENTOS"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["DESCUENTOS"]) : 0;
                            Item.gratuito = drd.HasColumn("GRATUITO") ? drd["GRATUITO"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["GRATUITO"]) : 0;
                            Item.total = drd.HasColumn("TOTAL") ? drd["TOTAL"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["TOTAL"]) : 0;
                            ListaGRUPO.Add(Item);
                        }
                    }
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con != null) { con.Dispose(); }
                }
            }

            return ListaGRUPO;
        }
        public TS_BEXDocumentos OBTENER_VENTAS_POR_DOCUMENTO(TS_BEParametro Parametros, TS_BETerminal Terminal)
        {
            TS_BEXDocumentos Documentos = new TS_BEXDocumentos(); ;

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CIERRE_X", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDLOCAL", SqlDbType.VarChar, 5).Value = Parametros.cdlocal;
                    cmd.Parameters.Add("@CDALMACEN", SqlDbType.VarChar, 5).Value = Terminal.cdalmacen;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 20).Value = Terminal.fecproceso;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 10).Value = Terminal.nropos;
                    cmd.Parameters.Add("@TURNO", SqlDbType.VarChar, 10).Value = Terminal.turno;
                    cmd.Parameters.Add("@NROSERIMAQ", SqlDbType.VarChar, 20).Value = Terminal.nroseriemaq;
                    cmd.Parameters.Add("@CDUSUARIO", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@NROZETA", SqlDbType.VarChar, 10).Value = Terminal.nrozeta;
                    cmd.Parameters.Add("@MTOZETA", SqlDbType.VarChar, 20).Value = Terminal.mtozeta;
                    cmd.Parameters.Add("@CDVENDEDOR", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 2).Value = "VD";/*VENTAS POR VENDEDOR VV O USUARIO VU*/
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {

                            Documentos.cantidad_facturas = (drd.HasColumn("FACTURAS") ? drd["FACTURAS"] == DBNull.Value ? "" : drd["FACTURAS"].ToString() : "").Trim();
                            Documentos.total_facturas = drd.HasColumn("TOTALFACTURAS") ? drd["TOTALFACTURAS"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["TOTALFACTURAS"]) : 0;
                            Documentos.cantidad_boletas = (drd.HasColumn("BOLETAS") ? drd["BOLETAS"] == DBNull.Value ? "" : drd["BOLETAS"].ToString() : "").Trim();
                            Documentos.total_boletas = drd.HasColumn("TOTALBOLETAS") ? drd["TOTALBOLETAS"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["TOTALBOLETAS"]) : 0;
                            Documentos.cantidad_notadespacho = (drd.HasColumn("NOTADESPACHO") ? drd["NOTADESPACHO"] == DBNull.Value ? "" : drd["NOTADESPACHO"].ToString() : "").Trim();
                            Documentos.total_notadespacho = drd.HasColumn("TOTALNOTADESPACHO") ? drd["TOTALNOTADESPACHO"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["TOTALNOTADESPACHO"]) : 0;

                        }
                    }
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con != null) { con.Dispose(); }
                }
            }

            return Documentos;
        }
        public TS_BEXTipoPago OBTENER_TIPOS_PAGO(TS_BEParametro Parametros, TS_BETerminal Terminal)
        {
            TS_BEXTipoPago Documentos = new TS_BEXTipoPago(); ;

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CIERRE_X", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDLOCAL", SqlDbType.VarChar, 5).Value = Parametros.cdlocal;
                    cmd.Parameters.Add("@CDALMACEN", SqlDbType.VarChar, 5).Value = Terminal.cdalmacen;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 20).Value = Terminal.fecproceso;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 10).Value = Terminal.nropos;
                    cmd.Parameters.Add("@TURNO", SqlDbType.VarChar, 10).Value = Terminal.turno;
                    cmd.Parameters.Add("@NROSERIMAQ", SqlDbType.VarChar, 20).Value = Terminal.nroseriemaq;
                    cmd.Parameters.Add("@CDUSUARIO", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@NROZETA", SqlDbType.VarChar, 10).Value = Terminal.nrozeta;
                    cmd.Parameters.Add("@MTOZETA", SqlDbType.VarChar, 20).Value = Terminal.mtozeta;
                    cmd.Parameters.Add("@CDVENDEDOR", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 2).Value = "TP";/*VENTAS POR VENDEDOR VV O USUARIO VU*/
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            Documentos.efectivo = drd.HasColumn("EFECTIVO") ? drd["EFECTIVO"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["EFECTIVO"]) : 0;
                            Documentos.tarjeta = drd.HasColumn("TARJETA") ? drd["TARJETA"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["TARJETA"]) : 0;
                            Documentos.cheque = drd.HasColumn("CHEQUE") ? drd["CHEQUE"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["CHEQUE"]) : 0;
                            Documentos.credito = drd.HasColumn("CREDITO") ? drd["CREDITO"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["CREDITO"]) : 0;
                            Documentos.gratuito = drd.HasColumn("GRATUITO") ? drd["GRATUITO"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["GRATUITO"]) : 0;
                            Documentos.viatico = drd.HasColumn("VIATICO") ? drd["VIATICO"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["VIATICO"]) : 0;
                            Documentos.serafin = drd.HasColumn("SERAFIN") ? drd["SERAFIN"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["SERAFIN"]) : 0;
                            Documentos.totalneto = drd.HasColumn("TOTALNETO") ? drd["TOTALNETO"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["TOTALNETO"]) : 0;
                            Documentos.total = drd.HasColumn("TOTAL") ? drd["TOTAL"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["TOTAL"]) : 0;

                        }

                    }
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con != null) { con.Dispose(); }
                }
            }

            return Documentos;
        }
        public decimal OBTENER_TOTAL_CANJES(TS_BEParametro Parametros, TS_BETerminal Terminal)
        {
            decimal TotalCanje = 0;

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CIERRE_X", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDLOCAL", SqlDbType.VarChar, 5).Value = Parametros.cdlocal;
                    cmd.Parameters.Add("@CDALMACEN", SqlDbType.VarChar, 5).Value = Terminal.cdalmacen;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 20).Value = Terminal.fecproceso;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 10).Value = Terminal.nropos;
                    cmd.Parameters.Add("@TURNO", SqlDbType.VarChar, 10).Value = Terminal.turno;
                    cmd.Parameters.Add("@NROSERIMAQ", SqlDbType.VarChar, 20).Value = Terminal.nroseriemaq;
                    cmd.Parameters.Add("@CDUSUARIO", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@NROZETA", SqlDbType.VarChar, 10).Value = Terminal.nrozeta;
                    cmd.Parameters.Add("@MTOZETA", SqlDbType.VarChar, 20).Value = Terminal.mtozeta;
                    cmd.Parameters.Add("@CDVENDEDOR", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 2).Value = "TC";/*VENTAS POR VENDEDOR VV O USUARIO VU*/
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TotalCanje = drd.HasColumn("TOTALCANJES") ? drd["TOTALCANJES"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["TOTALCANJES"]) : 0;
                        }
                    }
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con != null) { con.Dispose(); }
                }
            }

            return TotalCanje;
        }
        public List<TS_BEXDepositosVendedor> OBTENER_DEPOSITOS(TS_BEXCierre Cierre,TS_BEParametro Parametros, TS_BETerminal Terminal)
        {
            List<TS_BEXDepositosVendedor> Depositos = new List<TS_BEXDepositosVendedor>(); ;

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CIERRE_X", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDLOCAL", SqlDbType.VarChar, 5).Value = Parametros.cdlocal;
                    cmd.Parameters.Add("@CDALMACEN", SqlDbType.VarChar, 5).Value = Terminal.cdalmacen;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 20).Value = Terminal.fecproceso;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 10).Value = Terminal.nropos;
                    cmd.Parameters.Add("@TURNO", SqlDbType.VarChar, 10).Value = Terminal.turno;
                    cmd.Parameters.Add("@NROSERIMAQ", SqlDbType.VarChar, 20).Value = Terminal.nroseriemaq;
                    cmd.Parameters.Add("@CDUSUARIO", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@NROZETA", SqlDbType.VarChar, 10).Value = Terminal.nrozeta;
                    cmd.Parameters.Add("@MTOZETA", SqlDbType.VarChar, 20).Value = Terminal.mtozeta;
                    cmd.Parameters.Add("@CDVENDEDOR", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 2).Value = "DV";/*DEPOSITOS DE VENDEDOR*/
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BEXDepositosVendedor Deposito = new TS_BEXDepositosVendedor();
                            Deposito.nombre = (drd.HasColumn("VENDEDOR") ? drd["VENDEDOR"] == DBNull.Value ? "N/A" : drd["VENDEDOR"].ToString() : "N/A").Trim();
                            Deposito.soles = drd.HasColumn("SOLES") ? drd["SOLES"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["SOLES"]) : 0;
                            Deposito.dolares = drd.HasColumn("DOLARES") ? drd["DOLARES"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["DOLARES"]) : 0;
                            Deposito.sobres = (drd.HasColumn("SOBRES") ? drd["SOBRES"] == DBNull.Value ? "0" : drd["SOBRES"].ToString() : "0").Trim();
                            Deposito.efectivo = Cierre.cVentasPorTipoPago.efectivo;
                            Deposito.tipo_cambio = Cierre.cCabecera.tipo_cambio;
                            Depositos.Add(Deposito);
                        }

                    }
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con != null) { con.Dispose(); }
                }
            }

            return Depositos;
        }
        public TS_BEXTotales OBTENER_TOTALIZADOS(TS_BEParametro Parametros, TS_BETerminal Terminal)
        {
            TS_BEXTotales Totales = new TS_BEXTotales(); ;

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CIERRE_X", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDLOCAL", SqlDbType.VarChar, 5).Value = Parametros.cdlocal;
                    cmd.Parameters.Add("@CDALMACEN", SqlDbType.VarChar, 5).Value = Terminal.cdalmacen;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 20).Value = Terminal.fecproceso;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 10).Value = Terminal.nropos;
                    cmd.Parameters.Add("@TURNO", SqlDbType.VarChar, 10).Value = Terminal.turno;
                    cmd.Parameters.Add("@NROSERIMAQ", SqlDbType.VarChar, 20).Value = Terminal.nroseriemaq;
                    cmd.Parameters.Add("@CDUSUARIO", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@NROZETA", SqlDbType.VarChar, 10).Value = Terminal.nrozeta;
                    cmd.Parameters.Add("@MTOZETA", SqlDbType.VarChar, 20).Value = Terminal.mtozeta;
                    cmd.Parameters.Add("@CDVENDEDOR", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 2).Value = "DI";/*Totales descuentos, aumentos , totales*/
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            Totales.incrementro = drd.HasColumn("INCREMENTO") ? drd["INCREMENTO"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["INCREMENTO"]) : 0;
                            Totales.descuentos = drd.HasColumn("DESCUENTO") ? drd["DESCUENTO"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["DESCUENTO"]) : 0;
                            Totales.total_sin_decuentos = drd.HasColumn("SINDESCUENTO") ? drd["SINDESCUENTO"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["SINDESCUENTO"]) : 0;
                            Totales.total_con_decuentos = drd.HasColumn("TOTAL") ? drd["TOTAL"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["TOTAL"]) : 0;
                        }
                    }
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con != null) { con.Dispose(); }
                }
            }

            return Totales;
        }
        public List<TS_BEXArticuloStock> OBTENER_ARTICULOS_VENDIDOS_STOCK_NEGATIVO(TS_BEParametro Parametros, TS_BETerminal Terminal)
        {
            List<TS_BEXArticuloStock> Lista = new List<TS_BEXArticuloStock>();

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CIERRE_X", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDLOCAL", SqlDbType.VarChar, 5).Value = Parametros.cdlocal;
                    cmd.Parameters.Add("@CDALMACEN", SqlDbType.VarChar, 5).Value = Terminal.cdalmacen;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 20).Value = Terminal.fecproceso;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 10).Value = Terminal.nropos;
                    cmd.Parameters.Add("@TURNO", SqlDbType.VarChar, 10).Value = Terminal.turno;
                    cmd.Parameters.Add("@NROSERIMAQ", SqlDbType.VarChar, 20).Value = Terminal.nroseriemaq;
                    cmd.Parameters.Add("@CDUSUARIO", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@NROZETA", SqlDbType.VarChar, 10).Value = Terminal.nrozeta;
                    cmd.Parameters.Add("@MTOZETA", SqlDbType.VarChar, 20).Value = Terminal.mtozeta;
                    cmd.Parameters.Add("@CDVENDEDOR", SqlDbType.VarChar, 20).Value = Terminal.cdusuario;
                    cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 2).Value = "SN";/*Totales descuentos, aumentos , totales*/
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BEXArticuloStock Totales = new TS_BEXArticuloStock(); ;
                            Totales.codigo = (drd.HasColumn("CODIGO") ? drd["CODIGO"] == DBNull.Value ? "N/A" : drd["CODIGO"].ToString() : "N/A").Trim();
                            Totales.nombre = (drd.HasColumn("NOMBRE") ? drd["NOMBRE"] == DBNull.Value ? "N/A" : drd["NOMBRE"].ToString() : "N/A").Trim();
                            Totales.stock = drd.HasColumn("STOCK") ? drd["STOCK"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["STOCK"]) : 0;
                            Lista.Add(Totales);
                        }
                    }
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con != null) { con.Dispose(); }
                }
            }

            return Lista;
        }

    }
}
