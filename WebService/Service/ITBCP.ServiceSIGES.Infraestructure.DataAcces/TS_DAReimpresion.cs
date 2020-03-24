using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Reimpresion;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;

namespace ITBCP.ServiceSIGES.Infraestructure.DataAcces
{

    public class TS_DAReimpresion : ITS_DOReimpresion
    {
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public TS_BEReimpresionLOutput OBTENER_VENTAG(TS_BEVentagInput input)
        {
            TS_BEReimpresionLOutput ListaDocumentos = new TS_BEReimpresionLOutput(new TS_BEMensaje("",false),new List<TS_BEReimpresionL>());

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_DOCUMENTO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDTIPODOC", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@NRODOCUMENTO", SqlDbType.VarChar, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@NROSERIEMAQ", SqlDbType.VarChar, 10).Value = "";
                    cmd.Parameters.Add("@FECHA", SqlDbType.VarChar, 10).Value = "";
                    cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 1).Value = "G";
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BEReimpresionL Documento = new TS_BEReimpresionL();
                            Documento.nroseriemaq = (drd["nroseriemaq"].ToString() ?? "").Trim();
                            Documento.cdtipodoc = (drd["cdtipodoc"].ToString() ?? "").Trim();
                            Documento.nrodocumento = (drd["nrodocumento"].ToString() ?? "").Trim();
                            Documento.fecdocumento = Convert.ToDateTime(drd["fecdocumento"]);
                            Documento.fecha = (drd["fecha"].ToString() ?? "").Trim();
                            Documento.nropos = (drd["nropos"].ToString() ?? "").Trim();
                            Documento.cdcliente = (drd["cdcliente"].ToString() ?? "").Trim();
                            Documento.rscliente = (drd["rscliente"].ToString() ?? "").Trim();
                            Documento.anulado = Convert.ToBoolean(drd["anulado"]);
                            ListaDocumentos.Documentos.Add(Documento);
                        }
                        ListaDocumentos.Mensaje.Ok = true;
                        if (ListaDocumentos.Documentos.Count == 0)
                        {
                            ListaDocumentos.Mensaje.mensaje = "No se encontraron documentos";
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
            return ListaDocumentos;
        }
        public TS_BECabecera OBTENER_VENTA_CABECERA(TS_BEDocumentoInput input)
        {
            TS_BECabecera Venta = null;

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_DOCUMENTO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NRODOCUMENTO", SqlDbType.VarChar, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@CDTIPODOC", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@NROSERIEMAQ", SqlDbType.Char, 100).Value = input.nroseriemaq;
                    cmd.Parameters.Add("@FECHA", SqlDbType.Char, 10).Value = input.fecha;
                    cmd.Parameters.Add("@TIPO", SqlDbType.Char, 1).Value = 'C';
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            Venta = new TS_BECabecera();
                            Venta.cdlocal = (drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? "" : drd["cdlocal"].ToString() : "").Trim();
                            Venta.nroseriemaq = (drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? "" : drd["nroseriemaq"].ToString() : "").Trim();
                            Venta.cdtipodoc = (drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? "" : drd["cdtipodoc"].ToString() : "").Trim();
                            Venta.nrodocumento = (drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? "" : drd["nrodocumento"].ToString() : "").Trim();
                            Venta.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?) null : (DateTime)(drd["fecproceso"]) : (DateTime?) null;
                            Venta.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? DateTime.Now : (DateTime)(drd["fecdocumento"]) : DateTime.Now;
                            Venta.nropos = (drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? "" : drd["nropos"].ToString() : "").Trim();
                            Venta.mtovueltosol = drd.HasColumn("mtovueltosol") ? drd["mtovueltosol"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtovueltosol"]) : 0;
                            Venta.mtovueltodol = drd.HasColumn("mtovueltodol") ? drd["mtovueltodol"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtovueltodol"]) : 0;
                            Venta.cdcliente = (drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? "" : drd["cdcliente"].ToString() : "").Trim();
                            Venta.ruccliente = (drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? "" : drd["ruccliente"].ToString() : "").Trim();
                            Venta.rscliente = (drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? "" : drd["rscliente"].ToString() : "").Trim();
                            Venta.drcliente = (drd.HasColumn("drcliente") ? drd["drcliente"] == DBNull.Value ? "" : drd["drcliente"].ToString() : "").Trim();
                            Venta.cdmoneda = (drd.HasColumn("cdmoneda") ? drd["cdmoneda"] == DBNull.Value ? "" : drd["cdmoneda"].ToString() : "").Trim();
                            Venta.valorvta = drd.HasColumn("valorvta") ? drd["valorvta"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["valorvta"]) : 0;
                            Venta.mtodscto = drd.HasColumn("mtodscto") ? drd["mtodscto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtodscto"]) : 0;
                            Venta.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtosubtotal"]) : 0;
                            Venta.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtoimpuesto"]) : 0;
                            Venta.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtototal"]) : 0;
                            Venta.nroplaca = (drd.HasColumn("nroplaca") ? drd["nroplaca"] == DBNull.Value ? "" : drd["nroplaca"].ToString() : "").Trim();
                            Venta.cdusuario = (drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? "" : drd["cdusuario"].ToString() : "").Trim();
                            Venta.anulado = drd.HasColumn("anulado") ? drd["anulado"] == DBNull.Value ? false : Convert.ToBoolean(drd["anulado"]) : false;
                            Venta.observacion = (drd.HasColumn("observacion") ? drd["observacion"] == DBNull.Value ? "" : drd["observacion"].ToString() : "").Trim();
                            Venta.turno = (drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? "" : drd["turno"].ToString() : "").Trim();
                            Venta.nrotarjeta = (drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? "" : drd["nrotarjeta"].ToString() : "").Trim();
                            Venta.odometro = (drd.HasColumn("odometro") ? drd["odometro"] == DBNull.Value ? "" : drd["odometro"].ToString() : "").Trim();
                            Venta.ptosganados = drd.HasColumn("ptoganados") ? drd["ptoganados"] == DBNull.Value ? 0 : Convert.ToInt32(drd["ptoganados"]) : 0;
                            Venta.cdmedio_pago = (drd.HasColumn("cdMedio_Pago") ? drd["cdMedio_Pago"] == DBNull.Value ? "" : drd["cdMedio_Pago"].ToString() : "").Trim();
                            Venta.redondea_indecopi = drd.HasColumn("redondea_indecopi") ? drd["redondea_indecopi"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["redondea_indecopi"]) : 0;
                            Venta.cdhash = (drd.HasColumn("cdhash") ? drd["cdhash"] == DBNull.Value ? "" : drd["cdhash"].ToString() : "").Trim();
                            Venta.scop = (drd.HasColumn("scop") ? drd["scop"] == DBNull.Value ? "" : drd["scop"].ToString() : "").Trim();
                            Venta.nroguia = (drd.HasColumn("nroguia") ? drd["nroguia"] == DBNull.Value ? "" : drd["nroguia"].ToString() : "").Trim();
                            Venta.nrolicencia = (drd.HasColumn("nrolicencia") ? drd["nrolicencia"] == DBNull.Value ? "" : drd["nrolicencia"].ToString() : "").Trim();
                            Venta.tipoventa = (drd.HasColumn("tipoventa") ? drd["tipoventa"] == DBNull.Value ? "" : drd["tipoventa"].ToString() : "").Trim();
                            Venta.nrocelular = (drd.HasColumn("nrocelular") ? drd["nrocelular"] == DBNull.Value ? "" : drd["nrocelular"].ToString() : "").Trim();
                            Venta.cdruta = (drd.HasColumn("cdruta") ? drd["cdruta"] == DBNull.Value ? "" : drd["cdruta"].ToString() : "").Trim();
                            Venta.codes = (drd.HasColumn("codes") ? drd["codes"] == DBNull.Value ? "" : drd["codes"].ToString() : "").Trim();
                            Venta.codes = (drd.HasColumn("codeid") ? drd["codeid"] == DBNull.Value ? "" : drd["codeid"].ToString() : "").Trim();
                            Venta.precio_orig = drd.HasColumn("precio_orig") ? drd["precio_orig"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["precio_orig"]) : 0;
                            Venta.lado = (drd.HasColumn("lado") ? drd["lado"] == DBNull.Value ? "" : drd["lado"].ToString() : "").Trim();
                            Venta.nrobonus = (drd.HasColumn("nrobonus") ? drd["nrobonus"] == DBNull.Value ? "" : drd["nrobonus"].ToString() : "").Trim();
                            Venta.cdtranspor = (drd.HasColumn("cdtranspor") ? drd["cdtranspor"] == DBNull.Value ? "" : drd["cdtranspor"].ToString() : "").Trim();
                            Venta.chofer = (drd.HasColumn("chofer") ? drd["chofer"] == DBNull.Value ? "" : drd["chofer"].ToString() : "").Trim();
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
            return Venta;
        }
        public List<TS_BEArticulo> OBTENER_VENTA_DETALLE(TS_BEDocumentoInput input)
        {
            List<TS_BEArticulo> Lista = new List<TS_BEArticulo>();

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_DOCUMENTO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NRODOCUMENTO", SqlDbType.VarChar, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@CDTIPODOC", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@NROSERIEMAQ", SqlDbType.Char, 100).Value = input.nroseriemaq;
                    cmd.Parameters.Add("@FECHA", SqlDbType.Char, 10).Value = input.fecha;
                    cmd.Parameters.Add("@TIPO", SqlDbType.Char, 1).Value = 'D';
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BEArticulo Ventad = new TS_BEArticulo();
                            Ventad.cantidad = drd.HasColumn("cantidad") ? drd["cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["cantidad"]) : 0;
                            Ventad.precio = drd.HasColumn("precio") ? drd["precio"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["precio"]) : 0;
                            Ventad.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["impuesto"]) : 0;
                            Ventad.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtototal"]) : 0;
                            Ventad.glosa = (drd.HasColumn("glosa") ? drd["glosa"] == DBNull.Value ? "" : drd["glosa"].ToString() : "").Trim();
                            Ventad.cdunimed = (drd.HasColumn("cdunimed") ? drd["cdunimed"] == DBNull.Value ? "" : drd["cdunimed"].ToString() : "").Trim();
                            Ventad.cara = (drd.HasColumn("cara") ? drd["cara"] == DBNull.Value ? "" : drd["cara"].ToString() : "").Trim();
                            Ventad.total = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtototal"]) : 0;
                            Ventad.mtodscto = drd.HasColumn("mtodscto") ? drd["mtodscto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtodscto"]) : 0;
                            Ventad.precio_orig = drd.HasColumn("precio_orig") ? drd["precio_orig"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["precio_orig"]) : 0;
                            Lista.Add(Ventad);
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
        public List<TS_BEPago> OBTENER_VENTA_PAGO(TS_BEDocumentoInput input)
        {

            List<TS_BEPago> Lista = new List<TS_BEPago>();

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_DOCUMENTO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NRODOCUMENTO", SqlDbType.VarChar, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@CDTIPODOC", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@NROSERIEMAQ", SqlDbType.Char, 100).Value = input.nroseriemaq;
                    cmd.Parameters.Add("@FECHA", SqlDbType.Char, 10).Value = input.fecha;
                    cmd.Parameters.Add("@TIPO", SqlDbType.Char, 1).Value = 'P';
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BEPago Ventap = new TS_BEPago();
                            Ventap.cdtppago = (drd.HasColumn("cdtppago") ? drd["cdtppago"] == DBNull.Value ? "" : drd["cdtppago"].ToString() : "").Trim();
                            Ventap.mtopagosol = drd.HasColumn("mtopagosol") ? drd["mtopagosol"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtopagosol"]) : 0;
                            Ventap.mtopagodol = drd.HasColumn("mtopagodol") ? drd["mtopagodol"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtopagodol"]) : 0;
                            Ventap.cdtarjeta = (drd.HasColumn("cdtarjeta") ? drd["cdtarjeta"] == DBNull.Value ? "" : drd["cdtarjeta"].ToString() : "").Trim();
                            Ventap.nrotarjeta = (drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? "" : drd["nrotarjeta"].ToString() : "").Trim();
                            Ventap.cambio = (drd.HasColumn("cambio") ? drd["cambio"] == DBNull.Value ? "" : drd["cambio"].ToString() : "").Trim();
                            Lista.Add(Ventap);
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
        public TS_BEClienteInput OBTENER_CLIENTE(TS_BEDocumento Documento, TS_BEClienteOutput cCliente)
        {
            if(cCliente == null)
            {
                cCliente = new TS_BEClienteOutput();
            }

            TS_BEClienteInput vcCliente = new TS_BEClienteInput()
            {
                cdcliente = Documento.cCabecera.cdcliente == null ? "" : Documento.cCabecera.cdcliente,
                ruccliente = Documento.cCabecera.ruccliente == null ? "" : Documento.cCabecera.ruccliente,
                rscliente = Documento.cCabecera.rscliente == null ? "" : Documento.cCabecera.rscliente,
                drcliente = Documento.cCabecera.drcliente == null ? "" : Documento.cCabecera.drcliente,
                sunat_actualiza = Convert.ToByte(cCliente.sunat_actualiza),                diascredito = Convert.ToByte(cCliente.diascredito),                diasmax_nd = Convert.ToByte(cCliente.diasmax_nd),                bloqcredito = Convert.ToBoolean(cCliente.bloqcredito),                flgpreciond = Convert.ToBoolean(cCliente.flgpreciond),                consulta_sunat= Convert.ToBoolean(cCliente.consulta_sunat),                flg_pideclave = Convert.ToBoolean(cCliente.flg_pideclave),                flgtotalnd = Convert.ToBoolean(cCliente.flgtotalnd),                tlfcliente = cCliente.tlfcliente,                tlfcliente1 = cCliente.tlfcliente1,                faxcliente = cCliente.faxcliente,                mtodisminuir = Convert.ToDecimal(cCliente.mtodisminuir),                nroTarjeta = cCliente.nroTarjeta,                tarjAfiliacion = Documento.cCabecera.nrobonus,                correoelectronico = cCliente.emcliente,                flgmostrarsaldo = Convert.ToBoolean(cCliente.flgmostrarsaldo),
            };
            return vcCliente;
        }
        public TS_BEUltimoDocumentoInput OBTENER_DATOS_ULTIMO_DOCUMENTO(TS_BEUltimoDocumentoInput input)
        {
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_DOCUMENTO_ULTIMO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 10).Value = input.nropos;
                    cmd.Parameters.Add("@NROSERIEMAQ", SqlDbType.Char, 5).Value = "";
                    cmd.Parameters.Add("@CDTIPODOC", SqlDbType.Char, 100).Value = "";
                    cmd.Parameters.Add("@NRODOCUMENTO", SqlDbType.Char, 10).Value = "";
                    cmd.Parameters.Add("@TIPO", SqlDbType.Char, 1).Value = 'R';
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        if (!drd.HasRows)
                        {
                            input.Mensaje = "El punto no cuenta con documentos registrados";
                            input.Ok = false;
                        }
                        else
                        {
                            while (drd.Read())
                            {
                                input.nroseriemaq = (drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? "" : drd["nroseriemaq"].ToString() : "").Trim();
                                input.cdtipodoc = (drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? "" : drd["cdtipodoc"].ToString() : "").Trim();
                                input.nrodocumento = (drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? "" : drd["nrodocumento"].ToString() : "").Trim();
                                input.Mensaje = "Datos encontrados exitosamente";
                                input.Ok = true;
                            }

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

            return input;
        }
        public TS_BECabecera OBTENER_VENTA_ULTIMO_DOCUMENTO(TS_BEUltimoDocumentoInput input)
        {
            TS_BECabecera Venta = null;

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_DOCUMENTO_ULTIMO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 15).Value = "";
                    cmd.Parameters.Add("@NROSERIEMAQ", SqlDbType.Char, 15).Value = input.nroseriemaq;
                    cmd.Parameters.Add("@CDTIPODOC", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@NRODOCUMENTO", SqlDbType.Char, 15).Value = input.nrodocumento;
                    cmd.Parameters.Add("@TIPO", SqlDbType.Char, 1).Value = 'C';
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            Venta = new TS_BECabecera();
                            Venta.nroseriemaq = (drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? "" : drd["nroseriemaq"].ToString() : "").Trim();
                            Venta.cdtipodoc = (drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? "" : drd["cdtipodoc"].ToString() : "").Trim();
                            Venta.nrodocumento = (drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? "" : drd["nrodocumento"].ToString() : "").Trim();
                            Venta.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? DateTime.Now : (DateTime)(drd["fecdocumento"]) : DateTime.Now;
                            Venta.nropos = (drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? "" : drd["nropos"].ToString() : "").Trim();
                            Venta.chofer = (drd.HasColumn("chofer") ? drd["chofer"] == DBNull.Value ? "" : drd["chofer"].ToString() : "").Trim();
                            Venta.mtovueltosol = drd.HasColumn("mtovueltosol") ? drd["mtovueltosol"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtovueltosol"]) : 0;
                            Venta.mtovueltodol = drd.HasColumn("mtovueltodol") ? drd["mtovueltodol"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtovueltodol"]) : 0;
                            Venta.cdcliente = (drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? "" : drd["cdcliente"].ToString() : "").Trim();
                            Venta.ruccliente = (drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? "" : drd["ruccliente"].ToString() : "").Trim();
                            Venta.rscliente = (drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? "" : drd["rscliente"].ToString() : "").Trim();
                            Venta.drcliente = (drd.HasColumn("drcliente") ? drd["drcliente"] == DBNull.Value ? "" : drd["drcliente"].ToString() : "").Trim();
                            Venta.cdmoneda = (drd.HasColumn("cdmoneda") ? drd["cdmoneda"] == DBNull.Value ? "" : drd["cdmoneda"].ToString() : "").Trim();
                            Venta.valorvta = drd.HasColumn("valorvta") ? drd["valorvta"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["valorvta"]) : 0;
                            Venta.mtodscto = drd.HasColumn("mtodscto") ? drd["mtodscto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtodscto"]) : 0;
                            Venta.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtosubtotal"]) : 0;
                            Venta.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtoimpuesto"]) : 0;
                            Venta.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtototal"]) : 0;
                            Venta.nroplaca = (drd.HasColumn("nroplaca") ? drd["nroplaca"] == DBNull.Value ? "" : drd["nroplaca"].ToString() : "").Trim();
                            Venta.cdusuario = (drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? "" : drd["cdusuario"].ToString() : "").Trim();
                            Venta.anulado = drd.HasColumn("anulado") ? drd["anulado"] == DBNull.Value ? false : Convert.ToBoolean(drd["anulado"]) : false;
                            Venta.observacion = (drd.HasColumn("observacion") ? drd["observacion"] == DBNull.Value ? "" : drd["observacion"].ToString() : "").Trim();
                            Venta.turno = (drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? "" : drd["turno"].ToString() : "").Trim();
                            Venta.nrotarjeta = (drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? "" : drd["nrotarjeta"].ToString() : "").Trim();
                            Venta.odometro = (drd.HasColumn("odometro") ? drd["odometro"] == DBNull.Value ? "" : drd["odometro"].ToString() : "").Trim();
                            Venta.ptosganados = drd.HasColumn("ptosganados") ? drd["ptosganados"] == DBNull.Value ? 0 : Convert.ToInt32(drd["ptosganados"]) : 0;
                            Venta.cdmedio_pago = (drd.HasColumn("cdMedio_Pago") ? drd["cdMedio_Pago"] == DBNull.Value ? "" : drd["cdMedio_Pago"].ToString() : "").Trim();
                            Venta.redondea_indecopi = drd.HasColumn("redondea_indecopi") ? drd["redondea_indecopi"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["redondea_indecopi"]) : 0;
                            Venta.cdhash = (drd.HasColumn("cdhash") ? drd["cdhash"] == DBNull.Value ? "" : drd["cdhash"].ToString() : "").Trim();
                            Venta.scop = (drd.HasColumn("scop") ? drd["scop"] == DBNull.Value ? "" : drd["scop"].ToString() : "").Trim();
                            Venta.nroguia = (drd.HasColumn("nroguia") ? drd["nroguia"] == DBNull.Value ? "" : drd["nroguia"].ToString() : "").Trim();
                            Venta.nrolicencia = (drd.HasColumn("nrolicencia") ? drd["nrolicencia"] == DBNull.Value ? "" : drd["nrolicencia"].ToString() : "").Trim();
                            Venta.tipoventa = (drd.HasColumn("tipoventa") ? drd["tipoventa"] == DBNull.Value ? "" : drd["tipoventa"].ToString() : "").Trim();
                            Venta.nrocelular = (drd.HasColumn("nrocelular") ? drd["nrocelular"] == DBNull.Value ? "" : drd["nrocelular"].ToString() : "").Trim();
                            Venta.cdruta = (drd.HasColumn("cdruta") ? drd["cdruta"] == DBNull.Value ? "" : drd["cdruta"].ToString() : "").Trim();
                            Venta.codes = (drd.HasColumn("codes") ? drd["codes"] == DBNull.Value ? "" : drd["codes"].ToString() : "").Trim();
                            Venta.codes = (drd.HasColumn("codeid") ? drd["codeid"] == DBNull.Value ? "" : drd["codeid"].ToString() : "").Trim();
                            Venta.precio_orig = drd.HasColumn("precio_orig") ? drd["precio_orig"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["precio_orig"]) : 0;
                            Venta.lado = (drd.HasColumn("lado") ? drd["lado"] == DBNull.Value ? "" : drd["lado"].ToString() : "").Trim();
                            Venta.nrobonus = (drd.HasColumn("nrobonus") ? drd["nrobonus"] == DBNull.Value ? "" : drd["nrobonus"].ToString() : "").Trim();
                            Venta.cdtranspor = (drd.HasColumn("cdtranspor") ? drd["cdtranspor"] == DBNull.Value ? "" : drd["cdtranspor"].ToString() : "").Trim();
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
            return Venta;
        }
        public List<TS_BEArticulo> OBTENER_VENTAD_ULTIMO_DOCUMENTO(TS_BEUltimoDocumentoInput input)
        {
            List<TS_BEArticulo> Lista = new List<TS_BEArticulo>();

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_DOCUMENTO_ULTIMO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 15).Value = "";
                    cmd.Parameters.Add("@NROSERIEMAQ", SqlDbType.Char, 15).Value = input.nroseriemaq;
                    cmd.Parameters.Add("@CDTIPODOC", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@NRODOCUMENTO", SqlDbType.Char, 15).Value = input.nrodocumento;
                    cmd.Parameters.Add("@TIPO", SqlDbType.Char, 1).Value = 'D';
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BEArticulo Ventad = new TS_BEArticulo();
                            Ventad.cantidad = drd.HasColumn("cantidad") ? drd["cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["cantidad"]) : 0;
                            Ventad.precio = drd.HasColumn("precio") ? drd["precio"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["precio"]) : 0;
                            Ventad.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["impuesto"]) : 0;
                            Ventad.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtototal"]) : 0;
                            Ventad.total = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtototal"]) : 0;
                            Ventad.glosa = (drd.HasColumn("glosa") ? drd["glosa"] == DBNull.Value ? "" : drd["glosa"].ToString() : "").Trim();
                            Ventad.cara = (drd.HasColumn("cara") ? drd["cara"] == DBNull.Value ? "" : drd["cara"].ToString() : "").Trim();
                            Ventad.cdunimed = (drd.HasColumn("cdunimed") ? drd["cdunimed"] == DBNull.Value ? "" : drd["cdunimed"].ToString() : "").Trim();
                            Ventad.mtodscto = drd.HasColumn("mtodscto") ? drd["mtodscto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtodscto"]) : 0;
                            Ventad.precio_orig = drd.HasColumn("precio_orig") ? drd["precio_orig"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["precio_orig"]) : 0;
                            Lista.Add(Ventad);
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
        public List<TS_BEPago> OBTENER_VENTAP_ULTIMO_DOCUMENTO(TS_BEUltimoDocumentoInput input)
        {
            List<TS_BEPago> Lista = new List<TS_BEPago>();

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_DOCUMENTO_ULTIMO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 15).Value = "";
                    cmd.Parameters.Add("@NROSERIEMAQ", SqlDbType.Char, 15).Value = input.nroseriemaq;
                    cmd.Parameters.Add("@CDTIPODOC", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@NRODOCUMENTO", SqlDbType.Char, 15).Value = input.nrodocumento;
                    cmd.Parameters.Add("@TIPO", SqlDbType.Char, 1).Value = 'P';
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BEPago Ventap = new TS_BEPago();
                            Ventap.cdtppago = (drd.HasColumn("cdtppago") ? drd["cdtppago"] == DBNull.Value ? "" : drd["cdtppago"].ToString() : "").Trim();
                            Ventap.mtopagosol = drd.HasColumn("mtopagosol") ? drd["mtopagosol"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtopagosol"]) : 0;
                            Ventap.mtopagodol = drd.HasColumn("mtopagodol") ? drd["mtopagodol"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtopagodol"]) : 0;
                            Ventap.cdtarjeta = (drd.HasColumn("cdtarjeta") ? drd["cdtarjeta"] == DBNull.Value ? "" : drd["cdtarjeta"].ToString() : "").Trim();
                            Ventap.nrotarjeta = (drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? "" : drd["nrotarjeta"].ToString() : "").Trim();
                            Ventap.cambio = (drd.HasColumn("cambio") ? drd["cambio"] == DBNull.Value ? "" : drd["cambio"].ToString() : "").Trim();
                            Lista.Add(Ventap);
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
        public TS_BEEmisor OBTENER_EMISOR()
        {
            TS_BEEmisor Emisor = new TS_BEEmisor();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_DOCUMENTO_ULTIMO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 15).Value = "";
                    cmd.Parameters.Add("@NROSERIEMAQ", SqlDbType.Char, 15).Value = "";
                    cmd.Parameters.Add("@CDTIPODOC", SqlDbType.Char, 5).Value = "";
                    cmd.Parameters.Add("@NRODOCUMENTO", SqlDbType.Char, 15).Value = "";
                    cmd.Parameters.Add("@TIPO", SqlDbType.Char, 1).Value = 'E';
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            Emisor.detallesempresa = (drd.HasColumn("cabecera") ? drd["cabecera"] == DBNull.Value ? "" : drd["cabecera"].ToString() : "").Trim();
                            string[] detallado = Emisor.detallesempresa.Split('|');
                            foreach (string t in detallado)
                            {
                                if ((Regex.Replace(t, "[^0-9]", "")).Length == 11)
                                {
                                    Emisor.RUC = Regex.Replace(t, "[^0-9]", "");
                                }
                            }
                            Emisor.detallesempresa = Regex.Replace(Emisor.detallesempresa, "\\|", "\n");
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
            return Emisor;
        }
        public TS_BEDAnulaInput OBTENER_VENTAG_ESPECIFICO(TS_BEDAnulaInput input)
        {
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_DOCUMENTO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDTIPODOC", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@NRODOCUMENTO", SqlDbType.VarChar, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@NROSERIEMAQ", SqlDbType.VarChar, 10).Value = input.nroseriemaq;
                    cmd.Parameters.Add("@FECHA", SqlDbType.VarChar, 10).Value = "";
                    cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 1).Value = "E";
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        input.exists = drd.HasRows;

                        while (drd.Read())
                        {
                            input.cdlocal = drd["cdlocal"].ToString();
                            input.fecdocumento = Convert.ToDateTime(drd["fecdocumento"]);
                            input.anulado = Convert.ToBoolean(drd["anulado"]);
                            input.cerrado = Convert.ToBoolean(drd["cerrado"]);
                            input.nropos = drd["nropos"].ToString();
                            input.fecproceso = Convert.ToDateTime(drd["fecproceso"]);
                            input.fecha = drd["fecha"].ToString();
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
            return input;
        }

        public TS_BEReimpresionLOutput LISTAR_DOCUMENTOS_REIMPRESION(TS_BEReimpresionLInput input)
        {
            TS_BEReimpresionLOutput ListaDocumentos = new TS_BEReimpresionLOutput(new TS_BEMensaje("", false),new List<TS_BEReimpresionL>());

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_DOCUMENTOS_REIMPRESION", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NRODOCUMENTO", SqlDbType.VarChar, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@CDTIPODOC", SqlDbType.VarChar, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 20).Value = input.nropos; 
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BEReimpresionL Documento = new TS_BEReimpresionL();
                            Documento.nroseriemaq = (drd["nroseriemaq"].ToString() ?? "").Trim();
                            Documento.cdtipodoc = (drd["cdtipodoc"].ToString() ?? "").Trim();
                            Documento.tipodoc = (drd["tipodoc"].ToString() ?? "").Trim();
                            Documento.nrodocumento = (drd["nrodocumento"].ToString() ?? "").Trim();
                            Documento.fecdocumento = Convert.ToDateTime(drd["fecdocumento"]);
                            Documento.fecha = (drd["fecha"].ToString() ?? "").Trim();
                            Documento.nropos = (drd["nropos"].ToString() ?? "").Trim();
                            Documento.cdcliente  = (drd["cdcliente"].ToString() ?? "").Trim();
                            Documento.rscliente = (drd["rscliente"].ToString() ?? "").Trim();
                            Documento.estado = (drd["estado"].ToString() ?? "").Trim();
                            Documento.anulado = Convert.ToBoolean(drd["anulado"]);
                            ListaDocumentos.Documentos.Add(Documento);
                        }
                        ListaDocumentos.Mensaje.Ok = true;
                        if(ListaDocumentos.Documentos.Count == 0)
                        {
                            ListaDocumentos.Mensaje.mensaje = "No se encontraron documentos";
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
            return ListaDocumentos;
        }
    }

}


