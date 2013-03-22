IF((SELECT Object_Id('dbo.USP_ORDEN_CAMBIO_SEL_INFORME')) IS NOT NULL)
BEGIN
	DROP PROCEDURE dbo.USP_ORDEN_CAMBIO_SEL_INFORME
END
GO

CREATE PROCEDURE dbo.USP_ORDEN_CAMBIO_SEL_INFORME
@CODIGO_INFORME INT
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT  
		OC.CODIGO, OC.NOMBRE AS NOMBRE_ORDEN, OC.CODIGO_INFORME, IC.NOMBRE, 
		OC.CODIGO_USUARIO_REG, OC.FECHA_REGISTRO, OC.PRIORIDAD, 
		OC.CODIGO_USUARIO_ASIGNADO, OC.NOMBRE_ARCHIVO
	FROM
		dbo.ORDEN_CAMBIO AS OC
		INNER JOIN dbo.INFORME_CAMBIO AS IC
		ON IC.CODIGO = OC.CODIGO_INFORME
	WHERE
		OC.CODIGO_INFORME = @CODIGO_INFORME
	SET NOCOUNT OFF;
END
GO