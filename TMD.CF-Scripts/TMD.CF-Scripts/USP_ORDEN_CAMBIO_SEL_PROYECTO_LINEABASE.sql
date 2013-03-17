IF((SELECT Object_Id('dbo.USP_ORDEN_CAMBIO_SEL_PROYECTO_LINEABASE')) IS NOT NULL)
BEGIN
	DROP PROCEDURE dbo.USP_ORDEN_CAMBIO_SEL_PROYECTO_LINEABASE
END
GO

CREATE PROCEDURE dbo.USP_ORDEN_CAMBIO_SEL_PROYECTO_LINEABASE
@CODIGO_PROYECTO INT,
@CODIGO_LINEABASE INT
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT  
		OC.CODIGO, OC.NOMBRE AS NOMBRE_ORDEN, OC.CODIGO_INFORME, IC.NOMBRE, 
		OC.CODIGO_USUARIO_REG, OC.FECHA_REGISTRO, OC.PRIORIDAD, 
		OC.CODIGO_USUARIO_ASIGNADO
	FROM
		dbo.ORDEN_CAMBIO AS OC
		INNER JOIN dbo.INFORME_CAMBIO AS IC
		ON IC.CODIGO = OC.CODIGO_INFORME
		INNER JOIN dbo.SOLICITUD_CAMBIO AS S
		ON S.CODIGO = IC.CODIGO_SOLICITUD
	WHERE
		S.CODIGO_PROYECTO = @CODIGO_PROYECTO
		AND (@CODIGO_LINEABASE = 0 OR S.CODIGO_LINEA_BASE = @CODIGO_LINEABASE)
	SET NOCOUNT OFF;
END
GO