using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities.Users;

namespace ITBCP.ServiceSIGES.Infraestructure.DataAcces
{
   public class TS_DAServer:ITS_DOServer
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public bool EXISTE_TABLA(string nombreTabla)
        {
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * from dbo.sysobjects where id = object_id(@nombreTabla)", con);
                    cmd.Parameters.AddWithValue("@nombreTabla", nombreTabla);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                    if (reader.HasRows)
                    {
                        return true;
                    }

                    return false;
             
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

        public string OBTENER_FECHA_SERVIDOR()
        {
            string output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_FECHA_SERVIDOR", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    output = cmd.ExecuteScalar().ToString();
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

        public TS_BEUsers OBTENER_USUARIO(string cdusuario)
        {
            TS_BEUsers Usuario = new TS_BEUsers();

            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_USUARIO_POR_CODIGO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CDUSUARIO", SqlDbType.Char, 20).Value = cdusuario;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            Usuario.cdusuario = (drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? "" : drd["cdusuario"].ToString() : "").Trim();
                            Usuario.drusuario = (drd.HasColumn("drusuario") ? drd["drusuario"] == DBNull.Value ? "" : drd["drusuario"].ToString() : "").Trim();
                            Usuario.dsusuario = (drd.HasColumn("dsusuario") ? drd["dsusuario"] == DBNull.Value ? "" : drd["dsusuario"].ToString() : "").Trim();
                            Usuario.rucusuario = (drd.HasColumn("rucusuario") ? drd["rucusuario"] == DBNull.Value ? "" : drd["rucusuario"].ToString() : "").Trim();
                            Usuario.tlfusuario = (drd.HasColumn("tlfusuario") ? drd["tlfusuario"] == DBNull.Value ? "" : drd["tlfusuario"].ToString() : "").Trim();
                            Usuario.tlfusuario1 = (drd.HasColumn("tlfusuario1") ? drd["tlfusuario1"] == DBNull.Value ? "" : drd["tlfusuario1"].ToString() : "").Trim();
                            Usuario.cdnivel = (drd.HasColumn("cdnivel") ? drd["cdnivel"] == DBNull.Value ? "" : drd["cdnivel"].ToString() : "").Trim();
                            Usuario.flganular = (drd.HasColumn("flganular") ? drd["flganular"] == DBNull.Value ? false : Convert.ToBoolean(drd["flganular"]) : false);
                            Usuario.flgborraritem = (drd.HasColumn("flgborraritem") ? drd["flgborraritem"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgborraritem"]) : false);
                            Usuario.flgdscto =  (drd.HasColumn("flgdscto") ? drd["flgdscto"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgdscto"]) : false);
                            Usuario.flgTurno = (drd.HasColumn("flgTurno") ? drd["flgTurno"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgTurno"]) : false);
                            Usuario.flgCierreX = (drd.HasColumn("flgCierreX") ? drd["flgCierreX"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgCierreX"]) : false);
                            Usuario.flgCierreZ = (drd.HasColumn("flgCierreZ") ? drd["flgCierreZ"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgCierreZ"]) : false);
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
            return Usuario;
        }
    }
}
