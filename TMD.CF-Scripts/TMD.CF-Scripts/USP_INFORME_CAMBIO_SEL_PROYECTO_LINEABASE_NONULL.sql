USE [TMD]
GO
/****** Object:  StoredProcedure [dbo].[USP_INFORME_CAMBIO_SEL_PROYECTO_LINEABASE_NONULL]    Script Date: 03/18/2013 00:54:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[USP_INFORME_CAMBIO_SEL_PROYECTO_LINEABASE_NONULL]
@CODIGO_PROYECTO INT,
@CODIGO_LINEABASE INT
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		A.CODIGO AS CODIGO_SOLICITUD,
		A.NOMBRE AS NOMBRE_SOLICITUD,
		A.FECHA_APROBACION AS SOLICITUD_FECHA_APROBACION,
		B.CODIGO,
		B.NOMBRE,
		B.ESTADO,
		B.FECHA_REGISTRO,
		B.FECHA_APROBACION,
		B.MOTIVO,
		B.NOMBRE_ARCHIVO
	FROM 
		dbo.SOLICITUD_CAMBIO AS A LEFT JOIN dbo.INFORME_CAMBIO AS B
	ON 
		B.CODIGO_SOLICITUD = A.CODIGO 
	WHERE 
		A.ESTADO = 2 AND A.CODIGO_PROYECTO = @CODIGO_PROYECTO AND A.CODIGO_LINEA_BASE = @CODIGO_LINEABASE AND B.ESTADO > 2
		
	SET NOCOUNT OFF;
END


