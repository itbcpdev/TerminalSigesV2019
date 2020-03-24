using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOPagoVenta
    {
        bool InsertTransVentaPago(TS_BEPago input, SqlTransaction pSqlTransaction);
        bool InsertTransVentaPagoMes(string lExtension, TS_BEPago input, SqlTransaction pSqlTransaction);
    }
}
