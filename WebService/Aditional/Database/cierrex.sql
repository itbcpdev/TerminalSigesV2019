
--Tienda
exec [SP_ITBCP_GENERAR CIERREX_T]
go
alter PROCEDURE [dbo].[SP_ITBCP_GENERAR CIERREX_T]

AS
declare @fecproc2 datetime 
declare @nropos char(10)
declare @turno numeric(2,0)
declare @lvar_tipofac char(1)
declare @ltipoterminal char(1)
declare @cdgrupocombustible char(5)
declare @cdloc char(3)
declare @cdalmacen char(3)
set @cdalmacen ='001'
set @cdloc ='001'
set @fecproc2 ='21/01/2019'
set @nropos = 'CAJA1'
set @turno = 1--2
set @lvar_tipofac ='V'
set @cdgrupocombustible = '00020'
set @ltipoterminal ='P' 

IF @ltipoterminal = 'T'
BEGIN
---TcVenta
	declare @cGrupo02 table (
	cdgrupo02 char(5),
	dsgrupo02 varchar(100),
	dagrupo02 varchar (100) 
	)
	declare  @TcVenta table (
	cdtipodoc char(5),
	nrodocumento char(10), 
	mtosubtotal numeric(12,4), 
	mtoservicio numeric(12,4), 
	mtoimpuesto numeric(12,4), 
	mtototal numeric(12,4), 
	cdvendedor char(10), 
	fecanula smalldatetime, 
	cdusuanula char(10), 
	flgcierrez bit, 
	cdlocal char(3), 
	ruccliente char(15)		
	)
	declare @TVentaux table (
		nrodocumento char(10), 
		cdarticulo char(20), 
		cantidad  numeric(12,4),  
		mtosubtotal  numeric(12,4),  
		mtoservicio  numeric(12,4),  
		mtoimpuesto  numeric(12,4), 
		cdtipodoc char(5), 
		mtototal  numeric(12,4), 
		dsarticulo char(60),
		cdgrupo01 char(5), 
		cdgrupo02 char(5), 
		cdgrupo03 char(5), 
		cdgrupo04 char(5),
		cdgrupo05 char(5), 
		cara char(2),
		talla char(10), 
		nroitem numeric (3,0), 
		tipofactura char(1) 
	)
	declare @TcVentad table(
		cdtipodoc char(5), 
		nrodocumento char(10), 
		cdarticulo char(20), 
		cantidad numeric(12,4), 
		mtosubtotal numeric(12,4),
		mtoservicio numeric(12,4), 
		mtoimpuesto numeric(12,4), 
		mtototal numeric(12,4), 
		dsarticulo char(60), 
		cdgrupo01 char(5),
		cdgrupo02 char(5), 
		cdgrupo03 char(5), 
		cdgrupo04 char(5), 
		cdgrupo05 char(5), 
		cara char(2) 
	)
	 insert into @cGrupo02 Select cdgrupo02, dsgrupo02,'' From grupo02 
	 insert into @TcVenta Select cdtipodoc, nrodocumento, mtosubtotal, mtoservicio, mtoimpuesto, mtototal, cdvendedor, fecanula, cdusuanula, flgcierrez,cdlocal, ruccliente 
					From venta 
					Where ltrim(rtrim(@nropos))!= ltrim(rtrim(Venta.NroPos))
					 and @fecproc2=convert(char(10), fecproceso,103) 
					 and @turno=Turno 
					 and (flgcierrez=0 or flgcierrez is null )
					 and venta.tipofactura!=@lvar_tipofac
	 				Order By nrodocumento			  
	---TVentaux
	insert into @TVentaux Select Ventad.nrodocumento, Ventad.cdarticulo, Ventad.cantidad, Ventad.mtosubtotal,Ventad.mtoservicio,Ventad.mtoimpuesto,Ventad.cdtipodoc, 
			Ventad.mtototal,Articulo.dsarticulo, Articulo.cdgrupo01,Articulo.cdgrupo02, Articulo.cdgrupo03,Articulo.cdgrupo04,Articulo.cdgrupo05,ventad.cara,
			Ventad.talla, Ventad.nroitem, venta.tipofactura  
			From Ventad INNER JOIN  Articulo ON  Ventad.cdarticulo = Articulo.cdarticulo 
			Join Venta as Venta ON(Venta.CdLocal = VentaD.CdLocal and Venta.NroSerieMaq = VentaD.NroSerieMaq and 
			Venta.CdTipoDoc = VentaD.CdTipoDoc and Venta.NroDocumento = VentaD.NroDocumento) 
			Where ltrim(rtrim(@nropos))!= ltrim(rtrim(Ventad.NroPos)) And articulo.CDGRUPO02!=@cdgrupocombustible 
			And @fecproc2=convert(char(10), Ventad.fecproceso,103) and venta.tipofactura!=@lvar_tipofac 
			And @turno=Ventad.Turno And (Ventad.flgcierrez=0 or Ventad.flgcierrez is null) and (Venta.CdUsuAnula is null or LEN(LTRIM(RTRIM(Venta.CdUsuAnula))) = 0)

	insert into @TcVentad Select TVentaux.cdtipodoc, TVentaux.nrodocumento, TVentaux.cdarticulo, TVentaux.cantidad, TVentaux.mtosubtotal,
			TVentaux.mtoservicio, TVentaux.mtoimpuesto, TVentaux.mtototal, TVentaux.dsarticulo, TVentaux.cdgrupo01,
			TVentaux.cdgrupo02, TVentaux.cdgrupo03, TVentaux.cdgrupo04, TVentaux.cdgrupo05, TVentaux.cara 
			From @TVentaux TVentaux INNER Join @TcVenta TcVenta On (TcVenta.cdtipodoc+TcVenta.nrodocumento = TVentaux.cdtipodoc+TVentaux.nrodocumento) 
			WHERE (TcVenta.fecanula is null or TcVenta.fecanula ='') 
			
	Select TcVentad.cdgrupo02, cGrupo02.dsgrupo02,
		 Sum(TcVentad.mtototal) As mtototal, Sum(TcVentad.cantidad) As cantidad 	
		From @TcVentad TcVentad, @cGrupo02 cGrupo02 
			Where RTRIM(cGrupo02.cdgrupo02) = RTRIM(TcVentad.cdgrupo02) 
			Group By TcVentad.cdgrupo02, cGrupo02.dsgrupo02 Order By TcVentad.cdgrupo02
		
			delete from @cGrupo02
			delete from @TcVenta
			delete from @TVentaux
			delete from @TcVentad
