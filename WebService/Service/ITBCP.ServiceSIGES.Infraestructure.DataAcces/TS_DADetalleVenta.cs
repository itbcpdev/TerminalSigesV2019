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
    public class TS_DADetalleVenta : ITS_DODetalleVenta
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public bool InsertTransVentaDetalle(TS_BEArticulo item, TS_BECabecera oCabecera, SqlTransaction pSqlTransaction)
        {

            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_VENTAD")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = pSqlTransaction.Connection,
                    Transaction = pSqlTransaction
                };
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = item.cdlocal;
                cmd.Parameters.Add("@nroseriemaq", SqlDbType.Char, 15).Value = item.nroseriemaq;
                cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = item.cdtipodoc;
                cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = item.nrodocumento;
                cmd.Parameters.Add("@nroitem", SqlDbType.Decimal, 5).Value = item.item;
                cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = item.cdarticulo;
                cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = oCabecera.nropos;
                cmd.Parameters.Add("@fecdocumento", SqlDbType.DateTime, 8).Value = oCabecera.fecdocumento;
                cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = oCabecera.fecproceso;
                cmd.Parameters.Add("@cdalterna", SqlDbType.Char, 20).Value = item.cdalterna;// oVenta.cdalterna;
                cmd.Parameters.Add("@talla", SqlDbType.Char, 10).Value = item.talla;// oVenta.talla;
                cmd.Parameters.Add("@cdvendedor", SqlDbType.Char, 10).Value = item.cdvendedor;// oVenta.cdvendedor;
                cmd.Parameters.Add("@impuesto", SqlDbType.Decimal, 5).Value = item.impuesto;
                cmd.Parameters.Add("@pordscto1", SqlDbType.Decimal, 5).Value = item.pordscto1;
                cmd.Parameters.Add("@pordscto2", SqlDbType.Decimal, 5).Value = item.pordscto2;
                cmd.Parameters.Add("@pordscto3", SqlDbType.Decimal, 5).Value = item.pordscto3;
                cmd.Parameters.Add("@pordsctoeq", SqlDbType.Decimal, 5).Value = item.pordsctoeq;
                cmd.Parameters.Add("@cantidad", SqlDbType.Decimal, 9).Value = item.cantidad;
                cmd.Parameters.Add("@cant_ncredito", SqlDbType.Decimal, 9).Value = item.cant_ncredito;// oVenta.cant_ncredito;
                cmd.Parameters.Add("@precio", SqlDbType.Decimal, 9).Value = item.precio;
                cmd.Parameters.Add("@mtonoafecto", SqlDbType.Decimal, 9).Value = item.mtonoafecto;
                cmd.Parameters.Add("@valorvta", SqlDbType.Decimal, 9).Value = item.valorvta;
                cmd.Parameters.Add("@mtodscto", SqlDbType.Decimal, 9).Value = item.mtodscto;
                cmd.Parameters.Add("@mtosubtotal", SqlDbType.Decimal, 9).Value = item.subtotal;
                cmd.Parameters.Add("@mtoservicio", SqlDbType.Decimal, 9).Value = item.mtoservicio;
                cmd.Parameters.Add("@mtoimpuesto", SqlDbType.Decimal, 9).Value = item.mtoimpuesto;
                cmd.Parameters.Add("@mtototal", SqlDbType.Decimal, 9).Value = item.total;
                cmd.Parameters.Add("@flgcierrez", SqlDbType.Bit, 1).Value = item.flgcierrez;// oVenta.flgcierrez;
                cmd.Parameters.Add("@cara", SqlDbType.Char, 2).Value = item.cara;
                cmd.Parameters.Add("@nrogasboy", SqlDbType.Char, 20).Value = item.nrogasboy;
                cmd.Parameters.Add("@turno", SqlDbType.Decimal, 5).Value = item.turno;
                cmd.Parameters.Add("@nroguia", SqlDbType.Char, 10).Value = oCabecera.nroguia;
                cmd.Parameters.Add("@nroproforma", SqlDbType.Char, 10).Value = oCabecera.nroproforma;
                cmd.Parameters.Add("@moverstock", SqlDbType.Bit, 1).Value = item.moverstock;
                cmd.Parameters.Add("@glosa", SqlDbType.Text, 16).Value = item.glosa;
                cmd.Parameters.Add("@archturno", SqlDbType.Bit, 1).Value = item.archturno;// oVenta.archturno;
                cmd.Parameters.Add("@manguera", SqlDbType.Char, 1).Value = item.manguera;// oVenta.manguera;
                cmd.Parameters.Add("@costo", SqlDbType.Decimal, 9).Value = item.costo;// oVenta.costo;
                cmd.Parameters.Add("@precio_orig", SqlDbType.Decimal, 9).Value = item.precio_orig;
                cmd.Parameters.Add("@PtosGanados", SqlDbType.Decimal, 9).Value = oCabecera.ptosganados;
                cmd.Parameters.Add("@precioafiliacion", SqlDbType.Decimal, 9).Value = item.precioafiliacion;// oVenta.precioafiliacion;
                cmd.Parameters.Add("@tipoacumula", SqlDbType.Char, 25).Value = oCabecera.TipoAcumula;
                cmd.Parameters.Add("@valoracumula", SqlDbType.Decimal, 9).Value = oCabecera.valoracumula;
                cmd.Parameters.Add("@Costo_Venta", SqlDbType.Decimal, 9).Value = item.costo_venta;
                cmd.Parameters.Add("@TipoSuma", SqlDbType.VarChar, 50).Value = item.tiposuma;// oVenta.tiposuma;
                cmd.Parameters.Add("@mtopercepcion", SqlDbType.Decimal, 9).Value = oCabecera.MtoPercepcion;
                cmd.Parameters.Add("@Cdpack", SqlDbType.VarChar, 20).Value = item.cdpack;
                cmd.Parameters.Add("@trfgratuita", SqlDbType.Bit, 1).Value = item.trfgratuita;// oVenta.trfgratuita;
                cmd.Parameters.Add("@redondea_indecopi", SqlDbType.Decimal, 9).Value = item.redondea_indecopi;
                cmd.Parameters.Add("@porcdetraccion", SqlDbType.Decimal, 5).Value = item.porcdetraccion;
                cmd.Parameters.Add("@mtodetraccion", SqlDbType.Decimal, 9).Value = item.mtodetraccion;
                cmd.Parameters.Add("@cdarticulosunat", SqlDbType.VarChar, 20).Value = item.cdarticulosunat;
                flag = cmd.ExecuteNonQuery() > 0;

                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;
        }
        public bool InsertTransVentaDetalleMes(string lExtension, TS_BEArticulo item, TS_BECabecera oCabecera, SqlTransaction pSqlTransaction)
        {

            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_VENTADMES")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = pSqlTransaction.Connection,
                    Transaction = pSqlTransaction
                };
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@periodo", SqlDbType.Char, 6).Value = lExtension;
                cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = item.cdlocal;
                cmd.Parameters.Add("@nroseriemaq", SqlDbType.Char, 15).Value = item.nroseriemaq;
                cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = item.cdtipodoc;
                cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = item.nrodocumento;
                cmd.Parameters.Add("@nroitem", SqlDbType.Decimal, 5).Value = item.item;
                cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = item.cdarticulo;
                cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = oCabecera.nropos;
                cmd.Parameters.Add("@fecdocumento", SqlDbType.DateTime, 8).Value = oCabecera.fecdocumento;
                cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = oCabecera.fecproceso;
                cmd.Parameters.Add("@cdalterna", SqlDbType.Char, 20).Value = item.cdalterna;// oVenta.cdalterna;
                cmd.Parameters.Add("@talla", SqlDbType.Char, 10).Value = item.talla;// oVenta.talla;
                cmd.Parameters.Add("@cdvendedor", SqlDbType.Char, 10).Value = item.cdvendedor;// oVenta.cdvendedor;
                cmd.Parameters.Add("@impuesto", SqlDbType.Decimal, 5).Value = item.impuesto;
                cmd.Parameters.Add("@pordscto1", SqlDbType.Decimal, 5).Value = item.pordscto1;
                cmd.Parameters.Add("@pordscto2", SqlDbType.Decimal, 5).Value = item.pordscto2;
                cmd.Parameters.Add("@pordscto3", SqlDbType.Decimal, 5).Value = item.pordscto3;
                cmd.Parameters.Add("@pordsctoeq", SqlDbType.Decimal, 5).Value = item.pordsctoeq;
                cmd.Parameters.Add("@cantidad", SqlDbType.Decimal, 9).Value = item.cantidad;
                cmd.Parameters.Add("@cant_ncredito", SqlDbType.Decimal, 9).Value = item.cant_ncredito;// oVenta.cant_ncredito;
                cmd.Parameters.Add("@precio", SqlDbType.Decimal, 9).Value = item.precio;
                cmd.Parameters.Add("@mtonoafecto", SqlDbType.Decimal, 9).Value = item.mtonoafecto;
                cmd.Parameters.Add("@valorvta", SqlDbType.Decimal, 9).Value = item.valorvta;
                cmd.Parameters.Add("@mtodscto", SqlDbType.Decimal, 9).Value = item.mtodscto;
                cmd.Parameters.Add("@mtosubtotal", SqlDbType.Decimal, 9).Value = item.subtotal;
                cmd.Parameters.Add("@mtoservicio", SqlDbType.Decimal, 9).Value = item.mtoservicio;
                cmd.Parameters.Add("@mtoimpuesto", SqlDbType.Decimal, 9).Value = item.mtoimpuesto;
                cmd.Parameters.Add("@mtototal", SqlDbType.Decimal, 9).Value = item.total;
                cmd.Parameters.Add("@flgcierrez", SqlDbType.Bit, 1).Value = item.flgcierrez;// oVenta.flgcierrez;
                cmd.Parameters.Add("@cara", SqlDbType.Char, 2).Value = item.cara;
                cmd.Parameters.Add("@nrogasboy", SqlDbType.Char, 20).Value = item.nrogasboy;
                cmd.Parameters.Add("@turno", SqlDbType.Decimal, 5).Value = item.turno;
                cmd.Parameters.Add("@nroguia", SqlDbType.Char, 10).Value = oCabecera.nroguia;
                cmd.Parameters.Add("@nroproforma", SqlDbType.Char, 10).Value = oCabecera.nroproforma;
                cmd.Parameters.Add("@moverstock", SqlDbType.Bit, 1).Value = item.moverstock;
                cmd.Parameters.Add("@glosa", SqlDbType.Text, 16).Value = item.glosa;
                cmd.Parameters.Add("@archturno", SqlDbType.Bit, 1).Value = item.archturno;// oVenta.archturno;
                cmd.Parameters.Add("@manguera", SqlDbType.Char, 1).Value = item.manguera;// oVenta.manguera;
                cmd.Parameters.Add("@costo", SqlDbType.Decimal, 9).Value = item.costo;// oVenta.costo;
                cmd.Parameters.Add("@precio_orig", SqlDbType.Decimal, 9).Value = item.precio_orig;
                cmd.Parameters.Add("@PtosGanados", SqlDbType.Decimal, 9).Value = oCabecera.ptosganados;
                cmd.Parameters.Add("@precioafiliacion", SqlDbType.Decimal, 9).Value = item.precioafiliacion;// oVenta.precioafiliacion;
                cmd.Parameters.Add("@tipoacumula", SqlDbType.Char, 25).Value = oCabecera.TipoAcumula;
                cmd.Parameters.Add("@valoracumula", SqlDbType.Decimal, 9).Value = oCabecera.valoracumula;
                cmd.Parameters.Add("@Costo_Venta", SqlDbType.Decimal, 9).Value = item.costo_venta;
                cmd.Parameters.Add("@TipoSuma", SqlDbType.VarChar, 50).Value = item.tiposuma;// oVenta.tiposuma;
                cmd.Parameters.Add("@mtopercepcion", SqlDbType.Decimal, 9).Value = oCabecera.MtoPercepcion;
                cmd.Parameters.Add("@Cdpack", SqlDbType.VarChar, 20).Value = item.cdpack;
                cmd.Parameters.Add("@trfgratuita", SqlDbType.Bit, 1).Value = item.trfgratuita;// oVenta.trfgratuita;
                cmd.Parameters.Add("@redondea_indecopi", SqlDbType.Decimal, 9).Value = item.redondea_indecopi;
                cmd.Parameters.Add("@porcdetraccion", SqlDbType.Decimal, 5).Value = item.porcdetraccion;
                cmd.Parameters.Add("@mtodetraccion", SqlDbType.Decimal, 9).Value = item.mtodetraccion;
                cmd.Parameters.Add("@cdarticulosunat", SqlDbType.VarChar, 20).Value = item.cdarticulosunat;
                flag = cmd.ExecuteNonQuery() > 0;

                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;
        }
        public bool InsertTransVentaG(TS_BEVentag input, SqlTransaction pSqlTransaction)
        {
            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_VENTAG")
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
                cmd.Parameters.Add("@fecdocumento", SqlDbType.SmallDateTime, 4).Value = input.fecdocumento;
                cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                cmd.Parameters.Add("@fecanula", SqlDbType.SmallDateTime, 4).Value = input.fecanula;
                cmd.Parameters.Add("@fecanulasis", SqlDbType.SmallDateTime, 4).Value = input.fecanulasis;
                cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 15).Value = input.cdcliente;
                cmd.Parameters.Add("@declarado", SqlDbType.Bit, 1).Value = input.declarado;
                cmd.Parameters.Add("@anulado", SqlDbType.Bit, 1).Value = input.anulado;
                flag = cmd.ExecuteNonQuery() > 0;

                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;

        }
        public bool InsertTransVentaR(TS_BEVentar input, SqlTransaction pSqlTransaction)
        {
            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand command = new SqlCommand("SP_ITBCP_INSERTAR_VENTAR")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = pSqlTransaction.Connection,
                    Transaction = pSqlTransaction
                };
                command.Parameters.Clear();
                command.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = input.cdlocal;
                command.Parameters.Add("@fecdocumento", SqlDbType.SmallDateTime, 4).Value = input.fecdocumento;
                command.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                flag = command.ExecuteNonQuery() > 0;

                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;

        }
        
        public bool InsertTransVentaD(TS_BEArticulo item, TS_BECabecera oCabecera, SqlTransaction pSqlTransaction)
        {

            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_VENTAD")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = pSqlTransaction.Connection,
                    Transaction = pSqlTransaction
                };
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = item.cdlocal;
                cmd.Parameters.Add("@nroseriemaq", SqlDbType.Char, 15).Value = item.nroseriemaq;
                cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = item.cdtipodoc;
                cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = item.nrodocumento;
                cmd.Parameters.Add("@nroitem", SqlDbType.Decimal, 5).Value = item.item;
                cmd.Parameters.Add("@cdarticulo", SqlDbType.Char, 20).Value = item.cdarticulo;
                cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = oCabecera.nropos;
                cmd.Parameters.Add("@fecdocumento", SqlDbType.DateTime, 8).Value = oCabecera.fecdocumento;
                cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = oCabecera.fecproceso;
                cmd.Parameters.Add("@cdalterna", SqlDbType.Char, 20).Value = item.cdalterna;// oVenta.cdalterna;
                cmd.Parameters.Add("@talla", SqlDbType.Char, 10).Value = item.talla;// oVenta.talla;
                cmd.Parameters.Add("@cdvendedor", SqlDbType.Char, 10).Value = item.cdvendedor;// oVenta.cdvendedor;
                cmd.Parameters.Add("@impuesto", SqlDbType.Decimal, 5).Value = item.impuesto;
                cmd.Parameters.Add("@pordscto1", SqlDbType.Decimal, 5).Value = item.pordscto1;
                cmd.Parameters.Add("@pordscto2", SqlDbType.Decimal, 5).Value = item.pordscto2;
                cmd.Parameters.Add("@pordscto3", SqlDbType.Decimal, 5).Value = item.pordscto3;
                cmd.Parameters.Add("@pordsctoeq", SqlDbType.Decimal, 5).Value = item.pordsctoeq;
                cmd.Parameters.Add("@cantidad", SqlDbType.Decimal, 9).Value = item.cantidad;
                cmd.Parameters.Add("@cant_ncredito", SqlDbType.Decimal, 9).Value = item.cant_ncredito;// oVenta.cant_ncredito;
                cmd.Parameters.Add("@precio", SqlDbType.Decimal, 9).Value = item.precio;
                cmd.Parameters.Add("@mtonoafecto", SqlDbType.Decimal, 9).Value = item.mtonoafecto;
                cmd.Parameters.Add("@valorvta", SqlDbType.Decimal, 9).Value = item.valorvta;
                cmd.Parameters.Add("@mtodscto", SqlDbType.Decimal, 9).Value = item.mtodscto;
                cmd.Parameters.Add("@mtosubtotal", SqlDbType.Decimal, 9).Value = oCabecera.mtosubtotal;
                cmd.Parameters.Add("@mtoservicio", SqlDbType.Decimal, 9).Value = item.mtoservicio;
                cmd.Parameters.Add("@mtoimpuesto", SqlDbType.Decimal, 9).Value = item.mtoimpuesto;
                cmd.Parameters.Add("@mtototal", SqlDbType.Decimal, 9).Value = oCabecera.mtototal;
                cmd.Parameters.Add("@flgcierrez", SqlDbType.Bit, 1).Value = item.flgcierrez;// oVenta.flgcierrez;
                cmd.Parameters.Add("@cara", SqlDbType.Char, 2).Value = item.cara;
                cmd.Parameters.Add("@nrogasboy", SqlDbType.Char, 20).Value = item.nrogasboy;
                cmd.Parameters.Add("@turno", SqlDbType.Decimal, 5).Value = item.turno;
                cmd.Parameters.Add("@nroguia", SqlDbType.Char, 10).Value = oCabecera.nroguia;
                cmd.Parameters.Add("@nroproforma", SqlDbType.Char, 10).Value = oCabecera.nroproforma;
                cmd.Parameters.Add("@moverstock", SqlDbType.Bit, 1).Value = item.moverstock;
                cmd.Parameters.Add("@glosa", SqlDbType.Text, 16).Value = item.glosa;
                cmd.Parameters.Add("@archturno", SqlDbType.Bit, 1).Value = item.archturno;// oVenta.archturno;
                cmd.Parameters.Add("@manguera", SqlDbType.Char, 1).Value = item.manguera;// oVenta.manguera;
                cmd.Parameters.Add("@costo", SqlDbType.Decimal, 9).Value = item.costo;// oVenta.costo;
                cmd.Parameters.Add("@precio_orig", SqlDbType.Decimal, 9).Value = item.precio_orig;
                cmd.Parameters.Add("@PtosGanados", SqlDbType.Decimal, 9).Value = oCabecera.ptosganados;
                cmd.Parameters.Add("@precioafiliacion", SqlDbType.Decimal, 9).Value = item.precioafiliacion;// oVenta.precioafiliacion;
                cmd.Parameters.Add("@tipoacumula", SqlDbType.Char, 25).Value = oCabecera.TipoAcumula;
                cmd.Parameters.Add("@valoracumula", SqlDbType.Decimal, 9).Value = oCabecera.valoracumula;
                cmd.Parameters.Add("@Costo_Venta", SqlDbType.Decimal, 9).Value = item.costo_venta;
                cmd.Parameters.Add("@TipoSuma", SqlDbType.VarChar, 50).Value = item.tiposuma;// oVenta.tiposuma;
                cmd.Parameters.Add("@mtopercepcion", SqlDbType.Decimal, 9).Value = oCabecera.MtoPercepcion;
                cmd.Parameters.Add("@Cdpack", SqlDbType.VarChar, 20).Value = item.cdpack;
                cmd.Parameters.Add("@trfgratuita", SqlDbType.Bit, 1).Value = item.trfgratuita;// oVenta.trfgratuita;
                cmd.Parameters.Add("@redondea_indecopi", SqlDbType.Decimal, 9).Value = item.redondea_indecopi;
                cmd.Parameters.Add("@porcdetraccion", SqlDbType.Decimal, 5).Value = item.porcdetraccion;
                cmd.Parameters.Add("@mtodetraccion", SqlDbType.Decimal, 9).Value = item.mtodetraccion;
                cmd.Parameters.Add("@cdarticulosunat", SqlDbType.VarChar, 20).Value = item.cdarticulosunat;
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
