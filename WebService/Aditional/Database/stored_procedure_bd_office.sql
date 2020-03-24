USE [backoffice]
GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_VENTA_CABECERA]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_VENTA_CABECERA]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_VALIDAR_OPCION_PRINT_PANTALLA_OR_FISICO]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_VALIDAR_OPCION_PRINT_PANTALLA_OR_FISICO]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_OBTENER_TOPES_MONTO_VENTA]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_OBTENER_TOPES_MONTO_VENTA]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_OBTENER_TIPO_INGRESO]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_OBTENER_TIPO_INGRESO]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_OBTENER_RUTA]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_OBTENER_RUTA]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_OBTENER_PORCENTAJE_DSCTO]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_OBTENER_PORCENTAJE_DSCTO]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_OBTENER_LOCAL]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_OBTENER_LOCAL]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_OBTENER_IGV]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_OBTENER_IGV]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_OBTENER_FECHA_SERVIDOR]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_OBTENER_FECHA_SERVIDOR]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_OBTENER_ALMACEN]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_OBTENER_ALMACEN]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LSITAR_TERMINAL_POR_USUARIO]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LSITAR_TERMINAL_POR_USUARIO]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTARTIPOCAMBIO]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTARTIPOCAMBIO]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_ZONAS]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_ZONAS]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VISTA_PUNTOS_TARJETA]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VISTA_PUNTOS_TARJETA]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTAP_2]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VENTAP_2]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTAP_1]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VENTAP_1]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTAP]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VENTAP]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTAD_2]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VENTAD_2]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTAD_1]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VENTAD_1]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTAD]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VENTAD]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTA_9]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VENTA_9]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTA_8]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VENTA_8]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTA_7]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VENTA_7]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTA_6]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VENTA_6]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTA_5]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VENTA_5]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTA_4]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VENTA_4]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTA_3]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VENTA_3]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTA_2]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VENTA_2]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTA]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VENTA]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VARIABLES_1]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VARIABLES_1]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VARIABLES]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VARIABLES]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VALE]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_VALE]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_ULTIMO_CIERRE]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_ULTIMO_CIERRE]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_TRANSACCION_ARTICULO]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_TRANSACCION_ARTICULO]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_TIPO_PAGOS]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_TIPO_PAGOS]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_TIPO_PAGO_EFECTIVO]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_TIPO_PAGO_EFECTIVO]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_TIPO_CAMBIO]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_TIPO_CAMBIO]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_TERMINALES]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_TERMINALES]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_TARJETA_CONCEPTO_1]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_TARJETA_CONCEPTO_1]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_TARJETA_CONCEPTO]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_TARJETA_CONCEPTO]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_TALLAS]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_TALLAS]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_STOCK]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_STOCK]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_SALDOCLID_1]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_SALDOCLID_1]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_SALDOCLID]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_SALDOCLID]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_SALDO_CLIENTE]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_SALDO_CLIENTE]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_PTOS_DISPONIBLES_POR_TARJETA_AFILIACION]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_PTOS_DISPONIBLES_POR_TARJETA_AFILIACION]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_PRECIOS_VARIOS_1]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_PRECIOS_VARIOS_1]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_PRECIOS_VARIOS]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_PRECIOS_VARIOS]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_PRECIOS]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_PRECIOS]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_PRECIO_POR_ARTICULO_PRECIO]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_PRECIO_POR_ARTICULO_PRECIO]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_PRECIO_CLIENTE]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_PRECIO_CLIENTE]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_MOVPUNTOS]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_MOVPUNTOS]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_MOVIMIENTO_PUNTOS_POR_GRUPO_COMBUSTIBLE]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_MOVIMIENTO_PUNTOS_POR_GRUPO_COMBUSTIBLE]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_MOVDET_PUNTOS]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_MOVDET_PUNTOS]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_MOV_FACTURA]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_MOV_FACTURA]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_LOCAL_POR_ID]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_LOCAL_POR_ID]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_GRUPOS_CONSUMOS]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_GRUPOS_CONSUMOS]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_FORMATO_TICKET]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_FORMATO_TICKET]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_FORMATO_NOTA_VENTA]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_FORMATO_NOTA_VENTA]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_FORMATO_GUIA_DESPACHO]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_FORMATO_GUIA_DESPACHO]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_CONF_PUNTO]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_CONF_PUNTO]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_CLIENTE_POR_CODIGO]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_CLIENTE_POR_CODIGO]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_CIERRE]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_CIERRE]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_CATEGORIAS_GRUPO2]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_CATEGORIAS_GRUPO2]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_CARA_POR_POSICION]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_CARA_POR_POSICION]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_ARTICULO_POR_GRUPO_COMBUSTIBLE]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_ARTICULO_POR_GRUPO_COMBUSTIBLE]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_ARTICULO_POR_CODIGO]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_ARTICULO_POR_CODIGO]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_ARTICULO]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_LISTAR_ARTICULO]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_IMPRIMIR_IMPRESORA]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_IMPRIMIR_IMPRESORA]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_IMPRIMIR_CLIENTE]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_IMPRIMIR_CLIENTE]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_IMPRIMIR]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_IMPRIMIR]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_ELIMINAR_MOV_FACTURA]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_ELIMINAR_MOV_FACTURA]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_BLOQUEA_VENTANA_PLAYA]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_BLOQUEA_VENTANA_PLAYA]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_AVISO_LOTERIA]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_AVISO_LOTERIA]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_ARTICULOS_EN_PLAYA]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_ARTICULOS_EN_PLAYA]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_ACTUALIZAR_VENTA]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_ACTUALIZAR_VENTA]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_ACTUALIZAR_TERMINAL_2]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_ACTUALIZAR_TERMINAL_2]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_ITBCP_ACTUALIZAR_TERMINAL]    Script Date: 2/3/2019 12:51:53 AM ******/
--DROP PROCEDURE IF EXISTS [dbo].[SP_ITBCP_ACTUALIZAR_TERMINAL]
--GO