END 
IF @ltipoterminal ='P'

	declare @Stock table (
		cdlocal char(3), 
		cdalmacen char(3), 
		cdArticulo char(20), 
		Stock numeric(12,4)
	)
declare @SELMaestro table(
cdarticulo char(20),
dsarticulo char(60), 
cdgrupo01 char(5), 
cdgrupo02 char(5) 
)
BEGIN
	--Stock
insert into @Stock	Select cdlocal, 
			cdalmacen, 
			cdArticulo, 
			stockactual As Stock 
			From Stock 
			Where cdlocal=@cdloc And 
				  Stock.cdalmacen=@cdalmacen 
		Order by cdarticulo
		--SELMaestro
insert into @SELMaestro	SELECT cdarticulo, dsarticulo, cdgrupo01, cdgrupo02 
			FROM articulo 
			where articulo.CDGRUPO02!=@cdgrupocombustible Order By cdarticulo
		
		--Reporte
	Select selmaestro.cdarticulo,
			 selmaestro.dsarticulo, 
			 selmaestro.cdgrupo02, Stock.Stock
		FROM @SELMaestro selmaestro Left Join @Stock Stock 
		ON  selmaestro.cdarticulo = Stock.cdarticulo
		WHERE Stock.Stock <> 0 And Stock.cdalmacen=@cdalmacen 
		ORDER By selmaestro.dsarticulo
		
		delete from @Stock
		delete from @SELMaestro
