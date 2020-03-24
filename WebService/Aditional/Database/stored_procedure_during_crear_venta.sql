--USE [backoffice]
--GO

IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_VENTAG]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_VENTAG] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_VENTAG] 
    @cdlocal char(3),
    @nroseriemaq char(15),
    @cdtipodoc char(5),
    @nrodocumento char(10),
    @fecdocumento smalldatetime = NULL,
    @fecproceso smalldatetime = NULL,
    @fecanula smalldatetime = NULL,
    @fecanulasis smalldatetime = NULL,
    @nropos char(10) = NULL,
    @cdcliente char(15) = NULL,
    @declarado bit = NULL,
    @anulado bit = NULL
AS 
	
	INSERT INTO ventag ([cdlocal], [nroseriemaq], [cdtipodoc], [nrodocumento], [fecdocumento], [fecproceso], [fecanula], [fecanulasis], [nropos], [cdcliente], [declarado], [anulado])
	SELECT @cdlocal, @nroseriemaq, @cdtipodoc, @nrodocumento, @fecdocumento, @fecproceso, @fecanula, @fecanulasis, @nropos, @cdcliente, @declarado, @anulado

GO

IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_VENTAR]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_VENTAR] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_VENTAR] 
    @cdlocal char(3),
    @fecdocumento smalldatetime,
    @fecproceso smalldatetime
AS 
	
	IF NOT EXISTS (SELECT * FROM ventar WHERE cdlocal = @cdlocal AND fecdocumento = @fecdocumento AND fecproceso = @fecproceso)
	BEGIN
		INSERT INTO ventar ([cdlocal], [fecdocumento], [fecproceso])
		SELECT @cdlocal, @fecdocumento, @fecproceso
	END
	ELSE
	BEGIN
		UPDATE ventar SET cdlocal = @cdlocal, fecdocumento = @fecdocumento, fecproceso = @fecproceso
		WHERE cdlocal = @cdlocal AND fecdocumento = @fecdocumento AND fecproceso = @fecproceso
	END	
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_DISMINUIR_CREDITO_ACTUALIZAR]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_DISMINUIR_CREDITO_ACTUALIZAR] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_DISMINUIR_CREDITO_ACTUALIZAR] 
    @cdcliente char(20),
    @mtodisminuir numeric(13, 2) = NULL
AS 

	UPDATE cliente
	SET    mtodisponible = mtodisponible - @mtodisminuir
	WHERE  [cdcliente] = @cdcliente	
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_ACTUALIZAR_VALES_DE_CREDITO]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_ACTUALIZAR_VALES_DE_CREDITO] 
END 
GO

CREATE PROC [dbo].[SP_ITBCP_ACTUALIZAR_VALES_DE_CREDITO] 
    @nrovale char(10),
    @fecvale smalldatetime = NULL,
    @cdmoneda char(1) = NULL,
    @mtovale numeric(12, 2) = NULL,
    @cdcliente char(15) = NULL,
    @nroplaca char(10) = NULL,
    @nroseriemaq char(15) = NULL,
    @cdtipodoc char(5) = NULL,
    @nrodocumento char(10) = NULL,
    @fecdocumento smalldatetime = NULL,
    @fecproceso smalldatetime = NULL,
    @nroseriemaqfac char(15) = NULL,
    @cdtipodocfac char(5) = NULL,
    @nrodocumentofac char(10) = NULL,
    @fecdocumentofac smalldatetime = NULL,
    @fecprocesofac smalldatetime = NULL,
    @placa char(10) = NULL,
    @turno numeric(2, 0) = NULL,
    @archturno bit = NULL,
    @docvale char(10) = NULL
AS 

	UPDATE hvale
	SET    [fecvale] = @fecvale, 
	[cdmoneda] = @cdmoneda, 
	[mtovale] = @mtovale, 
	[cdcliente] = @cdcliente, 
	[nroplaca] = @nroplaca, 
	[nroseriemaq] = @nroseriemaq, 
	[cdtipodoc] = @cdtipodoc, 
	[nrodocumento] = @nrodocumento, 
	[fecdocumento] = @fecdocumento, 
	[fecproceso] = @fecproceso, 
	[nroseriemaqfac] = @nroseriemaqfac, 
	[cdtipodocfac] = @cdtipodocfac, 
	[nrodocumentofac] = @nrodocumentofac, 
	[fecdocumentofac] = @fecdocumentofac, 
	[fecprocesofac] = @fecprocesofac, 
	[placa] = @placa, 
	[turno] = @turno, 
	[archturno] = @archturno, 
	[docvale] = @docvale
	WHERE  [nrovale] = @nrovale And (cdtipodocfac IS NULL or LTRIM(RTRIM(cdtipodocfac))=''
			OR nrodocumentofac IS NULL OR LTRIM(RTRIM(nrodocumentofac))='')
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_CREDITO_CLIENTE]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_CREDITO_CLIENTE] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_CREDITO_CLIENTE]     
    @cdtipodoc char(5),
    @nrodocumento char(10),
    @nropos char(10) = NULL,
    @cdlocal char(3) = NULL,
    @cdalmacen char(3) = NULL,
    @fecdocumento smalldatetime = NULL,
    @fecvencimiento smalldatetime = NULL,
	@fecsistema smalldatetime = NULL,
    @cdcliente char(20) = NULL,
	@cdmoneda char(1) = NULL,
	@mtototal numeric(12, 2) = NULL,
    @mtoemision numeric(12, 2) = NULL,
	@mtosoles numeric(12, 2) = NULL,
	@tcambio numeric(10, 6) = NULL,
	@cdvendedor char(10) = NULL,
	@fecproceso smalldatetime = NULL
AS 
	
	INSERT INTO credcliente ([docpago], [cdtipodoc], [nrodocumento], [renovacion], [nropos], [cdlocal], [cdalmacen], [fecdocumento], [fecvencimiento], [fecsistema], [cdcliente], [cdmoneda], [mtototal], [mtoemision], [mtosoles], [mtodolares], [tcambio], [cdvendedor], [nropago], [fecproceso])
	SELECT 'D', @cdtipodoc, @nrodocumento, '', @nropos, @cdlocal, @cdalmacen, @fecdocumento, @fecvencimiento, @fecsistema, @cdcliente, @cdmoneda, @mtototal, @mtoemision, @mtosoles, @mtosoles * @tcambio, @tcambio, @cdvendedor, 0, @fecproceso
	
GO


IF OBJECT_ID('[dbo].[SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA] 
	@TarjAfiliacion char(20),
    @Canjeado numeric(11, 0) = NULL,
    @Disponible numeric(11, 0) = NULL
AS 
	UPDATE AfiliacionTarj
	SET    [Canjeado] = [Canjeado] - @Canjeado, [Disponible] = [Disponible] - @Canjeado
	WHERE  [TarjAfiliacion] = @TarjAfiliacion AND bloqueado=0
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA_VALOR_ACUMULADO]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA_VALOR_ACUMULADO] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA_VALOR_ACUMULADO] 
	@TarjAfiliacion char(20),
    @Canjeado numeric(11, 0) = NULL
AS 
	UPDATE AfiliacionTarj
	SET    [valoracumula] = [valoracumula] - @Canjeado
	WHERE  [TarjAfiliacion] = @TarjAfiliacion AND bloqueado=0
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_AFILIACION_PUNTOS]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_AFILIACION_PUNTOS] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_AFILIACION_PUNTOS] 
    @cdlocal char(3),
    @TarjAfiliacion char(20),
    @tipo char(1),
    @nropos char(10),
    @cdtipodoc char(5),
    @nrodocumento char(10),
    @cdproducto char(20),
    @fecha datetime = NULL,
    @fecproceso smalldatetime = NULL,
    @total numeric(10, 2) = NULL,
    @cantidad numeric(10, 3) = NULL,
    @Puntos numeric(11, 0) = NULL,
    @Estado char(1) = NULL,
    @enviado bit = NULL,
    @canjeados numeric(12, 3) = NULL,
    @cdusuario char(10) = NULL,
    @TArjAfiliacion_Traspaso char(25) = NULL,
    @valoracumula numeric(18, 2) = NULL,
    @item tinyint = NULL
AS 
	
	INSERT INTO AfiliacionPtos ([cdlocal], [TarjAfiliacion], [tipo], [nropos], [cdtipodoc], [nrodocumento], [cdproducto], [fecha], [fecproceso], [total], [cantidad], [Puntos], [Estado], [enviado], [canjeados], [cdusuario], [TArjAfiliacion_Traspaso], [valoracumula], [item])
	SELECT @cdlocal, @TarjAfiliacion, @tipo, @nropos, @cdtipodoc, @nrodocumento, @cdproducto, @fecha, @fecproceso, @total, @cantidad, @Puntos, @Estado, @enviado, @canjeados, @cdusuario, @TArjAfiliacion_Traspaso, @valoracumula, @item
		
GO


