using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ITBCP.ServiceSIGES.Infraestructure.DataAcces
{
    public class TS_DAHvale : ITS_DOHvale
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public bool InsertTransVentaHvale(TS_BECabecera input, SqlTransaction pSqlTransaction)
        {

            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_HVALE")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = pSqlTransaction.Connection,
                    Transaction = pSqlTransaction
                };
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@nrovale", SqlDbType.Char, 10).Value = input.nrodocumento;
                cmd.Parameters.Add("@fecvale", SqlDbType.DateTime, 8).Value = input.fecdocumento;
                cmd.Parameters.Add("@cdmoneda", SqlDbType.Char, 1).Value = input.cdmoneda;
                cmd.Parameters.Add("@mtovale", SqlDbType.Decimal, 9).Value = input.mtototal;
                cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 20).Value = input.cdcliente;
                cmd.Parameters.Add("@nroplaca", SqlDbType.VarChar, 250).Value = input.nroplaca;
                cmd.Parameters.Add("@nroseriemaq", SqlDbType.Char, 15).Value = input.nroseriemaq;
                cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;
                cmd.Parameters.Add("@fecdocumento", SqlDbType.DateTime, 8).Value = input.fecdocumento;
                cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                cmd.Parameters.Add("@turno", SqlDbType.Decimal, 5).Value = input.turno;
                flag = cmd.ExecuteNonQuery() > 0;

                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;
        }

    }
}