END
--VENTAP - PAGOS 
SELECT * INTO #VENTAP FROM (
Select Ventap.cdtppago, Ventap.cdbanco, Ventap.cdtarjeta, ventap.cdtipodoc, Ventap.mtopagosol, 
	Ventap.mtopagodol, Ventap.nroncredito, Venta.fecanula, Venta.nrodocumento, Venta.mtovueltosol, 
	Venta.mtovueltodol, venta.tcambio, venta.cdcliente, venta.fecproceso, venta.redondea_indecopi From ventap LEFT OUTER JOIN venta On 
	Venta.cdtipodoc=Ventap.cdtipodoc And  Venta.nrodocumento=Ventap.nrodocumento 
	Where @nropos= Ventap.NroPos And @fecproc2=convert(char(10), Ventap.fecproceso, 103) 
	and @turno= Ventap.Turno And (Ventap.flgcierrez=0 or Ventap.flgcierrez is null )  and venta.tipofactura!=@lvar_tipofac 
	) AS VENTAP  Order By VENTAP.nrodocumento

SELECT * FROM #VENTAP

DECLARE @mtopagosol numeric(12,4)
DECLARE @mtopagodol numeric(12,4)
DECLARE @mtovueltosol numeric(12,4)
DECLARE @mtovueltodol numeric(12,4)
DECLARE @redondea_indecopi numeric(12,4)

DECLARE VENTAP CURSOR LOCAL
	FOR select mtopagosol,mtopagodol, mtovueltosol,mtovueltodol,redondea_indecopi  from #VENTAP for update
	OPEN VENTAP
		FETCH VENTAP into @mtopagosol, @mtopagodol,@mtovueltosol,@mtovueltodol, @redondea_indecopi
			while (@@FETCH_STATUS =0)
				begin
					IF @redondea_indecopi !=0 AND (@mtovueltosol!=0 OR @mtovueltodol!=0)
					BEGIN
						update #VENTAP set  mtopagosol = @mtopagosol-@redondea_indecopi
						where current of #VENTAP			
					END
					fetch VENTAP into @mtopagosol, @mtopagodol,@mtovueltosol,@mtovueltodol, @redondea_indecopi
				end
	CLOSE VENTAP
DEALLOCATE VENTAP

--VENTA - CABECERA
SELECT * INTO #cVenta FROM (
Select cdtipodoc, nrodocumento, mtosubtotal, mtoservicio, mtoimpuesto, mtototal, cdvendedor, cdusuario, redondea_indecopi,
	fecanula, cdusuanula, flgcierrez, cdlocal, ruccliente, tipoventa, referencia, nrobonus From venta 
	Where @nropos= NroPos And @fecproc2=convert(char(10), fecproceso,103) and @turno=Turno  and tipofactura!=@lvar_tipofac 
	And (flgcierrez=0 or flgcierrez is null )  ) AS CABECERA Order By CABECERA.nrodocumento

Select Sum(redondea_indecopi) As Total From #cVenta cVenta Where cVenta.fecanula is null Or cVenta.fecanula=''


--VENTAS CON TRANSFERENCIA GRATUITA
SELECT * INTO #cVentaT FROM (
Select cdtipodoc, nrodocumento, mtosubtotal, mtoservicio, mtoimpuesto, mtototal, cdvendedor, cdusuario,
	fecanula, cdusuanula, flgcierrez, cdlocal, ruccliente, tipoventa, referencia, nrobonus From venta 
	Where @nropos= NroPos And @fecproc2=convert(char(10), fecproceso,103) and @turno=Turno 
	And (flgcierrez=0 or flgcierrez is null ) And TipoVenta = 'T'  ) AS GRATUITA Order By GRATUITA.nrodocumento
	Select Sum (mtototal) as lmtototaltgratuita  from #cVentaT  

--DEPOSITOS X GRIFERO 
SELECT SUM(mtototal) as mtototal FROM gastos WHERE fecproceso = @fecproc2 AND nropos = @nropos AND turno = @turno
---cTicket
Select Sum(mtosubtotal) As mtosubtotal, Sum(mtoservicio) As mtoservicio, Sum(mtoimpuesto) As mtoimpuesto,
	sum(mtototal) As mtototal
	From #cVenta cVenta Where (fecanula is null Or fecanula='') 
--- cTicketAnul
Select mtototal From #cVenta cVenta Where fecanula is not null Or fecanula!=''
Select SUM(mtototal) as lmtoticketanul From #cVenta cVenta Where fecanula is not null Or fecanula!=''

--SELECT * FROM #VENTAP
--SELECT * FROM #CABECERA
--SELECT * FROM #GRATUITA 

DROP TABLE #VENTAP
DROP TABLE #cVenta
DROP TABLE #cVentaT

