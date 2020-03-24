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
    public class TS_DAStock : ITS_DOStock
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public bool UpdateStock(TS_BEParametro oParametro, string cdarticulo, decimal cantidad, TS_BECabecera oCabecera, TS_BELoadInput oLoading, SqlTransaction pSqlTransaction)
        {
            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand command = new SqlCommand("SP_ITBCP_ACTUALIZAR_STOCK")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = pSqlTransaction.Connection,
                    Transaction = pSqlTransaction
                };
                command.Parameters.Clear();
                command.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = oCabecera.cdlocal;
                command.Parameters.Add("@cdalmacen", SqlDbType.Char, 4).Value = oCabecera.cdalmacen;
                command.Parameters.Add("@cdarticulo", SqlDbType.VarChar, 20).Value = cdarticulo;
                command.Parameters.Add("@talla", SqlDbType.VarChar, 10).Value = "";
                command.Parameters.Add("@fecinicial", SqlDbType.SmallDateTime, 4).Value = oParametro.fecinstall;
                command.Parameters.Add("@stockinicial", SqlDbType.Decimal, 5).Value = 0;
                command.Parameters.Add("@monctoinicial", SqlDbType.Char, 1).Value = oParametro.monsistema;
                command.Parameters.Add("@ctoinicial", SqlDbType.Decimal, 5).Value = 0;
                command.Parameters.Add("@fecinventario", SqlDbType.SmallDateTime, 4).Value = oParametro.fecinstall;
                command.Parameters.Add("@stockinventario", SqlDbType.Decimal, 5).Value = 0;
                command.Parameters.Add("@monctoinventario", SqlDbType.Char, 1).Value = oParametro.monsistema;
                command.Parameters.Add("@ctoinventario", SqlDbType.Decimal, 5).Value = 0;
                command.Parameters.Add("@cantidad", SqlDbType.Decimal, 5).Value = cantidad;
                command.Parameters.Add("@monctorepo", SqlDbType.Char, 1).Value = oParametro.monsistema;
                command.Parameters.Add("@ctoreposicion", SqlDbType.Decimal, 5).Value = 0;
                command.Parameters.Add("@usuventa", SqlDbType.Char, 10).Value = oLoading.cdusuario;
                command.Parameters.Add("@fecventa", SqlDbType.SmallDateTime, 4).Value = oCabecera.fecdocumento;

                flag = command.ExecuteNonQuery() > 0;

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
