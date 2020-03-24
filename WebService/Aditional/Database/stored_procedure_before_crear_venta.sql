CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_TRANSACCION
	@nombreTabla VARCHAR(50)
AS

 DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (Numero Char(4) Null, Soles Char(6) Null, producto Char(2) Null, ' +
		'Precio Char(4) Null, galones Char(8) Null, Cara Char(2) Null, Fecha Char(6) Null, Hora Char(4) Null, ' + 
		'Turno Char(1) Null, cdtipodoc Char(5) Null, Documento Char(10) Null, Fecproceso SMALLDATETIME Null) '
	
	EXEC (@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_INSUMOIS
	@nombreTabla VARCHAR(50)
AS

	DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + '(cdlocal Char(3) NOT NULL, nroseriemaq Char(20) NOT NULL, ' +
		  'cdtpmov Char(5) NOT Null, nromov Char(10) NOT Null, cdtipodoc Char(5) NOT Null, nrodocumento Char(15) NOT Null, ' +
		  'movimiento Char(1) NOT Null, cdalmacen Char(3) Null, nroitem numeric(4) NOT Null, cdarticulo Char(20) NOT Null, ' +
		  'talla Char(10) NOT Null, cantidad Numeric(12,4) Null, monctorepo Char(1) Null, ctoreposicion Numeric(14,6) Null, ' +
		  'ctopromedio Numeric(14,6) Null, tcambio Numeric(10,6) Null, fecdocumento DATETIME Null, flganulacion bit Null, ' +
		  'fecsistema DATETIME Null, fecproceso SMALLDATETIME NULL, precio Numeric(12,4) null, CONSTRAINT PK_' + @nombreTabla + 
		  ' PRIMARY KEY (cdlocal,nroseriemaq,movimiento,cdtpmov,nromov,cdtipodoc,nrodocumento,nroitem,cdarticulo,talla) )' 

	EXEC(@SQL)
GO


CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_NOVENTA
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (nropos char(10) NOT NULL, fecproceso SMALLDATETIME NOT NULL, ' +
		'turno numeric(2,0) NULL, cantidad numeric(6,0) NULL, ' + 
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (nropos, fecproceso) )'
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_VENTA
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal char(3) NOT NULL, nroseriemaq char(20) NOT NULL, ' +
		'cdtipodoc char(5) NOT NULL, nrodocumento char(10) NOT NULL, fecdocumento DATETIME NULL, ' +
		'fecproceso SMALLDATETIME  NULL, fecsistema SMALLDATETIME NULL, nropos char(10) NULL, ' +
		'mtovueltosol numeric(12,4) NULL,mtovueltodol numeric(12, 4) NULL, cdalmacen char(3) NULL, ' +
		'cdcliente char(20) NULL, ruccliente char(15) NULL, rscliente varchar(120) NULL, nroproforma char(10) NULL, ' +
		'cdprecio char(5) NULL, cdmoneda char(1) NULL, porservicio numeric(6, 2) NULL, pordscto1 numeric(6,2) NULL, ' +
		'pordscto2 numeric(6,2) NULL, pordscto3 numeric(6,2) NULL, pordsctoeq numeric(6,2) NULL, ' +
		'mtonoafecto numeric(12,4) NULL, valorvta numeric(12,4) NULL, mtodscto numeric(12,4) NULL, ' +
		'mtosubtotal numeric(12,4) NULL, mtoservicio numeric(12,4) NULL, mtoimpuesto numeric(12,4) NULL, ' +
		'mtototal numeric(12,4) NULL, cdtranspor char(20) NULL, ructranspor char(15) NULL, nroplaca varchar(250) NULL, ' +
		'drpartida char(60) NULL, MarcaVehic char(15) null,  ' +
		'drdestino char(60) NULL, cdusuario char(10) NULL, cdvendedor char(10) NULL, cdusuanula char(10) NULL, ' +
		'fecanula SMALLDATETIME NULL, fecanulasis SMALLDATETIME NULL, tipofactura char(1) NULL, flgmanual bit NULL, ' +
		'tcambio numeric(10,6) NULL, nroocompra char(15) NULL, flgcierrez bit NULL, observacion char(250) NULL, ' +
		'flgmovimiento bit NULL, referencia char(250) NULL, nroserie1 char(15) NULL, nroserie2 char(10) NULL, ' +
		'turno numeric(2,0) NULL, nrobonus char(20) NULL, nrotarjeta char(20) NULL, odometro char(10) NULL, ' +
		'archturno bit NULL, mtorecaudo numeric(12,4) NULL, inscripcion char(15) null, chofer char(40) null, nrolicencia char(15) null, ' +
		'chkespecial bit NULL, tipoventa char(1) NULL, nrocelular char(12) null, PtosGanados numeric(5,0) null, TipoAcumula char(2) NULL, ValorAcumula numeric(12,2) NULL, ' +
		'c_centralizacion Varchar(50) null, cantcupon numeric(12,2) null, mtocanje numeric(12,4) null, MtoPercepcion numeric(12,2) null, ' +
		'cdruta char(10) NULL, Codes varchar(250), codeID varchar(250), mensaje1 varchar(120), mensaje2 varchar(120), pdf417 varchar(450), ' +
		'cdhash varchar(50), scop varchar(50), nroguia varchar(50), mtodetraccion numeric(12,2), porcdetraccion numeric(5,2), ctadetraccion char(20),' +
		'fact_elect bit null, redondea_indecopi  numeric(12,4) null,cdMedio_Pago char(3) ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, nroseriemaq, cdtipodoc, nrodocumento) ) '
EXEC(@SQL)
GO		

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_VENTAD
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal char(3) NOT NULL, nroseriemaq char(20) NOT NULL, ' +
		'nropos char(10) NULL, cdtipodoc char(5) NOT NULL, nrodocumento char(10) NOT NULL, ' +
		'fecdocumento DATETIME NULL, fecproceso SMALLDATETIME NULL, nroitem numeric(3,0) NOT NULL, ' +
		'cdarticulo char(20) NOT NULL, cdalterna char(20) NULL, talla char(10) NOT NULL, cdvendedor char(10) NULL, ' +
		'impuesto numeric(6,2) NULL, pordscto1 numeric(6,2) NULL, pordscto2 numeric(6,2) NULL, ' +
		'pordscto3 numeric(6,2) NULL, pordsctoeq  numeric(6,2) NULL, cantidad numeric(12,4) NULL, ' +
		'cant_ncredito numeric(12,4) NULL, precio numeric(12,4) NULL, mtonoafecto numeric(12,4) NULL, ' +
		'valorvta numeric(12,4) NULL, mtodscto numeric(12,4) NULL, mtosubtotal numeric(12,4) NULL, ' +
		'mtoservicio numeric(12,4) NULL, mtoimpuesto numeric(12,4) NULL, mtototal numeric(12,4) NULL, ' +
		'flgcierrez bit NULL, cara char(2) NULL, nrogasboy char(20) NULL, turno  numeric(2,0) NULL, ' +
		'nroguia  char(10) NULL, nroproforma char(10) NULL, moverstock  bit NULL, glosa text NULL, ' +
		'manguera char(1) NULL, costo numeric(12,4) NULL, precio_orig numeric(12,4) NULL, precioafiliacion numeric(12,4) NULL, ' +
		'PtosGanados numeric(10,0) null, TipoAcumula varchar(50) null, ValorAcumula numeric(12, 2) null, ' +
		'TipoSuma varchar(50) null, Costo_Venta numeric(12,4) null, MtoPercepcion numeric(12,2) null, cdpack char(20) null, ' +
		'mtodetraccion numeric(12,2), porcdetraccion numeric(5,2), redondea_indecopi numeric(12,4), cdarticulosunat varchar(20) ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, nroseriemaq, cdtipodoc, nrodocumento, ' +
		'nroitem, cdarticulo, talla) ) '
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_VENTAP
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal char(3) NOT NULL, nroseriemaq char(20) NOT NULL, ' +
		'nropos  char(10) NULL, cdtipodoc char(5) NOT NULL, nrodocumento char(10) NOT NULL, cdtppago char(5) NOT NULL, ' +
		'fecdocumento DATETIME NULL, fecproceso SMALLDATETIME NULL, cdbanco  char(4) NOT NULL, ' +
		'nrocuenta char(20) NOT NULL, nrocheque char(20) NOT NULL, cdtarjeta char(2) NOT NULL, ' +
		'nrotarjeta char(20) NOT NULL, mtopagosol numeric(12,4) NULL, mtopagodol numeric(12,4) NULL, ' +
		'flgcierrez bit NULL, turno numeric(2,0) NULL, nroncredito char(10) NULL, valoracumula numeric(12,4) ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, nroseriemaq, cdtipodoc, nrodocumento, cdtppago, ' +
		'cdbanco, nrocuenta, nrocheque, cdtarjeta, nrotarjeta) ) '
EXEC(@SQL)
GO


CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_INGRESO
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE '+ @nombreTabla + ' (cdlocal char(3) NOT NULL, cdtpingreso char(5) NOT NULL, ' +
		'nroingreso char(10) NOT NULL, cdtipodoc char(5) NULL, nrodocumento char(15) NULL, ' +
		'cdproveedor char(15) NULL, cdalmacen char(3) NULL, cdalmorig char(3) NULL, cdmoneda char(1) NULL, ' +
		'mtosubtotal numeric(12,4) NULL, mtoimpuesto numeric(12,4) NULL, mtoimpuesto1 numeric(12,4) NULL, ' +
		'mtototal numeric(12, 4) NULL, tcambio numeric(10, 6) NULL, fecingreso SMALLDATETIME NULL, ' +
		'fecsistema SMALLDATETIME NULL, cdusuario char(10) NULL, fecanula SMALLDATETIME NULL, ' +
		'fecanulasis SMALLDATETIME NULL, cdusuanula char(10) NULL, observacion char(80) NULL, c_centralizacion bigint null, ' +
		'fecproceso SMALLDATETIME NULL, FECVENCIMIENTO SMALLDATETIME NULL, SCOP char(11) NULL, nropedido char(15) NULL, ' +
		'cancelado bit null, mtopercepcion numeric(12,4) NULL, FISE numeric(12,4) NULL, ' +
		'nroseriedoc char(5) NULL, NumSAP char(20) NULL, Redondeo numeric(14,4) NULL, IsSAP BIT, Flete numeric(12,4) NULL ' +
		' CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, cdtpingreso, ' +
		'nroingreso)) '
EXEC(@SQL)
GO


CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_INGRESOD
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal char(3) NOT NULL, cdtpingreso char(5) NOT NULL, ' +
		'nroingreso char(10) NOT NULL, nroitem numeric(4, 0) NOT NULL, cdarticulo char(20) NOT NULL, ' +
		'talla char(10) NOT NULL, cdalternativo char(20) NULL, cdcompra char(20) NULL, cdalmacen char(3) NULL, ' +
		'fecingreso SMALLDATETIME NULL, cantidad  numeric(12,7) NULL, costo  numeric(14,7) NULL, ' +
		'mtosubtotal numeric(12,4) NULL, mtoimpuesto numeric(12,4) NULL, mtoimpuesto1 numeric(12,4) NULL, ' +
		'mtototal numeric(12, 4) NULL, ctopromedio numeric(12, 4) NULL, impuesto numeric(6, 2) NULL, ' +
		'impuesto1 numeric(6, 2) NULL, tcambio numeric(10, 6) NULL, cdmoneda char(1) NULL, ' +
		'precactual numeric(11, 2) NULL, mgutilidad numeric(7, 2) NULL, preciosug numeric(11, 2) NULL, ' +
		'flgcambprec bit NULL, categoria char(5) NULL, Linea numeric(4, 0) NULL,CostoFlete numeric(12,4) NULL ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, cdtpingreso, nroingreso, nroitem, cdarticulo, talla) )'
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_SALIDA
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal char(3) NOT NULL, cdtpsalida char(5) NOT NULL, ' +
		'nrosalida char(10) NOT NULL, cdtipodoc char(5) NULL, nrodocumento char(15) NULL, cdproveedor char(15) NULL, ' +
		'cdalmacen char(3) NULL, cdalmdest char(3) NULL, nroingreso char(10) NULL, cdmoneda char(1) NULL, ' +
		'mtosubtotal numeric(12, 4) NULL, mtoimpuesto numeric(12, 4) NULL, mtoimpuesto1 numeric(12, 4) NULL, ' +
		'mtototal numeric(12, 4) NULL, tcambio numeric(10, 6) NULL, fecsalida  SMALLDATETIME NULL, ' +
		'fecsistema SMALLDATETIME NULL, cdusuario char(10) NULL, fecanula SMALLDATETIME NULL, ' +
		'fecanulasis SMALLDATETIME NULL, cdusuanula char(10) NULL, observacion varchar(80) NULL, ' +
		'fecproceso SMALLDATETIME NULL, IsSAP BIT ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, cdtpsalida, nrosalida) )'
EXEC(@SQL)
GO


CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_SALIDAD
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal char(3) NOT NULL, cdtpsalida char(5) NOT NULL, ' +
		'nrosalida char(10) NOT NULL, nroitem numeric(4,0) NOT NULL, cdarticulo char(20) NOT NULL, ' +
		'talla char(10) NOT NULL, cdalmacen char(3) NULL, fecsalida SMALLDATETIME NULL, cdalternativo char(20) NULL, ' +
		'cdcompra char(20) NULL, cantidad numeric(12,4) NULL, costo numeric(12,4) NULL, precio numeric(12,4) NULL, ' +
		'mtosubtotal numeric(12,4) NULL, mtoimpuesto numeric(12,4) NULL, mtoimpuesto1 numeric(12,4) NULL, ' +
		'mtototal numeric(12, 4) NULL, ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, cdtpsalida, nrosalida, nroitem, cdarticulo, talla) )'
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_GUIA
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (CDLOCAL Char(3) NOT NULL, FECGUIA SMALLDATETIME Null, ' +
		'FECSISTEMA SMALLDATETIME Null, NROPOS Char(10) Null, CDTPGUIA Char(5) Null, NROGUIA Char(10) NOT Null, ' +
		'CDCLIENTE Char(15) Null, RUCCLIENTE Char(15) Null, RSCLIENTE Char(60) Null, DRCLIENTE Char(60) Null, ' +
		'CDPRECIO Char(5) Null, CDMONEDA  Char(1) Null, PORDSCTO1 Numeric(7,2) Null, PORDSCTO2 Numeric(7,2) Null, ' +
		'PORDSCTO3 Numeric(7,2) Null, PORDSCTOEQ Numeric(7,2) Null, VALORVTA Numeric(12,4) Null, ' +
		'MTODSCTO Numeric(12,4) Null, MTOSUBTOTAL Numeric(12,4) Null, MTOIMPUESTO Numeric(12,4) Null, ' +
		'MTOTOTAL Numeric(12,4) Null, CDUSUARIO Char(10) Null, CDVENDEDOR Char(10) Null, ructranspor char(15) NULL, ' +
		'CDUSUANULA Char(10) Null, FECANULA SMALLDATETIME Null, FECANULASIS SMALLDATETIME Null, TCAMBIO Numeric(10,6) Null, ' +
		'OBSERVACION Char(50) Null, ESTADO Numeric(1) Null, CDTRANSPOR Char(10) Null, nroplaca Char(10) Null, ' +
		'DRPARTIDA Char(60) Null, DRDESTINO Char(60) Null, CDALMACEN Char(3) Null, NROOCOMPRA Char(15) Null, ' +
		'MarcaVehic char(15) null, inscripcion char(15) null, chofer char(40) null, nrolicencia char(15) null, ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, nroguia) )'
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_GUIAD
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (CDLOCAL Char(3) NOT Null, NROPOS  Char(10) Null, NROGUIA Char(10) NOT Null, ' +
		'NROITEM Numeric(3) Null, CDARTICULO Char(20) NOT Null, CDALTERNA Char(20) Null, TALLA char(10) Null, ' +
		'CANTIDAD Numeric(12,4) Null, CANTFACTURADA Numeric(12,4) Null, PRECIO Numeric(12,4) Null, ' +
		'IMPUESTO Numeric(7,2) Null, PORDSCTO1 Numeric(7,2) Null, PORDSCTO2 Numeric(7,2) Null, PORDSCTO3 Numeric(7,2) Null, ' +
		'PORDSCTOEQ Numeric(7,2) Null, VALORVTA Numeric(12,4) Null, MTODSCTO Numeric(12,4) Null, ' +
		'MTOSUBTOTAL Numeric(12,4) Null, MTOIMPUESTO Numeric(12,4) Null, MTOTOTAL Numeric(12,4) Null, ' +
		'NROPROFORMA Char(10) NOT Null, glosa Text Null, peso Numeric(11,3) null, moverstock Bit Null, cdunimed char(5) null, ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, nroguia, cdarticulo, nroproforma) )'
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_NCREDITO
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal char(3) NOT NULL, nroncredito Char(10) NOT NULL, ' +
		'fecncredito SMALLDATETIME NULL, fecproceso SMALLDATETIME NULL, fecsistema SMALLDATETIME NULL, ' +
		'nropos Char(10) Null, NroSerie1 Char(15) Null, NroSerie2 Char(10) Null, cdcliente Char(15) Null, ' +
		'ruccliente Char(15) Null, rscliente Char(60) Null, cdmoneda Char(1) Null, mtosubtotal numeric(12,4) Null, ' +
		'mtoimpuesto Numeric(12,4) Null, mtototal Numeric(12,4) Null, cdusuario Char(10) Null, cdusuanula Char(10) Null, ' +
		'fecanula SMALLDATETIME Null, fecanulasis SMALLDATETIME Null, tcambio Numeric(10,6) Null, ' +
		'tcambioorigen Numeric(10,6) Null, observacion Char(60) Null, flgdevolucion bit Null, Tiponcredito char(1) Null, ' +
		'cdmotncredito Char(5) Null, pdf417 Varchar(450) Null, cdhash Varchar(50) Null, sustento Varchar(60) Null, ' +
		'docreferencia Varchar(13), fecreferencia Datetime, turno numeric(2,0), flgmanual bit, cddocorigen char(5) ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, nroncredito) ) '
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_NCREDITOD
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE '+ @nombreTabla + ' (cdlocal char(3) NOT NULL, nroncredito char(10) NOT NULL, ' +
		'nroitem Numeric(3) NOT NULL, cdarticulo char(20) NOT NULL, dsarticulo varchar(100) NOT NULL, talla char(10) NOT NULL, ' +
		'cdvendedor char(10) null, cdalmacen char(3) null, cddocorigen char(5) null, nrodocorigen Char(10) Null, ' +
		'nroitemorigen Numeric(3) Null, fecorigen SMALLDATETIME NULL, tcambioorigen Numeric(10,6) Null, ' +
		'impuesto Numeric(6,2) Null, cantidad Numeric(12,4) Null, precio Numeric(12,4) Null, mtosubtotal Numeric(12,4) Null, ' +
		'mtoimpuesto Numeric(12,4) Null, mtototal Numeric(12,4) Null, moverstock bit Null, cara char(2), cdunimed char(5),' +
		'cdarticulosunat varchar(20), ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, nroncredito, nroitem, cdarticulo, talla) ) '
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_DIASISLAVENDEDOR
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal char(3) Not Null, fecproceso SMALLDATETIME Not Null, ' +
		'turno numeric(2) Not NULL, isla char(2) Not NULL, cdvendedor char(10) not NULL, lado char(2) not null DEFAULT (''01'') ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, fecproceso, turno, isla, cdvendedor, lado) )'
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_DIADEPVENDEDOR
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal char(3) Not Null, fecproceso SMALLDATETIME Not NULL, ' +
		'turno numeric(2) Not NULL, cdvendedor char(10) Not NULL, cdtppago char(5) Not NULL, ' +
		'nrodeposito Numeric(10) Not NULL, mtosoles numeric(12,2) NULL, mtodolar numeric(12,2) NULL, ' +
		'tcambio numeric(10,6) NULL, cdtarjeta char(2) NULL, nrotarjeta char(20) NULL, glp bit Null, ' +
		'nrosobres numeric(3,0) NULL, nrodocumento char(10) NULL, cdproveedor char(15) NULL, cdtipodoc char(5) NULL, nropos char(10) NULL ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, nrodeposito, fecproceso, turno, cdvendedor, cdtppago) )'
EXEC(@SQL)		
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_FALTSOBR
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal char(3) Not Null, fecproceso SMALLDATETIME Not NULL, ' +
		'turno numeric(2) Not NULL, cdvendedor char(10) Not NULL, total_ing numeric(12,2) Not Null, totalvta numeric(12,2) Not Null, nropos char(10) not null ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, fecproceso, turno, cdvendedor, nropos) )'
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_DIACAJA
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal char(3) Not null, fecproceso SMALLDATETIME Not NULL, ' +
		'item numeric(3) NOT NULL, dsingreso char(50) NOT NULL, mtosoles numeric(12,2) NULL, ' +
		'mtodolar numeric(12,2) NULL, tcambio numeric(10,6) NULL, CONSTRAINT PK_' + @nombreTabla  +
		' PRIMARY KEY (cdlocal, fecproceso, item, dsingreso) )'
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_DIACOBRANZA
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal char(3) Not null, fecproceso SMALLDATETIME Not NULL, ' +
		'cdtppago char(5) Not NULL, mtosoles numeric(12,2) NULL, mtodolar numeric(12,2) NULL, ' +
		'tcambio numeric(10,6) NULL, CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, fecproceso, cdtppago) )'
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_DIACONTOMETRO
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal char(3) Not null, fecproceso SMALLDATETIME Not NULL, ' +
		'turno numeric(2) Not NULL, lado char(2) Not NULL, manguera char(2) Not NULL, cdarticulo char(20) null, Inicial Numeric(14,4) NULL, ' +
		'final numeric(14,4) NULL,  galonesc numeric(12,4) NULL, precio numeric(12,4) NULL, total numeric(12,2) NULL, ' +
		'galonespec numeric(12,4) NULL, totalpec numeric(12,4) NULL, NOCONTA numeric(12,4) NULL ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, fecproceso, turno, lado, manguera) )'
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_DIACONTOMETROMANUAL
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal char(3) Not null, fecproceso SMALLDATETIME Not NULL, ' +
		'turno numeric(2) Not NULL, lado char(2) Not NULL, manguera char(2) Not NULL, cdarticulo char(20) null, Inicial Numeric(14,4) NULL, ' +
		'final numeric(14,4) NULL,  galonesc numeric(12,4) NULL, precio numeric(12,4) NULL, total numeric(12,2) NULL, ' +
		'galonespec numeric(12,4) NULL, totalpec numeric(12,4) NULL, Observaciones char (100)  NULL, dsusuario char (20) ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, fecproceso, turno, lado, manguera) )'
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_DIATARJETA
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal char(3) Not null, fecproceso SMALLDATETIME Not NULL, ' +
		'item Numeric(3) NOT NULL, cdtarjeta char(2) Not NULL, nrotarjeta char(20), mtosoles numeric(12,2) NULL, ' +
		'mtodolar numeric(12,2) NULL, tcambio numeric(10,6) NULL, CONSTRAINT PK_' + @nombreTabla + 
		' PRIMARY KEY (cdlocal, fecproceso, item, cdtarjeta) )'
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_DIAVARILLAJE
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal char(3) Not null, fecproceso SMALLDATETIME Not NULL, ' +
		'cdarticulo char(20) Not NULL, inicial numeric(15,3) NULL, compra numeric(15,3) NULL, ' +
		'venta numeric(15,3) NULL, final numeric(15,3) NULL, varillaje numeric(15,3) NULL, ' +
		'difdia numeric(15,3) NULL, difmes numeric(15,3) NULL, variacion numeric(7,3) NULL, ' +
		'total numeric(15,2) NULL, CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, fecproceso, cdarticulo) )'
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_DIADEPBANCO
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal char(3) Not null, fecproceso SMALLDATETIME Not NULL, ' +
		'Turno numeric(2,0) not NULL, nrocuenta char(20) NOT NULL, nrodeposito char(20) NOT NULL, mtototal numeric(11,2) NULL, ' +
		'TCambio numeric(8,4) NULL, valores numeric(11,2) NULL, cheques numeric(11,2) NULL, Observacion char(60) NULL,  CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, fecproceso, turno, nrocuenta) )'
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_NDEBITO
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal Char(3) Not Null, nrondebito Char(10) NOT Null, ' +
		'fecndebito SMALLDATETIME Null, fecproceso SMALLDATETIME Null, fecsistema SMALLDATETIME Null, ' +
		'nropos Char(10) Null, NroSerie1 Char(15) Null, NroSerie2 Char(10) Null, cddocorigen Char(5) Null, ' +
		'nrodocorigen Char(10) NULL, fecorigen SMALLDATETIME Null, tcambioorigen Numeric(10,6) Null, ' +
		'cdalmacen Char(3) Null, cdcliente Char(15) Null, ruccliente Char(15) Null, rscliente Char(60) Null, ' +
		'cdmoneda Char(1) Null, mtosubtotal Numeric(12,4) Null, mtoimpuesto Numeric(12,4) Null, ' +
		'mtototal Numeric(12,4) Null, cdusuario Char(10) Null, cdusuanula Char(10) Null, fecanula SMALLDATETIME Null, ' +
		'fecanulasis SMALLDATETIME Null, tcambio Numeric(7,4) Null, observacion Char(60) Null, ' +
		'cdmotndebito Char(5) Null, pdf417 Varchar(450) Null, cdhash Varchar(50) Null, sustento Varchar(60) Null, ' +
		'docreferencia Varchar(13), fecreferencia Datetime, flgmanual Bit, ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, nrondebito) ) '
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_NDEBITOD
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocal Char(3) Not Null, nrondebito Char(10) NOT Null, ' +
		'nroitem numeric(3,0), dsarticulo char(60), impuesto Numeric(6,2), mtosubtotal Numeric(12,4) Null, ' +
		'mtoimpuesto Numeric(12,4) Null, mtototal Numeric(12,4) Null, cdarticulosunat varchar(20), ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocal, nrondebito, nroitem) ) '
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_HTRANSACCION
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' ( Numero Char(4) Null, Soles Char(6) Null, ' +
			'producto Char(2) Null, Precio Char(4) Null, galones Char(8) Null, ' +
			'Cara Char(2) Null, Fecha Char(6) Null, Hora Char(4) Null, Turno Char(1) Null, ' +
		'cdtipodoc Char(5) Null, Documento Char(10) Null, Fecproceso Datetime Null ) '
EXEC(@SQL)				
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_OCOMPRA
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE '+ @nombreTabla + ' (cdlocalEmis char(3) NOT NULL, cdlocal char(3) NOT NULL, ' +
		'nroOCompra char(10) NOT NULL, cdalmacen char(3) NULL, cdproveedor char(15) NULL, ' +
		'fecha SMALLDATETIME NULL, fecproceso SMALLDATETIME NULL, FECEntrega SMALLDATETIME NULL, ' +
		'fecsistema SMALLDATETIME NULL, formapago char(25) null, cdmoneda char(1) NULL, ' +
		'mtosubtotal numeric(12,4) NULL, mtoimpuesto numeric(12,4) NULL, mtoimpuesto1 numeric(12,4) NULL, ' +
		'mtototal numeric(12,4) NULL, cdusuario char(10) NULL, fecanula SMALLDATETIME NULL, ' +
		'fecanulasis SMALLDATETIME NULL, cdusuanula char(10) NULL, Estado char(1) null, observacion char(80) NULL, ' +
		'tcambio numeric(10,4) NULL, cdtipodoc char(5) NULL, nrodocumento char(15) NULL, ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocalemis, cdlocal, nroOCompra)) '
EXEC(@SQL)
GO

CREATE PROCEDURE SP_ITBCP_CREAR_TABLA_OCOMPRAD
	@nombreTabla VARCHAR(50)
AS

DECLARE @SQL as NVARCHAR(MAX) = 'CREATE TABLE ' + @nombreTabla + ' (cdlocalEmis char(3) NOT NULL, cdlocal char(3) NOT NULL, ' +
		'nroOCompra char(10) NOT NULL, cdalmacen char(3) NULL, nroitem numeric(4, 0) NOT NULL, ' +
		'cdarticulo char(20) NOT NULL, cdalternativo char(20) NULL, cdcompra char(20) NULL, ' +
		'fecha SMALLDATETIME NULL, cantidad numeric(12,4) NULL, cantIngreso numeric(12,4) NULL, costo numeric(12,4) NULL, ' +
		'mtosubtotal numeric(12,4) NULL, mtoimpuesto numeric(12,4) NULL, mtoimpuesto1 numeric(12,4) NULL, ' +
		'mtototal numeric(12, 4) NULL, impuesto numeric(6, 2) NULL, impuesto1 numeric(6, 2) NULL, ' +
		'CONSTRAINT PK_' + @nombreTabla + ' PRIMARY KEY (cdlocalEmis, cdlocal, nroOCompra, nroitem, cdarticulo) )'
EXEC(@SQL)
GO