IF OBJECT_ID('[dbo].[SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA_PUNTOS_GANADOS]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA_PUNTOS_GANADOS] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA_PUNTOS_GANADOS] 
	@TarjAfiliacion char(20),
	@Puntos numeric(11, 0) = NULL,
	@valoracumula numeric(18, 2) = NULL,
    @fechaultconsumo smalldatetime
AS 
	UPDATE AfiliacionTarj
	SET    [Puntos] = [Puntos] + @Puntos, 
	[Disponible] = [Disponible] + @Puntos,
	[valoracumula] = [valoracumula] + @valoracumula,
	[fechaultconsumo] = @fechaultconsumo
	WHERE  [TarjAfiliacion] = @TarjAfiliacion AND bloqueado=0
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_SELECT_PARAMETROS]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_SELECT_PARAMETROS] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_SELECT_PARAMETROS] 
AS 
	SELECT [cdlocal], [monsistema], [monticket], [tpsalida], [tpingreso], [coloron], [coloroff], [colorgrid], [masccantidad], [masccantidadf], [mascprecio], [masccosto], [masctotal], [impuesto], [flgtalla], [flgformula], [precioconigv], [precioconservicio], [porservicio], [fecinstall], [tpcompra], [nrocompra], [tpcambiotalla], [tpanulacion], [tpinicial], [tptransferencia], [tptransferenciainterna], [utilidadcosto], [flgintegrador], [nropago], [stknegativo], [nrocdbarra], [cdgrupocombustible], [cdgrupovtaplaya], [digitoruc], [conexiondispensador], [nrocara], [tpguiatransferencia], [flggrifo], [nrovale], [nrotransgasboy], [zenpantalla], [cdletrainicial], [nroimportacion], [digitocdcliente], [flgcreaprodmov], [porcipm], [tpingimportacion], [flgvalidaruc], [cant_turno], [tppgocanje], [prefcredlocal], [prefcredcorp], [prefbonus], [ptobonus], [bloqventaplaya], [cdestacion], [nivelserafin], [cd_estacion], [intervaltimer], [minutosxtktbol], [tptransftienda], [nrodeposito], [longtarjeta], [saltoauto], [lin1display], [lin2display], [tipocontrol], [mtominimodni], [tarjcredplaca], [flgprintndespacho], [cdcliprintndespacho], [cdtipodocautomatico], [cdclienteautomatico], [flgSistema01], [flgSistema02], [flgSistema03], [flgcontometro], [flgsolotienda], [mtominautomatico], [VERSIONBO], [VERSIONtInven], [VERSIONplaya], [VERSIONtienda], [flgmostrar_precio_orig], [VERTIPOSVENTA], [TipoAfiliacion], [TipoPtoAfiliacion], [CantDigitos_Tarjpromo], [redondeaSolesCombus], [TipoCierreXTienda], [Cursor_tienda], [repite_articulo], [mtocupon], [MOdifica_precio_tienda], [imprime_canjeweb], [precio_varios], [SerieHd_Imprime_Ticket_Web], [pantalland_cliprintnd], [imprime_total_dispensado], [imprime_ptosacumulados], [tarjeta_actu_cdcliente], [boton_transfer_gratuita], [imprime_clientes_credito], [tienda_cant_neg], [imprime_tiketera], [imprime_nvta], [Modifica_depositos_parte], [mostrar_local_gastos], [Notad_cdarticulo], [imprimir_cdarticulo_config], [Mostrar_IGV_Pantalla], [tipo_menu], [nd_playa], [valida_cdarticulo], [Conf_cierrex], [cierreX_formatos], [Imprime_fact_playa], [credplaca], [cierre_especial], [parte_tienda], [FLG_DESC_PREFIJO], [RUTA_BACKUP], [cierre_kardex], [valorcanje_regvta], [triveno], [activasawa], [desanular], [activadispensador], [cdDepart_base], [cambioturno], [iniciodia], [factura_c], [facturaimpre_c], [facturafmt_c], [pd_separaglp], [flgvalida_nrovale], [arequipa], [BBDDSETUP], [GUIA], [GUIAIMPR], [GUIAFMT], [punto_nd], [noconectawpuntos], [diasresetptos], [cancelado], [correlativos2_ticket], [chkclienteDia], [escirsa], [FLGCIERRATURNOXCAJA], [flgruta], [GALONES_DECIMALES], [flg_prefij_seriesdoc], [Mostrar_Articulo_Kardex], [tiendagazel], [tpsalmerma], [tpsaldev], [Redondeo], [terminalserver], [flg_BotonTiendaenPlaya], [Valida_Correlativo], [ruta_websaldos], [flg_invent_fisicoteorico], [flg_botoncredito], [flg_nobuscar_nombre], [consulta_sunat], [clubgazel], [ruta_webclubgazel], [activa_camedi], [tarjeta_mascara], [tipo_canje], [cdalmacen], [ruta_ws_easytaxy], [activa_elsol], [cod_viatico], [flg_boton_facturacionmanual], [mostrar_ptos_ganados], [activa_formas_pago], [mtominimodni_sunat], [flg_pideplaca], [depositos_playa], [flg_anula_easytaxi], [mtominideposito], [ConIGV], [ValorIGV], [flg_pideplacatb], [horacierrepd], [activa_repro_stock], [flg_valfecpos], [rango_valfecpos], [flg_anulapos], [flg_nc_liberand], [flg_transfer_gratuita_cero], [interfaz], [flg_fecsrv], [prefflotlocal], [flg_pideodometro], [fe_fecValida], [flg_valdscto], [tppgogasto], [flg_pideclavecred], [flg_modo_fact], [colum_termica], [Label_Bellavista], [mtominimodetraccion], [Nd_imp_saldoyconsumo], [nro_caracteres_rsocial], [valida_fecha_playa], [flg_valida_fecproce_dia], [impr_Veces_ND], [impr_Veces_fac], [impr_Veces_bol], [flg_canjend], [nroversionBO], [nroversionplaya], [nroversiontienda], [nroversionTI], [flg_nrodias], [flg_credito_centralizado], [flgsoloterminal], [flg_round_dec_indecopi], [flg_round_indecopi_1_9], [CONEXIONWEB], [INSTANCIAWEB], [BDWEB], [USERWEB], [PASSWORDWEB], [ruta_qr_jpg], [Mto_desc_Descripcion], [flg_kardex_unalinea], [nroinventario], [flg_invent_2], [flg_facturacion_automatica], [mto_facturacion_automatica], [flg_btn_credito_playa], [flg_validateclas_cdcliente], [flg_activa_TI_todosProd], [flg_boton_promo], [flg_gastos_playa], [flg_ocultar_campos_tck], [flg_print_qr], [flg_repx_terminal], [flg_cliente_automatico], [cdcliente_automatico], [rscliente_automatico], [Desactivar_FoxyPreviewer], [flg_notas_multiref], [flg_AfectarCosto_FleteCompras], [Msg_Anula_Documento], [flg_ImprimirND_Menos5S], [flg_OcultarVta_Menos5S], [flg_noaplica_desc_tarj], [flg_activar_clientes_varios] 
	FROM parametro
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_VENTA]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_VENTA] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_VENTA] 
    @cdlocal char(3),
    @nroseriemaq char(15),
    @cdtipodoc char(5),
    @nrodocumento char(10),
    @fecdocumento datetime = NULL,
    @fecproceso smalldatetime = NULL,
    @fecsistema datetime = NULL,
    @nropos char(10) = NULL,
    @mtovueltosol numeric(12, 4) = NULL,
    @mtovueltodol numeric(12, 4) = NULL,
    @cdalmacen char(3) = NULL,
    @cdcliente char(20) = NULL,
    @ruccliente char(15) = NULL,
    @rscliente char(120) = NULL,
    @nroproforma char(10) = NULL,
    @cdprecio char(5) = NULL,
    @cdmoneda char(1) = NULL,
    @porservicio numeric(6, 2) = NULL,
    @pordscto1 numeric(6, 2) = NULL,
    @pordscto2 numeric(6, 2) = NULL,
    @pordscto3 numeric(6, 2) = NULL,
    @pordsctoeq numeric(6, 2) = NULL,
    @mtonoafecto numeric(12, 4) = NULL,
    @valorvta numeric(12, 4) = NULL,
    @mtodscto numeric(12, 4) = NULL,
    @mtosubtotal numeric(12, 4) = NULL,
    @mtoservicio numeric(12, 4) = NULL,
    @mtoimpuesto numeric(12, 4) = NULL,
    @mtototal numeric(12, 4) = NULL,
    @cdtranspor char(20) = NULL,
    @nroplaca varchar(250) = NULL,
    @drpartida char(60) = NULL,
    @drdestino char(60) = NULL,
    @cdusuario char(10) = NULL,
    @cdvendedor char(10) = NULL,
    @cdusuanula char(10) = NULL,
    @fecanula smalldatetime = NULL,
    @fecanulasis smalldatetime = NULL,
    @tipofactura char(1) = NULL,
    @flgmanual bit = NULL,
    @tcambio numeric(10, 6) = NULL,
    @nroocompra char(15) = NULL,
    @flgcierrez bit = NULL,
    @observacion varchar(250) = NULL,
    @flgmovimiento bit = NULL,
    @referencia varchar(250) = NULL,
    @nroserie1 char(15) = NULL,
    @nroserie2 char(10) = NULL,
    @turno numeric(2, 0) = NULL,
    @nrobonus char(20) = NULL,
    @nrotarjeta char(20) = NULL,
    @odometro char(10) = NULL,
    @archturno bit = NULL,
    @marcavehic char(15) = NULL,
    @mtorecaudo numeric(12, 4) = NULL,
    @inscripcion char(15) = NULL,
    @chofer char(40) = NULL,
    @nrolicencia char(15) = NULL,
    @chkespecial bit = NULL,
    @tipoventa char(1) = NULL,
    @nrocelular char(12) = NULL,
    @PtosGanados numeric(5, 0) = NULL,
    @precio_orig numeric(12, 4) = NULL,
    @rucinvalido bit = NULL,
    @usadecimales bit = NULL,
    @tipoacumula char(2) = NULL,
    @valoracumula numeric(12, 2) = NULL,
    @cantcupon numeric(12, 2) = NULL,
    @c_centralizacion varchar(50) = NULL,
    @mtocanje numeric(12, 4) = NULL,
    @mtopercepcion numeric(12, 4) = NULL,
    @CDRUTA char(10) = NULL,
    @Codes varchar(250) = NULL,
    @codeID varchar(250) = NULL,
    @mensaje1 varchar(120) = NULL,
    @mensaje2 varchar(120) = NULL,
    @redondea_indecopi numeric(12, 4) = NULL,
    @pdf417 varchar(450) = NULL,
    @cdhash varchar(50) = NULL,
    @scop varchar(50) = NULL,
    @nroguia varchar(50) = NULL,
    @porcdetraccion numeric(5, 2) = NULL,
    @mtodetraccion numeric(12, 2) = NULL,
    @ctadetraccion char(20) = NULL,
    @fact_elect bit = NULL,
    @cdMedio_pago char(4) = NULL
