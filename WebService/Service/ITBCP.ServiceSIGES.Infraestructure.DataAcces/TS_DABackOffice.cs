using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;

namespace ITBCP.ServiceSIGES.Infraestructure.DataAcces
{
      
    public class TS_DABackOffice : ITS_DOBackOffice
    {

        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public List<TS_BEVenta> SP_ITBCP_VENTA_CABECERA(TS_BEVenta input)
        {
            List<TS_BEVenta> lista = new List<TS_BEVenta>();
            TS_BEVenta output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_VENTA_CABECERA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                    cmd.Parameters.Add("@Turno", SqlDbType.Decimal, 5).Value = input.turno;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVenta();
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.fecanula = drd.HasColumn("fecanula") ? drd["fecanula"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanula"]) : (DateTime?)null;
                            output.fecanulasis = drd.HasColumn("fecanulasis") ? drd["fecanulasis"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanulasis"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.fecsistema = drd.HasColumn("fecsistema") ? drd["fecsistema"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecsistema"]) : (DateTime?)null;
                            output.flgmanual = drd.HasColumn("flgmanual") ? drd["flgmanual"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmanual"]) : false;
                            output.flgcierrez = drd.HasColumn("flgcierrez") ? drd["flgcierrez"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrez"]) : false;
                            output.flgmovimiento = drd.HasColumn("flgmovimiento") ? drd["flgmovimiento"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmovimiento"]) : false;
                            output.archturno = drd.HasColumn("archturno") ? drd["archturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["archturno"]) : false;
                            output.chkespecial = drd.HasColumn("chkespecial") ? drd["chkespecial"] == DBNull.Value ? false : Convert.ToBoolean(drd["chkespecial"]) : false;
                            output.rucinvalido = drd.HasColumn("rucinvalido") ? drd["rucinvalido"] == DBNull.Value ? false : Convert.ToBoolean(drd["rucinvalido"]) : false;
                            output.usadecimales = drd.HasColumn("usadecimales") ? drd["usadecimales"] == DBNull.Value ? false : Convert.ToBoolean(drd["usadecimales"]) : false;
                            output.fact_elect = drd.HasColumn("fact_elect") ? drd["fact_elect"] == DBNull.Value ? false : Convert.ToBoolean(drd["fact_elect"]) : false;
                            output.mtovueltosol = drd.HasColumn("mtovueltosol") ? drd["mtovueltosol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltosol"]) : (decimal?)null;
                            output.mtovueltodol = drd.HasColumn("mtovueltodol") ? drd["mtovueltodol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltodol"]) : (decimal?)null;
                            output.porservicio = drd.HasColumn("porservicio") ? drd["porservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porservicio"]) : (decimal?)null;
                            output.pordscto1 = drd.HasColumn("pordscto1") ? drd["pordscto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto1"]) : (decimal?)null;
                            output.pordscto2 = drd.HasColumn("pordscto2") ? drd["pordscto2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto2"]) : (decimal?)null;
                            output.pordscto3 = drd.HasColumn("pordscto3") ? drd["pordscto3"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto3"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcdetraccion"]) : (decimal?)null;
                            output.mtodetraccion = drd.HasColumn("mtodetraccion") ? drd["mtodetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodetraccion"]) : (decimal?)null;
                            output.precio_orig = drd.HasColumn("precio_orig") ? drd["precio_orig"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio_orig"]) : (decimal?)null;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valoracumula"]) : (decimal?)null;
                            output.cantcupon = drd.HasColumn("cantcupon") ? drd["cantcupon"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantcupon"]) : (decimal?)null;
                            output.mtocanje = drd.HasColumn("mtocanje") ? drd["mtocanje"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtocanje"]) : (decimal?)null;
                            output.mtopercepcion = drd.HasColumn("mtopercepcion") ? drd["mtopercepcion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopercepcion"]) : (decimal?)null;
                            output.redondea_indecopi = drd.HasColumn("redondea_indecopi") ? drd["redondea_indecopi"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["redondea_indecopi"]) : (decimal?)null;
                            output.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoimpuesto"]) : (decimal?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtototal"]) : (decimal?)null;
                            output.tcambio = drd.HasColumn("tcambio") ? drd["tcambio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["tcambio"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.mtorecaudo = drd.HasColumn("mtorecaudo") ? drd["mtorecaudo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtorecaudo"]) : (decimal?)null;
                            output.ptosganados = drd.HasColumn("ptosganados") ? drd["ptosganados"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ptosganados"]) : (decimal?)null;
                            output.pordsctoeq = drd.HasColumn("pordsctoeq") ? drd["pordsctoeq"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordsctoeq"]) : (decimal?)null;
                            output.mtonoafecto = drd.HasColumn("mtonoafecto") ? drd["mtonoafecto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtonoafecto"]) : (decimal?)null;
                            output.valorvta = drd.HasColumn("valorvta") ? drd["valorvta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorvta"]) : (decimal?)null;
                            output.mtodscto = drd.HasColumn("mtodscto") ? drd["mtodscto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodscto"]) : (decimal?)null;
                            output.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtosubtotal"]) : (decimal?)null;
                            output.mtoservicio = drd.HasColumn("mtoservicio") ? drd["mtoservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoservicio"]) : (decimal?)null;
                            output.nroplaca = drd.HasColumn("nroplaca") ? drd["nroplaca"] == DBNull.Value ? null : drd["nroplaca"].ToString() : null;
                            output.observacion = drd.HasColumn("observacion") ? drd["observacion"] == DBNull.Value ? null : drd["observacion"].ToString() : null;
                            output.referencia = drd.HasColumn("referencia") ? drd["referencia"] == DBNull.Value ? null : drd["referencia"].ToString() : null;
                            output.c_centralizacion = drd.HasColumn("c_centralizacion") ? drd["c_centralizacion"] == DBNull.Value ? null : drd["c_centralizacion"].ToString() : null;
                            output.codes = drd.HasColumn("codes") ? drd["codes"] == DBNull.Value ? null : drd["codes"].ToString() : null;
                            output.codeid = drd.HasColumn("codeid") ? drd["codeid"] == DBNull.Value ? null : drd["codeid"].ToString() : null;
                            output.mensaje1 = drd.HasColumn("mensaje1") ? drd["mensaje1"] == DBNull.Value ? null : drd["mensaje1"].ToString() : null;
                            output.mensaje2 = drd.HasColumn("mensaje2") ? drd["mensaje2"] == DBNull.Value ? null : drd["mensaje2"].ToString() : null;
                            output.pdf417 = drd.HasColumn("pdf417") ? drd["pdf417"] == DBNull.Value ? null : drd["pdf417"].ToString() : null;
                            output.cdhash = drd.HasColumn("cdhash") ? drd["cdhash"] == DBNull.Value ? null : drd["cdhash"].ToString() : null;
                            output.scop = drd.HasColumn("scop") ? drd["scop"] == DBNull.Value ? null : drd["scop"].ToString() : null;
                            output.nroguia = drd.HasColumn("nroguia") ? drd["nroguia"] == DBNull.Value ? null : drd["nroguia"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.nrocelular = drd.HasColumn("nrocelular") ? drd["nrocelular"] == DBNull.Value ? null : drd["nrocelular"].ToString() : null;
                            output.tipoacumula = drd.HasColumn("tipoacumula") ? drd["tipoacumula"] == DBNull.Value ? null : drd["tipoacumula"].ToString() : null;
                            output.cdruta = drd.HasColumn("cdruta") ? drd["cdruta"] == DBNull.Value ? null : drd["cdruta"].ToString() : null;
                            output.ctadetraccion = drd.HasColumn("ctadetraccion") ? drd["ctadetraccion"] == DBNull.Value ? null : drd["ctadetraccion"].ToString() : null;
                            output.cdmedio_pago = drd.HasColumn("cdmedio_pago") ? drd["cdmedio_pago"] == DBNull.Value ? null : drd["cdmedio_pago"].ToString() : null;
                            output.odometro = drd.HasColumn("odometro") ? drd["odometro"] == DBNull.Value ? null : drd["odometro"].ToString() : null;
                            output.marcavehic = drd.HasColumn("marcavehic") ? drd["marcavehic"] == DBNull.Value ? null : drd["marcavehic"].ToString() : null;
                            output.inscripcion = drd.HasColumn("inscripcion") ? drd["inscripcion"] == DBNull.Value ? null : drd["inscripcion"].ToString() : null;
                            output.chofer = drd.HasColumn("chofer") ? drd["chofer"] == DBNull.Value ? null : drd["chofer"].ToString() : null;
                            output.nrolicencia = drd.HasColumn("nrolicencia") ? drd["nrolicencia"] == DBNull.Value ? null : drd["nrolicencia"].ToString() : null;
                            output.tipoventa = drd.HasColumn("tipoventa") ? drd["tipoventa"] == DBNull.Value ? null : drd["tipoventa"].ToString() : null;
                            output.tipofactura = drd.HasColumn("tipofactura") ? drd["tipofactura"] == DBNull.Value ? null : drd["tipofactura"].ToString() : null;
                            output.nroocompra = drd.HasColumn("nroocompra") ? drd["nroocompra"] == DBNull.Value ? null : drd["nroocompra"].ToString() : null;
                            output.nroserie1 = drd.HasColumn("nroserie1") ? drd["nroserie1"] == DBNull.Value ? null : drd["nroserie1"].ToString() : null;
                            output.nroserie2 = drd.HasColumn("nroserie2") ? drd["nroserie2"] == DBNull.Value ? null : drd["nroserie2"].ToString() : null;
                            output.nrobonus = drd.HasColumn("nrobonus") ? drd["nrobonus"] == DBNull.Value ? null : drd["nrobonus"].ToString() : null;
                            output.nrotarjeta = drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? null : drd["nrotarjeta"].ToString() : null;
                            output.cdtranspor = drd.HasColumn("cdtranspor") ? drd["cdtranspor"] == DBNull.Value ? null : drd["cdtranspor"].ToString() : null;
                            output.drpartida = drd.HasColumn("drpartida") ? drd["drpartida"] == DBNull.Value ? null : drd["drpartida"].ToString() : null;
                            output.drdestino = drd.HasColumn("drdestino") ? drd["drdestino"] == DBNull.Value ? null : drd["drdestino"].ToString() : null;
                            output.cdusuario = drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString() : null;
                            output.cdvendedor = drd.HasColumn("cdvendedor") ? drd["cdvendedor"] == DBNull.Value ? null : drd["cdvendedor"].ToString() : null;
                            output.cdusuanula = drd.HasColumn("cdusuanula") ? drd["cdusuanula"] == DBNull.Value ? null : drd["cdusuanula"].ToString() : null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;
                            output.rscliente = drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? null : drd["rscliente"].ToString() : null;
                            output.nroproforma = drd.HasColumn("nroproforma") ? drd["nroproforma"] == DBNull.Value ? null : drd["nroproforma"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.cdmoneda = drd.HasColumn("cdmoneda") ? drd["cdmoneda"] == DBNull.Value ? null : drd["cdmoneda"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVariables> SP_ITBCP_VALIDAR_OPCION_PRINT_PANTALLA_OR_FISICO(TS_BEVariables input)
        {
            List<TS_BEVariables> lista = new List<TS_BEVariables>();
            TS_BEVariables output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_VALIDAR_OPCION_PRINT_PANTALLA_OR_FISICO", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVariables();
                            output.varid = drd.HasColumn("varid") ? drd["varid"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["varid"]) : (int?)null;
                            output.valorpto = drd.HasColumn("valorpto") ? drd["valorpto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["valorpto"]) : (double?)null;
                            output.flgelimina = drd.HasColumn("flgelimina") ? drd["flgelimina"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgelimina"]) : false;
                            output.tipovar = drd.HasColumn("tipovar") ? drd["tipovar"] == DBNull.Value ? null : drd["tipovar"].ToString() : null;
                            output.clave = drd.HasColumn("clave") ? drd["clave"] == DBNull.Value ? null : drd["clave"].ToString() : null;
                            output.descripcion = drd.HasColumn("descripcion") ? drd["descripcion"] == DBNull.Value ? null : drd["descripcion"].ToString() : null;
                            output.config = drd.HasColumn("config") ? drd["config"] == DBNull.Value ? null : drd["config"].ToString() : null;
                            output.valor = drd.HasColumn("valor") ? drd["valor"] == DBNull.Value ? null : drd["valor"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVariables> SP_ITBCP_OBTENER_TOPES_MONTO_VENTA(TS_BEVariables input)
        {
            List<TS_BEVariables> lista = new List<TS_BEVariables>();
            TS_BEVariables output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_TOPES_MONTO_VENTA", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVariables();
                            output.varid = drd.HasColumn("varid") ? drd["varid"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["varid"]) : (int?)null;
                            output.valorpto = drd.HasColumn("valorpto") ? drd["valorpto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["valorpto"]) : (double?)null;
                            output.flgelimina = drd.HasColumn("flgelimina") ? drd["flgelimina"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgelimina"]) : false;
                            output.tipovar = drd.HasColumn("tipovar") ? drd["tipovar"] == DBNull.Value ? null : drd["tipovar"].ToString() : null;
                            output.clave = drd.HasColumn("clave") ? drd["clave"] == DBNull.Value ? null : drd["clave"].ToString() : null;
                            output.descripcion = drd.HasColumn("descripcion") ? drd["descripcion"] == DBNull.Value ? null : drd["descripcion"].ToString() : null;
                            output.config = drd.HasColumn("config") ? drd["config"] == DBNull.Value ? null : drd["config"].ToString() : null;
                            output.valor = drd.HasColumn("valor") ? drd["valor"] == DBNull.Value ? null : drd["valor"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVariables> SP_ITBCP_OBTENER_TIPO_INGRESO(TS_BEVariables input)
        {
            List<TS_BEVariables> lista = new List<TS_BEVariables>();
            TS_BEVariables output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_TIPO_INGRESO", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVariables();
                            output.varid = drd.HasColumn("varid") ? drd["varid"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["varid"]) : (int?)null;
                            output.valorpto = drd.HasColumn("valorpto") ? drd["valorpto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["valorpto"]) : (double?)null;
                            output.flgelimina = drd.HasColumn("flgelimina") ? drd["flgelimina"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgelimina"]) : false;
                            output.tipovar = drd.HasColumn("tipovar") ? drd["tipovar"] == DBNull.Value ? null : drd["tipovar"].ToString() : null;
                            output.clave = drd.HasColumn("clave") ? drd["clave"] == DBNull.Value ? null : drd["clave"].ToString() : null;
                            output.descripcion = drd.HasColumn("descripcion") ? drd["descripcion"] == DBNull.Value ? null : drd["descripcion"].ToString() : null;
                            output.config = drd.HasColumn("config") ? drd["config"] == DBNull.Value ? null : drd["config"].ToString() : null;
                            output.valor = drd.HasColumn("valor") ? drd["valor"] == DBNull.Value ? null : drd["valor"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BERuta> SP_ITBCP_OBTENER_RUTA(TS_BERuta input)
        {
            List<TS_BERuta> lista = new List<TS_BERuta>();
            TS_BERuta output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_RUTA", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BERuta();
                            output.dsruta = drd.HasColumn("dsruta") ? drd["dsruta"] == DBNull.Value ? null : drd["dsruta"].ToString() : null;
                            output.cdruta = drd.HasColumn("cdruta") ? drd["cdruta"] == DBNull.Value ? null : drd["cdruta"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEDescuento> SP_ITBCP_OBTENER_PORCENTAJE_DSCTO(TS_BEDescuento input)
        {
            List<TS_BEDescuento> lista = new List<TS_BEDescuento>();
            TS_BEDescuento output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_PORCENTAJE_DSCTO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = input.cdarticulo;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Decimal, 5).Value = input.cantidad;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEDescuento();
                            output.nroitem = drd.HasColumn("nroitem") ? drd["nroitem"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nroitem"]) : (decimal?)null;
                            output.cantidad1 = drd.HasColumn("cantidad1") ? drd["cantidad1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantidad1"]) : (decimal?)null;
                            output.cantidad2 = drd.HasColumn("cantidad2") ? drd["cantidad2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantidad2"]) : (decimal?)null;
                            output.porcentaje = drd.HasColumn("porcentaje") ? drd["porcentaje"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcentaje"]) : (decimal?)null;
                            output.descuento = drd.HasColumn("descuento") ? drd["descuento"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["descuento"]) : (decimal?)null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public TS_BELocal SP_ITBCP_OBTENER_LOCAL(TS_BELocal input)
        {
            TS_BELocal output = new TS_BELocal();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_LOCAL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 4).Value = input.cdlocal;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output.nro_centralizacion = drd.HasColumn("nro_centralizacion") ? drd["nro_centralizacion"] == DBNull.Value ? null : drd["nro_centralizacion"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.dslocal = drd.HasColumn("dslocal") ? drd["dslocal"] == DBNull.Value ? null : drd["dslocal"].ToString() : null;
                            output.drlocal = drd.HasColumn("drlocal") ? drd["drlocal"] == DBNull.Value ? null : drd["drlocal"].ToString() : null;
                            output.tlflocal = drd.HasColumn("tlflocal") ? drd["tlflocal"] == DBNull.Value ? null : drd["tlflocal"].ToString() : null;
                            output.tlflocal1 = drd.HasColumn("tlflocal1") ? drd["tlflocal1"] == DBNull.Value ? null : drd["tlflocal1"].ToString() : null;
                            output.cdzona = drd.HasColumn("cdzona") ? drd["cdzona"] == DBNull.Value ? null : drd["cdzona"].ToString() : null;
                            output.cdsunat = drd.HasColumn("cdsunat") ? drd["cdsunat"] == DBNull.Value ? null : drd["cdsunat"].ToString() : null;
                            output.dislocal = drd.HasColumn("dislocal") ? drd["dislocal"] == DBNull.Value ? null : drd["dislocal"].ToString() : null;
                            output.provlocal = drd.HasColumn("provlocal") ? drd["provlocal"] == DBNull.Value ? null : drd["provlocal"].ToString() : null;
                            output.deplocal = drd.HasColumn("deplocal") ? drd["deplocal"] == DBNull.Value ? null : drd["deplocal"].ToString() : null;
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
            return output;
        }
         

        public List<TS_BEAlmacen> SP_ITBCP_OBTENER_ALMACEN(TS_BEAlmacen input)
        {
            List<TS_BEAlmacen> lista = new List<TS_BEAlmacen>();
            TS_BEAlmacen output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_ALMACEN", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEAlmacen();
                            output.fecinventario = drd.HasColumn("fecinventario") ? drd["fecinventario"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinventario"]) : (DateTime?)null;
                            output.inventario = drd.HasColumn("inventario") ? drd["inventario"] == DBNull.Value ? false : Convert.ToBoolean(drd["inventario"]) : false;
                            output.activo = drd.HasColumn("activo") ? drd["activo"] == DBNull.Value ? false : Convert.ToBoolean(drd["activo"]) : false;
                            output.daalmacen = drd.HasColumn("daalmacen") ? drd["daalmacen"] == DBNull.Value ? null : drd["daalmacen"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.dsalmacen = drd.HasColumn("dsalmacen") ? drd["dsalmacen"] == DBNull.Value ? null : drd["dsalmacen"].ToString() : null;
                            output.tipo = drd.HasColumn("tipo") ? drd["tipo"] == DBNull.Value ? null : drd["tipo"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BETerminal> SP_ITBCP_LSITAR_TERMINAL_POR_USUARIO(TS_BETerminal input)
        {
            List<TS_BETerminal> lista = new List<TS_BETerminal>();
            TS_BETerminal output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LSITAR_TERMINAL_POR_USUARIO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@seriehd", SqlDbType.Char, 2).Value = input.seriehd;
                    cmd.Parameters.Add("@cdusuario", SqlDbType.Char, 2).Value = input.cdusuario;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BETerminal();
                            output.conexion_dispensador = drd.HasColumn("conexion_dispensador") ? drd["conexion_dispensador"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["conexion_dispensador"]) : (byte?)null;
                            output.fe_idpos = drd.HasColumn("fe_idpos") ? drd["fe_idpos"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["fe_idpos"]) : (int?)null;
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.tktfactura = drd.HasColumn("tktfactura") ? drd["tktfactura"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktfactura"]) : false;
                            output.tktboleta = drd.HasColumn("tktboleta") ? drd["tktboleta"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktboleta"]) : false;
                            output.tktpromocion = drd.HasColumn("tktpromocion") ? drd["tktpromocion"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktpromocion"]) : false;
                            output.facturapreimpre = drd.HasColumn("facturapreimpre") ? drd["facturapreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["facturapreimpre"]) : false;
                            output.boletapreimpre = drd.HasColumn("boletapreimpre") ? drd["boletapreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["boletapreimpre"]) : false;
                            output.promocionpreimpre = drd.HasColumn("promocionpreimpre") ? drd["promocionpreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["promocionpreimpre"]) : false;
                            output.activa_boton_playa = drd.HasColumn("activa_boton_playa") ? drd["activa_boton_playa"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_boton_playa"]) : false;
                            output.flg_pdf417 = drd.HasColumn("flg_pdf417") ? drd["flg_pdf417"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pdf417"]) : false;
                            output.flg_nc_correlativo = drd.HasColumn("flg_nc_correlativo") ? drd["flg_nc_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nc_correlativo"]) : false;
                            output.flg_nd_correlativo = drd.HasColumn("flg_nd_correlativo") ? drd["flg_nd_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nd_correlativo"]) : false;
                            output.flg_print_qr = drd.HasColumn("flg_print_qr") ? drd["flg_print_qr"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_print_qr"]) : false;
                            output.flg_formato_a4 = drd.HasColumn("flg_formato_a4") ? drd["flg_formato_a4"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_formato_a4"]) : false;
                            output.rucinvalido = drd.HasColumn("rucinvalido") ? drd["rucinvalido"] == DBNull.Value ? false : Convert.ToBoolean(drd["rucinvalido"]) : false;
                            output._virtual = drd.HasColumn("virtual") ? drd["virtual"] == DBNull.Value ? false : Convert.ToBoolean(drd["virtual"]) : false;
                            output.tktnotadespacho = drd.HasColumn("tktnotadespacho") ? drd["tktnotadespacho"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktnotadespacho"]) : false;
                            output.flgtransferencia = drd.HasColumn("flgtransferencia") ? drd["flgtransferencia"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgtransferencia"]) : false;
                            output.playa_formasdepago = drd.HasColumn("playa_formasdepago") ? drd["playa_formasdepago"] == DBNull.Value ? false : Convert.ToBoolean(drd["playa_formasdepago"]) : false;
                            output.modif_corr = drd.HasColumn("modif_corr") ? drd["modif_corr"] == DBNull.Value ? false : Convert.ToBoolean(drd["modif_corr"]) : false;
                            output.flgpagotarjeta = drd.HasColumn("flgpagotarjeta") ? drd["flgpagotarjeta"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagotarjeta"]) : false;
                            output.flgpagocheque = drd.HasColumn("flgpagocheque") ? drd["flgpagocheque"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagocheque"]) : false;
                            output.flgpagocredito = drd.HasColumn("flgpagocredito") ? drd["flgpagocredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagocredito"]) : false;
                            output.flgpagoncredito = drd.HasColumn("flgpagoncredito") ? drd["flgpagoncredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagoncredito"]) : false;
                            output.flgvalidaz = drd.HasColumn("flgvalidaz") ? drd["flgvalidaz"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgvalidaz"]) : false;
                            output.flgcierrezok = drd.HasColumn("flgcierrezok") ? drd["flgcierrezok"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrezok"]) : false;
                            output.flghotkey = drd.HasColumn("flghotkey") ? drd["flghotkey"] == DBNull.Value ? false : Convert.ToBoolean(drd["flghotkey"]) : false;
                            output.flgfacturacion = drd.HasColumn("flgfacturacion") ? drd["flgfacturacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgfacturacion"]) : false;
                            output.grabarcliente = drd.HasColumn("grabarcliente") ? drd["grabarcliente"] == DBNull.Value ? false : Convert.ToBoolean(drd["grabarcliente"]) : false;
                            output.flgautomatica = drd.HasColumn("flgautomatica") ? drd["flgautomatica"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgautomatica"]) : false;
                            output.flgaperturacaja = drd.HasColumn("flgaperturacaja") ? drd["flgaperturacaja"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgaperturacaja"]) : false;
                            output.flgpagoefectivo = drd.HasColumn("flgpagoefectivo") ? drd["flgpagoefectivo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagoefectivo"]) : false;
                            output.modocompra = drd.HasColumn("modocompra") ? drd["modocompra"] == DBNull.Value ? false : Convert.ToBoolean(drd["modocompra"]) : false;
                            output.modservicio = drd.HasColumn("modservicio") ? drd["modservicio"] == DBNull.Value ? false : Convert.ToBoolean(drd["modservicio"]) : false;
                            output.modobservacion = drd.HasColumn("modobservacion") ? drd["modobservacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["modobservacion"]) : false;
                            output.moddsctogral = drd.HasColumn("moddsctogral") ? drd["moddsctogral"] == DBNull.Value ? false : Convert.ToBoolean(drd["moddsctogral"]) : false;
                            output.moddsctoitem = drd.HasColumn("moddsctoitem") ? drd["moddsctoitem"] == DBNull.Value ? false : Convert.ToBoolean(drd["moddsctoitem"]) : false;
                            output.preciocero = drd.HasColumn("preciocero") ? drd["preciocero"] == DBNull.Value ? false : Convert.ToBoolean(drd["preciocero"]) : false;
                            output.modfecha = drd.HasColumn("modfecha") ? drd["modfecha"] == DBNull.Value ? false : Convert.ToBoolean(drd["modfecha"]) : false;
                            output.modmoneda = drd.HasColumn("modmoneda") ? drd["modmoneda"] == DBNull.Value ? false : Convert.ToBoolean(drd["modmoneda"]) : false;
                            output.modvendedor = drd.HasColumn("modvendedor") ? drd["modvendedor"] == DBNull.Value ? false : Convert.ToBoolean(drd["modvendedor"]) : false;
                            output.modalmacen = drd.HasColumn("modalmacen") ? drd["modalmacen"] == DBNull.Value ? false : Convert.ToBoolean(drd["modalmacen"]) : false;
                            output.modlistap = drd.HasColumn("modlistap") ? drd["modlistap"] == DBNull.Value ? false : Convert.ToBoolean(drd["modlistap"]) : false;
                            output.modprecio = drd.HasColumn("modprecio") ? drd["modprecio"] == DBNull.Value ? false : Convert.ToBoolean(drd["modprecio"]) : false;
                            output.nrozeta = drd.HasColumn("nrozeta") ? drd["nrozeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrozeta"]) : (decimal?)null;
                            output.mtozeta = drd.HasColumn("mtozeta") ? drd["mtozeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtozeta"]) : (decimal?)null;
                            output.ticketfeed = drd.HasColumn("ticketfeed") ? drd["ticketfeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticketfeed"]) : (decimal?)null;
                            output.ticketlineacorte = drd.HasColumn("ticketlineacorte") ? drd["ticketlineacorte"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticketlineacorte"]) : (decimal?)null;
                            output.ticket2columnas = drd.HasColumn("ticket2columnas") ? drd["ticket2columnas"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticket2columnas"]) : (decimal?)null;
                            output.nventafeed = drd.HasColumn("nventafeed") ? drd["nventafeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nventafeed"]) : (decimal?)null;
                            output.promocionfeed = drd.HasColumn("promocionfeed") ? drd["promocionfeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["promocionfeed"]) : (decimal?)null;
                            output.mtodsctomax = drd.HasColumn("mtodsctomax") ? drd["mtodsctomax"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodsctomax"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.tranvirtual = drd.HasColumn("tranvirtual") ? drd["tranvirtual"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["tranvirtual"]) : (decimal?)null;
                            output.nrodeposito = drd.HasColumn("nrodeposito") ? drd["nrodeposito"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrodeposito"]) : (decimal?)null;
                            output.facturaimpre = drd.HasColumn("facturaimpre") ? drd["facturaimpre"] == DBNull.Value ? null : drd["facturaimpre"].ToString() : null;
                            output.boletaimpre = drd.HasColumn("boletaimpre") ? drd["boletaimpre"] == DBNull.Value ? null : drd["boletaimpre"].ToString() : null;
                            output.gavetachr = drd.HasColumn("gavetachr") ? drd["gavetachr"] == DBNull.Value ? null : drd["gavetachr"].ToString() : null;
                            output.promocionimpre = drd.HasColumn("promocionimpre") ? drd["promocionimpre"] == DBNull.Value ? null : drd["promocionimpre"].ToString() : null;
                            output.ncreditoimpre = drd.HasColumn("ncreditoimpre") ? drd["ncreditoimpre"] == DBNull.Value ? null : drd["ncreditoimpre"].ToString() : null;
                            output.ndebitoimpre = drd.HasColumn("ndebitoimpre") ? drd["ndebitoimpre"] == DBNull.Value ? null : drd["ndebitoimpre"].ToString() : null;
                            output.guiaimpre = drd.HasColumn("guiaimpre") ? drd["guiaimpre"] == DBNull.Value ? null : drd["guiaimpre"].ToString() : null;
                            output.proformaimpre = drd.HasColumn("proformaimpre") ? drd["proformaimpre"] == DBNull.Value ? null : drd["proformaimpre"].ToString() : null;
                            output.letraimpre = drd.HasColumn("letraimpre") ? drd["letraimpre"] == DBNull.Value ? null : drd["letraimpre"].ToString() : null;
                            output.path_loteria = drd.HasColumn("path_loteria") ? drd["path_loteria"] == DBNull.Value ? null : drd["path_loteria"].ToString() : null;
                            output.fe_nompos = drd.HasColumn("fe_nompos") ? drd["fe_nompos"] == DBNull.Value ? null : drd["fe_nompos"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdusuario = drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString() : null;
                            output.seriehd = drd.HasColumn("seriehd") ? drd["seriehd"] == DBNull.Value ? null : drd["seriehd"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.nroserie1 = drd.HasColumn("nroserie1") ? drd["nroserie1"] == DBNull.Value ? null : drd["nroserie1"].ToString() : null;
                            output.nroserie2 = drd.HasColumn("nroserie2") ? drd["nroserie2"] == DBNull.Value ? null : drd["nroserie2"].ToString() : null;
                            output.tipoterminal = drd.HasColumn("tipoterminal") ? drd["tipoterminal"] == DBNull.Value ? null : drd["tipoterminal"].ToString() : null;
                            output.ticketfactura = drd.HasColumn("ticketfactura") ? drd["ticketfactura"] == DBNull.Value ? null : drd["ticketfactura"].ToString() : null;
                            output.ncreditoboleta = drd.HasColumn("ncreditoboleta") ? drd["ncreditoboleta"] == DBNull.Value ? null : drd["ncreditoboleta"].ToString() : null;
                            output.ndebitoboleta = drd.HasColumn("ndebitoboleta") ? drd["ndebitoboleta"] == DBNull.Value ? null : drd["ndebitoboleta"].ToString() : null;
                            output.guiafmt = drd.HasColumn("guiafmt") ? drd["guiafmt"] == DBNull.Value ? null : drd["guiafmt"].ToString() : null;
                            output.proforma = drd.HasColumn("proforma") ? drd["proforma"] == DBNull.Value ? null : drd["proforma"].ToString() : null;
                            output.proformafmt = drd.HasColumn("proformafmt") ? drd["proformafmt"] == DBNull.Value ? null : drd["proformafmt"].ToString() : null;
                            output.letra = drd.HasColumn("letra") ? drd["letra"] == DBNull.Value ? null : drd["letra"].ToString() : null;
                            output.letrafmt = drd.HasColumn("letrafmt") ? drd["letrafmt"] == DBNull.Value ? null : drd["letrafmt"].ToString() : null;
                            output.displayimpre = drd.HasColumn("displayimpre") ? drd["displayimpre"] == DBNull.Value ? null : drd["displayimpre"].ToString() : null;
                            output.promocionchrfin = drd.HasColumn("promocionchrfin") ? drd["promocionchrfin"] == DBNull.Value ? null : drd["promocionchrfin"].ToString() : null;
                            output.ncredito = drd.HasColumn("ncredito") ? drd["ncredito"] == DBNull.Value ? null : drd["ncredito"].ToString() : null;
                            output.ncreditofmt = drd.HasColumn("ncreditofmt") ? drd["ncreditofmt"] == DBNull.Value ? null : drd["ncreditofmt"].ToString() : null;
                            output.ndebito = drd.HasColumn("ndebito") ? drd["ndebito"] == DBNull.Value ? null : drd["ndebito"].ToString() : null;
                            output.ndebitofmt = drd.HasColumn("ndebitofmt") ? drd["ndebitofmt"] == DBNull.Value ? null : drd["ndebitofmt"].ToString() : null;
                            output.guia = drd.HasColumn("guia") ? drd["guia"] == DBNull.Value ? null : drd["guia"].ToString() : null;
                            output.nventaimpre = drd.HasColumn("nventaimpre") ? drd["nventaimpre"] == DBNull.Value ? null : drd["nventaimpre"].ToString() : null;
                            output.nventachrini = drd.HasColumn("nventachrini") ? drd["nventachrini"] == DBNull.Value ? null : drd["nventachrini"].ToString() : null;
                            output.nventachrfin = drd.HasColumn("nventachrfin") ? drd["nventachrfin"] == DBNull.Value ? null : drd["nventachrfin"].ToString() : null;
                            output.promocion = drd.HasColumn("promocion") ? drd["promocion"] == DBNull.Value ? null : drd["promocion"].ToString() : null;
                            output.promocionfmt = drd.HasColumn("promocionfmt") ? drd["promocionfmt"] == DBNull.Value ? null : drd["promocionfmt"].ToString() : null;
                            output.promocionchrini = drd.HasColumn("promocionchrini") ? drd["promocionchrini"] == DBNull.Value ? null : drd["promocionchrini"].ToString() : null;
                            output.gavetaimpre = drd.HasColumn("gavetaimpre") ? drd["gavetaimpre"] == DBNull.Value ? null : drd["gavetaimpre"].ToString() : null;
                            output.ticket = drd.HasColumn("ticket") ? drd["ticket"] == DBNull.Value ? null : drd["ticket"].ToString() : null;
                            output.ticketimpre = drd.HasColumn("ticketimpre") ? drd["ticketimpre"] == DBNull.Value ? null : drd["ticketimpre"].ToString() : null;
                            output.ticketchrini = drd.HasColumn("ticketchrini") ? drd["ticketchrini"] == DBNull.Value ? null : drd["ticketchrini"].ToString() : null;
                            output.ticketchrfin = drd.HasColumn("ticketchrfin") ? drd["ticketchrfin"] == DBNull.Value ? null : drd["ticketchrfin"].ToString() : null;
                            output.nventa = drd.HasColumn("nventa") ? drd["nventa"] == DBNull.Value ? null : drd["nventa"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.factura = drd.HasColumn("factura") ? drd["factura"] == DBNull.Value ? null : drd["factura"].ToString() : null;
                            output.facturafmt = drd.HasColumn("facturafmt") ? drd["facturafmt"] == DBNull.Value ? null : drd["facturafmt"].ToString() : null;
                            output.boleta = drd.HasColumn("boleta") ? drd["boleta"] == DBNull.Value ? null : drd["boleta"].ToString() : null;
                            output.boletafmt = drd.HasColumn("boletafmt") ? drd["boletafmt"] == DBNull.Value ? null : drd["boletafmt"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

     

        public List<TS_BEZona> SP_ITBCP_LISTAR_ZONAS(TS_BEZona input)
        {
            List<TS_BEZona> lista = new List<TS_BEZona>();
            TS_BEZona output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_ZONAS", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEZona();
                            output.dazona = drd.HasColumn("dazona") ? drd["dazona"] == DBNull.Value ? null : drd["dazona"].ToString() : null;
                            output.cdzona = drd.HasColumn("cdzona") ? drd["cdzona"] == DBNull.Value ? null : drd["cdzona"].ToString() : null;
                            output.dszona = drd.HasColumn("dszona") ? drd["dszona"] == DBNull.Value ? null : drd["dszona"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVw_Puntos_Por_Tarjeta> SP_ITBCP_LISTAR_VISTA_PUNTOS_TARJETA(TS_BEVw_Puntos_Por_Tarjeta input)
        {
            List<TS_BEVw_Puntos_Por_Tarjeta> lista = new List<TS_BEVw_Puntos_Por_Tarjeta>();
            TS_BEVw_Puntos_Por_Tarjeta output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VISTA_PUNTOS_TARJETA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdArticulo", SqlDbType.Char, 20).Value = input.cdarticulo;
                    cmd.Parameters.Add("@TarjAfiliacion", SqlDbType.VarChar, 25).Value = input.tarjafiliacion;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVw_Puntos_Por_Tarjeta();
                            output.valorid = drd.HasColumn("valorid") ? drd["valorid"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["valorid"]) : (int?)null;
                            output.valorpunto = drd.HasColumn("valorpunto") ? drd["valorpunto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["valorpunto"]) : (double?)null;
                            output.tipovar = drd.HasColumn("tipovar") ? drd["tipovar"] == DBNull.Value ? null : drd["tipovar"].ToString() : null;
                            output.descripcion = drd.HasColumn("descripcion") ? drd["descripcion"] == DBNull.Value ? null : drd["descripcion"].ToString() : null;
                            output.ctipo_punto = drd.HasColumn("ctipo_punto") ? drd["ctipo_punto"] == DBNull.Value ? null : drd["ctipo_punto"].ToString() : null;
                            output.expr1 = drd.HasColumn("expr1") ? drd["expr1"] == DBNull.Value ? null : drd["expr1"].ToString() : null;
                            output.tarjafiliacion = drd.HasColumn("tarjafiliacion") ? drd["tarjafiliacion"] == DBNull.Value ? null : drd["tarjafiliacion"].ToString() : null;
                            output.cdgrupo02 = drd.HasColumn("cdgrupo02") ? drd["cdgrupo02"] == DBNull.Value ? null : drd["cdgrupo02"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.dsarticulo = drd.HasColumn("dsarticulo") ? drd["dsarticulo"] == DBNull.Value ? null : drd["dsarticulo"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVentap> SP_ITBCP_LISTAR_VENTAP_2(TS_BEVentap input)
        {
            List<TS_BEVentap> lista = new List<TS_BEVentap>();
            TS_BEVentap output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VENTAP_2", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVentap();
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.flgcierrez = drd.HasColumn("flgcierrez") ? drd["flgcierrez"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrez"]) : false;
                            output.mtopagosol = drd.HasColumn("mtopagosol") ? drd["mtopagosol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopagosol"]) : (decimal?)null;
                            output.mtopagodol = drd.HasColumn("mtopagodol") ? drd["mtopagodol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopagodol"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valoracumula"]) : (decimal?)null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.cdtppago = drd.HasColumn("cdtppago") ? drd["cdtppago"] == DBNull.Value ? null : drd["cdtppago"].ToString() : null;
                            output.cdbanco = drd.HasColumn("cdbanco") ? drd["cdbanco"] == DBNull.Value ? null : drd["cdbanco"].ToString() : null;
                            output.nrocuenta = drd.HasColumn("nrocuenta") ? drd["nrocuenta"] == DBNull.Value ? null : drd["nrocuenta"].ToString() : null;
                            output.nrocheque = drd.HasColumn("nrocheque") ? drd["nrocheque"] == DBNull.Value ? null : drd["nrocheque"].ToString() : null;
                            output.cdtarjeta = drd.HasColumn("cdtarjeta") ? drd["cdtarjeta"] == DBNull.Value ? null : drd["cdtarjeta"].ToString() : null;
                            output.nrotarjeta = drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? null : drd["nrotarjeta"].ToString() : null;
                            output.nroncredito = drd.HasColumn("nroncredito") ? drd["nroncredito"] == DBNull.Value ? null : drd["nroncredito"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVentap> SP_ITBCP_LISTAR_VENTAP_1(TS_BEVentap input)
        {
            List<TS_BEVentap> lista = new List<TS_BEVentap>();
            TS_BEVentap output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VENTAP_1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVentap();
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.flgcierrez = drd.HasColumn("flgcierrez") ? drd["flgcierrez"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrez"]) : false;
                            output.mtopagosol = drd.HasColumn("mtopagosol") ? drd["mtopagosol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopagosol"]) : (decimal?)null;
                            output.mtopagodol = drd.HasColumn("mtopagodol") ? drd["mtopagodol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopagodol"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valoracumula"]) : (decimal?)null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.cdtppago = drd.HasColumn("cdtppago") ? drd["cdtppago"] == DBNull.Value ? null : drd["cdtppago"].ToString() : null;
                            output.cdbanco = drd.HasColumn("cdbanco") ? drd["cdbanco"] == DBNull.Value ? null : drd["cdbanco"].ToString() : null;
                            output.nrocuenta = drd.HasColumn("nrocuenta") ? drd["nrocuenta"] == DBNull.Value ? null : drd["nrocuenta"].ToString() : null;
                            output.nrocheque = drd.HasColumn("nrocheque") ? drd["nrocheque"] == DBNull.Value ? null : drd["nrocheque"].ToString() : null;
                            output.cdtarjeta = drd.HasColumn("cdtarjeta") ? drd["cdtarjeta"] == DBNull.Value ? null : drd["cdtarjeta"].ToString() : null;
                            output.nrotarjeta = drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? null : drd["nrotarjeta"].ToString() : null;
                            output.nroncredito = drd.HasColumn("nroncredito") ? drd["nroncredito"] == DBNull.Value ? null : drd["nroncredito"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVentap> SP_ITBCP_LISTAR_VENTAP(TS_BEVentap input)
        {
            List<TS_BEVentap> lista = new List<TS_BEVentap>();
            TS_BEVentap output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VENTAP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                    cmd.Parameters.Add("@Turno", SqlDbType.Decimal, 5).Value = input.turno;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVentap();
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.flgcierrez = drd.HasColumn("flgcierrez") ? drd["flgcierrez"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrez"]) : false;
                            output.mtopagosol = drd.HasColumn("mtopagosol") ? drd["mtopagosol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopagosol"]) : (decimal?)null;
                            output.mtopagodol = drd.HasColumn("mtopagodol") ? drd["mtopagodol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopagodol"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valoracumula"]) : (decimal?)null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.cdtppago = drd.HasColumn("cdtppago") ? drd["cdtppago"] == DBNull.Value ? null : drd["cdtppago"].ToString() : null;
                            output.cdbanco = drd.HasColumn("cdbanco") ? drd["cdbanco"] == DBNull.Value ? null : drd["cdbanco"].ToString() : null;
                            output.nrocuenta = drd.HasColumn("nrocuenta") ? drd["nrocuenta"] == DBNull.Value ? null : drd["nrocuenta"].ToString() : null;
                            output.nrocheque = drd.HasColumn("nrocheque") ? drd["nrocheque"] == DBNull.Value ? null : drd["nrocheque"].ToString() : null;
                            output.cdtarjeta = drd.HasColumn("cdtarjeta") ? drd["cdtarjeta"] == DBNull.Value ? null : drd["cdtarjeta"].ToString() : null;
                            output.nrotarjeta = drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? null : drd["nrotarjeta"].ToString() : null;
                            output.nroncredito = drd.HasColumn("nroncredito") ? drd["nroncredito"] == DBNull.Value ? null : drd["nroncredito"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVentad> SP_ITBCP_LISTAR_VENTAD_2(TS_BEVentad input)
        {
            List<TS_BEVentad> lista = new List<TS_BEVentad>();
            TS_BEVentad output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VENTAD_2", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVentad();
                            output.glosa = drd.HasColumn("glosa") ? drd["glosa"] == DBNull.Value ? null : drd["glosa"].ToString() : null;
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.flgcierrez = drd.HasColumn("flgcierrez") ? drd["flgcierrez"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrez"]) : false;
                            output.moverstock = drd.HasColumn("moverstock") ? drd["moverstock"] == DBNull.Value ? false : Convert.ToBoolean(drd["moverstock"]) : false;
                            output.archturno = drd.HasColumn("archturno") ? drd["archturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["archturno"]) : false;
                            output.trfgratuita = drd.HasColumn("trfgratuita") ? drd["trfgratuita"] == DBNull.Value ? false : Convert.ToBoolean(drd["trfgratuita"]) : false;
                            output.nroitem = drd.HasColumn("nroitem") ? drd["nroitem"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nroitem"]) : (decimal?)null;
                            output.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["impuesto"]) : (decimal?)null;
                            output.pordscto1 = drd.HasColumn("pordscto1") ? drd["pordscto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto1"]) : (decimal?)null;
                            output.pordscto2 = drd.HasColumn("pordscto2") ? drd["pordscto2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto2"]) : (decimal?)null;
                            output.pordscto3 = drd.HasColumn("pordscto3") ? drd["pordscto3"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto3"]) : (decimal?)null;
                            output.pordsctoeq = drd.HasColumn("pordsctoeq") ? drd["pordsctoeq"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordsctoeq"]) : (decimal?)null;
                            output.redondea_indecopi = drd.HasColumn("redondea_indecopi") ? drd["redondea_indecopi"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["redondea_indecopi"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcdetraccion"]) : (decimal?)null;
                            output.mtodetraccion = drd.HasColumn("mtodetraccion") ? drd["mtodetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodetraccion"]) : (decimal?)null;
                            output.precio_orig = drd.HasColumn("precio_orig") ? drd["precio_orig"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio_orig"]) : (decimal?)null;
                            output.ptosganados = drd.HasColumn("ptosganados") ? drd["ptosganados"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ptosganados"]) : (decimal?)null;
                            output.precioafiliacion = drd.HasColumn("precioafiliacion") ? drd["precioafiliacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precioafiliacion"]) : (decimal?)null;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valoracumula"]) : (decimal?)null;
                            output.costo_venta = drd.HasColumn("costo_venta") ? drd["costo_venta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["costo_venta"]) : (decimal?)null;
                            output.mtopercepcion = drd.HasColumn("mtopercepcion") ? drd["mtopercepcion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopercepcion"]) : (decimal?)null;
                            output.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtosubtotal"]) : (decimal?)null;
                            output.mtoservicio = drd.HasColumn("mtoservicio") ? drd["mtoservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoservicio"]) : (decimal?)null;
                            output.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoimpuesto"]) : (decimal?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtototal"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? null : drd["turno"].ToString() : null;
                            output.costo = drd.HasColumn("costo") ? drd["costo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["costo"]) : (decimal?)null;
                            output.cantidad = drd.HasColumn("cantidad") ? drd["cantidad"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantidad"]) : (decimal?)null;
                            output.cant_ncredito = drd.HasColumn("cant_ncredito") ? drd["cant_ncredito"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cant_ncredito"]) : (decimal?)null;
                            output.precio = drd.HasColumn("precio") ? drd["precio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio"]) : (decimal?)null;
                            output.mtonoafecto = drd.HasColumn("mtonoafecto") ? drd["mtonoafecto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtonoafecto"]) : (decimal?)null;
                            output.valorvta = drd.HasColumn("valorvta") ? drd["valorvta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorvta"]) : (decimal?)null;
                            output.mtodscto = drd.HasColumn("mtodscto") ? drd["mtodscto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodscto"]) : (decimal?)null;
                            output.tiposuma = drd.HasColumn("tiposuma") ? drd["tiposuma"] == DBNull.Value ? null : drd["tiposuma"].ToString() : null;
                            output.cdpack = drd.HasColumn("cdpack") ? drd["cdpack"] == DBNull.Value ? null : drd["cdpack"].ToString() : null;
                            output.cdarticulosunat = drd.HasColumn("cdarticulosunat") ? drd["cdarticulosunat"] == DBNull.Value ? null : drd["cdarticulosunat"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.nroproforma = drd.HasColumn("nroproforma") ? drd["nroproforma"] == DBNull.Value ? null : drd["nroproforma"].ToString() : null;
                            output.manguera = drd.HasColumn("manguera") ? drd["manguera"] == DBNull.Value ? null : drd["manguera"].ToString() : null;
                            output.tipoacumula = drd.HasColumn("tipoacumula") ? drd["tipoacumula"] == DBNull.Value ? null : drd["tipoacumula"].ToString() : null;
                            output.cdalterna = drd.HasColumn("cdalterna") ? drd["cdalterna"] == DBNull.Value ? null : drd["cdalterna"].ToString() : null;
                            output.talla = drd.HasColumn("talla") ? drd["talla"] == DBNull.Value ? null : drd["talla"].ToString() : null;
                            output.cdvendedor = drd.HasColumn("cdvendedor") ? drd["cdvendedor"] == DBNull.Value ? null : drd["cdvendedor"].ToString() : null;
                            output.cara = drd.HasColumn("cara") ? drd["cara"] == DBNull.Value ? null : drd["cara"].ToString() : null;
                            output.nrogasboy = drd.HasColumn("nrogasboy") ? drd["nrogasboy"] == DBNull.Value ? null : drd["nrogasboy"].ToString() : null;
                            output.nroguia = drd.HasColumn("nroguia") ? drd["nroguia"] == DBNull.Value ? null : drd["nroguia"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVentad> SP_ITBCP_LISTAR_VENTAD_1(TS_BEVentad input)
        {
            List<TS_BEVentad> lista = new List<TS_BEVentad>();
            TS_BEVentad output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VENTAD_1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVentad();
                            output.glosa = drd.HasColumn("glosa") ? drd["glosa"] == DBNull.Value ? null : drd["glosa"].ToString() : null;
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.flgcierrez = drd.HasColumn("flgcierrez") ? drd["flgcierrez"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrez"]) : false;
                            output.moverstock = drd.HasColumn("moverstock") ? drd["moverstock"] == DBNull.Value ? false : Convert.ToBoolean(drd["moverstock"]) : false;
                            output.archturno = drd.HasColumn("archturno") ? drd["archturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["archturno"]) : false;
                            output.trfgratuita = drd.HasColumn("trfgratuita") ? drd["trfgratuita"] == DBNull.Value ? false : Convert.ToBoolean(drd["trfgratuita"]) : false;
                            output.nroitem = drd.HasColumn("nroitem") ? drd["nroitem"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nroitem"]) : (decimal?)null;
                            output.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["impuesto"]) : (decimal?)null;
                            output.pordscto1 = drd.HasColumn("pordscto1") ? drd["pordscto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto1"]) : (decimal?)null;
                            output.pordscto2 = drd.HasColumn("pordscto2") ? drd["pordscto2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto2"]) : (decimal?)null;
                            output.pordscto3 = drd.HasColumn("pordscto3") ? drd["pordscto3"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto3"]) : (decimal?)null;
                            output.pordsctoeq = drd.HasColumn("pordsctoeq") ? drd["pordsctoeq"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordsctoeq"]) : (decimal?)null;
                            output.redondea_indecopi = drd.HasColumn("redondea_indecopi") ? drd["redondea_indecopi"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["redondea_indecopi"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcdetraccion"]) : (decimal?)null;
                            output.mtodetraccion = drd.HasColumn("mtodetraccion") ? drd["mtodetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodetraccion"]) : (decimal?)null;
                            output.precio_orig = drd.HasColumn("precio_orig") ? drd["precio_orig"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio_orig"]) : (decimal?)null;
                            output.ptosganados = drd.HasColumn("ptosganados") ? drd["ptosganados"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ptosganados"]) : (decimal?)null;
                            output.precioafiliacion = drd.HasColumn("precioafiliacion") ? drd["precioafiliacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precioafiliacion"]) : (decimal?)null;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valoracumula"]) : (decimal?)null;
                            output.costo_venta = drd.HasColumn("costo_venta") ? drd["costo_venta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["costo_venta"]) : (decimal?)null;
                            output.mtopercepcion = drd.HasColumn("mtopercepcion") ? drd["mtopercepcion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopercepcion"]) : (decimal?)null;
                            output.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtosubtotal"]) : (decimal?)null;
                            output.mtoservicio = drd.HasColumn("mtoservicio") ? drd["mtoservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoservicio"]) : (decimal?)null;
                            output.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoimpuesto"]) : (decimal?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtototal"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? null : drd["turno"].ToString() : null;
                            output.costo = drd.HasColumn("costo") ? drd["costo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["costo"]) : (decimal?)null;
                            output.cantidad = drd.HasColumn("cantidad") ? drd["cantidad"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantidad"]) : (decimal?)null;
                            output.cant_ncredito = drd.HasColumn("cant_ncredito") ? drd["cant_ncredito"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cant_ncredito"]) : (decimal?)null;
                            output.precio = drd.HasColumn("precio") ? drd["precio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio"]) : (decimal?)null;
                            output.mtonoafecto = drd.HasColumn("mtonoafecto") ? drd["mtonoafecto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtonoafecto"]) : (decimal?)null;
                            output.valorvta = drd.HasColumn("valorvta") ? drd["valorvta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorvta"]) : (decimal?)null;
                            output.mtodscto = drd.HasColumn("mtodscto") ? drd["mtodscto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodscto"]) : (decimal?)null;
                            output.tiposuma = drd.HasColumn("tiposuma") ? drd["tiposuma"] == DBNull.Value ? null : drd["tiposuma"].ToString() : null;
                            output.cdpack = drd.HasColumn("cdpack") ? drd["cdpack"] == DBNull.Value ? null : drd["cdpack"].ToString() : null;
                            output.cdarticulosunat = drd.HasColumn("cdarticulosunat") ? drd["cdarticulosunat"] == DBNull.Value ? null : drd["cdarticulosunat"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.nroproforma = drd.HasColumn("nroproforma") ? drd["nroproforma"] == DBNull.Value ? null : drd["nroproforma"].ToString() : null;
                            output.manguera = drd.HasColumn("manguera") ? drd["manguera"] == DBNull.Value ? null : drd["manguera"].ToString() : null;
                            output.tipoacumula = drd.HasColumn("tipoacumula") ? drd["tipoacumula"] == DBNull.Value ? null : drd["tipoacumula"].ToString() : null;
                            output.cdalterna = drd.HasColumn("cdalterna") ? drd["cdalterna"] == DBNull.Value ? null : drd["cdalterna"].ToString() : null;
                            output.talla = drd.HasColumn("talla") ? drd["talla"] == DBNull.Value ? null : drd["talla"].ToString() : null;
                            output.cdvendedor = drd.HasColumn("cdvendedor") ? drd["cdvendedor"] == DBNull.Value ? null : drd["cdvendedor"].ToString() : null;
                            output.cara = drd.HasColumn("cara") ? drd["cara"] == DBNull.Value ? null : drd["cara"].ToString() : null;
                            output.nrogasboy = drd.HasColumn("nrogasboy") ? drd["nrogasboy"] == DBNull.Value ? null : drd["nrogasboy"].ToString() : null;
                            output.nroguia = drd.HasColumn("nroguia") ? drd["nroguia"] == DBNull.Value ? null : drd["nroguia"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVentad> SP_ITBCP_LISTAR_VENTAD(TS_BEVentad input)
        {
            List<TS_BEVentad> lista = new List<TS_BEVentad>();
            TS_BEVentad output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VENTAD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                    cmd.Parameters.Add("@cdgrupo02", SqlDbType.Char, 5).Value = input.cdgrupo02;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                    cmd.Parameters.Add("@Turno", SqlDbType.Decimal, 5).Value = input.turno;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVentad();
                            output.glosa = drd.HasColumn("glosa") ? drd["glosa"] == DBNull.Value ? null : drd["glosa"].ToString() : null;
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.flgcierrez = drd.HasColumn("flgcierrez") ? drd["flgcierrez"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrez"]) : false;
                            output.moverstock = drd.HasColumn("moverstock") ? drd["moverstock"] == DBNull.Value ? false : Convert.ToBoolean(drd["moverstock"]) : false;
                            output.archturno = drd.HasColumn("archturno") ? drd["archturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["archturno"]) : false;
                            output.trfgratuita = drd.HasColumn("trfgratuita") ? drd["trfgratuita"] == DBNull.Value ? false : Convert.ToBoolean(drd["trfgratuita"]) : false;
                            output.nroitem = drd.HasColumn("nroitem") ? drd["nroitem"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nroitem"]) : (decimal?)null;
                            output.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["impuesto"]) : (decimal?)null;
                            output.pordscto1 = drd.HasColumn("pordscto1") ? drd["pordscto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto1"]) : (decimal?)null;
                            output.pordscto2 = drd.HasColumn("pordscto2") ? drd["pordscto2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto2"]) : (decimal?)null;
                            output.pordscto3 = drd.HasColumn("pordscto3") ? drd["pordscto3"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto3"]) : (decimal?)null;
                            output.pordsctoeq = drd.HasColumn("pordsctoeq") ? drd["pordsctoeq"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordsctoeq"]) : (decimal?)null;
                            output.redondea_indecopi = drd.HasColumn("redondea_indecopi") ? drd["redondea_indecopi"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["redondea_indecopi"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcdetraccion"]) : (decimal?)null;
                            output.mtodetraccion = drd.HasColumn("mtodetraccion") ? drd["mtodetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodetraccion"]) : (decimal?)null;
                            output.precio_orig = drd.HasColumn("precio_orig") ? drd["precio_orig"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio_orig"]) : (decimal?)null;
                            output.ptosganados = drd.HasColumn("ptosganados") ? drd["ptosganados"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ptosganados"]) : (decimal?)null;
                            output.precioafiliacion = drd.HasColumn("precioafiliacion") ? drd["precioafiliacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precioafiliacion"]) : (decimal?)null;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valoracumula"]) : (decimal?)null;
                            output.costo_venta = drd.HasColumn("costo_venta") ? drd["costo_venta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["costo_venta"]) : (decimal?)null;
                            output.mtopercepcion = drd.HasColumn("mtopercepcion") ? drd["mtopercepcion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopercepcion"]) : (decimal?)null;
                            output.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtosubtotal"]) : (decimal?)null;
                            output.mtoservicio = drd.HasColumn("mtoservicio") ? drd["mtoservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoservicio"]) : (decimal?)null;
                            output.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoimpuesto"]) : (decimal?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtototal"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? null : drd["turno"].ToString() : null;
                            output.costo = drd.HasColumn("costo") ? drd["costo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["costo"]) : (decimal?)null;
                            output.cantidad = drd.HasColumn("cantidad") ? drd["cantidad"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantidad"]) : (decimal?)null;
                            output.cant_ncredito = drd.HasColumn("cant_ncredito") ? drd["cant_ncredito"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cant_ncredito"]) : (decimal?)null;
                            output.precio = drd.HasColumn("precio") ? drd["precio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio"]) : (decimal?)null;
                            output.mtonoafecto = drd.HasColumn("mtonoafecto") ? drd["mtonoafecto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtonoafecto"]) : (decimal?)null;
                            output.valorvta = drd.HasColumn("valorvta") ? drd["valorvta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorvta"]) : (decimal?)null;
                            output.mtodscto = drd.HasColumn("mtodscto") ? drd["mtodscto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodscto"]) : (decimal?)null;
                            output.tiposuma = drd.HasColumn("tiposuma") ? drd["tiposuma"] == DBNull.Value ? null : drd["tiposuma"].ToString() : null;
                            output.cdpack = drd.HasColumn("cdpack") ? drd["cdpack"] == DBNull.Value ? null : drd["cdpack"].ToString() : null;
                            output.cdarticulosunat = drd.HasColumn("cdarticulosunat") ? drd["cdarticulosunat"] == DBNull.Value ? null : drd["cdarticulosunat"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.nroproforma = drd.HasColumn("nroproforma") ? drd["nroproforma"] == DBNull.Value ? null : drd["nroproforma"].ToString() : null;
                            output.manguera = drd.HasColumn("manguera") ? drd["manguera"] == DBNull.Value ? null : drd["manguera"].ToString() : null;
                            output.tipoacumula = drd.HasColumn("tipoacumula") ? drd["tipoacumula"] == DBNull.Value ? null : drd["tipoacumula"].ToString() : null;
                            output.cdalterna = drd.HasColumn("cdalterna") ? drd["cdalterna"] == DBNull.Value ? null : drd["cdalterna"].ToString() : null;
                            output.talla = drd.HasColumn("talla") ? drd["talla"] == DBNull.Value ? null : drd["talla"].ToString() : null;
                            output.cdvendedor = drd.HasColumn("cdvendedor") ? drd["cdvendedor"] == DBNull.Value ? null : drd["cdvendedor"].ToString() : null;
                            output.cara = drd.HasColumn("cara") ? drd["cara"] == DBNull.Value ? null : drd["cara"].ToString() : null;
                            output.nrogasboy = drd.HasColumn("nrogasboy") ? drd["nrogasboy"] == DBNull.Value ? null : drd["nrogasboy"].ToString() : null;
                            output.nroguia = drd.HasColumn("nroguia") ? drd["nroguia"] == DBNull.Value ? null : drd["nroguia"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_9(TS_BEVenta input)
        {
            List<TS_BEVenta> lista = new List<TS_BEVenta>();
            TS_BEVenta output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VENTA_9", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVenta();
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.fecanula = drd.HasColumn("fecanula") ? drd["fecanula"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanula"]) : (DateTime?)null;
                            output.fecanulasis = drd.HasColumn("fecanulasis") ? drd["fecanulasis"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanulasis"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.fecsistema = drd.HasColumn("fecsistema") ? drd["fecsistema"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecsistema"]) : (DateTime?)null;
                            output.flgmanual = drd.HasColumn("flgmanual") ? drd["flgmanual"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmanual"]) : false;
                            output.flgcierrez = drd.HasColumn("flgcierrez") ? drd["flgcierrez"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrez"]) : false;
                            output.flgmovimiento = drd.HasColumn("flgmovimiento") ? drd["flgmovimiento"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmovimiento"]) : false;
                            output.archturno = drd.HasColumn("archturno") ? drd["archturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["archturno"]) : false;
                            output.chkespecial = drd.HasColumn("chkespecial") ? drd["chkespecial"] == DBNull.Value ? false : Convert.ToBoolean(drd["chkespecial"]) : false;
                            output.rucinvalido = drd.HasColumn("rucinvalido") ? drd["rucinvalido"] == DBNull.Value ? false : Convert.ToBoolean(drd["rucinvalido"]) : false;
                            output.usadecimales = drd.HasColumn("usadecimales") ? drd["usadecimales"] == DBNull.Value ? false : Convert.ToBoolean(drd["usadecimales"]) : false;
                            output.fact_elect = drd.HasColumn("fact_elect") ? drd["fact_elect"] == DBNull.Value ? false : Convert.ToBoolean(drd["fact_elect"]) : false;
                            output.mtovueltosol = drd.HasColumn("mtovueltosol") ? drd["mtovueltosol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltosol"]) : (decimal?)null;
                            output.mtovueltodol = drd.HasColumn("mtovueltodol") ? drd["mtovueltodol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltodol"]) : (decimal?)null;
                            output.porservicio = drd.HasColumn("porservicio") ? drd["porservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porservicio"]) : (decimal?)null;
                            output.pordscto1 = drd.HasColumn("pordscto1") ? drd["pordscto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto1"]) : (decimal?)null;
                            output.pordscto2 = drd.HasColumn("pordscto2") ? drd["pordscto2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto2"]) : (decimal?)null;
                            output.pordscto3 = drd.HasColumn("pordscto3") ? drd["pordscto3"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto3"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcdetraccion"]) : (decimal?)null;
                            output.mtodetraccion = drd.HasColumn("mtodetraccion") ? drd["mtodetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodetraccion"]) : (decimal?)null;
                            output.precio_orig = drd.HasColumn("precio_orig") ? drd["precio_orig"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio_orig"]) : (decimal?)null;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valoracumula"]) : (decimal?)null;
                            output.cantcupon = drd.HasColumn("cantcupon") ? drd["cantcupon"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantcupon"]) : (decimal?)null;
                            output.mtocanje = drd.HasColumn("mtocanje") ? drd["mtocanje"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtocanje"]) : (decimal?)null;
                            output.mtopercepcion = drd.HasColumn("mtopercepcion") ? drd["mtopercepcion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopercepcion"]) : (decimal?)null;
                            output.redondea_indecopi = drd.HasColumn("redondea_indecopi") ? drd["redondea_indecopi"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["redondea_indecopi"]) : (decimal?)null;
                            output.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoimpuesto"]) : (decimal?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtototal"]) : (decimal?)null;
                            output.tcambio = drd.HasColumn("tcambio") ? drd["tcambio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["tcambio"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.mtorecaudo = drd.HasColumn("mtorecaudo") ? drd["mtorecaudo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtorecaudo"]) : (decimal?)null;
                            output.ptosganados = drd.HasColumn("ptosganados") ? drd["ptosganados"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ptosganados"]) : (decimal?)null;
                            output.pordsctoeq = drd.HasColumn("pordsctoeq") ? drd["pordsctoeq"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordsctoeq"]) : (decimal?)null;
                            output.mtonoafecto = drd.HasColumn("mtonoafecto") ? drd["mtonoafecto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtonoafecto"]) : (decimal?)null;
                            output.valorvta = drd.HasColumn("valorvta") ? drd["valorvta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorvta"]) : (decimal?)null;
                            output.mtodscto = drd.HasColumn("mtodscto") ? drd["mtodscto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodscto"]) : (decimal?)null;
                            output.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtosubtotal"]) : (decimal?)null;
                            output.mtoservicio = drd.HasColumn("mtoservicio") ? drd["mtoservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoservicio"]) : (decimal?)null;
                            output.nroplaca = drd.HasColumn("nroplaca") ? drd["nroplaca"] == DBNull.Value ? null : drd["nroplaca"].ToString() : null;
                            output.observacion = drd.HasColumn("observacion") ? drd["observacion"] == DBNull.Value ? null : drd["observacion"].ToString() : null;
                            output.referencia = drd.HasColumn("referencia") ? drd["referencia"] == DBNull.Value ? null : drd["referencia"].ToString() : null;
                            output.c_centralizacion = drd.HasColumn("c_centralizacion") ? drd["c_centralizacion"] == DBNull.Value ? null : drd["c_centralizacion"].ToString() : null;
                            output.codes = drd.HasColumn("codes") ? drd["codes"] == DBNull.Value ? null : drd["codes"].ToString() : null;
                            output.codeid = drd.HasColumn("codeid") ? drd["codeid"] == DBNull.Value ? null : drd["codeid"].ToString() : null;
                            output.mensaje1 = drd.HasColumn("mensaje1") ? drd["mensaje1"] == DBNull.Value ? null : drd["mensaje1"].ToString() : null;
                            output.mensaje2 = drd.HasColumn("mensaje2") ? drd["mensaje2"] == DBNull.Value ? null : drd["mensaje2"].ToString() : null;
                            output.pdf417 = drd.HasColumn("pdf417") ? drd["pdf417"] == DBNull.Value ? null : drd["pdf417"].ToString() : null;
                            output.cdhash = drd.HasColumn("cdhash") ? drd["cdhash"] == DBNull.Value ? null : drd["cdhash"].ToString() : null;
                            output.scop = drd.HasColumn("scop") ? drd["scop"] == DBNull.Value ? null : drd["scop"].ToString() : null;
                            output.nroguia = drd.HasColumn("nroguia") ? drd["nroguia"] == DBNull.Value ? null : drd["nroguia"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.nrocelular = drd.HasColumn("nrocelular") ? drd["nrocelular"] == DBNull.Value ? null : drd["nrocelular"].ToString() : null;
                            output.tipoacumula = drd.HasColumn("tipoacumula") ? drd["tipoacumula"] == DBNull.Value ? null : drd["tipoacumula"].ToString() : null;
                            output.cdruta = drd.HasColumn("cdruta") ? drd["cdruta"] == DBNull.Value ? null : drd["cdruta"].ToString() : null;
                            output.ctadetraccion = drd.HasColumn("ctadetraccion") ? drd["ctadetraccion"] == DBNull.Value ? null : drd["ctadetraccion"].ToString() : null;
                            output.cdmedio_pago = drd.HasColumn("cdmedio_pago") ? drd["cdmedio_pago"] == DBNull.Value ? null : drd["cdmedio_pago"].ToString() : null;
                            output.odometro = drd.HasColumn("odometro") ? drd["odometro"] == DBNull.Value ? null : drd["odometro"].ToString() : null;
                            output.marcavehic = drd.HasColumn("marcavehic") ? drd["marcavehic"] == DBNull.Value ? null : drd["marcavehic"].ToString() : null;
                            output.inscripcion = drd.HasColumn("inscripcion") ? drd["inscripcion"] == DBNull.Value ? null : drd["inscripcion"].ToString() : null;
                            output.chofer = drd.HasColumn("chofer") ? drd["chofer"] == DBNull.Value ? null : drd["chofer"].ToString() : null;
                            output.nrolicencia = drd.HasColumn("nrolicencia") ? drd["nrolicencia"] == DBNull.Value ? null : drd["nrolicencia"].ToString() : null;
                            output.tipoventa = drd.HasColumn("tipoventa") ? drd["tipoventa"] == DBNull.Value ? null : drd["tipoventa"].ToString() : null;
                            output.tipofactura = drd.HasColumn("tipofactura") ? drd["tipofactura"] == DBNull.Value ? null : drd["tipofactura"].ToString() : null;
                            output.nroocompra = drd.HasColumn("nroocompra") ? drd["nroocompra"] == DBNull.Value ? null : drd["nroocompra"].ToString() : null;
                            output.nroserie1 = drd.HasColumn("nroserie1") ? drd["nroserie1"] == DBNull.Value ? null : drd["nroserie1"].ToString() : null;
                            output.nroserie2 = drd.HasColumn("nroserie2") ? drd["nroserie2"] == DBNull.Value ? null : drd["nroserie2"].ToString() : null;
                            output.nrobonus = drd.HasColumn("nrobonus") ? drd["nrobonus"] == DBNull.Value ? null : drd["nrobonus"].ToString() : null;
                            output.nrotarjeta = drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? null : drd["nrotarjeta"].ToString() : null;
                            output.cdtranspor = drd.HasColumn("cdtranspor") ? drd["cdtranspor"] == DBNull.Value ? null : drd["cdtranspor"].ToString() : null;
                            output.drpartida = drd.HasColumn("drpartida") ? drd["drpartida"] == DBNull.Value ? null : drd["drpartida"].ToString() : null;
                            output.drdestino = drd.HasColumn("drdestino") ? drd["drdestino"] == DBNull.Value ? null : drd["drdestino"].ToString() : null;
                            output.cdusuario = drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString() : null;
                            output.cdvendedor = drd.HasColumn("cdvendedor") ? drd["cdvendedor"] == DBNull.Value ? null : drd["cdvendedor"].ToString() : null;
                            output.cdusuanula = drd.HasColumn("cdusuanula") ? drd["cdusuanula"] == DBNull.Value ? null : drd["cdusuanula"].ToString() : null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;
                            output.rscliente = drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? null : drd["rscliente"].ToString() : null;
                            output.nroproforma = drd.HasColumn("nroproforma") ? drd["nroproforma"] == DBNull.Value ? null : drd["nroproforma"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.cdmoneda = drd.HasColumn("cdmoneda") ? drd["cdmoneda"] == DBNull.Value ? null : drd["cdmoneda"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_8(TS_BEVenta input)
        {
            List<TS_BEVenta> lista = new List<TS_BEVenta>();
            TS_BEVenta output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VENTA_8", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVenta();
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.fecanula = drd.HasColumn("fecanula") ? drd["fecanula"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanula"]) : (DateTime?)null;
                            output.fecanulasis = drd.HasColumn("fecanulasis") ? drd["fecanulasis"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanulasis"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.fecsistema = drd.HasColumn("fecsistema") ? drd["fecsistema"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecsistema"]) : (DateTime?)null;
                            output.flgmanual = drd.HasColumn("flgmanual") ? drd["flgmanual"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmanual"]) : false;
                            output.flgcierrez = drd.HasColumn("flgcierrez") ? drd["flgcierrez"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrez"]) : false;
                            output.flgmovimiento = drd.HasColumn("flgmovimiento") ? drd["flgmovimiento"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmovimiento"]) : false;
                            output.archturno = drd.HasColumn("archturno") ? drd["archturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["archturno"]) : false;
                            output.chkespecial = drd.HasColumn("chkespecial") ? drd["chkespecial"] == DBNull.Value ? false : Convert.ToBoolean(drd["chkespecial"]) : false;
                            output.rucinvalido = drd.HasColumn("rucinvalido") ? drd["rucinvalido"] == DBNull.Value ? false : Convert.ToBoolean(drd["rucinvalido"]) : false;
                            output.usadecimales = drd.HasColumn("usadecimales") ? drd["usadecimales"] == DBNull.Value ? false : Convert.ToBoolean(drd["usadecimales"]) : false;
                            output.fact_elect = drd.HasColumn("fact_elect") ? drd["fact_elect"] == DBNull.Value ? false : Convert.ToBoolean(drd["fact_elect"]) : false;
                            output.mtovueltosol = drd.HasColumn("mtovueltosol") ? drd["mtovueltosol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltosol"]) : (decimal?)null;
                            output.mtovueltodol = drd.HasColumn("mtovueltodol") ? drd["mtovueltodol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltodol"]) : (decimal?)null;
                            output.porservicio = drd.HasColumn("porservicio") ? drd["porservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porservicio"]) : (decimal?)null;
                            output.pordscto1 = drd.HasColumn("pordscto1") ? drd["pordscto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto1"]) : (decimal?)null;
                            output.pordscto2 = drd.HasColumn("pordscto2") ? drd["pordscto2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto2"]) : (decimal?)null;
                            output.pordscto3 = drd.HasColumn("pordscto3") ? drd["pordscto3"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto3"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcdetraccion"]) : (decimal?)null;
                            output.mtodetraccion = drd.HasColumn("mtodetraccion") ? drd["mtodetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodetraccion"]) : (decimal?)null;
                            output.precio_orig = drd.HasColumn("precio_orig") ? drd["precio_orig"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio_orig"]) : (decimal?)null;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valoracumula"]) : (decimal?)null;
                            output.cantcupon = drd.HasColumn("cantcupon") ? drd["cantcupon"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantcupon"]) : (decimal?)null;
                            output.mtocanje = drd.HasColumn("mtocanje") ? drd["mtocanje"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtocanje"]) : (decimal?)null;
                            output.mtopercepcion = drd.HasColumn("mtopercepcion") ? drd["mtopercepcion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopercepcion"]) : (decimal?)null;
                            output.redondea_indecopi = drd.HasColumn("redondea_indecopi") ? drd["redondea_indecopi"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["redondea_indecopi"]) : (decimal?)null;
                            output.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoimpuesto"]) : (decimal?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtototal"]) : (decimal?)null;
                            output.tcambio = drd.HasColumn("tcambio") ? drd["tcambio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["tcambio"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.mtorecaudo = drd.HasColumn("mtorecaudo") ? drd["mtorecaudo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtorecaudo"]) : (decimal?)null;
                            output.ptosganados = drd.HasColumn("ptosganados") ? drd["ptosganados"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ptosganados"]) : (decimal?)null;
                            output.pordsctoeq = drd.HasColumn("pordsctoeq") ? drd["pordsctoeq"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordsctoeq"]) : (decimal?)null;
                            output.mtonoafecto = drd.HasColumn("mtonoafecto") ? drd["mtonoafecto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtonoafecto"]) : (decimal?)null;
                            output.valorvta = drd.HasColumn("valorvta") ? drd["valorvta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorvta"]) : (decimal?)null;
                            output.mtodscto = drd.HasColumn("mtodscto") ? drd["mtodscto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodscto"]) : (decimal?)null;
                            output.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtosubtotal"]) : (decimal?)null;
                            output.mtoservicio = drd.HasColumn("mtoservicio") ? drd["mtoservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoservicio"]) : (decimal?)null;
                            output.nroplaca = drd.HasColumn("nroplaca") ? drd["nroplaca"] == DBNull.Value ? null : drd["nroplaca"].ToString() : null;
                            output.observacion = drd.HasColumn("observacion") ? drd["observacion"] == DBNull.Value ? null : drd["observacion"].ToString() : null;
                            output.referencia = drd.HasColumn("referencia") ? drd["referencia"] == DBNull.Value ? null : drd["referencia"].ToString() : null;
                            output.c_centralizacion = drd.HasColumn("c_centralizacion") ? drd["c_centralizacion"] == DBNull.Value ? null : drd["c_centralizacion"].ToString() : null;
                            output.codes = drd.HasColumn("codes") ? drd["codes"] == DBNull.Value ? null : drd["codes"].ToString() : null;
                            output.codeid = drd.HasColumn("codeid") ? drd["codeid"] == DBNull.Value ? null : drd["codeid"].ToString() : null;
                            output.mensaje1 = drd.HasColumn("mensaje1") ? drd["mensaje1"] == DBNull.Value ? null : drd["mensaje1"].ToString() : null;
                            output.mensaje2 = drd.HasColumn("mensaje2") ? drd["mensaje2"] == DBNull.Value ? null : drd["mensaje2"].ToString() : null;
                            output.pdf417 = drd.HasColumn("pdf417") ? drd["pdf417"] == DBNull.Value ? null : drd["pdf417"].ToString() : null;
                            output.cdhash = drd.HasColumn("cdhash") ? drd["cdhash"] == DBNull.Value ? null : drd["cdhash"].ToString() : null;
                            output.scop = drd.HasColumn("scop") ? drd["scop"] == DBNull.Value ? null : drd["scop"].ToString() : null;
                            output.nroguia = drd.HasColumn("nroguia") ? drd["nroguia"] == DBNull.Value ? null : drd["nroguia"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.nrocelular = drd.HasColumn("nrocelular") ? drd["nrocelular"] == DBNull.Value ? null : drd["nrocelular"].ToString() : null;
                            output.tipoacumula = drd.HasColumn("tipoacumula") ? drd["tipoacumula"] == DBNull.Value ? null : drd["tipoacumula"].ToString() : null;
                            output.cdruta = drd.HasColumn("cdruta") ? drd["cdruta"] == DBNull.Value ? null : drd["cdruta"].ToString() : null;
                            output.ctadetraccion = drd.HasColumn("ctadetraccion") ? drd["ctadetraccion"] == DBNull.Value ? null : drd["ctadetraccion"].ToString() : null;
                            output.cdmedio_pago = drd.HasColumn("cdmedio_pago") ? drd["cdmedio_pago"] == DBNull.Value ? null : drd["cdmedio_pago"].ToString() : null;
                            output.odometro = drd.HasColumn("odometro") ? drd["odometro"] == DBNull.Value ? null : drd["odometro"].ToString() : null;
                            output.marcavehic = drd.HasColumn("marcavehic") ? drd["marcavehic"] == DBNull.Value ? null : drd["marcavehic"].ToString() : null;
                            output.inscripcion = drd.HasColumn("inscripcion") ? drd["inscripcion"] == DBNull.Value ? null : drd["inscripcion"].ToString() : null;
                            output.chofer = drd.HasColumn("chofer") ? drd["chofer"] == DBNull.Value ? null : drd["chofer"].ToString() : null;
                            output.nrolicencia = drd.HasColumn("nrolicencia") ? drd["nrolicencia"] == DBNull.Value ? null : drd["nrolicencia"].ToString() : null;
                            output.tipoventa = drd.HasColumn("tipoventa") ? drd["tipoventa"] == DBNull.Value ? null : drd["tipoventa"].ToString() : null;
                            output.tipofactura = drd.HasColumn("tipofactura") ? drd["tipofactura"] == DBNull.Value ? null : drd["tipofactura"].ToString() : null;
                            output.nroocompra = drd.HasColumn("nroocompra") ? drd["nroocompra"] == DBNull.Value ? null : drd["nroocompra"].ToString() : null;
                            output.nroserie1 = drd.HasColumn("nroserie1") ? drd["nroserie1"] == DBNull.Value ? null : drd["nroserie1"].ToString() : null;
                            output.nroserie2 = drd.HasColumn("nroserie2") ? drd["nroserie2"] == DBNull.Value ? null : drd["nroserie2"].ToString() : null;
                            output.nrobonus = drd.HasColumn("nrobonus") ? drd["nrobonus"] == DBNull.Value ? null : drd["nrobonus"].ToString() : null;
                            output.nrotarjeta = drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? null : drd["nrotarjeta"].ToString() : null;
                            output.cdtranspor = drd.HasColumn("cdtranspor") ? drd["cdtranspor"] == DBNull.Value ? null : drd["cdtranspor"].ToString() : null;
                            output.drpartida = drd.HasColumn("drpartida") ? drd["drpartida"] == DBNull.Value ? null : drd["drpartida"].ToString() : null;
                            output.drdestino = drd.HasColumn("drdestino") ? drd["drdestino"] == DBNull.Value ? null : drd["drdestino"].ToString() : null;
                            output.cdusuario = drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString() : null;
                            output.cdvendedor = drd.HasColumn("cdvendedor") ? drd["cdvendedor"] == DBNull.Value ? null : drd["cdvendedor"].ToString() : null;
                            output.cdusuanula = drd.HasColumn("cdusuanula") ? drd["cdusuanula"] == DBNull.Value ? null : drd["cdusuanula"].ToString() : null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;
                            output.rscliente = drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? null : drd["rscliente"].ToString() : null;
                            output.nroproforma = drd.HasColumn("nroproforma") ? drd["nroproforma"] == DBNull.Value ? null : drd["nroproforma"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.cdmoneda = drd.HasColumn("cdmoneda") ? drd["cdmoneda"] == DBNull.Value ? null : drd["cdmoneda"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_7(TS_BEVenta input)
        {
            List<TS_BEVenta> lista = new List<TS_BEVenta>();
            TS_BEVenta output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VENTA_7", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVenta();
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.fecanula = drd.HasColumn("fecanula") ? drd["fecanula"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanula"]) : (DateTime?)null;
                            output.fecanulasis = drd.HasColumn("fecanulasis") ? drd["fecanulasis"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanulasis"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.fecsistema = drd.HasColumn("fecsistema") ? drd["fecsistema"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecsistema"]) : (DateTime?)null;
                            output.flgmanual = drd.HasColumn("flgmanual") ? drd["flgmanual"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmanual"]) : false;
                            output.flgcierrez = drd.HasColumn("flgcierrez") ? drd["flgcierrez"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrez"]) : false;
                            output.flgmovimiento = drd.HasColumn("flgmovimiento") ? drd["flgmovimiento"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmovimiento"]) : false;
                            output.archturno = drd.HasColumn("archturno") ? drd["archturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["archturno"]) : false;
                            output.chkespecial = drd.HasColumn("chkespecial") ? drd["chkespecial"] == DBNull.Value ? false : Convert.ToBoolean(drd["chkespecial"]) : false;
                            output.rucinvalido = drd.HasColumn("rucinvalido") ? drd["rucinvalido"] == DBNull.Value ? false : Convert.ToBoolean(drd["rucinvalido"]) : false;
                            output.usadecimales = drd.HasColumn("usadecimales") ? drd["usadecimales"] == DBNull.Value ? false : Convert.ToBoolean(drd["usadecimales"]) : false;
                            output.fact_elect = drd.HasColumn("fact_elect") ? drd["fact_elect"] == DBNull.Value ? false : Convert.ToBoolean(drd["fact_elect"]) : false;
                            output.mtovueltosol = drd.HasColumn("mtovueltosol") ? drd["mtovueltosol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltosol"]) : (decimal?)null;
                            output.mtovueltodol = drd.HasColumn("mtovueltodol") ? drd["mtovueltodol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltodol"]) : (decimal?)null;
                            output.porservicio = drd.HasColumn("porservicio") ? drd["porservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porservicio"]) : (decimal?)null;
                            output.pordscto1 = drd.HasColumn("pordscto1") ? drd["pordscto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto1"]) : (decimal?)null;
                            output.pordscto2 = drd.HasColumn("pordscto2") ? drd["pordscto2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto2"]) : (decimal?)null;
                            output.pordscto3 = drd.HasColumn("pordscto3") ? drd["pordscto3"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto3"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcdetraccion"]) : (decimal?)null;
                            output.mtodetraccion = drd.HasColumn("mtodetraccion") ? drd["mtodetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodetraccion"]) : (decimal?)null;
                            output.precio_orig = drd.HasColumn("precio_orig") ? drd["precio_orig"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio_orig"]) : (decimal?)null;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valoracumula"]) : (decimal?)null;
                            output.cantcupon = drd.HasColumn("cantcupon") ? drd["cantcupon"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantcupon"]) : (decimal?)null;
                            output.mtocanje = drd.HasColumn("mtocanje") ? drd["mtocanje"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtocanje"]) : (decimal?)null;
                            output.mtopercepcion = drd.HasColumn("mtopercepcion") ? drd["mtopercepcion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopercepcion"]) : (decimal?)null;
                            output.redondea_indecopi = drd.HasColumn("redondea_indecopi") ? drd["redondea_indecopi"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["redondea_indecopi"]) : (decimal?)null;
                            output.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoimpuesto"]) : (decimal?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtototal"]) : (decimal?)null;
                            output.tcambio = drd.HasColumn("tcambio") ? drd["tcambio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["tcambio"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.mtorecaudo = drd.HasColumn("mtorecaudo") ? drd["mtorecaudo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtorecaudo"]) : (decimal?)null;
                            output.ptosganados = drd.HasColumn("ptosganados") ? drd["ptosganados"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ptosganados"]) : (decimal?)null;
                            output.pordsctoeq = drd.HasColumn("pordsctoeq") ? drd["pordsctoeq"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordsctoeq"]) : (decimal?)null;
                            output.mtonoafecto = drd.HasColumn("mtonoafecto") ? drd["mtonoafecto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtonoafecto"]) : (decimal?)null;
                            output.valorvta = drd.HasColumn("valorvta") ? drd["valorvta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorvta"]) : (decimal?)null;
                            output.mtodscto = drd.HasColumn("mtodscto") ? drd["mtodscto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodscto"]) : (decimal?)null;
                            output.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtosubtotal"]) : (decimal?)null;
                            output.mtoservicio = drd.HasColumn("mtoservicio") ? drd["mtoservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoservicio"]) : (decimal?)null;
                            output.nroplaca = drd.HasColumn("nroplaca") ? drd["nroplaca"] == DBNull.Value ? null : drd["nroplaca"].ToString() : null;
                            output.observacion = drd.HasColumn("observacion") ? drd["observacion"] == DBNull.Value ? null : drd["observacion"].ToString() : null;
                            output.referencia = drd.HasColumn("referencia") ? drd["referencia"] == DBNull.Value ? null : drd["referencia"].ToString() : null;
                            output.c_centralizacion = drd.HasColumn("c_centralizacion") ? drd["c_centralizacion"] == DBNull.Value ? null : drd["c_centralizacion"].ToString() : null;
                            output.codes = drd.HasColumn("codes") ? drd["codes"] == DBNull.Value ? null : drd["codes"].ToString() : null;
                            output.codeid = drd.HasColumn("codeid") ? drd["codeid"] == DBNull.Value ? null : drd["codeid"].ToString() : null;
                            output.mensaje1 = drd.HasColumn("mensaje1") ? drd["mensaje1"] == DBNull.Value ? null : drd["mensaje1"].ToString() : null;
                            output.mensaje2 = drd.HasColumn("mensaje2") ? drd["mensaje2"] == DBNull.Value ? null : drd["mensaje2"].ToString() : null;
                            output.pdf417 = drd.HasColumn("pdf417") ? drd["pdf417"] == DBNull.Value ? null : drd["pdf417"].ToString() : null;
                            output.cdhash = drd.HasColumn("cdhash") ? drd["cdhash"] == DBNull.Value ? null : drd["cdhash"].ToString() : null;
                            output.scop = drd.HasColumn("scop") ? drd["scop"] == DBNull.Value ? null : drd["scop"].ToString() : null;
                            output.nroguia = drd.HasColumn("nroguia") ? drd["nroguia"] == DBNull.Value ? null : drd["nroguia"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.nrocelular = drd.HasColumn("nrocelular") ? drd["nrocelular"] == DBNull.Value ? null : drd["nrocelular"].ToString() : null;
                            output.tipoacumula = drd.HasColumn("tipoacumula") ? drd["tipoacumula"] == DBNull.Value ? null : drd["tipoacumula"].ToString() : null;
                            output.cdruta = drd.HasColumn("cdruta") ? drd["cdruta"] == DBNull.Value ? null : drd["cdruta"].ToString() : null;
                            output.ctadetraccion = drd.HasColumn("ctadetraccion") ? drd["ctadetraccion"] == DBNull.Value ? null : drd["ctadetraccion"].ToString() : null;
                            output.cdmedio_pago = drd.HasColumn("cdmedio_pago") ? drd["cdmedio_pago"] == DBNull.Value ? null : drd["cdmedio_pago"].ToString() : null;
                            output.odometro = drd.HasColumn("odometro") ? drd["odometro"] == DBNull.Value ? null : drd["odometro"].ToString() : null;
                            output.marcavehic = drd.HasColumn("marcavehic") ? drd["marcavehic"] == DBNull.Value ? null : drd["marcavehic"].ToString() : null;
                            output.inscripcion = drd.HasColumn("inscripcion") ? drd["inscripcion"] == DBNull.Value ? null : drd["inscripcion"].ToString() : null;
                            output.chofer = drd.HasColumn("chofer") ? drd["chofer"] == DBNull.Value ? null : drd["chofer"].ToString() : null;
                            output.nrolicencia = drd.HasColumn("nrolicencia") ? drd["nrolicencia"] == DBNull.Value ? null : drd["nrolicencia"].ToString() : null;
                            output.tipoventa = drd.HasColumn("tipoventa") ? drd["tipoventa"] == DBNull.Value ? null : drd["tipoventa"].ToString() : null;
                            output.tipofactura = drd.HasColumn("tipofactura") ? drd["tipofactura"] == DBNull.Value ? null : drd["tipofactura"].ToString() : null;
                            output.nroocompra = drd.HasColumn("nroocompra") ? drd["nroocompra"] == DBNull.Value ? null : drd["nroocompra"].ToString() : null;
                            output.nroserie1 = drd.HasColumn("nroserie1") ? drd["nroserie1"] == DBNull.Value ? null : drd["nroserie1"].ToString() : null;
                            output.nroserie2 = drd.HasColumn("nroserie2") ? drd["nroserie2"] == DBNull.Value ? null : drd["nroserie2"].ToString() : null;
                            output.nrobonus = drd.HasColumn("nrobonus") ? drd["nrobonus"] == DBNull.Value ? null : drd["nrobonus"].ToString() : null;
                            output.nrotarjeta = drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? null : drd["nrotarjeta"].ToString() : null;
                            output.cdtranspor = drd.HasColumn("cdtranspor") ? drd["cdtranspor"] == DBNull.Value ? null : drd["cdtranspor"].ToString() : null;
                            output.drpartida = drd.HasColumn("drpartida") ? drd["drpartida"] == DBNull.Value ? null : drd["drpartida"].ToString() : null;
                            output.drdestino = drd.HasColumn("drdestino") ? drd["drdestino"] == DBNull.Value ? null : drd["drdestino"].ToString() : null;
                            output.cdusuario = drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString() : null;
                            output.cdvendedor = drd.HasColumn("cdvendedor") ? drd["cdvendedor"] == DBNull.Value ? null : drd["cdvendedor"].ToString() : null;
                            output.cdusuanula = drd.HasColumn("cdusuanula") ? drd["cdusuanula"] == DBNull.Value ? null : drd["cdusuanula"].ToString() : null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;
                            output.rscliente = drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? null : drd["rscliente"].ToString() : null;
                            output.nroproforma = drd.HasColumn("nroproforma") ? drd["nroproforma"] == DBNull.Value ? null : drd["nroproforma"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.cdmoneda = drd.HasColumn("cdmoneda") ? drd["cdmoneda"] == DBNull.Value ? null : drd["cdmoneda"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_6(TS_BEVenta input)
        {
            List<TS_BEVenta> lista = new List<TS_BEVenta>();
            TS_BEVenta output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VENTA_6", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@cdUsuario", SqlDbType.Char, 10).Value = input.cdusuario;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVenta();
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.fecanula = drd.HasColumn("fecanula") ? drd["fecanula"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanula"]) : (DateTime?)null;
                            output.fecanulasis = drd.HasColumn("fecanulasis") ? drd["fecanulasis"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanulasis"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.fecsistema = drd.HasColumn("fecsistema") ? drd["fecsistema"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecsistema"]) : (DateTime?)null;
                            output.flgmanual = drd.HasColumn("flgmanual") ? drd["flgmanual"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmanual"]) : false;
                            output.flgcierrez = drd.HasColumn("flgcierrez") ? drd["flgcierrez"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrez"]) : false;
                            output.flgmovimiento = drd.HasColumn("flgmovimiento") ? drd["flgmovimiento"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmovimiento"]) : false;
                            output.archturno = drd.HasColumn("archturno") ? drd["archturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["archturno"]) : false;
                            output.chkespecial = drd.HasColumn("chkespecial") ? drd["chkespecial"] == DBNull.Value ? false : Convert.ToBoolean(drd["chkespecial"]) : false;
                            output.rucinvalido = drd.HasColumn("rucinvalido") ? drd["rucinvalido"] == DBNull.Value ? false : Convert.ToBoolean(drd["rucinvalido"]) : false;
                            output.usadecimales = drd.HasColumn("usadecimales") ? drd["usadecimales"] == DBNull.Value ? false : Convert.ToBoolean(drd["usadecimales"]) : false;
                            output.fact_elect = drd.HasColumn("fact_elect") ? drd["fact_elect"] == DBNull.Value ? false : Convert.ToBoolean(drd["fact_elect"]) : false;
                            output.mtovueltosol = drd.HasColumn("mtovueltosol") ? drd["mtovueltosol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltosol"]) : (decimal?)null;
                            output.mtovueltodol = drd.HasColumn("mtovueltodol") ? drd["mtovueltodol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltodol"]) : (decimal?)null;
                            output.porservicio = drd.HasColumn("porservicio") ? drd["porservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porservicio"]) : (decimal?)null;
                            output.pordscto1 = drd.HasColumn("pordscto1") ? drd["pordscto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto1"]) : (decimal?)null;
                            output.pordscto2 = drd.HasColumn("pordscto2") ? drd["pordscto2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto2"]) : (decimal?)null;
                            output.pordscto3 = drd.HasColumn("pordscto3") ? drd["pordscto3"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto3"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcdetraccion"]) : (decimal?)null;
                            output.mtodetraccion = drd.HasColumn("mtodetraccion") ? drd["mtodetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodetraccion"]) : (decimal?)null;
                            output.precio_orig = drd.HasColumn("precio_orig") ? drd["precio_orig"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio_orig"]) : (decimal?)null;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valoracumula"]) : (decimal?)null;
                            output.cantcupon = drd.HasColumn("cantcupon") ? drd["cantcupon"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantcupon"]) : (decimal?)null;
                            output.mtocanje = drd.HasColumn("mtocanje") ? drd["mtocanje"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtocanje"]) : (decimal?)null;
                            output.mtopercepcion = drd.HasColumn("mtopercepcion") ? drd["mtopercepcion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopercepcion"]) : (decimal?)null;
                            output.redondea_indecopi = drd.HasColumn("redondea_indecopi") ? drd["redondea_indecopi"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["redondea_indecopi"]) : (decimal?)null;
                            output.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoimpuesto"]) : (decimal?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtototal"]) : (decimal?)null;
                            output.tcambio = drd.HasColumn("tcambio") ? drd["tcambio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["tcambio"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.mtorecaudo = drd.HasColumn("mtorecaudo") ? drd["mtorecaudo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtorecaudo"]) : (decimal?)null;
                            output.ptosganados = drd.HasColumn("ptosganados") ? drd["ptosganados"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ptosganados"]) : (decimal?)null;
                            output.pordsctoeq = drd.HasColumn("pordsctoeq") ? drd["pordsctoeq"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordsctoeq"]) : (decimal?)null;
                            output.mtonoafecto = drd.HasColumn("mtonoafecto") ? drd["mtonoafecto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtonoafecto"]) : (decimal?)null;
                            output.valorvta = drd.HasColumn("valorvta") ? drd["valorvta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorvta"]) : (decimal?)null;
                            output.mtodscto = drd.HasColumn("mtodscto") ? drd["mtodscto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodscto"]) : (decimal?)null;
                            output.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtosubtotal"]) : (decimal?)null;
                            output.mtoservicio = drd.HasColumn("mtoservicio") ? drd["mtoservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoservicio"]) : (decimal?)null;
                            output.nroplaca = drd.HasColumn("nroplaca") ? drd["nroplaca"] == DBNull.Value ? null : drd["nroplaca"].ToString() : null;
                            output.observacion = drd.HasColumn("observacion") ? drd["observacion"] == DBNull.Value ? null : drd["observacion"].ToString() : null;
                            output.referencia = drd.HasColumn("referencia") ? drd["referencia"] == DBNull.Value ? null : drd["referencia"].ToString() : null;
                            output.c_centralizacion = drd.HasColumn("c_centralizacion") ? drd["c_centralizacion"] == DBNull.Value ? null : drd["c_centralizacion"].ToString() : null;
                            output.codes = drd.HasColumn("codes") ? drd["codes"] == DBNull.Value ? null : drd["codes"].ToString() : null;
                            output.codeid = drd.HasColumn("codeid") ? drd["codeid"] == DBNull.Value ? null : drd["codeid"].ToString() : null;
                            output.mensaje1 = drd.HasColumn("mensaje1") ? drd["mensaje1"] == DBNull.Value ? null : drd["mensaje1"].ToString() : null;
                            output.mensaje2 = drd.HasColumn("mensaje2") ? drd["mensaje2"] == DBNull.Value ? null : drd["mensaje2"].ToString() : null;
                            output.pdf417 = drd.HasColumn("pdf417") ? drd["pdf417"] == DBNull.Value ? null : drd["pdf417"].ToString() : null;
                            output.cdhash = drd.HasColumn("cdhash") ? drd["cdhash"] == DBNull.Value ? null : drd["cdhash"].ToString() : null;
                            output.scop = drd.HasColumn("scop") ? drd["scop"] == DBNull.Value ? null : drd["scop"].ToString() : null;
                            output.nroguia = drd.HasColumn("nroguia") ? drd["nroguia"] == DBNull.Value ? null : drd["nroguia"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.nrocelular = drd.HasColumn("nrocelular") ? drd["nrocelular"] == DBNull.Value ? null : drd["nrocelular"].ToString() : null;
                            output.tipoacumula = drd.HasColumn("tipoacumula") ? drd["tipoacumula"] == DBNull.Value ? null : drd["tipoacumula"].ToString() : null;
                            output.cdruta = drd.HasColumn("cdruta") ? drd["cdruta"] == DBNull.Value ? null : drd["cdruta"].ToString() : null;
                            output.ctadetraccion = drd.HasColumn("ctadetraccion") ? drd["ctadetraccion"] == DBNull.Value ? null : drd["ctadetraccion"].ToString() : null;
                            output.cdmedio_pago = drd.HasColumn("cdmedio_pago") ? drd["cdmedio_pago"] == DBNull.Value ? null : drd["cdmedio_pago"].ToString() : null;
                            output.odometro = drd.HasColumn("odometro") ? drd["odometro"] == DBNull.Value ? null : drd["odometro"].ToString() : null;
                            output.marcavehic = drd.HasColumn("marcavehic") ? drd["marcavehic"] == DBNull.Value ? null : drd["marcavehic"].ToString() : null;
                            output.inscripcion = drd.HasColumn("inscripcion") ? drd["inscripcion"] == DBNull.Value ? null : drd["inscripcion"].ToString() : null;
                            output.chofer = drd.HasColumn("chofer") ? drd["chofer"] == DBNull.Value ? null : drd["chofer"].ToString() : null;
                            output.nrolicencia = drd.HasColumn("nrolicencia") ? drd["nrolicencia"] == DBNull.Value ? null : drd["nrolicencia"].ToString() : null;
                            output.tipoventa = drd.HasColumn("tipoventa") ? drd["tipoventa"] == DBNull.Value ? null : drd["tipoventa"].ToString() : null;
                            output.tipofactura = drd.HasColumn("tipofactura") ? drd["tipofactura"] == DBNull.Value ? null : drd["tipofactura"].ToString() : null;
                            output.nroocompra = drd.HasColumn("nroocompra") ? drd["nroocompra"] == DBNull.Value ? null : drd["nroocompra"].ToString() : null;
                            output.nroserie1 = drd.HasColumn("nroserie1") ? drd["nroserie1"] == DBNull.Value ? null : drd["nroserie1"].ToString() : null;
                            output.nroserie2 = drd.HasColumn("nroserie2") ? drd["nroserie2"] == DBNull.Value ? null : drd["nroserie2"].ToString() : null;
                            output.nrobonus = drd.HasColumn("nrobonus") ? drd["nrobonus"] == DBNull.Value ? null : drd["nrobonus"].ToString() : null;
                            output.nrotarjeta = drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? null : drd["nrotarjeta"].ToString() : null;
                            output.cdtranspor = drd.HasColumn("cdtranspor") ? drd["cdtranspor"] == DBNull.Value ? null : drd["cdtranspor"].ToString() : null;
                            output.drpartida = drd.HasColumn("drpartida") ? drd["drpartida"] == DBNull.Value ? null : drd["drpartida"].ToString() : null;
                            output.drdestino = drd.HasColumn("drdestino") ? drd["drdestino"] == DBNull.Value ? null : drd["drdestino"].ToString() : null;
                            output.cdusuario = drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString() : null;
                            output.cdvendedor = drd.HasColumn("cdvendedor") ? drd["cdvendedor"] == DBNull.Value ? null : drd["cdvendedor"].ToString() : null;
                            output.cdusuanula = drd.HasColumn("cdusuanula") ? drd["cdusuanula"] == DBNull.Value ? null : drd["cdusuanula"].ToString() : null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;
                            output.rscliente = drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? null : drd["rscliente"].ToString() : null;
                            output.nroproforma = drd.HasColumn("nroproforma") ? drd["nroproforma"] == DBNull.Value ? null : drd["nroproforma"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.cdmoneda = drd.HasColumn("cdmoneda") ? drd["cdmoneda"] == DBNull.Value ? null : drd["cdmoneda"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVentad> SP_ITBCP_LISTAR_VENTA_5(TS_BEVentad input)
        {
            List<TS_BEVentad> lista = new List<TS_BEVentad>();
            TS_BEVentad output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VENTA_5", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                    cmd.Parameters.Add("@Turno", SqlDbType.Decimal, 5).Value = input.turno;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVentad();
                            output.glosa = drd.HasColumn("glosa") ? drd["glosa"] == DBNull.Value ? null : drd["glosa"].ToString() : null;
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.flgcierrez = drd.HasColumn("flgcierrez") ? drd["flgcierrez"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrez"]) : false;
                            output.moverstock = drd.HasColumn("moverstock") ? drd["moverstock"] == DBNull.Value ? false : Convert.ToBoolean(drd["moverstock"]) : false;
                            output.archturno = drd.HasColumn("archturno") ? drd["archturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["archturno"]) : false;
                            output.trfgratuita = drd.HasColumn("trfgratuita") ? drd["trfgratuita"] == DBNull.Value ? false : Convert.ToBoolean(drd["trfgratuita"]) : false;
                            output.nroitem = drd.HasColumn("nroitem") ? drd["nroitem"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nroitem"]) : (decimal?)null;
                            output.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["impuesto"]) : (decimal?)null;
                            output.pordscto1 = drd.HasColumn("pordscto1") ? drd["pordscto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto1"]) : (decimal?)null;
                            output.pordscto2 = drd.HasColumn("pordscto2") ? drd["pordscto2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto2"]) : (decimal?)null;
                            output.pordscto3 = drd.HasColumn("pordscto3") ? drd["pordscto3"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto3"]) : (decimal?)null;
                            output.pordsctoeq = drd.HasColumn("pordsctoeq") ? drd["pordsctoeq"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordsctoeq"]) : (decimal?)null;
                            output.redondea_indecopi = drd.HasColumn("redondea_indecopi") ? drd["redondea_indecopi"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["redondea_indecopi"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcdetraccion"]) : (decimal?)null;
                            output.mtodetraccion = drd.HasColumn("mtodetraccion") ? drd["mtodetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodetraccion"]) : (decimal?)null;
                            output.precio_orig = drd.HasColumn("precio_orig") ? drd["precio_orig"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio_orig"]) : (decimal?)null;
                            output.ptosganados = drd.HasColumn("ptosganados") ? drd["ptosganados"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ptosganados"]) : (decimal?)null;
                            output.precioafiliacion = drd.HasColumn("precioafiliacion") ? drd["precioafiliacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precioafiliacion"]) : (decimal?)null;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valoracumula"]) : (decimal?)null;
                            output.costo_venta = drd.HasColumn("costo_venta") ? drd["costo_venta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["costo_venta"]) : (decimal?)null;
                            output.mtopercepcion = drd.HasColumn("mtopercepcion") ? drd["mtopercepcion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopercepcion"]) : (decimal?)null;
                            output.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtosubtotal"]) : (decimal?)null;
                            output.mtoservicio = drd.HasColumn("mtoservicio") ? drd["mtoservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoservicio"]) : (decimal?)null;
                            output.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoimpuesto"]) : (decimal?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtototal"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? null : drd["turno"].ToString() : null;
                            output.costo = drd.HasColumn("costo") ? drd["costo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["costo"]) : (decimal?)null;
                            output.cantidad = drd.HasColumn("cantidad") ? drd["cantidad"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantidad"]) : (decimal?)null;
                            output.cant_ncredito = drd.HasColumn("cant_ncredito") ? drd["cant_ncredito"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cant_ncredito"]) : (decimal?)null;
                            output.precio = drd.HasColumn("precio") ? drd["precio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio"]) : (decimal?)null;
                            output.mtonoafecto = drd.HasColumn("mtonoafecto") ? drd["mtonoafecto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtonoafecto"]) : (decimal?)null;
                            output.valorvta = drd.HasColumn("valorvta") ? drd["valorvta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorvta"]) : (decimal?)null;
                            output.mtodscto = drd.HasColumn("mtodscto") ? drd["mtodscto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodscto"]) : (decimal?)null;
                            output.tiposuma = drd.HasColumn("tiposuma") ? drd["tiposuma"] == DBNull.Value ? null : drd["tiposuma"].ToString() : null;
                            output.cdpack = drd.HasColumn("cdpack") ? drd["cdpack"] == DBNull.Value ? null : drd["cdpack"].ToString() : null;
                            output.cdarticulosunat = drd.HasColumn("cdarticulosunat") ? drd["cdarticulosunat"] == DBNull.Value ? null : drd["cdarticulosunat"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.nroproforma = drd.HasColumn("nroproforma") ? drd["nroproforma"] == DBNull.Value ? null : drd["nroproforma"].ToString() : null;
                            output.manguera = drd.HasColumn("manguera") ? drd["manguera"] == DBNull.Value ? null : drd["manguera"].ToString() : null;
                            output.tipoacumula = drd.HasColumn("tipoacumula") ? drd["tipoacumula"] == DBNull.Value ? null : drd["tipoacumula"].ToString() : null;
                            output.cdalterna = drd.HasColumn("cdalterna") ? drd["cdalterna"] == DBNull.Value ? null : drd["cdalterna"].ToString() : null;
                            output.talla = drd.HasColumn("talla") ? drd["talla"] == DBNull.Value ? null : drd["talla"].ToString() : null;
                            output.cdvendedor = drd.HasColumn("cdvendedor") ? drd["cdvendedor"] == DBNull.Value ? null : drd["cdvendedor"].ToString() : null;
                            output.cara = drd.HasColumn("cara") ? drd["cara"] == DBNull.Value ? null : drd["cara"].ToString() : null;
                            output.nrogasboy = drd.HasColumn("nrogasboy") ? drd["nrogasboy"] == DBNull.Value ? null : drd["nrogasboy"].ToString() : null;
                            output.nroguia = drd.HasColumn("nroguia") ? drd["nroguia"] == DBNull.Value ? null : drd["nroguia"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_4(TS_BEVenta input)
        {
            List<TS_BEVenta> lista = new List<TS_BEVenta>();
            TS_BEVenta output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VENTA_4", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                    cmd.Parameters.Add("@Turno", SqlDbType.Decimal, 5).Value = input.turno;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVenta();
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.fecanula = drd.HasColumn("fecanula") ? drd["fecanula"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanula"]) : (DateTime?)null;
                            output.fecanulasis = drd.HasColumn("fecanulasis") ? drd["fecanulasis"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanulasis"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.fecsistema = drd.HasColumn("fecsistema") ? drd["fecsistema"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecsistema"]) : (DateTime?)null;
                            output.flgmanual = drd.HasColumn("flgmanual") ? drd["flgmanual"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmanual"]) : false;
                            output.flgcierrez = drd.HasColumn("flgcierrez") ? drd["flgcierrez"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrez"]) : false;
                            output.flgmovimiento = drd.HasColumn("flgmovimiento") ? drd["flgmovimiento"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmovimiento"]) : false;
                            output.archturno = drd.HasColumn("archturno") ? drd["archturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["archturno"]) : false;
                            output.chkespecial = drd.HasColumn("chkespecial") ? drd["chkespecial"] == DBNull.Value ? false : Convert.ToBoolean(drd["chkespecial"]) : false;
                            output.rucinvalido = drd.HasColumn("rucinvalido") ? drd["rucinvalido"] == DBNull.Value ? false : Convert.ToBoolean(drd["rucinvalido"]) : false;
                            output.usadecimales = drd.HasColumn("usadecimales") ? drd["usadecimales"] == DBNull.Value ? false : Convert.ToBoolean(drd["usadecimales"]) : false;
                            output.fact_elect = drd.HasColumn("fact_elect") ? drd["fact_elect"] == DBNull.Value ? false : Convert.ToBoolean(drd["fact_elect"]) : false;
                            output.mtovueltosol = drd.HasColumn("mtovueltosol") ? drd["mtovueltosol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltosol"]) : (decimal?)null;
                            output.mtovueltodol = drd.HasColumn("mtovueltodol") ? drd["mtovueltodol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltodol"]) : (decimal?)null;
                            output.porservicio = drd.HasColumn("porservicio") ? drd["porservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porservicio"]) : (decimal?)null;
                            output.pordscto1 = drd.HasColumn("pordscto1") ? drd["pordscto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto1"]) : (decimal?)null;
                            output.pordscto2 = drd.HasColumn("pordscto2") ? drd["pordscto2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto2"]) : (decimal?)null;
                            output.pordscto3 = drd.HasColumn("pordscto3") ? drd["pordscto3"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto3"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcdetraccion"]) : (decimal?)null;
                            output.mtodetraccion = drd.HasColumn("mtodetraccion") ? drd["mtodetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodetraccion"]) : (decimal?)null;
                            output.precio_orig = drd.HasColumn("precio_orig") ? drd["precio_orig"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio_orig"]) : (decimal?)null;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valoracumula"]) : (decimal?)null;
                            output.cantcupon = drd.HasColumn("cantcupon") ? drd["cantcupon"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantcupon"]) : (decimal?)null;
                            output.mtocanje = drd.HasColumn("mtocanje") ? drd["mtocanje"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtocanje"]) : (decimal?)null;
                            output.mtopercepcion = drd.HasColumn("mtopercepcion") ? drd["mtopercepcion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopercepcion"]) : (decimal?)null;
                            output.redondea_indecopi = drd.HasColumn("redondea_indecopi") ? drd["redondea_indecopi"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["redondea_indecopi"]) : (decimal?)null;
                            output.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoimpuesto"]) : (decimal?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtototal"]) : (decimal?)null;
                            output.tcambio = drd.HasColumn("tcambio") ? drd["tcambio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["tcambio"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.mtorecaudo = drd.HasColumn("mtorecaudo") ? drd["mtorecaudo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtorecaudo"]) : (decimal?)null;
                            output.ptosganados = drd.HasColumn("ptosganados") ? drd["ptosganados"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ptosganados"]) : (decimal?)null;
                            output.pordsctoeq = drd.HasColumn("pordsctoeq") ? drd["pordsctoeq"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordsctoeq"]) : (decimal?)null;
                            output.mtonoafecto = drd.HasColumn("mtonoafecto") ? drd["mtonoafecto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtonoafecto"]) : (decimal?)null;
                            output.valorvta = drd.HasColumn("valorvta") ? drd["valorvta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorvta"]) : (decimal?)null;
                            output.mtodscto = drd.HasColumn("mtodscto") ? drd["mtodscto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodscto"]) : (decimal?)null;
                            output.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtosubtotal"]) : (decimal?)null;
                            output.mtoservicio = drd.HasColumn("mtoservicio") ? drd["mtoservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoservicio"]) : (decimal?)null;
                            output.nroplaca = drd.HasColumn("nroplaca") ? drd["nroplaca"] == DBNull.Value ? null : drd["nroplaca"].ToString() : null;
                            output.observacion = drd.HasColumn("observacion") ? drd["observacion"] == DBNull.Value ? null : drd["observacion"].ToString() : null;
                            output.referencia = drd.HasColumn("referencia") ? drd["referencia"] == DBNull.Value ? null : drd["referencia"].ToString() : null;
                            output.c_centralizacion = drd.HasColumn("c_centralizacion") ? drd["c_centralizacion"] == DBNull.Value ? null : drd["c_centralizacion"].ToString() : null;
                            output.codes = drd.HasColumn("codes") ? drd["codes"] == DBNull.Value ? null : drd["codes"].ToString() : null;
                            output.codeid = drd.HasColumn("codeid") ? drd["codeid"] == DBNull.Value ? null : drd["codeid"].ToString() : null;
                            output.mensaje1 = drd.HasColumn("mensaje1") ? drd["mensaje1"] == DBNull.Value ? null : drd["mensaje1"].ToString() : null;
                            output.mensaje2 = drd.HasColumn("mensaje2") ? drd["mensaje2"] == DBNull.Value ? null : drd["mensaje2"].ToString() : null;
                            output.pdf417 = drd.HasColumn("pdf417") ? drd["pdf417"] == DBNull.Value ? null : drd["pdf417"].ToString() : null;
                            output.cdhash = drd.HasColumn("cdhash") ? drd["cdhash"] == DBNull.Value ? null : drd["cdhash"].ToString() : null;
                            output.scop = drd.HasColumn("scop") ? drd["scop"] == DBNull.Value ? null : drd["scop"].ToString() : null;
                            output.nroguia = drd.HasColumn("nroguia") ? drd["nroguia"] == DBNull.Value ? null : drd["nroguia"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.nrocelular = drd.HasColumn("nrocelular") ? drd["nrocelular"] == DBNull.Value ? null : drd["nrocelular"].ToString() : null;
                            output.tipoacumula = drd.HasColumn("tipoacumula") ? drd["tipoacumula"] == DBNull.Value ? null : drd["tipoacumula"].ToString() : null;
                            output.cdruta = drd.HasColumn("cdruta") ? drd["cdruta"] == DBNull.Value ? null : drd["cdruta"].ToString() : null;
                            output.ctadetraccion = drd.HasColumn("ctadetraccion") ? drd["ctadetraccion"] == DBNull.Value ? null : drd["ctadetraccion"].ToString() : null;
                            output.cdmedio_pago = drd.HasColumn("cdmedio_pago") ? drd["cdmedio_pago"] == DBNull.Value ? null : drd["cdmedio_pago"].ToString() : null;
                            output.odometro = drd.HasColumn("odometro") ? drd["odometro"] == DBNull.Value ? null : drd["odometro"].ToString() : null;
                            output.marcavehic = drd.HasColumn("marcavehic") ? drd["marcavehic"] == DBNull.Value ? null : drd["marcavehic"].ToString() : null;
                            output.inscripcion = drd.HasColumn("inscripcion") ? drd["inscripcion"] == DBNull.Value ? null : drd["inscripcion"].ToString() : null;
                            output.chofer = drd.HasColumn("chofer") ? drd["chofer"] == DBNull.Value ? null : drd["chofer"].ToString() : null;
                            output.nrolicencia = drd.HasColumn("nrolicencia") ? drd["nrolicencia"] == DBNull.Value ? null : drd["nrolicencia"].ToString() : null;
                            output.tipoventa = drd.HasColumn("tipoventa") ? drd["tipoventa"] == DBNull.Value ? null : drd["tipoventa"].ToString() : null;
                            output.tipofactura = drd.HasColumn("tipofactura") ? drd["tipofactura"] == DBNull.Value ? null : drd["tipofactura"].ToString() : null;
                            output.nroocompra = drd.HasColumn("nroocompra") ? drd["nroocompra"] == DBNull.Value ? null : drd["nroocompra"].ToString() : null;
                            output.nroserie1 = drd.HasColumn("nroserie1") ? drd["nroserie1"] == DBNull.Value ? null : drd["nroserie1"].ToString() : null;
                            output.nroserie2 = drd.HasColumn("nroserie2") ? drd["nroserie2"] == DBNull.Value ? null : drd["nroserie2"].ToString() : null;
                            output.nrobonus = drd.HasColumn("nrobonus") ? drd["nrobonus"] == DBNull.Value ? null : drd["nrobonus"].ToString() : null;
                            output.nrotarjeta = drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? null : drd["nrotarjeta"].ToString() : null;
                            output.cdtranspor = drd.HasColumn("cdtranspor") ? drd["cdtranspor"] == DBNull.Value ? null : drd["cdtranspor"].ToString() : null;
                            output.drpartida = drd.HasColumn("drpartida") ? drd["drpartida"] == DBNull.Value ? null : drd["drpartida"].ToString() : null;
                            output.drdestino = drd.HasColumn("drdestino") ? drd["drdestino"] == DBNull.Value ? null : drd["drdestino"].ToString() : null;
                            output.cdusuario = drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString() : null;
                            output.cdvendedor = drd.HasColumn("cdvendedor") ? drd["cdvendedor"] == DBNull.Value ? null : drd["cdvendedor"].ToString() : null;
                            output.cdusuanula = drd.HasColumn("cdusuanula") ? drd["cdusuanula"] == DBNull.Value ? null : drd["cdusuanula"].ToString() : null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;
                            output.rscliente = drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? null : drd["rscliente"].ToString() : null;
                            output.nroproforma = drd.HasColumn("nroproforma") ? drd["nroproforma"] == DBNull.Value ? null : drd["nroproforma"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.cdmoneda = drd.HasColumn("cdmoneda") ? drd["cdmoneda"] == DBNull.Value ? null : drd["cdmoneda"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_3(TS_BEVenta input)
        {
            List<TS_BEVenta> lista = new List<TS_BEVenta>();
            TS_BEVenta output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VENTA_3", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                    cmd.Parameters.Add("@Turno", SqlDbType.Decimal, 5).Value = input.turno;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVenta();
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.fecanula = drd.HasColumn("fecanula") ? drd["fecanula"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanula"]) : (DateTime?)null;
                            output.fecanulasis = drd.HasColumn("fecanulasis") ? drd["fecanulasis"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanulasis"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.fecsistema = drd.HasColumn("fecsistema") ? drd["fecsistema"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecsistema"]) : (DateTime?)null;
                            output.flgmanual = drd.HasColumn("flgmanual") ? drd["flgmanual"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmanual"]) : false;
                            output.flgcierrez = drd.HasColumn("flgcierrez") ? drd["flgcierrez"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrez"]) : false;
                            output.flgmovimiento = drd.HasColumn("flgmovimiento") ? drd["flgmovimiento"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmovimiento"]) : false;
                            output.archturno = drd.HasColumn("archturno") ? drd["archturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["archturno"]) : false;
                            output.chkespecial = drd.HasColumn("chkespecial") ? drd["chkespecial"] == DBNull.Value ? false : Convert.ToBoolean(drd["chkespecial"]) : false;
                            output.rucinvalido = drd.HasColumn("rucinvalido") ? drd["rucinvalido"] == DBNull.Value ? false : Convert.ToBoolean(drd["rucinvalido"]) : false;
                            output.usadecimales = drd.HasColumn("usadecimales") ? drd["usadecimales"] == DBNull.Value ? false : Convert.ToBoolean(drd["usadecimales"]) : false;
                            output.fact_elect = drd.HasColumn("fact_elect") ? drd["fact_elect"] == DBNull.Value ? false : Convert.ToBoolean(drd["fact_elect"]) : false;
                            output.mtovueltosol = drd.HasColumn("mtovueltosol") ? drd["mtovueltosol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltosol"]) : (decimal?)null;
                            output.mtovueltodol = drd.HasColumn("mtovueltodol") ? drd["mtovueltodol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltodol"]) : (decimal?)null;
                            output.porservicio = drd.HasColumn("porservicio") ? drd["porservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porservicio"]) : (decimal?)null;
                            output.pordscto1 = drd.HasColumn("pordscto1") ? drd["pordscto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto1"]) : (decimal?)null;
                            output.pordscto2 = drd.HasColumn("pordscto2") ? drd["pordscto2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto2"]) : (decimal?)null;
                            output.pordscto3 = drd.HasColumn("pordscto3") ? drd["pordscto3"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto3"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcdetraccion"]) : (decimal?)null;
                            output.mtodetraccion = drd.HasColumn("mtodetraccion") ? drd["mtodetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodetraccion"]) : (decimal?)null;
                            output.precio_orig = drd.HasColumn("precio_orig") ? drd["precio_orig"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio_orig"]) : (decimal?)null;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valoracumula"]) : (decimal?)null;
                            output.cantcupon = drd.HasColumn("cantcupon") ? drd["cantcupon"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantcupon"]) : (decimal?)null;
                            output.mtocanje = drd.HasColumn("mtocanje") ? drd["mtocanje"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtocanje"]) : (decimal?)null;
                            output.mtopercepcion = drd.HasColumn("mtopercepcion") ? drd["mtopercepcion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopercepcion"]) : (decimal?)null;
                            output.redondea_indecopi = drd.HasColumn("redondea_indecopi") ? drd["redondea_indecopi"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["redondea_indecopi"]) : (decimal?)null;
                            output.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoimpuesto"]) : (decimal?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtototal"]) : (decimal?)null;
                            output.tcambio = drd.HasColumn("tcambio") ? drd["tcambio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["tcambio"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.mtorecaudo = drd.HasColumn("mtorecaudo") ? drd["mtorecaudo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtorecaudo"]) : (decimal?)null;
                            output.ptosganados = drd.HasColumn("ptosganados") ? drd["ptosganados"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ptosganados"]) : (decimal?)null;
                            output.pordsctoeq = drd.HasColumn("pordsctoeq") ? drd["pordsctoeq"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordsctoeq"]) : (decimal?)null;
                            output.mtonoafecto = drd.HasColumn("mtonoafecto") ? drd["mtonoafecto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtonoafecto"]) : (decimal?)null;
                            output.valorvta = drd.HasColumn("valorvta") ? drd["valorvta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorvta"]) : (decimal?)null;
                            output.mtodscto = drd.HasColumn("mtodscto") ? drd["mtodscto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodscto"]) : (decimal?)null;
                            output.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtosubtotal"]) : (decimal?)null;
                            output.mtoservicio = drd.HasColumn("mtoservicio") ? drd["mtoservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoservicio"]) : (decimal?)null;
                            output.nroplaca = drd.HasColumn("nroplaca") ? drd["nroplaca"] == DBNull.Value ? null : drd["nroplaca"].ToString() : null;
                            output.observacion = drd.HasColumn("observacion") ? drd["observacion"] == DBNull.Value ? null : drd["observacion"].ToString() : null;
                            output.referencia = drd.HasColumn("referencia") ? drd["referencia"] == DBNull.Value ? null : drd["referencia"].ToString() : null;
                            output.c_centralizacion = drd.HasColumn("c_centralizacion") ? drd["c_centralizacion"] == DBNull.Value ? null : drd["c_centralizacion"].ToString() : null;
                            output.codes = drd.HasColumn("codes") ? drd["codes"] == DBNull.Value ? null : drd["codes"].ToString() : null;
                            output.codeid = drd.HasColumn("codeid") ? drd["codeid"] == DBNull.Value ? null : drd["codeid"].ToString() : null;
                            output.mensaje1 = drd.HasColumn("mensaje1") ? drd["mensaje1"] == DBNull.Value ? null : drd["mensaje1"].ToString() : null;
                            output.mensaje2 = drd.HasColumn("mensaje2") ? drd["mensaje2"] == DBNull.Value ? null : drd["mensaje2"].ToString() : null;
                            output.pdf417 = drd.HasColumn("pdf417") ? drd["pdf417"] == DBNull.Value ? null : drd["pdf417"].ToString() : null;
                            output.cdhash = drd.HasColumn("cdhash") ? drd["cdhash"] == DBNull.Value ? null : drd["cdhash"].ToString() : null;
                            output.scop = drd.HasColumn("scop") ? drd["scop"] == DBNull.Value ? null : drd["scop"].ToString() : null;
                            output.nroguia = drd.HasColumn("nroguia") ? drd["nroguia"] == DBNull.Value ? null : drd["nroguia"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.nrocelular = drd.HasColumn("nrocelular") ? drd["nrocelular"] == DBNull.Value ? null : drd["nrocelular"].ToString() : null;
                            output.tipoacumula = drd.HasColumn("tipoacumula") ? drd["tipoacumula"] == DBNull.Value ? null : drd["tipoacumula"].ToString() : null;
                            output.cdruta = drd.HasColumn("cdruta") ? drd["cdruta"] == DBNull.Value ? null : drd["cdruta"].ToString() : null;
                            output.ctadetraccion = drd.HasColumn("ctadetraccion") ? drd["ctadetraccion"] == DBNull.Value ? null : drd["ctadetraccion"].ToString() : null;
                            output.cdmedio_pago = drd.HasColumn("cdmedio_pago") ? drd["cdmedio_pago"] == DBNull.Value ? null : drd["cdmedio_pago"].ToString() : null;
                            output.odometro = drd.HasColumn("odometro") ? drd["odometro"] == DBNull.Value ? null : drd["odometro"].ToString() : null;
                            output.marcavehic = drd.HasColumn("marcavehic") ? drd["marcavehic"] == DBNull.Value ? null : drd["marcavehic"].ToString() : null;
                            output.inscripcion = drd.HasColumn("inscripcion") ? drd["inscripcion"] == DBNull.Value ? null : drd["inscripcion"].ToString() : null;
                            output.chofer = drd.HasColumn("chofer") ? drd["chofer"] == DBNull.Value ? null : drd["chofer"].ToString() : null;
                            output.nrolicencia = drd.HasColumn("nrolicencia") ? drd["nrolicencia"] == DBNull.Value ? null : drd["nrolicencia"].ToString() : null;
                            output.tipoventa = drd.HasColumn("tipoventa") ? drd["tipoventa"] == DBNull.Value ? null : drd["tipoventa"].ToString() : null;
                            output.tipofactura = drd.HasColumn("tipofactura") ? drd["tipofactura"] == DBNull.Value ? null : drd["tipofactura"].ToString() : null;
                            output.nroocompra = drd.HasColumn("nroocompra") ? drd["nroocompra"] == DBNull.Value ? null : drd["nroocompra"].ToString() : null;
                            output.nroserie1 = drd.HasColumn("nroserie1") ? drd["nroserie1"] == DBNull.Value ? null : drd["nroserie1"].ToString() : null;
                            output.nroserie2 = drd.HasColumn("nroserie2") ? drd["nroserie2"] == DBNull.Value ? null : drd["nroserie2"].ToString() : null;
                            output.nrobonus = drd.HasColumn("nrobonus") ? drd["nrobonus"] == DBNull.Value ? null : drd["nrobonus"].ToString() : null;
                            output.nrotarjeta = drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? null : drd["nrotarjeta"].ToString() : null;
                            output.cdtranspor = drd.HasColumn("cdtranspor") ? drd["cdtranspor"] == DBNull.Value ? null : drd["cdtranspor"].ToString() : null;
                            output.drpartida = drd.HasColumn("drpartida") ? drd["drpartida"] == DBNull.Value ? null : drd["drpartida"].ToString() : null;
                            output.drdestino = drd.HasColumn("drdestino") ? drd["drdestino"] == DBNull.Value ? null : drd["drdestino"].ToString() : null;
                            output.cdusuario = drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString() : null;
                            output.cdvendedor = drd.HasColumn("cdvendedor") ? drd["cdvendedor"] == DBNull.Value ? null : drd["cdvendedor"].ToString() : null;
                            output.cdusuanula = drd.HasColumn("cdusuanula") ? drd["cdusuanula"] == DBNull.Value ? null : drd["cdusuanula"].ToString() : null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;
                            output.rscliente = drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? null : drd["rscliente"].ToString() : null;
                            output.nroproforma = drd.HasColumn("nroproforma") ? drd["nroproforma"] == DBNull.Value ? null : drd["nroproforma"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.cdmoneda = drd.HasColumn("cdmoneda") ? drd["cdmoneda"] == DBNull.Value ? null : drd["cdmoneda"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_2(TS_BEVenta input)
        {
            List<TS_BEVenta> lista = new List<TS_BEVenta>();
            TS_BEVenta output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VENTA_2", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                    cmd.Parameters.Add("@Turno", SqlDbType.Decimal, 5).Value = input.turno;
                    cmd.Parameters.Add("@CDGRUPO02", SqlDbType.Char, 5).Value = input.cdgrupo02;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVenta();
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.fecanula = drd.HasColumn("fecanula") ? drd["fecanula"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanula"]) : (DateTime?)null;
                            output.fecanulasis = drd.HasColumn("fecanulasis") ? drd["fecanulasis"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanulasis"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.fecsistema = drd.HasColumn("fecsistema") ? drd["fecsistema"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecsistema"]) : (DateTime?)null;
                            output.flgmanual = drd.HasColumn("flgmanual") ? drd["flgmanual"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmanual"]) : false;
                            output.flgcierrez = drd.HasColumn("flgcierrez") ? drd["flgcierrez"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrez"]) : false;
                            output.flgmovimiento = drd.HasColumn("flgmovimiento") ? drd["flgmovimiento"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmovimiento"]) : false;
                            output.archturno = drd.HasColumn("archturno") ? drd["archturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["archturno"]) : false;
                            output.chkespecial = drd.HasColumn("chkespecial") ? drd["chkespecial"] == DBNull.Value ? false : Convert.ToBoolean(drd["chkespecial"]) : false;
                            output.rucinvalido = drd.HasColumn("rucinvalido") ? drd["rucinvalido"] == DBNull.Value ? false : Convert.ToBoolean(drd["rucinvalido"]) : false;
                            output.usadecimales = drd.HasColumn("usadecimales") ? drd["usadecimales"] == DBNull.Value ? false : Convert.ToBoolean(drd["usadecimales"]) : false;
                            output.fact_elect = drd.HasColumn("fact_elect") ? drd["fact_elect"] == DBNull.Value ? false : Convert.ToBoolean(drd["fact_elect"]) : false;
                            output.mtovueltosol = drd.HasColumn("mtovueltosol") ? drd["mtovueltosol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltosol"]) : (decimal?)null;
                            output.mtovueltodol = drd.HasColumn("mtovueltodol") ? drd["mtovueltodol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltodol"]) : (decimal?)null;
                            output.porservicio = drd.HasColumn("porservicio") ? drd["porservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porservicio"]) : (decimal?)null;
                            output.pordscto1 = drd.HasColumn("pordscto1") ? drd["pordscto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto1"]) : (decimal?)null;
                            output.pordscto2 = drd.HasColumn("pordscto2") ? drd["pordscto2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto2"]) : (decimal?)null;
                            output.pordscto3 = drd.HasColumn("pordscto3") ? drd["pordscto3"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto3"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcdetraccion"]) : (decimal?)null;
                            output.mtodetraccion = drd.HasColumn("mtodetraccion") ? drd["mtodetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodetraccion"]) : (decimal?)null;
                            output.precio_orig = drd.HasColumn("precio_orig") ? drd["precio_orig"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio_orig"]) : (decimal?)null;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valoracumula"]) : (decimal?)null;
                            output.cantcupon = drd.HasColumn("cantcupon") ? drd["cantcupon"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantcupon"]) : (decimal?)null;
                            output.mtocanje = drd.HasColumn("mtocanje") ? drd["mtocanje"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtocanje"]) : (decimal?)null;
                            output.mtopercepcion = drd.HasColumn("mtopercepcion") ? drd["mtopercepcion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopercepcion"]) : (decimal?)null;
                            output.redondea_indecopi = drd.HasColumn("redondea_indecopi") ? drd["redondea_indecopi"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["redondea_indecopi"]) : (decimal?)null;
                            output.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoimpuesto"]) : (decimal?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtototal"]) : (decimal?)null;
                            output.tcambio = drd.HasColumn("tcambio") ? drd["tcambio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["tcambio"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.mtorecaudo = drd.HasColumn("mtorecaudo") ? drd["mtorecaudo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtorecaudo"]) : (decimal?)null;
                            output.ptosganados = drd.HasColumn("ptosganados") ? drd["ptosganados"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ptosganados"]) : (decimal?)null;
                            output.pordsctoeq = drd.HasColumn("pordsctoeq") ? drd["pordsctoeq"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordsctoeq"]) : (decimal?)null;
                            output.mtonoafecto = drd.HasColumn("mtonoafecto") ? drd["mtonoafecto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtonoafecto"]) : (decimal?)null;
                            output.valorvta = drd.HasColumn("valorvta") ? drd["valorvta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorvta"]) : (decimal?)null;
                            output.mtodscto = drd.HasColumn("mtodscto") ? drd["mtodscto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodscto"]) : (decimal?)null;
                            output.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtosubtotal"]) : (decimal?)null;
                            output.mtoservicio = drd.HasColumn("mtoservicio") ? drd["mtoservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoservicio"]) : (decimal?)null;
                            output.nroplaca = drd.HasColumn("nroplaca") ? drd["nroplaca"] == DBNull.Value ? null : drd["nroplaca"].ToString() : null;
                            output.observacion = drd.HasColumn("observacion") ? drd["observacion"] == DBNull.Value ? null : drd["observacion"].ToString() : null;
                            output.referencia = drd.HasColumn("referencia") ? drd["referencia"] == DBNull.Value ? null : drd["referencia"].ToString() : null;
                            output.c_centralizacion = drd.HasColumn("c_centralizacion") ? drd["c_centralizacion"] == DBNull.Value ? null : drd["c_centralizacion"].ToString() : null;
                            output.codes = drd.HasColumn("codes") ? drd["codes"] == DBNull.Value ? null : drd["codes"].ToString() : null;
                            output.codeid = drd.HasColumn("codeid") ? drd["codeid"] == DBNull.Value ? null : drd["codeid"].ToString() : null;
                            output.mensaje1 = drd.HasColumn("mensaje1") ? drd["mensaje1"] == DBNull.Value ? null : drd["mensaje1"].ToString() : null;
                            output.mensaje2 = drd.HasColumn("mensaje2") ? drd["mensaje2"] == DBNull.Value ? null : drd["mensaje2"].ToString() : null;
                            output.pdf417 = drd.HasColumn("pdf417") ? drd["pdf417"] == DBNull.Value ? null : drd["pdf417"].ToString() : null;
                            output.cdhash = drd.HasColumn("cdhash") ? drd["cdhash"] == DBNull.Value ? null : drd["cdhash"].ToString() : null;
                            output.scop = drd.HasColumn("scop") ? drd["scop"] == DBNull.Value ? null : drd["scop"].ToString() : null;
                            output.nroguia = drd.HasColumn("nroguia") ? drd["nroguia"] == DBNull.Value ? null : drd["nroguia"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.nrocelular = drd.HasColumn("nrocelular") ? drd["nrocelular"] == DBNull.Value ? null : drd["nrocelular"].ToString() : null;
                            output.tipoacumula = drd.HasColumn("tipoacumula") ? drd["tipoacumula"] == DBNull.Value ? null : drd["tipoacumula"].ToString() : null;
                            output.cdruta = drd.HasColumn("cdruta") ? drd["cdruta"] == DBNull.Value ? null : drd["cdruta"].ToString() : null;
                            output.ctadetraccion = drd.HasColumn("ctadetraccion") ? drd["ctadetraccion"] == DBNull.Value ? null : drd["ctadetraccion"].ToString() : null;
                            output.cdmedio_pago = drd.HasColumn("cdmedio_pago") ? drd["cdmedio_pago"] == DBNull.Value ? null : drd["cdmedio_pago"].ToString() : null;
                            output.odometro = drd.HasColumn("odometro") ? drd["odometro"] == DBNull.Value ? null : drd["odometro"].ToString() : null;
                            output.marcavehic = drd.HasColumn("marcavehic") ? drd["marcavehic"] == DBNull.Value ? null : drd["marcavehic"].ToString() : null;
                            output.inscripcion = drd.HasColumn("inscripcion") ? drd["inscripcion"] == DBNull.Value ? null : drd["inscripcion"].ToString() : null;
                            output.chofer = drd.HasColumn("chofer") ? drd["chofer"] == DBNull.Value ? null : drd["chofer"].ToString() : null;
                            output.nrolicencia = drd.HasColumn("nrolicencia") ? drd["nrolicencia"] == DBNull.Value ? null : drd["nrolicencia"].ToString() : null;
                            output.tipoventa = drd.HasColumn("tipoventa") ? drd["tipoventa"] == DBNull.Value ? null : drd["tipoventa"].ToString() : null;
                            output.tipofactura = drd.HasColumn("tipofactura") ? drd["tipofactura"] == DBNull.Value ? null : drd["tipofactura"].ToString() : null;
                            output.nroocompra = drd.HasColumn("nroocompra") ? drd["nroocompra"] == DBNull.Value ? null : drd["nroocompra"].ToString() : null;
                            output.nroserie1 = drd.HasColumn("nroserie1") ? drd["nroserie1"] == DBNull.Value ? null : drd["nroserie1"].ToString() : null;
                            output.nroserie2 = drd.HasColumn("nroserie2") ? drd["nroserie2"] == DBNull.Value ? null : drd["nroserie2"].ToString() : null;
                            output.nrobonus = drd.HasColumn("nrobonus") ? drd["nrobonus"] == DBNull.Value ? null : drd["nrobonus"].ToString() : null;
                            output.nrotarjeta = drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? null : drd["nrotarjeta"].ToString() : null;
                            output.cdtranspor = drd.HasColumn("cdtranspor") ? drd["cdtranspor"] == DBNull.Value ? null : drd["cdtranspor"].ToString() : null;
                            output.drpartida = drd.HasColumn("drpartida") ? drd["drpartida"] == DBNull.Value ? null : drd["drpartida"].ToString() : null;
                            output.drdestino = drd.HasColumn("drdestino") ? drd["drdestino"] == DBNull.Value ? null : drd["drdestino"].ToString() : null;
                            output.cdusuario = drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString() : null;
                            output.cdvendedor = drd.HasColumn("cdvendedor") ? drd["cdvendedor"] == DBNull.Value ? null : drd["cdvendedor"].ToString() : null;
                            output.cdusuanula = drd.HasColumn("cdusuanula") ? drd["cdusuanula"] == DBNull.Value ? null : drd["cdusuanula"].ToString() : null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;
                            output.rscliente = drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? null : drd["rscliente"].ToString() : null;
                            output.nroproforma = drd.HasColumn("nroproforma") ? drd["nroproforma"] == DBNull.Value ? null : drd["nroproforma"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.cdmoneda = drd.HasColumn("cdmoneda") ? drd["cdmoneda"] == DBNull.Value ? null : drd["cdmoneda"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA(TS_BEVenta input)
        {
            List<TS_BEVenta> lista = new List<TS_BEVenta>();
            TS_BEVenta output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VENTA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                    cmd.Parameters.Add("@Turno", SqlDbType.Decimal, 5).Value = input.turno;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVenta();
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.fecanula = drd.HasColumn("fecanula") ? drd["fecanula"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanula"]) : (DateTime?)null;
                            output.fecanulasis = drd.HasColumn("fecanulasis") ? drd["fecanulasis"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanulasis"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.fecsistema = drd.HasColumn("fecsistema") ? drd["fecsistema"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecsistema"]) : (DateTime?)null;
                            output.flgmanual = drd.HasColumn("flgmanual") ? drd["flgmanual"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmanual"]) : false;
                            output.flgcierrez = drd.HasColumn("flgcierrez") ? drd["flgcierrez"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrez"]) : false;
                            output.flgmovimiento = drd.HasColumn("flgmovimiento") ? drd["flgmovimiento"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmovimiento"]) : false;
                            output.archturno = drd.HasColumn("archturno") ? drd["archturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["archturno"]) : false;
                            output.chkespecial = drd.HasColumn("chkespecial") ? drd["chkespecial"] == DBNull.Value ? false : Convert.ToBoolean(drd["chkespecial"]) : false;
                            output.rucinvalido = drd.HasColumn("rucinvalido") ? drd["rucinvalido"] == DBNull.Value ? false : Convert.ToBoolean(drd["rucinvalido"]) : false;
                            output.usadecimales = drd.HasColumn("usadecimales") ? drd["usadecimales"] == DBNull.Value ? false : Convert.ToBoolean(drd["usadecimales"]) : false;
                            output.fact_elect = drd.HasColumn("fact_elect") ? drd["fact_elect"] == DBNull.Value ? false : Convert.ToBoolean(drd["fact_elect"]) : false;
                            output.mtovueltosol = drd.HasColumn("mtovueltosol") ? drd["mtovueltosol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltosol"]) : (decimal?)null;
                            output.mtovueltodol = drd.HasColumn("mtovueltodol") ? drd["mtovueltodol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltodol"]) : (decimal?)null;
                            output.porservicio = drd.HasColumn("porservicio") ? drd["porservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porservicio"]) : (decimal?)null;
                            output.pordscto1 = drd.HasColumn("pordscto1") ? drd["pordscto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto1"]) : (decimal?)null;
                            output.pordscto2 = drd.HasColumn("pordscto2") ? drd["pordscto2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto2"]) : (decimal?)null;
                            output.pordscto3 = drd.HasColumn("pordscto3") ? drd["pordscto3"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto3"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcdetraccion"]) : (decimal?)null;
                            output.mtodetraccion = drd.HasColumn("mtodetraccion") ? drd["mtodetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodetraccion"]) : (decimal?)null;
                            output.precio_orig = drd.HasColumn("precio_orig") ? drd["precio_orig"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio_orig"]) : (decimal?)null;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valoracumula"]) : (decimal?)null;
                            output.cantcupon = drd.HasColumn("cantcupon") ? drd["cantcupon"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantcupon"]) : (decimal?)null;
                            output.mtocanje = drd.HasColumn("mtocanje") ? drd["mtocanje"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtocanje"]) : (decimal?)null;
                            output.mtopercepcion = drd.HasColumn("mtopercepcion") ? drd["mtopercepcion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopercepcion"]) : (decimal?)null;
                            output.redondea_indecopi = drd.HasColumn("redondea_indecopi") ? drd["redondea_indecopi"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["redondea_indecopi"]) : (decimal?)null;
                            output.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoimpuesto"]) : (decimal?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtototal"]) : (decimal?)null;
                            output.tcambio = drd.HasColumn("tcambio") ? drd["tcambio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["tcambio"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.mtorecaudo = drd.HasColumn("mtorecaudo") ? drd["mtorecaudo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtorecaudo"]) : (decimal?)null;
                            output.ptosganados = drd.HasColumn("ptosganados") ? drd["ptosganados"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ptosganados"]) : (decimal?)null;
                            output.pordsctoeq = drd.HasColumn("pordsctoeq") ? drd["pordsctoeq"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordsctoeq"]) : (decimal?)null;
                            output.mtonoafecto = drd.HasColumn("mtonoafecto") ? drd["mtonoafecto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtonoafecto"]) : (decimal?)null;
                            output.valorvta = drd.HasColumn("valorvta") ? drd["valorvta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorvta"]) : (decimal?)null;
                            output.mtodscto = drd.HasColumn("mtodscto") ? drd["mtodscto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodscto"]) : (decimal?)null;
                            output.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtosubtotal"]) : (decimal?)null;
                            output.mtoservicio = drd.HasColumn("mtoservicio") ? drd["mtoservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoservicio"]) : (decimal?)null;
                            output.nroplaca = drd.HasColumn("nroplaca") ? drd["nroplaca"] == DBNull.Value ? null : drd["nroplaca"].ToString() : null;
                            output.observacion = drd.HasColumn("observacion") ? drd["observacion"] == DBNull.Value ? null : drd["observacion"].ToString() : null;
                            output.referencia = drd.HasColumn("referencia") ? drd["referencia"] == DBNull.Value ? null : drd["referencia"].ToString() : null;
                            output.c_centralizacion = drd.HasColumn("c_centralizacion") ? drd["c_centralizacion"] == DBNull.Value ? null : drd["c_centralizacion"].ToString() : null;
                            output.codes = drd.HasColumn("codes") ? drd["codes"] == DBNull.Value ? null : drd["codes"].ToString() : null;
                            output.codeid = drd.HasColumn("codeid") ? drd["codeid"] == DBNull.Value ? null : drd["codeid"].ToString() : null;
                            output.mensaje1 = drd.HasColumn("mensaje1") ? drd["mensaje1"] == DBNull.Value ? null : drd["mensaje1"].ToString() : null;
                            output.mensaje2 = drd.HasColumn("mensaje2") ? drd["mensaje2"] == DBNull.Value ? null : drd["mensaje2"].ToString() : null;
                            output.pdf417 = drd.HasColumn("pdf417") ? drd["pdf417"] == DBNull.Value ? null : drd["pdf417"].ToString() : null;
                            output.cdhash = drd.HasColumn("cdhash") ? drd["cdhash"] == DBNull.Value ? null : drd["cdhash"].ToString() : null;
                            output.scop = drd.HasColumn("scop") ? drd["scop"] == DBNull.Value ? null : drd["scop"].ToString() : null;
                            output.nroguia = drd.HasColumn("nroguia") ? drd["nroguia"] == DBNull.Value ? null : drd["nroguia"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.nrocelular = drd.HasColumn("nrocelular") ? drd["nrocelular"] == DBNull.Value ? null : drd["nrocelular"].ToString() : null;
                            output.tipoacumula = drd.HasColumn("tipoacumula") ? drd["tipoacumula"] == DBNull.Value ? null : drd["tipoacumula"].ToString() : null;
                            output.cdruta = drd.HasColumn("cdruta") ? drd["cdruta"] == DBNull.Value ? null : drd["cdruta"].ToString() : null;
                            output.ctadetraccion = drd.HasColumn("ctadetraccion") ? drd["ctadetraccion"] == DBNull.Value ? null : drd["ctadetraccion"].ToString() : null;
                            output.cdmedio_pago = drd.HasColumn("cdmedio_pago") ? drd["cdmedio_pago"] == DBNull.Value ? null : drd["cdmedio_pago"].ToString() : null;
                            output.odometro = drd.HasColumn("odometro") ? drd["odometro"] == DBNull.Value ? null : drd["odometro"].ToString() : null;
                            output.marcavehic = drd.HasColumn("marcavehic") ? drd["marcavehic"] == DBNull.Value ? null : drd["marcavehic"].ToString() : null;
                            output.inscripcion = drd.HasColumn("inscripcion") ? drd["inscripcion"] == DBNull.Value ? null : drd["inscripcion"].ToString() : null;
                            output.chofer = drd.HasColumn("chofer") ? drd["chofer"] == DBNull.Value ? null : drd["chofer"].ToString() : null;
                            output.nrolicencia = drd.HasColumn("nrolicencia") ? drd["nrolicencia"] == DBNull.Value ? null : drd["nrolicencia"].ToString() : null;
                            output.tipoventa = drd.HasColumn("tipoventa") ? drd["tipoventa"] == DBNull.Value ? null : drd["tipoventa"].ToString() : null;
                            output.tipofactura = drd.HasColumn("tipofactura") ? drd["tipofactura"] == DBNull.Value ? null : drd["tipofactura"].ToString() : null;
                            output.nroocompra = drd.HasColumn("nroocompra") ? drd["nroocompra"] == DBNull.Value ? null : drd["nroocompra"].ToString() : null;
                            output.nroserie1 = drd.HasColumn("nroserie1") ? drd["nroserie1"] == DBNull.Value ? null : drd["nroserie1"].ToString() : null;
                            output.nroserie2 = drd.HasColumn("nroserie2") ? drd["nroserie2"] == DBNull.Value ? null : drd["nroserie2"].ToString() : null;
                            output.nrobonus = drd.HasColumn("nrobonus") ? drd["nrobonus"] == DBNull.Value ? null : drd["nrobonus"].ToString() : null;
                            output.nrotarjeta = drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? null : drd["nrotarjeta"].ToString() : null;
                            output.cdtranspor = drd.HasColumn("cdtranspor") ? drd["cdtranspor"] == DBNull.Value ? null : drd["cdtranspor"].ToString() : null;
                            output.drpartida = drd.HasColumn("drpartida") ? drd["drpartida"] == DBNull.Value ? null : drd["drpartida"].ToString() : null;
                            output.drdestino = drd.HasColumn("drdestino") ? drd["drdestino"] == DBNull.Value ? null : drd["drdestino"].ToString() : null;
                            output.cdusuario = drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString() : null;
                            output.cdvendedor = drd.HasColumn("cdvendedor") ? drd["cdvendedor"] == DBNull.Value ? null : drd["cdvendedor"].ToString() : null;
                            output.cdusuanula = drd.HasColumn("cdusuanula") ? drd["cdusuanula"] == DBNull.Value ? null : drd["cdusuanula"].ToString() : null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;
                            output.rscliente = drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? null : drd["rscliente"].ToString() : null;
                            output.nroproforma = drd.HasColumn("nroproforma") ? drd["nroproforma"] == DBNull.Value ? null : drd["nroproforma"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.cdmoneda = drd.HasColumn("cdmoneda") ? drd["cdmoneda"] == DBNull.Value ? null : drd["cdmoneda"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEConceptoVariables> SP_ITBCP_LISTAR_VARIABLES_1(TS_BEConceptoVariables input)
        {
            List<TS_BEConceptoVariables> lista = new List<TS_BEConceptoVariables>();
            TS_BEConceptoVariables output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VARIABLES_1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PrefijoCard", SqlDbType.Int, 4).Value = input.prefijocard;
                    cmd.Parameters.Add("@TipoAcumula", SqlDbType.Char, 2).Value = input.tipoacumula;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEConceptoVariables();
                            output.valorid = drd.HasColumn("valorid") ? drd["valorid"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["valorid"]) : (int?)null;
                            output.prefijocard = drd.HasColumn("prefijocard") ? drd["prefijocard"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["prefijocard"]) : (int?)null;
                            output.concepto = drd.HasColumn("concepto") ? drd["concepto"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["concepto"]) : (int?)null;
                            output.tipopunto = drd.HasColumn("tipopunto") ? drd["tipopunto"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["tipopunto"]) : (int?)null;
                            output.valorpunto = drd.HasColumn("valorpunto") ? drd["valorpunto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["valorpunto"]) : (double?)null;
                            output.status = drd.HasColumn("status") ? drd["status"] == DBNull.Value ? false : Convert.ToBoolean(drd["status"]) : false;
                            output.descripcion = drd.HasColumn("descripcion") ? drd["descripcion"] == DBNull.Value ? null : drd["descripcion"].ToString() : null;
                            output.tipoacumula = drd.HasColumn("tipoacumula") ? drd["tipoacumula"] == DBNull.Value ? null : drd["tipoacumula"].ToString() : null;
                            output.tipocanje = drd.HasColumn("tipocanje") ? drd["tipocanje"] == DBNull.Value ? null : drd["tipocanje"].ToString() : null;
                            output.conceptos_prefijo = drd.HasColumn("conceptos_prefijo") ? drd["conceptos_prefijo"] == DBNull.Value ? null : drd["conceptos_prefijo"].ToString() : null;

                            output.varid = drd.HasColumn("varid") ? drd["varid"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["varid"]) : (int?)null;
                            output.valorpto = drd.HasColumn("valorpto") ? drd["valorpto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["valorpto"]) : (double?)null;
                            output.flgelimina = drd.HasColumn("flgelimina") ? drd["flgelimina"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgelimina"]) : false;
                            output.tipovar = drd.HasColumn("tipovar") ? drd["tipovar"] == DBNull.Value ? null : drd["tipovar"].ToString() : null;
                            output.clave = drd.HasColumn("clave") ? drd["clave"] == DBNull.Value ? null : drd["clave"].ToString() : null;
                            output.descripcion = drd.HasColumn("TipoAA") ? drd["TipoAA"] == DBNull.Value ? null : drd["TipoAA"].ToString() : null;
                            output.config = drd.HasColumn("config") ? drd["config"] == DBNull.Value ? null : drd["config"].ToString() : null;
                            output.valor = drd.HasColumn("valor") ? drd["valor"] == DBNull.Value ? null : drd["valor"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVariables> SP_ITBCP_LISTAR_VARIABLES(TS_BEVariables input)
        {
            List<TS_BEVariables> lista = new List<TS_BEVariables>();
            TS_BEVariables output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VARIABLES", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Clave", SqlDbType.VarChar, 30).Value = input.clave;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVariables();
                            output.varid = drd.HasColumn("varid") ? drd["varid"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["varid"]) : (int?)null;
                            output.valorpto = drd.HasColumn("valorpto") ? drd["valorpto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["valorpto"]) : (double?)null;
                            output.flgelimina = drd.HasColumn("flgelimina") ? drd["flgelimina"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgelimina"]) : false;
                            output.tipovar = drd.HasColumn("tipovar") ? drd["tipovar"] == DBNull.Value ? null : drd["tipovar"].ToString() : null;
                            output.clave = drd.HasColumn("clave") ? drd["clave"] == DBNull.Value ? null : drd["clave"].ToString() : null;
                            output.descripcion = drd.HasColumn("descripcion") ? drd["descripcion"] == DBNull.Value ? null : drd["descripcion"].ToString() : null;
                            output.config = drd.HasColumn("config") ? drd["config"] == DBNull.Value ? null : drd["config"].ToString() : null;
                            output.valor = drd.HasColumn("valor") ? drd["valor"] == DBNull.Value ? null : drd["valor"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEHvale> SP_ITBCP_LISTAR_VALE(TS_BEHvale input)
        {
            List<TS_BEHvale> lista = new List<TS_BEHvale>();
            TS_BEHvale output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_VALE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nrovale", SqlDbType.Char, 10).Value = input.nrovale;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEHvale();
                            output.fecvale = drd.HasColumn("fecvale") ? drd["fecvale"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecvale"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.fecdocumentofac = drd.HasColumn("fecdocumentofac") ? drd["fecdocumentofac"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumentofac"]) : (DateTime?)null;
                            output.fecprocesofac = drd.HasColumn("fecprocesofac") ? drd["fecprocesofac"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecprocesofac"]) : (DateTime?)null;
                            output.archturno = drd.HasColumn("archturno") ? drd["archturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["archturno"]) : false;
                            output.mtovale = drd.HasColumn("mtovale") ? drd["mtovale"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovale"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.nrovale = drd.HasColumn("nrovale") ? drd["nrovale"] == DBNull.Value ? null : drd["nrovale"].ToString() : null;
                            output.cdmoneda = drd.HasColumn("cdmoneda") ? drd["cdmoneda"] == DBNull.Value ? null : drd["cdmoneda"].ToString() : null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.nroplaca = drd.HasColumn("nroplaca") ? drd["nroplaca"] == DBNull.Value ? null : drd["nroplaca"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.nroseriemaqfac = drd.HasColumn("nroseriemaqfac") ? drd["nroseriemaqfac"] == DBNull.Value ? null : drd["nroseriemaqfac"].ToString() : null;
                            output.cdtipodocfac = drd.HasColumn("cdtipodocfac") ? drd["cdtipodocfac"] == DBNull.Value ? null : drd["cdtipodocfac"].ToString() : null;
                            output.nrodocumentofac = drd.HasColumn("nrodocumentofac") ? drd["nrodocumentofac"] == DBNull.Value ? null : drd["nrodocumentofac"].ToString() : null;
                            output.placa = drd.HasColumn("placa") ? drd["placa"] == DBNull.Value ? null : drd["placa"].ToString() : null;
                            output.docvale = drd.HasColumn("docvale") ? drd["docvale"] == DBNull.Value ? null : drd["docvale"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

      

        public List<TS_BEOp_Tran> SP_ITBCP_LISTAR_TRANSACCION_ARTICULO(TS_BEOp_Tran input)
        {
            List<TS_BEOp_Tran> lista = new List<TS_BEOp_Tran>();
            TS_BEOp_Tran output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_TRANSACCION_ARTICULO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cara", SqlDbType.Char, 2).Value = input.cara;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEOp_Tran();
                            output.manguera = drd.HasColumn("manguera") ? drd["manguera"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["manguera"]) : (int?)null;
                            output.fecha = drd.HasColumn("fecha") ? drd["fecha"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecha"]) : (DateTime?)null;
                            //output.hora = drd.HasColumn("hora") ? drd["hora"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["hora"]) : (DateTime?)null;
                            output.dateproce = drd.HasColumn("dateproce") ? drd["dateproce"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["dateproce"]) : (DateTime?)null;
                            output.fecsistema = drd.HasColumn("fecsistema") ? drd["fecsistema"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecsistema"]) : (DateTime?)null;
                            output.soles = drd.HasColumn("soles") ? drd["soles"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["soles"]) : (decimal?)null;
                            output.precio = drd.HasColumn("precio") ? drd["precio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio"]) : (decimal?)null;
                            output.galones = drd.HasColumn("galones") ? drd["galones"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["galones"]) : (decimal?)null;
                            output.documento = drd.HasColumn("documento") ? drd["documento"] == DBNull.Value ? null : (drd["documento"]).ToString() : null;
                            output.c_interno = drd.HasColumn("c_interno") ? drd["c_interno"] == DBNull.Value ? (long?)null : (long)(drd["c_interno"]) : (long?)null;
                            output.controlador = drd.HasColumn("controlador") ? drd["controlador"] == DBNull.Value ? null : drd["controlador"].ToString() : null;
                            output.numero = drd.HasColumn("numero") ? drd["numero"] == DBNull.Value ? null : drd["numero"].ToString() : null;
                            output.producto = drd.HasColumn("producto") ? drd["producto"] == DBNull.Value ? null : drd["producto"].ToString() : null;
                            output.cara = drd.HasColumn("cara") ? drd["cara"] == DBNull.Value ? null : drd["cara"].ToString() : null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? null : drd["turno"].ToString() : null;
                            output.estado = drd.HasColumn("estado") ? drd["estado"] == DBNull.Value ? null : drd["estado"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

       

       

        public List<TS_BETerminal> SP_ITBCP_LISTAR_TERMINALES(TS_BETerminal input)
        {
            List<TS_BETerminal> lista = new List<TS_BETerminal>();
            TS_BETerminal output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_TERMINALES", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BETerminal();
                            output.conexion_dispensador = drd.HasColumn("conexion_dispensador") ? drd["conexion_dispensador"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["conexion_dispensador"]) : (byte?)null;
                            output.fe_idpos = drd.HasColumn("fe_idpos") ? drd["fe_idpos"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["fe_idpos"]) : (int?)null;
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.tktfactura = drd.HasColumn("tktfactura") ? drd["tktfactura"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktfactura"]) : false;
                            output.tktboleta = drd.HasColumn("tktboleta") ? drd["tktboleta"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktboleta"]) : false;
                            output.tktpromocion = drd.HasColumn("tktpromocion") ? drd["tktpromocion"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktpromocion"]) : false;
                            output.facturapreimpre = drd.HasColumn("facturapreimpre") ? drd["facturapreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["facturapreimpre"]) : false;
                            output.boletapreimpre = drd.HasColumn("boletapreimpre") ? drd["boletapreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["boletapreimpre"]) : false;
                            output.promocionpreimpre = drd.HasColumn("promocionpreimpre") ? drd["promocionpreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["promocionpreimpre"]) : false;
                            output.activa_boton_playa = drd.HasColumn("activa_boton_playa") ? drd["activa_boton_playa"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_boton_playa"]) : false;
                            output.flg_pdf417 = drd.HasColumn("flg_pdf417") ? drd["flg_pdf417"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pdf417"]) : false;
                            output.flg_nc_correlativo = drd.HasColumn("flg_nc_correlativo") ? drd["flg_nc_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nc_correlativo"]) : false;
                            output.flg_nd_correlativo = drd.HasColumn("flg_nd_correlativo") ? drd["flg_nd_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nd_correlativo"]) : false;
                            output.flg_print_qr = drd.HasColumn("flg_print_qr") ? drd["flg_print_qr"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_print_qr"]) : false;
                            output.flg_formato_a4 = drd.HasColumn("flg_formato_a4") ? drd["flg_formato_a4"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_formato_a4"]) : false;
                            output.rucinvalido = drd.HasColumn("rucinvalido") ? drd["rucinvalido"] == DBNull.Value ? false : Convert.ToBoolean(drd["rucinvalido"]) : false;
                            output._virtual = drd.HasColumn("virtual") ? drd["virtual"] == DBNull.Value ? false : Convert.ToBoolean(drd["virtual"]) : false;
                            output.tktnotadespacho = drd.HasColumn("tktnotadespacho") ? drd["tktnotadespacho"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktnotadespacho"]) : false;
                            output.flgtransferencia = drd.HasColumn("flgtransferencia") ? drd["flgtransferencia"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgtransferencia"]) : false;
                            output.playa_formasdepago = drd.HasColumn("playa_formasdepago") ? drd["playa_formasdepago"] == DBNull.Value ? false : Convert.ToBoolean(drd["playa_formasdepago"]) : false;
                            output.modif_corr = drd.HasColumn("modif_corr") ? drd["modif_corr"] == DBNull.Value ? false : Convert.ToBoolean(drd["modif_corr"]) : false;
                            output.flgpagotarjeta = drd.HasColumn("flgpagotarjeta") ? drd["flgpagotarjeta"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagotarjeta"]) : false;
                            output.flgpagocheque = drd.HasColumn("flgpagocheque") ? drd["flgpagocheque"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagocheque"]) : false;
                            output.flgpagocredito = drd.HasColumn("flgpagocredito") ? drd["flgpagocredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagocredito"]) : false;
                            output.flgpagoncredito = drd.HasColumn("flgpagoncredito") ? drd["flgpagoncredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagoncredito"]) : false;
                            output.flgvalidaz = drd.HasColumn("flgvalidaz") ? drd["flgvalidaz"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgvalidaz"]) : false;
                            output.flgcierrezok = drd.HasColumn("flgcierrezok") ? drd["flgcierrezok"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrezok"]) : false;
                            output.flghotkey = drd.HasColumn("flghotkey") ? drd["flghotkey"] == DBNull.Value ? false : Convert.ToBoolean(drd["flghotkey"]) : false;
                            output.flgfacturacion = drd.HasColumn("flgfacturacion") ? drd["flgfacturacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgfacturacion"]) : false;
                            output.grabarcliente = drd.HasColumn("grabarcliente") ? drd["grabarcliente"] == DBNull.Value ? false : Convert.ToBoolean(drd["grabarcliente"]) : false;
                            output.flgautomatica = drd.HasColumn("flgautomatica") ? drd["flgautomatica"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgautomatica"]) : false;
                            output.flgaperturacaja = drd.HasColumn("flgaperturacaja") ? drd["flgaperturacaja"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgaperturacaja"]) : false;
                            output.flgpagoefectivo = drd.HasColumn("flgpagoefectivo") ? drd["flgpagoefectivo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagoefectivo"]) : false;
                            output.modocompra = drd.HasColumn("modocompra") ? drd["modocompra"] == DBNull.Value ? false : Convert.ToBoolean(drd["modocompra"]) : false;
                            output.modservicio = drd.HasColumn("modservicio") ? drd["modservicio"] == DBNull.Value ? false : Convert.ToBoolean(drd["modservicio"]) : false;
                            output.modobservacion = drd.HasColumn("modobservacion") ? drd["modobservacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["modobservacion"]) : false;
                            output.moddsctogral = drd.HasColumn("moddsctogral") ? drd["moddsctogral"] == DBNull.Value ? false : Convert.ToBoolean(drd["moddsctogral"]) : false;
                            output.moddsctoitem = drd.HasColumn("moddsctoitem") ? drd["moddsctoitem"] == DBNull.Value ? false : Convert.ToBoolean(drd["moddsctoitem"]) : false;
                            output.preciocero = drd.HasColumn("preciocero") ? drd["preciocero"] == DBNull.Value ? false : Convert.ToBoolean(drd["preciocero"]) : false;
                            output.modfecha = drd.HasColumn("modfecha") ? drd["modfecha"] == DBNull.Value ? false : Convert.ToBoolean(drd["modfecha"]) : false;
                            output.modmoneda = drd.HasColumn("modmoneda") ? drd["modmoneda"] == DBNull.Value ? false : Convert.ToBoolean(drd["modmoneda"]) : false;
                            output.modvendedor = drd.HasColumn("modvendedor") ? drd["modvendedor"] == DBNull.Value ? false : Convert.ToBoolean(drd["modvendedor"]) : false;
                            output.modalmacen = drd.HasColumn("modalmacen") ? drd["modalmacen"] == DBNull.Value ? false : Convert.ToBoolean(drd["modalmacen"]) : false;
                            output.modlistap = drd.HasColumn("modlistap") ? drd["modlistap"] == DBNull.Value ? false : Convert.ToBoolean(drd["modlistap"]) : false;
                            output.modprecio = drd.HasColumn("modprecio") ? drd["modprecio"] == DBNull.Value ? false : Convert.ToBoolean(drd["modprecio"]) : false;
                            output.nrozeta = drd.HasColumn("nrozeta") ? drd["nrozeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrozeta"]) : (decimal?)null;
                            output.mtozeta = drd.HasColumn("mtozeta") ? drd["mtozeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtozeta"]) : (decimal?)null;
                            output.ticketfeed = drd.HasColumn("ticketfeed") ? drd["ticketfeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticketfeed"]) : (decimal?)null;
                            output.ticketlineacorte = drd.HasColumn("ticketlineacorte") ? drd["ticketlineacorte"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticketlineacorte"]) : (decimal?)null;
                            output.ticket2columnas = drd.HasColumn("ticket2columnas") ? drd["ticket2columnas"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticket2columnas"]) : (decimal?)null;
                            output.nventafeed = drd.HasColumn("nventafeed") ? drd["nventafeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nventafeed"]) : (decimal?)null;
                            output.promocionfeed = drd.HasColumn("promocionfeed") ? drd["promocionfeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["promocionfeed"]) : (decimal?)null;
                            output.mtodsctomax = drd.HasColumn("mtodsctomax") ? drd["mtodsctomax"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodsctomax"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.tranvirtual = drd.HasColumn("tranvirtual") ? drd["tranvirtual"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["tranvirtual"]) : (decimal?)null;
                            output.nrodeposito = drd.HasColumn("nrodeposito") ? drd["nrodeposito"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrodeposito"]) : (decimal?)null;
                            output.facturaimpre = drd.HasColumn("facturaimpre") ? drd["facturaimpre"] == DBNull.Value ? null : drd["facturaimpre"].ToString() : null;
                            output.boletaimpre = drd.HasColumn("boletaimpre") ? drd["boletaimpre"] == DBNull.Value ? null : drd["boletaimpre"].ToString() : null;
                            output.gavetachr = drd.HasColumn("gavetachr") ? drd["gavetachr"] == DBNull.Value ? null : drd["gavetachr"].ToString() : null;
                            output.promocionimpre = drd.HasColumn("promocionimpre") ? drd["promocionimpre"] == DBNull.Value ? null : drd["promocionimpre"].ToString() : null;
                            output.ncreditoimpre = drd.HasColumn("ncreditoimpre") ? drd["ncreditoimpre"] == DBNull.Value ? null : drd["ncreditoimpre"].ToString() : null;
                            output.ndebitoimpre = drd.HasColumn("ndebitoimpre") ? drd["ndebitoimpre"] == DBNull.Value ? null : drd["ndebitoimpre"].ToString() : null;
                            output.guiaimpre = drd.HasColumn("guiaimpre") ? drd["guiaimpre"] == DBNull.Value ? null : drd["guiaimpre"].ToString() : null;
                            output.proformaimpre = drd.HasColumn("proformaimpre") ? drd["proformaimpre"] == DBNull.Value ? null : drd["proformaimpre"].ToString() : null;
                            output.letraimpre = drd.HasColumn("letraimpre") ? drd["letraimpre"] == DBNull.Value ? null : drd["letraimpre"].ToString() : null;
                            output.path_loteria = drd.HasColumn("path_loteria") ? drd["path_loteria"] == DBNull.Value ? null : drd["path_loteria"].ToString() : null;
                            output.fe_nompos = drd.HasColumn("fe_nompos") ? drd["fe_nompos"] == DBNull.Value ? null : drd["fe_nompos"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdusuario = drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString() : null;
                            output.seriehd = drd.HasColumn("seriehd") ? drd["seriehd"] == DBNull.Value ? null : drd["seriehd"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.nroserie1 = drd.HasColumn("nroserie1") ? drd["nroserie1"] == DBNull.Value ? null : drd["nroserie1"].ToString() : null;
                            output.nroserie2 = drd.HasColumn("nroserie2") ? drd["nroserie2"] == DBNull.Value ? null : drd["nroserie2"].ToString() : null;
                            output.tipoterminal = drd.HasColumn("tipoterminal") ? drd["tipoterminal"] == DBNull.Value ? null : drd["tipoterminal"].ToString() : null;
                            output.ticketfactura = drd.HasColumn("ticketfactura") ? drd["ticketfactura"] == DBNull.Value ? null : drd["ticketfactura"].ToString() : null;
                            output.ncreditoboleta = drd.HasColumn("ncreditoboleta") ? drd["ncreditoboleta"] == DBNull.Value ? null : drd["ncreditoboleta"].ToString() : null;
                            output.ndebitoboleta = drd.HasColumn("ndebitoboleta") ? drd["ndebitoboleta"] == DBNull.Value ? null : drd["ndebitoboleta"].ToString() : null;
                            output.guiafmt = drd.HasColumn("guiafmt") ? drd["guiafmt"] == DBNull.Value ? null : drd["guiafmt"].ToString() : null;
                            output.proforma = drd.HasColumn("proforma") ? drd["proforma"] == DBNull.Value ? null : drd["proforma"].ToString() : null;
                            output.proformafmt = drd.HasColumn("proformafmt") ? drd["proformafmt"] == DBNull.Value ? null : drd["proformafmt"].ToString() : null;
                            output.letra = drd.HasColumn("letra") ? drd["letra"] == DBNull.Value ? null : drd["letra"].ToString() : null;
                            output.letrafmt = drd.HasColumn("letrafmt") ? drd["letrafmt"] == DBNull.Value ? null : drd["letrafmt"].ToString() : null;
                            output.displayimpre = drd.HasColumn("displayimpre") ? drd["displayimpre"] == DBNull.Value ? null : drd["displayimpre"].ToString() : null;
                            output.promocionchrfin = drd.HasColumn("promocionchrfin") ? drd["promocionchrfin"] == DBNull.Value ? null : drd["promocionchrfin"].ToString() : null;
                            output.ncredito = drd.HasColumn("ncredito") ? drd["ncredito"] == DBNull.Value ? null : drd["ncredito"].ToString() : null;
                            output.ncreditofmt = drd.HasColumn("ncreditofmt") ? drd["ncreditofmt"] == DBNull.Value ? null : drd["ncreditofmt"].ToString() : null;
                            output.ndebito = drd.HasColumn("ndebito") ? drd["ndebito"] == DBNull.Value ? null : drd["ndebito"].ToString() : null;
                            output.ndebitofmt = drd.HasColumn("ndebitofmt") ? drd["ndebitofmt"] == DBNull.Value ? null : drd["ndebitofmt"].ToString() : null;
                            output.guia = drd.HasColumn("guia") ? drd["guia"] == DBNull.Value ? null : drd["guia"].ToString() : null;
                            output.nventaimpre = drd.HasColumn("nventaimpre") ? drd["nventaimpre"] == DBNull.Value ? null : drd["nventaimpre"].ToString() : null;
                            output.nventachrini = drd.HasColumn("nventachrini") ? drd["nventachrini"] == DBNull.Value ? null : drd["nventachrini"].ToString() : null;
                            output.nventachrfin = drd.HasColumn("nventachrfin") ? drd["nventachrfin"] == DBNull.Value ? null : drd["nventachrfin"].ToString() : null;
                            output.promocion = drd.HasColumn("promocion") ? drd["promocion"] == DBNull.Value ? null : drd["promocion"].ToString() : null;
                            output.promocionfmt = drd.HasColumn("promocionfmt") ? drd["promocionfmt"] == DBNull.Value ? null : drd["promocionfmt"].ToString() : null;
                            output.promocionchrini = drd.HasColumn("promocionchrini") ? drd["promocionchrini"] == DBNull.Value ? null : drd["promocionchrini"].ToString() : null;
                            output.gavetaimpre = drd.HasColumn("gavetaimpre") ? drd["gavetaimpre"] == DBNull.Value ? null : drd["gavetaimpre"].ToString() : null;
                            output.ticket = drd.HasColumn("ticket") ? drd["ticket"] == DBNull.Value ? null : drd["ticket"].ToString() : null;
                            output.ticketimpre = drd.HasColumn("ticketimpre") ? drd["ticketimpre"] == DBNull.Value ? null : drd["ticketimpre"].ToString() : null;
                            output.ticketchrini = drd.HasColumn("ticketchrini") ? drd["ticketchrini"] == DBNull.Value ? null : drd["ticketchrini"].ToString() : null;
                            output.ticketchrfin = drd.HasColumn("ticketchrfin") ? drd["ticketchrfin"] == DBNull.Value ? null : drd["ticketchrfin"].ToString() : null;
                            output.nventa = drd.HasColumn("nventa") ? drd["nventa"] == DBNull.Value ? null : drd["nventa"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.factura = drd.HasColumn("factura") ? drd["factura"] == DBNull.Value ? null : drd["factura"].ToString() : null;
                            output.facturafmt = drd.HasColumn("facturafmt") ? drd["facturafmt"] == DBNull.Value ? null : drd["facturafmt"].ToString() : null;
                            output.boleta = drd.HasColumn("boleta") ? drd["boleta"] == DBNull.Value ? null : drd["boleta"].ToString() : null;
                            output.boletafmt = drd.HasColumn("boletafmt") ? drd["boletafmt"] == DBNull.Value ? null : drd["boletafmt"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        // Change ts_bevariables x tarjetaConcepto
        public List<TS_BETarjeta_Concepto> SP_ITBCP_LISTAR_TARJETA_CONCEPTO_1(TS_BETarjeta_Concepto input)
        {
            List<TS_BETarjeta_Concepto> lista = new List<TS_BETarjeta_Concepto>();
            TS_BETarjeta_Concepto output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_TARJETA_CONCEPTO_1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TarjAfiliacion", SqlDbType.VarChar, 25).Value = input.tarjafiliacion;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BETarjeta_Concepto();
                            output.valorid = drd.HasColumn("valorid") ? drd["valorid"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["valorid"]) : (int?)null;
                            output.tarjafiliacion = drd.HasColumn("tarjafiliacion") ? drd["tarjafiliacion"] == DBNull.Value ? null : drd["tarjafiliacion"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        //Generar Clase Personalizada
        /*public List<TS_BE(> SP_ITBCP_LISTAR_TARJETA_CONCEPTO(TS_BE( input)
		{
			List<TS_BE(> lista = new List<TS_BE(>();
			TS_BE( output;
			using (SqlConnection con = new SqlConnection(stringBackOffice))
			{
				try
				{
					con.Open();
					SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_TARJETA_CONCEPTO", con);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@tarjafiliacion", SqlDbType.VarChar, 25).Value = input.tarjafiliacion; 

					using (SqlDataReader drd = cmd.ExecuteReader())
					{
						while (drd.Read())
						{
							output = new TS_BE((); 

							lista.Add(output);
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
					if (con!=null){ con.Dispose(); }
				}
			}
			return lista;
		} */

        public List<TS_BETallad> SP_ITBCP_LISTAR_TALLAS(TS_BETallad input)
        {
            List<TS_BETallad> lista = new List<TS_BETallad>();
            TS_BETallad output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_TALLAS", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BETallad();
                            output.orden = drd.HasColumn("orden") ? drd["orden"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["orden"]) : (decimal?)null;
                            output.cdtalla = drd.HasColumn("cdtalla") ? drd["cdtalla"] == DBNull.Value ? null : drd["cdtalla"].ToString() : null;
                            output.talla = drd.HasColumn("talla") ? drd["talla"] == DBNull.Value ? null : drd["talla"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEStock> SP_ITBCP_LISTAR_STOCK(TS_BEStock input)
        {
            List<TS_BEStock> lista = new List<TS_BEStock>();
            TS_BEStock output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_STOCK", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = input.cdlocal;
                    cmd.Parameters.Add("@cdalmacen", SqlDbType.Char, 3).Value = input.cdalmacen;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEStock();
                            output.fecinicial = drd.HasColumn("fecinicial") ? drd["fecinicial"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinicial"]) : (DateTime?)null;
                            output.fecinventario = drd.HasColumn("fecinventario") ? drd["fecinventario"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinventario"]) : (DateTime?)null;
                            output.fecingreso = drd.HasColumn("fecingreso") ? drd["fecingreso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecingreso"]) : (DateTime?)null;
                            output.fecsalida = drd.HasColumn("fecsalida") ? drd["fecsalida"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecsalida"]) : (DateTime?)null;
                            output.fecventa = drd.HasColumn("fecventa") ? drd["fecventa"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecventa"]) : (DateTime?)null;
                            output.is_recalculo = drd.HasColumn("is_recalculo") ? drd["is_recalculo"] == DBNull.Value ? false : Convert.ToBoolean(drd["is_recalculo"]) : false;
                            output.stockinicial = drd.HasColumn("stockinicial") ? drd["stockinicial"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["stockinicial"]) : (decimal?)null;
                            output.ctoinicial = drd.HasColumn("ctoinicial") ? drd["ctoinicial"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoinicial"]) : (decimal?)null;
                            output.stockinventario = drd.HasColumn("stockinventario") ? drd["stockinventario"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["stockinventario"]) : (decimal?)null;
                            output.ctoinventario = drd.HasColumn("ctoinventario") ? drd["ctoinventario"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoinventario"]) : (decimal?)null;
                            output.stockminimo = drd.HasColumn("stockminimo") ? drd["stockminimo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["stockminimo"]) : (decimal?)null;
                            output.stockactual = drd.HasColumn("stockactual") ? drd["stockactual"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["stockactual"]) : (decimal?)null;
                            output.stockseparado = drd.HasColumn("stockseparado") ? drd["stockseparado"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["stockseparado"]) : (decimal?)null;
                            output.stockmaximo = drd.HasColumn("stockmaximo") ? drd["stockmaximo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["stockmaximo"]) : (decimal?)null;
                            output.ctoreposicion = drd.HasColumn("ctoreposicion") ? drd["ctoreposicion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoreposicion"]) : (decimal?)null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.talla = drd.HasColumn("talla") ? drd["talla"] == DBNull.Value ? null : drd["talla"].ToString() : null;
                            output.monctoinicial = drd.HasColumn("monctoinicial") ? drd["monctoinicial"] == DBNull.Value ? null : drd["monctoinicial"].ToString() : null;
                            output.monctoinventario = drd.HasColumn("monctoinventario") ? drd["monctoinventario"] == DBNull.Value ? null : drd["monctoinventario"].ToString() : null;
                            output.monctorepo = drd.HasColumn("monctorepo") ? drd["monctorepo"] == DBNull.Value ? null : drd["monctorepo"].ToString() : null;
                            output.usuingreso = drd.HasColumn("usuingreso") ? drd["usuingreso"] == DBNull.Value ? null : drd["usuingreso"].ToString() : null;
                            output.ususalida = drd.HasColumn("ususalida") ? drd["ususalida"] == DBNull.Value ? null : drd["ususalida"].ToString() : null;
                            output.usuventa = drd.HasColumn("usuventa") ? drd["usuventa"] == DBNull.Value ? null : drd["usuventa"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BESaldoclic> SP_ITBCP_LISTAR_SALDOCLID_1(TS_BESaldoclic input)
        {
            List<TS_BESaldoclic> lista = new List<TS_BESaldoclic>();
            TS_BESaldoclic output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_SALDOCLID_1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 15).Value = input.cdcliente;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BESaldoclic();
                            output.fechainicio = drd.HasColumn("fechainicio") ? drd["fechainicio"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fechainicio"]) : (DateTime?)null;
                            output.flgilimit = drd.HasColumn("flgilimit") ? drd["flgilimit"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgilimit"]) : false;
                            output.flgbloquea = drd.HasColumn("flgbloquea") ? drd["flgbloquea"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgbloquea"]) : false;
                            output.limitemto = drd.HasColumn("limitemto") ? drd["limitemto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["limitemto"]) : (decimal?)null;
                            output.consumto = drd.HasColumn("consumto") ? drd["consumto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["consumto"]) : (decimal?)null;
                            output.nrocontrato = drd.HasColumn("nrocontrato") ? drd["nrocontrato"] == DBNull.Value ? null : drd["nrocontrato"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.tpsaldo = drd.HasColumn("tpsaldo") ? drd["tpsaldo"] == DBNull.Value ? null : drd["tpsaldo"].ToString() : null;
                            output.tipodespacho = drd.HasColumn("tipodespacho") ? drd["tipodespacho"] == DBNull.Value ? null : drd["tipodespacho"].ToString() : null;
                            output.tipocredito = drd.HasColumn("tipocredito") ? drd["tipocredito"] == DBNull.Value ? null : drd["tipocredito"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

       

    

        public List<TS_BEAfiliaciontarj> SP_ITBCP_LISTAR_PTOS_DISPONIBLES_POR_TARJETA_AFILIACION(TS_BEAfiliaciontarj input)
        {
            List<TS_BEAfiliaciontarj> lista = new List<TS_BEAfiliaciontarj>();
            TS_BEAfiliaciontarj output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_PTOS_DISPONIBLES_POR_TARJETA_AFILIACION", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@tarjafiliacion", SqlDbType.Char, 20).Value = input.tarjafiliacion;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEAfiliaciontarj();
                            output.estado = drd.HasColumn("estado") ? drd["estado"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["estado"]) : (int?)null;
                            output.fechaultconsumo = drd.HasColumn("fechaultconsumo") ? drd["fechaultconsumo"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fechaultconsumo"]) : (DateTime?)null;
                            output.bloqueado = drd.HasColumn("bloqueado") ? drd["bloqueado"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqueado"]) : false;
                            output.csql_actualiza = drd.HasColumn("csql_actualiza") ? drd["csql_actualiza"] == DBNull.Value ? false : Convert.ToBoolean(drd["csql_actualiza"]) : false;
                            output.puntos = drd.HasColumn("puntos") ? drd["puntos"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["puntos"]) : (decimal?)null;
                            output.canjeado = drd.HasColumn("canjeado") ? drd["canjeado"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["canjeado"]) : (decimal?)null;
                            output.disponible = drd.HasColumn("disponible") ? drd["disponible"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["disponible"]) : (decimal?)null;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valoracumula"]) : (decimal?)null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.tarjafiliacion = drd.HasColumn("tarjafiliacion") ? drd["tarjafiliacion"] == DBNull.Value ? null : drd["tarjafiliacion"].ToString() : null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;
                            output.rscliente = drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? null : drd["rscliente"].ToString() : null;
                            output.drcliente = drd.HasColumn("drcliente") ? drd["drcliente"] == DBNull.Value ? null : drd["drcliente"].ToString() : null;
                            output.tlfcliente = drd.HasColumn("tlfcliente") ? drd["tlfcliente"] == DBNull.Value ? null : drd["tlfcliente"].ToString() : null;
                            output.tlfcliente1 = drd.HasColumn("tlfcliente1") ? drd["tlfcliente1"] == DBNull.Value ? null : drd["tlfcliente1"].ToString() : null;
                            output.emcliente = drd.HasColumn("emcliente") ? drd["emcliente"] == DBNull.Value ? null : drd["emcliente"].ToString() : null;
                            output.provtelefonia = drd.HasColumn("provtelefonia") ? drd["provtelefonia"] == DBNull.Value ? null : drd["provtelefonia"].ToString() : null;
                            output.provtelefonia1 = drd.HasColumn("provtelefonia1") ? drd["provtelefonia1"] == DBNull.Value ? null : drd["provtelefonia1"].ToString() : null;
                            output.tarjafiliacion_traspaso = drd.HasColumn("tarjafiliacion_traspaso") ? drd["tarjafiliacion_traspaso"] == DBNull.Value ? null : drd["tarjafiliacion_traspaso"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEPrecio_Varios> SP_ITBCP_LISTAR_PRECIOS_VARIOS_1(TS_BEPrecio_Varios input)
        {
            List<TS_BEPrecio_Varios> lista = new List<TS_BEPrecio_Varios>();
            TS_BEPrecio_Varios output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_PRECIOS_VARIOS_1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.VarChar, 15).Value = input.cdcliente;
                    cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = input.cdarticulo;
                    cmd.Parameters.Add("@tipocli", SqlDbType.Char, 3).Value = input.tipocli;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEPrecio_Varios();
                            output.fechamodificacion = drd.HasColumn("fechamodificacion") ? drd["fechamodificacion"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fechamodificacion"]) : (DateTime?)null;
                            output.rango1 = drd.HasColumn("rango1") ? drd["rango1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["rango1"]) : (decimal?)null;
                            output.rango2 = drd.HasColumn("rango2") ? drd["rango2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["rango2"]) : (decimal?)null;
                            output.valor = drd.HasColumn("valor") ? drd["valor"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valor"]) : (decimal?)null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.tipocli = drd.HasColumn("tipocli") ? drd["tipocli"] == DBNull.Value ? null : drd["tipocli"].ToString() : null;
                            output.tiporango = drd.HasColumn("tiporango") ? drd["tiporango"] == DBNull.Value ? null : drd["tiporango"].ToString() : null;
                            output.tipo = drd.HasColumn("tipo") ? drd["tipo"] == DBNull.Value ? null : drd["tipo"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEPrecio_Varios> SP_ITBCP_LISTAR_PRECIOS_VARIOS(TS_BEPrecio_Varios input)
        {
            List<TS_BEPrecio_Varios> lista = new List<TS_BEPrecio_Varios>();
            TS_BEPrecio_Varios output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_PRECIOS_VARIOS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = input.cdarticulo;
                    cmd.Parameters.Add("@tipocli", SqlDbType.Char, 3).Value = input.tipocli;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEPrecio_Varios();
                            output.fechamodificacion = drd.HasColumn("fechamodificacion") ? drd["fechamodificacion"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fechamodificacion"]) : (DateTime?)null;
                            output.rango1 = drd.HasColumn("rango1") ? drd["rango1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["rango1"]) : (decimal?)null;
                            output.rango2 = drd.HasColumn("rango2") ? drd["rango2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["rango2"]) : (decimal?)null;
                            output.valor = drd.HasColumn("valor") ? drd["valor"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valor"]) : (decimal?)null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.tipocli = drd.HasColumn("tipocli") ? drd["tipocli"] == DBNull.Value ? null : drd["tipocli"].ToString() : null;
                            output.tiporango = drd.HasColumn("tiporango") ? drd["tiporango"] == DBNull.Value ? null : drd["tiporango"].ToString() : null;
                            output.tipo = drd.HasColumn("tipo") ? drd["tipo"] == DBNull.Value ? null : drd["tipo"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEListaprecio> SP_ITBCP_LISTAR_PRECIOS(TS_BEListaprecio input)
        {
            List<TS_BEListaprecio> lista = new List<TS_BEListaprecio>();
            TS_BEListaprecio output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_PRECIOS", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEListaprecio();
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.dsprecio = drd.HasColumn("dsprecio") ? drd["dsprecio"] == DBNull.Value ? null : drd["dsprecio"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEPrecio> SP_ITBCP_LISTAR_PRECIO_POR_ARTICULO_PRECIO(TS_BEPrecio input)
        {
            List<TS_BEPrecio> lista = new List<TS_BEPrecio>();
            TS_BEPrecio output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_PRECIO_POR_ARTICULO_PRECIO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CdArticulo", SqlDbType.Char, 20).Value = input.cdarticulo;
                    cmd.Parameters.Add("@cdprecio", SqlDbType.Char, 5).Value = input.cdprecio;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEPrecio();
                            output.fecinioferta = drd.HasColumn("fecinioferta") ? drd["fecinioferta"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinioferta"]) : (DateTime?)null;
                            output.fecfinoferta = drd.HasColumn("fecfinoferta") ? drd["fecfinoferta"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecfinoferta"]) : (DateTime?)null;
                            output.fecedicion = drd.HasColumn("fecedicion") ? drd["fecedicion"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecedicion"]) : (DateTime?)null;
                            output.mtoprecio = drd.HasColumn("mtoprecio") ? drd["mtoprecio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoprecio"]) : (decimal?)null;
                            output.porcomision = drd.HasColumn("porcomision") ? drd["porcomision"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcomision"]) : (decimal?)null;
                            output.mtoprecioferta = drd.HasColumn("mtoprecioferta") ? drd["mtoprecioferta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoprecioferta"]) : (decimal?)null;
                            output.promocionid = drd.HasColumn("promocionid") ? drd["promocionid"] == DBNull.Value ? null : drd["promocionid"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.talla = drd.HasColumn("talla") ? drd["talla"] == DBNull.Value ? null : drd["talla"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.cdmoneda = drd.HasColumn("cdmoneda") ? drd["cdmoneda"] == DBNull.Value ? null : drd["cdmoneda"].ToString() : null;
                            output.cdmonoferta = drd.HasColumn("cdmonoferta") ? drd["cdmonoferta"] == DBNull.Value ? null : drd["cdmonoferta"].ToString() : null;
                            output.horinioferta = drd.HasColumn("horinioferta") ? drd["horinioferta"] == DBNull.Value ? null : drd["horinioferta"].ToString() : null;
                            output.horfinoferta = drd.HasColumn("horfinoferta") ? drd["horfinoferta"] == DBNull.Value ? null : drd["horfinoferta"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEPreciocliente> SP_ITBCP_LISTAR_PRECIO_CLIENTE(TS_BEPreciocliente input)
        {
            List<TS_BEPreciocliente> lista = new List<TS_BEPreciocliente>();
            TS_BEPreciocliente output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_PRECIO_CLIENTE", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEPreciocliente();
                            output.precio = drd.HasColumn("precio") ? drd["precio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio"]) : (decimal?)null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.tipocli = drd.HasColumn("tipocli") ? drd["tipocli"] == DBNull.Value ? null : drd["tipocli"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.tipodes = drd.HasColumn("tipodes") ? drd["tipodes"] == DBNull.Value ? null : drd["tipodes"].ToString() : null;
                            output.nrocontrato = drd.HasColumn("nrocontrato") ? drd["nrocontrato"] == DBNull.Value ? null : drd["nrocontrato"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public TS_BEMensaje SP_ITBCP_APLICAR_DESCUENTO(TS_BECabeceraOutPut input, TS_BEOpTransInput inputcli)
        {
            TS_BEMensaje Mensaje = new TS_BEMensaje("",true);
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    foreach (TS_BEArticulo articulo in input.cDetalleOutPut)
                    {
                        SqlCommand cmd = new SqlCommand("SP_ITBCP_APLICAR_DESCUENTO", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@CDCLIENTE", SqlDbType.VarChar, 50).Value = inputcli.cdcliente ?? "";
                        cmd.Parameters.Add("@CDARTICULO", SqlDbType.VarChar, 50).Value = articulo.cdarticulo;
                        cmd.Parameters.Add("@PRECIO", SqlDbType.Decimal, 50).Value = articulo.precio;
                        cmd.Parameters.Add("@CANTIDAD", SqlDbType.Decimal, 50).Value = articulo.cantidad;
                        cmd.Parameters.Add("@CREDITO", SqlDbType.Bit, 5).Value = inputcli.isCredito;

                        using (SqlDataReader drd = cmd.ExecuteReader())
                        {
                            while (drd.Read())
                            {
                               articulo.precio = drd.HasColumn("PRECIO") ? drd["PRECIO"] == DBNull.Value ? (decimal) 0 : Convert.ToDecimal(drd["PRECIO"]) : (decimal) 0;
                               articulo.precio_orig = drd.HasColumn("PRECIO_ORG") ? drd["PRECIO_ORG"] == DBNull.Value ? (decimal)0 : Convert.ToDecimal(drd["PRECIO_ORG"]) : (decimal)0;
                               articulo.total = drd.HasColumn("TOTAL") ? drd["TOTAL"] == DBNull.Value ? (decimal)0 : Convert.ToDecimal(drd["TOTAL"]) : (decimal)0;
                               if(drd.HasColumn("ERROR") ? drd["ERROR"] == DBNull.Value ? false : Convert.ToBoolean(drd["ERROR"]) : false)
                               {
                                    Mensaje.Ok = false;
                                    Mensaje.mensaje = "Hubo un error al consultar las promociones para dicho cliente";
                               }
                            }
                        }
                        cmd.Dispose();
                    }
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
            return Mensaje;
        }

        public TS_BEMensaje SP_ITBCP_APLICAR_DESCUENTO(TS_BEPromotionInput input)
        {
            TS_BEMensaje Mensaje = new TS_BEMensaje("", true);
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SP_ITBCP_APLICAR_DESCUENTO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDCLIENTE", SqlDbType.VarChar, 50).Value = input.cdcliente ?? "";
                    cmd.Parameters.Add("@CDARTICULO", SqlDbType.VarChar, 50).Value = input.cdarticulo;
                    cmd.Parameters.Add("@PRECIO", SqlDbType.Decimal, 50).Value = input.precio;
                    cmd.Parameters.Add("@CANTIDAD", SqlDbType.Decimal, 50).Value = input.cantidad;
                    cmd.Parameters.Add("@CREDITO", SqlDbType.Bit, 5).Value = input.isCredito;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            input.precio = drd.HasColumn("PRECIO") ? drd["PRECIO"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["PRECIO"]) : 0;
                            input.precio_orig = drd.HasColumn("PRECIO_ORG") ? drd["PRECIO_ORG"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["PRECIO_ORG"]) : 0;
                            input.total = drd.HasColumn("TOTAL") ? drd["TOTAL"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["TOTAL"]) : 0;
                            if (drd.HasColumn("ERROR") ? drd["ERROR"] == DBNull.Value ? false : Convert.ToBoolean(drd["ERROR"]) : false)
                            {
                                Mensaje.Ok = false;
                                Mensaje.mensaje = "Hubo un error al consultar las promociones para dicho cliente";
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
            return Mensaje;
        }

        public List<TS_BETmpmovpuntosArticulo> SP_ITBCP_LISTAR_MOVPUNTOS(TS_BETmpmovpuntosArticulo input)
        {
            List<TS_BETmpmovpuntosArticulo> lista = new List<TS_BETmpmovpuntosArticulo>();
            TS_BETmpmovpuntosArticulo output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_MOVPUNTOS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = input.cdarticulo;
                    cmd.Parameters.Add("@cdgrupo02", SqlDbType.Char, 5).Value = input.cdgrupo02;
                    cmd.Parameters.Add("@tarjafiliacion", SqlDbType.VarChar, 25).Value = input.tarjafiliacion;
                    cmd.Parameters.Add("@localid", SqlDbType.Char, 4).Value = input.localid;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                    cmd.Parameters.Add("@mtototal", SqlDbType.Float, 8).Value = input.mtototal;


                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BETmpmovpuntosArticulo();
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["turno"]) : (byte?)null;
                            output.item = drd.HasColumn("item") ? drd["item"] == DBNull.Value ? (short?)null : Convert.ToInt16(drd["item"]) : (short?)null;
                            output.fechadoc = drd.HasColumn("fechadoc") ? drd["fechadoc"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fechadoc"]) : (DateTime?)null;
                            output.fechasis = drd.HasColumn("fechasis") ? drd["fechasis"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fechasis"]) : (DateTime?)null;
                            output.tcambio = drd.HasColumn("tcambio") ? drd["tcambio"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["tcambio"]) : (double?)null;
                            output.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["impuesto"]) : (double?)null;
                            output.precio = drd.HasColumn("precio") ? drd["precio"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["precio"]) : (double?)null;
                            output.cantidad = drd.HasColumn("cantidad") ? drd["cantidad"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["cantidad"]) : (double?)null;
                            output.mtodescto = drd.HasColumn("mtodescto") ? drd["mtodescto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["mtodescto"]) : (double?)null;
                            output.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["mtosubtotal"]) : (double?)null;
                            output.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["mtoimpuesto"]) : (double?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["mtototal"]) : (double?)null;
                            output.puntos = drd.HasColumn("puntos") ? drd["puntos"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["puntos"]) : (double?)null;
                            output.valoracumulado = drd.HasColumn("valoracumulado") ? drd["valoracumulado"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["valoracumulado"]) : (double?)null;
                            output.enviado = drd.HasColumn("enviado") ? drd["enviado"] == DBNull.Value ? false : Convert.ToBoolean(drd["enviado"]) : false;
                            output.credito = drd.HasColumn("credito") ? drd["credito"] == DBNull.Value ? false : Convert.ToBoolean(drd["credito"]) : false;
                            output.tarjafiliacion = drd.HasColumn("tarjafiliacion") ? drd["tarjafiliacion"] == DBNull.Value ? null : drd["tarjafiliacion"].ToString() : null;
                            output.rscliente = drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? null : drd["rscliente"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.tipotran = drd.HasColumn("tipotran") ? drd["tipotran"] == DBNull.Value ? null : drd["tipotran"].ToString() : null;
                            output.localid = drd.HasColumn("localid") ? drd["localid"] == DBNull.Value ? null : drd["localid"].ToString() : null;
                            output.cdproducto = drd.HasColumn("cdproducto") ? drd["cdproducto"] == DBNull.Value ? null : drd["cdproducto"].ToString() : null;
                            output.serieprinter = drd.HasColumn("serieprinter") ? drd["serieprinter"] == DBNull.Value ? null : drd["serieprinter"].ToString() : null;
                            output.almacen = drd.HasColumn("almacen") ? drd["almacen"] == DBNull.Value ? null : drd["almacen"].ToString() : null;
                            output.clienteid = drd.HasColumn("clienteid") ? drd["clienteid"] == DBNull.Value ? null : drd["clienteid"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.moneda = drd.HasColumn("moneda") ? drd["moneda"] == DBNull.Value ? null : drd["moneda"].ToString() : null;
                            output.estado = drd.HasColumn("estado") ? drd["estado"] == DBNull.Value ? null : drd["estado"].ToString() : null;
                            output.tmstamp = drd.HasColumn("tmstamp") ? drd["tmstamp"] == DBNull.Value ? (byte[])null : (byte[])drd["tmstamp"] : (byte[])null;
                            output.glosa = drd.HasColumn("glosa") ? drd["glosa"] == DBNull.Value ? null : drd["glosa"].ToString() : null;
                            output.referencia = drd.HasColumn("referencia") ? drd["referencia"] == DBNull.Value ? null : drd["referencia"].ToString() : null;
                            output.usuario = drd.HasColumn("usuario") ? drd["usuario"] == DBNull.Value ? null : drd["usuario"].ToString() : null;
                            output.glosa = drd.HasColumn("glosa") ? drd["glosa"] == DBNull.Value ? null : drd["glosa"].ToString() : null;
                            output.referencia = drd.HasColumn("referencia") ? drd["referencia"] == DBNull.Value ? null : drd["referencia"].ToString() : null;

                            output.glosaArticulo = drd.HasColumn("glosaArticulo") ? drd["glosaArticulo"] == DBNull.Value ? null : drd["glosaArticulo"].ToString() : null;
                            output.fecinicial = drd.HasColumn("fecinicial") ? drd["fecinicial"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinicial"]) : (DateTime?)null;
                            output.fecinventario = drd.HasColumn("fecinventario") ? drd["fecinventario"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinventario"]) : (DateTime?)null;
                            output.fecedicion = drd.HasColumn("fecedicion") ? drd["fecedicion"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecedicion"]) : (DateTime?)null;
                            output.bloqvta = drd.HasColumn("bloqvta") ? drd["bloqvta"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqvta"]) : false;
                            output.bloqcom = drd.HasColumn("bloqcom") ? drd["bloqcom"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqcom"]) : false;
                            output.flgglosa = drd.HasColumn("flgglosa") ? drd["flgglosa"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgglosa"]) : false;
                            output.moverstock = drd.HasColumn("moverstock") ? drd["moverstock"] == DBNull.Value ? false : Convert.ToBoolean(drd["moverstock"]) : false;
                            output.venta = drd.HasColumn("venta") ? drd["venta"] == DBNull.Value ? false : Convert.ToBoolean(drd["venta"]) : false;
                            output.consignacion = drd.HasColumn("consignacion") ? drd["consignacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["consignacion"]) : false;
                            output.trfgratuita = drd.HasColumn("trfgratuita") ? drd["trfgratuita"] == DBNull.Value ? false : Convert.ToBoolean(drd["trfgratuita"]) : false;
                            output.is_easytaxi = drd.HasColumn("is_easytaxi") ? drd["is_easytaxi"] == DBNull.Value ? false : Convert.ToBoolean(drd["is_easytaxi"]) : false;
                            output.bloqgral = drd.HasColumn("bloqgral") ? drd["bloqgral"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqgral"]) : false;
                            output.movimiento = drd.HasColumn("movimiento") ? drd["movimiento"] == DBNull.Value ? false : Convert.ToBoolean(drd["movimiento"]) : false;
                            output.vtaxmonto = drd.HasColumn("vtaxmonto") ? drd["vtaxmonto"] == DBNull.Value ? false : Convert.ToBoolean(drd["vtaxmonto"]) : false;
                            output.flgpromocion = drd.HasColumn("flgpromocion") ? drd["flgpromocion"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpromocion"]) : false;
                            output.usadecimales = drd.HasColumn("usadecimales") ? drd["usadecimales"] == DBNull.Value ? false : Convert.ToBoolean(drd["usadecimales"]) : false;
                            output._virtual = drd.HasColumn("virtual") ? drd["virtual"] == DBNull.Value ? false : Convert.ToBoolean(drd["virtual"]) : false;
                            output.ctoreposicion = drd.HasColumn("ctoreposicion") ? drd["ctoreposicion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoreposicion"]) : (decimal?)null;
                            output.impuestoArticulo = drd.HasColumn("impuestoArticulo") ? drd["impuestoArticulo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["impuestoArticulo"]) : (decimal?)null;
                            output.impuesto1 = drd.HasColumn("impuesto1") ? drd["impuesto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["impuesto1"]) : (decimal?)null;
                            output.ctoinicial = drd.HasColumn("ctoinicial") ? drd["ctoinicial"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoinicial"]) : (decimal?)null;
                            output.ctoinventario = drd.HasColumn("ctoinventario") ? drd["ctoinventario"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoinventario"]) : (decimal?)null;
                            output.ctopromedio = drd.HasColumn("ctopromedio") ? drd["ctopromedio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctopromedio"]) : (decimal?)null;
                            output.mgutilidad = drd.HasColumn("mgutilidad") ? drd["mgutilidad"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mgutilidad"]) : (decimal?)null;
                            output.montofidelizacion = drd.HasColumn("montofidelizacion") ? drd["montofidelizacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["montofidelizacion"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcdetraccion"]) : (decimal?)null;
                            output.equivalencia = drd.HasColumn("equivalencia") ? drd["equivalencia"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["equivalencia"]) : (decimal?)null;
                            output.valorconversion = drd.HasColumn("valorconversion") ? drd["valorconversion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorconversion"]) : (decimal?)null;
                            output.precioafiliacion = drd.HasColumn("precioafiliacion") ? drd["precioafiliacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precioafiliacion"]) : (decimal?)null;
                            output.porcpercepcion = drd.HasColumn("porcpercepcion") ? drd["porcpercepcion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcpercepcion"]) : (decimal?)null;
                            output.puntosfidelizacion = drd.HasColumn("puntosfidelizacion") ? drd["puntosfidelizacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["puntosfidelizacion"]) : (decimal?)null;
                            output.cantfidelizacion = drd.HasColumn("cantfidelizacion") ? drd["cantfidelizacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantfidelizacion"]) : (decimal?)null;
                            output.c_cuenta = drd.HasColumn("c_cuenta") ? drd["c_cuenta"] == DBNull.Value ? null : drd["c_cuenta"].ToString() : null;
                            output.c_cuenta_ventas = drd.HasColumn("c_cuenta_ventas") ? drd["c_cuenta_ventas"] == DBNull.Value ? null : drd["c_cuenta_ventas"].ToString() : null;
                            output.c_centrocosto = drd.HasColumn("c_centrocosto") ? drd["c_centrocosto"] == DBNull.Value ? null : drd["c_centrocosto"].ToString() : null;
                            output.c_cuenta_compras = drd.HasColumn("c_cuenta_compras") ? drd["c_cuenta_compras"] == DBNull.Value ? null : drd["c_cuenta_compras"].ToString() : null;
                            output.cdarticulovulcano = drd.HasColumn("cdarticulovulcano") ? drd["cdarticulovulcano"] == DBNull.Value ? null : drd["cdarticulovulcano"].ToString() : null;
                            output.cdarticulosunat = drd.HasColumn("cdarticulosunat") ? drd["cdarticulosunat"] == DBNull.Value ? null : drd["cdarticulosunat"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.dsarticulo = drd.HasColumn("dsarticulo") ? drd["dsarticulo"] == DBNull.Value ? null : drd["dsarticulo"].ToString() : null;
                            output.dsarticulo1 = drd.HasColumn("dsarticulo1") ? drd["dsarticulo1"] == DBNull.Value ? null : drd["dsarticulo1"].ToString() : null;
                            output.cdgrupo01 = drd.HasColumn("cdgrupo01") ? drd["cdgrupo01"] == DBNull.Value ? null : drd["cdgrupo01"].ToString() : null;
                            output.cdgrupo02 = drd.HasColumn("cdgrupo02") ? drd["cdgrupo02"] == DBNull.Value ? null : drd["cdgrupo02"].ToString() : null;
                            output.cdgrupo03 = drd.HasColumn("cdgrupo03") ? drd["cdgrupo03"] == DBNull.Value ? null : drd["cdgrupo03"].ToString() : null;
                            output.ctacompra = drd.HasColumn("ctacompra") ? drd["ctacompra"] == DBNull.Value ? null : drd["ctacompra"].ToString() : null;
                            output.ctaventa = drd.HasColumn("ctaventa") ? drd["ctaventa"] == DBNull.Value ? null : drd["ctaventa"].ToString() : null;
                            output.ctacosto = drd.HasColumn("ctacosto") ? drd["ctacosto"] == DBNull.Value ? null : drd["ctacosto"].ToString() : null;
                            output.ctaalmacen = drd.HasColumn("ctaalmacen") ? drd["ctaalmacen"] == DBNull.Value ? null : drd["ctaalmacen"].ToString() : null;
                            output.ticketfactura = drd.HasColumn("ticketfactura") ? drd["ticketfactura"] == DBNull.Value ? null : drd["ticketfactura"].ToString() : null;
                            output.monctoinventario = drd.HasColumn("monctoinventario") ? drd["monctoinventario"] == DBNull.Value ? null : drd["monctoinventario"].ToString() : null;
                            output.monctoprom = drd.HasColumn("monctoprom") ? drd["monctoprom"] == DBNull.Value ? null : drd["monctoprom"].ToString() : null;
                            output.monctorepo = drd.HasColumn("monctorepo") ? drd["monctorepo"] == DBNull.Value ? null : drd["monctorepo"].ToString() : null;
                            output.cdmedequiv = drd.HasColumn("cdmedequiv") ? drd["cdmedequiv"] == DBNull.Value ? null : drd["cdmedequiv"].ToString() : null;
                            output.cdamarre = drd.HasColumn("cdamarre") ? drd["cdamarre"] == DBNull.Value ? null : drd["cdamarre"].ToString() : null;
                            output.tpconversion = drd.HasColumn("tpconversion") ? drd["tpconversion"] == DBNull.Value ? null : drd["tpconversion"].ToString() : null;
                            output.cdgrupo04 = drd.HasColumn("cdgrupo04") ? drd["cdgrupo04"] == DBNull.Value ? null : drd["cdgrupo04"].ToString() : null;
                            output.cdgrupo05 = drd.HasColumn("cdgrupo05") ? drd["cdgrupo05"] == DBNull.Value ? null : drd["cdgrupo05"].ToString() : null;
                            output.cdunimed = drd.HasColumn("cdunimed") ? drd["cdunimed"] == DBNull.Value ? null : drd["cdunimed"].ToString() : null;
                            output.cdtalla = drd.HasColumn("cdtalla") ? drd["cdtalla"] == DBNull.Value ? null : drd["cdtalla"].ToString() : null;
                            output.tpformula = drd.HasColumn("tpformula") ? drd["tpformula"] == DBNull.Value ? null : drd["tpformula"].ToString() : null;
                            output.monctoinicial = drd.HasColumn("monctoinicial") ? drd["monctoinicial"] == DBNull.Value ? null : drd["monctoinicial"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BETmpmovpuntosArticulo> SP_ITBCP_LISTAR_MOVIMIENTO_PUNTOS_POR_GRUPO_COMBUSTIBLE(TS_BETmpmovpuntosArticulo input)
        {
            List<TS_BETmpmovpuntosArticulo> lista = new List<TS_BETmpmovpuntosArticulo>();
            TS_BETmpmovpuntosArticulo output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_MOVIMIENTO_PUNTOS_POR_GRUPO_COMBUSTIBLE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdgrupo02", SqlDbType.Char, 5).Value = input.cdgrupo02;
                    cmd.Parameters.Add("@localid", SqlDbType.Char, 4).Value = input.localid;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BETmpmovpuntosArticulo();
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["turno"]) : (byte?)null;
                            output.item = drd.HasColumn("item") ? drd["item"] == DBNull.Value ? (short?)null : Convert.ToInt16(drd["item"]) : (short?)null;
                            output.fechadoc = drd.HasColumn("fechadoc") ? drd["fechadoc"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fechadoc"]) : (DateTime?)null;
                            output.fechasis = drd.HasColumn("fechasis") ? drd["fechasis"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fechasis"]) : (DateTime?)null;
                            output.tcambio = drd.HasColumn("tcambio") ? drd["tcambio"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["tcambio"]) : (double?)null;
                            output.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["impuesto"]) : (double?)null;
                            output.precio = drd.HasColumn("precio") ? drd["precio"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["precio"]) : (double?)null;
                            output.cantidad = drd.HasColumn("cantidad") ? drd["cantidad"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["cantidad"]) : (double?)null;
                            output.mtodescto = drd.HasColumn("mtodescto") ? drd["mtodescto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["mtodescto"]) : (double?)null;
                            output.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["mtosubtotal"]) : (double?)null;
                            output.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["mtoimpuesto"]) : (double?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["mtototal"]) : (double?)null;
                            output.puntos = drd.HasColumn("puntos") ? drd["puntos"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["puntos"]) : (double?)null;
                            output.valoracumulado = drd.HasColumn("valoracumulado") ? drd["valoracumulado"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["valoracumulado"]) : (double?)null;
                            output.enviado = drd.HasColumn("enviado") ? drd["enviado"] == DBNull.Value ? false : Convert.ToBoolean(drd["enviado"]) : false;
                            output.credito = drd.HasColumn("credito") ? drd["credito"] == DBNull.Value ? false : Convert.ToBoolean(drd["credito"]) : false;
                            output.tarjafiliacion = drd.HasColumn("tarjafiliacion") ? drd["tarjafiliacion"] == DBNull.Value ? null : drd["tarjafiliacion"].ToString() : null;
                            output.rscliente = drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? null : drd["rscliente"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.tipotran = drd.HasColumn("tipotran") ? drd["tipotran"] == DBNull.Value ? null : drd["tipotran"].ToString() : null;
                            output.localid = drd.HasColumn("localid") ? drd["localid"] == DBNull.Value ? null : drd["localid"].ToString() : null;
                            output.cdproducto = drd.HasColumn("cdproducto") ? drd["cdproducto"] == DBNull.Value ? null : drd["cdproducto"].ToString() : null;
                            output.serieprinter = drd.HasColumn("serieprinter") ? drd["serieprinter"] == DBNull.Value ? null : drd["serieprinter"].ToString() : null;
                            output.almacen = drd.HasColumn("almacen") ? drd["almacen"] == DBNull.Value ? null : drd["almacen"].ToString() : null;
                            output.clienteid = drd.HasColumn("clienteid") ? drd["clienteid"] == DBNull.Value ? null : drd["clienteid"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.moneda = drd.HasColumn("moneda") ? drd["moneda"] == DBNull.Value ? null : drd["moneda"].ToString() : null;
                            output.estado = drd.HasColumn("estado") ? drd["estado"] == DBNull.Value ? null : drd["estado"].ToString() : null;
                            output.tmstamp = drd.HasColumn("tmstamp") ? drd["tmstamp"] == DBNull.Value ? (byte[])null : (byte[])drd["tmstamp"] : (byte[])null;
                            output.glosa = drd.HasColumn("glosa") ? drd["glosa"] == DBNull.Value ? null : drd["glosa"].ToString() : null;
                            output.referencia = drd.HasColumn("referencia") ? drd["referencia"] == DBNull.Value ? null : drd["referencia"].ToString() : null;
                            output.usuario = drd.HasColumn("usuario") ? drd["usuario"] == DBNull.Value ? null : drd["usuario"].ToString() : null;
                            output.glosa = drd.HasColumn("glosa") ? drd["glosa"] == DBNull.Value ? null : drd["glosa"].ToString() : null;
                            output.referencia = drd.HasColumn("referencia") ? drd["referencia"] == DBNull.Value ? null : drd["referencia"].ToString() : null;

                            output.glosaArticulo = drd.HasColumn("glosaArticulo") ? drd["glosaArticulo"] == DBNull.Value ? null : drd["glosaArticulo"].ToString() : null;
                            output.fecinicial = drd.HasColumn("fecinicial") ? drd["fecinicial"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinicial"]) : (DateTime?)null;
                            output.fecinventario = drd.HasColumn("fecinventario") ? drd["fecinventario"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinventario"]) : (DateTime?)null;
                            output.fecedicion = drd.HasColumn("fecedicion") ? drd["fecedicion"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecedicion"]) : (DateTime?)null;
                            output.bloqvta = drd.HasColumn("bloqvta") ? drd["bloqvta"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqvta"]) : false;
                            output.bloqcom = drd.HasColumn("bloqcom") ? drd["bloqcom"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqcom"]) : false;
                            output.flgglosa = drd.HasColumn("flgglosa") ? drd["flgglosa"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgglosa"]) : false;
                            output.moverstock = drd.HasColumn("moverstock") ? drd["moverstock"] == DBNull.Value ? false : Convert.ToBoolean(drd["moverstock"]) : false;
                            output.venta = drd.HasColumn("venta") ? drd["venta"] == DBNull.Value ? false : Convert.ToBoolean(drd["venta"]) : false;
                            output.consignacion = drd.HasColumn("consignacion") ? drd["consignacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["consignacion"]) : false;
                            output.trfgratuita = drd.HasColumn("trfgratuita") ? drd["trfgratuita"] == DBNull.Value ? false : Convert.ToBoolean(drd["trfgratuita"]) : false;
                            output.is_easytaxi = drd.HasColumn("is_easytaxi") ? drd["is_easytaxi"] == DBNull.Value ? false : Convert.ToBoolean(drd["is_easytaxi"]) : false;
                            output.bloqgral = drd.HasColumn("bloqgral") ? drd["bloqgral"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqgral"]) : false;
                            output.movimiento = drd.HasColumn("movimiento") ? drd["movimiento"] == DBNull.Value ? false : Convert.ToBoolean(drd["movimiento"]) : false;
                            output.vtaxmonto = drd.HasColumn("vtaxmonto") ? drd["vtaxmonto"] == DBNull.Value ? false : Convert.ToBoolean(drd["vtaxmonto"]) : false;
                            output.flgpromocion = drd.HasColumn("flgpromocion") ? drd["flgpromocion"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpromocion"]) : false;
                            output.usadecimales = drd.HasColumn("usadecimales") ? drd["usadecimales"] == DBNull.Value ? false : Convert.ToBoolean(drd["usadecimales"]) : false;
                            output._virtual = drd.HasColumn("virtual") ? drd["virtual"] == DBNull.Value ? false : Convert.ToBoolean(drd["virtual"]) : false;
                            output.ctoreposicion = drd.HasColumn("ctoreposicion") ? drd["ctoreposicion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoreposicion"]) : (decimal?)null;
                            output.impuestoArticulo = drd.HasColumn("impuestoArticulo") ? drd["impuestoArticulo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["impuestoArticulo"]) : (decimal?)null;
                            output.impuesto1 = drd.HasColumn("impuesto1") ? drd["impuesto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["impuesto1"]) : (decimal?)null;
                            output.ctoinicial = drd.HasColumn("ctoinicial") ? drd["ctoinicial"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoinicial"]) : (decimal?)null;
                            output.ctoinventario = drd.HasColumn("ctoinventario") ? drd["ctoinventario"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoinventario"]) : (decimal?)null;
                            output.ctopromedio = drd.HasColumn("ctopromedio") ? drd["ctopromedio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctopromedio"]) : (decimal?)null;
                            output.mgutilidad = drd.HasColumn("mgutilidad") ? drd["mgutilidad"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mgutilidad"]) : (decimal?)null;
                            output.montofidelizacion = drd.HasColumn("montofidelizacion") ? drd["montofidelizacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["montofidelizacion"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcdetraccion"]) : (decimal?)null;
                            output.equivalencia = drd.HasColumn("equivalencia") ? drd["equivalencia"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["equivalencia"]) : (decimal?)null;
                            output.valorconversion = drd.HasColumn("valorconversion") ? drd["valorconversion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorconversion"]) : (decimal?)null;
                            output.precioafiliacion = drd.HasColumn("precioafiliacion") ? drd["precioafiliacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precioafiliacion"]) : (decimal?)null;
                            output.porcpercepcion = drd.HasColumn("porcpercepcion") ? drd["porcpercepcion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcpercepcion"]) : (decimal?)null;
                            output.puntosfidelizacion = drd.HasColumn("puntosfidelizacion") ? drd["puntosfidelizacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["puntosfidelizacion"]) : (decimal?)null;
                            output.cantfidelizacion = drd.HasColumn("cantfidelizacion") ? drd["cantfidelizacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantfidelizacion"]) : (decimal?)null;
                            output.c_cuenta = drd.HasColumn("c_cuenta") ? drd["c_cuenta"] == DBNull.Value ? null : drd["c_cuenta"].ToString() : null;
                            output.c_cuenta_ventas = drd.HasColumn("c_cuenta_ventas") ? drd["c_cuenta_ventas"] == DBNull.Value ? null : drd["c_cuenta_ventas"].ToString() : null;
                            output.c_centrocosto = drd.HasColumn("c_centrocosto") ? drd["c_centrocosto"] == DBNull.Value ? null : drd["c_centrocosto"].ToString() : null;
                            output.c_cuenta_compras = drd.HasColumn("c_cuenta_compras") ? drd["c_cuenta_compras"] == DBNull.Value ? null : drd["c_cuenta_compras"].ToString() : null;
                            output.cdarticulovulcano = drd.HasColumn("cdarticulovulcano") ? drd["cdarticulovulcano"] == DBNull.Value ? null : drd["cdarticulovulcano"].ToString() : null;
                            output.cdarticulosunat = drd.HasColumn("cdarticulosunat") ? drd["cdarticulosunat"] == DBNull.Value ? null : drd["cdarticulosunat"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.dsarticulo = drd.HasColumn("dsarticulo") ? drd["dsarticulo"] == DBNull.Value ? null : drd["dsarticulo"].ToString() : null;
                            output.dsarticulo1 = drd.HasColumn("dsarticulo1") ? drd["dsarticulo1"] == DBNull.Value ? null : drd["dsarticulo1"].ToString() : null;
                            output.cdgrupo01 = drd.HasColumn("cdgrupo01") ? drd["cdgrupo01"] == DBNull.Value ? null : drd["cdgrupo01"].ToString() : null;
                            output.cdgrupo02 = drd.HasColumn("cdgrupo02") ? drd["cdgrupo02"] == DBNull.Value ? null : drd["cdgrupo02"].ToString() : null;
                            output.cdgrupo03 = drd.HasColumn("cdgrupo03") ? drd["cdgrupo03"] == DBNull.Value ? null : drd["cdgrupo03"].ToString() : null;
                            output.ctacompra = drd.HasColumn("ctacompra") ? drd["ctacompra"] == DBNull.Value ? null : drd["ctacompra"].ToString() : null;
                            output.ctaventa = drd.HasColumn("ctaventa") ? drd["ctaventa"] == DBNull.Value ? null : drd["ctaventa"].ToString() : null;
                            output.ctacosto = drd.HasColumn("ctacosto") ? drd["ctacosto"] == DBNull.Value ? null : drd["ctacosto"].ToString() : null;
                            output.ctaalmacen = drd.HasColumn("ctaalmacen") ? drd["ctaalmacen"] == DBNull.Value ? null : drd["ctaalmacen"].ToString() : null;
                            output.ticketfactura = drd.HasColumn("ticketfactura") ? drd["ticketfactura"] == DBNull.Value ? null : drd["ticketfactura"].ToString() : null;
                            output.monctoinventario = drd.HasColumn("monctoinventario") ? drd["monctoinventario"] == DBNull.Value ? null : drd["monctoinventario"].ToString() : null;
                            output.monctoprom = drd.HasColumn("monctoprom") ? drd["monctoprom"] == DBNull.Value ? null : drd["monctoprom"].ToString() : null;
                            output.monctorepo = drd.HasColumn("monctorepo") ? drd["monctorepo"] == DBNull.Value ? null : drd["monctorepo"].ToString() : null;
                            output.cdmedequiv = drd.HasColumn("cdmedequiv") ? drd["cdmedequiv"] == DBNull.Value ? null : drd["cdmedequiv"].ToString() : null;
                            output.cdamarre = drd.HasColumn("cdamarre") ? drd["cdamarre"] == DBNull.Value ? null : drd["cdamarre"].ToString() : null;
                            output.tpconversion = drd.HasColumn("tpconversion") ? drd["tpconversion"] == DBNull.Value ? null : drd["tpconversion"].ToString() : null;
                            output.cdgrupo04 = drd.HasColumn("cdgrupo04") ? drd["cdgrupo04"] == DBNull.Value ? null : drd["cdgrupo04"].ToString() : null;
                            output.cdgrupo05 = drd.HasColumn("cdgrupo05") ? drd["cdgrupo05"] == DBNull.Value ? null : drd["cdgrupo05"].ToString() : null;
                            output.cdunimed = drd.HasColumn("cdunimed") ? drd["cdunimed"] == DBNull.Value ? null : drd["cdunimed"].ToString() : null;
                            output.cdtalla = drd.HasColumn("cdtalla") ? drd["cdtalla"] == DBNull.Value ? null : drd["cdtalla"].ToString() : null;
                            output.tpformula = drd.HasColumn("tpformula") ? drd["tpformula"] == DBNull.Value ? null : drd["tpformula"].ToString() : null;
                            output.monctoinicial = drd.HasColumn("monctoinicial") ? drd["monctoinicial"] == DBNull.Value ? null : drd["monctoinicial"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BETmpmovpuntos> SP_ITBCP_LISTAR_MOVDET_PUNTOS(TS_BETmpmovpuntos input)
        {
            List<TS_BETmpmovpuntos> lista = new List<TS_BETmpmovpuntos>();
            TS_BETmpmovpuntos output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_MOVDET_PUNTOS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@tipotran", SqlDbType.Char, 1).Value = input.tipotran;
                    cmd.Parameters.Add("@localid", SqlDbType.Char, 4).Value = input.localid;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BETmpmovpuntos();
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["turno"]) : (byte?)null;
                            output.item = drd.HasColumn("item") ? drd["item"] == DBNull.Value ? (short?)null : Convert.ToInt16(drd["item"]) : (short?)null;
                            output.fechadoc = drd.HasColumn("fechadoc") ? drd["fechadoc"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fechadoc"]) : (DateTime?)null;
                            output.fechasis = drd.HasColumn("fechasis") ? drd["fechasis"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fechasis"]) : (DateTime?)null;
                            output.tcambio = drd.HasColumn("tcambio") ? drd["tcambio"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["tcambio"]) : (double?)null;
                            output.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["impuesto"]) : (double?)null;
                            output.precio = drd.HasColumn("precio") ? drd["precio"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["precio"]) : (double?)null;
                            output.cantidad = drd.HasColumn("cantidad") ? drd["cantidad"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["cantidad"]) : (double?)null;
                            output.mtodescto = drd.HasColumn("mtodescto") ? drd["mtodescto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["mtodescto"]) : (double?)null;
                            output.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["mtosubtotal"]) : (double?)null;
                            output.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["mtoimpuesto"]) : (double?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["mtototal"]) : (double?)null;
                            output.puntos = drd.HasColumn("puntos") ? drd["puntos"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["puntos"]) : (double?)null;
                            output.valoracumulado = drd.HasColumn("valoracumulado") ? drd["valoracumulado"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["valoracumulado"]) : (double?)null;
                            output.enviado = drd.HasColumn("enviado") ? drd["enviado"] == DBNull.Value ? false : Convert.ToBoolean(drd["enviado"]) : false;
                            output.credito = drd.HasColumn("credito") ? drd["credito"] == DBNull.Value ? false : Convert.ToBoolean(drd["credito"]) : false;
                            output.tarjafiliacion = drd.HasColumn("tarjafiliacion") ? drd["tarjafiliacion"] == DBNull.Value ? null : drd["tarjafiliacion"].ToString() : null;
                            output.rscliente = drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? null : drd["rscliente"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.tipotran = drd.HasColumn("tipotran") ? drd["tipotran"] == DBNull.Value ? null : drd["tipotran"].ToString() : null;
                            output.localid = drd.HasColumn("localid") ? drd["localid"] == DBNull.Value ? null : drd["localid"].ToString() : null;
                            output.cdproducto = drd.HasColumn("cdproducto") ? drd["cdproducto"] == DBNull.Value ? null : drd["cdproducto"].ToString() : null;
                            output.serieprinter = drd.HasColumn("serieprinter") ? drd["serieprinter"] == DBNull.Value ? null : drd["serieprinter"].ToString() : null;
                            output.almacen = drd.HasColumn("almacen") ? drd["almacen"] == DBNull.Value ? null : drd["almacen"].ToString() : null;
                            output.clienteid = drd.HasColumn("clienteid") ? drd["clienteid"] == DBNull.Value ? null : drd["clienteid"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.moneda = drd.HasColumn("moneda") ? drd["moneda"] == DBNull.Value ? null : drd["moneda"].ToString() : null;
                            output.estado = drd.HasColumn("estado") ? drd["estado"] == DBNull.Value ? null : drd["estado"].ToString() : null;
                            output.tmstamp = drd.HasColumn("tmstamp") ? drd["tmstamp"] == DBNull.Value ? (byte[])null : (byte[])drd["tmstamp"] : (byte[])null;
                            output.glosa = drd.HasColumn("glosa") ? drd["glosa"] == DBNull.Value ? null : drd["glosa"].ToString() : null;
                            output.referencia = drd.HasColumn("referencia") ? drd["referencia"] == DBNull.Value ? null : drd["referencia"].ToString() : null;
                            output.usuario = drd.HasColumn("usuario") ? drd["usuario"] == DBNull.Value ? null : drd["usuario"].ToString() : null;
                            output.glosa = drd.HasColumn("glosa") ? drd["glosa"] == DBNull.Value ? null : drd["glosa"].ToString() : null;
                            output.referencia = drd.HasColumn("referencia") ? drd["referencia"] == DBNull.Value ? null : drd["referencia"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BETmpmovfactura> SP_ITBCP_LISTAR_MOV_FACTURA(TS_BETmpmovfactura input)
        {
            List<TS_BETmpmovfactura> lista = new List<TS_BETmpmovfactura>();
            TS_BETmpmovfactura output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_MOV_FACTURA", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BETmpmovfactura();
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["turno"]) : (byte?)null;
                            output.item = drd.HasColumn("item") ? drd["item"] == DBNull.Value ? (short?)null : Convert.ToInt16(drd["item"]) : (short?)null;
                            output.fechadoc = drd.HasColumn("fechadoc") ? drd["fechadoc"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fechadoc"]) : (DateTime?)null;
                            output.fechasis = drd.HasColumn("fechasis") ? drd["fechasis"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fechasis"]) : (DateTime?)null;
                            output.tcambio = drd.HasColumn("tcambio") ? drd["tcambio"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["tcambio"]) : (double?)null;
                            output.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["impuesto"]) : (double?)null;
                            output.precio = drd.HasColumn("precio") ? drd["precio"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["precio"]) : (double?)null;
                            output.cantidad = drd.HasColumn("cantidad") ? drd["cantidad"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["cantidad"]) : (double?)null;
                            output.mtodescto = drd.HasColumn("mtodescto") ? drd["mtodescto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["mtodescto"]) : (double?)null;
                            output.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["mtosubtotal"]) : (double?)null;
                            output.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["mtoimpuesto"]) : (double?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["mtototal"]) : (double?)null;
                            output.puntos = drd.HasColumn("puntos") ? drd["puntos"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["puntos"]) : (double?)null;
                            output.valoracumulado = drd.HasColumn("valoracumulado") ? drd["valoracumulado"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["valoracumulado"]) : (double?)null;
                            output.costo = drd.HasColumn("costo") ? drd["costo"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["costo"]) : (double?)null;
                            output.enviado = drd.HasColumn("enviado") ? drd["enviado"] == DBNull.Value ? false : Convert.ToBoolean(drd["enviado"]) : false;
                            output.credito = drd.HasColumn("credito") ? drd["credito"] == DBNull.Value ? false : Convert.ToBoolean(drd["credito"]) : false;
                            output.rscliente = drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? null : drd["rscliente"].ToString() : null;
                            output.drcliente = drd.HasColumn("drcliente") ? drd["drcliente"] == DBNull.Value ? null : drd["drcliente"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.localid = drd.HasColumn("localid") ? drd["localid"] == DBNull.Value ? null : drd["localid"].ToString() : null;
                            output.cdproducto = drd.HasColumn("cdproducto") ? drd["cdproducto"] == DBNull.Value ? null : drd["cdproducto"].ToString() : null;
                            output.almacen = drd.HasColumn("almacen") ? drd["almacen"] == DBNull.Value ? null : drd["almacen"].ToString() : null;
                            output.clienteid = drd.HasColumn("clienteid") ? drd["clienteid"] == DBNull.Value ? null : drd["clienteid"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.moneda = drd.HasColumn("moneda") ? drd["moneda"] == DBNull.Value ? null : drd["moneda"].ToString() : null;
                            output.estado = drd.HasColumn("estado") ? drd["estado"] == DBNull.Value ? null : drd["estado"].ToString() : null;
                            output.cara = drd.HasColumn("cara") ? drd["cara"] == DBNull.Value ? null : drd["cara"].ToString() : null;
                            output.tmstamp = drd.HasColumn("tmstamp") ? drd["tmstamp"] == DBNull.Value ? (byte[])null : (byte[])drd["tmstamp"] : (byte[])null;
                            output.glosa = drd.HasColumn("glosa") ? drd["glosa"] == DBNull.Value ? null : drd["glosa"].ToString() : null;
                            output.referencia = drd.HasColumn("referencia") ? drd["referencia"] == DBNull.Value ? null : drd["referencia"].ToString() : null;
                            output.usuario = drd.HasColumn("usuario") ? drd["usuario"] == DBNull.Value ? null : drd["usuario"].ToString() : null;
                            output.glosa = drd.HasColumn("glosa") ? drd["glosa"] == DBNull.Value ? null : drd["glosa"].ToString() : null;
                            output.referencia = drd.HasColumn("referencia") ? drd["referencia"] == DBNull.Value ? null : drd["referencia"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BELocal> SP_ITBCP_LISTAR_LOCAL_POR_ID(TS_BELocal input)
        {
            List<TS_BELocal> lista = new List<TS_BELocal>();
            TS_BELocal output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_LOCAL_POR_ID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 4).Value = input.cdlocal;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BELocal();
                            output.nro_centralizacion = drd.HasColumn("nro_centralizacion") ? drd["nro_centralizacion"] == DBNull.Value ? null : drd["nro_centralizacion"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.dslocal = drd.HasColumn("dslocal") ? drd["dslocal"] == DBNull.Value ? null : drd["dslocal"].ToString() : null;
                            output.drlocal = drd.HasColumn("drlocal") ? drd["drlocal"] == DBNull.Value ? null : drd["drlocal"].ToString() : null;
                            output.tlflocal = drd.HasColumn("tlflocal") ? drd["tlflocal"] == DBNull.Value ? null : drd["tlflocal"].ToString() : null;
                            output.tlflocal1 = drd.HasColumn("tlflocal1") ? drd["tlflocal1"] == DBNull.Value ? null : drd["tlflocal1"].ToString() : null;
                            output.cdzona = drd.HasColumn("cdzona") ? drd["cdzona"] == DBNull.Value ? null : drd["cdzona"].ToString() : null;
                            output.cdsunat = drd.HasColumn("cdsunat") ? drd["cdsunat"] == DBNull.Value ? null : drd["cdsunat"].ToString() : null;
                            output.dislocal = drd.HasColumn("dislocal") ? drd["dislocal"] == DBNull.Value ? null : drd["dislocal"].ToString() : null;
                            output.provlocal = drd.HasColumn("provlocal") ? drd["provlocal"] == DBNull.Value ? null : drd["provlocal"].ToString() : null;
                            output.deplocal = drd.HasColumn("deplocal") ? drd["deplocal"] == DBNull.Value ? null : drd["deplocal"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEGruposconsumo> SP_ITBCP_LISTAR_GRUPOS_CONSUMOS(TS_BEGruposconsumo input)
        {
            List<TS_BEGruposconsumo> lista = new List<TS_BEGruposconsumo>();
            TS_BEGruposconsumo output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_GRUPOS_CONSUMOS", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEGruposconsumo();
                            output.cdgrupos = drd.HasColumn("cdgrupos") ? drd["cdgrupos"] == DBNull.Value ? null : drd["cdgrupos"].ToString() : null;
                            output.cdgrupo02 = drd.HasColumn("cdgrupo02") ? drd["cdgrupo02"] == DBNull.Value ? null : drd["cdgrupo02"].ToString() : null;
                            output.dsgrupos = drd.HasColumn("dsgrupos") ? drd["dsgrupos"] == DBNull.Value ? null : drd["dsgrupos"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public TS_BETicket SP_ITBCP_LISTAR_FORMATO_TICKET()
        {
            TS_BETicket cTicket = new TS_BETicket();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_FORMATO_TICKET", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            cTicket.cabecera = drd.HasColumn("cabecera") ? drd["cabecera"] == DBNull.Value ? "" : drd["cabecera"].ToString().Trim() : "";
                            cTicket.pie = drd.HasColumn("pie") ? drd["pie"] == DBNull.Value ? "" : drd["pie"].ToString().Trim() : "";
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
            return cTicket;
        }

        public TS_BETicket SP_ITBCP_LISTAR_FORMATO_NOTA_VENTA()
        {
            TS_BETicket cTicket = new TS_BETicket();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_FORMATO_NOTA_VENTA", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            cTicket.cabecera = drd.HasColumn("cabecera") ? drd["cabecera"] == DBNull.Value ? "" : drd["cabecera"].ToString().Trim() : "";
                            cTicket.pie = drd.HasColumn("pie") ? drd["pie"] == DBNull.Value ? "" : drd["pie"].ToString().Trim() : "";
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
            return cTicket;
        }

        public TS_BETicket SP_ITBCP_LISTAR_FORMATO_SERAFIN()
        {
            TS_BETicket cTicket = new TS_BETicket();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_FORMATO_SERAFIN", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            cTicket.cabecera = drd.HasColumn("cabecera") ? drd["cabecera"] == DBNull.Value ? "" : drd["cabecera"].ToString().Trim() : "";
                            cTicket.pie = drd.HasColumn("pie") ? drd["pie"] == DBNull.Value ? "" : drd["pie"].ToString().Trim() : "";
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
            return cTicket;
        }

        public List<TS_BECnfgvalorpuntoVariables> SP_ITBCP_LISTAR_CONF_PUNTO(TS_BECnfgvalorpuntoVariables input)
        {
            List<TS_BECnfgvalorpuntoVariables> lista = new List<TS_BECnfgvalorpuntoVariables>();
            TS_BECnfgvalorpuntoVariables output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_CONF_PUNTO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PrefijoCard", SqlDbType.Int, 4).Value = input.prefijocard;
                    cmd.Parameters.Add("@TipoAcumula", SqlDbType.Char, 2).Value = input.tipoacumula;
                    cmd.Parameters.Add("@Clave", SqlDbType.VarChar, 30).Value = input.clave;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BECnfgvalorpuntoVariables();
                            output.valorid = drd.HasColumn("valorid") ? drd["valorid"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["valorid"]) : (int?)null;
                            output.prefijocard = drd.HasColumn("prefijocard") ? drd["prefijocard"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["prefijocard"]) : (int?)null;
                            output.concepto = drd.HasColumn("concepto") ? drd["concepto"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["concepto"]) : (int?)null;
                            output.tipopunto = drd.HasColumn("tipopunto") ? drd["tipopunto"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["tipopunto"]) : (int?)null;
                            output.valorpunto = drd.HasColumn("valorpunto") ? drd["valorpunto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["valorpunto"]) : (double?)null;
                            output.status = drd.HasColumn("status") ? drd["status"] == DBNull.Value ? false : Convert.ToBoolean(drd["status"]) : false;
                            output.descripcion = drd.HasColumn("descripcion") ? drd["descripcion"] == DBNull.Value ? null : drd["descripcion"].ToString() : null;
                            output.tipoacumula = drd.HasColumn("tipoacumula") ? drd["tipoacumula"] == DBNull.Value ? null : drd["tipoacumula"].ToString() : null;
                            output.tipocanje = drd.HasColumn("tipocanje") ? drd["tipocanje"] == DBNull.Value ? null : drd["tipocanje"].ToString() : null;
                            output.conceptos_prefijo = drd.HasColumn("conceptos_prefijo") ? drd["conceptos_prefijo"] == DBNull.Value ? null : drd["conceptos_prefijo"].ToString() : null;

                            output.varid = drd.HasColumn("varid") ? drd["varid"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["varid"]) : (int?)null;
                            output.valorpto = drd.HasColumn("valorpto") ? drd["valorpto"] == DBNull.Value ? (double?)null : Convert.ToDouble(drd["valorpto"]) : (double?)null;
                            output.flgelimina = drd.HasColumn("flgelimina") ? drd["flgelimina"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgelimina"]) : false;
                            output.tipovar = drd.HasColumn("TipoGrupo") ? drd["TipoGrupo"] == DBNull.Value ? null : drd["TipoGrupo"].ToString() : null;
                            output.clave = drd.HasColumn("clave") ? drd["clave"] == DBNull.Value ? null : drd["clave"].ToString() : null;
                            output.descripcion = drd.HasColumn("DescripcionVariable") ? drd["DescripcionVariable"] == DBNull.Value ? null : drd["DescripcionVariable"].ToString() : null;
                            output.descripcionTipoPunto = drd.HasColumn("TipoAA") ? drd["TipoAA"] == DBNull.Value ? null : drd["TipoAA"].ToString() : null;
                            output.config = drd.HasColumn("config") ? drd["config"] == DBNull.Value ? null : drd["config"].ToString() : null;
                            output.valor = drd.HasColumn("valor") ? drd["valor"] == DBNull.Value ? null : drd["valor"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }             

       
        public List<TS_BEGrupo02> SP_ITBCP_LISTAR_CATEGORIAS_GRUPO2(TS_BEGrupo02 input)
        {
            List<TS_BEGrupo02> lista = new List<TS_BEGrupo02>();
            TS_BEGrupo02 output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_CATEGORIAS_GRUPO2", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEGrupo02();
                            output.dsgrupo02 = drd.HasColumn("dsgrupo02") ? drd["dsgrupo02"] == DBNull.Value ? null : drd["dsgrupo02"].ToString() : null;
                            output.dagrupo02 = drd.HasColumn("dagrupo02") ? drd["dagrupo02"] == DBNull.Value ? null : drd["dagrupo02"].ToString() : null;
                            output.cdgrupo02 = drd.HasColumn("cdgrupo02") ? drd["cdgrupo02"] == DBNull.Value ? null : drd["cdgrupo02"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BECara> SP_ITBCP_LISTAR_CARA_POR_POSICION(TS_BECara input)
        {
            List<TS_BECara> lista = new List<TS_BECara>();
            TS_BECara output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_CARA_POR_POSICION", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BECara();
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cara = drd.HasColumn("cara") ? drd["cara"] == DBNull.Value ? null : drd["cara"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEArticulo> SP_ITBCP_LISTAR_ARTICULO_POR_GRUPO_COMBUSTIBLE(TS_BEArticulo input)
        {
            List<TS_BEArticulo> lista = new List<TS_BEArticulo>();
            TS_BEArticulo output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_ARTICULO_POR_GRUPO_COMBUSTIBLE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdgrupo02", SqlDbType.Char, 5).Value = input.cdgrupo02;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEArticulo();
                            output.glosa = drd.HasColumn("glosa") ? drd["glosa"] == DBNull.Value ? null : drd["glosa"].ToString() : null;
                            output.fecinicial = drd.HasColumn("fecinicial") ? drd["fecinicial"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinicial"]) : (DateTime?)null;
                            output.fecinventario = drd.HasColumn("fecinventario") ? drd["fecinventario"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinventario"]) : (DateTime?)null;
                            output.fecedicion = drd.HasColumn("fecedicion") ? drd["fecedicion"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecedicion"]) : (DateTime?)null;
                            output.bloqvta = drd.HasColumn("bloqvta") ? drd["bloqvta"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqvta"]) : false;
                            output.bloqcom = drd.HasColumn("bloqcom") ? drd["bloqcom"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqcom"]) : false;
                            output.flgglosa = drd.HasColumn("flgglosa") ? drd["flgglosa"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgglosa"]) : false;
                            output.moverstock = drd.HasColumn("moverstock") ? drd["moverstock"] == DBNull.Value ? false : Convert.ToBoolean(drd["moverstock"]) : false;
                            output.venta = drd.HasColumn("venta") ? drd["venta"] == DBNull.Value ? false : Convert.ToBoolean(drd["venta"]) : false;
                            output.consignacion = drd.HasColumn("consignacion") ? drd["consignacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["consignacion"]) : false;
                            output.trfgratuita = drd.HasColumn("trfgratuita") ? drd["trfgratuita"] == DBNull.Value ? false : Convert.ToBoolean(drd["trfgratuita"]) : false;
                            output.is_easytaxi = drd.HasColumn("is_easytaxi") ? drd["is_easytaxi"] == DBNull.Value ? false : Convert.ToBoolean(drd["is_easytaxi"]) : false;
                            output.bloqgral = drd.HasColumn("bloqgral") ? drd["bloqgral"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqgral"]) : false;
                            output.movimiento = drd.HasColumn("movimiento") ? drd["movimiento"] == DBNull.Value ? false : Convert.ToBoolean(drd["movimiento"]) : false;
                            output.vtaxmonto = drd.HasColumn("vtaxmonto") ? drd["vtaxmonto"] == DBNull.Value ? false : Convert.ToBoolean(drd["vtaxmonto"]) : false;
                            output.flgpromocion = drd.HasColumn("flgpromocion") ? drd["flgpromocion"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpromocion"]) : false;
                            output.usadecimales = drd.HasColumn("usadecimales") ? drd["usadecimales"] == DBNull.Value ? false : Convert.ToBoolean(drd["usadecimales"]) : false;
                            output._virtual = drd.HasColumn("virtual") ? drd["virtual"] == DBNull.Value ? false : Convert.ToBoolean(drd["virtual"]) : false;
                            output.ctoreposicion = drd.HasColumn("ctoreposicion") ? drd["ctoreposicion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoreposicion"]) : (decimal?)null;
                            output.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["impuesto"]) : 0;
                            output.impuesto1 = drd.HasColumn("impuesto1") ? drd["impuesto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["impuesto1"]) : (decimal?)null;
                            output.ctoinicial = drd.HasColumn("ctoinicial") ? drd["ctoinicial"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoinicial"]) : (decimal?)null;
                            output.ctoinventario = drd.HasColumn("ctoinventario") ? drd["ctoinventario"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoinventario"]) : (decimal?)null;
                            output.ctopromedio = drd.HasColumn("ctopromedio") ? drd["ctopromedio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctopromedio"]) : (decimal?)null;
                            output.mgutilidad = drd.HasColumn("mgutilidad") ? drd["mgutilidad"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mgutilidad"]) : (decimal?)null;
                            output.montofidelizacion = drd.HasColumn("montofidelizacion") ? drd["montofidelizacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["montofidelizacion"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["porcdetraccion"]) : 0;
                            output.equivalencia = drd.HasColumn("equivalencia") ? drd["equivalencia"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["equivalencia"]) : (decimal?)null;
                            output.valorconversion = drd.HasColumn("valorconversion") ? drd["valorconversion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["valorconversion"]) : 0;
                            output.precioafiliacion = drd.HasColumn("precioafiliacion") ? drd["precioafiliacion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["precioafiliacion"]) : 0;
                            output.porcpercepcion = drd.HasColumn("porcpercepcion") ? drd["porcpercepcion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["porcpercepcion"]) : 0;
                            output.puntosfidelizacion = drd.HasColumn("puntosfidelizacion") ? drd["puntosfidelizacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["puntosfidelizacion"]) : (decimal?)null;
                            output.cantfidelizacion = drd.HasColumn("cantfidelizacion") ? drd["cantfidelizacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantfidelizacion"]) : (decimal?)null;
                            output.c_cuenta = drd.HasColumn("c_cuenta") ? drd["c_cuenta"] == DBNull.Value ? null : drd["c_cuenta"].ToString() : null;
                            output.c_cuenta_ventas = drd.HasColumn("c_cuenta_ventas") ? drd["c_cuenta_ventas"] == DBNull.Value ? null : drd["c_cuenta_ventas"].ToString() : null;
                            output.c_centrocosto = drd.HasColumn("c_centrocosto") ? drd["c_centrocosto"] == DBNull.Value ? null : drd["c_centrocosto"].ToString() : null;
                            output.c_cuenta_compras = drd.HasColumn("c_cuenta_compras") ? drd["c_cuenta_compras"] == DBNull.Value ? null : drd["c_cuenta_compras"].ToString() : null;
                            output.cdarticulovulcano = drd.HasColumn("cdarticulovulcano") ? drd["cdarticulovulcano"] == DBNull.Value ? null : drd["cdarticulovulcano"].ToString() : null;
                            output.cdarticulosunat = drd.HasColumn("cdarticulosunat") ? drd["cdarticulosunat"] == DBNull.Value ? null : drd["cdarticulosunat"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.dsarticulo = drd.HasColumn("dsarticulo") ? drd["dsarticulo"] == DBNull.Value ? null : drd["dsarticulo"].ToString() : null;
                            output.dsarticulo1 = drd.HasColumn("dsarticulo1") ? drd["dsarticulo1"] == DBNull.Value ? null : drd["dsarticulo1"].ToString() : null;
                            output.cdgrupo01 = drd.HasColumn("cdgrupo01") ? drd["cdgrupo01"] == DBNull.Value ? null : drd["cdgrupo01"].ToString() : null;
                            output.cdgrupo02 = drd.HasColumn("cdgrupo02") ? drd["cdgrupo02"] == DBNull.Value ? null : drd["cdgrupo02"].ToString() : null;
                            output.cdgrupo03 = drd.HasColumn("cdgrupo03") ? drd["cdgrupo03"] == DBNull.Value ? null : drd["cdgrupo03"].ToString() : null;
                            output.ctacompra = drd.HasColumn("ctacompra") ? drd["ctacompra"] == DBNull.Value ? null : drd["ctacompra"].ToString() : null;
                            output.ctaventa = drd.HasColumn("ctaventa") ? drd["ctaventa"] == DBNull.Value ? null : drd["ctaventa"].ToString() : null;
                            output.ctacosto = drd.HasColumn("ctacosto") ? drd["ctacosto"] == DBNull.Value ? null : drd["ctacosto"].ToString() : null;
                            output.ctaalmacen = drd.HasColumn("ctaalmacen") ? drd["ctaalmacen"] == DBNull.Value ? null : drd["ctaalmacen"].ToString() : null;
                            output.ticketfactura = drd.HasColumn("ticketfactura") ? drd["ticketfactura"] == DBNull.Value ? null : drd["ticketfactura"].ToString() : null;
                            output.monctoinventario = drd.HasColumn("monctoinventario") ? drd["monctoinventario"] == DBNull.Value ? null : drd["monctoinventario"].ToString() : null;
                            output.monctoprom = drd.HasColumn("monctoprom") ? drd["monctoprom"] == DBNull.Value ? null : drd["monctoprom"].ToString() : null;
                            output.monctorepo = drd.HasColumn("monctorepo") ? drd["monctorepo"] == DBNull.Value ? null : drd["monctorepo"].ToString() : null;
                            output.cdmedequiv = drd.HasColumn("cdmedequiv") ? drd["cdmedequiv"] == DBNull.Value ? null : drd["cdmedequiv"].ToString() : null;
                            output.cdamarre = drd.HasColumn("cdamarre") ? drd["cdamarre"] == DBNull.Value ? null : drd["cdamarre"].ToString() : null;
                            output.tpconversion = drd.HasColumn("tpconversion") ? drd["tpconversion"] == DBNull.Value ? null : drd["tpconversion"].ToString() : null;
                            output.cdgrupo04 = drd.HasColumn("cdgrupo04") ? drd["cdgrupo04"] == DBNull.Value ? null : drd["cdgrupo04"].ToString() : null;
                            output.cdgrupo05 = drd.HasColumn("cdgrupo05") ? drd["cdgrupo05"] == DBNull.Value ? null : drd["cdgrupo05"].ToString() : null;
                            output.cdunimed = drd.HasColumn("cdunimed") ? drd["cdunimed"] == DBNull.Value ? null : drd["cdunimed"].ToString() : null;
                            output.cdtalla = drd.HasColumn("cdtalla") ? drd["cdtalla"] == DBNull.Value ? null : drd["cdtalla"].ToString() : null;
                            output.tpformula = drd.HasColumn("tpformula") ? drd["tpformula"] == DBNull.Value ? null : drd["tpformula"].ToString() : null;
                            output.monctoinicial = drd.HasColumn("monctoinicial") ? drd["monctoinicial"] == DBNull.Value ? null : drd["monctoinicial"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEArticulo> SP_ITBCP_LISTAR_ARTICULO_POR_CODIGO(TS_BEArticulo input)
        {
            List<TS_BEArticulo> lista = new List<TS_BEArticulo>();
            TS_BEArticulo output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_ARTICULO_POR_CODIGO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = input.cdarticulo;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEArticulo();
                            output.glosa = drd.HasColumn("glosa") ? drd["glosa"] == DBNull.Value ? null : drd["glosa"].ToString() : null;
                            output.fecinicial = drd.HasColumn("fecinicial") ? drd["fecinicial"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinicial"]) : (DateTime?)null;
                            output.fecinventario = drd.HasColumn("fecinventario") ? drd["fecinventario"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinventario"]) : (DateTime?)null;
                            output.fecedicion = drd.HasColumn("fecedicion") ? drd["fecedicion"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecedicion"]) : (DateTime?)null;
                            output.bloqvta = drd.HasColumn("bloqvta") ? drd["bloqvta"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqvta"]) : false;
                            output.bloqcom = drd.HasColumn("bloqcom") ? drd["bloqcom"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqcom"]) : false;
                            output.flgglosa = drd.HasColumn("flgglosa") ? drd["flgglosa"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgglosa"]) : false;
                            output.moverstock = drd.HasColumn("moverstock") ? drd["moverstock"] == DBNull.Value ? false : Convert.ToBoolean(drd["moverstock"]) : false;
                            output.venta = drd.HasColumn("venta") ? drd["venta"] == DBNull.Value ? false : Convert.ToBoolean(drd["venta"]) : false;
                            output.consignacion = drd.HasColumn("consignacion") ? drd["consignacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["consignacion"]) : false;
                            output.trfgratuita = drd.HasColumn("trfgratuita") ? drd["trfgratuita"] == DBNull.Value ? false : Convert.ToBoolean(drd["trfgratuita"]) : false;
                            output.is_easytaxi = drd.HasColumn("is_easytaxi") ? drd["is_easytaxi"] == DBNull.Value ? false : Convert.ToBoolean(drd["is_easytaxi"]) : false;
                            output.bloqgral = drd.HasColumn("bloqgral") ? drd["bloqgral"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqgral"]) : false;
                            output.movimiento = drd.HasColumn("movimiento") ? drd["movimiento"] == DBNull.Value ? false : Convert.ToBoolean(drd["movimiento"]) : false;
                            output.vtaxmonto = drd.HasColumn("vtaxmonto") ? drd["vtaxmonto"] == DBNull.Value ? false : Convert.ToBoolean(drd["vtaxmonto"]) : false;
                            output.flgpromocion = drd.HasColumn("flgpromocion") ? drd["flgpromocion"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpromocion"]) : false;
                            output.usadecimales = drd.HasColumn("usadecimales") ? drd["usadecimales"] == DBNull.Value ? false : Convert.ToBoolean(drd["usadecimales"]) : false;
                            output._virtual = drd.HasColumn("virtual") ? drd["virtual"] == DBNull.Value ? false : Convert.ToBoolean(drd["virtual"]) : false;
                            output.ctoreposicion = drd.HasColumn("ctoreposicion") ? drd["ctoreposicion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoreposicion"]) : (decimal?)null;
                            output.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["impuesto"]) : 0;
                            output.impuesto1 = drd.HasColumn("impuesto1") ? drd["impuesto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["impuesto1"]) : (decimal?)null;
                            output.ctoinicial = drd.HasColumn("ctoinicial") ? drd["ctoinicial"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoinicial"]) : (decimal?)null;
                            output.ctoinventario = drd.HasColumn("ctoinventario") ? drd["ctoinventario"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoinventario"]) : (decimal?)null;
                            output.ctopromedio = drd.HasColumn("ctopromedio") ? drd["ctopromedio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctopromedio"]) : (decimal?)null;
                            output.mgutilidad = drd.HasColumn("mgutilidad") ? drd["mgutilidad"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mgutilidad"]) : (decimal?)null;
                            output.montofidelizacion = drd.HasColumn("montofidelizacion") ? drd["montofidelizacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["montofidelizacion"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["porcdetraccion"]) : 0;
                            output.equivalencia = drd.HasColumn("equivalencia") ? drd["equivalencia"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["equivalencia"]) : (decimal?)null;
                            output.valorconversion = drd.HasColumn("valorconversion") ? drd["valorconversion"] == DBNull.Value ? 0: Convert.ToDecimal(drd["valorconversion"]) : 0;
                            output.precioafiliacion = drd.HasColumn("precioafiliacion") ? drd["precioafiliacion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["precioafiliacion"]) : 0;
                            output.porcpercepcion = drd.HasColumn("porcpercepcion") ? drd["porcpercepcion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["porcpercepcion"]) : 0;
                            output.puntosfidelizacion = drd.HasColumn("puntosfidelizacion") ? drd["puntosfidelizacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["puntosfidelizacion"]) : (decimal?)null;
                            output.cantfidelizacion = drd.HasColumn("cantfidelizacion") ? drd["cantfidelizacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantfidelizacion"]) : (decimal?)null;
                            output.c_cuenta = drd.HasColumn("c_cuenta") ? drd["c_cuenta"] == DBNull.Value ? null : drd["c_cuenta"].ToString() : null;
                            output.c_cuenta_ventas = drd.HasColumn("c_cuenta_ventas") ? drd["c_cuenta_ventas"] == DBNull.Value ? null : drd["c_cuenta_ventas"].ToString() : null;
                            output.c_centrocosto = drd.HasColumn("c_centrocosto") ? drd["c_centrocosto"] == DBNull.Value ? null : drd["c_centrocosto"].ToString() : null;
                            output.c_cuenta_compras = drd.HasColumn("c_cuenta_compras") ? drd["c_cuenta_compras"] == DBNull.Value ? null : drd["c_cuenta_compras"].ToString() : null;
                            output.cdarticulovulcano = drd.HasColumn("cdarticulovulcano") ? drd["cdarticulovulcano"] == DBNull.Value ? null : drd["cdarticulovulcano"].ToString() : null;
                            output.cdarticulosunat = drd.HasColumn("cdarticulosunat") ? drd["cdarticulosunat"] == DBNull.Value ? null : drd["cdarticulosunat"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.dsarticulo = drd.HasColumn("dsarticulo") ? drd["dsarticulo"] == DBNull.Value ? null : drd["dsarticulo"].ToString() : null;
                            output.dsarticulo1 = drd.HasColumn("dsarticulo1") ? drd["dsarticulo1"] == DBNull.Value ? null : drd["dsarticulo1"].ToString() : null;
                            output.cdgrupo01 = drd.HasColumn("cdgrupo01") ? drd["cdgrupo01"] == DBNull.Value ? null : drd["cdgrupo01"].ToString() : null;
                            output.cdgrupo02 = drd.HasColumn("cdgrupo02") ? drd["cdgrupo02"] == DBNull.Value ? null : drd["cdgrupo02"].ToString() : null;
                            output.cdgrupo03 = drd.HasColumn("cdgrupo03") ? drd["cdgrupo03"] == DBNull.Value ? null : drd["cdgrupo03"].ToString() : null;
                            output.ctacompra = drd.HasColumn("ctacompra") ? drd["ctacompra"] == DBNull.Value ? null : drd["ctacompra"].ToString() : null;
                            output.ctaventa = drd.HasColumn("ctaventa") ? drd["ctaventa"] == DBNull.Value ? null : drd["ctaventa"].ToString() : null;
                            output.ctacosto = drd.HasColumn("ctacosto") ? drd["ctacosto"] == DBNull.Value ? null : drd["ctacosto"].ToString() : null;
                            output.ctaalmacen = drd.HasColumn("ctaalmacen") ? drd["ctaalmacen"] == DBNull.Value ? null : drd["ctaalmacen"].ToString() : null;
                            output.ticketfactura = drd.HasColumn("ticketfactura") ? drd["ticketfactura"] == DBNull.Value ? null : drd["ticketfactura"].ToString() : null;
                            output.monctoinventario = drd.HasColumn("monctoinventario") ? drd["monctoinventario"] == DBNull.Value ? null : drd["monctoinventario"].ToString() : null;
                            output.monctoprom = drd.HasColumn("monctoprom") ? drd["monctoprom"] == DBNull.Value ? null : drd["monctoprom"].ToString() : null;
                            output.monctorepo = drd.HasColumn("monctorepo") ? drd["monctorepo"] == DBNull.Value ? null : drd["monctorepo"].ToString() : null;
                            output.cdmedequiv = drd.HasColumn("cdmedequiv") ? drd["cdmedequiv"] == DBNull.Value ? null : drd["cdmedequiv"].ToString() : null;
                            output.cdamarre = drd.HasColumn("cdamarre") ? drd["cdamarre"] == DBNull.Value ? null : drd["cdamarre"].ToString() : null;
                            output.tpconversion = drd.HasColumn("tpconversion") ? drd["tpconversion"] == DBNull.Value ? null : drd["tpconversion"].ToString() : null;
                            output.cdgrupo04 = drd.HasColumn("cdgrupo04") ? drd["cdgrupo04"] == DBNull.Value ? null : drd["cdgrupo04"].ToString() : null;
                            output.cdgrupo05 = drd.HasColumn("cdgrupo05") ? drd["cdgrupo05"] == DBNull.Value ? null : drd["cdgrupo05"].ToString() : null;
                            output.cdunimed = drd.HasColumn("cdunimed") ? drd["cdunimed"] == DBNull.Value ? null : drd["cdunimed"].ToString() : null;
                            output.cdtalla = drd.HasColumn("cdtalla") ? drd["cdtalla"] == DBNull.Value ? null : drd["cdtalla"].ToString() : null;
                            output.tpformula = drd.HasColumn("tpformula") ? drd["tpformula"] == DBNull.Value ? null : drd["tpformula"].ToString() : null;
                            output.monctoinicial = drd.HasColumn("monctoinicial") ? drd["monctoinicial"] == DBNull.Value ? null : drd["monctoinicial"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEArticulo> SP_ITBCP_LISTAR_ARTICULO(TS_BEArticulo input)
        {
            List<TS_BEArticulo> lista = new List<TS_BEArticulo>();
            TS_BEArticulo output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_ARTICULO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdgrupo02", SqlDbType.Char, 5).Value = input.cdgrupo02;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEArticulo();
                            output.glosa = drd.HasColumn("glosa") ? drd["glosa"] == DBNull.Value ? null : drd["glosa"].ToString() : null;
                            output.fecinicial = drd.HasColumn("fecinicial") ? drd["fecinicial"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinicial"]) : (DateTime?)null;
                            output.fecinventario = drd.HasColumn("fecinventario") ? drd["fecinventario"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinventario"]) : (DateTime?)null;
                            output.fecedicion = drd.HasColumn("fecedicion") ? drd["fecedicion"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecedicion"]) : (DateTime?)null;
                            output.bloqvta = drd.HasColumn("bloqvta") ? drd["bloqvta"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqvta"]) : false;
                            output.bloqcom = drd.HasColumn("bloqcom") ? drd["bloqcom"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqcom"]) : false;
                            output.flgglosa = drd.HasColumn("flgglosa") ? drd["flgglosa"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgglosa"]) : false;
                            output.moverstock = drd.HasColumn("moverstock") ? drd["moverstock"] == DBNull.Value ? false : Convert.ToBoolean(drd["moverstock"]) : false;
                            output.venta = drd.HasColumn("venta") ? drd["venta"] == DBNull.Value ? false : Convert.ToBoolean(drd["venta"]) : false;
                            output.consignacion = drd.HasColumn("consignacion") ? drd["consignacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["consignacion"]) : false;
                            output.trfgratuita = drd.HasColumn("trfgratuita") ? drd["trfgratuita"] == DBNull.Value ? false : Convert.ToBoolean(drd["trfgratuita"]) : false;
                            output.is_easytaxi = drd.HasColumn("is_easytaxi") ? drd["is_easytaxi"] == DBNull.Value ? false : Convert.ToBoolean(drd["is_easytaxi"]) : false;
                            output.bloqgral = drd.HasColumn("bloqgral") ? drd["bloqgral"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqgral"]) : false;
                            output.movimiento = drd.HasColumn("movimiento") ? drd["movimiento"] == DBNull.Value ? false : Convert.ToBoolean(drd["movimiento"]) : false;
                            output.vtaxmonto = drd.HasColumn("vtaxmonto") ? drd["vtaxmonto"] == DBNull.Value ? false : Convert.ToBoolean(drd["vtaxmonto"]) : false;
                            output.flgpromocion = drd.HasColumn("flgpromocion") ? drd["flgpromocion"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpromocion"]) : false;
                            output.usadecimales = drd.HasColumn("usadecimales") ? drd["usadecimales"] == DBNull.Value ? false : Convert.ToBoolean(drd["usadecimales"]) : false;
                            output._virtual = drd.HasColumn("virtual") ? drd["virtual"] == DBNull.Value ? false : Convert.ToBoolean(drd["virtual"]) : false;
                            output.ctoreposicion = drd.HasColumn("ctoreposicion") ? drd["ctoreposicion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoreposicion"]) : (decimal?)null;
                            output.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["impuesto"]) : 0;
                            output.impuesto1 = drd.HasColumn("impuesto1") ? drd["impuesto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["impuesto1"]) : (decimal?)null;
                            output.ctoinicial = drd.HasColumn("ctoinicial") ? drd["ctoinicial"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoinicial"]) : (decimal?)null;
                            output.ctoinventario = drd.HasColumn("ctoinventario") ? drd["ctoinventario"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoinventario"]) : (decimal?)null;
                            output.ctopromedio = drd.HasColumn("ctopromedio") ? drd["ctopromedio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctopromedio"]) : (decimal?)null;
                            output.mgutilidad = drd.HasColumn("mgutilidad") ? drd["mgutilidad"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mgutilidad"]) : (decimal?)null;
                            output.montofidelizacion = drd.HasColumn("montofidelizacion") ? drd["montofidelizacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["montofidelizacion"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["porcdetraccion"]) : 0;
                            output.equivalencia = drd.HasColumn("equivalencia") ? drd["equivalencia"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["equivalencia"]) : (decimal?)null;
                            output.valorconversion = drd.HasColumn("valorconversion") ? drd["valorconversion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["valorconversion"]) : 0;
                            output.precioafiliacion = drd.HasColumn("precioafiliacion") ? drd["precioafiliacion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["precioafiliacion"]) : 0;
                            output.porcpercepcion = drd.HasColumn("porcpercepcion") ? drd["porcpercepcion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["porcpercepcion"]) : 0;
                            output.puntosfidelizacion = drd.HasColumn("puntosfidelizacion") ? drd["puntosfidelizacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["puntosfidelizacion"]) : (decimal?)null;
                            output.cantfidelizacion = drd.HasColumn("cantfidelizacion") ? drd["cantfidelizacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantfidelizacion"]) : (decimal?)null;
                            output.c_cuenta = drd.HasColumn("c_cuenta") ? drd["c_cuenta"] == DBNull.Value ? null : drd["c_cuenta"].ToString() : null;
                            output.c_cuenta_ventas = drd.HasColumn("c_cuenta_ventas") ? drd["c_cuenta_ventas"] == DBNull.Value ? null : drd["c_cuenta_ventas"].ToString() : null;
                            output.c_centrocosto = drd.HasColumn("c_centrocosto") ? drd["c_centrocosto"] == DBNull.Value ? null : drd["c_centrocosto"].ToString() : null;
                            output.c_cuenta_compras = drd.HasColumn("c_cuenta_compras") ? drd["c_cuenta_compras"] == DBNull.Value ? null : drd["c_cuenta_compras"].ToString() : null;
                            output.cdarticulovulcano = drd.HasColumn("cdarticulovulcano") ? drd["cdarticulovulcano"] == DBNull.Value ? null : drd["cdarticulovulcano"].ToString() : null;
                            output.cdarticulosunat = drd.HasColumn("cdarticulosunat") ? drd["cdarticulosunat"] == DBNull.Value ? null : drd["cdarticulosunat"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.dsarticulo = drd.HasColumn("dsarticulo") ? drd["dsarticulo"] == DBNull.Value ? null : drd["dsarticulo"].ToString() : null;
                            output.dsarticulo1 = drd.HasColumn("dsarticulo1") ? drd["dsarticulo1"] == DBNull.Value ? null : drd["dsarticulo1"].ToString() : null;
                            output.cdgrupo01 = drd.HasColumn("cdgrupo01") ? drd["cdgrupo01"] == DBNull.Value ? null : drd["cdgrupo01"].ToString() : null;
                            output.cdgrupo02 = drd.HasColumn("cdgrupo02") ? drd["cdgrupo02"] == DBNull.Value ? null : drd["cdgrupo02"].ToString() : null;
                            output.cdgrupo03 = drd.HasColumn("cdgrupo03") ? drd["cdgrupo03"] == DBNull.Value ? null : drd["cdgrupo03"].ToString() : null;
                            output.ctacompra = drd.HasColumn("ctacompra") ? drd["ctacompra"] == DBNull.Value ? null : drd["ctacompra"].ToString() : null;
                            output.ctaventa = drd.HasColumn("ctaventa") ? drd["ctaventa"] == DBNull.Value ? null : drd["ctaventa"].ToString() : null;
                            output.ctacosto = drd.HasColumn("ctacosto") ? drd["ctacosto"] == DBNull.Value ? null : drd["ctacosto"].ToString() : null;
                            output.ctaalmacen = drd.HasColumn("ctaalmacen") ? drd["ctaalmacen"] == DBNull.Value ? null : drd["ctaalmacen"].ToString() : null;
                            output.ticketfactura = drd.HasColumn("ticketfactura") ? drd["ticketfactura"] == DBNull.Value ? null : drd["ticketfactura"].ToString() : null;
                            output.monctoinventario = drd.HasColumn("monctoinventario") ? drd["monctoinventario"] == DBNull.Value ? null : drd["monctoinventario"].ToString() : null;
                            output.monctoprom = drd.HasColumn("monctoprom") ? drd["monctoprom"] == DBNull.Value ? null : drd["monctoprom"].ToString() : null;
                            output.monctorepo = drd.HasColumn("monctorepo") ? drd["monctorepo"] == DBNull.Value ? null : drd["monctorepo"].ToString() : null;
                            output.cdmedequiv = drd.HasColumn("cdmedequiv") ? drd["cdmedequiv"] == DBNull.Value ? null : drd["cdmedequiv"].ToString() : null;
                            output.cdamarre = drd.HasColumn("cdamarre") ? drd["cdamarre"] == DBNull.Value ? null : drd["cdamarre"].ToString() : null;
                            output.tpconversion = drd.HasColumn("tpconversion") ? drd["tpconversion"] == DBNull.Value ? null : drd["tpconversion"].ToString() : null;
                            output.cdgrupo04 = drd.HasColumn("cdgrupo04") ? drd["cdgrupo04"] == DBNull.Value ? null : drd["cdgrupo04"].ToString() : null;
                            output.cdgrupo05 = drd.HasColumn("cdgrupo05") ? drd["cdgrupo05"] == DBNull.Value ? null : drd["cdgrupo05"].ToString() : null;
                            output.cdunimed = drd.HasColumn("cdunimed") ? drd["cdunimed"] == DBNull.Value ? null : drd["cdunimed"].ToString() : null;
                            output.cdtalla = drd.HasColumn("cdtalla") ? drd["cdtalla"] == DBNull.Value ? null : drd["cdtalla"].ToString() : null;
                            output.tpformula = drd.HasColumn("tpformula") ? drd["tpformula"] == DBNull.Value ? null : drd["tpformula"].ToString() : null;
                            output.monctoinicial = drd.HasColumn("monctoinicial") ? drd["monctoinicial"] == DBNull.Value ? null : drd["monctoinicial"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BETipopago> SP_ITBCP_IMPRIMIR_IMPRESORA(TS_BETipopago input)
        {
            List<TS_BETipopago> lista = new List<TS_BETipopago>();
            TS_BETipopago output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_IMPRIMIR_IMPRESORA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdtppago", SqlDbType.Char, 5).Value = input.cdtppago;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BETipopago();
                            output.flgpago = drd.HasColumn("flgpago") ? drd["flgpago"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpago"]) : false;
                            output.flgsistema = drd.HasColumn("flgsistema") ? drd["flgsistema"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsistema"]) : false;
                            output.cdtppago = drd.HasColumn("cdtppago") ? drd["cdtppago"] == DBNull.Value ? null : drd["cdtppago"].ToString() : null;
                            output.dstppago = drd.HasColumn("dstppago") ? drd["dstppago"] == DBNull.Value ? null : drd["dstppago"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BECliente> SP_ITBCP_IMPRIMIR_CLIENTE(TS_BECliente input)
        {
            List<TS_BECliente> lista = new List<TS_BECliente>();
            TS_BECliente output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_IMPRIMIR_CLIENTE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 20).Value = input.cdcliente;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BECliente();
                            output.sunat_actualiza = drd.HasColumn("sunat_actualiza") ? drd["sunat_actualiza"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["sunat_actualiza"]) : (byte?)null;
                            output.diascredito = drd.HasColumn("diascredito") ? drd["diascredito"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["diascredito"]) : (int?)null;
                            output.diasmax_nd = drd.HasColumn("diasmax_nd") ? drd["diasmax_nd"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["diasmax_nd"]) : (int?)null;
                            output.fecnacimiento = drd.HasColumn("fecnacimiento") ? drd["fecnacimiento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecnacimiento"]) : (DateTime?)null;
                            output.fecha_creacion = drd.HasColumn("fecha_creacion") ? drd["fecha_creacion"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecha_creacion"]) : (DateTime?)null;
                            output.bloqcredito = drd.HasColumn("bloqcredito") ? drd["bloqcredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqcredito"]) : false;
                            output.flgpreciond = drd.HasColumn("flgpreciond") ? drd["flgpreciond"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpreciond"]) : false;
                            output.consulta_sunat = drd.HasColumn("consulta_sunat") ? drd["consulta_sunat"] == DBNull.Value ? false : Convert.ToBoolean(drd["consulta_sunat"]) : false;
                            output.flg_pideclave = drd.HasColumn("flg_pideclave") ? drd["flg_pideclave"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pideclave"]) : false;
                            output.flgtotalnd = drd.HasColumn("flgtotalnd") ? drd["flgtotalnd"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgtotalnd"]) : false;
                            output.mtolimite = drd.HasColumn("mtolimite") ? drd["mtolimite"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtolimite"]) : (decimal?)null;
                            output.mtodisponible = drd.HasColumn("mtodisponible") ? drd["mtodisponible"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodisponible"]) : (decimal?)null;
                            output.cliente = drd.HasColumn("cliente") ? drd["cliente"] == DBNull.Value ? null : drd["cliente"].ToString() : null;
                            output.contacto = drd.HasColumn("contacto") ? drd["contacto"] == DBNull.Value ? null : drd["contacto"].ToString() : null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;
                            output.rscliente = drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? null : drd["rscliente"].ToString() : null;
                            output.drcliente = drd.HasColumn("drcliente") ? drd["drcliente"] == DBNull.Value ? null : drd["drcliente"].ToString() : null;
                            output.cddistrito = drd.HasColumn("cddistrito") ? drd["cddistrito"] == DBNull.Value ? null : drd["cddistrito"].ToString() : null;
                            output.cddepartamento = drd.HasColumn("cddepartamento") ? drd["cddepartamento"] == DBNull.Value ? null : drd["cddepartamento"].ToString() : null;
                            output.monlimite = drd.HasColumn("monlimite") ? drd["monlimite"] == DBNull.Value ? null : drd["monlimite"].ToString() : null;
                            output.emcliente = drd.HasColumn("emcliente") ? drd["emcliente"] == DBNull.Value ? null : drd["emcliente"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.tipocli = drd.HasColumn("tipocli") ? drd["tipocli"] == DBNull.Value ? null : drd["tipocli"].ToString() : null;
                            output.cdgrupocli = drd.HasColumn("cdgrupocli") ? drd["cdgrupocli"] == DBNull.Value ? null : drd["cdgrupocli"].ToString() : null;
                            output.gruporuta = drd.HasColumn("gruporuta") ? drd["gruporuta"] == DBNull.Value ? null : drd["gruporuta"].ToString() : null;
                            output.cdzona = drd.HasColumn("cdzona") ? drd["cdzona"] == DBNull.Value ? null : drd["cdzona"].ToString() : null;
                            output.drcobranza = drd.HasColumn("drcobranza") ? drd["drcobranza"] == DBNull.Value ? null : drd["drcobranza"].ToString() : null;
                            output.drentrega = drd.HasColumn("drentrega") ? drd["drentrega"] == DBNull.Value ? null : drd["drentrega"].ToString() : null;
                            output.tlfcliente = drd.HasColumn("tlfcliente") ? drd["tlfcliente"] == DBNull.Value ? null : drd["tlfcliente"].ToString() : null;
                            output.tlfcliente1 = drd.HasColumn("tlfcliente1") ? drd["tlfcliente1"] == DBNull.Value ? null : drd["tlfcliente1"].ToString() : null;
                            output.faxcliente = drd.HasColumn("faxcliente") ? drd["faxcliente"] == DBNull.Value ? null : drd["faxcliente"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVenta> SP_ITBCP_IMPRIMIR(TS_BEVenta input)
        {
            List<TS_BEVenta> lista = new List<TS_BEVenta>();
            TS_BEVenta output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_IMPRIMIR", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEVenta();
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.fecanula = drd.HasColumn("fecanula") ? drd["fecanula"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanula"]) : (DateTime?)null;
                            output.fecanulasis = drd.HasColumn("fecanulasis") ? drd["fecanulasis"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecanulasis"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.fecsistema = drd.HasColumn("fecsistema") ? drd["fecsistema"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecsistema"]) : (DateTime?)null;
                            output.flgmanual = drd.HasColumn("flgmanual") ? drd["flgmanual"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmanual"]) : false;
                            output.flgcierrez = drd.HasColumn("flgcierrez") ? drd["flgcierrez"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrez"]) : false;
                            output.flgmovimiento = drd.HasColumn("flgmovimiento") ? drd["flgmovimiento"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmovimiento"]) : false;
                            output.archturno = drd.HasColumn("archturno") ? drd["archturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["archturno"]) : false;
                            output.chkespecial = drd.HasColumn("chkespecial") ? drd["chkespecial"] == DBNull.Value ? false : Convert.ToBoolean(drd["chkespecial"]) : false;
                            output.rucinvalido = drd.HasColumn("rucinvalido") ? drd["rucinvalido"] == DBNull.Value ? false : Convert.ToBoolean(drd["rucinvalido"]) : false;
                            output.usadecimales = drd.HasColumn("usadecimales") ? drd["usadecimales"] == DBNull.Value ? false : Convert.ToBoolean(drd["usadecimales"]) : false;
                            output.fact_elect = drd.HasColumn("fact_elect") ? drd["fact_elect"] == DBNull.Value ? false : Convert.ToBoolean(drd["fact_elect"]) : false;
                            output.mtovueltosol = drd.HasColumn("mtovueltosol") ? drd["mtovueltosol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltosol"]) : (decimal?)null;
                            output.mtovueltodol = drd.HasColumn("mtovueltodol") ? drd["mtovueltodol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtovueltodol"]) : (decimal?)null;
                            output.porservicio = drd.HasColumn("porservicio") ? drd["porservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porservicio"]) : (decimal?)null;
                            output.pordscto1 = drd.HasColumn("pordscto1") ? drd["pordscto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto1"]) : (decimal?)null;
                            output.pordscto2 = drd.HasColumn("pordscto2") ? drd["pordscto2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto2"]) : (decimal?)null;
                            output.pordscto3 = drd.HasColumn("pordscto3") ? drd["pordscto3"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordscto3"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcdetraccion"]) : (decimal?)null;
                            output.mtodetraccion = drd.HasColumn("mtodetraccion") ? drd["mtodetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodetraccion"]) : (decimal?)null;
                            output.precio_orig = drd.HasColumn("precio_orig") ? drd["precio_orig"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio_orig"]) : (decimal?)null;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valoracumula"]) : (decimal?)null;
                            output.cantcupon = drd.HasColumn("cantcupon") ? drd["cantcupon"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantcupon"]) : (decimal?)null;
                            output.mtocanje = drd.HasColumn("mtocanje") ? drd["mtocanje"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtocanje"]) : (decimal?)null;
                            output.mtopercepcion = drd.HasColumn("mtopercepcion") ? drd["mtopercepcion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtopercepcion"]) : (decimal?)null;
                            output.redondea_indecopi = drd.HasColumn("redondea_indecopi") ? drd["redondea_indecopi"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["redondea_indecopi"]) : (decimal?)null;
                            output.mtoimpuesto = drd.HasColumn("mtoimpuesto") ? drd["mtoimpuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoimpuesto"]) : (decimal?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtototal"]) : (decimal?)null;
                            output.tcambio = drd.HasColumn("tcambio") ? drd["tcambio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["tcambio"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.mtorecaudo = drd.HasColumn("mtorecaudo") ? drd["mtorecaudo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtorecaudo"]) : (decimal?)null;
                            output.ptosganados = drd.HasColumn("ptosganados") ? drd["ptosganados"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ptosganados"]) : (decimal?)null;
                            output.pordsctoeq = drd.HasColumn("pordsctoeq") ? drd["pordsctoeq"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["pordsctoeq"]) : (decimal?)null;
                            output.mtonoafecto = drd.HasColumn("mtonoafecto") ? drd["mtonoafecto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtonoafecto"]) : (decimal?)null;
                            output.valorvta = drd.HasColumn("valorvta") ? drd["valorvta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorvta"]) : (decimal?)null;
                            output.mtodscto = drd.HasColumn("mtodscto") ? drd["mtodscto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodscto"]) : (decimal?)null;
                            output.mtosubtotal = drd.HasColumn("mtosubtotal") ? drd["mtosubtotal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtosubtotal"]) : (decimal?)null;
                            output.mtoservicio = drd.HasColumn("mtoservicio") ? drd["mtoservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtoservicio"]) : (decimal?)null;
                            output.nroplaca = drd.HasColumn("nroplaca") ? drd["nroplaca"] == DBNull.Value ? null : drd["nroplaca"].ToString() : null;
                            output.observacion = drd.HasColumn("observacion") ? drd["observacion"] == DBNull.Value ? null : drd["observacion"].ToString() : null;
                            output.referencia = drd.HasColumn("referencia") ? drd["referencia"] == DBNull.Value ? null : drd["referencia"].ToString() : null;
                            output.c_centralizacion = drd.HasColumn("c_centralizacion") ? drd["c_centralizacion"] == DBNull.Value ? null : drd["c_centralizacion"].ToString() : null;
                            output.codes = drd.HasColumn("codes") ? drd["codes"] == DBNull.Value ? null : drd["codes"].ToString() : null;
                            output.codeid = drd.HasColumn("codeid") ? drd["codeid"] == DBNull.Value ? null : drd["codeid"].ToString() : null;
                            output.mensaje1 = drd.HasColumn("mensaje1") ? drd["mensaje1"] == DBNull.Value ? null : drd["mensaje1"].ToString() : null;
                            output.mensaje2 = drd.HasColumn("mensaje2") ? drd["mensaje2"] == DBNull.Value ? null : drd["mensaje2"].ToString() : null;
                            output.pdf417 = drd.HasColumn("pdf417") ? drd["pdf417"] == DBNull.Value ? null : drd["pdf417"].ToString() : null;
                            output.cdhash = drd.HasColumn("cdhash") ? drd["cdhash"] == DBNull.Value ? null : drd["cdhash"].ToString() : null;
                            output.scop = drd.HasColumn("scop") ? drd["scop"] == DBNull.Value ? null : drd["scop"].ToString() : null;
                            output.nroguia = drd.HasColumn("nroguia") ? drd["nroguia"] == DBNull.Value ? null : drd["nroguia"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.nrocelular = drd.HasColumn("nrocelular") ? drd["nrocelular"] == DBNull.Value ? null : drd["nrocelular"].ToString() : null;
                            output.tipoacumula = drd.HasColumn("tipoacumula") ? drd["tipoacumula"] == DBNull.Value ? null : drd["tipoacumula"].ToString() : null;
                            output.cdruta = drd.HasColumn("cdruta") ? drd["cdruta"] == DBNull.Value ? null : drd["cdruta"].ToString() : null;
                            output.ctadetraccion = drd.HasColumn("ctadetraccion") ? drd["ctadetraccion"] == DBNull.Value ? null : drd["ctadetraccion"].ToString() : null;
                            output.cdmedio_pago = drd.HasColumn("cdmedio_pago") ? drd["cdmedio_pago"] == DBNull.Value ? null : drd["cdmedio_pago"].ToString() : null;
                            output.odometro = drd.HasColumn("odometro") ? drd["odometro"] == DBNull.Value ? null : drd["odometro"].ToString() : null;
                            output.marcavehic = drd.HasColumn("marcavehic") ? drd["marcavehic"] == DBNull.Value ? null : drd["marcavehic"].ToString() : null;
                            output.inscripcion = drd.HasColumn("inscripcion") ? drd["inscripcion"] == DBNull.Value ? null : drd["inscripcion"].ToString() : null;
                            output.chofer = drd.HasColumn("chofer") ? drd["chofer"] == DBNull.Value ? null : drd["chofer"].ToString() : null;
                            output.nrolicencia = drd.HasColumn("nrolicencia") ? drd["nrolicencia"] == DBNull.Value ? null : drd["nrolicencia"].ToString() : null;
                            output.tipoventa = drd.HasColumn("tipoventa") ? drd["tipoventa"] == DBNull.Value ? null : drd["tipoventa"].ToString() : null;
                            output.tipofactura = drd.HasColumn("tipofactura") ? drd["tipofactura"] == DBNull.Value ? null : drd["tipofactura"].ToString() : null;
                            output.nroocompra = drd.HasColumn("nroocompra") ? drd["nroocompra"] == DBNull.Value ? null : drd["nroocompra"].ToString() : null;
                            output.nroserie1 = drd.HasColumn("nroserie1") ? drd["nroserie1"] == DBNull.Value ? null : drd["nroserie1"].ToString() : null;
                            output.nroserie2 = drd.HasColumn("nroserie2") ? drd["nroserie2"] == DBNull.Value ? null : drd["nroserie2"].ToString() : null;
                            output.nrobonus = drd.HasColumn("nrobonus") ? drd["nrobonus"] == DBNull.Value ? null : drd["nrobonus"].ToString() : null;
                            output.nrotarjeta = drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? null : drd["nrotarjeta"].ToString() : null;
                            output.cdtranspor = drd.HasColumn("cdtranspor") ? drd["cdtranspor"] == DBNull.Value ? null : drd["cdtranspor"].ToString() : null;
                            output.drpartida = drd.HasColumn("drpartida") ? drd["drpartida"] == DBNull.Value ? null : drd["drpartida"].ToString() : null;
                            output.drdestino = drd.HasColumn("drdestino") ? drd["drdestino"] == DBNull.Value ? null : drd["drdestino"].ToString() : null;
                            output.cdusuario = drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString() : null;
                            output.cdvendedor = drd.HasColumn("cdvendedor") ? drd["cdvendedor"] == DBNull.Value ? null : drd["cdvendedor"].ToString() : null;
                            output.cdusuanula = drd.HasColumn("cdusuanula") ? drd["cdusuanula"] == DBNull.Value ? null : drd["cdusuanula"].ToString() : null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;
                            output.rscliente = drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? null : drd["rscliente"].ToString() : null;
                            output.nroproforma = drd.HasColumn("nroproforma") ? drd["nroproforma"] == DBNull.Value ? null : drd["nroproforma"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.cdmoneda = drd.HasColumn("cdmoneda") ? drd["cdmoneda"] == DBNull.Value ? null : drd["cdmoneda"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BETmpmovfactura> SP_ITBCP_ELIMINAR_MOV_FACTURA(TS_BETmpmovfactura input)
        {
            List<TS_BETmpmovfactura> lista = new List<TS_BETmpmovfactura>();
           
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ELIMINAR_MOV_FACTURA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@localid", SqlDbType.Char, 4).Value = input.localid;
                    cmd.Parameters.Add("@cdproducto", SqlDbType.Char, 20).Value = input.cdproducto;

                    cmd.ExecuteNonQuery();
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
            return lista;
        }

        public List<TS_BETerminal> SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD(TS_BETerminal input)
        {
            List<TS_BETerminal> lista = new List<TS_BETerminal>();
            TS_BETerminal output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@seriehd", SqlDbType.Char, 10).Value = input.seriehd;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BETerminal();
                            output.conexion_dispensador = drd.HasColumn("conexion_dispensador") ? drd["conexion_dispensador"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["conexion_dispensador"]) : (byte?)null;
                            output.fe_idpos = drd.HasColumn("fe_idpos") ? drd["fe_idpos"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["fe_idpos"]) : (int?)null;
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.tktfactura = drd.HasColumn("tktfactura") ? drd["tktfactura"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktfactura"]) : false;
                            output.tktboleta = drd.HasColumn("tktboleta") ? drd["tktboleta"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktboleta"]) : false;
                            output.tktpromocion = drd.HasColumn("tktpromocion") ? drd["tktpromocion"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktpromocion"]) : false;
                            output.facturapreimpre = drd.HasColumn("facturapreimpre") ? drd["facturapreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["facturapreimpre"]) : false;
                            output.boletapreimpre = drd.HasColumn("boletapreimpre") ? drd["boletapreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["boletapreimpre"]) : false;
                            output.promocionpreimpre = drd.HasColumn("promocionpreimpre") ? drd["promocionpreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["promocionpreimpre"]) : false;
                            output.activa_boton_playa = drd.HasColumn("activa_boton_playa") ? drd["activa_boton_playa"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_boton_playa"]) : false;
                            output.flg_pdf417 = drd.HasColumn("flg_pdf417") ? drd["flg_pdf417"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pdf417"]) : false;
                            output.flg_nc_correlativo = drd.HasColumn("flg_nc_correlativo") ? drd["flg_nc_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nc_correlativo"]) : false;
                            output.flg_nd_correlativo = drd.HasColumn("flg_nd_correlativo") ? drd["flg_nd_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nd_correlativo"]) : false;
                            output.flg_print_qr = drd.HasColumn("flg_print_qr") ? drd["flg_print_qr"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_print_qr"]) : false;
                            output.flg_formato_a4 = drd.HasColumn("flg_formato_a4") ? drd["flg_formato_a4"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_formato_a4"]) : false;
                            output.rucinvalido = drd.HasColumn("rucinvalido") ? drd["rucinvalido"] == DBNull.Value ? false : Convert.ToBoolean(drd["rucinvalido"]) : false;
                            output._virtual = drd.HasColumn("virtual") ? drd["virtual"] == DBNull.Value ? false : Convert.ToBoolean(drd["virtual"]) : false;
                            output.tktnotadespacho = drd.HasColumn("tktnotadespacho") ? drd["tktnotadespacho"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktnotadespacho"]) : false;
                            output.flgtransferencia = drd.HasColumn("flgtransferencia") ? drd["flgtransferencia"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgtransferencia"]) : false;
                            output.playa_formasdepago = drd.HasColumn("playa_formasdepago") ? drd["playa_formasdepago"] == DBNull.Value ? false : Convert.ToBoolean(drd["playa_formasdepago"]) : false;
                            output.modif_corr = drd.HasColumn("modif_corr") ? drd["modif_corr"] == DBNull.Value ? false : Convert.ToBoolean(drd["modif_corr"]) : false;
                            output.flgpagotarjeta = drd.HasColumn("flgpagotarjeta") ? drd["flgpagotarjeta"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagotarjeta"]) : false;
                            output.flgpagocheque = drd.HasColumn("flgpagocheque") ? drd["flgpagocheque"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagocheque"]) : false;
                            output.flgpagocredito = drd.HasColumn("flgpagocredito") ? drd["flgpagocredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagocredito"]) : false;
                            output.flgpagoncredito = drd.HasColumn("flgpagoncredito") ? drd["flgpagoncredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagoncredito"]) : false;
                            output.flgvalidaz = drd.HasColumn("flgvalidaz") ? drd["flgvalidaz"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgvalidaz"]) : false;
                            output.flgcierrezok = drd.HasColumn("flgcierrezok") ? drd["flgcierrezok"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrezok"]) : false;
                            output.flghotkey = drd.HasColumn("flghotkey") ? drd["flghotkey"] == DBNull.Value ? false : Convert.ToBoolean(drd["flghotkey"]) : false;
                            output.flgfacturacion = drd.HasColumn("flgfacturacion") ? drd["flgfacturacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgfacturacion"]) : false;
                            output.grabarcliente = drd.HasColumn("grabarcliente") ? drd["grabarcliente"] == DBNull.Value ? false : Convert.ToBoolean(drd["grabarcliente"]) : false;
                            output.flgautomatica = drd.HasColumn("flgautomatica") ? drd["flgautomatica"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgautomatica"]) : false;
                            output.flgaperturacaja = drd.HasColumn("flgaperturacaja") ? drd["flgaperturacaja"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgaperturacaja"]) : false;
                            output.flgpagoefectivo = drd.HasColumn("flgpagoefectivo") ? drd["flgpagoefectivo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagoefectivo"]) : false;
                            output.modocompra = drd.HasColumn("modocompra") ? drd["modocompra"] == DBNull.Value ? false : Convert.ToBoolean(drd["modocompra"]) : false;
                            output.modservicio = drd.HasColumn("modservicio") ? drd["modservicio"] == DBNull.Value ? false : Convert.ToBoolean(drd["modservicio"]) : false;
                            output.modobservacion = drd.HasColumn("modobservacion") ? drd["modobservacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["modobservacion"]) : false;
                            output.moddsctogral = drd.HasColumn("moddsctogral") ? drd["moddsctogral"] == DBNull.Value ? false : Convert.ToBoolean(drd["moddsctogral"]) : false;
                            output.moddsctoitem = drd.HasColumn("moddsctoitem") ? drd["moddsctoitem"] == DBNull.Value ? false : Convert.ToBoolean(drd["moddsctoitem"]) : false;
                            output.preciocero = drd.HasColumn("preciocero") ? drd["preciocero"] == DBNull.Value ? false : Convert.ToBoolean(drd["preciocero"]) : false;
                            output.modfecha = drd.HasColumn("modfecha") ? drd["modfecha"] == DBNull.Value ? false : Convert.ToBoolean(drd["modfecha"]) : false;
                            output.modmoneda = drd.HasColumn("modmoneda") ? drd["modmoneda"] == DBNull.Value ? false : Convert.ToBoolean(drd["modmoneda"]) : false;
                            output.modvendedor = drd.HasColumn("modvendedor") ? drd["modvendedor"] == DBNull.Value ? false : Convert.ToBoolean(drd["modvendedor"]) : false;
                            output.modalmacen = drd.HasColumn("modalmacen") ? drd["modalmacen"] == DBNull.Value ? false : Convert.ToBoolean(drd["modalmacen"]) : false;
                            output.modlistap = drd.HasColumn("modlistap") ? drd["modlistap"] == DBNull.Value ? false : Convert.ToBoolean(drd["modlistap"]) : false;
                            output.modprecio = drd.HasColumn("modprecio") ? drd["modprecio"] == DBNull.Value ? false : Convert.ToBoolean(drd["modprecio"]) : false;
                            output.nrozeta = drd.HasColumn("nrozeta") ? drd["nrozeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrozeta"]) : (decimal?)null;
                            output.mtozeta = drd.HasColumn("mtozeta") ? drd["mtozeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtozeta"]) : (decimal?)null;
                            output.ticketfeed = drd.HasColumn("ticketfeed") ? drd["ticketfeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticketfeed"]) : (decimal?)null;
                            output.ticketlineacorte = drd.HasColumn("ticketlineacorte") ? drd["ticketlineacorte"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticketlineacorte"]) : (decimal?)null;
                            output.ticket2columnas = drd.HasColumn("ticket2columnas") ? drd["ticket2columnas"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticket2columnas"]) : (decimal?)null;
                            output.nventafeed = drd.HasColumn("nventafeed") ? drd["nventafeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nventafeed"]) : (decimal?)null;
                            output.promocionfeed = drd.HasColumn("promocionfeed") ? drd["promocionfeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["promocionfeed"]) : (decimal?)null;
                            output.mtodsctomax = drd.HasColumn("mtodsctomax") ? drd["mtodsctomax"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodsctomax"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.tranvirtual = drd.HasColumn("tranvirtual") ? drd["tranvirtual"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["tranvirtual"]) : (decimal?)null;
                            output.nrodeposito = drd.HasColumn("nrodeposito") ? drd["nrodeposito"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrodeposito"]) : (decimal?)null;
                            output.facturaimpre = drd.HasColumn("facturaimpre") ? drd["facturaimpre"] == DBNull.Value ? null : drd["facturaimpre"].ToString() : null;
                            output.boletaimpre = drd.HasColumn("boletaimpre") ? drd["boletaimpre"] == DBNull.Value ? null : drd["boletaimpre"].ToString() : null;
                            output.gavetachr = drd.HasColumn("gavetachr") ? drd["gavetachr"] == DBNull.Value ? null : drd["gavetachr"].ToString() : null;
                            output.promocionimpre = drd.HasColumn("promocionimpre") ? drd["promocionimpre"] == DBNull.Value ? null : drd["promocionimpre"].ToString() : null;
                            output.ncreditoimpre = drd.HasColumn("ncreditoimpre") ? drd["ncreditoimpre"] == DBNull.Value ? null : drd["ncreditoimpre"].ToString() : null;
                            output.ndebitoimpre = drd.HasColumn("ndebitoimpre") ? drd["ndebitoimpre"] == DBNull.Value ? null : drd["ndebitoimpre"].ToString() : null;
                            output.guiaimpre = drd.HasColumn("guiaimpre") ? drd["guiaimpre"] == DBNull.Value ? null : drd["guiaimpre"].ToString() : null;
                            output.proformaimpre = drd.HasColumn("proformaimpre") ? drd["proformaimpre"] == DBNull.Value ? null : drd["proformaimpre"].ToString() : null;
                            output.letraimpre = drd.HasColumn("letraimpre") ? drd["letraimpre"] == DBNull.Value ? null : drd["letraimpre"].ToString() : null;
                            output.path_loteria = drd.HasColumn("path_loteria") ? drd["path_loteria"] == DBNull.Value ? null : drd["path_loteria"].ToString() : null;
                            output.fe_nompos = drd.HasColumn("fe_nompos") ? drd["fe_nompos"] == DBNull.Value ? null : drd["fe_nompos"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdusuario = drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString() : null;
                            output.seriehd = drd.HasColumn("seriehd") ? drd["seriehd"] == DBNull.Value ? null : drd["seriehd"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.nroserie1 = drd.HasColumn("nroserie1") ? drd["nroserie1"] == DBNull.Value ? null : drd["nroserie1"].ToString() : null;
                            output.nroserie2 = drd.HasColumn("nroserie2") ? drd["nroserie2"] == DBNull.Value ? null : drd["nroserie2"].ToString() : null;
                            output.tipoterminal = drd.HasColumn("tipoterminal") ? drd["tipoterminal"] == DBNull.Value ? null : drd["tipoterminal"].ToString() : null;
                            output.ticketfactura = drd.HasColumn("ticketfactura") ? drd["ticketfactura"] == DBNull.Value ? null : drd["ticketfactura"].ToString() : null;
                            output.ncreditoboleta = drd.HasColumn("ncreditoboleta") ? drd["ncreditoboleta"] == DBNull.Value ? null : drd["ncreditoboleta"].ToString() : null;
                            output.ndebitoboleta = drd.HasColumn("ndebitoboleta") ? drd["ndebitoboleta"] == DBNull.Value ? null : drd["ndebitoboleta"].ToString() : null;
                            output.guiafmt = drd.HasColumn("guiafmt") ? drd["guiafmt"] == DBNull.Value ? null : drd["guiafmt"].ToString() : null;
                            output.proforma = drd.HasColumn("proforma") ? drd["proforma"] == DBNull.Value ? null : drd["proforma"].ToString() : null;
                            output.proformafmt = drd.HasColumn("proformafmt") ? drd["proformafmt"] == DBNull.Value ? null : drd["proformafmt"].ToString() : null;
                            output.letra = drd.HasColumn("letra") ? drd["letra"] == DBNull.Value ? null : drd["letra"].ToString() : null;
                            output.letrafmt = drd.HasColumn("letrafmt") ? drd["letrafmt"] == DBNull.Value ? null : drd["letrafmt"].ToString() : null;
                            output.displayimpre = drd.HasColumn("displayimpre") ? drd["displayimpre"] == DBNull.Value ? null : drd["displayimpre"].ToString() : null;
                            output.promocionchrfin = drd.HasColumn("promocionchrfin") ? drd["promocionchrfin"] == DBNull.Value ? null : drd["promocionchrfin"].ToString() : null;
                            output.ncredito = drd.HasColumn("ncredito") ? drd["ncredito"] == DBNull.Value ? null : drd["ncredito"].ToString() : null;
                            output.ncreditofmt = drd.HasColumn("ncreditofmt") ? drd["ncreditofmt"] == DBNull.Value ? null : drd["ncreditofmt"].ToString() : null;
                            output.ndebito = drd.HasColumn("ndebito") ? drd["ndebito"] == DBNull.Value ? null : drd["ndebito"].ToString() : null;
                            output.ndebitofmt = drd.HasColumn("ndebitofmt") ? drd["ndebitofmt"] == DBNull.Value ? null : drd["ndebitofmt"].ToString() : null;
                            output.guia = drd.HasColumn("guia") ? drd["guia"] == DBNull.Value ? null : drd["guia"].ToString() : null;
                            output.nventaimpre = drd.HasColumn("nventaimpre") ? drd["nventaimpre"] == DBNull.Value ? null : drd["nventaimpre"].ToString() : null;
                            output.nventachrini = drd.HasColumn("nventachrini") ? drd["nventachrini"] == DBNull.Value ? null : drd["nventachrini"].ToString() : null;
                            output.nventachrfin = drd.HasColumn("nventachrfin") ? drd["nventachrfin"] == DBNull.Value ? null : drd["nventachrfin"].ToString() : null;
                            output.promocion = drd.HasColumn("promocion") ? drd["promocion"] == DBNull.Value ? null : drd["promocion"].ToString() : null;
                            output.promocionfmt = drd.HasColumn("promocionfmt") ? drd["promocionfmt"] == DBNull.Value ? null : drd["promocionfmt"].ToString() : null;
                            output.promocionchrini = drd.HasColumn("promocionchrini") ? drd["promocionchrini"] == DBNull.Value ? null : drd["promocionchrini"].ToString() : null;
                            output.gavetaimpre = drd.HasColumn("gavetaimpre") ? drd["gavetaimpre"] == DBNull.Value ? null : drd["gavetaimpre"].ToString() : null;
                            output.ticket = drd.HasColumn("ticket") ? drd["ticket"] == DBNull.Value ? null : drd["ticket"].ToString() : null;
                            output.ticketimpre = drd.HasColumn("ticketimpre") ? drd["ticketimpre"] == DBNull.Value ? null : drd["ticketimpre"].ToString() : null;
                            output.ticketchrini = drd.HasColumn("ticketchrini") ? drd["ticketchrini"] == DBNull.Value ? null : drd["ticketchrini"].ToString() : null;
                            output.ticketchrfin = drd.HasColumn("ticketchrfin") ? drd["ticketchrfin"] == DBNull.Value ? null : drd["ticketchrfin"].ToString() : null;
                            output.nventa = drd.HasColumn("nventa") ? drd["nventa"] == DBNull.Value ? null : drd["nventa"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.factura = drd.HasColumn("factura") ? drd["factura"] == DBNull.Value ? null : drd["factura"].ToString() : null;
                            output.facturafmt = drd.HasColumn("facturafmt") ? drd["facturafmt"] == DBNull.Value ? null : drd["facturafmt"].ToString() : null;
                            output.boleta = drd.HasColumn("boleta") ? drd["boleta"] == DBNull.Value ? null : drd["boleta"].ToString() : null;
                            output.boletafmt = drd.HasColumn("boletafmt") ? drd["boletafmt"] == DBNull.Value ? null : drd["boletafmt"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEParametro> SP_ITBCP_BLOQUEA_VENTANA_PLAYA(TS_BEParametro input)
        {
            List<TS_BEParametro> lista = new List<TS_BEParametro>();
            TS_BEParametro output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_BLOQUEA_VENTANA_PLAYA", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEParametro();
                            output.tipocierrextienda = drd.HasColumn("tipocierrextienda") ? drd["tipocierrextienda"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["tipocierrextienda"]) : (byte?)null;
                            output.cursor_tienda = drd.HasColumn("cursor_tienda") ? drd["cursor_tienda"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["cursor_tienda"]) : (byte?)null;
                            output.repite_articulo = drd.HasColumn("repite_articulo") ? drd["repite_articulo"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["repite_articulo"]) : (byte?)null;
                            output.imprime_canjeweb = drd.HasColumn("imprime_canjeweb") ? drd["imprime_canjeweb"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["imprime_canjeweb"]) : (byte?)null;
                            output.imprime_ptosacumulados = drd.HasColumn("imprime_ptosacumulados") ? drd["imprime_ptosacumulados"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["imprime_ptosacumulados"]) : (byte?)null;
                            output.tarjeta_actu_cdcliente = drd.HasColumn("tarjeta_actu_cdcliente") ? drd["tarjeta_actu_cdcliente"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["tarjeta_actu_cdcliente"]) : (byte?)null;
                            output.cierre_kardex = drd.HasColumn("cierre_kardex") ? drd["cierre_kardex"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["cierre_kardex"]) : (byte?)null;
                            output.noconectawpuntos = drd.HasColumn("noconectawpuntos") ? drd["noconectawpuntos"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["noconectawpuntos"]) : (byte?)null;
                            output.cierrex_formatos = drd.HasColumn("cierrex_formatos") ? drd["cierrex_formatos"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["cierrex_formatos"]) : (byte?)null;
                            output.imprime_fact_playa = drd.HasColumn("imprime_fact_playa") ? drd["imprime_fact_playa"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["imprime_fact_playa"]) : (byte?)null;
                            output.credplaca = drd.HasColumn("credplaca") ? drd["credplaca"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["credplaca"]) : (byte?)null;
                            output.cierre_especial = drd.HasColumn("cierre_especial") ? drd["cierre_especial"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["cierre_especial"]) : (byte?)null;
                            output.parte_tienda = drd.HasColumn("parte_tienda") ? drd["parte_tienda"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["parte_tienda"]) : (byte?)null;
                            output.flg_desc_prefijo = drd.HasColumn("flg_desc_prefijo") ? drd["flg_desc_prefijo"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["flg_desc_prefijo"]) : (byte?)null;
                            output.imprimir_cdarticulo_config = drd.HasColumn("imprimir_cdarticulo_config") ? drd["imprimir_cdarticulo_config"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["imprimir_cdarticulo_config"]) : (byte?)null;
                            output.mostrar_igv_pantalla = drd.HasColumn("mostrar_igv_pantalla") ? drd["mostrar_igv_pantalla"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["mostrar_igv_pantalla"]) : (byte?)null;
                            output.tipo_menu = drd.HasColumn("tipo_menu") ? drd["tipo_menu"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["tipo_menu"]) : (byte?)null;
                            output.nd_playa = drd.HasColumn("nd_playa") ? drd["nd_playa"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["nd_playa"]) : (byte?)null;
                            output.valida_cdarticulo = drd.HasColumn("valida_cdarticulo") ? drd["valida_cdarticulo"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["valida_cdarticulo"]) : (byte?)null;
                            output.conf_cierrex = drd.HasColumn("conf_cierrex") ? drd["conf_cierrex"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["conf_cierrex"]) : (byte?)null;
                            output.boton_transfer_gratuita = drd.HasColumn("boton_transfer_gratuita") ? drd["boton_transfer_gratuita"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["boton_transfer_gratuita"]) : (byte?)null;
                            output.tienda_cant_neg = drd.HasColumn("tienda_cant_neg") ? drd["tienda_cant_neg"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["tienda_cant_neg"]) : (byte?)null;
                            output.imprime_tiketera = drd.HasColumn("imprime_tiketera") ? drd["imprime_tiketera"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["imprime_tiketera"]) : (byte?)null;
                            output.imprime_nvta = drd.HasColumn("imprime_nvta") ? drd["imprime_nvta"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["imprime_nvta"]) : (byte?)null;
                            output.modifica_depositos_parte = drd.HasColumn("modifica_depositos_parte") ? drd["modifica_depositos_parte"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["modifica_depositos_parte"]) : (byte?)null;
                            output.mostrar_local_gastos = drd.HasColumn("mostrar_local_gastos") ? drd["mostrar_local_gastos"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["mostrar_local_gastos"]) : (byte?)null;
                            output.cantdigitos_tarjpromo = drd.HasColumn("cantdigitos_tarjpromo") ? drd["cantdigitos_tarjpromo"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["cantdigitos_tarjpromo"]) : (int?)null;
                            output.galones_decimales = drd.HasColumn("galones_decimales") ? drd["galones_decimales"] == DBNull.Value ? 0 : Convert.ToInt32(drd["galones_decimales"]) : 0;
                            output.tiendagazel = drd.HasColumn("tiendagazel") ? drd["tiendagazel"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["tiendagazel"]) : (int?)null;
                            output.terminalserver = drd.HasColumn("terminalserver") ? drd["terminalserver"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["terminalserver"]) : (int?)null;
                            output.rango_valfecpos = drd.HasColumn("rango_valfecpos") ? drd["rango_valfecpos"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["rango_valfecpos"]) : (int?)null;
                            output.nro_caracteres_rsocial = drd.HasColumn("nro_caracteres_rsocial") ? drd["nro_caracteres_rsocial"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["nro_caracteres_rsocial"]) : (int?)null;
                            output.valida_fecha_playa = drd.HasColumn("valida_fecha_playa") ? drd["valida_fecha_playa"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["valida_fecha_playa"]) : (int?)null;
                            output.impr_veces_nd = drd.HasColumn("impr_veces_nd") ? drd["impr_veces_nd"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["impr_veces_nd"]) : (int?)null;
                            output.impr_veces_fac = drd.HasColumn("impr_veces_fac") ? drd["impr_veces_fac"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["impr_veces_fac"]) : (int?)null;
                            output.impr_veces_bol = drd.HasColumn("impr_veces_bol") ? drd["impr_veces_bol"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["impr_veces_bol"]) : (int?)null;
                            output.fecinstall = drd.HasColumn("fecinstall") ? drd["fecinstall"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinstall"]) : (DateTime?)null;
                            output.flgtalla = drd.HasColumn("flgtalla") ? drd["flgtalla"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgtalla"]) : false;
                            output.flgformula = drd.HasColumn("flgformula") ? drd["flgformula"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgformula"]) : false;
                            output.precioconigv = drd.HasColumn("precioconigv") ? drd["precioconigv"] == DBNull.Value ? false : Convert.ToBoolean(drd["precioconigv"]) : false;
                            output.precioconservicio = drd.HasColumn("precioconservicio") ? drd["precioconservicio"] == DBNull.Value ? false : Convert.ToBoolean(drd["precioconservicio"]) : false;
                            output.utilidadcosto = drd.HasColumn("utilidadcosto") ? drd["utilidadcosto"] == DBNull.Value ? false : Convert.ToBoolean(drd["utilidadcosto"]) : false;
                            output.flgintegrador = drd.HasColumn("flgintegrador") ? drd["flgintegrador"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgintegrador"]) : false;
                            output.flg_imprimirnd_menos5s = drd.HasColumn("flg_imprimirnd_menos5s") ? drd["flg_imprimirnd_menos5s"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_imprimirnd_menos5s"]) : false;
                            output.flg_ocultarvta_menos5s = drd.HasColumn("flg_ocultarvta_menos5s") ? drd["flg_ocultarvta_menos5s"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_ocultarvta_menos5s"]) : false;
                            output.flg_noaplica_desc_tarj = drd.HasColumn("flg_noaplica_desc_tarj") ? drd["flg_noaplica_desc_tarj"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_noaplica_desc_tarj"]) : false;
                            output.flg_activar_clientes_varios = drd.HasColumn("flg_activar_clientes_varios") ? drd["flg_activar_clientes_varios"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_activar_clientes_varios"]) : false;
                            output.flg_print_qr = drd.HasColumn("flg_print_qr") ? drd["flg_print_qr"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_print_qr"]) : false;
                            output.flg_repx_terminal = drd.HasColumn("flg_repx_terminal") ? drd["flg_repx_terminal"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_repx_terminal"]) : false;
                            output.flg_cliente_automatico = drd.HasColumn("flg_cliente_automatico") ? drd["flg_cliente_automatico"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_cliente_automatico"]) : false;
                            output.desactivar_foxypreviewer = drd.HasColumn("desactivar_foxypreviewer") ? drd["desactivar_foxypreviewer"] == DBNull.Value ? false : Convert.ToBoolean(drd["desactivar_foxypreviewer"]) : false;
                            output.flg_notas_multiref = drd.HasColumn("flg_notas_multiref") ? drd["flg_notas_multiref"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_notas_multiref"]) : false;
                            output.flg_afectarcosto_fletecompras = drd.HasColumn("flg_afectarcosto_fletecompras") ? drd["flg_afectarcosto_fletecompras"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_afectarcosto_fletecompras"]) : false;
                            output.flg_btn_credito_playa = drd.HasColumn("flg_btn_credito_playa") ? drd["flg_btn_credito_playa"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_btn_credito_playa"]) : false;
                            output.flg_validateclas_cdcliente = drd.HasColumn("flg_validateclas_cdcliente") ? drd["flg_validateclas_cdcliente"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_validateclas_cdcliente"]) : false;
                            output.flg_activa_ti_todosprod = drd.HasColumn("flg_activa_ti_todosprod") ? drd["flg_activa_ti_todosprod"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_activa_ti_todosprod"]) : false;
                            output.flg_boton_promo = drd.HasColumn("flg_boton_promo") ? drd["flg_boton_promo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_boton_promo"]) : false;
                            output.flg_gastos_playa = drd.HasColumn("flg_gastos_playa") ? drd["flg_gastos_playa"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_gastos_playa"]) : false;
                            output.flg_ocultar_campos_tck = drd.HasColumn("flg_ocultar_campos_tck") ? drd["flg_ocultar_campos_tck"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_ocultar_campos_tck"]) : false;
                            output.flg_credito_centralizado = drd.HasColumn("flg_credito_centralizado") ? drd["flg_credito_centralizado"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_credito_centralizado"]) : false;
                            output.flgsoloterminal = drd.HasColumn("flgsoloterminal") ? drd["flgsoloterminal"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsoloterminal"]) : false;
                            output.flg_round_dec_indecopi = drd.HasColumn("flg_round_dec_indecopi") ? drd["flg_round_dec_indecopi"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_round_dec_indecopi"]) : false;
                            output.flg_round_indecopi_1_9 = drd.HasColumn("flg_round_indecopi_1_9") ? drd["flg_round_indecopi_1_9"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_round_indecopi_1_9"]) : false;
                            output.flg_kardex_unalinea = drd.HasColumn("flg_kardex_unalinea") ? drd["flg_kardex_unalinea"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_kardex_unalinea"]) : false;
                            output.flg_facturacion_automatica = drd.HasColumn("flg_facturacion_automatica") ? drd["flg_facturacion_automatica"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_facturacion_automatica"]) : false;
                            output.flg_modo_fact = drd.HasColumn("flg_modo_fact") ? drd["flg_modo_fact"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_modo_fact"]) : false;
                            output.label_bellavista = drd.HasColumn("label_bellavista") ? drd["label_bellavista"] == DBNull.Value ? false : Convert.ToBoolean(drd["label_bellavista"]) : false;
                            output.nd_imp_saldoyconsumo = drd.HasColumn("nd_imp_saldoyconsumo") ? drd["nd_imp_saldoyconsumo"] == DBNull.Value ? false : Convert.ToBoolean(drd["nd_imp_saldoyconsumo"]) : false;
                            output.flg_valida_fecproce_dia = drd.HasColumn("flg_valida_fecproce_dia") ? drd["flg_valida_fecproce_dia"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_valida_fecproce_dia"]) : false;
                            output.flg_canjend = drd.HasColumn("flg_canjend") ? drd["flg_canjend"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_canjend"]) : false;
                            output.flg_nrodias = drd.HasColumn("flg_nrodias") ? drd["flg_nrodias"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nrodias"]) : false;
                            output.flg_nc_liberand = drd.HasColumn("flg_nc_liberand") ? drd["flg_nc_liberand"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nc_liberand"]) : false;
                            output.flg_transfer_gratuita_cero = drd.HasColumn("flg_transfer_gratuita_cero") ? drd["flg_transfer_gratuita_cero"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_transfer_gratuita_cero"]) : false;
                            output.flg_fecsrv = drd.HasColumn("flg_fecsrv") ? drd["flg_fecsrv"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_fecsrv"]) : false;
                            output.flg_pideodometro = drd.HasColumn("flg_pideodometro") ? drd["flg_pideodometro"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pideodometro"]) : false;
                            output.flg_valdscto = drd.HasColumn("flg_valdscto") ? drd["flg_valdscto"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_valdscto"]) : false;
                            output.flg_pideclavecred = drd.HasColumn("flg_pideclavecred") ? drd["flg_pideclavecred"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pideclavecred"]) : false;
                            output.flg_anula_easytaxi = drd.HasColumn("flg_anula_easytaxi") ? drd["flg_anula_easytaxi"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_anula_easytaxi"]) : false;
                            output.conigv = drd.HasColumn("conigv") ? drd["conigv"] == DBNull.Value ? false : Convert.ToBoolean(drd["conigv"]) : false;
                            output.flg_pideplacatb = drd.HasColumn("flg_pideplacatb") ? drd["flg_pideplacatb"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pideplacatb"]) : false;
                            output.activa_repro_stock = drd.HasColumn("activa_repro_stock") ? drd["activa_repro_stock"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_repro_stock"]) : false;
                            output.flg_valfecpos = drd.HasColumn("flg_valfecpos") ? drd["flg_valfecpos"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_valfecpos"]) : false;
                            output.flg_anulapos = drd.HasColumn("flg_anulapos") ? drd["flg_anulapos"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_anulapos"]) : false;
                            output.activa_elsol = drd.HasColumn("activa_elsol") ? drd["activa_elsol"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_elsol"]) : false;
                            output.flg_boton_facturacionmanual = drd.HasColumn("flg_boton_facturacionmanual") ? drd["flg_boton_facturacionmanual"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_boton_facturacionmanual"]) : false;
                            output.mostrar_ptos_ganados = drd.HasColumn("mostrar_ptos_ganados") ? drd["mostrar_ptos_ganados"] == DBNull.Value ? false : Convert.ToBoolean(drd["mostrar_ptos_ganados"]) : false;
                            output.activa_formas_pago = drd.HasColumn("activa_formas_pago") ? drd["activa_formas_pago"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_formas_pago"]) : false;
                            output.flg_pideplaca = drd.HasColumn("flg_pideplaca") ? drd["flg_pideplaca"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pideplaca"]) : false;
                            output.depositos_playa = drd.HasColumn("depositos_playa") ? drd["depositos_playa"] == DBNull.Value ? false : Convert.ToBoolean(drd["depositos_playa"]) : false;
                            output.flg_botoncredito = drd.HasColumn("flg_botoncredito") ? drd["flg_botoncredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_botoncredito"]) : false;
                            output.flg_nobuscar_nombre = drd.HasColumn("flg_nobuscar_nombre") ? drd["flg_nobuscar_nombre"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nobuscar_nombre"]) : false;
                            output.consulta_sunat = drd.HasColumn("consulta_sunat") ? drd["consulta_sunat"] == DBNull.Value ? false : Convert.ToBoolean(drd["consulta_sunat"]) : false;
                            output.clubgazel = drd.HasColumn("clubgazel") ? drd["clubgazel"] == DBNull.Value ? false : Convert.ToBoolean(drd["clubgazel"]) : false;
                            output.activa_camedi = drd.HasColumn("activa_camedi") ? drd["activa_camedi"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_camedi"]) : false;
                            output.tarjeta_mascara = drd.HasColumn("tarjeta_mascara") ? drd["tarjeta_mascara"] == DBNull.Value ? false : Convert.ToBoolean(drd["tarjeta_mascara"]) : false;
                            output.flgruta = drd.HasColumn("flgruta") ? drd["flgruta"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgruta"]) : false;
                            output.flg_prefij_seriesdoc = drd.HasColumn("flg_prefij_seriesdoc") ? drd["flg_prefij_seriesdoc"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_prefij_seriesdoc"]) : false;
                            output.mostrar_articulo_kardex = drd.HasColumn("mostrar_articulo_kardex") ? drd["mostrar_articulo_kardex"] == DBNull.Value ? false : Convert.ToBoolean(drd["mostrar_articulo_kardex"]) : false;
                            output.flg_botontiendaenplaya = drd.HasColumn("flg_botontiendaenplaya") ? drd["flg_botontiendaenplaya"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_botontiendaenplaya"]) : false;
                            output.valida_correlativo = drd.HasColumn("valida_correlativo") ? drd["valida_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["valida_correlativo"]) : false;
                            output.flg_invent_fisicoteorico = drd.HasColumn("flg_invent_fisicoteorico") ? drd["flg_invent_fisicoteorico"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_invent_fisicoteorico"]) : false;
                            output.punto_nd = drd.HasColumn("punto_nd") ? drd["punto_nd"] == DBNull.Value ? false : Convert.ToBoolean(drd["punto_nd"]) : false;
                            output.cancelado = drd.HasColumn("cancelado") ? drd["cancelado"] == DBNull.Value ? false : Convert.ToBoolean(drd["cancelado"]) : false;
                            output.correlativos2_ticket = drd.HasColumn("correlativos2_ticket") ? drd["correlativos2_ticket"] == DBNull.Value ? false : Convert.ToBoolean(drd["correlativos2_ticket"]) : false;
                            output.chkclientedia = drd.HasColumn("chkclientedia") ? drd["chkclientedia"] == DBNull.Value ? false : Convert.ToBoolean(drd["chkclientedia"]) : false;
                            output.escirsa = drd.HasColumn("escirsa") ? drd["escirsa"] == DBNull.Value ? false : Convert.ToBoolean(drd["escirsa"]) : false;
                            output.flgcierraturnoxcaja = drd.HasColumn("flgcierraturnoxcaja") ? drd["flgcierraturnoxcaja"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierraturnoxcaja"]) : false;
                            output.activadispensador = drd.HasColumn("activadispensador") ? drd["activadispensador"] == DBNull.Value ? false : Convert.ToBoolean(drd["activadispensador"]) : false;
                            output.cambioturno = drd.HasColumn("cambioturno") ? drd["cambioturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["cambioturno"]) : false;
                            output.iniciodia = drd.HasColumn("iniciodia") ? drd["iniciodia"] == DBNull.Value ? false : Convert.ToBoolean(drd["iniciodia"]) : false;
                            output.pd_separaglp = drd.HasColumn("pd_separaglp") ? drd["pd_separaglp"] == DBNull.Value ? false : Convert.ToBoolean(drd["pd_separaglp"]) : false;
                            output.flgvalida_nrovale = drd.HasColumn("flgvalida_nrovale") ? drd["flgvalida_nrovale"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgvalida_nrovale"]) : false;
                            output.arequipa = drd.HasColumn("arequipa") ? drd["arequipa"] == DBNull.Value ? false : Convert.ToBoolean(drd["arequipa"]) : false;
                            output.pantalland_cliprintnd = drd.HasColumn("pantalland_cliprintnd") ? drd["pantalland_cliprintnd"] == DBNull.Value ? false : Convert.ToBoolean(drd["pantalland_cliprintnd"]) : false;
                            output.imprime_total_dispensado = drd.HasColumn("imprime_total_dispensado") ? drd["imprime_total_dispensado"] == DBNull.Value ? false : Convert.ToBoolean(drd["imprime_total_dispensado"]) : false;
                            output.imprime_clientes_credito = drd.HasColumn("imprime_clientes_credito") ? drd["imprime_clientes_credito"] == DBNull.Value ? false : Convert.ToBoolean(drd["imprime_clientes_credito"]) : false;
                            output.triveno = drd.HasColumn("triveno") ? drd["triveno"] == DBNull.Value ? false : Convert.ToBoolean(drd["triveno"]) : false;
                            output.activasawa = drd.HasColumn("activasawa") ? drd["activasawa"] == DBNull.Value ? false : Convert.ToBoolean(drd["activasawa"]) : false;
                            output.desanular = drd.HasColumn("desanular") ? drd["desanular"] == DBNull.Value ? false : Convert.ToBoolean(drd["desanular"]) : false;
                            output.flgsistema03 = drd.HasColumn("flgsistema03") ? drd["flgsistema03"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsistema03"]) : false;
                            output.flgcontometro = drd.HasColumn("flgcontometro") ? drd["flgcontometro"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcontometro"]) : false;
                            output.flgsolotienda = drd.HasColumn("flgsolotienda") ? drd["flgsolotienda"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsolotienda"]) : false;
                            output.flgmostrar_precio_orig = drd.HasColumn("flgmostrar_precio_orig") ? drd["flgmostrar_precio_orig"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmostrar_precio_orig"]) : false;
                            output.vertiposventa = drd.HasColumn("vertiposventa") ? drd["vertiposventa"] == DBNull.Value ? false : Convert.ToBoolean(drd["vertiposventa"]) : false;
                            output.redondeasolescombus = drd.HasColumn("redondeasolescombus") ? drd["redondeasolescombus"] == DBNull.Value ? false : Convert.ToBoolean(drd["redondeasolescombus"]) : false;
                            output.bloqventaplaya = drd.HasColumn("bloqventaplaya") ? drd["bloqventaplaya"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqventaplaya"]) : false;
                            output.saltoauto = drd.HasColumn("saltoauto") ? drd["saltoauto"] == DBNull.Value ? false : Convert.ToBoolean(drd["saltoauto"]) : false;
                            output.tarjcredplaca = drd.HasColumn("tarjcredplaca") ? drd["tarjcredplaca"] == DBNull.Value ? false : Convert.ToBoolean(drd["tarjcredplaca"]) : false;
                            output.flgprintndespacho = drd.HasColumn("flgprintndespacho") ? drd["flgprintndespacho"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgprintndespacho"]) : false;
                            output.flgsistema01 = drd.HasColumn("flgsistema01") ? drd["flgsistema01"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsistema01"]) : false;
                            output.flgsistema02 = drd.HasColumn("flgsistema02") ? drd["flgsistema02"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsistema02"]) : false;
                            output.stknegativo = drd.HasColumn("stknegativo") ? drd["stknegativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["stknegativo"]) : false;
                            output.conexiondispensador = drd.HasColumn("conexiondispensador") ? drd["conexiondispensador"] == DBNull.Value ? false : Convert.ToBoolean(drd["conexiondispensador"]) : false;
                            output.flggrifo = drd.HasColumn("flggrifo") ? drd["flggrifo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flggrifo"]) : false;
                            output.zenpantalla = drd.HasColumn("zenpantalla") ? drd["zenpantalla"] == DBNull.Value ? false : Convert.ToBoolean(drd["zenpantalla"]) : false;
                            output.flgcreaprodmov = drd.HasColumn("flgcreaprodmov") ? drd["flgcreaprodmov"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcreaprodmov"]) : false;
                            output.flgvalidaruc = drd.HasColumn("flgvalidaruc") ? drd["flgvalidaruc"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgvalidaruc"]) : false;
                            output.coloron = drd.HasColumn("coloron") ? drd["coloron"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["coloron"]) : (decimal?)null;
                            output.coloroff = drd.HasColumn("coloroff") ? drd["coloroff"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["coloroff"]) : (decimal?)null;
                            output.colorgrid = drd.HasColumn("colorgrid") ? drd["colorgrid"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["colorgrid"]) : (decimal?)null;
                            output.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["impuesto"]) : (decimal?)null;
                            output.porservicio = drd.HasColumn("porservicio") ? drd["porservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porservicio"]) : (decimal?)null;
                            output.nropago = drd.HasColumn("nropago") ? drd["nropago"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nropago"]) : (decimal?)null;
                            output.nroinventario = drd.HasColumn("nroinventario") ? drd["nroinventario"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nroinventario"]) : (decimal?)null;
                            output.mto_facturacion_automatica = drd.HasColumn("mto_facturacion_automatica") ? drd["mto_facturacion_automatica"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mto_facturacion_automatica"]) : (decimal?)null;
                            output.redondeo = drd.HasColumn("redondeo") ? drd["redondeo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["redondeo"]) : (decimal?)null;
                            output.mtominimodni_sunat = drd.HasColumn("mtominimodni_sunat") ? drd["mtominimodni_sunat"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtominimodni_sunat"]) : (decimal?)null;
                            output.mtominideposito = drd.HasColumn("mtominideposito") ? drd["mtominideposito"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtominideposito"]) : (decimal?)null;
                            output.valorigv = drd.HasColumn("valorigv") ? drd["valorigv"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorigv"]) : (decimal?)null;
                            output.colum_termica = drd.HasColumn("colum_termica") ? drd["colum_termica"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["colum_termica"]) : (decimal?)null;
                            output.mtominimodetraccion = drd.HasColumn("mtominimodetraccion") ? drd["mtominimodetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtominimodetraccion"]) : (decimal?)null;
                            output.mtominimodni = drd.HasColumn("mtominimodni") ? drd["mtominimodni"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtominimodni"]) : (decimal?)null;
                            output.mtominautomatico = drd.HasColumn("mtominautomatico") ? drd["mtominautomatico"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtominautomatico"]) : (decimal?)null;
                            output.mtocupon = drd.HasColumn("mtocupon") ? drd["mtocupon"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtocupon"]) : (decimal?)null;
                            output.modifica_precio_tienda = drd.HasColumn("modifica_precio_tienda") ? drd["modifica_precio_tienda"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["modifica_precio_tienda"]) : (decimal?)null;
                            output.precio_varios = drd.HasColumn("precio_varios") ? drd["precio_varios"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio_varios"]) : (decimal?)null;
                            output.diasresetptos = drd.HasColumn("diasresetptos") ? drd["diasresetptos"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["diasresetptos"]) : (decimal?)null;
                            output.cant_turno = drd.HasColumn("cant_turno") ? drd["cant_turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cant_turno"]) : (decimal?)null;
                            output.ptobonus = drd.HasColumn("ptobonus") ? drd["ptobonus"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ptobonus"]) : (decimal?)null;
                            output.intervaltimer = drd.HasColumn("intervaltimer") ? drd["intervaltimer"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["intervaltimer"]) : (decimal?)null;
                            output.minutosxtktbol = drd.HasColumn("minutosxtktbol") ? drd["minutosxtktbol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["minutosxtktbol"]) : (decimal?)null;
                            output.nrodeposito = drd.HasColumn("nrodeposito") ? drd["nrodeposito"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrodeposito"]) : (decimal?)null;
                            output.longtarjeta = drd.HasColumn("longtarjeta") ? drd["longtarjeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["longtarjeta"]) : (decimal?)null;
                            output.nrocdbarra = drd.HasColumn("nrocdbarra") ? drd["nrocdbarra"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrocdbarra"]) : (decimal?)null;
                            output.digitoruc = drd.HasColumn("digitoruc") ? drd["digitoruc"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["digitoruc"]) : (decimal?)null;
                            output.nrocara = drd.HasColumn("nrocara") ? drd["nrocara"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrocara"]) : (decimal?)null;
                            output.nrotransgasboy = drd.HasColumn("nrotransgasboy") ? drd["nrotransgasboy"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrotransgasboy"]) : (decimal?)null;
                            output.digitocdcliente = drd.HasColumn("digitocdcliente") ? drd["digitocdcliente"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["digitocdcliente"]) : (decimal?)null;
                            output.porcipm = drd.HasColumn("porcipm") ? drd["porcipm"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcipm"]) : (decimal?)null;
                            output.versionbo = drd.HasColumn("versionbo") ? drd["versionbo"] == DBNull.Value ? null : drd["versionbo"].ToString() : null;
                            output.versiontinven = drd.HasColumn("versiontinven") ? drd["versiontinven"] == DBNull.Value ? null : drd["versiontinven"].ToString() : null;
                            output.versionplaya = drd.HasColumn("versionplaya") ? drd["versionplaya"] == DBNull.Value ? null : drd["versionplaya"].ToString() : null;
                            output.versiontienda = drd.HasColumn("versiontienda") ? drd["versiontienda"] == DBNull.Value ? null : drd["versiontienda"].ToString() : null;
                            output.ruta_backup = drd.HasColumn("ruta_backup") ? drd["ruta_backup"] == DBNull.Value ? null : drd["ruta_backup"].ToString() : null;
                            output.valorcanje_regvta = drd.HasColumn("valorcanje_regvta") ? drd["valorcanje_regvta"] == DBNull.Value ? null : drd["valorcanje_regvta"].ToString() : null;
                            output.passwordweb = drd.HasColumn("passwordweb") ? drd["passwordweb"] == DBNull.Value ? null : drd["passwordweb"].ToString() : null;
                            output.ruta_qr_jpg = drd.HasColumn("ruta_qr_jpg") ? drd["ruta_qr_jpg"] == DBNull.Value ? null : drd["ruta_qr_jpg"].ToString() : null;
                            output.mto_desc_descripcion = drd.HasColumn("mto_desc_descripcion") ? drd["mto_desc_descripcion"] == DBNull.Value ? null : drd["mto_desc_descripcion"].ToString() : null;
                            output.cdcliente_automatico = drd.HasColumn("cdcliente_automatico") ? drd["cdcliente_automatico"] == DBNull.Value ? null : drd["cdcliente_automatico"].ToString() : null;
                            output.rscliente_automatico = drd.HasColumn("rscliente_automatico") ? drd["rscliente_automatico"] == DBNull.Value ? null : drd["rscliente_automatico"].ToString() : null;
                            output.msg_anula_documento = drd.HasColumn("msg_anula_documento") ? drd["msg_anula_documento"] == DBNull.Value ? null : drd["msg_anula_documento"].ToString() : null;
                            output.nroversiontienda = drd.HasColumn("nroversiontienda") ? drd["nroversiontienda"] == DBNull.Value ? null : drd["nroversiontienda"].ToString() : null;
                            output.nroversionti = drd.HasColumn("nroversionti") ? drd["nroversionti"] == DBNull.Value ? null : drd["nroversionti"].ToString() : null;
                            output.conexionweb = drd.HasColumn("conexionweb") ? drd["conexionweb"] == DBNull.Value ? null : drd["conexionweb"].ToString() : null;
                            output.instanciaweb = drd.HasColumn("instanciaweb") ? drd["instanciaweb"] == DBNull.Value ? null : drd["instanciaweb"].ToString() : null;
                            output.bdweb = drd.HasColumn("bdweb") ? drd["bdweb"] == DBNull.Value ? null : drd["bdweb"].ToString() : null;
                            output.userweb = drd.HasColumn("userweb") ? drd["userweb"] == DBNull.Value ? null : drd["userweb"].ToString() : null;
                            output.ruta_ws_easytaxy = drd.HasColumn("ruta_ws_easytaxy") ? drd["ruta_ws_easytaxy"] == DBNull.Value ? null : drd["ruta_ws_easytaxy"].ToString() : null;
                            output.cod_viatico = drd.HasColumn("cod_viatico") ? drd["cod_viatico"] == DBNull.Value ? null : drd["cod_viatico"].ToString() : null;
                            output.horacierrepd = drd.HasColumn("horacierrepd") ? drd["horacierrepd"] == DBNull.Value ? null : drd["horacierrepd"].ToString() : null;
                            output.interfaz = drd.HasColumn("interfaz") ? drd["interfaz"] == DBNull.Value ? null : drd["interfaz"].ToString() : null;
                            output.nroversionbo = drd.HasColumn("nroversionbo") ? drd["nroversionbo"] == DBNull.Value ? null : drd["nroversionbo"].ToString() : null;
                            output.nroversionplaya = drd.HasColumn("nroversionplaya") ? drd["nroversionplaya"] == DBNull.Value ? null : drd["nroversionplaya"].ToString() : null;
                            output.facturaimpre_c = drd.HasColumn("facturaimpre_c") ? drd["facturaimpre_c"] == DBNull.Value ? null : drd["facturaimpre_c"].ToString() : null;
                            output.facturafmt_c = drd.HasColumn("facturafmt_c") ? drd["facturafmt_c"] == DBNull.Value ? null : drd["facturafmt_c"].ToString() : null;
                            output.tpsalmerma = drd.HasColumn("tpsalmerma") ? drd["tpsalmerma"] == DBNull.Value ? null : drd["tpsalmerma"].ToString() : null;
                            output.tpsaldev = drd.HasColumn("tpsaldev") ? drd["tpsaldev"] == DBNull.Value ? null : drd["tpsaldev"].ToString() : null;
                            output.ruta_websaldos = drd.HasColumn("ruta_websaldos") ? drd["ruta_websaldos"] == DBNull.Value ? null : drd["ruta_websaldos"].ToString() : null;
                            output.ruta_webclubgazel = drd.HasColumn("ruta_webclubgazel") ? drd["ruta_webclubgazel"] == DBNull.Value ? null : drd["ruta_webclubgazel"].ToString() : null;
                            output.monsistema = drd.HasColumn("monsistema") ? drd["monsistema"] == DBNull.Value ? null : drd["monsistema"].ToString() : null;
                            output.monticket = drd.HasColumn("monticket") ? drd["monticket"] == DBNull.Value ? null : drd["monticket"].ToString() : null;
                            output.tpsalida = drd.HasColumn("tpsalida") ? drd["tpsalida"] == DBNull.Value ? null : drd["tpsalida"].ToString() : null;
                            output.tpingreso = drd.HasColumn("tpingreso") ? drd["tpingreso"] == DBNull.Value ? null : drd["tpingreso"].ToString() : null;
                            output.masccantidad = drd.HasColumn("masccantidad") ? drd["masccantidad"] == DBNull.Value ? null : drd["masccantidad"].ToString() : null;
                            output.masccantidadf = drd.HasColumn("masccantidadf") ? drd["masccantidadf"] == DBNull.Value ? null : drd["masccantidadf"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.prefflotlocal = drd.HasColumn("prefflotlocal") ? drd["prefflotlocal"] == DBNull.Value ? null : drd["prefflotlocal"].ToString() : null;
                            output.fe_fecvalida = drd.HasColumn("fe_fecvalida") ? drd["fe_fecvalida"] == DBNull.Value ? null : drd["fe_fecvalida"].ToString() : null;
                            output.tppgogasto = drd.HasColumn("tppgogasto") ? drd["tppgogasto"] == DBNull.Value ? null : drd["tppgogasto"].ToString() : null;
                            output.flg_invent_2 = drd.HasColumn("flg_invent_2") ? drd["flg_invent_2"] == DBNull.Value ? null : drd["flg_invent_2"].ToString() : null;
                            output.cddepart_base = drd.HasColumn("cddepart_base") ? drd["cddepart_base"] == DBNull.Value ? null : drd["cddepart_base"].ToString() : null;
                            output.factura_c = drd.HasColumn("factura_c") ? drd["factura_c"] == DBNull.Value ? null : drd["factura_c"].ToString() : null;
                            output.guia = drd.HasColumn("guia") ? drd["guia"] == DBNull.Value ? null : drd["guia"].ToString() : null;
                            output.guiaimpr = drd.HasColumn("guiaimpr") ? drd["guiaimpr"] == DBNull.Value ? null : drd["guiaimpr"].ToString() : null;
                            output.guiafmt = drd.HasColumn("guiafmt") ? drd["guiafmt"] == DBNull.Value ? null : drd["guiafmt"].ToString() : null;
                            output.tipo_canje = drd.HasColumn("tipo_canje") ? drd["tipo_canje"] == DBNull.Value ? null : drd["tipo_canje"].ToString() : null;
                            output.cdtipodocautomatico = drd.HasColumn("cdtipodocautomatico") ? drd["cdtipodocautomatico"] == DBNull.Value ? null : drd["cdtipodocautomatico"].ToString() : null;
                            output.cdclienteautomatico = drd.HasColumn("cdclienteautomatico") ? drd["cdclienteautomatico"] == DBNull.Value ? null : drd["cdclienteautomatico"].ToString() : null;
                            output.tipoafiliacion = drd.HasColumn("tipoafiliacion") ? drd["tipoafiliacion"] == DBNull.Value ? null : drd["tipoafiliacion"].ToString() : null;
                            output.tipoptoafiliacion = drd.HasColumn("tipoptoafiliacion") ? drd["tipoptoafiliacion"] == DBNull.Value ? null : drd["tipoptoafiliacion"].ToString() : null;
                            output.seriehd_imprime_ticket_web = drd.HasColumn("seriehd_imprime_ticket_web") ? drd["seriehd_imprime_ticket_web"] == DBNull.Value ? null : drd["seriehd_imprime_ticket_web"].ToString() : null;
                            output.notad_cdarticulo = drd.HasColumn("notad_cdarticulo") ? drd["notad_cdarticulo"] == DBNull.Value ? null : drd["notad_cdarticulo"].ToString() : null;
                            output.cd_estacion = drd.HasColumn("cd_estacion") ? drd["cd_estacion"] == DBNull.Value ? null : drd["cd_estacion"].ToString() : null;
                            output.tptransftienda = drd.HasColumn("tptransftienda") ? drd["tptransftienda"] == DBNull.Value ? null : drd["tptransftienda"].ToString() : null;
                            output.lin1display = drd.HasColumn("lin1display") ? drd["lin1display"] == DBNull.Value ? null : drd["lin1display"].ToString() : null;
                            output.lin2display = drd.HasColumn("lin2display") ? drd["lin2display"] == DBNull.Value ? null : drd["lin2display"].ToString() : null;
                            output.tipocontrol = drd.HasColumn("tipocontrol") ? drd["tipocontrol"] == DBNull.Value ? null : drd["tipocontrol"].ToString() : null;
                            output.cdcliprintndespacho = drd.HasColumn("cdcliprintndespacho") ? drd["cdcliprintndespacho"] == DBNull.Value ? null : drd["cdcliprintndespacho"].ToString() : null;
                            output.tppgocanje = drd.HasColumn("tppgocanje") ? drd["tppgocanje"] == DBNull.Value ? null : drd["tppgocanje"].ToString() : null;
                            output.prefcredlocal = drd.HasColumn("prefcredlocal") ? drd["prefcredlocal"] == DBNull.Value ? null : drd["prefcredlocal"].ToString() : null;
                            output.prefcredcorp = drd.HasColumn("prefcredcorp") ? drd["prefcredcorp"] == DBNull.Value ? null : drd["prefcredcorp"].ToString() : null;
                            output.prefbonus = drd.HasColumn("prefbonus") ? drd["prefbonus"] == DBNull.Value ? null : drd["prefbonus"].ToString() : null;
                            output.cdestacion = drd.HasColumn("cdestacion") ? drd["cdestacion"] == DBNull.Value ? null : drd["cdestacion"].ToString() : null;
                            output.nivelserafin = drd.HasColumn("nivelserafin") ? drd["nivelserafin"] == DBNull.Value ? null : drd["nivelserafin"].ToString() : null;
                            output.cdgrupovtaplaya = drd.HasColumn("cdgrupovtaplaya") ? drd["cdgrupovtaplaya"] == DBNull.Value ? null : drd["cdgrupovtaplaya"].ToString() : null;
                            output.tpguiatransferencia = drd.HasColumn("tpguiatransferencia") ? drd["tpguiatransferencia"] == DBNull.Value ? null : drd["tpguiatransferencia"].ToString() : null;
                            output.nrovale = drd.HasColumn("nrovale") ? drd["nrovale"] == DBNull.Value ? null : drd["nrovale"].ToString() : null;
                            output.cdletrainicial = drd.HasColumn("cdletrainicial") ? drd["cdletrainicial"] == DBNull.Value ? null : drd["cdletrainicial"].ToString() : null;
                            output.nroimportacion = drd.HasColumn("nroimportacion") ? drd["nroimportacion"] == DBNull.Value ? null : drd["nroimportacion"].ToString() : null;
                            output.tpingimportacion = drd.HasColumn("tpingimportacion") ? drd["tpingimportacion"] == DBNull.Value ? null : drd["tpingimportacion"].ToString() : null;
                            output.tpanulacion = drd.HasColumn("tpanulacion") ? drd["tpanulacion"] == DBNull.Value ? null : drd["tpanulacion"].ToString() : null;
                            output.tpinicial = drd.HasColumn("tpinicial") ? drd["tpinicial"] == DBNull.Value ? null : drd["tpinicial"].ToString() : null;
                            output.tptransferencia = drd.HasColumn("tptransferencia") ? drd["tptransferencia"] == DBNull.Value ? null : drd["tptransferencia"].ToString() : null;
                            output.tptransferenciainterna = drd.HasColumn("tptransferenciainterna") ? drd["tptransferenciainterna"] == DBNull.Value ? null : drd["tptransferenciainterna"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.cdgrupocombustible = drd.HasColumn("cdgrupocombustible") ? drd["cdgrupocombustible"] == DBNull.Value ? null : drd["cdgrupocombustible"].ToString() : null;
                            output.mascprecio = drd.HasColumn("mascprecio") ? drd["mascprecio"] == DBNull.Value ? null : drd["mascprecio"].ToString() : null;
                            output.masccosto = drd.HasColumn("masccosto") ? drd["masccosto"] == DBNull.Value ? null : drd["masccosto"].ToString() : null;
                            output.masctotal = drd.HasColumn("masctotal") ? drd["masctotal"] == DBNull.Value ? null : drd["masctotal"].ToString() : null;
                            output.tpcompra = drd.HasColumn("tpcompra") ? drd["tpcompra"] == DBNull.Value ? null : drd["tpcompra"].ToString() : null;
                            output.nrocompra = drd.HasColumn("nrocompra") ? drd["nrocompra"] == DBNull.Value ? null : drd["nrocompra"].ToString() : null;
                            output.tpcambiotalla = drd.HasColumn("tpcambiotalla") ? drd["tpcambiotalla"] == DBNull.Value ? null : drd["tpcambiotalla"].ToString() : null;
                            output.bbddsetup = drd.HasColumn("bbddsetup") ? drd["bbddsetup"] == DBNull.Value ? null : drd["bbddsetup"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BELoteriaaviso> SP_ITBCP_AVISO_LOTERIA(TS_BELoteriaaviso input)
        {
            List<TS_BELoteriaaviso> lista = new List<TS_BELoteriaaviso>();
            TS_BELoteriaaviso output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_AVISO_LOTERIA", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BELoteriaaviso();
                            output.linea1 = drd.HasColumn("linea1") ? drd["linea1"] == DBNull.Value ? null : drd["linea1"].ToString() : null;
                            output.linea2 = drd.HasColumn("linea2") ? drd["linea2"] == DBNull.Value ? null : drd["linea2"].ToString() : null;
                            output.linea3 = drd.HasColumn("linea3") ? drd["linea3"] == DBNull.Value ? null : drd["linea3"].ToString() : null;
                            output.linea4 = drd.HasColumn("linea4") ? drd["linea4"] == DBNull.Value ? null : drd["linea4"].ToString() : null;
                            output.linea5 = drd.HasColumn("linea5") ? drd["linea5"] == DBNull.Value ? null : drd["linea5"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEArticulo> SP_ITBCP_ARTICULOS_EN_PLAYA(TS_BEArticulo input)
        {
            List<TS_BEArticulo> lista = new List<TS_BEArticulo>();
            TS_BEArticulo output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ARTICULOS_EN_PLAYA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdgrupo05", SqlDbType.Char, 5).Value = input.cdgrupo05;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEArticulo();
                            output.glosa = drd.HasColumn("glosa") ? drd["glosa"] == DBNull.Value ? null : drd["glosa"].ToString() : null;
                            output.fecinicial = drd.HasColumn("fecinicial") ? drd["fecinicial"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinicial"]) : (DateTime?)null;
                            output.fecinventario = drd.HasColumn("fecinventario") ? drd["fecinventario"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinventario"]) : (DateTime?)null;
                            output.fecedicion = drd.HasColumn("fecedicion") ? drd["fecedicion"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecedicion"]) : (DateTime?)null;
                            output.bloqvta = drd.HasColumn("bloqvta") ? drd["bloqvta"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqvta"]) : false;
                            output.bloqcom = drd.HasColumn("bloqcom") ? drd["bloqcom"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqcom"]) : false;
                            output.flgglosa = drd.HasColumn("flgglosa") ? drd["flgglosa"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgglosa"]) : false;
                            output.moverstock = drd.HasColumn("moverstock") ? drd["moverstock"] == DBNull.Value ? false : Convert.ToBoolean(drd["moverstock"]) : false;
                            output.venta = drd.HasColumn("venta") ? drd["venta"] == DBNull.Value ? false : Convert.ToBoolean(drd["venta"]) : false;
                            output.consignacion = drd.HasColumn("consignacion") ? drd["consignacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["consignacion"]) : false;
                            output.trfgratuita = drd.HasColumn("trfgratuita") ? drd["trfgratuita"] == DBNull.Value ? false : Convert.ToBoolean(drd["trfgratuita"]) : false;
                            output.is_easytaxi = drd.HasColumn("is_easytaxi") ? drd["is_easytaxi"] == DBNull.Value ? false : Convert.ToBoolean(drd["is_easytaxi"]) : false;
                            output.bloqgral = drd.HasColumn("bloqgral") ? drd["bloqgral"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqgral"]) : false;
                            output.movimiento = drd.HasColumn("movimiento") ? drd["movimiento"] == DBNull.Value ? false : Convert.ToBoolean(drd["movimiento"]) : false;
                            output.vtaxmonto = drd.HasColumn("vtaxmonto") ? drd["vtaxmonto"] == DBNull.Value ? false : Convert.ToBoolean(drd["vtaxmonto"]) : false;
                            output.flgpromocion = drd.HasColumn("flgpromocion") ? drd["flgpromocion"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpromocion"]) : false;
                            output.usadecimales = drd.HasColumn("usadecimales") ? drd["usadecimales"] == DBNull.Value ? false : Convert.ToBoolean(drd["usadecimales"]) : false;
                            output._virtual = drd.HasColumn("virtual") ? drd["virtual"] == DBNull.Value ? false : Convert.ToBoolean(drd["virtual"]) : false;
                            output.ctoreposicion = drd.HasColumn("ctoreposicion") ? drd["ctoreposicion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoreposicion"]) : (decimal?)null;
                            output.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["impuesto"]) : 0;
                            output.impuesto1 = drd.HasColumn("impuesto1") ? drd["impuesto1"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["impuesto1"]) : (decimal?)null;
                            output.ctoinicial = drd.HasColumn("ctoinicial") ? drd["ctoinicial"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoinicial"]) : (decimal?)null;
                            output.ctoinventario = drd.HasColumn("ctoinventario") ? drd["ctoinventario"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctoinventario"]) : (decimal?)null;
                            output.ctopromedio = drd.HasColumn("ctopromedio") ? drd["ctopromedio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ctopromedio"]) : (decimal?)null;
                            output.mgutilidad = drd.HasColumn("mgutilidad") ? drd["mgutilidad"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mgutilidad"]) : (decimal?)null;
                            output.montofidelizacion = drd.HasColumn("montofidelizacion") ? drd["montofidelizacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["montofidelizacion"]) : (decimal?)null;
                            output.porcdetraccion = drd.HasColumn("porcdetraccion") ? drd["porcdetraccion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["porcdetraccion"]) : 0;
                            output.equivalencia = drd.HasColumn("equivalencia") ? drd["equivalencia"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["equivalencia"]) : (decimal?)null;
                            output.valorconversion = drd.HasColumn("valorconversion") ? drd["valorconversion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["valorconversion"]) : 0;
                            output.precioafiliacion = drd.HasColumn("precioafiliacion") ? drd["precioafiliacion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["precioafiliacion"]) : 0;
                            output.porcpercepcion = drd.HasColumn("porcpercepcion") ? drd["porcpercepcion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["porcpercepcion"]) : 0;
                            output.puntosfidelizacion = drd.HasColumn("puntosfidelizacion") ? drd["puntosfidelizacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["puntosfidelizacion"]) : (decimal?)null;
                            output.cantfidelizacion = drd.HasColumn("cantfidelizacion") ? drd["cantfidelizacion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantfidelizacion"]) : (decimal?)null;
                            output.c_cuenta = drd.HasColumn("c_cuenta") ? drd["c_cuenta"] == DBNull.Value ? null : drd["c_cuenta"].ToString() : null;
                            output.c_cuenta_ventas = drd.HasColumn("c_cuenta_ventas") ? drd["c_cuenta_ventas"] == DBNull.Value ? null : drd["c_cuenta_ventas"].ToString() : null;
                            output.c_centrocosto = drd.HasColumn("c_centrocosto") ? drd["c_centrocosto"] == DBNull.Value ? null : drd["c_centrocosto"].ToString() : null;
                            output.c_cuenta_compras = drd.HasColumn("c_cuenta_compras") ? drd["c_cuenta_compras"] == DBNull.Value ? null : drd["c_cuenta_compras"].ToString() : null;
                            output.cdarticulovulcano = drd.HasColumn("cdarticulovulcano") ? drd["cdarticulovulcano"] == DBNull.Value ? null : drd["cdarticulovulcano"].ToString() : null;
                            output.cdarticulosunat = drd.HasColumn("cdarticulosunat") ? drd["cdarticulosunat"] == DBNull.Value ? null : drd["cdarticulosunat"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.dsarticulo = drd.HasColumn("dsarticulo") ? drd["dsarticulo"] == DBNull.Value ? null : drd["dsarticulo"].ToString() : null;
                            output.dsarticulo1 = drd.HasColumn("dsarticulo1") ? drd["dsarticulo1"] == DBNull.Value ? null : drd["dsarticulo1"].ToString() : null;
                            output.cdgrupo01 = drd.HasColumn("cdgrupo01") ? drd["cdgrupo01"] == DBNull.Value ? null : drd["cdgrupo01"].ToString() : null;
                            output.cdgrupo02 = drd.HasColumn("cdgrupo02") ? drd["cdgrupo02"] == DBNull.Value ? null : drd["cdgrupo02"].ToString() : null;
                            output.cdgrupo03 = drd.HasColumn("cdgrupo03") ? drd["cdgrupo03"] == DBNull.Value ? null : drd["cdgrupo03"].ToString() : null;
                            output.ctacompra = drd.HasColumn("ctacompra") ? drd["ctacompra"] == DBNull.Value ? null : drd["ctacompra"].ToString() : null;
                            output.ctaventa = drd.HasColumn("ctaventa") ? drd["ctaventa"] == DBNull.Value ? null : drd["ctaventa"].ToString() : null;
                            output.ctacosto = drd.HasColumn("ctacosto") ? drd["ctacosto"] == DBNull.Value ? null : drd["ctacosto"].ToString() : null;
                            output.ctaalmacen = drd.HasColumn("ctaalmacen") ? drd["ctaalmacen"] == DBNull.Value ? null : drd["ctaalmacen"].ToString() : null;
                            output.ticketfactura = drd.HasColumn("ticketfactura") ? drd["ticketfactura"] == DBNull.Value ? null : drd["ticketfactura"].ToString() : null;
                            output.monctoinventario = drd.HasColumn("monctoinventario") ? drd["monctoinventario"] == DBNull.Value ? null : drd["monctoinventario"].ToString() : null;
                            output.monctoprom = drd.HasColumn("monctoprom") ? drd["monctoprom"] == DBNull.Value ? null : drd["monctoprom"].ToString() : null;
                            output.monctorepo = drd.HasColumn("monctorepo") ? drd["monctorepo"] == DBNull.Value ? null : drd["monctorepo"].ToString() : null;
                            output.cdmedequiv = drd.HasColumn("cdmedequiv") ? drd["cdmedequiv"] == DBNull.Value ? null : drd["cdmedequiv"].ToString() : null;
                            output.cdamarre = drd.HasColumn("cdamarre") ? drd["cdamarre"] == DBNull.Value ? null : drd["cdamarre"].ToString() : null;
                            output.tpconversion = drd.HasColumn("tpconversion") ? drd["tpconversion"] == DBNull.Value ? null : drd["tpconversion"].ToString() : null;
                            output.cdgrupo04 = drd.HasColumn("cdgrupo04") ? drd["cdgrupo04"] == DBNull.Value ? null : drd["cdgrupo04"].ToString() : null;
                            output.cdgrupo05 = drd.HasColumn("cdgrupo05") ? drd["cdgrupo05"] == DBNull.Value ? null : drd["cdgrupo05"].ToString() : null;
                            output.cdunimed = drd.HasColumn("cdunimed") ? drd["cdunimed"] == DBNull.Value ? null : drd["cdunimed"].ToString() : null;
                            output.cdtalla = drd.HasColumn("cdtalla") ? drd["cdtalla"] == DBNull.Value ? null : drd["cdtalla"].ToString() : null;
                            output.tpformula = drd.HasColumn("tpformula") ? drd["tpformula"] == DBNull.Value ? null : drd["tpformula"].ToString() : null;
                            output.monctoinicial = drd.HasColumn("monctoinicial") ? drd["monctoinicial"] == DBNull.Value ? null : drd["monctoinicial"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BEVenta> SP_ITBCP_ACTUALIZAR_VENTA(TS_BEVenta input)
        {
            List<TS_BEVenta> lista = new List<TS_BEVenta>();
         
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_VENTA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;

                    cmd.ExecuteNonQuery();
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
            return lista;
        }

        public List<TS_BETerminal> SP_ITBCP_ACTUALIZAR_TERMINAL_2(TS_BETerminal input)
        {
            List<TS_BETerminal> lista = new List<TS_BETerminal>();
           
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_TERMINAL_2", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@mtozeta", SqlDbType.Decimal, 5).Value = input.mtozeta;
                    cmd.Parameters.Add("@seriehd", SqlDbType.Char, 10).Value = input.seriehd;

                    cmd.ExecuteNonQuery();
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
            return lista;
        }

        public List<TS_BETerminal> SP_ITBCP_ACTUALIZAR_TERMINAL(TS_BETerminal input)
        {
            List<TS_BETerminal> lista = new List<TS_BETerminal>();
         
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_TERMINAL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdusuario", SqlDbType.Char, 10).Value = input.cdusuario;
                    cmd.Parameters.Add("@seriehd", SqlDbType.Char, 10).Value = input.seriehd;

                    cmd.ExecuteNonQuery();
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
            return lista;
        }


        public void CrearTabla(string SP, string nombreTabla)
        {
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(SP, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nombreTabla", SqlDbType.VarChar, 50).Value = nombreTabla;


                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_CREAR_TABLA_TRANSACCION(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_TRANSACCION", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_INSUMOIS(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_INSUMOIS", nombreTabla);          
        }

        public void SP_ITBCP_CREAR_TABLA_NOVENTA(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_NOVENTA", nombreTabla);           
        }

        public void SP_ITBCP_CREAR_TABLA_VENTA(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_VENTA", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_VENTAD(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_VENTAD", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_VENTAP(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_VENTAP", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_INGRESO(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_INGRESO", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_INGRESOD(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_INGRESOD", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_SALIDA(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_SALIDA", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_SALIDAD(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_SALIDAD", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_GUIA(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_GUIA", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_GUIAD(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_GUIAD", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_NCREDITO(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_NCREDITO", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_NCREDITOD(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_NCREDITOD", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_DIASISLAVENDEDOR(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_DIASISLAVENDEDOR", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_DIADEPVENDEDOR(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_DIADEPVENDEDOR", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_FALTSOBR(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_FALTSOBR", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_DIACAJA(string nombreTabla)
        {
           CrearTabla("SP_ITBCP_CREAR_TABLA_DIACAJA", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_DIACOBRANZA(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_DIACOBRANZA", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_DIACONTOMETRO(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_DIACONTOMETRO", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_DIACONTOMETROMANUAL(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_DIACONTOMETROMANUAL", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_DIATARJETA(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_DIATARJETA", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_DIAVARILLAJE(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_DIAVARILLAJE", nombreTabla);           
        }

        public void SP_ITBCP_CREAR_TABLA_DIADEPBANCO(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_DIADEPBANCO", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_NDEBITO(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_NDEBITO", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_NDEBITOD(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_NDEBITOD", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_HTRANSACCION(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_HTRANSACCION", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_OCOMPRA(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_OCOMPRA", nombreTabla);
        }

        public void SP_ITBCP_CREAR_TABLA_OCOMPRAD(string nombreTabla)
        {
            CrearTabla("SP_ITBCP_CREAR_TABLA_OCOMPRAD", nombreTabla);
        }

        public List<TS_BESaldoclid> SP_ITBCP_SELECT_SALDOCLIENTED(TS_BESaldoclid input)
        {
            List<TS_BESaldoclid> lista = new List<TS_BESaldoclid>();
            TS_BESaldoclid output;
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_SELECT_SALDOCLIENTED", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 15).Value = input.cdcliente;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BESaldoclid();
                            output.fechaatencion = drd.HasColumn("fechaatencion") ? drd["fechaatencion"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fechaatencion"]) : (DateTime?)null;
                            output.flgilimit = drd.HasColumn("flgilimit") ? drd["flgilimit"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgilimit"]) : false;
                            output.flgbloquea = drd.HasColumn("flgbloquea") ? drd["flgbloquea"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgbloquea"]) : false;
                            output.enviado = drd.HasColumn("enviado") ? drd["enviado"] == DBNull.Value ? false : Convert.ToBoolean(drd["enviado"]) : false;
                            output.limitemto = drd.HasColumn("limitemto") ? drd["limitemto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["limitemto"]) : (decimal?)null;
                            output.consumto = drd.HasColumn("consumto") ? drd["consumto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["consumto"]) : (decimal?)null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.nrotarjeta = drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? null : drd["nrotarjeta"].ToString() : null;
                            output.cdgrupo02 = drd.HasColumn("cdgrupo02") ? drd["cdgrupo02"] == DBNull.Value ? null : drd["cdgrupo02"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.nrobonus = drd.HasColumn("nrobonus") ? drd["nrobonus"] == DBNull.Value ? null : drd["nrobonus"].ToString() : null;
                            output.nroplaca = drd.HasColumn("nroplaca") ? drd["nroplaca"] == DBNull.Value ? null : drd["nroplaca"].ToString() : null;
                            output.tipodespacho = drd.HasColumn("tipodespacho") ? drd["tipodespacho"] == DBNull.Value ? null : drd["tipodespacho"].ToString() : null;
                            output.clave = drd.HasColumn("clave") ? drd["clave"] == DBNull.Value ? null : drd["clave"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public void SP_ITBCP_INSERTAR_VENTAG(TS_BEVentag input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_VENTAG ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = input.cdlocal;
                    cmd.Parameters.Add("@nroseriemaq", SqlDbType.Char, 15).Value = input.nroseriemaq;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@fecdocumento", SqlDbType.SmallDateTime, 4).Value = input.fecdocumento;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                    cmd.Parameters.Add("@fecanula", SqlDbType.SmallDateTime, 4).Value = input.fecanula;
                    cmd.Parameters.Add("@fecanulasis", SqlDbType.SmallDateTime, 4).Value = input.fecanulasis;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 15).Value = input.cdcliente;
                    cmd.Parameters.Add("@declarado", SqlDbType.Bit, 1).Value = input.declarado;
                    cmd.Parameters.Add("@anulado", SqlDbType.Bit, 1).Value = input.anulado;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_INSERTAR_VENTAR(TS_BEVentar input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_VENTAR ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = input.cdlocal;
                    cmd.Parameters.Add("@fecdocumento", SqlDbType.SmallDateTime, 4).Value = input.fecdocumento;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_DISMINUIR_CREDITO_ACTUALIZAR(TS_BECliente input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_DISMINUIR_CREDITO_ACTUALIZAR", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 20).Value = input.cdcliente;
                    cmd.Parameters.Add("@mtodisminuir", SqlDbType.Decimal, 9).Value = input.mtodisminuir;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_ACTUALIZAR_VALES_DE_CREDITO(TS_BEHvale input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_VALES_DE_CREDITO ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nrovale", SqlDbType.Char, 10).Value = input.nrovale;
                    cmd.Parameters.Add("@fecvale", SqlDbType.SmallDateTime, 4).Value = input.fecvale;
                    cmd.Parameters.Add("@cdmoneda", SqlDbType.Char, 1).Value = input.cdmoneda;
                    cmd.Parameters.Add("@mtovale", SqlDbType.Decimal, 9).Value = input.mtovale;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 15).Value = input.cdcliente;
                    cmd.Parameters.Add("@nroplaca", SqlDbType.Char, 10).Value = input.nroplaca;
                    cmd.Parameters.Add("@nroseriemaq", SqlDbType.Char, 15).Value = input.nroseriemaq;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@fecdocumento", SqlDbType.SmallDateTime, 4).Value = input.fecdocumento;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                    cmd.Parameters.Add("@nroseriemaqfac", SqlDbType.Char, 15).Value = input.nroseriemaqfac;
                    cmd.Parameters.Add("@cdtipodocfac", SqlDbType.Char, 5).Value = input.cdtipodocfac;
                    cmd.Parameters.Add("@nrodocumentofac", SqlDbType.Char, 10).Value = input.nrodocumentofac;
                    cmd.Parameters.Add("@fecdocumentofac", SqlDbType.SmallDateTime, 4).Value = input.fecdocumentofac;
                    cmd.Parameters.Add("@fecprocesofac", SqlDbType.SmallDateTime, 4).Value = input.fecprocesofac;
                    cmd.Parameters.Add("@placa", SqlDbType.Char, 10).Value = input.placa;
                    cmd.Parameters.Add("@turno", SqlDbType.Decimal, 5).Value = input.turno;
                    cmd.Parameters.Add("@archturno", SqlDbType.Bit, 1).Value = input.archturno;
                    cmd.Parameters.Add("@docvale", SqlDbType.Char, 10).Value = input.docvale;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_INSERTAR_CREDITO_CLIENTE(TS_BECredcliente input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_CREDITO_CLIENTE ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@docpago", SqlDbType.Char, 1).Value = input.docpago;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@renovacion", SqlDbType.Char, 2).Value = input.renovacion;
                    cmd.Parameters.Add("@fecsistema", SqlDbType.SmallDateTime, 4).Value = input.fecsistema;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                    cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = input.cdlocal;
                    cmd.Parameters.Add("@cdalmacen", SqlDbType.Char, 3).Value = input.cdalmacen;
                    cmd.Parameters.Add("@fecdocumento", SqlDbType.SmallDateTime, 4).Value = input.fecdocumento;
                    cmd.Parameters.Add("@fecvencimiento", SqlDbType.SmallDateTime, 4).Value = input.fecvencimiento;
                    cmd.Parameters.Add("@fecpago", SqlDbType.SmallDateTime, 4).Value = input.fecpago;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 20).Value = input.cdcliente;
                    cmd.Parameters.Add("@cdmoneda", SqlDbType.Char, 1).Value = input.cdmoneda;
                    cmd.Parameters.Add("@mtototal", SqlDbType.Decimal, 9).Value = input.mtototal;
                    cmd.Parameters.Add("@mtoemision", SqlDbType.Decimal, 9).Value = input.mtoemision;
                    cmd.Parameters.Add("@mtosoles", SqlDbType.Decimal, 9).Value = input.mtosoles;
                    cmd.Parameters.Add("@mtodolares", SqlDbType.Decimal, 9).Value = input.mtodolares;
                    cmd.Parameters.Add("@mtodifcambio", SqlDbType.Decimal, 9).Value = input.mtodifcambio;
                    cmd.Parameters.Add("@tcambio", SqlDbType.Decimal, 9).Value = input.tcambio;
                    cmd.Parameters.Add("@cddocaplica", SqlDbType.Char, 5).Value = input.cddocaplica;
                    cmd.Parameters.Add("@nrodocaplica", SqlDbType.Char, 10).Value = input.nrodocaplica;
                    cmd.Parameters.Add("@cdvendedor", SqlDbType.Char, 10).Value = input.cdvendedor;
                    cmd.Parameters.Add("@cdcobrador", SqlDbType.Char, 10).Value = input.cdcobrador;
                    cmd.Parameters.Add("@nropago", SqlDbType.Decimal, 9).Value = input.nropago;
                    cmd.Parameters.Add("@nroplanilla", SqlDbType.Char, 10).Value = input.nroplanilla;
                    cmd.Parameters.Add("@nrorecibo", SqlDbType.Char, 10).Value = input.nrorecibo;
                    cmd.Parameters.Add("@cdtppago", SqlDbType.Char, 5).Value = input.cdtppago;
                    cmd.Parameters.Add("@cdbanco", SqlDbType.Char, 5).Value = input.cdbanco;
                    cmd.Parameters.Add("@nrocuenta", SqlDbType.Char, 20).Value = input.nrocuenta;
                    cmd.Parameters.Add("@nrocheque", SqlDbType.Char, 20).Value = input.nrocheque;
                    cmd.Parameters.Add("@cdtarjeta", SqlDbType.Char, 2).Value = input.cdtarjeta;
                    cmd.Parameters.Add("@nrotarjeta", SqlDbType.Char, 20).Value = input.nrotarjeta;
                    cmd.Parameters.Add("@referencia", SqlDbType.Char, 60).Value = input.referencia;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;

                    cmd.ExecuteNonQuery();
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
        }

        public bool SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA(string tarjeta, decimal puntos,decimal valor_acumulado)
        {
            bool respuesta = false;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TARJETA", SqlDbType.Char, 20).Value = tarjeta;
                    cmd.Parameters.Add("@PUNTOS", SqlDbType.Decimal, 11).Value = puntos;
                    cmd.Parameters.Add("@VALORACUMULADO", SqlDbType.Decimal, 11).Value = valor_acumulado;

                    respuesta = cmd.ExecuteNonQuery() > 0;
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
            return respuesta;
        }

        public void SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA_VALOR_ACUMULADO(TS_BEAfiliaciontarj input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA_VALOR_ACUMULADO ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TarjAfiliacion", SqlDbType.Char, 20).Value = input.tarjafiliacion;
                    cmd.Parameters.Add("@Canjeado", SqlDbType.Decimal, 9).Value = input.canjeado;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_INSERTAR_AFILIACION_PUNTOS(TS_BEAfiliacionptos input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_AFILIACION_PUNTOS ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = input.cdlocal;
                    cmd.Parameters.Add("@TarjAfiliacion", SqlDbType.Char, 20).Value = input.tarjafiliacion;
                    cmd.Parameters.Add("@tipo", SqlDbType.Char, 1).Value = input.tipo;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@cdproducto", SqlDbType.Char, 20).Value = input.cdproducto;
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime, 8).Value = input.fecha;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                    cmd.Parameters.Add("@total", SqlDbType.Decimal, 9).Value = input.total;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Decimal, 9).Value = input.cantidad;
                    cmd.Parameters.Add("@Puntos", SqlDbType.Decimal, 9).Value = input.puntos;
                    cmd.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = input.estado;
                    cmd.Parameters.Add("@enviado", SqlDbType.Bit, 1).Value = input.enviado;
                    cmd.Parameters.Add("@canjeados", SqlDbType.Decimal, 9).Value = input.canjeados;
                    cmd.Parameters.Add("@cdusuario", SqlDbType.Char, 10).Value = input.cdusuario;
                    cmd.Parameters.Add("@TArjAfiliacion_Traspaso", SqlDbType.Char, 25).Value = input.tarjafiliacion_traspaso;
                    cmd.Parameters.Add("@valoracumula", SqlDbType.Decimal, 9).Value = input.valoracumula;
                    cmd.Parameters.Add("@item", SqlDbType.TinyInt, 1).Value = input.item;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA_PUNTOS_GANADOS(TS_BEAfiliaciontarj input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA_PUNTOS_GANADOS ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TarjAfiliacion", SqlDbType.Char, 20).Value = input.tarjafiliacion;
                    cmd.Parameters.Add("@Puntos", SqlDbType.Decimal, 9).Value = input.puntos;
                    cmd.Parameters.Add("@valoracumula", SqlDbType.Decimal, 9).Value = input.valoracumula;
                    cmd.Parameters.Add("@fechaultconsumo", SqlDbType.SmallDateTime, 4).Value = input.fechaultconsumo;

                    cmd.ExecuteNonQuery();
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
        }

        public List<TS_BEParametro> SP_ITBCP_SELECT_PARAMETROS(TS_BEParametro input)
        {
            List<TS_BEParametro> lista = new List<TS_BEParametro>();
            TS_BEParametro output;
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_SELECT_PARAMETROS ", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEParametro();
                            output.tipocierrextienda = drd.HasColumn("tipocierrextienda") ? drd["tipocierrextienda"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["tipocierrextienda"]) : (byte?)null;
                            output.cursor_tienda = drd.HasColumn("cursor_tienda") ? drd["cursor_tienda"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["cursor_tienda"]) : (byte?)null;
                            output.repite_articulo = drd.HasColumn("repite_articulo") ? drd["repite_articulo"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["repite_articulo"]) : (byte?)null;
                            output.imprime_canjeweb = drd.HasColumn("imprime_canjeweb") ? drd["imprime_canjeweb"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["imprime_canjeweb"]) : (byte?)null;
                            output.imprime_ptosacumulados = drd.HasColumn("imprime_ptosacumulados") ? drd["imprime_ptosacumulados"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["imprime_ptosacumulados"]) : (byte?)null;
                            output.tarjeta_actu_cdcliente = drd.HasColumn("tarjeta_actu_cdcliente") ? drd["tarjeta_actu_cdcliente"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["tarjeta_actu_cdcliente"]) : (byte?)null;
                            output.cierre_kardex = drd.HasColumn("cierre_kardex") ? drd["cierre_kardex"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["cierre_kardex"]) : (byte?)null;
                            output.noconectawpuntos = drd.HasColumn("noconectawpuntos") ? drd["noconectawpuntos"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["noconectawpuntos"]) : (byte?)null;
                            output.cierrex_formatos = drd.HasColumn("cierrex_formatos") ? drd["cierrex_formatos"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["cierrex_formatos"]) : (byte?)null;
                            output.imprime_fact_playa = drd.HasColumn("imprime_fact_playa") ? drd["imprime_fact_playa"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["imprime_fact_playa"]) : (byte?)null;
                            output.credplaca = drd.HasColumn("credplaca") ? drd["credplaca"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["credplaca"]) : (byte?)null;
                            output.cierre_especial = drd.HasColumn("cierre_especial") ? drd["cierre_especial"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["cierre_especial"]) : (byte?)null;
                            output.parte_tienda = drd.HasColumn("parte_tienda") ? drd["parte_tienda"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["parte_tienda"]) : (byte?)null;
                            output.flg_desc_prefijo = drd.HasColumn("flg_desc_prefijo") ? drd["flg_desc_prefijo"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["flg_desc_prefijo"]) : (byte?)null;
                            output.imprimir_cdarticulo_config = drd.HasColumn("imprimir_cdarticulo_config") ? drd["imprimir_cdarticulo_config"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["imprimir_cdarticulo_config"]) : (byte?)null;
                            output.mostrar_igv_pantalla = drd.HasColumn("mostrar_igv_pantalla") ? drd["mostrar_igv_pantalla"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["mostrar_igv_pantalla"]) : (byte?)null;
                            output.tipo_menu = drd.HasColumn("tipo_menu") ? drd["tipo_menu"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["tipo_menu"]) : (byte?)null;
                            output.nd_playa = drd.HasColumn("nd_playa") ? drd["nd_playa"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["nd_playa"]) : (byte?)null;
                            output.valida_cdarticulo = drd.HasColumn("valida_cdarticulo") ? drd["valida_cdarticulo"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["valida_cdarticulo"]) : (byte?)null;
                            output.conf_cierrex = drd.HasColumn("conf_cierrex") ? drd["conf_cierrex"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["conf_cierrex"]) : (byte?)null;
                            output.boton_transfer_gratuita = drd.HasColumn("boton_transfer_gratuita") ? drd["boton_transfer_gratuita"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["boton_transfer_gratuita"]) : (byte?)null;
                            output.tienda_cant_neg = drd.HasColumn("tienda_cant_neg") ? drd["tienda_cant_neg"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["tienda_cant_neg"]) : (byte?)null;
                            output.imprime_tiketera = drd.HasColumn("imprime_tiketera") ? drd["imprime_tiketera"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["imprime_tiketera"]) : (byte?)null;
                            output.imprime_nvta = drd.HasColumn("imprime_nvta") ? drd["imprime_nvta"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["imprime_nvta"]) : (byte?)null;
                            output.modifica_depositos_parte = drd.HasColumn("modifica_depositos_parte") ? drd["modifica_depositos_parte"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["modifica_depositos_parte"]) : (byte?)null;
                            output.mostrar_local_gastos = drd.HasColumn("mostrar_local_gastos") ? drd["mostrar_local_gastos"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["mostrar_local_gastos"]) : (byte?)null;
                            output.cantdigitos_tarjpromo = drd.HasColumn("cantdigitos_tarjpromo") ? drd["cantdigitos_tarjpromo"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["cantdigitos_tarjpromo"]) : (int?)null;
                            output.galones_decimales = drd.HasColumn("galones_decimales") ? drd["galones_decimales"] == DBNull.Value ? 0 : Convert.ToInt32(drd["galones_decimales"]) : 0;
                            output.tiendagazel = drd.HasColumn("tiendagazel") ? drd["tiendagazel"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["tiendagazel"]) : (int?)null;
                            output.terminalserver = drd.HasColumn("terminalserver") ? drd["terminalserver"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["terminalserver"]) : (int?)null;
                            output.rango_valfecpos = drd.HasColumn("rango_valfecpos") ? drd["rango_valfecpos"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["rango_valfecpos"]) : (int?)null;
                            output.nro_caracteres_rsocial = drd.HasColumn("nro_caracteres_rsocial") ? drd["nro_caracteres_rsocial"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["nro_caracteres_rsocial"]) : (int?)null;
                            output.valida_fecha_playa = drd.HasColumn("valida_fecha_playa") ? drd["valida_fecha_playa"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["valida_fecha_playa"]) : (int?)null;
                            output.impr_veces_nd = drd.HasColumn("impr_veces_nd") ? drd["impr_veces_nd"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["impr_veces_nd"]) : (int?)null;
                            output.impr_veces_fac = drd.HasColumn("impr_veces_fac") ? drd["impr_veces_fac"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["impr_veces_fac"]) : (int?)null;
                            output.impr_veces_bol = drd.HasColumn("impr_veces_bol") ? drd["impr_veces_bol"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["impr_veces_bol"]) : (int?)null;
                            output.fecinstall = drd.HasColumn("fecinstall") ? drd["fecinstall"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinstall"]) : (DateTime?)null;
                            output.flgtalla = drd.HasColumn("flgtalla") ? drd["flgtalla"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgtalla"]) : false;
                            output.flgformula = drd.HasColumn("flgformula") ? drd["flgformula"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgformula"]) : false;
                            output.precioconigv = drd.HasColumn("precioconigv") ? drd["precioconigv"] == DBNull.Value ? false : Convert.ToBoolean(drd["precioconigv"]) : false;
                            output.precioconservicio = drd.HasColumn("precioconservicio") ? drd["precioconservicio"] == DBNull.Value ? false : Convert.ToBoolean(drd["precioconservicio"]) : false;
                            output.utilidadcosto = drd.HasColumn("utilidadcosto") ? drd["utilidadcosto"] == DBNull.Value ? false : Convert.ToBoolean(drd["utilidadcosto"]) : false;
                            output.flgintegrador = drd.HasColumn("flgintegrador") ? drd["flgintegrador"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgintegrador"]) : false;
                            output.flg_imprimirnd_menos5s = drd.HasColumn("flg_imprimirnd_menos5s") ? drd["flg_imprimirnd_menos5s"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_imprimirnd_menos5s"]) : false;
                            output.flg_ocultarvta_menos5s = drd.HasColumn("flg_ocultarvta_menos5s") ? drd["flg_ocultarvta_menos5s"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_ocultarvta_menos5s"]) : false;
                            output.flg_noaplica_desc_tarj = drd.HasColumn("flg_noaplica_desc_tarj") ? drd["flg_noaplica_desc_tarj"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_noaplica_desc_tarj"]) : false;
                            output.flg_activar_clientes_varios = drd.HasColumn("flg_activar_clientes_varios") ? drd["flg_activar_clientes_varios"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_activar_clientes_varios"]) : false;
                            output.flg_print_qr = drd.HasColumn("flg_print_qr") ? drd["flg_print_qr"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_print_qr"]) : false;
                            output.flg_repx_terminal = drd.HasColumn("flg_repx_terminal") ? drd["flg_repx_terminal"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_repx_terminal"]) : false;
                            output.flg_cliente_automatico = drd.HasColumn("flg_cliente_automatico") ? drd["flg_cliente_automatico"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_cliente_automatico"]) : false;
                            output.desactivar_foxypreviewer = drd.HasColumn("desactivar_foxypreviewer") ? drd["desactivar_foxypreviewer"] == DBNull.Value ? false : Convert.ToBoolean(drd["desactivar_foxypreviewer"]) : false;
                            output.flg_notas_multiref = drd.HasColumn("flg_notas_multiref") ? drd["flg_notas_multiref"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_notas_multiref"]) : false;
                            output.flg_afectarcosto_fletecompras = drd.HasColumn("flg_afectarcosto_fletecompras") ? drd["flg_afectarcosto_fletecompras"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_afectarcosto_fletecompras"]) : false;
                            output.flg_btn_credito_playa = drd.HasColumn("flg_btn_credito_playa") ? drd["flg_btn_credito_playa"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_btn_credito_playa"]) : false;
                            output.flg_validateclas_cdcliente = drd.HasColumn("flg_validateclas_cdcliente") ? drd["flg_validateclas_cdcliente"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_validateclas_cdcliente"]) : false;
                            output.flg_activa_ti_todosprod = drd.HasColumn("flg_activa_ti_todosprod") ? drd["flg_activa_ti_todosprod"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_activa_ti_todosprod"]) : false;
                            output.flg_boton_promo = drd.HasColumn("flg_boton_promo") ? drd["flg_boton_promo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_boton_promo"]) : false;
                            output.flg_gastos_playa = drd.HasColumn("flg_gastos_playa") ? drd["flg_gastos_playa"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_gastos_playa"]) : false;
                            output.flg_ocultar_campos_tck = drd.HasColumn("flg_ocultar_campos_tck") ? drd["flg_ocultar_campos_tck"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_ocultar_campos_tck"]) : false;
                            output.flg_credito_centralizado = drd.HasColumn("flg_credito_centralizado") ? drd["flg_credito_centralizado"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_credito_centralizado"]) : false;
                            output.flgsoloterminal = drd.HasColumn("flgsoloterminal") ? drd["flgsoloterminal"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsoloterminal"]) : false;
                            output.flg_round_dec_indecopi = drd.HasColumn("flg_round_dec_indecopi") ? drd["flg_round_dec_indecopi"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_round_dec_indecopi"]) : false;
                            output.flg_round_indecopi_1_9 = drd.HasColumn("flg_round_indecopi_1_9") ? drd["flg_round_indecopi_1_9"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_round_indecopi_1_9"]) : false;
                            output.flg_kardex_unalinea = drd.HasColumn("flg_kardex_unalinea") ? drd["flg_kardex_unalinea"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_kardex_unalinea"]) : false;
                            output.flg_facturacion_automatica = drd.HasColumn("flg_facturacion_automatica") ? drd["flg_facturacion_automatica"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_facturacion_automatica"]) : false;
                            output.flg_modo_fact = drd.HasColumn("flg_modo_fact") ? drd["flg_modo_fact"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_modo_fact"]) : false;
                            output.label_bellavista = drd.HasColumn("label_bellavista") ? drd["label_bellavista"] == DBNull.Value ? false : Convert.ToBoolean(drd["label_bellavista"]) : false;
                            output.nd_imp_saldoyconsumo = drd.HasColumn("nd_imp_saldoyconsumo") ? drd["nd_imp_saldoyconsumo"] == DBNull.Value ? false : Convert.ToBoolean(drd["nd_imp_saldoyconsumo"]) : false;
                            output.flg_valida_fecproce_dia = drd.HasColumn("flg_valida_fecproce_dia") ? drd["flg_valida_fecproce_dia"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_valida_fecproce_dia"]) : false;
                            output.flg_canjend = drd.HasColumn("flg_canjend") ? drd["flg_canjend"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_canjend"]) : false;
                            output.flg_nrodias = drd.HasColumn("flg_nrodias") ? drd["flg_nrodias"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nrodias"]) : false;
                            output.flg_nc_liberand = drd.HasColumn("flg_nc_liberand") ? drd["flg_nc_liberand"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nc_liberand"]) : false;
                            output.flg_transfer_gratuita_cero = drd.HasColumn("flg_transfer_gratuita_cero") ? drd["flg_transfer_gratuita_cero"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_transfer_gratuita_cero"]) : false;
                            output.flg_fecsrv = drd.HasColumn("flg_fecsrv") ? drd["flg_fecsrv"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_fecsrv"]) : false;
                            output.flg_pideodometro = drd.HasColumn("flg_pideodometro") ? drd["flg_pideodometro"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pideodometro"]) : false;
                            output.flg_valdscto = drd.HasColumn("flg_valdscto") ? drd["flg_valdscto"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_valdscto"]) : false;
                            output.flg_pideclavecred = drd.HasColumn("flg_pideclavecred") ? drd["flg_pideclavecred"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pideclavecred"]) : false;
                            output.flg_anula_easytaxi = drd.HasColumn("flg_anula_easytaxi") ? drd["flg_anula_easytaxi"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_anula_easytaxi"]) : false;
                            output.conigv = drd.HasColumn("conigv") ? drd["conigv"] == DBNull.Value ? false : Convert.ToBoolean(drd["conigv"]) : false;
                            output.flg_pideplacatb = drd.HasColumn("flg_pideplacatb") ? drd["flg_pideplacatb"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pideplacatb"]) : false;
                            output.activa_repro_stock = drd.HasColumn("activa_repro_stock") ? drd["activa_repro_stock"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_repro_stock"]) : false;
                            output.flg_valfecpos = drd.HasColumn("flg_valfecpos") ? drd["flg_valfecpos"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_valfecpos"]) : false;
                            output.flg_anulapos = drd.HasColumn("flg_anulapos") ? drd["flg_anulapos"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_anulapos"]) : false;
                            output.activa_elsol = drd.HasColumn("activa_elsol") ? drd["activa_elsol"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_elsol"]) : false;
                            output.flg_boton_facturacionmanual = drd.HasColumn("flg_boton_facturacionmanual") ? drd["flg_boton_facturacionmanual"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_boton_facturacionmanual"]) : false;
                            output.mostrar_ptos_ganados = drd.HasColumn("mostrar_ptos_ganados") ? drd["mostrar_ptos_ganados"] == DBNull.Value ? false : Convert.ToBoolean(drd["mostrar_ptos_ganados"]) : false;
                            output.activa_formas_pago = drd.HasColumn("activa_formas_pago") ? drd["activa_formas_pago"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_formas_pago"]) : false;
                            output.flg_pideplaca = drd.HasColumn("flg_pideplaca") ? drd["flg_pideplaca"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pideplaca"]) : false;
                            output.depositos_playa = drd.HasColumn("depositos_playa") ? drd["depositos_playa"] == DBNull.Value ? false : Convert.ToBoolean(drd["depositos_playa"]) : false;
                            output.flg_botoncredito = drd.HasColumn("flg_botoncredito") ? drd["flg_botoncredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_botoncredito"]) : false;
                            output.flg_nobuscar_nombre = drd.HasColumn("flg_nobuscar_nombre") ? drd["flg_nobuscar_nombre"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nobuscar_nombre"]) : false;
                            output.consulta_sunat = drd.HasColumn("consulta_sunat") ? drd["consulta_sunat"] == DBNull.Value ? false : Convert.ToBoolean(drd["consulta_sunat"]) : false;
                            output.clubgazel = drd.HasColumn("clubgazel") ? drd["clubgazel"] == DBNull.Value ? false : Convert.ToBoolean(drd["clubgazel"]) : false;
                            output.activa_camedi = drd.HasColumn("activa_camedi") ? drd["activa_camedi"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_camedi"]) : false;
                            output.tarjeta_mascara = drd.HasColumn("tarjeta_mascara") ? drd["tarjeta_mascara"] == DBNull.Value ? false : Convert.ToBoolean(drd["tarjeta_mascara"]) : false;
                            output.flgruta = drd.HasColumn("flgruta") ? drd["flgruta"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgruta"]) : false;
                            output.flg_prefij_seriesdoc = drd.HasColumn("flg_prefij_seriesdoc") ? drd["flg_prefij_seriesdoc"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_prefij_seriesdoc"]) : false;
                            output.mostrar_articulo_kardex = drd.HasColumn("mostrar_articulo_kardex") ? drd["mostrar_articulo_kardex"] == DBNull.Value ? false : Convert.ToBoolean(drd["mostrar_articulo_kardex"]) : false;
                            output.flg_botontiendaenplaya = drd.HasColumn("flg_botontiendaenplaya") ? drd["flg_botontiendaenplaya"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_botontiendaenplaya"]) : false;
                            output.valida_correlativo = drd.HasColumn("valida_correlativo") ? drd["valida_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["valida_correlativo"]) : false;
                            output.flg_invent_fisicoteorico = drd.HasColumn("flg_invent_fisicoteorico") ? drd["flg_invent_fisicoteorico"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_invent_fisicoteorico"]) : false;
                            output.punto_nd = drd.HasColumn("punto_nd") ? drd["punto_nd"] == DBNull.Value ? false : Convert.ToBoolean(drd["punto_nd"]) : false;
                            output.cancelado = drd.HasColumn("cancelado") ? drd["cancelado"] == DBNull.Value ? false : Convert.ToBoolean(drd["cancelado"]) : false;
                            output.correlativos2_ticket = drd.HasColumn("correlativos2_ticket") ? drd["correlativos2_ticket"] == DBNull.Value ? false : Convert.ToBoolean(drd["correlativos2_ticket"]) : false;
                            output.chkclientedia = drd.HasColumn("chkclientedia") ? drd["chkclientedia"] == DBNull.Value ? false : Convert.ToBoolean(drd["chkclientedia"]) : false;
                            output.escirsa = drd.HasColumn("escirsa") ? drd["escirsa"] == DBNull.Value ? false : Convert.ToBoolean(drd["escirsa"]) : false;
                            output.flgcierraturnoxcaja = drd.HasColumn("flgcierraturnoxcaja") ? drd["flgcierraturnoxcaja"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierraturnoxcaja"]) : false;
                            output.activadispensador = drd.HasColumn("activadispensador") ? drd["activadispensador"] == DBNull.Value ? false : Convert.ToBoolean(drd["activadispensador"]) : false;
                            output.cambioturno = drd.HasColumn("cambioturno") ? drd["cambioturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["cambioturno"]) : false;
                            output.iniciodia = drd.HasColumn("iniciodia") ? drd["iniciodia"] == DBNull.Value ? false : Convert.ToBoolean(drd["iniciodia"]) : false;
                            output.pd_separaglp = drd.HasColumn("pd_separaglp") ? drd["pd_separaglp"] == DBNull.Value ? false : Convert.ToBoolean(drd["pd_separaglp"]) : false;
                            output.flgvalida_nrovale = drd.HasColumn("flgvalida_nrovale") ? drd["flgvalida_nrovale"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgvalida_nrovale"]) : false;
                            output.arequipa = drd.HasColumn("arequipa") ? drd["arequipa"] == DBNull.Value ? false : Convert.ToBoolean(drd["arequipa"]) : false;
                            output.pantalland_cliprintnd = drd.HasColumn("pantalland_cliprintnd") ? drd["pantalland_cliprintnd"] == DBNull.Value ? false : Convert.ToBoolean(drd["pantalland_cliprintnd"]) : false;
                            output.imprime_total_dispensado = drd.HasColumn("imprime_total_dispensado") ? drd["imprime_total_dispensado"] == DBNull.Value ? false : Convert.ToBoolean(drd["imprime_total_dispensado"]) : false;
                            output.imprime_clientes_credito = drd.HasColumn("imprime_clientes_credito") ? drd["imprime_clientes_credito"] == DBNull.Value ? false : Convert.ToBoolean(drd["imprime_clientes_credito"]) : false;
                            output.triveno = drd.HasColumn("triveno") ? drd["triveno"] == DBNull.Value ? false : Convert.ToBoolean(drd["triveno"]) : false;
                            output.activasawa = drd.HasColumn("activasawa") ? drd["activasawa"] == DBNull.Value ? false : Convert.ToBoolean(drd["activasawa"]) : false;
                            output.desanular = drd.HasColumn("desanular") ? drd["desanular"] == DBNull.Value ? false : Convert.ToBoolean(drd["desanular"]) : false;
                            output.flgsistema03 = drd.HasColumn("flgsistema03") ? drd["flgsistema03"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsistema03"]) : false;
                            output.flgcontometro = drd.HasColumn("flgcontometro") ? drd["flgcontometro"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcontometro"]) : false;
                            output.flgsolotienda = drd.HasColumn("flgsolotienda") ? drd["flgsolotienda"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsolotienda"]) : false;
                            output.flgmostrar_precio_orig = drd.HasColumn("flgmostrar_precio_orig") ? drd["flgmostrar_precio_orig"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmostrar_precio_orig"]) : false;
                            output.vertiposventa = drd.HasColumn("vertiposventa") ? drd["vertiposventa"] == DBNull.Value ? false : Convert.ToBoolean(drd["vertiposventa"]) : false;
                            output.redondeasolescombus = drd.HasColumn("redondeasolescombus") ? drd["redondeasolescombus"] == DBNull.Value ? false : Convert.ToBoolean(drd["redondeasolescombus"]) : false;
                            output.bloqventaplaya = drd.HasColumn("bloqventaplaya") ? drd["bloqventaplaya"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqventaplaya"]) : false;
                            output.saltoauto = drd.HasColumn("saltoauto") ? drd["saltoauto"] == DBNull.Value ? false : Convert.ToBoolean(drd["saltoauto"]) : false;
                            output.tarjcredplaca = drd.HasColumn("tarjcredplaca") ? drd["tarjcredplaca"] == DBNull.Value ? false : Convert.ToBoolean(drd["tarjcredplaca"]) : false;
                            output.flgprintndespacho = drd.HasColumn("flgprintndespacho") ? drd["flgprintndespacho"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgprintndespacho"]) : false;
                            output.flgsistema01 = drd.HasColumn("flgsistema01") ? drd["flgsistema01"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsistema01"]) : false;
                            output.flgsistema02 = drd.HasColumn("flgsistema02") ? drd["flgsistema02"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsistema02"]) : false;
                            output.stknegativo = drd.HasColumn("stknegativo") ? drd["stknegativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["stknegativo"]) : false;
                            output.conexiondispensador = drd.HasColumn("conexiondispensador") ? drd["conexiondispensador"] == DBNull.Value ? false : Convert.ToBoolean(drd["conexiondispensador"]) : false;
                            output.flggrifo = drd.HasColumn("flggrifo") ? drd["flggrifo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flggrifo"]) : false;
                            output.zenpantalla = drd.HasColumn("zenpantalla") ? drd["zenpantalla"] == DBNull.Value ? false : Convert.ToBoolean(drd["zenpantalla"]) : false;
                            output.flgcreaprodmov = drd.HasColumn("flgcreaprodmov") ? drd["flgcreaprodmov"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcreaprodmov"]) : false;
                            output.flgvalidaruc = drd.HasColumn("flgvalidaruc") ? drd["flgvalidaruc"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgvalidaruc"]) : false;
                            output.coloron = drd.HasColumn("coloron") ? drd["coloron"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["coloron"]) : (decimal?)null;
                            output.coloroff = drd.HasColumn("coloroff") ? drd["coloroff"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["coloroff"]) : (decimal?)null;
                            output.colorgrid = drd.HasColumn("colorgrid") ? drd["colorgrid"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["colorgrid"]) : (decimal?)null;
                            output.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["impuesto"]) : (decimal?)null;
                            output.porservicio = drd.HasColumn("porservicio") ? drd["porservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porservicio"]) : (decimal?)null;
                            output.nropago = drd.HasColumn("nropago") ? drd["nropago"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nropago"]) : (decimal?)null;
                            output.nroinventario = drd.HasColumn("nroinventario") ? drd["nroinventario"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nroinventario"]) : (decimal?)null;
                            output.mto_facturacion_automatica = drd.HasColumn("mto_facturacion_automatica") ? drd["mto_facturacion_automatica"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mto_facturacion_automatica"]) : (decimal?)null;
                            output.redondeo = drd.HasColumn("redondeo") ? drd["redondeo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["redondeo"]) : (decimal?)null;
                            output.mtominimodni_sunat = drd.HasColumn("mtominimodni_sunat") ? drd["mtominimodni_sunat"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtominimodni_sunat"]) : (decimal?)null;
                            output.mtominideposito = drd.HasColumn("mtominideposito") ? drd["mtominideposito"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtominideposito"]) : (decimal?)null;
                            output.valorigv = drd.HasColumn("valorigv") ? drd["valorigv"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorigv"]) : (decimal?)null;
                            output.colum_termica = drd.HasColumn("colum_termica") ? drd["colum_termica"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["colum_termica"]) : (decimal?)null;
                            output.mtominimodetraccion = drd.HasColumn("mtominimodetraccion") ? drd["mtominimodetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtominimodetraccion"]) : (decimal?)null;
                            output.mtominimodni = drd.HasColumn("mtominimodni") ? drd["mtominimodni"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtominimodni"]) : (decimal?)null;
                            output.mtominautomatico = drd.HasColumn("mtominautomatico") ? drd["mtominautomatico"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtominautomatico"]) : (decimal?)null;
                            output.mtocupon = drd.HasColumn("mtocupon") ? drd["mtocupon"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtocupon"]) : (decimal?)null;
                            output.modifica_precio_tienda = drd.HasColumn("modifica_precio_tienda") ? drd["modifica_precio_tienda"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["modifica_precio_tienda"]) : (decimal?)null;
                            output.precio_varios = drd.HasColumn("precio_varios") ? drd["precio_varios"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio_varios"]) : (decimal?)null;
                            output.diasresetptos = drd.HasColumn("diasresetptos") ? drd["diasresetptos"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["diasresetptos"]) : (decimal?)null;
                            output.cant_turno = drd.HasColumn("cant_turno") ? drd["cant_turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cant_turno"]) : (decimal?)null;
                            output.ptobonus = drd.HasColumn("ptobonus") ? drd["ptobonus"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ptobonus"]) : (decimal?)null;
                            output.intervaltimer = drd.HasColumn("intervaltimer") ? drd["intervaltimer"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["intervaltimer"]) : (decimal?)null;
                            output.minutosxtktbol = drd.HasColumn("minutosxtktbol") ? drd["minutosxtktbol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["minutosxtktbol"]) : (decimal?)null;
                            output.nrodeposito = drd.HasColumn("nrodeposito") ? drd["nrodeposito"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrodeposito"]) : (decimal?)null;
                            output.longtarjeta = drd.HasColumn("longtarjeta") ? drd["longtarjeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["longtarjeta"]) : (decimal?)null;
                            output.nrocdbarra = drd.HasColumn("nrocdbarra") ? drd["nrocdbarra"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrocdbarra"]) : (decimal?)null;
                            output.digitoruc = drd.HasColumn("digitoruc") ? drd["digitoruc"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["digitoruc"]) : (decimal?)null;
                            output.nrocara = drd.HasColumn("nrocara") ? drd["nrocara"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrocara"]) : (decimal?)null;
                            output.nrotransgasboy = drd.HasColumn("nrotransgasboy") ? drd["nrotransgasboy"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrotransgasboy"]) : (decimal?)null;
                            output.digitocdcliente = drd.HasColumn("digitocdcliente") ? drd["digitocdcliente"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["digitocdcliente"]) : (decimal?)null;
                            output.porcipm = drd.HasColumn("porcipm") ? drd["porcipm"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcipm"]) : (decimal?)null;
                            output.versionbo = drd.HasColumn("versionbo") ? drd["versionbo"] == DBNull.Value ? null : drd["versionbo"].ToString() : null;
                            output.versiontinven = drd.HasColumn("versiontinven") ? drd["versiontinven"] == DBNull.Value ? null : drd["versiontinven"].ToString() : null;
                            output.versionplaya = drd.HasColumn("versionplaya") ? drd["versionplaya"] == DBNull.Value ? null : drd["versionplaya"].ToString() : null;
                            output.versiontienda = drd.HasColumn("versiontienda") ? drd["versiontienda"] == DBNull.Value ? null : drd["versiontienda"].ToString() : null;
                            output.ruta_backup = drd.HasColumn("ruta_backup") ? drd["ruta_backup"] == DBNull.Value ? null : drd["ruta_backup"].ToString() : null;
                            output.valorcanje_regvta = drd.HasColumn("valorcanje_regvta") ? drd["valorcanje_regvta"] == DBNull.Value ? null : drd["valorcanje_regvta"].ToString() : null;
                            output.passwordweb = drd.HasColumn("passwordweb") ? drd["passwordweb"] == DBNull.Value ? null : drd["passwordweb"].ToString() : null;
                            output.ruta_qr_jpg = drd.HasColumn("ruta_qr_jpg") ? drd["ruta_qr_jpg"] == DBNull.Value ? null : drd["ruta_qr_jpg"].ToString() : null;
                            output.mto_desc_descripcion = drd.HasColumn("mto_desc_descripcion") ? drd["mto_desc_descripcion"] == DBNull.Value ? null : drd["mto_desc_descripcion"].ToString() : null;
                            output.cdcliente_automatico = drd.HasColumn("cdcliente_automatico") ? drd["cdcliente_automatico"] == DBNull.Value ? null : drd["cdcliente_automatico"].ToString() : null;
                            output.rscliente_automatico = drd.HasColumn("rscliente_automatico") ? drd["rscliente_automatico"] == DBNull.Value ? null : drd["rscliente_automatico"].ToString() : null;
                            output.msg_anula_documento = drd.HasColumn("msg_anula_documento") ? drd["msg_anula_documento"] == DBNull.Value ? null : drd["msg_anula_documento"].ToString() : null;
                            output.nroversiontienda = drd.HasColumn("nroversiontienda") ? drd["nroversiontienda"] == DBNull.Value ? null : drd["nroversiontienda"].ToString() : null;
                            output.nroversionti = drd.HasColumn("nroversionti") ? drd["nroversionti"] == DBNull.Value ? null : drd["nroversionti"].ToString() : null;
                            output.conexionweb = drd.HasColumn("conexionweb") ? drd["conexionweb"] == DBNull.Value ? null : drd["conexionweb"].ToString() : null;
                            output.instanciaweb = drd.HasColumn("instanciaweb") ? drd["instanciaweb"] == DBNull.Value ? null : drd["instanciaweb"].ToString() : null;
                            output.bdweb = drd.HasColumn("bdweb") ? drd["bdweb"] == DBNull.Value ? null : drd["bdweb"].ToString() : null;
                            output.userweb = drd.HasColumn("userweb") ? drd["userweb"] == DBNull.Value ? null : drd["userweb"].ToString() : null;
                            output.ruta_ws_easytaxy = drd.HasColumn("ruta_ws_easytaxy") ? drd["ruta_ws_easytaxy"] == DBNull.Value ? null : drd["ruta_ws_easytaxy"].ToString() : null;
                            output.cod_viatico = drd.HasColumn("cod_viatico") ? drd["cod_viatico"] == DBNull.Value ? null : drd["cod_viatico"].ToString() : null;
                            output.horacierrepd = drd.HasColumn("horacierrepd") ? drd["horacierrepd"] == DBNull.Value ? null : drd["horacierrepd"].ToString() : null;
                            output.interfaz = drd.HasColumn("interfaz") ? drd["interfaz"] == DBNull.Value ? null : drd["interfaz"].ToString() : null;
                            output.nroversionbo = drd.HasColumn("nroversionbo") ? drd["nroversionbo"] == DBNull.Value ? null : drd["nroversionbo"].ToString() : null;
                            output.nroversionplaya = drd.HasColumn("nroversionplaya") ? drd["nroversionplaya"] == DBNull.Value ? null : drd["nroversionplaya"].ToString() : null;
                            output.facturaimpre_c = drd.HasColumn("facturaimpre_c") ? drd["facturaimpre_c"] == DBNull.Value ? null : drd["facturaimpre_c"].ToString() : null;
                            output.facturafmt_c = drd.HasColumn("facturafmt_c") ? drd["facturafmt_c"] == DBNull.Value ? null : drd["facturafmt_c"].ToString() : null;
                            output.tpsalmerma = drd.HasColumn("tpsalmerma") ? drd["tpsalmerma"] == DBNull.Value ? null : drd["tpsalmerma"].ToString() : null;
                            output.tpsaldev = drd.HasColumn("tpsaldev") ? drd["tpsaldev"] == DBNull.Value ? null : drd["tpsaldev"].ToString() : null;
                            output.ruta_websaldos = drd.HasColumn("ruta_websaldos") ? drd["ruta_websaldos"] == DBNull.Value ? null : drd["ruta_websaldos"].ToString() : null;
                            output.ruta_webclubgazel = drd.HasColumn("ruta_webclubgazel") ? drd["ruta_webclubgazel"] == DBNull.Value ? null : drd["ruta_webclubgazel"].ToString() : null;
                            output.monsistema = drd.HasColumn("monsistema") ? drd["monsistema"] == DBNull.Value ? null : drd["monsistema"].ToString() : null;
                            output.monticket = drd.HasColumn("monticket") ? drd["monticket"] == DBNull.Value ? null : drd["monticket"].ToString() : null;
                            output.tpsalida = drd.HasColumn("tpsalida") ? drd["tpsalida"] == DBNull.Value ? null : drd["tpsalida"].ToString() : null;
                            output.tpingreso = drd.HasColumn("tpingreso") ? drd["tpingreso"] == DBNull.Value ? null : drd["tpingreso"].ToString() : null;
                            output.masccantidad = drd.HasColumn("masccantidad") ? drd["masccantidad"] == DBNull.Value ? null : drd["masccantidad"].ToString() : null;
                            output.masccantidadf = drd.HasColumn("masccantidadf") ? drd["masccantidadf"] == DBNull.Value ? null : drd["masccantidadf"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.prefflotlocal = drd.HasColumn("prefflotlocal") ? drd["prefflotlocal"] == DBNull.Value ? null : drd["prefflotlocal"].ToString() : null;
                            output.fe_fecvalida = drd.HasColumn("fe_fecvalida") ? drd["fe_fecvalida"] == DBNull.Value ? null : drd["fe_fecvalida"].ToString() : null;
                            output.tppgogasto = drd.HasColumn("tppgogasto") ? drd["tppgogasto"] == DBNull.Value ? null : drd["tppgogasto"].ToString() : null;
                            output.flg_invent_2 = drd.HasColumn("flg_invent_2") ? drd["flg_invent_2"] == DBNull.Value ? null : drd["flg_invent_2"].ToString() : null;
                            output.cddepart_base = drd.HasColumn("cddepart_base") ? drd["cddepart_base"] == DBNull.Value ? null : drd["cddepart_base"].ToString() : null;
                            output.factura_c = drd.HasColumn("factura_c") ? drd["factura_c"] == DBNull.Value ? null : drd["factura_c"].ToString() : null;
                            output.guia = drd.HasColumn("guia") ? drd["guia"] == DBNull.Value ? null : drd["guia"].ToString() : null;
                            output.guiaimpr = drd.HasColumn("guiaimpr") ? drd["guiaimpr"] == DBNull.Value ? null : drd["guiaimpr"].ToString() : null;
                            output.guiafmt = drd.HasColumn("guiafmt") ? drd["guiafmt"] == DBNull.Value ? null : drd["guiafmt"].ToString() : null;
                            output.tipo_canje = drd.HasColumn("tipo_canje") ? drd["tipo_canje"] == DBNull.Value ? null : drd["tipo_canje"].ToString() : null;
                            output.cdtipodocautomatico = drd.HasColumn("cdtipodocautomatico") ? drd["cdtipodocautomatico"] == DBNull.Value ? null : drd["cdtipodocautomatico"].ToString() : null;
                            output.cdclienteautomatico = drd.HasColumn("cdclienteautomatico") ? drd["cdclienteautomatico"] == DBNull.Value ? null : drd["cdclienteautomatico"].ToString() : null;
                            output.tipoafiliacion = drd.HasColumn("tipoafiliacion") ? drd["tipoafiliacion"] == DBNull.Value ? null : drd["tipoafiliacion"].ToString() : null;
                            output.tipoptoafiliacion = drd.HasColumn("tipoptoafiliacion") ? drd["tipoptoafiliacion"] == DBNull.Value ? null : drd["tipoptoafiliacion"].ToString() : null;
                            output.seriehd_imprime_ticket_web = drd.HasColumn("seriehd_imprime_ticket_web") ? drd["seriehd_imprime_ticket_web"] == DBNull.Value ? null : drd["seriehd_imprime_ticket_web"].ToString() : null;
                            output.notad_cdarticulo = drd.HasColumn("notad_cdarticulo") ? drd["notad_cdarticulo"] == DBNull.Value ? null : drd["notad_cdarticulo"].ToString() : null;
                            output.cd_estacion = drd.HasColumn("cd_estacion") ? drd["cd_estacion"] == DBNull.Value ? null : drd["cd_estacion"].ToString() : null;
                            output.tptransftienda = drd.HasColumn("tptransftienda") ? drd["tptransftienda"] == DBNull.Value ? null : drd["tptransftienda"].ToString() : null;
                            output.lin1display = drd.HasColumn("lin1display") ? drd["lin1display"] == DBNull.Value ? null : drd["lin1display"].ToString() : null;
                            output.lin2display = drd.HasColumn("lin2display") ? drd["lin2display"] == DBNull.Value ? null : drd["lin2display"].ToString() : null;
                            output.tipocontrol = drd.HasColumn("tipocontrol") ? drd["tipocontrol"] == DBNull.Value ? null : drd["tipocontrol"].ToString() : null;
                            output.cdcliprintndespacho = drd.HasColumn("cdcliprintndespacho") ? drd["cdcliprintndespacho"] == DBNull.Value ? null : drd["cdcliprintndespacho"].ToString() : null;
                            output.tppgocanje = drd.HasColumn("tppgocanje") ? drd["tppgocanje"] == DBNull.Value ? null : drd["tppgocanje"].ToString() : null;
                            output.prefcredlocal = drd.HasColumn("prefcredlocal") ? drd["prefcredlocal"] == DBNull.Value ? null : drd["prefcredlocal"].ToString() : null;
                            output.prefcredcorp = drd.HasColumn("prefcredcorp") ? drd["prefcredcorp"] == DBNull.Value ? null : drd["prefcredcorp"].ToString() : null;
                            output.prefbonus = drd.HasColumn("prefbonus") ? drd["prefbonus"] == DBNull.Value ? null : drd["prefbonus"].ToString() : null;
                            output.cdestacion = drd.HasColumn("cdestacion") ? drd["cdestacion"] == DBNull.Value ? null : drd["cdestacion"].ToString() : null;
                            output.nivelserafin = drd.HasColumn("nivelserafin") ? drd["nivelserafin"] == DBNull.Value ? null : drd["nivelserafin"].ToString() : null;
                            output.cdgrupovtaplaya = drd.HasColumn("cdgrupovtaplaya") ? drd["cdgrupovtaplaya"] == DBNull.Value ? null : drd["cdgrupovtaplaya"].ToString() : null;
                            output.tpguiatransferencia = drd.HasColumn("tpguiatransferencia") ? drd["tpguiatransferencia"] == DBNull.Value ? null : drd["tpguiatransferencia"].ToString() : null;
                            output.nrovale = drd.HasColumn("nrovale") ? drd["nrovale"] == DBNull.Value ? null : drd["nrovale"].ToString() : null;
                            output.cdletrainicial = drd.HasColumn("cdletrainicial") ? drd["cdletrainicial"] == DBNull.Value ? null : drd["cdletrainicial"].ToString() : null;
                            output.nroimportacion = drd.HasColumn("nroimportacion") ? drd["nroimportacion"] == DBNull.Value ? null : drd["nroimportacion"].ToString() : null;
                            output.tpingimportacion = drd.HasColumn("tpingimportacion") ? drd["tpingimportacion"] == DBNull.Value ? null : drd["tpingimportacion"].ToString() : null;
                            output.tpanulacion = drd.HasColumn("tpanulacion") ? drd["tpanulacion"] == DBNull.Value ? null : drd["tpanulacion"].ToString() : null;
                            output.tpinicial = drd.HasColumn("tpinicial") ? drd["tpinicial"] == DBNull.Value ? null : drd["tpinicial"].ToString() : null;
                            output.tptransferencia = drd.HasColumn("tptransferencia") ? drd["tptransferencia"] == DBNull.Value ? null : drd["tptransferencia"].ToString() : null;
                            output.tptransferenciainterna = drd.HasColumn("tptransferenciainterna") ? drd["tptransferenciainterna"] == DBNull.Value ? null : drd["tptransferenciainterna"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.cdgrupocombustible = drd.HasColumn("cdgrupocombustible") ? drd["cdgrupocombustible"] == DBNull.Value ? null : drd["cdgrupocombustible"].ToString() : null;
                            output.mascprecio = drd.HasColumn("mascprecio") ? drd["mascprecio"] == DBNull.Value ? null : drd["mascprecio"].ToString() : null;
                            output.masccosto = drd.HasColumn("masccosto") ? drd["masccosto"] == DBNull.Value ? null : drd["masccosto"].ToString() : null;
                            output.masctotal = drd.HasColumn("masctotal") ? drd["masctotal"] == DBNull.Value ? null : drd["masctotal"].ToString() : null;
                            output.tpcompra = drd.HasColumn("tpcompra") ? drd["tpcompra"] == DBNull.Value ? null : drd["tpcompra"].ToString() : null;
                            output.nrocompra = drd.HasColumn("nrocompra") ? drd["nrocompra"] == DBNull.Value ? null : drd["nrocompra"].ToString() : null;
                            output.tpcambiotalla = drd.HasColumn("tpcambiotalla") ? drd["tpcambiotalla"] == DBNull.Value ? null : drd["tpcambiotalla"].ToString() : null;
                            output.bbddsetup = drd.HasColumn("bbddsetup") ? drd["bbddsetup"] == DBNull.Value ? null : drd["bbddsetup"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public void SP_ITBCP_INSERTAR_VENTA(TS_BEVenta input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_VENTA ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = input.cdlocal;
                    cmd.Parameters.Add("@nroseriemaq", SqlDbType.Char, 15).Value = input.nroseriemaq;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@fecdocumento", SqlDbType.DateTime, 8).Value = input.fecdocumento;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                    cmd.Parameters.Add("@fecsistema", SqlDbType.DateTime, 8).Value = input.fecsistema;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                    cmd.Parameters.Add("@mtovueltosol", SqlDbType.Decimal, 9).Value = input.mtovueltosol;
                    cmd.Parameters.Add("@mtovueltodol", SqlDbType.Decimal, 9).Value = input.mtovueltodol;
                    cmd.Parameters.Add("@cdalmacen", SqlDbType.Char, 3).Value = input.cdalmacen;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 20).Value = input.cdcliente;
                    cmd.Parameters.Add("@ruccliente", SqlDbType.Char, 15).Value = input.ruccliente;
                    cmd.Parameters.Add("@rscliente", SqlDbType.Char, 120).Value = input.rscliente;
                    cmd.Parameters.Add("@nroproforma", SqlDbType.Char, 10).Value = input.nroproforma;
                    cmd.Parameters.Add("@cdprecio", SqlDbType.Char, 5).Value = input.cdprecio;
                    cmd.Parameters.Add("@cdmoneda", SqlDbType.Char, 1).Value = input.cdmoneda;
                    cmd.Parameters.Add("@porservicio", SqlDbType.Decimal, 5).Value = input.porservicio;
                    cmd.Parameters.Add("@pordscto1", SqlDbType.Decimal, 5).Value = input.pordscto1;
                    cmd.Parameters.Add("@pordscto2", SqlDbType.Decimal, 5).Value = input.pordscto2;
                    cmd.Parameters.Add("@pordscto3", SqlDbType.Decimal, 5).Value = input.pordscto3;
                    cmd.Parameters.Add("@pordsctoeq", SqlDbType.Decimal, 5).Value = input.pordsctoeq;
                    cmd.Parameters.Add("@mtonoafecto", SqlDbType.Decimal, 9).Value = input.mtonoafecto;
                    cmd.Parameters.Add("@valorvta", SqlDbType.Decimal, 9).Value = input.valorvta;
                    cmd.Parameters.Add("@mtodscto", SqlDbType.Decimal, 9).Value = input.mtodscto;
                    cmd.Parameters.Add("@mtosubtotal", SqlDbType.Decimal, 9).Value = input.mtosubtotal;
                    cmd.Parameters.Add("@mtoservicio", SqlDbType.Decimal, 9).Value = input.mtoservicio;
                    cmd.Parameters.Add("@mtoimpuesto", SqlDbType.Decimal, 9).Value = input.mtoimpuesto;
                    cmd.Parameters.Add("@mtototal", SqlDbType.Decimal, 9).Value = input.mtototal;
                    cmd.Parameters.Add("@cdtranspor", SqlDbType.Char, 20).Value = input.cdtranspor;
                    cmd.Parameters.Add("@nroplaca", SqlDbType.VarChar, 250).Value = input.nroplaca;
                    cmd.Parameters.Add("@drpartida", SqlDbType.Char, 60).Value = input.drpartida;
                    cmd.Parameters.Add("@drdestino", SqlDbType.Char, 60).Value = input.drdestino;
                    cmd.Parameters.Add("@cdusuario", SqlDbType.Char, 10).Value = input.cdusuario;
                    cmd.Parameters.Add("@cdvendedor", SqlDbType.Char, 10).Value = input.cdvendedor;
                    cmd.Parameters.Add("@cdusuanula", SqlDbType.Char, 10).Value = input.cdusuanula;
                    cmd.Parameters.Add("@fecanula", SqlDbType.SmallDateTime, 4).Value = input.fecanula;
                    cmd.Parameters.Add("@fecanulasis", SqlDbType.SmallDateTime, 4).Value = input.fecanulasis;
                    cmd.Parameters.Add("@tipofactura", SqlDbType.Char, 1).Value = input.tipofactura;
                    cmd.Parameters.Add("@flgmanual", SqlDbType.Bit, 1).Value = input.flgmanual;
                    cmd.Parameters.Add("@tcambio", SqlDbType.Decimal, 9).Value = input.tcambio;
                    cmd.Parameters.Add("@nroocompra", SqlDbType.Char, 15).Value = input.nroocompra;
                    cmd.Parameters.Add("@flgcierrez", SqlDbType.Bit, 1).Value = input.flgcierrez;
                    cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 250).Value = input.observacion;
                    cmd.Parameters.Add("@flgmovimiento", SqlDbType.Bit, 1).Value = input.flgmovimiento;
                    cmd.Parameters.Add("@referencia", SqlDbType.VarChar, 250).Value = input.referencia;
                    cmd.Parameters.Add("@nroserie1", SqlDbType.Char, 15).Value = input.nroserie1;
                    cmd.Parameters.Add("@nroserie2", SqlDbType.Char, 10).Value = input.nroserie2;
                    cmd.Parameters.Add("@turno", SqlDbType.Decimal, 5).Value = input.turno;
                    cmd.Parameters.Add("@nrobonus", SqlDbType.Char, 20).Value = input.nrobonus;
                    cmd.Parameters.Add("@nrotarjeta", SqlDbType.Char, 20).Value = input.nrotarjeta;
                    cmd.Parameters.Add("@odometro", SqlDbType.Char, 10).Value = input.odometro;
                    cmd.Parameters.Add("@archturno", SqlDbType.Bit, 1).Value = input.archturno;
                    cmd.Parameters.Add("@marcavehic", SqlDbType.Char, 15).Value = input.marcavehic;
                    cmd.Parameters.Add("@mtorecaudo", SqlDbType.Decimal, 9).Value = input.mtorecaudo;
                    cmd.Parameters.Add("@inscripcion", SqlDbType.Char, 15).Value = input.inscripcion;
                    cmd.Parameters.Add("@chofer", SqlDbType.Char, 40).Value = input.chofer;
                    cmd.Parameters.Add("@nrolicencia", SqlDbType.Char, 15).Value = input.nrolicencia;
                    cmd.Parameters.Add("@chkespecial", SqlDbType.Bit, 1).Value = input.chkespecial;
                    cmd.Parameters.Add("@tipoventa", SqlDbType.Char, 1).Value = input.tipoventa;
                    cmd.Parameters.Add("@nrocelular", SqlDbType.Char, 12).Value = input.nrocelular;
                    cmd.Parameters.Add("@PtosGanados", SqlDbType.Decimal, 5).Value = input.ptosganados;
                    cmd.Parameters.Add("@precio_orig", SqlDbType.Decimal, 9).Value = input.precio_orig;
                    cmd.Parameters.Add("@rucinvalido", SqlDbType.Bit, 1).Value = input.rucinvalido;
                    cmd.Parameters.Add("@usadecimales", SqlDbType.Bit, 1).Value = input.usadecimales;
                    cmd.Parameters.Add("@tipoacumula", SqlDbType.Char, 2).Value = input.tipoacumula;
                    cmd.Parameters.Add("@valoracumula", SqlDbType.Decimal, 9).Value = input.valoracumula;
                    cmd.Parameters.Add("@cantcupon", SqlDbType.Decimal, 9).Value = input.cantcupon;
                    cmd.Parameters.Add("@c_centralizacion", SqlDbType.VarChar, 50).Value = input.c_centralizacion;
                    cmd.Parameters.Add("@mtocanje", SqlDbType.Decimal, 9).Value = input.mtocanje;
                    cmd.Parameters.Add("@mtopercepcion", SqlDbType.Decimal, 9).Value = input.mtopercepcion;
                    cmd.Parameters.Add("@CDRUTA", SqlDbType.Char, 10).Value = input.cdruta;
                    cmd.Parameters.Add("@Codes", SqlDbType.VarChar, 250).Value = input.codes;
                    cmd.Parameters.Add("@codeID", SqlDbType.VarChar, 250).Value = input.codeid;
                    cmd.Parameters.Add("@mensaje1", SqlDbType.VarChar, 120).Value = input.mensaje1;
                    cmd.Parameters.Add("@mensaje2", SqlDbType.VarChar, 120).Value = input.mensaje2;
                    cmd.Parameters.Add("@redondea_indecopi", SqlDbType.Decimal, 9).Value = input.redondea_indecopi;
                    cmd.Parameters.Add("@pdf417", SqlDbType.VarChar, 450).Value = input.pdf417;
                    cmd.Parameters.Add("@cdhash", SqlDbType.VarChar, 50).Value = input.cdhash;
                    cmd.Parameters.Add("@scop", SqlDbType.VarChar, 50).Value = input.scop;
                    cmd.Parameters.Add("@nroguia", SqlDbType.VarChar, 50).Value = input.nroguia;
                    cmd.Parameters.Add("@porcdetraccion", SqlDbType.Decimal, 5).Value = input.porcdetraccion;
                    cmd.Parameters.Add("@mtodetraccion", SqlDbType.Decimal, 9).Value = input.mtodetraccion;
                    cmd.Parameters.Add("@ctadetraccion", SqlDbType.Char, 20).Value = input.ctadetraccion;
                    cmd.Parameters.Add("@fact_elect", SqlDbType.Bit, 1).Value = input.fact_elect;
                    cmd.Parameters.Add("@cdMedio_pago", SqlDbType.Char, 4).Value = input.cdmedio_pago;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_INSERTAR_VENTAP(TS_BEVentap input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_VENTAP ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = input.cdlocal;
                    cmd.Parameters.Add("@nroseriemaq", SqlDbType.Char, 15).Value = input.nroseriemaq;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@cdtppago", SqlDbType.Char, 5).Value = input.cdtppago;
                    cmd.Parameters.Add("@cdbanco", SqlDbType.Char, 4).Value = input.cdbanco;
                    cmd.Parameters.Add("@nrocuenta", SqlDbType.Char, 20).Value = input.nrocuenta;
                    cmd.Parameters.Add("@nrocheque", SqlDbType.Char, 20).Value = input.nrocheque;
                    cmd.Parameters.Add("@cdtarjeta", SqlDbType.Char, 2).Value = input.cdtarjeta;
                    cmd.Parameters.Add("@nrotarjeta", SqlDbType.Char, 20).Value = input.nrotarjeta;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                    cmd.Parameters.Add("@fecdocumento", SqlDbType.DateTime, 8).Value = input.fecdocumento;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                    cmd.Parameters.Add("@mtopagosol", SqlDbType.Decimal, 9).Value = input.mtopagosol;
                    cmd.Parameters.Add("@mtopagodol", SqlDbType.Decimal, 9).Value = input.mtopagodol;
                    cmd.Parameters.Add("@flgcierrez", SqlDbType.Bit, 1).Value = input.flgcierrez;
                    cmd.Parameters.Add("@turno", SqlDbType.Decimal, 5).Value = input.turno;
                    cmd.Parameters.Add("@nroncredito", SqlDbType.Char, 10).Value = input.nroncredito;
                    cmd.Parameters.Add("@valoracumula", SqlDbType.Decimal, 9).Value = input.valoracumula;

                    cmd.ExecuteNonQuery();
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
        }


        public decimal SP_ITBCP_CALCULAR_COSTO_PROMEDIO (string cdProducto, DateTime fechaProceso)
		{
			using (SqlConnection con = new SqlConnection(stringConnectionSetup))
			{
				try
				{
					con.Open();
					SqlCommand cmd = new SqlCommand("SP_ITBCP_CALCULAR_COSTO_PROMEDIO ", con);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@cdproducto", SqlDbType.Char, 20).Value = cdProducto; 
					cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = fechaProceso;

                    decimal costo = (decimal)cmd.ExecuteScalar();
					cmd.Dispose();

                    return costo;
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
				finally
				{
					if (con!=null){ con.Dispose(); }
				}
			}
		} 

        public void SP_ITBCP_INSERTAR_VENTAD(TS_BEVentad input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_VENTAD ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = input.cdlocal;
                    cmd.Parameters.Add("@nroseriemaq", SqlDbType.Char, 15).Value = input.nroseriemaq;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@nroitem", SqlDbType.Decimal, 5).Value = input.nroitem;
                    cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = input.cdarticulo;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                    cmd.Parameters.Add("@fecdocumento", SqlDbType.DateTime, 8).Value = input.fecdocumento;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                    cmd.Parameters.Add("@cdalterna", SqlDbType.Char, 20).Value = input.cdalterna;
                    cmd.Parameters.Add("@talla", SqlDbType.Char, 10).Value = input.talla;
                    cmd.Parameters.Add("@cdvendedor", SqlDbType.Char, 10).Value = input.cdvendedor;
                    cmd.Parameters.Add("@impuesto", SqlDbType.Decimal, 5).Value = input.impuesto;
                    cmd.Parameters.Add("@pordscto1", SqlDbType.Decimal, 5).Value = input.pordscto1;
                    cmd.Parameters.Add("@pordscto2", SqlDbType.Decimal, 5).Value = input.pordscto2;
                    cmd.Parameters.Add("@pordscto3", SqlDbType.Decimal, 5).Value = input.pordscto3;
                    cmd.Parameters.Add("@pordsctoeq", SqlDbType.Decimal, 5).Value = input.pordsctoeq;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Decimal, 9).Value = input.cantidad;
                    cmd.Parameters.Add("@cant_ncredito", SqlDbType.Decimal, 9).Value = input.cant_ncredito;
                    cmd.Parameters.Add("@precio", SqlDbType.Decimal, 9).Value = input.precio;
                    cmd.Parameters.Add("@mtonoafecto", SqlDbType.Decimal, 9).Value = input.mtonoafecto;
                    cmd.Parameters.Add("@valorvta", SqlDbType.Decimal, 9).Value = input.valorvta;
                    cmd.Parameters.Add("@mtodscto", SqlDbType.Decimal, 9).Value = input.mtodscto;
                    cmd.Parameters.Add("@mtosubtotal", SqlDbType.Decimal, 9).Value = input.mtosubtotal;
                    cmd.Parameters.Add("@mtoservicio", SqlDbType.Decimal, 9).Value = input.mtoservicio;
                    cmd.Parameters.Add("@mtoimpuesto", SqlDbType.Decimal, 9).Value = input.mtoimpuesto;
                    cmd.Parameters.Add("@mtototal", SqlDbType.Decimal, 9).Value = input.mtototal;
                    cmd.Parameters.Add("@flgcierrez", SqlDbType.Bit, 1).Value = input.flgcierrez;
                    cmd.Parameters.Add("@cara", SqlDbType.Char, 2).Value = input.cara;
                    cmd.Parameters.Add("@nrogasboy", SqlDbType.Char, 4).Value = input.nrogasboy;
                    cmd.Parameters.Add("@turno", SqlDbType.Decimal, 5).Value = input.turno;
                    cmd.Parameters.Add("@nroguia", SqlDbType.Char, 10).Value = input.nroguia;
                    cmd.Parameters.Add("@nroproforma", SqlDbType.Char, 10).Value = input.nroproforma;
                    cmd.Parameters.Add("@moverstock", SqlDbType.Bit, 1).Value = input.moverstock;
                    cmd.Parameters.Add("@glosa", SqlDbType.Text, 16).Value = input.glosa;
                    cmd.Parameters.Add("@archturno", SqlDbType.Bit, 1).Value = input.archturno;
                    cmd.Parameters.Add("@manguera", SqlDbType.Char, 1).Value = input.manguera;
                    cmd.Parameters.Add("@costo", SqlDbType.Decimal, 9).Value = input.costo;
                    cmd.Parameters.Add("@precio_orig", SqlDbType.Decimal, 9).Value = input.precio_orig;
                    cmd.Parameters.Add("@PtosGanados", SqlDbType.Decimal, 9).Value = input.ptosganados;
                    cmd.Parameters.Add("@precioafiliacion", SqlDbType.Decimal, 9).Value = input.precioafiliacion;
                    cmd.Parameters.Add("@tipoacumula", SqlDbType.Char, 25).Value = input.tipoacumula;
                    cmd.Parameters.Add("@valoracumula", SqlDbType.Decimal, 9).Value = input.valoracumula;
                    cmd.Parameters.Add("@Costo_Venta", SqlDbType.Decimal, 9).Value = input.costo_venta;
                    cmd.Parameters.Add("@TipoSuma", SqlDbType.VarChar, 50).Value = input.tiposuma;
                    cmd.Parameters.Add("@mtopercepcion", SqlDbType.Decimal, 9).Value = input.mtopercepcion;
                    cmd.Parameters.Add("@Cdpack", SqlDbType.VarChar, 20).Value = input.cdpack;
                    cmd.Parameters.Add("@trfgratuita", SqlDbType.Bit, 1).Value = input.trfgratuita;
                    cmd.Parameters.Add("@redondea_indecopi", SqlDbType.Decimal, 9).Value = input.redondea_indecopi;
                    cmd.Parameters.Add("@porcdetraccion", SqlDbType.Decimal, 5).Value = input.porcdetraccion;
                    cmd.Parameters.Add("@mtodetraccion", SqlDbType.Decimal, 9).Value = input.mtodetraccion;
                    cmd.Parameters.Add("@cdarticulosunat", SqlDbType.VarChar, 20).Value = input.cdarticulosunat;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_INSERTAR_DESPACHO(TS_BEDespachos input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_DESPACHO ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@codvehiculo", SqlDbType.Char, 20).Value = input.codvehiculo;
                    cmd.Parameters.Add("@codruta", SqlDbType.Char, 10).Value = input.codruta;
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime, 3).Value = input.fecha;
                    cmd.Parameters.Add("@hora", SqlDbType.Char, 12).Value = input.hora;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Decimal, 9).Value = input.cantidad;
                    cmd.Parameters.Add("@total", SqlDbType.Decimal, 9).Value = input.total;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_ACTUALIZAR_SALDOCLIENTE(TS_BESaldoclid input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_SALDOCLIENTE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 15).Value = input.cdcliente;
                    cmd.Parameters.Add("@nrotarjeta", SqlDbType.Char, 20).Value = input.nrotarjeta;
                    cmd.Parameters.Add("@cdgrupo02", SqlDbType.Char, 5).Value = input.cdgrupo02;
                    cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = input.cdarticulo;
                    cmd.Parameters.Add("@limitemto", SqlDbType.Decimal, 9).Value = input.limitemto;
                    cmd.Parameters.Add("@consumto", SqlDbType.Decimal, 9).Value = input.consumto;
                    cmd.Parameters.Add("@nrobonus", SqlDbType.Char, 20).Value = input.nrobonus;
                    cmd.Parameters.Add("@nroplaca", SqlDbType.Char, 10).Value = input.nroplaca;
                    cmd.Parameters.Add("@flgilimit", SqlDbType.Bit, 1).Value = input.flgilimit;
                    cmd.Parameters.Add("@flgbloquea", SqlDbType.Bit, 1).Value = input.flgbloquea;
                    cmd.Parameters.Add("@TipoDespacho", SqlDbType.Char, 1).Value = input.tipodespacho;
                    cmd.Parameters.Add("@FechaAtencion", SqlDbType.SmallDateTime, 4).Value = input.fechaatencion;
                    cmd.Parameters.Add("@Enviado", SqlDbType.Bit, 1).Value = input.enviado;
                    cmd.Parameters.Add("@clave", SqlDbType.Char, 15).Value = input.clave;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nrodocumento", SqlDbType.VarChar, 20).Value = input.nrodocumento;

                    cmd.ExecuteNonQuery();
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
        }

        public List<TS_BESaldoclid> SP_ITBCP_SELECT_SALDOCLIENTED1(TS_BESaldoclid input)
        {
            List<TS_BESaldoclid> lista = new List<TS_BESaldoclid>();
            TS_BESaldoclid output;
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_SELECT_SALDOCLIENTED1 ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nrotarjeta", SqlDbType.Char, 20).Value = input.nrotarjeta;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BESaldoclid();
                            output.fechaatencion = drd.HasColumn("fechaatencion") ? drd["fechaatencion"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fechaatencion"]) : (DateTime?)null;
                            output.flgilimit = drd.HasColumn("flgilimit") ? drd["flgilimit"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgilimit"]) : false;
                            output.flgbloquea = drd.HasColumn("flgbloquea") ? drd["flgbloquea"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgbloquea"]) : false;
                            output.enviado = drd.HasColumn("enviado") ? drd["enviado"] == DBNull.Value ? false : Convert.ToBoolean(drd["enviado"]) : false;
                            output.limitemto = drd.HasColumn("limitemto") ? drd["limitemto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["limitemto"]) : (decimal?)null;
                            output.consumto = drd.HasColumn("consumto") ? drd["consumto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["consumto"]) : (decimal?)null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.nrotarjeta = drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? null : drd["nrotarjeta"].ToString() : null;
                            output.cdgrupo02 = drd.HasColumn("cdgrupo02") ? drd["cdgrupo02"] == DBNull.Value ? null : drd["cdgrupo02"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.nrobonus = drd.HasColumn("nrobonus") ? drd["nrobonus"] == DBNull.Value ? null : drd["nrobonus"].ToString() : null;
                            output.nroplaca = drd.HasColumn("nroplaca") ? drd["nroplaca"] == DBNull.Value ? null : drd["nroplaca"].ToString() : null;
                            output.tipodespacho = drd.HasColumn("tipodespacho") ? drd["tipodespacho"] == DBNull.Value ? null : drd["tipodespacho"].ToString() : null;
                            output.clave = drd.HasColumn("clave") ? drd["clave"] == DBNull.Value ? null : drd["clave"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public void SP_ITBCP_ACTUALIZAR_SALDOCLIENTE_1(TS_BESaldoclid input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_SALDOCLIENTE_1 ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 15).Value = input.cdcliente;
                    cmd.Parameters.Add("@nrotarjeta", SqlDbType.Char, 20).Value = input.nrotarjeta;
                    cmd.Parameters.Add("@consumto", SqlDbType.Decimal, 9).Value = input.consumto;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_ACTUALIZAR_SALDOCLIENTE_2(TS_BESaldoclid input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_SALDOCLIENTE_2 ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 15).Value = input.cdcliente;
                    cmd.Parameters.Add("@consumto", SqlDbType.Decimal, 9).Value = input.consumto;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_ELIMINAR_TMPMOVPUNTOS(TS_BETmpmovpuntos input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ELIMINAR_TMPMOVPUNTOS ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@LocalID", SqlDbType.Char, 4).Value = input.localid;
                    cmd.Parameters.Add("@cdproducto", SqlDbType.Char, 20).Value = input.cdproducto;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_INSERTAR_TARJETABONUS(TS_BETarjbonus input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_TARJETABONUS ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdestacion", SqlDbType.Char, 6).Value = input.cdestacion;
                    cmd.Parameters.Add("@nrobonus", SqlDbType.Char, 11).Value = input.nrobonus;
                    cmd.Parameters.Add("@fecha", SqlDbType.Char, 8).Value = input.fecha;
                    cmd.Parameters.Add("@hora", SqlDbType.Char, 4).Value = input.hora;
                    cmd.Parameters.Add("@nroequipo", SqlDbType.Char, 6).Value = input.nroequipo;
                    cmd.Parameters.Add("@nrotransac", SqlDbType.Char, 6).Value = input.nrotransac;
                    cmd.Parameters.Add("@total", SqlDbType.Char, 7).Value = input.total;
                    cmd.Parameters.Add("@cdproducto", SqlDbType.Char, 14).Value = input.cdproducto;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Char, 8).Value = input.cantidad;
                    cmd.Parameters.Add("@totalvta", SqlDbType.Char, 7).Value = input.totalvta;
                    cmd.Parameters.Add("@enviado", SqlDbType.Bit, 1).Value = input.enviado;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_INSERTAR_STOCK(TS_BEStock input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_STOCK ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = input.cdlocal;
                    cmd.Parameters.Add("@cdalmacen", SqlDbType.Char, 3).Value = input.cdalmacen;
                    cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = input.cdarticulo;
                    cmd.Parameters.Add("@talla", SqlDbType.Char, 10).Value = input.talla;
                    cmd.Parameters.Add("@fecinicial", SqlDbType.SmallDateTime, 4).Value = input.fecinicial;
                    cmd.Parameters.Add("@stockinicial", SqlDbType.Decimal, 9).Value = input.stockinicial;
                    cmd.Parameters.Add("@monctoinicial", SqlDbType.Char, 1).Value = input.monctoinicial;
                    cmd.Parameters.Add("@ctoinicial", SqlDbType.Decimal, 9).Value = input.ctoinicial;
                    cmd.Parameters.Add("@fecinventario", SqlDbType.SmallDateTime, 4).Value = input.fecinventario;
                    cmd.Parameters.Add("@stockinventario", SqlDbType.Decimal, 9).Value = input.stockinventario;
                    cmd.Parameters.Add("@monctoinventario", SqlDbType.Char, 1).Value = input.monctoinventario;
                    cmd.Parameters.Add("@ctoinventario", SqlDbType.Decimal, 9).Value = input.ctoinventario;
                    cmd.Parameters.Add("@stockminimo", SqlDbType.Decimal, 9).Value = input.stockminimo;
                    cmd.Parameters.Add("@stockactual", SqlDbType.Decimal, 9).Value = input.stockactual;
                    cmd.Parameters.Add("@stockseparado", SqlDbType.Decimal, 9).Value = input.stockseparado;
                    cmd.Parameters.Add("@stockmaximo", SqlDbType.Decimal, 9).Value = input.stockmaximo;
                    cmd.Parameters.Add("@monctorepo", SqlDbType.Char, 1).Value = input.monctorepo;
                    cmd.Parameters.Add("@ctoreposicion", SqlDbType.Decimal, 9).Value = input.ctoreposicion;
                    cmd.Parameters.Add("@usuingreso", SqlDbType.Char, 10).Value = input.usuingreso;
                    cmd.Parameters.Add("@fecingreso", SqlDbType.SmallDateTime, 4).Value = input.fecingreso;
                    cmd.Parameters.Add("@ususalida", SqlDbType.Char, 10).Value = input.ususalida;
                    cmd.Parameters.Add("@fecsalida", SqlDbType.SmallDateTime, 4).Value = input.fecsalida;
                    cmd.Parameters.Add("@usuventa", SqlDbType.Char, 10).Value = input.usuventa;
                    cmd.Parameters.Add("@fecventa", SqlDbType.SmallDateTime, 4).Value = input.fecventa;
                    cmd.Parameters.Add("@IS_RECALCULO", SqlDbType.Bit, 1).Value = input.is_recalculo;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_ACTUALIZAR_STOCK(TS_BEStock input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_STOCK ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = input.cdlocal;
                    cmd.Parameters.Add("@cdalmacen", SqlDbType.Char, 3).Value = input.cdalmacen;
                    cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = input.cdarticulo;
                    cmd.Parameters.Add("@talla", SqlDbType.Char, 10).Value = input.talla;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Decimal, 9).Value = input.cantidad;
                    cmd.Parameters.Add("@usuventa", SqlDbType.Char, 10).Value = input.usuventa;
                    cmd.Parameters.Add("@fecventa", SqlDbType.SmallDateTime, 4).Value = input.fecventa;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_INSERTAR_INSUMOISR(TS_BEInsumoisr input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_INSUMOISR ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = input.cdlocal;
                    cmd.Parameters.Add("@fecdocumento", SqlDbType.SmallDateTime, 4).Value = input.fecdocumento;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;

                    cmd.ExecuteNonQuery();
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
        }

        public bool SP_ITBCP_INSERTAR_INSUMOIS(TS_BEInsumois input, string nombreTabla, SqlTransaction pSqlTransaction)
        {
            bool flag = false;

            try
            {
                SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_INSUMOIS")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = pSqlTransaction.Connection,
                    Transaction = pSqlTransaction
                };

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nombreTabla", SqlDbType.VarChar, 50).Value = nombreTabla;
                cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = input.cdlocal;
                cmd.Parameters.Add("@nroseriemaq", SqlDbType.Char, 20).Value = input.nroseriemaq;
                cmd.Parameters.Add("@cdtpmov", SqlDbType.Char, 5).Value = input.cdtpmov;
                cmd.Parameters.Add("@nromov", SqlDbType.Char, 10).Value = input.nromov;
                cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 15).Value = input.nrodocumento;
                cmd.Parameters.Add("@movimiento", SqlDbType.Char, 1).Value = input.movimiento;
                cmd.Parameters.Add("@nroitem", SqlDbType.Decimal, 5).Value = input.nroitem;
                cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = input.cdarticulo;
                cmd.Parameters.Add("@talla", SqlDbType.Char, 10).Value = input.talla;
                cmd.Parameters.Add("@cdalmacen", SqlDbType.Char, 3).Value = input.cdalmacen;
                cmd.Parameters.Add("@cantidad", SqlDbType.Decimal, 9).Value = input.cantidad;
                cmd.Parameters.Add("@monctorepo", SqlDbType.Char, 1).Value = input.monctorepo;
                cmd.Parameters.Add("@ctoreposicion", SqlDbType.Decimal, 9).Value = input.ctoreposicion;
                cmd.Parameters.Add("@ctopromedio", SqlDbType.Decimal, 9).Value = input.ctopromedio;
                cmd.Parameters.Add("@tcambio", SqlDbType.Decimal, 9).Value = input.tcambio;
                cmd.Parameters.Add("@fecdocumento", SqlDbType.DateTime, 8).Value = input.fecdocumento;
                cmd.Parameters.Add("@flganulacion", SqlDbType.Bit, 1).Value = input.flganulacion;
                cmd.Parameters.Add("@fecsistema", SqlDbType.DateTime, 8).Value = input.fecsistema;
                cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                cmd.Parameters.Add("@precio", SqlDbType.Decimal, 9).Value = input.precio;

                flag = cmd.ExecuteNonQuery() > 0;
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return flag;
        }

        public void SP_ITBCP_ACTUALIZAR_ARTICULO(TS_BEArticulo input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_ARTICULO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = input.cdarticulo;
                    cmd.Parameters.Add("@movimiento", SqlDbType.Bit, 1).Value = input.movimiento;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_INSERTAR_CIERREMOV(TS_BECierremov input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_CIERREMOV ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = input.cdlocal;
                    cmd.Parameters.Add("@cdalmacen", SqlDbType.Char, 3).Value = input.cdalmacen;
                    cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = input.cdarticulo;
                    cmd.Parameters.Add("@ventas", SqlDbType.Decimal, 9).Value = input.ventas;
                    cmd.Parameters.Add("@ingresos", SqlDbType.Decimal, 9).Value = input.ingresos;
                    cmd.Parameters.Add("@salidas", SqlDbType.Decimal, 9).Value = input.salidas;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_ACTUALIZAR_CIERREMOV(TS_BECierremov input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_CIERREMOV ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = input.cdlocal;
                    cmd.Parameters.Add("@cdalmacen", SqlDbType.Char, 3).Value = input.cdalmacen;
                    cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = input.cdarticulo;
                    cmd.Parameters.Add("@ventas", SqlDbType.Decimal, 9).Value = input.ventas;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_INSERTAR_CLIENTE(TS_BECliente input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_CLIENTE ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 20).Value = input.cdcliente;
                    cmd.Parameters.Add("@ruccliente", SqlDbType.Char, 15).Value = input.ruccliente;
                    cmd.Parameters.Add("@rscliente", SqlDbType.Char, 120).Value = input.rscliente;
                    cmd.Parameters.Add("@drcliente", SqlDbType.Char, 120).Value = input.drcliente;
                    cmd.Parameters.Add("@cddistrito", SqlDbType.Char, 2).Value = input.cddistrito;
                    cmd.Parameters.Add("@cddepartamento", SqlDbType.Char, 2).Value = input.cddepartamento;
                    cmd.Parameters.Add("@cdzona", SqlDbType.Char, 5).Value = input.cdzona;
                    cmd.Parameters.Add("@drcobranza", SqlDbType.Char, 60).Value = input.drcobranza;
                    cmd.Parameters.Add("@drentrega", SqlDbType.Char, 60).Value = input.drentrega;
                    cmd.Parameters.Add("@tlfcliente", SqlDbType.Char, 15).Value = input.tlfcliente;
                    cmd.Parameters.Add("@tlfcliente1", SqlDbType.Char, 15).Value = input.tlfcliente1;
                    cmd.Parameters.Add("@faxcliente", SqlDbType.Char, 15).Value = input.faxcliente;
                    cmd.Parameters.Add("@monlimite", SqlDbType.Char, 1).Value = input.monlimite;
                    cmd.Parameters.Add("@mtolimite", SqlDbType.Decimal, 9).Value = input.mtolimite;
                    cmd.Parameters.Add("@mtodisponible", SqlDbType.Decimal, 9).Value = input.mtodisponible;
                    cmd.Parameters.Add("@bloqcredito", SqlDbType.Bit, 1).Value = input.bloqcredito;
                    cmd.Parameters.Add("@emcliente", SqlDbType.Char, 60).Value = input.emcliente;
                    cmd.Parameters.Add("@fecnacimiento", SqlDbType.SmallDateTime, 4).Value = input.fecnacimiento;
                    cmd.Parameters.Add("@cdalmacen", SqlDbType.Char, 3).Value = input.cdalmacen;
                    cmd.Parameters.Add("@tipocli", SqlDbType.Char, 1).Value = input.tipocli;
                    cmd.Parameters.Add("@diascredito", SqlDbType.Int, 4).Value = input.diascredito;
                    cmd.Parameters.Add("@CDGRUPOCLI", SqlDbType.Char, 5).Value = input.cdgrupocli;
                    cmd.Parameters.Add("@Sunat_Actualiza", SqlDbType.TinyInt, 1).Value = input.sunat_actualiza;
                    cmd.Parameters.Add("@cliente", SqlDbType.VarChar, 60).Value = input.cliente;
                    cmd.Parameters.Add("@contacto", SqlDbType.VarChar, 60).Value = input.contacto;
                    cmd.Parameters.Add("@fecha_creacion", SqlDbType.SmallDateTime, 4).Value = input.fecha_creacion;
                    cmd.Parameters.Add("@DIASMAX_ND", SqlDbType.Int, 4).Value = input.diasmax_nd;
                    cmd.Parameters.Add("@GRUPORUTA", SqlDbType.Char, 10).Value = input.gruporuta;
                    cmd.Parameters.Add("@flgpreciond", SqlDbType.Bit, 1).Value = input.flgpreciond;
                    cmd.Parameters.Add("@consulta_sunat", SqlDbType.Bit, 1).Value = input.consulta_sunat;
                    cmd.Parameters.Add("@flg_pideclave", SqlDbType.Bit, 1).Value = input.flg_pideclave;
                    cmd.Parameters.Add("@flgtotalnd", SqlDbType.Bit, 1).Value = input.flgtotalnd;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_ACTUALIZAR_CLIENTE(TS_BECliente input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_CLIENTE ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 20).Value = input.cdcliente;
                    cmd.Parameters.Add("@ruccliente", SqlDbType.Char, 15).Value = input.ruccliente;
                    cmd.Parameters.Add("@rscliente", SqlDbType.Char, 120).Value = input.rscliente;
                    cmd.Parameters.Add("@drcliente", SqlDbType.Char, 120).Value = input.drcliente;
                    cmd.Parameters.Add("@cddistrito", SqlDbType.Char, 2).Value = input.cddistrito;
                    cmd.Parameters.Add("@cddepartamento", SqlDbType.Char, 2).Value = input.cddepartamento;
                    cmd.Parameters.Add("@cdzona", SqlDbType.Char, 5).Value = input.cdzona;
                    cmd.Parameters.Add("@drcobranza", SqlDbType.Char, 60).Value = input.drcobranza;
                    cmd.Parameters.Add("@drentrega", SqlDbType.Char, 60).Value = input.drentrega;
                    cmd.Parameters.Add("@tlfcliente", SqlDbType.Char, 15).Value = input.tlfcliente;
                    cmd.Parameters.Add("@tlfcliente1", SqlDbType.Char, 15).Value = input.tlfcliente1;
                    cmd.Parameters.Add("@faxcliente", SqlDbType.Char, 15).Value = input.faxcliente;
                    cmd.Parameters.Add("@monlimite", SqlDbType.Char, 1).Value = input.monlimite;
                    cmd.Parameters.Add("@mtolimite", SqlDbType.Decimal, 9).Value = input.mtolimite;
                    cmd.Parameters.Add("@mtodisponible", SqlDbType.Decimal, 9).Value = input.mtodisponible;
                    cmd.Parameters.Add("@bloqcredito", SqlDbType.Bit, 1).Value = input.bloqcredito;
                    cmd.Parameters.Add("@emcliente", SqlDbType.Char, 60).Value = input.emcliente;
                    cmd.Parameters.Add("@fecnacimiento", SqlDbType.SmallDateTime, 4).Value = input.fecnacimiento;
                    cmd.Parameters.Add("@cdalmacen", SqlDbType.Char, 3).Value = input.cdalmacen;
                    cmd.Parameters.Add("@tipocli", SqlDbType.Char, 1).Value = input.tipocli;
                    cmd.Parameters.Add("@diascredito", SqlDbType.Int, 4).Value = input.diascredito;
                    cmd.Parameters.Add("@CDGRUPOCLI", SqlDbType.Char, 5).Value = input.cdgrupocli;
                    cmd.Parameters.Add("@Sunat_Actualiza", SqlDbType.TinyInt, 1).Value = input.sunat_actualiza;
                    cmd.Parameters.Add("@cliente", SqlDbType.VarChar, 60).Value = input.cliente;
                    cmd.Parameters.Add("@contacto", SqlDbType.VarChar, 60).Value = input.contacto;
                    cmd.Parameters.Add("@fecha_creacion", SqlDbType.SmallDateTime, 4).Value = input.fecha_creacion;
                    cmd.Parameters.Add("@DIASMAX_ND", SqlDbType.Int, 4).Value = input.diasmax_nd;
                    cmd.Parameters.Add("@GRUPORUTA", SqlDbType.Char, 10).Value = input.gruporuta;
                    cmd.Parameters.Add("@flgpreciond", SqlDbType.Bit, 1).Value = input.flgpreciond;
                    cmd.Parameters.Add("@consulta_sunat", SqlDbType.Bit, 1).Value = input.consulta_sunat;
                    cmd.Parameters.Add("@flg_pideclave", SqlDbType.Bit, 1).Value = input.flg_pideclave;
                    cmd.Parameters.Add("@flgtotalnd", SqlDbType.Bit, 1).Value = input.flgtotalnd;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_INSERTAR_PLACA(TS_BEPlaca input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_PLACA ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nroplaca", SqlDbType.VarChar, 250).Value = input.nroplaca;
                    cmd.Parameters.Add("@marca", SqlDbType.Char, 50).Value = input.marca;
                    cmd.Parameters.Add("@modelo", SqlDbType.Char, 50).Value = input.modelo;
                    cmd.Parameters.Add("@color", SqlDbType.Char, 50).Value = input.color;
                    cmd.Parameters.Add("@ano", SqlDbType.Decimal, 5).Value = input.ano;
                    cmd.Parameters.Add("@nroserie", SqlDbType.Char, 40).Value = input.nroserie;
                    cmd.Parameters.Add("@nromotor", SqlDbType.Char, 40).Value = input.nromotor;
                    cmd.Parameters.Add("@kilometraje", SqlDbType.Decimal, 5).Value = input.kilometraje;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_ELIMINAR_CVENTA(TS_BECventa input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ELIMINAR_CVENTA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                    cmd.Parameters.Add("@fecha", SqlDbType.SmallDateTime, 4).Value = input.fecha;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_ELIMINAR_CVENTAD(TS_BECventad input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ELIMINAR_CVENTAD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                    cmd.Parameters.Add("@fecha", SqlDbType.SmallDateTime, 4).Value = input.fecha;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_ELIMINAR_VALE(TS_BEVale input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ELIMINAR_VALE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nrovale", SqlDbType.Char, 10).Value = input.nrovale;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_INSERTAR_HVALE(TS_BEHvale input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_HVALE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nrovale", SqlDbType.Char, 10).Value = input.nrovale;
                    cmd.Parameters.Add("@fecvale", SqlDbType.SmallDateTime, 4).Value = input.fecvale;
                    cmd.Parameters.Add("@cdmoneda", SqlDbType.Char, 1).Value = input.cdmoneda;
                    cmd.Parameters.Add("@mtovale", SqlDbType.Decimal, 9).Value = input.mtovale;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 15).Value = input.cdcliente;
                    cmd.Parameters.Add("@nroplaca", SqlDbType.Char, 10).Value = input.nroplaca;
                    cmd.Parameters.Add("@nroseriemaq", SqlDbType.Char, 15).Value = input.nroseriemaq;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@fecdocumento", SqlDbType.SmallDateTime, 4).Value = input.fecdocumento;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                    cmd.Parameters.Add("@nroseriemaqfac", SqlDbType.Char, 15).Value = input.nroseriemaqfac;
                    cmd.Parameters.Add("@cdtipodocfac", SqlDbType.Char, 5).Value = input.cdtipodocfac;
                    cmd.Parameters.Add("@nrodocumentofac", SqlDbType.Char, 10).Value = input.nrodocumentofac;
                    cmd.Parameters.Add("@fecdocumentofac", SqlDbType.SmallDateTime, 4).Value = input.fecdocumentofac;
                    cmd.Parameters.Add("@fecprocesofac", SqlDbType.SmallDateTime, 4).Value = input.fecprocesofac;
                    cmd.Parameters.Add("@placa", SqlDbType.Char, 10).Value = input.placa;
                    cmd.Parameters.Add("@turno", SqlDbType.Decimal, 5).Value = input.turno;
                    cmd.Parameters.Add("@archturno", SqlDbType.Bit, 1).Value = input.archturno;
                    cmd.Parameters.Add("@docvale", SqlDbType.Char, 10).Value = input.docvale;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_ACTUALIZAR_CDHASH_VENTA(TS_BEVenta input, string nombretabla)

        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_CDHASH_VENTA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nombreTabla", SqlDbType.VarChar, 50).Value = nombretabla;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@cdhash", SqlDbType.VarChar, 50).Value = input.cdhash;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_ACTUALIZAR_OPTRAN(TS_BEOp_Tran input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_OPTRAN", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CONTROLADOR", SqlDbType.Char, 2).Value = input.controlador;
                    cmd.Parameters.Add("@NUMERO", SqlDbType.Char, 4).Value = input.numero;
                    cmd.Parameters.Add("@PRODUCTO", SqlDbType.Char, 2).Value = input.producto;
                    cmd.Parameters.Add("@CARA", SqlDbType.Char, 2).Value = input.cara;
                    cmd.Parameters.Add("@FECHA", SqlDbType.SmallDateTime, 4).Value = input.fecha;
                    cmd.Parameters.Add("@HORA", SqlDbType.SmallDateTime, 4).Value = input.hora;
                    cmd.Parameters.Add("@c_interno", SqlDbType.BigInt, 8).Value = input.c_interno;
                    cmd.Parameters.Add("@SOLES", SqlDbType.Decimal, 9).Value = input.soles;
                    cmd.Parameters.Add("@PRECIO", SqlDbType.Decimal, 5).Value = input.precio;
                    cmd.Parameters.Add("@GALONES", SqlDbType.Decimal, 5).Value = input.galones;
                    cmd.Parameters.Add("@TURNO", SqlDbType.Char, 1).Value = input.turno;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.Char, 10).Value = input.estado;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@DOCUMENTO", SqlDbType.Decimal, 9).Value = input.documento;
                    cmd.Parameters.Add("@DATEPROCE", SqlDbType.SmallDateTime, 4).Value = input.dateproce;
                    cmd.Parameters.Add("@MANGUERA", SqlDbType.Int, 4).Value = input.manguera;
                    cmd.Parameters.Add("@FECSISTEMA", SqlDbType.DateTime, 8).Value = input.fecsistema;

                    cmd.ExecuteNonQuery();
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
        }

        public List<TS_BEInsumo> SP_ITBCP_SELECT_INSUMOS(TS_BEInsumo input)
        {
            List<TS_BEInsumo> lista = new List<TS_BEInsumo>();
            TS_BEInsumo output;
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_SELECT_INSUMOS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = input.cdarticulo;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEInsumo();
                            output.cantidad = drd.HasColumn("cantidad") ? drd["cantidad"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cantidad"]) : (decimal?)null;
                            output.costo = drd.HasColumn("costo") ? drd["costo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["costo"]) : (decimal?)null;
                            output.porcprecio = drd.HasColumn("porcprecio") ? drd["porcprecio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcprecio"]) : (decimal?)null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.cdinsumo = drd.HasColumn("cdinsumo") ? drd["cdinsumo"] == DBNull.Value ? null : drd["cdinsumo"].ToString() : null;
                            output.talla = drd.HasColumn("talla") ? drd["talla"] == DBNull.Value ? null : drd["talla"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BELoteria> SP_ITBCP_SELECT_LOTERIA(TS_BELoteria input)
        {
            List<TS_BELoteria> lista = new List<TS_BELoteria>();
            TS_BELoteria output;
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_SELECT_LOTERIA", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BELoteria();
                            output.id = drd.HasColumn("id") ? drd["id"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["id"]) : (int?)null;
                            output.fecinicio = drd.HasColumn("fecinicio") ? drd["fecinicio"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinicio"]) : (DateTime?)null;
                            output.fecfin = drd.HasColumn("fecfin") ? drd["fecfin"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecfin"]) : (DateTime?)null;
                            output.flgactivo = drd.HasColumn("flgactivo") ? drd["flgactivo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgactivo"]) : false;
                            output.flgefectivo = drd.HasColumn("flgefectivo") ? drd["flgefectivo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgefectivo"]) : false;
                            output.flgtarjeta = drd.HasColumn("flgtarjeta") ? drd["flgtarjeta"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgtarjeta"]) : false;
                            output.flgcheque = drd.HasColumn("flgcheque") ? drd["flgcheque"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcheque"]) : false;
                            output.flgcredito = drd.HasColumn("flgcredito") ? drd["flgcredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcredito"]) : false;
                            output.flgpromocion = drd.HasColumn("flgpromocion") ? drd["flgpromocion"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpromocion"]) : false;
                            output.nro_centralizacion = drd.HasColumn("nro_centralizacion") ? drd["nro_centralizacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["nro_centralizacion"]) : false;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BELoteriahora> SP_ITBCP_SELECT_LOTERIA_HORA(TS_BELoteriahora input)
        {
            List<TS_BELoteriahora> lista = new List<TS_BELoteriahora>();
            TS_BELoteriahora output;
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_SELECT_LOTERIA_HORA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@hora", SqlDbType.Char, 5).Value = input.hora;
                    cmd.Parameters.Add("@dia", SqlDbType.Int, 4).Value = input.dia;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BELoteriahora();
                            output.flglunes = drd.HasColumn("flglunes") ? drd["flglunes"] == DBNull.Value ? false : Convert.ToBoolean(drd["flglunes"]) : false;
                            output.flgmartes = drd.HasColumn("flgmartes") ? drd["flgmartes"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmartes"]) : false;
                            output.flgmiercoles = drd.HasColumn("flgmiercoles") ? drd["flgmiercoles"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmiercoles"]) : false;
                            output.flgjueves = drd.HasColumn("flgjueves") ? drd["flgjueves"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgjueves"]) : false;
                            output.flgviernes = drd.HasColumn("flgviernes") ? drd["flgviernes"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgviernes"]) : false;
                            output.flgsabado = drd.HasColumn("flgsabado") ? drd["flgsabado"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsabado"]) : false;
                            output.flgdomingo = drd.HasColumn("flgdomingo") ? drd["flgdomingo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgdomingo"]) : false;
                            output.flgprod = drd.HasColumn("flgprod") ? drd["flgprod"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgprod"]) : false;
                            output.item = drd.HasColumn("item") ? drd["item"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["item"]) : (decimal?)null;
                            output.nroganador = drd.HasColumn("nroganador") ? drd["nroganador"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nroganador"]) : (decimal?)null;
                            output.mtomax = drd.HasColumn("mtomax") ? drd["mtomax"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtomax"]) : (decimal?)null;
                            output.frecuencia = drd.HasColumn("frecuencia") ? drd["frecuencia"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["frecuencia"]) : (decimal?)null;
                            output.horainicio = drd.HasColumn("horainicio") ? drd["horainicio"] == DBNull.Value ? null : drd["horainicio"].ToString() : null;
                            output.horafin = drd.HasColumn("horafin") ? drd["horafin"] == DBNull.Value ? null : drd["horafin"].ToString() : null;
                            output.monmto = drd.HasColumn("monmto") ? drd["monmto"] == DBNull.Value ? null : drd["monmto"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BELoteriaart> SP_ITBCP_SELECT_LOTERIART(TS_BELoteriaart input)
        {
            List<TS_BELoteriaart> lista = new List<TS_BELoteriaart>();
            TS_BELoteriaart output;
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_SELECT_LOTERIART", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@item", SqlDbType.Decimal, 5).Value = input.item;
                    cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = input.cdarticulo;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BELoteriaart();
                            output.item = drd.HasColumn("item") ? drd["item"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["item"]) : (decimal?)null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public List<TS_BELoteriawin> SP_ITBCP_SELECT_LOTERIAWIN(TS_BELoteriawin input)
        {
            List<TS_BELoteriawin> lista = new List<TS_BELoteriawin>();
            TS_BELoteriawin output;
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_SELECT_LOTERIAWIN", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fecha", SqlDbType.SmallDateTime, 4).Value = input.fecha;
                    cmd.Parameters.Add("@item", SqlDbType.Decimal, 5).Value = input.item;
                    cmd.Parameters.Add("@nroseriemaq", SqlDbType.Char, 15).Value = input.nroseriemaq;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BELoteriawin();
                            output.fecha = drd.HasColumn("fecha") ? drd["fecha"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecha"]) : (DateTime?)null;
                            output.fecdocumento = drd.HasColumn("fecdocumento") ? drd["fecdocumento"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecdocumento"]) : (DateTime?)null;
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.item = drd.HasColumn("item") ? drd["item"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["item"]) : (decimal?)null;
                            output.mtototal = drd.HasColumn("mtototal") ? drd["mtototal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtototal"]) : (decimal?)null;
                            output.nroganador = drd.HasColumn("nroganador") ? drd["nroganador"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nroganador"]) : (decimal?)null;
                            output.frecuencia = drd.HasColumn("frecuencia") ? drd["frecuencia"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["frecuencia"]) : (decimal?)null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.cdtipodoc = drd.HasColumn("cdtipodoc") ? drd["cdtipodoc"] == DBNull.Value ? null : drd["cdtipodoc"].ToString() : null;
                            output.nrodocumento = drd.HasColumn("nrodocumento") ? drd["nrodocumento"] == DBNull.Value ? null : drd["nrodocumento"].ToString() : null;
                            output.cdmoneda = drd.HasColumn("cdmoneda") ? drd["cdmoneda"] == DBNull.Value ? null : drd["cdmoneda"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }

        public void SP_ITBCP_INSERTAR_LOTERIAWIN(TS_BELoteriawin input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_LOTERIAWIN", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fecha", SqlDbType.SmallDateTime, 4).Value = input.fecha;
                    cmd.Parameters.Add("@item", SqlDbType.Decimal, 5).Value = input.item;
                    cmd.Parameters.Add("@nroseriemaq", SqlDbType.Char, 15).Value = input.nroseriemaq;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@fecdocumento", SqlDbType.SmallDateTime, 4).Value = input.fecdocumento;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                    cmd.Parameters.Add("@cdmoneda", SqlDbType.Char, 1).Value = input.cdmoneda;
                    cmd.Parameters.Add("@mtototal", SqlDbType.Decimal, 9).Value = input.mtototal;
                    cmd.Parameters.Add("@nroganador", SqlDbType.Decimal, 5).Value = input.nroganador;
                    cmd.Parameters.Add("@frecuencia", SqlDbType.Decimal, 5).Value = input.frecuencia;

                    cmd.ExecuteNonQuery();
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
        }

        public void SP_ITBCP_ACTUALIZAR_LOTERIAWIN(TS_BELoteriawin input)
        {
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_LOTERIAWIN", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fecha", SqlDbType.SmallDateTime, 4).Value = input.fecha;
                    cmd.Parameters.Add("@item", SqlDbType.Decimal, 5).Value = input.item;
                    cmd.Parameters.Add("@nroseriemaq", SqlDbType.Char, 15).Value = input.nroseriemaq;
                    cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                    cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;
                    cmd.Parameters.Add("@fecdocumento", SqlDbType.SmallDateTime, 4).Value = input.fecdocumento;
                    cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                    cmd.Parameters.Add("@cdmoneda", SqlDbType.Char, 1).Value = input.cdmoneda;
                    cmd.Parameters.Add("@mtototal", SqlDbType.Decimal, 9).Value = input.mtototal;
                    cmd.Parameters.Add("@nroganador", SqlDbType.Decimal, 5).Value = input.nroganador;
                    cmd.Parameters.Add("@frecuencia", SqlDbType.Decimal, 5).Value = input.frecuencia;

                    cmd.ExecuteNonQuery();
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
        }

        public List<TS_BEInsumoCantidad> SP_ITBCP_OBTENER_ARTICULO_INSUMO(string cdarticulo)
        {
            List<TS_BEInsumoCantidad> lista = new List<TS_BEInsumoCantidad>();
            
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_ARTICULO_INSUMO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDARTICULO", SqlDbType.Char, 30).Value = cdarticulo;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            lista.Add(new TS_BEInsumoCantidad()
                            {
                                cantidad = drd.HasColumn("cantidad") ? drd["cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["cantidad"]) : 0,
                                cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? "" : drd["cdarticulo"].ToString().Trim() : "",
                                ctoreposicion = drd.HasColumn("ctoreposicion") ? drd["ctoreposicion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["ctoreposicion"]) : 0,
                                ctopromedio = drd.HasColumn("ctopromedio") ? drd["ctopromedio"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["ctopromedio"]) : 0,
                                precio = drd.HasColumn("precio") ? drd["precio"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["precio"]) : 0,
                            });
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
            return lista;
        }

    }
}