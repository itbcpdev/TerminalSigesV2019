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
    public class TS_DATipoCambio: ITS_DOTipoCambio
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public TS_BECambio OBTENER_TIPOCAMBIO()
        {
            
            TS_BECambio output = new TS_BECambio();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_TIPO_CAMBIO", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {                            
                            output.fecha = drd.HasColumn("fecha") ? drd["fecha"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecha"]) : (DateTime?)null;
                            output.cambio = drd.HasColumn("cambio") ? drd["cambio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cambio"]) : (decimal?)null;
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
        public List<TS_BECambio> LISTARTIPOCAMBIO(TS_BECambio input)
        {
            List<TS_BECambio> lista = new List<TS_BECambio>();
            TS_BECambio output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTARTIPOCAMBIO", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BECambio();
                            output.fecha = drd.HasColumn("fecha") ? drd["fecha"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecha"]) : (DateTime?)null;
                            output.cambio = drd.HasColumn("cambio") ? drd["cambio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cambio"]) : (decimal?)null;

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