AS 
	
	INSERT INTO venta ([cdlocal], [nroseriemaq], [cdtipodoc], [nrodocumento], [fecdocumento], [fecproceso], [fecsistema], [nropos], [mtovueltosol], [mtovueltodol], [cdalmacen], [cdcliente], [ruccliente], [rscliente], [nroproforma], [cdprecio], [cdmoneda], [porservicio], [pordscto1], [pordscto2], [pordscto3], [pordsctoeq], [mtonoafecto], [valorvta], [mtodscto], [mtosubtotal], [mtoservicio], [mtoimpuesto], [mtototal], [cdtranspor], [nroplaca], [drpartida], [drdestino], [cdusuario], [cdvendedor], [cdusuanula], [fecanula], [fecanulasis], [tipofactura], [flgmanual], [tcambio], [nroocompra], [flgcierrez], [observacion], [flgmovimiento], [referencia], [nroserie1], [nroserie2], [turno], [nrobonus], [nrotarjeta], [odometro], [archturno], [marcavehic], [mtorecaudo], [inscripcion], [chofer], [nrolicencia], [chkespecial], [tipoventa], [nrocelular], [PtosGanados], [precio_orig], [rucinvalido], [usadecimales], [tipoacumula], [valoracumula], [cantcupon], [c_centralizacion], [mtocanje], [mtopercepcion], [CDRUTA], [Codes], [codeID], [mensaje1], [mensaje2], [redondea_indecopi], [pdf417], [cdhash], [scop], [nroguia], [porcdetraccion], [mtodetraccion], [ctadetraccion], [fact_elect], [cdMedio_pago])
	SELECT @cdlocal, @nroseriemaq, @cdtipodoc, @nrodocumento, @fecdocumento, @fecproceso, @fecsistema, @nropos, @mtovueltosol, @mtovueltodol, @cdalmacen, @cdcliente, @ruccliente, @rscliente, @nroproforma, @cdprecio, @cdmoneda, @porservicio, @pordscto1, @pordscto2, @pordscto3, @pordsctoeq, @mtonoafecto, @valorvta, @mtodscto, @mtosubtotal, @mtoservicio, @mtoimpuesto, @mtototal, @cdtranspor, @nroplaca, @drpartida, @drdestino, @cdusuario, @cdvendedor, @cdusuanula, @fecanula, @fecanulasis, @tipofactura, @flgmanual, @tcambio, @nroocompra, @flgcierrez, @observacion, @flgmovimiento, @referencia, @nroserie1, @nroserie2, @turno, @nrobonus, @nrotarjeta, @odometro, @archturno, @marcavehic, @mtorecaudo, @inscripcion, @chofer, @nrolicencia, @chkespecial, @tipoventa, @nrocelular, @PtosGanados, @precio_orig, @rucinvalido, @usadecimales, @tipoacumula, @valoracumula, @cantcupon, @c_centralizacion, @mtocanje, @mtopercepcion, @CDRUTA, @Codes, @codeID, @mensaje1, @mensaje2, @redondea_indecopi, @pdf417, @cdhash, @scop, @nroguia, @porcdetraccion, @mtodetraccion, @ctadetraccion, @fact_elect, @cdMedio_pago
		
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_VENTAMES]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_VENTAMES] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_VENTAMES] 
    @periodo char(6), @cdlocal char(3), @nroseriemaq char(15), @cdtipodoc char(5), @nrodocumento char(10), @fecdocumento datetime = NULL,
    @fecproceso smalldatetime = NULL, @fecsistema datetime = NULL, @nropos char(10) = NULL, @mtovueltosol numeric(12, 4) = NULL,
    @mtovueltodol numeric(12, 4) = NULL, @cdalmacen char(3) = NULL, @cdcliente char(20) = NULL, @ruccliente char(15) = NULL,
    @rscliente char(120) = NULL, @nroproforma char(10) = NULL, @cdprecio char(5) = NULL, @cdmoneda char(1) = NULL,
    @porservicio numeric(6, 2) = NULL, @pordscto1 numeric(6, 2) = NULL, @pordscto2 numeric(6, 2) = NULL, @pordscto3 numeric(6, 2) = NULL,
    @pordsctoeq numeric(6, 2) = NULL,@mtonoafecto numeric(12, 4) = NULL,@valorvta numeric(12, 4) = NULL,@mtodscto numeric(12, 4) = NULL,
    @mtosubtotal numeric(12, 4) = NULL,@mtoservicio numeric(12, 4) = NULL,@mtoimpuesto numeric(12, 4) = NULL,@mtototal numeric(12, 4) = NULL,
    @cdtranspor char(20) = NULL,@nroplaca varchar(250) = NULL,@drpartida char(60) = NULL,@drdestino char(60) = NULL,@cdusuario char(10) = NULL,
    @cdvendedor char(10) = NULL,@cdusuanula char(10) = NULL,@fecanula smalldatetime = NULL,@fecanulasis smalldatetime = NULL,@tipofactura char(1) = NULL,
    @flgmanual bit = NULL,@tcambio numeric(10, 6) = NULL,@nroocompra char(15) = NULL,@flgcierrez bit = NULL,@observacion varchar(250) = NULL,
    @flgmovimiento bit = NULL,@referencia varchar(250) = NULL,@nroserie1 char(15) = NULL,@nroserie2 char(10) = NULL,@turno numeric(2, 0) = NULL,
    @nrobonus char(20) = NULL,@nrotarjeta char(20) = NULL,@odometro char(10) = NULL,@archturno bit = NULL,@marcavehic char(15) = NULL,
    @mtorecaudo numeric(12, 4) = NULL,@inscripcion char(15) = NULL,@chofer char(40) = NULL,@nrolicencia char(15) = NULL,@chkespecial bit = NULL,
    @tipoventa char(1) = NULL,@nrocelular char(12) = NULL,@PtosGanados numeric(5, 0) = NULL,@precio_orig numeric(12, 4) = NULL,
    @rucinvalido bit = NULL,@usadecimales bit = NULL,@tipoacumula char(2) = NULL,@valoracumula numeric(12, 2) = NULL,@cantcupon numeric(12, 2) = NULL,@c_centralizacion varchar(50) = NULL,
    @mtocanje numeric(12, 4) = NULL,@mtopercepcion numeric(12, 4) = NULL,@CDRUTA char(10) = NULL,@Codes varchar(250) = NULL,@codeID varchar(250) = NULL,
    @mensaje1 varchar(120) = NULL,@mensaje2 varchar(120) = NULL,@redondea_indecopi numeric(12, 4) = NULL,@pdf417 varchar(450) = NULL,@cdhash varchar(50) = NULL,
    @scop varchar(50) = NULL,@nroguia varchar(50) = NULL,@porcdetraccion numeric(5, 2) = NULL,@mtodetraccion numeric(12, 2) = NULL,@ctadetraccion char(20) = NULL,
    @fact_elect bit = NULL,@cdMedio_pago char(4) = NULL
