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
    public class TS_DATipoPago:ITS_DOTipoPago
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;
        public List<TS_BETipopago> LISTAR_TIPO_PAGOS(TS_BETipopago input)
        {
            List<TS_BETipopago> lista = new List<TS_BETipopago>();
            TS_BETipopago output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_TIPO_PAGOS", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BETipopago();
                            output.flgpago = drd.HasColumn("flgpago") ? drd["flgpago"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpago"]) : false;
                            output.flgsistema = drd.HasColumn("flgsistema") ? drd["flgsistema"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsistema"]) : false;
                            output.cdtppago = drd.HasColumn("cdtppago") ? drd["cdtppago"] == DBNull.Value ? null : drd["cdtppago"].ToString() : null;
                            output.dstppago = drd.HasColumn("dstppago") ? drd["dstppago"] == DBNull.Value ? null : drd["dstppago"].ToString() : null;

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

        public List<TS_BETipopago> LISTAR_TIPO_PAGO_EFECTIVO(TS_BETipopago input)
        {
            List<TS_BETipopago> lista = new List<TS_BETipopago>();
            TS_BETipopago output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_TIPO_PAGO_EFECTIVO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdtppago", SqlDbType.Char, 5).Value = input.cdtppago;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BETipopago();
                            output.flgpago = drd.HasColumn("flgpago") ? drd["flgpago"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpago"]) : false;
                            output.flgsistema = drd.HasColumn("flgsistema") ? drd["flgsistema"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsistema"]) : false;
                            output.cdtppago = drd.HasColumn("cdtppago") ? drd["cdtppago"] == DBNull.Value ? null : drd["cdtppago"].ToString() : null;
                            output.dstppago = drd.HasColumn("dstppago") ? drd["dstppago"] == DBNull.Value ? null : drd["dstppago"].ToString() : null;

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