/****** Object:  StoredProcedure [dbo].[SP_ITBCP_ACTUALIZAR_TERMINAL]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_ACTUALIZAR_TERMINAL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_ACTUALIZAR_TERMINAL] AS' 
END
GO
-- SPS PARA OFFICE

ALTER PROCEDURE [dbo].[SP_ITBCP_ACTUALIZAR_TERMINAL]
	@cdusuario char(10),
	@seriehd char(10) 
AS
	UPDATE Terminal Set cdusuario =@cdusuario Where seriehd = ltrim(rtrim(@seriehd))
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_ACTUALIZAR_TERMINAL_2]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_ACTUALIZAR_TERMINAL_2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_ACTUALIZAR_TERMINAL_2] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_ACTUALIZAR_TERMINAL_2]
	@mtozeta NUMERIC(9),
	@seriehd CHAR(10)
AS
	UPDATE terminal Set nrozeta = nrozeta+1, mtozeta = mtozeta+@mtozeta, flgcierrezok=1
	where @seriehd = ltrim(rtrim(seriehd))
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_ACTUALIZAR_VENTA]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_ACTUALIZAR_VENTA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_ACTUALIZAR_VENTA] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_ACTUALIZAR_VENTA]
	@cdtipodoc CHAR(5),
	@nropos CHAR(10)
AS
	UPDATE Venta Set flgcierrez = 1. Where @cdtipodoc = cdtipodoc And @nropos = nropos
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_ARTICULOS_EN_PLAYA]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_ARTICULOS_EN_PLAYA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_ARTICULOS_EN_PLAYA] AS' 
END
GO


ALTER PROCEDURE [dbo].[SP_ITBCP_ARTICULOS_EN_PLAYA]
	@cdgrupo05 CHAR(5)
AS
	SELECT * FROM articulo 
	WHERE ltrim(rtrim(articulo.cdgrupo05)) = @cdgrupo05 and Articulo.bloqvta=0 and Articulo.venta=1
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_AVISO_LOTERIA]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_AVISO_LOTERIA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_AVISO_LOTERIA] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_AVISO_LOTERIA]
AS
	Select linea1, linea2, linea3, linea4, linea5 FROM LoteriaAviso
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_BLOQUEA_VENTANA_PLAYA]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_BLOQUEA_VENTANA_PLAYA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_BLOQUEA_VENTANA_PLAYA] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_BLOQUEA_VENTANA_PLAYA]
AS
	SELECT Bloqventaplaya FROM Parametro
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD] AS' 
END
GO
	
ALTER PROCEDURE [dbo].[SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD]
	@seriehd CHAR(10)
AS
	SELECT * FROM terminal where seriehd = ltrim(rtrim(@seriehd))
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_ELIMINAR_MOV_FACTURA]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_ELIMINAR_MOV_FACTURA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_ELIMINAR_MOV_FACTURA] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_ELIMINAR_MOV_FACTURA]
	@cdtipodoc char(5),
	@nrodocumento char(10),
	@localid char(4),
	@cdproducto char(20) 
AS

	DELETE FROM TMPMOVfactura 
	WHERE cdtipodoc= @cdtipodoc and nrodocumento= @nrodocumento and localid= @localid and cdproducto= @cdproducto
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_IMPRIMIR]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_IMPRIMIR]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_IMPRIMIR] AS' 
END
GO

---- IMPRIMIR -----
ALTER PROCEDURE [dbo].[SP_ITBCP_IMPRIMIR]
	@nropos CHAR(10)
AS
	Select top 1 cdtipodoc, substring(nrodocumento, 1,3)+'-'+substring(nrodocumento, 4,7) as nrodocumento, fecdocumento,
	mtovueltosol, mtovueltodol, cdalmacen, cdprecio, cdcliente, rscliente, ruccliente, cdmoneda, porservicio, redondea_indecopi,
	pordscto1, pordscto2, pordscto3, pordsctoeq, mtonoafecto, valorvta, mtodscto, mtosubtotal, mtoservicio,
	mtoimpuesto, mtototal, drpartida, drdestino, cdvendedor, cdusuanula = isnull(cdusuanula,'9999999999'), fecanula, tcambio, nroocompra,
	observacion,  referencia, tipofactura, cdtranspor, nroplaca, nropos, nrobonus, nrotarjeta, odometro, tipoventa, mtopercepcion,
	PtosGanados = ISNULL(PtosGanados,0), TipoAcumula = ISNULL(TipoAcumula,'02'), ValorAcumula = ISNULL(ValorAcumula,0),
	Codes = ISNULL(Codes,''), codeID = ISNULL(codeID,''), mensaje1 = ISNULL(mensaje1,''), mensaje2 = ISNULL(mensaje2,'')
	FROM venta WHERE (flgcierrez=0 or flgcierrez IS NULL) and ltrim(rtrim(@nropos)) = nropos
	ORDER BY fecsistema DESC
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_IMPRIMIR_CLIENTE]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_IMPRIMIR_CLIENTE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_IMPRIMIR_CLIENTE] AS' 
END
GO
  

ALTER PROCEDURE [dbo].[SP_ITBCP_IMPRIMIR_CLIENTE]
	@cdcliente CHAR(20)
AS
	SELECT cdcliente, ruccliente, rscliente, drcliente, drcobranza, drentrega, tlfcliente, tlfcliente1,
	faxcliente, cddistrito, cddepartamento, cdzona, monlimite, mtolimite, mtodisponible,
	bloqcredito, emcliente FROM cliente 
	WHERE @cdcliente=ltrim(rtrim(cdcliente))
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_IMPRIMIR_IMPRESORA]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_IMPRIMIR_IMPRESORA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_IMPRIMIR_IMPRESORA] AS' 
END
GO
 
---- IMPRIMIR_IMPRESORA------------
ALTER PROCEDURE [dbo].[SP_ITBCP_IMPRIMIR_IMPRESORA]
	@cdtppago CHAR(5)
AS
	SELECT dstppago 
	FROM tipopago WHERE @cdtppago=cdtppago
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_ARTICULOS]    Script Date: 2/3/2019 12:51:53 AM ******/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_ARTICULOS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_ARTICULOS] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_ARTICULOS]
	@cdgrupo02 CHAR(5)