AS

	DECLARE @SQL as NVARCHAR(MAX)

	SET @SQL = 	'INSERT INTO Venta'+@periodo+'
					([cdlocal], [nroseriemaq], [cdtipodoc], [nrodocumento],
					[fecdocumento], [fecproceso], [fecsistema], [nropos],
					[mtovueltosol], [mtovueltodol], [cdalmacen], [cdcliente],
					[ruccliente], [rscliente], [nroproforma], [cdprecio],
					[cdmoneda], [porservicio], [pordscto1], [pordscto2],
					[pordscto3], [pordsctoeq], [mtonoafecto], [valorvta],
					[mtodscto], [mtosubtotal], [mtoservicio], [mtoimpuesto],
					[mtototal], [cdtranspor], [nroplaca], [drpartida],
					[drdestino], [cdusuario], [cdvendedor], [cdusuanula],
					[tipofactura], [flgmanual], [tcambio], [nroocompra], 
					[observacion], [flgmovimiento], [referencia], [nroserie1],
					[nroserie2], [turno], [nrobonus], [nrotarjeta],
					[odometro], [marcavehic], [mtorecaudo], [inscripcion],
					[chofer], [nrolicencia], [tipoventa], [nrocelular],
					[PtosGanados], [tipoacumula], [valoracumula], [cantcupon], 
					[c_centralizacion], [mtocanje], [mtopercepcion], [cdruta], 
					[Codes], [codeID], [mensaje1], [mensaje2],
					[redondea_indecopi], [pdf417], [cdhash], [scop],
					[nroguia], [porcdetraccion], [mtodetraccion], [ctadetraccion],
					[fact_elect], [cdMedio_pago]
					)
				
				SELECT 
					'''+@cdlocal+''', '''+@nroseriemaq+''', '''+@cdtipodoc+''', '''+@nrodocumento+''',
					'''+CONVERT(VARCHAR,@fecdocumento)+''', '''+CONVERT(VARCHAR,@fecproceso)+''', '''+CONVERT(VARCHAR,@fecsistema)+''', '''+@nropos+''',
					'''+CONVERT(VARCHAR,@mtovueltosol)+''', '''+CONVERT(VARCHAR,@mtovueltodol)+''', '''+@cdalmacen+''', '''+@cdcliente+''',
					'''+@ruccliente+''', '''+@rscliente+''', '''+@nroproforma+''', '''+@cdprecio+''',
					'''+@cdmoneda+''', '''+CONVERT(VARCHAR,@porservicio)+''', '''+CONVERT(VARCHAR,@pordscto1)+''', '''+CONVERT(VARCHAR,@pordscto2)+''',
					'''+CONVERT(VARCHAR,@pordscto3)+''', '''+CONVERT(VARCHAR,@pordsctoeq)+''', '''+CONVERT(VARCHAR,@mtonoafecto)+''', '''+CONVERT(VARCHAR,@valorvta)+''',
					'''+CONVERT(VARCHAR,@mtodscto)+''', '''+CONVERT(VARCHAR,@mtosubtotal)+''', '''+CONVERT(VARCHAR,@mtoservicio)+''', '''+CONVERT(VARCHAR,@mtoimpuesto)+''',
					'''+CONVERT(VARCHAR,@mtototal)+''', '''+@cdtranspor+''', '''+@nroplaca+''', '''+@drpartida+''',
					'''+@drdestino+''', '''+@cdusuario+''', '''+@cdvendedor+''', '''+@cdusuanula+''',
					'''+@tipofactura+''', ''0'', '''+CONVERT(VARCHAR,@tcambio)+''', '''+@nroocompra+''', 
					'''+@observacion+''', '+(SELECT IIF(@flgmovimiento=1,'1','0'))+', '''+@referencia+''', '''+@nroserie1+''',
					'''+@nroserie2+''', '''+CONVERT(VARCHAR,@turno)+''', '''+@nrobonus+''', '''+@nrotarjeta+''',
					'''+@odometro+''', '''+@marcavehic+''', '''+CONVERT(VARCHAR,@mtorecaudo)+''', '''+@inscripcion+''',
					'''+@chofer+''', '''+@nrolicencia+''', '''+@tipoventa+''', '''+@nrocelular+''',
					'''+CONVERT(VARCHAR,@PtosGanados)+''', '''+@tipoacumula+''', '''+CONVERT(VARCHAR,@valoracumula)+''', '''+CONVERT(VARCHAR,@cantcupon)+''', 
					'''+@c_centralizacion+''', '''+CONVERT(VARCHAR,@mtocanje)+''', '''+CONVERT(VARCHAR,@mtopercepcion)+''', '''+@cdruta+''', 
					'''+@Codes+''', '''+@codeID+''', '''+@mensaje1+''', '''+@mensaje1+''',
					'''+CONVERT(VARCHAR,@redondea_indecopi)+''', '''+@pdf417+''', '''+@cdhash+''', '''+@scop+''', 
					'''+@nroguia+''', '''+CONVERT(VARCHAR,@porcdetraccion)+''', '''+CONVERT(VARCHAR,@mtodetraccion)+''', '''+@ctadetraccion+''',
					'''+(SELECT IIF(@fact_elect=1,'1','0'))+''', '''+@cdMedio_pago+''' '
	
	EXEC (@SQL)

GO

IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_VENTAP]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_VENTAP] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_VENTAP]
    @cdlocal char(3),
    @nroseriemaq char(15),
    @cdtipodoc char(5),
    @nrodocumento char(10),
    @cdtppago char(5),
    @cdbanco char(4),
    @nrocuenta char(20),
    @nrocheque char(20),
    @cdtarjeta char(2),
    @nrotarjeta char(20),
    @nropos char(10) = NULL,
    @fecdocumento datetime = NULL,
    @fecproceso smalldatetime = NULL,
    @mtopagosol numeric(12, 4) = NULL,
    @mtopagodol numeric(12, 4) = NULL,
    @flgcierrez bit = NULL,
    @turno numeric(2, 0) = NULL,
    @nroncredito char(10) = NULL,
    @valoracumula numeric(12, 2) = NULL
AS 
	
	INSERT INTO ventap ([cdlocal], [nroseriemaq], [cdtipodoc], [nrodocumento], [cdtppago], [cdbanco], [nrocuenta], [nrocheque], [cdtarjeta], [nrotarjeta], [nropos], [fecdocumento], [fecproceso], [mtopagosol], [mtopagodol], [flgcierrez], [turno], [nroncredito], [valoracumula])
	SELECT @cdlocal, @nroseriemaq, @cdtipodoc, @nrodocumento, @cdtppago, @cdbanco, @nrocuenta, @nrocheque, @cdtarjeta, @nrotarjeta, @nropos, @fecdocumento, @fecproceso, @mtopagosol, @mtopagodol, @flgcierrez, @turno, @nroncredito, @valoracumula
	
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_VENTAPMES]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_VENTAPMES] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_VENTAPMES]

	@periodo char(6), @cdlocal char(3), @nroseriemaq char(15), @cdtipodoc char(5),
    @nrodocumento char(10), @cdtppago char(5), @cdbanco char(4), @nrocuenta char(20),
    @nrocheque char(20), @cdtarjeta char(2), @nrotarjeta char(20), @nropos char(10) = NULL,
    @fecdocumento datetime = NULL, @fecproceso smalldatetime = NULL, @mtopagosol numeric(12, 4) = NULL, @mtopagodol numeric(12, 4) = NULL,
    @flgcierrez bit = NULL, @turno numeric(2, 0) = NULL, @nroncredito char(10) = NULL, @valoracumula numeric(12, 2) = NULL
AS 

	DECLARE @SQL as NVARCHAR(MAX)

	SET @SQL = 	'INSERT INTO ventap'+@periodo+' 
					([cdlocal], [nroseriemaq], [cdtipodoc], [nrodocumento], 
					[cdtppago], [cdbanco], [nrocuenta], [nrocheque], 
					[cdtarjeta], [nrotarjeta], [nropos], [fecdocumento], 
					[fecproceso], [mtopagosol], [mtopagodol], [turno], 
					[nroncredito], [valoracumula])
				SELECT 
					'''+@cdlocal+''', '''+@nroseriemaq+''', '''+@cdtipodoc+''', '''+@nrodocumento+''', 
					'''+@cdtppago+''', '''+@cdbanco+''', '''+@nrocuenta+''', '''+@nrocheque+''', 
					'''+@cdtarjeta+''', '''+@nrotarjeta+''', '''+@nropos+''', '''+CONVERT(VARCHAR,@fecdocumento)+''', 
					'''+CONVERT(VARCHAR,@fecproceso)+''', '''+CONVERT(VARCHAR,@mtopagosol)+''', '''+CONVERT(VARCHAR,@mtopagodol)+''', '''+CONVERT(VARCHAR,@turno)+''', 
					'''+@nroncredito+''', '''+CONVERT(VARCHAR,@valoracumula)+''''
	EXEC (@SQL)	
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_CALCULAR_COSTO_PROMEDIO]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_CALCULAR_COSTO_PROMEDIO] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_CALCULAR_COSTO_PROMEDIO]
	@cdproducto char(20),
    @fecproceso smalldatetime = NULL
AS 
	EXEC pa_Calcular_Costo_Promedio @cdproducto, @fecproceso 
GO
 

IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_VENTAD]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_VENTAD] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_VENTAD] 
    @cdlocal char(3),
    @nroseriemaq char(15),
    @cdtipodoc char(5),
    @nrodocumento char(10),
    @nroitem numeric(3, 0),
    @cdarticulo char(20),
    @nropos char(10) = NULL,
    @fecdocumento datetime = NULL,
    @fecproceso smalldatetime = NULL,
    @cdalterna char(20) = NULL,
    @talla char(10) = NULL,
    @cdvendedor char(10) = NULL,
    @impuesto numeric(6, 2) = NULL,
    @pordscto1 numeric(6, 2) = NULL,
    @pordscto2 numeric(6, 2) = NULL,
    @pordscto3 numeric(6, 2) = NULL,
    @pordsctoeq numeric(6, 2) = NULL,
    @cantidad numeric(12, 4) = NULL,
    @cant_ncredito numeric(12, 4) = NULL,
    @precio numeric(12, 4) = NULL,
    @mtonoafecto numeric(12, 4) = NULL,
    @valorvta numeric(12, 4) = NULL,
    @mtodscto numeric(12, 4) = NULL,
    @mtosubtotal numeric(12, 4) = NULL,
    @mtoservicio numeric(12, 4) = NULL,
    @mtoimpuesto numeric(12, 4) = NULL,
    @mtototal numeric(12, 4) = NULL,
    @flgcierrez bit = NULL,
    @cara char(2) = NULL,
    @nrogasboy char(4) = NULL,
    @turno numeric(2, 0) = NULL,
    @nroguia char(10) = NULL,
    @nroproforma char(10) = NULL,
    @moverstock bit = NULL,
    @glosa text = NULL,
    @archturno bit = NULL,
    @manguera char(1) = NULL,
    @costo numeric(12, 4) = NULL,
    @precio_orig numeric(12, 4) = NULL,
    @PtosGanados numeric(10, 0) = NULL,
    @precioafiliacion numeric(10, 0) = NULL,
    @tipoacumula char(25) = NULL,
    @valoracumula numeric(12, 2) = NULL,
    @Costo_Venta numeric(12, 4) = NULL,
    @TipoSuma varchar(50) = NULL,
    @mtopercepcion numeric(12, 4) = NULL,
    @Cdpack varchar(20) = NULL,
    @trfgratuita bit = NULL,
    @redondea_indecopi numeric(12, 4) = NULL,
    @porcdetraccion numeric(5, 2) = NULL,
    @mtodetraccion numeric(12, 2) = NULL,
    @cdarticulosunat varchar(20) = NULL
