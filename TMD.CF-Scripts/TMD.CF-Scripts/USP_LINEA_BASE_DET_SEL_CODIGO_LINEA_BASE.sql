IF((SELECT Object_Id('dbo.USP_LINEA_BASE_DET_SEL_CODIGO_LINEA_BASE')) IS NOT NULL)
BEGIN
	DROP PROCEDURE dbo.USP_LINEA_BASE_DET_SEL_CODIGO_LINEA_BASE
END
GO

CREATE PROCEDURE [dbo].USP_LINEA_BASE_DET_SEL_CODIGO_LINEA_BASE 
@CODIGO_LINEA_BASE INT,  
@CODIGO_USUARIO INT  
AS  
BEGIN  
  
 SET NOCOUNT ON;  
  
 SELECT DISTINCT  
  LBD.CODIGO,   
  LBD.CODIGO_ECS,   
  EC.NOMBRE AS ECS_NOMBRE,  
  EC.TIPO,  
  LBD.CODIGO_RESPONSABLE,   
  LBD.FECHA_ENTREGA,   
  LBD.VERSION_MENOR,   
  LBD.VERSION_MAYOR,   
  LBD.CODIGO_LINEA_BASE,  
  LBD.NOMBRE,  
  LBD.EXTENSION ,
  PF.FECHA_INICIO 
 FROM  
  dbo.LINEA_BASE_DETALLE AS LBD  
  INNER JOIN dbo.ELEMENTO_CONFIGURACION AS EC  
  ON LBD.CODIGO_ECS = EC.CODIGO  
  INNER JOIN dbo.LINEA_BASE AS LB  
  ON LB.CODIGO = LBD.CODIGO_LINEA_BASE  
  INNER JOIN dbo.PROYECTO_FASE AS PF  
  ON PF.CODIGO = LB.CODIGO_PROYECTO_FASE  
  INNER JOIN dbo.USUARIO_PROYECTO AS UP  
  ON UP.CODIGO_PROYECTO = PF.CODIGO_PROYECTO  
 WHERE  
  LBD.CODIGO_LINEA_BASE = @CODIGO_LINEA_BASE  
  AND (@CODIGO_USUARIO = 0 OR LBD.CODIGO_RESPONSABLE = @CODIGO_USUARIO);   
  
 SET NOCOUNT OFF;  
  
END  
GO