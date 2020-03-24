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
    public class TS_DAMoneda: ITS_DOMoneda
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public List<TS_BEMoneda> SP_ITBCP_LISTAR_MONEDAS(TS_BEMoneda input)
        {
            List<TS_BEMoneda> lista = new List<TS_BEMoneda>();
            TS_BEMoneda output;
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_MONEDAS", con);
                    cmd.CommandType = CommandType.StoredProcedure; 
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BEMoneda();
                            output.cdmoneda = drd.HasColumn("cdmoneda") ? drd["cdmoneda"] == DBNull.Value ? null : drd["cdmoneda"].ToString() : null;
                            output.dsmoneda = drd.HasColumn("dsmoneda") ? drd["dsmoneda"] == DBNull.Value ? null : drd["dsmoneda"].ToString() : null;
                            output.smbmoneda = drd.HasColumn("smbmoneda ") ? drd["smbmoneda "] == DBNull.Value ? null : drd["smbmoneda "].ToString() : null;
                            output.cdiso = drd.HasColumn("cdiso ") ? drd["cdiso "] == DBNull.Value ? null : drd["cdiso "].ToString() : null;
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
        public TS_BEMoneda SP_ITBCP_OBTENER_MONEDA(TS_BEMoneda input)
        {
            TS_BEMoneda output = new TS_BEMoneda();
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_MONEDA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdmoneda", SqlDbType.Char, 1).Value = input.cdmoneda;
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        { 
                            output.cdmoneda = drd.HasColumn("cdmoneda") ? drd["cdmoneda"] == DBNull.Value ? null : drd["cdmoneda"].ToString() : null;
                            output.dsmoneda = drd.HasColumn("dsmoneda") ? drd["dsmoneda"] == DBNull.Value ? null : drd["dsmoneda"].ToString() : null;
                            output.smbmoneda = drd.HasColumn("smbmoneda ") ? drd["smbmoneda "] == DBNull.Value ? null : drd["smbmoneda "].ToString() : null;
                            output.cdiso = drd.HasColumn("cdiso ") ? drd["cdiso "] == DBNull.Value ? null : drd["cdiso "].ToString() : null;
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
