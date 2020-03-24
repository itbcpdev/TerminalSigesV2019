using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
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
    public class TS_DAParametros : ITS_DOParametro
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public TS_BEParameters ObtenerParameters()
        {
            TS_BEParameters output = new TS_BEParameters();
            using (SqlConnection con = new SqlConnection(stringConnectionSetup))
            {

                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_S_PARAMETERS", con);
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader drd = cmd.ExecuteReader())
                    { 
                        while (drd.Read())
                        {
                            output.id = drd["id"]?.ToString() ?? null;
                            output.monpais = drd["monpais"]?.ToString() ?? null;
                            output.path_repo = drd["path_repo"]?.ToString() ?? null;
                            output.path_formato = drd["path_formato"]?.ToString() ?? null;
                            output.path_gasboy = drd["path_gasboy"]?.ToString() ?? null;
                            output.path_loteria = drd["path_loteria"]?.ToString() ?? null;
                            output.numempresa = drd["numempresa"] == DBNull.Value ? 0 : Convert.ToDouble(drd["numempresa"]);
                            output.tpfactura = drd["tpfactura"]?.ToString() ?? null;
                            output.tpboleta = drd["tpboleta"]?.ToString() ?? null;
                            output.tpticket = drd["tpticket"]?.ToString() ?? null;
                            output.tppromocion = drd["tppromocion"]?.ToString() ?? null;
                            output.tpntavta = drd["tpntavta"]?.ToString() ?? null;
                            output.tpncredito = drd["tpncredito"]?.ToString() ?? null;
                            output.tpndebito = drd["tpndebito"]?.ToString() ?? null;
                            output.tpletra = drd["tpletra"]?.ToString() ?? null;
                            output.tpletraprot = drd["tpletraprot"]?.ToString() ?? null;
                            output.tpguia = drd["tpguia"]?.ToString() ?? null;
                            output.tpvale = drd["tpvale"]?.ToString() ?? null;
                            output.tpanticipo = drd["tpanticipo"]?.ToString() ?? null;
                            output.tpcheque = drd["tpcheque"]?.ToString() ?? null;
                            output.tpproforma = drd["tpproforma"]?.ToString() ?? null;
                            output.tpseparacion = drd["tpseparacion"]?.ToString() ?? null;
                            output.tpcomanda = drd["tpcomanda"]?.ToString() ?? null;
                            output.tppedido = drd["tppedido"]?.ToString() ?? null;
                            output.tppgoefectivo = drd["tppgoefectivo"]?.ToString() ?? null;
                            output.tppgotarjeta = drd["tppgotarjeta"]?.ToString() ?? null;
                            output.tppgocheque = drd["tppgocheque"]?.ToString() ?? null;
                            output.tppgocredito = drd["tppgocredito"]?.ToString() ?? null;
                            output.tpaplicncred = drd["tpaplicncred"]?.ToString() ?? null;
                            output.tpaplicantic = drd["tpaplicantic"]?.ToString() ?? null;
                            output.tppgocanje = drd["tppgocanje"]?.ToString() ?? null;
                            output.cdarticulocontable = drd["cdarticulocontable"]?.ToString() ?? null;
                            output.calculoigv = drd["calculoigv"]?.ToString() ?? null;
                            output.flgdesgtkfact = drd["flgdesgtkfact"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgdesgtkfact"]);
                            output.flgmolotov = drd["flgmolotov"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmolotov"]);
                            output.path_clicorp = drd["path_clicorp"]?.ToString() ?? null;
                            output.path_bonus = drd["path_bonus"]?.ToString() ?? null;
                            output.central = drd["central"]?.ToString() ?? null;
                            output.path_transfer = drd["path_transfer"]?.ToString() ?? null;
                            output.cambioturno = drd["cambioturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["cambioturno"]);
                            output.tppgotransferencia = drd["tppgotransferencia"]?.ToString() ?? null;
                            output.tpticketfac = drd["tpticketfac"]?.ToString() ?? null;
                            output.nom_ventaplaya = drd["nom_ventaplaya"]?.ToString() ?? null;
                            output.tpcliente_corporativo = drd["tpcliente_corporativo"]?.ToString() ?? null;
                            output.fe_ipremoto = drd["fe_ipremoto"]?.ToString() ?? null;
                            output.fe_puertoremoto = drd["fe_puertoremoto"]?.ToString() ?? null;
                            output.fe_proveedor = drd["fe_proveedor"]?.ToString() ?? "";
                            output.fe_dbz_rutasuitepos = drd["fe_dbz_rutasuitepos"]?.ToString() ?? null;
                            output.fe_dbz_rutasuitesuc = drd["fe_dbz_rutasuitesuc"]?.ToString() ?? null;
                            output.fe_snt_rutaprocesamiento = drd["fe_snt_rutaprocesamiento"]?.ToString() ?? null;
                            output.fe_snt_rutafacturador = drd["fe_snt_rutafacturador"]?.ToString() ?? null;
                            output.fe_snt_rutagenerador = drd["fe_snt_rutagenerador"]?.ToString() ?? null;
                            output.fe_mst_rutawebservice = drd["fe_mst_rutawebservice"]?.ToString() ?? null;
                            output.fe_sge_rutawebservice = drd["fe_sge_rutawebservice"]?.ToString() ?? null;
                            output.fe_sge_clavecertificado = drd["fe_sge_clavecertificado"]?.ToString() ?? null;
                            output.fe_asp_rutaprocesamiento = drd["fe_asp_rutaprocesamiento"]?.ToString() ?? null;
                            output.fe_inc_rutaprocesamiento = drd["fe_inc_rutaprocesamiento"]?.ToString() ?? null;
                            output.fe_bzl_tiempoespera = drd["fe_bzl_tiempoespera"] == DBNull.Value ? 0 : (int)drd["fe_bzl_tiempoespera"];
                            output.fe_act_rutaprocesamiento = drd["fe_act_rutaprocesamiento"]?.ToString() ?? null;
                            output.fe_tci_rutaprocesamiento = drd["fe_tci_rutaprocesamiento"]?.ToString() ?? null;
                            output.fe_act_ruta_ws = drd["fe_act_ruta_ws"]?.ToString() ?? null;
                            output.fe_act_clave_ws = drd["fe_act_clave_ws"]?.ToString() ?? null;
                            output.fe_act_ruta_ws_CDR = drd["fe_act_ruta_ws_CDR"]?.ToString() ?? null;
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
                    if (con != null)
                    {
                        con.Dispose();
                    }
                      
                }
            }
            return output;
        }

        public TS_BEParametro ObtenerParametros()
        {

            TS_BEParametro output = new TS_BEParametro();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_PARAMETRO", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            
                            output.tipocierrextienda = drd.HasColumn("tipocierrextienda") ? drd["tipocierrextienda"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["tipocierrextienda"]) : (byte?)null;
                            output.cursor_tienda = drd.HasColumn("cursor_tienda") ? drd["cursor_tienda"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["cursor_tienda"]) : (byte?)null;
                            output.repite_articulo = drd.HasColumn("repite_articulo") ? drd["repite_articulo"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["repite_articulo"]) : (byte?)null;
                            output.imprime_canjeweb = drd.HasColumn("imprime_canjeweb") ? drd["imprime_canjeweb"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["imprime_canjeweb"]) : (byte?)null;
                            output.imprime_ptosacumulados = drd.HasColumn("imprime_ptosacumulados") ? drd["imprime_ptosacumulados"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["imprime_ptosacumulados"]) : (byte?)null;
                            output.tarjeta_actu_cdcliente = drd.HasColumn("tarjeta_actu_cdcliente") ? drd["tarjeta_actu_cdcliente"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["tarjeta_actu_cdcliente"]) : (byte?)null;
                            output.cierre_kardex = drd.HasColumn("cierre_kardex") ? drd["cierre_kardex"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["cierre_kardex"]) : (byte?)null;
                            output.noconectawpuntos = drd.HasColumn("noconectawpuntos") ? drd["noconectawpuntos"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["noconectawpuntos"]) : (byte?)null;
                            output.cierrex_formatos = drd.HasColumn("cierrex_formatos") ? drd["cierrex_formatos"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["cierrex_formatos"]) : (byte?)null;
                            output.imprime_fact_playa = drd.HasColumn("imprime_fact_playa") ? drd["imprime_fact_playa"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["imprime_fact_playa"]) : (byte?)null;
                            output.credplaca = drd.HasColumn("credplaca") ? drd["credplaca"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["credplaca"]) : (byte?)null;
                            output.cierre_especial = drd.HasColumn("cierre_especial") ? drd["cierre_especial"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["cierre_especial"]) : (byte?)null;
                            output.parte_tienda = drd.HasColumn("parte_tienda") ? drd["parte_tienda"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["parte_tienda"]) : (byte?)null;
                            output.flg_desc_prefijo = drd.HasColumn("flg_desc_prefijo") ? drd["flg_desc_prefijo"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["flg_desc_prefijo"]) : (byte?)null;
                            output.imprimir_cdarticulo_config = drd.HasColumn("imprimir_cdarticulo_config") ? drd["imprimir_cdarticulo_config"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["imprimir_cdarticulo_config"]) : (byte?)null;
                            output.mostrar_igv_pantalla = drd.HasColumn("mostrar_igv_pantalla") ? drd["mostrar_igv_pantalla"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["mostrar_igv_pantalla"]) : (byte?)null;
                            output.tipo_menu = drd.HasColumn("tipo_menu") ? drd["tipo_menu"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["tipo_menu"]) : (byte?)null;
                            output.nd_playa = drd.HasColumn("nd_playa") ? drd["nd_playa"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["nd_playa"]) : (byte?)null;
                            output.valida_cdarticulo = drd.HasColumn("valida_cdarticulo") ? drd["valida_cdarticulo"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["valida_cdarticulo"]) : (byte?)null;
                            output.conf_cierrex = drd.HasColumn("conf_cierrex") ? drd["conf_cierrex"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["conf_cierrex"]) : (byte?)null;
                            output.boton_transfer_gratuita = drd.HasColumn("boton_transfer_gratuita") ? drd["boton_transfer_gratuita"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["boton_transfer_gratuita"]) : (byte?)null;
                            output.tienda_cant_neg = drd.HasColumn("tienda_cant_neg") ? drd["tienda_cant_neg"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["tienda_cant_neg"]) : (byte?)null;
                            output.imprime_tiketera = drd.HasColumn("imprime_tiketera") ? drd["imprime_tiketera"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["imprime_tiketera"]) : (byte?)null;
                            output.imprime_nvta = drd.HasColumn("imprime_nvta") ? drd["imprime_nvta"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["imprime_nvta"]) : (byte?)null;
                            output.modifica_depositos_parte = drd.HasColumn("modifica_depositos_parte") ? drd["modifica_depositos_parte"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["modifica_depositos_parte"]) : (byte?)null;
                            output.mostrar_local_gastos = drd.HasColumn("mostrar_local_gastos") ? drd["mostrar_local_gastos"] == DBNull.Value ? (byte?)null : Convert.ToByte(drd["mostrar_local_gastos"]) : (byte?)null;
                            output.cantdigitos_tarjpromo = drd.HasColumn("cantdigitos_tarjpromo") ? drd["cantdigitos_tarjpromo"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["cantdigitos_tarjpromo"]) : (int?)null;
                            output.galones_decimales = drd.HasColumn("galones_decimales") ? drd["galones_decimales"] == DBNull.Value ? 0 : Convert.ToInt32(drd["galones_decimales"]) : 0;
                            output.tiendagazel = drd.HasColumn("tiendagazel") ? drd["tiendagazel"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["tiendagazel"]) : (int?)null;
                            output.terminalserver = drd.HasColumn("terminalserver") ? drd["terminalserver"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["terminalserver"]) : (int?)null;
                            output.rango_valfecpos = drd.HasColumn("rango_valfecpos") ? drd["rango_valfecpos"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["rango_valfecpos"]) : (int?)null;
                            output.nro_caracteres_rsocial = drd.HasColumn("nro_caracteres_rsocial") ? drd["nro_caracteres_rsocial"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["nro_caracteres_rsocial"]) : (int?)null;
                            output.valida_fecha_playa = drd.HasColumn("valida_fecha_playa") ? drd["valida_fecha_playa"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["valida_fecha_playa"]) : (int?)null;
                            output.impr_veces_nd = drd.HasColumn("impr_veces_nd") ? drd["impr_veces_nd"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["impr_veces_nd"]) : (int?)null;
                            output.impr_veces_fac = drd.HasColumn("impr_veces_fac") ? drd["impr_veces_fac"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["impr_veces_fac"]) : (int?)null;
                            output.impr_veces_bol = drd.HasColumn("impr_veces_bol") ? drd["impr_veces_bol"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["impr_veces_bol"]) : (int?)null;
                            output.fecinstall = drd.HasColumn("fecinstall") ? drd["fecinstall"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecinstall"]) : (DateTime?)null;
                            output.flgtalla = drd.HasColumn("flgtalla") ? drd["flgtalla"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgtalla"]) : false;
                            output.flgformula = drd.HasColumn("flgformula") ? drd["flgformula"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgformula"]) : false;
                            output.precioconigv = drd.HasColumn("precioconigv") ? drd["precioconigv"] == DBNull.Value ? false : Convert.ToBoolean(drd["precioconigv"]) : false;
                            output.precioconservicio = drd.HasColumn("precioconservicio") ? drd["precioconservicio"] == DBNull.Value ? false : Convert.ToBoolean(drd["precioconservicio"]) : false;
                            output.utilidadcosto = drd.HasColumn("utilidadcosto") ? drd["utilidadcosto"] == DBNull.Value ? false : Convert.ToBoolean(drd["utilidadcosto"]) : false;
                            output.flgintegrador = drd.HasColumn("flgintegrador") ? drd["flgintegrador"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgintegrador"]) : false;
                            output.flg_imprimirnd_menos5s = drd.HasColumn("flg_imprimirnd_menos5s") ? drd["flg_imprimirnd_menos5s"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_imprimirnd_menos5s"]) : false;
                            output.flg_ocultarvta_menos5s = drd.HasColumn("flg_ocultarvta_menos5s") ? drd["flg_ocultarvta_menos5s"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_ocultarvta_menos5s"]) : false;
                            output.flg_noaplica_desc_tarj = drd.HasColumn("flg_noaplica_desc_tarj") ? drd["flg_noaplica_desc_tarj"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_noaplica_desc_tarj"]) : false;
                            output.flg_activar_clientes_varios = drd.HasColumn("flg_activar_clientes_varios") ? drd["flg_activar_clientes_varios"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_activar_clientes_varios"]) : false;
                            output.flg_print_qr = drd.HasColumn("flg_print_qr") ? drd["flg_print_qr"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_print_qr"]) : false;
                            output.flg_repx_terminal = drd.HasColumn("flg_repx_terminal") ? drd["flg_repx_terminal"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_repx_terminal"]) : false;
                            output.flg_cliente_automatico = drd.HasColumn("flg_cliente_automatico") ? drd["flg_cliente_automatico"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_cliente_automatico"]) : false;
                            output.desactivar_foxypreviewer = drd.HasColumn("desactivar_foxypreviewer") ? drd["desactivar_foxypreviewer"] == DBNull.Value ? false : Convert.ToBoolean(drd["desactivar_foxypreviewer"]) : false;
                            output.flg_notas_multiref = drd.HasColumn("flg_notas_multiref") ? drd["flg_notas_multiref"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_notas_multiref"]) : false;
                            output.flg_afectarcosto_fletecompras = drd.HasColumn("flg_afectarcosto_fletecompras") ? drd["flg_afectarcosto_fletecompras"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_afectarcosto_fletecompras"]) : false;
                            output.flg_btn_credito_playa = drd.HasColumn("flg_btn_credito_playa") ? drd["flg_btn_credito_playa"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_btn_credito_playa"]) : false;
                            output.flg_validateclas_cdcliente = drd.HasColumn("flg_validateclas_cdcliente") ? drd["flg_validateclas_cdcliente"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_validateclas_cdcliente"]) : false;
                            output.flg_activa_ti_todosprod = drd.HasColumn("flg_activa_ti_todosprod") ? drd["flg_activa_ti_todosprod"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_activa_ti_todosprod"]) : false;
                            output.flg_boton_promo = drd.HasColumn("flg_boton_promo") ? drd["flg_boton_promo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_boton_promo"]) : false;
                            output.flg_gastos_playa = drd.HasColumn("flg_gastos_playa") ? drd["flg_gastos_playa"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_gastos_playa"]) : false;
                            output.flg_ocultar_campos_tck = drd.HasColumn("flg_ocultar_campos_tck") ? drd["flg_ocultar_campos_tck"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_ocultar_campos_tck"]) : false;
                            output.flg_credito_centralizado = drd.HasColumn("flg_credito_centralizado") ? drd["flg_credito_centralizado"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_credito_centralizado"]) : false;
                            output.flgsoloterminal = drd.HasColumn("flgsoloterminal") ? drd["flgsoloterminal"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsoloterminal"]) : false;
                            output.flg_round_dec_indecopi = drd.HasColumn("flg_round_dec_indecopi") ? drd["flg_round_dec_indecopi"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_round_dec_indecopi"]) : false;
                            output.flg_round_indecopi_1_9 = drd.HasColumn("flg_round_indecopi_1_9") ? drd["flg_round_indecopi_1_9"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_round_indecopi_1_9"]) : false;
                            output.flg_kardex_unalinea = drd.HasColumn("flg_kardex_unalinea") ? drd["flg_kardex_unalinea"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_kardex_unalinea"]) : false;
                            output.flg_facturacion_automatica = drd.HasColumn("flg_facturacion_automatica") ? drd["flg_facturacion_automatica"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_facturacion_automatica"]) : false;
                            output.flg_modo_fact = drd.HasColumn("flg_modo_fact") ? drd["flg_modo_fact"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_modo_fact"]) : false;
                            output.label_bellavista = drd.HasColumn("label_bellavista") ? drd["label_bellavista"] == DBNull.Value ? false : Convert.ToBoolean(drd["label_bellavista"]) : false;
                            output.nd_imp_saldoyconsumo = drd.HasColumn("nd_imp_saldoyconsumo") ? drd["nd_imp_saldoyconsumo"] == DBNull.Value ? false : Convert.ToBoolean(drd["nd_imp_saldoyconsumo"]) : false;
                            output.flg_valida_fecproce_dia = drd.HasColumn("flg_valida_fecproce_dia") ? drd["flg_valida_fecproce_dia"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_valida_fecproce_dia"]) : false;
                            output.flg_canjend = drd.HasColumn("flg_canjend") ? drd["flg_canjend"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_canjend"]) : false;
                            output.flg_nrodias = drd.HasColumn("flg_nrodias") ? drd["flg_nrodias"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nrodias"]) : false;
                            output.flg_nc_liberand = drd.HasColumn("flg_nc_liberand") ? drd["flg_nc_liberand"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nc_liberand"]) : false;
                            output.flg_transfer_gratuita_cero = drd.HasColumn("flg_transfer_gratuita_cero") ? drd["flg_transfer_gratuita_cero"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_transfer_gratuita_cero"]) : false;
                            output.flg_fecsrv = drd.HasColumn("flg_fecsrv") ? drd["flg_fecsrv"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_fecsrv"]) : false;
                            output.flg_pideodometro = drd.HasColumn("flg_pideodometro") ? drd["flg_pideodometro"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pideodometro"]) : false;
                            output.flg_valdscto = drd.HasColumn("flg_valdscto") ? drd["flg_valdscto"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_valdscto"]) : false;
                            output.flg_pideclavecred = drd.HasColumn("flg_pideclavecred") ? drd["flg_pideclavecred"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pideclavecred"]) : false;
                            output.flg_anula_easytaxi = drd.HasColumn("flg_anula_easytaxi") ? drd["flg_anula_easytaxi"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_anula_easytaxi"]) : false;
                            output.conigv = drd.HasColumn("conigv") ? drd["conigv"] == DBNull.Value ? false : Convert.ToBoolean(drd["conigv"]) : false;
                            output.flg_pideplacatb = drd.HasColumn("flg_pideplacatb") ? drd["flg_pideplacatb"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pideplacatb"]) : false;
                            output.activa_repro_stock = drd.HasColumn("activa_repro_stock") ? drd["activa_repro_stock"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_repro_stock"]) : false;
                            output.flg_valfecpos = drd.HasColumn("flg_valfecpos") ? drd["flg_valfecpos"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_valfecpos"]) : false;
                            output.flg_anulapos = drd.HasColumn("flg_anulapos") ? drd["flg_anulapos"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_anulapos"]) : false;
                            output.activa_elsol = drd.HasColumn("activa_elsol") ? drd["activa_elsol"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_elsol"]) : false;
                            output.flg_boton_facturacionmanual = drd.HasColumn("flg_boton_facturacionmanual") ? drd["flg_boton_facturacionmanual"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_boton_facturacionmanual"]) : false;
                            output.mostrar_ptos_ganados = drd.HasColumn("mostrar_ptos_ganados") ? drd["mostrar_ptos_ganados"] == DBNull.Value ? false : Convert.ToBoolean(drd["mostrar_ptos_ganados"]) : false;
                            output.activa_formas_pago = drd.HasColumn("activa_formas_pago") ? drd["activa_formas_pago"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_formas_pago"]) : false;
                            output.flg_pideplaca = drd.HasColumn("flg_pideplaca") ? drd["flg_pideplaca"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pideplaca"]) : false;
                            output.depositos_playa = drd.HasColumn("depositos_playa") ? drd["depositos_playa"] == DBNull.Value ? false : Convert.ToBoolean(drd["depositos_playa"]) : false;
                            output.flg_botoncredito = drd.HasColumn("flg_botoncredito") ? drd["flg_botoncredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_botoncredito"]) : false;
                            output.flg_nobuscar_nombre = drd.HasColumn("flg_nobuscar_nombre") ? drd["flg_nobuscar_nombre"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nobuscar_nombre"]) : false;
                            output.consulta_sunat = drd.HasColumn("consulta_sunat") ? drd["consulta_sunat"] == DBNull.Value ? false : Convert.ToBoolean(drd["consulta_sunat"]) : false;
                            output.clubgazel = drd.HasColumn("clubgazel") ? drd["clubgazel"] == DBNull.Value ? false : Convert.ToBoolean(drd["clubgazel"]) : false;
                            output.activa_camedi = drd.HasColumn("activa_camedi") ? drd["activa_camedi"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_camedi"]) : false;
                            output.tarjeta_mascara = drd.HasColumn("tarjeta_mascara") ? drd["tarjeta_mascara"] == DBNull.Value ? false : Convert.ToBoolean(drd["tarjeta_mascara"]) : false;
                            output.flgruta = drd.HasColumn("flgruta") ? drd["flgruta"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgruta"]) : false;
                            output.flg_prefij_seriesdoc = drd.HasColumn("flg_prefij_seriesdoc") ? drd["flg_prefij_seriesdoc"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_prefij_seriesdoc"]) : false;
                            output.mostrar_articulo_kardex = drd.HasColumn("mostrar_articulo_kardex") ? drd["mostrar_articulo_kardex"] == DBNull.Value ? false : Convert.ToBoolean(drd["mostrar_articulo_kardex"]) : false;
                            output.flg_botontiendaenplaya = drd.HasColumn("flg_botontiendaenplaya") ? drd["flg_botontiendaenplaya"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_botontiendaenplaya"]) : false;
                            output.valida_correlativo = drd.HasColumn("valida_correlativo") ? drd["valida_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["valida_correlativo"]) : false;
                            output.flg_invent_fisicoteorico = drd.HasColumn("flg_invent_fisicoteorico") ? drd["flg_invent_fisicoteorico"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_invent_fisicoteorico"]) : false;
                            output.punto_nd = drd.HasColumn("punto_nd") ? drd["punto_nd"] == DBNull.Value ? false : Convert.ToBoolean(drd["punto_nd"]) : false;
                            output.cancelado = drd.HasColumn("cancelado") ? drd["cancelado"] == DBNull.Value ? false : Convert.ToBoolean(drd["cancelado"]) : false;
                            output.correlativos2_ticket = drd.HasColumn("correlativos2_ticket") ? drd["correlativos2_ticket"] == DBNull.Value ? false : Convert.ToBoolean(drd["correlativos2_ticket"]) : false;
                            output.chkclientedia = drd.HasColumn("chkclientedia") ? drd["chkclientedia"] == DBNull.Value ? false : Convert.ToBoolean(drd["chkclientedia"]) : false;
                            output.escirsa = drd.HasColumn("escirsa") ? drd["escirsa"] == DBNull.Value ? false : Convert.ToBoolean(drd["escirsa"]) : false;
                            output.flgcierraturnoxcaja = drd.HasColumn("flgcierraturnoxcaja") ? drd["flgcierraturnoxcaja"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierraturnoxcaja"]) : false;
                            output.activadispensador = drd.HasColumn("activadispensador") ? drd["activadispensador"] == DBNull.Value ? false : Convert.ToBoolean(drd["activadispensador"]) : false;
                            output.cambioturno = drd.HasColumn("cambioturno") ? drd["cambioturno"] == DBNull.Value ? false : Convert.ToBoolean(drd["cambioturno"]) : false;
                            output.iniciodia = drd.HasColumn("iniciodia") ? drd["iniciodia"] == DBNull.Value ? false : Convert.ToBoolean(drd["iniciodia"]) : false;
                            output.pd_separaglp = drd.HasColumn("pd_separaglp") ? drd["pd_separaglp"] == DBNull.Value ? false : Convert.ToBoolean(drd["pd_separaglp"]) : false;
                            output.flgvalida_nrovale = drd.HasColumn("flgvalida_nrovale") ? drd["flgvalida_nrovale"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgvalida_nrovale"]) : false;
                            output.arequipa = drd.HasColumn("arequipa") ? drd["arequipa"] == DBNull.Value ? false : Convert.ToBoolean(drd["arequipa"]) : false;
                            output.pantalland_cliprintnd = drd.HasColumn("pantalland_cliprintnd") ? drd["pantalland_cliprintnd"] == DBNull.Value ? false : Convert.ToBoolean(drd["pantalland_cliprintnd"]) : false;
                            output.imprime_total_dispensado = drd.HasColumn("imprime_total_dispensado") ? drd["imprime_total_dispensado"] == DBNull.Value ? false : Convert.ToBoolean(drd["imprime_total_dispensado"]) : false;
                            output.imprime_clientes_credito = drd.HasColumn("imprime_clientes_credito") ? drd["imprime_clientes_credito"] == DBNull.Value ? false : Convert.ToBoolean(drd["imprime_clientes_credito"]) : false;
                            output.triveno = drd.HasColumn("triveno") ? drd["triveno"] == DBNull.Value ? false : Convert.ToBoolean(drd["triveno"]) : false;
                            output.activasawa = drd.HasColumn("activasawa") ? drd["activasawa"] == DBNull.Value ? false : Convert.ToBoolean(drd["activasawa"]) : false;
                            output.desanular = drd.HasColumn("desanular") ? drd["desanular"] == DBNull.Value ? false : Convert.ToBoolean(drd["desanular"]) : false;
                            output.flgsistema03 = drd.HasColumn("flgsistema03") ? drd["flgsistema03"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsistema03"]) : false;
                            output.flgcontometro = drd.HasColumn("flgcontometro") ? drd["flgcontometro"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcontometro"]) : false;
                            output.flgsolotienda = drd.HasColumn("flgsolotienda") ? drd["flgsolotienda"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsolotienda"]) : false;
                            output.flgmostrar_precio_orig = drd.HasColumn("flgmostrar_precio_orig") ? drd["flgmostrar_precio_orig"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgmostrar_precio_orig"]) : false;
                            output.vertiposventa = drd.HasColumn("vertiposventa") ? drd["vertiposventa"] == DBNull.Value ? false : Convert.ToBoolean(drd["vertiposventa"]) : false;
                            output.redondeasolescombus = drd.HasColumn("redondeasolescombus") ? drd["redondeasolescombus"] == DBNull.Value ? false : Convert.ToBoolean(drd["redondeasolescombus"]) : false;
                            output.bloqventaplaya = drd.HasColumn("bloqventaplaya") ? drd["bloqventaplaya"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqventaplaya"]) : false;
                            output.saltoauto = drd.HasColumn("saltoauto") ? drd["saltoauto"] == DBNull.Value ? false : Convert.ToBoolean(drd["saltoauto"]) : false;
                            output.tarjcredplaca = drd.HasColumn("tarjcredplaca") ? drd["tarjcredplaca"] == DBNull.Value ? false : Convert.ToBoolean(drd["tarjcredplaca"]) : false;
                            output.flgprintndespacho = drd.HasColumn("flgprintndespacho") ? drd["flgprintndespacho"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgprintndespacho"]) : false;
                            output.flgsistema01 = drd.HasColumn("flgsistema01") ? drd["flgsistema01"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsistema01"]) : false;
                            output.flgsistema02 = drd.HasColumn("flgsistema02") ? drd["flgsistema02"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgsistema02"]) : false;
                            output.stknegativo = drd.HasColumn("stknegativo") ? drd["stknegativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["stknegativo"]) : false;
                            output.conexiondispensador = drd.HasColumn("conexiondispensador") ? drd["conexiondispensador"] == DBNull.Value ? false : Convert.ToBoolean(drd["conexiondispensador"]) : false;
                            output.flggrifo = drd.HasColumn("flggrifo") ? drd["flggrifo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flggrifo"]) : false;
                            output.zenpantalla = drd.HasColumn("zenpantalla") ? drd["zenpantalla"] == DBNull.Value ? false : Convert.ToBoolean(drd["zenpantalla"]) : false;
                            output.flgcreaprodmov = drd.HasColumn("flgcreaprodmov") ? drd["flgcreaprodmov"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcreaprodmov"]) : false;
                            output.flgvalidaruc = drd.HasColumn("flgvalidaruc") ? drd["flgvalidaruc"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgvalidaruc"]) : false;
                            output.coloron = drd.HasColumn("coloron") ? drd["coloron"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["coloron"]) : (decimal?)null;
                            output.coloroff = drd.HasColumn("coloroff") ? drd["coloroff"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["coloroff"]) : (decimal?)null;
                            output.colorgrid = drd.HasColumn("colorgrid") ? drd["colorgrid"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["colorgrid"]) : (decimal?)null;
                            output.impuesto = drd.HasColumn("impuesto") ? drd["impuesto"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["impuesto"]) : (decimal?)null;
                            output.porservicio = drd.HasColumn("porservicio") ? drd["porservicio"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porservicio"]) : (decimal?)null;
                            output.nropago = drd.HasColumn("nropago") ? drd["nropago"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nropago"]) : (decimal?)null;
                            output.nroinventario = drd.HasColumn("nroinventario") ? drd["nroinventario"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nroinventario"]) : (decimal?)null;
                            output.mto_facturacion_automatica = drd.HasColumn("mto_facturacion_automatica") ? drd["mto_facturacion_automatica"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mto_facturacion_automatica"]) : (decimal?)null;
                            output.redondeo = drd.HasColumn("redondeo") ? drd["redondeo"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["redondeo"]) : (decimal?)null;
                            output.mtominimodni_sunat = drd.HasColumn("mtominimodni_sunat") ? drd["mtominimodni_sunat"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtominimodni_sunat"]) : (decimal?)null;
                            output.mtominideposito = drd.HasColumn("mtominideposito") ? drd["mtominideposito"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtominideposito"]) : (decimal?)null;
                            output.valorigv = drd.HasColumn("valorigv") ? drd["valorigv"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["valorigv"]) : (decimal?)null;
                            output.colum_termica = drd.HasColumn("colum_termica") ? drd["colum_termica"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["colum_termica"]) : (decimal?)null;
                            output.mtominimodetraccion = drd.HasColumn("mtominimodetraccion") ? drd["mtominimodetraccion"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtominimodetraccion"]) : (decimal?)null;
                            output.mtominimodni = drd.HasColumn("mtominimodni") ? drd["mtominimodni"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtominimodni"]) : (decimal?)null;
                            output.mtominautomatico = drd.HasColumn("mtominautomatico") ? drd["mtominautomatico"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtominautomatico"]) : (decimal?)null;
                            output.mtocupon = drd.HasColumn("mtocupon") ? drd["mtocupon"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtocupon"]) : (decimal?)null;
                            output.modifica_precio_tienda = drd.HasColumn("modifica_precio_tienda") ? drd["modifica_precio_tienda"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["modifica_precio_tienda"]) : (decimal?)null;
                            output.precio_varios = drd.HasColumn("precio_varios") ? drd["precio_varios"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["precio_varios"]) : (decimal?)null;
                            output.diasresetptos = drd.HasColumn("diasresetptos") ? drd["diasresetptos"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["diasresetptos"]) : (decimal?)null;
                            output.cant_turno = drd.HasColumn("cant_turno") ? drd["cant_turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["cant_turno"]) : (decimal?)null;
                            output.ptobonus = drd.HasColumn("ptobonus") ? drd["ptobonus"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ptobonus"]) : (decimal?)null;
                            output.intervaltimer = drd.HasColumn("intervaltimer") ? drd["intervaltimer"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["intervaltimer"]) : (decimal?)null;
                            output.minutosxtktbol = drd.HasColumn("minutosxtktbol") ? drd["minutosxtktbol"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["minutosxtktbol"]) : (decimal?)null;
                            output.nrodeposito = drd.HasColumn("nrodeposito") ? drd["nrodeposito"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrodeposito"]) : (decimal?)null;
                            output.longtarjeta = drd.HasColumn("longtarjeta") ? drd["longtarjeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["longtarjeta"]) : (decimal?)null;
                            output.nrocdbarra = drd.HasColumn("nrocdbarra") ? drd["nrocdbarra"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrocdbarra"]) : (decimal?)null;
                            output.digitoruc = drd.HasColumn("digitoruc") ? drd["digitoruc"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["digitoruc"]) : (decimal?)null;
                            output.nrocara = drd.HasColumn("nrocara") ? drd["nrocara"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrocara"]) : (decimal?)null;
                            output.nrotransgasboy = drd.HasColumn("nrotransgasboy") ? drd["nrotransgasboy"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrotransgasboy"]) : (decimal?)null;
                            output.digitocdcliente = drd.HasColumn("digitocdcliente") ? drd["digitocdcliente"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["digitocdcliente"]) : (decimal?)null;
                            output.porcipm = drd.HasColumn("porcipm") ? drd["porcipm"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["porcipm"]) : (decimal?)null;
                            output.versionbo = drd.HasColumn("versionbo") ? drd["versionbo"] == DBNull.Value ? null : drd["versionbo"].ToString() : null;
                            output.versiontinven = drd.HasColumn("versiontinven") ? drd["versiontinven"] == DBNull.Value ? null : drd["versiontinven"].ToString() : null;
                            output.versionplaya = drd.HasColumn("versionplaya") ? drd["versionplaya"] == DBNull.Value ? null : drd["versionplaya"].ToString() : null;
                            output.versiontienda = drd.HasColumn("versiontienda") ? drd["versiontienda"] == DBNull.Value ? null : drd["versiontienda"].ToString() : null;
                            output.ruta_backup = drd.HasColumn("ruta_backup") ? drd["ruta_backup"] == DBNull.Value ? null : drd["ruta_backup"].ToString() : null;
                            output.valorcanje_regvta = drd.HasColumn("valorcanje_regvta") ? drd["valorcanje_regvta"] == DBNull.Value ? null : drd["valorcanje_regvta"].ToString() : null;
                            output.passwordweb = drd.HasColumn("passwordweb") ? drd["passwordweb"] == DBNull.Value ? null : drd["passwordweb"].ToString() : null;
                            output.ruta_qr_jpg = drd.HasColumn("ruta_qr_jpg") ? drd["ruta_qr_jpg"] == DBNull.Value ? null : drd["ruta_qr_jpg"].ToString() : null;
                            output.mto_desc_descripcion = drd.HasColumn("mto_desc_descripcion") ? drd["mto_desc_descripcion"] == DBNull.Value ? null : drd["mto_desc_descripcion"].ToString() : null;
                            output.cdcliente_automatico = drd.HasColumn("cdcliente_automatico") ? drd["cdcliente_automatico"] == DBNull.Value ? null : drd["cdcliente_automatico"].ToString() : null;
                            output.rscliente_automatico = drd.HasColumn("rscliente_automatico") ? drd["rscliente_automatico"] == DBNull.Value ? null : drd["rscliente_automatico"].ToString() : null;
                            output.msg_anula_documento = drd.HasColumn("msg_anula_documento") ? drd["msg_anula_documento"] == DBNull.Value ? null : drd["msg_anula_documento"].ToString() : null;
                            output.nroversiontienda = drd.HasColumn("nroversiontienda") ? drd["nroversiontienda"] == DBNull.Value ? null : drd["nroversiontienda"].ToString() : null;
                            output.nroversionti = drd.HasColumn("nroversionti") ? drd["nroversionti"] == DBNull.Value ? null : drd["nroversionti"].ToString() : null;
                            output.conexionweb = drd.HasColumn("conexionweb") ? drd["conexionweb"] == DBNull.Value ? null : drd["conexionweb"].ToString() : null;
                            output.instanciaweb = drd.HasColumn("instanciaweb") ? drd["instanciaweb"] == DBNull.Value ? null : drd["instanciaweb"].ToString() : null;
                            output.bdweb = drd.HasColumn("bdweb") ? drd["bdweb"] == DBNull.Value ? null : drd["bdweb"].ToString() : null;
                            output.userweb = drd.HasColumn("userweb") ? drd["userweb"] == DBNull.Value ? null : drd["userweb"].ToString() : null;
                            output.ruta_ws_easytaxy = drd.HasColumn("ruta_ws_easytaxy") ? drd["ruta_ws_easytaxy"] == DBNull.Value ? null : drd["ruta_ws_easytaxy"].ToString() : null;
                            output.cod_viatico = drd.HasColumn("cod_viatico") ? drd["cod_viatico"] == DBNull.Value ? null : drd["cod_viatico"].ToString() : null;
                            output.horacierrepd = drd.HasColumn("horacierrepd") ? drd["horacierrepd"] == DBNull.Value ? null : drd["horacierrepd"].ToString() : null;
                            output.interfaz = drd.HasColumn("interfaz") ? drd["interfaz"] == DBNull.Value ? null : drd["interfaz"].ToString() : null;
                            output.nroversionbo = drd.HasColumn("nroversionbo") ? drd["nroversionbo"] == DBNull.Value ? null : drd["nroversionbo"].ToString() : null;
                            output.nroversionplaya = drd.HasColumn("nroversionplaya") ? drd["nroversionplaya"] == DBNull.Value ? null : drd["nroversionplaya"].ToString() : null;
                            output.facturaimpre_c = drd.HasColumn("facturaimpre_c") ? drd["facturaimpre_c"] == DBNull.Value ? null : drd["facturaimpre_c"].ToString() : null;
                            output.facturafmt_c = drd.HasColumn("facturafmt_c") ? drd["facturafmt_c"] == DBNull.Value ? null : drd["facturafmt_c"].ToString() : null;
                            output.tpsalmerma = drd.HasColumn("tpsalmerma") ? drd["tpsalmerma"] == DBNull.Value ? null : drd["tpsalmerma"].ToString() : null;
                            output.tpsaldev = drd.HasColumn("tpsaldev") ? drd["tpsaldev"] == DBNull.Value ? null : drd["tpsaldev"].ToString() : null;
                            output.ruta_websaldos = drd.HasColumn("ruta_websaldos") ? drd["ruta_websaldos"] == DBNull.Value ? null : drd["ruta_websaldos"].ToString() : null;
                            output.ruta_webclubgazel = drd.HasColumn("ruta_webclubgazel") ? drd["ruta_webclubgazel"] == DBNull.Value ? null : drd["ruta_webclubgazel"].ToString() : null;
                            output.monsistema = drd.HasColumn("monsistema") ? drd["monsistema"] == DBNull.Value ? null : drd["monsistema"].ToString() : null;
                            output.monticket = drd.HasColumn("monticket") ? drd["monticket"] == DBNull.Value ? null : drd["monticket"].ToString() : null;
                            output.tpsalida = drd.HasColumn("tpsalida") ? drd["tpsalida"] == DBNull.Value ? null : drd["tpsalida"].ToString() : null;
                            output.tpingreso = drd.HasColumn("tpingreso") ? drd["tpingreso"] == DBNull.Value ? null : drd["tpingreso"].ToString() : null;
                            output.masccantidad = drd.HasColumn("masccantidad") ? drd["masccantidad"] == DBNull.Value ? null : drd["masccantidad"].ToString() : null;
                            output.masccantidadf = drd.HasColumn("masccantidadf") ? drd["masccantidadf"] == DBNull.Value ? null : drd["masccantidadf"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.prefflotlocal = drd.HasColumn("prefflotlocal") ? drd["prefflotlocal"] == DBNull.Value ? null : drd["prefflotlocal"].ToString() : null;
                            output.fe_fecvalida = drd.HasColumn("fe_fecvalida") ? drd["fe_fecvalida"] == DBNull.Value ? null : drd["fe_fecvalida"].ToString() : null;
                            output.tppgogasto = drd.HasColumn("tppgogasto") ? drd["tppgogasto"] == DBNull.Value ? null : drd["tppgogasto"].ToString() : null;
                            output.flg_invent_2 = drd.HasColumn("flg_invent_2") ? drd["flg_invent_2"] == DBNull.Value ? null : drd["flg_invent_2"].ToString() : null;
                            output.cddepart_base = drd.HasColumn("cddepart_base") ? drd["cddepart_base"] == DBNull.Value ? null : drd["cddepart_base"].ToString() : null;
                            output.factura_c = drd.HasColumn("factura_c") ? drd["factura_c"] == DBNull.Value ? null : drd["factura_c"].ToString() : null;
                            output.guia = drd.HasColumn("guia") ? drd["guia"] == DBNull.Value ? null : drd["guia"].ToString() : null;
                            output.guiaimpr = drd.HasColumn("guiaimpr") ? drd["guiaimpr"] == DBNull.Value ? null : drd["guiaimpr"].ToString() : null;
                            output.guiafmt = drd.HasColumn("guiafmt") ? drd["guiafmt"] == DBNull.Value ? null : drd["guiafmt"].ToString() : null;
                            output.tipo_canje = drd.HasColumn("tipo_canje") ? drd["tipo_canje"] == DBNull.Value ? null : drd["tipo_canje"].ToString() : null;
                            output.cdtipodocautomatico = drd.HasColumn("cdtipodocautomatico") ? drd["cdtipodocautomatico"] == DBNull.Value ? null : drd["cdtipodocautomatico"].ToString() : null;
                            output.cdclienteautomatico = drd.HasColumn("cdclienteautomatico") ? drd["cdclienteautomatico"] == DBNull.Value ? null : drd["cdclienteautomatico"].ToString() : null;
                            output.tipoafiliacion = drd.HasColumn("tipoafiliacion") ? drd["tipoafiliacion"] == DBNull.Value ? null : drd["tipoafiliacion"].ToString() : null;
                            output.tipoptoafiliacion = drd.HasColumn("tipoptoafiliacion") ? drd["tipoptoafiliacion"] == DBNull.Value ? null : drd["tipoptoafiliacion"].ToString() : null;
                            output.seriehd_imprime_ticket_web = drd.HasColumn("seriehd_imprime_ticket_web") ? drd["seriehd_imprime_ticket_web"] == DBNull.Value ? null : drd["seriehd_imprime_ticket_web"].ToString() : null;
                            output.notad_cdarticulo = drd.HasColumn("notad_cdarticulo") ? drd["notad_cdarticulo"] == DBNull.Value ? null : drd["notad_cdarticulo"].ToString() : null;
                            output.cd_estacion = drd.HasColumn("cd_estacion") ? drd["cd_estacion"] == DBNull.Value ? null : drd["cd_estacion"].ToString() : null;
                            output.tptransftienda = drd.HasColumn("tptransftienda") ? drd["tptransftienda"] == DBNull.Value ? null : drd["tptransftienda"].ToString() : null;
                            output.lin1display = drd.HasColumn("lin1display") ? drd["lin1display"] == DBNull.Value ? null : drd["lin1display"].ToString() : null;
                            output.lin2display = drd.HasColumn("lin2display") ? drd["lin2display"] == DBNull.Value ? null : drd["lin2display"].ToString() : null;
                            output.tipocontrol = drd.HasColumn("tipocontrol") ? drd["tipocontrol"] == DBNull.Value ? null : drd["tipocontrol"].ToString() : null;
                            output.cdcliprintndespacho = drd.HasColumn("cdcliprintndespacho") ? drd["cdcliprintndespacho"] == DBNull.Value ? null : drd["cdcliprintndespacho"].ToString() : null;
                            output.tppgocanje = drd.HasColumn("tppgocanje") ? drd["tppgocanje"] == DBNull.Value ? null : drd["tppgocanje"].ToString() : null;
                            output.prefcredlocal = drd.HasColumn("prefcredlocal") ? drd["prefcredlocal"] == DBNull.Value ? null : drd["prefcredlocal"].ToString() : null;
                            output.prefcredcorp = drd.HasColumn("prefcredcorp") ? drd["prefcredcorp"] == DBNull.Value ? null : drd["prefcredcorp"].ToString() : null;
                            output.prefbonus = drd.HasColumn("prefbonus") ? drd["prefbonus"] == DBNull.Value ? null : drd["prefbonus"].ToString() : null;
                            output.cdestacion = drd.HasColumn("cdestacion") ? drd["cdestacion"] == DBNull.Value ? null : drd["cdestacion"].ToString() : null;
                            output.nivelserafin = drd.HasColumn("nivelserafin") ? drd["nivelserafin"] == DBNull.Value ? null : drd["nivelserafin"].ToString() : null;
                            output.cdgrupovtaplaya = drd.HasColumn("cdgrupovtaplaya") ? drd["cdgrupovtaplaya"] == DBNull.Value ? null : drd["cdgrupovtaplaya"].ToString() : null;
                            output.tpguiatransferencia = drd.HasColumn("tpguiatransferencia") ? drd["tpguiatransferencia"] == DBNull.Value ? null : drd["tpguiatransferencia"].ToString() : null;
                            output.nrovale = drd.HasColumn("nrovale") ? drd["nrovale"] == DBNull.Value ? null : drd["nrovale"].ToString() : null;
                            output.cdletrainicial = drd.HasColumn("cdletrainicial") ? drd["cdletrainicial"] == DBNull.Value ? null : drd["cdletrainicial"].ToString() : null;
                            output.nroimportacion = drd.HasColumn("nroimportacion") ? drd["nroimportacion"] == DBNull.Value ? null : drd["nroimportacion"].ToString() : null;
                            output.tpingimportacion = drd.HasColumn("tpingimportacion") ? drd["tpingimportacion"] == DBNull.Value ? null : drd["tpingimportacion"].ToString() : null;
                            output.tpanulacion = drd.HasColumn("tpanulacion") ? drd["tpanulacion"] == DBNull.Value ? null : drd["tpanulacion"].ToString() : null;
                            output.tpinicial = drd.HasColumn("tpinicial") ? drd["tpinicial"] == DBNull.Value ? null : drd["tpinicial"].ToString() : null;
                            output.tptransferencia = drd.HasColumn("tptransferencia") ? drd["tptransferencia"] == DBNull.Value ? null : drd["tptransferencia"].ToString() : null;
                            output.tptransferenciainterna = drd.HasColumn("tptransferenciainterna") ? drd["tptransferenciainterna"] == DBNull.Value ? null : drd["tptransferenciainterna"].ToString() : null;
                            output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
                            output.cdgrupocombustible = drd.HasColumn("cdgrupocombustible") ? drd["cdgrupocombustible"] == DBNull.Value ? null : drd["cdgrupocombustible"].ToString() : null;
                            output.mascprecio = drd.HasColumn("mascprecio") ? drd["mascprecio"] == DBNull.Value ? null : drd["mascprecio"].ToString() : null;
                            output.masccosto = drd.HasColumn("masccosto") ? drd["masccosto"] == DBNull.Value ? null : drd["masccosto"].ToString() : null;
                            output.masctotal = drd.HasColumn("masctotal") ? drd["masctotal"] == DBNull.Value ? null : drd["masctotal"].ToString() : null;
                            output.tpcompra = drd.HasColumn("tpcompra") ? drd["tpcompra"] == DBNull.Value ? null : drd["tpcompra"].ToString() : null;
                            output.nrocompra = drd.HasColumn("nrocompra") ? drd["nrocompra"] == DBNull.Value ? null : drd["nrocompra"].ToString() : null;
                            output.tpcambiotalla = drd.HasColumn("tpcambiotalla") ? drd["tpcambiotalla"] == DBNull.Value ? null : drd["tpcambiotalla"].ToString() : null;
                            output.bbddsetup = drd.HasColumn("bbddsetup") ? drd["bbddsetup"] == DBNull.Value ? null : drd["bbddsetup"].ToString() : null;
                             
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
            // using (SqlConnection con = new SqlConnection(stringBackOffice))
            //{

            //    try
            //    {
            //        con.Open();
            //        SqlCommand cmd = new SqlCommand("SP_ITBCP_OBTENER_PARAMETRO", con);

            //        cmd.CommandType = CommandType.StoredProcedure;
            //        using (SqlDataReader drd = cmd.ExecuteReader())
            //        {
            //            while (drd.Read())
            //            {
            //                output.monsistema = drd.HasColumn("monsistema") ? drd["monsistema"] == DBNull.Value ? null : drd["monsistema"].ToString() : null;
            //                output.monticket = drd.HasColumn("monticket") ? drd["monticket"] == DBNull.Value ? null : drd["monticket"].ToString() : null;
            //                output.tpsalida = drd.HasColumn("tpsalida") ? drd["tpsalida"] == DBNull.Value ? null : drd["tpsalida"].ToString() : null;
            //                output.tpingreso = drd.HasColumn("tpingreso") ? drd["tpingreso"] == DBNull.Value ? null : drd["tpingreso"].ToString() : null;
            //                output.coloron = drd.HasColumn("coloron") ? (drd["coloron"] == DBNull.Value ? 0 :Convert.ToDecimal(drd["coloron"])) : 0;
            //                 output.coloroff = drd.HasColumn("coloroff") ? (drd["coloroff"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["coloroff"])) : 0;
            //                 output.colorgrid = drd.HasColumn("colorgrid") ? (drd["colorgrid"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["colorgrid"])) : 0;
            //                 output.masccantidad = drd.HasColumn("masccantidad") ? drd["masccantidad"] == DBNull.Value ? null : drd["masccantidad"].ToString() : null;
            //                 output.masccantidadf = drd.HasColumn("masccantidadf") ? drd["masccantidadf"] == DBNull.Value ? null : drd["masccantidadf"].ToString() : null;
            //                 output.mascprecio = drd.HasColumn("mascprecio") ? drd["mascprecio"] == DBNull.Value ? null : drd["mascprecio"].ToString() : null;
            //                 output.masccosto = drd.HasColumn("masccosto") ? drd["masccosto"] == DBNull.Value ? null : drd["masccosto"].ToString() : null;
            //                 output.masctotal = drd.HasColumn("masctotal") ? drd["masctotal"] == DBNull.Value ? null : drd["masctotal"].ToString() : null;
            //                 output.impuesto = drd.HasColumn("impuesto") ? (drd["impuesto"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["impuesto"])) : 0;
            //                output.flgtalla =drd.HasColumn("flgtalla") ? drd["flgtalla"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgtalla"]) : false;
            //                 output.flgformula = drd.HasColumn("flgformula") ? drd["flgformula"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgformula"]) : false;
            //                 output.precioconigv = drd.HasColumn("precioconigv") ? drd["precioconigv"] == DBNull.Value ? false : Convert.ToBoolean(drd["precioconigv"]) : false;
            //                 output.precioconservicio = drd.HasColumn("precioconservicio") ? drd["precioconservicio"] == DBNull.Value ? false : Convert.ToBoolean(drd["precioconservicio"]) : false;
            //                 output.porservicio = drd.HasColumn("porservicio") ? drd["porservicio"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["porservicio"]) : 0;
            //                 output.fecinstall = drd.HasColumn("fecinstall") ? drd["fecinstall"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(drd["fecinstall"]) : DateTime.Now;
            //                output.tpcompra = drd.HasColumn("tpcompra") ? drd["tpcompra"] == DBNull.Value ? null : drd["tpcompra"].ToString() : null;
            //                 output.nrocompra = drd.HasColumn("nrocompra") ? drd["nrocompra"] == DBNull.Value ? null : drd["nrocompra"].ToString() : null;
            //                 output.tpcambiotalla = drd.HasColumn("tpcambiotalla") ? drd["tpcambiotalla"] == DBNull.Value ? null : drd["tpcambiotalla"].ToString() : null;
            //                 output.tpanulacion = drd.HasColumn("tpanulacion") ? drd["tpanulacion"] == DBNull.Value ? null : drd["tpanulacion"].ToString() : null;
            //                output.tpinicial = drd.HasColumn("tpinicial") ? drd["tpinicial"] == DBNull.Value ? null : drd["tpinicial"].ToString() : null;
            //                 output.tptransferencia = drd.HasColumn("tptransferencia") ? drd["tptransferencia"] == DBNull.Value ? null : drd["tptransferencia"].ToString() : null;
            //                 output.tptransferenciainterna = drd.HasColumn("tptransferenciainterna") ? drd["tptransferenciainterna"] == DBNull.Value ? null : drd["tptransferenciainterna"].ToString() : null;
            //                 output.utilidadcosto = drd.HasColumn("utilidadcosto") ? drd["utilidadcosto"] == DBNull.Value ? false : Convert.ToBoolean(drd["utilidadcosto"]) : false;
            //                 output.flgintegrador = drd.HasColumn("flgintegrador") ? drd["flgintegrador"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgintegrador"]) : false;
            //                 output.cdlocal = drd.HasColumn("cdlocal") ? drd["cdlocal"] == DBNull.Value ? null : drd["cdlocal"].ToString() : null;
            //                 output.nropago = drd.HasColumn("nropago") ? drd["nropago"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["nropago"]) : 0;
            //                 output.stknegativo = drd.HasColumn("stknegativo") ? drd["stknegativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["stknegativo"]) : false;
            //                 output.nrocdbarra = drd.HasColumn("nrocdbarra") ? drd["nrocdbarra"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["nrocdbarra"]) : 0;
            //               output.cdgrupocombustible = drd.HasColumn("cdgrupocombustible") ? drd["cdgrupocombustible"] == DBNull.Value ? null : drd["cdgrupocombustible"].ToString() : null;
            //               output.cdgrupovtaplaya = drd.HasColumn("cdgrupovtaplaya") ? drd["cdgrupovtaplaya"] == DBNull.Value ? null : drd["cdgrupovtaplaya"].ToString() : null;
            //                 output.conexiondispensador = drd.HasColumn("conexiondispensador") ? drd["conexiondispensador"] == DBNull.Value ? false : Convert.ToBoolean(drd["conexiondispensador"]) : false;
            //                 output.nrocara = drd.HasColumn("nrocara") ? drd["nrocara"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["nrocara"]) : 0;
            //                output.tpguiatransferencia = drd.HasColumn("tpguiatransferencia") ? drd["tpguiatransferencia"] == DBNull.Value ? null : drd["tpguiatransferencia"].ToString() : null;
            //                 output.flggrifo = drd.HasColumn("flggrifo") ? drd["flggrifo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flggrifo"]) : false;
            //                 output.nrovale = drd.HasColumn("nrovale") ? drd["nrovale"] == DBNull.Value ? null : drd["nrovale"].ToString() : null;
            //                 output.nrotransgasboy = drd.HasColumn("nrotransgasboy") ? drd["nrotransgasboy"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["nrotransgasboy"]) : 0;
            //                 output.zenpantalla = drd.HasColumn("zenpantalla") ? drd["zenpantalla"] == DBNull.Value ? false : Convert.ToBoolean(drd["zenpantalla"]) : false;
            //                 output.cdletrainicial = drd.HasColumn("cdletrainicial") ? drd["cdletrainicial"] == DBNull.Value ? null : drd["cdletrainicial"].ToString() : null;
            //                 output.nroimportacion = drd.HasColumn("nroimportacion") ? drd["nroimportacion"] == DBNull.Value ? null : drd["nroimportacion"].ToString() : null;
            //                 output.digitocdcliente = drd.HasColumn("digitocdcliente") ? drd["digitocdcliente"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["digitocdcliente"]) : 0;
            //                 output.flgcreaprodmov = drd.HasColumn("flgcreaprodmov") ? drd["flgcreaprodmov"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcreaprodmov"]) : false;
            //                 output.porcipm = drd.HasColumn("porcipm") ? drd["porcipm"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["porcipm"]) : 0;
            //                 output.tpingimportacion = drd.HasColumn("tpingimportacion") ? drd["tpingimportacion"] == DBNull.Value ? null : drd["tpingimportacion"].ToString() : null;
            //                output.flgvalidaruc = drd.HasColumn("flgvalidaruc") ? drd["flgvalidaruc"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgvalidaruc"]) : false;
            //                 output.cant_turno = drd.HasColumn("cant_turno") ? drd["cant_turno"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["cant_turno"]) : 0;
            //                 output.tppgocanje = drd.HasColumn("tppgocanje") ? drd["tppgocanje"] == DBNull.Value ? null : drd["tppgocanje"].ToString() : null;
            //                 output.prefcredlocal = drd.HasColumn("prefcredlocal") ? drd["prefcredlocal"] == DBNull.Value ? null : drd["prefcredlocal"].ToString() : null;
            //                 output.prefcredcorp = drd.HasColumn("prefcredcorp") ? drd["prefcredcorp"] == DBNull.Value ? null : drd["prefcredcorp"].ToString() : null;
            //                 output.prefbonus = drd.HasColumn("prefbonus") ? drd["prefbonus"] == DBNull.Value ? null : drd["prefbonus"].ToString() : null;
            //                 output.ptobonus = drd.HasColumn("ptobonus") ? drd["ptobonus"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["ptobonus"]) : 0;
            //                 output.bloqventaplaya = drd.HasColumn("bloqventaplaya") ? drd["bloqventaplaya"] == DBNull.Value ? false : Convert.ToBoolean(drd["bloqventaplaya"]) : false;
            //                output.cdestacion = drd.HasColumn("cdestacion") ? drd["cdestacion"] == DBNull.Value ? null : drd["cdestacion"].ToString() : null;
            //                 output.nivelserafin = drd.HasColumn("nivelserafin") ? drd["nivelserafin"] == DBNull.Value ? null : drd["nivelserafin"].ToString() : null;
            //                 output.cd_estacion = drd.HasColumn("cd_estacion") ? drd["cd_estacion"] == DBNull.Value ? null : drd["cd_estacion"].ToString() : null;
            //                 output.intervaltimer = drd.HasColumn("intervaltimer") ? drd["intervaltimer"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["intervaltimer"]) : 0;
            //                 output.minutosxtktbol = drd.HasColumn("minutosxtktbol") ? drd["minutosxtktbol"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["minutosxtktbol"]) : 0;
            //                 output.tptransftienda = drd.HasColumn("tptransftienda") ? drd["tptransftienda"] == DBNull.Value ? null : drd["tptransftienda"].ToString() : null;
            //                 output.nrodeposito = drd.HasColumn("nrodeposito") ? drd["nrodeposito"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["nrodeposito"]) : 0;
            //                 output.longtarjeta = drd.HasColumn("longtarjeta") ? drd["longtarjeta"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["longtarjeta"]) : 0;
            //                 output.saltoauto = drd.HasColumn("saltoauto") ? drd["saltoauto"] == DBNull.Value ? false : Convert.ToBoolean(drd["saltoauto"]) : false;
            //                 output.lin1display = drd.HasColumn("lin1display") ? drd["lin1display"] == DBNull.Value ? null : drd["lin1display"].ToString() : null;
            //                 output.lin2display = drd.HasColumn("lin2display") ? drd["lin2display"] == DBNull.Value ? null : drd["lin2display"].ToString() : null;
            //                 output.tipocontrol = drd.HasColumn("tipocontrol") ? drd["tipocontrol"] == DBNull.Value ? null : drd["tipocontrol"].ToString() : null;
            //                 output.mtominimodni = drd.HasColumn("mtominimodni") ? drd["mtominimodni"] == DBNull.Value ? 0 : Convert.ToDecimal(drd["mtominimodni"]) : 0;
            //                 output.tarjcredplaca = drd.HasColumn("tarjcredplaca") ? drd["tarjcredplaca"] == DBNull.Value ? false : Convert.ToBoolean(drd["tarjcredplaca"]) : false;
            //                 output.flgprintndespacho = drd.HasColumn("flgprintndespacho") ? drd["flgprintndespacho"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgprintndespacho"]) : false;
            //                output.cdcliprintndespacho = drd.HasColumn("cdcliprintndespacho") ? drd["cdcliprintndespacho"] == DBNull.Value ? null : drd["cdcliprintndespacho"].ToString() : null;
            //                output.cdclienteautomatico = drd.HasColumn("cdclienteautomatico") ? drd["cdclienteautomatico"] == DBNull.Value ? null : drd["cdclienteautomatico"].ToString() : null;
            //                // output.flgSistema01 = drd.HasColumn("flgSistema01") ? drd["flgSistema01"] == DBNull.Value ? null : drd["flgSistema01"].ToString() : null;
            //                //  output.flgSistema02 = drd.HasColumn("flgSistema02") ? drd["flgSistema02"] == DBNull.Value ? null : drd["flgSistema02"].ToString() : null;
            //                // output.flgSistema03 = drd.HasColumn("flgSistema03") ? drd["flgSistema03"] == DBNull.Value ? null : drd["flgSistema03"].ToString() : null;
            //                // output.flgcontometro = drd.HasColumn("flgcontometro") ? drd["flgcontometro"] == DBNull.Value ? null : drd["flgcontometro"].ToString() : null;
            //                // output.flgsolotienda = drd.HasColumn("flgsolotienda") ? drd["flgsolotienda"] == DBNull.Value ? null : drd["flgsolotienda"].ToString() : null;
            //                // output.digitoruc = drd.HasColumn("digitoruc") ? drd["digitoruc"] == DBNull.Value ? null : drd["digitoruc"].ToString() : null;
            //                // output.mtominautomatico = drd.HasColumn("mtominautomatico") ? drd["mtominautomatico"] == DBNull.Value ? null : drd["mtominautomatico"].ToString() : null;
            //                // output.VERSIONBO = drd.HasColumn("VERSIONBO") ? drd["VERSIONBO"] == DBNull.Value ? null : drd["VERSIONBO"].ToString() : null;
            //                // output.VERSIONtInven = drd.HasColumn("VERSIONtInven") ? drd["VERSIONtInven"] == DBNull.Value ? null : drd["VERSIONtInven"].ToString() : null;
            //                // output.VERSIONplaya = drd.HasColumn("VERSIONplaya") ? drd["VERSIONplaya"] == DBNull.Value ? null : drd["VERSIONplaya"].ToString() : null;
            //                // output.VERSIONtienda = drd.HasColumn("VERSIONtienda") ? drd["VERSIONtienda"] == DBNull.Value ? null : drd["VERSIONtienda"].ToString() : null;
            //                // output.flgmostrar_precio_orig = drd.HasColumn("flgmostrar_precio_orig") ? drd["flgmostrar_precio_orig"] == DBNull.Value ? null : drd["flgmostrar_precio_orig"].ToString() : null;
            //                // output.VERTIPOSVENTA = drd.HasColumn("VERTIPOSVENTA") ? drd["VERTIPOSVENTA"] == DBNull.Value ? null : drd["VERTIPOSVENTA"].ToString() : null;
            //                // output.TipoAfiliacion = drd.HasColumn("TipoAfiliacion") ? drd["TipoAfiliacion"] == DBNull.Value ? null : drd["TipoAfiliacion"].ToString() : null;
            //                // output.TipoPtoAfiliacion = drd.HasColumn("TipoPtoAfiliacion") ? drd["TipoPtoAfiliacion"] == DBNull.Value ? null : drd["TipoPtoAfiliacion"].ToString() : null;
            //                // output.CantDigitos_Tarjpromo = drd.HasColumn("CantDigitos_Tarjpromo") ? drd["CantDigitos_Tarjpromo"] == DBNull.Value ? null : drd["CantDigitos_Tarjpromo"].ToString() : null;
            //                // output.redondeaSolesCombus = drd.HasColumn("redondeaSolesCombus") ? drd["redondeaSolesCombus"] == DBNull.Value ? null : drd["redondeaSolesCombus"].ToString() : null;
            //                // output.TipoCierreXTienda = drd.HasColumn("TipoCierreXTienda") ? drd["TipoCierreXTienda"] == DBNull.Value ? null : drd["TipoCierreXTienda"].ToString() : null;
            //                // output.Cursor_tienda = drd.HasColumn("Cursor_tienda") ? drd["Cursor_tienda"] == DBNull.Value ? null : drd["Cursor_tienda"].ToString() : null;
            //                // output.repite_articulo = drd.HasColumn("repite_articulo") ? drd["repite_articulo"] == DBNull.Value ? null : drd["repite_articulo"].ToString() : null;
            //                // output.mtocupon = drd.HasColumn("mtocupon") ? drd["mtocupon"] == DBNull.Value ? null : drd["mtocupon"].ToString() : null;
            //                // output.MOdifica_precio_tienda = drd.HasColumn("MOdifica_precio_tienda") ? drd["MOdifica_precio_tienda"] == DBNull.Value ? null : drd["MOdifica_precio_tienda"].ToString() : null;
            //                // output.imprime_canjeweb = drd.HasColumn("imprime_canjeweb") ? drd["imprime_canjeweb"] == DBNull.Value ? null : drd["imprime_canjeweb"].ToString() : null;
            //                // output.precio_varios = drd.HasColumn("precio_varios") ? drd["precio_varios"] == DBNull.Value ? null : drd["precio_varios"].ToString() : null;
            //                // output.SerieHd_Imprime_Ticket_Web = drd.HasColumn("SerieHd_Imprime_Ticket_Web") ? drd["SerieHd_Imprime_Ticket_Web"] == DBNull.Value ? null : drd["SerieHd_Imprime_Ticket_Web"].ToString() : null;
            //                // output.pantalland_cliprintnd = drd.HasColumn("pantalland_cliprintnd") ? drd["pantalland_cliprintnd"] == DBNull.Value ? null : drd["pantalland_cliprintnd"].ToString() : null;
            //                // output.imprime_total_dispensado = drd.HasColumn("imprime_total_dispensado") ? drd["imprime_total_dispensado"] == DBNull.Value ? null : drd["imprime_total_dispensado"].ToString() : null;
            //                // output.imprime_ptosacumulados = drd.HasColumn("imprime_ptosacumulados") ? drd["imprime_ptosacumulados"] == DBNull.Value ? null : drd["imprime_ptosacumulados"].ToString() : null;
            //                // output.tarjeta_actu_cdcliente = drd.HasColumn("tarjeta_actu_cdcliente") ? drd["tarjeta_actu_cdcliente"] == DBNull.Value ? null : drd["tarjeta_actu_cdcliente"].ToString() : null;
            //                // output.boton_transfer_gratuita = drd.HasColumn("boton_transfer_gratuita") ? drd["boton_transfer_gratuita"] == DBNull.Value ? null : drd["boton_transfer_gratuita"].ToString() : null;
            //                // output.imprime_clientes_credito = drd.HasColumn("imprime_clientes_credito") ? drd["imprime_clientes_credito"] == DBNull.Value ? null : drd["imprime_clientes_credito"].ToString() : null;
            //                // output.tienda_cant_neg = drd.HasColumn("tienda_cant_neg") ? drd["tienda_cant_neg"] == DBNull.Value ? null : drd["tienda_cant_neg"].ToString() : null;
            //                // output.imprime_tiketera = drd.HasColumn("imprime_tiketera") ? drd["imprime_tiketera"] == DBNull.Value ? null : drd["imprime_tiketera"].ToString() : null;
            //                // output.imprime_nvta = drd.HasColumn("imprime_nvta") ? drd["imprime_nvta"] == DBNull.Value ? null : drd["imprime_nvta"].ToString() : null;
            //                // output.Modifica_depositos_parte = drd.HasColumn("Modifica_depositos_parte") ? drd["Modifica_depositos_parte"] == DBNull.Value ? null : drd["Modifica_depositos_parte"].ToString() : null;
            //                // output.mostrar_local_gastos = drd.HasColumn("mostrar_local_gastos") ? drd["mostrar_local_gastos"] == DBNull.Value ? null : drd["mostrar_local_gastos"].ToString() : null;
            //                // output.Notad_cdarticulo = drd.HasColumn("Notad_cdarticulo") ? drd["Notad_cdarticulo"] == DBNull.Value ? null : drd["Notad_cdarticulo"].ToString() : null;
            //                // output.imprimir_cdarticulo_config = drd.HasColumn("imprimir_cdarticulo_config") ? drd["imprimir_cdarticulo_config"] == DBNull.Value ? null : drd["imprimir_cdarticulo_config"].ToString() : null;
            //                // output.Mostrar_IGV_Pantalla = drd.HasColumn("Mostrar_IGV_Pantalla") ? drd["Mostrar_IGV_Pantalla"] == DBNull.Value ? null : drd["Mostrar_IGV_Pantalla"].ToString() : null;
            //                // output.tipo_menu = drd.HasColumn("tipo_menu") ? drd["tipo_menu"] == DBNull.Value ? null : drd["tipo_menu"].ToString() : null;
            //                // output.nd_playa = drd.HasColumn("nd_playa") ? drd["nd_playa"] == DBNull.Value ? null : drd["nd_playa"].ToString() : null;
            //                // output.valida_cdarticulo = drd.HasColumn("valida_cdarticulo") ? drd["valida_cdarticulo"] == DBNull.Value ? null : drd["valida_cdarticulo"].ToString() : null;
            //                // output.Conf_cierrex = drd.HasColumn("Conf_cierrex") ? drd["Conf_cierrex"] == DBNull.Value ? null : drd["Conf_cierrex"].ToString() : null;
            //                // output.cierreX_formatos = drd.HasColumn("cierreX_formatos") ? drd["cierreX_formatos"] == DBNull.Value ? null : drd["cierreX_formatos"].ToString() : null;
            //                // output.Imprime_fact_playa = drd.HasColumn("Imprime_fact_playa") ? drd["Imprime_fact_playa"] == DBNull.Value ? null : drd["Imprime_fact_playa"].ToString() : null;
            //                // output.credplaca = drd.HasColumn("credplaca") ? drd["credplaca"] == DBNull.Value ? null : drd["credplaca"].ToString() : null;
            //                // output.cierre_especial = drd.HasColumn("cierre_especial") ? drd["cierre_especial"] == DBNull.Value ? null : drd["cierre_especial"].ToString() : null;
            //                // output.parte_tienda = drd.HasColumn("parte_tienda") ? drd["parte_tienda"] == DBNull.Value ? null : drd["parte_tienda"].ToString() : null;
            //                // output.FLG_DESC_PREFIJO = drd.HasColumn("FLG_DESC_PREFIJO") ? drd["FLG_DESC_PREFIJO"] == DBNull.Value ? null : drd["FLG_DESC_PREFIJO"].ToString() : null;
            //                // output.RUTA_BACKUP = drd.HasColumn("RUTA_BACKUP") ? drd["RUTA_BACKUP"] == DBNull.Value ? null : drd["RUTA_BACKUP"].ToString() : null;
            //                // output.cierre_kardex = drd.HasColumn("cierre_kardex") ? drd["cierre_kardex"] == DBNull.Value ? null : drd["cierre_kardex"].ToString() : null;
            //                // output.valorcanje_regvta = drd.HasColumn("valorcanje_regvta") ? drd["valorcanje_regvta"] == DBNull.Value ? null : drd["valorcanje_regvta"].ToString() : null
            //                // output.triveno = drd.HasColumn("triveno") ? drd["triveno"] == DBNull.Value ? null : drd["triveno"].ToString() : null
            //                // output.activasawa = drd.HasColumn("activasawa") ? drd["activasawa"] == DBNull.Value ? null : drd["activasawa"].ToString() : null
            //                // output.desanular = drd.HasColumn("desanular") ? drd["desanular"] == DBNull.Value ? null : drd["desanular"].ToString() : null
            //                // output.activadispensador = drd.HasColumn("activadispensador") ? drd["activadispensador"] == DBNull.Value ? null : drd["activadispensador"].ToString() : null
            //                // output.cdDepart_base = drd.HasColumn("cdDepart_base") ? drd["cdDepart_base"] == DBNull.Value ? null : drd["cdDepart_base"].ToString() : null
            //                // output.cambioturno = drd.HasColumn("cambioturno") ? drd["cambioturno"] == DBNull.Value ? null : drd["cambioturno"].ToString() : null
            //                // output.iniciodia = drd.HasColumn("iniciodia") ? drd["iniciodia"] == DBNull.Value ? null : drd["iniciodia"].ToString() : null
            //                // output.factura_c = drd.HasColumn("factura_c") ? drd["factura_c"] == DBNull.Value ? null : drd["factura_c"].ToString() : null
            //                // output.facturaimpre_c = drd.HasColumn("facturaimpre_c") ? drd["facturaimpre_c"] == DBNull.Value ? null : drd["facturaimpre_c"].ToString() : null
            //                // output.facturafmt_c = drd.HasColumn("facturafmt_c") ? drd["facturafmt_c"] == DBNull.Value ? null : drd["facturafmt_c"].ToString() : null
            //                // output.pd_separaglp = drd.HasColumn("pd_separaglp") ? drd["pd_separaglp"] == DBNull.Value ? null : drd["pd_separaglp"].ToString() : null
            //                // output.flgvalida_nrovale = drd.HasColumn("flgvalida_nrovale") ? drd["flgvalida_nrovale"] == DBNull.Value ? null : drd["flgvalida_nrovale"].ToString() : null
            //                // output.arequipa = drd.HasColumn("arequipa") ? drd["arequipa"] == DBNull.Value ? null : drd["arequipa"].ToString() : null
            //                // output.BBDDSETUP = drd.HasColumn("BBDDSETUP") ? drd["BBDDSETUP"] == DBNull.Value ? null : drd["BBDDSETUP"].ToString() : null
            //                // output.GUIA = drd.HasColumn("GUIA") ? drd["GUIA"] == DBNull.Value ? null : drd["GUIA"].ToString() : null
            //                // output.GUIAIMPR = drd.HasColumn("GUIAIMPR") ? drd["GUIAIMPR"] == DBNull.Value ? null : drd["GUIAIMPR"].ToString() : null
            //                // output.GUIAFMT = drd.HasColumn("GUIAFMT") ? drd["GUIAFMT"] == DBNull.Value ? null : drd["GUIAFMT"].ToString() : null
            //                // output.punto_nd = drd.HasColumn("punto_nd") ? drd["punto_nd"] == DBNull.Value ? null : drd["punto_nd"].ToString() : null
            //                // output.noconectawpuntos = drd.HasColumn("noconectawpuntos") ? drd["noconectawpuntos"] == DBNull.Value ? null : drd["noconectawpuntos"].ToString() : null
            //                // output.diasresetptos = drd.HasColumn("diasresetptos") ? drd["diasresetptos"] == DBNull.Value ? null : drd["diasresetptos"].ToString() : null
            //                // output.cancelado = drd.HasColumn("cancelado") ? drd["cancelado"] == DBNull.Value ? null : drd["cancelado"].ToString() : null
            //                // output.correlativos2_ticket = drd.HasColumn("correlativos2_ticket") ? drd["correlativos2_ticket"] == DBNull.Value ? null : drd["correlativos2_ticket"].ToString() : null
            //                // output.chkclienteDia = drd.HasColumn("chkclienteDia") ? drd["chkclienteDia"] == DBNull.Value ? null : drd["chkclienteDia"].ToString() : null
            //                // output.escirsa = drd.HasColumn("escirsa") ? drd["escirsa"] == DBNull.Value ? null : drd["escirsa"].ToString() : null
            //                // output.FLGCIERRATURNOXCAJA = drd.HasColumn("FLGCIERRATURNOXCAJA") ? drd["FLGCIERRATURNOXCAJA"] == DBNull.Value ? null : drd["FLGCIERRATURNOXCAJA"].ToString() : null
            //                // output.flgruta = drd.HasColumn("flgruta") ? drd["flgruta"] == DBNull.Value ? null : drd["flgruta"].ToString() : null
            //                // output.GALONES_DECIMALES = drd.HasColumn("GALONES_DECIMALES") ? drd["GALONES_DECIMALES"] == DBNull.Value ? null : drd["GALONES_DECIMALES"].ToString() : null
            //                // output.flg_prefij_seriesdoc = drd.HasColumn("flg_prefij_seriesdoc") ? drd["flg_prefij_seriesdoc"] == DBNull.Value ? null : drd["flg_prefij_seriesdoc"].ToString() : null
            //                // output.Mostrar_Articulo_Kardex = drd.HasColumn("Mostrar_Articulo_Kardex") ? drd["Mostrar_Articulo_Kardex"] == DBNull.Value ? null : drd["Mostrar_Articulo_Kardex"].ToString() : null
            //                // output.tiendagazel = drd.HasColumn("tiendagazel") ? drd["tiendagazel"] == DBNull.Value ? null : drd["tiendagazel"].ToString() : null
            //                // output.tpsalmerma = drd.HasColumn("tpsalmerma") ? drd["tpsalmerma"] == DBNull.Value ? null : drd["tpsalmerma"].ToString() : null
            //                // output.tpsaldev = drd.HasColumn("tpsaldev") ? drd["tpsaldev"] == DBNull.Value ? null : drd["tpsaldev"].ToString() : null
            //                // output.Redondeo = drd.HasColumn("Redondeo") ? drd["Redondeo"] == DBNull.Value ? null : drd["Redondeo"].ToString() : null
            //                // output.terminalserver = drd.HasColumn("terminalserver") ? drd["terminalserver"] == DBNull.Value ? null : drd["terminalserver"].ToString() : null
            //                // output.flg_invent_fisicoteorico = drd.HasColumn("flg_invent_fisicoteorico") ? drd["flg_invent_fisicoteorico"] == DBNull.Value ? null : drd["flg_invent_fisicoteorico"].ToString() : null
            //                // output.flg_botoncredito = drd.HasColumn("flg_botoncredito") ? drd["flg_botoncredito"] == DBNull.Value ? null : drd["flg_botoncredito"].ToString() : null
            //                // output.flg_nobuscar_nombre = drd.HasColumn("flg_nobuscar_nombre") ? drd["flg_nobuscar_nombre"] == DBNull.Value ? null : drd["flg_nobuscar_nombre"].ToString() : null
            //                // output.consulta_sunat = drd.HasColumn("consulta_sunat") ? drd["consulta_sunat"] == DBNull.Value ? null : drd["consulta_sunat"].ToString() : null
            //                // output.clubgazel = drd.HasColumn("clubgazel") ? drd["clubgazel"] == DBNull.Value ? null : drd["clubgazel"].ToString() : null
            //                // output.ruta_webclubgazel = drd.HasColumn("ruta_webclubgazel") ? drd["ruta_webclubgazel"] == DBNull.Value ? null : drd["ruta_webclubgazel"].ToString() : null
            //                // output.activa_camedi = drd.HasColumn("activa_camedi") ? drd["activa_camedi"] == DBNull.Value ? null : drd["activa_camedi"].ToString() : null
            //                // output.tarjeta_mascara = drd.HasColumn("tarjeta_mascara") ? drd["tarjeta_mascara"] == DBNull.Value ? null : drd["tarjeta_mascara"].ToString() : null
            //                // output.tipo_canje = drd.HasColumn("tipo_canje") ? drd["tipo_canje"] == DBNull.Value ? null : drd["tipo_canje"].ToString() : null
            //                // output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null
            //                // output.ruta_ws_easytaxy = drd.HasColumn("ruta_ws_easytaxy") ? drd["ruta_ws_easytaxy"] == DBNull.Value ? null : drd["ruta_ws_easytaxy"].ToString() : null
            //                // output.activa_elsol = drd.HasColumn("activa_elsol") ? drd["activa_elsol"] == DBNull.Value ? null : drd["activa_elsol"].ToString() : null
            //                // output.cod_viatico = drd.HasColumn("cod_viatico") ? drd["cod_viatico"] == DBNull.Value ? null : drd["cod_viatico"].ToString() : null
            //                // output.flg_boton_facturacionmanual = drd.HasColumn("flg_boton_facturacionmanual") ? drd["flg_boton_facturacionmanual"] == DBNull.Value ? null : drd["Redondeo"].ToString() : null
            //                // output.mostrar_ptos_ganados = drd.HasColumn("mostrar_ptos_ganados") ? drd["mostrar_ptos_ganados"] == DBNull.Value ? null : drd["mostrar_ptos_ganados"].ToString() : null
            //                // output.activa_formas_pago = drd.HasColumn("activa_formas_pago") ? drd["activa_formas_pago"] == DBNull.Value ? null : drd["activa_formas_pago"].ToString() : null
            //                // output.mtominimodni_sunat = drd.HasColumn("mtominimodni_sunat") ? drd["mtominimodni_sunat"] == DBNull.Value ? null : drd["mtominimodni_sunat"].ToString() : null
            //                // output.flg_pideplaca = drd.HasColumn("flg_pideplaca") ? drd["flg_pideplaca"] == DBNull.Value ? null : drd["flg_pideplaca"].ToString() : null
            //                // output.depositos_playa = drd.HasColumn("depositos_playa") ? drd["depositos_playa"] == DBNull.Value ? null : drd["depositos_playa"].ToString() : null
            //                // output.mtominideposito = drd.HasColumn("mtominideposito") ? drd["mtominideposito"] == DBNull.Value ? null : drd["mtominideposito"].ToString() : null
            //                // output.ConIGV = drd.HasColumn("ConIGV") ? drd["ConIGV"] == DBNull.Value ? null : drd["ConIGV"].ToString() : null
            //                // output.flg_pideplacatb = drd.HasColumn("flg_pideplacatb") ? drd["flg_pideplacatb"] == DBNull.Value ? null : drd["flg_pideplacatb"].ToString() : null
            //                // output.horacierrepd = drd.HasColumn("horacierrepd") ? drd["horacierrepd"] == DBNull.Value ? null : drd["horacierrepd"].ToString() : null
            //                // output.activa_repro_stock = drd.HasColumn("activa_repro_stock") ? drd["activa_repro_stock"] == DBNull.Value ? null : drd["activa_repro_stock"].ToString() : null
            //                // output.flg_valfecpos = drd.HasColumn("flg_valfecpos") ? drd["flg_valfecpos"] == DBNull.Value ? null : drd["flg_valfecpos"].ToString() : null
            //                // output.rango_valfecpos = drd.HasColumn("rango_valfecpos") ? drd["rango_valfecpos"] == DBNull.Value ? null : drd["rango_valfecpos"].ToString() : null
            //                // output.flg_anulapos = drd.HasColumn("flg_anulapos") ? drd["flg_anulapos"] == DBNull.Value ? null : drd["flg_anulapos"].ToString() : null
            //                // output.flg_nc_liberand = drd.HasColumn("flg_nc_liberand") ? drd["flg_nc_liberand"] == DBNull.Value ? null : drd["flg_nc_liberand"].ToString() : null
            //                // output.flg_transfer_gratuita_cero = drd.HasColumn("flg_transfer_gratuita_cero") ? drd["flg_transfer_gratuita_cero"] == DBNull.Value ? null : drd["flg_transfer_gratuita_cero"].ToString() : null
            //                // output.interfaz = drd.HasColumn("interfaz") ? drd["interfaz"] == DBNull.Value ? null : drd["interfaz"].ToString() : null
            //                // output.Redoflg_fecsrvndeo = drd.HasColumn("flg_fecsrv") ? drd["flg_fecsrv"] == DBNull.Value ? null : drd["flg_fecsrv"].ToString() : null
            //                // output.prefflotlocal = drd.HasColumn("prefflotlocal") ? drd["prefflotlocal"] == DBNull.Value ? null : drd["prefflotlocal"].ToString() : null
            //                // output.flg_pideodometro = drd.HasColumn("flg_pideodometro") ? flg_pideodometrodrd["flg_pideodometro"] == DBNull.Value ? null : drd["flg_pideodometro"].ToString() 
            //                // output.fe_fecValida = drd.HasColumn("fe_fecValida") ? drd["fe_fecValida"] == DBNull.Value ? null : drd["fe_fecValida"].ToString() : null
            //                // output.flg_valdscto = drd.HasColumn("flg_valdscto") ? drd["flg_valdscto"] == DBNull.Value ? null : drd["flg_valdscto"].ToString() : null
            //                // output.tppgogasto = drd.HasColumn("tppgogasto") ? drd["tppgogasto"] == DBNull.Value ? null : drd["tppgogasto"].ToString() : null
            //                // output.flg_pideclavecred = drd.HasColumn("flg_pideclavecred") ? drd["flg_pideclavecred"] == DBNull.Value ? null : drd["flg_pideclavecred"].ToString() : null
            //                // output.flg_modo_fact = drd.HasColumn("flg_modo_fact") ? drd["flg_modo_fact"] == DBNull.Value ? null : drd["flg_modo_fact"].ToString() : null
            //                // output.colum_termica = drd.HasColumn("colum_termica") ? drd["colum_termica"] == DBNull.Value ? null : drd["colum_termica"].ToString() : null
            //                // output.Label_Bellavista = drd.HasColumn("Label_Bellavista") ? drd["Label_Bellavista"] == DBNull.Value ? null : drd["Label_Bellavista"].ToString() : null
            //                // output.mtominimodetraccion = drd.HasColumn("mtominimodetraccion") ? drd["mtominimodetraccion"] == DBNull.Value ? null : drd["mtominimodetraccion"].ToString() : null
            //                // output.Nd_imp_saldoyconsumo = drd.HasColumn("Nd_imp_saldoyconsumo") ? drd["Nd_imp_saldoyconsumo"] == DBNull.Value ? null : drd["Nd_imp_saldoyconsumo"].ToString() : null
            //                // output.nro_caracteres_rsocial = drd.HasColumn("nro_caracteres_rsocial") ? drd["nro_caracteres_rsocial"] == DBNull.Value ? null : drd["nro_caracteres_rsocial"].ToString() : null
            //                // output.valida_fecha_playa = drd.HasColumn("valida_fecha_playa") ? drd["valida_fecha_playa"] == DBNull.Value ? null : drd["valida_fecha_playa"].ToString() : null
            //                // output.flg_valida_fecproce_dia = drd.HasColumn("flg_valida_fecproce_dia") ? drd["flg_valida_fecproce_dia"] == DBNull.Value ? null : drd["flg_valida_fecproce_dia"].ToString() : null
            //                // output.impr_Veces_ND = drd.HasColumn("impr_Veces_ND") ? drd["impr_Veces_ND"] == DBNull.Value ? null : drd["impr_Veces_ND"].ToString() : null
            //                // output.impr_Veces_fac = drd.HasColumn("impr_Veces_fac") ? drd["impr_Veces_fac"] == DBNull.Value ? null : drd["impr_Veces_fac"].ToString() : null
            //                // output.impr_Veces_bol = drd.HasColumn("impr_Veces_bol") ? drd["impr_Veces_bol"] == DBNull.Value ? null : drd["impr_Veces_bol"].ToString() : null
            //                // output.flg_canjend = drd.HasColumn("flg_canjend") ? drd["flg_canjend"] == DBNull.Value ? null : drd["flg_canjend"].ToString() : null
            //                // output.nroversionBO = drd.HasColumn("nroversionBO") ? drd["nroversionBO"] == DBNull.Value ? null : drd["nroversionBO"].ToString() : null
            //                // output.nroversionplaya = drd.HasColumn("nroversionplaya") ? drd["nroversionplaya"] == DBNull.Value ? null : drd["nroversionplaya"].ToString() : null
            //                // output.nroversiontienda = drd.HasColumn("nroversiontienda") ? drd["nroversiontienda"] == DBNull.Value ? null : drd["nroversiontienda"].ToString() : null
            //                // output.nroversionTI = drd.HasColumn("nroversionTI") ? drd["nroversionTI"] == DBNull.Value ? null : drd["nroversionTI"].ToString() : null
            //                // output.flg_nrodias = drd.HasColumn("flg_nrodias") ? drd["flg_nrodias"] == DBNull.Value ? null : drd["flg_nrodias"].ToString() : null
            //                // output.flg_credito_centralizado = drd.HasColumn("flg_credito_centralizado") ? drd["flg_credito_centralizado"] == DBNull.Value ? null : drd["flg_credito_centralizado"].ToString() : null
            //                // output.flgsoloterminal = drd.HasColumn("flgsoloterminal") ? drd["flgsoloterminal"] == DBNull.Value ? null : drd["flgsoloterminal"].ToString() : null
            //                // output.flg_round_dec_indecopi = drd.HasColumn("flg_round_dec_indecopi") ? drd["flg_round_dec_indecopi"] == DBNull.Value ? null : drd["flg_round_dec_indecopi"].ToString() : null
            //                // output.flg_round_indecopi_1_9 = drd.HasColumn("flg_round_indecopi_1_9") ? drd["flg_round_indecopi_1_9"] == DBNull.Value ? null : drd["flg_round_indecopi_1_9"].ToString() : null
            //                // output.CONEXIONWEB = drd.HasColumn("CONEXIONWEB") ? drd["CONEXIONWEB"] == DBNull.Value ? null : drd["CONEXIONWEB"].ToString() : null
            //                // output.INSTANCIAWEB = drd.HasColumn("INSTANCIAWEB") ? drd["INSTANCIAWEB"] == DBNull.Value ? null : drd["INSTANCIAWEB"].ToString() : null
            //                // output.BDWEB = drd.HasColumn("BDWEB") ? drd["BDWEB"] == DBNull.Value ? null : drd["BDWEB"].ToString() : null
            //                // output.USERWEB = drd.HasColumn("USERWEB") ? drd["USERWEB"] == DBNull.Value ? null : drd["USERWEB"].ToString() : null
            //                // output.PASSWORDWEB = drd.HasColumn("PASSWORDWEB") ? drd["PASSWORDWEB"] == DBNull.Value ? null : drd["PASSWORDWEB"].ToString() : null
            //                // output.ruta_qr_jpg = drd.HasColumn("ruta_qr_jpg") ? drd["ruta_qr_jpg"] == DBNull.Value ? null : drd["ruta_qr_jpg"].ToString() : null
            //                // output.Mto_desc_Descripcion = drd.HasColumn("Mto_desc_Descripcion") ? drd["Mto_desc_Descripcion"] == DBNull.Value ? null : drd["Mto_desc_Descripcion"].ToString() : null
            //                // output.flg_kardex_unalinea = drd.HasColumn("flg_kardex_unalinea") ? drd["flg_kardex_unalinea"] == DBNull.Value ? null : drd["flg_kardex_unalinea"].ToString() : null
            //                // output.nroinventario = drd.HasColumn("nroinventario") ? drd["nroinventario"] == DBNull.Value ? null : drd["nroinventario"].ToString() : null
            //                // output.flg_invent_2 = drd.HasColumn("flg_invent_2") ? drd["flg_invent_2"] == DBNull.Value ? null : drd["flg_invent_2"].ToString() : null
            //                // output.flg_facturacion_automatica = drd.HasColumn("flg_facturacion_automatica") ? drd["flg_facturacion_automatica"] == DBNull.Value ? null : drd["flg_facturacion_automatica"].ToString() : null
            //                // output.mto_facturacion_automatica = drd.HasColumn("mto_facturacion_automatica") ? drd["mto_facturacion_automatica"] == DBNull.Value ? null : drd["mto_facturacion_automatica"].ToString() : null
            //                // output.flg_btn_credito_playa = drd.HasColumn("flg_btn_credito_playa") ? drd["flg_btn_credito_playa"] == DBNull.Value ? null : drd["flg_btn_credito_playa"].ToString() : null
            //                // output.flg_validateclas_cdcliente = drd.HasColumn("flg_validateclas_cdcliente") ? drd["flg_validateclas_cdcliente"] == DBNull.Value ? null : drd["flg_validateclas_cdcliente"].ToString() : null
            //                // output.flg_activa_TI_todosProd = drd.HasColumn("flg_activa_TI_todosProd") ? drd["flg_activa_TI_todosProd"] == DBNull.Value ? null : drd["flg_activa_TI_todosProd"].ToString() : null
            //                // output.flg_boton_promo = drd.HasColumn("flg_boton_promo") ? drd["flg_boton_promo"] == DBNull.Value ? null : drd["flg_boton_promo"].ToString() : null
            //                // output.flg_gastos_playa = drd.HasColumn("flg_gastos_playa") ? drd["flg_gastos_playa"] == DBNull.Value ? null : drd["flg_gastos_playa"].ToString() : null
            //                // output.flg_ocultar_campos_tck = drd.HasColumn("flg_ocultar_campos_tck") ? drd["flg_ocultar_campos_tck"] == DBNull.Value ? null : drd["flg_ocultar_campos_tck"].ToString() : null
            //                // output.flg_print_qr = drd.HasColumn("flg_print_qr") ? drd["flg_print_qr"] == DBNull.Value ? null : drd["flg_print_qr"].ToString() : null
            //                // output.flg_repx_terminal = drd.HasColumn("flg_repx_terminal") ? drd["flg_repx_terminal"] == DBNull.Value ? null : drd["flg_repx_terminal"].ToString() : null
            //                // output.flg_cliente_automatico = drd.HasColumn("flg_cliente_automatico") ? drd["flg_cliente_automatico"] == DBNull.Value ? null : drd["flg_cliente_automatico"].ToString() : null
            //                // output.cdcliente_automatico = drd.HasColumn("cdcliente_automatico") ? drd["cdcliente_automatico"] == DBNull.Value ? null : drd["cdcliente_automatico"].ToString() : null
            //                // output.rscliente_automatico = drd.HasColumn("rscliente_automatico") ? drd["rscliente_automatico"] == DBNull.Value ? null : drd["rscliente_automatico"].ToString() : null
            //                // output.Desactivar_FoxyPreviewer = drd.HasColumn("Desactivar_FoxyPreviewer") ? drd["Desactivar_FoxyPreviewer"] == DBNull.Value ? null : drd["Desactivar_FoxyPreviewer"].ToString() : null
            //                // output.flg_notas_multiref = drd.HasColumn("flg_notas_multiref") ? drd["flg_notas_multiref"] == DBNull.Value ? null : drd["flg_notas_multiref"].ToString() : null
            //                // output.flg_AfectarCosto_FleteCompras = drd.HasColumn("flg_AfectarCosto_FleteCompras") ? drd["flg_AfectarCosto_FleteCompras"] == DBNull.Value ? null : drd["flg_AfectarCosto_FleteCompras"].ToString() : null
            //                // output.Msg_Anula_Documento = drd.HasColumn("Msg_Anula_Documento") ? drd["Msg_Anula_Documento"] == DBNull.Value ? null : drd["Msg_Anula_Documento"].ToString() : null
            //                // output.flg_ImprimirND_Menos5S = drd.HasColumn("flg_ImprimirND_Menos5S") ? drd["flg_ImprimirND_Menos5S"] == DBNull.Value ? null : drd["flg_ImprimirND_Menos5S"].ToString() : null
            //                // output.flg_OcultarVta_Menos5S = drd.HasColumn("flg_OcultarVta_Menos5S") ? drd["flg_OcultarVta_Menos5S"] == DBNull.Value ? null : drd["flg_OcultarVta_Menos5S"].ToString() : null
            //                // output.flg_noaplica_desc_tarj = drd.HasColumn("flg_noaplica_desc_tarj") ? drd["flg_noaplica_desc_tarj"] == DBNull.Value ? null : drd["flg_noaplica_desc_tarj"].ToString() : null
            //                // output.flg_activar_clientes_varios = drd.HasColumn("flg_activar_clientes_varios") ? drd["flg_activar_clientes_varios"] == DBNull.Value ? null : drd["flg_activar_clientes_varios"].ToString() : null








            //            }
            //        }
            //        cmd.Dispose();

            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception(ex.Message);
            //    }
            //    finally
            //    {
            //        if (con != null)
            //        {
            //            con.Dispose();
            //        }

            //    }
            //}

            return output;
        }
    }
}
