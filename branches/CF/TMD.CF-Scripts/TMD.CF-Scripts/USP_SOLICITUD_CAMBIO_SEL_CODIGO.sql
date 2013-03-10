IF((SELECT Object_Id('dbo.USP_SOLICITUD_CAMBIO_SEL_CODIGO')) IS NOT NULL)
BEGIN
	DROP PROCEDURE dbo.USP_SOLICITUD_CAMBIO_SEL_CODIGO
END
GO

CREATE PROCEDURE dbo.USP_SOLICITUD_CAMBIO_SEL_CODIGO
@CODIGO INT 
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		SC.CODIGO,
		SC.NOMBRE,
		SC.CODIGO_PROYECTO,
		SC.CODIGO_LINEA_BASE,
		SC.CODIGO_USUARIO,
		SC.FECHA_APROBACION,
		SC.FECHA_REGISTRO,
		SC.ESTADO,
		SC.CODIGO_ECS,
		SC.PRIORIDAD,
		SC.MOTIVO,
		P.NOMBRE AS PROYECTO,
		LB.NOMBRE AS LINEA_BASE,
		E.NOMBRE AS ELEMENTO,
		SC.NOMBRE_ARCHIVO
	FROM
		dbo.SOLICITUD_CAMBIO AS SC
		INNER JOIN dbo.PROYECTO AS P
		ON SC.CODIGO_PROYECTO = P.CODIGO_PROYECTO
		INNER JOIN dbo.LINEA_BASE AS LB
		ON SC.CODIGO_LINEA_BASE = LB.CODIGO
		INNER JOIN dbo.ELEMENTO_CONFIGURACION AS E
		ON SC.CODIGO_ECS = E.CODIGO
	WHERE
		SC.CODIGO = @CODIGO;
		
	SET NOCOUNT OFF;
END
GO