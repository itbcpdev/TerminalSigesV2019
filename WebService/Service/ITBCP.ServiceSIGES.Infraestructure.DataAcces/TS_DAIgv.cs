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
    public class TS_DAIgv : ITS_DOIgv
    { 
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;
        public List<TS_BETipo_Igv> OBTENER_IGV(TS_BETipo_Igv input)
        {
            List<TS_BETipo_Igv> lista = new List<TS_BETipo_Igv>();
            TS_BETipo_Igv output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_IGV", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BETipo_Igv();
                            output.fecha = drd.HasColumn("fecha") ? drd["fecha"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecha"]) : (DateTime?)null;
                            output.igv = drd.HasColumn("igv") ? drd["igv"] == DBNull.Value ? null : drd["igv"].ToString() : null;

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