AS 
	INSERT INTO ventad ([cdlocal], [nroseriemaq], [cdtipodoc], [nrodocumento], [nroitem], [cdarticulo], [nropos], [fecdocumento], [fecproceso], [cdalterna], [talla], [cdvendedor], [impuesto], [pordscto1], [pordscto2], [pordscto3], [pordsctoeq], [cantidad], [cant_ncredito], [precio], [mtonoafecto], [valorvta], [mtodscto], [mtosubtotal], [mtoservicio], [mtoimpuesto], [mtototal], [flgcierrez], [cara], [nrogasboy], [turno], [nroguia], [nroproforma], [moverstock], [glosa], [archturno], [manguera], [costo], [precio_orig], [PtosGanados], [precioafiliacion], [tipoacumula], [valoracumula], [Costo_Venta], [TipoSuma], [mtopercepcion], [Cdpack], [trfgratuita], [redondea_indecopi], [porcdetraccion], [mtodetraccion], [cdarticulosunat])
	SELECT @cdlocal, @nroseriemaq, @cdtipodoc, @nrodocumento, @nroitem, @cdarticulo, @nropos, @fecdocumento, @fecproceso, @cdalterna, @talla, @cdvendedor, @impuesto, @pordscto1, @pordscto2, @pordscto3, @pordsctoeq, @cantidad, @cant_ncredito, @precio, @mtonoafecto, @valorvta, @mtodscto, @mtosubtotal, @mtoservicio, @mtoimpuesto, @mtototal, @flgcierrez, @cara, @nrogasboy, @turno, @nroguia, @nroproforma, @moverstock, @glosa, @archturno, @manguera, @costo, @precio_orig, @PtosGanados, @precioafiliacion, @tipoacumula, @valoracumula, @Costo_Venta, @TipoSuma, @mtopercepcion, @Cdpack, @trfgratuita, @redondea_indecopi, @porcdetraccion, @mtodetraccion, @cdarticulosunat		
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_VENTADMES]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_VENTADMES] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_VENTADMES] 
    @periodo char(6), @cdlocal char(3), @nroseriemaq char(15), @cdtipodoc char(5), @nrodocumento char(10),
    @nroitem numeric(3, 0), @cdarticulo char(20), @nropos char(10) = NULL, @fecdocumento datetime = NULL,
    @fecproceso smalldatetime = NULL, @cdalterna char(20) = NULL, @talla char(10) = NULL, @cdvendedor char(10) = NULL,
    @impuesto numeric(6, 2) = NULL, @pordscto1 numeric(6, 2) = NULL, @pordscto2 numeric(6, 2) = NULL, @pordscto3 numeric(6, 2) = NULL,
    @pordsctoeq numeric(6, 2) = NULL, @cantidad numeric(12, 4) = NULL, @cant_ncredito numeric(12, 4) = NULL, @precio numeric(12, 4) = NULL,
    @mtonoafecto numeric(12, 4) = NULL, @valorvta numeric(12, 4) = NULL, @mtodscto numeric(12, 4) = NULL, @mtosubtotal numeric(12, 4) = NULL,
    @mtoservicio numeric(12, 4) = NULL, @mtoimpuesto numeric(12, 4) = NULL, @mtototal numeric(12, 4) = NULL, @flgcierrez bit = NULL,
    @cara char(2) = NULL, @nrogasboy char(4) = NULL, @turno numeric(2, 0) = NULL, @nroguia char(10) = NULL,
    @nroproforma char(10) = NULL, @moverstock bit = NULL, @glosa varchar(60) = NULL, @archturno bit = NULL,
    @manguera char(1) = NULL, @costo numeric(12, 4) = NULL, @precio_orig numeric(12, 4) = NULL, @PtosGanados numeric(10, 0) = NULL,
    @precioafiliacion numeric(10, 0) = NULL, @tipoacumula char(25) = NULL, @valoracumula numeric(12, 2) = NULL, @Costo_Venta numeric(12, 4) = NULL,
    @TipoSuma varchar(50) = NULL, @mtopercepcion numeric(12, 4) = NULL, @Cdpack varchar(20) = NULL, @trfgratuita bit = NULL,
    @redondea_indecopi numeric(12, 4) = NULL, @porcdetraccion numeric(5, 2) = NULL, @mtodetraccion numeric(12, 2) = NULL, @cdarticulosunat varchar(20) = NULL
