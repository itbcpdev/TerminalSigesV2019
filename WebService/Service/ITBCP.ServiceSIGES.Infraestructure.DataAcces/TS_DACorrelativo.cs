using ITBCP.ServiceSIGES.Domain;
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
    public class TS_DACorrelativo : ITS_DOCorrelativo
    {

        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public TS_BECorrelativoOutput ObtenerCorrelativo(TS_BECorrelativoInput input)
        {
            TS_BECorrelativoOutput output = new TS_BECorrelativoOutput();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@seriehd", SqlDbType.Char, 10).Value = input.seriehd;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.factura = drd.HasColumn("factura") ? drd["factura"] == DBNull.Value ? null : drd["factura"].ToString() : null;
                            output.boleta = drd.HasColumn("boleta") ? drd["boleta"] == DBNull.Value ? null : drd["boleta"].ToString() : null;
                            output.ticket = drd.HasColumn("ticket") ? drd["ticket"] == DBNull.Value ? null : drd["ticket"].ToString() : null;
                            output.nventa = drd.HasColumn("nventa") ? drd["nventa"] == DBNull.Value ? null : drd["nventa"].ToString() : null;
                            output.promocion = drd.HasColumn("promocion") ? drd["promocion"] == DBNull.Value ? null : drd["promocion"].ToString() : null;
                            output.ncredito = drd.HasColumn("ncredito") ? drd["ncredito"] == DBNull.Value ? null : drd["ncredito"].ToString() : null;
                            output.ndebito = drd.HasColumn("ndebito") ? drd["ndebito"] == DBNull.Value ? null : drd["ndebito"].ToString() : null;
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