AS
	SELECT *
	FROM articulo 
	WHERE articulo.cdgrupo02 = @cdgrupo02
	Order By cdarticulo
GO


/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_ARTICULO]    Script Date: 2/3/2019 12:51:53 AM ******/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_ARTICULO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_ARTICULO] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_ARTICULO]
	@cdgrupo02 CHAR(5)
AS
	SELECT cdarticulo, dsarticulo, cdgrupo01, cdgrupo02
	FROM articulo 
	WHERE articulo.cdgrupo02 != @cdgrupo02
	Order By cdarticulo
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_ARTICULO_POR_CODIGO]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_ARTICULO_POR_CODIGO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_ARTICULO_POR_CODIGO] AS' 
END
GO
  
ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_ARTICULO_POR_CODIGO]
	@cdarticulo CHAR(20)
AS
	SELECT * FROM articulo
	WHERE ltrim(rtrim(@cdarticulo)) = ltrim(rtrim(cdarticulo))
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_ARTICULO_POR_GRUPO_COMBUSTIBLE]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_ARTICULO_POR_GRUPO_COMBUSTIBLE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_ARTICULO_POR_GRUPO_COMBUSTIBLE] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_ARTICULO_POR_GRUPO_COMBUSTIBLE]
	@cdgrupo02 CHAR(5)
AS
	SELECT cdarticulo, dsarticulo FROM Articulo WHERE cdgrupo02 = @cdgrupo02
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_CARA_POR_POSICION]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_CARA_POR_POSICION]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_CARA_POR_POSICION] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_CARA_POR_POSICION]
	@nropos char(10)
AS
	SELECT * FROM cara WHERE ltrim(rtrim(nropos))= @nropos
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_CATEGORIAS_GRUPO2]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_CATEGORIAS_GRUPO2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_CATEGORIAS_GRUPO2] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_CATEGORIAS_GRUPO2]
AS
	select cdgrupo02, dsgrupo02 FROM grupo02
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_CIERRE]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_CIERRE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_CIERRE] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_CIERRE]
AS
	Select flgarticulo, flggrupo01, flggrupo02, flggrupo03, flggrupo04, flggrupo05, flgvendedor, flgpago,
	flgcara, flgdocmanual, flgusuario, flgcanjearticulo FROM Cierre Where cdcierre='X'
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_CLIENTE_POR_CODIGO]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_CLIENTE_POR_CODIGO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_CLIENTE_POR_CODIGO] AS' 
END
GO
-- PAGONTADESPACHO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_CLIENTE_POR_CODIGO]
	@cdcliente CHAR(20)
AS
	Select cdcliente, ruccliente, rscliente, drcliente, drcobranza, drentrega, tlfcliente, tlfcliente1,
	faxcliente, cddistrito, cddepartamento, cdzona, monlimite, mtolimite, mtodisponible, bloqcredito, emcliente,
	flgpreciond, flgtotalnd 
	FROM cliente where @cdcliente=ltrim(rtrim(cdcliente))
GO

/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_CLIENTES]    Script Date: 20/05/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_CLIENTES]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_CLIENTES] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_CLIENTES]
AS
	Select cdcliente, ruccliente, rscliente
	FROM cliente
GO

/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_CONF_PUNTO]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_CONF_PUNTO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_CONF_PUNTO] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_CONF_PUNTO]
	@PrefijoCard INT,
	@TipoAcumula CHAR(2),
	@Clave VARCHAR(30)
AS  
	select Articulo.TipoVar as TipoGrupo, Articulo.Clave as TipoProducto, concepto.*, tipoPunto.Descripcion as TipoAA
	FROM CnfgValorPunto as concepto
	join variables as tipoPunto on (TipoPunto.VarId = Concepto.TipoPunto) 
	join variables as Articulo on (Articulo.VarId = Concepto.Concepto) 
	where concepto.PrefijoCard = @PrefijoCard and 
	concepto.TipoAcumula = @TipoAcumula 
	and Articulo.Clave = @Clave
GO

/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_FORMATO_SERAFIN]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_FORMATO_SERAFIN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_FORMATO_SERAFIN] AS' 
END
GO
ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_FORMATO_SERAFIN]
AS
	Select tipo, linea, texto FROM Ticket Where documento='PROMOC' and tipo in ('C','P') order by tipo, linea
GO

/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_FORMATO_NOTA_VENTA]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_FORMATO_NOTA_VENTA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_FORMATO_NOTA_VENTA] AS' 
END
GO
ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_FORMATO_NOTA_VENTA]
AS
	Select tipo, linea, texto FROM Ticket Where documento='NVENTA' and tipo in ('C','P') order by tipo, linea
GO

/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_FORMATO_TICKET]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_FORMATO_TICKET]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_FORMATO_TICKET] AS' 
END
GO
ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_FORMATO_TICKET]
AS
	Select tipo, linea, texto FROM Ticket Where documento='TICKET' and tipo in ('C','P') order by tipo, linea
GO

/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_GRUPOS_CONSUMOS]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_GRUPOS_CONSUMOS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_GRUPOS_CONSUMOS] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_GRUPOS_CONSUMOS]
AS
	Select cdgrupos, dsgrupos, cdgrupo02 FROM Gruposconsumo
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_LOCAL_POR_ID]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_LOCAL_POR_ID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_LOCAL_POR_ID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_LOCAL_POR_ID]
	@cdlocal char(4)
AS
	Select drlocal FROM local Where ltrim(rtrim(cdlocal)) = @cdlocal
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_MOV_FACTURA]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_MOV_FACTURA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_MOV_FACTURA] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_MOV_FACTURA]
AS
	select * FROM TMPMovfactura
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_MOVDET_PUNTOS]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_MOVDET_PUNTOS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_MOVDET_PUNTOS] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_MOVDET_PUNTOS]
	@nrodocumento CHAR(10),
	@cdtipodoc CHAR(5),
	@tipotran CHAR(1),
	@localid CHAR(4),
	@nropos CHAR(10)
