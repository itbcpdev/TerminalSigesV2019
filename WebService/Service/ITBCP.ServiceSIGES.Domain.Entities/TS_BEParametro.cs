using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
	[DataContract]
	//ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
	//Creado por     : Ronald Noé Saavedra Bances (28/01/2019)
	//ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
	/// <summary> Entidad = Parametro</summary>
	///
	public class TS_BEParametro
	{

		[DataMember]
		public byte? tipocierrextienda { get; set; }

		[DataMember]
		public byte? cursor_tienda { get; set; }

		[DataMember]
		public byte? repite_articulo { get; set; }

		[DataMember]
		public byte? imprime_canjeweb { get; set; }

		[DataMember]
		public byte? imprime_ptosacumulados { get; set; }

		[DataMember]
		public byte? tarjeta_actu_cdcliente { get; set; }

		[DataMember]
		public byte? cierre_kardex { get; set; }

		[DataMember]
		public byte? noconectawpuntos { get; set; }

		[DataMember]
		public byte? cierrex_formatos { get; set; }

		[DataMember]
		public byte? imprime_fact_playa { get; set; }

		[DataMember]
		public byte? credplaca { get; set; }

		[DataMember]
		public byte? cierre_especial { get; set; }

		[DataMember]
		public byte? parte_tienda { get; set; }

		[DataMember]
		public byte? flg_desc_prefijo { get; set; }

		[DataMember]
		public byte? imprimir_cdarticulo_config { get; set; }

		[DataMember]
		public byte? mostrar_igv_pantalla { get; set; }

		[DataMember]
		public byte? tipo_menu { get; set; }

		[DataMember]
		public byte? nd_playa { get; set; }

		[DataMember]
		public byte? valida_cdarticulo { get; set; }

		[DataMember]
		public byte? conf_cierrex { get; set; }

		[DataMember]
		public byte? boton_transfer_gratuita { get; set; }

		[DataMember]
		public byte? tienda_cant_neg { get; set; }

		[DataMember]
		public byte? imprime_tiketera { get; set; }

		[DataMember]
		public byte? imprime_nvta { get; set; }

		[DataMember]
		public byte? modifica_depositos_parte { get; set; }

		[DataMember]
		public byte? mostrar_local_gastos { get; set; }

		[DataMember]
		public int? cantdigitos_tarjpromo { get; set; }

		[DataMember]
		public int galones_decimales { get; set; }

		[DataMember]
		public int? tiendagazel { get; set; }

		[DataMember]
		public int? terminalserver { get; set; }

		[DataMember]
		public int? rango_valfecpos { get; set; }

		[DataMember]
		public int? nro_caracteres_rsocial { get; set; }

		[DataMember]
		public int? valida_fecha_playa { get; set; }

		[DataMember]
		public int? impr_veces_nd { get; set; }

		[DataMember]
		public int? impr_veces_fac { get; set; }

		[DataMember]
		public int? impr_veces_bol { get; set; }

		[DataMember]
		public DateTime? fecinstall { get; set; }

		[DataMember]
		public bool? flgtalla { get; set; }

		[DataMember]
		public bool? flgformula { get; set; }

		[DataMember]
		public bool? precioconigv { get; set; }

		[DataMember]
		public bool? precioconservicio { get; set; }

		[DataMember]
		public bool? utilidadcosto { get; set; }

		[DataMember]
		public bool? flgintegrador { get; set; }

		[DataMember]
		public bool? flg_imprimirnd_menos5s { get; set; }

		[DataMember]
		public bool? flg_ocultarvta_menos5s { get; set; }

		[DataMember]
		public bool? flg_noaplica_desc_tarj { get; set; }

		[DataMember]
		public bool? flg_activar_clientes_varios { get; set; }

		[DataMember]
		public bool? flg_print_qr { get; set; }

		[DataMember]
		public bool? flg_repx_terminal { get; set; }

		[DataMember]
		public bool? flg_cliente_automatico { get; set; }

		[DataMember]
		public bool? desactivar_foxypreviewer { get; set; }

		[DataMember]
		public bool? flg_notas_multiref { get; set; }

		[DataMember]
		public bool? flg_afectarcosto_fletecompras { get; set; }

		[DataMember]
		public bool? flg_btn_credito_playa { get; set; }

		[DataMember]
		public bool? flg_validateclas_cdcliente { get; set; }

		[DataMember]
		public bool? flg_activa_ti_todosprod { get; set; }

		[DataMember]
		public bool? flg_boton_promo { get; set; }

		[DataMember]
		public bool? flg_gastos_playa { get; set; }

		[DataMember]
		public bool? flg_ocultar_campos_tck { get; set; }

		[DataMember]
		public bool? flg_credito_centralizado { get; set; }

		[DataMember]
		public bool? flgsoloterminal { get; set; }

		[DataMember]
		public bool? flg_round_dec_indecopi { get; set; }

		[DataMember]
		public bool? flg_round_indecopi_1_9 { get; set; }

		[DataMember]
		public bool? flg_kardex_unalinea { get; set; }

		[DataMember]
		public bool? flg_facturacion_automatica { get; set; }

		[DataMember]
		public bool? flg_modo_fact { get; set; }

		[DataMember]
		public bool? label_bellavista { get; set; }

		[DataMember]
		public bool? nd_imp_saldoyconsumo { get; set; }

		[DataMember]
		public bool? flg_valida_fecproce_dia { get; set; }

		[DataMember]
		public bool? flg_canjend { get; set; }

		[DataMember]
		public bool? flg_nrodias { get; set; }

		[DataMember]
		public bool? flg_nc_liberand { get; set; }

		[DataMember]
		public bool? flg_transfer_gratuita_cero { get; set; }

		[DataMember]
		public bool? flg_fecsrv { get; set; }

		[DataMember]
		public bool? flg_pideodometro { get; set; }

		[DataMember]
		public bool? flg_valdscto { get; set; }

		[DataMember]
		public bool? flg_pideclavecred { get; set; }

		[DataMember]
		public bool? flg_anula_easytaxi { get; set; }

		[DataMember]
		public bool? conigv { get; set; }

		[DataMember]
		public bool? flg_pideplacatb { get; set; }

		[DataMember]
		public bool? activa_repro_stock { get; set; }

		[DataMember]
		public bool? flg_valfecpos { get; set; }

		[DataMember]
		public bool? flg_anulapos { get; set; }

		[DataMember]
		public bool? activa_elsol { get; set; }

		[DataMember]
		public bool? flg_boton_facturacionmanual { get; set; }

		[DataMember]
		public bool? mostrar_ptos_ganados { get; set; }

		[DataMember]
		public bool? activa_formas_pago { get; set; }

		[DataMember]
		public bool? flg_pideplaca { get; set; }

		[DataMember]
		public bool? depositos_playa { get; set; }

		[DataMember]
		public bool? flg_botoncredito { get; set; }

		[DataMember]
		public bool? flg_nobuscar_nombre { get; set; }

		[DataMember]
		public bool? consulta_sunat { get; set; }

		[DataMember]
		public bool? clubgazel { get; set; }

		[DataMember]
		public bool? activa_camedi { get; set; }

		[DataMember]
		public bool? tarjeta_mascara { get; set; }

		[DataMember]
		public bool? flgruta { get; set; }

		[DataMember]
		public bool? flg_prefij_seriesdoc { get; set; }

		[DataMember]
		public bool? mostrar_articulo_kardex { get; set; }

		[DataMember]
		public bool? flg_botontiendaenplaya { get; set; }

		[DataMember]
		public bool? valida_correlativo { get; set; }

		[DataMember]
		public bool? flg_invent_fisicoteorico { get; set; }

		[DataMember]
		public bool? punto_nd { get; set; }

		[DataMember]
		public bool? cancelado { get; set; }

		[DataMember]
		public bool? correlativos2_ticket { get; set; }

		[DataMember]
		public bool? chkclientedia { get; set; }

		[DataMember]
		public bool? escirsa { get; set; }

		[DataMember]
		public bool? flgcierraturnoxcaja { get; set; }

		[DataMember]
		public bool? activadispensador { get; set; }

		[DataMember]
		public bool? cambioturno { get; set; }

		[DataMember]
		public bool? iniciodia { get; set; }

		[DataMember]
		public bool? pd_separaglp { get; set; }

		[DataMember]
		public bool? flgvalida_nrovale { get; set; }

		[DataMember]
		public bool? arequipa { get; set; }

		[DataMember]
		public bool? pantalland_cliprintnd { get; set; }

		[DataMember]
		public bool? imprime_total_dispensado { get; set; }

		[DataMember]
		public bool? imprime_clientes_credito { get; set; }

		[DataMember]
		public bool? triveno { get; set; }

		[DataMember]
		public bool? activasawa { get; set; }

		[DataMember]
		public bool? desanular { get; set; }

		[DataMember]
		public bool? flgsistema03 { get; set; }

		[DataMember]
		public bool? flgcontometro { get; set; }

		[DataMember]
		public bool? flgsolotienda { get; set; }

		[DataMember]
		public bool? flgmostrar_precio_orig { get; set; }

		[DataMember]
		public bool? vertiposventa { get; set; }

		[DataMember]
		public bool? redondeasolescombus { get; set; }

		[DataMember]
		public bool? bloqventaplaya { get; set; }

		[DataMember]
		public bool? saltoauto { get; set; }

		[DataMember]
		public bool? tarjcredplaca { get; set; }

		[DataMember]
		public bool? flgprintndespacho { get; set; }

		[DataMember]
		public bool? flgsistema01 { get; set; }

		[DataMember]
		public bool? flgsistema02 { get; set; }

		[DataMember]
		public bool? stknegativo { get; set; }

		[DataMember]
		public bool? conexiondispensador { get; set; }

		[DataMember]
		public bool? flggrifo { get; set; }

		[DataMember]
		public bool? zenpantalla { get; set; }

		[DataMember]
		public bool? flgcreaprodmov { get; set; }

		[DataMember]
		public bool? flgvalidaruc { get; set; }

		[DataMember]
		public decimal? coloron { get; set; }

		[DataMember]
		public decimal? coloroff { get; set; }

		[DataMember]
		public decimal? colorgrid { get; set; }

		[DataMember]
		public decimal? impuesto { get; set; }

		[DataMember]
		public decimal? porservicio { get; set; }

		[DataMember]
		public decimal? nropago { get; set; }

		[DataMember]
		public decimal? nroinventario { get; set; }

		[DataMember]
		public decimal? mto_facturacion_automatica { get; set; }

		[DataMember]
		public decimal? redondeo { get; set; }

		[DataMember]
		public decimal? mtominimodni_sunat { get; set; }

		[DataMember]
		public decimal? mtominideposito { get; set; }

		[DataMember]
		public decimal? valorigv { get; set; }

		[DataMember]
		public decimal? colum_termica { get; set; }

		[DataMember]
		public decimal? mtominimodetraccion { get; set; }

		[DataMember]
		public decimal? mtominimodni { get; set; }

		[DataMember]
		public decimal? mtominautomatico { get; set; }

		[DataMember]
		public decimal? mtocupon { get; set; }

		[DataMember]
		public decimal? modifica_precio_tienda { get; set; }

		[DataMember]
		public decimal? precio_varios { get; set; }

		[DataMember]
		public decimal? diasresetptos { get; set; }

		[DataMember]
		public decimal? cant_turno { get; set; }

		[DataMember]
		public decimal? ptobonus { get; set; }

		[DataMember]
		public decimal? intervaltimer { get; set; }

		[DataMember]
		public decimal? minutosxtktbol { get; set; }

		[DataMember]
		public decimal? nrodeposito { get; set; }

		[DataMember]
		public decimal? longtarjeta { get; set; }

		[DataMember]
		public decimal? nrocdbarra { get; set; }

		[DataMember]
		public decimal? digitoruc { get; set; }

		[DataMember]
		public decimal? nrocara { get; set; }

		[DataMember]
		public decimal? nrotransgasboy { get; set; }

		[DataMember]
		public decimal? digitocdcliente { get; set; }

		[DataMember]
		public decimal? porcipm { get; set; }

		[DataMember]
		public string versionbo { get; set; }

		[DataMember]
		public string versiontinven { get; set; }

		[DataMember]
		public string versionplaya { get; set; }

		[DataMember]
		public string versiontienda { get; set; }

		[DataMember]
		public string ruta_backup { get; set; }

		[DataMember]
		public string valorcanje_regvta { get; set; }

		[DataMember]
		public string passwordweb { get; set; }

		[DataMember]
		public string ruta_qr_jpg { get; set; }

		[DataMember]
		public string mto_desc_descripcion { get; set; }

		[DataMember]
		public string cdcliente_automatico { get; set; }

		[DataMember]
		public string rscliente_automatico { get; set; }

		[DataMember]
		public string msg_anula_documento { get; set; }

		[DataMember]
		public string nroversiontienda { get; set; }

		[DataMember]
		public string nroversionti { get; set; }

		[DataMember]
		public string conexionweb { get; set; }

		[DataMember]
		public string instanciaweb { get; set; }

		[DataMember]
		public string bdweb { get; set; }

		[DataMember]
		public string userweb { get; set; }

		[DataMember]
		public string ruta_ws_easytaxy { get; set; }

		[DataMember]
		public string cod_viatico { get; set; }

		[DataMember]
		public string horacierrepd { get; set; }

		[DataMember]
		public string interfaz { get; set; }

		[DataMember]
		public string nroversionbo { get; set; }

		[DataMember]
		public string nroversionplaya { get; set; }

		[DataMember]
		public string facturaimpre_c { get; set; }

		[DataMember]
		public string facturafmt_c { get; set; }

		[DataMember]
		public string tpsalmerma { get; set; }

		[DataMember]
		public string tpsaldev { get; set; }

		[DataMember]
		public string ruta_websaldos { get; set; }

		[DataMember]
		public string ruta_webclubgazel { get; set; }

		[DataMember]
		public string monsistema { get; set; }

		[DataMember]
		public string monticket { get; set; }

		[DataMember]
		public string tpsalida { get; set; }

		[DataMember]
		public string tpingreso { get; set; }

		[DataMember]
		public string masccantidad { get; set; }

		[DataMember]
		public string masccantidadf { get; set; }

		[DataMember]
		public string cdalmacen { get; set; }

		[DataMember]
		public string prefflotlocal { get; set; }

		[DataMember]
		public string fe_fecvalida { get; set; }

		[DataMember]
		public string tppgogasto { get; set; }

		[DataMember]
		public string flg_invent_2 { get; set; }

		[DataMember]
		public string cddepart_base { get; set; }

		[DataMember]
		public string factura_c { get; set; }

		[DataMember]
		public string guia { get; set; }

		[DataMember]
		public string guiaimpr { get; set; }

		[DataMember]
		public string guiafmt { get; set; }

		[DataMember]
		public string tipo_canje { get; set; }

		[DataMember]
		public string cdtipodocautomatico { get; set; }

		[DataMember]
		public string cdclienteautomatico { get; set; }

		[DataMember]
		public string tipoafiliacion { get; set; }

		[DataMember]
		public string tipoptoafiliacion { get; set; }

		[DataMember]
		public string seriehd_imprime_ticket_web { get; set; }

		[DataMember]
		public string notad_cdarticulo { get; set; }

		[DataMember]
		public string cd_estacion { get; set; }

		[DataMember]
		public string tptransftienda { get; set; }

		[DataMember]
		public string lin1display { get; set; }

		[DataMember]
		public string lin2display { get; set; }

		[DataMember]
		public string tipocontrol { get; set; }

		[DataMember]
		public string cdcliprintndespacho { get; set; }

		[DataMember]
		public string tppgocanje { get; set; }

		[DataMember]
		public string prefcredlocal { get; set; }

		[DataMember]
		public string prefcredcorp { get; set; }

		[DataMember]
		public string prefbonus { get; set; }

		[DataMember]
		public string cdestacion { get; set; }

		[DataMember]
		public string nivelserafin { get; set; }

		[DataMember]
		public string cdgrupovtaplaya { get; set; }

		[DataMember]
		public string tpguiatransferencia { get; set; }

		[DataMember]
		public string nrovale { get; set; }

		[DataMember]
		public string cdletrainicial { get; set; }

		[DataMember]
		public string nroimportacion { get; set; }

		[DataMember]
		public string tpingimportacion { get; set; }

		[DataMember]
		public string tpanulacion { get; set; }

		[DataMember]
		public string tpinicial { get; set; }

		[DataMember]
		public string tptransferencia { get; set; }

		[DataMember]
		public string tptransferenciainterna { get; set; }

		[DataMember]
		public string cdlocal { get; set; }

		[DataMember]
		public string cdgrupocombustible { get; set; }

		[DataMember]
		public string mascprecio { get; set; }

		[DataMember]
		public string masccosto { get; set; }

		[DataMember]
		public string masctotal { get; set; }

		[DataMember]
		public string tpcompra { get; set; }

		[DataMember]
		public string nrocompra { get; set; }

		[DataMember]
		public string tpcambiotalla { get; set; }

		[DataMember]
		public string bbddsetup { get; set; }

	}
}
