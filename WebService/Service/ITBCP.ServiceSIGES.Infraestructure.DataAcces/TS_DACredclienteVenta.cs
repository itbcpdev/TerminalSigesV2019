using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
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
    public class TS_DACredclienteVenta : ITS_DOCredclienteVenta
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;
        public bool InsertTransVentaCredcliente(TS_BECabecera input, SqlTransaction pSqlTransaction)
        {

            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_CREDITO_CLIENTE")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = pSqlTransaction.Connection,
                    Transaction = pSqlTransaction
                };
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = input.cdtipodoc;
                cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = input.nrodocumento;
                cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = input.cdlocal;
                cmd.Parameters.Add("@cdalmacen", SqlDbType.Char, 3).Value = input.cdalmacen;
                cmd.Parameters.Add("@fecdocumento", SqlDbType.DateTime, 8).Value = input.fecdocumento;
                cmd.Parameters.Add("@fecvencimiento", SqlDbType.DateTime, 8).Value = input.fecdocumento;
                cmd.Parameters.Add("@fecsistema", SqlDbType.DateTime, 8).Value = input.fecsistema;
                cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 20).Value = input.cdcliente;
                cmd.Parameters.Add("@cdmoneda", SqlDbType.Char, 1).Value = input.cdmoneda;
                cmd.Parameters.Add("@mtototal", SqlDbType.Decimal, 9).Value = input.mtototal;
                cmd.Parameters.Add("@mtoemision", SqlDbType.Decimal, 9).Value = input.mtototal;
                cmd.Parameters.Add("@mtosoles", SqlDbType.Decimal, 9).Value = input.mtototal;
                cmd.Parameters.Add("@tcambio", SqlDbType.Decimal, 9).Value = input.tcambio;
                cmd.Parameters.Add("@cdvendedor", SqlDbType.Char, 10).Value = input.cdvendedor;
                cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
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
