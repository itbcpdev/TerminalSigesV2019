using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities.Users;
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
    public class TS_DAAutentication : ITS_DOAutentication
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public List<TS_BEAccesos> GetAccesos(TS_BEAccesos input)
        {

            List<TS_BEAccesos> list = new List<TS_BEAccesos>();
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_S_ACCESOS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@vcdNivel", SqlDbType.Char, 2).Value = input.cdnivel;
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            list.Add(new TS_BEAccesos()
                            {
                                cdmodulo = drd["cdmodulo"]?.ToString() ?? null,
                                cdnivel = drd["cdnivel"]?.ToString() ?? null,
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
                    if (con != null)
                    {
                        con.Dispose();
                    }

                }
            }
            return list;

        }

        public List<TS_BEEmpresaUser> GetEmpresaUser(TS_BELogin input)
        {
            List<TS_BEEmpresaUser> list = new List<TS_BEEmpresaUser>();
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_S_EMPRESA_USUARIO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@vcdUsuario", SqlDbType.Char, 60).Value = input.cdusuario;
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            list.Add(new TS_BEEmpresaUser()
                            {
                                cdempresa = drd["cdempresa"]?.ToString() ?? null,
                                dsempresa = drd["dsempresa"]?.ToString() ?? null,
                                drempresa = drd["drempresa"]?.ToString() ?? null,
                                conexion = drd["conexion"]?.ToString() ?? null,
                                rucempresa = drd["rucempresa"]?.ToString() ?? null,
                                cdnivel = drd["cdnivel"]?.ToString() ?? null,
                                facturacion_electronica = drd["facturacion_electronica"]?.ToString() ?? null
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
                    if (con != null)
                    {
                        con.Dispose();
                    }
                }
            }
            return list;
        }

        public List<TS_BEModulo> GetModulos()
        {
            List<TS_BEModulo> list = new List<TS_BEModulo>();
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_S_MODULO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            list.Add(new TS_BEModulo()
                            {
                                cdmodulo = drd["cdmodulo"]?.ToString() ?? null,
                                dsmodulo = drd["dsmodulo"]?.ToString() ?? null,
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
                    if (con != null)
                    {
                        con.Dispose();
                    }
                }
            }
            return list;
        }

        public List<TS_BENivel> GetNivel(TS_BENivel input)
        {
            List<TS_BENivel> list = new List<TS_BENivel>();
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_S_NIVEL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@vtipo", SqlDbType.Char, 3).Value = input.tipo;
                    cmd.Parameters.Add("@vcdUsuario", SqlDbType.Char, 60).Value = input.codigo;
                    cmd.Parameters.Add("@vcdempresa", SqlDbType.Char, 2).Value = input.cdempresa;
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            list.Add(new TS_BENivel()
                            {
                                tipo = drd["tipo"]?.ToString() ?? null,
                                codigo = drd["codigo"]?.ToString() ?? null,
                                cdempresa = drd["cdempresa"]?.ToString() ?? null,
                                cdnivel = drd["cdnivel"]?.ToString() ?? null,
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
                    if (con != null)
                    {
                        con.Dispose();
                    }
                }
            }
            return list;
        }

        public List<TS_BEUsers> Login(TS_BELogin input)
        {
            List<TS_BEUsers> list = new List<TS_BEUsers>();
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_AUTENTICA_USER", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@vcdUsuario", SqlDbType.Char, 60).Value = input.cdusuario;
                    cmd.Parameters.Add("@vPassword", SqlDbType.Float).Value = input.password;
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            list.Add(new TS_BEUsers()
                            {
                                cdusuario = drd["cdusuario"]?.ToString() ?? null,
                                dsusuario = drd["dsusuario"]?.ToString() ?? null,

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
                    if (con != null)
                    {
                        con.Dispose();
                    }
                }
            }
            return list;
        }

        public bool IsValidToken(string usuario,string token)
        {
            bool Respuesta = false;
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_AUTENTICA_USER_TOKEN", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDUSUARIO", SqlDbType.VarChar, 60).Value = usuario;
                    cmd.Parameters.Add("@TOKEN", SqlDbType.VarChar, 355).Value = token;
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        Respuesta = drd.HasRows;
                    }
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con != null)
                    {
                        con.Dispose();
                    }
                }
            }
            return Respuesta;
        }

        public bool RegistraToken(string usuario, string token)
        {
            bool Respuesta = false;
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_REGISTRA_USER_TOKEN", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDUSUARIO", SqlDbType.VarChar, 60).Value = usuario;
                    cmd.Parameters.Add("@TOKEN", SqlDbType.VarChar, 355).Value = token;

                    Respuesta = cmd.ExecuteNonQuery() > 0;
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con != null)
                    {
                        con.Dispose();
                    }
                }
            }
            return Respuesta;
        }

        public TS_BELoginTurnoOutPut LoginTurno(TS_BELoginTurno input)
        {
            TS_BELoginTurnoOutPut vRespuesta = new TS_BELoginTurnoOutPut() { Mensaje = "No se proceso la transacción",Ok = false };

            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_AUTENTICA_USER_TURNO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar, 60).Value = input.cdusuario;
                    cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = input.password;
                    cmd.Parameters.Add("@CDEMPRESA", SqlDbType.VarChar, 2).Value = input.cdempresa;
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            vRespuesta.Mensaje = (drd.HasColumn("mensaje") ? drd["mensaje"] == DBNull.Value ? "" : drd["mensaje"].ToString() : "").Trim();
                            vRespuesta.Ok      = (drd.HasColumn("mensaje") ? drd["mensaje"] == DBNull.Value ? "" : drd["mensaje"].ToString() : "").Trim().ToUpper().Equals("OK");
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
                    if (con != null)
                    {
                        con.Dispose();
                    }
                }
            }
            return vRespuesta;
        }
    }
}
