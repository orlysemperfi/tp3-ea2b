USE [TMD]
GO

/****** Object:  StoredProcedure [dbo].[USP_USUARIO_PROYECTO]    Script Date: 03/13/2013 00:31:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_USUARIO_PROYECTO]
@CODIGO_USUARIO INT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		UP.CODIGO,
		UP.TIPO_ACCESO
	FROM
		dbo.USUARIO_PROYECTO AS UP
	WHERE
		UP.CODIGO_USUARIO = @CODIGO_USUARIO;

	SET NOCOUNT OFF;

END

GO


