using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
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
    public class TS_DAOpTransaction : ITS_DOOpTransaction
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public List<TS_BEArticulo> LISTAR_TRANSACTIONS(TS_BEOp_Tran input)
        {
            List<TS_BEArticulo> lista = new List<TS_BEArticulo>();
            TS_BEArticulo output;
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
                            output = new TS_BEArticulo();
                            output.manguera = drd.HasColumn("manguera") ? drd["manguera"] == DBNull.Value ? "" : drd["manguera"].ToString() : "";
                            //output.fecha = drd.HasColumn("fecha") ? drd["fecha"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecha"]) : (DateTime?)null;
                            //output.orden = drd.HasColumn("fecha") ? drd["fecha"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecha"]) : (DateTime?)null;
                            output.hora = drd.HasColumn("hora") ? drd["hora"] == DBNull.Value ? null : (drd["hora"].ToString()) : null;
                            output.total = drd.HasColumn("soles") ? drd["soles"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["soles"]) : 0;
                            output.total_display = drd.HasColumn("soles") ? drd["soles"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["soles"]) : 0;
                            output.precio = drd.HasColumn("precio") ? drd["precio"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["precio"]) : 0;
                            output.cantidad = drd.HasColumn("galones") ? drd["galones"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["galones"]) : 0;
                            //output.documento = drd.HasColumn("documento") ? drd["documento"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["documento"]) : 0;
                            output.nrogasboy = drd.HasColumn("numero") ? drd["numero"] == DBNull.Value ? null : drd["numero"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.cara = drd.HasColumn("cara") ? drd["cara"] == DBNull.Value ? null : drd["cara"].ToString() : null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? null : drd["turno"].ToString() : null;
                            output.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["impuesto"]) : 0;
                            output.dsarticulo = drd.HasColumn("dsarticulo") ? drd["dsarticulo"] == DBNull.Value ? null : drd["dsarticulo"].ToString() : null;
                            output.moverstock = drd.HasColumn("moverstock") ? drd["moverstock"] == DBNull.Value ? false : Convert.ToBoolean(drd["moverstock"]) : false;
                            output.dsarticulo1 = drd.HasColumn("dsarticulo1") ? drd["dsarticulo1"] == DBNull.Value ? null : drd["dsarticulo1"].ToString() : null;
                            output.porcpercepcion = drd.HasColumn("porcpercepcion") ? drd["porcpercepcion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["porcpercepcion"]) : 0;
                            output.cdgrupo01 = drd.HasColumn("cdgrupo01") ? drd["cdgrupo01"] == DBNull.Value ? null : drd["cdgrupo01"].ToString() : null;
                            //output. = drd.HasColumn("monctorepo") ? drd["monctorepo"] == DBNull.Value ? null : drd["monctorepo"].ToString() : null;
                            output.costo = drd.HasColumn("ctoreposicion") ? drd["ctoreposicion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["ctoreposicion"]) : 0;
                            //output.tpconversion = drd.HasColumn("tpconversion") ? drd["tpconversion"] == DBNull.Value ? null : drd["tpconversion"].ToString() : null;
                            //output.valorconversion = drd.HasColumn("valorconversion") ? drd["valorconversion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["valorconversion"]) : 0;
                            output.trfgratuita = drd.HasColumn("trfgratuita") ? drd["trfgratuita"] == DBNull.Value ? false : Convert.ToBoolean(drd["trfgratuita"]) : false;
                            output.cdunimed = drd.HasColumn("cdunimed") ? drd["cdunimed"] == DBNull.Value ? null : drd["cdunimed"].ToString() : null;
                            output.cdarticulosunat = drd.HasColumn("cdarticulosunat") ? drd["cdarticulosunat"] == DBNull.Value ? null : drd["cdarticulosunat"].ToString() : null;
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

        public List<TS_BEArticulo> LISTAR_TRANSACTION(TS_BEOp_Tran input)
        {
            List<TS_BEArticulo> lista = new List<TS_BEArticulo>();
            TS_BEArticulo output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_TRANSACCION_ARTICULO_AUTOMATIC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cara", SqlDbType.Char, 2).Value = input.cara;
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEArticulo();
                            output.manguera = drd.HasColumn("manguera") ? drd["manguera"] == DBNull.Value ? "" : drd["manguera"].ToString() : "";
                            //output.fecha = drd.HasColumn("fecha") ? drd["fecha"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecha"]) : (DateTime?)null;
                            //output.orden = drd.HasColumn("fecha") ? drd["fecha"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecha"]) : (DateTime?)null;
                            output.hora = drd.HasColumn("hora") ? drd["hora"] == DBNull.Value ? null : (drd["hora"].ToString()) : null;
                            output.total = drd.HasColumn("soles") ? drd["soles"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["soles"]) : 0;
                            output.total_display = drd.HasColumn("soles") ? drd["soles"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["soles"]) : 0;
                            output.precio = drd.HasColumn("precio") ? drd["precio"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["precio"]) : 0;
                            output.cantidad = drd.HasColumn("galones") ? drd["galones"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["galones"]) : 0;
                            //output.documento = drd.HasColumn("documento") ? drd["documento"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["documento"]) : 0;
                            output.nrogasboy = drd.HasColumn("numero") ? drd["numero"] == DBNull.Value ? null : drd["numero"].ToString() : null;
                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.cara = drd.HasColumn("cara") ? drd["cara"] == DBNull.Value ? null : drd["cara"].ToString() : null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? null : drd["turno"].ToString() : null;
                            output.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["impuesto"]) : 0;
                            output.dsarticulo = drd.HasColumn("dsarticulo") ? drd["dsarticulo"] == DBNull.Value ? null : drd["dsarticulo"].ToString() : null;
                            output.moverstock = drd.HasColumn("moverstock") ? drd["moverstock"] == DBNull.Value ? false : Convert.ToBoolean(drd["moverstock"]) : false;
                            output.dsarticulo1 = drd.HasColumn("dsarticulo1") ? drd["dsarticulo1"] == DBNull.Value ? null : drd["dsarticulo1"].ToString() : null;
                            output.porcpercepcion = drd.HasColumn("porcpercepcion") ? drd["porcpercepcion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["porcpercepcion"]) : 0;
                            output.cdgrupo01 = drd.HasColumn("cdgrupo01") ? drd["cdgrupo01"] == DBNull.Value ? null : drd["cdgrupo01"].ToString() : null;
                            //output. = drd.HasColumn("monctorepo") ? drd["monctorepo"] == DBNull.Value ? null : drd["monctorepo"].ToString() : null;
                            output.costo = drd.HasColumn("ctoreposicion") ? drd["ctoreposicion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["ctoreposicion"]) : 0;
                            //output.tpconversion = drd.HasColumn("tpconversion") ? drd["tpconversion"] == DBNull.Value ? null : drd["tpconversion"].ToString() : null;
                            //output.valorconversion = drd.HasColumn("valorconversion") ? drd["valorconversion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["valorconversion"]) : 0;
                            output.trfgratuita = drd.HasColumn("trfgratuita") ? drd["trfgratuita"] == DBNull.Value ? false : Convert.ToBoolean(drd["trfgratuita"]) : false;
                            output.cdunimed = drd.HasColumn("cdunimed") ? drd["cdunimed"] == DBNull.Value ? null : drd["cdunimed"].ToString() : null;
                            output.cdarticulosunat = drd.HasColumn("cdarticulosunat") ? drd["cdarticulosunat"] == DBNull.Value ? null : drd["cdarticulosunat"].ToString() : null;
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

        public List<TS_BEOp_Tran> LISTAR_TRANSACTIONS_PENDIENTES(TS_BEOp_Tran input)
        {
            List<TS_BEOp_Tran> lista = new List<TS_BEOp_Tran>();
            TS_BEOp_Tran output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_TRANSACCION_PENDIENTE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cara", SqlDbType.Char, 2).Value = input.cara;
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEOp_Tran();
                            output.manguera = drd.HasColumn("manguera") ? drd["manguera"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["manguera"]) : (int?)null;
                            output.fecha = drd.HasColumn("fecha") ? drd["fecha"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecha"]) : (DateTime?)null;
                            output.hora = drd.HasColumn("hora") ? drd["hora"] == DBNull.Value ? null : (drd["hora"].ToString()) : null;
                            output.dateproce = drd.HasColumn("dateproce") ? drd["dateproce"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["dateproce"]) : (DateTime?)null;
                            output.fecsistema = drd.HasColumn("fecsistema") ? drd["fecsistema"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecsistema"]) : (DateTime?)null;
                            output.soles = drd.HasColumn("soles") ? drd["soles"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["soles"]) : (decimal?)null;
                            output.precio = drd.HasColumn("precio") ? drd["precio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio"]) : (decimal?)null;
                            output.galones = drd.HasColumn("galones") ? drd["galones"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["galones"]) : (decimal?)null;
                            output.documento = drd.HasColumn("documento") ? drd["documento"] == DBNull.Value ? null : (drd["documento"].ToString()) : null;
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

        public bool UpdateTransOpTransaction(string gasboy, string tipoDocumento, string nroDocumento, DateTime? fecProceso, SqlTransaction pSqlTransaction)
        {
            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_OPTRAN")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = pSqlTransaction.Connection,
                    Transaction = pSqlTransaction
                };
                cmd.Parameters.Clear();                
                cmd.Parameters.Add("@numero", SqlDbType.VarChar, 20).Value = gasboy;               
                cmd.Parameters.Add("@cdtipodoc", SqlDbType.VarChar, 5).Value = tipoDocumento;
                cmd.Parameters.Add("@documento", SqlDbType.VarChar, 10).Value = nroDocumento;
                cmd.Parameters.Add("@dateproce", SqlDbType.SmallDateTime, 4).Value = fecProceso;
                flag = cmd.ExecuteNonQuery() > 0;
                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;

        }

        public List<TS_BEArticulo> LISTAR_TRANSACTION_MANUAL()
        {
            List<TS_BEArticulo> Lista = new List<TS_BEArticulo>();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_PRODUCTOS_COMBUSTIBLE", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            Lista.Add(new TS_BEArticulo()
                            {
                                cdarticulo = (drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? "" : drd["cdarticulo"].ToString() : "").Trim(),
                                precio = drd.HasColumn("mtoprecio") ? drd["mtoprecio"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtoprecio"]) : 0,
                                precio_orig = drd.HasColumn("mtoprecio") ? drd["mtoprecio"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtoprecio"]) : 0,
                                impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["impuesto"]) : 0,
                                dsarticulo = (drd.HasColumn("dsarticulo") ? drd["dsarticulo"] == DBNull.Value ? "" : drd["dsarticulo"].ToString() : "").Trim(),
                                moverstock = drd.HasColumn("moverstock") ? drd["moverstock"] == DBNull.Value ? false : Convert.ToBoolean(drd["moverstock"]) : false,
                                trfgratuita = drd.HasColumn("trfgratuita") ? drd["trfgratuita"] == DBNull.Value ? false : Convert.ToBoolean(drd["trfgratuita"]) : false,
                                dsarticulo1 = (drd.HasColumn("dsarticulo1") ? drd["dsarticulo1"] == DBNull.Value ? "" : drd["dsarticulo1"].ToString() : "").Trim(),
                                cdgrupo01 = (drd.HasColumn("cdgrupo01") ? drd["cdgrupo01"] == DBNull.Value ? "" : drd["cdgrupo01"].ToString() : "").Trim(),
                                costo = drd.HasColumn("ctoreposicion") ? drd["ctoreposicion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["ctoreposicion"]) : 0,
                                cdunimed = (drd.HasColumn("cdunimed") ? drd["cdunimed"] == DBNull.Value ? "" : drd["cdunimed"].ToString() : "N/A").Trim(),
                                cdarticulosunat = (drd.HasColumn("cdarticulosunat") ? drd["cdarticulosunat"] == DBNull.Value ? "" : drd["cdarticulosunat"].ToString() : "").Trim(),
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
            return Lista;
        }
    }
}