AS	
	SELECT * FROM tmpMovPuntos where NroDocumento = @nrodocumento and 
	cdtipodoc = @cdtipodoc  and 
    tipotran = @tipotran
	and  localid= @localid 
	and nropos= @nropos 
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_MOVIMIENTO_PUNTOS_POR_GRUPO_COMBUSTIBLE]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_MOVIMIENTO_PUNTOS_POR_GRUPO_COMBUSTIBLE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_MOVIMIENTO_PUNTOS_POR_GRUPO_COMBUSTIBLE] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_MOVIMIENTO_PUNTOS_POR_GRUPO_COMBUSTIBLE]
	@cdgrupo02 char(5),
	@localid char(4),
	@nropos char(10)
AS
	select * FROM TMPMovPuntos T, articulo A
	where t.cdproducto=A.cdarticulo and 
	A.cdgrupo02!= @cdgrupo02
	and T.localid= @localid and t.nropos= @nropos
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_MOVPUNTOS]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_MOVPUNTOS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_MOVPUNTOS] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_MOVPUNTOS]
	@cdarticulo CHAR(20),
	@cdgrupo02 CHAR(5),
	@tarjafiliacion VARCHAR(25),
	@localid CHAR(4),
	@nropos CHAR(10),
	@mtototal FLOAT
AS
-- trfgratuita ---
	select * FROM TMPMovPuntos T, articulo A 
	where A.cdarticulo=@cdarticulo and A.cdgrupo02= @cdgrupo02
	and t.tarjafiliacion=@tarjafiliacion and T.localid = @localid and t.nropos=@nropos 
	and t.mtototal=@mtototal 
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_PRECIO_CLIENTE]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_PRECIO_CLIENTE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_PRECIO_CLIENTE] AS' 
END
GO

---- MENSAJE_DEPOSITOS_GRIFERO -----

--Exec pa_Verifica_Depositos @ldNroPos, @ldFecha, @ldTurno, @mtominideposito


-- PAGAR --

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_PRECIO_CLIENTE]
AS
SELECT cdcliente, tipocli, tipodes, cdarticulo, precio FROM preciocliente
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_PRECIO_POR_ARTICULO_PRECIO]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_PRECIO_POR_ARTICULO_PRECIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_PRECIO_POR_ARTICULO_PRECIO] AS' 
END
GO

--CREATE PROCEDURE SP_ITBCP_LISTAR_PUNTOS_DISPONIBLES
--@txtBonus VARCHAR(25)
--AS
--	select ptosdisponibles FROM tarjetas Where tarjafiliacion = @txtBonus
--GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_PRECIO_POR_ARTICULO_PRECIO]
	@CdArticulo CHAR(20),
	@cdprecio CHAR(5) 
AS
Select * FROM PRECIO where CdArticulo = @CdArticulo and cdprecio= @cdprecio
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_PRECIOS]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_PRECIOS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_PRECIOS] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_PRECIOS]
AS
	Select cdprecio, substring(dsprecio,1,35) as dsprecio FROM ListaPrecio
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_PRECIOS_VARIOS]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_PRECIOS_VARIOS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_PRECIOS_VARIOS] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_PRECIOS_VARIOS]
	@cdarticulo CHAR(20),
	@tipocli CHAR(3)
AS
	Select CDARTICULO,TIPOCLI, TIPORANGO, RANGO1, RANGO2, FECHAMODIFICACION, TIPO, VALOR 
	FROM precio_varios 
	Where cdarticulo= @cdarticulo And 
	tipocli = @tipocli
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_PRECIOS_VARIOS_1]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_PRECIOS_VARIOS_1]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_PRECIOS_VARIOS_1] AS' 
END
GO

----- ticketautomatico ---

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_PRECIOS_VARIOS_1]
	@cdcliente VARCHAR(15),
	@cdarticulo CHAR(20),
	@tipocli CHAR(3) 
AS
	SELECT * FROM precio_VARIOS 
	where cdcliente=@cdcliente and cdarticulo=@cdarticulo and tipocli=@tipocli
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_PTOS_DISPONIBLES_POR_TARJETA_AFILIACION]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_PTOS_DISPONIBLES_POR_TARJETA_AFILIACION]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_PTOS_DISPONIBLES_POR_TARJETA_AFILIACION] AS' 
END
GO


ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_PTOS_DISPONIBLES_POR_TARJETA_AFILIACION]
	@tarjafiliacion CHAR(20)
AS
	select * FROM afiliacionTarj where tarjafiliacion = @tarjafiliacion
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_SALDO_CLIENTE]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_SALDO_CLIENTE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_SALDO_CLIENTE] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_SALDO_CLIENTE]
	@cdcliente CHAR(15) 
AS
	SELECT * FROM saldocliC WHERE @cdcliente=ltrim(rtrim(cdcliente))
	ORDER BY cdcliente 
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_SALDOCLID]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_SALDOCLID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_SALDOCLID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_SALDOCLID]
	@nrotarjeta CHAR(20)
AS
	SELECT cdcliente, nrotarjeta, cdgrupo02, cdarticulo, (limitemto-consumto) as saldomto,
	limitemto, consumto, nrobonus, nroplaca, flgilimit, flgbloquea, TipoDespacho, FechaAtencion, Enviado, Clave
	FROM saldocliD
	WHERE @nrotarjeta=ltrim(rtrim(nrotarjeta))
	ORDER BY cdcliente, nrotarjeta, cdgrupo02
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_SALDOCLID_1]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_SALDOCLID_1]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_SALDOCLID_1] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_SALDOCLID_1]
	@cdcliente CHAR(15)
AS
	SELECT cdcliente,tpsaldo,flgilimit, flgbloquea, (limitemto-consumto) as saldomto, limitemto, consumto, TipoDespacho, TipoCredito
	FROM saldocliC
	WHERE @cdcliente=ltrim(rtrim(cdcliente)) 
	ORDER BY cdcliente 
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_STOCK]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_STOCK]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_STOCK] AS' 
END
GO


ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_STOCK]
	@cdlocal CHAR(3),
	@cdalmacen CHAR(3)
