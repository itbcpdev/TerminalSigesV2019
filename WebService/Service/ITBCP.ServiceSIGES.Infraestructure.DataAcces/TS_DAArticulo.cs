using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Articulo;
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
    public class TS_DAArticulo : ITS_DOArticulo
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public List<TS_BEArticulo> SP_ITBCP_LISTAR_ARTICULO_POR_GRUPO_COMBUSTIBLE(string cdgrupo02)
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
                    cmd.Parameters.Add("@cdgrupo02", SqlDbType.Char, 5).Value = cdgrupo02;

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
                            output.impuesto_plastico = drd.HasColumn("impplastico") ? drd["impplastico"] == DBNull.Value ? false : Convert.ToBoolean(drd["impplastico"]) : false;
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
        public TS_BEArticulo ObtenerArticulByCodigo(string cdarticulo)
        {

            TS_BEArticulo output = new TS_BEArticulo();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_ARTICULO_POR_CODIGO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = cdarticulo;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {

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
                            output.cdmedequiv = drd.HasColumn("cdmedequiv") ? drd["cdmedequiv"] == DBNull.Value ? "" : drd["cdmedequiv"].ToString() : "";
                            output.cdamarre = drd.HasColumn("cdamarre") ? drd["cdamarre"] == DBNull.Value ? null : drd["cdamarre"].ToString() : null;
                            output.tpconversion = drd.HasColumn("tpconversion") ? drd["tpconversion"] == DBNull.Value ? null : drd["tpconversion"].ToString() : null;
                            output.cdgrupo04 = drd.HasColumn("cdgrupo04") ? drd["cdgrupo04"] == DBNull.Value ? null : drd["cdgrupo04"].ToString() : null;
                            output.cdgrupo05 = drd.HasColumn("cdgrupo05") ? drd["cdgrupo05"] == DBNull.Value ? null : drd["cdgrupo05"].ToString() : null;
                            output.cdunimed = drd.HasColumn("cdunimed") ? drd["cdunimed"] == DBNull.Value ? null : drd["cdunimed"].ToString() : null;
                            output.cdtalla = drd.HasColumn("cdtalla") ? drd["cdtalla"] == DBNull.Value ? null : drd["cdtalla"].ToString() : null;
                            output.tpformula = drd.HasColumn("tpformula") ? drd["tpformula"] == DBNull.Value ? null : drd["tpformula"].ToString() : null;
                            output.monctoinicial = drd.HasColumn("monctoinicial") ? drd["monctoinicial"] == DBNull.Value ? null : drd["monctoinicial"].ToString() : null;
                            output.impuesto_plastico = drd.HasColumn("impplastico") ? drd["impplastico"] == DBNull.Value ? false : Convert.ToBoolean(drd["impplastico"]) : false;

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
        public List<TS_BEArticulo> SP_ITBCP_LISTAR_ARTICULO(string cdgrupo02)
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
                    cmd.Parameters.Add("@cdgrupo02", SqlDbType.Char, 5).Value = cdgrupo02;

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
                            output.impuesto_plastico = drd.HasColumn("impplastico") ? drd["impplastico"] == DBNull.Value ? false : Convert.ToBoolean(drd["impplastico"]) : false;
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
        public List<TS_BEArticulo> SP_ITBCP_LISTAR_ARTICULOS(string cdgrupo02)
        {
            List<TS_BEArticulo> lista = new List<TS_BEArticulo>();
            TS_BEArticulo output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_ARTICULOS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdgrupo02", SqlDbType.Char, 5).Value = cdgrupo02;

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
                            output.impuesto_plastico = drd.HasColumn("impplastico") ? drd["impplastico"] == DBNull.Value ? false : Convert.ToBoolean(drd["impplastico"]) : false;
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
        public List<TS_BEArticulo> ListarArticuloPrecios(string glosa)
        {
            List<TS_BEArticulo> lista = new List<TS_BEArticulo>();
            TS_BEArticulo output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_PRODUCTOS_PRECIOS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@INFORMACION", SqlDbType.VarChar, 30).Value = (glosa ?? "").Trim();

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEArticulo();

                            output.cdarticulo = drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? null : drd["cdarticulo"].ToString() : null;
                            output.precio = drd.HasColumn("mtoprecio") ? drd["mtoprecio"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtoprecio"]) : 0;
                            output.precio_orig = drd.HasColumn("mtoprecio") ? drd["mtoprecio"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtoprecio"]) : 0;
                            output.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["impuesto"]) : 0;
                            output.dsarticulo = drd.HasColumn("dsarticulo") ? drd["dsarticulo"] == DBNull.Value ? null : drd["dsarticulo"].ToString() : null;
                            output.moverstock = drd.HasColumn("moverstock") ? drd["moverstock"] == DBNull.Value ? false : Convert.ToBoolean(drd["moverstock"]) : false;
                            output.trfgratuita = drd.HasColumn("trfgratuita") ? drd["trfgratuita"] == DBNull.Value ? false : Convert.ToBoolean(drd["trfgratuita"]) : false;
                            output.dsarticulo1 = drd.HasColumn("dsarticulo1") ? drd["dsarticulo1"] == DBNull.Value ? null : drd["dsarticulo1"].ToString() : null;
                            output.cdgrupo01 = drd.HasColumn("cdgrupo01") ? drd["cdgrupo01"] == DBNull.Value ? null : drd["cdgrupo01"].ToString() : null;
                            output.costo = drd.HasColumn("ctoreposicion") ? drd["ctoreposicion"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["ctoreposicion"]) : 0;
                            output.cdunimed = drd.HasColumn("cdunimed") ? drd["cdunimed"] == DBNull.Value ? null : drd["cdunimed"].ToString() : null;
                            output.tpformula = drd.HasColumn("tpformula") ? drd["tpformula"] == DBNull.Value ? null : drd["tpformula"].ToString() : null;
                            output.cdarticulosunat = drd.HasColumn("cdarticulosunat") ? drd["cdarticulosunat"] == DBNull.Value ? null : drd["cdarticulosunat"].ToString() : null;
                            output.impuesto_plastico = drd.HasColumn("impplastico") ? drd["impplastico"] == DBNull.Value ? false : Convert.ToBoolean(drd["impplastico"]) : false;
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
    }
}
