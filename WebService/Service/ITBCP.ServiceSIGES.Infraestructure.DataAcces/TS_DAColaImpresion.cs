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
    public class TS_DAColaImpresion : ITS_DOColaImpresion
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public bool InsertColaImpresion(TS_BECabecera cCabecera,TS_BEGrabarConfig cConfiguracion,string lImpresora, string lTrama, string lJson, SqlTransaction pSqlTransaction,string formato)
        {

            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_COLA_IMPRESION")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = pSqlTransaction.Connection,
                    Transaction = pSqlTransaction
                };

                cmd.Parameters.Clear();

                cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = cCabecera.cdtipodoc;
                cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = cCabecera.nrodocumento;
                cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = cCabecera.nropos;
                cmd.Parameters.Add("@fecdocumento", SqlDbType.SmallDateTime, 8).Value = cCabecera.fecdocumento;
                cmd.Parameters.Add("@formato", SqlDbType.Char, 50).Value = formato;
                cmd.Parameters.Add("@impresora", SqlDbType.VarChar, 40).Value = lImpresora;
                cmd.Parameters.Add("@trama", SqlDbType.VarChar, -1).Value = lTrama ?? "";
                cmd.Parameters.Add("@json", SqlDbType.VarChar, -1).Value = lJson;
                cmd.Parameters.Add("@hash", SqlDbType.VarChar, 50).Value = "";
                cmd.Parameters.Add("@impreso", SqlDbType.Bit).Value = cConfiguracion.IsNotPrint;
                cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 120).Value = "";
                cmd.Parameters.Add("@timestamp", SqlDbType.SmallDateTime, 8).Value = DateTime.Now;
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
