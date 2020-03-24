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

namespace ITBCP.ServiceSIGES.Infraestructure.DataAcces
{
    public class TS_DAInicioDia : ITS_DOInicioDia
    {
        private readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        private readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public bool EJECUTAR_INICIO_DIA(string seriehd, string cdusuario)
        {
            bool Estado = false;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_INICIO_DIA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SERIEHD", SqlDbType.VarChar, 10).Value = seriehd;
                    cmd.Parameters.Add("@CDUSUARIO", SqlDbType.VarChar, 20).Value = cdusuario;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            Estado = ((drd.HasColumn("OK") ? drd["OK"] == DBNull.Value ? "" : drd["OK"].ToString() : "").Trim()).Equals("OK");
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

            return Estado;
        }



    }
}
