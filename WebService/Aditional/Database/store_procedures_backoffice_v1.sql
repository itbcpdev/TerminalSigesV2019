 
 

 --******* START [SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD] ************
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_OBTENER_PARAMETRO') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_OBTENER_PARAMETRO]
END
go
 
create PROCEDURE [dbo].[SP_ITBCP_OBTENER_PARAMETRO]
 
AS
SELECT * FROM [parametro]
--******* END [[SP_ITBCP_OBTENER_PARAMETRO]] ************
GO
  

 --******* START [SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD] ************
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD]
END
go
 
create PROCEDURE [dbo].[SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD]
@seriehd CHAR(10)
AS
SELECT * FROM terminal where seriehd = ltrim(rtrim(@seriehd))
--******* END [SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD] ************
GO
 
  --******* START [SP_ITBCP_OBTENER_TIPO_CAMBIO] ************
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_OBTENER_TIPO_CAMBIO]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_OBTENER_TIPO_CAMBIO]
END
go
 
create PROCEDURE [dbo].[SP_ITBCP_OBTENER_TIPO_CAMBIO]
AS
SELECT top 1 * FROM cambio order by fecha desc 
--******* END [SP_ITBCP_OBTENER_TIPO_CAMBIO] ************
GO
   --******* START [SP_ITBCP_OBTENER_CIERRE] ************
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_OBTENER_CIERRE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_OBTENER_CIERRE]
END
go
 
create PROCEDURE [dbo].[SP_ITBCP_OBTENER_CIERRE]
@cdcierre char(1)
AS
Select * From Cierre Where cdcierre=@cdcierre
--******* END [SP_ITBCP_OBTENER_CIERRE] ************
GO
 
 
   --******* START [SP_ITBCP_LISTAR_TRANSACCION_PENDIENTE] ************
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_LISTAR_TRANSACCION_PENDIENTE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_LISTAR_TRANSACCION_PENDIENTE]
END
go
create PROCEDURE [dbo].[SP_ITBCP_LISTAR_TRANSACCION_PENDIENTE]
	@cara CHAR(2)
AS
	SELECT *
	FROM OP_TRAN
	where cara=@cara 
			and (documento is null or documento ='')
			and (cdtipodoc is null or cdtipodoc ='')
	order by numero 
 
--******* END [SP_ITBCP_LISTAR_TRANSACCION_PENDIENTE]     
 
GO
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_LISTAR_CARA_POR_POSICION]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_LISTAR_CARA_POR_POSICION]
END
go
create PROCEDURE [dbo].[SP_ITBCP_LISTAR_CARA_POR_POSICION]
	@nropos char(10)
AS
	SELECT * FROM cara WHERE ltrim(rtrim(nropos))= @nropos
go
--******* END [[SP_ITBCP_LISTAR_CARA_POR_POSICION]] 
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_LISTAR_CARA_POR_TERMINAL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_LISTAR_CARA_POR_CARA]
END
go
create PROCEDURE [dbo].[SP_ITBCP_LISTAR_CARA_POR_CARA]
	@cara char(10)
AS
	SELECT * FROM cara WHERE ltrim(rtrim(cara))= @cara
go
--******* END [SP_ITBCP_LISTAR_CARA_POR_CARA]     
 
GO
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_OBTENER_TIPO_CAMBIO]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_OBTENER_TIPO_CAMBIO]
END
go
create PROCEDURE [dbo].[SP_ITBCP_OBTENER_TIPO_CAMBIO]
AS
	Select top 1 cambio FROM cambio order by fecha desc
GO
--******* END [[SP_ITBCP_OBTENER_TIPO_CAMBIO]] 
GO
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_LISTAR_TIPO_PAGOS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_LISTAR_TIPO_PAGOS]
END
go
    
 create PROCEDURE [dbo].[SP_ITBCP_LISTAR_TIPO_PAGOS]
AS
	Select cdtppago, dstppago FROM tipopago

	--******* END [SP_ITBCP_LISTAR_TIPO_PAGOS] 
GO
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_OBTENER_GESTIONFLOTAC]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_OBTENER_GESTIONFLOTAC]
END
go
    
 create PROCEDURE [dbo].[SP_ITBCP_OBTENER_GESTIONFLOTAC]
 @cdcliente char(15)
AS
	Select * FROM gestionflotac where RTRIM(LTRIM(cdcliente))= @cdcliente
	--******* END [[SP_ITBCP_OBTENER_GESTIONFLOTAC]] 
GO

IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_OBTENER_GESTIONFLOTAD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_OBTENER_GESTIONFLOTAD]
END
go
    
 create PROCEDURE [dbo].[SP_ITBCP_OBTENER_GESTIONFLOTAD]
@nrotarjeta char(20)
AS
	Select * FROM gestionflotad  where RTRIM(LTRIM(nrotarjeta))= @nrotarjeta
GO

IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_LISTAR_PRODUCTOS_PRECIOS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_LISTAR_PRODUCTOS_PRECIOS]
END
go
    
create PROCEDURE [dbo].[SP_ITBCP_LISTAR_PRODUCTOS_PRECIOS]
--@cdarticulo char(20)
AS

	--Select a.cdarticulo, a.dsarticulo, a.cdunimed, a.cdgrupo01, a.cdgrupo02,a.cdgrupo03,a.cdgrupo04,a.cdgrupo05,a.cdarticulosunat,a.impuesto, a.bloqvta,a.moverstock,a.venta,a.bloqgral, a.movimiento, a.vtaxmonto, 
	--		p.mtoprecio			
	--		 FROM articulo a 
	--			inner join precio p 
	--			on p.cdarticulo = a.cdarticulo  
	-- go

 	SELECT a.cdarticulo, p.mtoprecio, a.impuesto, a.dsarticulo, a.moverstock, a.dsarticulo1, a.cdgrupo01, a.monctorepo, a.ctoreposicion, a.cdunimed, a.cdarticulosunat
	FROM articulo a JOIN precio p ON (a.cdarticulo = p.cdarticulo)
	WHERE a.cdgrupo05 = '00001' AND cdgrupo01 <> '00999' AND moverstock = 1 AND a.bloqvta = 0 AND a.bloqgral = 0
	ORDER BY dsarticulo DESC

GO


	