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
    public class TS_DACara: ITS_DOCara
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;
        public TS_BECara OBTENER_CARA_POR_POSICION(TS_BECara input)
        {

            TS_BECara output = new TS_BECara();
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
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cara = drd.HasColumn("cara") ? drd["cara"] == DBNull.Value ? null : drd["cara"].ToString() : null;
 
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
        public List<TS_BECara> LISTAR_CARA_POR_POSICION(TS_BECara input)
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
                            output.nropos = (drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? "" : drd["nropos"].ToString() : "").Trim();
                            output.cara = (drd.HasColumn("cara") ? drd["cara"] == DBNull.Value ? "" : drd["cara"].ToString() : "").Trim();

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

        public TS_BECara OBTENER_CARA_POR_CARA(TS_BECara input)
        {

            TS_BECara output = new TS_BECara();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_CARA_POR_CARA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cara", SqlDbType.Char, 10).Value = input.cara;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cara = drd.HasColumn("cara") ? drd["cara"] == DBNull.Value ? null : drd["cara"].ToString() : null;

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
    }
}
