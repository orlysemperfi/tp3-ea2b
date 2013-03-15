USE [TMD]
GO
/****** Object:  Table [dbo].[AC_PROGRAMA_AUDITORIA]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AC_PROGRAMA_AUDITORIA](
	[idPrograma] [int] IDENTITY(1,1) NOT NULL,
	[anio] [int] NULL,
	[fechaElaboracion] [datetime] NULL,
	[elaboradoPor] [int] NULL,
	[fechaAprobacion] [datetime] NULL,
	[aprobadoPor] [int] NULL,
	[estado] [varchar](20) NULL,
 CONSTRAINT [PK_AC_PROGRAMAAUDITORIA] PRIMARY KEY CLUSTERED 
(
	[idPrograma] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AC_PREGUNTA_EVALUACION]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AC_PREGUNTA_EVALUACION](
	[idPreguntaEvaluacion] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AC_PREGUNTA_EVALUACION] PRIMARY KEY CLUSTERED 
(
	[idPreguntaEvaluacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AC_PREGUNTA_CALIFICACION]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AC_PREGUNTA_CALIFICACION](
	[idPreguntaCalificacion] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AC_PREGUNTA_CALIFICACION] PRIMARY KEY CLUSTERED 
(
	[idPreguntaCalificacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AC_PREGUNTA_BASE]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AC_PREGUNTA_BASE](
	[idPreguntaBase] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[ereg] [char](1) NOT NULL,
	[freg] [datetime] NULL,
	[hreg] [varchar](8) NOT NULL,
	[ureg] [varchar](10) NOT NULL,
 CONSTRAINT [PK_AC_PREGUNTA_BASE] PRIMARY KEY CLUSTERED 
(
	[idPreguntaBase] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AC_NORMA]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AC_NORMA](
	[idNorma] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[ereg] [char](1) NOT NULL,
	[freg] [datetime] NULL,
	[hreg] [varchar](8) NOT NULL,
	[ureg] [varchar](10) NOT NULL,
 CONSTRAINT [PK_AC_NORMA] PRIMARY KEY CLUSTERED 
(
	[idNorma] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AC_ARCHIVO]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AC_ARCHIVO](
	[idArchivo] [int] IDENTITY(1,1) NOT NULL,
	[dataBinaria] [varbinary](max) NOT NULL,
	[nombreArchivo] [varchar](255) NOT NULL,
	[mimeType] [varchar](255) NOT NULL,
	[fechaCarga] [datetime] NOT NULL,
	[idOrigen] [int] NULL,
	[tipoOrigen] [char](1) NULL,
 CONSTRAINT [PK_AC_ARCHIVO] PRIMARY KEY CLUSTERED 
(
	[idArchivo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AREA]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AREA](
	[CODIGO_AREA] [int] NOT NULL,
	[DESCRIPCION] [varchar](50) NOT NULL,
	[VISION] [varchar](50) NULL,
	[MISION] [varchar](50) NULL,
	[CODIGO_ORGANIZACION] [int] NULL,
 CONSTRAINT [PK_AC_AREA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_AREA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PERFIL_USUARIO]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PERFIL_USUARIO](
	[CODIGO_PERFIL_USUARIO] [int] NOT NULL,
	[DESCRIPCION] [varchar](200) NULL,
	[USUARIO_CREACION] [int] NULL,
	[FECHA_CREACION] [datetime] NULL,
	[USUARIO_MODIFICACION] [int] NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
 CONSTRAINT [PK_PERFIL_USUARIO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PERFIL_USUARIO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USUARIO](
	[CODIGO_PERSONA] [int] NOT NULL,
	[CODIGO_USUARIO] [varchar](50) NULL,
	[CONTRASENIA] [varchar](50) NULL,
	[ESTADO] [nchar](10) NULL,
	[CODIGO_PERFIL_USUARIO] [int] NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PERSONA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_NORMA]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raul Callupe
-- Create date: 26/11/2012
-- Description:	Obtiene normas
-- =============================================
CREATE PROCEDURE [dbo].[ACP_SP_OBTENER_NORMA]
(
	@idNorma int
)
AS
BEGIN
	select N.idNorma, N.descripcion as descripcionNorma
	from AC_NORMA N			
	where	(@idNorma is null or idNorma = @idNorma)
			
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_ARCHIVOS]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raul Callupe
-- Create date: 26/11/2012
-- Description:	Obtiene archivos
-- =============================================
CREATE PROCEDURE [dbo].[ACP_SP_OBTENER_ARCHIVOS]
(
	@idOrigen int,
	@tipoOrigen char(1)
)
AS
BEGIN
	select A.idArchivo, A.fechaCarga, A.mimeType, A.nombreArchivo, A.idOrigen, A.tipoOrigen
	from AC_ARCHIVO A
	where (@idOrigen is null or A.idOrigen = @idOrigen) and 
			(@tipoOrigen is null or A.tipoOrigen = @tipoOrigen) 
			
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_MODIFICAR_ARCHIVO]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raul Callupe
-- Create date: 26/11/2012
-- Description:	Actualiza la informacion de un archivo
-- =============================================
CREATE PROCEDURE [dbo].[ACP_SP_MODIFICAR_ARCHIVO]
(
	@idArchivo int,
	@idOrigen int, 
	@tipoOrigen char(1)
)
AS
BEGIN
	update AC_ARCHIVO
	set idOrigen = @idOrigen,
		tipoOrigen = @tipoOrigen
	where idArchivo = @idArchivo
END
GO
/****** Object:  Table [dbo].[EMPLEADO]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMPLEADO](
	[CODIGO_EMPLEADO] [int] NOT NULL,
	[NOMBRES] [varchar](50) NULL,
	[APEPAT] [varchar](50) NULL,
	[APEMAT] [varchar](50) NULL,
	[CODIGO_AREA] [int] NULL,
	[SUELDO] [decimal](18, 2) NULL,
	[FECHA_INICIO_CONTRATO] [datetime] NULL,
	[FECHA_FIN_CONTRATO] [datetime] NULL,
	[CODIGO_JEFE] [int] NULL,
	[HORA_INGRESO] [datetime] NULL,
	[HORA_SALIDA] [datetime] NULL,
 CONSTRAINT [PK_EMPLEADO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_EMPLEADO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AC_CAPITULO]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AC_CAPITULO](
	[idNorma] [int] NOT NULL,
	[idCapitulo] [int] NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[ereg] [char](1) NOT NULL,
	[freg] [datetime] NULL,
	[hreg] [varchar](8) NOT NULL,
	[ureg] [varchar](10) NOT NULL,
 CONSTRAINT [PK_AC_CAPITULO] PRIMARY KEY CLUSTERED 
(
	[idNorma] ASC,
	[idCapitulo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AC_ENTIDAD_AUDITADA]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AC_ENTIDAD_AUDITADA](
	[idEntidadAuditada] [int] NOT NULL,
	[idArea] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[ereg] [char](1) NOT NULL,
	[tipoEntidad] [varchar](20) NOT NULL,
	[fecInicioProyecto] [datetime] NULL,
	[FecFinProyecto] [datetime] NULL,
	[porcentajeAvance] [numeric](9, 2) NOT NULL,
	[responsableProyecto] [varchar](50) NOT NULL,
	[freg] [datetime] NULL,
	[hreg] [varchar](8) NOT NULL,
	[ureg] [varchar](10) NOT NULL,
	[riesgo] [int] NULL,
	[criticidad] [int] NULL,
	[alcance] [int] NULL,
 CONSTRAINT [PK_AC_ENTIDAD_AUDITADA] PRIMARY KEY CLUSTERED 
(
	[idEntidadAuditada] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_ELIMINAR_GRUPO_ARCHIVOS]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raul Callupe
-- Create date: 26/11/2012
-- Description:	Elimina un grupo de archivos basado en el origen y tipo
-- =============================================
CREATE PROCEDURE [dbo].[ACP_SP_ELIMINAR_GRUPO_ARCHIVOS]
(
	@idOrigen int,
	@tipoOrigen char(1)
)
AS
BEGIN
	delete from AC_ARCHIVO where idOrigen = @idOrigen and tipoOrigen = @tipoOrigen
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_ELIMINAR_ARCHIVO]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raul Callupe
-- Create date: 26/11/2012
-- Description:	Elimina el archivo especificado
-- =============================================
CREATE PROCEDURE [dbo].[ACP_SP_ELIMINAR_ARCHIVO]
(
	@idArchivo int
)
AS
BEGIN
	delete from AC_ARCHIVO where idArchivo = @idArchivo
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_INSERTAR_PROGRAMA_ANUAL]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carla Mier
-- Create date: 26/11/2012
-- Description:	Inserta un programa anual de auditoria
-- =============================================
CREATE PROCEDURE [dbo].[ACP_SP_INSERTAR_PROGRAMA_ANUAL] --2013,'CREADO','CMIER'
(
	@anio int, 
	@estado varchar(20),
	@elaboradoPor varchar(8)
)
AS
BEGIN
	insert into AC_PROGRAMA_AUDITORIA(anio, fechaElaboracion, elaboradoPor, estado)
	values(@anio, getdate(), @elaboradoPor, @estado)
	
	select max(idPrograma) from AC_PROGRAMA_AUDITORIA
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_EMPLEADOS_POR_AREA]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =========================================================
CREATE PROCEDURE [dbo].[ACP_SP_LISTAR_EMPLEADOS_POR_AREA]   
@idArea INT
AS  
BEGIN  
 SELECT -1 AS CODIGO_EMPLEADO, 
		'SELECCIONAR' AS nombres,
		'' AS apepat,
		'' AS apemat,
		'' AS CODIGO_AREA,
		'' AS nombreArea
 UNION
 SELECT CODIGO_EMPLEADO, 
		nombres + ' ' + apepat + ' ' + apemat AS nombres,
		apepat,
		apemat,
		EMPLEADO.CODIGO_AREA,AREA.descripcion as nombreArea
 FROM	EMPLEADO  EMPLEADO
 inner join AREA AREA on (EMPLEADO.CODIGO_AREA = AREA.CODIGO_AREA)   
 WHERE  EMPLEADO.CODIGO_AREA = @idArea 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_EMPLEADOS]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =========================================================
CREATE PROCEDURE [dbo].[ACP_SP_LISTAR_EMPLEADOS]    
AS  
BEGIN  
 SELECT CODIGO_EMPLEADO, nombres, apepat, apemat, EMPLEADO.CODIGO_AREA,AREA.descripcion as nombreArea FROM EMPLEADO      
 inner join AREA AREA on (EMPLEADO.CODIGO_AREA = AREA.CODIGO_AREA)   
END
GO
/****** Object:  Table [dbo].[AC_AUDITADOS]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AC_AUDITADOS](
	[idAuditoria] [int] NOT NULL,
	[idAuditado] [int] NOT NULL,
	[calificacionAuditoria] [numeric](10, 2) NULL,
 CONSTRAINT [PK_AC_AUDITADOS] PRIMARY KEY CLUSTERED 
(
	[idAuditoria] ASC,
	[idAuditado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AC_DET_PREGUNTA_BASE]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AC_DET_PREGUNTA_BASE](
	[idNorma] [int] NOT NULL,
	[idCapitulo] [int] NOT NULL,
	[idPreguntaBase] [int] NOT NULL,
	[descripcionPregunta] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AUDITORIA]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AUDITORIA](
	[CODIGO_AUDITORIA] [int] NOT NULL,
	[CODIGO_PROGRAMA] [int] NOT NULL,
	[CODIGO_ENTIDAD_AUDITADA] [int] NOT NULL,
	[RESPONSABLE_PROCESO] [int] NULL,
	[ALCANCE] [varchar](300) NOT NULL,
	[OBJETIVO] [varchar](300) NOT NULL,
	[FECHA_INICIO] [datetime] NULL,
	[FECHA_FIN] [datetime] NULL,
	[DOCUMENTO] [image] NULL,
	[RESULTADO] [bit] NULL,
	[DURACION] [int] NULL,
	[CONCLUSION] [varchar](300) NULL,
	[RECOMENDACION] [varchar](300) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[USUARIO_MODIFICACION] [int] NULL,
	[ESTADO] [varchar](20) NULL,
 CONSTRAINT [PK_AC_AUDITORIA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_AUDITORIA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_ENTIDAD_AUDITADA]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACP_SP_OBTENER_ENTIDAD_AUDITADA]    
(  
 @idEntidadAuditada int
)  
AS  
BEGIN  

 SELECT	idEntidadAuditada, 
		E.descripcion AS NombreEntidadAuditada, 
		idArea AS codigoArea, 
		A.DESCRIPCION AS descripcionArea, 
		1 criticidad,
		1 riesgo,
		1 alcance,
		1 nroseguimiento,
		1 nroauditorias,
		1 puntaje
 FROM	AC_ENTIDAD_AUDITADA E     
 inner 
 join	AREA A on (E.idArea = A.CODIGO_AREA)   
 WHERE	idEntidadAuditada = @idEntidadAuditada
 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_EMPLEADO]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACP_SP_OBTENER_EMPLEADO]    
(  
 @idEmpleado int
)  
AS  
BEGIN  
 SELECT CODIGO_EMPLEADO, nombres, apepat, apemat, EMPLEADO.CODIGO_AREA,AREA.descripcion as nombreArea FROM EMPLEADO      
 inner join AREA AREA on (EMPLEADO.CODIGO_AREA = AREA.CODIGO_AREA)   
 WHERE CODIGO_EMPLEADO = @idEmpleado
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_CAPITULO]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raul Callupe
-- Create date: 26/11/2012
-- Description:	Obtiene capitulos por norma
-- =============================================
CREATE PROCEDURE [dbo].[ACP_SP_OBTENER_CAPITULO]
(
	@idNorma int,
	@idCapitulo int
)
AS
BEGIN
	select C.idCapitulo, C.descripcion as descripcionCapitulo, C.idNorma
	from AC_CAPITULO C	
	where	(idNorma = @idNorma) and
				(@idCapitulo is null or idCapitulo = @idCapitulo)
			
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_PROGRAMA_ANUAL_AUDITORIA]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carla Mier
-- Create date: 26/11/2012
-- Description:	Obtiene auditorias
-- =============================================
CREATE PROCEDURE [dbo].[ACP_SP_OBTENER_PROGRAMA_ANUAL_AUDITORIA]
AS
BEGIN
	select		idPrograma, anio, fechaElaboracion, elaboradoPor, 
				E1.nombres + ' ' + E1.apepat as nombre1, 
				fechaAprobacion, aprobadoPor, 
				E2.nombres + ' ' + E2.apepat as nombre2, estado
	from		AC_PROGRAMA_AUDITORIA P
	left join	EMPLEADO E1 on (E1.CODIGO_EMPLEADO = P.elaboradoPor)
	left join	EMPLEADO E2 on (E2.CODIGO_EMPLEADO = P.aprobadoPor)
	where		anio = YEAR(GETDATE()) and estado <> 'RECHAZADO'
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC1]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC1]
	@idAuditoria int
as
BEGIN
 
	select AUD.CODIGO_AUDITORIA, 
			REPLICATE('0', 6 - LEN(AUD.CODIGO_AUDITORIA)) + cast(AUD.CODIGO_AUDITORIA as varchar) as idAuditoriaFormato, 
			AUD.FECHA_INICIO, AUD.FECHA_FIN, 
			'Jonathan Soncco' as jefeAuditor,
			AREA.descripcion as nombreArea, 
			ENT.descripcion as nombreEntidad, 		
			ENT.responsableProyecto,
			AUD.objetivo,
			AUD.alcance			
	from AUDITORIA AUD
			inner join AC_ENTIDAD_AUDITADA ENT on (AUD.CODIGO_ENTIDAD_AUDITADA = ENT.idEntidadAuditada)
			inner join AREA AREA on (ENT.idArea = AREA.CODIGO_AREA)
	where AUD.CODIGO_AUDITORIA = @idAuditoria

END
GO
/****** Object:  Table [dbo].[AC_EVALUACION_AUDITORIA]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AC_EVALUACION_AUDITORIA](
	[idEvaluacionAuditoria] [int] NOT NULL,
	[idAuditoria] [int] NOT NULL,
	[idAuditado] [int] NOT NULL,
	[idPreguntaEvaluacion] [int] NOT NULL,
	[respuesta] [text] NOT NULL,
	[observacion] [text] NOT NULL,
 CONSTRAINT [PK_AC_EVALUACION_AUDITORIA_1] PRIMARY KEY CLUSTERED 
(
	[idEvaluacionAuditoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_PLAN_AUDITORIA_POR_ID]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACP_SP_OBTENER_PLAN_AUDITORIA_POR_ID]  
(  
 @idAuditoria int
)  
AS  
BEGIN  
 select AUD.CODIGO_AUDITORIA, ENT.idEntidadAuditada, ENT.descripcion as nombreEntidad, AREA.CODIGO_AREA, AREA.descripcion as nombreArea,   
   AUD.FECHA_INICIO, AUD.FECHA_FIN, AUD.estado,ENT.responsableProyecto,AUD.objetivo,AUD.alcance
 from AUDITORIA AUD  
   inner join AC_ENTIDAD_AUDITADA ENT on (AUD.CODIGO_ENTIDAD_AUDITADA = ENT.idEntidadAuditada)  
   inner join AREA AREA on (ENT.idArea = AREA.CODIGO_AREA)   
 where AUD.CODIGO_AUDITORIA = @idAuditoria
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_PLAN_AUDITORIAS]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =========================================================
-- Author:  JONATHAN SONCCO  
-- Create date: 03/12/2012  
-- Description: Listar plan de auditorias
-- =========================================================
CREATE PROCEDURE [dbo].[ACP_SP_LISTAR_PLAN_AUDITORIAS]  
(  
 @anhoAuditoria int,    
 @estado1 varchar(20),  
 @estado2 varchar(20)  
)  
AS  
BEGIN  
 select AUD.CODIGO_AUDITORIA, ENT.idEntidadAuditada, ENT.descripcion as nombreEntidad, AREA.CODIGO_AREA, AREA.DESCRIPCION as nombreArea,   
   AUD.FECHA_INICIO, AUD.FECHA_FIN, AUD.ESTADO
 from AUDITORIA AUD  
   inner join AC_ENTIDAD_AUDITADA ENT on (AUD.CODIGO_ENTIDAD_AUDITADA = ENT.idEntidadAuditada)  
   inner join AREA AREA on (ENT.idArea = AREA.CODIGO_AREA)   
 where (@anhoAuditoria is null or year(AUD.FECHA_INICIO) = @anhoAuditoria) and     
   (ESTADO = @estado1 or ESTADO = @estado2)      
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_VALIDAR_AUDITORIA]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACP_SP_VALIDAR_AUDITORIA]     
@idEntidadAuditada int
AS  
BEGIN  

	SELECT count(1) 
	FROM AUDITORIA 
	WHERE  CODIGO_ENTIDAD_AUDITADA = @idEntidadAuditada
	and CODIGO_PROGRAMA in (select idPrograma 
							from dbo.AC_PROGRAMA_AUDITORIA 
							where anio = (year(getdate())-1))
 
END
GO
/****** Object:  Table [dbo].[AC_PREGUNTA_VERIFICACION]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AC_PREGUNTA_VERIFICACION](
	[idAuditoria] [int] NOT NULL,
	[idPreguntaVerificacion] [int] NOT NULL,
	[descripcionPregunta] [varchar](150) NOT NULL,
	[idNorma] [int] NOT NULL,
	[idCapitulo] [int] NOT NULL,
	[respuesta] [bit] NULL,
	[sustento] [varchar](200) NULL,
	[porcentaje] [numeric](10, 2) NULL,
 CONSTRAINT [PK_AC_PREGUNTA_VERIFICACION] PRIMARY KEY CLUSTERED 
(
	[idAuditoria] ASC,
	[idPreguntaVerificacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_INSERTAR_PLAN_AUDITORIA]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACP_SP_INSERTAR_PLAN_AUDITORIA]    
(  
 @idAuditoria int,
 @estado varchar(20) 
)  
AS  
BEGIN  
	UPDATE  AUDITORIA SET ESTADO = @estado  
	WHERE CODIGO_AUDITORIA = @idAuditoria
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_AUDITORIAS_POR_ANIO]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =========================================================
-- Author:  Carla Mier
-- Create date: 03/12/2012  
-- Description: Listar plan de auditorias
-- =========================================================
CREATE PROCEDURE [dbo].[ACP_SP_LISTAR_AUDITORIAS_POR_ANIO] 
(  
 @anhoAuditoria int
)  
AS  
BEGIN  

select	AUD.CODIGO_AUDITORIA, 
		ENT.idEntidadAuditada, 
		ENT.descripcion as nombreEntidad, 
		AREA.CODIGO_AREA, 
		AREA.DESCRIPCION as nombreArea,   
		AUD.alcance,
		AUD.objetivo,
		AUD.FECHA_INICIO, 
		AUD.FECHA_FIN, 
		AUD.ESTADO,
		E.CODIGO_EMPLEADO,
		E.nombres + ' ' + E.apepat AS NOMBREEMPLEADO			
from	AUDITORIA AUD  
inner 
join	AC_ENTIDAD_AUDITADA ENT on (AUD.CODIGO_ENTIDAD_AUDITADA = ENT.idEntidadAuditada)  
inner 
join	AREA AREA on (ENT.idArea = AREA.CODIGO_AREA)   
inner 
join	EMPLEADO E on (E.CODIGO_EMPLEADO = AUD.RESPONSABLE_PROCESO)   
where	AUD.CODIGO_PROGRAMA IN (SELECT idPrograma FROM dbo.AC_PROGRAMA_AUDITORIA WHERE ANIO = @anhoAuditoria)

END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_INSERTAR_AUDITORIA]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carla Mier
-- Create date: 26/11/2012
-- Description:	Inserta auditoria al programa
-- =============================================
CREATE PROCEDURE [dbo].[ACP_SP_INSERTAR_AUDITORIA] 
(
	@idPrograma int, 
	@idEntidadAuditada int,
	@responsable int,
	@alcance varchar(300), 
	@objetivo varchar(300), 
	@fechainicio datetime,
	@fechafin datetime,
	@estado varchar(20)
)
AS
BEGIN
	declare @idAuditoria int
	select @idAuditoria = (ISNULL(MAX(CODIGO_AUDITORIA), 0)+1) from AUDITORIA

	insert into AUDITORIA(CODIGO_AUDITORIA, CODIGO_PROGRAMA, CODIGO_ENTIDAD_AUDITADA, RESPONSABLE_PROCESO, ALCANCE, OBJETIVO, FECHA_INICIO, FECHA_FIN, ESTADO)
	values(@idAuditoria, @idPrograma, @idEntidadAuditada, @responsable, @alcance, @objetivo, @fechainicio, @fechafin, @estado)
END
GO
/****** Object:  Table [dbo].[AC_ACTIVIDAD]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AC_ACTIVIDAD](
	[idAuditoria] [int] NOT NULL,
	[idActividad] [int] NOT NULL,
	[idAuditor] [int] NULL,
	[descripcionActividad] [varchar](50) NOT NULL,
	[lugar] [varchar](50) NOT NULL,
	[fechaInicio] [datetime] NULL,
	[fechaFin] [datetime] NULL,
	[estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_AC_ACTIVIDAD] PRIMARY KEY CLUSTERED 
(
	[idAuditoria] ASC,
	[idActividad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AC_AUDITOR]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AC_AUDITOR](
	[idAuditoria] [int] NOT NULL,
	[idAuditor] [int] NOT NULL,
 CONSTRAINT [PK_AC_AUDITOR] PRIMARY KEY CLUSTERED 
(
	[idAuditoria] ASC,
	[idAuditor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AC_HALLAZGO]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AC_HALLAZGO](
	[idHallazgo] [int] NOT NULL,
	[idAuditoria] [int] NOT NULL,
	[idPreguntaVerificacion] [int] NOT NULL,
	[tipoHallazgo] [varchar](20) NOT NULL,
	[descripcion] [varchar](1000) NOT NULL,
	[documento] [image] NULL,
	[fechaCompromiso] [datetime] NULL,
	[causa] [text] NULL,
	[accionCorrectiva] [text] NULL,
	[accionPreventiva] [text] NULL,
	[fechaSeguimiento] [datetime] NULL,
	[comentarioSeguimiento] [text] NULL,
	[estado] [varchar](20) NOT NULL,
 CONSTRAINT [PK_AC_HALLAZGO_1] PRIMARY KEY CLUSTERED 
(
	[idHallazgo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AC_CALIFICACION_AUDITOR]    Script Date: 03/14/2013 02:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AC_CALIFICACION_AUDITOR](
	[idCalificacionAuditoria] [int] NOT NULL,
	[idAuditoria] [int] NOT NULL,
	[idAuditor] [int] NOT NULL,
	[idPreguntaCalificacion] [int] NOT NULL,
	[respuesta] [text] NOT NULL,
	[observacion] [text] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ACP_ELIMINAR_AUDITORES_X_AUDITORIA]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACP_ELIMINAR_AUDITORES_X_AUDITORIA]    
(  
 @idAuditoria int
)  
AS  
BEGIN  	
 DELETE FROM AC_AUDITOR WHERE idAuditoria = @idAuditoria
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_ELIMINAR_ACTIVIDADES_X_AUDITORIA]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACP_ELIMINAR_ACTIVIDADES_X_AUDITORIA]    
(  
 @idAuditoria int
)  
AS  
BEGIN  	
 DELETE FROM AC_ACTIVIDAD WHERE idAuditoria = @idAuditoria
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_INSERTAR_AUDITOR]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACP_SP_INSERTAR_AUDITOR]    
(  
 @idAuditoria int,
 @idAuditor int
)  
AS  
BEGIN  
	INSERT INTO AC_AUDITOR VALUES (@idAuditoria,@idAuditor)
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_INSERTAR_ACTIVIDAD]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACP_SP_INSERTAR_ACTIVIDAD]    
(  
 @idAuditoria int,
 @idActividad int,
 @idAuditor int,
 @descripcionActividad varchar(50),
 @lugar varchar(50),
 @fechaInicio datetime,
 @fechaFin datetime,
 @estado varchar(10) 
)  
AS  
BEGIN  
	INSERT INTO AC_ACTIVIDAD (idAuditoria,idActividad,idAuditor,descripcionActividad,lugar,fechaInicio,fechaFin,estado)
	VALUES (@idAuditoria,@idActividad,@idAuditor,@descripcionActividad,@lugar,@fechaInicio,@fechaFin,@estado)
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_AUDITORES_POR_AUDITORIA]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACP_SP_LISTAR_AUDITORES_POR_AUDITORIA]    
(  
 @idAuditoria int
)  
AS  
BEGIN  	
SELECT idAuditoria,idAuditor FROM AC_AUDITOR WHERE idAuditoria = @idAuditoria
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_ACTIVIDADES_POR_AUDITORIA]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACP_SP_LISTAR_ACTIVIDADES_POR_AUDITORIA]    
(  
 @idAuditoria int
) 
AS  
BEGIN
	SELECT idAuditoria,idActividad,idAuditor,descripcionActividad,lugar,fechaInicio,fechaFin,estado 
	FROM AC_ACTIVIDAD
	WHERE idAuditoria = @idAuditoria
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC3]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC3]
	@idAuditoria int
as
BEGIN

	select A.idAuditoria, convert(varchar, ROW_NUMBER() OVER(ORDER BY A.idActividad asc)) AS Id, A.descripcionActividad, 
			(E.apepat + ' ' + E.apemat + ', ' + E.nombres) as responsable,
			A.lugar,
			convert(char(10), A.fechaInicio, 103) as fechaInicio,
			convert(char(10), A.fechaFin, 103) as fechaFin,
			A.estado
	from AC_ACTIVIDAD A
			inner join EMPLEADO E on (A.idAuditor = E.CODIGO_EMPLEADO) 
	where A.idAuditoria = @idAuditoria

END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC2]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC2]
	@idAuditoria int
as
BEGIN

	select A.idAuditoria,(E.apepat + ' ' + E.apemat + ', ' + E.nombres) as nombreAuditor
	from AC_AUDITOR A
		inner join EMPLEADO E on (A.idAuditor = E.CODIGO_EMPLEADO)
	where A.idAuditoria = @idAuditoria

END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_MODIFICAR_PREGUNTA_VERIFICACION]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raul Callupe
-- Create date: 26/11/2012
-- Description:	actualiza item del checklist de auditoria
-- =============================================
CREATE PROCEDURE [dbo].[ACP_SP_MODIFICAR_PREGUNTA_VERIFICACION]
(
	@idAuditoria int,
	@idPreguntaVerificacion int,
	@respuesta bit,
	@sustento varchar(200),
	@porcentaje numeric(10,2)
)
AS
BEGIN
	update AC_PREGUNTA_VERIFICACION
	set respuesta = @respuesta, sustento = @sustento, porcentaje = @porcentaje
	where idAuditoria = @idAuditoria and idPreguntaVerificacion = @idPreguntaVerificacion
			
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_AUDITORIA]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raul Callupe
-- Create date: 26/11/2012
-- Description:	Obtiene auditorias
-- =============================================
CREATE PROCEDURE [dbo].[ACP_SP_OBTENER_AUDITORIA]
(
	@anhoAuditoria int,
	@idAuditoria int, 
	@estado varchar(20),
	@indChecklistEstablecido bit
)
AS
BEGIN
	select AUD.CODIGO_AUDITORIA, ENT.idEntidadAuditada, ENT.descripcion as nombreEntidad, AREA.CODIGO_AREA, AREA.DESCRIPCION as nombreArea, 
			AUD.FECHA_INICIO, AUD.FECHA_FIN, AUD.ESTADO, ENT.responsableProyecto, 
			COUNT(PREG.idPreguntaVerificacion) as numItemsChecklist
	from AUDITORIA AUD
			inner join AC_ENTIDAD_AUDITADA ENT on (AUD.CODIGO_ENTIDAD_AUDITADA = ENT.idEntidadAuditada)
			inner join AREA AREA on (ENT.idArea = AREA.CODIGO_AREA)
			left join AC_PREGUNTA_VERIFICACION PREG on (AUD.CODIGO_AUDITORIA = PREG.idAuditoria)
	where	(@anhoAuditoria is null or year(AUD.FECHA_INICIO) = @anhoAuditoria) and
			(@idAuditoria is null or AUD.CODIGO_AUDITORIA = @idAuditoria) and
			(@estado is null or ESTADO = @estado)
	group by AUD.CODIGO_AUDITORIA, ENT.idEntidadAuditada, ENT.descripcion, AREA.CODIGO_AREA, AREA.DESCRIPCION, 
				AUD.FECHA_INICIO, AUD.FECHA_FIN, AUD.estado, ENT.responsableProyecto
	having (@indChecklistEstablecido = 1 and COUNT(PREG.idPreguntaVerificacion) > 0)
			
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_HALLAZGO]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raul Callupe
-- Create date: 26/11/2012
-- Description:	Obtiene uno o mas hallazgos
-- =============================================
CREATE PROCEDURE [dbo].[ACP_SP_OBTENER_HALLAZGO]
(
	@idHallazgo int,
	@idAuditoria int, 
	@idPreguntaVerificacion int,
	@estado varchar(20)
)
AS
BEGIN
	select	H.idHallazgo, H.tipoHallazgo, 
			min(H.descripcion) as descripcion, 
			min(H.idAuditoria) as idAuditoria, 
			min(H.idPreguntaVerificacion) as idPreguntaVerificacion, 
			min(H.estado)as estado, COUNT(A.idOrigen) as ndoc
	from	AC_HALLAZGO H
			left join AC_ARCHIVO A on (H.idHallazgo = A.idOrigen) and A.tipoOrigen='H'
	where (@idHallazgo is null or idHallazgo = @idHallazgo) and
			(@idAuditoria is null or H.idAuditoria = @idAuditoria) and
			(@idPreguntaVerificacion is null or H.idPreguntaVerificacion = @idPreguntaVerificacion) and
			(@estado is null or estado = @estado)		
	group by H.idHallazgo, H.tipoHallazgo
			
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_CHECKLIST]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raul Callupe
-- Create date: 26/11/2012
-- Description:	Obtiene checklist
-- =============================================
CREATE PROCEDURE [dbo].[ACP_SP_OBTENER_CHECKLIST] --1,1,2
(
	@idAuditoria int,
	@idNorma int,
	@idCapitulo int
)
AS
BEGIN
	select P.idPreguntaVerificacion, P.descripcionPregunta, P.respuesta, P.sustento, 
	P.porcentaje , P.idAuditoria, P.idNorma, P.idCapitulo, ISNULL(nCant,0) as nCantPlan
	from AC_PREGUNTA_VERIFICACION P	
	LEFT JOIN (select idPreguntaVerificacion, count(*) as nCant 
	from AC_HALLAZGO where estado<>'CREADO' group by idPreguntaVerificacion) H ON 
	P.idPreguntaVerificacion=H.idPreguntaVerificacion
	where idAuditoria = @idAuditoria and idNorma = @idNorma and idCapitulo = @idCapitulo
			
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_MODIFICAR_HALLAZGO]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raul Callupe
-- Create date: 26/11/2012
-- Description:	Actualiza un hallazgo para una auditoria asociada a una pregunta de verificacion
-- =============================================
CREATE PROCEDURE [dbo].[ACP_SP_MODIFICAR_HALLAZGO]
(
	@idHallazgo int,
	@tipoHallazgo varchar(20), 
	@descripcion varchar(1000),
	@estado varchar(20)
)
AS
BEGIN
	update AC_HALLAZGO
	set tipoHallazgo = isnull(@tipoHallazgo, tipoHallazgo),
		descripcion = isnull(@descripcion, descripcion)
	where idHallazgo = @idHallazgo
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_MATRIZ_ENTIDAD_AUDITADA]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACP_SP_LISTAR_MATRIZ_ENTIDAD_AUDITADA]     
AS  
BEGIN  

 SELECT	E.idEntidadAuditada, 
		E.descripcion AS NombreEntidadAuditada, 
		idArea AS codigoArea, 
		A.DESCRIPCION AS descripcionArea, 
		E.criticidad,
		E.riesgo,
		E.alcance,
		(SELECT COUNT(1) FROM AC_HALLAZGO
		WHERE idAuditoria IN (
			SELECT CODIGO_AUDITORIA 
			FROM dbo.AUDITORIA 
			WHERE CODIGO_ENTIDAD_AUDITADA = E.idEntidadAuditada)) nroseguimiento,
		(SELECT COUNT(1) 
		FROM dbo.AUDITORIA 
		WHERE CODIGO_ENTIDAD_AUDITADA = E.idEntidadAuditada) nroauditorias,
		(E.criticidad + E.riesgo + E.alcance + 
		(SELECT COUNT(1) FROM AC_HALLAZGO
		WHERE idAuditoria IN (
			SELECT CODIGO_AUDITORIA 
			FROM dbo.AUDITORIA 
			WHERE CODIGO_ENTIDAD_AUDITADA = E.idEntidadAuditada)) +
		(SELECT COUNT(1) 
		FROM dbo.AUDITORIA 
		WHERE CODIGO_ENTIDAD_AUDITADA = E.idEntidadAuditada)) puntaje
 FROM	AC_ENTIDAD_AUDITADA E     
 inner 
 join	AREA A on (E.idArea = A.CODIGO_AREA)   
 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_INSERTAR_HALLAZGO]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raul Callupe
-- Create date: 26/11/2012
-- Description:	Inserta un hallazgo para una auditoria asociada a una pregunta de verificacion
-- =============================================
CREATE PROCEDURE [dbo].[ACP_SP_INSERTAR_HALLAZGO]
(
	@tipoHallazgo varchar(20), 
	@descripcion varchar(1000), 
	@idAuditoria int, 
	@idPreguntaVerificacion int,
	@estado varchar(20),
	@idHallazgoCreado int output
)
AS
BEGIN
	declare @idHallazgoNuevo int
	select @idHallazgoNuevo = (ISNULL(MAX(idHallazgo), 0)+1) from AC_HALLAZGO

	insert into AC_HALLAZGO(idHallazgo, tipoHallazgo, descripcion, idAuditoria, idPreguntaVerificacion, estado)
	values(@idHallazgoNuevo, @tipoHallazgo, @descripcion, @idAuditoria, @idPreguntaVerificacion, @estado)
	
	set @idHallazgoCreado = @idHallazgoNuevo
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_ELIMINAR_HALLAZGO]    Script Date: 03/14/2013 02:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Raul Callupe
-- Create date: 26/11/2012
-- Description:	Actualiza un hallazgo para una auditoria asociada a una pregunta de verificacion
-- =============================================
CREATE PROCEDURE [dbo].[ACP_SP_ELIMINAR_HALLAZGO]
(
	@idHallazgo int
)
AS
BEGIN
	delete from AC_HALLAZGO where idHallazgo = @idHallazgo
END
GO
/****** Object:  ForeignKey [FK_AC_ACTIVIDAD_AC_AUDITORIA]    Script Date: 03/14/2013 02:34:04 ******/
ALTER TABLE [dbo].[AC_ACTIVIDAD]  WITH CHECK ADD  CONSTRAINT [FK_AC_ACTIVIDAD_AC_AUDITORIA] FOREIGN KEY([idAuditoria])
REFERENCES [dbo].[AUDITORIA] ([CODIGO_AUDITORIA])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AC_ACTIVIDAD] CHECK CONSTRAINT [FK_AC_ACTIVIDAD_AC_AUDITORIA]
GO
/****** Object:  ForeignKey [FK_AC_AUDITADOS_EMPLEADO]    Script Date: 03/14/2013 02:34:04 ******/
ALTER TABLE [dbo].[AC_AUDITADOS]  WITH CHECK ADD  CONSTRAINT [FK_AC_AUDITADOS_EMPLEADO] FOREIGN KEY([idAuditado])
REFERENCES [dbo].[EMPLEADO] ([CODIGO_EMPLEADO])
GO
ALTER TABLE [dbo].[AC_AUDITADOS] CHECK CONSTRAINT [FK_AC_AUDITADOS_EMPLEADO]
GO
/****** Object:  ForeignKey [FK_AC_AUDITOR_AC_AUDITORIA]    Script Date: 03/14/2013 02:34:04 ******/
ALTER TABLE [dbo].[AC_AUDITOR]  WITH CHECK ADD  CONSTRAINT [FK_AC_AUDITOR_AC_AUDITORIA] FOREIGN KEY([idAuditoria])
REFERENCES [dbo].[AUDITORIA] ([CODIGO_AUDITORIA])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AC_AUDITOR] CHECK CONSTRAINT [FK_AC_AUDITOR_AC_AUDITORIA]
GO
/****** Object:  ForeignKey [FK_AC_CALIFICACION_AUDITOR_AC_AUDITOR]    Script Date: 03/14/2013 02:34:04 ******/
ALTER TABLE [dbo].[AC_CALIFICACION_AUDITOR]  WITH CHECK ADD  CONSTRAINT [FK_AC_CALIFICACION_AUDITOR_AC_AUDITOR] FOREIGN KEY([idAuditoria], [idAuditor])
REFERENCES [dbo].[AC_AUDITOR] ([idAuditoria], [idAuditor])
GO
ALTER TABLE [dbo].[AC_CALIFICACION_AUDITOR] CHECK CONSTRAINT [FK_AC_CALIFICACION_AUDITOR_AC_AUDITOR]
GO
/****** Object:  ForeignKey [FK_AC_CALIFICACION_AUDITOR_AC_PREGUNTA_CALIFICACION]    Script Date: 03/14/2013 02:34:04 ******/
ALTER TABLE [dbo].[AC_CALIFICACION_AUDITOR]  WITH CHECK ADD  CONSTRAINT [FK_AC_CALIFICACION_AUDITOR_AC_PREGUNTA_CALIFICACION] FOREIGN KEY([idPreguntaCalificacion])
REFERENCES [dbo].[AC_PREGUNTA_CALIFICACION] ([idPreguntaCalificacion])
GO
ALTER TABLE [dbo].[AC_CALIFICACION_AUDITOR] CHECK CONSTRAINT [FK_AC_CALIFICACION_AUDITOR_AC_PREGUNTA_CALIFICACION]
GO
/****** Object:  ForeignKey [FK_AC_CAPITULO_AC_NORMA]    Script Date: 03/14/2013 02:34:04 ******/
ALTER TABLE [dbo].[AC_CAPITULO]  WITH CHECK ADD  CONSTRAINT [FK_AC_CAPITULO_AC_NORMA] FOREIGN KEY([idNorma])
REFERENCES [dbo].[AC_NORMA] ([idNorma])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AC_CAPITULO] CHECK CONSTRAINT [FK_AC_CAPITULO_AC_NORMA]
GO
/****** Object:  ForeignKey [FK_AC_DET_PREGUNTA_BASE_AC_CAPITULO]    Script Date: 03/14/2013 02:34:04 ******/
ALTER TABLE [dbo].[AC_DET_PREGUNTA_BASE]  WITH CHECK ADD  CONSTRAINT [FK_AC_DET_PREGUNTA_BASE_AC_CAPITULO] FOREIGN KEY([idCapitulo], [idNorma])
REFERENCES [dbo].[AC_CAPITULO] ([idNorma], [idCapitulo])
GO
ALTER TABLE [dbo].[AC_DET_PREGUNTA_BASE] CHECK CONSTRAINT [FK_AC_DET_PREGUNTA_BASE_AC_CAPITULO]
GO
/****** Object:  ForeignKey [FK_AC_DET_PREGUNTA_BASE_AC_PREGUNTA_BASE]    Script Date: 03/14/2013 02:34:04 ******/
ALTER TABLE [dbo].[AC_DET_PREGUNTA_BASE]  WITH CHECK ADD  CONSTRAINT [FK_AC_DET_PREGUNTA_BASE_AC_PREGUNTA_BASE] FOREIGN KEY([idPreguntaBase])
REFERENCES [dbo].[AC_PREGUNTA_BASE] ([idPreguntaBase])
GO
ALTER TABLE [dbo].[AC_DET_PREGUNTA_BASE] CHECK CONSTRAINT [FK_AC_DET_PREGUNTA_BASE_AC_PREGUNTA_BASE]
GO
/****** Object:  ForeignKey [FK_AC_ENTIDAD_AUDITADA_AC_AREA]    Script Date: 03/14/2013 02:34:04 ******/
ALTER TABLE [dbo].[AC_ENTIDAD_AUDITADA]  WITH CHECK ADD  CONSTRAINT [FK_AC_ENTIDAD_AUDITADA_AC_AREA] FOREIGN KEY([idArea])
REFERENCES [dbo].[AREA] ([CODIGO_AREA])
GO
ALTER TABLE [dbo].[AC_ENTIDAD_AUDITADA] CHECK CONSTRAINT [FK_AC_ENTIDAD_AUDITADA_AC_AREA]
GO
/****** Object:  ForeignKey [FK_AC_EVALUACION_AUDITORIA_AC_AUDITADOS]    Script Date: 03/14/2013 02:34:04 ******/
ALTER TABLE [dbo].[AC_EVALUACION_AUDITORIA]  WITH CHECK ADD  CONSTRAINT [FK_AC_EVALUACION_AUDITORIA_AC_AUDITADOS] FOREIGN KEY([idAuditoria], [idAuditado])
REFERENCES [dbo].[AC_AUDITADOS] ([idAuditoria], [idAuditado])
GO
ALTER TABLE [dbo].[AC_EVALUACION_AUDITORIA] CHECK CONSTRAINT [FK_AC_EVALUACION_AUDITORIA_AC_AUDITADOS]
GO
/****** Object:  ForeignKey [FK_AC_EVALUACION_AUDITORIA_AC_PREGUNTA_EVALUACION]    Script Date: 03/14/2013 02:34:04 ******/
ALTER TABLE [dbo].[AC_EVALUACION_AUDITORIA]  WITH CHECK ADD  CONSTRAINT [FK_AC_EVALUACION_AUDITORIA_AC_PREGUNTA_EVALUACION] FOREIGN KEY([idPreguntaEvaluacion])
REFERENCES [dbo].[AC_PREGUNTA_EVALUACION] ([idPreguntaEvaluacion])
GO
ALTER TABLE [dbo].[AC_EVALUACION_AUDITORIA] CHECK CONSTRAINT [FK_AC_EVALUACION_AUDITORIA_AC_PREGUNTA_EVALUACION]
GO
/****** Object:  ForeignKey [FK_AC_HALLAZGO_AC_PREGUNTA_VERIFICACION]    Script Date: 03/14/2013 02:34:04 ******/
ALTER TABLE [dbo].[AC_HALLAZGO]  WITH CHECK ADD  CONSTRAINT [FK_AC_HALLAZGO_AC_PREGUNTA_VERIFICACION] FOREIGN KEY([idAuditoria], [idPreguntaVerificacion])
REFERENCES [dbo].[AC_PREGUNTA_VERIFICACION] ([idAuditoria], [idPreguntaVerificacion])
GO
ALTER TABLE [dbo].[AC_HALLAZGO] CHECK CONSTRAINT [FK_AC_HALLAZGO_AC_PREGUNTA_VERIFICACION]
GO
/****** Object:  ForeignKey [FK_AC_PREGUNTA_VERIFICACION_AC_AUDITORIA]    Script Date: 03/14/2013 02:34:04 ******/
ALTER TABLE [dbo].[AC_PREGUNTA_VERIFICACION]  WITH CHECK ADD  CONSTRAINT [FK_AC_PREGUNTA_VERIFICACION_AC_AUDITORIA] FOREIGN KEY([idAuditoria])
REFERENCES [dbo].[AUDITORIA] ([CODIGO_AUDITORIA])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AC_PREGUNTA_VERIFICACION] CHECK CONSTRAINT [FK_AC_PREGUNTA_VERIFICACION_AC_AUDITORIA]
GO
/****** Object:  ForeignKey [FK_AC_AUDITORIA_AC_ENTIDAD_AUDITADA]    Script Date: 03/14/2013 02:34:04 ******/
ALTER TABLE [dbo].[AUDITORIA]  WITH CHECK ADD  CONSTRAINT [FK_AC_AUDITORIA_AC_ENTIDAD_AUDITADA] FOREIGN KEY([CODIGO_ENTIDAD_AUDITADA])
REFERENCES [dbo].[AC_ENTIDAD_AUDITADA] ([idEntidadAuditada])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AUDITORIA] CHECK CONSTRAINT [FK_AC_AUDITORIA_AC_ENTIDAD_AUDITADA]
GO
/****** Object:  ForeignKey [FK_AC_AUDITORIA_AC_PROGRAMA_AUDITORIA]    Script Date: 03/14/2013 02:34:04 ******/
ALTER TABLE [dbo].[AUDITORIA]  WITH CHECK ADD  CONSTRAINT [FK_AC_AUDITORIA_AC_PROGRAMA_AUDITORIA] FOREIGN KEY([CODIGO_PROGRAMA])
REFERENCES [dbo].[AC_PROGRAMA_AUDITORIA] ([idPrograma])
GO
ALTER TABLE [dbo].[AUDITORIA] CHECK CONSTRAINT [FK_AC_AUDITORIA_AC_PROGRAMA_AUDITORIA]
GO
/****** Object:  ForeignKey [FK_EMPLEADO_AC_AREA]    Script Date: 03/14/2013 02:34:04 ******/
ALTER TABLE [dbo].[EMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADO_AC_AREA] FOREIGN KEY([CODIGO_AREA])
REFERENCES [dbo].[AREA] ([CODIGO_AREA])
GO
ALTER TABLE [dbo].[EMPLEADO] CHECK CONSTRAINT [FK_EMPLEADO_AC_AREA]
GO
/****** Object:  ForeignKey [FK_USUARIO_PERFIL_USUARIO]    Script Date: 03/14/2013 02:34:04 ******/
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_PERFIL_USUARIO] FOREIGN KEY([CODIGO_PERFIL_USUARIO])
REFERENCES [dbo].[PERFIL_USUARIO] ([CODIGO_PERFIL_USUARIO])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [FK_USUARIO_PERFIL_USUARIO]
GO
