using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
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
    public class TS_DALados : ITS_DOLados
    {
        private readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        private readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public TS_BEMensaje ELIMINAR_LADO(string lado)
        {
            bool estado = false;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_ELIMINAR_LADO_POR_TERMINAL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LADO", SqlDbType.VarChar, 20).Value = (lado ?? "").Trim();
                    estado = cmd.ExecuteNonQuery() > 0;
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
            return estado ? new TS_BEMensaje("OK",true) : new TS_BEMensaje("No se pudo eliminar debido a que no se encontraba el registro especificado",false);
        }

        public TS_BELados OBTENER_LADOS()
        {
            TS_BELados cLados = new TS_BELados() { cLados = new List<TS_BELado>(), Mensaje = new TS_BEMensaje("",true) };

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_LADOS_POR_TERMINAL", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            TS_BELado cLado = new TS_BELado();
                            cLado.nropos = (drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? "" : drd["nropos"].ToString() : "").Trim();
                            cLado.lado = (drd.HasColumn("lado") ? drd["lado"] == DBNull.Value ? "" : drd["lado"].ToString() : "").Trim();
                            cLados.cLados.Add(cLado);
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
            return cLados;
        }

        public TS_BEMensaje REGISTRAR_LADO(string nropos, string lado)
        {
            bool estado = false;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_REGISTRAR_LADOS_POR_TERMINAL", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LADO", SqlDbType.VarChar, 20).Value   = (lado ?? "").Trim();
                    cmd.Parameters.Add("@NROPOS", SqlDbType.VarChar, 20).Value = (nropos ?? "").Trim();
                    estado = cmd.ExecuteNonQuery() > 0;
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
            return estado ? new TS_BEMensaje("OK", true) : new TS_BEMensaje("No se pudo registrar la solicitud intente mas tarde", false);
        }
    }
}