AS
	SELECT cdlocal, cdalmacen, cdArticulo, stockactual As Stock
	FROM Stock Where cdlocal=@cdlocal And Stock.cdalmacen=@cdalmacen
	Order by cdarticulo
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_TALLAS]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_TALLAS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_TALLAS] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_TALLAS]
AS
	Select cdtalla, talla FROM Tallad
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_TARJETA_CONCEPTO]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_TARJETA_CONCEPTO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_TARJETA_CONCEPTO] AS' 
END
GO


--execute SP_ITBCP_Verifica_Campo_En_Tabla @cVenta, @cCampo, @cTipo
--[dbo].[SP_ITBCP_LISTAR_TARJETA_CONCEPTO] 'DD'
ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_TARJETA_CONCEPTO]
	@tarjafiliacion VARCHAR(25)
AS
	SELECT len(V.clave) as longi, V.TipoVar, V.Clave, V.Descripcion, V.Config, V.VarId FROM ( 
	SELECT top 1 c.prefijocard FROM tarjeta_concepto t join cnfgvalorpunto c on (c.valorid = t.valorid) 
	WHERE  t.tarjafiliacion = @tarjafiliacion ) as P join variables V on (V.VarId = P.prefijocard)  
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_TARJETA_CONCEPTO_1]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_TARJETA_CONCEPTO_1]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_TARJETA_CONCEPTO_1] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_TARJETA_CONCEPTO_1]
	@TarjAfiliacion VARCHAR(25)
AS
	select t.TarjAfiliacion,t.ValorID,
	ClaveConcepto=(select Clave FROM Variables where VarId=c.Concepto),
	TipoValoriza=(select Descripcion FROM Variables where VarId=c.TipoPunto),c.ValorPunto, c.tipoacumula
	FROM tarjeta_concepto t inner join CnfgValorPunto c on c.ValorID = t.ValorID where t.TarjAfiliacion = TarjAfiliacion
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_TERMINALES]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_TERMINALES]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_TERMINALES] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_TERMINALES]
AS
	Select nropos,seriehd FROM terminal order by nropos desc
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_TIPO_CAMBIO]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_TIPO_CAMBIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_TIPO_CAMBIO] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_TIPO_CAMBIO]
AS
	Select top 1 cambio FROM cambio order by fecha desc
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_TIPO_PAGO_EFECTIVO]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_TIPO_PAGO_EFECTIVO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_TIPO_PAGO_EFECTIVO] AS' 
END
GO


--EXEC pa_Mensajes_Predeterminados_Confi_Insertar @xlcliente, @xlrscliente
 
----- PAGOS EFECTIVO-----
ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_TIPO_PAGO_EFECTIVO]
	@cdtppago CHAR(5)
AS
	Select dstppago FROM tipopago Where @cdtppago=cdtppago
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_TIPO_PAGOS]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_TIPO_PAGOS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_TIPO_PAGOS] AS' 
END
GO


ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_TIPO_PAGOS]
AS
	Select cdtppago, dstppago FROM tipopago
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_TRANSACCION_ARTICULO]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_TRANSACCION_ARTICULO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_TRANSACCION_ARTICULO] AS' 
END
GO


-- REVISAPENDIENTE --
ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_TRANSACCION_ARTICULO]
	@cara CHAR(2)
AS
	SELECT top 1 o.numero,o.soles,o.producto as cdarticulo,o.precio,o.galones,o.cara,convert(varchar(10),o.hora,108) as hora,o.fecha as orden,o.fecha,o.turno,a.impuesto, 
	a.dsarticulo as producto,a.moverstock, a.dsarticulo1, a.cdgrupo01, o.documento, a.monctorepo, a.ctoreposicion, NULL as manguera,
	a.tpconversion, a.valorconversion, a.cdunimed, a.cdarticulosunat
	FROM OP_TRAN o JOIN articulo a ON (o.producto = a.cdarticulo)
	where cara = @cara and o.documento is null
	order by o.numero 
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_ULTIMO_CIERRE]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_ULTIMO_CIERRE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_ULTIMO_CIERRE] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_ULTIMO_CIERRE]
AS
	SELECT TOP 1 fecha FROM cierres ORDER BY fecha DESC
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VALE]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VALE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VALE] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VALE]
	@cdtipodoc CHAR(5),
	@nrovale CHAR(10)
AS
	SELECT nrovale, docvale, fecvale, cdmoneda, mtovale, mtovale1 = mtovale, mtovaleorig = mtovale, cdcliente 
	FROM hvale Where @cdtipodoc = cdtipodoc and @nrovale = nrovale
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VARIABLES]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VARIABLES]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VARIABLES] AS' 
END
GO
     
ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VARIABLES]
	@Clave VARCHAR(30)
AS
	select Prefijo.TipoVar, Prefijo.Clave, Acumula.Descripcion, Prefijo.Config, Prefijo.VarId
	FROM Variables as Prefijo
	left join variables as Acumula on (Acumula.Clave = Prefijo.Config and Acumula.TipoVar = 'TipoAcumula')
	where Prefijo.Clave = @Clave and Prefijo.TipoVar = 'Prefijo'
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VARIABLES_1]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VARIABLES_1]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VARIABLES_1] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VARIABLES_1]
	@PrefijoCard INT,
	@TipoAcumula CHAR(2)
AS
 
	select concepto.*, tipoPunto.Descripcion as TipoAA FROM CnfgValorPunto as concepto
	join variables as tipoPunto on (TipoPunto.VarId = Concepto.TipoPunto)
	where concepto.PrefijoCard = @PrefijoCard and concepto.TipoAcumula = @TipoAcumula
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTA]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VENTA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTA] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTA]
	@nropos CHAR(10),
	@fecproceso SMALLDATETIME,
	@Turno NUMERIC(5)
AS
	Select cdtipodoc, nrodocumento, mtosubtotal, mtoservicio, mtoimpuesto, mtototal, cdvendedor, 
	fecanula, cdusuanula, flgcierrez, cdlocal, ruccliente 
	FROM venta
	Where ltrim(rtrim(@nropos))!= ltrim(rtrim(venta.NroPos)) And @fecproceso=convert(char(10), fecproceso,103) and @Turno=Turno 
	And (flgcierrez=0 or flgcierrez is null ) Order By nrodocumento 
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTA_2]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VENTA_2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTA_2] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTA_2]
	@nropos CHAR(10),
	@fecproceso SMALLDATETIME,
	@Turno NUMERIC(5),
	@CDGRUPO02 CHAR(5)
