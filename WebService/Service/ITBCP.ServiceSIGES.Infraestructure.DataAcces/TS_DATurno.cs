using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;

namespace ITBCP.ServiceSIGES.Infraestructure.DataAcces
{
    
    public class TS_DATurno : ITS_DOTurno
    {
        private readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        private readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;
        private string FechaRespaldo = "";
        private string HoraRespaldo  = "";

        public bool INICIAR_CAMBIO_TURNO_SYSCON()
        {
            string estado = "";
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CAMBIO_TURNO_SYSCON", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PASO", SqlDbType.VarChar, 20).Value = "P1";
                    cmd.Parameters.Add("@FECHARESPALDO", SqlDbType.VarChar, 20).Value = "";
                    cmd.Parameters.Add("@HORARESPALDO", SqlDbType.VarChar, 20).Value = "";
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        if (!drd.HasRows)
                        {

                        }
                        else
                        {
                            while (drd.Read())
                            {
                                estado = (drd.HasColumn("OK") ? drd["OK"] == DBNull.Value ? "" : drd["OK"].ToString() : "").Trim();
                                FechaRespaldo = (drd.HasColumn("FECHA") ? drd["FECHA"] == DBNull.Value ? "" : drd["FECHA"].ToString() : "").Trim();
                                HoraRespaldo = (drd.HasColumn("HORA") ? drd["HORA"] == DBNull.Value ? "" : drd["HORA"].ToString() : "").Trim();
                            }

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
            return estado.Equals("OK");
        }
        public bool VERIFICAR_CAMBIO_TURNO_SISCON()
        {
            string estado = "";
            string respuesta = "";

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CAMBIO_TURNO_SYSCON", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PASO", SqlDbType.VarChar, 20).Value = "P4";
                    cmd.Parameters.Add("@FECHARESPALDO", SqlDbType.VarChar, 20).Value = "";
                    cmd.Parameters.Add("@HORARESPALDO", SqlDbType.VarChar, 20).Value = "";
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        if (!drd.HasRows)
                        {

                        }
                        else
                        {
                            while (drd.Read())
                            {
                                estado = (drd.HasColumn("OK") ? drd["OK"] == DBNull.Value ? "" : drd["OK"].ToString() : "").Trim();
                                respuesta = (drd.HasColumn("RESPUESTA") ? drd["RESPUESTA"] == DBNull.Value ? "" : drd["RESPUESTA"].ToString() : "").Trim();
                            }

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
            return estado.Equals("OK") && respuesta.Equals("OK");
        }
        public bool TERMINAR_CAMBIO_TURNO_SISCON()
        {
            string estado = "";

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CAMBIO_TURNO_SYSCON", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PASO", SqlDbType.VarChar, 20).Value = "P2";
                    cmd.Parameters.Add("@FECHARESPALDO", SqlDbType.VarChar, 20).Value = "";
                    cmd.Parameters.Add("@HORARESPALDO", SqlDbType.VarChar, 20).Value = "";

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        if (!drd.HasRows)
                        {

                        }
                        else
                        {
                            while (drd.Read())
                            {
                                estado = (drd.HasColumn("OK") ? drd["OK"] == DBNull.Value ? "" : drd["OK"].ToString() : "").Trim();
                            }

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
            return estado.Equals("OK");
        }
        public bool DESHACER_CAMBIO_TURNO_SISCON()
        {
            string estado = "";

            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CAMBIO_TURNO_SYSCON", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PASO", SqlDbType.VarChar, 20).Value = "P3";
                    cmd.Parameters.Add("@FECHARESPALDO", SqlDbType.VarChar, 20).Value = FechaRespaldo;
                    cmd.Parameters.Add("@HORARESPALDO", SqlDbType.VarChar, 20).Value = HoraRespaldo;
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        if (!drd.HasRows)
                        {

                        }
                        else
                        {
                            while (drd.Read())
                            {
                                estado = (drd.HasColumn("OK") ? drd["OK"] == DBNull.Value ? "" : drd["OK"].ToString() : "").Trim();
                            }

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

            return estado.Equals("OK");
        }


        public bool INICIAR_CAMBIO_TURNO_PEC()
        {
            bool estado = false;
            string constr = "Provider=vfpoledb;DSN=INTERFASE;";
            OleDbConnection con = new OleDbConnection(constr);
            try
            {
                var sql = $"UPDATE parametro.dbf SET cambioturno = 1";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new System.Data.DataSet();
                da.Fill(ds, "Parametro");
                con.Dispose();
                estado = true;
            }
            catch (Exception ex)
            {
                estado = false;
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }

            }
            return estado;
        }
        public bool VERIFICAR_CAMBIO_TURNO_PEC()
        {
            bool Estado = true;
            string constr = "Provider=vfpoledb;DSN=INTERFASE;";
            OleDbConnection con = new OleDbConnection(constr);
            try
            {
                var sql = "select * from parametro";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.Open();
                DataSet ds = new DataSet(); ;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Estado = row["cambioturno"].ToString() == "False" ? true : false;

                }
                con.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }

            }
            return Estado;
        }
        public bool TERMINAR_CAMBIO_TURNO_PEC()
        {
            string estado = "";
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CAMBIO_TURNO_PEC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PASO", SqlDbType.VarChar, 20).Value = "P2";
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            estado = (drd.HasColumn("OK") ? drd["OK"] == DBNull.Value ? "" : drd["OK"].ToString() : "").Trim();
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


                return estado.Equals("OK");
            }
        }
        public bool DESHACER_CAMBIO_TURNO_PEC()
        {
            string constr = "Provider=vfpoledb;DSN=INTERFASE;";
            bool estado = false;
            OleDbConnection con = new OleDbConnection(constr);
            try
            {
                var sql = $"UPDATE parametro.dbf SET cambioturno = 0";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new System.Data.DataSet();
                da.Fill(ds, "Parametro");
                con.Dispose();
                estado = true;
            }
            catch (Exception ex)
            {
                estado = false;
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }

            }
            return estado;
        }
        public bool BLOQUEAR_DESBLOQUEAR_PLAYA_PEC(bool estado)
        {
            string Respuesta = "";
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CAMBIO_TURNO_PEC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PASO", SqlDbType.VarChar, 20).Value = estado ? "P1" : "P3";
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            Respuesta = (drd.HasColumn("OK") ? drd["OK"] == DBNull.Value ? "" : drd["OK"].ToString() : "").Trim();
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


                return Respuesta.Equals("OK");
            }
        }
        public bool PROCESAR_CAMBIO_TURNO_SIN_CONTROLADOR()
        {
            string estado = "";
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_CAMBIO_TURNO_SIN_CONTROLADOR", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            estado = (drd.HasColumn("OK") ? drd["OK"] == DBNull.Value ? "" : drd["OK"].ToString() : "").Trim();
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
            return estado.Equals("OK");
        }
    }
}
