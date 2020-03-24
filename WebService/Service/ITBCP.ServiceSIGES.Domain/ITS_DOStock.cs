using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOStock
    {
        bool UpdateStock(TS_BEParametro cParametro, string cdarticulo, decimal cantidad, TS_BECabecera oCabecera, TS_BELoadInput oLoading, SqlTransaction pSqlTransaction);
    }
}