AS
	Select c.cdtipodoc, c.nrodocumento, c.mtosubtotal, c.mtoservicio, c.mtoimpuesto, c.mtototal, c.cdvendedor, c.cdusuario,
	c.fecanula, c.cdusuanula, c.flgcierrez, c.cdlocal, c.ruccliente FROM venta c, ventad d, articulo a
	Where c.cdtipodoc=d.cdtipodoc and c.nrodocumento=d.nrodocumento and d.cdarticulo=a.cdarticulo and
	a.CDGRUPO02!= @CDGRUPO02 and
	ltrim(rtrim(@nropos))!= ltrim(rtrim(c.NroPos)) And @fecproceso = convert(char(10), c.fecproceso,103) and @Turno = c.Turno
	And (c.flgcierrez=0 or c.flgcierrez is null ) Order By c.nrodocumento
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTA_3]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VENTA_3]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTA_3] AS' 
END
GO


ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTA_3]
	@nropos CHAR(10),
	@fecproceso SMALLDATETIME,
	@Turno NUMERIC(5)	
AS
	Select fecproceso, sum(cantcupon) as cantcupon 
	FROM venta Where @nropos = ltrim(rtrim(Venta.NroPos)) And @fecproceso = convert(char(10), fecproceso,103) 
	and @Turno=Turno And (flgcierrez=0 or flgcierrez is null ) and (Venta.CdUsuAnula is null
	or LEN(LTRIM(RTRIM(Venta.CdUsuAnula))) = 0)   group by venta.fecproceso Order By venta.fecproceso

GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTA_4]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VENTA_4]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTA_4] AS' 
END
GO
 

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTA_4]
	@nropos CHAR(10),
	@fecproceso SMALLDATETIME,
	@Turno NUMERIC(5)
AS
	SELECT afiliacionptos.fecproceso,afiliacionptos.nropos,sum(afiliacionptos.valoracumula) AS valoracumula,venta.turno
	FROM venta  JOIN afiliacionptos  on venta.nrodocumento = afiliacionptos.nrodocumento where afiliacionptos.tipo='C' 
	And @nropos = ltrim(rtrim(afiliacionptos.NroPos)) And  @fecproceso=convert(char(10), 
	afiliacionptos.fecproceso,103) and @Turno=venta.Turno 
	group by afiliacionptos.fecproceso,afiliacionptos.nropos,venta.turno 
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTA_5]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VENTA_5]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTA_5] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTA_5]
	@nropos CHAR(10),
	@fecproceso SMALLDATETIME,
	@Turno NUMERIC(5)
AS
	Select Ventad.nrodocumento, Ventad.cdarticulo, Ventad.cantidad, Ventad.mtosubtotal,
	Ventad.mtoservicio, Ventad.mtoimpuesto, Ventad.cdtipodoc, Ventad.mtototal, Articulo.dsarticulo,
	Articulo.cdgrupo01, Articulo.cdgrupo02, Articulo.cdgrupo03, Articulo.cdgrupo04,Articulo.cdgrupo05, 
	'                    ' as dspago, ventad.cara, ventad.mtodscto, Ventad.talla, 
	Ventad.nroitem, '     ' as cdtppago, '                    ' as cdcliente, ' ' as tipocli
	FROM Ventad INNER JOIN  Articulo ON  Ventad.cdarticulo = Articulo.cdarticulo
	Join Venta as Venta ON(Venta.CdLocal = VentaD.CdLocal and Venta.NroSerieMaq = VentaD.NroSerieMaq and
	Venta.CdTipoDoc = VentaD.CdTipoDoc and Venta.NroDocumento = VentaD.NroDocumento) 
	Where @nropos= Ventad.NroPos And @fecproceso=convert(char(10), Ventad.fecproceso,103) 
	And @Turno=Ventad.Turno And (Ventad.flgcierrez=0 or Ventad.flgcierrez is null) and (Venta.CdUsuAnula is null
	or LEN(LTRIM(RTRIM(Venta.CdUsuAnula))) = 0)
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTA_6]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VENTA_6]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTA_6] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTA_6]
	@cdtipodoc CHAR(5),
	@cdUsuario CHAR(10),
	@nropos CHAR(10)
AS
	Select Distinct Venta.cdtipodoc, sum(Venta.mtototal) as mtototal FROM Venta
	Where @cdUsuario = ltrim(rtrim(Venta.cdusuario)) And @cdtipodoc != cdtipodoc
	And @nropos = Venta.NroPos and (venta.fecanula is null) Group by Venta.cdtipodoc Order By Venta.cdtipodoc
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTA_7]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VENTA_7]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTA_7] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTA_7]
	@cdtipodoc CHAR(5),
	@nropos CHAR(10)
AS
	Select Distinct Venta.cdtipodoc, sum(Venta.mtototal) as mtototal FROM Venta
	Where @cdtipodoc != Venta.cdtipodoc And @nroPos = Venta.NroPos and
	venta.fecanula is null Group By Venta.cdtipodoc Order By Venta.cdtipodoc
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTA_8]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VENTA_8]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTA_8] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTA_8]
	@nropos CHAR(10),
	@fecproceso SMALLDATETIME	
AS
	Select fecproceso, sum(cantcupon) as cantcupon 
	FROM venta Where @nropos = ltrim(rtrim(Venta.NroPos)) And @fecproceso=convert(char(10), fecproceso,103)
	 And (flgcierrez=0 or flgcierrez is null ) and (Venta.CdUsuAnula is null 
	 or LEN(LTRIM(RTRIM(Venta.CdUsuAnula))) = 0)   group by venta.fecproceso Order By venta.fecproceso 
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTA_9]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VENTA_9]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTA_9] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTA_9]
	@cdtipodoc CHAR(5),
	@nropos CHAR(10)
