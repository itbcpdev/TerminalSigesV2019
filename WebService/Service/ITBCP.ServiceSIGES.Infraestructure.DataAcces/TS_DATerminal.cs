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
   public class TS_DATerminal: ITS_DOTerminal
    {
        readonly string stringConnectionSetup = ConfigurationManager.ConnectionStrings["ConnectionSetup"].ConnectionString;
        readonly string stringBackOffice = ConfigurationManager.ConnectionStrings["ConnectionBackOffice"].ConnectionString;

        public List<TS_BETerminal> LISTAR_TERMINALES(TS_BETerminal input)
        {
            List<TS_BETerminal> lista = new List<TS_BETerminal>();
            TS_BETerminal output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_TERMINALES", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BETerminal();
                            output.conexion_dispensador = drd.HasColumn("conexion_dispensador") ? drd["conexion_dispensador"] == DBNull.Value ? (byte?) 1 : Convert.ToByte(drd["conexion_dispensador"]) : (byte?) 1;
                            output.fe_idpos = drd.HasColumn("fe_idpos") ? drd["fe_idpos"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["fe_idpos"]) : (int?)null;
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.tktfactura = drd.HasColumn("tktfactura") ? drd["tktfactura"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktfactura"]) : false;
                            output.tktboleta = drd.HasColumn("tktboleta") ? drd["tktboleta"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktboleta"]) : false;
                            output.tktpromocion = drd.HasColumn("tktpromocion") ? drd["tktpromocion"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktpromocion"]) : false;
                            output.facturapreimpre = drd.HasColumn("facturapreimpre") ? drd["facturapreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["facturapreimpre"]) : false;
                            output.boletapreimpre = drd.HasColumn("boletapreimpre") ? drd["boletapreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["boletapreimpre"]) : false;
                            output.promocionpreimpre = drd.HasColumn("promocionpreimpre") ? drd["promocionpreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["promocionpreimpre"]) : false;
                            output.activa_boton_playa = drd.HasColumn("activa_boton_playa") ? drd["activa_boton_playa"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_boton_playa"]) : false;
                            output.flg_pdf417 = drd.HasColumn("flg_pdf417") ? drd["flg_pdf417"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pdf417"]) : false;
                            output.flg_nc_correlativo = drd.HasColumn("flg_nc_correlativo") ? drd["flg_nc_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nc_correlativo"]) : false;
                            output.flg_nd_correlativo = drd.HasColumn("flg_nd_correlativo") ? drd["flg_nd_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nd_correlativo"]) : false;
                            output.flg_print_qr = drd.HasColumn("flg_print_qr") ? drd["flg_print_qr"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_print_qr"]) : false;
                            output.flg_formato_a4 = drd.HasColumn("flg_formato_a4") ? drd["flg_formato_a4"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_formato_a4"]) : false;
                            output.rucinvalido = drd.HasColumn("rucinvalido") ? drd["rucinvalido"] == DBNull.Value ? false : Convert.ToBoolean(drd["rucinvalido"]) : false;
                            output._virtual = drd.HasColumn("virtual") ? drd["virtual"] == DBNull.Value ? false : Convert.ToBoolean(drd["virtual"]) : false;
                            output.tktnotadespacho = drd.HasColumn("tktnotadespacho") ? drd["tktnotadespacho"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktnotadespacho"]) : false;
                            output.flgtransferencia = drd.HasColumn("flgtransferencia") ? drd["flgtransferencia"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgtransferencia"]) : false;
                            output.playa_formasdepago = drd.HasColumn("playa_formasdepago") ? drd["playa_formasdepago"] == DBNull.Value ? false : Convert.ToBoolean(drd["playa_formasdepago"]) : false;
                            output.modif_corr = drd.HasColumn("modif_corr") ? drd["modif_corr"] == DBNull.Value ? false : Convert.ToBoolean(drd["modif_corr"]) : false;
                            output.flgpagotarjeta = drd.HasColumn("flgpagotarjeta") ? drd["flgpagotarjeta"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagotarjeta"]) : false;
                            output.flgpagocheque = drd.HasColumn("flgpagocheque") ? drd["flgpagocheque"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagocheque"]) : false;
                            output.flgpagocredito = drd.HasColumn("flgpagocredito") ? drd["flgpagocredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagocredito"]) : false;
                            output.flgpagoncredito = drd.HasColumn("flgpagoncredito") ? drd["flgpagoncredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagoncredito"]) : false;
                            output.flgvalidaz = drd.HasColumn("flgvalidaz") ? drd["flgvalidaz"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgvalidaz"]) : false;
                            output.flgcierrezok = drd.HasColumn("flgcierrezok") ? drd["flgcierrezok"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrezok"]) : false;
                            output.flghotkey = drd.HasColumn("flghotkey") ? drd["flghotkey"] == DBNull.Value ? false : Convert.ToBoolean(drd["flghotkey"]) : false;
                            output.flgfacturacion = drd.HasColumn("flgfacturacion") ? drd["flgfacturacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgfacturacion"]) : false;
                            output.grabarcliente = drd.HasColumn("grabarcliente") ? drd["grabarcliente"] == DBNull.Value ? false : Convert.ToBoolean(drd["grabarcliente"]) : false;
                            output.flgautomatica = drd.HasColumn("flgautomatica") ? drd["flgautomatica"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgautomatica"]) : false;
                            output.flgaperturacaja = drd.HasColumn("flgaperturacaja") ? drd["flgaperturacaja"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgaperturacaja"]) : false;
                            output.flgpagoefectivo = drd.HasColumn("flgpagoefectivo") ? drd["flgpagoefectivo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagoefectivo"]) : false;
                            output.modocompra = drd.HasColumn("modocompra") ? drd["modocompra"] == DBNull.Value ? false : Convert.ToBoolean(drd["modocompra"]) : false;
                            output.modservicio = drd.HasColumn("modservicio") ? drd["modservicio"] == DBNull.Value ? false : Convert.ToBoolean(drd["modservicio"]) : false;
                            output.modobservacion = drd.HasColumn("modobservacion") ? drd["modobservacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["modobservacion"]) : false;
                            output.moddsctogral = drd.HasColumn("moddsctogral") ? drd["moddsctogral"] == DBNull.Value ? false : Convert.ToBoolean(drd["moddsctogral"]) : false;
                            output.moddsctoitem = drd.HasColumn("moddsctoitem") ? drd["moddsctoitem"] == DBNull.Value ? false : Convert.ToBoolean(drd["moddsctoitem"]) : false;
                            output.preciocero = drd.HasColumn("preciocero") ? drd["preciocero"] == DBNull.Value ? false : Convert.ToBoolean(drd["preciocero"]) : false;
                            output.modfecha = drd.HasColumn("modfecha") ? drd["modfecha"] == DBNull.Value ? false : Convert.ToBoolean(drd["modfecha"]) : false;
                            output.modmoneda = drd.HasColumn("modmoneda") ? drd["modmoneda"] == DBNull.Value ? false : Convert.ToBoolean(drd["modmoneda"]) : false;
                            output.modvendedor = drd.HasColumn("modvendedor") ? drd["modvendedor"] == DBNull.Value ? false : Convert.ToBoolean(drd["modvendedor"]) : false;
                            output.modalmacen = drd.HasColumn("modalmacen") ? drd["modalmacen"] == DBNull.Value ? false : Convert.ToBoolean(drd["modalmacen"]) : false;
                            output.modlistap = drd.HasColumn("modlistap") ? drd["modlistap"] == DBNull.Value ? false : Convert.ToBoolean(drd["modlistap"]) : false;
                            output.modprecio = drd.HasColumn("modprecio") ? drd["modprecio"] == DBNull.Value ? false : Convert.ToBoolean(drd["modprecio"]) : false;
                            output.nrozeta = drd.HasColumn("nrozeta") ? drd["nrozeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrozeta"]) : (decimal?)null;
                            output.mtozeta = drd.HasColumn("mtozeta") ? drd["mtozeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtozeta"]) : (decimal?)null;
                            output.ticketfeed = drd.HasColumn("ticketfeed") ? drd["ticketfeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticketfeed"]) : (decimal?)null;
                            output.ticketlineacorte = drd.HasColumn("ticketlineacorte") ? drd["ticketlineacorte"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticketlineacorte"]) : (decimal?)null;
                            output.ticket2columnas = drd.HasColumn("ticket2columnas") ? drd["ticket2columnas"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticket2columnas"]) : (decimal?)null;
                            output.nventafeed = drd.HasColumn("nventafeed") ? drd["nventafeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nventafeed"]) : (decimal?)null;
                            output.promocionfeed = drd.HasColumn("promocionfeed") ? drd["promocionfeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["promocionfeed"]) : (decimal?)null;
                            output.mtodsctomax = drd.HasColumn("mtodsctomax") ? drd["mtodsctomax"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodsctomax"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.tranvirtual = drd.HasColumn("tranvirtual") ? drd["tranvirtual"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["tranvirtual"]) : (decimal?)null;
                            output.nrodeposito = drd.HasColumn("nrodeposito") ? drd["nrodeposito"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrodeposito"]) : (decimal?)null;
                            output.facturaimpre = drd.HasColumn("facturaimpre") ? drd["facturaimpre"] == DBNull.Value ? null : drd["facturaimpre"].ToString() : null;
                            output.boletaimpre = drd.HasColumn("boletaimpre") ? drd["boletaimpre"] == DBNull.Value ? null : drd["boletaimpre"].ToString() : null;
                            output.gavetachr = drd.HasColumn("gavetachr") ? drd["gavetachr"] == DBNull.Value ? null : drd["gavetachr"].ToString() : null;
                            output.promocionimpre = drd.HasColumn("promocionimpre") ? drd["promocionimpre"] == DBNull.Value ? null : drd["promocionimpre"].ToString() : null;
                            output.ncreditoimpre = drd.HasColumn("ncreditoimpre") ? drd["ncreditoimpre"] == DBNull.Value ? null : drd["ncreditoimpre"].ToString() : null;
                            output.ndebitoimpre = drd.HasColumn("ndebitoimpre") ? drd["ndebitoimpre"] == DBNull.Value ? null : drd["ndebitoimpre"].ToString() : null;
                            output.guiaimpre = drd.HasColumn("guiaimpre") ? drd["guiaimpre"] == DBNull.Value ? null : drd["guiaimpre"].ToString() : null;
                            output.proformaimpre = drd.HasColumn("proformaimpre") ? drd["proformaimpre"] == DBNull.Value ? null : drd["proformaimpre"].ToString() : null;
                            output.letraimpre = drd.HasColumn("letraimpre") ? drd["letraimpre"] == DBNull.Value ? null : drd["letraimpre"].ToString() : null;
                            output.path_loteria = drd.HasColumn("path_loteria") ? drd["path_loteria"] == DBNull.Value ? null : drd["path_loteria"].ToString() : null;
                            output.fe_nompos = drd.HasColumn("fe_nompos") ? drd["fe_nompos"] == DBNull.Value ? null : drd["fe_nompos"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdusuario = drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString() : null;
                            output.seriehd = drd.HasColumn("seriehd") ? drd["seriehd"] == DBNull.Value ? null : drd["seriehd"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.nroserie1 = drd.HasColumn("nroserie1") ? drd["nroserie1"] == DBNull.Value ? null : drd["nroserie1"].ToString() : null;
                            output.nroserie2 = drd.HasColumn("nroserie2") ? drd["nroserie2"] == DBNull.Value ? null : drd["nroserie2"].ToString() : null;
                            output.tipoterminal = drd.HasColumn("tipoterminal") ? drd["tipoterminal"] == DBNull.Value ? null : drd["tipoterminal"].ToString() : null;
                            output.ticketfactura = drd.HasColumn("ticketfactura") ? drd["ticketfactura"] == DBNull.Value ? null : drd["ticketfactura"].ToString() : null;
                            output.ncreditoboleta = drd.HasColumn("ncreditoboleta") ? drd["ncreditoboleta"] == DBNull.Value ? null : drd["ncreditoboleta"].ToString() : null;
                            output.ndebitoboleta = drd.HasColumn("ndebitoboleta") ? drd["ndebitoboleta"] == DBNull.Value ? null : drd["ndebitoboleta"].ToString() : null;
                            output.guiafmt = drd.HasColumn("guiafmt") ? drd["guiafmt"] == DBNull.Value ? null : drd["guiafmt"].ToString() : null;
                            output.proforma = drd.HasColumn("proforma") ? drd["proforma"] == DBNull.Value ? null : drd["proforma"].ToString() : null;
                            output.proformafmt = drd.HasColumn("proformafmt") ? drd["proformafmt"] == DBNull.Value ? null : drd["proformafmt"].ToString() : null;
                            output.letra = drd.HasColumn("letra") ? drd["letra"] == DBNull.Value ? null : drd["letra"].ToString() : null;
                            output.letrafmt = drd.HasColumn("letrafmt") ? drd["letrafmt"] == DBNull.Value ? null : drd["letrafmt"].ToString() : null;
                            output.displayimpre = drd.HasColumn("displayimpre") ? drd["displayimpre"] == DBNull.Value ? null : drd["displayimpre"].ToString() : null;
                            output.promocionchrfin = drd.HasColumn("promocionchrfin") ? drd["promocionchrfin"] == DBNull.Value ? null : drd["promocionchrfin"].ToString() : null;
                            output.ncredito = drd.HasColumn("ncredito") ? drd["ncredito"] == DBNull.Value ? null : drd["ncredito"].ToString() : null;
                            output.ncreditofmt = drd.HasColumn("ncreditofmt") ? drd["ncreditofmt"] == DBNull.Value ? null : drd["ncreditofmt"].ToString() : null;
                            output.ndebito = drd.HasColumn("ndebito") ? drd["ndebito"] == DBNull.Value ? null : drd["ndebito"].ToString() : null;
                            output.ndebitofmt = drd.HasColumn("ndebitofmt") ? drd["ndebitofmt"] == DBNull.Value ? null : drd["ndebitofmt"].ToString() : null;
                            output.guia = drd.HasColumn("guia") ? drd["guia"] == DBNull.Value ? null : drd["guia"].ToString() : null;
                            output.nventaimpre = drd.HasColumn("nventaimpre") ? drd["nventaimpre"] == DBNull.Value ? null : drd["nventaimpre"].ToString() : null;
                            output.nventachrini = drd.HasColumn("nventachrini") ? drd["nventachrini"] == DBNull.Value ? null : drd["nventachrini"].ToString() : null;
                            output.nventachrfin = drd.HasColumn("nventachrfin") ? drd["nventachrfin"] == DBNull.Value ? null : drd["nventachrfin"].ToString() : null;
                            output.promocion = drd.HasColumn("promocion") ? drd["promocion"] == DBNull.Value ? null : drd["promocion"].ToString() : null;
                            output.promocionfmt = drd.HasColumn("promocionfmt") ? drd["promocionfmt"] == DBNull.Value ? null : drd["promocionfmt"].ToString() : null;
                            output.promocionchrini = drd.HasColumn("promocionchrini") ? drd["promocionchrini"] == DBNull.Value ? null : drd["promocionchrini"].ToString() : null;
                            output.gavetaimpre = drd.HasColumn("gavetaimpre") ? drd["gavetaimpre"] == DBNull.Value ? null : drd["gavetaimpre"].ToString() : null;
                            output.ticket = drd.HasColumn("ticket") ? drd["ticket"] == DBNull.Value ? null : drd["ticket"].ToString() : null;
                            output.ticketimpre = drd.HasColumn("ticketimpre") ? drd["ticketimpre"] == DBNull.Value ? null : drd["ticketimpre"].ToString() : null;
                            output.ticketchrini = drd.HasColumn("ticketchrini") ? drd["ticketchrini"] == DBNull.Value ? null : drd["ticketchrini"].ToString() : null;
                            output.ticketchrfin = drd.HasColumn("ticketchrfin") ? drd["ticketchrfin"] == DBNull.Value ? null : drd["ticketchrfin"].ToString() : null;
                            output.nventa = drd.HasColumn("nventa") ? drd["nventa"] == DBNull.Value ? null : drd["nventa"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.factura = drd.HasColumn("factura") ? drd["factura"] == DBNull.Value ? null : drd["factura"].ToString() : null;
                            output.facturafmt = drd.HasColumn("facturafmt") ? drd["facturafmt"] == DBNull.Value ? null : drd["facturafmt"].ToString() : null;
                            output.boleta = drd.HasColumn("boleta") ? drd["boleta"] == DBNull.Value ? null : drd["boleta"].ToString() : null;
                            output.boletafmt = drd.HasColumn("boletafmt") ? drd["boletafmt"] == DBNull.Value ? null : drd["boletafmt"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }
        public TS_BETerminal OBTENER_TERMINAL_POR_SERIEHD(TS_BETerminal input)
        {
            TS_BETerminal output = new TS_BETerminal();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@seriehd", SqlDbType.Char, 10).Value = input.seriehd;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output.conexion_dispensador = drd.HasColumn("conexion_dispensador") ? drd["conexion_dispensador"] == DBNull.Value ? (byte?) 1 : Convert.ToByte(drd["conexion_dispensador"]) : (byte?) 1;
                            output.fe_idpos = drd.HasColumn("fe_idpos") ? drd["fe_idpos"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["fe_idpos"]) : (int?)null;
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.tktfactura = drd.HasColumn("tktfactura") ? drd["tktfactura"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktfactura"]) : false;
                            output.tktboleta = drd.HasColumn("tktboleta") ? drd["tktboleta"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktboleta"]) : false;
                            output.tktpromocion = drd.HasColumn("tktpromocion") ? drd["tktpromocion"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktpromocion"]) : false;
                            output.facturapreimpre = drd.HasColumn("facturapreimpre") ? drd["facturapreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["facturapreimpre"]) : false;
                            output.boletapreimpre = drd.HasColumn("boletapreimpre") ? drd["boletapreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["boletapreimpre"]) : false;
                            output.promocionpreimpre = drd.HasColumn("promocionpreimpre") ? drd["promocionpreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["promocionpreimpre"]) : false;
                            output.activa_boton_playa = drd.HasColumn("activa_boton_playa") ? drd["activa_boton_playa"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_boton_playa"]) : false;
                            output.flg_pdf417 = drd.HasColumn("flg_pdf417") ? drd["flg_pdf417"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pdf417"]) : false;
                            output.flg_nc_correlativo = drd.HasColumn("flg_nc_correlativo") ? drd["flg_nc_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nc_correlativo"]) : false;
                            output.flg_nd_correlativo = drd.HasColumn("flg_nd_correlativo") ? drd["flg_nd_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nd_correlativo"]) : false;
                            output.flg_print_qr = drd.HasColumn("flg_print_qr") ? drd["flg_print_qr"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_print_qr"]) : false;
                            output.flg_formato_a4 = drd.HasColumn("flg_formato_a4") ? drd["flg_formato_a4"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_formato_a4"]) : false;
                            output.rucinvalido = drd.HasColumn("rucinvalido") ? drd["rucinvalido"] == DBNull.Value ? false : Convert.ToBoolean(drd["rucinvalido"]) : false;
                            output._virtual = drd.HasColumn("virtual") ? drd["virtual"] == DBNull.Value ? false : Convert.ToBoolean(drd["virtual"]) : false;
                            output.tktnotadespacho = drd.HasColumn("tktnotadespacho") ? drd["tktnotadespacho"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktnotadespacho"]) : false;
                            output.flgtransferencia = drd.HasColumn("flgtransferencia") ? drd["flgtransferencia"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgtransferencia"]) : false;
                            output.playa_formasdepago = drd.HasColumn("playa_formasdepago") ? drd["playa_formasdepago"] == DBNull.Value ? false : Convert.ToBoolean(drd["playa_formasdepago"]) : false;
                            output.modif_corr = drd.HasColumn("modif_corr") ? drd["modif_corr"] == DBNull.Value ? false : Convert.ToBoolean(drd["modif_corr"]) : false;
                            output.flgpagotarjeta = drd.HasColumn("flgpagotarjeta") ? drd["flgpagotarjeta"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagotarjeta"]) : false;
                            output.flgpagocheque = drd.HasColumn("flgpagocheque") ? drd["flgpagocheque"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagocheque"]) : false;
                            output.flgpagocredito = drd.HasColumn("flgpagocredito") ? drd["flgpagocredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagocredito"]) : false;
                            output.flgpagoncredito = drd.HasColumn("flgpagoncredito") ? drd["flgpagoncredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagoncredito"]) : false;
                            output.flgvalidaz = drd.HasColumn("flgvalidaz") ? drd["flgvalidaz"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgvalidaz"]) : false;
                            output.flgcierrezok = drd.HasColumn("flgcierrezok") ? drd["flgcierrezok"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrezok"]) : false;
                            output.flghotkey = drd.HasColumn("flghotkey") ? drd["flghotkey"] == DBNull.Value ? false : Convert.ToBoolean(drd["flghotkey"]) : false;
                            output.flgfacturacion = drd.HasColumn("flgfacturacion") ? drd["flgfacturacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgfacturacion"]) : false;
                            output.grabarcliente = drd.HasColumn("grabarcliente") ? drd["grabarcliente"] == DBNull.Value ? false : Convert.ToBoolean(drd["grabarcliente"]) : false;
                            output.flgautomatica = drd.HasColumn("flgautomatica") ? drd["flgautomatica"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgautomatica"]) : false;
                            output.flgaperturacaja = drd.HasColumn("flgaperturacaja") ? drd["flgaperturacaja"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgaperturacaja"]) : false;
                            output.flgpagoefectivo = drd.HasColumn("flgpagoefectivo") ? drd["flgpagoefectivo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagoefectivo"]) : false;
                            output.modocompra = drd.HasColumn("modocompra") ? drd["modocompra"] == DBNull.Value ? false : Convert.ToBoolean(drd["modocompra"]) : false;
                            output.modservicio = drd.HasColumn("modservicio") ? drd["modservicio"] == DBNull.Value ? false : Convert.ToBoolean(drd["modservicio"]) : false;
                            output.modobservacion = drd.HasColumn("modobservacion") ? drd["modobservacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["modobservacion"]) : false;
                            output.moddsctogral = drd.HasColumn("moddsctogral") ? drd["moddsctogral"] == DBNull.Value ? false : Convert.ToBoolean(drd["moddsctogral"]) : false;
                            output.moddsctoitem = drd.HasColumn("moddsctoitem") ? drd["moddsctoitem"] == DBNull.Value ? false : Convert.ToBoolean(drd["moddsctoitem"]) : false;
                            output.preciocero = drd.HasColumn("preciocero") ? drd["preciocero"] == DBNull.Value ? false : Convert.ToBoolean(drd["preciocero"]) : false;
                            output.modfecha = drd.HasColumn("modfecha") ? drd["modfecha"] == DBNull.Value ? false : Convert.ToBoolean(drd["modfecha"]) : false;
                            output.modmoneda = drd.HasColumn("modmoneda") ? drd["modmoneda"] == DBNull.Value ? false : Convert.ToBoolean(drd["modmoneda"]) : false;
                            output.modvendedor = drd.HasColumn("modvendedor") ? drd["modvendedor"] == DBNull.Value ? false : Convert.ToBoolean(drd["modvendedor"]) : false;
                            output.modalmacen = drd.HasColumn("modalmacen") ? drd["modalmacen"] == DBNull.Value ? false : Convert.ToBoolean(drd["modalmacen"]) : false;
                            output.modlistap = drd.HasColumn("modlistap") ? drd["modlistap"] == DBNull.Value ? false : Convert.ToBoolean(drd["modlistap"]) : false;
                            output.modprecio = drd.HasColumn("modprecio") ? drd["modprecio"] == DBNull.Value ? false : Convert.ToBoolean(drd["modprecio"]) : false;
                            output.nrozeta = drd.HasColumn("nrozeta") ? drd["nrozeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrozeta"]) : (decimal?)null;
                            output.mtozeta = drd.HasColumn("mtozeta") ? drd["mtozeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtozeta"]) : (decimal?)null;
                            output.ticketfeed = drd.HasColumn("ticketfeed") ? drd["ticketfeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticketfeed"]) : (decimal?)null;
                            output.ticketlineacorte = drd.HasColumn("ticketlineacorte") ? drd["ticketlineacorte"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticketlineacorte"]) : (decimal?)null;
                            output.ticket2columnas = drd.HasColumn("ticket2columnas") ? drd["ticket2columnas"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticket2columnas"]) : (decimal?)null;
                            output.nventafeed = drd.HasColumn("nventafeed") ? drd["nventafeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nventafeed"]) : (decimal?)null;
                            output.promocionfeed = drd.HasColumn("promocionfeed") ? drd["promocionfeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["promocionfeed"]) : (decimal?)null;
                            output.mtodsctomax = drd.HasColumn("mtodsctomax") ? drd["mtodsctomax"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodsctomax"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.tranvirtual = drd.HasColumn("tranvirtual") ? drd["tranvirtual"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["tranvirtual"]) : (decimal?)null;
                            output.nrodeposito = drd.HasColumn("nrodeposito") ? drd["nrodeposito"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrodeposito"]) : (decimal?)null;
                            output.facturaimpre = (drd.HasColumn("facturaimpre") ? drd["facturaimpre"] == DBNull.Value ? "" : drd["facturaimpre"].ToString().Trim() : "");
                            output.boletaimpre = (drd.HasColumn("boletaimpre") ? drd["boletaimpre"] == DBNull.Value ? "" : drd["boletaimpre"].ToString().Trim() : "");
                            output.gavetachr = drd.HasColumn("gavetachr") ? drd["gavetachr"] == DBNull.Value ? null : drd["gavetachr"].ToString() : null;
                            output.promocionimpre = drd.HasColumn("promocionimpre") ? drd["promocionimpre"] == DBNull.Value ? "" : drd["promocionimpre"].ToString() : "";
                            output.ncreditoimpre = (drd.HasColumn("ncreditoimpre") ? drd["ncreditoimpre"] == DBNull.Value ? "" : drd["ncreditoimpre"].ToString().Trim() : "");
                            output.ndebitoimpre = (drd.HasColumn("ndebitoimpre") ? drd["ndebitoimpre"] == DBNull.Value ? "" : drd["ndebitoimpre"].ToString().Trim() : "");
                            output.guiaimpre = (drd.HasColumn("guiaimpre") ? drd["guiaimpre"] == DBNull.Value ? "" : drd["guiaimpre"].ToString().Trim() : "");
                            output.proformaimpre = drd.HasColumn("proformaimpre") ? drd["proformaimpre"] == DBNull.Value ? "" : drd["proformaimpre"].ToString() : "";
                            output.letraimpre = drd.HasColumn("letraimpre") ? drd["letraimpre"] == DBNull.Value ? "" : drd["letraimpre"].ToString() : "";
                            output.path_loteria = drd.HasColumn("path_loteria") ? drd["path_loteria"] == DBNull.Value ? null : drd["path_loteria"].ToString() : null;
                            output.fe_nompos = drd.HasColumn("fe_nompos") ? drd["fe_nompos"] == DBNull.Value ? null : drd["fe_nompos"].ToString() : null;
                            output.nropos = (drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString().Trim() : null);
                            output.cdusuario = (drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString().Trim() : null);
                            output.seriehd = (drd.HasColumn("seriehd") ? drd["seriehd"] == DBNull.Value ? null : drd["seriehd"].ToString().Trim() : null);
                            output.nroseriemaq = (drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? "" : drd["nroseriemaq"].ToString().Trim() : null);
                            output.nroserie1 = drd.HasColumn("nroserie1") ? drd["nroserie1"] == DBNull.Value ? null : drd["nroserie1"].ToString() : null;
                            output.nroserie2 = drd.HasColumn("nroserie2") ? drd["nroserie2"] == DBNull.Value ? null : drd["nroserie2"].ToString() : null;
                            output.tipoterminal = drd.HasColumn("tipoterminal") ? drd["tipoterminal"] == DBNull.Value ? null : drd["tipoterminal"].ToString() : null;
                            output.ticketfactura = drd.HasColumn("ticketfactura") ? drd["ticketfactura"] == DBNull.Value ? null : drd["ticketfactura"].ToString() : null;
                            output.ncreditoboleta = drd.HasColumn("ncreditoboleta") ? drd["ncreditoboleta"] == DBNull.Value ? null : drd["ncreditoboleta"].ToString() : null;
                            output.ndebitoboleta = drd.HasColumn("ndebitoboleta") ? drd["ndebitoboleta"] == DBNull.Value ? null : drd["ndebitoboleta"].ToString() : null;
                            output.guiafmt = drd.HasColumn("guiafmt") ? drd["guiafmt"] == DBNull.Value ? null : drd["guiafmt"].ToString() : null;
                            output.proforma = drd.HasColumn("proforma") ? drd["proforma"] == DBNull.Value ? null : drd["proforma"].ToString() : null;
                            output.proformafmt = drd.HasColumn("proformafmt") ? drd["proformafmt"] == DBNull.Value ? null : drd["proformafmt"].ToString() : null;
                            output.letra = drd.HasColumn("letra") ? drd["letra"] == DBNull.Value ? null : drd["letra"].ToString() : null;
                            output.letrafmt = drd.HasColumn("letrafmt") ? drd["letrafmt"] == DBNull.Value ? null : drd["letrafmt"].ToString() : null;
                            output.displayimpre = drd.HasColumn("displayimpre") ? drd["displayimpre"] == DBNull.Value ? null : drd["displayimpre"].ToString() : null;
                            output.promocionchrfin = drd.HasColumn("promocionchrfin") ? drd["promocionchrfin"] == DBNull.Value ? null : drd["promocionchrfin"].ToString() : null;
                            output.ncredito = drd.HasColumn("ncredito") ? drd["ncredito"] == DBNull.Value ? null : drd["ncredito"].ToString() : null;
                            output.ncreditofmt = drd.HasColumn("ncreditofmt") ? drd["ncreditofmt"] == DBNull.Value ? null : drd["ncreditofmt"].ToString() : null;
                            output.ndebito = drd.HasColumn("ndebito") ? drd["ndebito"] == DBNull.Value ? null : drd["ndebito"].ToString() : null;
                            output.ndebitofmt = drd.HasColumn("ndebitofmt") ? drd["ndebitofmt"] == DBNull.Value ? null : drd["ndebitofmt"].ToString() : null;
                            output.guia = drd.HasColumn("guia") ? drd["guia"] == DBNull.Value ? null : drd["guia"].ToString() : null;
                            output.nventaimpre = drd.HasColumn("nventaimpre") ? drd["nventaimpre"] == DBNull.Value ? "" : drd["nventaimpre"].ToString() : "";
                            output.nventachrini = drd.HasColumn("nventachrini") ? drd["nventachrini"] == DBNull.Value ? null : drd["nventachrini"].ToString() : null;
                            output.nventachrfin = drd.HasColumn("nventachrfin") ? drd["nventachrfin"] == DBNull.Value ? null : drd["nventachrfin"].ToString() : null;
                            output.promocion = drd.HasColumn("promocion") ? drd["promocion"] == DBNull.Value ? null : drd["promocion"].ToString() : null;
                            output.promocionfmt = drd.HasColumn("promocionfmt") ? drd["promocionfmt"] == DBNull.Value ? null : drd["promocionfmt"].ToString() : null;
                            output.promocionchrini = drd.HasColumn("promocionchrini") ? drd["promocionchrini"] == DBNull.Value ? null : drd["promocionchrini"].ToString() : null;
                            output.gavetaimpre = drd.HasColumn("gavetaimpre") ? drd["gavetaimpre"] == DBNull.Value ? "" : drd["gavetaimpre"].ToString() : "";
                            output.ticket = drd.HasColumn("ticket") ? drd["ticket"] == DBNull.Value ? null : drd["ticket"].ToString() : null;
                            output.ticketimpre = drd.HasColumn("ticketimpre") ? drd["ticketimpre"] == DBNull.Value ? "" : drd["ticketimpre"].ToString() : "";
                            output.ticketchrini = drd.HasColumn("ticketchrini") ? drd["ticketchrini"] == DBNull.Value ? null : drd["ticketchrini"].ToString() : null;
                            output.ticketchrfin = drd.HasColumn("ticketchrfin") ? drd["ticketchrfin"] == DBNull.Value ? null : drd["ticketchrfin"].ToString() : null;
                            output.nventa = drd.HasColumn("nventa") ? drd["nventa"] == DBNull.Value ? null : drd["nventa"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.factura = drd.HasColumn("factura") ? drd["factura"] == DBNull.Value ? null : drd["factura"].ToString() : null;
                            output.facturafmt = drd.HasColumn("facturafmt") ? drd["facturafmt"] == DBNull.Value ? null : drd["facturafmt"].ToString() : null;
                            output.boleta = drd.HasColumn("boleta") ? drd["boleta"] == DBNull.Value ? null : drd["boleta"].ToString() : null;
                            output.boletafmt = drd.HasColumn("boletafmt") ? drd["boletafmt"] == DBNull.Value ? null : drd["boletafmt"].ToString() : null;
                            output.rutaservicio = drd.HasColumn("rutaservicio") ? drd["rutaservicio"] == DBNull.Value ? "" : drd["rutaservicio"].ToString() : "";
                            output.cierrexfmt = drd.HasColumn("cierrexfmt") ? drd["cierrexfmt"] == DBNull.Value ? "" : drd["cierrexfmt"].ToString() : "";
                            output.cierrezfmt = drd.HasColumn("cierrezfmt") ? drd["cierrezfmt"] == DBNull.Value ? "" : drd["cierrezfmt"].ToString() : "";
                            output.nventafmt = drd.HasColumn("nventafmt") ? drd["nventafmt"] == DBNull.Value ? "" : drd["nventafmt"].ToString() : "";
                            output.serafinfmt = drd.HasColumn("serafinfmt") ? drd["serafinfmt"] == DBNull.Value ? "" : drd["serafinfmt"].ToString() : "";
                            output.depositofmt = drd.HasColumn("depositofmt") ? drd["depositofmt"] == DBNull.Value ? "" : drd["depositofmt"].ToString() : "";
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
            return output;
        }
        public TS_BETerminal OBTENER_TERMINAL_POR_USUARIO(TS_BETerminal input)
        {
 
            TS_BETerminal output = new TS_BETerminal(); 
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LSITAR_TERMINAL_POR_USUARIO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@seriehd", SqlDbType.Char, 2).Value = input.seriehd;
                    cmd.Parameters.Add("@cdusuario", SqlDbType.Char, 2).Value = input.cdusuario;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {                            
                            output.conexion_dispensador = drd.HasColumn("conexion_dispensador") ? drd["conexion_dispensador"] == DBNull.Value ? (byte?) 1 : Convert.ToByte(drd["conexion_dispensador"]) : (byte?) 1;
                            output.fe_idpos = drd.HasColumn("fe_idpos") ? drd["fe_idpos"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["fe_idpos"]) : (int?)null;
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.tktfactura = drd.HasColumn("tktfactura") ? drd["tktfactura"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktfactura"]) : false;
                            output.tktboleta = drd.HasColumn("tktboleta") ? drd["tktboleta"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktboleta"]) : false;
                            output.tktpromocion = drd.HasColumn("tktpromocion") ? drd["tktpromocion"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktpromocion"]) : false;
                            output.facturapreimpre = drd.HasColumn("facturapreimpre") ? drd["facturapreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["facturapreimpre"]) : false;
                            output.boletapreimpre = drd.HasColumn("boletapreimpre") ? drd["boletapreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["boletapreimpre"]) : false;
                            output.promocionpreimpre = drd.HasColumn("promocionpreimpre") ? drd["promocionpreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["promocionpreimpre"]) : false;
                            output.activa_boton_playa = drd.HasColumn("activa_boton_playa") ? drd["activa_boton_playa"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_boton_playa"]) : false;
                            output.flg_pdf417 = drd.HasColumn("flg_pdf417") ? drd["flg_pdf417"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pdf417"]) : false;
                            output.flg_nc_correlativo = drd.HasColumn("flg_nc_correlativo") ? drd["flg_nc_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nc_correlativo"]) : false;
                            output.flg_nd_correlativo = drd.HasColumn("flg_nd_correlativo") ? drd["flg_nd_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nd_correlativo"]) : false;
                            output.flg_print_qr = drd.HasColumn("flg_print_qr") ? drd["flg_print_qr"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_print_qr"]) : false;
                            output.flg_formato_a4 = drd.HasColumn("flg_formato_a4") ? drd["flg_formato_a4"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_formato_a4"]) : false;
                            output.rucinvalido = drd.HasColumn("rucinvalido") ? drd["rucinvalido"] == DBNull.Value ? false : Convert.ToBoolean(drd["rucinvalido"]) : false;
                            output._virtual = drd.HasColumn("virtual") ? drd["virtual"] == DBNull.Value ? false : Convert.ToBoolean(drd["virtual"]) : false;
                            output.tktnotadespacho = drd.HasColumn("tktnotadespacho") ? drd["tktnotadespacho"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktnotadespacho"]) : false;
                            output.flgtransferencia = drd.HasColumn("flgtransferencia") ? drd["flgtransferencia"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgtransferencia"]) : false;
                            output.playa_formasdepago = drd.HasColumn("playa_formasdepago") ? drd["playa_formasdepago"] == DBNull.Value ? false : Convert.ToBoolean(drd["playa_formasdepago"]) : false;
                            output.modif_corr = drd.HasColumn("modif_corr") ? drd["modif_corr"] == DBNull.Value ? false : Convert.ToBoolean(drd["modif_corr"]) : false;
                            output.flgpagotarjeta = drd.HasColumn("flgpagotarjeta") ? drd["flgpagotarjeta"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagotarjeta"]) : false;
                            output.flgpagocheque = drd.HasColumn("flgpagocheque") ? drd["flgpagocheque"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagocheque"]) : false;
                            output.flgpagocredito = drd.HasColumn("flgpagocredito") ? drd["flgpagocredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagocredito"]) : false;
                            output.flgpagoncredito = drd.HasColumn("flgpagoncredito") ? drd["flgpagoncredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagoncredito"]) : false;
                            output.flgvalidaz = drd.HasColumn("flgvalidaz") ? drd["flgvalidaz"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgvalidaz"]) : false;
                            output.flgcierrezok = drd.HasColumn("flgcierrezok") ? drd["flgcierrezok"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrezok"]) : false;
                            output.flghotkey = drd.HasColumn("flghotkey") ? drd["flghotkey"] == DBNull.Value ? false : Convert.ToBoolean(drd["flghotkey"]) : false;
                            output.flgfacturacion = drd.HasColumn("flgfacturacion") ? drd["flgfacturacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgfacturacion"]) : false;
                            output.grabarcliente = drd.HasColumn("grabarcliente") ? drd["grabarcliente"] == DBNull.Value ? false : Convert.ToBoolean(drd["grabarcliente"]) : false;
                            output.flgautomatica = drd.HasColumn("flgautomatica") ? drd["flgautomatica"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgautomatica"]) : false;
                            output.flgaperturacaja = drd.HasColumn("flgaperturacaja") ? drd["flgaperturacaja"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgaperturacaja"]) : false;
                            output.flgpagoefectivo = drd.HasColumn("flgpagoefectivo") ? drd["flgpagoefectivo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagoefectivo"]) : false;
                            output.modocompra = drd.HasColumn("modocompra") ? drd["modocompra"] == DBNull.Value ? false : Convert.ToBoolean(drd["modocompra"]) : false;
                            output.modservicio = drd.HasColumn("modservicio") ? drd["modservicio"] == DBNull.Value ? false : Convert.ToBoolean(drd["modservicio"]) : false;
                            output.modobservacion = drd.HasColumn("modobservacion") ? drd["modobservacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["modobservacion"]) : false;
                            output.moddsctogral = drd.HasColumn("moddsctogral") ? drd["moddsctogral"] == DBNull.Value ? false : Convert.ToBoolean(drd["moddsctogral"]) : false;
                            output.moddsctoitem = drd.HasColumn("moddsctoitem") ? drd["moddsctoitem"] == DBNull.Value ? false : Convert.ToBoolean(drd["moddsctoitem"]) : false;
                            output.preciocero = drd.HasColumn("preciocero") ? drd["preciocero"] == DBNull.Value ? false : Convert.ToBoolean(drd["preciocero"]) : false;
                            output.modfecha = drd.HasColumn("modfecha") ? drd["modfecha"] == DBNull.Value ? false : Convert.ToBoolean(drd["modfecha"]) : false;
                            output.modmoneda = drd.HasColumn("modmoneda") ? drd["modmoneda"] == DBNull.Value ? false : Convert.ToBoolean(drd["modmoneda"]) : false;
                            output.modvendedor = drd.HasColumn("modvendedor") ? drd["modvendedor"] == DBNull.Value ? false : Convert.ToBoolean(drd["modvendedor"]) : false;
                            output.modalmacen = drd.HasColumn("modalmacen") ? drd["modalmacen"] == DBNull.Value ? false : Convert.ToBoolean(drd["modalmacen"]) : false;
                            output.modlistap = drd.HasColumn("modlistap") ? drd["modlistap"] == DBNull.Value ? false : Convert.ToBoolean(drd["modlistap"]) : false;
                            output.modprecio = drd.HasColumn("modprecio") ? drd["modprecio"] == DBNull.Value ? false : Convert.ToBoolean(drd["modprecio"]) : false;
                            output.nrozeta = drd.HasColumn("nrozeta") ? drd["nrozeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrozeta"]) : (decimal?)null;
                            output.mtozeta = drd.HasColumn("mtozeta") ? drd["mtozeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtozeta"]) : (decimal?)null;
                            output.ticketfeed = drd.HasColumn("ticketfeed") ? drd["ticketfeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticketfeed"]) : (decimal?)null;
                            output.ticketlineacorte = drd.HasColumn("ticketlineacorte") ? drd["ticketlineacorte"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticketlineacorte"]) : (decimal?)null;
                            output.ticket2columnas = drd.HasColumn("ticket2columnas") ? drd["ticket2columnas"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticket2columnas"]) : (decimal?)null;
                            output.nventafeed = drd.HasColumn("nventafeed") ? drd["nventafeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nventafeed"]) : (decimal?)null;
                            output.promocionfeed = drd.HasColumn("promocionfeed") ? drd["promocionfeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["promocionfeed"]) : (decimal?)null;
                            output.mtodsctomax = drd.HasColumn("mtodsctomax") ? drd["mtodsctomax"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodsctomax"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.tranvirtual = drd.HasColumn("tranvirtual") ? drd["tranvirtual"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["tranvirtual"]) : (decimal?)null;
                            output.nrodeposito = drd.HasColumn("nrodeposito") ? drd["nrodeposito"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrodeposito"]) : (decimal?)null;
                            output.facturaimpre = drd.HasColumn("facturaimpre") ? drd["facturaimpre"] == DBNull.Value ? null : drd["facturaimpre"].ToString() : null;
                            output.boletaimpre = drd.HasColumn("boletaimpre") ? drd["boletaimpre"] == DBNull.Value ? null : drd["boletaimpre"].ToString() : null;
                            output.gavetachr = drd.HasColumn("gavetachr") ? drd["gavetachr"] == DBNull.Value ? null : drd["gavetachr"].ToString() : null;
                            output.promocionimpre = drd.HasColumn("promocionimpre") ? drd["promocionimpre"] == DBNull.Value ? null : drd["promocionimpre"].ToString() : null;
                            output.ncreditoimpre = drd.HasColumn("ncreditoimpre") ? drd["ncreditoimpre"] == DBNull.Value ? null : drd["ncreditoimpre"].ToString() : null;
                            output.ndebitoimpre = drd.HasColumn("ndebitoimpre") ? drd["ndebitoimpre"] == DBNull.Value ? null : drd["ndebitoimpre"].ToString() : null;
                            output.guiaimpre = drd.HasColumn("guiaimpre") ? drd["guiaimpre"] == DBNull.Value ? null : drd["guiaimpre"].ToString() : null;
                            output.proformaimpre = drd.HasColumn("proformaimpre") ? drd["proformaimpre"] == DBNull.Value ? null : drd["proformaimpre"].ToString() : null;
                            output.letraimpre = drd.HasColumn("letraimpre") ? drd["letraimpre"] == DBNull.Value ? null : drd["letraimpre"].ToString() : null;
                            output.path_loteria = drd.HasColumn("path_loteria") ? drd["path_loteria"] == DBNull.Value ? null : drd["path_loteria"].ToString() : null;
                            output.fe_nompos = drd.HasColumn("fe_nompos") ? drd["fe_nompos"] == DBNull.Value ? null : drd["fe_nompos"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdusuario = drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString() : null;
                            output.seriehd = drd.HasColumn("seriehd") ? drd["seriehd"] == DBNull.Value ? null : drd["seriehd"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.nroserie1 = drd.HasColumn("nroserie1") ? drd["nroserie1"] == DBNull.Value ? null : drd["nroserie1"].ToString() : null;
                            output.nroserie2 = drd.HasColumn("nroserie2") ? drd["nroserie2"] == DBNull.Value ? null : drd["nroserie2"].ToString() : null;
                            output.tipoterminal = drd.HasColumn("tipoterminal") ? drd["tipoterminal"] == DBNull.Value ? null : drd["tipoterminal"].ToString() : null;
                            output.ticketfactura = drd.HasColumn("ticketfactura") ? drd["ticketfactura"] == DBNull.Value ? null : drd["ticketfactura"].ToString() : null;
                            output.ncreditoboleta = drd.HasColumn("ncreditoboleta") ? drd["ncreditoboleta"] == DBNull.Value ? null : drd["ncreditoboleta"].ToString() : null;
                            output.ndebitoboleta = drd.HasColumn("ndebitoboleta") ? drd["ndebitoboleta"] == DBNull.Value ? null : drd["ndebitoboleta"].ToString() : null;
                            output.guiafmt = drd.HasColumn("guiafmt") ? drd["guiafmt"] == DBNull.Value ? null : drd["guiafmt"].ToString() : null;
                            output.proforma = drd.HasColumn("proforma") ? drd["proforma"] == DBNull.Value ? null : drd["proforma"].ToString() : null;
                            output.proformafmt = drd.HasColumn("proformafmt") ? drd["proformafmt"] == DBNull.Value ? null : drd["proformafmt"].ToString() : null;
                            output.letra = drd.HasColumn("letra") ? drd["letra"] == DBNull.Value ? null : drd["letra"].ToString() : null;
                            output.letrafmt = drd.HasColumn("letrafmt") ? drd["letrafmt"] == DBNull.Value ? null : drd["letrafmt"].ToString() : null;
                            output.displayimpre = drd.HasColumn("displayimpre") ? drd["displayimpre"] == DBNull.Value ? null : drd["displayimpre"].ToString() : null;
                            output.promocionchrfin = drd.HasColumn("promocionchrfin") ? drd["promocionchrfin"] == DBNull.Value ? null : drd["promocionchrfin"].ToString() : null;
                            output.ncredito = drd.HasColumn("ncredito") ? drd["ncredito"] == DBNull.Value ? null : drd["ncredito"].ToString() : null;
                            output.ncreditofmt = drd.HasColumn("ncreditofmt") ? drd["ncreditofmt"] == DBNull.Value ? null : drd["ncreditofmt"].ToString() : null;
                            output.ndebito = drd.HasColumn("ndebito") ? drd["ndebito"] == DBNull.Value ? null : drd["ndebito"].ToString() : null;
                            output.ndebitofmt = drd.HasColumn("ndebitofmt") ? drd["ndebitofmt"] == DBNull.Value ? null : drd["ndebitofmt"].ToString() : null;
                            output.guia = drd.HasColumn("guia") ? drd["guia"] == DBNull.Value ? null : drd["guia"].ToString() : null;
                            output.nventaimpre = drd.HasColumn("nventaimpre") ? drd["nventaimpre"] == DBNull.Value ? null : drd["nventaimpre"].ToString() : null;
                            output.nventachrini = drd.HasColumn("nventachrini") ? drd["nventachrini"] == DBNull.Value ? null : drd["nventachrini"].ToString() : null;
                            output.nventachrfin = drd.HasColumn("nventachrfin") ? drd["nventachrfin"] == DBNull.Value ? null : drd["nventachrfin"].ToString() : null;
                            output.promocion = drd.HasColumn("promocion") ? drd["promocion"] == DBNull.Value ? null : drd["promocion"].ToString() : null;
                            output.promocionfmt = drd.HasColumn("promocionfmt") ? drd["promocionfmt"] == DBNull.Value ? null : drd["promocionfmt"].ToString() : null;
                            output.promocionchrini = drd.HasColumn("promocionchrini") ? drd["promocionchrini"] == DBNull.Value ? null : drd["promocionchrini"].ToString() : null;
                            output.gavetaimpre = drd.HasColumn("gavetaimpre") ? drd["gavetaimpre"] == DBNull.Value ? null : drd["gavetaimpre"].ToString() : null;
                            output.ticket = drd.HasColumn("ticket") ? drd["ticket"] == DBNull.Value ? null : drd["ticket"].ToString() : null;
                            output.ticketimpre = drd.HasColumn("ticketimpre") ? drd["ticketimpre"] == DBNull.Value ? null : drd["ticketimpre"].ToString() : null;
                            output.ticketchrini = drd.HasColumn("ticketchrini") ? drd["ticketchrini"] == DBNull.Value ? null : drd["ticketchrini"].ToString() : null;
                            output.ticketchrfin = drd.HasColumn("ticketchrfin") ? drd["ticketchrfin"] == DBNull.Value ? null : drd["ticketchrfin"].ToString() : null;
                            output.nventa = drd.HasColumn("nventa") ? drd["nventa"] == DBNull.Value ? null : drd["nventa"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.factura = drd.HasColumn("factura") ? drd["factura"] == DBNull.Value ? null : drd["factura"].ToString() : null;
                            output.facturafmt = drd.HasColumn("facturafmt") ? drd["facturafmt"] == DBNull.Value ? null : drd["facturafmt"].ToString() : null;
                            output.boleta = drd.HasColumn("boleta") ? drd["boleta"] == DBNull.Value ? null : drd["boleta"].ToString() : null;
                            output.boletafmt = drd.HasColumn("boletafmt") ? drd["boletafmt"] == DBNull.Value ? null : drd["boletafmt"].ToString() : null;
                             
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
            return output;
        }
        public List<TS_BETerminal>LISTAR_TERMINAL_POR_USUARIO(TS_BETerminal input)
        {
            List<TS_BETerminal> lista = new List<TS_BETerminal>();
            TS_BETerminal output;
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LSITAR_TERMINAL_POR_USUARIO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@seriehd", SqlDbType.Char, 2).Value = input.seriehd;
                    cmd.Parameters.Add("@cdusuario", SqlDbType.Char, 2).Value = input.cdusuario;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output = new TS_BETerminal();
                            output.conexion_dispensador = drd.HasColumn("conexion_dispensador") ? drd["conexion_dispensador"] == DBNull.Value ? (byte?) 1 : Convert.ToByte(drd["conexion_dispensador"]) : (byte?) 1;
                            output.fe_idpos = drd.HasColumn("fe_idpos") ? drd["fe_idpos"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["fe_idpos"]) : (int?)null;
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.tktfactura = drd.HasColumn("tktfactura") ? drd["tktfactura"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktfactura"]) : false;
                            output.tktboleta = drd.HasColumn("tktboleta") ? drd["tktboleta"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktboleta"]) : false;
                            output.tktpromocion = drd.HasColumn("tktpromocion") ? drd["tktpromocion"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktpromocion"]) : false;
                            output.facturapreimpre = drd.HasColumn("facturapreimpre") ? drd["facturapreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["facturapreimpre"]) : false;
                            output.boletapreimpre = drd.HasColumn("boletapreimpre") ? drd["boletapreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["boletapreimpre"]) : false;
                            output.promocionpreimpre = drd.HasColumn("promocionpreimpre") ? drd["promocionpreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["promocionpreimpre"]) : false;
                            output.activa_boton_playa = drd.HasColumn("activa_boton_playa") ? drd["activa_boton_playa"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_boton_playa"]) : false;
                            output.flg_pdf417 = drd.HasColumn("flg_pdf417") ? drd["flg_pdf417"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pdf417"]) : false;
                            output.flg_nc_correlativo = drd.HasColumn("flg_nc_correlativo") ? drd["flg_nc_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nc_correlativo"]) : false;
                            output.flg_nd_correlativo = drd.HasColumn("flg_nd_correlativo") ? drd["flg_nd_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nd_correlativo"]) : false;
                            output.flg_print_qr = drd.HasColumn("flg_print_qr") ? drd["flg_print_qr"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_print_qr"]) : false;
                            output.flg_formato_a4 = drd.HasColumn("flg_formato_a4") ? drd["flg_formato_a4"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_formato_a4"]) : false;
                            output.rucinvalido = drd.HasColumn("rucinvalido") ? drd["rucinvalido"] == DBNull.Value ? false : Convert.ToBoolean(drd["rucinvalido"]) : false;
                            output._virtual = drd.HasColumn("virtual") ? drd["virtual"] == DBNull.Value ? false : Convert.ToBoolean(drd["virtual"]) : false;
                            output.tktnotadespacho = drd.HasColumn("tktnotadespacho") ? drd["tktnotadespacho"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktnotadespacho"]) : false;
                            output.flgtransferencia = drd.HasColumn("flgtransferencia") ? drd["flgtransferencia"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgtransferencia"]) : false;
                            output.playa_formasdepago = drd.HasColumn("playa_formasdepago") ? drd["playa_formasdepago"] == DBNull.Value ? false : Convert.ToBoolean(drd["playa_formasdepago"]) : false;
                            output.modif_corr = drd.HasColumn("modif_corr") ? drd["modif_corr"] == DBNull.Value ? false : Convert.ToBoolean(drd["modif_corr"]) : false;
                            output.flgpagotarjeta = drd.HasColumn("flgpagotarjeta") ? drd["flgpagotarjeta"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagotarjeta"]) : false;
                            output.flgpagocheque = drd.HasColumn("flgpagocheque") ? drd["flgpagocheque"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagocheque"]) : false;
                            output.flgpagocredito = drd.HasColumn("flgpagocredito") ? drd["flgpagocredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagocredito"]) : false;
                            output.flgpagoncredito = drd.HasColumn("flgpagoncredito") ? drd["flgpagoncredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagoncredito"]) : false;
                            output.flgvalidaz = drd.HasColumn("flgvalidaz") ? drd["flgvalidaz"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgvalidaz"]) : false;
                            output.flgcierrezok = drd.HasColumn("flgcierrezok") ? drd["flgcierrezok"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrezok"]) : false;
                            output.flghotkey = drd.HasColumn("flghotkey") ? drd["flghotkey"] == DBNull.Value ? false : Convert.ToBoolean(drd["flghotkey"]) : false;
                            output.flgfacturacion = drd.HasColumn("flgfacturacion") ? drd["flgfacturacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgfacturacion"]) : false;
                            output.grabarcliente = drd.HasColumn("grabarcliente") ? drd["grabarcliente"] == DBNull.Value ? false : Convert.ToBoolean(drd["grabarcliente"]) : false;
                            output.flgautomatica = drd.HasColumn("flgautomatica") ? drd["flgautomatica"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgautomatica"]) : false;
                            output.flgaperturacaja = drd.HasColumn("flgaperturacaja") ? drd["flgaperturacaja"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgaperturacaja"]) : false;
                            output.flgpagoefectivo = drd.HasColumn("flgpagoefectivo") ? drd["flgpagoefectivo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagoefectivo"]) : false;
                            output.modocompra = drd.HasColumn("modocompra") ? drd["modocompra"] == DBNull.Value ? false : Convert.ToBoolean(drd["modocompra"]) : false;
                            output.modservicio = drd.HasColumn("modservicio") ? drd["modservicio"] == DBNull.Value ? false : Convert.ToBoolean(drd["modservicio"]) : false;
                            output.modobservacion = drd.HasColumn("modobservacion") ? drd["modobservacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["modobservacion"]) : false;
                            output.moddsctogral = drd.HasColumn("moddsctogral") ? drd["moddsctogral"] == DBNull.Value ? false : Convert.ToBoolean(drd["moddsctogral"]) : false;
                            output.moddsctoitem = drd.HasColumn("moddsctoitem") ? drd["moddsctoitem"] == DBNull.Value ? false : Convert.ToBoolean(drd["moddsctoitem"]) : false;
                            output.preciocero = drd.HasColumn("preciocero") ? drd["preciocero"] == DBNull.Value ? false : Convert.ToBoolean(drd["preciocero"]) : false;
                            output.modfecha = drd.HasColumn("modfecha") ? drd["modfecha"] == DBNull.Value ? false : Convert.ToBoolean(drd["modfecha"]) : false;
                            output.modmoneda = drd.HasColumn("modmoneda") ? drd["modmoneda"] == DBNull.Value ? false : Convert.ToBoolean(drd["modmoneda"]) : false;
                            output.modvendedor = drd.HasColumn("modvendedor") ? drd["modvendedor"] == DBNull.Value ? false : Convert.ToBoolean(drd["modvendedor"]) : false;
                            output.modalmacen = drd.HasColumn("modalmacen") ? drd["modalmacen"] == DBNull.Value ? false : Convert.ToBoolean(drd["modalmacen"]) : false;
                            output.modlistap = drd.HasColumn("modlistap") ? drd["modlistap"] == DBNull.Value ? false : Convert.ToBoolean(drd["modlistap"]) : false;
                            output.modprecio = drd.HasColumn("modprecio") ? drd["modprecio"] == DBNull.Value ? false : Convert.ToBoolean(drd["modprecio"]) : false;
                            output.nrozeta = drd.HasColumn("nrozeta") ? drd["nrozeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrozeta"]) : (decimal?)null;
                            output.mtozeta = drd.HasColumn("mtozeta") ? drd["mtozeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtozeta"]) : (decimal?)null;
                            output.ticketfeed = drd.HasColumn("ticketfeed") ? drd["ticketfeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticketfeed"]) : (decimal?)null;
                            output.ticketlineacorte = drd.HasColumn("ticketlineacorte") ? drd["ticketlineacorte"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticketlineacorte"]) : (decimal?)null;
                            output.ticket2columnas = drd.HasColumn("ticket2columnas") ? drd["ticket2columnas"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticket2columnas"]) : (decimal?)null;
                            output.nventafeed = drd.HasColumn("nventafeed") ? drd["nventafeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nventafeed"]) : (decimal?)null;
                            output.promocionfeed = drd.HasColumn("promocionfeed") ? drd["promocionfeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["promocionfeed"]) : (decimal?)null;
                            output.mtodsctomax = drd.HasColumn("mtodsctomax") ? drd["mtodsctomax"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodsctomax"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.tranvirtual = drd.HasColumn("tranvirtual") ? drd["tranvirtual"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["tranvirtual"]) : (decimal?)null;
                            output.nrodeposito = drd.HasColumn("nrodeposito") ? drd["nrodeposito"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrodeposito"]) : (decimal?)null;
                            output.facturaimpre = drd.HasColumn("facturaimpre") ? drd["facturaimpre"] == DBNull.Value ? null : drd["facturaimpre"].ToString() : null;
                            output.boletaimpre = drd.HasColumn("boletaimpre") ? drd["boletaimpre"] == DBNull.Value ? null : drd["boletaimpre"].ToString() : null;
                            output.gavetachr = drd.HasColumn("gavetachr") ? drd["gavetachr"] == DBNull.Value ? null : drd["gavetachr"].ToString() : null;
                            output.promocionimpre = drd.HasColumn("promocionimpre") ? drd["promocionimpre"] == DBNull.Value ? null : drd["promocionimpre"].ToString() : null;
                            output.ncreditoimpre = drd.HasColumn("ncreditoimpre") ? drd["ncreditoimpre"] == DBNull.Value ? null : drd["ncreditoimpre"].ToString() : null;
                            output.ndebitoimpre = drd.HasColumn("ndebitoimpre") ? drd["ndebitoimpre"] == DBNull.Value ? null : drd["ndebitoimpre"].ToString() : null;
                            output.guiaimpre = drd.HasColumn("guiaimpre") ? drd["guiaimpre"] == DBNull.Value ? null : drd["guiaimpre"].ToString() : null;
                            output.proformaimpre = drd.HasColumn("proformaimpre") ? drd["proformaimpre"] == DBNull.Value ? null : drd["proformaimpre"].ToString() : null;
                            output.letraimpre = drd.HasColumn("letraimpre") ? drd["letraimpre"] == DBNull.Value ? null : drd["letraimpre"].ToString() : null;
                            output.path_loteria = drd.HasColumn("path_loteria") ? drd["path_loteria"] == DBNull.Value ? null : drd["path_loteria"].ToString() : null;
                            output.fe_nompos = drd.HasColumn("fe_nompos") ? drd["fe_nompos"] == DBNull.Value ? null : drd["fe_nompos"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdusuario = drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString() : null;
                            output.seriehd = drd.HasColumn("seriehd") ? drd["seriehd"] == DBNull.Value ? null : drd["seriehd"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.nroserie1 = drd.HasColumn("nroserie1") ? drd["nroserie1"] == DBNull.Value ? null : drd["nroserie1"].ToString() : null;
                            output.nroserie2 = drd.HasColumn("nroserie2") ? drd["nroserie2"] == DBNull.Value ? null : drd["nroserie2"].ToString() : null;
                            output.tipoterminal = drd.HasColumn("tipoterminal") ? drd["tipoterminal"] == DBNull.Value ? null : drd["tipoterminal"].ToString() : null;
                            output.ticketfactura = drd.HasColumn("ticketfactura") ? drd["ticketfactura"] == DBNull.Value ? null : drd["ticketfactura"].ToString() : null;
                            output.ncreditoboleta = drd.HasColumn("ncreditoboleta") ? drd["ncreditoboleta"] == DBNull.Value ? null : drd["ncreditoboleta"].ToString() : null;
                            output.ndebitoboleta = drd.HasColumn("ndebitoboleta") ? drd["ndebitoboleta"] == DBNull.Value ? null : drd["ndebitoboleta"].ToString() : null;
                            output.guiafmt = drd.HasColumn("guiafmt") ? drd["guiafmt"] == DBNull.Value ? null : drd["guiafmt"].ToString() : null;
                            output.proforma = drd.HasColumn("proforma") ? drd["proforma"] == DBNull.Value ? null : drd["proforma"].ToString() : null;
                            output.proformafmt = drd.HasColumn("proformafmt") ? drd["proformafmt"] == DBNull.Value ? null : drd["proformafmt"].ToString() : null;
                            output.letra = drd.HasColumn("letra") ? drd["letra"] == DBNull.Value ? null : drd["letra"].ToString() : null;
                            output.letrafmt = drd.HasColumn("letrafmt") ? drd["letrafmt"] == DBNull.Value ? null : drd["letrafmt"].ToString() : null;
                            output.displayimpre = drd.HasColumn("displayimpre") ? drd["displayimpre"] == DBNull.Value ? null : drd["displayimpre"].ToString() : null;
                            output.promocionchrfin = drd.HasColumn("promocionchrfin") ? drd["promocionchrfin"] == DBNull.Value ? null : drd["promocionchrfin"].ToString() : null;
                            output.ncredito = drd.HasColumn("ncredito") ? drd["ncredito"] == DBNull.Value ? null : drd["ncredito"].ToString() : null;
                            output.ncreditofmt = drd.HasColumn("ncreditofmt") ? drd["ncreditofmt"] == DBNull.Value ? null : drd["ncreditofmt"].ToString() : null;
                            output.ndebito = drd.HasColumn("ndebito") ? drd["ndebito"] == DBNull.Value ? null : drd["ndebito"].ToString() : null;
                            output.ndebitofmt = drd.HasColumn("ndebitofmt") ? drd["ndebitofmt"] == DBNull.Value ? null : drd["ndebitofmt"].ToString() : null;
                            output.guia = drd.HasColumn("guia") ? drd["guia"] == DBNull.Value ? null : drd["guia"].ToString() : null;
                            output.nventaimpre = drd.HasColumn("nventaimpre") ? drd["nventaimpre"] == DBNull.Value ? null : drd["nventaimpre"].ToString() : null;
                            output.nventachrini = drd.HasColumn("nventachrini") ? drd["nventachrini"] == DBNull.Value ? null : drd["nventachrini"].ToString() : null;
                            output.nventachrfin = drd.HasColumn("nventachrfin") ? drd["nventachrfin"] == DBNull.Value ? null : drd["nventachrfin"].ToString() : null;
                            output.promocion = drd.HasColumn("promocion") ? drd["promocion"] == DBNull.Value ? null : drd["promocion"].ToString() : null;
                            output.promocionfmt = drd.HasColumn("promocionfmt") ? drd["promocionfmt"] == DBNull.Value ? null : drd["promocionfmt"].ToString() : null;
                            output.promocionchrini = drd.HasColumn("promocionchrini") ? drd["promocionchrini"] == DBNull.Value ? null : drd["promocionchrini"].ToString() : null;
                            output.gavetaimpre = drd.HasColumn("gavetaimpre") ? drd["gavetaimpre"] == DBNull.Value ? null : drd["gavetaimpre"].ToString() : null;
                            output.ticket = drd.HasColumn("ticket") ? drd["ticket"] == DBNull.Value ? null : drd["ticket"].ToString() : null;
                            output.ticketimpre = drd.HasColumn("ticketimpre") ? drd["ticketimpre"] == DBNull.Value ? null : drd["ticketimpre"].ToString() : null;
                            output.ticketchrini = drd.HasColumn("ticketchrini") ? drd["ticketchrini"] == DBNull.Value ? null : drd["ticketchrini"].ToString() : null;
                            output.ticketchrfin = drd.HasColumn("ticketchrfin") ? drd["ticketchrfin"] == DBNull.Value ? null : drd["ticketchrfin"].ToString() : null;
                            output.nventa = drd.HasColumn("nventa") ? drd["nventa"] == DBNull.Value ? null : drd["nventa"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.factura = drd.HasColumn("factura") ? drd["factura"] == DBNull.Value ? null : drd["factura"].ToString() : null;
                            output.facturafmt = drd.HasColumn("facturafmt") ? drd["facturafmt"] == DBNull.Value ? null : drd["facturafmt"].ToString() : null;
                            output.boleta = drd.HasColumn("boleta") ? drd["boleta"] == DBNull.Value ? null : drd["boleta"].ToString() : null;
                            output.boletafmt = drd.HasColumn("boletafmt") ? drd["boletafmt"] == DBNull.Value ? null : drd["boletafmt"].ToString() : null;

                            lista.Add(output);
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
            return lista;
        }
        public bool UpdateCorrelativo(string TipoDoc, string NroDocumento, string SerieHd, SqlTransaction pSqlTransaction)
        {

            bool flag2;
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("SP_ITBCP_ACTUALIZAR_CORRELATIVO_POR_SERIE")
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = pSqlTransaction.Connection,
                    Transaction = pSqlTransaction
                };
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@tipodocumento", SqlDbType.VarChar, 15).Value = TipoDoc;
                cmd.Parameters.Add("@nrodocumento", SqlDbType.Char, 10).Value = NroDocumento;
                cmd.Parameters.Add("@seriehd", SqlDbType.Char, 10).Value = SerieHd;
                flag = cmd.ExecuteNonQuery() > 0;

                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;
        }
        public TS_BETerminal OBTENER_TERMINAL_POR_NROPOS(TS_BETerminal input)
        {
            TS_BETerminal output = new TS_BETerminal();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_BUSCAR_TERMINAL_POR_NROPOS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NROPOS", SqlDbType.Char, 10).Value = input.nropos;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            output.conexion_dispensador = drd.HasColumn("conexion_dispensador") ? drd["conexion_dispensador"] == DBNull.Value ? (byte?) 1 : Convert.ToByte(drd["conexion_dispensador"]) : (byte?) 1;
                            output.fe_idpos = drd.HasColumn("fe_idpos") ? drd["fe_idpos"] == DBNull.Value ? (int?)null : Convert.ToInt32(drd["fe_idpos"]) : (int?)null;
                            output.fecproceso = drd.HasColumn("fecproceso") ? drd["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(drd["fecproceso"]) : (DateTime?)null;
                            output.tktfactura = drd.HasColumn("tktfactura") ? drd["tktfactura"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktfactura"]) : false;
                            output.tktboleta = drd.HasColumn("tktboleta") ? drd["tktboleta"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktboleta"]) : false;
                            output.tktpromocion = drd.HasColumn("tktpromocion") ? drd["tktpromocion"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktpromocion"]) : false;
                            output.facturapreimpre = drd.HasColumn("facturapreimpre") ? drd["facturapreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["facturapreimpre"]) : false;
                            output.boletapreimpre = drd.HasColumn("boletapreimpre") ? drd["boletapreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["boletapreimpre"]) : false;
                            output.promocionpreimpre = drd.HasColumn("promocionpreimpre") ? drd["promocionpreimpre"] == DBNull.Value ? false : Convert.ToBoolean(drd["promocionpreimpre"]) : false;
                            output.activa_boton_playa = drd.HasColumn("activa_boton_playa") ? drd["activa_boton_playa"] == DBNull.Value ? false : Convert.ToBoolean(drd["activa_boton_playa"]) : false;
                            output.flg_pdf417 = drd.HasColumn("flg_pdf417") ? drd["flg_pdf417"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_pdf417"]) : false;
                            output.flg_nc_correlativo = drd.HasColumn("flg_nc_correlativo") ? drd["flg_nc_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nc_correlativo"]) : false;
                            output.flg_nd_correlativo = drd.HasColumn("flg_nd_correlativo") ? drd["flg_nd_correlativo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_nd_correlativo"]) : false;
                            output.flg_print_qr = drd.HasColumn("flg_print_qr") ? drd["flg_print_qr"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_print_qr"]) : false;
                            output.flg_formato_a4 = drd.HasColumn("flg_formato_a4") ? drd["flg_formato_a4"] == DBNull.Value ? false : Convert.ToBoolean(drd["flg_formato_a4"]) : false;
                            output.rucinvalido = drd.HasColumn("rucinvalido") ? drd["rucinvalido"] == DBNull.Value ? false : Convert.ToBoolean(drd["rucinvalido"]) : false;
                            output._virtual = drd.HasColumn("virtual") ? drd["virtual"] == DBNull.Value ? false : Convert.ToBoolean(drd["virtual"]) : false;
                            output.tktnotadespacho = drd.HasColumn("tktnotadespacho") ? drd["tktnotadespacho"] == DBNull.Value ? false : Convert.ToBoolean(drd["tktnotadespacho"]) : false;
                            output.flgtransferencia = drd.HasColumn("flgtransferencia") ? drd["flgtransferencia"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgtransferencia"]) : false;
                            output.playa_formasdepago = drd.HasColumn("playa_formasdepago") ? drd["playa_formasdepago"] == DBNull.Value ? false : Convert.ToBoolean(drd["playa_formasdepago"]) : false;
                            output.modif_corr = drd.HasColumn("modif_corr") ? drd["modif_corr"] == DBNull.Value ? false : Convert.ToBoolean(drd["modif_corr"]) : false;
                            output.flgpagotarjeta = drd.HasColumn("flgpagotarjeta") ? drd["flgpagotarjeta"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagotarjeta"]) : false;
                            output.flgpagocheque = drd.HasColumn("flgpagocheque") ? drd["flgpagocheque"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagocheque"]) : false;
                            output.flgpagocredito = drd.HasColumn("flgpagocredito") ? drd["flgpagocredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagocredito"]) : false;
                            output.flgpagoncredito = drd.HasColumn("flgpagoncredito") ? drd["flgpagoncredito"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagoncredito"]) : false;
                            output.flgvalidaz = drd.HasColumn("flgvalidaz") ? drd["flgvalidaz"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgvalidaz"]) : false;
                            output.flgcierrezok = drd.HasColumn("flgcierrezok") ? drd["flgcierrezok"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgcierrezok"]) : false;
                            output.flghotkey = drd.HasColumn("flghotkey") ? drd["flghotkey"] == DBNull.Value ? false : Convert.ToBoolean(drd["flghotkey"]) : false;
                            output.flgfacturacion = drd.HasColumn("flgfacturacion") ? drd["flgfacturacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgfacturacion"]) : false;
                            output.grabarcliente = drd.HasColumn("grabarcliente") ? drd["grabarcliente"] == DBNull.Value ? false : Convert.ToBoolean(drd["grabarcliente"]) : false;
                            output.flgautomatica = drd.HasColumn("flgautomatica") ? drd["flgautomatica"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgautomatica"]) : false;
                            output.flgaperturacaja = drd.HasColumn("flgaperturacaja") ? drd["flgaperturacaja"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgaperturacaja"]) : false;
                            output.flgpagoefectivo = drd.HasColumn("flgpagoefectivo") ? drd["flgpagoefectivo"] == DBNull.Value ? false : Convert.ToBoolean(drd["flgpagoefectivo"]) : false;
                            output.modocompra = drd.HasColumn("modocompra") ? drd["modocompra"] == DBNull.Value ? false : Convert.ToBoolean(drd["modocompra"]) : false;
                            output.modservicio = drd.HasColumn("modservicio") ? drd["modservicio"] == DBNull.Value ? false : Convert.ToBoolean(drd["modservicio"]) : false;
                            output.modobservacion = drd.HasColumn("modobservacion") ? drd["modobservacion"] == DBNull.Value ? false : Convert.ToBoolean(drd["modobservacion"]) : false;
                            output.moddsctogral = drd.HasColumn("moddsctogral") ? drd["moddsctogral"] == DBNull.Value ? false : Convert.ToBoolean(drd["moddsctogral"]) : false;
                            output.moddsctoitem = drd.HasColumn("moddsctoitem") ? drd["moddsctoitem"] == DBNull.Value ? false : Convert.ToBoolean(drd["moddsctoitem"]) : false;
                            output.preciocero = drd.HasColumn("preciocero") ? drd["preciocero"] == DBNull.Value ? false : Convert.ToBoolean(drd["preciocero"]) : false;
                            output.modfecha = drd.HasColumn("modfecha") ? drd["modfecha"] == DBNull.Value ? false : Convert.ToBoolean(drd["modfecha"]) : false;
                            output.modmoneda = drd.HasColumn("modmoneda") ? drd["modmoneda"] == DBNull.Value ? false : Convert.ToBoolean(drd["modmoneda"]) : false;
                            output.modvendedor = drd.HasColumn("modvendedor") ? drd["modvendedor"] == DBNull.Value ? false : Convert.ToBoolean(drd["modvendedor"]) : false;
                            output.modalmacen = drd.HasColumn("modalmacen") ? drd["modalmacen"] == DBNull.Value ? false : Convert.ToBoolean(drd["modalmacen"]) : false;
                            output.modlistap = drd.HasColumn("modlistap") ? drd["modlistap"] == DBNull.Value ? false : Convert.ToBoolean(drd["modlistap"]) : false;
                            output.modprecio = drd.HasColumn("modprecio") ? drd["modprecio"] == DBNull.Value ? false : Convert.ToBoolean(drd["modprecio"]) : false;
                            output.nrozeta = drd.HasColumn("nrozeta") ? drd["nrozeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrozeta"]) : (decimal?)null;
                            output.mtozeta = drd.HasColumn("mtozeta") ? drd["mtozeta"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtozeta"]) : (decimal?)null;
                            output.ticketfeed = drd.HasColumn("ticketfeed") ? drd["ticketfeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticketfeed"]) : (decimal?)null;
                            output.ticketlineacorte = drd.HasColumn("ticketlineacorte") ? drd["ticketlineacorte"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticketlineacorte"]) : (decimal?)null;
                            output.ticket2columnas = drd.HasColumn("ticket2columnas") ? drd["ticket2columnas"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["ticket2columnas"]) : (decimal?)null;
                            output.nventafeed = drd.HasColumn("nventafeed") ? drd["nventafeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nventafeed"]) : (decimal?)null;
                            output.promocionfeed = drd.HasColumn("promocionfeed") ? drd["promocionfeed"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["promocionfeed"]) : (decimal?)null;
                            output.mtodsctomax = drd.HasColumn("mtodsctomax") ? drd["mtodsctomax"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["mtodsctomax"]) : (decimal?)null;
                            output.turno = drd.HasColumn("turno") ? drd["turno"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["turno"]) : (decimal?)null;
                            output.tranvirtual = drd.HasColumn("tranvirtual") ? drd["tranvirtual"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["tranvirtual"]) : (decimal?)null;
                            output.nrodeposito = drd.HasColumn("nrodeposito") ? drd["nrodeposito"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(drd["nrodeposito"]) : (decimal?)null;
                            output.facturaimpre = drd.HasColumn("facturaimpre") ? drd["facturaimpre"] == DBNull.Value ? null : drd["facturaimpre"].ToString() : null;
                            output.boletaimpre = drd.HasColumn("boletaimpre") ? drd["boletaimpre"] == DBNull.Value ? null : drd["boletaimpre"].ToString() : null;
                            output.gavetachr = drd.HasColumn("gavetachr") ? drd["gavetachr"] == DBNull.Value ? null : drd["gavetachr"].ToString() : null;
                            output.promocionimpre = drd.HasColumn("promocionimpre") ? drd["promocionimpre"] == DBNull.Value ? null : drd["promocionimpre"].ToString() : null;
                            output.ncreditoimpre = drd.HasColumn("ncreditoimpre") ? drd["ncreditoimpre"] == DBNull.Value ? null : drd["ncreditoimpre"].ToString() : null;
                            output.ndebitoimpre = drd.HasColumn("ndebitoimpre") ? drd["ndebitoimpre"] == DBNull.Value ? null : drd["ndebitoimpre"].ToString() : null;
                            output.guiaimpre = drd.HasColumn("guiaimpre") ? drd["guiaimpre"] == DBNull.Value ? null : drd["guiaimpre"].ToString() : null;
                            output.proformaimpre = drd.HasColumn("proformaimpre") ? drd["proformaimpre"] == DBNull.Value ? null : drd["proformaimpre"].ToString() : null;
                            output.letraimpre = drd.HasColumn("letraimpre") ? drd["letraimpre"] == DBNull.Value ? null : drd["letraimpre"].ToString() : null;
                            output.path_loteria = drd.HasColumn("path_loteria") ? drd["path_loteria"] == DBNull.Value ? null : drd["path_loteria"].ToString() : null;
                            output.fe_nompos = drd.HasColumn("fe_nompos") ? drd["fe_nompos"] == DBNull.Value ? null : drd["fe_nompos"].ToString() : null;
                            output.nropos = drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? null : drd["nropos"].ToString() : null;
                            output.cdusuario = drd.HasColumn("cdusuario") ? drd["cdusuario"] == DBNull.Value ? null : drd["cdusuario"].ToString() : null;
                            output.seriehd = drd.HasColumn("seriehd") ? drd["seriehd"] == DBNull.Value ? null : drd["seriehd"].ToString() : null;
                            output.nroseriemaq = drd.HasColumn("nroseriemaq") ? drd["nroseriemaq"] == DBNull.Value ? null : drd["nroseriemaq"].ToString() : null;
                            output.nroserie1 = drd.HasColumn("nroserie1") ? drd["nroserie1"] == DBNull.Value ? null : drd["nroserie1"].ToString() : null;
                            output.nroserie2 = drd.HasColumn("nroserie2") ? drd["nroserie2"] == DBNull.Value ? null : drd["nroserie2"].ToString() : null;
                            output.tipoterminal = drd.HasColumn("tipoterminal") ? drd["tipoterminal"] == DBNull.Value ? null : drd["tipoterminal"].ToString() : null;
                            output.ticketfactura = drd.HasColumn("ticketfactura") ? drd["ticketfactura"] == DBNull.Value ? null : drd["ticketfactura"].ToString() : null;
                            output.ncreditoboleta = drd.HasColumn("ncreditoboleta") ? drd["ncreditoboleta"] == DBNull.Value ? null : drd["ncreditoboleta"].ToString() : null;
                            output.ndebitoboleta = drd.HasColumn("ndebitoboleta") ? drd["ndebitoboleta"] == DBNull.Value ? null : drd["ndebitoboleta"].ToString() : null;
                            output.guiafmt = drd.HasColumn("guiafmt") ? drd["guiafmt"] == DBNull.Value ? null : drd["guiafmt"].ToString() : null;
                            output.proforma = drd.HasColumn("proforma") ? drd["proforma"] == DBNull.Value ? null : drd["proforma"].ToString() : null;
                            output.proformafmt = drd.HasColumn("proformafmt") ? drd["proformafmt"] == DBNull.Value ? null : drd["proformafmt"].ToString() : null;
                            output.letra = drd.HasColumn("letra") ? drd["letra"] == DBNull.Value ? null : drd["letra"].ToString() : null;
                            output.letrafmt = drd.HasColumn("letrafmt") ? drd["letrafmt"] == DBNull.Value ? null : drd["letrafmt"].ToString() : null;
                            output.displayimpre = drd.HasColumn("displayimpre") ? drd["displayimpre"] == DBNull.Value ? null : drd["displayimpre"].ToString() : null;
                            output.promocionchrfin = drd.HasColumn("promocionchrfin") ? drd["promocionchrfin"] == DBNull.Value ? null : drd["promocionchrfin"].ToString() : null;
                            output.ncredito = drd.HasColumn("ncredito") ? drd["ncredito"] == DBNull.Value ? null : drd["ncredito"].ToString() : null;
                            output.ncreditofmt = drd.HasColumn("ncreditofmt") ? drd["ncreditofmt"] == DBNull.Value ? null : drd["ncreditofmt"].ToString() : null;
                            output.ndebito = drd.HasColumn("ndebito") ? drd["ndebito"] == DBNull.Value ? null : drd["ndebito"].ToString() : null;
                            output.ndebitofmt = drd.HasColumn("ndebitofmt") ? drd["ndebitofmt"] == DBNull.Value ? null : drd["ndebitofmt"].ToString() : null;
                            output.guia = drd.HasColumn("guia") ? drd["guia"] == DBNull.Value ? null : drd["guia"].ToString() : null;
                            output.nventaimpre = drd.HasColumn("nventaimpre") ? drd["nventaimpre"] == DBNull.Value ? null : drd["nventaimpre"].ToString() : null;
                            output.nventachrini = drd.HasColumn("nventachrini") ? drd["nventachrini"] == DBNull.Value ? null : drd["nventachrini"].ToString() : null;
                            output.nventachrfin = drd.HasColumn("nventachrfin") ? drd["nventachrfin"] == DBNull.Value ? null : drd["nventachrfin"].ToString() : null;
                            output.promocion = drd.HasColumn("promocion") ? drd["promocion"] == DBNull.Value ? null : drd["promocion"].ToString() : null;
                            output.promocionfmt = drd.HasColumn("promocionfmt") ? drd["promocionfmt"] == DBNull.Value ? null : drd["promocionfmt"].ToString() : null;
                            output.promocionchrini = drd.HasColumn("promocionchrini") ? drd["promocionchrini"] == DBNull.Value ? null : drd["promocionchrini"].ToString() : null;
                            output.gavetaimpre = drd.HasColumn("gavetaimpre") ? drd["gavetaimpre"] == DBNull.Value ? null : drd["gavetaimpre"].ToString() : null;
                            output.ticket = drd.HasColumn("ticket") ? drd["ticket"] == DBNull.Value ? null : drd["ticket"].ToString() : null;
                            output.ticketimpre = drd.HasColumn("ticketimpre") ? drd["ticketimpre"] == DBNull.Value ? null : drd["ticketimpre"].ToString() : null;
                            output.ticketchrini = drd.HasColumn("ticketchrini") ? drd["ticketchrini"] == DBNull.Value ? null : drd["ticketchrini"].ToString() : null;
                            output.ticketchrfin = drd.HasColumn("ticketchrfin") ? drd["ticketchrfin"] == DBNull.Value ? null : drd["ticketchrfin"].ToString() : null;
                            output.nventa = drd.HasColumn("nventa") ? drd["nventa"] == DBNull.Value ? null : drd["nventa"].ToString() : null;
                            output.cdalmacen = drd.HasColumn("cdalmacen") ? drd["cdalmacen"] == DBNull.Value ? null : drd["cdalmacen"].ToString() : null;
                            output.cdprecio = drd.HasColumn("cdprecio") ? drd["cdprecio"] == DBNull.Value ? null : drd["cdprecio"].ToString() : null;
                            output.factura = drd.HasColumn("factura") ? drd["factura"] == DBNull.Value ? null : drd["factura"].ToString() : null;
                            output.facturafmt = drd.HasColumn("facturafmt") ? drd["facturafmt"] == DBNull.Value ? null : drd["facturafmt"].ToString() : null;
                            output.boleta = drd.HasColumn("boleta") ? drd["boleta"] == DBNull.Value ? null : drd["boleta"].ToString() : null;
                            output.boletafmt = drd.HasColumn("boletafmt") ? drd["boletafmt"] == DBNull.Value ? null : drd["boletafmt"].ToString() : null;
                            output.generapdf = drd.HasColumn("generapdf") ? drd["generapdf"] == DBNull.Value ? false : Convert.ToBoolean(drd["generapdf"]) : false;
                            output.rutaservicio = drd.HasColumn("rutaservicio") ? drd["rutaservicio"] == DBNull.Value ? "" : drd["rutaservicio"].ToString() : "";
                            output.cierrexfmt = drd.HasColumn("cierrexfmt") ? drd["cierrexfmt"] == DBNull.Value ? "" : drd["cierrexfmt"].ToString() : "";
                            output.cierrezfmt = drd.HasColumn("cierrezfmt") ? drd["cierrezfmt"] == DBNull.Value ? "" : drd["cierrezfmt"].ToString() : "";
                            output.nventafmt = drd.HasColumn("nventafmt") ? drd["nventafmt"] == DBNull.Value ? "" : drd["nventafmt"].ToString() : "";
                            output.serafinfmt = drd.HasColumn("serafinfmt") ? drd["serafinfmt"] == DBNull.Value ? "" : drd["serafinfmt"].ToString() : "";
                            output.depositofmt = drd.HasColumn("depositofmt") ? drd["depositofmt"] == DBNull.Value ? "" : drd["depositofmt"].ToString() : "";
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
            return output;
        }

        public List<TS_BENropos> SP_ITBCP_LISTAR_NROPOS()
        {
            List<TS_BENropos> output = new List<TS_BENropos>();
            using (SqlConnection con = new SqlConnection(stringBackOffice))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ITBCP_LISTAR_TERMINAL_NROPOS", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader drd = cmd.ExecuteReader())
                    {
                        while (drd.Read())
                        {
                            
                            string pos = (drd.HasColumn("nropos") ? drd["nropos"] == DBNull.Value ? "" : drd["nropos"].ToString() : "").Trim();
                            string serie = (drd.HasColumn("seriehd") ? drd["seriehd"] == DBNull.Value ? "" : drd["seriehd"].ToString() : "").Trim();
                            if (String.IsNullOrEmpty(pos) == false)
                            {
                                TS_BENropos terminal = new TS_BENropos()
                                {
                                    nropos = pos,
                                    seriehd = serie

                                };
                                output.Add(terminal);
                            }  
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
            return output;
        }
    }
}
