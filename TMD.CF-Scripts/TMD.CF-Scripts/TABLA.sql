ALTER TABLE dbo.SOLICITUD_CAMBIO
ADD NOMBRE_ARCHIVO VARCHAR(50) NULL;
GO

ALTER TABLE dbo.SOLICITUD_CAMBIO
ADD EXTENSION CHAR(3) NULL;
GO

ALTER TABLE dbo.SOLICITUD_CAMBIO
DROP COLUMN DATA
GO

ALTER TABLE dbo.SOLICITUD_CAMBIO
ADD DATA VARBINARY(MAX) FILESTREAM  NULL
GO