AS 

	DECLARE @SQL as NVARCHAR(MAX)

	SET @SQL = 'INSERT INTO ventad'+@periodo+' 
					([cdlocal], [nroseriemaq], [cdtipodoc], [nrodocumento], 
					[nroitem], [cdarticulo], [nropos], [fecdocumento], 
					[fecproceso], [cdalterna], [talla], [cdvendedor], [impuesto], 
					[pordscto1], [pordscto2], [pordscto3], [pordsctoeq], 
					[cantidad], [cant_ncredito], [precio], [mtonoafecto], 
					[valorvta], [mtodscto], [mtosubtotal], [mtoservicio], 
					[mtoimpuesto], [mtototal], [cara], [nrogasboy], 
					[turno], [nroguia], [nroproforma], [moverstock], 
					[glosa], [manguera], [costo], [precio_orig], 
					[PtosGanados], [precioafiliacion], [tipoacumula], [valoracumula], 
					[Costo_Venta], [TipoSuma], [mtopercepcion], [Cdpack], 
					[redondea_indecopi], [porcdetraccion], [mtodetraccion], [cdarticulosunat])
				SELECT 
					'''+@cdlocal+''', '''+@nroseriemaq+''', '''+@cdtipodoc+''', '''+@nrodocumento+''', 
					'''+CONVERT(VARCHAR,@nroitem)+''', '''+@cdarticulo+''', '''+@nropos+''', '''+CONVERT(VARCHAR,@fecdocumento)+''', 
					'''+CONVERT(VARCHAR,@fecproceso)+''', '''+@cdalterna+''', '''', '''+@cdvendedor+''', '''+CONVERT(VARCHAR,@impuesto)+''', 
					'''+CONVERT(VARCHAR,@pordscto1)+''', '''+CONVERT(VARCHAR,@pordscto2)+''', '''+CONVERT(VARCHAR,@pordscto3)+''', '''+CONVERT(VARCHAR,@pordsctoeq)+''', 
					'''+CONVERT(VARCHAR,@cantidad)+''', '''+CONVERT(VARCHAR,@cant_ncredito)+''', '''+CONVERT(VARCHAR,@precio)+''', '''+CONVERT(VARCHAR,@mtonoafecto)+''', 
					'''+CONVERT(VARCHAR,@valorvta)+''', '''+CONVERT(VARCHAR,@mtodscto)+''', '''+CONVERT(VARCHAR,@mtosubtotal)+''', '''+CONVERT(VARCHAR,@mtoservicio)+''', 
					'''+CONVERT(VARCHAR,@mtoimpuesto)+''', '''+CONVERT(VARCHAR,@mtototal)+''', '''+@cara+''', '''+@nrogasboy+''', 
					'''+CONVERT(VARCHAR,@turno)+''', '''+@nroguia+''', '''+@nroproforma+''', '''+(SELECT IIF(@moverstock=1,'1','0'))+''', 
					'''+@glosa+''', '''+@manguera+''', '''+CONVERT(VARCHAR,@costo)+''', '''+CONVERT(VARCHAR,@precio_orig)+''', 
					'''+CONVERT(VARCHAR,@PtosGanados)+''', '''+CONVERT(VARCHAR,@precioafiliacion)+''', '''+@tipoacumula+''', '''+CONVERT(VARCHAR,@valoracumula)+''', 
					'''+CONVERT(VARCHAR,@Costo_Venta)+''', '''+@TipoSuma+''', '''+CONVERT(VARCHAR,@mtopercepcion)+''', '''+@Cdpack+''', 
					'''+CONVERT(VARCHAR,@redondea_indecopi)+''', '''+CONVERT(VARCHAR,@porcdetraccion)+''', '''+CONVERT(VARCHAR,@mtodetraccion)+''', '''+@cdarticulosunat+''' '
	EXEC (@SQL)
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_DESPACHO]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_DESPACHO] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_DESPACHO] 
    @codvehiculo char(20) = NULL,
    @codruta char(10) = NULL,
    @fecha date = NULL,
    @hora char(12) = NULL,
    @cantidad numeric(12, 4) = NULL,
    @total numeric(12, 2) = NULL
AS 
	INSERT INTO despachos ([codvehiculo], [codruta], [fecha], [hora], [cantidad], [total])
	SELECT @codvehiculo, @codruta, @fecha, @hora, @cantidad, @total
	
GO


IF OBJECT_ID('[dbo].[SP_ITBCP_ACTUALIZAR_SALDOCLIENTE]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_ACTUALIZAR_SALDOCLIENTE] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_ACTUALIZAR_SALDOCLIENTE] 
    @cdcliente char(15),
    @nrotarjeta char(20),
    @cdgrupo02 char(5),
    @cdarticulo char(20) = NULL,
    @limitemto numeric(12, 3) = NULL,
    @consumto numeric(12, 3) = NULL,
    @nrobonus char(20) = NULL,
    @nroplaca char(10) = NULL,
    @flgilimit bit = NULL,
    @flgbloquea bit = NULL,
    @TipoDespacho char(1) = NULL,
    @FechaAtencion smalldatetime = NULL,
    @Enviado bit = NULL,
    @clave char(15) = NULL,
    @cdtipodoc char(5) = NULL,
    @nrodocumento varchar(20) = NULL
AS 
	UPDATE saldoclid
	SET    [consumto] = [consumto] + @consumto
	WHERE  [cdcliente] = @cdcliente
	       AND [nrotarjeta] = @nrotarjeta
	       AND [cdgrupo02] = @cdgrupo02
GO


IF OBJECT_ID('[dbo].[SP_ITBCP_SELECT_SALDOCLIENTED]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_SELECT_SALDOCLIENTED] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_SELECT_SALDOCLIENTED] 
    @cdcliente char(15)
AS 
	SELECT [cdcliente], [nrotarjeta], [cdgrupo02], [cdarticulo], [limitemto], [consumto], [nrobonus], [nroplaca], [flgilimit], [flgbloquea], [TipoDespacho], [FechaAtencion], [Enviado], [clave], [cdtipodoc], [nrodocumento] 
	FROM saldoclid
	WHERE  ([cdcliente] = @cdcliente OR @cdcliente IS NULL) 	
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_SELECT_SALDOCLIENTED1]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_SELECT_SALDOCLIENTED1] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_SELECT_SALDOCLIENTED1] 
    @nrotarjeta char(20)
AS 
	SELECT [cdcliente], [nrotarjeta], [cdgrupo02], [cdarticulo], [limitemto], [consumto], [nrobonus], [nroplaca], [flgilimit], [flgbloquea], [TipoDespacho], [FechaAtencion], [Enviado], [clave], [cdtipodoc], [nrodocumento] 
	FROM saldoclid
	WHERE  (nrotarjeta = @nrotarjeta) 	
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_ACTUALIZAR_SALDOCLIENTE_1]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_ACTUALIZAR_SALDOCLIENTE_1] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_ACTUALIZAR_SALDOCLIENTE_1] 
    @cdcliente char(15),
    @nrotarjeta char(20),
    @consumto numeric(12, 3) = NULL
AS 
	UPDATE saldoclid
	SET    [consumto] = [consumto] + @consumto
	WHERE  [cdcliente] = @cdcliente
	       AND [nrotarjeta] = @nrotarjeta	
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_ACTUALIZAR_SALDOCLIENTE_2]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_ACTUALIZAR_SALDOCLIENTE_2] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_ACTUALIZAR_SALDOCLIENTE_2] 
    @cdcliente char(15),
    @consumto numeric(12, 3) = NULL
AS 
	UPDATE saldoclid
	SET    [consumto] = [consumto] + @consumto
	WHERE  [cdcliente] = @cdcliente
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_ELIMINAR_TMPMOVPUNTOS]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_ELIMINAR_TMPMOVPUNTOS] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_ELIMINAR_TMPMOVPUNTOS] 
    @nrodocumento char(10),
    @LocalID char(4),
    @cdproducto char(20),
    @nropos char(10)
AS 

	DELETE FROM TmpMovPuntos
	WHERE  [nrodocumento] = @nrodocumento
	       AND [LocalID] = @LocalID
	       AND [cdproducto] = @cdproducto
	       AND nropos = @nropos
	COMMIT
GO


IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_TARJETABONUS]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_TARJETABONUS] 
END 
GO

CREATE PROC [dbo].[SP_ITBCP_INSERTAR_TARJETABONUS] 
	@cdestacion char(6),
	@nrobonus char(11),
	@fecha char(8),
	@hora char(4),
	@nroequipo char(6),
	@nrotransac char(6),
	@total char(7),
	@cdproducto char(14),
	@cantidad char(8),
	@totalvta char(7),
	@enviado bit
AS 

	INSERT INTO tarjbonus
           ([cdestacion]
           ,[nrobonus]
           ,[fecha]
           ,[hora]
           ,[nroequipo]
           ,[nrotransac]
           ,[total]
           ,[cdproducto]
           ,[cantidad]
           ,[totalvta]
           ,[enviado])
     VALUES (
           @cdestacion,
           @nrobonus,
           @fecha, 
           @hora,
           @nroequipo,
           @nrotransac,
           @total,
           @cdproducto,
           @cantidad,
           @totalvta,
           @enviado)
GO


IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_STOCK]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_STOCK] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_STOCK] 
    @cdlocal char(3),
    @cdalmacen char(3),
    @cdarticulo char(20),
    @talla char(10) = NULL,
    @fecinicial smalldatetime = NULL,
    @stockinicial numeric(12, 4) = NULL,
    @monctoinicial char(1) = NULL,
    @ctoinicial numeric(12, 4) = NULL,
    @fecinventario smalldatetime = NULL,
    @stockinventario numeric(12, 4) = NULL,
    @monctoinventario char(1) = NULL,
    @ctoinventario numeric(12, 4) = NULL,
    @stockminimo numeric(12, 4) = NULL,
    @stockactual numeric(12, 4) = NULL,
    @stockseparado numeric(12, 4) = NULL,
    @stockmaximo numeric(12, 4) = NULL,
    @monctorepo char(1) = NULL,
    @ctoreposicion numeric(12, 4) = NULL,
    @usuingreso char(10) = NULL,
    @fecingreso smalldatetime = NULL,
    @ususalida char(10) = NULL,
    @fecsalida smalldatetime = NULL,
    @usuventa char(10) = NULL,
    @fecventa smalldatetime = NULL,
    @IS_RECALCULO bit = NULL
AS 
	INSERT INTO stock ([cdlocal], [cdalmacen], [cdarticulo], [talla], [fecinicial], [stockinicial], [monctoinicial], [ctoinicial], [fecinventario], [stockinventario], [monctoinventario], [ctoinventario], [stockminimo], [stockactual], [stockseparado], [stockmaximo], [monctorepo], [ctoreposicion], [usuingreso], [fecingreso], [ususalida], [fecsalida], [usuventa], [fecventa], [IS_RECALCULO])
	SELECT @cdlocal, @cdalmacen, @cdarticulo, @talla, @fecinicial, @stockinicial, @monctoinicial, @ctoinicial, @fecinventario, @stockinventario, @monctoinventario, @ctoinventario, @stockminimo, @stockactual, @stockseparado, @stockmaximo, @monctorepo, @ctoreposicion, @usuingreso, @fecingreso, @ususalida, @fecsalida, @usuventa, @fecventa, @IS_RECALCULO	
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_ACTUALIZAR_STOCK]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_ACTUALIZAR_STOCK] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_ACTUALIZAR_STOCK] 
    @cdlocal char(3),
    @cdalmacen char(3),
    @cdarticulo char(20),
    @talla char(10) = NULL,
    @fecinicial smalldatetime = NULL,
    @stockinicial numeric(12, 4) = NULL,
    @monctoinicial char(1) = NULL,
    @ctoinicial numeric(12, 4) = NULL,
    @fecinventario smalldatetime = NULL,
    @stockinventario numeric(12, 4) = NULL,
    @monctoinventario char(1) = NULL,
    @ctoinventario numeric(12, 4) = NULL,
    @cantidad numeric(12, 4) = NULL,
    @monctorepo char(1) = NULL,
    @ctoreposicion numeric(12, 4) = NULL,
    @usuventa char(10) = NULL,
    @fecventa smalldatetime = NULL
AS 
	
	IF EXISTS(SELECT * FROM stock WHERE cdarticulo = @cdarticulo AND cdalmacen = @cdalmacen)

	BEGIN
		UPDATE stock
		SET    [stockactual] = [stockactual] - @cantidad, [usuventa] = @usuventa, [fecventa] = @fecventa
		WHERE  [cdlocal] = @cdlocal
			   AND [cdalmacen] = @cdalmacen
			   AND [cdarticulo] = @cdarticulo
	END

	ELSE

	BEGIN		
		INSERT INTO stock ([cdlocal], [cdalmacen], [cdarticulo], [talla], [fecinicial], [stockinicial], [monctoinicial], [ctoinicial], [fecinventario], [stockinventario], [monctoinventario], [ctoinventario], [stockactual], [monctorepo], [ctoreposicion], [usuventa], [fecventa])
		SELECT @cdlocal, @cdalmacen, @cdarticulo, @talla, @fecinicial, @stockinicial, @monctoinicial, @ctoinicial, @fecinventario, @stockinventario, @monctoinventario, @ctoinventario, @cantidad * -1, @monctorepo, @ctoreposicion, @usuventa, @fecventa	
	END
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_INSUMOISR]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_INSUMOISR] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_INSUMOISR] 
    @cdlocal char(3),
    @fecdocumento smalldatetime,
    @FECPROCESO smalldatetime
AS 

	INSERT INTO insumoisr
           ([cdlocal]
           ,[fecdocumento]
           ,[FECPROCESO])
     VALUES
           (@cdlocal,
           @fecdocumento,
           @FECPROCESO)
GO


IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_INSUMOIS]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_INSUMOIS] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_INSUMOIS] 
	@nombreTabla VARCHAR(50),
    @cdlocal char(3),
    @nroseriemaq char(20),
    @cdtpmov char(5),
    @nromov char(10),
    @cdtipodoc char(5),
    @nrodocumento char(15),
    @movimiento char(1),
    @nroitem numeric(4, 0),
    @cdarticulo char(20),
    @talla char(10),
    @cdalmacen char(3) = NULL,
    @cantidad numeric(12, 4) = NULL,
    @monctorepo char(1) = NULL,
    @ctoreposicion numeric(14, 6) = NULL,
    @ctopromedio numeric(14, 6) = NULL,
    @tcambio numeric(10, 6) = NULL,
    @fecdocumento datetime = NULL,
    @flganulacion bit = NULL,
    @fecsistema datetime = NULL,
    @fecproceso smalldatetime = NULL,
    @precio numeric(12, 4) = NULL
AS 
	EXEC ('INSERT INTO ' + @nombreTabla + ' ([cdlocal], [nroseriemaq], [cdtpmov], [nromov], [cdtipodoc], [nrodocumento], [movimiento], [nroitem], [cdarticulo], [talla], [cdalmacen], [cantidad], [monctorepo], [ctoreposicion], [ctopromedio], [tcambio], [fecdocumento], [flganulacion], [fecsistema], [fecproceso], [precio])
	SELECT ' + @cdlocal + ', ' + @nroseriemaq + ', ' + @cdtpmov + ', ' + @nromov + ', ' + @cdtipodoc + ', ' + @nrodocumento + ', ' + @movimiento + ', ' + @nroitem + ', ' + @cdarticulo + ', ' + @talla + ', ' + @cdalmacen + ', ' + @cantidad + ', ' + @monctorepo + ', ' + @ctoreposicion + ', ' + @ctopromedio + ', ' + @tcambio + ', ' + @fecdocumento + ', ' + @flganulacion + ', ' + @fecsistema + ', ' + @fecproceso + ', ' + @precio)
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_ACTUALIZAR_ARTICULO]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_ACTUALIZAR_ARTICULO]
END 
GO
CREATE PROC [dbo].[SP_ITBCP_ACTUALIZAR_ARTICULO] 
    @cdarticulo char(20),
    @movimiento bit = NULL
AS 
	UPDATE articulo
	SET    [movimiento] = @movimiento
	WHERE  [cdarticulo] = @cdarticulo
	
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_CIERREMOV]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_CIERREMOV] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_CIERREMOV] 
    @cdlocal char(3),
    @cdalmacen char(3),
    @cdarticulo char(20),
    @ventas numeric(12, 4) = NULL,
    @ingresos numeric(12, 4) = NULL,
    @salidas numeric(12, 4) = NULL
AS 
	INSERT INTO cierremov ([cdlocal], [cdalmacen], [cdarticulo], [ventas], [ingresos], [salidas])
	SELECT @cdlocal, @cdalmacen, @cdarticulo, @ventas, @ingresos, @salidas
GO	

IF OBJECT_ID('[dbo].[SP_ITBCP_ACTUALIZAR_CIERREMOV]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_ACTUALIZAR_CIERREMOV] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_ACTUALIZAR_CIERREMOV] 
    @cdlocal char(3),
    @cdalmacen char(3),
    @cdarticulo char(20),
    @ventas numeric(12, 4) = NULL    
AS 
	UPDATE cierremov
	SET    [ventas] = [ventas] + @ventas
	WHERE  [cdlocal] = @cdlocal
	       AND [cdalmacen] = @cdalmacen
	       AND [cdarticulo] = @cdarticulo	
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_CLIENTE]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_CLIENTE] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_CLIENTE] 
    @cdcliente char(20),
    @ruccliente char(15) = NULL,
    @rscliente char(120) = NULL,
    @drcliente char(120) = NULL,
    @cddistrito char(2) = NULL,
    @cddepartamento char(2) = NULL,
    @cdzona char(5) = NULL,
    @drcobranza char(60) = NULL,
    @drentrega char(60) = NULL,
    @tlfcliente char(15) = NULL,
    @tlfcliente1 char(15) = NULL,
    @faxcliente char(15) = NULL,
    @monlimite char(1) = NULL,
    @mtolimite numeric(13, 2) = NULL,
    @mtodisponible numeric(13, 2) = NULL,
    @bloqcredito bit = NULL,
    @emcliente char(60) = NULL,
    @fecnacimiento smalldatetime = NULL,
    @cdalmacen char(3) = NULL,
    @tipocli char(1) = NULL,
    @diascredito int = NULL,
    @CDGRUPOCLI char(5) = NULL,
    @Sunat_Actualiza tinyint = NULL,
    @cliente varchar(60) = NULL,
    @contacto varchar(60) = NULL,
    @fecha_creacion smalldatetime = NULL,
    @DIASMAX_ND int = NULL,
    @GRUPORUTA char(10) = NULL,
    @flgpreciond bit = NULL,
    @consulta_sunat bit = NULL,
    @flg_pideclave bit = NULL,
    @flgtotalnd bit = NULL
AS 
	
	IF EXISTS(SELECT * FROM cliente WHERE cdcliente = @cdcliente)

	BEGIN
		UPDATE cliente SET 
			cdcliente = @cdcliente, 
			ruccliente = @ruccliente, 
			rscliente = @rscliente, 
			drcliente = @drcliente, 
			cddistrito = @cddistrito, 
			cddepartamento = @cddepartamento, 
			cdzona = @cdzona, 
			drcobranza = @drcobranza, 
			drentrega = @drentrega, 
			tlfcliente = @tlfcliente, 
			tlfcliente1 = @tlfcliente1, 
			faxcliente = @faxcliente, 
			monlimite = @monlimite, 
			mtolimite = @mtolimite, 
			mtodisponible = @mtodisponible, 
			bloqcredito = @bloqcredito, 
			emcliente = @emcliente, 
			fecnacimiento = @fecnacimiento, 
			cdalmacen = @cdalmacen, 
			tipocli = @tipocli, 
			diascredito = @diascredito, 
			CDGRUPOCLI = @CDGRUPOCLI, 
			Sunat_Actualiza = @Sunat_Actualiza, 
			cliente = @cliente, 
			contacto = @contacto, 
			fecha_creacion = @fecha_creacion, 
			DIASMAX_ND = @DIASMAX_ND, 
			GRUPORUTA = @GRUPORUTA, 
			flgpreciond = @flgpreciond,
			consulta_sunat = @consulta_sunat,
			flg_pideclave = @flg_pideclave, 
			flgtotalnd = @flgtotalnd
		WHERE cdcliente = @cdcliente		
	END

	ELSE

	BEGIN
		INSERT INTO cliente ([cdcliente], [ruccliente], [rscliente], [drcliente], [cddistrito], [cddepartamento], [cdzona], [drcobranza], [drentrega], [tlfcliente], [tlfcliente1], [faxcliente], [monlimite], [mtolimite], [mtodisponible], [bloqcredito], [emcliente], [fecnacimiento], [cdalmacen], [tipocli], [diascredito], [CDGRUPOCLI], [Sunat_Actualiza], [cliente], [contacto], [fecha_creacion], [DIASMAX_ND], [GRUPORUTA], [flgpreciond], [consulta_sunat], [flg_pideclave], [flgtotalnd])
		SELECT @cdcliente, @ruccliente, @rscliente, @drcliente, @cddistrito, @cddepartamento, @cdzona, @drcobranza, @drentrega, @tlfcliente, @tlfcliente1, @faxcliente, @monlimite, @mtolimite, @mtodisponible, @bloqcredito, @emcliente, @fecnacimiento, @cdalmacen, @tipocli, @diascredito, @CDGRUPOCLI, @Sunat_Actualiza, @cliente, @contacto, @fecha_creacion, @DIASMAX_ND, @GRUPORUTA, @flgpreciond, @consulta_sunat, @flg_pideclave, @flgtotalnd
	END

	
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_ACTUALIZAR_CLIENTE]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_ACTUALIZAR_CLIENTE] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_ACTUALIZAR_CLIENTE] 
    @cdcliente char(20),
    @ruccliente char(15) = NULL,
    @rscliente char(120) = NULL,
    @drcliente char(120) = NULL,
    @cddistrito char(2) = NULL,
    @cddepartamento char(2) = NULL,
    @cdzona char(5) = NULL,
    @drcobranza char(60) = NULL,
    @drentrega char(60) = NULL,
    @tlfcliente char(15) = NULL,
    @tlfcliente1 char(15) = NULL,
    @faxcliente char(15) = NULL,
    @monlimite char(1) = NULL,
    @mtolimite numeric(13, 2) = NULL,
    @mtodisponible numeric(13, 2) = NULL,
    @bloqcredito bit = NULL,
    @emcliente char(60) = NULL,
    @fecnacimiento smalldatetime = NULL,
    @cdalmacen char(3) = NULL,
    @tipocli char(1) = NULL,
    @diascredito int = NULL,
    @CDGRUPOCLI char(5) = NULL,
    @Sunat_Actualiza tinyint = NULL,
    @cliente varchar(60) = NULL,
    @contacto varchar(60) = NULL,
    @fecha_creacion smalldatetime = NULL,
    @DIASMAX_ND int = NULL,
    @GRUPORUTA char(10) = NULL,
    @flgpreciond bit = NULL,
    @consulta_sunat bit = NULL,
    @flg_pideclave bit = NULL,
    @flgtotalnd bit = NULL
AS 
	
	UPDATE cliente
	SET    [ruccliente] = @ruccliente, [rscliente] = @rscliente, [drcliente] = @drcliente, [cddistrito] = @cddistrito, [cddepartamento] = @cddepartamento, [cdzona] = @cdzona, [drcobranza] = @drcobranza, [drentrega] = @drentrega, [tlfcliente] = @tlfcliente, [tlfcliente1] = @tlfcliente1, [faxcliente] = @faxcliente, [monlimite] = @monlimite, [mtolimite] = @mtolimite, [mtodisponible] = @mtodisponible, [bloqcredito] = @bloqcredito, [emcliente] = @emcliente, [fecnacimiento] = @fecnacimiento, [cdalmacen] = @cdalmacen, [tipocli] = @tipocli, [diascredito] = @diascredito, [CDGRUPOCLI] = @CDGRUPOCLI, [Sunat_Actualiza] = @Sunat_Actualiza, [cliente] = @cliente, [contacto] = @contacto, [fecha_creacion] = @fecha_creacion, [DIASMAX_ND] = @DIASMAX_ND, [GRUPORUTA] = @GRUPORUTA, [flgpreciond] = @flgpreciond, [consulta_sunat] = @consulta_sunat, [flg_pideclave] = @flg_pideclave, [flgtotalnd] = @flgtotalnd
	WHERE  [cdcliente] = @cdcliente
	
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_PLACA]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_PLACA] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_PLACA] 
    @nroplaca varchar(250),
    @marca char(50) = NULL,
    @modelo char(50) = NULL,
    @color char(50) = NULL,
    @ano numeric(4, 0) = NULL,
    @nroserie char(40) = NULL,
    @nromotor char(40) = NULL,
    @kilometraje numeric(8, 0) = NULL
AS 
	
	INSERT INTO placa ([nroplaca], [marca], [modelo], [color], [ano], [nroserie], [nromotor], [kilometraje])
	SELECT @nroplaca, @marca, @modelo, @color, @ano, @nroserie, @nromotor, @kilometraje
	
	
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_ELIMINAR_CVENTA]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_ELIMINAR_CVENTA] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_ELIMINAR_CVENTA] 
    @nropos char(10),
    @fecha smalldatetime
AS 
	DELETE FROM cventa
	WHERE  [nropos] = @nropos
	       AND [fecha] = @fecha
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_ELIMINAR_CVENTAD]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_ELIMINAR_CVENTAD] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_ELIMINAR_CVENTAD] 
    @nropos char(10),
    @fecha smalldatetime
AS 

	DELETE FROM cventad
	WHERE  [nropos] = @nropos
	       AND [fecha] = @fecha

GO

IF OBJECT_ID('[dbo].[SP_ITBCP_ELIMINAR_VALE]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_ELIMINAR_VALE] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_ELIMINAR_VALE] 
    @nrovale char(10)
AS 
	DELETE FROM vale
	WHERE  [nrovale] = @nrovale
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_HVALE]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_HVALE] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_HVALE] 
    @nrovale char(10),
    @fecvale smalldatetime = NULL,
    @cdmoneda char(1) = NULL,
    @mtovale numeric(12, 2) = NULL,
    @cdcliente char(15) = NULL,
    @nroplaca char(10) = NULL,
    @nroseriemaq char(15) = NULL,
    @cdtipodoc char(5) = NULL,
    @nrodocumento char(10) = NULL,
    @fecdocumento smalldatetime = NULL,
    @fecproceso smalldatetime = NULL,
	@turno numeric(2, 0) = NULL
AS 
	INSERT INTO hvale ([nrovale], [fecvale], [cdmoneda], [mtovale], [cdcliente], [nroplaca], [nroseriemaq], [cdtipodoc], [nrodocumento], [fecdocumento], [fecproceso], [turno])
	SELECT @nrovale, @fecvale, @cdmoneda, @mtovale, @cdcliente, @nroplaca, @nroseriemaq, @cdtipodoc, @nrodocumento, @fecdocumento, @fecproceso, @turno
GO


IF OBJECT_ID('[dbo].[SP_ITBCP_ACTUALIZAR_CDHASH_VENTA]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_ACTUALIZAR_CDHASH_VENTA] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_ACTUALIZAR_CDHASH_VENTA] 
	@nombreTabla varchar(50),
    @cdtipodoc char(5),
    @nrodocumento char(10),
    @cdhash varchar(50) = NULL
AS 
	EXEC('UPDATE ' + @nombreTabla + '
	SET   [cdhash] = ' + @cdhash + '
	WHERE  [cdtipodoc] = ' + @cdtipodoc + ' AND [nrodocumento] = ' + @nrodocumento)
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_ACTUALIZAR_OPTRAN]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_ACTUALIZAR_OPTRAN] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_ACTUALIZAR_OPTRAN] 
    @NUMERO char(4),
    @cdtipodoc char(5) = NULL,
    @DOCUMENTO numeric(10, 0) = NULL,
    @DATEPROCE smalldatetime = NULL
AS 
	UPDATE OP_TRAN
	SET    [cdtipodoc] = @cdtipodoc, [DOCUMENTO] = @DOCUMENTO, [DATEPROCE] = @DATEPROCE
	WHERE  [NUMERO] = @NUMERO
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_SELECT_INSUMOS]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_SELECT_INSUMOS] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_SELECT_INSUMOS] 
    @cdarticulo char(20)
AS 
	-- devuelve el campo cantidad, y luego en el cliente multiplicar por el control cantidad de la UI
	SELECT insumo.cdinsumo as cdarticulo, insumo.talla, Insumo.cantidad, articulo.tpformula
	FROM insumo AS insumo LEFT OUTER JOIN articulo as articulo ON Insumo.cdinsumo = Articulo.cdarticulo
	WHERE Insumo.cdarticulo = @cdarticulo and articulo.moverstock = 1
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_SELECT_LOTERIA]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_SELECT_LOTERIA] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_SELECT_LOTERIA] 
AS 
	SELECT  [flgactivo], [fecinicio], [fecfin], [flgefectivo], [flgtarjeta], [flgcheque], [flgcredito], [flgpromocion], [nro_centralizacion] 
	FROM loteria 
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_SELECT_LOTERIA_HORA]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_SELECT_LOTERIA_HORA] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_SELECT_LOTERIA_HORA] 
	@hora char(5) = NULL,
	@dia INT
AS 
	SELECT *
	FROM loteriahora
	WHERE CAST(@hora as time) >= LoteriaHora.horainicio 
	OR CAST(@hora as time) < LoteriaHora.horafin
	AND (flgdomingo = 1 and @dia = 1)
	AND (flglunes = 1 and @dia = 2)
	AND (flgmartes = 1 and @dia = 3)
	AND (flgmiercoles = 1 and @dia = 4)
	AND (flgjueves = 1 and @dia = 5)
	AND (flgviernes = 1 and @dia = 6)
	AND (flgsabado = 1 and @dia = 7)
GO


IF OBJECT_ID('[dbo].[SP_ITBCP_SELECT_LOTERIART]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_SELECT_LOTERIART] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_SELECT_LOTERIART] 
    @item numeric(2, 0),
    @cdarticulo char(20)
AS 
	SELECT [item], [cdarticulo] 
	FROM loteriaart
	WHERE  ([item] = @item OR @item IS NULL) 
	       AND ([cdarticulo] = @cdarticulo OR @cdarticulo IS NULL) 
GO


IF OBJECT_ID('[dbo].[SP_ITBCP_SELECT_LOTERIAWIN]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_SELECT_LOTERIAWIN] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_SELECT_LOTERIAWIN] 
    @fecha smalldatetime,
    @item numeric(2, 0),
    @nroseriemaq char(15),
    @cdtipodoc char(5),
    @nrodocumento char(10)
AS

	SELECT [fecha], [item], [nroseriemaq], [cdtipodoc], [nrodocumento], [fecdocumento], [fecproceso], [cdmoneda], [mtototal], [nroganador], [frecuencia] 
	FROM loteriawin
	WHERE  ([fecha] = @fecha OR @fecha IS NULL) 
	       AND ([item] = @item OR @item IS NULL) 
	       AND ([nroseriemaq] = @nroseriemaq OR @nroseriemaq IS NULL) 
	       AND ([cdtipodoc] = @cdtipodoc OR @cdtipodoc IS NULL) 
	       AND ([nrodocumento] = @nrodocumento OR @nrodocumento IS NULL) 
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_LOTERIAWIN]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_LOTERIAWIN] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_LOTERIAWIN] 
    @fecha smalldatetime,
    @item numeric(2, 0),
    @nroseriemaq char(15),
    @cdtipodoc char(5),
    @nrodocumento char(10),
    @fecdocumento smalldatetime = NULL,
    @fecproceso smalldatetime = NULL,
    @cdmoneda char(1) = NULL,
    @mtototal numeric(12, 4) = NULL,
    @nroganador numeric(2, 0) = NULL,
    @frecuencia numeric(4, 0) = NULL
AS 
	
	INSERT INTO loteriawin ([fecha], [item], [nroseriemaq], [cdtipodoc], [nrodocumento], [fecdocumento], [fecproceso], [cdmoneda], [mtototal], [nroganador], [frecuencia])
	SELECT @fecha, @item, @nroseriemaq, @cdtipodoc, @nrodocumento, @fecdocumento, @fecproceso, @cdmoneda, @mtototal, @nroganador, @frecuencia
GO

IF OBJECT_ID('[dbo].[SP_ITBCP_ACTUALIZAR_LOTERIAWIN]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_ACTUALIZAR_LOTERIAWIN] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_ACTUALIZAR_LOTERIAWIN] 
    @fecha smalldatetime,
    @item numeric(2, 0),
    @nroseriemaq char(15),
    @cdtipodoc char(5),
    @nrodocumento char(10),
    @fecdocumento smalldatetime = NULL,
    @fecproceso smalldatetime = NULL,
    @cdmoneda char(1) = NULL,
    @mtototal numeric(12, 4) = NULL,
    @nroganador numeric(2, 0) = NULL,
    @frecuencia numeric(4, 0) = NULL
AS 

	UPDATE loteriawin
	SET    [fecdocumento] = @fecdocumento, [fecproceso] = @fecproceso, [cdmoneda] = @cdmoneda, [mtototal] = @mtototal, [nroganador] = @nroganador, [frecuencia] = @frecuencia
	WHERE  [fecha] = @fecha
	       AND [item] = @item
	       AND [nroseriemaq] = @nroseriemaq
	       AND [cdtipodoc] = @cdtipodoc
	       AND [nrodocumento] = @nrodocumento

GO

IF OBJECT_ID('[dbo].[SP_ITBCP_INSERTAR_COLA_IMPRESION]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[SP_ITBCP_INSERTAR_COLA_IMPRESION] 
END 
GO
CREATE PROC [dbo].[SP_ITBCP_INSERTAR_COLA_IMPRESION] 
    @cdtipodoc char(5) = NULL,
	@nrodocumento char(10) = NULL,
	@nropos char(10) = NULL,
	@fecdocumento datetime = NULL,
	@formato char(5) = NULL,
	@impresora varchar(40) = NULL,
	@trama varchar(max) = NULL,
	@json varchar(max) = NULL,
	@hash varchar(50) = NULL,
	@impreso bit = NULL,
	@observacion varchar(120) = NULL,
	@timestamp smalldatetime = NULL
AS 
	INSERT INTO ColaImpresion ([cdtipodoc], [nrodocumento], [nropos], [fecdocumento], [formato], [impresora], [trama], [json], [hash], [impreso], [observacion], [timestamp])
	SELECT @cdtipodoc, @nrodocumento, @nropos, @fecdocumento, @formato, @impresora, @trama, @json, @hash, @impreso, @observacion, @timestamp
GO