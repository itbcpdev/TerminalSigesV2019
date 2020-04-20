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
    public interface ITS_DODetalleVenta
    {
        bool InsertTransVentaDetalle(TS_BEArticulo input, TS_BECabecera oCabecera, TS_BEMascara mascara, SqlTransaction pSqlTransaction);
        bool InsertTransVentaDetalleMes(string lExtension, TS_BEArticulo input, TS_BECabecera oCabecera, TS_BEMascara mascara, SqlTransaction pSqlTransaction);
        bool InsertTransVentaG(TS_BEVentag input, SqlTransaction pSqlTransaction);
        bool InsertTransVentaR(TS_BEVentar input, SqlTransaction pSqlTransaction);
        bool InsertTransVentaD(TS_BEArticulo item, TS_BECabecera oCabecera, SqlTransaction pSqlTransaction);
    }
}
