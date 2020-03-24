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
    public class TS_DAPagoVenta : ITS_DOPagoVenta
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public bool InsertTransVentaPago(TS_BEPago input, SqlTransaction pSqlTransaction)
        {

            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_VENTAP")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = pSqlTransaction.Connection,
                    Transaction = pSqlTransaction
                };
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = input.cdlocal;
                cmd.Parameters.Add("@nroseriemaq", SqlDbType.Char, 15).Value = input.nroseriemaq;
                cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;
                cmd.Parameters.Add("@cdtppago", SqlDbType.Char, 5).Value = input.cdtppago;
                cmd.Parameters.Add("@cdbanco", SqlDbType.Char, 4).Value = input.cdbanco;
                cmd.Parameters.Add("@nrocuenta", SqlDbType.Char, 20).Value = input.nrocuenta;
                cmd.Parameters.Add("@nrocheque", SqlDbType.Char, 20).Value = input.nrocheque;
                cmd.Parameters.Add("@cdtarjeta", SqlDbType.Char, 2).Value = input.cdtarjeta;
                cmd.Parameters.Add("@nrotarjeta", SqlDbType.Char, 20).Value = input.nrotarjeta;
                cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                cmd.Parameters.Add("@fecdocumento", SqlDbType.DateTime, 8).Value = input.fecdocumento;
                cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                cmd.Parameters.Add("@mtopagosol", SqlDbType.Decimal, 9).Value = input.mtopagosol;
                cmd.Parameters.Add("@mtopagodol", SqlDbType.Decimal, 9).Value = input.mtopagodol;
                cmd.Parameters.Add("@flgcierrez", SqlDbType.Bit, 1).Value = input.flgcierrez;
                cmd.Parameters.Add("@turno", SqlDbType.Decimal, 5).Value = input.turno;
                cmd.Parameters.Add("@nroncredito", SqlDbType.Char, 10).Value = input.nroncredito;
                cmd.Parameters.Add("@valoracumula", SqlDbType.Decimal, 9).Value = input.valoracumula;
                flag = cmd.ExecuteNonQuery() > 0;

                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;
        }

        public bool InsertTransVentaPagoMes(string lExtension, TS_BEPago input, SqlTransaction pSqlTransaction)
        {

            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_VENTAPMES")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = pSqlTransaction.Connection,
                    Transaction = pSqlTransaction
                };
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@periodo", SqlDbType.Char, 6).Value = lExtension;
                cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = input.cdlocal;
                cmd.Parameters.Add("@nroseriemaq", SqlDbType.Char, 15).Value = input.nroseriemaq;
                cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;
                cmd.Parameters.Add("@cdtppago", SqlDbType.Char, 5).Value = input.cdtppago;
                cmd.Parameters.Add("@cdbanco", SqlDbType.Char, 4).Value = input.cdbanco;
                cmd.Parameters.Add("@nrocuenta", SqlDbType.Char, 20).Value = input.nrocuenta;
                cmd.Parameters.Add("@nrocheque", SqlDbType.Char, 20).Value = input.nrocheque;
                cmd.Parameters.Add("@cdtarjeta", SqlDbType.Char, 2).Value = input.cdtarjeta;
                cmd.Parameters.Add("@nrotarjeta", SqlDbType.Char, 20).Value = input.nrotarjeta;
                cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                cmd.Parameters.Add("@fecdocumento", SqlDbType.DateTime, 8).Value = input.fecdocumento;
                cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                cmd.Parameters.Add("@mtopagosol", SqlDbType.Decimal, 9).Value = input.mtopagosol;
                cmd.Parameters.Add("@mtopagodol", SqlDbType.Decimal, 9).Value = input.mtopagodol;
                cmd.Parameters.Add("@flgcierrez", SqlDbType.Bit, 1).Value = input.flgcierrez;
                cmd.Parameters.Add("@turno", SqlDbType.Decimal, 5).Value = input.turno;
                cmd.Parameters.Add("@nroncredito", SqlDbType.Char, 10).Value = input.nroncredito;
                cmd.Parameters.Add("@valoracumula", SqlDbType.Decimal, 9).Value = input.valoracumula;
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
