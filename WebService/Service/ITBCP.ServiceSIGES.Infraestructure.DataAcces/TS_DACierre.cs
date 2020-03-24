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
   public class TS_DACierre: ITS_DOCierre
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;
        public TS_BECierre OBTENER_CIERRE(TS_BECierre input)
        {
      
            TS_BECierre output = new TS_BECierre();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CIERRE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cdcierre", SqlDbType.Char, 1).Value = input.cdcierre;
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output.flggrupo01 = drd.HasColumn("flggrupo01") ? drd["flggrupo01"] == DBNull.Value ? false : Convert.ToBoolean(drd["flggrupo01"]) : false;
                            output.flggrupo02 = drd.HasColumn("flggrupo02") ? drd["flggrupo02"] == DBNull.Value ? false : Convert.ToBoolean(drd["flggrupo02"]) : false;
                            output.flggrupo03 = drd.HasColumn("flggrupo03") ? drd["flggrupo03"] == DBNull.Value ? false : Convert.ToBoolean(drd["flggrupo03"]) : false;
                            output.flggrupo04 = drd.HasColumn("flggrupo04") ? drd["flggrupo04"] == DBNull.Value ? false : Convert.ToBoolean(drd["flggrupo04"]) : false;
                            output.flggrupo05 = drd.HasColumn("flggrupo05") ? drd["flggrupo05"] == DBNull.Value ? false : Convert.ToBoolean(drd["flggrupo05"]) : false;
                            output.flgvendedor = drd.HasColumn("flgvendedor") ? drd["flgvendedor"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgvendedor"]) : false;
                            output.flgdesc = drd.HasColumn("flgdesc") ? drd["flgdesc"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgdesc"]) : false;
                            output.flgarticulodesc = drd.HasColumn("flgarticulodesc") ? drd["flgarticulodesc"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgarticulodesc"]) : false;
                            output.flgdepositogrifero = drd.HasColumn("flgdepositogrifero") ? drd["flgdepositogrifero"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgdepositogrifero"]) : false;
                            output.flgconsolidarlados = drd.HasColumn("flgconsolidarlados") ? drd["flgconsolidarlados"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgconsolidarlados"]) : false;
                            output.flggastogrifero = drd.HasColumn("flggastogrifero") ? drd["flggastogrifero"] == DBNull.Value ? false : Convert.ToBoolean(drd["flggastogrifero"]) : false;
                            output.flgarticulo = drd.HasColumn("flgarticulo") ? drd["flgarticulo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgarticulo"]) : false;
                            output.flgpago = drd.HasColumn("flgpago") ? drd["flgpago"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpago"]) : false;
                            output.flgcara = drd.HasColumn("flgcara") ? drd["flgcara"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcara"]) : false;
                            output.flgdocmanual = drd.HasColumn("flgdocmanual") ? drd["flgdocmanual"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgdocmanual"]) : false;
                            output.flgusuario = drd.HasColumn("flgusuario") ? drd["flgusuario"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgusuario"]) : false;
                            output.flgcanjearticulo = drd.HasColumn("flgcanjearticulo") ? drd["flgcanjearticulo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcanjearticulo"]) : false;
                            output.cdcierre = drd.HasColumn("cdcierre") ? drd["cdcierre"] == DBNull.Value ? null : drd["cdcierre"].ToString() : null;
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
        public List<TS_BECierres> SP_ITBCP_LISTAR_ULTIMO_CIERRE(TS_BECierres input)
        {
            List<TS_BECierres> lista = new List<TS_BECierres>();
            TS_BECierres output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_ULTIMO_CIERRE", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BECierres();
                            output.fecha = drd.HasColumn("fecha") ? drd["fecha"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecha"]) : (DateTime?)null;
                            output.fecsistema = drd.HasColumn("fecsistema") ? drd["fecsistema"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecsistema"]) : (DateTime?)null;
                            output.cdusuario = drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString() : null;

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
        public List<TS_BECierre> SP_ITBCP_LISTAR_CIERRE(TS_BECierre input)
        {
            List<TS_BECierre> lista = new List<TS_BECierre>();
            TS_BECierre output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_CIERRE", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BECierre();
                            output.flggrupo01 = drd.HasColumn("flggrupo01") ? drd["flggrupo01"] == DBNull.Value ? false : Convert.ToBoolean(drd["flggrupo01"]) : false;
                            output.flggrupo02 = drd.HasColumn("flggrupo02") ? drd["flggrupo02"] == DBNull.Value ? false : Convert.ToBoolean(drd["flggrupo02"]) : false;
                            output.flggrupo03 = drd.HasColumn("flggrupo03") ? drd["flggrupo03"] == DBNull.Value ? false : Convert.ToBoolean(drd["flggrupo03"]) : false;
                            output.flggrupo04 = drd.HasColumn("flggrupo04") ? drd["flggrupo04"] == DBNull.Value ? false : Convert.ToBoolean(drd["flggrupo04"]) : false;
                            output.flggrupo05 = drd.HasColumn("flggrupo05") ? drd["flggrupo05"] == DBNull.Value ? false : Convert.ToBoolean(drd["flggrupo05"]) : false;
                            output.flgvendedor = drd.HasColumn("flgvendedor") ? drd["flgvendedor"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgvendedor"]) : false;
                            output.flgdesc = drd.HasColumn("flgdesc") ? drd["flgdesc"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgdesc"]) : false;
                            output.flgarticulodesc = drd.HasColumn("flgarticulodesc") ? drd["flgarticulodesc"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgarticulodesc"]) : false;
                            output.flgdepositogrifero = drd.HasColumn("flgdepositogrifero") ? drd["flgdepositogrifero"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgdepositogrifero"]) : false;
                            output.flgconsolidarlados = drd.HasColumn("flgconsolidarlados") ? drd["flgconsolidarlados"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgconsolidarlados"]) : false;
                            output.flggastogrifero = drd.HasColumn("flggastogrifero") ? drd["flggastogrifero"] == DBNull.Value ? false : Convert.ToBoolean(drd["flggastogrifero"]) : false;
                            output.flgarticulo = drd.HasColumn("flgarticulo") ? drd["flgarticulo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgarticulo"]) : false;
                            output.flgpago = drd.HasColumn("flgpago") ? drd["flgpago"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpago"]) : false;
                            output.flgcara = drd.HasColumn("flgcara") ? drd["flgcara"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcara"]) : false;
                            output.flgdocmanual = drd.HasColumn("flgdocmanual") ? drd["flgdocmanual"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgdocmanual"]) : false;
                            output.flgusuario = drd.HasColumn("flgusuario") ? drd["flgusuario"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgusuario"]) : false;
                            output.flgcanjearticulo = drd.HasColumn("flgcanjearticulo") ? drd["flgcanjearticulo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcanjearticulo"]) : false;
                            output.cdcierre = drd.HasColumn("cdcierre") ? drd["cdcierre"] == DBNull.Value ? null : drd["cdcierre"].ToString() : null;

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