AS
	Select Distinct nrodocumento, mtosubtotal, mtoservicio, mtoimpuesto, mtototal, nropos, cdvendedor, 
	 fecanula, cdusuanula, flgcierrez, cdusuario, cdlocal, ruccliente FROM Venta 
	 Where (flgcierrez=0 or flgcierrez IS NULL) And @cdtipodoc = cdtipodoc 
	 And @nropos = NroPos Order By nrodocumento
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTAD]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VENTAD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTAD] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTAD]
	@nropos CHAR(10),
	@cdgrupo02 CHAR(5),
	@fecproceso SMALLDATETIME,
	@Turno NUMERIC(5)
AS
	Select Ventad.nrodocumento, Ventad.cdarticulo, Ventad.cantidad, Ventad.mtosubtotal,
	Ventad.mtoservicio, Ventad.mtoimpuesto, Ventad.cdtipodoc, Ventad.mtototal, Articulo.dsarticulo, 
	Articulo.cdgrupo01, Articulo.cdgrupo02, Articulo.cdgrupo03, Articulo.cdgrupo04,Articulo.cdgrupo05, 
	ventad.cara, Ventad.talla, Ventad.nroitem  
	FROM Ventad INNER JOIN  Articulo ON  Ventad.cdarticulo = Articulo.cdarticulo
	Join Venta as Venta ON(Venta.CdLocal = VentaD.CdLocal and Venta.NroSerieMaq = VentaD.NroSerieMaq and  
	Venta.CdTipoDoc = VentaD.CdTipoDoc and Venta.NroDocumento = VentaD.NroDocumento) 
	Where ltrim(rtrim(@nropos))!= ltrim(rtrim(Ventad.NroPos)) And articulo.cdgrupo02!=@cdgrupo02 
	And @fecproceso=convert(char(10), Ventad.fecproceso,103) 
	And @Turno=Ventad.Turno And (Ventad.flgcierrez=0 or Ventad.flgcierrez is null) and (Venta.CdUsuAnula is null
	 or LEN(LTRIM(RTRIM(Venta.CdUsuAnula))) = 0)
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTAD_1]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VENTAD_1]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTAD_1] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTAD_1]
	@cdtipodoc CHAR(5)
AS
	Select Distinct Ventad.nrodocumento, Ventad.cdarticulo, Ventad.cantidad, Ventad.mtosubtotal,
	 Ventad.mtoservicio, Ventad.mtoimpuesto, Ventad.mtototal, Articulo.dsarticulo,
	 Articulo.cdgrupo01, Articulo.cdgrupo02, Articulo.cdgrupo03, Articulo.cdgrupo04, Articulo.cdgrupo05,
	 Ventad.cara, Ventad.talla, Ventad.nroitem
	 FROM Ventad LEFT OUTER JOIN Articulo ON  Ventad.cdarticulo = Articulo.cdarticulo
	 Where @cdtipodoc = Ventad.cdtipodoc and (Ventad.flgcierrez=0 or Ventad.flgcierrez is null)
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTAD_2]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VENTAD_2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTAD_2] AS' 
END
GO
 
ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTAD_2]
	@cdtipodoc CHAR(5),
	@nrodocumento CHAR(10)
AS

	Select nroitem as item, cdarticulo, talla, impuesto, pordscto1, pordscto2, pordscto3, pordsctoeq, cantidad,
	precio, precio_orig, mtodscto, mtototal as total, valorvta, mtoimpuesto as impuesto, mtosubtotal as subtotal,
	mtoservicio,cara 
	FROM ventad 
	Where @cdtipodoc = cdtipodoc and @nrodocumento = nrodocumento
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTAP]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VENTAP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTAP] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTAP]
	@nropos CHAR(10),
	@fecproceso SMALLDATETIME,
	@Turno NUMERIC(5)
AS
	Select Ventap.cdtppago, Ventap.cdbanco, Ventap.cdtarjeta, ventap.cdtipodoc, Ventap.mtopagosol, 
	Ventap.mtopagodol, Ventap.nroncredito, Venta.fecanula, Venta.nrodocumento, Venta.mtovueltosol, 
	Venta.mtovueltodol, venta.tcambio, venta.cdcliente, venta.fecproceso 
	FROM ventap LEFT OUTER JOIN venta On Venta.cdtipodoc=Ventap.cdtipodoc And  Venta.nrodocumento=Ventap.nrodocumento
	Where @nropos = Ventap.NroPos And @fecproceso=convert(char(10), Ventap.fecproceso, 103)
	and @Turno= Ventap.Turno And (Ventap.flgcierrez=0 or Ventap.flgcierrez is null )
	Order By Venta.nrodocumento
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTAP_1]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VENTAP_1]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTAP_1] AS' 
END
GO


ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTAP_1]
	@cdtipodoc CHAR(5),
	@nropos CHAR(10)
AS

	Select Distinct Ventap.cdtppago, Ventap.cdbanco, Ventap.cdtarjeta, Ventap.mtopagosol, Ventap.mtopagodol,
	Ventap.nroncredito, Venta.fecanula, Ventap.nrodocumento, Venta.mtovueltosol, Venta.mtovueltodol, venta.tcambio 
	FROM ventap LEFT OUTER JOIN venta On (Venta.cdtipodoc + Venta.nrodocumento) = (Ventap.cdtipodoc + Ventap.nrodocumento) 
	Where (Ventap.flgcierrez=0 or Ventap.flgcierrez is null) And @cdtipodoc = Ventap.cdtipodoc
	And @nropos = Ventap.NroPos Order By Ventap.nrodocumento
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VENTAP_2]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VENTAP_2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTAP_2] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VENTAP_2]
	@cdtipodoc CHAR(5),
	@nrodocumento CHAR(10)
AS
	Select cdtppago, cdbanco, nrocuenta, nrocheque, cdtarjeta, nrotarjeta, mtopagosol, mtopagodol, nroncredito 
	FROM Ventap 
	Where @cdtipodoc = cdtipodoc and @nrodocumento = nrodocumento
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_VISTA_PUNTOS_TARJETA]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_VISTA_PUNTOS_TARJETA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_VISTA_PUNTOS_TARJETA] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_VISTA_PUNTOS_TARJETA]
	@cdArticulo  CHAR(20),
	@TarjAfiliacion VARCHAR(25)
