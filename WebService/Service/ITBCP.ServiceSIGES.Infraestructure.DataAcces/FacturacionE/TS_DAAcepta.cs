using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;

namespace ITBCP.ServiceSIGES.Infraestructure.DataAcces.FacturacionE
{
    public class TS_DAAcepta : ITS_DOAceptaFE
    {

        private readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        private readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public string OBTENER_CABECERA(TS_BEDocumento Documento)
        {
            string Cabecera = "";
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_GENERA_CABECERA_ACT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fe_TipDoc", SqlDbType.VarChar,    2).Value = Documento.cCabecera.cdtipodoc.Substring(3, 2);
                    cmd.Parameters.Add("@fe_NumDoc", SqlDbType.VarChar,   13).Value = Documento.cCabecera.nrodocumento;
                    cmd.Parameters.Add("@fe_FecDoc", SqlDbType.DateTime,  20).Value = Documento.cCabecera.fecdocumento;
                    cmd.Parameters.Add("@fe_TipMon", SqlDbType.VarChar,    3).Value = Documento.cCabecera.cdmoneda.Trim() == "S" ? "PEN" : "DOL";
                    cmd.Parameters.Add("@fe_EmpVen", SqlDbType.VarChar,   15).Value = Documento.cEmisor.RUC.Trim();
                    cmd.Parameters.Add("@fe_TipEmi", SqlDbType.VarChar,    1).Value = "6";
                    cmd.Parameters.Add("@fe_NomEmi", SqlDbType.VarChar,  100).Value = Documento.cEmisor.RazonSocial.Trim();
                    cmd.Parameters.Add("@fe_CodUbi", SqlDbType.VarChar,   10).Value = Documento.cEmisor.Ubigeo.Trim();
                    cmd.Parameters.Add("@fe_DirEmi", SqlDbType.VarChar,  100).Value = Documento.cEmisor.Direccion.Trim();
                    cmd.Parameters.Add("@fe_UrbEmi", SqlDbType.VarChar,  100).Value = Documento.cEmisor.Urbanizacion.Trim();
                    cmd.Parameters.Add("@fe_PrvEmi", SqlDbType.VarChar,   20).Value = Documento.cEmisor.Provincia.Trim();
                    cmd.Parameters.Add("@fe_DepEmi", SqlDbType.VarChar,   20).Value = Documento.cEmisor.Departamento.Trim();
                    cmd.Parameters.Add("@fe_DisEmi", SqlDbType.VarChar,   30).Value = Documento.cEmisor.Distrito.Trim();
                    cmd.Parameters.Add("@fe_NroDoc", SqlDbType.VarChar,   20).Value = Documento.cCliente.cdcliente.Trim();
                    cmd.Parameters.Add("@fe_TipAdq", SqlDbType.VarChar,    1).Value = "";
                    cmd.Parameters.Add("@fe_RucRec", SqlDbType.VarChar,   15).Value = Documento.cCliente.ruccliente.Trim();
                    cmd.Parameters.Add("@fe_RazRec", SqlDbType.VarChar,  100).Value = Documento.cCliente.rscliente.Trim();
                    cmd.Parameters.Add("@fe_DirRec", SqlDbType.VarChar,  100).Value = Documento.cCliente.drcliente.Trim();
                    cmd.Parameters.Add("@fe_MtoImp", SqlDbType.Decimal,   18).Value = Documento.cCabecera.mtoimpuesto;
                    cmd.Parameters.Add("@fe_MtoTot", SqlDbType.Decimal,   18).Value = Documento.cCabecera.mtototal;
                    cmd.Parameters.Add("@fe_TipVen", SqlDbType.VarChar,   10).Value = Documento.cCabecera.tipoventa;
                    cmd.Parameters.Add("@fe_NumGuia", SqlDbType.VarChar,  10).Value = Documento.cCabecera.nroguia;
                    cmd.Parameters.Add("@fe_OrdCompra", SqlDbType.VarChar,10).Value = "";
                    cmd.Parameters.Add("@fe_MtoDsc", SqlDbType.Decimal,   10).Value = Documento.cCabecera.mtodscto;
                    cmd.Parameters.Add("@fe_SubTot", SqlDbType.Decimal,   10).Value = Documento.cCabecera.mtosubtotal;
                    cmd.Parameters.Add("@fe_FecVen", SqlDbType.DateTime,  10).Value = Documento.cCabecera.fecdocumento;
                    cmd.Parameters.Add("@fe_Indeco", SqlDbType.Decimal,   10).Value = Documento.cCabecera.redondea_indecopi; 
                    cmd.Parameters.Add("@fe_MtoExo", SqlDbType.Decimal,  18).Value = 0;
                    cmd.Parameters.Add("@fe_Contig", SqlDbType.Bit, 1).Value = 0;
                    cmd.Parameters.Add("@fe_TipRef", SqlDbType.VarChar, 10).Value   = "";
                    cmd.Parameters.Add("@fe_TipNot", SqlDbType.VarChar, 10).Value   = "";

                    cmd.Parameters.Add("@fe_DocRef", SqlDbType.VarChar,  10).Value  = "";
                    cmd.Parameters.Add("@fe_MotNot", SqlDbType.VarChar,  10).Value  = "";
                    cmd.Parameters.Add("@fe_fecRef", SqlDbType.DateTime, 10).Value = DateTime.Now;
                    cmd.Parameters.Add("@fe_tpdRef", SqlDbType.VarChar,  10).Value  = "";

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            Cabecera = Cabecera + "\n"+ (drd.HasColumn("CABECERA") ? drd["CABECERA"] == DBNull.Value ? "" : drd["CABECERA"].ToString() : "").Trim();
                        }
                    }
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (con != null) { con.Dispose(); }
                }
            }
            return Cabecera;
        }
        public String OBTENER_DETALLES(TS_BEDocumento Documento)
        {
            String Detalles = "";
            foreach (TS_BEArticulo Detalle in Documento.cDetalles)
            {
                using (SqlConnection con = new SqlConnection(stringBackOffice))
                {   
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("SP_ITBCP_GENERA_DETALLE_ACT", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fe_DesIte", SqlDbType.VarChar,    60).Value = Detalle.dsarticulo.Trim(); // NOMBRE DE PRODUCTO
                        cmd.Parameters.Add("@fe_CodPro", SqlDbType.VarChar,    20).Value = Detalle.cdarticulo.Trim();//CODIGO DE PRODUCTO
                        cmd.Parameters.Add("@fe_LinDet", SqlDbType.Int,        10).Value = Detalle.item;//NRºITEM < ID > Número de línea Secuenial
                        cmd.Parameters.Add("@fe_UniMed", SqlDbType.VarChar,     3).Value = Detalle.cdunimed; //CDUNIMED UNIDAD DE MEDIDA<UnitCode> ü   Unidad de medida por íteM
                        cmd.Parameters.Add("@fe_CanVen", SqlDbType.Decimal,    18).Value = Detalle.cantidad;//CANTIDAD < InvoicedQuantity > Cantidad de item
                        cmd.Parameters.Add("@fe_MonIte", SqlDbType.Decimal,    18).Value = Detalle.valorvta;//< LineExtensionAmount > Valor de venta del ítem -Este elemento es el producto de la cantidad por el valor unitario(Q x Valor Unitario) y la deducción de los descuentos aplicados a dicho ítem(de existir).  
                        cmd.Parameters.Add("@fe_ValUni", SqlDbType.Decimal,    18).Value = Detalle.precio;//PRECIO-- VALOR CON IGV DEL PRODUCTO
                        cmd.Parameters.Add("@fe_ImpIte", SqlDbType.Decimal,    18).Value = Detalle.mtoimpuesto; //IGV DEL PRODUCTO 18 % 21 % O 0 % AGARRA VALOR IGV DE PARAMETRO
                        cmd.Parameters.Add("@fe_TipVen", SqlDbType.VarChar,     1).Value = String.IsNullOrEmpty(Documento.cCabecera.tipoventa) ? "" : Documento.cCabecera.tipoventa;//T TRANSFERENCIA GRATUITA
                        cmd.Parameters.Add("@fe_DesRec", SqlDbType.Decimal,    18).Value = Detalle.impuesto; //MTOIGV
                        cmd.Parameters.Add("@fe_TipDoc", SqlDbType.VarChar,     5).Value = Documento.cCabecera.cdtipodoc.Substring(3, 2);// CDTIPODOC RESUMIDO EN 01,03,07,08
                        cmd.Parameters.Add("@Fe_cmdMon", SqlDbType.VarChar,    10).Value = "";
                        cmd.Parameters.Add("@fe_MonDes", SqlDbType.Decimal,    18).Value = Detalle.mtodscto < 0 ? 0 : Detalle.mtodscto;//mtodescuento--CANTIDAD DEL DESCUENTO
                        cmd.Parameters.Add("@fe_MonTot", SqlDbType.Decimal,    18).Value = Detalle.mtototal; //MONTO TOTAL PARA TRANSFERENCIA GRATUITA
                        cmd.Parameters.Add("@fe_ArtSunat", SqlDbType.VarChar, 100).Value = Detalle.cdarticulosunat.Trim();//CDARTICULO SUNAT

                        using (SqlDataReader drd = cmd.ExecuteReader())
                        {
                            while (drd.Read())
                            {
                                Detalles = Detalles + "\n" +(drd.HasColumn("DETALLE") ? drd["DETALLE"] == DBNull.Value ? "" : drd["DETALLE"].ToString() : "").Trim();
                            }
 
                        }
                        cmd.Dispose();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (con != null) { con.Dispose(); }
                    }
                }
            }
            return Detalles;
        }
        public string OBTENER_GLOBAL(TS_BEDocumento Documento)
        {
            String Global = "";
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                string Lados = "";
                foreach (TS_BEArticulo Detalle in Documento.cDetalles)
                {
                    Lados = Lados + Detalle.cara + " ";
                }
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_GENERA_GLOBAL_ACT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fe_MtoNet", SqlDbType.Decimal,    60).Value = Documento.cCabecera.mtototal;
                    cmd.Parameters.Add("@fe_MtoImp", SqlDbType.Decimal,    18).Value = Documento.cCabecera.mtoimpuesto;
                    cmd.Parameters.Add("@fe_MtoDsc", SqlDbType.Decimal,    18).Value = Documento.cCabecera.mtodscto;
                    cmd.Parameters.Add("@fe_TipVen", SqlDbType.VarChar,     3).Value = Documento.cCabecera.tipoventa;
                    cmd.Parameters.Add("@fe_TotTxt", SqlDbType.VarChar,   100).Value = Documento.cCabecera.numero_texto;
                    cmd.Parameters.Add("@fe_CorRec", SqlDbType.VarChar,    50).Value = Documento.cCliente.emcliente == null? "": Documento.cCliente.emcliente.Trim();
                    cmd.Parameters.Add("@fe_TipDoc", SqlDbType.VarChar,    18).Value = Documento.cCabecera.cdtipodoc.Substring(3,2);
                    cmd.Parameters.Add("@fe_FecVen", SqlDbType.DateTime,   18).Value = Documento.cCabecera.fecdocumento;
                    cmd.Parameters.Add("@fe_CodUsu", SqlDbType.VarChar,   100).Value = String.IsNullOrEmpty(Documento.cCabecera.cdvendedor) ? "" : Documento.cCabecera.cdvendedor;
                    cmd.Parameters.Add("@fe_LadVen", SqlDbType.VarChar,    18).Value = Lados;
                    cmd.Parameters.Add("@fe_TurVen", SqlDbType.VarChar,     5).Value = Documento.cCabecera.turno;
                    cmd.Parameters.Add("@fe_NroPla", SqlDbType.VarChar,   100).Value = Documento.cCabecera.nroplaca == null ? "" : Documento.cCabecera.nroplaca.Trim();
                    cmd.Parameters.Add("@fe_ConPag", SqlDbType.VarChar,    18).Value  = (Documento.cPagos.Count == 1 && Documento.cPagos[0].cdtppago == "00004") ? "CREDITO" : "CONTADO";
                    cmd.Parameters.Add("@fe_NumOdo", SqlDbType.VarChar,    18).Value = String.IsNullOrEmpty(Documento.cCabecera.odometro) ? "" : Documento.cCabecera.odometro.Trim();
                    cmd.Parameters.Add("@fe_NomTar", SqlDbType.VarChar,   100).Value = "";
                    cmd.Parameters.Add("@fe_NroLic", SqlDbType.VarChar, 100).Value   = "";
                    cmd.Parameters.Add("@fe_ObsVen", SqlDbType.VarChar, 100).Value   = Documento.cCabecera.observacion == null ? "" : Documento.cCabecera.observacion.Trim();
                    cmd.Parameters.Add("@fe_DirSuc", SqlDbType.VarChar, 100).Value   = Documento.cLocal.drlocal == null ? "" : Documento.cLocal.drlocal.Trim();
                    cmd.Parameters.Add("@fe_scop", SqlDbType.VarChar,   100).Value   = "";
                    cmd.Parameters.Add("@fe_NomSuc", SqlDbType.VarChar, 100).Value   = Documento.cLocal.dslocal == null ? "" : Documento.cLocal.dslocal.Trim();
                    cmd.Parameters.Add("@fe_ProSuc", SqlDbType.VarChar, 100).Value   = Documento.cLocal.provlocal == null ? "" : Documento.cLocal.provlocal.Trim();
                    cmd.Parameters.Add("@fe_NroAut", SqlDbType.VarChar, 100).Value   = Documento.cLocal.cdsunat == null ? "" : Documento.cLocal.cdsunat.Trim();

                    using (SqlDataReader drd = cmd.ExecuteReader())
                        {
                            while (drd.Read())
                            {
                                Global = Global + "\n" + (drd.HasColumn("GLOBALES") ? drd["GLOBALES"] == DBNull.Value ? "" : drd["GLOBALES"].ToString().ToUpper() : "").Trim();
                            }

                        }
                        cmd.Dispose();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (con != null) { con.Dispose(); }
                }
            }
            
            return Global;
        }
        public string OBTENER_PAGOS(TS_BEDocumento Documento)
        {
            string Pagos = "";
            foreach(TS_BEPago Pago in Documento.cPagos) { 
                using (SqlConnection con = new SqlConnection(stringBackOffice))
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("SP_ITBCP_GENERA_PAGO_ACT", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@fe_ConPag", SqlDbType.VarChar, 60).Value = Pago.cdtppago.Equals("00001") ? "EFECTIVO" : Pago.cdtppago.Equals("00002") ? "TARJETA DE CREDITO" : Pago.cdtppago.Equals("00003") ? "CHEQUE" : Pago.cdtppago.Equals("00004") ? "CREDITO" : "OTROS";
                        cmd.Parameters.Add("@fe_MtoPag", SqlDbType.Decimal, 18).Value = (Pago.mtopagosol == 0 ? 0 : Pago.mtopagosol) + (Pago.mtopagodol == 0 ? 0 : ((Pago.mtopagodol) * (Documento.cTipoCambio.cambio)));
                        cmd.Parameters.Add("@fe_TipVen", SqlDbType.VarChar, 1).Value = Documento.cCabecera.tipoventa;
                        using (SqlDataReader drd = cmd.ExecuteReader())
                        {
                            while (drd.Read())
                            {
                                Pagos = Pagos + "\n" +(drd.HasColumn("PAGO") ? drd["PAGO"] == DBNull.Value ? "" : drd["PAGO"].ToString() : "").Trim();
                            }
                        }
                        cmd.Dispose();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (con != null) { con.Dispose(); }
                    }
                }
            }
            return Pagos;
        }
    }
}
