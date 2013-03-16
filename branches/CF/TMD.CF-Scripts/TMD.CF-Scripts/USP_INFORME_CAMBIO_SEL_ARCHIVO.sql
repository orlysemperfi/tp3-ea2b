USE [TMD]
GO
/****** Object:  StoredProcedure [dbo].[USP_SOLICITUD_CAMBIO_SEL_ARCHIVO]    Script Date: 03/16/2013 18:18:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_INFORME_CAMBIO_SEL_ARCHIVO]
@CODIGO INT
AS
BEGIN
	SET NOCOUNT ON;	
	
	SELECT
		NOMBRE_ARCHIVO,
		DATA.PathName() AS RUTA_ARCHIVO,
		GET_FILESTREAM_TRANSACTION_CONTEXT() AS TRANSACTION_CONTEXT
	FROM 
		dbo.INFORME_CAMBIO
	WHERE 
		CODIGO = @CODIGO;

	SET NOCOUNT OFF;
END
