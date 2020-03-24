using ITBCP.ServiceSIGES.Aplication.Interfaces;
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
    public class TS_DACliente : ITS_DOCliente
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public TS_BEClienteOutput ObtenerClienteByCodigo(TS_BEClienteSearch input)
        {

            TS_BEClienteOutput output = new TS_BEClienteOutput();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_CLIENTE_POR_CODIGO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 20).Value = input.Codigo;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {

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
                            output.bloqueado = drd.HasColumn("bloqueado") ? drd["bloqueado"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqueado"]) : false;
                            output.baja = drd.HasColumn("baja") ? drd["baja"] == DBNull.Value ? false : Convert.ToBoolean(drd["baja"]) : false;
                            output.isafiliacion = drd.HasColumn("isafiliacion") ? drd["isafiliacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["isafiliacion"]) : false;
                            output.puntos = drd.HasColumn("puntos") ? drd["puntos"] == DBNull.Value ? 0 : Convert.ToInt32(drd["puntos"]) : 0;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["valoracumula"]) : 0;
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
        public TS_BESaldoclid ObtenerSaldoClientTarjeta(TS_BEClienteSearch input)
        {

            TS_BESaldoclid output = new TS_BESaldoclid(); ;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_SALDOCLID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nrotarjeta", SqlDbType.Char, 20).Value = input.Codigo;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {

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
        public List<TS_BESaldoclid> ListarSaldoClientTarjeta(TS_BEClienteSearch input)
        {
            List<TS_BESaldoclid> lista = new List<TS_BESaldoclid>();
            TS_BESaldoclid output = new TS_BESaldoclid(); ;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_SALDOCLID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nrotarjeta", SqlDbType.Char, 20).Value = input.NroTarjeta;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {

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
        public TS_BESaldoclic ObtenerSaldoClientebyCodigo(TS_BEClienteSearch input)
        {
            //List<TS_BESaldoclic> lista = new List<TS_BESaldoclic>();
            TS_BESaldoclic output = new TS_BESaldoclic();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_SALDO_CLIENTE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 15).Value = input.Codigo;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {

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

                            //  lista.Add(output);
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
        public List<TS_BEClienteOutput> ListarClienteByCodigo(TS_BEClienteSearch input)
        {
            List<TS_BEClienteOutput> lista = new List<TS_BEClienteOutput>();
            TS_BEClienteOutput output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_CLIENTE_POR_CODIGO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 20).Value = input.Codigo;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEClienteOutput();
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
                            output.flgmostrarsaldo = drd.HasColumn("flgmostrarsaldo") ? drd["flgmostrarsaldo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmostrarsaldo"]) : false;
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
        public List<TS_BEClienteLista> ListarClientes()
        {
            List<TS_BEClienteLista> lista = new List<TS_BEClienteLista>();
            TS_BEClienteLista output = new TS_BEClienteLista();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_CLIENTES", con);
                    cmd.CommandType = CommandType.StoredProcedure;                    

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEClienteLista();
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.ruccliente = drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? null : drd["ruccliente"].ToString() : null;
                            output.rscliente = drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? null : drd["rscliente"].ToString() : null;
                            output.drcliente = drd.HasColumn("drcliente") ? drd["drcliente"] == DBNull.Value ? null : drd["drcliente"].ToString() : null;
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
        public TS_BEGestionFlotaC ObtenerGestionFlotaC(TS_BEGestionFlotaC input)
        {
            TS_BEGestionFlotaC output = new TS_BEGestionFlotaC(); ;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_GESTIONFLOTAC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 20).Value = input.cdcliente;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output.fechainicio = drd.HasColumn("fechainicio ") ? drd["fechainicio "] == DBNull.Value ? DateTime.MinValue : (DateTime)(drd["fechainicio "]) : DateTime.MinValue;
                            output.flgbloquea = drd.HasColumn("flgbloquea") ? drd["flgbloquea"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgbloquea"]) : false;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.NroContrato = drd.HasColumn("NroContrato") ? drd["NroContrato"] == DBNull.Value ? null : drd["NroContrato"].ToString() : null;
                            output.cdgrupoID = drd.HasColumn("cdgrupoID") ? drd["cdgrupoID"] == DBNull.Value ? 0 : Convert.ToInt32(drd["cdgrupoID"]) : 0;
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
        public TS_BEGestionFlotaD ObtenerGestionFlotaD(TS_BEGestionFlotaD input)
        {
            TS_BEGestionFlotaD output = new TS_BEGestionFlotaD(); ;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_GESTIONFLOTAD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nrotarjeta", SqlDbType.Char, 20).Value = input.nrotarjeta;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output.flgbloquea = drd.HasColumn("flgbloquea") ? drd["flgbloquea"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgbloquea"]) : false;
                            output.cdcliente = drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? null : drd["cdcliente"].ToString() : null;
                            output.nrotarjeta = drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? null : drd["nrotarjeta"].ToString() : null;
                            output.nrobonus = drd.HasColumn("nrobonus") ? drd["nrobonus"] == DBNull.Value ? null : drd["nrobonus"].ToString() : null;
                            output.nroplaca = drd.HasColumn("nroplaca") ? drd["nroplaca"] == DBNull.Value ? null : drd["nroplaca"].ToString() : null;

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
        public List<TS_BEDepartamento> ListarDepartamentos()
        {
            List<TS_BEDepartamento> lista = new List<TS_BEDepartamento>();
            TS_BEDepartamento output = new TS_BEDepartamento(); ;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_DEPARTAMENTO", con);
                    cmd.CommandType = CommandType.StoredProcedure; 

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        { 
                            output.FlgAfecto = drd.HasColumn("FlgAfecto") ? drd["FlgAfecto"] == DBNull.Value ? false : Convert.ToBoolean(drd["FlgAfecto"]) : false; 
                            output.cddepartamento = drd.HasColumn("cddepartamento") ? drd["cddepartamento"] == DBNull.Value ? null : drd["cddepartamento"].ToString() : null;
                            output.dsdepartamento = drd.HasColumn("dsdepartamento") ? drd["dsdepartamento"] == DBNull.Value ? null : drd["dsdepartamento"].ToString() : null;                           

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
        public TS_BEMensaje InsertTransCliente(TS_BEClienteInput input, SqlTransaction pSqlTransaction)
        {
            TS_BEMensaje Respuesta = new TS_BEMensaje();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_CLIENTE")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = pSqlTransaction.Connection,
                    Transaction = pSqlTransaction
                };
                cmd.Parameters.Clear();
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
                cmd.Parameters.Add("@fecnacimiento", SqlDbType.SmallDateTime, 4).Value = null;
                cmd.Parameters.Add("@cdalmacen", SqlDbType.Char, 3).Value = input.cdalmacen;
                cmd.Parameters.Add("@diascredito", SqlDbType.Int, 4).Value = input.diascredito;
                cmd.Parameters.Add("@CDGRUPOCLI", SqlDbType.Char, 5).Value = input.cdgrupocli;
                cmd.Parameters.Add("@Sunat_Actualiza", SqlDbType.TinyInt, 1).Value = input.sunat_actualiza;
                cmd.Parameters.Add("@cliente", SqlDbType.VarChar, 60).Value = input.cliente;
                cmd.Parameters.Add("@contacto", SqlDbType.VarChar, 60).Value = input.contacto;
                cmd.Parameters.Add("@fecha_creacion", SqlDbType.SmallDateTime, 4).Value = DateTime.Now;
                cmd.Parameters.Add("@DIASMAX_ND", SqlDbType.Int, 4).Value = input.diasmax_nd;
                cmd.Parameters.Add("@GRUPORUTA", SqlDbType.Char, 10).Value = input.gruporuta;
                cmd.Parameters.Add("@flgpreciond", SqlDbType.Bit, 1).Value = input.flgpreciond;
                cmd.Parameters.Add("@consulta_sunat", SqlDbType.Bit, 1).Value = input.consulta_sunat;
                cmd.Parameters.Add("@flg_pideclave", SqlDbType.Bit, 1).Value = input.flg_pideclave;
                cmd.Parameters.Add("@flgtotalnd", SqlDbType.Bit, 1).Value = input.flgtotalnd;
                Respuesta.Ok = cmd.ExecuteNonQuery() > 0;
                Respuesta.mensaje = Respuesta.Ok ? "" : "Error al registrar el cliente";
            }
            catch (Exception exception)
            {
              
                throw exception;
            }
            return Respuesta;
        }
        public TS_BEMensaje InsertTransClientePlaca(TS_BEClienteInput cCliente,TS_BECabecera cCabecera, SqlTransaction pSqlTransaction)
        {
            TS_BEMensaje Respuesta = new TS_BEMensaje();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_PLACA")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = pSqlTransaction.Connection,
                    Transaction = pSqlTransaction
                };
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@PLACA", SqlDbType.VarChar, 10).Value = cCabecera.nroplaca;
                cmd.Parameters.Add("@CDCLIENTE", SqlDbType.VarChar, 20).Value = cCabecera.cdcliente;
                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar, 50).Value = "";
                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar, 50).Value = "";
                cmd.Parameters.Add("@COLOR", SqlDbType.VarChar, 50).Value = "";
                cmd.Parameters.Add("@YEAR", SqlDbType.Decimal, 4).Value = 0;
                cmd.Parameters.Add("@NROSERIE", SqlDbType.VarChar, 40).Value = "";
                cmd.Parameters.Add("@NROMOTOR", SqlDbType.VarChar, 40).Value = "";
                cmd.Parameters.Add("@KILOMETRAJE", SqlDbType.Decimal, 8).Value = 0;
                Respuesta.Ok = cmd.ExecuteNonQuery() > 0;
                Respuesta.mensaje = Respuesta.Ok ? "" : "ERROR AL REGISTRAR LA PLACA";
            }
            catch (Exception exception)
            {

                throw exception;
            }
            return Respuesta;
        }
        public TS_BEClienteCreditoOutput OBTENER_CLIENTE_CREDITO_LOCAL(string nrotarjeta)
        {
            TS_BEClienteCreditoOutput cCliente = new TS_BEClienteCreditoOutput();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_CLIENTE_CREDITO_LOCAL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NROTARJETA", SqlDbType.Char, 20).Value = nrotarjeta;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        if(drd.HasRows)
                        {
                            cCliente.Mensaje = new TS_BEMensaje("", true);
                        }
                        else
                        {
                            cCliente.Mensaje = new TS_BEMensaje("El cliente no existe", false);
                        }
                        while (drd.Read())
                        {
                            cCliente.cdcliente = (drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? "" : drd["cdcliente"].ToString() : "").Trim();
                            cCliente.nrotarjeta = (drd.HasColumn("nrotarjeta") ? drd["nrotarjeta"] == DBNull.Value ? "" : drd["nrotarjeta"].ToString() : "").Trim();
                            cCliente.cdgrupo02 = (drd.HasColumn("cdgrupo02") ? drd["cdgrupo02"] == DBNull.Value ? "" : drd["cdgrupo02"].ToString() : "").Trim();
                            cCliente.cdarticulo = (drd.HasColumn("cdarticulo") ? drd["cdarticulo"] == DBNull.Value ? "" : drd["cdarticulo"].ToString() : "").Trim();
                            cCliente.limitemto = drd.HasColumn("limitemto") ? drd["limitemto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["limitemto"]) : 0;
                            cCliente.consumto = drd.HasColumn("consumto") ? drd["consumto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["consumto"]) : 0;
                            cCliente.nrobonus = (drd.HasColumn("nrobonus") ? drd["nrobonus"] == DBNull.Value ? "" : drd["nrobonus"].ToString() : "").Trim();
                            cCliente.nroplaca = (drd.HasColumn("nroplaca") ? drd["nroplaca"] == DBNull.Value ? "" : drd["nroplaca"].ToString() : "").Trim();
                            cCliente.flgilimit = drd.HasColumn("flgilimit") ? drd["flgilimit"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgilimit"]) : false;
                            cCliente.flgbloquea = drd.HasColumn("flgbloquea") ? drd["flgbloquea"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgbloquea"]) : false;
                            cCliente.nrocontrato = (drd.HasColumn("nrocontrato") ? drd["nrocontrato"] == DBNull.Value ? "" : drd["nrocontrato"].ToString() : "").Trim();
                            cCliente.tpsaldo = (drd.HasColumn("tpsaldo") ? drd["tpsaldo"] == DBNull.Value ? "" : drd["tpsaldo"].ToString() : "").Trim();
                            cCliente.consumtoC = drd.HasColumn("consumtoC") ? drd["consumtoC"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["consumtoC"]) : 0;
                            cCliente.flgbloqueaC = drd.HasColumn("flgbloqueaC") ? drd["flgbloqueaC"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgbloqueaC"]) : false;
                            cCliente.limitemtoC = drd.HasColumn("limitemtoC") ? drd["limitemtoC"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["limitemtoC"]) : 0;
                            cCliente.flgilimitC = drd.HasColumn("flgilimitC") ? drd["flgilimitC"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgilimitC"]) : false;
                            cCliente.ruc = (drd.HasColumn("ruc") ? drd["ruc"] == DBNull.Value ? "" : drd["ruc"].ToString() : "").Trim();
                            cCliente.razonsocial = (drd.HasColumn("razonsocial") ? drd["razonsocial"] == DBNull.Value ? "" : drd["razonsocial"].ToString() : "").Trim();
                            cCliente.direccion = (drd.HasColumn("direccion") ? drd["direccion"] == DBNull.Value ? "" : drd["direccion"].ToString() : "").Trim();
                            cCliente.nrocontrato1 = (drd.HasColumn("nrocontrato1") ? drd["nrocontrato1"] == DBNull.Value ? "" : drd["nrocontrato1"].ToString() : "").Trim();
                            cCliente.tipodespacho = (drd.HasColumn("tipodespacho") ? drd["tipodespacho"] == DBNull.Value ? "" : drd["tipodespacho"].ToString() : "").Trim();
                            cCliente.tipocli = "L";
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
            return cCliente;
        }
        public bool UPDATE_SALDO_CLIENTE_LOCAL(TS_BECabecera cCabecera, TS_BEClienteInput cCliente,SqlTransaction pSqlTransaction,Decimal cantidad)
        {
            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_SALDO_CLIENTE_LOCAL")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = pSqlTransaction.Connection,
                    Transaction = pSqlTransaction
                };
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@NROTARJETA", SqlDbType.VarChar, 25).Value = cCliente.nroTarjeta;
                cmd.Parameters.Add("@CDCLIENTE", SqlDbType.VarChar, 25).Value = cCliente.cdcliente;
                cmd.Parameters.Add("@TIPOCLIENTE", SqlDbType.Char, 5).Value = cCliente.tipocli;
                cmd.Parameters.Add("@TOTAL", SqlDbType.Decimal, 20).Value = cCabecera.mtototal;
                cmd.Parameters.Add("@CANTIDAD", SqlDbType.Decimal, 20).Value = cantidad;
                flag = cmd.ExecuteNonQuery() > 0;
                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;
        }
        public List<TS_BEPTarjeta> LISTA_TARJETA_PREFIJOS()
        {
            List<TS_BEPTarjeta> cPrefijosTarjeta = new List<TS_BEPTarjeta>();

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_TARJETA_PREFIJO", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BEPTarjeta cPrefijoTarjeta = new TS_BEPTarjeta();
                            cPrefijoTarjeta.varid       = (drd.HasColumn("varid")       ? drd["varid"]       == DBNull.Value ? "" : drd["varid"].ToString() : ""      ).Trim();
                            cPrefijoTarjeta.tipo        = (drd.HasColumn("tipo")        ? drd["tipo"]        == DBNull.Value ? "" : drd["tipo"].ToString() : ""       ).Trim();
                            cPrefijoTarjeta.prefijo     = (drd.HasColumn("prefijo")     ? drd["prefijo"]     == DBNull.Value ? "" : drd["prefijo"].ToString() : ""    ).Trim();
                            cPrefijoTarjeta.descripcion = (drd.HasColumn("descripcion") ? drd["descripcion"] == DBNull.Value ? "" : drd["descripcion"].ToString() : "").Trim();
                            cPrefijosTarjeta.Add(cPrefijoTarjeta);
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
            return cPrefijosTarjeta;
        }
        public TS_BEClienteOutput ObtenerClienteByTarjeta(TS_BEClienteSearch input)
        {

            TS_BEClienteOutput output = new TS_BEClienteOutput();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_CLIENTE_POR_TARJETA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDTARJETA", SqlDbType.Char, 30).Value = input.NroTarjeta;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        if (drd.HasRows)
                        {
                            output.Mensaje = "";
                            output.Ok = true;
                        }
                        else
                        {
                            output.Mensaje = "Tarjeta no existe";
                            output.Ok = false;
                        }
                        while (drd.Read())
                        {

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
                            output.bloqueado = drd.HasColumn("bloqueado") ? drd["bloqueado"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqueado"]) : false;
                            output.baja = drd.HasColumn("baja") ? drd["baja"] == DBNull.Value ? false : Convert.ToBoolean(drd["baja"]) : false;
                            output.isafiliacion = drd.HasColumn("isafiliacion") ? drd["isafiliacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["isafiliacion"]) : false;
                            output.puntos = drd.HasColumn("puntos") ? drd["puntos"] == DBNull.Value ? 0 : Convert.ToInt32(drd["puntos"]) : 0;
                            output.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["valoracumula"]) : 0;
                            output.tarjafiliacion = drd.HasColumn("tarjafiliacion") ? drd["tarjafiliacion"] == DBNull.Value ? "" : drd["tarjafiliacion"].ToString() : "";
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
        public List<TS_BEClienteLista> ListarClientesByName(string rscliente)
        {
            List<TS_BEClienteLista> lista = new List<TS_BEClienteLista>();

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_CLIENTE_POR_NOMBRE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RAZONSOCIAL", SqlDbType.VarChar, 100).Value = rscliente;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            lista.Add(new TS_BEClienteLista()
                            {
                                cdcliente = (drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? "" : drd["cdcliente"].ToString() : "").Trim(),
                                rscliente = (drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? "" : drd["rscliente"].ToString() : "").Trim(),
                                drcliente = (drd.HasColumn("drcliente") ? drd["drcliente"] == DBNull.Value ? "" : drd["drcliente"].ToString() : "").Trim(),
                                ruccliente = (drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? "" : drd["ruccliente"].ToString() : "").Trim(),
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
        public List<TS_BEClienteLista> ListarClientesByPlaca(string placa)
        {
            List<TS_BEClienteLista> lista = new List<TS_BEClienteLista>();

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_CLIENTE_POR_PLACA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PLACA", SqlDbType.VarChar, 100).Value = placa;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            lista.Add(new TS_BEClienteLista()
                            {
                                cdcliente = (drd.HasColumn("cdcliente") ? drd["cdcliente"] == DBNull.Value ? "" : drd["cdcliente"].ToString() : "").Trim(),
                                rscliente = (drd.HasColumn("rscliente") ? drd["rscliente"] == DBNull.Value ? "" : drd["rscliente"].ToString() : "").Trim(),
                                drcliente = (drd.HasColumn("drcliente") ? drd["drcliente"] == DBNull.Value ? "" : drd["drcliente"].ToString() : "").Trim(),
                                ruccliente = (drd.HasColumn("ruccliente") ? drd["ruccliente"] == DBNull.Value ? "" : drd["ruccliente"].ToString() : "").Trim(),
                                placa = (drd.HasColumn("placa") ? drd["placa"] == DBNull.Value ? "" : drd["placa"].ToString() : "").Trim(),
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
