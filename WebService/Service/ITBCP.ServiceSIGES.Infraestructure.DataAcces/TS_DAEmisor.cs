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
    public class TS_DAEmisor : ITS_DOEmisor
    {

        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;

        public TS_BEEmisor OBTENER_EMISOR_POR_EMPRESA(TS_BEEmisor input)
        {
            TS_BEEmisor output = new TS_BEEmisor();
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_INFORMACION_EMPRESA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdempresa", SqlDbType.Char, 2).Value = input.cdempresa;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output.cdempresa = drd.HasColumn("cdempresa") ? drd["cdempresa"] == DBNull.Value ? null : drd["cdempresa"].ToString().Trim() : null;
                            output.RUC = drd.HasColumn("rucempresa") ? drd["rucempresa"] == DBNull.Value ? null : drd["rucempresa"].ToString().Trim() : null;
                            output.RazonSocial = drd.HasColumn("dsempresa") ? drd["dsempresa"] == DBNull.Value ? null : drd["dsempresa"].ToString().Trim() : null;
                            output.Direccion = drd.HasColumn("drempresa") ? drd["drempresa"] == DBNull.Value ? null : drd["drempresa"].ToString().Trim() : null;
                            output.Departamento = drd.HasColumn("depempresa") ? drd["depempresa"] == DBNull.Value ? null : drd["depempresa"].ToString().Trim() : null;
                            output.Provincia = drd.HasColumn("provempresa") ? drd["provempresa"] == DBNull.Value ? null : drd["provempresa"].ToString().Trim() : null;
                            output.Distrito = drd.HasColumn("disempresa") ? drd["disempresa"] == DBNull.Value ? null : drd["disempresa"].ToString().Trim() : null;
                            output.Urbanizacion = drd.HasColumn("urbempresa") ? drd["urbempresa"] == DBNull.Value ? null : drd["urbempresa"].ToString().Trim() : null;
                            output.Ubigeo = drd.HasColumn("cdubigeo") ? drd["cdubigeo"] == DBNull.Value ? null : drd["cdubigeo"].ToString().Trim() : null;
                            output.nroautorizacion = drd.HasColumn("autorizacion") ? drd["autorizacion"] == DBNull.Value ? null : drd["autorizacion"].ToString().Trim() : null;
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