AS
---verifica_puntos---
select * FROM Vw_Puntos_Por_Tarjeta where TarjAfiliacion = @TarjAfiliacion and cdArticulo = @cdArticulo
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTAR_ZONAS]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTAR_ZONAS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTAR_ZONAS] AS' 
END
GO



ALTER PROCEDURE [dbo].[SP_ITBCP_LISTAR_ZONAS]
AS
	Select cdzona, dszona FROM Zona
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LISTARTIPOCAMBIO]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LISTARTIPOCAMBIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LISTARTIPOCAMBIO] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LISTARTIPOCAMBIO]
AS
Select top 1 cambio FROM cambio order by fecha desc
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_LSITAR_TERMINAL_POR_USUARIO]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_LSITAR_TERMINAL_POR_USUARIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_LSITAR_TERMINAL_POR_USUARIO] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_LSITAR_TERMINAL_POR_USUARIO]
	@seriehd char(2),
	@cdusuario char(2)
AS
	Select nropos FROM terminal where seriehd != ltrim(rtrim(@seriehd)) and
	ltrim(rtrim(cdusuario)) = @cdusuario	
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_OBTENER_ALMACEN]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_OBTENER_ALMACEN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_OBTENER_ALMACEN] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_OBTENER_ALMACEN]
AS
	Select cdalmacen, substring(dsalmacen,1,35) as dsalmacen FROM almacen
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_OBTENER_FECHA_SERVIDOR]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_OBTENER_FECHA_SERVIDOR]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_OBTENER_FECHA_SERVIDOR] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_OBTENER_FECHA_SERVIDOR]
AS
	SELECT GETDATE() AS Fecha
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_OBTENER_IGV]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_OBTENER_IGV]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_OBTENER_IGV] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_OBTENER_IGV]
AS
	select top 1 * FROM tipo_igv order by 1 desc
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_OBTENER_LOCAL]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_OBTENER_LOCAL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_OBTENER_LOCAL] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_OBTENER_LOCAL]
	@cdlocal char(4)
AS
	Select * FROM local Where cdlocal = ltrim(rtrim(@cdlocal))
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_OBTENER_PORCENTAJE_DSCTO]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_OBTENER_PORCENTAJE_DSCTO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_OBTENER_PORCENTAJE_DSCTO] AS' 
END
GO
    
ALTER PROCEDURE [dbo].[SP_ITBCP_OBTENER_PORCENTAJE_DSCTO]
	@cdarticulo CHAR(20),
	@cantidad NUMERIC(9)
AS

	Select porcentaje FROM descuento Where cdarticulo = @cdarticulo And 
	@cantidad BETWEEN cantidad1 and cantidad2
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_OBTENER_RUTA]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_OBTENER_RUTA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_OBTENER_RUTA] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_OBTENER_RUTA]
AS
	Select * FROM RUTA
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_OBTENER_TIPO_INGRESO]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_OBTENER_TIPO_INGRESO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_OBTENER_TIPO_INGRESO] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_OBTENER_TIPO_INGRESO]
AS
	select descripcion FROM Variables where TipoVar = 'TipoFac' order by clave
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_OBTENER_TOPES_MONTO_VENTA]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_OBTENER_TOPES_MONTO_VENTA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_OBTENER_TOPES_MONTO_VENTA] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_OBTENER_TOPES_MONTO_VENTA]
AS
	select * FROM Variables  where TipoVar = 'TOPES'
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_VALIDAR_OPCION_PRINT_PANTALLA_OR_FISICO]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_VALIDAR_OPCION_PRINT_PANTALLA_OR_FISICO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_VALIDAR_OPCION_PRINT_PANTALLA_OR_FISICO] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_VALIDAR_OPCION_PRINT_PANTALLA_OR_FISICO]
AS
	SELECT ValorPto FROM variables
	WHERE UPPER(TipoVar)= 'NOIMPDOCVTA'
GO
/****** Object:  StoredProcedure [dbo].[SP_ITBCP_VENTA_CABECERA]    Script Date: 2/3/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_VENTA_CABECERA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_VENTA_CABECERA] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_VENTA_CABECERA]
	@nropos CHAR(10),
	@fecproceso SMALLDATETIME,
	@Turno NUMERIC(5)
AS
	Select cdtipodoc, nrodocumento, mtosubtotal, mtoservicio, mtoimpuesto, mtototal, cdvendedor, cdusuario,
	fecanula, cdusuanula, flgcierrez, cdlocal, ruccliente, tipoventa, referencia, nrobonus 
	FROM venta
	Where @nroPos= NroPos And @fecproceso=convert(char(10), fecproceso,103) and @Turno=Turno
	And (flgcierrez=0 or flgcierrez is null ) Order By nrodocumento
GO

/****** Object:  StoredProcedure [dbo].[SP_ITBCP_OBTENER_CORRELATIVO_POR_SERIE]    Script Date: 10/06/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_OBTENER_CORRELATIVO_POR_SERIE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_OBTENER_CORRELATIVO_POR_SERIE] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_OBTENER_CORRELATIVO_POR_SERIE]
	@seriehd CHAR(10)
AS
	SELECT nropos, factura, boleta, ticket, nventa, promocion, ncredito, ndebito FROM terminal WHERE seriehd = @seriehd
GO

/****** Object:  StoredProcedure [dbo].[SP_ITBCP_ACTUALIZAR_CORRELATIVO_POR_SERIE]    Script Date: 11/06/2019 12:51:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ITBCP_ACTUALIZAR_CORRELATIVO_POR_SERIE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ITBCP_ACTUALIZAR_CORRELATIVO_POR_SERIE] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ITBCP_ACTUALIZAR_CORRELATIVO_POR_SERIE]
	@tipodocumento VARCHAR(15),
	@nrodocumento CHAR(10),
	@seriehd CHAR(10)
AS
	DECLARE @SQL as NVARCHAR(MAX)

	SET @SQL = 'UPDATE terminal SET '+@tipodocumento+' = '''+@nrodocumento+''' WHERE seriehd = '''+@seriehd+''' '
	
	EXEC (@SQL)
GO
