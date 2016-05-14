PRINT N'Creating KPMG...';
GO
CREATE SCHEMA [KPMG]
    AUTHORIZATION [dbo];
	GO
PRINT N'Creating KPMG.Transaction...';
GO
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[Transaction]') AND type in (N'U'))
CREATE TABLE [KPMG].[Transaction] (
    [Account]		VARCHAR (MAX)			NOT NULL,
    [Description]   VARCHAR (MAX)			NOT NULL,
    [Currency]		VARCHAR (100)			NOT NULL,
    [Value]			DEC(38,2)				NOT NULL
);
GO