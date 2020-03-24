using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ITBCP.ServiceSIGES.Infraestructure.DataAcces
{
    public class TS_DADeposito : ITS_DODeposito
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        private readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;
        public TS_BEDepositos CONSULTAR_DEPOSITOS(TS_BEDeposito input, TS_BETerminal terminal)
        {
            TS_BEDepositos cDepositos = new TS_BEDepositos() { cDepositos = new List<TS_BEDeposito>(), cMensaje = new TS_BEMensaje() };
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_DEPOSITOS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 20).Value       = input.nropos;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 30).Value  = terminal.fecproceso;
                    cmd.Parameters.Add("@TURNO", SqlDbType.VarChar, 2).Value         = terminal.turno;
                    cmd.Parameters.Add("@CDVENDEDOR", SqlDbType.VarChar, 20).Value   = input.cdvendedor;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BEDeposito cDeposito = new TS_BEDeposito();
                            cDeposito.nropos       = (drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? "" : drd["nropos"].ToString() : "").Trim();
                            cDeposito.cdvendedor   = (drd.HasColumn("cdvendedor") ? drd["cdvendedor"] == DBNull.Value ? "" : drd["cdvendedor"].ToString() : "").Trim();
                            cDeposito.cdtppago     = (drd.HasColumn("cdtppago") ? drd["cdtppago"] == DBNull.Value ? "" : drd["cdtppago"].ToString() : "").Trim();
                            cDeposito.dstppago     = (drd.HasColumn("dstppago") ? drd["dstppago"] == DBNull.Value ? "" : drd["dstppago"].ToString() : "").Trim();
                            cDeposito.mtosoles     = drd.HasColumn("mtosoles") ? drd["mtosoles"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtosoles"]) : 0;
                            cDeposito.mtodolares   = drd.HasColumn("mtodolares") ? drd["mtodolares"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtodolares"]) : 0;
                            cDeposito.nrosobres    = drd.HasColumn("nrosobres") ? drd["nrosobres"] == DBNull.Value ? 0 : Convert.ToInt32(drd["nrosobres"]) : 0;
                            cDeposito.nrodeposito  = (drd.HasColumn("nrodeposito") ? drd["nrodeposito"] == DBNull.Value ? "" : drd["nrodeposito"].ToString() : "").Trim();
                            cDeposito.fecdocumento = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(drd["fecproceso"]) : DateTime.Now;
                            cDeposito.turno        = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? 0 : Convert.ToInt32(drd["turno"]) : 0;
                            cDeposito.fecha         = (drd.HasColumn("fecha") ? drd["fecha"] == DBNull.Value ? "" : drd["fecha"].ToString() : "").Trim();
                            cDeposito.info          = (drd.HasColumn("info") ? drd["info"] == DBNull.Value ? "" : drd["info"].ToString() : "").Trim();
                            cDepositos.cDepositos.Add(cDeposito);
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
            if(cDepositos.cDepositos.Count > 0)
            {
                cDepositos.cMensaje.mensaje = "OK";
                cDepositos.cMensaje.Ok = true;
            }
            if (cDepositos.cDepositos.Count == 0)
            {
                cDepositos.cMensaje.mensaje = "SIN DEPOSITOS";
                cDepositos.cMensaje.Ok = true;
            }
            return cDepositos;
        }
        public TS_BEMensaje REGISTRAR_DEPOSITO(TS_BEDeposito input, TS_BETerminal terminal)
        {
            TS_BEMensaje Mensaje = new TS_BEMensaje();

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_DEPOSITO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 20).Value       = input.nropos;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 20).Value  = terminal.fecproceso;
                    cmd.Parameters.Add("@TURNO", SqlDbType.VarChar,       2).Value   = terminal.turno ?? 0;
                    cmd.Parameters.Add("@CDVENDEDOR", SqlDbType.VarChar, 10).Value   = input.cdvendedor;
                    cmd.Parameters.Add("@CDTPPAGO", SqlDbType.VarChar,     5).Value  = input.cdtppago;
                    cmd.Parameters.Add("@NRODEPOSITO", SqlDbType.VarChar, 10).Value  = terminal.nrodeposito ?? 1;
                    cmd.Parameters.Add("@MTOSOLES", SqlDbType.Decimal, 100).Value    = input.mtosoles;
                    cmd.Parameters.Add("@MTODOLAR", SqlDbType.VarChar, 18).Value     = input.mtodolares;
                    cmd.Parameters.Add("@NROSOBRES", SqlDbType.VarChar, 100).Value   = input.nrosobres;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            input.nrodeposito = (drd.HasColumn("DEPOSITO") ? drd["DEPOSITO"] == DBNull.Value ? "" : drd["DEPOSITO"].ToString() : "").Trim();
                            Mensaje.mensaje =  (drd.HasColumn("OK") ? drd["OK"] == DBNull.Value ? "" : drd["OK"].ToString() : "").Trim();
                            Mensaje.Ok      =  ((drd.HasColumn("OK") ? drd["OK"] == DBNull.Value ? "" : drd["OK"].ToString() : "").Trim()).Equals("OK");
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
        public TS_BEMensaje AUTENTICAR_DEPOSITO_GRIFERO(TS_BELoginVendedor input)
        {
            TS_BEMensaje Mensaje = new TS_BEMensaje();

            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_AUTENTICA_GRIFERO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar, 20).Value = input.usuario;
                    cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar, 20).Value = input.clave;
                    cmd.Parameters.Add("@CDEMPRESA", SqlDbType.VarChar, 20).Value = input.cdempresa;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            Mensaje.mensaje = (drd.HasColumn("MENSAJE") ? drd["MENSAJE"] == DBNull.Value ? "" : drd["MENSAJE"].ToString() : "").Trim();
                            Mensaje.Ok = ((drd.HasColumn("MENSAJE") ? drd["MENSAJE"] == DBNull.Value ? "" : drd["MENSAJE"].ToString() : "").Trim()).Equals("OK");
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
        public TS_BEMensaje VERIFICAR_GRIFERO_LADOS()
        {
            TS_BEMensaje Mensaje = new TS_BEMensaje();
            int cantidad = 0;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_VERIFICAR_GRIFERO_LADOS", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            cantidad++;
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
            if (cantidad > 0)
            {
                Mensaje.mensaje = "OK";
                Mensaje.Ok = true;
            }
            else
            {
                Mensaje.mensaje = "Debe registrar el grifero por lados";
                Mensaje.Ok = false;
            }
            return Mensaje;
        }
        public TS_BEMensaje REGISTRAR_GRIFERO_LADOS(TS_BELado input)
        {
            TS_BEMensaje mensaje = new TS_BEMensaje();

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_GRIFERO_LADO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 30).Value = input.fecproceso;
                    cmd.Parameters.Add("@CDVENDEDOR", SqlDbType.VarChar, 20).Value = input.cdvendedor;
                    cmd.Parameters.Add("@TURNO", SqlDbType.VarChar, 20).Value = input.turno;                    
                    cmd.Parameters.Add("@LADO", SqlDbType.VarChar, 20).Value = input.lado;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            mensaje.mensaje = (drd.HasColumn("MENSAJE") ? drd["MENSAJE"] == DBNull.Value ? "" : drd["MENSAJE"].ToString() : "").Trim();
                            mensaje.Ok = ((drd.HasColumn("MENSAJE") ? drd["MENSAJE"] == DBNull.Value ? "" : drd["MENSAJE"].ToString() : "").Trim()).Equals("OK");
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
            if (String.IsNullOrEmpty(mensaje.mensaje))
            {
                mensaje.mensaje = "No se obtuvo resultados al procesar la solicitud";
                mensaje.Ok = false;
            }
            return mensaje;
        }
        public TS_BELados OBTENER_GRIFERO_LADOS(TS_BELado input)
        {
            List<TS_BELado> Lista = new List<TS_BELado>();
            TS_BEMensaje Mensaje = new TS_BEMensaje("",false);

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_GRIFERO_LADO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 30).Value = input.fecproceso;
                    cmd.Parameters.Add("@TURNO", SqlDbType.VarChar, 20).Value = input.turno;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BELado lado = new TS_BELado();
                            
            
                            lado.lado = (drd.HasColumn("lado") ? drd["lado"] == DBNull.Value ? "" : drd["lado"].ToString() : "").Trim();
                            lado.cdvendedor = (drd.HasColumn("cdvendedor") ? drd["cdvendedor"] == DBNull.Value ? "" : drd["cdvendedor"].ToString() : "").Trim();
                            lado.nropos = input.nropos;
                            Lista.Add(lado);
                        }
                        Mensaje.mensaje = "OK";
                        Mensaje.Ok      = true;
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
            return new TS_BELados(Lista,Mensaje);
        }
        public TS_BEMensaje ELIMINAR_GRIFERO_LADOS(TS_BELadoEInput input)
        {
            TS_BEMensaje Mensaje = new TS_BEMensaje("", false);

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ELIMINAR_GRIFERO_LADO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 30).Value = input.fecproceso;
                    cmd.Parameters.Add("@TURNO", SqlDbType.VarChar, 20).Value = input.turno;
                    cmd.Parameters.Add("@LADO", SqlDbType.VarChar, 20).Value = input.lado;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            Mensaje.mensaje = (drd.HasColumn("OK") ? drd["OK"] == DBNull.Value ? "" : drd["OK"].ToString() : "").Trim();
                            Mensaje.Ok = ((drd.HasColumn("OK") ? drd["OK"] == DBNull.Value ? "" : drd["OK"].ToString() : "").Trim()).Equals("OK");
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
        public TS_BEMensaje ELIMINAR_DEPOSITOS(TS_BEDepositoEInput input, TS_BETerminal terminal)
        {
            TS_BEMensaje Mensaje = new TS_BEMensaje("", false);
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ELIMINAR_DEPOSITO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 20).Value = input.nropos;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 30).Value = terminal.fecproceso;
                    cmd.Parameters.Add("@TURNO", SqlDbType.VarChar, 2).Value = terminal.turno;
                    cmd.Parameters.Add("@NRODEPOSITO", SqlDbType.VarChar, 10).Value = input.nrodeposito;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            Mensaje.mensaje = (drd.HasColumn("OK") ? drd["OK"] == DBNull.Value ? "" : drd["OK"].ToString() : "").Trim();
                            Mensaje.Ok = ((drd.HasColumn("OK") ? drd["OK"] == DBNull.Value ? "" : drd["OK"].ToString() : "").Trim()).Equals("OK");                           
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
        public TS_BEDeposito OBTENER_DEPOSITO(TS_BEDepositoEInput input, TS_BETerminal terminal)
        {
            
            
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_DEPOSITO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 20).Value      = input.nropos;
                    cmd.Parameters.Add("@TURNO", SqlDbType.VarChar, 30).Value      = terminal.turno;
                    cmd.Parameters.Add("@FECPROCESO", SqlDbType.DateTime, 25).Value   = terminal.fecproceso;
                    cmd.Parameters.Add("@NRODEPOSITO", SqlDbType.VarChar, 10).Value = input.nrodeposito;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        if (drd.HasRows)
                        {
                            TS_BEDeposito Deposito = new TS_BEDeposito();
                            while (drd.Read())
                            {

                                Deposito.nropos      = (drd.HasColumn("nropos")      ? drd["nropos"]      == DBNull.Value ? "" : drd["nropos"].ToString()             : "").Trim();
                                Deposito.nrodeposito = (drd.HasColumn("nrodeposito") ? drd["nrodeposito"] == DBNull.Value ? "" : drd["nrodeposito"].ToString()        : "").Trim();
                                Deposito.cdtppago    = (drd.HasColumn("cdtppago")    ? drd["cdtppago"]    == DBNull.Value ? "" : drd["cdtppago"].ToString()           : "").Trim();
                                Deposito.cdvendedor  = (drd.HasColumn("cdvendedor")  ? drd["cdvendedor"]  == DBNull.Value ? "" : drd["cdvendedor"].ToString()         : "").Trim();
                                Deposito.dstppago    = (drd.HasColumn("dstppago")    ? drd["dstppago"]    == DBNull.Value ? "" : drd["dstppago"].ToString()           : "").Trim();
                                Deposito.mtosoles    = drd.HasColumn("mtosoles")     ? drd["mtosoles"]    == DBNull.Value ? 0  : Convert.ToDecimal(drd["mtosoles"]  ) : 0;
                                Deposito.mtodolares  = drd.HasColumn("mtodolares")   ? drd["mtodolares"]  == DBNull.Value ? 0  : Convert.ToDecimal(drd["mtodolares"]) : 0;
                                Deposito.nrosobres   = drd.HasColumn("nrosobres")    ? drd["nrosobres"]   == DBNull.Value ? 0  : Convert.ToInt32(drd["nrosobres"])    : 0;
                                Deposito.turno       = drd.HasColumn("turno")        ? drd["turno"]       == DBNull.Value ? 0  : Convert.ToInt32(drd["turno"])        : 0;
                            }
                            cmd.Dispose();
                            return Deposito;
                        }
                        else
                        {
                            cmd.Dispose();
                            return null;
                        }
                        
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
        }
        public TS_BEVendedores OBTENER_VENDEDORES(string cdempresa)
        {
            
            TS_BEVendedores cVendedores = new TS_BEVendedores() { cVendedores = new List<TS_BEVendedor>(), Mensaje = new TS_BEMensaje() };
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_GRIFEROS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDEMPRESA", SqlDbType.VarChar, 20).Value = cdempresa;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            cVendedores.cVendedores.Add(new TS_BEVendedor()
                            {
                                cdusuario = (drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? "" : drd["cdusuario"].ToString() : "").Trim(),
                                dsvendedor = (drd.HasColumn("dsvendedor") ? drd["dsvendedor"] == DBNull.Value ? "" : drd["dsvendedor"].ToString() : "").Trim()
                            });
                            cVendedores.Mensaje.mensaje = (drd.HasColumn("OK") ? drd["OK"] == DBNull.Value ? "" : drd["OK"].ToString() : "").Trim();
                            cVendedores.Mensaje.Ok      = (drd.HasColumn("OK") ? drd["OK"] == DBNull.Value ? "" : drd["OK"].ToString() : "").Equals("OK");
                        }
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
            return cVendedores;
        }
        public TS_BEVendedores OBTENER_VENDEDORES()
        {

            TS_BEVendedores cVendedores = new TS_BEVendedores() { cVendedores = new List<TS_BEVendedor>(), Mensaje = new TS_BEMensaje() };
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_GRIFEROS_TODOS", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            cVendedores.cVendedores.Add(new TS_BEVendedor()
                            {
                                cdusuario = (drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? "" : drd["cdusuario"].ToString() : "").Trim(),
                                dsvendedor = (drd.HasColumn("dsvendedor") ? drd["dsvendedor"] == DBNull.Value ? "" : drd["dsvendedor"].ToString() : "").Trim()
                            });
                        }
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
            return cVendedores;
        }
        public List<TS_BEUsers> OBTENER_USUARIOS_TODOS()
        {
            List<TS_BEUsers> cUsuarios = new List<TS_BEUsers>();
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_USUARIOS_TODOS", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            cUsuarios.Add(new TS_BEUsers()
                            {
                                cdusuario = (drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? "" : drd["cdusuario"].ToString() : "").Trim(),
                                dsusuario = (drd.HasColumn("dsusuario") ? drd["dsusuario"] == DBNull.Value ? "" : drd["dsusuario"].ToString() : "").Trim()
                            });
                        }
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
            return cUsuarios;
        }
        public TS_BEVendedor OBTENER_VENDEDOR(string cdusuario)
        {

            TS_BEVendedor cVendedor = new TS_BEVendedor();
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_GRIFERO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDUSUARIO", SqlDbType.VarChar, 20).Value = cdusuario;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            cVendedor.cdusuario = cdusuario = (drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? "" : drd["cdusuario"].ToString() : "").Trim();
                            cVendedor.dsvendedor = (drd.HasColumn("dsusuario") ? drd["dsusuario"] == DBNull.Value ? "" : drd["dsusuario"].ToString() : "").Trim();
                        }
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
            return cVendedor;
        }

        public TS_BEMensaje AUTENTICAR_CONFIGURACION_LADOS(TS_BELoginVendedor input)
        {
            TS_BEMensaje Mensaje = new TS_BEMensaje();

            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_AUTENTICA_CONFIGURACION_LADOS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar, 20).Value = input.usuario;
                    cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar, 20).Value = input.clave;
                    cmd.Parameters.Add("@CDEMPRESA", SqlDbType.VarChar, 20).Value = input.cdempresa;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            Mensaje.mensaje = (drd.HasColumn("MENSAJE") ? drd["MENSAJE"] == DBNull.Value ? "" : drd["MENSAJE"].ToString() : "").Trim();
                            Mensaje.Ok = ((drd.HasColumn("MENSAJE") ? drd["MENSAJE"] == DBNull.Value ? "" : drd["MENSAJE"].ToString() : "").Trim()).Equals("OK");
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
    }
}
