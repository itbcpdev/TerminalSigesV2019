using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Articulo;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;

namespace ITBCP.ServiceSIGES.Infraestructure.DataAcces
{
    public class TS_DATarjeta : ITS_DOTarjeta
    {

        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;
        public List<TS_BETarjeta> Obtener_Tarjetas()
        {
            List<TS_BETarjeta> lista = new List<TS_BETarjeta>();
            TS_BETarjeta output;
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_TIPO_TARJETA", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {



                        while (drd.Read())
                        {
                            output = new TS_BETarjeta();
                            output.cdtarjeta = drd.HasColumn("cdtarjeta") ? drd["cdtarjeta"] == DBNull.Value ? null : drd["cdtarjeta"].ToString() : null;
                            output.dstarjeta = drd.HasColumn("dstarjeta") ? drd["dstarjeta"] == DBNull.Value ? null : drd["dstarjeta"].ToString() : null;
                            output.c_cuenta = drd.HasColumn("c_cuenta") ? drd["c_cuenta"] == DBNull.Value ? null : drd["c_cuenta"].ToString() : null;
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
        public TS_BETarjeta ObtenerTarjeta(TS_BETarjeta input)
        {

            TS_BETarjeta output = new TS_BETarjeta();
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_TIPO_TARJETA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdtarjeta", SqlDbType.Char, 2).Value = input.cdtarjeta;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {

                            output.cdtarjeta = drd.HasColumn("cdtarjeta") ? drd["cdtarjeta"] == DBNull.Value ? null : drd["cdtarjeta"].ToString() : null;
                            output.dstarjeta = drd.HasColumn("dstarjeta") ? drd["dstarjeta"] == DBNull.Value ? null : drd["dstarjeta"].ToString() : null;
                            output.c_cuenta = drd.HasColumn("c_cuenta") ? drd["c_cuenta"] == DBNull.Value ? null : drd["c_cuenta"].ToString() : null;

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
        public List<TS_BEArticulo> LISTAR_ARTICULOS_CANJE(string tarjeta)
        {
            List<TS_BEArticulo> lista = new List<TS_BEArticulo>();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_ARTICULOS_CANJE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TARJETA", SqlDbType.Char, 25).Value = (tarjeta ?? "").Trim();
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BEArticulo Item = new TS_BEArticulo();
                            Item.cdarticulo = (drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? "" : drd["cdarticulo"].ToString() : "").Trim();
                            Item.dsarticulo = (drd.HasColumn("dsarticulo") ? drd["dsarticulo"] == DBNull.Value ? "" : drd["dsarticulo"].ToString() : "").Trim();
                            Item.config = (drd.HasColumn("config") ? drd["config"] == DBNull.Value ? "" : drd["config"].ToString() : "").Trim();
                            Item.valor_acumulado = Item.config.Equals("POR") ? (drd.HasColumn("valorpto") ? drd["valorpto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["valorpto"]) : 0) : 0;
                            Item.valor_puntos = Item.config.Equals("POR") ? 0 : (drd.HasColumn("valorpto") ? drd["valorpto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["valorpto"]) : 0);
                            lista.Add(Item);
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

        public TS_BEArticuloOutput OBTENER_ARTICULOS_POR_PREFIJO(string prefijo)
        {
            TS_BEArticuloOutput Output = new TS_BEArticuloOutput() { Mensaje = "", Ok = true, Articulos = new List<TS_BEArticulo>() };

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_AFILIACION_LISTAR_ARTICULO_POR_PREFIJO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PREFIJO", SqlDbType.Char, 25).Value = (prefijo ?? "").Trim();
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BEArticulo Item = new TS_BEArticulo();
                            Item.cdarticulo = (drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? "" : drd["cdarticulo"].ToString() : "").Trim();
                            Item.dsarticulo = (drd.HasColumn("dsarticulo") ? drd["dsarticulo"] == DBNull.Value ? "" : drd["dsarticulo"].ToString() : "").Trim();
                            Item.config = (drd.HasColumn("config") ? drd["config"] == DBNull.Value ? "" : drd["config"].ToString() : "").Trim();
                            Item.valor_acumulado = Item.config.Equals("POR") ? (drd.HasColumn("valorpto") ? drd["valorpto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["valorpto"]) : 0) : 0;
                            Item.valor_puntos = Item.config.Equals("POR") ? 0 : (drd.HasColumn("valorpto") ? drd["valorpto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["valorpto"]) : 0);
                            Item.valorid = drd.HasColumn("id") ? drd["id"] == DBNull.Value ? 0 : Convert.ToInt32(drd["id"]) : 0;
                            Output.Articulos.Add(Item);
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
            return Output;
        }
        public TS_BEArticuloOutput OBTENER_ARTICULOS_POR_TARJETA(string tarjeta)
        {
            TS_BEArticuloOutput Output = new TS_BEArticuloOutput() { Mensaje = "", Ok = true, Articulos = new List<TS_BEArticulo>() };

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_AFILIACION_LISTAR_ARTICULO_POR_TARJETA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TARJETA", SqlDbType.Char, 25).Value = (tarjeta ?? "").Trim();
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BEArticulo Item = new TS_BEArticulo();
                            Item.cdarticulo = (drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? "" : drd["cdarticulo"].ToString() : "").Trim();
                            Item.dsarticulo = (drd.HasColumn("dsarticulo") ? drd["dsarticulo"] == DBNull.Value ? "" : drd["dsarticulo"].ToString() : "").Trim();
                            Item.config = (drd.HasColumn("config") ? drd["config"] == DBNull.Value ? "" : drd["config"].ToString() : "").Trim();
                            Item.valor_acumulado = Item.config.Equals("POR") ? (drd.HasColumn("valorpto") ? drd["valorpto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["valorpto"]) : 0) : 0;
                            Item.valor_puntos = Item.config.Equals("POR") ? 0 : (drd.HasColumn("valorpto") ? drd["valorpto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["valorpto"]) : 0);
                            Item.valorid = drd.HasColumn("id") ? drd["id"] == DBNull.Value ? 0 : Convert.ToInt32(drd["id"]) : 0;
                            Output.Articulos.Add(Item);
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
            return Output;
        }
    }
}
