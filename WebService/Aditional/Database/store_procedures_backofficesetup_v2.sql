
GO
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_LISTAR_TIPO_TARJETA]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_LISTAR_TIPO_TARJETA]
END
go
create PROCEDURE [dbo].[SP_ITBCP_LISTAR_TIPO_TARJETA]
 
AS
Select * from tab0s08 
go
--******* START SP_S_PARAMETERS ************
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_S_PARAMETERS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_S_PARAMETERS]
END
go
create PROCEDURE [dbo].[SP_ITBCP_S_PARAMETERS]
AS
select * from dbo.tab0s00
--******* END SP_S_PARAMETERS ************
GO
--******* START [SP_ITBCP_AUTENTICA_USER] ************
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_AUTENTICA_USER]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_AUTENTICA_USER]
END
go
 
create PROCEDURE [dbo].[SP_ITBCP_AUTENTICA_USER]
@vcdUsuario char(60),
@vPassword numeric (4,0)
AS

SELECT T1.cdusuario, 
		T1.dsusuario, 
		T1.password 
		FROM tab0s02 T1 WHERE T1.cdusuario = @vcdUsuario
							  and T1.password = @vPassword

--******* END [SP_ITBCP_AUTENTICA_USER] ************
GO
--******* START [SP_ITBCP_S_MODULO] ************
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_S_MODULO]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_S_MODULO]
END
go
 
create PROCEDURE [dbo].[SP_ITBCP_S_MODULO]
 
AS

Select * from TAB0S17

--******* END [SP_ITBCP_S_MODULO] ************
GO
GO
--******* START [SP_ITBCP_S_NIVEL] ************
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_S_NIVEL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_S_NIVEL]
END
go
 
create PROCEDURE [dbo].[SP_ITBCP_S_NIVEL]
 @vtipo char(3),
 @vcdUsuario char(60),
 @vcdempresa char(2) 
AS

Select * from TAB1S99 
where Tipo=@vtipo and 
		codigo=@vcdUsuario and 
			Cdempresa=@vcdempresa

--******* END [SP_ITBCP_S_NIVEL] ************
GO
 --******* START [SP_ITBCP_S_ACCESOS] ************
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_S_ACCESOS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_S_ACCESOS]
END
go
 
create PROCEDURE [dbo].[SP_ITBCP_S_ACCESOS]
 @vcdNivel char(2) 
AS

Select * from tab0s12 
where cdnivel=@vcdNivel  

--******* END [SP_ITBCP_S_ACCESOS] ************
GO
 --******* START [SP_ITBCP_S_EMPRESA_USUARIO] ************
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_S_EMPRESA_USUARIO]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_S_EMPRESA_USUARIO]
END
go
 
create PROCEDURE [dbo].[SP_ITBCP_S_EMPRESA_USUARIO]
 @vcdUsuario char(60)
AS

SELECT	T1.cdempresa, 
		T1.dsempresa, 
		T1.drempresa, 
		T1.conexion,
		T1.rucempresa,
		T2.cdnivel, 
		T1.facturacion_electronica  
		 FROM tab0s01 T1 INNER JOIN tab1s99 T2  
			ON T2.cdempresa = T1.cdempresa  
				WHERE T2.codigo=@vcdUsuario AND 
					   T2.tipo='USU' 
				ORDER BY T1.dsempresa

--******* END [SP_ITBCP_S_EMPRESA_USUARIO] ************
GO

--******* START [SP_ITBCP_S_EMPRESA_USUARIO_TURNO] ************
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_AUTENTICA_USER_TURNO]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_AUTENTICA_USER_TURNO]
END
go
 
create PROCEDURE [dbo].[SP_ITBCP_AUTENTICA_USER_TURNO]
@vcdUsuario char(60),
@vPassword numeric (4,0),
@vcdEmpresa char(2)
AS

SELECT T1.cdusuario, 
		T1.dsusuario, 
		T1.password 
		FROM tab0s02 T1 INNER JOIN tab1s99 T2 
			ON (T1.cdusuario = T2.codigo)
				WHERE T1.cdusuario = @vcdUsuario AND 
					  T1.password = @vPassword AND
					  T2.cdempresa = @vcdEmpresa AND
					  CONVERT(INT,T2.cdnivel) <= 3

--******* END [SP_ITBCP_AUTENTICA_USER_TURNO] ************
GO

 --******* START [SP_ITBCP_LISTAR_MONEDAS] ************
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_LISTAR_MONEDAS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_LISTAR_MONEDAS]
END
go
 
create PROCEDURE [dbo].[SP_ITBCP_LISTAR_MONEDAS]
 
AS

Select * from tab0s14

--******* END [SP_ITBCP_LISTAR_MONEDAS] ************
GO

 --******* START [SP_ITBCP_OBTENER_MONEDA] ************
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[SP_ITBCP_OBTENER_MONEDA]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN 
	DROP PROCEDURE [dbo].[SP_ITBCP_OBTENER_MONEDA]
END
go
 
create PROCEDURE [dbo].[SP_ITBCP_OBTENER_MONEDA]
  @cdmoneda char(60)
AS

Select * from tab0s14 where cdmoneda = @cdmoneda

--******* END [SP_ITBCP_OBTENER_MONEDA] ************
GO

