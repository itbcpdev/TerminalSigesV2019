using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System.Data.SqlClient;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOHvale
    {
        bool InsertTransVentaHvale(TS_BECabecera oCabecera, SqlTransaction pSqlTransaction);
    }
}
