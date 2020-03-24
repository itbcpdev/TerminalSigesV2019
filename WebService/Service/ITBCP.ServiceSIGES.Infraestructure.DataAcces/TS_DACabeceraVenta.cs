using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ITBCP.ServiceSIGES.Infraestructure.DataAcces
{
    public class TS_DACabeceraVenta : ITS_DOCabeceraVenta
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public bool InsertTransVentaCabecera(TS_BECabecera input, SqlTransaction pSqlTransaction)
        {

            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_VENTA")
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
                cmd.Parameters.Add("@fecdocumento", SqlDbType.DateTime, 8).Value = input.fecdocumento;
                cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                cmd.Parameters.Add("@fecsistema", SqlDbType.DateTime, 8).Value = input.fecsistema;
                cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                cmd.Parameters.Add("@mtovueltosol", SqlDbType.Decimal, 9).Value = input.mtovueltosol;
                cmd.Parameters.Add("@mtovueltodol", SqlDbType.Decimal, 9).Value = input.mtovueltodol;
                cmd.Parameters.Add("@cdalmacen", SqlDbType.Char, 3).Value = input.cdalmacen;
                cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 20).Value = input.cdcliente;
                cmd.Parameters.Add("@ruccliente", SqlDbType.Char, 15).Value = input.ruccliente;
                cmd.Parameters.Add("@rscliente", SqlDbType.Char, 120).Value = input.rscliente;
                cmd.Parameters.Add("@nroproforma", SqlDbType.Char, 10).Value = input.nroproforma;
                cmd.Parameters.Add("@cdprecio", SqlDbType.Char, 5).Value = input.cdprecio;
                cmd.Parameters.Add("@cdmoneda", SqlDbType.Char, 1).Value = input.cdmoneda;
                cmd.Parameters.Add("@porservicio", SqlDbType.Decimal, 5).Value = input.porservicio;
                cmd.Parameters.Add("@pordscto1", SqlDbType.Decimal, 5).Value = input.pordscto1;
                cmd.Parameters.Add("@pordscto2", SqlDbType.Decimal, 5).Value = input.pordscto2;
                cmd.Parameters.Add("@pordscto3", SqlDbType.Decimal, 5).Value = input.pordscto3;
                cmd.Parameters.Add("@pordsctoeq", SqlDbType.Decimal, 5).Value = input.pordsctoeq;
                cmd.Parameters.Add("@mtonoafecto", SqlDbType.Decimal, 9).Value = input.mtonoafecto;
                cmd.Parameters.Add("@valorvta", SqlDbType.Decimal, 9).Value = input.valorvta;
                cmd.Parameters.Add("@mtodscto", SqlDbType.Decimal, 9).Value = input.mtodscto;
                cmd.Parameters.Add("@mtosubtotal", SqlDbType.Decimal, 9).Value = input.mtosubtotal;
                cmd.Parameters.Add("@mtoservicio", SqlDbType.Decimal, 9).Value = input.mtoservicio;
                cmd.Parameters.Add("@mtoimpuesto", SqlDbType.Decimal, 9).Value = input.mtoimpuesto;
                cmd.Parameters.Add("@mtototal", SqlDbType.Decimal, 9).Value = input.mtototal;
                cmd.Parameters.Add("@cdtranspor", SqlDbType.Char, 20).Value = input.cdtranspor;
                cmd.Parameters.Add("@nroplaca", SqlDbType.VarChar, 250).Value = input.nroplaca;
                cmd.Parameters.Add("@drpartida", SqlDbType.Char, 60).Value = input.drpartida;
                cmd.Parameters.Add("@drdestino", SqlDbType.Char, 60).Value = input.drdestino;
                cmd.Parameters.Add("@cdusuario", SqlDbType.Char, 10).Value = input.cdusuario;
                cmd.Parameters.Add("@cdvendedor", SqlDbType.Char, 10).Value = input.cdvendedor;
                cmd.Parameters.Add("@cdusuanula", SqlDbType.Char, 10).Value = input.cdusuanula;
                cmd.Parameters.Add("@fecanula", SqlDbType.SmallDateTime, 4).Value = input.fecanula;
                cmd.Parameters.Add("@fecanulasis", SqlDbType.SmallDateTime, 4).Value = input.fecanulasis;
                cmd.Parameters.Add("@tipofactura", SqlDbType.Char, 1).Value = input.tipofactura;
                cmd.Parameters.Add("@flgmanual", SqlDbType.Bit, 1).Value = input.flgmanual;
                cmd.Parameters.Add("@tcambio", SqlDbType.Decimal, 9).Value = input.tcambio;
                cmd.Parameters.Add("@nroocompra", SqlDbType.Char, 15).Value = input.nroocompra;
                cmd.Parameters.Add("@flgcierrez", SqlDbType.Bit, 1).Value = input.flgcierrez;
                cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 250).Value = input.observacion;
                cmd.Parameters.Add("@flgmovimiento", SqlDbType.Bit, 1).Value = input.flgmovimiento;
                cmd.Parameters.Add("@referencia", SqlDbType.VarChar, 250).Value = input.referencia;
                cmd.Parameters.Add("@nroserie1", SqlDbType.Char, 15).Value = input.nroserie1;
                cmd.Parameters.Add("@nroserie2", SqlDbType.Char, 10).Value = input.nroserie2;
                cmd.Parameters.Add("@turno", SqlDbType.Decimal, 5).Value = input.turno;
                cmd.Parameters.Add("@nrobonus", SqlDbType.Char, 20).Value = input.nrobonus;
                cmd.Parameters.Add("@nrotarjeta", SqlDbType.Char, 20).Value = input.nrotarjeta;
                cmd.Parameters.Add("@odometro", SqlDbType.Char, 10).Value = input.odometro;
                cmd.Parameters.Add("@archturno", SqlDbType.Bit, 1).Value = input.archturno;
                cmd.Parameters.Add("@marcavehic", SqlDbType.Char, 15).Value = input.marcavehic;
                cmd.Parameters.Add("@mtorecaudo", SqlDbType.Decimal, 9).Value = input.mtorecaudo;
                cmd.Parameters.Add("@inscripcion", SqlDbType.Char, 15).Value = input.inscripcion;
                cmd.Parameters.Add("@chofer", SqlDbType.Char, 40).Value = input.chofer;
                cmd.Parameters.Add("@nrolicencia", SqlDbType.Char, 15).Value = input.nrolicencia;
                cmd.Parameters.Add("@chkespecial", SqlDbType.Bit, 1).Value = input.chkespecial;
                cmd.Parameters.Add("@tipoventa", SqlDbType.Char, 1).Value = input.tipoventa;
                cmd.Parameters.Add("@nrocelular", SqlDbType.Char, 12).Value = input.nrocelular;
                cmd.Parameters.Add("@PtosGanados", SqlDbType.Decimal, 5).Value = input.ptosganados;
                cmd.Parameters.Add("@precio_orig", SqlDbType.Decimal, 9).Value = input.precio_orig;
                cmd.Parameters.Add("@rucinvalido", SqlDbType.Bit, 1).Value = input.rucinvalido;
                cmd.Parameters.Add("@usadecimales", SqlDbType.Bit, 1).Value = input.usadecimales;
                cmd.Parameters.Add("@tipoacumula", SqlDbType.Char, 2).Value = input.TipoAcumula;
                cmd.Parameters.Add("@valoracumula", SqlDbType.Decimal, 9).Value = input.valoracumula;
                cmd.Parameters.Add("@cantcupon", SqlDbType.Decimal, 9).Value = input.cantcupon;
                cmd.Parameters.Add("@c_centralizacion", SqlDbType.VarChar, 50).Value = input.c_centralizacion;
                cmd.Parameters.Add("@mtocanje", SqlDbType.Decimal, 9).Value = input.mtocanje;
                cmd.Parameters.Add("@mtopercepcion", SqlDbType.Decimal, 9).Value = input.MtoPercepcion;
                cmd.Parameters.Add("@CDRUTA", SqlDbType.Char, 10).Value = input.cdruta;
                cmd.Parameters.Add("@Codes", SqlDbType.VarChar, 250).Value = input.codes;
                cmd.Parameters.Add("@codeID", SqlDbType.VarChar, 250).Value = input.codeID;
                cmd.Parameters.Add("@mensaje1", SqlDbType.VarChar, 120).Value = input.mensaje1;
                cmd.Parameters.Add("@mensaje2", SqlDbType.VarChar, 120).Value = input.mensaje2;
                cmd.Parameters.Add("@redondea_indecopi", SqlDbType.Decimal, 9).Value = input.redondea_indecopi;
                cmd.Parameters.Add("@pdf417", SqlDbType.VarChar, 450).Value = input.pdf417;
                cmd.Parameters.Add("@cdhash", SqlDbType.VarChar, 50).Value = input.cdhash;
                cmd.Parameters.Add("@scop", SqlDbType.VarChar, 50).Value = input.scop;
                cmd.Parameters.Add("@nroguia", SqlDbType.VarChar, 50).Value = input.nroguia;
                cmd.Parameters.Add("@porcdetraccion", SqlDbType.Decimal, 5).Value = input.porcdetraccion;
                cmd.Parameters.Add("@mtodetraccion", SqlDbType.Decimal, 9).Value = input.mtodetraccion;
                cmd.Parameters.Add("@ctadetraccion", SqlDbType.Char, 20).Value = input.ctadetraccion;
                cmd.Parameters.Add("@fact_elect", SqlDbType.Bit, 1).Value = input.fact_elect;
                cmd.Parameters.Add("@cdMedio_pago", SqlDbType.Char, 4).Value = input.cdmedio_pago;
                flag = cmd.ExecuteNonQuery() > 0;

                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;
        }

        public bool InsertTransVentaCabeceraMes(string lExtension, TS_BECabecera input, SqlTransaction pSqlTransaction)
        {

            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_VENTAMES")
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
                cmd.Parameters.Add("@fecdocumento", SqlDbType.DateTime, 8).Value = input.fecdocumento;
                cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = input.fecproceso;
                cmd.Parameters.Add("@fecsistema", SqlDbType.DateTime, 8).Value = input.fecsistema;
                cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = input.nropos;
                cmd.Parameters.Add("@mtovueltosol", SqlDbType.Decimal, 9).Value = input.mtovueltosol;
                cmd.Parameters.Add("@mtovueltodol", SqlDbType.Decimal, 9).Value = input.mtovueltodol;
                cmd.Parameters.Add("@cdalmacen", SqlDbType.Char, 3).Value = input.cdalmacen;
                cmd.Parameters.Add("@cdcliente", SqlDbType.Char, 20).Value = input.cdcliente;
                cmd.Parameters.Add("@ruccliente", SqlDbType.Char, 15).Value = input.ruccliente;
                cmd.Parameters.Add("@rscliente", SqlDbType.Char, 120).Value = input.rscliente;
                cmd.Parameters.Add("@nroproforma", SqlDbType.Char, 10).Value = input.nroproforma;
                cmd.Parameters.Add("@cdprecio", SqlDbType.Char, 5).Value = input.cdprecio;
                cmd.Parameters.Add("@cdmoneda", SqlDbType.Char, 1).Value = input.cdmoneda;
                cmd.Parameters.Add("@porservicio", SqlDbType.Decimal, 5).Value = input.porservicio;
                cmd.Parameters.Add("@pordscto1", SqlDbType.Decimal, 5).Value = input.pordscto1;
                cmd.Parameters.Add("@pordscto2", SqlDbType.Decimal, 5).Value = input.pordscto2;
                cmd.Parameters.Add("@pordscto3", SqlDbType.Decimal, 5).Value = input.pordscto3;
                cmd.Parameters.Add("@pordsctoeq", SqlDbType.Decimal, 5).Value = input.pordsctoeq;
                cmd.Parameters.Add("@mtonoafecto", SqlDbType.Decimal, 9).Value = input.mtonoafecto;
                cmd.Parameters.Add("@valorvta", SqlDbType.Decimal, 9).Value = input.valorvta;
                cmd.Parameters.Add("@mtodscto", SqlDbType.Decimal, 9).Value = input.mtodscto;
                cmd.Parameters.Add("@mtosubtotal", SqlDbType.Decimal, 9).Value = input.mtosubtotal;
                cmd.Parameters.Add("@mtoservicio", SqlDbType.Decimal, 9).Value = input.mtoservicio;
                cmd.Parameters.Add("@mtoimpuesto", SqlDbType.Decimal, 9).Value = input.mtoimpuesto;
                cmd.Parameters.Add("@mtototal", SqlDbType.Decimal, 9).Value = input.mtototal;
                cmd.Parameters.Add("@cdtranspor", SqlDbType.Char, 20).Value = input.cdtranspor;
                cmd.Parameters.Add("@nroplaca", SqlDbType.VarChar, 250).Value = input.nroplaca;
                cmd.Parameters.Add("@drpartida", SqlDbType.Char, 60).Value = input.drpartida;
                cmd.Parameters.Add("@drdestino", SqlDbType.Char, 60).Value = input.drdestino;
                cmd.Parameters.Add("@cdusuario", SqlDbType.Char, 10).Value = input.cdusuario;
                cmd.Parameters.Add("@cdvendedor", SqlDbType.Char, 10).Value = input.cdvendedor;
                cmd.Parameters.Add("@cdusuanula", SqlDbType.Char, 10).Value = input.cdusuanula;
                cmd.Parameters.Add("@fecanula", SqlDbType.SmallDateTime, 4).Value = input.fecanula;
                cmd.Parameters.Add("@fecanulasis", SqlDbType.SmallDateTime, 4).Value = input.fecanulasis;
                cmd.Parameters.Add("@tipofactura", SqlDbType.Char, 1).Value = input.tipofactura;
                cmd.Parameters.Add("@flgmanual", SqlDbType.Bit, 1).Value = input.flgmanual;
                cmd.Parameters.Add("@tcambio", SqlDbType.Decimal, 9).Value = input.tcambio;
                cmd.Parameters.Add("@nroocompra", SqlDbType.Char, 15).Value = input.nroocompra;
                cmd.Parameters.Add("@flgcierrez", SqlDbType.Bit, 1).Value = input.flgcierrez;
                cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 250).Value = input.observacion;
                cmd.Parameters.Add("@flgmovimiento", SqlDbType.Bit, 1).Value = input.flgmovimiento;
                cmd.Parameters.Add("@referencia", SqlDbType.VarChar, 250).Value = input.referencia;
                cmd.Parameters.Add("@nroserie1", SqlDbType.Char, 15).Value = input.nroserie1;
                cmd.Parameters.Add("@nroserie2", SqlDbType.Char, 10).Value = input.nroserie2;
                cmd.Parameters.Add("@turno", SqlDbType.Decimal, 5).Value = input.turno;
                cmd.Parameters.Add("@nrobonus", SqlDbType.Char, 20).Value = input.nrobonus;
                cmd.Parameters.Add("@nrotarjeta", SqlDbType.Char, 20).Value = input.nrotarjeta;
                cmd.Parameters.Add("@odometro", SqlDbType.Char, 10).Value = input.odometro;
                cmd.Parameters.Add("@archturno", SqlDbType.Bit, 1).Value = input.archturno;
                cmd.Parameters.Add("@marcavehic", SqlDbType.Char, 15).Value = input.marcavehic;
                cmd.Parameters.Add("@mtorecaudo", SqlDbType.Decimal, 9).Value = input.mtorecaudo;
                cmd.Parameters.Add("@inscripcion", SqlDbType.Char, 15).Value = input.inscripcion;
                cmd.Parameters.Add("@chofer", SqlDbType.Char, 40).Value = input.chofer;
                cmd.Parameters.Add("@nrolicencia", SqlDbType.Char, 15).Value = input.nrolicencia;
                cmd.Parameters.Add("@chkespecial", SqlDbType.Bit, 1).Value = input.chkespecial;
                cmd.Parameters.Add("@tipoventa", SqlDbType.Char, 1).Value = input.tipoventa;
                cmd.Parameters.Add("@nrocelular", SqlDbType.Char, 12).Value = input.nrocelular;
                cmd.Parameters.Add("@PtosGanados", SqlDbType.Decimal, 5).Value = input.ptosganados;
                cmd.Parameters.Add("@precio_orig", SqlDbType.Decimal, 9).Value = input.precio_orig;
                cmd.Parameters.Add("@rucinvalido", SqlDbType.Bit, 1).Value = input.rucinvalido;
                cmd.Parameters.Add("@usadecimales", SqlDbType.Bit, 1).Value = input.usadecimales;
                cmd.Parameters.Add("@tipoacumula", SqlDbType.Char, 2).Value = input.TipoAcumula;
                cmd.Parameters.Add("@valoracumula", SqlDbType.Decimal, 9).Value = input.valoracumula;
                cmd.Parameters.Add("@cantcupon", SqlDbType.Decimal, 9).Value = input.cantcupon;
                cmd.Parameters.Add("@c_centralizacion", SqlDbType.VarChar, 50).Value = input.c_centralizacion;
                cmd.Parameters.Add("@mtocanje", SqlDbType.Decimal, 9).Value = input.mtocanje;
                cmd.Parameters.Add("@mtopercepcion", SqlDbType.Decimal, 9).Value = input.MtoPercepcion;
                cmd.Parameters.Add("@CDRUTA", SqlDbType.Char, 10).Value = input.cdruta;
                cmd.Parameters.Add("@Codes", SqlDbType.VarChar, 250).Value = input.codes;
                cmd.Parameters.Add("@codeID", SqlDbType.VarChar, 250).Value = input.codeID;
                cmd.Parameters.Add("@mensaje1", SqlDbType.VarChar, 120).Value = input.mensaje1;
                cmd.Parameters.Add("@mensaje2", SqlDbType.VarChar, 120).Value = input.mensaje2;
                cmd.Parameters.Add("@redondea_indecopi", SqlDbType.Decimal, 9).Value = input.redondea_indecopi;
                cmd.Parameters.Add("@pdf417", SqlDbType.VarChar, 450).Value = input.pdf417;
                cmd.Parameters.Add("@cdhash", SqlDbType.VarChar, 50).Value = input.cdhash;
                cmd.Parameters.Add("@scop", SqlDbType.VarChar, 50).Value = input.scop;
                cmd.Parameters.Add("@nroguia", SqlDbType.VarChar, 50).Value = input.nroguia;
                cmd.Parameters.Add("@porcdetraccion", SqlDbType.Decimal, 5).Value = input.porcdetraccion;
                cmd.Parameters.Add("@mtodetraccion", SqlDbType.Decimal, 9).Value = input.mtodetraccion;
                cmd.Parameters.Add("@ctadetraccion", SqlDbType.Char, 20).Value = input.ctadetraccion;
                cmd.Parameters.Add("@fact_elect", SqlDbType.Bit, 1).Value = input.fact_elect;
                cmd.Parameters.Add("@cdMedio_pago", SqlDbType.Char, 4).Value = input.cdmedio_pago;
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
