USE [BACKOFFICE]
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ColaImpresion]'))
BEGIN
	CREATE TABLE [dbo].[ColaImpresion](
			[cdtipodoc] [char](5) NOT NULL,
			[nrodocumento] [char](10) NOT NULL,
			[nropos] [char](10) NOT NULL,
			[fecdocumento] [smalldatetime] NOT NULL,
			[impresora] [varchar](40) NOT NULL,
			[trama] [varchar](max) NOT NULL,
			[json] [varchar](max) NOT NULL,
			[hash] [varchar](50) NOT NULL,
			[impreso] [bit] NOT NULL,
			[observacion] [varchar](120) NOT NULL,
			[timestamp] [smalldatetime] NOT NULL,
		CONSTRAINT [PK_ColaImpresion] PRIMARY KEY NONCLUSTERED 
		(
			[cdtipodoc] ASC,
			[nrodocumento] ASC,
			[nropos] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
		) ON [PRIMARY]
END
