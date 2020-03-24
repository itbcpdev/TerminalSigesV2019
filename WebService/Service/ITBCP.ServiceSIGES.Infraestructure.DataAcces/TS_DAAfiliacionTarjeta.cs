using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Infraestructure.DataAcces
{
    public class TS_DAAfiliacionTarjeta : ITS_DOAfiliacionTarjeta
    {
        public bool INSERT_AFILIACION_PUNTOS(TS_BECabecera cCabecera, TS_BEArticulo cDetalles, TS_BEClienteInput cCliente, SqlTransaction oSqlTransaction)
        {
            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_AFILIACION_PUNTOS")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = oSqlTransaction.Connection,
                    Transaction = oSqlTransaction
                };

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = cCabecera.cdlocal;
                cmd.Parameters.Add("@TarjAfiliacion", SqlDbType.Char, 20).Value = cCabecera.nrobonus;
                cmd.Parameters.Add("@tipo", SqlDbType.Char, 5).Value = "V";
                cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = cCabecera.nropos;
                cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = cCabecera.cdtipodoc;
                cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = cCabecera.nrodocumento;
                cmd.Parameters.Add("@cdproducto", SqlDbType.Char, 20).Value = cDetalles.cdarticulo;
                cmd.Parameters.Add("@fecha", SqlDbType.DateTime, 20).Value = cCabecera.fecproceso;
                cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = cCabecera.fecproceso;
                cmd.Parameters.Add("@total", SqlDbType.Decimal, 18).Value = cDetalles.mtototal;// oVenta.cdalterna;
                cmd.Parameters.Add("@cantidad", SqlDbType.Decimal, 18).Value = cDetalles.cantidad;// oVenta.talla;
                cmd.Parameters.Add("@Puntos", SqlDbType.Decimal, 10).Value = cDetalles.ptosganados;// oVenta.cdvendedor;
                cmd.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = "";
                cmd.Parameters.Add("@enviado", SqlDbType.Bit, 5).Value = null;
                cmd.Parameters.Add("@canjeados", SqlDbType.Decimal, 5).Value = null;
                cmd.Parameters.Add("@cdusuario", SqlDbType.VarChar, 10).Value = cCabecera.cdusuario;
                cmd.Parameters.Add("@TArjAfiliacion_Traspaso", SqlDbType.VarChar, 5).Value = null;
                cmd.Parameters.Add("@valoracumula", SqlDbType.Decimal, 9).Value = cDetalles.valoracumula;
                cmd.Parameters.Add("@item", SqlDbType.TinyInt, 9).Value = cDetalles.item;// oVenta.cant_ncredito;

                flag = cmd.ExecuteNonQuery() > 0;

                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;
        }

        public TS_BEMensaje OBTENER_PUNTOS_POR_PRODUCTO(TS_BECabecera cCabecera, TS_BEClienteInput cCliente, TS_BEArticulo Producto, SqlTransaction oSqlTransaction)
        {
            TS_BEMensaje mensaje = new TS_BEMensaje("", false);

            try
            {
                SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_PUNTOS_GANADOS")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = oSqlTransaction.Connection,
                    Transaction = oSqlTransaction
                };

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@NROTARJETA", SqlDbType.Char, 25).Value = (cCliente.tarjAfiliacion ?? "").Trim();
                cmd.Parameters.Add("@CDPRODUCTO", SqlDbType.Char, 25).Value = (Producto.cdarticulo ?? "").Trim();
                cmd.Parameters.Add("@TOTAL", SqlDbType.Decimal, 18).Value = Producto.total;
                cmd.Parameters.Add("@CANTIDAD", SqlDbType.Decimal, 18).Value = Producto.cantidad;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    while (drd.Read())
                    {
                        cCabecera.ptosganados += drd.HasColumn("ptosganados") ? drd["ptosganados"] == DBNull.Value ? 0 : Convert.ToInt32(drd["ptosganados"]) : 0;
                        cCabecera.valoracumula += drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["valoracumula"]) : 0;
                        Producto.ptosganados = drd.HasColumn("ptosganados") ? drd["ptosganados"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["ptosganados"]) : 0;
                        Producto.valoracumula = drd.HasColumn("valoracumula") ? drd["valoracumula"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["valoracumula"]) : 0;
                        mensaje.mensaje = drd.HasColumn("mensaje") ? drd["mensaje"] == DBNull.Value ? "" : drd["mensaje"].ToString() : "";
                        mensaje.Ok = drd.HasColumn("OK") ? drd["OK"] == DBNull.Value ? false : Convert.ToBoolean(drd["OK"]) : false;
                    }
                }
                cmd.Dispose();
            }

            catch (Exception exception)
            {
                throw exception;
            }

            return mensaje;
        }

        public bool UPDATE_AFILIACION_PUNTOS(TS_BECabecera cCabecera, TS_BEArticulo cDetalles, SqlTransaction oSqlTransaction)
        {
            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA_PUNTOS_GANADOS")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = oSqlTransaction.Connection,
                    Transaction = oSqlTransaction
                };

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@TarjAfiliacion", SqlDbType.Char, 20).Value = cCabecera.nrobonus;
                cmd.Parameters.Add("@Puntos", SqlDbType.Decimal, 10).Value = cDetalles.ptosganados;
                cmd.Parameters.Add("@valoracumula", SqlDbType.Decimal, 9).Value = cDetalles.valoracumula;
                cmd.Parameters.Add("@fechaultconsumo", SqlDbType.SmallDateTime, 25).Value = cCabecera.fecdocumento;
                flag = cmd.ExecuteNonQuery() > 0;

                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;
        }

        public bool INSERT_AFILIACION_PUNTOS_CANJE(TS_BECabecera cCabecera, TS_BEArticulo cDetalles, TS_BEClienteInput cCliente, SqlTransaction oSqlTransaction)
        {
            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_AFILIACION_PUNTOS")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = oSqlTransaction.Connection,
                    Transaction = oSqlTransaction
                };

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@cdlocal", SqlDbType.Char, 3).Value = cCabecera.cdlocal;
                cmd.Parameters.Add("@TarjAfiliacion", SqlDbType.Char, 20).Value = cCabecera.nrobonus;
                cmd.Parameters.Add("@tipo", SqlDbType.Char, 5).Value = "C";
                cmd.Parameters.Add("@nropos", SqlDbType.Char, 10).Value = cCabecera.nropos;
                cmd.Parameters.Add("@cdtipodoc", SqlDbType.Char, 5).Value = cCabecera.cdtipodoc;
                cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = cCabecera.nrodocumento;
                cmd.Parameters.Add("@cdproducto", SqlDbType.Char, 20).Value = cDetalles.cdarticulo;
                cmd.Parameters.Add("@fecha", SqlDbType.DateTime, 20).Value = cCabecera.fecproceso;
                cmd.Parameters.Add("@fecproceso", SqlDbType.SmallDateTime, 4).Value = cCabecera.fecproceso;
                cmd.Parameters.Add("@total", SqlDbType.Decimal, 18).Value = cDetalles.mtototal;// oVenta.cdalterna;
                cmd.Parameters.Add("@cantidad", SqlDbType.Decimal, 18).Value = cDetalles.cantidad;// oVenta.talla;
                cmd.Parameters.Add("@Puntos", SqlDbType.Decimal, 10).Value = cDetalles.valor_puntos * cDetalles.cantidad;// oVenta.cdvendedor;
                cmd.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = "";
                cmd.Parameters.Add("@enviado", SqlDbType.Bit, 5).Value = null;
                cmd.Parameters.Add("@canjeados", SqlDbType.Decimal, 11).Value = cDetalles.config.Equals("POR") ? cDetalles.cantidad * cDetalles.valor_acumulado : cDetalles.cantidad * cDetalles.valor_puntos;
                cmd.Parameters.Add("@cdusuario", SqlDbType.VarChar, 10).Value = cCabecera.cdusuario;
                cmd.Parameters.Add("@TArjAfiliacion_Traspaso", SqlDbType.VarChar, 5).Value = null;
                cmd.Parameters.Add("@valoracumula", SqlDbType.Decimal, 9).Value = cDetalles.valor_acumulado * cDetalles.cantidad;
                cmd.Parameters.Add("@item", SqlDbType.TinyInt, 9).Value = cDetalles.item;// oVenta.cant_ncredito;

                flag = cmd.ExecuteNonQuery() > 0;

                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;
        }

        public bool INSERT_AFILIACION_TARJETA(TS_BEClienteInput cCliente, SqlTransaction oSqlTransaction)
        {
            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_AFILIACION_TARJETA")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = oSqlTransaction.Connection,
                    Transaction = oSqlTransaction
                };

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@TARJAFILIACION", SqlDbType.VarChar, 20).Value = cCliente.tarjAfiliacion;
                cmd.Parameters.Add("@CDCLIENTE", SqlDbType.VarChar, 15).Value = cCliente.cdcliente;
                cmd.Parameters.Add("@RUCCLIENTE", SqlDbType.VarChar, 15).Value = cCliente.ruccliente;
                cmd.Parameters.Add("@RSCLIENTE", SqlDbType.VarChar, 60).Value = cCliente.rscliente;
                cmd.Parameters.Add("@DRCLIENTE", SqlDbType.VarChar, 60).Value = cCliente.drcliente;
                cmd.Parameters.Add("@BLOQUEADO", SqlDbType.Bit).Value = cCliente.bloqueado_afiliacion;
                cmd.Parameters.Add("@ESTADO", SqlDbType.Bit).Value = cCliente.estado_afiliacion;
                cmd.Parameters.Add("@CDUSUARIO", SqlDbType.VarChar, 20).Value = cCliente.cdusuario; 

                 flag = cmd.ExecuteNonQuery() > 0;

                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;
        }


        public bool INSERT_AFILIACION_TARJETA_CONCEPTOS(TS_BEClienteInput cCliente,TS_BEArticulo Articulo, SqlTransaction oSqlTransaction)
        {
            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_INSERTAR_AFILIACION_CONCEPTOS")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = oSqlTransaction.Connection,
                    Transaction = oSqlTransaction
                };

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@TARJAFILIACION", SqlDbType.VarChar, 20).Value = cCliente.tarjAfiliacion;
                cmd.Parameters.Add("@CDCLIENTE", SqlDbType.VarChar, 15).Value = cCliente.cdcliente;
                cmd.Parameters.Add("@RUCCLIENTE", SqlDbType.VarChar, 15).Value = cCliente.ruccliente;
                cmd.Parameters.Add("@VALORID", SqlDbType.Int, 10).Value = Articulo.valorid;

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
