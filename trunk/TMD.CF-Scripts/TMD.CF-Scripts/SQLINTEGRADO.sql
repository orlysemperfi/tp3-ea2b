USE [master]
GO
/****** Object:  Database [TMD]    Script Date: 03/23/2013 16:50:41 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'TMD')
BEGIN
CREATE DATABASE [TMD] ON  PRIMARY 
( NAME = N'TMD', FILENAME = N'C:\BD\TMD.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ), 
 FILEGROUP [TMD_fg_filestream] CONTAINS FILESTREAM  DEFAULT 
( NAME = N'TMD_filestream', FILENAME = N'C:\SqlFileStream\TMD_2.TMD_FS' )
 LOG ON 
( NAME = N'TMD_log', FILENAME = N'C:\BD\TMD_1.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END
GO
ALTER DATABASE [TMD] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TMD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TMD] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [TMD] SET ANSI_NULLS OFF
GO
ALTER DATABASE [TMD] SET ANSI_PADDING OFF
GO
ALTER DATABASE [TMD] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [TMD] SET ARITHABORT OFF
GO
ALTER DATABASE [TMD] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [TMD] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [TMD] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [TMD] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [TMD] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [TMD] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [TMD] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [TMD] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [TMD] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [TMD] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [TMD] SET  DISABLE_BROKER
GO
ALTER DATABASE [TMD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [TMD] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [TMD] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [TMD] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [TMD] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [TMD] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [TMD] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [TMD] SET  READ_WRITE
GO
ALTER DATABASE [TMD] SET RECOVERY FULL
GO
ALTER DATABASE [TMD] SET  MULTI_USER
GO
ALTER DATABASE [TMD] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [TMD] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'TMD', N'ON'
GO
USE [TMD]
GO
/****** Object:  ForeignKey [Relacion_05]    Script Date: 03/23/2013 16:50:47 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_05]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO_CLIENTE]'))
ALTER TABLE [dbo].[USUARIO_CLIENTE] DROP CONSTRAINT [Relacion_05]
GO
/****** Object:  ForeignKey [Relacion_08]    Script Date: 03/23/2013 16:50:47 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_08]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO_CLIENTE]'))
ALTER TABLE [dbo].[USUARIO_CLIENTE] DROP CONSTRAINT [Relacion_08]
GO
/****** Object:  ForeignKey [FK_USUARIO_PERFIL_USUARIO]    Script Date: 03/23/2013 16:50:47 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_USUARIO_PERFIL_USUARIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO]'))
ALTER TABLE [dbo].[USUARIO] DROP CONSTRAINT [FK_USUARIO_PERFIL_USUARIO]
GO
/****** Object:  ForeignKey [Relacion_30]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_30]') AND parent_object_id = OBJECT_ID(N'[dbo].[SOFTWARE]'))
ALTER TABLE [dbo].[SOFTWARE] DROP CONSTRAINT [Relacion_30]
GO
/****** Object:  ForeignKey [FK_LECCION_APRENDIDA_PROCESO (MP)_LECCIONES_APRENDIDAS_PROCESO]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LECCION_APRENDIDA_PROCESO (MP)_LECCIONES_APRENDIDAS_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[LECCION_APRENDIDA_PROCESO]'))
ALTER TABLE [dbo].[LECCION_APRENDIDA_PROCESO] DROP CONSTRAINT [FK_LECCION_APRENDIDA_PROCESO (MP)_LECCIONES_APRENDIDAS_PROCESO]
GO
/****** Object:  ForeignKey [FK_LECCION_APRENDIDA_PROCESO (MP)_PROCESO]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LECCION_APRENDIDA_PROCESO (MP)_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[LECCION_APRENDIDA_PROCESO]'))
ALTER TABLE [dbo].[LECCION_APRENDIDA_PROCESO] DROP CONSTRAINT [FK_LECCION_APRENDIDA_PROCESO (MP)_PROCESO]
GO
/****** Object:  ForeignKey [Relacion_01]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_01]') AND parent_object_id = OBJECT_ID(N'[dbo].[PREGUNTA_ENCUESTA]'))
ALTER TABLE [dbo].[PREGUNTA_ENCUESTA] DROP CONSTRAINT [Relacion_01]
GO
/****** Object:  ForeignKey [Relacion_02]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_02]') AND parent_object_id = OBJECT_ID(N'[dbo].[PREGUNTA_ENCUESTA]'))
ALTER TABLE [dbo].[PREGUNTA_ENCUESTA] DROP CONSTRAINT [Relacion_02]
GO
/****** Object:  ForeignKey [FK_AC_CAPITULO_AC_NORMA]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_CAPITULO_AC_NORMA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_CAPITULO]'))
ALTER TABLE [dbo].[AC_CAPITULO] DROP CONSTRAINT [FK_AC_CAPITULO_AC_NORMA]
GO
/****** Object:  ForeignKey [FK_AC_ENTIDAD_AUDITADA_AC_AREA]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_ENTIDAD_AUDITADA_AC_AREA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_ENTIDAD_AUDITADA]'))
ALTER TABLE [dbo].[AC_ENTIDAD_AUDITADA] DROP CONSTRAINT [FK_AC_ENTIDAD_AUDITADA_AC_AREA]
GO
/****** Object:  ForeignKey [FK_INDICADOR_INDICADOR]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_INDICADOR_INDICADOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[INDICADOR]'))
ALTER TABLE [dbo].[INDICADOR] DROP CONSTRAINT [FK_INDICADOR_INDICADOR]
GO
/****** Object:  ForeignKey [FK_INDICADOR_PROCESO]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_INDICADOR_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[INDICADOR]'))
ALTER TABLE [dbo].[INDICADOR] DROP CONSTRAINT [FK_INDICADOR_PROCESO]
GO
/****** Object:  ForeignKey [Relacion_29]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_29]') AND parent_object_id = OBJECT_ID(N'[dbo].[HARDWARE]'))
ALTER TABLE [dbo].[HARDWARE] DROP CONSTRAINT [Relacion_29]
GO
/****** Object:  ForeignKey [FK_EMPLEADO_AC_AREA]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EMPLEADO_AC_AREA]') AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLEADO]'))
ALTER TABLE [dbo].[EMPLEADO] DROP CONSTRAINT [FK_EMPLEADO_AC_AREA]
GO
/****** Object:  ForeignKey [FK_EMPLEADO_AREA]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EMPLEADO_AREA]') AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLEADO]'))
ALTER TABLE [dbo].[EMPLEADO] DROP CONSTRAINT [FK_EMPLEADO_AREA]
GO
/****** Object:  ForeignKey [FK_EMPLEADO_EMPLEADO]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EMPLEADO_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLEADO]'))
ALTER TABLE [dbo].[EMPLEADO] DROP CONSTRAINT [FK_EMPLEADO_EMPLEADO]
GO
/****** Object:  ForeignKey [FK_EMPLEADO_PUESTO]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EMPLEADO_PUESTO]') AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLEADO]'))
ALTER TABLE [dbo].[EMPLEADO] DROP CONSTRAINT [FK_EMPLEADO_PUESTO]
GO
/****** Object:  ForeignKey [FK_ELEMENTO_CONFIGURACION_FASE]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ELEMENTO_CONFIGURACION_FASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[ELEMENTO_CONFIGURACION]'))
ALTER TABLE [dbo].[ELEMENTO_CONFIGURACION] DROP CONSTRAINT [FK_ELEMENTO_CONFIGURACION_FASE]
GO
/****** Object:  ForeignKey [Relacion_31]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_31]') AND parent_object_id = OBJECT_ID(N'[dbo].[DOCUMENTO]'))
ALTER TABLE [dbo].[DOCUMENTO] DROP CONSTRAINT [Relacion_31]
GO
/****** Object:  ForeignKey [Relacion_13]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_13]') AND parent_object_id = OBJECT_ID(N'[dbo].[DETALLE_SLA]'))
ALTER TABLE [dbo].[DETALLE_SLA] DROP CONSTRAINT [Relacion_13]
GO
/****** Object:  ForeignKey [FK_ARTEFACTO_PROCESO_PROCESO]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ARTEFACTO_PROCESO_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ARTEFACTO_PROCESO]'))
ALTER TABLE [dbo].[ARTEFACTO_PROCESO] DROP CONSTRAINT [FK_ARTEFACTO_PROCESO_PROCESO]
GO
/****** Object:  ForeignKey [Relacion_25]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_25]') AND parent_object_id = OBJECT_ID(N'[dbo].[INTEGRANTE]'))
ALTER TABLE [dbo].[INTEGRANTE] DROP CONSTRAINT [Relacion_25]
GO
/****** Object:  ForeignKey [Relacion_27]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_27]') AND parent_object_id = OBJECT_ID(N'[dbo].[INTEGRANTE]'))
ALTER TABLE [dbo].[INTEGRANTE] DROP CONSTRAINT [Relacion_27]
GO
/****** Object:  ForeignKey [FK_ESCALA_CUANTITATIVO_INDICADOR]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESCALA_CUANTITATIVO_INDICADOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESCALA_CUANTITATIVO]'))
ALTER TABLE [dbo].[ESCALA_CUANTITATIVO] DROP CONSTRAINT [FK_ESCALA_CUANTITATIVO_INDICADOR]
GO
/****** Object:  ForeignKey [FK_ESCALA_CUALITATIVO_INDICADOR]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESCALA_CUALITATIVO_INDICADOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESCALA_CUALITATIVO]'))
ALTER TABLE [dbo].[ESCALA_CUALITATIVO] DROP CONSTRAINT [FK_ESCALA_CUALITATIVO_INDICADOR]
GO
/****** Object:  ForeignKey [FK_PILOTO_EMPLEADO]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PILOTO_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PILOTO]'))
ALTER TABLE [dbo].[PILOTO] DROP CONSTRAINT [FK_PILOTO_EMPLEADO]
GO
/****** Object:  ForeignKey [FK_PERSONA_CLIENTE]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PERSONA_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[dbo].[PERSONA]'))
ALTER TABLE [dbo].[PERSONA] DROP CONSTRAINT [FK_PERSONA_CLIENTE]
GO
/****** Object:  ForeignKey [FK_PERSONA_CLIENTE1]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PERSONA_CLIENTE1]') AND parent_object_id = OBJECT_ID(N'[dbo].[PERSONA]'))
ALTER TABLE [dbo].[PERSONA] DROP CONSTRAINT [FK_PERSONA_CLIENTE1]
GO
/****** Object:  ForeignKey [FK_PERSONA_EMPLEADO]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PERSONA_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PERSONA]'))
ALTER TABLE [dbo].[PERSONA] DROP CONSTRAINT [FK_PERSONA_EMPLEADO]
GO
/****** Object:  ForeignKey [FK_Proyecto_CLIENTE]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Proyecto_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO]'))
ALTER TABLE [dbo].[PROYECTO] DROP CONSTRAINT [FK_Proyecto_CLIENTE]
GO
/****** Object:  ForeignKey [FK_Proyecto_USUARIO]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Proyecto_USUARIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO]'))
ALTER TABLE [dbo].[PROYECTO] DROP CONSTRAINT [FK_Proyecto_USUARIO]
GO
/****** Object:  ForeignKey [Relacion_10]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_10]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO]'))
ALTER TABLE [dbo].[PROYECTO] DROP CONSTRAINT [Relacion_10]
GO
/****** Object:  ForeignKey [FK_PROPUESTAMEJORA_EMPLEADO]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTAMEJORA_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTAMEJORA]'))
ALTER TABLE [dbo].[PROPUESTAMEJORA] DROP CONSTRAINT [FK_PROPUESTAMEJORA_EMPLEADO]
GO
/****** Object:  ForeignKey [FK_PROPUESTAMEJORA_PROCESO]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTAMEJORA_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTAMEJORA]'))
ALTER TABLE [dbo].[PROPUESTAMEJORA] DROP CONSTRAINT [FK_PROPUESTAMEJORA_PROCESO]
GO
/****** Object:  ForeignKey [FK_AC_AUDITADOS_EMPLEADO]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_AUDITADOS_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_AUDITADOS]'))
ALTER TABLE [dbo].[AC_AUDITADOS] DROP CONSTRAINT [FK_AC_AUDITADOS_EMPLEADO]
GO
/****** Object:  ForeignKey [FK_AC_DET_PREGUNTA_BASE_AC_CAPITULO]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_DET_PREGUNTA_BASE_AC_CAPITULO]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_DET_PREGUNTA_BASE]'))
ALTER TABLE [dbo].[AC_DET_PREGUNTA_BASE] DROP CONSTRAINT [FK_AC_DET_PREGUNTA_BASE_AC_CAPITULO]
GO
/****** Object:  ForeignKey [FK_AC_DET_PREGUNTA_BASE_AC_PREGUNTA_BASE]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_DET_PREGUNTA_BASE_AC_PREGUNTA_BASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_DET_PREGUNTA_BASE]'))
ALTER TABLE [dbo].[AC_DET_PREGUNTA_BASE] DROP CONSTRAINT [FK_AC_DET_PREGUNTA_BASE_AC_PREGUNTA_BASE]
GO
/****** Object:  ForeignKey [FK_AC_AUDITORIA_AC_ENTIDAD_AUDITADA]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_AUDITORIA_AC_ENTIDAD_AUDITADA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AUDITORIA]'))
ALTER TABLE [dbo].[AUDITORIA] DROP CONSTRAINT [FK_AC_AUDITORIA_AC_ENTIDAD_AUDITADA]
GO
/****** Object:  ForeignKey [FK_AC_AUDITORIA_AC_PROGRAMA_AUDITORIA]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_AUDITORIA_AC_PROGRAMA_AUDITORIA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AUDITORIA]'))
ALTER TABLE [dbo].[AUDITORIA] DROP CONSTRAINT [FK_AC_AUDITORIA_AC_PROGRAMA_AUDITORIA]
GO
/****** Object:  ForeignKey [Relacion_04]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_04]') AND parent_object_id = OBJECT_ID(N'[dbo].[RESPUESTA_ENCUESTA]'))
ALTER TABLE [dbo].[RESPUESTA_ENCUESTA] DROP CONSTRAINT [Relacion_04]
GO
/****** Object:  ForeignKey [Relacion_42]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_42]') AND parent_object_id = OBJECT_ID(N'[dbo].[RESPUESTA_ENCUESTA]'))
ALTER TABLE [dbo].[RESPUESTA_ENCUESTA] DROP CONSTRAINT [Relacion_42]
GO
/****** Object:  ForeignKey [FK_USUARIO_PROYECTO_Proyecto]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_USUARIO_PROYECTO_Proyecto]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO_PROYECTO]'))
ALTER TABLE [dbo].[USUARIO_PROYECTO] DROP CONSTRAINT [FK_USUARIO_PROYECTO_Proyecto]
GO
/****** Object:  ForeignKey [FK_USUARIO_PROYECTO_USUARIO]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_USUARIO_PROYECTO_USUARIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO_PROYECTO]'))
ALTER TABLE [dbo].[USUARIO_PROYECTO] DROP CONSTRAINT [FK_USUARIO_PROYECTO_USUARIO]
GO
/****** Object:  ForeignKey [FK_SOLUCION_MEJORA_EMPLEADO]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SOLUCION_MEJORA_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[SOLUCION_MEJORA]'))
ALTER TABLE [dbo].[SOLUCION_MEJORA] DROP CONSTRAINT [FK_SOLUCION_MEJORA_EMPLEADO]
GO
/****** Object:  ForeignKey [FK_SOLUCION_MEJORA_PROPUESTAMEJORA]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SOLUCION_MEJORA_PROPUESTAMEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[SOLUCION_MEJORA]'))
ALTER TABLE [dbo].[SOLUCION_MEJORA] DROP CONSTRAINT [FK_SOLUCION_MEJORA_PROPUESTAMEJORA]
GO
/****** Object:  ForeignKey [Relacion_09]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_09]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE] DROP CONSTRAINT [Relacion_09]
GO
/****** Object:  ForeignKey [Relacion_11]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_11]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE] DROP CONSTRAINT [Relacion_11]
GO
/****** Object:  ForeignKey [Relacion_18]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_18]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE] DROP CONSTRAINT [Relacion_18]
GO
/****** Object:  ForeignKey [Relacion_36]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_36]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE] DROP CONSTRAINT [Relacion_36]
GO
/****** Object:  ForeignKey [FK_PROYECTO_FASE_FASE]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROYECTO_FASE_FASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_FASE]'))
ALTER TABLE [dbo].[PROYECTO_FASE] DROP CONSTRAINT [FK_PROYECTO_FASE_FASE]
GO
/****** Object:  ForeignKey [FK_PROYECTO_FASE_Proyecto1]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROYECTO_FASE_Proyecto1]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_FASE]'))
ALTER TABLE [dbo].[PROYECTO_FASE] DROP CONSTRAINT [FK_PROYECTO_FASE_Proyecto1]
GO
/****** Object:  ForeignKey [Relacion_34]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_34]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_CMDB]'))
ALTER TABLE [dbo].[PROYECTO_CMDB] DROP CONSTRAINT [Relacion_34]
GO
/****** Object:  ForeignKey [Relacion_35]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_35]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_CMDB]'))
ALTER TABLE [dbo].[PROYECTO_CMDB] DROP CONSTRAINT [Relacion_35]
GO
/****** Object:  ForeignKey [Relacion_06]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_06]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_USUARIO_CLIENTE]'))
ALTER TABLE [dbo].[PROYECTO_USUARIO_CLIENTE] DROP CONSTRAINT [Relacion_06]
GO
/****** Object:  ForeignKey [Relacion_07]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_07]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_USUARIO_CLIENTE]'))
ALTER TABLE [dbo].[PROYECTO_USUARIO_CLIENTE] DROP CONSTRAINT [Relacion_07]
GO
/****** Object:  ForeignKey [FK_AC_PREGUNTA_VERIFICACION_AC_AUDITORIA]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_PREGUNTA_VERIFICACION_AC_AUDITORIA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_PREGUNTA_VERIFICACION]'))
ALTER TABLE [dbo].[AC_PREGUNTA_VERIFICACION] DROP CONSTRAINT [FK_AC_PREGUNTA_VERIFICACION_AC_AUDITORIA]
GO
/****** Object:  ForeignKey [FK_AC_ACTIVIDAD_AC_AUDITORIA]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_ACTIVIDAD_AC_AUDITORIA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_ACTIVIDAD]'))
ALTER TABLE [dbo].[AC_ACTIVIDAD] DROP CONSTRAINT [FK_AC_ACTIVIDAD_AC_AUDITORIA]
GO
/****** Object:  ForeignKey [FK_AC_AUDITOR_AC_AUDITORIA]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_AUDITOR_AC_AUDITORIA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_AUDITOR]'))
ALTER TABLE [dbo].[AC_AUDITOR] DROP CONSTRAINT [FK_AC_AUDITOR_AC_AUDITORIA]
GO
/****** Object:  ForeignKey [FK_PROPUESTA_INDICADOR_INDICADOR]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_INDICADOR_INDICADOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_INDICADOR]'))
ALTER TABLE [dbo].[PROPUESTA_INDICADOR] DROP CONSTRAINT [FK_PROPUESTA_INDICADOR_INDICADOR]
GO
/****** Object:  ForeignKey [FK_PROPUESTA_INDICADOR_PROPUESTAMEJORA]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_INDICADOR_PROPUESTAMEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_INDICADOR]'))
ALTER TABLE [dbo].[PROPUESTA_INDICADOR] DROP CONSTRAINT [FK_PROPUESTA_INDICADOR_PROPUESTAMEJORA]
GO
/****** Object:  ForeignKey [FK_PROPUESTA_ESTADO_EMPLEADO]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_ESTADO_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_ESTADO]'))
ALTER TABLE [dbo].[PROPUESTA_ESTADO] DROP CONSTRAINT [FK_PROPUESTA_ESTADO_EMPLEADO]
GO
/****** Object:  ForeignKey [FK_PROPUESTA_ESTADO_ESTADO]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_ESTADO_ESTADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_ESTADO]'))
ALTER TABLE [dbo].[PROPUESTA_ESTADO] DROP CONSTRAINT [FK_PROPUESTA_ESTADO_ESTADO]
GO
/****** Object:  ForeignKey [FK_PROPUESTA_ESTADO_PROPUESTAMEJORA]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_ESTADO_PROPUESTAMEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_ESTADO]'))
ALTER TABLE [dbo].[PROPUESTA_ESTADO] DROP CONSTRAINT [FK_PROPUESTA_ESTADO_PROPUESTAMEJORA]
GO
/****** Object:  ForeignKey [FK_OBSERVACIONES_PILOTO_PILOTO]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OBSERVACIONES_PILOTO_PILOTO]') AND parent_object_id = OBJECT_ID(N'[dbo].[OBSERVACIONES_PILOTO]'))
ALTER TABLE [dbo].[OBSERVACIONES_PILOTO] DROP CONSTRAINT [FK_OBSERVACIONES_PILOTO_PILOTO]
GO
/****** Object:  ForeignKey [FK_ESTADO_PILOTO_ESTADO]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESTADO_PILOTO_ESTADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESTADO_PILOTO]'))
ALTER TABLE [dbo].[ESTADO_PILOTO] DROP CONSTRAINT [FK_ESTADO_PILOTO_ESTADO]
GO
/****** Object:  ForeignKey [FK_ESTADO_PILOTO_PILOTO]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESTADO_PILOTO_PILOTO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESTADO_PILOTO]'))
ALTER TABLE [dbo].[ESTADO_PILOTO] DROP CONSTRAINT [FK_ESTADO_PILOTO_PILOTO]
GO
/****** Object:  ForeignKey [FK_AC_EVALUACION_AUDITORIA_AC_AUDITADOS]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_EVALUACION_AUDITORIA_AC_AUDITADOS]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_EVALUACION_AUDITORIA]'))
ALTER TABLE [dbo].[AC_EVALUACION_AUDITORIA] DROP CONSTRAINT [FK_AC_EVALUACION_AUDITORIA_AC_AUDITADOS]
GO
/****** Object:  ForeignKey [FK_AC_EVALUACION_AUDITORIA_AC_PREGUNTA_EVALUACION]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_EVALUACION_AUDITORIA_AC_PREGUNTA_EVALUACION]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_EVALUACION_AUDITORIA]'))
ALTER TABLE [dbo].[AC_EVALUACION_AUDITORIA] DROP CONSTRAINT [FK_AC_EVALUACION_AUDITORIA_AC_PREGUNTA_EVALUACION]
GO
/****** Object:  ForeignKey [FK_ESTADO_SOLUCION_ESTADO]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESTADO_SOLUCION_ESTADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESTADO_SOLUCION]'))
ALTER TABLE [dbo].[ESTADO_SOLUCION] DROP CONSTRAINT [FK_ESTADO_SOLUCION_ESTADO]
GO
/****** Object:  ForeignKey [FK_ESTADO_SOLUCION_SOLUCION_MEJORA]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESTADO_SOLUCION_SOLUCION_MEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESTADO_SOLUCION]'))
ALTER TABLE [dbo].[ESTADO_SOLUCION] DROP CONSTRAINT [FK_ESTADO_SOLUCION_SOLUCION_MEJORA]
GO
/****** Object:  ForeignKey [FK_LINEA_BASE_PROYECTO_FASE]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LINEA_BASE_PROYECTO_FASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[LINEA_BASE]'))
ALTER TABLE [dbo].[LINEA_BASE] DROP CONSTRAINT [FK_LINEA_BASE_PROYECTO_FASE]
GO
/****** Object:  ForeignKey [FK_AC_HALLAZGO_AC_PREGUNTA_VERIFICACION]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_HALLAZGO_AC_PREGUNTA_VERIFICACION]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_HALLAZGO]'))
ALTER TABLE [dbo].[AC_HALLAZGO] DROP CONSTRAINT [FK_AC_HALLAZGO_AC_PREGUNTA_VERIFICACION]
GO
/****** Object:  ForeignKey [FK_AC_CALIFICACION_AUDITOR_AC_AUDITOR]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_CALIFICACION_AUDITOR_AC_AUDITOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_CALIFICACION_AUDITOR]'))
ALTER TABLE [dbo].[AC_CALIFICACION_AUDITOR] DROP CONSTRAINT [FK_AC_CALIFICACION_AUDITOR_AC_AUDITOR]
GO
/****** Object:  ForeignKey [FK_AC_CALIFICACION_AUDITOR_AC_PREGUNTA_CALIFICACION]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_CALIFICACION_AUDITOR_AC_PREGUNTA_CALIFICACION]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_CALIFICACION_AUDITOR]'))
ALTER TABLE [dbo].[AC_CALIFICACION_AUDITOR] DROP CONSTRAINT [FK_AC_CALIFICACION_AUDITOR_AC_PREGUNTA_CALIFICACION]
GO
/****** Object:  ForeignKey [FK_ACCIONES_SOLUCION_SOLUCION_MEJORA]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ACCIONES_SOLUCION_SOLUCION_MEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[ACCIONES_SOLUCION]'))
ALTER TABLE [dbo].[ACCIONES_SOLUCION] DROP CONSTRAINT [FK_ACCIONES_SOLUCION_SOLUCION_MEJORA]
GO
/****** Object:  ForeignKey [Relacion_16]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_16]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO] DROP CONSTRAINT [Relacion_16]
GO
/****** Object:  ForeignKey [Relacion_17]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_17]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO] DROP CONSTRAINT [Relacion_17]
GO
/****** Object:  ForeignKey [FK_PLAN_DESPLIEGUE_EMPLEADO]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PLAN_DESPLIEGUE_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PLAN_DESPLIEGUE]'))
ALTER TABLE [dbo].[PLAN_DESPLIEGUE] DROP CONSTRAINT [FK_PLAN_DESPLIEGUE_EMPLEADO]
GO
/****** Object:  ForeignKey [FK_PLAN_DESPLIEGUE_SOLUCION_MEJORA1]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PLAN_DESPLIEGUE_SOLUCION_MEJORA1]') AND parent_object_id = OBJECT_ID(N'[dbo].[PLAN_DESPLIEGUE]'))
ALTER TABLE [dbo].[PLAN_DESPLIEGUE] DROP CONSTRAINT [FK_PLAN_DESPLIEGUE_SOLUCION_MEJORA1]
GO
/****** Object:  ForeignKey [Relacion_12]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_12]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET] DROP CONSTRAINT [Relacion_12]
GO
/****** Object:  ForeignKey [Relacion_40]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_40]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET] DROP CONSTRAINT [Relacion_40]
GO
/****** Object:  ForeignKey [Relacion_41]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_41]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET] DROP CONSTRAINT [Relacion_41]
GO
/****** Object:  ForeignKey [Relacion_43]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_43]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET] DROP CONSTRAINT [Relacion_43]
GO
/****** Object:  ForeignKey [Relacion_44]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_44]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET] DROP CONSTRAINT [Relacion_44]
GO
/****** Object:  ForeignKey [FK_LINEA_BASE_DETALLE_ELEMENTO_CONFIGURACION]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LINEA_BASE_DETALLE_ELEMENTO_CONFIGURACION]') AND parent_object_id = OBJECT_ID(N'[dbo].[LINEA_BASE_DETALLE]'))
ALTER TABLE [dbo].[LINEA_BASE_DETALLE] DROP CONSTRAINT [FK_LINEA_BASE_DETALLE_ELEMENTO_CONFIGURACION]
GO
/****** Object:  ForeignKey [FK_LINEA_BASE_DETALLE_LINEA_BASE]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LINEA_BASE_DETALLE_LINEA_BASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[LINEA_BASE_DETALLE]'))
ALTER TABLE [dbo].[LINEA_BASE_DETALLE] DROP CONSTRAINT [FK_LINEA_BASE_DETALLE_LINEA_BASE]
GO
/****** Object:  ForeignKey [Relacion_21]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_21]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORMACION_SEGUIMIENTO]'))
ALTER TABLE [dbo].[INFORMACION_SEGUIMIENTO] DROP CONSTRAINT [Relacion_21]
GO
/****** Object:  ForeignKey [Relacion_37]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_37]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORMACION_SEGUIMIENTO]'))
ALTER TABLE [dbo].[INFORMACION_SEGUIMIENTO] DROP CONSTRAINT [Relacion_37]
GO
/****** Object:  ForeignKey [Relacion_20]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_20]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORMACION_ADICIONAL]'))
ALTER TABLE [dbo].[INFORMACION_ADICIONAL] DROP CONSTRAINT [Relacion_20]
GO
/****** Object:  ForeignKey [Relacion_39]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_39]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORMACION_ADICIONAL]'))
ALTER TABLE [dbo].[INFORMACION_ADICIONAL] DROP CONSTRAINT [Relacion_39]
GO
/****** Object:  ForeignKey [FK_SOLICITUD_CAMBIO_LINEA_BASE_DETALLE]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SOLICITUD_CAMBIO_LINEA_BASE_DETALLE]') AND parent_object_id = OBJECT_ID(N'[dbo].[SOLICITUD_CAMBIO]'))
ALTER TABLE [dbo].[SOLICITUD_CAMBIO] DROP CONSTRAINT [FK_SOLICITUD_CAMBIO_LINEA_BASE_DETALLE]
GO
/****** Object:  ForeignKey [Relacion_19]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_19]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET_LECCION_APRENDIDA]'))
ALTER TABLE [dbo].[TICKET_LECCION_APRENDIDA] DROP CONSTRAINT [Relacion_19]
GO
/****** Object:  ForeignKey [Relacion_28]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_28]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET_LECCION_APRENDIDA]'))
ALTER TABLE [dbo].[TICKET_LECCION_APRENDIDA] DROP CONSTRAINT [Relacion_28]
GO
/****** Object:  ForeignKey [Relacion_15]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_15]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET_CMDB]'))
ALTER TABLE [dbo].[TICKET_CMDB] DROP CONSTRAINT [Relacion_15]
GO
/****** Object:  ForeignKey [Relacion_32]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_32]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET_CMDB]'))
ALTER TABLE [dbo].[TICKET_CMDB] DROP CONSTRAINT [Relacion_32]
GO
/****** Object:  ForeignKey [FK_INFORME_CAMBIO_SOLICITUD_CAMBIO]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_INFORME_CAMBIO_SOLICITUD_CAMBIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORME_CAMBIO]'))
ALTER TABLE [dbo].[INFORME_CAMBIO] DROP CONSTRAINT [FK_INFORME_CAMBIO_SOLICITUD_CAMBIO]
GO
/****** Object:  ForeignKey [FK_ORDEN_CAMBIO_INFORME_CAMBIO]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ORDEN_CAMBIO_INFORME_CAMBIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ORDEN_CAMBIO]'))
ALTER TABLE [dbo].[ORDEN_CAMBIO] DROP CONSTRAINT [FK_ORDEN_CAMBIO_INFORME_CAMBIO]
GO
/****** Object:  Check [CK_CLIENTE_TIPO_CLIENTE]    Script Date: 03/23/2013 16:50:46 ******/
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_CLIENTE_TIPO_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[dbo].[CLIENTE]'))
BEGIN
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_CLIENTE_TIPO_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[dbo].[CLIENTE]'))
ALTER TABLE [dbo].[CLIENTE] DROP CONSTRAINT [CK_CLIENTE_TIPO_CLIENTE]

END
GO
/****** Object:  StoredProcedure [dbo].[USP_ORDEN_CAMBIO_INS]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ORDEN_CAMBIO_INS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_ORDEN_CAMBIO_INS]
GO
/****** Object:  StoredProcedure [dbo].[USP_ORDEN_CAMBIO_SEL_ARCHIVO]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ORDEN_CAMBIO_SEL_ARCHIVO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_ORDEN_CAMBIO_SEL_ARCHIVO]
GO
/****** Object:  StoredProcedure [dbo].[USP_ORDEN_CAMBIO_SEL_CODIGO]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ORDEN_CAMBIO_SEL_CODIGO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_ORDEN_CAMBIO_SEL_CODIGO]
GO
/****** Object:  StoredProcedure [dbo].[USP_ORDEN_CAMBIO_SEL_INFORME]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ORDEN_CAMBIO_SEL_INFORME]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_ORDEN_CAMBIO_SEL_INFORME]
GO
/****** Object:  StoredProcedure [dbo].[USP_ORDEN_CAMBIO_SEL_PROYECTO_LINEABASE]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ORDEN_CAMBIO_SEL_PROYECTO_LINEABASE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_ORDEN_CAMBIO_SEL_PROYECTO_LINEABASE]
GO
/****** Object:  StoredProcedure [dbo].[USP_ORDEN_CAMBIO_UPD_ARCHIVO]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ORDEN_CAMBIO_UPD_ARCHIVO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_ORDEN_CAMBIO_UPD_ARCHIVO]
GO
/****** Object:  StoredProcedure [dbo].[USP_LISTA_INFORME_POR_SOLICITUD]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LISTA_INFORME_POR_SOLICITUD]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_LISTA_INFORME_POR_SOLICITUD]
GO
/****** Object:  StoredProcedure [dbo].[USP_INFORME_CAMBIO_APROBAR_UPD]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_INFORME_CAMBIO_APROBAR_UPD]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_INFORME_CAMBIO_APROBAR_UPD]
GO
/****** Object:  StoredProcedure [dbo].[USP_INFORME_CAMBIO_INS]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_INFORME_CAMBIO_INS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_INFORME_CAMBIO_INS]
GO
/****** Object:  StoredProcedure [dbo].[USP_INFORME_CAMBIO_SEL_ARCHIVO]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_INFORME_CAMBIO_SEL_ARCHIVO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_INFORME_CAMBIO_SEL_ARCHIVO]
GO
/****** Object:  StoredProcedure [dbo].[USP_INFORME_CAMBIO_SEL_CODIGO]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_INFORME_CAMBIO_SEL_CODIGO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_INFORME_CAMBIO_SEL_CODIGO]
GO
/****** Object:  StoredProcedure [dbo].[USP_INFORME_CAMBIO_SEL_PROYECTO_LINEABASE]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_INFORME_CAMBIO_SEL_PROYECTO_LINEABASE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_INFORME_CAMBIO_SEL_PROYECTO_LINEABASE]
GO
/****** Object:  StoredProcedure [dbo].[USP_INFORME_CAMBIO_SEL_PROYECTO_LINEABASE_NONULL]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_INFORME_CAMBIO_SEL_PROYECTO_LINEABASE_NONULL]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_INFORME_CAMBIO_SEL_PROYECTO_LINEABASE_NONULL]
GO
/****** Object:  StoredProcedure [dbo].[USP_INFORME_CAMBIO_UPD_ARCHIVO]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_INFORME_CAMBIO_UPD_ARCHIVO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_INFORME_CAMBIO_UPD_ARCHIVO]
GO
/****** Object:  Table [dbo].[ORDEN_CAMBIO]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ORDEN_CAMBIO_INFORME_CAMBIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ORDEN_CAMBIO]'))
ALTER TABLE [dbo].[ORDEN_CAMBIO] DROP CONSTRAINT [FK_ORDEN_CAMBIO_INFORME_CAMBIO]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__ORDEN_CAM__ROWGU__74AE54BC]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ORDEN_CAMBIO] DROP CONSTRAINT [DF__ORDEN_CAM__ROWGU__74AE54BC]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ORDEN_CAMBIO]') AND type in (N'U'))
DROP TABLE [dbo].[ORDEN_CAMBIO]
GO
/****** Object:  Table [dbo].[INFORME_CAMBIO]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_INFORME_CAMBIO_SOLICITUD_CAMBIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORME_CAMBIO]'))
ALTER TABLE [dbo].[INFORME_CAMBIO] DROP CONSTRAINT [FK_INFORME_CAMBIO_SOLICITUD_CAMBIO]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__INFORME_C__ROWGU__48CFD27E]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[INFORME_CAMBIO] DROP CONSTRAINT [DF__INFORME_C__ROWGU__48CFD27E]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INFORME_CAMBIO]') AND type in (N'U'))
DROP TABLE [dbo].[INFORME_CAMBIO]
GO
/****** Object:  StoredProcedure [dbo].[usp_InformacionSeguimiento_AgregarSeguimiento]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_InformacionSeguimiento_AgregarSeguimiento]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_InformacionSeguimiento_AgregarSeguimiento]
GO
/****** Object:  StoredProcedure [dbo].[usp_InformacionSeguimiento_ModificarSeguimiento]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_InformacionSeguimiento_ModificarSeguimiento]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_InformacionSeguimiento_ModificarSeguimiento]
GO
/****** Object:  StoredProcedure [dbo].[USP_LISTA_SOLICITUD_PROYECTO_BASE]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LISTA_SOLICITUD_PROYECTO_BASE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_LISTA_SOLICITUD_PROYECTO_BASE]
GO
/****** Object:  StoredProcedure [dbo].[USP_SOLICITUD_CAMBIO_APROBAR_UPD]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_SOLICITUD_CAMBIO_APROBAR_UPD]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_SOLICITUD_CAMBIO_APROBAR_UPD]
GO
/****** Object:  StoredProcedure [dbo].[USP_SOLICITUD_CAMBIO_ESTADO_UPD]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_SOLICITUD_CAMBIO_ESTADO_UPD]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_SOLICITUD_CAMBIO_ESTADO_UPD]
GO
/****** Object:  StoredProcedure [dbo].[USP_SOLICITUD_CAMBIO_INS]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_SOLICITUD_CAMBIO_INS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_SOLICITUD_CAMBIO_INS]
GO
/****** Object:  StoredProcedure [dbo].[USP_SOLICITUD_CAMBIO_MOTIVO_UPD]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_SOLICITUD_CAMBIO_MOTIVO_UPD]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_SOLICITUD_CAMBIO_MOTIVO_UPD]
GO
/****** Object:  StoredProcedure [dbo].[USP_SOLICITUD_CAMBIO_SEL_ARCHIVO]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_SOLICITUD_CAMBIO_SEL_ARCHIVO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_SOLICITUD_CAMBIO_SEL_ARCHIVO]
GO
/****** Object:  StoredProcedure [dbo].[USP_SOLICITUD_CAMBIO_SEL_CODIGO]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_SOLICITUD_CAMBIO_SEL_CODIGO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_SOLICITUD_CAMBIO_SEL_CODIGO]
GO
/****** Object:  StoredProcedure [dbo].[USP_SOLICITUD_CAMBIO_SEL_PROYECTO_LINEABASE]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_SOLICITUD_CAMBIO_SEL_PROYECTO_LINEABASE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_SOLICITUD_CAMBIO_SEL_PROYECTO_LINEABASE]
GO
/****** Object:  StoredProcedure [dbo].[USP_SOLICITUD_CAMBIO_UPD_ARCHIVO]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_SOLICITUD_CAMBIO_UPD_ARCHIVO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_SOLICITUD_CAMBIO_UPD_ARCHIVO]
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_AgregarCMDB]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_AgregarCMDB]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Ticket_AgregarCMDB]
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_AgregarLeccionAprendida]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_AgregarLeccionAprendida]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Ticket_AgregarLeccionAprendida]
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_ListaCMDB]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_ListaCMDB]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Ticket_ListaCMDB]
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_ModificarCMDB]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_ModificarCMDB]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Ticket_ModificarCMDB]
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_ModificarLeccionAprendida]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_ModificarLeccionAprendida]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Ticket_ModificarLeccionAprendida]
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_ModificarTicket]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_ModificarTicket]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Ticket_ModificarTicket]
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_RegistrarSolucion]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_RegistrarSolucion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Ticket_RegistrarSolucion]
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_ListaTicketsEstado]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_ListaTicketsEstado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Ticket_ListaTicketsEstado]
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_ListaTicketsIntegrante]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_ListaTicketsIntegrante]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Ticket_ListaTicketsIntegrante]
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_ListaTicketsIntegranteProyecto]    Script Date: 03/23/2013 16:50:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_ListaTicketsIntegranteProyecto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Ticket_ListaTicketsIntegranteProyecto]
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_AgregarTicket]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_AgregarTicket]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Ticket_AgregarTicket]
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_CambiarEstado]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_CambiarEstado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Ticket_CambiarEstado]
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_DatosTicket]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_DatosTicket]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Ticket_DatosTicket]
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_DET_DEL_CODIGO_LINEA_BASE]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_DET_DEL_CODIGO_LINEA_BASE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_LINEA_BASE_DET_DEL_CODIGO_LINEA_BASE]
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_DET_SEL_CODIGO]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_DET_SEL_CODIGO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_LINEA_BASE_DET_SEL_CODIGO]
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_DET_SEL_CODIGO_LINEA_BASE]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_DET_SEL_CODIGO_LINEA_BASE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_LINEA_BASE_DET_SEL_CODIGO_LINEA_BASE]
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_DETALLE_INS]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_DETALLE_INS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_LINEA_BASE_DETALLE_INS]
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_DETALLE_SEL_ARCHIVO]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_DETALLE_SEL_ARCHIVO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_LINEA_BASE_DETALLE_SEL_ARCHIVO]
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_DETALLE_UPD_ARCHIVO]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_DETALLE_UPD_ARCHIVO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_LINEA_BASE_DETALLE_UPD_ARCHIVO]
GO
/****** Object:  Table [dbo].[TICKET_CMDB]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_15]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET_CMDB]'))
ALTER TABLE [dbo].[TICKET_CMDB] DROP CONSTRAINT [Relacion_15]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_32]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET_CMDB]'))
ALTER TABLE [dbo].[TICKET_CMDB] DROP CONSTRAINT [Relacion_32]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TICKET_CMDB]') AND type in (N'U'))
DROP TABLE [dbo].[TICKET_CMDB]
GO
/****** Object:  Table [dbo].[TICKET_LECCION_APRENDIDA]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_19]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET_LECCION_APRENDIDA]'))
ALTER TABLE [dbo].[TICKET_LECCION_APRENDIDA] DROP CONSTRAINT [Relacion_19]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_28]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET_LECCION_APRENDIDA]'))
ALTER TABLE [dbo].[TICKET_LECCION_APRENDIDA] DROP CONSTRAINT [Relacion_28]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TICKET_LECCION_APRENDIDA]') AND type in (N'U'))
DROP TABLE [dbo].[TICKET_LECCION_APRENDIDA]
GO
/****** Object:  Table [dbo].[SOLICITUD_CAMBIO]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SOLICITUD_CAMBIO_LINEA_BASE_DETALLE]') AND parent_object_id = OBJECT_ID(N'[dbo].[SOLICITUD_CAMBIO]'))
ALTER TABLE [dbo].[SOLICITUD_CAMBIO] DROP CONSTRAINT [FK_SOLICITUD_CAMBIO_LINEA_BASE_DETALLE]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__SOLICITUD__ROWGU__70DDC3D8]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SOLICITUD_CAMBIO] DROP CONSTRAINT [DF__SOLICITUD__ROWGU__70DDC3D8]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SOLICITUD_CAMBIO]') AND type in (N'U'))
DROP TABLE [dbo].[SOLICITUD_CAMBIO]
GO
/****** Object:  Table [dbo].[INFORMACION_ADICIONAL]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_20]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORMACION_ADICIONAL]'))
ALTER TABLE [dbo].[INFORMACION_ADICIONAL] DROP CONSTRAINT [Relacion_20]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_39]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORMACION_ADICIONAL]'))
ALTER TABLE [dbo].[INFORMACION_ADICIONAL] DROP CONSTRAINT [Relacion_39]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INFORMACION_ADICIONAL]') AND type in (N'U'))
DROP TABLE [dbo].[INFORMACION_ADICIONAL]
GO
/****** Object:  Table [dbo].[INFORMACION_SEGUIMIENTO]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_21]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORMACION_SEGUIMIENTO]'))
ALTER TABLE [dbo].[INFORMACION_SEGUIMIENTO] DROP CONSTRAINT [Relacion_21]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_37]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORMACION_SEGUIMIENTO]'))
ALTER TABLE [dbo].[INFORMACION_SEGUIMIENTO] DROP CONSTRAINT [Relacion_37]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_INFORMACION_SEGUIMIENTO_TIPO_SEGUIMIENTO]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[INFORMACION_SEGUIMIENTO] DROP CONSTRAINT [DF_INFORMACION_SEGUIMIENTO_TIPO_SEGUIMIENTO]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INFORMACION_SEGUIMIENTO]') AND type in (N'U'))
DROP TABLE [dbo].[INFORMACION_SEGUIMIENTO]
GO
/****** Object:  Table [dbo].[LINEA_BASE_DETALLE]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LINEA_BASE_DETALLE_ELEMENTO_CONFIGURACION]') AND parent_object_id = OBJECT_ID(N'[dbo].[LINEA_BASE_DETALLE]'))
ALTER TABLE [dbo].[LINEA_BASE_DETALLE] DROP CONSTRAINT [FK_LINEA_BASE_DETALLE_ELEMENTO_CONFIGURACION]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LINEA_BASE_DETALLE_LINEA_BASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[LINEA_BASE_DETALLE]'))
ALTER TABLE [dbo].[LINEA_BASE_DETALLE] DROP CONSTRAINT [FK_LINEA_BASE_DETALLE_LINEA_BASE]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__LINEA_BAS__ROWGU__531856C7]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[LINEA_BASE_DETALLE] DROP CONSTRAINT [DF__LINEA_BAS__ROWGU__531856C7]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LINEA_BASE_DETALLE]') AND type in (N'U'))
DROP TABLE [dbo].[LINEA_BASE_DETALLE]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_ELIMINAR_HALLAZGO]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_ELIMINAR_HALLAZGO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_ELIMINAR_HALLAZGO]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_INSERTAR_HALLAZGO]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_INSERTAR_HALLAZGO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_INSERTAR_HALLAZGO]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_HALLAZGOS_POR_ANIO]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_LISTAR_HALLAZGOS_POR_ANIO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_LISTAR_HALLAZGOS_POR_ANIO]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_MATRIZ_ENTIDAD_AUDITADA]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_LISTAR_MATRIZ_ENTIDAD_AUDITADA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_LISTAR_MATRIZ_ENTIDAD_AUDITADA]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_MODIFICAR_HALLAZGO]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_MODIFICAR_HALLAZGO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_MODIFICAR_HALLAZGO]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_MODIFICAR_HALLAZGO_SEGUIMIENTO]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_MODIFICAR_HALLAZGO_SEGUIMIENTO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_MODIFICAR_HALLAZGO_SEGUIMIENTO]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_CHECKLIST]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_CHECKLIST]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_OBTENER_CHECKLIST]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_HALLAZGO]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_HALLAZGO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_OBTENER_HALLAZGO]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_HALLAZGOS_SEGUIMIENTO]    Script Date: 03/23/2013 16:50:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_HALLAZGOS_SEGUIMIENTO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_OBTENER_HALLAZGOS_SEGUIMIENTO]
GO
/****** Object:  StoredProcedure [dbo].[usp_Equipo_ListaEquiposPSSNivelEmpleado]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Equipo_ListaEquiposPSSNivelEmpleado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Equipo_ListaEquiposPSSNivelEmpleado]
GO
/****** Object:  StoredProcedure [dbo].[USP_FASE_PROYECTO_SEL_CODIGO_PROYECTO]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_FASE_PROYECTO_SEL_CODIGO_PROYECTO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_FASE_PROYECTO_SEL_CODIGO_PROYECTO]
GO
/****** Object:  Table [dbo].[TICKET]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_12]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET] DROP CONSTRAINT [Relacion_12]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_40]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET] DROP CONSTRAINT [Relacion_40]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_41]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET] DROP CONSTRAINT [Relacion_41]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_43]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET] DROP CONSTRAINT [Relacion_43]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_44]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET] DROP CONSTRAINT [Relacion_44]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TICKET_ULTIMA_SECUENCIA_SEGUMIENTO_TICKET]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TICKET] DROP CONSTRAINT [DF_TICKET_ULTIMA_SECUENCIA_SEGUMIENTO_TICKET]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TICKET_ULTIMA_SECUENCIA_ADICIONAL_TICKET]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TICKET] DROP CONSTRAINT [DF_TICKET_ULTIMA_SECUENCIA_ADICIONAL_TICKET]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TICKET]') AND type in (N'U'))
DROP TABLE [dbo].[TICKET]
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_INS]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_INS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_LINEA_BASE_INS]
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_SEL_CODIGO]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_SEL_CODIGO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_LINEA_BASE_SEL_CODIGO]
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_SEL_CODIGO_PROYECTO]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_SEL_CODIGO_PROYECTO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_LINEA_BASE_SEL_CODIGO_PROYECTO]
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_SEL_CODIGO_PROYECTO_FASE]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_SEL_CODIGO_PROYECTO_FASE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_LINEA_BASE_SEL_CODIGO_PROYECTO_FASE]
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_UPD]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_UPD]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_LINEA_BASE_UPD]
GO
/****** Object:  StoredProcedure [dbo].[USP_LISTA_PROYECTO_FASE]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LISTA_PROYECTO_FASE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_LISTA_PROYECTO_FASE]
GO
/****** Object:  StoredProcedure [dbo].[usp_Servicio_ListaServiciosSedeEquipo]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Servicio_ListaServiciosSedeEquipo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Servicio_ListaServiciosSedeEquipo]
GO
/****** Object:  StoredProcedure [dbo].[usp_Servicio_ListaServiciosUsuarioCliente]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Servicio_ListaServiciosUsuarioCliente]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Servicio_ListaServiciosUsuarioCliente]
GO
/****** Object:  StoredProcedure [dbo].[USP_USUARIO_PROYECTO]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_USUARIO_PROYECTO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_USUARIO_PROYECTO]
GO
/****** Object:  StoredProcedure [dbo].[USP_USUARIO_SEL_CODIGO_PROYECTO]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_USUARIO_SEL_CODIGO_PROYECTO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_USUARIO_SEL_CODIGO_PROYECTO]
GO
/****** Object:  StoredProcedure [dbo].[USP_PROYECTO_SEL_CODIGO_USUARIO]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_PROYECTO_SEL_CODIGO_USUARIO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_PROYECTO_SEL_CODIGO_USUARIO]
GO
/****** Object:  StoredProcedure [dbo].[usp_Proyecto_Servicio_Sede]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Proyecto_Servicio_Sede]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Proyecto_Servicio_Sede]
GO
/****** Object:  StoredProcedure [dbo].[USP_PROYECO_FASE_COD_PROYECTO_FASE]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_PROYECO_FASE_COD_PROYECTO_FASE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_PROYECO_FASE_COD_PROYECTO_FASE]
GO
/****** Object:  StoredProcedure [dbo].[usp_Proyecto_ListaSedes]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Proyecto_ListaSedes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Proyecto_ListaSedes]
GO
/****** Object:  StoredProcedure [dbo].[usp_CMDB_ListaCompleta]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CMDB_ListaCompleta]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_CMDB_ListaCompleta]
GO
/****** Object:  Table [dbo].[PLAN_DESPLIEGUE]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PLAN_DESPLIEGUE_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PLAN_DESPLIEGUE]'))
ALTER TABLE [dbo].[PLAN_DESPLIEGUE] DROP CONSTRAINT [FK_PLAN_DESPLIEGUE_EMPLEADO]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PLAN_DESPLIEGUE_SOLUCION_MEJORA1]') AND parent_object_id = OBJECT_ID(N'[dbo].[PLAN_DESPLIEGUE]'))
ALTER TABLE [dbo].[PLAN_DESPLIEGUE] DROP CONSTRAINT [FK_PLAN_DESPLIEGUE_SOLUCION_MEJORA1]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLAN_DESPLIEGUE]') AND type in (N'U'))
DROP TABLE [dbo].[PLAN_DESPLIEGUE]
GO
/****** Object:  Table [dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_16]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO] DROP CONSTRAINT [Relacion_16]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_17]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO] DROP CONSTRAINT [Relacion_17]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PROYECTO_SERVICIO_SEDE_EQUIPO_ESTADO_PSSE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO] DROP CONSTRAINT [DF_PROYECTO_SERVICIO_SEDE_EQUIPO_ESTADO_PSSE]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO]') AND type in (N'U'))
DROP TABLE [dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_AUDITORIA]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_AUDITORIA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_OBTENER_AUDITORIA]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_MODIFICAR_PREGUNTA_VERIFICACION]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_MODIFICAR_PREGUNTA_VERIFICACION]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_MODIFICAR_PREGUNTA_VERIFICACION]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC2]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC2]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC2]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC3]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC3]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC3]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_ACTIVIDADES_POR_AUDITORIA]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_LISTAR_ACTIVIDADES_POR_AUDITORIA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_LISTAR_ACTIVIDADES_POR_AUDITORIA]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_AUDITORES_POR_AUDITORIA]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_LISTAR_AUDITORES_POR_AUDITORIA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_LISTAR_AUDITORES_POR_AUDITORIA]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_INSERTAR_ACTIVIDAD]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_INSERTAR_ACTIVIDAD]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_INSERTAR_ACTIVIDAD]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_INSERTAR_AUDITOR]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_INSERTAR_AUDITOR]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_INSERTAR_AUDITOR]
GO
/****** Object:  Table [dbo].[ACCIONES_SOLUCION]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ACCIONES_SOLUCION_SOLUCION_MEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[ACCIONES_SOLUCION]'))
ALTER TABLE [dbo].[ACCIONES_SOLUCION] DROP CONSTRAINT [FK_ACCIONES_SOLUCION_SOLUCION_MEJORA]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACCIONES_SOLUCION]') AND type in (N'U'))
DROP TABLE [dbo].[ACCIONES_SOLUCION]
GO
/****** Object:  StoredProcedure [dbo].[ACP_ELIMINAR_ACTIVIDADES_X_AUDITORIA]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_ELIMINAR_ACTIVIDADES_X_AUDITORIA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_ELIMINAR_ACTIVIDADES_X_AUDITORIA]
GO
/****** Object:  StoredProcedure [dbo].[ACP_ELIMINAR_AUDITORES_X_AUDITORIA]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_ELIMINAR_AUDITORES_X_AUDITORIA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_ELIMINAR_AUDITORES_X_AUDITORIA]
GO
/****** Object:  Table [dbo].[AC_CALIFICACION_AUDITOR]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_CALIFICACION_AUDITOR_AC_AUDITOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_CALIFICACION_AUDITOR]'))
ALTER TABLE [dbo].[AC_CALIFICACION_AUDITOR] DROP CONSTRAINT [FK_AC_CALIFICACION_AUDITOR_AC_AUDITOR]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_CALIFICACION_AUDITOR_AC_PREGUNTA_CALIFICACION]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_CALIFICACION_AUDITOR]'))
ALTER TABLE [dbo].[AC_CALIFICACION_AUDITOR] DROP CONSTRAINT [FK_AC_CALIFICACION_AUDITOR_AC_PREGUNTA_CALIFICACION]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_CALIFICACION_AUDITOR]') AND type in (N'U'))
DROP TABLE [dbo].[AC_CALIFICACION_AUDITOR]
GO
/****** Object:  Table [dbo].[AC_HALLAZGO]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_HALLAZGO_AC_PREGUNTA_VERIFICACION]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_HALLAZGO]'))
ALTER TABLE [dbo].[AC_HALLAZGO] DROP CONSTRAINT [FK_AC_HALLAZGO_AC_PREGUNTA_VERIFICACION]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_HALLAZGO]') AND type in (N'U'))
DROP TABLE [dbo].[AC_HALLAZGO]
GO
/****** Object:  Table [dbo].[LINEA_BASE]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LINEA_BASE_PROYECTO_FASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[LINEA_BASE]'))
ALTER TABLE [dbo].[LINEA_BASE] DROP CONSTRAINT [FK_LINEA_BASE_PROYECTO_FASE]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LINEA_BASE]') AND type in (N'U'))
DROP TABLE [dbo].[LINEA_BASE]
GO
/****** Object:  Table [dbo].[ESTADO_SOLUCION]    Script Date: 03/23/2013 16:50:52 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESTADO_SOLUCION_ESTADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESTADO_SOLUCION]'))
ALTER TABLE [dbo].[ESTADO_SOLUCION] DROP CONSTRAINT [FK_ESTADO_SOLUCION_ESTADO]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESTADO_SOLUCION_SOLUCION_MEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESTADO_SOLUCION]'))
ALTER TABLE [dbo].[ESTADO_SOLUCION] DROP CONSTRAINT [FK_ESTADO_SOLUCION_SOLUCION_MEJORA]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ESTADO_SOLUCION]') AND type in (N'U'))
DROP TABLE [dbo].[ESTADO_SOLUCION]
GO
/****** Object:  Table [dbo].[AC_EVALUACION_AUDITORIA]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_EVALUACION_AUDITORIA_AC_AUDITADOS]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_EVALUACION_AUDITORIA]'))
ALTER TABLE [dbo].[AC_EVALUACION_AUDITORIA] DROP CONSTRAINT [FK_AC_EVALUACION_AUDITORIA_AC_AUDITADOS]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_EVALUACION_AUDITORIA_AC_PREGUNTA_EVALUACION]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_EVALUACION_AUDITORIA]'))
ALTER TABLE [dbo].[AC_EVALUACION_AUDITORIA] DROP CONSTRAINT [FK_AC_EVALUACION_AUDITORIA_AC_PREGUNTA_EVALUACION]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_EVALUACION_AUDITORIA]') AND type in (N'U'))
DROP TABLE [dbo].[AC_EVALUACION_AUDITORIA]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC1]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC1]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC1]
GO
/****** Object:  Table [dbo].[ESTADO_PILOTO]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESTADO_PILOTO_ESTADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESTADO_PILOTO]'))
ALTER TABLE [dbo].[ESTADO_PILOTO] DROP CONSTRAINT [FK_ESTADO_PILOTO_ESTADO]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESTADO_PILOTO_PILOTO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESTADO_PILOTO]'))
ALTER TABLE [dbo].[ESTADO_PILOTO] DROP CONSTRAINT [FK_ESTADO_PILOTO_PILOTO]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ESTADO_PILOTO]') AND type in (N'U'))
DROP TABLE [dbo].[ESTADO_PILOTO]
GO
/****** Object:  Table [dbo].[OBSERVACIONES_PILOTO]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OBSERVACIONES_PILOTO_PILOTO]') AND parent_object_id = OBJECT_ID(N'[dbo].[OBSERVACIONES_PILOTO]'))
ALTER TABLE [dbo].[OBSERVACIONES_PILOTO] DROP CONSTRAINT [FK_OBSERVACIONES_PILOTO_PILOTO]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OBSERVACIONES_PILOTO]') AND type in (N'U'))
DROP TABLE [dbo].[OBSERVACIONES_PILOTO]
GO
/****** Object:  Table [dbo].[PROPUESTA_ESTADO]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_ESTADO_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_ESTADO]'))
ALTER TABLE [dbo].[PROPUESTA_ESTADO] DROP CONSTRAINT [FK_PROPUESTA_ESTADO_EMPLEADO]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_ESTADO_ESTADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_ESTADO]'))
ALTER TABLE [dbo].[PROPUESTA_ESTADO] DROP CONSTRAINT [FK_PROPUESTA_ESTADO_ESTADO]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_ESTADO_PROPUESTAMEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_ESTADO]'))
ALTER TABLE [dbo].[PROPUESTA_ESTADO] DROP CONSTRAINT [FK_PROPUESTA_ESTADO_PROPUESTAMEJORA]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROPUESTA_ESTADO]') AND type in (N'U'))
DROP TABLE [dbo].[PROPUESTA_ESTADO]
GO
/****** Object:  Table [dbo].[PROPUESTA_INDICADOR]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_INDICADOR_INDICADOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_INDICADOR]'))
ALTER TABLE [dbo].[PROPUESTA_INDICADOR] DROP CONSTRAINT [FK_PROPUESTA_INDICADOR_INDICADOR]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_INDICADOR_PROPUESTAMEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_INDICADOR]'))
ALTER TABLE [dbo].[PROPUESTA_INDICADOR] DROP CONSTRAINT [FK_PROPUESTA_INDICADOR_PROPUESTAMEJORA]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PROPUESTA_INDICADOR_SELECCIONADO]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PROPUESTA_INDICADOR] DROP CONSTRAINT [DF_PROPUESTA_INDICADOR_SELECCIONADO]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROPUESTA_INDICADOR]') AND type in (N'U'))
DROP TABLE [dbo].[PROPUESTA_INDICADOR]
GO
/****** Object:  Table [dbo].[AC_AUDITOR]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_AUDITOR_AC_AUDITORIA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_AUDITOR]'))
ALTER TABLE [dbo].[AC_AUDITOR] DROP CONSTRAINT [FK_AC_AUDITOR_AC_AUDITORIA]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_AUDITOR]') AND type in (N'U'))
DROP TABLE [dbo].[AC_AUDITOR]
GO
/****** Object:  Table [dbo].[AC_ACTIVIDAD]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_ACTIVIDAD_AC_AUDITORIA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_ACTIVIDAD]'))
ALTER TABLE [dbo].[AC_ACTIVIDAD] DROP CONSTRAINT [FK_AC_ACTIVIDAD_AC_AUDITORIA]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_ACTIVIDAD]') AND type in (N'U'))
DROP TABLE [dbo].[AC_ACTIVIDAD]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_INSERTAR_AUDITORIA]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_INSERTAR_AUDITORIA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_INSERTAR_AUDITORIA]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_AUDITORIAS_POR_ANIO]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_LISTAR_AUDITORIAS_POR_ANIO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_LISTAR_AUDITORIAS_POR_ANIO]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_INSERTAR_PLAN_AUDITORIA]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_INSERTAR_PLAN_AUDITORIA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_INSERTAR_PLAN_AUDITORIA]
GO
/****** Object:  Table [dbo].[AC_PREGUNTA_VERIFICACION]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_PREGUNTA_VERIFICACION_AC_AUDITORIA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_PREGUNTA_VERIFICACION]'))
ALTER TABLE [dbo].[AC_PREGUNTA_VERIFICACION] DROP CONSTRAINT [FK_AC_PREGUNTA_VERIFICACION_AC_AUDITORIA]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_PREGUNTA_VERIFICACION]') AND type in (N'U'))
DROP TABLE [dbo].[AC_PREGUNTA_VERIFICACION]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_VALIDAR_AUDITORIA]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_VALIDAR_AUDITORIA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_VALIDAR_AUDITORIA]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_PLAN_AUDITORIAS]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_LISTAR_PLAN_AUDITORIAS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_LISTAR_PLAN_AUDITORIAS]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_PLAN_AUDITORIA_POR_ID]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_PLAN_AUDITORIA_POR_ID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_OBTENER_PLAN_AUDITORIA_POR_ID]
GO
/****** Object:  Table [dbo].[PROYECTO_USUARIO_CLIENTE]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_06]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_USUARIO_CLIENTE]'))
ALTER TABLE [dbo].[PROYECTO_USUARIO_CLIENTE] DROP CONSTRAINT [Relacion_06]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_07]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_USUARIO_CLIENTE]'))
ALTER TABLE [dbo].[PROYECTO_USUARIO_CLIENTE] DROP CONSTRAINT [Relacion_07]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROYECTO_USUARIO_CLIENTE]') AND type in (N'U'))
DROP TABLE [dbo].[PROYECTO_USUARIO_CLIENTE]
GO
/****** Object:  Table [dbo].[PROYECTO_CMDB]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_34]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_CMDB]'))
ALTER TABLE [dbo].[PROYECTO_CMDB] DROP CONSTRAINT [Relacion_34]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_35]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_CMDB]'))
ALTER TABLE [dbo].[PROYECTO_CMDB] DROP CONSTRAINT [Relacion_35]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROYECTO_CMDB]') AND type in (N'U'))
DROP TABLE [dbo].[PROYECTO_CMDB]
GO
/****** Object:  Table [dbo].[PROYECTO_FASE]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROYECTO_FASE_FASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_FASE]'))
ALTER TABLE [dbo].[PROYECTO_FASE] DROP CONSTRAINT [FK_PROYECTO_FASE_FASE]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROYECTO_FASE_Proyecto1]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_FASE]'))
ALTER TABLE [dbo].[PROYECTO_FASE] DROP CONSTRAINT [FK_PROYECTO_FASE_Proyecto1]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROYECTO_FASE]') AND type in (N'U'))
DROP TABLE [dbo].[PROYECTO_FASE]
GO
/****** Object:  Table [dbo].[PROYECTO_SERVICIO_SEDE]    Script Date: 03/23/2013 16:50:51 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_09]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE] DROP CONSTRAINT [Relacion_09]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_11]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE] DROP CONSTRAINT [Relacion_11]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_18]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE] DROP CONSTRAINT [Relacion_18]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_36]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE] DROP CONSTRAINT [Relacion_36]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE]') AND type in (N'U'))
DROP TABLE [dbo].[PROYECTO_SERVICIO_SEDE]
GO
/****** Object:  Table [dbo].[SOLUCION_MEJORA]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SOLUCION_MEJORA_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[SOLUCION_MEJORA]'))
ALTER TABLE [dbo].[SOLUCION_MEJORA] DROP CONSTRAINT [FK_SOLUCION_MEJORA_EMPLEADO]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SOLUCION_MEJORA_PROPUESTAMEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[SOLUCION_MEJORA]'))
ALTER TABLE [dbo].[SOLUCION_MEJORA] DROP CONSTRAINT [FK_SOLUCION_MEJORA_PROPUESTAMEJORA]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SOLUCION_MEJORA]') AND type in (N'U'))
DROP TABLE [dbo].[SOLUCION_MEJORA]
GO
/****** Object:  StoredProcedure [dbo].[USP_PROYECTO_SEL_CODIGO]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_PROYECTO_SEL_CODIGO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_PROYECTO_SEL_CODIGO]
GO
/****** Object:  StoredProcedure [dbo].[USP_LISTA_PROYECTO]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LISTA_PROYECTO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_LISTA_PROYECTO]
GO
/****** Object:  Table [dbo].[USUARIO_PROYECTO]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_USUARIO_PROYECTO_Proyecto]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO_PROYECTO]'))
ALTER TABLE [dbo].[USUARIO_PROYECTO] DROP CONSTRAINT [FK_USUARIO_PROYECTO_Proyecto]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_USUARIO_PROYECTO_USUARIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO_PROYECTO]'))
ALTER TABLE [dbo].[USUARIO_PROYECTO] DROP CONSTRAINT [FK_USUARIO_PROYECTO_USUARIO]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USUARIO_PROYECTO]') AND type in (N'U'))
DROP TABLE [dbo].[USUARIO_PROYECTO]
GO
/****** Object:  StoredProcedure [dbo].[USP_USUARIO_SEL_CODIGO_ROL]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_USUARIO_SEL_CODIGO_ROL]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_USUARIO_SEL_CODIGO_ROL]
GO
/****** Object:  StoredProcedure [dbo].[USP_USUARIO_SEL_LOGIN]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_USUARIO_SEL_LOGIN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_USUARIO_SEL_LOGIN]
GO
/****** Object:  StoredProcedure [dbo].[usp_UsuarioCliente_Datos]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_UsuarioCliente_Datos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_UsuarioCliente_Datos]
GO
/****** Object:  StoredProcedure [dbo].[USP_USUARIO_SEL_CODIGO]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_USUARIO_SEL_CODIGO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_USUARIO_SEL_CODIGO]
GO
/****** Object:  StoredProcedure [dbo].[USP_ELEMENTO_CONFI_SEL_CODIGO_FASE]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ELEMENTO_CONFI_SEL_CODIGO_FASE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_ELEMENTO_CONFI_SEL_CODIGO_FASE]
GO
/****** Object:  StoredProcedure [dbo].[USP_ELEMENTO_CONFIGURACION_INS]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ELEMENTO_CONFIGURACION_INS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[USP_ELEMENTO_CONFIGURACION_INS]
GO
/****** Object:  Table [dbo].[RESPUESTA_ENCUESTA]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_04]') AND parent_object_id = OBJECT_ID(N'[dbo].[RESPUESTA_ENCUESTA]'))
ALTER TABLE [dbo].[RESPUESTA_ENCUESTA] DROP CONSTRAINT [Relacion_04]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_42]') AND parent_object_id = OBJECT_ID(N'[dbo].[RESPUESTA_ENCUESTA]'))
ALTER TABLE [dbo].[RESPUESTA_ENCUESTA] DROP CONSTRAINT [Relacion_42]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RESPUESTA_ENCUESTA]') AND type in (N'U'))
DROP TABLE [dbo].[RESPUESTA_ENCUESTA]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_PROGRAMA_ANUAL_AUDITORIA]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_PROGRAMA_ANUAL_AUDITORIA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_OBTENER_PROGRAMA_ANUAL_AUDITORIA]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_CAPITULO]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_CAPITULO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_OBTENER_CAPITULO]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_EMPLEADO]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_EMPLEADO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_OBTENER_EMPLEADO]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_ENTIDAD_AUDITADA]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_ENTIDAD_AUDITADA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_OBTENER_ENTIDAD_AUDITADA]
GO
/****** Object:  Table [dbo].[AUDITORIA]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_AUDITORIA_AC_ENTIDAD_AUDITADA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AUDITORIA]'))
ALTER TABLE [dbo].[AUDITORIA] DROP CONSTRAINT [FK_AC_AUDITORIA_AC_ENTIDAD_AUDITADA]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_AUDITORIA_AC_PROGRAMA_AUDITORIA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AUDITORIA]'))
ALTER TABLE [dbo].[AUDITORIA] DROP CONSTRAINT [FK_AC_AUDITORIA_AC_PROGRAMA_AUDITORIA]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUDITORIA]') AND type in (N'U'))
DROP TABLE [dbo].[AUDITORIA]
GO
/****** Object:  Table [dbo].[AC_DET_PREGUNTA_BASE]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_DET_PREGUNTA_BASE_AC_CAPITULO]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_DET_PREGUNTA_BASE]'))
ALTER TABLE [dbo].[AC_DET_PREGUNTA_BASE] DROP CONSTRAINT [FK_AC_DET_PREGUNTA_BASE_AC_CAPITULO]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_DET_PREGUNTA_BASE_AC_PREGUNTA_BASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_DET_PREGUNTA_BASE]'))
ALTER TABLE [dbo].[AC_DET_PREGUNTA_BASE] DROP CONSTRAINT [FK_AC_DET_PREGUNTA_BASE_AC_PREGUNTA_BASE]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_DET_PREGUNTA_BASE]') AND type in (N'U'))
DROP TABLE [dbo].[AC_DET_PREGUNTA_BASE]
GO
/****** Object:  Table [dbo].[AC_AUDITADOS]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_AUDITADOS_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_AUDITADOS]'))
ALTER TABLE [dbo].[AC_AUDITADOS] DROP CONSTRAINT [FK_AC_AUDITADOS_EMPLEADO]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_AUDITADOS]') AND type in (N'U'))
DROP TABLE [dbo].[AC_AUDITADOS]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_EMPLEADOS]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_LISTAR_EMPLEADOS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_LISTAR_EMPLEADOS]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_EMPLEADOS_POR_AREA]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_LISTAR_EMPLEADOS_POR_AREA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_LISTAR_EMPLEADOS_POR_AREA]
GO
/****** Object:  Table [dbo].[PROPUESTAMEJORA]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTAMEJORA_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTAMEJORA]'))
ALTER TABLE [dbo].[PROPUESTAMEJORA] DROP CONSTRAINT [FK_PROPUESTAMEJORA_EMPLEADO]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTAMEJORA_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTAMEJORA]'))
ALTER TABLE [dbo].[PROPUESTAMEJORA] DROP CONSTRAINT [FK_PROPUESTAMEJORA_PROCESO]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROPUESTAMEJORA]') AND type in (N'U'))
DROP TABLE [dbo].[PROPUESTAMEJORA]
GO
/****** Object:  Table [dbo].[PROYECTO]    Script Date: 03/23/2013 16:50:50 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Proyecto_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO]'))
ALTER TABLE [dbo].[PROYECTO] DROP CONSTRAINT [FK_Proyecto_CLIENTE]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Proyecto_USUARIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO]'))
ALTER TABLE [dbo].[PROYECTO] DROP CONSTRAINT [FK_Proyecto_USUARIO]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_10]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO]'))
ALTER TABLE [dbo].[PROYECTO] DROP CONSTRAINT [Relacion_10]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROYECTO]') AND type in (N'U'))
DROP TABLE [dbo].[PROYECTO]
GO
/****** Object:  Table [dbo].[PERSONA]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PERSONA_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[dbo].[PERSONA]'))
ALTER TABLE [dbo].[PERSONA] DROP CONSTRAINT [FK_PERSONA_CLIENTE]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PERSONA_CLIENTE1]') AND parent_object_id = OBJECT_ID(N'[dbo].[PERSONA]'))
ALTER TABLE [dbo].[PERSONA] DROP CONSTRAINT [FK_PERSONA_CLIENTE1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PERSONA_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PERSONA]'))
ALTER TABLE [dbo].[PERSONA] DROP CONSTRAINT [FK_PERSONA_EMPLEADO]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PERSONA]') AND type in (N'U'))
DROP TABLE [dbo].[PERSONA]
GO
/****** Object:  Table [dbo].[PILOTO]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PILOTO_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PILOTO]'))
ALTER TABLE [dbo].[PILOTO] DROP CONSTRAINT [FK_PILOTO_EMPLEADO]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PILOTO]') AND type in (N'U'))
DROP TABLE [dbo].[PILOTO]
GO
/****** Object:  Table [dbo].[ESCALA_CUALITATIVO]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESCALA_CUALITATIVO_INDICADOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESCALA_CUALITATIVO]'))
ALTER TABLE [dbo].[ESCALA_CUALITATIVO] DROP CONSTRAINT [FK_ESCALA_CUALITATIVO_INDICADOR]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ESCALA_CUALITATIVO]') AND type in (N'U'))
DROP TABLE [dbo].[ESCALA_CUALITATIVO]
GO
/****** Object:  Table [dbo].[ESCALA_CUANTITATIVO]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESCALA_CUANTITATIVO_INDICADOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESCALA_CUANTITATIVO]'))
ALTER TABLE [dbo].[ESCALA_CUANTITATIVO] DROP CONSTRAINT [FK_ESCALA_CUANTITATIVO_INDICADOR]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ESCALA_CUANTITATIVO]') AND type in (N'U'))
DROP TABLE [dbo].[ESCALA_CUANTITATIVO]
GO
/****** Object:  Table [dbo].[INTEGRANTE]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_25]') AND parent_object_id = OBJECT_ID(N'[dbo].[INTEGRANTE]'))
ALTER TABLE [dbo].[INTEGRANTE] DROP CONSTRAINT [Relacion_25]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_27]') AND parent_object_id = OBJECT_ID(N'[dbo].[INTEGRANTE]'))
ALTER TABLE [dbo].[INTEGRANTE] DROP CONSTRAINT [Relacion_27]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INTEGRANTE]') AND type in (N'U'))
DROP TABLE [dbo].[INTEGRANTE]
GO
/****** Object:  Table [dbo].[ARTEFACTO_PROCESO]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ARTEFACTO_PROCESO_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ARTEFACTO_PROCESO]'))
ALTER TABLE [dbo].[ARTEFACTO_PROCESO] DROP CONSTRAINT [FK_ARTEFACTO_PROCESO_PROCESO]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ARTEFACTO_PROCESO]') AND type in (N'U'))
DROP TABLE [dbo].[ARTEFACTO_PROCESO]
GO
/****** Object:  Table [dbo].[DETALLE_SLA]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_13]') AND parent_object_id = OBJECT_ID(N'[dbo].[DETALLE_SLA]'))
ALTER TABLE [dbo].[DETALLE_SLA] DROP CONSTRAINT [Relacion_13]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DETALLE_SLA]') AND type in (N'U'))
DROP TABLE [dbo].[DETALLE_SLA]
GO
/****** Object:  Table [dbo].[DOCUMENTO]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_31]') AND parent_object_id = OBJECT_ID(N'[dbo].[DOCUMENTO]'))
ALTER TABLE [dbo].[DOCUMENTO] DROP CONSTRAINT [Relacion_31]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DOCUMENTO]') AND type in (N'U'))
DROP TABLE [dbo].[DOCUMENTO]
GO
/****** Object:  Table [dbo].[ELEMENTO_CONFIGURACION]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ELEMENTO_CONFIGURACION_FASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[ELEMENTO_CONFIGURACION]'))
ALTER TABLE [dbo].[ELEMENTO_CONFIGURACION] DROP CONSTRAINT [FK_ELEMENTO_CONFIGURACION_FASE]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ELEMENTO_CONFIGURACION]') AND type in (N'U'))
DROP TABLE [dbo].[ELEMENTO_CONFIGURACION]
GO
/****** Object:  Table [dbo].[EMPLEADO]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EMPLEADO_AC_AREA]') AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLEADO]'))
ALTER TABLE [dbo].[EMPLEADO] DROP CONSTRAINT [FK_EMPLEADO_AC_AREA]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EMPLEADO_AREA]') AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLEADO]'))
ALTER TABLE [dbo].[EMPLEADO] DROP CONSTRAINT [FK_EMPLEADO_AREA]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EMPLEADO_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLEADO]'))
ALTER TABLE [dbo].[EMPLEADO] DROP CONSTRAINT [FK_EMPLEADO_EMPLEADO]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EMPLEADO_PUESTO]') AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLEADO]'))
ALTER TABLE [dbo].[EMPLEADO] DROP CONSTRAINT [FK_EMPLEADO_PUESTO]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EMPLEADO]') AND type in (N'U'))
DROP TABLE [dbo].[EMPLEADO]
GO
/****** Object:  Table [dbo].[HARDWARE]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_29]') AND parent_object_id = OBJECT_ID(N'[dbo].[HARDWARE]'))
ALTER TABLE [dbo].[HARDWARE] DROP CONSTRAINT [Relacion_29]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HARDWARE]') AND type in (N'U'))
DROP TABLE [dbo].[HARDWARE]
GO
/****** Object:  Table [dbo].[INDICADOR]    Script Date: 03/23/2013 16:50:49 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_INDICADOR_INDICADOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[INDICADOR]'))
ALTER TABLE [dbo].[INDICADOR] DROP CONSTRAINT [FK_INDICADOR_INDICADOR]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_INDICADOR_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[INDICADOR]'))
ALTER TABLE [dbo].[INDICADOR] DROP CONSTRAINT [FK_INDICADOR_PROCESO]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INDICADOR]') AND type in (N'U'))
DROP TABLE [dbo].[INDICADOR]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_INSERTAR_PROGRAMA_ANUAL]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_INSERTAR_PROGRAMA_ANUAL]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_INSERTAR_PROGRAMA_ANUAL]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_ELIMINAR_ARCHIVO]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_ELIMINAR_ARCHIVO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_ELIMINAR_ARCHIVO]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_ELIMINAR_GRUPO_ARCHIVOS]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_ELIMINAR_GRUPO_ARCHIVOS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_ELIMINAR_GRUPO_ARCHIVOS]
GO
/****** Object:  Table [dbo].[AC_ENTIDAD_AUDITADA]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_ENTIDAD_AUDITADA_AC_AREA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_ENTIDAD_AUDITADA]'))
ALTER TABLE [dbo].[AC_ENTIDAD_AUDITADA] DROP CONSTRAINT [FK_AC_ENTIDAD_AUDITADA_AC_AREA]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_ENTIDAD_AUDITADA]') AND type in (N'U'))
DROP TABLE [dbo].[AC_ENTIDAD_AUDITADA]
GO
/****** Object:  Table [dbo].[AC_CAPITULO]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_CAPITULO_AC_NORMA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_CAPITULO]'))
ALTER TABLE [dbo].[AC_CAPITULO] DROP CONSTRAINT [FK_AC_CAPITULO_AC_NORMA]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_CAPITULO]') AND type in (N'U'))
DROP TABLE [dbo].[AC_CAPITULO]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_NORMA]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_NORMA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_OBTENER_NORMA]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_MODIFICAR_ARCHIVO]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_MODIFICAR_ARCHIVO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_MODIFICAR_ARCHIVO]
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_ARCHIVOS]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_ARCHIVOS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ACP_SP_OBTENER_ARCHIVOS]
GO
/****** Object:  Table [dbo].[PREGUNTA_ENCUESTA]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_01]') AND parent_object_id = OBJECT_ID(N'[dbo].[PREGUNTA_ENCUESTA]'))
ALTER TABLE [dbo].[PREGUNTA_ENCUESTA] DROP CONSTRAINT [Relacion_01]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_02]') AND parent_object_id = OBJECT_ID(N'[dbo].[PREGUNTA_ENCUESTA]'))
ALTER TABLE [dbo].[PREGUNTA_ENCUESTA] DROP CONSTRAINT [Relacion_02]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PREGUNTA_ENCUESTA]') AND type in (N'U'))
DROP TABLE [dbo].[PREGUNTA_ENCUESTA]
GO
/****** Object:  Table [dbo].[LECCION_APRENDIDA_PROCESO]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LECCION_APRENDIDA_PROCESO (MP)_LECCIONES_APRENDIDAS_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[LECCION_APRENDIDA_PROCESO]'))
ALTER TABLE [dbo].[LECCION_APRENDIDA_PROCESO] DROP CONSTRAINT [FK_LECCION_APRENDIDA_PROCESO (MP)_LECCIONES_APRENDIDAS_PROCESO]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LECCION_APRENDIDA_PROCESO (MP)_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[LECCION_APRENDIDA_PROCESO]'))
ALTER TABLE [dbo].[LECCION_APRENDIDA_PROCESO] DROP CONSTRAINT [FK_LECCION_APRENDIDA_PROCESO (MP)_PROCESO]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LECCION_APRENDIDA_PROCESO]') AND type in (N'U'))
DROP TABLE [dbo].[LECCION_APRENDIDA_PROCESO]
GO
/****** Object:  Table [dbo].[SOFTWARE]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_30]') AND parent_object_id = OBJECT_ID(N'[dbo].[SOFTWARE]'))
ALTER TABLE [dbo].[SOFTWARE] DROP CONSTRAINT [Relacion_30]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SOFTWARE]') AND type in (N'U'))
DROP TABLE [dbo].[SOFTWARE]
GO
/****** Object:  StoredProcedure [dbo].[usp_CMDB_Datos]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CMDB_Datos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_CMDB_Datos]
GO
/****** Object:  StoredProcedure [dbo].[usp_Servicio_DatosServicio]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Servicio_DatosServicio]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Servicio_DatosServicio]
GO
/****** Object:  StoredProcedure [dbo].[usp_LeccionAprendida_BuscarLeccion]    Script Date: 03/23/2013 16:50:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_LeccionAprendida_BuscarLeccion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_LeccionAprendida_BuscarLeccion]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 03/23/2013 16:50:47 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_USUARIO_PERFIL_USUARIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO]'))
ALTER TABLE [dbo].[USUARIO] DROP CONSTRAINT [FK_USUARIO_PERFIL_USUARIO]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USUARIO]') AND type in (N'U'))
DROP TABLE [dbo].[USUARIO]
GO
/****** Object:  Table [dbo].[USUARIO_CLIENTE]    Script Date: 03/23/2013 16:50:47 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_05]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO_CLIENTE]'))
ALTER TABLE [dbo].[USUARIO_CLIENTE] DROP CONSTRAINT [Relacion_05]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_08]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO_CLIENTE]'))
ALTER TABLE [dbo].[USUARIO_CLIENTE] DROP CONSTRAINT [Relacion_08]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USUARIO_CLIENTE]') AND type in (N'U'))
DROP TABLE [dbo].[USUARIO_CLIENTE]
GO
/****** Object:  Table [dbo].[LECCIONES_APRENDIDAS_PROCESO]    Script Date: 03/23/2013 16:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LECCIONES_APRENDIDAS_PROCESO]') AND type in (N'U'))
DROP TABLE [dbo].[LECCIONES_APRENDIDAS_PROCESO]
GO
/****** Object:  Table [dbo].[UNIDAD]    Script Date: 03/23/2013 16:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UNIDAD]') AND type in (N'U'))
DROP TABLE [dbo].[UNIDAD]
GO
/****** Object:  Table [dbo].[PRIORIDAD]    Script Date: 03/23/2013 16:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRIORIDAD]') AND type in (N'U'))
DROP TABLE [dbo].[PRIORIDAD]
GO
/****** Object:  Table [dbo].[PROCESO]    Script Date: 03/23/2013 16:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROCESO]') AND type in (N'U'))
DROP TABLE [dbo].[PROCESO]
GO
/****** Object:  Table [dbo].[PUESTO]    Script Date: 03/23/2013 16:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PUESTO]') AND type in (N'U'))
DROP TABLE [dbo].[PUESTO]
GO
/****** Object:  Table [dbo].[SEDE]    Script Date: 03/23/2013 16:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SEDE]') AND type in (N'U'))
DROP TABLE [dbo].[SEDE]
GO
/****** Object:  Table [dbo].[SERVICIO]    Script Date: 03/23/2013 16:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SERVICIO]') AND type in (N'U'))
DROP TABLE [dbo].[SERVICIO]
GO
/****** Object:  Table [dbo].[SLA]    Script Date: 03/23/2013 16:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SLA]') AND type in (N'U'))
DROP TABLE [dbo].[SLA]
GO
/****** Object:  Table [dbo].[AREA]    Script Date: 03/23/2013 16:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AREA]') AND type in (N'U'))
DROP TABLE [dbo].[AREA]
GO
/****** Object:  Table [dbo].[BANCO_PREGUNTAS]    Script Date: 03/23/2013 16:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BANCO_PREGUNTAS]') AND type in (N'U'))
DROP TABLE [dbo].[BANCO_PREGUNTAS]
GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 03/23/2013 16:50:46 ******/
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_CLIENTE_TIPO_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[dbo].[CLIENTE]'))
ALTER TABLE [dbo].[CLIENTE] DROP CONSTRAINT [CK_CLIENTE_TIPO_CLIENTE]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CLIENTE]') AND type in (N'U'))
DROP TABLE [dbo].[CLIENTE]
GO
/****** Object:  Table [dbo].[CMDB]    Script Date: 03/23/2013 16:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMDB]') AND type in (N'U'))
DROP TABLE [dbo].[CMDB]
GO
/****** Object:  Table [dbo].[CUESTIONARIO_ENCUESTA]    Script Date: 03/23/2013 16:50:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CUESTIONARIO_ENCUESTA]') AND type in (N'U'))
DROP TABLE [dbo].[CUESTIONARIO_ENCUESTA]
GO
/****** Object:  Table [dbo].[AC_ARCHIVO]    Script Date: 03/23/2013 16:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_ARCHIVO]') AND type in (N'U'))
DROP TABLE [dbo].[AC_ARCHIVO]
GO
/****** Object:  Table [dbo].[AC_NORMA]    Script Date: 03/23/2013 16:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_NORMA]') AND type in (N'U'))
DROP TABLE [dbo].[AC_NORMA]
GO
/****** Object:  Table [dbo].[AC_PREGUNTA_BASE]    Script Date: 03/23/2013 16:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_PREGUNTA_BASE]') AND type in (N'U'))
DROP TABLE [dbo].[AC_PREGUNTA_BASE]
GO
/****** Object:  Table [dbo].[AC_PREGUNTA_CALIFICACION]    Script Date: 03/23/2013 16:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_PREGUNTA_CALIFICACION]') AND type in (N'U'))
DROP TABLE [dbo].[AC_PREGUNTA_CALIFICACION]
GO
/****** Object:  Table [dbo].[AC_PREGUNTA_EVALUACION]    Script Date: 03/23/2013 16:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_PREGUNTA_EVALUACION]') AND type in (N'U'))
DROP TABLE [dbo].[AC_PREGUNTA_EVALUACION]
GO
/****** Object:  Table [dbo].[AC_PROGRAMA_AUDITORIA]    Script Date: 03/23/2013 16:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_PROGRAMA_AUDITORIA]') AND type in (N'U'))
DROP TABLE [dbo].[AC_PROGRAMA_AUDITORIA]
GO
/****** Object:  Table [dbo].[INDICADOR_VALOR]    Script Date: 03/23/2013 16:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INDICADOR_VALOR]') AND type in (N'U'))
DROP TABLE [dbo].[INDICADOR_VALOR]
GO
/****** Object:  Table [dbo].[ORGANIZACION]    Script Date: 03/23/2013 16:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ORGANIZACION]') AND type in (N'U'))
DROP TABLE [dbo].[ORGANIZACION]
GO
/****** Object:  Table [dbo].[PERFIL_USUARIO]    Script Date: 03/23/2013 16:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PERFIL_USUARIO]') AND type in (N'U'))
DROP TABLE [dbo].[PERFIL_USUARIO]
GO
/****** Object:  Table [dbo].[EQUIPO]    Script Date: 03/23/2013 16:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EQUIPO]') AND type in (N'U'))
DROP TABLE [dbo].[EQUIPO]
GO
/****** Object:  Table [dbo].[ESTADO]    Script Date: 03/23/2013 16:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ESTADO]') AND type in (N'U'))
DROP TABLE [dbo].[ESTADO]
GO
/****** Object:  Table [dbo].[FASE]    Script Date: 03/23/2013 16:50:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FASE]') AND type in (N'U'))
DROP TABLE [dbo].[FASE]
GO
/****** Object:  Table [dbo].[LECCION_APRENDIDA]    Script Date: 03/23/2013 16:50:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LECCION_APRENDIDA]') AND type in (N'U'))
DROP TABLE [dbo].[LECCION_APRENDIDA]
GO
/****** Object:  Table [dbo].[LECCION_APRENDIDA]    Script Date: 03/23/2013 16:50:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LECCION_APRENDIDA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LECCION_APRENDIDA](
	[CODIGO_LECCION_APRENDIDA] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_LECCION_APRENDIDA] [varchar](50) NOT NULL,
	[AREA_LECCION_APRENDIDA] [varchar](40) NULL,
	[AUTOR_LECCION_APRENDIDA] [varchar](50) NOT NULL,
	[DESCRIPCION_LECCION_APRENDIDA] [varchar](1000) NOT NULL,
	[FECHA_REGISTRO_LECCION_APRENDIDA] [datetime] NOT NULL,
	[REVISOR1_LECCION_APRENDIDA] [varchar](50) NULL,
	[REVISOR2_LECCION_APRENDIDA] [varchar](50) NULL,
	[REVISOR3_LECCION_APRENDIDA] [varchar](50) NULL,
	[SUPUESTO_ORIGINAL_LECCION_APRENDIDA] [varchar](255) NOT NULL,
	[SUPUESTO_NUEVO_LECCION_APRENDIDA] [varchar](255) NULL,
	[EJEMPLO_LECCION_APRENDIDA] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_LECCION_APRENDIDA] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_LECCION_APRENDIDA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FASE]    Script Date: 03/23/2013 16:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FASE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FASE](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NULL,
 CONSTRAINT [PK__FASE__CC87E1277A09056A] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[FASE] ON
INSERT [dbo].[FASE] ([CODIGO], [NOMBRE]) VALUES (1, N'REQUERIMIENTO')
INSERT [dbo].[FASE] ([CODIGO], [NOMBRE]) VALUES (2, N'DISENO')
INSERT [dbo].[FASE] ([CODIGO], [NOMBRE]) VALUES (3, N'IMPLEMENTACION')
INSERT [dbo].[FASE] ([CODIGO], [NOMBRE]) VALUES (4, N'VERIFICACION')
INSERT [dbo].[FASE] ([CODIGO], [NOMBRE]) VALUES (5, N'DESPLIEGUE')
INSERT [dbo].[FASE] ([CODIGO], [NOMBRE]) VALUES (6, N'GESTION DE CONFIGURACION')
INSERT [dbo].[FASE] ([CODIGO], [NOMBRE]) VALUES (7, N'GESTION DE CALIDAD')
INSERT [dbo].[FASE] ([CODIGO], [NOMBRE]) VALUES (8, N'GESTION DE PROYECTO')
INSERT [dbo].[FASE] ([CODIGO], [NOMBRE]) VALUES (9, N'COMUNICACION')
SET IDENTITY_INSERT [dbo].[FASE] OFF
/****** Object:  Table [dbo].[ESTADO]    Script Date: 03/23/2013 16:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ESTADO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ESTADO](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[TIPO] [varchar](250) NULL,
	[NOMBRE] [varchar](250) NULL,
 CONSTRAINT [PK_ESTADO] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EQUIPO]    Script Date: 03/23/2013 16:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EQUIPO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EQUIPO](
	[CODIGO_EQUIPO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_EQUIPO] [varchar](50) NOT NULL,
	[DESCRIPCION_EQUIPO] [varchar](255) NULL,
	[NUMERO_INTEGRANTES_EQUIPO] [int] NOT NULL,
	[FECHA_CREACION_EQUIPO] [datetime] NOT NULL,
 CONSTRAINT [PK_EQUIPO] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_EQUIPO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PERFIL_USUARIO]    Script Date: 03/23/2013 16:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PERFIL_USUARIO]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ORGANIZACION]    Script Date: 03/23/2013 16:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ORGANIZACION]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ORGANIZACION](
	[CODIGO_ORGANIZACION] [varchar](5) NOT NULL,
	[NOMBRE] [varchar](100) NULL,
	[VISION] [varchar](255) NULL,
	[MISION] [varchar](255) NULL,
 CONSTRAINT [PK_ORGANIZACION] PRIMARY KEY CLUSTERED 
(
	[CODIGO_ORGANIZACION] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INDICADOR_VALOR]    Script Date: 03/23/2013 16:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INDICADOR_VALOR]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[INDICADOR_VALOR](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[FECHA] [datetime] NULL,
	[VALOR] [float] NULL,
	[CODIGO_INDICADOR] [int] NOT NULL,
 CONSTRAINT [PK_INDICADOR_VALOR] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AC_PROGRAMA_AUDITORIA]    Script Date: 03/23/2013 16:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_PROGRAMA_AUDITORIA]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AC_PREGUNTA_EVALUACION]    Script Date: 03/23/2013 16:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_PREGUNTA_EVALUACION]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AC_PREGUNTA_EVALUACION](
	[idPreguntaEvaluacion] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AC_PREGUNTA_EVALUACION] PRIMARY KEY CLUSTERED 
(
	[idPreguntaEvaluacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AC_PREGUNTA_CALIFICACION]    Script Date: 03/23/2013 16:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_PREGUNTA_CALIFICACION]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AC_PREGUNTA_CALIFICACION](
	[idPreguntaCalificacion] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AC_PREGUNTA_CALIFICACION] PRIMARY KEY CLUSTERED 
(
	[idPreguntaCalificacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AC_PREGUNTA_BASE]    Script Date: 03/23/2013 16:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_PREGUNTA_BASE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AC_PREGUNTA_BASE](
	[idPreguntaBase] [int] NOT NULL,
	[descripcion] [varchar](500) NOT NULL,
	[ereg] [char](1) NOT NULL,
	[freg] [datetime] NULL,
	[hreg] [varchar](8) NOT NULL,
	[ureg] [varchar](10) NOT NULL,
 CONSTRAINT [PK_AC_PREGUNTA_BASE] PRIMARY KEY CLUSTERED 
(
	[idPreguntaBase] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AC_NORMA]    Script Date: 03/23/2013 16:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_NORMA]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AC_ARCHIVO]    Script Date: 03/23/2013 16:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_ARCHIVO]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CUESTIONARIO_ENCUESTA]    Script Date: 03/23/2013 16:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CUESTIONARIO_ENCUESTA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CUESTIONARIO_ENCUESTA](
	[CODIGO_CUESTIONARIO_ENCUESTA] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION_CUESTIONARIO_ENCUESTA] [varchar](255) NULL,
	[FECHA_REGISTRO_CUESTIONARIO_ENCUESTA] [datetime] NOT NULL,
	[FECHA_INICIO_CUESTIONARIO_ENCUESTA] [datetime] NOT NULL,
	[FECHA_CIERRE_CUESTIONARIO_ENCUESTA] [datetime] NOT NULL,
 CONSTRAINT [PK_CUESTIONARIO_ENCUESTA] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_CUESTIONARIO_ENCUESTA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CMDB]    Script Date: 03/23/2013 16:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMDB]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CMDB](
	[CODIGO_CMDB] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_CMDB] [varchar](50) NOT NULL,
	[DESCRIPCION_CMDB] [varchar](255) NULL,
 CONSTRAINT [PK_CMDB] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_CMDB] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 03/23/2013 16:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CLIENTE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CLIENTE](
	[CODIGO_CLIENTE] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NULL,
	[RUC] [char](11) NULL,
	[DIRECCION] [varchar](80) NULL,
	[TIPO_CLIENTE] [char](1) NULL,
	[RAZON_SOCIAL] [varchar](100) NULL,
	[ANEXO] [varchar](2) NULL,
	[FAX] [varchar](15) NULL,
 CONSTRAINT [PK__CLIENTE__CC87E12703317E3D] PRIMARY KEY CLUSTERED 
(
	[CODIGO_CLIENTE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BANCO_PREGUNTAS]    Script Date: 03/23/2013 16:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BANCO_PREGUNTAS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BANCO_PREGUNTAS](
	[CODIGO_BANCO_PREGUNTAS] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION_BANCO_PREGUNTAS] [varchar](30) NULL,
	[TIPO_PREGUNTA_BANCO_PREGUNTAS] [varchar](15) NOT NULL,
	[PREGUNTA_BANCO_PREGUNTAS] [varchar](255) NOT NULL,
	[TIPO_ALTERNATIVA_BANCO_PREGUNTAS] [varchar](15) NULL,
	[ALTERNATIVA_BANCO_PREGUNTAS] [varchar](255) NULL,
	[FECHA_REGISTRO_BANCO_PREGUNTAS] [datetime] NOT NULL,
 CONSTRAINT [PK_BANCO_PREGUNTAS] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_BANCO_PREGUNTAS] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AREA]    Script Date: 03/23/2013 16:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AREA]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SLA]    Script Date: 03/23/2013 16:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SLA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SLA](
	[CODIGO_SLA] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_SLA] [varchar](50) NOT NULL,
	[DESCRIPCION_SLA] [varchar](50) NULL,
	[FECHA_CREACION_SLA] [datetime] NOT NULL,
	[FECHA_ACTIVACION_SLA] [datetime] NOT NULL,
 CONSTRAINT [PK_SLA] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_SLA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SERVICIO]    Script Date: 03/23/2013 16:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SERVICIO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SERVICIO](
	[CODIGO_SERVICIO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_SERVICIO] [varchar](50) NOT NULL,
	[DESCRIPCION_SERVICIO] [varchar](255) NULL,
	[FECHA_INICIO_SERVICIO] [datetime] NOT NULL,
	[FECHA_CIERRE_SERVICIO] [datetime] NOT NULL,
	[FECHA_ACTIVACION_SERVICIO] [datetime] NOT NULL,
	[MONTO_SERVICIO] [numeric](15, 2) NOT NULL,
 CONSTRAINT [PK_SERVICIO] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_SERVICIO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SEDE]    Script Date: 03/23/2013 16:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SEDE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SEDE](
	[CODIGO_SEDE] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_SEDE] [varchar](50) NOT NULL,
	[DIRECCION_SEDE] [varchar](50) NOT NULL,
	[TELEFONO_SEDE] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SEDE] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_SEDE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PUESTO]    Script Date: 03/23/2013 16:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PUESTO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PUESTO](
	[CODIGO_PUESTO] [int] NOT NULL,
	[DESCRIPCION] [varchar](100) NULL,
 CONSTRAINT [PK_PUESTO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PUESTO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PROCESO]    Script Date: 03/23/2013 16:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROCESO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PROCESO](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_AREA] [varchar](5) NOT NULL,
	[NOMBRE] [varchar](1000) NULL,
	[OBJETIVO] [varchar](4000) NULL,
	[ALCANCE] [varchar](4000) NULL,
 CONSTRAINT [PK_PROCESO] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PRIORIDAD]    Script Date: 03/23/2013 16:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRIORIDAD]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PRIORIDAD](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UNIDAD]    Script Date: 03/23/2013 16:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UNIDAD]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UNIDAD](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[MEDIDA] [varchar](50) NULL,
	[DESCRIPCION] [varchar](250) NULL,
 CONSTRAINT [PK_UNIDAD] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LECCIONES_APRENDIDAS_PROCESO]    Script Date: 03/23/2013 16:50:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LECCIONES_APRENDIDAS_PROCESO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LECCIONES_APRENDIDAS_PROCESO](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_PROCESO] [int] NULL,
	[ORIGEN] [varchar](100) NULL,
	[FECHA] [datetime] NULL,
	[LINEA_GRUPO] [varchar](100) NULL,
	[TIPO_LECCION] [varchar](100) NULL,
	[TEMA] [varchar](100) NULL,
	[CAUSA] [varchar](100) NULL,
	[DESCRIPCION] [varchar](100) NULL,
	[ACCIONES] [varchar](100) NULL,
	[BENEFICIOS] [varchar](100) NULL,
 CONSTRAINT [PK_LECCIONES_APRENDIDAS_PROCESO] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USUARIO_CLIENTE]    Script Date: 03/23/2013 16:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USUARIO_CLIENTE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[USUARIO_CLIENTE](
	[CODIGO_CLIENTE] [int] NOT NULL,
	[CODIGO_USUARIO_CLIENTE] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_USUARIO_CLIENTE] [varchar](50) NOT NULL,
	[ALIAS_USUARIO_CLIENTE] [varchar](20) NOT NULL,
	[NIVEL_USUARIO_CLIENTE] [varchar](50) NOT NULL,
	[FECHA_NACIMIENTO_USUARIO_CLIENTE] [datetime] NOT NULL,
	[CORREO_USUARIO_CLIENTE] [varchar](40) NOT NULL,
	[CARGO_USUARIO_CLIENTE] [varchar](40) NOT NULL,
	[AREA_USUARIO_CLIENTE] [varchar](50) NOT NULL,
	[TELEFONO_USUARIO_CLIENTE] [varchar](15) NOT NULL,
	[CODIGO_SEDE] [int] NOT NULL,
 CONSTRAINT [PK_USUARIO_CLIENTE] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_USUARIO_CLIENTE] ASC,
	[CODIGO_CLIENTE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 03/23/2013 16:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USUARIO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[USUARIO](
	[CODIGO_USUARIO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NULL,
	[CODIGO_AREA] [int] NULL,
	[ROL] [char](2) NULL,
	[LOGIN] [varchar](10) NULL,
	[CONTRASENIA] [varchar](50) NULL,
	[ESTADO] [nchar](10) NULL,
	[CODIGO_PERFIL_USUARIO] [int] NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_USUARIO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[USUARIO] ON
INSERT [dbo].[USUARIO] ([CODIGO_USUARIO], [NOMBRE], [CODIGO_AREA], [ROL], [LOGIN], [CONTRASENIA], [ESTADO], [CODIGO_PERFIL_USUARIO]) VALUES (1, N'ALEX ALDAZABAL', 1, N'GR', N'aaldazabal', NULL, NULL, NULL)
INSERT [dbo].[USUARIO] ([CODIGO_USUARIO], [NOMBRE], [CODIGO_AREA], [ROL], [LOGIN], [CONTRASENIA], [ESTADO], [CODIGO_PERFIL_USUARIO]) VALUES (2, N'ALONSO CARDENAS', 1, N'GC', N'acardenas', NULL, NULL, NULL)
INSERT [dbo].[USUARIO] ([CODIGO_USUARIO], [NOMBRE], [CODIGO_AREA], [ROL], [LOGIN], [CONTRASENIA], [ESTADO], [CODIGO_PERFIL_USUARIO]) VALUES (3, N'CARLOS PERALTA', 1, N'JP', N'cperalta', NULL, NULL, NULL)
INSERT [dbo].[USUARIO] ([CODIGO_USUARIO], [NOMBRE], [CODIGO_AREA], [ROL], [LOGIN], [CONTRASENIA], [ESTADO], [CODIGO_PERFIL_USUARIO]) VALUES (4, N'EDWIN LOPEZ', 2, N'RC', N'elopez', NULL, NULL, NULL)
INSERT [dbo].[USUARIO] ([CODIGO_USUARIO], [NOMBRE], [CODIGO_AREA], [ROL], [LOGIN], [CONTRASENIA], [ESTADO], [CODIGO_PERFIL_USUARIO]) VALUES (5, N'KEVIN VEGA', 2, N'RE', N'kvega', NULL, NULL, NULL)
INSERT [dbo].[USUARIO] ([CODIGO_USUARIO], [NOMBRE], [CODIGO_AREA], [ROL], [LOGIN], [CONTRASENIA], [ESTADO], [CODIGO_PERFIL_USUARIO]) VALUES (6, N'LOURDES LACRUZ', 2, N'RE', N'llacruz', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[USUARIO] OFF
/****** Object:  StoredProcedure [dbo].[usp_LeccionAprendida_BuscarLeccion]    Script Date: 03/23/2013 16:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_LeccionAprendida_BuscarLeccion]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_LeccionAprendida_BuscarLeccion]
	@TEXTO	varchar(100)
AS
	DECLARE @RETCODE_PROCESO int;
	IF
		@TEXTO	IS NULL
	BEGIN
		RETURN 255
	END
	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;
	SELECT A.CODIGO_LECCION_APRENDIDA, A.NOMBRE_LECCION_APRENDIDA, A.DESCRIPCION_LECCION_APRENDIDA, A.AREA_LECCION_APRENDIDA, A.EJEMPLO_LECCION_APRENDIDA
               FROM [dbo].[LECCION_APRENDIDA] AS A 
	WHERE A.DESCRIPCION_LECCION_APRENDIDA LIKE @TEXTO
	ORDER BY A.AREA_LECCION_APRENDIDA, A.CODIGO_LECCION_APRENDIDA;
	IF (@@ERROR <>0)
		SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Servicio_DatosServicio]    Script Date: 03/23/2013 16:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Servicio_DatosServicio]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Servicio_DatosServicio]
	@SERVICIO	bigint
AS
	DECLARE @RETCODE_PROCESO int;
	IF
		@SERVICIO	IS NULL
	BEGIN
		RETURN (255);
	END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SELECT A.CODIGO_SERVICIO, A.NOMBRE_SERVICIO, A.DESCRIPCION_SERVICIO, A.FECHA_INICIO_SERVICIO,
               A.FECHA_CIERRE_SERVICIO, A.FECHA_ACTIVACION_SERVICIO, A.MONTO_SERVICIO 
               FROM [dbo].[SERVICIO] AS A
	WHERE A.CODIGO_SERVICIO = @SERVICIO;
	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CMDB_Datos]    Script Date: 03/23/2013 16:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CMDB_Datos]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_CMDB_Datos]
	@CMDB	bigint
AS
	DECLARE @RETCODE_PROCESO int;
	IF
		@CMDB	IS NULL
	BEGIN
		RETURN 255
	END
	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;
	SELECT A.CODIGO_CMDB, A.NOMBRE_CMDB, A.DESCRIPCION_CMDB
               FROM [dbo].[CMDB] AS A 
	WHERE A.CODIGO_CMDB = @CMDB;
	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  Table [dbo].[SOFTWARE]    Script Date: 03/23/2013 16:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SOFTWARE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SOFTWARE](
	[CODIGO_SOFTWARE] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_SOFTWARE] [varchar](50) NOT NULL,
	[VERSION_SOFTWARE] [varchar](50) NOT NULL,
	[FABRICANTE_SOFTWARE] [varchar](50) NOT NULL,
	[LICENCIA_SOFTWARE] [varchar](50) NOT NULL,
	[CODIGO_CMDB] [int] NULL,
 CONSTRAINT [PK_SOFTWARE] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_SOFTWARE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LECCION_APRENDIDA_PROCESO]    Script Date: 03/23/2013 16:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LECCION_APRENDIDA_PROCESO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LECCION_APRENDIDA_PROCESO](
	[CODIGO_PROCESO] [int] NULL,
	[CODIGO_LECCION_APRENDIDA] [int] NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PREGUNTA_ENCUESTA]    Script Date: 03/23/2013 16:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PREGUNTA_ENCUESTA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PREGUNTA_ENCUESTA](
	[CODIGO_CUESTIONARIO_ENCUESTA] [int] NOT NULL,
	[ORDEN_PREGUNTA_ENCUESTA] [smallint] NOT NULL,
	[FECHA_REGISTRO_PREGUNTA_ENCUESTA] [datetime] NOT NULL,
	[CODIGO_BANCO_PREGUNTAS] [int] NOT NULL,
 CONSTRAINT [PK_PREGUNTA_ENCUESTA] PRIMARY KEY NONCLUSTERED 
(
	[ORDEN_PREGUNTA_ENCUESTA] ASC,
	[CODIGO_CUESTIONARIO_ENCUESTA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UN_PREGUNTA_ENCUESTA_01] UNIQUE NONCLUSTERED 
(
	[CODIGO_CUESTIONARIO_ENCUESTA] ASC,
	[CODIGO_BANCO_PREGUNTAS] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_ARCHIVOS]    Script Date: 03/23/2013 16:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_ARCHIVOS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_MODIFICAR_ARCHIVO]    Script Date: 03/23/2013 16:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_MODIFICAR_ARCHIVO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_NORMA]    Script Date: 03/23/2013 16:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_NORMA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
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
' 
END
GO
/****** Object:  Table [dbo].[AC_CAPITULO]    Script Date: 03/23/2013 16:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_CAPITULO]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AC_ENTIDAD_AUDITADA]    Script Date: 03/23/2013 16:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_ENTIDAD_AUDITADA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AC_ENTIDAD_AUDITADA](
	[idEntidadAuditada] [int] NOT NULL,
	[idArea] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[ereg] [char](1) NOT NULL,
	[tipoEntidad] [varchar](20) NOT NULL,
	[fecInicioProyecto] [datetime] NULL,
	[FecFinProyecto] [datetime] NULL,
	[porcentajeAvance] [numeric](9, 2) NOT NULL,
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_ELIMINAR_GRUPO_ARCHIVOS]    Script Date: 03/23/2013 16:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_ELIMINAR_GRUPO_ARCHIVOS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_ELIMINAR_ARCHIVO]    Script Date: 03/23/2013 16:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_ELIMINAR_ARCHIVO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_INSERTAR_PROGRAMA_ANUAL]    Script Date: 03/23/2013 16:50:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_INSERTAR_PROGRAMA_ANUAL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Carla Mier
-- Create date: 26/11/2012
-- Description:	Inserta un programa anual de auditoria
-- =============================================
CREATE PROCEDURE [dbo].[ACP_SP_INSERTAR_PROGRAMA_ANUAL] --2013,''CREADO'',''CMIER''
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
' 
END
GO
/****** Object:  Table [dbo].[INDICADOR]    Script Date: 03/23/2013 16:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INDICADOR]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[INDICADOR](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](250) NULL,
	[EXPRESION_MATEMATICA] [varchar](250) NULL,
	[FRECUENCIA_MEDICION] [varchar](250) NULL,
	[FUENTE_MEDICION] [varchar](250) NULL,
	[PLAZO] [varchar](250) NULL,
	[TIPO] [int] NULL,
	[CODIGO_PROCESO] [int] NULL,
	[REEMPLAZA_INDICADOR] [int] NULL,
	[ESTADO] [int] NULL,
 CONSTRAINT [PK_INDICADOR] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HARDWARE]    Script Date: 03/23/2013 16:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HARDWARE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[HARDWARE](
	[CODIGO_HARDWARE] [int] IDENTITY(1,1) NOT NULL,
	[MARCA_HARDWARE] [varchar](30) NOT NULL,
	[MODELO_HARDWARE] [varchar](30) NOT NULL,
	[SERIE_HARDWARE] [varchar](30) NOT NULL,
	[NUMERO_PARTE_HARDWARE] [varchar](30) NOT NULL,
	[DIMENSIONES_HARDWARE] [varchar](30) NULL,
	[CODIGO_CMDB] [int] NULL,
 CONSTRAINT [PK_HARDWARE] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_HARDWARE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMPLEADO]    Script Date: 03/23/2013 16:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EMPLEADO]') AND type in (N'U'))
BEGIN
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
	[CODIGO_PUESTO] [int] NULL,
 CONSTRAINT [PK_EMPLEADO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_EMPLEADO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ELEMENTO_CONFIGURACION]    Script Date: 03/23/2013 16:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ELEMENTO_CONFIGURACION]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ELEMENTO_CONFIGURACION](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NULL,
	[DESCRIPCION] [varchar](100) NULL,
	[TIPO] [varchar](2) NULL,
	[CODIGO_FASE] [int] NOT NULL,
 CONSTRAINT [PK__ELEMENTO__CC87E12707020F21] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ELEMENTO_CONFIGURACION] ON
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (1, N'RQACT', N'Acta de Reunion de Requeriminto', N'D', 1)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (2, N'RQDRQ', N'Especificacion de Requerimiento', N'D', 1)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (3, N'RQMOD', N'Modelo de Caso de Uso', N'D', 1)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (4, N'RQRSU', N'Requerimientos Suplementarios', N'D', 1)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (5, N'RQPIU', N'Pautas para Interfase de Usuario', N'D', 1)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (6, N'RQRCA', N'Requerimientos Candidatos', N'D', 1)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (7, N'RQALS', N'Alcance de Sistema', N'D', 1)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (8, N'RQGLO', N'GLosario', N'D', 1)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (9, N'RQOOMDO', N'Modelo de Negocio', N'D', 1)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (10, N'RQOODRP', N'Requerimientos para el Prototipo', N'D', 1)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (11, N'RQGXNOM', N'Nomenclatura', N'D', 1)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (12, N'DSMDI', N'Modelo de Diseño', N'D', 2)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (13, N'DSARQ', N'Descripción de la Arquitectura', N'D', 2)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (14, N'DSOOMDA', N'Modelo de Datos', N'D', 2)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (15, N'DSOODDP', N'Documento de Diseño del Prototipo', N'D', 2)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (16, N'IMEDT', N'Estándar de Documentación Técnica', N'D', 3)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (17, N'IMEI', N'Estándar de Implementación', N'D', 3)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (18, N'IMPR', N'Prototipo', N'D', 3)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (19, N'IMIIN', N'Informe de Integración', N'D', 3)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (20, N'IMDT', N'Documentación técnica', N'D', 3)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (21, N'IMIVU', N'Informe de Verificación Unitaria', N'D', 3)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (22, N'IMOOPII', N'Plan de Integración de la Iteración', N'D', 3)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (23, N'IMOOMIM', N'Modelo de Implementación', N'D', 3)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (24, N'IMOOEJI', N'Ejecutable de la Iteración', N'D', 3)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (25, N'IMOORRP', N'Reporte de Revisión por Pares', N'D', 3)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (26, N'IMOOCVU', N'Clases de la Verificación Unitaria de Módulo', N'D', 3)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (27, N'IMGXICO', N'Informe de Consolidación', N'D', 3)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (28, N'IMGXEST', N'BC Con Estilos', N'D', 3)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (29, N'IMGXCON', N'BC Consolidado', N'D', 3)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (30, N'IMGXNUC', N'BC Núcleo', N'D', 3)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (31, N'IMGXMOD', N'BC Módulo', N'D', 3)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (32, N'VRPVV', N'Plan de Verificación y Validación', N'D', 4)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (33, N'VRDAP', N'Documento de Evaluación y Ajuste del Plan de V & V', N'D', 4)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (34, N'VRPVI', N'Plan de Verificación de la Iteración', N'D', 4)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (35, N'VRMCP', N'Modelo de Casos de Prueba', N'D', 4)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (36, N'VRIVD', N'Informe de Verificación de Documento', N'D', 4)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (37, N'VRIVI', N'Informe de Verificación de Integración', N'D', 4)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (38, N'VRIVS', N'Informe de Verificación del Sistema', N'D', 4)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (39, N'VRRPR', N'Reportes de Pruebas', N'D', 4)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (40, N'VREV', N'Evaluación de la Verificación', N'D', 4)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (41, N'VRIFV', N'Informe Final de Verificación', N'D', 4)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (42, N'IPMSU', N'Materiales para Soporte al Usuario', N'D', 5)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (43, N'IPMCA', N'Materiales para Capacitación', N'D', 5)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (44, N'IPPS', N'Presentación del Sistema', N'D', 5)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (45, N'IPPLA', N'Plan de Implantación', N'D', 5)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (46, N'IPVPR', N'Versión del Producto', N'R', 5)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (47, N'IPOOEDU', N'Estándar de Documentación de Usuario', N'D', 5)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (48, N'IPOORFPA', N'Reporte Final de Pruebas de Aceptación', N'D', 5)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (49, N'SCMPLA', N'Plan de Configuración', N'D', 6)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (50, N'SCMMAC', N'Manejo del Ambiente Controlado', N'D', 6)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (51, N'SCMGC', N'Gestión de Cambios', N'D', 6)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (52, N'SCMRV', N'Registro de Versiones', N'D', 6)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (53, N'SCMILB', N'Informe de la Línea Base del Proyecto', N'D', 6)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (54, N'SCMIF', N'Informe Final de SCM', N'D', 6)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (55, N'SQAPLA', N'Plan de Calidad', N'D', 7)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (56, N'SQADAP', N'Documento de Evaluación y Ajuste del Plan de Calidad', N'D', 7)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (57, N'SQARTF', N'Informe de RTF', N'D', 7)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (58, N'SQAES', N'Entrega Semanal de SQA', N'D', 7)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (59, N'SQAIR', N'Informe de Revisión de SQA', N'D', 7)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (60, N'SQADV', N'Descripción de la Versión', N'D', 7)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (61, N'SQANV', N'Notas de la Versión', N'D', 7)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (62, N'SQAIF', N'Informe Final de SQA', N'D', 7)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (63, N'GPPLA', N'Plan de Proyecto', N'D', 8)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (64, N'GPISP', N'Informe de Situación del Proyecto', N'D', 8)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (65, N'GPEM', N'Estimaciones y Mediciones', N'D', 8)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (66, N'GPDRI', N'Documento de Riesgos', N'D', 8)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (67, N'GPRAC', N'Registro de Actividades', N'D', 8)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (68, N'GPIFP', N'Informe Final de Proyecto', N'D', 8)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (69, N'GPlidARE', N'Acta de la Reunión de Equipo', N'D', 8)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (70, N'GPPIT', N'Plan de la Iteración', N'D', 8)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (71, N'GPPDE', N'Plan de Desarrollo', N'D', 8)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (72, N'GPICF', N'Informe de Conclusiones de la Fase', N'D', 8)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (73, N'GPPDIP', N'Presentación en Diapositivas del Proyecto', N'D', 8)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (74, N'GPPDP', N'Presentación al Director del Proyecto', N'D', 8)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (75, N'GPARD', N'Acta de la Reunión con el Director del Proyecto', N'D', 8)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (76, N'GPOODAP', N'Documento de Evaluación y Ajuste al Plan de Proyecto', N'D', 8)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (77, N'GPIARI', N'Acta de la Reunión de Integración', N'D', 8)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (78, N'COMDI', N'Documento Informativo', N'D', 9)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (79, N'COMENS', N'Encuesta de Satisfacción del Cliente', N'D', 9)
INSERT [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO], [NOMBRE], [DESCRIPCION], [TIPO], [CODIGO_FASE]) VALUES (80, N'COMEVS', N'Evaluación de Satisfacción del Cliente', N'D', 9)
SET IDENTITY_INSERT [dbo].[ELEMENTO_CONFIGURACION] OFF
/****** Object:  Table [dbo].[DOCUMENTO]    Script Date: 03/23/2013 16:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DOCUMENTO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DOCUMENTO](
	[CODIGO_DOCUMENTO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_DOCUMENTO] [varchar](50) NOT NULL,
	[AREA_DOCUMENTO] [varchar](40) NULL,
	[CREADO_POR_DOCUMENTO] [varchar](50) NOT NULL,
	[FECHA_CREACION_DOCUMENTO] [datetime] NOT NULL,
	[MODIFICADO_POR_DOCUMENTO] [varchar](50) NULL,
	[FECHA_MODIFICACION_DOCUMENTO] [datetime] NULL,
	[TIPO_DOCUMENTO] [varchar](30) NOT NULL,
	[IMAGEN_DOCUMENTO] [varchar](1) NOT NULL,
	[CODIGO_CMDB] [int] NULL,
 CONSTRAINT [PK_DOCUMENTO] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_DOCUMENTO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DETALLE_SLA]    Script Date: 03/23/2013 16:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DETALLE_SLA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DETALLE_SLA](
	[CODIGO_SLA] [int] NOT NULL,
	[CODIGO_DETALLE_SLA] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_DETALLE_SLA] [varchar](50) NOT NULL,
	[DESCRIPCION_DETALLE_SLA] [varchar](255) NOT NULL,
	[URGENCIA_DETALLE_SLA] [smallint] NOT NULL,
	[IMPACTO_DETALLE_SLA] [smallint] NOT NULL,
	[COMPLEJIDAD_DETALLE_SLA] [smallint] NOT NULL,
	[TIEMPO_RESPUESTA_DETALLE_SLA] [bigint] NOT NULL,
	[TIEMPO_CIERRE_DETALLE_SLA] [bigint] NOT NULL,
 CONSTRAINT [PK_DETALLE_SLA] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_DETALLE_SLA] ASC,
	[CODIGO_SLA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ARTEFACTO_PROCESO]    Script Date: 03/23/2013 16:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ARTEFACTO_PROCESO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ARTEFACTO_PROCESO](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_PROCESO] [int] NULL,
	[ARCHIVO] [binary](50) NOT NULL,
 CONSTRAINT [PK_ARTEFACTO_PROCESO] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INTEGRANTE]    Script Date: 03/23/2013 16:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INTEGRANTE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[INTEGRANTE](
	[CODIGO_EQUIPO] [int] NOT NULL,
	[CODIGO_INTEGRANTE] [int] IDENTITY(1,1) NOT NULL,
	[NIVEL_INTEGRANTE] [varchar](50) NOT NULL,
	[FECHA_DESDE_INTEGRANTE] [datetime] NOT NULL,
	[FECHA_HASTA_INTEGRANTE] [datetime] NOT NULL,
	[CODIGO_EMPLEADO] [int] NULL,
 CONSTRAINT [PK_INTEGRANTE] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_INTEGRANTE] ASC,
	[CODIGO_EQUIPO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ESCALA_CUANTITATIVO]    Script Date: 03/23/2013 16:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ESCALA_CUANTITATIVO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ESCALA_CUANTITATIVO](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_INDICADOR] [int] NULL,
	[SIGNO] [varchar](50) NULL,
	[VALOR] [float] NULL,
	[CODIGO_UNIDAD] [int] NULL,
 CONSTRAINT [PK_ESCALA_CUANTITATIVO] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ESCALA_CUALITATIVO]    Script Date: 03/23/2013 16:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ESCALA_CUALITATIVO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ESCALA_CUALITATIVO](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_INDICADOR] [int] NOT NULL,
	[LIMITE_INFERIOR] [float] NULL,
	[LIMITE_SUPERIOR] [float] NULL,
	[CALIFICACION] [varchar](250) NULL,
	[PRINCIPAL] [bit] NULL,
 CONSTRAINT [PK_ESCALA_CUALITATIVO] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PILOTO]    Script Date: 03/23/2013 16:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PILOTO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PILOTO](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_EMPLEADO] [int] NULL,
	[FECHA_INICIO_IMPL] [datetime] NULL,
	[FECHA_FIN_IMPL] [datetime] NULL,
	[DESCRIPCION] [varchar](100) NULL,
	[DOCUMENTO] [binary](50) NULL,
	[CODIGO_SOLUCION] [int] NULL,
	[CODIGO_ESTADO] [int] NULL,
 CONSTRAINT [PK_PILOTO] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PERSONA]    Script Date: 03/23/2013 16:50:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PERSONA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PERSONA](
	[CODIGO_PERSONA] [int] NOT NULL,
	[NOMBRE_PERSONA] [varchar](200) NULL,
	[APELLIDO_PATERNO] [varchar](200) NULL,
	[APELLIDO_MATERNO] [varchar](200) NULL,
	[TIPO_PERSONA] [varchar](2) NULL,
	[TIPO_DOCUMENTO] [varchar](2) NULL,
	[NRO_DOCUMENTO] [varchar](20) NULL,
	[DIRECCION_PERSONA] [varchar](300) NULL,
	[TELEFONO_1] [varchar](20) NULL,
	[TELEFONO_2] [varchar](20) NULL,
	[USUARIOFLAG] [varchar](1) NULL,
	[ESTADO] [varchar](1) NULL,
	[SEXO] [varchar](1) NULL,
	[CORREO] [varchar](200) NULL,
 CONSTRAINT [PK_PERSONA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PERSONA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PROYECTO]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROYECTO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PROYECTO](
	[CODIGO_PROYECTO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NULL,
	[DESCRIPCION] [varchar](100) NULL,
	[FECHA_INICIO] [date] NULL,
	[FECHA_FIN] [date] NULL,
	[CODIGO_JEFE_PROYECTO] [int] NULL,
	[CODIGO_CLIENTE] [int] NULL,
	[ESTADO] [char](1) NULL,
 CONSTRAINT [PK__PROYECTO__CC87E1271DE57479] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PROYECTO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PROYECTO] ON
INSERT [dbo].[PROYECTO] ([CODIGO_PROYECTO], [NOMBRE], [DESCRIPCION], [FECHA_INICIO], [FECHA_FIN], [CODIGO_JEFE_PROYECTO], [CODIGO_CLIENTE], [ESTADO]) VALUES (1, N'SIGES', N'GESTION DE ESTACION DE SERVICIO', CAST(0x75360B00 AS Date), CAST(0x10370B00 AS Date), 3, NULL, NULL)
INSERT [dbo].[PROYECTO] ([CODIGO_PROYECTO], [NOMBRE], [DESCRIPCION], [FECHA_INICIO], [FECHA_FIN], [CODIGO_JEFE_PROYECTO], [CODIGO_CLIENTE], [ESTADO]) VALUES (2, N'TMD', N'GESTION DE CONFIGURACION', CAST(0x94360B00 AS Date), CAST(0x16370B00 AS Date), 3, NULL, NULL)
INSERT [dbo].[PROYECTO] ([CODIGO_PROYECTO], [NOMBRE], [DESCRIPCION], [FECHA_INICIO], [FECHA_FIN], [CODIGO_JEFE_PROYECTO], [CODIGO_CLIENTE], [ESTADO]) VALUES (3, N'STYR', N'GESTION TRANSACCIONAL TR', CAST(0xAE360B00 AS Date), CAST(0x3E370B00 AS Date), 3, NULL, NULL)
INSERT [dbo].[PROYECTO] ([CODIGO_PROYECTO], [NOMBRE], [DESCRIPCION], [FECHA_INICIO], [FECHA_FIN], [CODIGO_JEFE_PROYECTO], [CODIGO_CLIENTE], [ESTADO]) VALUES (4, N'SIES', N'GESTION DE GRIFOS', CAST(0xD8360B00 AS Date), CAST(0x61370B00 AS Date), 3, NULL, NULL)
INSERT [dbo].[PROYECTO] ([CODIGO_PROYECTO], [NOMBRE], [DESCRIPCION], [FECHA_INICIO], [FECHA_FIN], [CODIGO_JEFE_PROYECTO], [CODIGO_CLIENTE], [ESTADO]) VALUES (5, N'GRSSL', N'SEGUIMIENTO SALUD LABORAL', CAST(0xD8360B00 AS Date), CAST(0x06370B00 AS Date), 3, NULL, NULL)
SET IDENTITY_INSERT [dbo].[PROYECTO] OFF
/****** Object:  Table [dbo].[PROPUESTAMEJORA]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROPUESTAMEJORA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PROPUESTAMEJORA](
	[CODIGO_PROPUESTA] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_EMPLEADO] [int] NULL,
	[CODIGO_AREA] [varchar](5) NOT NULL,
	[CODIGO_PROCESO] [int] NOT NULL,
	[TIPO_PROPUESTA] [varchar](100) NULL,
	[CODIGO_RESPONSABLE] [int] NULL,
	[FECHA_ENVIO] [datetime] NULL,
	[FECHA_REGISTRO] [datetime] NULL,
	[DESCRIPCION] [varchar](200) NULL,
	[CAUSA] [varchar](200) NULL,
	[BENEFICIOS] [varchar](200) NULL,
	[OBSERVACIONES] [varchar](200) NULL,
	[CODIGO_ESTADO] [int] NULL,
 CONSTRAINT [PK_PROPUESTAMEJORA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PROPUESTA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_EMPLEADOS_POR_AREA]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_LISTAR_EMPLEADOS_POR_AREA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =========================================================
CREATE PROCEDURE [dbo].[ACP_SP_LISTAR_EMPLEADOS_POR_AREA]   
@idArea INT
AS  
BEGIN  
 SELECT -1 AS CODIGO_EMPLEADO, 
		''SELECCIONAR'' AS nombres,
		'''' AS apepat,
		'''' AS apemat,
		'''' AS CODIGO_AREA,
		'''' AS nombreArea
 UNION
 SELECT CODIGO_EMPLEADO, 
		nombres + '' '' + apepat + '' '' + apemat AS nombres,
		apepat,
		apemat,
		EMPLEADO.CODIGO_AREA,AREA.descripcion as nombreArea
 FROM	EMPLEADO  EMPLEADO
 inner join AREA AREA on (EMPLEADO.CODIGO_AREA = AREA.CODIGO_AREA)   
 WHERE  EMPLEADO.CODIGO_AREA = @idArea 
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_EMPLEADOS]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_LISTAR_EMPLEADOS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =========================================================
CREATE PROCEDURE [dbo].[ACP_SP_LISTAR_EMPLEADOS]    
AS  
BEGIN  
 SELECT CODIGO_EMPLEADO, nombres, apepat, apemat, EMPLEADO.CODIGO_AREA,AREA.descripcion as nombreArea FROM EMPLEADO      
 inner join AREA AREA on (EMPLEADO.CODIGO_AREA = AREA.CODIGO_AREA)   
END
' 
END
GO
/****** Object:  Table [dbo].[AC_AUDITADOS]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_AUDITADOS]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[AC_DET_PREGUNTA_BASE]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_DET_PREGUNTA_BASE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AC_DET_PREGUNTA_BASE](
	[idNorma] [int] NOT NULL,
	[idCapitulo] [int] NOT NULL,
	[idPreguntaBase] [int] NOT NULL,
	[descripcionPregunta] [varchar](500) NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AUDITORIA]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AUDITORIA]') AND type in (N'U'))
BEGIN
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
	[NOMBRE_ARCHIVO_L] [varchar](300) NULL,
	[NOMBRE_ARCHIVO_F] [varchar](300) NULL,
 CONSTRAINT [PK_AC_AUDITORIA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_AUDITORIA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE AUDITORIA ALTER COLUMN RESULTADO VARCHAR(300) NULL
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_ENTIDAD_AUDITADA]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_ENTIDAD_AUDITADA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ACP_SP_OBTENER_ENTIDAD_AUDITADA]    
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_EMPLEADO]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_EMPLEADO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ACP_SP_OBTENER_EMPLEADO]    
(  
 @idEmpleado int
)  
AS  
BEGIN  
 SELECT CODIGO_EMPLEADO, nombres, apepat, apemat, EMPLEADO.CODIGO_AREA,AREA.descripcion as nombreArea FROM EMPLEADO      
 inner join AREA AREA on (EMPLEADO.CODIGO_AREA = AREA.CODIGO_AREA)   
 WHERE CODIGO_EMPLEADO = @idEmpleado
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_CAPITULO]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_CAPITULO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_PROGRAMA_ANUAL_AUDITORIA]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_PROGRAMA_ANUAL_AUDITORIA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Carla Mier
-- Create date: 26/11/2012
-- Description:	Obtiene auditorias
-- =============================================
CREATE PROCEDURE [dbo].[ACP_SP_OBTENER_PROGRAMA_ANUAL_AUDITORIA]
AS
BEGIN
	select		idPrograma, anio, fechaElaboracion, elaboradoPor, 
				E1.nombres + '' '' + E1.apepat as nombre1, 
				fechaAprobacion, aprobadoPor, 
				E2.nombres + '' '' + E2.apepat as nombre2, estado
	from		AC_PROGRAMA_AUDITORIA P
	left join	EMPLEADO E1 on (E1.CODIGO_EMPLEADO = P.elaboradoPor)
	left join	EMPLEADO E2 on (E2.CODIGO_EMPLEADO = P.aprobadoPor)
	where		anio = YEAR(GETDATE()) and estado <> ''RECHAZADO''
END
' 
END
GO
/****** Object:  Table [dbo].[RESPUESTA_ENCUESTA]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RESPUESTA_ENCUESTA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RESPUESTA_ENCUESTA](
	[CODIGO_CUESTIONARIO_ENCUESTA] [int] NOT NULL,
	[ORDEN_PREGUNTA_ENCUESTA] [smallint] NOT NULL,
	[CODIGO_CLIENTE] [int] NOT NULL,
	[CODIGO_USUARIO_CLIENTE] [int] NOT NULL,
	[OPCION_RESPUESTA_ENCUESTA] [varchar](255) NULL,
	[TEXTO_LIBRE_RESPUESTA_ENCUESTA] [nvarchar](1000) NULL,
	[FECHA_RESPUESTA_ENCUESTA] [datetime] NOT NULL,
 CONSTRAINT [PK_RESPUESTA_ENCUESTA] PRIMARY KEY NONCLUSTERED 
(
	[ORDEN_PREGUNTA_ENCUESTA] ASC,
	[CODIGO_CUESTIONARIO_ENCUESTA] ASC,
	[CODIGO_USUARIO_CLIENTE] ASC,
	[CODIGO_CLIENTE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[USP_ELEMENTO_CONFIGURACION_INS]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ELEMENTO_CONFIGURACION_INS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[USP_ELEMENTO_CONFIGURACION_INS]
@CODIGO VARCHAR(10),
@NOMBRE VARCHAR(50),
@DESCRIPCION VARCHAR(100),
@TIPO VARCHAR(2),
@CODIGO_FASE VARCHAR(4)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [dbo].[ELEMENTO_CONFIGURACION](
		CODIGO,
		NOMBRE, 
		DESCRIPCION, 
		TIPO, 
		CODIGO_FASE)
	VALUES
		(@CODIGO,
		@NOMBRE, 
		@DESCRIPCION, 
		@TIPO, 
		@CODIGO_FASE);

	SET NOCOUNT OFF;

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_ELEMENTO_CONFI_SEL_CODIGO_FASE]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ELEMENTO_CONFI_SEL_CODIGO_FASE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[USP_ELEMENTO_CONFI_SEL_CODIGO_FASE]
@CODIGO_FASE INT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		CODIGO, 
		NOMBRE, 
		DESCRIPCION, 
		TIPO, 
		CODIGO_FASE
	FROM
		dbo.ELEMENTO_CONFIGURACION
	WHERE
		CODIGO_FASE = @CODIGO_FASE;

	SET NOCOUNT OFF;

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_USUARIO_SEL_CODIGO]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_USUARIO_SEL_CODIGO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_USUARIO_SEL_CODIGO]
@LOGIN VARCHAR(10)
AS
BEGIN

	SELECT
		U.CODIGO_USUARIO,
		U.NOMBRE,
		U.ROL
	FROM
		dbo.USUARIO AS U
	WHERE
		U.LOGIN = @LOGIN;
	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_UsuarioCliente_Datos]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_UsuarioCliente_Datos]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_UsuarioCliente_Datos]
	@USUARIO	bigint
AS
	DECLARE @RETCODE_PROCESO int;
	IF
		@USUARIO IS NULL
	BEGIN
		RETURN (255);
	END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SELECT A.CODIGO_CLIENTE, A.CODIGO_USUARIO_CLIENTE, A.NOMBRE_USUARIO_CLIENTE, A.ALIAS_USUARIO_CLIENTE, A.NIVEL_USUARIO_CLIENTE,
	       A.FECHA_NACIMIENTO_USUARIO_CLIENTE, A.CORREO_USUARIO_CLIENTE, A.CARGO_USUARIO_CLIENTE, A.AREA_USUARIO_CLIENTE,
	       A.TELEFONO_USUARIO_CLIENTE, A.CODIGO_CLIENTE , B.RAZON_SOCIAL, A.CODIGO_SEDE, C.NOMBRE_SEDE
    	FROM [dbo].[USUARIO_CLIENTE] AS A
		INNER JOIN [dbo].[CLIENTE] AS B ON A.CODIGO_CLIENTE = B.CODIGO_CLIENTE
		INNER JOIN [dbo].[SEDE] AS C ON A.CODIGO_SEDE = C.CODIGO_SEDE
 	WHERE A.CODIGO_USUARIO_CLIENTE = @USUARIO
	ORDER BY A.CODIGO_CLIENTE
 	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_USUARIO_SEL_LOGIN]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_USUARIO_SEL_LOGIN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_USUARIO_SEL_LOGIN]
@LOGIN VARCHAR(10)
AS
BEGIN

	SELECT
		U.CODIGO_USUARIO,
		U.NOMBRE,
		U.ROL
	FROM
		dbo.USUARIO AS U
	WHERE
		U.LOGIN = @LOGIN;
	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_USUARIO_SEL_CODIGO_ROL]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_USUARIO_SEL_CODIGO_ROL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_USUARIO_SEL_CODIGO_ROL]
@ROL CHAR(2)
AS
BEGIN
	SET NOCOUNT ON;	
	
	SELECT
		U.CODIGO_USUARIO,
		U.NOMBRE,
		U.ROL
	FROM
		dbo.USUARIO AS U
	WHERE
		@ROL = '''' OR U.ROL = @ROL;

	SET NOCOUNT OFF;
END

' 
END
GO
/****** Object:  Table [dbo].[USUARIO_PROYECTO]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USUARIO_PROYECTO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[USUARIO_PROYECTO](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_USUARIO] [int] NULL,
	[CODIGO_PROYECTO] [int] NULL,
	[TIPO_ACCESO] [char](10) NULL,
 CONSTRAINT [PK__USUARIO___CC87E1272B3F6F97] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[USUARIO_PROYECTO] ON
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (1, 1, 1, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (2, 2, 1, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (3, 3, 1, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (4, 4, 1, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (5, 1, 2, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (6, 2, 2, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (7, 3, 2, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (8, 4, 2, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (9, 5, 2, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (10, 1, 3, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (11, 2, 3, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (12, 3, 3, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (13, 1, 4, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (14, 2, 4, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (15, 3, 4, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (16, 5, 4, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (17, 1, 5, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (18, 2, 5, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (19, 3, 5, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (20, 4, 5, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (21, 5, 5, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (22, 6, 5, N'FULL      ')
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (23, 5, 1, NULL)
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (24, 6, 1, NULL)
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (25, 6, 2, NULL)
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (26, 4, 3, NULL)
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (27, 5, 3, NULL)
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (28, 6, 3, NULL)
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (29, 4, 4, NULL)
INSERT [dbo].[USUARIO_PROYECTO] ([CODIGO], [CODIGO_USUARIO], [CODIGO_PROYECTO], [TIPO_ACCESO]) VALUES (30, 6, 4, NULL)
SET IDENTITY_INSERT [dbo].[USUARIO_PROYECTO] OFF
/****** Object:  StoredProcedure [dbo].[USP_LISTA_PROYECTO]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LISTA_PROYECTO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[USP_LISTA_PROYECTO]
@CODIGO VARCHAR(10)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT US.[CODIGO_USUARIO], US.[NOMBRE], PR.[NOMBRE] AS NOM_PRO, PR.[FECHA_INICIO],
	PR.[FECHA_FIN]
	FROM [dbo].[PROYECTO] AS PR INNER JOIN [dbo].[USUARIO] AS US ON
	US.[CODIGO_USUARIO] = PR.[CODIGO_JEFE_PROYECTO]
	WHERE US.[CODIGO_USUARIO] = @CODIGO;

	SET NOCOUNT OFF;
END

IF((SELECT Object_Id(''dbo.USP_LISTA_PROYECTO_FASE'')) IS NOT NULL)
BEGIN
	DROP PROCEDURE dbo.USP_LISTA_PROYECTO_FASE
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_PROYECTO_SEL_CODIGO]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_PROYECTO_SEL_CODIGO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[USP_PROYECTO_SEL_CODIGO]
@CODIGO INT
AS
BEGIN
	SET NOCOUNT ON;	
	
	SELECT 
		PR.CODIGO_PROYECTO,
		PR.NOMBRE,
		PR.DESCRIPCION, 
		PR.[FECHA_INICIO],
		PR.[FECHA_FIN],
		PR.CODIGO_JEFE_PROYECTO,
		PR.ESTADO
	FROM 
		[dbo].[PROYECTO] AS PR 
	WHERE 
		PR.CODIGO_PROYECTO = @CODIGO;

	SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  Table [dbo].[SOLUCION_MEJORA]    Script Date: 03/23/2013 16:50:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SOLUCION_MEJORA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SOLUCION_MEJORA](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_EMPLEADO] [int] NULL,
	[CODIGO_PROPUESTA] [int] NOT NULL,
	[DESCRIPCION] [nchar](10) NULL,
	[DOCUMENTO] [nchar](10) NULL,
	[FECHA_APROBACION] [nchar](10) NULL,
	[TIENEPILOTO] [bit] NULL,
	[CODIGO_ESTADO] [int] NULL,
 CONSTRAINT [PK_SOLUCION_MEJORA] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PROYECTO_SERVICIO_SEDE]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PROYECTO_SERVICIO_SEDE](
	[CODIGO_PROYECTO] [int] NOT NULL,
	[CODIGO_SERVICIO] [int] NOT NULL,
	[CODIGO_SEDE] [int] NOT NULL,
	[CODIGO_SLA] [int] NOT NULL,
	[CODIGO_DETALLE_SLA] [int] NOT NULL,
 CONSTRAINT [PK_PROYECTO_SERVICIO] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_SERVICIO] ASC,
	[CODIGO_SEDE] ASC,
	[CODIGO_PROYECTO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PROYECTO_FASE]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROYECTO_FASE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PROYECTO_FASE](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_PROYECTO] [int] NULL,
	[CODIGO_FASE] [int] NULL,
	[FECHA_INICIO] [date] NULL,
	[FECHA_FIN] [date] NULL,
	[CODIGO_RESPONSABLE] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[PROYECTO_FASE] ON
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (1, 1, 1, CAST(0x75360B00 AS Date), CAST(0x88360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (2, 1, 2, CAST(0x89360B00 AS Date), CAST(0x92360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (3, 1, 3, CAST(0x26350B00 AS Date), CAST(0x34350B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (4, 1, 4, CAST(0xA3360B00 AS Date), CAST(0xC8360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (5, 1, 5, CAST(0xC8360B00 AS Date), CAST(0xEC360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (6, 1, 6, CAST(0xEC360B00 AS Date), CAST(0xF7360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (7, 1, 7, CAST(0xF7360B00 AS Date), CAST(0xFC360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (8, 1, 8, CAST(0x07370B00 AS Date), CAST(0x0B370B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (9, 1, 9, CAST(0x0B370B00 AS Date), CAST(0x10370B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (10, 2, 1, CAST(0x94360B00 AS Date), CAST(0xA1360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (11, 2, 2, CAST(0xA2360B00 AS Date), CAST(0xAE360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (12, 2, 3, CAST(0xAF360B00 AS Date), CAST(0xBC360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (13, 2, 4, CAST(0xBD360B00 AS Date), CAST(0xC7360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (14, 2, 5, CAST(0xC8360B00 AS Date), CAST(0xE2360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (15, 2, 6, CAST(0xE3360B00 AS Date), CAST(0xEC360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (16, 2, 7, CAST(0xEC360B00 AS Date), CAST(0xF7360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (17, 2, 8, CAST(0xF8360B00 AS Date), CAST(0x01370B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (18, 2, 9, CAST(0x02370B00 AS Date), CAST(0x15370B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (19, 3, 1, CAST(0xAE360B00 AS Date), CAST(0xB9360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (20, 3, 2, CAST(0xBA360B00 AS Date), CAST(0xC6360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (21, 3, 3, CAST(0xC7360B00 AS Date), CAST(0xCF360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (22, 3, 4, CAST(0xCF360B00 AS Date), CAST(0xDD360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (23, 3, 5, CAST(0xDD360B00 AS Date), CAST(0xEE360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (24, 3, 6, CAST(0xEF360B00 AS Date), CAST(0xFC360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (25, 3, 7, CAST(0xFD360B00 AS Date), CAST(0x0A370B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (26, 3, 8, CAST(0x01370B00 AS Date), CAST(0x29370B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (27, 3, 9, CAST(0x2A370B00 AS Date), CAST(0x3E370B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (28, 4, 1, CAST(0xCF360B00 AS Date), CAST(0xD9360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (29, 4, 2, CAST(0xDA360B00 AS Date), CAST(0xEC360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (30, 4, 3, CAST(0xED360B00 AS Date), CAST(0xF7360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (31, 4, 4, CAST(0xF8360B00 AS Date), CAST(0x06370B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (32, 4, 5, CAST(0x07370B00 AS Date), CAST(0x15370B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (33, 4, 6, CAST(0x16370B00 AS Date), CAST(0x28370B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (34, 4, 7, CAST(0x29370B00 AS Date), CAST(0x3E370B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (35, 4, 8, CAST(0x3F370B00 AS Date), CAST(0x52370B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (36, 4, 9, CAST(0x53370B00 AS Date), CAST(0x61370B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (37, 5, 1, CAST(0xD8360B00 AS Date), CAST(0xE2360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (38, 5, 2, CAST(0xE3360B00 AS Date), CAST(0xEC360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (39, 5, 3, CAST(0xED360B00 AS Date), CAST(0xF7360B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (40, 5, 4, CAST(0xF8360B00 AS Date), CAST(0x06370B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (41, 5, 5, CAST(0x07370B00 AS Date), CAST(0x15370B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (42, 5, 6, CAST(0x16370B00 AS Date), CAST(0x28370B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (43, 5, 7, CAST(0x29370B00 AS Date), CAST(0x3E370B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (44, 5, 8, CAST(0x3F370B00 AS Date), CAST(0x52370B00 AS Date), NULL)
INSERT [dbo].[PROYECTO_FASE] ([CODIGO], [CODIGO_PROYECTO], [CODIGO_FASE], [FECHA_INICIO], [FECHA_FIN], [CODIGO_RESPONSABLE]) VALUES (45, 5, 9, CAST(0x53370B00 AS Date), CAST(0x06370B00 AS Date), NULL)
SET IDENTITY_INSERT [dbo].[PROYECTO_FASE] OFF
/****** Object:  Table [dbo].[PROYECTO_CMDB]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROYECTO_CMDB]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PROYECTO_CMDB](
	[CODIGO_CMDB] [int] NOT NULL,
	[CODIGO_PROYECTO] [int] NOT NULL,
 CONSTRAINT [PK_PROYECTO_CMDB] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_CMDB] ASC,
	[CODIGO_PROYECTO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PROYECTO_USUARIO_CLIENTE]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROYECTO_USUARIO_CLIENTE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PROYECTO_USUARIO_CLIENTE](
	[CODIGO_CLIENTE] [int] NOT NULL,
	[CODIGO_USUARIO_CLIENTE] [int] NOT NULL,
	[CODIGO_PROYECTO] [int] NOT NULL,
 CONSTRAINT [PK_PROYECTO_USUARIO_CLIENTE] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_PROYECTO] ASC,
	[CODIGO_USUARIO_CLIENTE] ASC,
	[CODIGO_CLIENTE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_PLAN_AUDITORIA_POR_ID]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_PLAN_AUDITORIA_POR_ID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ACP_SP_OBTENER_PLAN_AUDITORIA_POR_ID]    
(    
	@idAuditoria int  
)    
AS    
BEGIN    
	select	AUD.CODIGO_AUDITORIA, 
			ENT.idEntidadAuditada, 
			ENT.descripcion as nombreEntidad, 
			AREA.CODIGO_AREA, 
			AREA.descripcion as nombreArea,     
			AUD.FECHA_INICIO, 
			AUD.FECHA_FIN, 
			AUD.estado,
			E.NOMBRES + '' '' + E.APEPAT as responsableProyecto,
			AUD.objetivo,
			AUD.alcance,
			AUD.NOMBRE_ARCHIVO_L,
			AUD.NOMBRE_ARCHIVO_F 
	from	AUDITORIA AUD    
	inner 
	join	AC_ENTIDAD_AUDITADA ENT on (AUD.CODIGO_ENTIDAD_AUDITADA = ENT.idEntidadAuditada)    
	inner 
	join	AREA AREA on (ENT.idArea = AREA.CODIGO_AREA)  
	inner 
	join	EMPLEADO E on (E.CODIGO_EMPLEADO = AUD.RESPONSABLE_PROCESO)    
	where	AUD.CODIGO_AUDITORIA = @idAuditoria  
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_PLAN_AUDITORIAS]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_LISTAR_PLAN_AUDITORIAS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =========================================================
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_VALIDAR_AUDITORIA]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_VALIDAR_AUDITORIA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ACP_SP_VALIDAR_AUDITORIA]     
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
' 
END
GO
/****** Object:  Table [dbo].[AC_PREGUNTA_VERIFICACION]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_PREGUNTA_VERIFICACION]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_INSERTAR_PLAN_AUDITORIA]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_INSERTAR_PLAN_AUDITORIA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ACP_SP_INSERTAR_PLAN_AUDITORIA]    
(  
 @idAuditoria int,
 @estado varchar(20),
 @archivo_l varchar(300),
 @archivo_f varchar(300)
)  
AS  
BEGIN  
	UPDATE  AUDITORIA SET ESTADO = @estado, NOMBRE_ARCHIVO_L = @archivo_l , NOMBRE_ARCHIVO_F = @archivo_f
	WHERE CODIGO_AUDITORIA = @idAuditoria
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_AUDITORIAS_POR_ANIO]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_LISTAR_AUDITORIAS_POR_ANIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =========================================================
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
		E.nombres + '' '' + E.apepat AS NOMBREEMPLEADO			
from	AUDITORIA AUD  
inner 
join	AC_ENTIDAD_AUDITADA ENT on (AUD.CODIGO_ENTIDAD_AUDITADA = ENT.idEntidadAuditada)  
inner 
join	AREA AREA on (ENT.idArea = AREA.CODIGO_AREA)   
inner 
join	EMPLEADO E on (E.CODIGO_EMPLEADO = AUD.RESPONSABLE_PROCESO)   
where	AUD.CODIGO_PROGRAMA IN (SELECT idPrograma FROM dbo.AC_PROGRAMA_AUDITORIA WHERE ANIO = @anhoAuditoria)

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_INSERTAR_AUDITORIA]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_INSERTAR_AUDITORIA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
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
' 
END
GO
/****** Object:  Table [dbo].[AC_ACTIVIDAD]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_ACTIVIDAD]') AND type in (N'U'))
BEGIN
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
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AC_AUDITOR]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_AUDITOR]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AC_AUDITOR](
	[idAuditoria] [int] NOT NULL,
	[idAuditor] [int] NOT NULL,
 CONSTRAINT [PK_AC_AUDITOR] PRIMARY KEY CLUSTERED 
(
	[idAuditoria] ASC,
	[idAuditor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PROPUESTA_INDICADOR]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROPUESTA_INDICADOR]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PROPUESTA_INDICADOR](
	[CODIGO_PROPUESTA] [int] NOT NULL,
	[CODIGO_INDICADOR] [int] NOT NULL,
	[SELECCIONADO] [varchar](10) NOT NULL CONSTRAINT [DF_PROPUESTA_INDICADOR_SELECCIONADO]  DEFAULT ('false')
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PROPUESTA_ESTADO]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROPUESTA_ESTADO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PROPUESTA_ESTADO](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_EMPLEADO] [int] NULL,
	[CODIGO_PROPUESTA] [int] NULL,
	[CODIGO_ESTADO] [int] NULL,
	[FECHA] [datetime] NULL,
	[OBSERVACIONES] [varchar](200) NULL,
 CONSTRAINT [PK_PROPUESTA_ESTADO] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OBSERVACIONES_PILOTO]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OBSERVACIONES_PILOTO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OBSERVACIONES_PILOTO](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_PILOTO] [int] NULL,
	[DESCRIPCION] [varchar](100) NULL,
 CONSTRAINT [PK_OBSERVACIONES_PILOTO] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ESTADO_PILOTO]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ESTADO_PILOTO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ESTADO_PILOTO](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_PILOTO] [int] NOT NULL,
	[CODIGO_ESTADO] [int] NOT NULL,
	[FECHA] [datetime] NOT NULL,
 CONSTRAINT [PK_ESTADO_PILOTO] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC1]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC1]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC1]
	@idAuditoria int
as
BEGIN
 
	select	AUD.CODIGO_AUDITORIA as idAuditoria, 
			cast(AUD.CODIGO_AUDITORIA as varchar) as idAuditoriaFormato, 
			AUD.FECHA_INICIO as fechaInicio, 
			AUD.FECHA_FIN as fechaFin, 
			E1.NOMBRES + '' '' + E1.APEPAT as jefeAuditor,
			AREA.descripcion as nombreArea, 
			ENT.descripcion as nombreEntidad, 		
			E.NOMBRES + '' '' + E.APEPAT as responsableProyecto,
			AUD.objetivo,
			AUD.alcance			
	from	AUDITORIA AUD
			inner join AC_ENTIDAD_AUDITADA ENT on (AUD.CODIGO_ENTIDAD_AUDITADA = ENT.idEntidadAuditada)
			inner join AREA AREA on (ENT.idArea = AREA.CODIGO_AREA)
			inner join EMPLEADO E on (AUD.RESPONSABLE_PROCESO = E.CODIGO_EMPLEADO)
			inner join dbo.AC_PROGRAMA_AUDITORIA p on (p.idPrograma = AUD.CODIGO_PROGRAMA)
			inner join EMPLEADO E1 on (p.elaboradoPor = E1.CODIGO_EMPLEADO)
	where	AUD.CODIGO_AUDITORIA = @idAuditoria

END
' 
END
GO
/****** Object:  Table [dbo].[AC_EVALUACION_AUDITORIA]    Script Date: 03/23/2013 16:50:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_EVALUACION_AUDITORIA]') AND type in (N'U'))
BEGIN
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
END
GO
/****** Object:  Table [dbo].[ESTADO_SOLUCION]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ESTADO_SOLUCION]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ESTADO_SOLUCION](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_SOLUCION] [int] NOT NULL,
	[CODIGO_ESTADO] [int] NOT NULL,
	[FECHA] [datetime] NULL,
 CONSTRAINT [PK_ESTADO_SOLUCION] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[LINEA_BASE]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LINEA_BASE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LINEA_BASE](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_PROYECTO_FASE] [int] NULL,
	[NOMBRE] [varchar](50) NULL,
	[DESCRIPCION] [varchar](100) NULL,
	[FECHA_CREACION] [date] NULL,
	[ESTADO] [varchar](2) NULL,
	[FECHA_LIBERACION] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[LINEA_BASE] ON
INSERT [dbo].[LINEA_BASE] ([CODIGO], [CODIGO_PROYECTO_FASE], [NOMBRE], [DESCRIPCION], [FECHA_CREACION], [ESTADO], [FECHA_LIBERACION]) VALUES (1, 1, N'GESTION DE REQUERIMIENTO', N'LEVANTAMIENTO DE REQ. FUNCIONAL', CAST(0x75360B00 AS Date), N'1', CAST(0x88360B00 AS Date))
INSERT [dbo].[LINEA_BASE] ([CODIGO], [CODIGO_PROYECTO_FASE], [NOMBRE], [DESCRIPCION], [FECHA_CREACION], [ESTADO], [FECHA_LIBERACION]) VALUES (2, 10, N'GESTION DE REQUERIMIENTO', N'LEVANTAMIENTO DE REQ. FUNCIONAL', CAST(0x94360B00 AS Date), N'1', CAST(0xA1360B00 AS Date))
INSERT [dbo].[LINEA_BASE] ([CODIGO], [CODIGO_PROYECTO_FASE], [NOMBRE], [DESCRIPCION], [FECHA_CREACION], [ESTADO], [FECHA_LIBERACION]) VALUES (3, 19, N'GESTION DE REQUERIMIENTO', N'INFORMES DE MOELADO', CAST(0xAE360B00 AS Date), N'1', CAST(0xB9360B00 AS Date))
INSERT [dbo].[LINEA_BASE] ([CODIGO], [CODIGO_PROYECTO_FASE], [NOMBRE], [DESCRIPCION], [FECHA_CREACION], [ESTADO], [FECHA_LIBERACION]) VALUES (4, 28, N'GESTION DE REQUERIMIENTO', N'ALCANCE DEL SISTEMA', CAST(0xCF360B00 AS Date), N'3', CAST(0xD8360B00 AS Date))
INSERT [dbo].[LINEA_BASE] ([CODIGO], [CODIGO_PROYECTO_FASE], [NOMBRE], [DESCRIPCION], [FECHA_CREACION], [ESTADO], [FECHA_LIBERACION]) VALUES (5, 29, N'GESTION DE REQUERIMIENTO', N'DOCUMENTOS DE REQUERIMIENTOS', CAST(0xD9360B00 AS Date), N'2', CAST(0xEC360B00 AS Date))
INSERT [dbo].[LINEA_BASE] ([CODIGO], [CODIGO_PROYECTO_FASE], [NOMBRE], [DESCRIPCION], [FECHA_CREACION], [ESTADO], [FECHA_LIBERACION]) VALUES (6, 2, N'ARQUITECTURA DEL PROYECTO', N'DIAGRAMA DE CAPAS', CAST(0x89360B00 AS Date), N'1', CAST(0x92360B00 AS Date))
INSERT [dbo].[LINEA_BASE] ([CODIGO], [CODIGO_PROYECTO_FASE], [NOMBRE], [DESCRIPCION], [FECHA_CREACION], [ESTADO], [FECHA_LIBERACION]) VALUES (7, 11, N'MODELO DE DISENO', N'DOCUMENTOS DE DISENO', CAST(0xA2360B00 AS Date), N'1', CAST(0xAE360B00 AS Date))
INSERT [dbo].[LINEA_BASE] ([CODIGO], [CODIGO_PROYECTO_FASE], [NOMBRE], [DESCRIPCION], [FECHA_CREACION], [ESTADO], [FECHA_LIBERACION]) VALUES (8, 20, N'MODELO DE DISENO', N'DOCUMENTOS DE DISENO', CAST(0xBA360B00 AS Date), N'1', CAST(0xC6360B00 AS Date))
INSERT [dbo].[LINEA_BASE] ([CODIGO], [CODIGO_PROYECTO_FASE], [NOMBRE], [DESCRIPCION], [FECHA_CREACION], [ESTADO], [FECHA_LIBERACION]) VALUES (9, 3, N'DOCUMENTO DE IMPLEMENTACION', N'DIAGRAMA DE IMPLEMENTACION', CAST(0x94360B00 AS Date), N'1', CAST(0xA2360B00 AS Date))
INSERT [dbo].[LINEA_BASE] ([CODIGO], [CODIGO_PROYECTO_FASE], [NOMBRE], [DESCRIPCION], [FECHA_CREACION], [ESTADO], [FECHA_LIBERACION]) VALUES (10, 12, N'DOCUMENTO DE IMPLEMENTACION', N'ARTEFACTOS CREADOS', CAST(0xAF360B00 AS Date), N'1', CAST(0xBC360B00 AS Date))
INSERT [dbo].[LINEA_BASE] ([CODIGO], [CODIGO_PROYECTO_FASE], [NOMBRE], [DESCRIPCION], [FECHA_CREACION], [ESTADO], [FECHA_LIBERACION]) VALUES (11, 21, N'INFORMES DE DESPLIEGUE', N'DOCUMENTOS DE PROTOTIPOS', CAST(0xC7360B00 AS Date), N'2', CAST(0xCF360B00 AS Date))
INSERT [dbo].[LINEA_BASE] ([CODIGO], [CODIGO_PROYECTO_FASE], [NOMBRE], [DESCRIPCION], [FECHA_CREACION], [ESTADO], [FECHA_LIBERACION]) VALUES (12, 4, N'DOCUMENTO DE VERIFICACION', N'DOCUMENTOS DE PRUEBAS', CAST(0xA3360B00 AS Date), N'1', CAST(0xA9360B00 AS Date))
INSERT [dbo].[LINEA_BASE] ([CODIGO], [CODIGO_PROYECTO_FASE], [NOMBRE], [DESCRIPCION], [FECHA_CREACION], [ESTADO], [FECHA_LIBERACION]) VALUES (13, 13, N'MODELADO DE CASOS DE PRUEBA', N'LISTADO DE CHECKLIST DE PRUEBA', CAST(0xBD360B00 AS Date), N'1', CAST(0xC6360B00 AS Date))
INSERT [dbo].[LINEA_BASE] ([CODIGO], [CODIGO_PROYECTO_FASE], [NOMBRE], [DESCRIPCION], [FECHA_CREACION], [ESTADO], [FECHA_LIBERACION]) VALUES (14, 22, N'DOCUMENTOS DE VERIFICACION', N'DOCUMENTOS DE PRUEBA', CAST(0xCF360B00 AS Date), N'1', CAST(0xE2360B00 AS Date))
INSERT [dbo].[LINEA_BASE] ([CODIGO], [CODIGO_PROYECTO_FASE], [NOMBRE], [DESCRIPCION], [FECHA_CREACION], [ESTADO], [FECHA_LIBERACION]) VALUES (15, 23, N'DESPLIEGUE DE APLICACION', N'VERSIONADO DEL PRODUCTO', CAST(0xE3360B00 AS Date), N'2', CAST(0xEE360B00 AS Date))
INSERT [dbo].[LINEA_BASE] ([CODIGO], [CODIGO_PROYECTO_FASE], [NOMBRE], [DESCRIPCION], [FECHA_CREACION], [ESTADO], [FECHA_LIBERACION]) VALUES (16, 5, N'Línea Base 1', N'Línea Base de Despliegue', CAST(0xDE360B00 AS Date), N'1', NULL)
INSERT [dbo].[LINEA_BASE] ([CODIGO], [CODIGO_PROYECTO_FASE], [NOMBRE], [DESCRIPCION], [FECHA_CREACION], [ESTADO], [FECHA_LIBERACION]) VALUES (17, 7, N'Linea base 1 de calidad', N'Línea base de calidad', CAST(0xDF360B00 AS Date), N'1', NULL)
SET IDENTITY_INSERT [dbo].[LINEA_BASE] OFF
/****** Object:  Table [dbo].[AC_HALLAZGO]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_HALLAZGO]') AND type in (N'U'))
BEGIN
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
	[idAuditorSeguimiento] [int] NULL,
 CONSTRAINT [PK_AC_HALLAZGO_1] PRIMARY KEY CLUSTERED 
(
	[idHallazgo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AC_CALIFICACION_AUDITOR]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AC_CALIFICACION_AUDITOR]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AC_CALIFICACION_AUDITOR](
	[idCalificacionAuditoria] [int] NOT NULL,
	[idAuditoria] [int] NOT NULL,
	[idAuditor] [int] NOT NULL,
	[idPreguntaCalificacion] [int] NOT NULL,
	[respuesta] [text] NOT NULL,
	[observacion] [text] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_ELIMINAR_AUDITORES_X_AUDITORIA]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_ELIMINAR_AUDITORES_X_AUDITORIA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ACP_ELIMINAR_AUDITORES_X_AUDITORIA]    
(  
 @idAuditoria int
)  
AS  
BEGIN  	
 DELETE FROM AC_AUDITOR WHERE idAuditoria = @idAuditoria
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_ELIMINAR_ACTIVIDADES_X_AUDITORIA]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_ELIMINAR_ACTIVIDADES_X_AUDITORIA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ACP_ELIMINAR_ACTIVIDADES_X_AUDITORIA]    
(  
 @idAuditoria int
)  
AS  
BEGIN  	
 DELETE FROM AC_ACTIVIDAD WHERE idAuditoria = @idAuditoria
END
' 
END
GO
/****** Object:  Table [dbo].[ACCIONES_SOLUCION]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACCIONES_SOLUCION]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ACCIONES_SOLUCION](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_SOLUCION] [int] NULL,
	[DESCRIPCION] [varchar](200) NULL,
	[FECHA] [datetime] NULL,
	[ARCHIVO_ADJUNTO] [binary](50) NULL,
 CONSTRAINT [PK_ACCIONES_SOLUCION] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_INSERTAR_AUDITOR]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_INSERTAR_AUDITOR]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ACP_SP_INSERTAR_AUDITOR]    
(  
 @idAuditoria int,
 @idAuditor int
)  
AS  
BEGIN  
	INSERT INTO AC_AUDITOR VALUES (@idAuditoria,@idAuditor)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_INSERTAR_ACTIVIDAD]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_INSERTAR_ACTIVIDAD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ACP_SP_INSERTAR_ACTIVIDAD]    
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_AUDITORES_POR_AUDITORIA]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_LISTAR_AUDITORES_POR_AUDITORIA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ACP_SP_LISTAR_AUDITORES_POR_AUDITORIA]    
(  
 @idAuditoria int
)  
AS  
BEGIN  	
SELECT idAuditoria,idAuditor FROM AC_AUDITOR WHERE idAuditoria = @idAuditoria
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_ACTIVIDADES_POR_AUDITORIA]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_LISTAR_ACTIVIDADES_POR_AUDITORIA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ACP_SP_LISTAR_ACTIVIDADES_POR_AUDITORIA]    
(  
 @idAuditoria int
) 
AS  
BEGIN
	SELECT idAuditoria,idActividad,idAuditor,descripcionActividad,lugar,fechaInicio,fechaFin,estado 
	FROM AC_ACTIVIDAD
	WHERE idAuditoria = @idAuditoria
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC3]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC3]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC3]
	@idAuditoria int
as
BEGIN

	select A.idAuditoria, convert(varchar, ROW_NUMBER() OVER(ORDER BY A.idActividad asc)) AS Id, A.descripcionActividad, 
			(E.apepat + '' '' + E.apemat + '', '' + E.nombres) as responsable,
			A.lugar,
			convert(char(10), A.fechaInicio, 103) as fechaInicio,
			convert(char(10), A.fechaFin, 103) as fechaFin,
			A.estado
	from AC_ACTIVIDAD A
			inner join EMPLEADO E on (A.idAuditor = E.CODIGO_EMPLEADO) 
	where A.idAuditoria = @idAuditoria

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC2]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[ACP_SP_REP_PLAN_AUDITORIA_SEC2]
	@idAuditoria int
as
BEGIN

	select A.idAuditoria,(E.apepat + '' '' + E.apemat + '', '' + E.nombres) as nombreAuditor
	from AC_AUDITOR A
		inner join EMPLEADO E on (A.idAuditor = E.CODIGO_EMPLEADO)
	where A.idAuditoria = @idAuditoria

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_MODIFICAR_PREGUNTA_VERIFICACION]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_MODIFICAR_PREGUNTA_VERIFICACION]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_AUDITORIA]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_AUDITORIA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
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
			AUD.FECHA_INICIO, AUD.FECHA_FIN, AUD.ESTADO, E.NOMBRES + '' '' + E.APEPAT AS responsableProyecto, 
			COUNT(PREG.idPreguntaVerificacion) as numItemsChecklist
	from AUDITORIA AUD
			inner join AC_ENTIDAD_AUDITADA ENT on (AUD.CODIGO_ENTIDAD_AUDITADA = ENT.idEntidadAuditada)
			inner join AREA AREA on (ENT.idArea = AREA.CODIGO_AREA)
			left join AC_PREGUNTA_VERIFICACION PREG on (AUD.CODIGO_AUDITORIA = PREG.idAuditoria)
			inner join EMPLEADO E on (AUD.RESPONSABLE_PROCESO = E.CODIGO_EMPLEADO)
	where	(@anhoAuditoria is null or year(AUD.FECHA_INICIO) = @anhoAuditoria) and
			(@idAuditoria is null or AUD.CODIGO_AUDITORIA = @idAuditoria) and
			(@estado is null or ESTADO = @estado)
	group by AUD.CODIGO_AUDITORIA, ENT.idEntidadAuditada, ENT.descripcion, AREA.CODIGO_AREA, AREA.DESCRIPCION, 
				AUD.FECHA_INICIO, AUD.FECHA_FIN, AUD.estado, E.NOMBRES + '' '' + E.APEPAT
	having (@indChecklistEstablecido = 1 and COUNT(PREG.idPreguntaVerificacion) > 0)
			
END
' 
END
GO
/****** Object:  Table [dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO](
	[CODIGO_PROYECTO] [int] NOT NULL,
	[CODIGO_SERVICIO] [int] NOT NULL,
	[CODIGO_SEDE] [int] NOT NULL,
	[CODIGO_EQUIPO] [int] NOT NULL,
	[ESTADO_PSSE] [varchar](15) NOT NULL CONSTRAINT [DF_PROYECTO_SERVICIO_SEDE_EQUIPO_ESTADO_PSSE]  DEFAULT ('ACTIVO'),
 CONSTRAINT [PK_PROYECTO_SERVICIO_SEDE_EQUIPO] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_EQUIPO] ASC,
	[CODIGO_SERVICIO] ASC,
	[CODIGO_SEDE] ASC,
	[CODIGO_PROYECTO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PLAN_DESPLIEGUE]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLAN_DESPLIEGUE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLAN_DESPLIEGUE](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_EMPLEADO] [int] NULL,
	[FECHA] [datetime] NULL,
	[DESCRIPCION] [varchar](200) NULL,
	[DOCUMENTO] [binary](50) NULL,
	[CODIGO_SOLUCION] [int] NULL,
 CONSTRAINT [PK_PLAN_DESPLIEGUE] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[usp_CMDB_ListaCompleta]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CMDB_ListaCompleta]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_CMDB_ListaCompleta] 
	@PROYECTO	bigint
AS
	DECLARE @RETCODE_PROCESO int;
	IF
		@PROYECTO	IS NULL
	BEGIN
		RETURN 255
	END
	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;
	SELECT A.CODIGO_CMDB, A.NOMBRE_CMDB, A.DESCRIPCION_CMDB 
	FROM [dbo].[CMDB] AS A
		INNER JOIN [dbo].[PROYECTO_CMDB] AS B ON A.CODIGO_CMDB = B.CODIGO_CMDB
	WHERE B.CODIGO_PROYECTO = @PROYECTO
	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Proyecto_ListaSedes]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Proyecto_ListaSedes]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Proyecto_ListaSedes]
	@PROYECTO	bigint
AS
	DECLARE @RETCODE_PROCESO int;
	IF
		@PROYECTO	IS NULL
	BEGIN
		RETURN (255);
	END
	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SELECT DISTINCT A.CODIGO_SEDE, A.NOMBRE_SEDE
               FROM [dbo].[SEDE] AS A
		  INNER JOIN [dbo].[PROYECTO_SERVICIO_SEDE] AS B ON A.CODIGO_SEDE = B.CODIGO_SEDE
	WHERE B.CODIGO_PROYECTO = @PROYECTO
	ORDER BY A.CODIGO_SEDE;
	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_PROYECO_FASE_COD_PROYECTO_FASE]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_PROYECO_FASE_COD_PROYECTO_FASE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_PROYECO_FASE_COD_PROYECTO_FASE]  
@CODIGO_PROYECTO INT,  
@CODIGO_FASE INT  
AS  
BEGIN  
  
 SET NOCOUNT ON;  
  
 SELECT  
  PF.CODIGO,   
  PF.CODIGO_PROYECTO,   
  PF.CODIGO_FASE,   
  PF.FECHA_INICIO,   
  PF.FECHA_FIN,
  P.FECHA_FIN AS FECHA_FIN_PROYECTO
 FROM  
  dbo.PROYECTO_FASE  AS PF
  INNER JOIN dbo.PROYECTO AS P
  ON PF.CODIGO_PROYECTO = P.CODIGO_PROYECTO
 WHERE  
  PF.CODIGO_PROYECTO = @CODIGO_PROYECTO  
  AND PF.CODIGO_FASE = @CODIGO_FASE;  
  
 SET NOCOUNT OFF;  
  
END  
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Proyecto_Servicio_Sede]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Proyecto_Servicio_Sede]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Proyecto_Servicio_Sede]
	@PROYECTO	bigint,
	@SERVICIO	bigint,
	@SEDE		bigint
AS
	DECLARE @RETCODE_PROCESO int;
	IF
		@PROYECTO IS NULL OR
		@SERVICIO IS NULL OR
		@SEDE     IS NULL
	BEGIN
		RETURN (255);
	END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SELECT A.CODIGO_SERVICIO,S.NOMBRE_SERVICIO,S.DESCRIPCION_SERVICIO,A.CODIGO_PROYECTO ,A.CODIGO_SEDE,
	       A.CODIGO_SLA, C.NOMBRE_SLA, C.DESCRIPCION_SLA, C.FECHA_CREACION_SLA, C.FECHA_ACTIVACION_SLA,
	       A.CODIGO_DETALLE_SLA, B.NOMBRE_DETALLE_SLA, B.DESCRIPCION_DETALLE_SLA, B.URGENCIA_DETALLE_SLA, B.IMPACTO_DETALLE_SLA, B.COMPLEJIDAD_DETALLE_SLA,
	       B.TIEMPO_RESPUESTA_DETALLE_SLA, B.TIEMPO_CIERRE_DETALLE_SLA
	FROM [dbo].[PROYECTO_SERVICIO_SEDE] AS A
		INNER JOIN [dbo].[DETALLE_SLA] AS B ON A.CODIGO_SLA = B.CODIGO_SLA AND A.CODIGO_DETALLE_SLA = B.CODIGO_DETALLE_SLA
		INNER JOIN [dbo].[SLA] AS C ON B.CODIGO_SLA = C.CODIGO_SLA
		INNER JOIN SD.SERVICIO S ON S.CODIGO_SERVICIO = A.CODIGO_SERVICIO
 	WHERE A.CODIGO_PROYECTO = @PROYECTO AND A.CODIGO_SERVICIO = @SERVICIO AND A.CODIGO_SEDE = @SEDE
	ORDER BY B.CODIGO_SLA, B.CODIGO_DETALLE_SLA
 	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_PROYECTO_SEL_CODIGO_USUARIO]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_PROYECTO_SEL_CODIGO_USUARIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[USP_PROYECTO_SEL_CODIGO_USUARIO]
@CODIGO_USUARIO INT
AS
BEGIN
	SET NOCOUNT ON;	
	
	SELECT 
		PR.CODIGO_PROYECTO,
		PR.NOMBRE,
		PR.DESCRIPCION, 
		PR.[FECHA_INICIO],
		PR.[FECHA_FIN],
		PR.CODIGO_JEFE_PROYECTO,
		PR.ESTADO
	FROM 
		[dbo].[PROYECTO] AS PR 
		INNER JOIN [dbo].[USUARIO_PROYECTO] AS US ON
		US.[CODIGO_PROYECTO] = PR.[CODIGO_PROYECTO]
	WHERE 
		US.[CODIGO_USUARIO] = @CODIGO_USUARIO;

	SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_USUARIO_SEL_CODIGO_PROYECTO]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_USUARIO_SEL_CODIGO_PROYECTO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[USP_USUARIO_SEL_CODIGO_PROYECTO]
@CODIGO_PROYECTO INT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		U.CODIGO_USUARIO, 
		U.NOMBRE, 
		U.CODIGO_AREA
	FROM
		dbo.USUARIO AS U
		INNER JOIN dbo.USUARIO_PROYECTO AS UP
		ON U.CODIGO_USUARIO = UP.CODIGO_USUARIO
	WHERE
		UP.CODIGO_PROYECTO = @CODIGO_PROYECTO;

	SET NOCOUNT OFF;

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_USUARIO_PROYECTO]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_USUARIO_PROYECTO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Servicio_ListaServiciosUsuarioCliente]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Servicio_ListaServiciosUsuarioCliente]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Servicio_ListaServiciosUsuarioCliente]
	@USUARIO	bigint,
	@CLIENTE	bigint
AS
	DECLARE @RETCODE_PROCESO int;
	IF
		@CLIENTE	IS NULL OR
		@USUARIO	IS NULL
	BEGIN
		RETURN (255);
	END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SELECT DISTINCT C.CODIGO_SERVICIO, D.NOMBRE_SERVICIO, D.DESCRIPCION_SERVICIO 
               FROM [dbo].[USUARIO_CLIENTE] AS A
		INNER JOIN [dbo].[PROYECTO_USUARIO_CLIENTE] AS B ON A.CODIGO_CLIENTE  = B.CODIGO_CLIENTE AND A.CODIGO_USUARIO_CLIENTE = B.CODIGO_USUARIO_CLIENTE
		INNER JOIN [dbo].[PROYECTO_SERVICIO_SEDE]   AS C ON B.CODIGO_PROYECTO = C.CODIGO_PROYECTO AND A.CODIGO_SEDE = C.CODIGO_SEDE
		INNER JOIN [dbo].[SERVICIO]                 AS D ON C.CODIGO_SERVICIO = D.CODIGO_SERVICIO
	WHERE A.CODIGO_CLIENTE = @CLIENTE AND A.CODIGO_USUARIO_CLIENTE = @USUARIO
	ORDER BY C.CODIGO_SERVICIO;
	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Servicio_ListaServiciosSedeEquipo]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Servicio_ListaServiciosSedeEquipo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Servicio_ListaServiciosSedeEquipo]
	@PROYECTO	bigint,
	@SEDE		bigint,
	@EQUIPO		bigint
AS
	DECLARE @RETCODE_PROCESO int;
	IF
		@PROYECTO	IS NULL OR
		@SEDE		IS NULL OR
		@EQUIPO		IS NULL
	BEGIN
		RETURN (255);
	END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SELECT DISTINCT B.CODIGO_SERVICIO, B.NOMBRE_SERVICIO, B.DESCRIPCION_SERVICIO, B.FECHA_INICIO_SERVICIO,
			B.FECHA_CIERRE_SERVICIO, B.FECHA_ACTIVACION_SERVICIO, B.MONTO_SERVICIO 
               FROM [dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO] AS A
		INNER JOIN [dbo].[SERVICIO] AS B ON A.CODIGO_SERVICIO = B.CODIGO_SERVICIO
	WHERE A.CODIGO_PROYECTO = @PROYECTO AND A.CODIGO_SEDE = @SEDE AND A.CODIGO_EQUIPO = @EQUIPO 
	ORDER BY B.CODIGO_SERVICIO;
	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LISTA_PROYECTO_FASE]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LISTA_PROYECTO_FASE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[USP_LISTA_PROYECTO_FASE]
@CODIGO_PROYECTO VARCHAR(10)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT  
		FA.[NOMBRE] AS NOM_FASE, 
		LB.[NOMBRE] AS NOM_LIN_BAS
	FROM ([dbo].[PROYECTO_FASE] AS PF INNER JOIN [dbo].[FASE] AS FA ON
	FA.[CODIGO] = PF.[CODIGO_FASE]) INNER JOIN [dbo].[LINEA_BASE] AS LB ON
	PF.[CODIGO] = LB.[CODIGO_PROYECTO_FASE]
	WHERE [CODIGO_PROYECTO] = @CODIGO_PROYECTO;

	SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_UPD]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_UPD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[USP_LINEA_BASE_UPD]
@CODIGO INT,
@NOMBRE VARCHAR(50),
@DESCRIPCION VARCHAR(100)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE 
		[dbo].[LINEA_BASE]
	SET
		NOMBRE = @NOMBRE,
		DESCRIPCION = @DESCRIPCION
	WHERE
	CODIGO = @CODIGO;

	SET NOCOUNT OFF;

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_SEL_CODIGO_PROYECTO_FASE]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_SEL_CODIGO_PROYECTO_FASE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[USP_LINEA_BASE_SEL_CODIGO_PROYECTO_FASE]
@CODIGO_PROYECTO INT,
@CODIGO_FASE INT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		LB.CODIGO,
		LB.CODIGO_PROYECTO_FASE,
		LB.NOMBRE,
		F.NOMBRE AS NOMBRE_FASE,
		F.CODIGO AS CODIGO_FASE,
		PF.FECHA_INICIO,
		PF.FECHA_FIN,
		LB.DESCRIPCION,
		LB.ESTADO,
		LB.FECHA_LIBERACION
	FROM
		dbo.LINEA_BASE AS LB
		INNER JOIN dbo.PROYECTO_FASE AS PF
		ON LB.CODIGO_PROYECTO_FASE = PF.CODIGO
		INNER JOIN dbo.FASE AS F
		ON PF.CODIGO_FASE = F.CODIGO
	WHERE
		PF.CODIGO_PROYECTO = @CODIGO_PROYECTO
		AND PF.CODIGO_FASE = @CODIGO_FASE;

	SET NOCOUNT OFF;

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_SEL_CODIGO_PROYECTO]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_SEL_CODIGO_PROYECTO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[USP_LINEA_BASE_SEL_CODIGO_PROYECTO]
@CODIGO_PROYECTO INT,
@CODIGO_USUARIO INT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT DISTINCT
		LB.CODIGO,
		LB.CODIGO_PROYECTO_FASE,
		LB.NOMBRE,
		F.NOMBRE AS NOMBRE_FASE,
		F.CODIGO AS CODIGO_FASE,
		PF.FECHA_INICIO,
		PF.FECHA_FIN,
		LB.DESCRIPCION,
		LB.ESTADO,
		LB.FECHA_LIBERACION
	FROM
		dbo.LINEA_BASE AS LB
		INNER JOIN dbo.PROYECTO_FASE AS PF
		ON LB.CODIGO_PROYECTO_FASE = PF.CODIGO
		INNER JOIN dbo.FASE AS F
		ON PF.CODIGO_FASE = F.CODIGO
		INNER JOIN dbo.USUARIO_PROYECTO AS UP
		ON UP.CODIGO_PROYECTO = PF.CODIGO_PROYECTO
	WHERE
		PF.CODIGO_PROYECTO = @CODIGO_PROYECTO
		AND (@CODIGO_USUARIO = 0 OR UP.CODIGO_USUARIO = @CODIGO_USUARIO);

	SET NOCOUNT OFF;

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_SEL_CODIGO]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_SEL_CODIGO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_LINEA_BASE_SEL_CODIGO]
@CODIGO INT
AS  
BEGIN  
  
 SET NOCOUNT ON;  
  
 SELECT  
  LB.CODIGO,  
  LB.CODIGO_PROYECTO_FASE,  
  LB.NOMBRE,  
  F.NOMBRE AS NOMBRE_FASE,  
  F.CODIGO AS CODIGO_FASE,  
  PF.FECHA_INICIO,  
  PF.FECHA_FIN,  
  LB.DESCRIPCION,  
  LB.ESTADO,  
  LB.FECHA_LIBERACION  
 FROM  
  dbo.LINEA_BASE AS LB  
  INNER JOIN dbo.PROYECTO_FASE AS PF  
  ON LB.CODIGO_PROYECTO_FASE = PF.CODIGO  
  INNER JOIN dbo.FASE AS F  
  ON PF.CODIGO_FASE = F.CODIGO  
 WHERE  
  LB.CODIGO = @CODIGO; 
  
 SET NOCOUNT OFF;  
  
END  
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_INS]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_INS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_LINEA_BASE_INS]
@CODIGO INT OUTPUT,
@CODIGO_PROYECTO_FASE INT,
@NOMBRE VARCHAR(50),
@DESCRIPCION VARCHAR(100)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [dbo].[LINEA_BASE](
		CODIGO_PROYECTO_FASE, 
		NOMBRE, 
		DESCRIPCION, 
		FECHA_CREACION, 
		ESTADO)
	VALUES
		(@CODIGO_PROYECTO_FASE, 
		@NOMBRE, 
		@DESCRIPCION, 
		GETDATE(), 
		''1'');
		
	SET @CODIGO = SCOPE_IDENTITY();

	SET NOCOUNT OFF;

END
' 
END
GO
/****** Object:  Table [dbo].[TICKET]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TICKET]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TICKET](
	[CODIGO_TICKET] [int] IDENTITY(1,1) NOT NULL,
	[TIPO_REGISTRO_TICKET] [varchar](20) NOT NULL,
	[TIPO_ATENCION_TICKET] [varchar](20) NOT NULL,
	[FECHA_REGISTRO_TICKET] [datetime] NOT NULL,
	[FECHA_EXPIRACION_TICKET] [datetime] NOT NULL,
	[FECHA_INICIO_TICKET] [datetime] NULL,
	[FECHA_CIERRE_TICKET] [datetime] NULL,
	[FECHA_SOLUCION_TICKET] [datetime] NULL,
	[DESCRIPCION_CORTA_TICKET] [varchar](50) NOT NULL,
	[DESCRIPCION_TICKET] [varchar](1000) NOT NULL,
	[TIEMPO_RESOLUCION_TICKET] [int] NOT NULL,
	[PRIORIDAD_TICKET] [int] NOT NULL,
	[SOLUCION_TICKET] [varchar](1000) NULL,
	[ULTIMA_SECUENCIA_SEGUIMIENTO_TICKET] [bigint] NOT NULL CONSTRAINT [DF_TICKET_ULTIMA_SECUENCIA_SEGUMIENTO_TICKET]  DEFAULT ((0)),
	[ULTIMA_SECUENCIA_ADICIONAL_TICKET] [bigint] NOT NULL CONSTRAINT [DF_TICKET_ULTIMA_SECUENCIA_ADICIONAL_TICKET]  DEFAULT ((0)),
	[ESTADO_TICKET] [varchar](15) NOT NULL,
	[SATISFACCION_SERVICIO_TICKET] [varchar](15) NULL,
	[CODIGO_CLIENTE] [int] NOT NULL,
	[CODIGO_USUARIO_CLIENTE] [int] NOT NULL,
	[CODIGO_PROYECTO] [int] NOT NULL,
	[CODIGO_SERVICIO] [int] NOT NULL,
	[CODIGO_SEDE] [int] NOT NULL,
	[CODIGO_EQUIPO] [int] NOT NULL,
	[CREADO_POR_CODIGO_INTEGRANTE] [int] NOT NULL,
	[ASIGNADO_A_CODIGO_INTEGRANTE] [int] NOT NULL,
	[ULTIMO_CAMBIO_CODIGO_INTEGRANTE] [int] NOT NULL,
 CONSTRAINT [PK_TICKET] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_TICKET] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[USP_FASE_PROYECTO_SEL_CODIGO_PROYECTO]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_FASE_PROYECTO_SEL_CODIGO_PROYECTO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[USP_FASE_PROYECTO_SEL_CODIGO_PROYECTO]
@CODIGO_PROYECTO INT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		F.CODIGO,
		F.NOMBRE,
		LB.CODIGO AS CODIGO_LINEA_BASE
	FROM
		[dbo].[PROYECTO_FASE] AS PF
		INNER JOIN [dbo].[FASE] AS F
		ON PF.CODIGO_FASE = F.CODIGO
		LEFT JOIN dbo.LINEA_BASE AS LB
		ON PF.CODIGO = LB.CODIGO_PROYECTO_FASE
	WHERE
		PF.CODIGO_PROYECTO = @CODIGO_PROYECTO;

	SET NOCOUNT OFF;

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Equipo_ListaEquiposPSSNivelEmpleado]    Script Date: 03/23/2013 16:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Equipo_ListaEquiposPSSNivelEmpleado]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Equipo_ListaEquiposPSSNivelEmpleado]
	@PROYECTO	bigint,
	@SEDE		bigint,
	@SERVICIO	bigint,
	@NIVEL		varchar(50),
	@EMPLEADO	bigint
AS
	DECLARE @RETCODE_PROCESO int;
	IF
		@PROYECTO IS NULL OR
		@SEDE     IS NULL OR
		@SERVICIO IS NULL OR
		@NIVEL    IS NULL OR
		@EMPLEADO IS NULL
	BEGIN
		RETURN (255);
	END
	IF
		@NIVEL <> ''ANALISTA'' AND 
		@NIVEL <> ''ESPECIALISTA''
	BEGIN
		RETURN (250);
	END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SELECT DISTINCT A.CODIGO_EQUIPO, B.NOMBRE_EQUIPO
               FROM [dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO] AS A
		INNER JOIN [dbo].[EQUIPO]     AS B ON A.CODIGO_EQUIPO = B.CODIGO_EQUIPO
		INNER JOIN [dbo].[INTEGRANTE] AS C ON B.CODIGO_EQUIPO = C.CODIGO_EQUIPO
	WHERE C.NIVEL_INTEGRANTE Like @NIVEL + ''%'' AND C.CODIGO_EMPLEADO = @EMPLEADO
	ORDER BY A.CODIGO_EQUIPO;
 	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_HALLAZGOS_SEGUIMIENTO]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_HALLAZGOS_SEGUIMIENTO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ACP_SP_OBTENER_HALLAZGOS_SEGUIMIENTO]
@idHallazgo int
AS
            SELECT 
            H.idHallazgo,H.idAuditoria,H.idPreguntaVerificacion,P.descripcionPregunta, 
            H.tipoHallazgo,H.descripcion,H.fechaCompromiso,H.idAuditorSeguimiento, 
            (E.NOMBRES + E.APEPAT + E.APEMAT) AS responsableSeguimiento,H.estado, H.accionCorrectiva, H.accionPreventiva
            FROM AC_HALLAZGO H 
            INNER JOIN AC_PREGUNTA_VERIFICACION P ON H.idAuditoria = P.idAuditoria AND H.idPreguntaVerificacion = P.idPreguntaVerificacion 
            INNER JOIN AUDITORIA A ON H.idAuditoria = A.CODIGO_AUDITORIA 
            LEFT JOIN EMPLEADO E ON H.idAuditorSeguimiento = E.CODIGO_EMPLEADO 
            WHERE (H.idHallazgo = @idHallazgo)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_HALLAZGO]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_HALLAZGO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
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
			left join AC_ARCHIVO A on (H.idHallazgo = A.idOrigen) and A.tipoOrigen=''H''
	where (@idHallazgo is null or idHallazgo = @idHallazgo) and
			(@idAuditoria is null or H.idAuditoria = @idAuditoria) and
			(@idPreguntaVerificacion is null or H.idPreguntaVerificacion = @idPreguntaVerificacion) and
			(@estado is null or estado = @estado)		
	group by H.idHallazgo, H.tipoHallazgo
			
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_OBTENER_CHECKLIST]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_OBTENER_CHECKLIST]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ACP_SP_OBTENER_CHECKLIST] --1,1,2
(
	@idAuditoria int,
	@idNorma int,
	@idCapitulo int
)
AS
BEGIN
	Select P.idPreguntaVerificacion, P.descripcionPregunta, P.respuesta, P.sustento, 
	Convert(Numeric(10,0), P.porcentaje) as Porcentaje , P.idAuditoria, P.idNorma, P.idCapitulo, ISNULL(nCant,0) as nCantPlan
	from AC_PREGUNTA_VERIFICACION P	
	LEFT JOIN (select idPreguntaVerificacion, count(*) as nCant 
	from AC_HALLAZGO where estado<>''CREADO'' group by idPreguntaVerificacion) H ON 
	P.idPreguntaVerificacion=H.idPreguntaVerificacion
	where idAuditoria = @idAuditoria and idNorma = @idNorma and idCapitulo = @idCapitulo
			
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_MODIFICAR_HALLAZGO_SEGUIMIENTO]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_MODIFICAR_HALLAZGO_SEGUIMIENTO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ACP_SP_MODIFICAR_HALLAZGO_SEGUIMIENTO]
(
	@idHallazgo int,
	@causa varchar(1000),
	@accioncorrectiva varchar(1000),
	@accionpreventiva varchar(1000),
	@fechacompromiso datetime
)
AS
BEGIN
	update AC_HALLAZGO
	set causa = isnull(@causa, causa),
		accionCorrectiva = isnull(@accioncorrectiva, accionCorrectiva),
		accionPreventiva = isnull(@accionpreventiva, accionPreventiva),
		fechaCompromiso = @fechacompromiso,
		estado= ''PLANIFICADO''		
	where idHallazgo = @idHallazgo
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_MODIFICAR_HALLAZGO]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_MODIFICAR_HALLAZGO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_MATRIZ_ENTIDAD_AUDITADA]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_LISTAR_MATRIZ_ENTIDAD_AUDITADA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ACP_SP_LISTAR_MATRIZ_ENTIDAD_AUDITADA]     
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
 ORDER	BY 10 DESC
			
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_LISTAR_HALLAZGOS_POR_ANIO]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_LISTAR_HALLAZGOS_POR_ANIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ACP_SP_LISTAR_HALLAZGOS_POR_ANIO]
@anhoAuditoria int
AS
select	H.idHallazgo as idHallazgo, min(H.idAuditoria) as idAuditoria, 
		min(H.idPreguntaVerificacion) as idPreguntaVerificacion, 
		min(P.descripcionPregunta) as Pregunta,
		min(H.descripcion) as descripcion, H.tipoHallazgo as TipoHallazgo, 		
		min(H.estado)as estado, COUNT(A.idOrigen) as ndoc
from	AC_HALLAZGO H
		left join AC_PREGUNTA_VERIFICACION P on (P.idPreguntaVerificacion=H.idPreguntaVerificacion)
		left join AC_ARCHIVO A on (H.idHallazgo = A.idOrigen) and A.tipoOrigen=''H''
		left join AUDITORIA AUD on (H.idAuditoria =  AUD.CODIGO_AUDITORIA)
where	H.estado=''CREADO'' and AUD.ESTADO=''REALIZADO'' AND
		(@anhoAuditoria is null or year(AUD.FECHA_INICIO) = @anhoAuditoria)
group by H.idHallazgo, H.tipoHallazgo
order by 3,1
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_INSERTAR_HALLAZGO]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_INSERTAR_HALLAZGO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ACP_SP_ELIMINAR_HALLAZGO]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ACP_SP_ELIMINAR_HALLAZGO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
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
' 
END
GO
/****** Object:  Table [dbo].[LINEA_BASE_DETALLE]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LINEA_BASE_DETALLE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LINEA_BASE_DETALLE](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_ECS] [int] NULL,
	[CODIGO_RESPONSABLE] [int] NULL,
	[FECHA_ENTREGA] [date] NULL,
	[VERSION_MENOR] [int] NULL,
	[VERSION_MAYOR] [int] NULL,
	[CODIGO_LINEA_BASE] [int] NOT NULL,
	[ROWGUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newid()),
	[DATA] [varbinary](max) FILESTREAM  NULL,
	[NOMBRE] [varchar](50) NULL,
	[EXTENSION] [char](3) NULL,
 CONSTRAINT [PK_LINEA_BASE_DETALLE] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] FILESTREAM_ON [TMD_fg_filestream],
UNIQUE NONCLUSTERED 
(
	[ROWGUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] FILESTREAM_ON [TMD_fg_filestream]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[LINEA_BASE_DETALLE] ON
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (1, 1, 1, CAST(0x7E360B00 AS Date), 0, 1, 1, N'70a7aeab-ea0d-4a15-b2e9-85b998e1cbc9', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (2, 2, 1, CAST(0x7F360B00 AS Date), 1, 1, 1, N'f2f99c22-9a28-4995-92b4-40abfbf6fd61', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (3, 3, 2, CAST(0x7F360B00 AS Date), 0, 1, 1, N'733bfcec-a98f-440e-9e81-779ae1b67bd1', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (4, 8, 2, CAST(0x83360B00 AS Date), 0, 1, 1, N'70f6ceed-8476-4116-9431-a3a39bbb035f', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (5, 9, 2, CAST(0x85360B00 AS Date), 1, 1, 1, N'2a4a8640-343b-4bcc-8dce-50009ab49930', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (6, 10, 2, CAST(0x75360B00 AS Date), 0, 1, 1, N'7a2aeb57-720b-414e-9e84-86664088ba65', NULL, N'DOCUMENTO', N'XLS')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (7, 7, 3, CAST(0x77360B00 AS Date), 1, 1, 1, N'ead1b731-6552-45be-afc8-0a87944ee060', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (8, 3, 2, CAST(0x9D360B00 AS Date), 0, 1, 2, N'296f0ec0-e956-46d3-8b69-fb7b4be7a421', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (9, 4, 2, CAST(0x9E360B00 AS Date), 1, 1, 2, N'6195df94-6ddc-46b9-bce1-4b7024f0c547', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (10, 5, 1, CAST(0x9E360B00 AS Date), 1, 1, 2, N'01e08e5c-a8e2-48ab-a1d8-f5ec307622af', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (11, 6, 1, CAST(0x9A360B00 AS Date), 0, 1, 2, N'7aa18482-644d-41cc-a97b-24f49d6d875f', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (12, 10, 1, CAST(0x9B360B00 AS Date), 1, 1, 2, N'd420eeb7-b31e-4a53-8ca2-c64aadcc71de', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (13, 11, 2, CAST(0x9C360B00 AS Date), 1, 1, 2, N'a17cf84e-12b3-49d5-a66f-8d3eb16a1f14', NULL, N'DOCUMENTO', N'XLS')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (14, 7, 4, CAST(0x9E360B00 AS Date), 1, 1, 2, N'5d2c82b9-bdff-4571-b906-0c11dfd5eb85', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (15, 3, 2, CAST(0xAF360B00 AS Date), 0, 1, 3, N'bf5c607b-d830-45b6-b33e-22664541d730', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (16, 1, 2, CAST(0xB1360B00 AS Date), 1, 1, 3, N'de7b899e-0c12-4eaa-831d-f9d1debf8216', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (17, 2, 1, CAST(0xB3360B00 AS Date), 1, 1, 3, N'1ff6ad56-f044-45d0-bb53-1505807b77c5', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (18, 6, 1, CAST(0xB9360B00 AS Date), 0, 1, 3, N'716f3bd1-7ed3-4e38-a951-a9cb9f298548', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (19, 9, 1, CAST(0xBA360B00 AS Date), 1, 1, 3, N'eae7a940-aba5-41b5-8df6-ec1e1531356e', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (20, 10, 2, CAST(0xB7360B00 AS Date), 1, 1, 3, N'89b3a90e-a08c-42aa-9ba4-c5692abdb488', NULL, N'DOCUMENTO', N'XLS')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (21, 7, 4, CAST(0xB3360B00 AS Date), 1, 1, 3, N'72c9efb2-ced8-4a7d-bdd2-eaa7c3f9205e', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (22, 3, 2, CAST(0xD9360B00 AS Date), 0, 1, 4, N'cd1275dc-0af6-4e29-a133-5309be90b974', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (23, 1, 2, CAST(0xDA360B00 AS Date), 1, 1, 4, N'f3d4d6c6-6613-43d1-9ddc-f57918b95b9b', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (24, 2, 1, CAST(0xDB360B00 AS Date), 1, 1, 4, N'b8885d11-aec0-4a7b-934f-942e58ca06c1', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (25, 6, 1, CAST(0xDC360B00 AS Date), 0, 1, 4, N'cc8b7682-6de6-484d-8468-9e3537747b47', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (26, 9, 1, CAST(0xDC360B00 AS Date), 0, 1, 4, N'eb726f94-a6f5-4e75-9b31-a4c733e2325e', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (27, 8, 2, CAST(0xDD360B00 AS Date), 1, 1, 4, N'fb45435d-53d9-413d-b383-0f5d009fc571', NULL, N'DOCUMENTO', N'XLS')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (28, 7, 4, CAST(0xDE360B00 AS Date), 1, 1, 4, N'23e89422-3175-4bc8-a2d9-c3a1b5634e39', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (29, 1, 2, CAST(0xDD360B00 AS Date), 0, 1, 5, N'65bb2d69-d04a-4836-98f2-a234f6fd4790', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (30, 2, 2, CAST(0xDE360B00 AS Date), 1, 1, 5, N'138ba3cc-234e-4bce-b889-95805d26ad3c', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (31, 6, 3, CAST(0xDF360B00 AS Date), 1, 1, 5, N'8f1d10ae-3238-408d-b4d3-1677c8ca66bb', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (32, 7, 3, CAST(0xE0360B00 AS Date), 0, 1, 5, N'0fb96576-f949-4b10-a5c0-9ae5d1be987c', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (33, 8, 1, CAST(0xE1360B00 AS Date), 0, 1, 5, N'0f63886e-c83e-40f9-b7b1-795fe6e9e7c2', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (34, 4, 2, CAST(0xE2360B00 AS Date), 1, 1, 5, N'046cd6c1-255d-4913-af29-a1a68da67a27', NULL, N'DOCUMENTO', N'XLS')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (35, 3, 4, CAST(0xE3360B00 AS Date), 1, 1, 5, N'473f13d8-f26c-492b-beeb-5d7146625ce2', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (36, 12, 2, CAST(0xFA370B00 AS Date), 0, 1, 6, N'c604ed56-20fe-426b-b060-002600864cd8', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (37, 13, 2, CAST(0xFC370B00 AS Date), 1, 1, 6, N'913c0f66-21be-47bb-915b-ee70a7f8fdc6', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (38, 14, 3, CAST(0xFD370B00 AS Date), 1, 1, 6, N'5842dd9b-e382-41b7-a059-f012840867a0', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (39, 15, 3, CAST(0xFE370B00 AS Date), 0, 1, 6, N'e4186455-ae97-4918-a307-d79844584bd5', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (40, 12, 1, CAST(0xA3360B00 AS Date), 0, 1, 7, N'8b1d40c6-2ff5-4c82-b936-adb5fcc2473d', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (41, 13, 2, CAST(0xA4360B00 AS Date), 1, 1, 7, N'd332b971-c5ea-4d7e-ae0e-3d2d425cf242', NULL, N'DOCUMENTO', N'XLS')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (42, 15, 4, CAST(0xA7360B00 AS Date), 1, 1, 7, N'01b603db-222e-47a8-9719-27fe8db38aab', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (43, 12, 2, CAST(0xBC360B00 AS Date), 0, 1, 8, N'cae1a2d1-4552-457e-bffb-0dcd083ff0c3', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (44, 13, 2, CAST(0xBD360B00 AS Date), 1, 1, 8, N'018ab9d5-41d2-47d4-bae6-5e18771e5688', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (45, 14, 3, CAST(0xBE360B00 AS Date), 1, 1, 8, N'64fc0928-667b-427e-a3fb-4fee9ef5f68f', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (46, 15, 3, CAST(0xBF360B00 AS Date), 0, 1, 8, N'ed653058-40dd-4496-83ee-7e3d092cf1c4', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (47, 17, 2, CAST(0x9D360B00 AS Date), 0, 1, 9, N'76ee3011-c246-4e8f-933d-771b071fb8b6', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (48, 20, 2, CAST(0x9E360B00 AS Date), 1, 1, 9, N'8b1aeee7-a911-4d7a-ae52-5334037bb7d3', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (49, 23, 3, CAST(0x9F360B00 AS Date), 1, 1, 9, N'1bd36a76-e87f-4f0d-95b5-9597b3b4ae6e', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (50, 24, 3, CAST(0xA0360B00 AS Date), 0, 1, 9, N'63486d6c-3d26-4ee4-a915-bfb8d8177c33', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (51, 25, 2, CAST(0x9D360B00 AS Date), 0, 1, 9, N'dab5db7f-7ffd-4a19-9ad6-2d929383af56', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (52, 26, 2, CAST(0x9E360B00 AS Date), 1, 1, 9, N'f93a6293-b0fa-4363-b66e-3c728f81c3a3', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (53, 17, 2, CAST(0xB1360B00 AS Date), 0, 1, 10, N'15c04307-9f5e-404b-a54b-859065ba936a', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (54, 19, 2, CAST(0xB6360B00 AS Date), 0, 1, 10, N'6d388127-9b71-4f99-b1cb-9c57af3a27d7', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (55, 27, 3, CAST(0xB3360B00 AS Date), 1, 1, 10, N'413a8adc-3454-4911-9d33-4f4cb3ed11b3', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (56, 30, 3, CAST(0xB9360B00 AS Date), 1, 1, 10, N'd8e33eeb-cf67-40bb-8050-eacc0aaab49b', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (57, 29, 2, CAST(0xBA360B00 AS Date), 0, 1, 10, N'a53fb8b6-8190-45a0-9ccd-4689a0d0582b', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (58, 22, 2, CAST(0xBB360B00 AS Date), 1, 1, 10, N'bc443a55-33a9-4c87-8f14-1328de5249b6', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (59, 17, 2, CAST(0xCE360B00 AS Date), 0, 1, 11, N'0e21d270-ac59-45db-92fb-e6519c7a06e7', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (60, 19, 2, CAST(0xCE360B00 AS Date), 0, 1, 11, N'd86c1ecb-0496-41e9-b07a-cfb8331b15f6', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (61, 25, 3, CAST(0xCD360B00 AS Date), 1, 1, 11, N'95bac967-a1ba-44b8-bfcd-cd905ab06b6b', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (62, 38, 3, CAST(0xD2360B00 AS Date), 1, 1, 11, N'fe92adb9-c68a-4170-833e-5ff1d93c9cc4', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (63, 29, 2, CAST(0xD4360B00 AS Date), 0, 1, 11, N'816c1d0c-3096-4843-88ee-22f7c184d3df', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (64, 22, 2, CAST(0xD5360B00 AS Date), 1, 1, 11, N'863ce36d-92b2-41e2-b4f9-d9c08d57d66d', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (65, 39, 2, CAST(0xA4360B00 AS Date), 0, 1, 12, N'345e0176-53c9-46c8-aaad-b073b69f15e9', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (66, 40, 2, CAST(0xA5360B00 AS Date), 0, 1, 12, N'c7a0c90c-a064-4024-94e3-1af3e79fd9c9', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (67, 36, 3, CAST(0xA6360B00 AS Date), 1, 1, 12, N'74b294bc-f211-4bf8-b172-4b5235487cb8', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (68, 35, 3, CAST(0x9F360B00 AS Date), 1, 1, 12, N'93a0e398-edc5-4108-af0c-b0a8ead299b4', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (69, 37, 2, CAST(0xA7360B00 AS Date), 0, 1, 12, N'dcc0bf6a-b59a-46a2-a511-daca9287188d', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (70, 33, 2, CAST(0xA7360B00 AS Date), 1, 1, 12, N'322fbfd6-651e-41ab-986f-f21838700768', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (71, 39, 2, CAST(0xC3360B00 AS Date), 0, 1, 13, N'c9fd0287-a976-469f-be43-919223ed4282', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (72, 38, 2, CAST(0xC4360B00 AS Date), 0, 1, 13, N'4d24457d-6cde-4005-8d62-8f391921240c', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (73, 36, 3, CAST(0xC5360B00 AS Date), 1, 1, 13, N'785a2983-bb31-4acf-a3ce-08689a2e988c', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (74, 35, 3, CAST(0xBE360B00 AS Date), 1, 1, 13, N'98af637d-b0e3-4b2e-818a-b6c7308d127f', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (75, 37, 2, CAST(0xBF360B00 AS Date), 0, 1, 13, N'8900bc69-1c13-46c4-ad14-3e98c4e33a22', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (76, 33, 2, CAST(0xBF360B00 AS Date), 1, 1, 13, N'715c1eb5-b1e7-4c3e-b3c6-564fe732f481', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (77, 39, 2, CAST(0xD3360B00 AS Date), 0, 1, 14, N'e0d6a626-5a1f-4e0e-ab21-c1fcca2e2faf', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (78, 38, 2, CAST(0xD3360B00 AS Date), 0, 1, 14, N'93151d40-abe4-463a-9141-5cf4cab00a67', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (79, 36, 3, CAST(0xD4360B00 AS Date), 1, 1, 14, N'11082268-cfdf-4065-b6a0-7b53203df72d', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (80, 35, 3, CAST(0xD4360B00 AS Date), 1, 1, 14, N'8bbaa2f6-7a86-4f25-b30e-176c5592c64b', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (81, 37, 2, CAST(0xD5360B00 AS Date), 0, 1, 14, N'262273f2-7ef4-4857-a3a8-a47eb58b9c5b', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (82, 33, 2, CAST(0xD5360B00 AS Date), 1, 1, 14, N'1b70c093-6a14-4b63-ac9d-fe725956dc8b', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (83, 39, 2, CAST(0xDF360B00 AS Date), 0, 1, 15, N'3aa71426-d647-4c3d-8bde-2058551ecd84', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (84, 40, 2, CAST(0xE0360B00 AS Date), 0, 1, 15, N'8a249278-1dfe-4fcb-b4db-7e8bb2c6d6b8', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (85, 36, 3, CAST(0xE1360B00 AS Date), 1, 1, 15, N'cc747845-dc54-424b-8a4f-47a9ca5b7559', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (86, 35, 3, CAST(0xDA360B00 AS Date), 1, 1, 15, N'8e64faa2-97cd-4631-b6f2-61ce36c87197', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (87, 32, 2, CAST(0xDB360B00 AS Date), 0, 1, 15, N'f31ef22b-1361-48bb-bbaf-2304e4936aac', NULL, N'DOCUMENTO', N'DOC')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (88, 33, 2, CAST(0xDB360B00 AS Date), 1, 1, 15, N'82c3518d-3698-4586-9b12-16ea7f7da315', NULL, N'DOCUMENTO', N'PDF')
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (90, 42, 3, NULL, 0, 1, 16, N'e0f27b2e-6bb9-4fa0-911b-449e4ad32f20', NULL, NULL, NULL)
INSERT [dbo].[LINEA_BASE_DETALLE] ([CODIGO], [CODIGO_ECS], [CODIGO_RESPONSABLE], [FECHA_ENTREGA], [VERSION_MENOR], [VERSION_MAYOR], [CODIGO_LINEA_BASE], [ROWGUID], [DATA], [NOMBRE], [EXTENSION]) VALUES (91, 55, 1, NULL, 0, 1, 17, N'a3f5f732-f69d-4181-8d42-dd795877442b', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[LINEA_BASE_DETALLE] OFF
/****** Object:  Table [dbo].[INFORMACION_SEGUIMIENTO]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INFORMACION_SEGUIMIENTO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[INFORMACION_SEGUIMIENTO](
	[CODIGO_TICKET] [int] NOT NULL,
	[CODIGO_SEGUIMIENTO] [bigint] NOT NULL,
	[FECHA_REGISTRO_INFORMACION_SEGUIMIENTO] [datetime] NOT NULL,
	[DESCRIPCION_INFORMACION_SEGUIMIENTO] [varchar](1000) NOT NULL,
	[CODIGO_EQUIPO] [int] NOT NULL,
	[CODIGO_INTEGRANTE] [int] NOT NULL,
	[TIPO_SEGUIMIENTO] [varchar](30) NOT NULL CONSTRAINT [DF_INFORMACION_SEGUIMIENTO_TIPO_SEGUIMIENTO]  DEFAULT ('SEGUIMIENTO'),
 CONSTRAINT [PK_INFORMACION_SEGUIMIENTO] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_SEGUIMIENTO] ASC,
	[CODIGO_TICKET] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INFORMACION_ADICIONAL]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INFORMACION_ADICIONAL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[INFORMACION_ADICIONAL](
	[CODIGO_TICKET] [int] NOT NULL,
	[CODIGO_INFORMACION_ADICIONAL] [bigint] NOT NULL,
	[FECHA_REGISTRO_INFORMACION_ADICIONAL] [datetime] NOT NULL,
	[DESCRIPCION_INFORMACION_ADICIONAL] [varchar](255) NOT NULL,
	[NOMBRE_ARCHIVO_INFORMACION_ADICIONAL] [varchar](100) NOT NULL,
	[RUTA_INFORMACION_ADICIONAL] [varchar](255) NOT NULL,
	[CODIGO_EQUIPO] [int] NOT NULL,
	[CODIGO_INTEGRANTE] [int] NOT NULL,
 CONSTRAINT [PK_INFORMACION_ADICIONAL] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_INFORMACION_ADICIONAL] ASC,
	[CODIGO_TICKET] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SOLICITUD_CAMBIO]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SOLICITUD_CAMBIO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SOLICITUD_CAMBIO](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NULL,
	[CODIGO_PROYECTO] [int] NULL,
	[CODIGO_LINEA_BASE] [int] NULL,
	[CODIGO_USUARIO] [int] NULL,
	[FECHA_REGISTRO] [date] NULL,
	[FECHA_APROBACION] [date] NULL,
	[ESTADO] [varchar](2) NULL,
	[CODIGO_ECS] [int] NULL,
	[PRIORIDAD] [int] NULL,
	[MOTIVO] [varchar](200) NULL,
	[ROWGUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF__SOLICITUD__ROWGU__70DDC3D8]  DEFAULT (newid()),
	[NOMBRE_ARCHIVO] [varchar](50) NULL,
	[EXTENSION] [char](3) NULL,
	[DATA] [varbinary](max) FILESTREAM  NULL,
 CONSTRAINT [PK__SOLICITU__CC87E127182C9B23] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] FILESTREAM_ON [TMD_fg_filestream],
 CONSTRAINT [UQ__SOLICITU__D7A3AA5572C60C4A] UNIQUE NONCLUSTERED 
(
	[ROWGUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] FILESTREAM_ON [TMD_fg_filestream]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[SOLICITUD_CAMBIO] ON
INSERT [dbo].[SOLICITUD_CAMBIO] ([CODIGO], [NOMBRE], [CODIGO_PROYECTO], [CODIGO_LINEA_BASE], [CODIGO_USUARIO], [FECHA_REGISTRO], [FECHA_APROBACION], [ESTADO], [CODIGO_ECS], [PRIORIDAD], [MOTIVO], [ROWGUID], [NOMBRE_ARCHIVO], [EXTENSION], [DATA]) VALUES (1, N'Solicitud 1', 4, 4, 5, CAST(0xDE360B00 AS Date), CAST(0xE0360B00 AS Date), N'2', 22, 2, N'Aprobado', N'f8dc6e65-742f-436e-9277-11980f4c7e39', N'Solicitud1.rtf', N'rtf', 0x7B5C727466317D)
INSERT [dbo].[SOLICITUD_CAMBIO] ([CODIGO], [NOMBRE], [CODIGO_PROYECTO], [CODIGO_LINEA_BASE], [CODIGO_USUARIO], [FECHA_REGISTRO], [FECHA_APROBACION], [ESTADO], [CODIGO_ECS], [PRIORIDAD], [MOTIVO], [ROWGUID], [NOMBRE_ARCHIVO], [EXTENSION], [DATA]) VALUES (2, N'Solicitud 2', 4, 4, 5, CAST(0xDF360B00 AS Date), CAST(0xE0360B00 AS Date), N'3', 22, 2, N'Rechazo', N'453ef2b9-3c6e-4d4a-80a9-c5284877e88d', N'Solicitud2.rtf', N'rtf', 0x7B5C727466317D)
INSERT [dbo].[SOLICITUD_CAMBIO] ([CODIGO], [NOMBRE], [CODIGO_PROYECTO], [CODIGO_LINEA_BASE], [CODIGO_USUARIO], [FECHA_REGISTRO], [FECHA_APROBACION], [ESTADO], [CODIGO_ECS], [PRIORIDAD], [MOTIVO], [ROWGUID], [NOMBRE_ARCHIVO], [EXTENSION], [DATA]) VALUES (3, N'Solicitud 3', 2, 13, 5, CAST(0xDF360B00 AS Date), NULL, N'1', 75, 3, NULL, N'95e45c3f-f248-4996-9d59-0213502db091', N'Solicitud2.rtf', N'rtf', 0x7B5C727466317D)
INSERT [dbo].[SOLICITUD_CAMBIO] ([CODIGO], [NOMBRE], [CODIGO_PROYECTO], [CODIGO_LINEA_BASE], [CODIGO_USUARIO], [FECHA_REGISTRO], [FECHA_APROBACION], [ESTADO], [CODIGO_ECS], [PRIORIDAD], [MOTIVO], [ROWGUID], [NOMBRE_ARCHIVO], [EXTENSION], [DATA]) VALUES (4, N'Solicitud 4', 2, 7, 5, CAST(0xDF360B00 AS Date), CAST(0xE0360B00 AS Date), N'2', 41, 2, N'Aprobar', N'bb4178af-6df3-466f-8e0b-d54f71590388', N'Solicitud1.rtf', N'rtf', 0x7B5C727466317D)
SET IDENTITY_INSERT [dbo].[SOLICITUD_CAMBIO] OFF
/****** Object:  Table [dbo].[TICKET_LECCION_APRENDIDA]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TICKET_LECCION_APRENDIDA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TICKET_LECCION_APRENDIDA](
	[CODIGO_TICKET] [int] NOT NULL,
	[CODIGO_LECCION_APRENDIDA] [int] NOT NULL,
 CONSTRAINT [PK_TICKET_LECCION_APRENDIDA] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_TICKET] ASC,
	[CODIGO_LECCION_APRENDIDA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TICKET_CMDB]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TICKET_CMDB]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TICKET_CMDB](
	[CODIGO_CMDB] [int] NOT NULL,
	[CODIGO_TICKET] [int] NOT NULL,
 CONSTRAINT [PK_TICKET_CMDB] PRIMARY KEY NONCLUSTERED 
(
	[CODIGO_CMDB] ASC,
	[CODIGO_TICKET] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_DETALLE_UPD_ARCHIVO]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_DETALLE_UPD_ARCHIVO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_LINEA_BASE_DETALLE_UPD_ARCHIVO]
@CODIGO INT,
@NOMBRE VARCHAR(50),
@EXTENSION CHAR(3),
@RUTA_ARCHIVO VARCHAR(MAX) OUTPUT,
@TRANSACTION_CONTEXT VARBINARY(MAX) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;	
	
	UPDATE 
		dbo.LINEA_BASE_DETALLE
	SET 
		NOMBRE = @NOMBRE,
		EXTENSION = @EXTENSION,
		DATA = CAST('''' AS VARBINARY(MAX))
	WHERE
		CODIGO = @CODIGO;
		
	SELECT 
		@RUTA_ARCHIVO = DATA.PathName(),
		@TRANSACTION_CONTEXT = GET_FILESTREAM_TRANSACTION_CONTEXT()
	FROM 
		dbo.LINEA_BASE_DETALLE
	WHERE 
		CODIGO = @CODIGO;

	SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_DETALLE_SEL_ARCHIVO]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_DETALLE_SEL_ARCHIVO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_LINEA_BASE_DETALLE_SEL_ARCHIVO]
@CODIGO INT
AS
BEGIN
	SET NOCOUNT ON;	
	
	SELECT
		NOMBRE,
		DATA.PathName() AS RUTA_ARCHIVO,
		GET_FILESTREAM_TRANSACTION_CONTEXT() AS TRANSACTION_CONTEXT
	FROM 
		dbo.LINEA_BASE_DETALLE
	WHERE 
		CODIGO = @CODIGO;

	SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_DETALLE_INS]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_DETALLE_INS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[USP_LINEA_BASE_DETALLE_INS]
@CODIGO INT OUTPUT,
@CODIGO_ECS INT,
@CODIGO_RESPONSABLE INT,
@VERSION_MENOR INT,
@VERSION_MAYOR INT,
@CODIGO_LINEA_BASE INT
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO dbo.LINEA_BASE_DETALLE(
			CODIGO_ECS, 
			CODIGO_RESPONSABLE,
			VERSION_MENOR, 
			VERSION_MAYOR, 
			CODIGO_LINEA_BASE)
	VALUES(
		@CODIGO_ECS, 
		@CODIGO_RESPONSABLE,
		@VERSION_MENOR, 
		@VERSION_MAYOR, 
		@CODIGO_LINEA_BASE);
		
	SET @CODIGO = SCOPE_IDENTITY();

	SET NOCOUNT OFF;

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_DET_SEL_CODIGO_LINEA_BASE]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_DET_SEL_CODIGO_LINEA_BASE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_LINEA_BASE_DET_SEL_CODIGO_LINEA_BASE] 
@CODIGO_LINEA_BASE INT,  
@CODIGO_USUARIO INT  
AS  
BEGIN  
  
 SET NOCOUNT ON;  
  
 SELECT DISTINCT  
  LBD.CODIGO,   
  LBD.CODIGO_ECS,   
  EC.DESCRIPCION AS ECS_NOMBRE,  
  EC.TIPO,  
  LBD.CODIGO_RESPONSABLE,   
  LBD.FECHA_ENTREGA,   
  LBD.VERSION_MENOR,   
  LBD.VERSION_MAYOR,   
  LBD.CODIGO_LINEA_BASE,  
  LBD.NOMBRE,  
  LBD.EXTENSION ,
  PF.FECHA_FIN 
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_DET_SEL_CODIGO]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_DET_SEL_CODIGO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_LINEA_BASE_DET_SEL_CODIGO]
@CODIGO INT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
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
		LBD.EXTENSION,
		PF.FECHA_FIN
	FROM
		dbo.LINEA_BASE_DETALLE AS LBD
		INNER JOIN dbo.LINEA_BASE AS LB
		ON LBD.CODIGO_LINEA_BASE = LB.CODIGO
		INNER JOIN dbo.PROYECTO_FASE AS PF
		ON LB.CODIGO_PROYECTO_FASE = PF.CODIGO
		INNER JOIN dbo.ELEMENTO_CONFIGURACION AS EC
		ON LBD.CODIGO_ECS = EC.CODIGO
	WHERE
		LBD.CODIGO = @CODIGO;
		

	SET NOCOUNT OFF;

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LINEA_BASE_DET_DEL_CODIGO_LINEA_BASE]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LINEA_BASE_DET_DEL_CODIGO_LINEA_BASE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[USP_LINEA_BASE_DET_DEL_CODIGO_LINEA_BASE]
@CODIGO_LINEA_BASE INT
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM
		dbo.LINEA_BASE_DETALLE
	WHERE
		CODIGO_LINEA_BASE = @CODIGO_LINEA_BASE;

	SET NOCOUNT OFF;

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_DatosTicket]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_DatosTicket]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Ticket_DatosTicket]
	@TICKET	bigint
AS
	DECLARE @RETCODE_PROCESO int;
	IF
		@TICKET	IS NULL
	BEGIN
		RETURN (255);
	END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SELECT A.CODIGO_TICKET, L.CODIGO_CLIENTE, L.RAZON_SOCIAL, I.CODIGO_USUARIO_CLIENTE, I.ALIAS_USUARIO_CLIENTE, I.NOMBRE_USUARIO_CLIENTE,
	       A.DESCRIPCION_CORTA_TICKET, A.DESCRIPCION_TICKET, A.TIPO_REGISTRO_TICKET, A.TIPO_ATENCION_TICKET, A.FECHA_REGISTRO_TICKET,
	       A.FECHA_EXPIRACION_TICKET, A.PRIORIDAD_TICKET, A.ESTADO_TICKET, A.CODIGO_EQUIPO,A.SOLUCION_TICKET ,A.CODIGO_SEDE, 
	       K.URGENCIA_DETALLE_SLA, K.IMPACTO_DETALLE_SLA, K.COMPLEJIDAD_DETALLE_SLA, K.TIEMPO_RESPUESTA_DETALLE_SLA, K.TIEMPO_CIERRE_DETALLE_SLA,
	       B.NIVEL_INTEGRANTE as Nivel_Propietario, A.CODIGO_PROYECTO,A.CODIGO_SERVICIO,  
	       M.NOMBRE_PERSONA + '' '' + M.APELLIDO_PATERNO + '' '' + M.APELLIDO_MATERNO AS Empleado_Propietario,
	       C.NIVEL_INTEGRANTE as Nivel_Asignado,
	       N.NOMBRE_PERSONA + '' '' + N.APELLIDO_PATERNO + '' '' + N.APELLIDO_MATERNO AS Empleado_Asignado,
               D.NIVEL_INTEGRANTE as Nivel_Ult_Modif, 
	       O.NOMBRE_PERSONA + '' '' + O.APELLIDO_PATERNO + '' '' + O.APELLIDO_MATERNO AS Empleado_Ult_Modif,
	       H.NOMBRE_SERVICIO,ULTIMA_SECUENCIA_SEGUIMIENTO_TICKET,ULTIMA_SECUENCIA_ADICIONAL_TICKET  
               FROM [dbo].[TICKET] AS A
                INNER JOIN [dbo].[INTEGRANTE] AS B ON A.CODIGO_EQUIPO = B.CODIGO_EQUIPO AND A.CREADO_POR_CODIGO_INTEGRANTE = B.CODIGO_INTEGRANTE
                INNER JOIN [dbo].[INTEGRANTE] AS C ON A.CODIGO_EQUIPO = C.CODIGO_EQUIPO AND A.ASIGNADO_A_CODIGO_INTEGRANTE = C.CODIGO_INTEGRANTE
                INNER JOIN [dbo].[INTEGRANTE] AS D ON A.CODIGO_EQUIPO = D.CODIGO_EQUIPO AND A.ULTIMO_CAMBIO_CODIGO_INTEGRANTE = D.CODIGO_INTEGRANTE
                INNER JOIN [dbo].[EMPLEADO]  AS E ON B.CODIGO_EMPLEADO = E.CODIGO_EMPLEADO
                INNER JOIN [dbo].[EMPLEADO]  AS F ON C.CODIGO_EMPLEADO = F.CODIGO_EMPLEADO
                INNER JOIN [dbo].[EMPLEADO]  AS G ON D.CODIGO_EMPLEADO = G.CODIGO_EMPLEADO
                INNER JOIN [dbo].[SERVICIO]   AS H ON A.CODIGO_SERVICIO = H.CODIGO_SERVICIO
		INNER JOIN [dbo].[USUARIO_CLIENTE] AS I ON A.CODIGO_CLIENTE = I.CODIGO_CLIENTE AND A.CODIGO_USUARIO_CLIENTE = I.CODIGO_USUARIO_CLIENTE
		INNER JOIN [dbo].[PROYECTO_SERVICIO_SEDE] AS J ON A.CODIGO_PROYECTO = J.CODIGO_PROYECTO AND A.CODIGO_SERVICIO = J.CODIGO_SERVICIO AND A.CODIGO_SEDE = J.CODIGO_SEDE
		INNER JOIN [dbo].[DETALLE_SLA] AS K ON J.CODIGO_SLA = K.CODIGO_SLA AND J.CODIGO_DETALLE_SLA = K.CODIGO_DETALLE_SLA
		INNER JOIN [dbo].[CLIENTE] AS L ON A.CODIGO_CLIENTE = L.CODIGO_CLIENTE
		INNER JOIN [dbo].[PERSONA] AS M ON E.CODIGO_EMPLEADO = M.CODIGO_PERSONA
		INNER JOIN [dbo].[PERSONA] AS N ON F.CODIGO_EMPLEADO = N.CODIGO_PERSONA
		INNER JOIN [dbo].[PERSONA] AS O ON G.CODIGO_EMPLEADO = O.CODIGO_PERSONA
	WHERE A.CODIGO_TICKET = @TICKET;
	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_CambiarEstado]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_CambiarEstado]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Ticket_CambiarEstado]
	@TICKET			bigint,
	@ESTADO			varchar(15),
	@EQUIPO			bigint,
	@INTEGRANTE		bigint
AS
	DECLARE @RETCODE_PROCESO int, @ESTADO_ACTUAL varchar(15), @EQUIPO_ACTUAL bigint;
	IF
		@TICKET		IS NULL OR	
		@ESTADO		IS NULL OR
		@EQUIPO		IS NULL OR
		@INTEGRANTE	IS NULL
	BEGIN
		RETURN (255);
	END
	IF
		@ESTADO NOT IN (''ABIERTO'', ''EN PROCESO'', ''EN ESPERA'', ''DEVUELTO'', ''RECHAZADO'', ''SOLUCIONADO'', ''CERRADO'', ''ANULADO'')
	BEGIN
		RETURN (241);
	END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SET @ESTADO_ACTUAL = (SELECT ESTADO_TICKET FROM [dbo].[TICKET] WHERE CODIGO_TICKET = @TICKET);
	SET @RETCODE_PROCESO = @@ERROR;
	IF (@RETCODE_PROCESO <> 0)
	BEGIN
		RETURN @RETCODE_PROCESO;
	END
	IF (@ESTADO_ACTUAL IS NULL)
	BEGIN
		RETURN (240);
	END
	
	IF
		(@ESTADO = ''ABIERTO''     AND @ESTADO_ACTUAL NOT IN (''SOLUCIONADO'', ''DEVUELTO'', ''RECHAZADO'')) OR
		(@ESTADO = ''EN PROCESO''  AND @ESTADO_ACTUAL NOT IN (''ABIERTO'', ''EN ESPERA'')) OR
		(@ESTADO = ''EN ESPERA''   AND @ESTADO_ACTUAL <> ''EN PROCESO'') OR
		(@ESTADO = ''DEVUELTO''    AND @ESTADO_ACTUAL <> ''EN PROCESO'') OR
		(@ESTADO = ''RECHAZADO''   AND @ESTADO_ACTUAL <> ''EN PROCESO'') OR
		(@ESTADO = ''SOLUCIONADO'' AND @ESTADO_ACTUAL NOT IN (''EN PROCESO'', ''EN ESPERA'')) OR
		(@ESTADO = ''CERRADO''     AND @ESTADO_ACTUAL <> ''SOLUCIONADO'') OR
		(@ESTADO = ''ANULADO''     AND @ESTADO_ACTUAL NOT IN (''ABIERTO'', ''EN PROCESO'', ''EN ESPERA'', ''DEVUELTO'', ''RECHAZADO''))
	BEGIN
		RETURN (239);
	END

	SET @EQUIPO_ACTUAL = (SELECT CODIGO_EQUIPO FROM [dbo].[TICKET] WHERE CODIGO_TICKET = @TICKET);
	SET @RETCODE_PROCESO = @@ERROR;
	IF (@RETCODE_PROCESO <> 0)
	BEGIN
		RETURN @RETCODE_PROCESO;
	END
	IF (@EQUIPO_ACTUAL IS NULL)
	BEGIN
		RETURN (238);
	END
	IF (@EQUIPO_ACTUAL <> @EQUIPO)
	BEGIN
		RETURN (237);
	END

	UPDATE [dbo].[TICKET]
	SET
		ESTADO_TICKET = @ESTADO,
		FECHA_INICIO_TICKET   = CASE 
									WHEN @ESTADO_ACTUAL = ''ABIERTO'' AND @ESTADO = ''EN PROCESO'' AND FECHA_INICIO_TICKET IS NULL
		                            THEN GETDATE()
		                            ELSE FECHA_INICIO_TICKET
		                        END,
		FECHA_CIERRE_TICKET   = CASE
									WHEN @ESTADO_ACTUAL = ''SOLUCIONADO'' AND @ESTADO = ''CERRADO''
		                            THEN GETDATE()
		                            ELSE FECHA_CIERRE_TICKET
		                        END,
		FECHA_SOLUCION_TICKET = CASE
									WHEN @ESTADO = ''SOLUCIONADO''
		                            THEN GETDATE()
		                            ELSE FECHA_SOLUCION_TICKET
		                        END,
		ULTIMO_CAMBIO_CODIGO_INTEGRANTE = @INTEGRANTE
	WHERE CODIGO_TICKET = @TICKET;
	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_AgregarTicket]    Script Date: 03/23/2013 16:50:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_AgregarTicket]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Ticket_AgregarTicket]
    @FECHA_REGISTRO    datetime,
	@TIPO_REGISTRO		varchar(20),
	@TIPO_ATENCION		varchar(20),
	@FECHA_EXPIRACION	datetime,
	@DESCRIPCION_CORTA	varchar(50),
	@DESCRIPCION_LARGA	varchar(1000),
	@TIEMPO_RESOLUCION	int,
	@PRIORIDAD		int,
	@CLIENTE		bigint,
	@USUARIO		bigint,
	@SERVICIO		bigint,
	@PROYECTO		bigint,
	@EQUIPO			bigint,
	@INTEGRANTE		bigint,
	@CODIGOTICKET   bigint out
AS
	DECLARE @RETCODE_PROCESO int, @SEDE bigint;
	IF
		@FECHA_REGISTRO	IS NULL OR
		@TIPO_REGISTRO		IS NULL OR
		@TIPO_ATENCION		IS NULL OR
		@FECHA_EXPIRACION	IS NULL OR
		@DESCRIPCION_CORTA	IS NULL OR
		@DESCRIPCION_LARGA	IS NULL OR
		@TIEMPO_RESOLUCION	IS NULL OR
		@PRIORIDAD		IS NULL OR
		@CLIENTE		IS NULL OR
		@USUARIO		IS NULL OR
		@SERVICIO		IS NULL OR
		@PROYECTO		IS NULL OR
		@EQUIPO			IS NULL OR
		@INTEGRANTE		IS NULL
	BEGIN
		RETURN (255);
	END
	IF
		@TIPO_REGISTRO		NOT IN (''CORREO'', ''TELEFONO'', ''CARTA'', ''INTERNET'')
	BEGIN
		RETURN (249);
	END
	IF
		@TIPO_ATENCION		NOT IN (''INCIDENTE'', ''CONSULTA'', ''REQUERIMIENTO'', ''PROBLEMA'')
	BEGIN
		RETURN (248);
	END
	--IF
	--	@FECHA_EXPIRACION < GETDATE()
	--BEGIN
	--	RETURN (247);
	--END
	--IF
	--	LEN(@DESCRIPCION_CORTA) < 5
	--BEGIN
	--	RETURN (246);
	--END
	--IF
	--	LEN(@DESCRIPCION_LARGA) < 15
	--BEGIN
	--	RETURN (245);
	--END
	--IF
	--	@TIEMPO_RESOLUCION < 5
	--BEGIN
	--	RETURN (244);
	--END
	--IF
	--	@PRIORIDAD <1 OR @PRIORIDAD > 50
	--BEGIN
	--	RETURN (243);
	--END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SET @SEDE = (SELECT CODIGO_SEDE FROM [dbo].[USUARIO_CLIENTE]
				 WHERE CODIGO_CLIENTE = @CLIENTE AND CODIGO_USUARIO_CLIENTE = @USUARIO);
	SET @RETCODE_PROCESO = @@ERROR;
	IF (@RETCODE_PROCESO <> 0)
	BEGIN
		RETURN @RETCODE_PROCESO;
	END
	IF (@SEDE IS NULL)
	BEGIN
		RETURN (242);
	END

    --''//GETDATE() 
	INSERT INTO [dbo].[TICKET] (TIPO_REGISTRO_TICKET, TIPO_ATENCION_TICKET, FECHA_REGISTRO_TICKET, FECHA_EXPIRACION_TICKET,
				   FECHA_INICIO_TICKET, FECHA_CIERRE_TICKET, FECHA_SOLUCION_TICKET, DESCRIPCION_CORTA_TICKET,
				   DESCRIPCION_TICKET, TIEMPO_RESOLUCION_TICKET, PRIORIDAD_TICKET, SOLUCION_TICKET,
				   ULTIMA_SECUENCIA_SEGUIMIENTO_TICKET, ULTIMA_SECUENCIA_ADICIONAL_TICKET, ESTADO_TICKET,
				   SATISFACCION_SERVICIO_TICKET, CODIGO_CLIENTE, CODIGO_USUARIO_CLIENTE, CODIGO_SERVICIO,
				   CODIGO_PROYECTO, CODIGO_SEDE, CODIGO_EQUIPO, CREADO_POR_CODIGO_INTEGRANTE,
				   ASIGNADO_A_CODIGO_INTEGRANTE, ULTIMO_CAMBIO_CODIGO_INTEGRANTE)
	VALUES (@TIPO_REGISTRO, @TIPO_ATENCION, @FECHA_REGISTRO, @FECHA_EXPIRACION,
		NULL, NULL, NULL, @DESCRIPCION_CORTA,
		@DESCRIPCION_LARGA, @TIEMPO_RESOLUCION, @PRIORIDAD, NULL,
		0, 0, ''ABIERTO'', 
		NULL, @CLIENTE, @USUARIO, @SERVICIO,
		@PROYECTO, @SEDE, @EQUIPO, @INTEGRANTE,
		@INTEGRANTE, @INTEGRANTE);
	SET @CODIGOTICKET = @@IDENTITY	
	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_ListaTicketsIntegranteProyecto]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_ListaTicketsIntegranteProyecto]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Ticket_ListaTicketsIntegranteProyecto]
	@PROYECTO	bigint,
	@EQUIPO		bigint,
	@INTEGRANTE	bigint,
	@TIPO_TICKET	varchar(20) = NULL,
	@ESTADO		varchar(15) = NULL,
	@FECHA_REGINI	datetime = NULL,
	@FECHA_REGFIN	datetime = NULL
AS
	DECLARE @RETCODE_PROCESO int;
	IF
		@PROYECTO	IS NULL OR
		@EQUIPO		IS NULL OR
		@INTEGRANTE	IS NULL
	BEGIN
		RETURN (255);
	END
	IF
		(@TIPO_TICKET IS NOT NULL) AND
		(@TIPO_TICKET NOT IN (''INCIDENTE'', ''CONSULTA'', ''REQUERIMIENTO'', ''PROBLEMA''))
	BEGIN
		RETURN (248);
	END
	IF
		(@ESTADO IS NOT NULL) AND
		(@ESTADO NOT IN (''ABIERTO'', ''EN PROCESO'', ''EN ESPERA'', ''DEVUELTO'', ''RECHAZADO'', ''SOLUCIONADO'', ''CERRADO'', ''ANULADO''))
	BEGIN
		RETURN (241);
	END
	IF
		(@FECHA_REGINI IS NOT NULL) AND
		(@FECHA_REGFIN IS NOT NULL) AND
		(@FECHA_REGFIN < @FECHA_REGINI )
	BEGIN
		RETURN (236);
	END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SELECT DISTINCT
	       	A.CODIGO_TICKET, L.CODIGO_CLIENTE, L.RAZON_SOCIAL, I.CODIGO_USUARIO_CLIENTE, I.ALIAS_USUARIO_CLIENTE, I.NOMBRE_USUARIO_CLIENTE,
		A.DESCRIPCION_CORTA_TICKET, A.DESCRIPCION_TICKET, A.TIPO_REGISTRO_TICKET, A.TIPO_ATENCION_TICKET, A.FECHA_REGISTRO_TICKET, 
		A.FECHA_EXPIRACION_TICKET, A.PRIORIDAD_TICKET, A.ESTADO_TICKET, A.CODIGO_EQUIPO,A.SOLUCION_TICKET,A.CODIGO_PROYECTO, A.CODIGO_SERVICIO,A.CODIGO_SEDE, 
	        K.URGENCIA_DETALLE_SLA, K.IMPACTO_DETALLE_SLA, K.COMPLEJIDAD_DETALLE_SLA, K.TIEMPO_RESPUESTA_DETALLE_SLA, K.TIEMPO_CIERRE_DETALLE_SLA,
	        B.NIVEL_INTEGRANTE as Nivel_Propietario, E.CODIGO_EMPLEADO as CodEmp_Propietario,
	        M.NOMBRE_PERSONA + '' '' + M.APELLIDO_PATERNO + '' '' + M.APELLIDO_MATERNO AS Empleado_Propietario,
	        C.NIVEL_INTEGRANTE as Nivel_Asignado,    F.CODIGO_EMPLEADO as CodEmp_Asignado,
 		N.NOMBRE_PERSONA + '' '' + N.APELLIDO_PATERNO + '' '' + N.APELLIDO_MATERNO AS Empleado_Asignado,
                D.NIVEL_INTEGRANTE as Nivel_Ult_Modif,   G.CODIGO_EMPLEADO as CodEmp_UltModif,
		O.NOMBRE_PERSONA + '' '' + O.APELLIDO_PATERNO + '' '' + O.APELLIDO_MATERNO AS Empleado_Ult_Modif,
	        H.NOMBRE_SERVICIO,ULTIMA_SECUENCIA_SEGUIMIENTO_TICKET,ULTIMA_SECUENCIA_ADICIONAL_TICKET 
               FROM [dbo].[TICKET] AS A
                INNER JOIN [dbo].[INTEGRANTE] AS B ON A.CODIGO_EQUIPO = B.CODIGO_EQUIPO AND A.CREADO_POR_CODIGO_INTEGRANTE = B.CODIGO_INTEGRANTE
                INNER JOIN [dbo].[INTEGRANTE] AS C ON A.CODIGO_EQUIPO = C.CODIGO_EQUIPO AND A.ASIGNADO_A_CODIGO_INTEGRANTE = C.CODIGO_INTEGRANTE
                INNER JOIN [dbo].[INTEGRANTE] AS D ON A.CODIGO_EQUIPO = D.CODIGO_EQUIPO AND A.ULTIMO_CAMBIO_CODIGO_INTEGRANTE = D.CODIGO_INTEGRANTE
                INNER JOIN [dbo].[EMPLEADO]  AS E ON B.CODIGO_EMPLEADO = E.CODIGO_EMPLEADO
                INNER JOIN [dbo].[EMPLEADO]  AS F ON C.CODIGO_EMPLEADO = F.CODIGO_EMPLEADO
                INNER JOIN [dbo].[EMPLEADO]  AS G ON D.CODIGO_EMPLEADO = G.CODIGO_EMPLEADO
                INNER JOIN [dbo].[SERVICIO]   AS H ON A.CODIGO_SERVICIO = H.CODIGO_SERVICIO
		INNER JOIN [dbo].[USUARIO_CLIENTE] AS I ON A.CODIGO_CLIENTE = I.CODIGO_CLIENTE AND A.CODIGO_USUARIO_CLIENTE = I.CODIGO_USUARIO_CLIENTE
		INNER JOIN [dbo].[PROYECTO_SERVICIO_SEDE] AS J ON A.CODIGO_PROYECTO = J.CODIGO_PROYECTO AND A.CODIGO_SERVICIO = J.CODIGO_SERVICIO AND A.CODIGO_SEDE = J.CODIGO_SEDE
		INNER JOIN [dbo].[DETALLE_SLA] AS K ON J.CODIGO_SLA = K.CODIGO_SLA AND J.CODIGO_DETALLE_SLA = K.CODIGO_DETALLE_SLA
		INNER JOIN [dbo].[CLIENTE] AS L ON A.CODIGO_CLIENTE = L.CODIGO_CLIENTE
		INNER JOIN [dbo].[PERSONA] AS M ON E.CODIGO_EMPLEADO = M.CODIGO_PERSONA
		INNER JOIN [dbo].[PERSONA] AS N ON F.CODIGO_EMPLEADO = N.CODIGO_PERSONA
		INNER JOIN [dbo].[PERSONA] AS O ON G.CODIGO_EMPLEADO = O.CODIGO_PERSONA
	WHERE A.CODIGO_PROYECTO = @PROYECTO AND
	      A.CODIGO_EQUIPO = @EQUIPO AND
	      ((A.CREADO_POR_CODIGO_INTEGRANTE = @INTEGRANTE) OR (A.ASIGNADO_A_CODIGO_INTEGRANTE = @INTEGRANTE) OR (A.ULTIMO_CAMBIO_CODIGO_INTEGRANTE = @INTEGRANTE)) AND
	      (@TIPO_TICKET  IS NULL OR A.TIPO_ATENCION_TICKET = @TIPO_TICKET   ) AND
	      (@ESTADO       IS NULL OR A.ESTADO_TICKET = @ESTADO               ) AND
	      (@FECHA_REGINI IS NULL OR A.FECHA_REGISTRO_TICKET >= @FECHA_REGINI) AND
	      (@FECHA_REGFIN IS NULL OR A.FECHA_REGISTRO_TICKET <= @FECHA_REGFIN)
	ORDER BY A.CODIGO_TICKET;
	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_ListaTicketsIntegrante]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_ListaTicketsIntegrante]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Ticket_ListaTicketsIntegrante]
	
	@INTEGRANTE	bigint,
	@TIPO_TICKET	varchar(20) = NULL,
	@ESTADO		varchar(15) = NULL,
	@FECHA_REGINI	datetime = NULL,
	@FECHA_REGFIN	datetime = NULL
AS
	DECLARE @RETCODE_PROCESO int;
	IF
			@INTEGRANTE	IS NULL
	BEGIN
		RETURN (255);
	END
	IF
		(@TIPO_TICKET IS NOT NULL) AND
		(@TIPO_TICKET NOT IN (''INCIDENTE'', ''CONSULTA'', ''REQUERIMIENTO'', ''PROBLEMA''))
	BEGIN
		RETURN (248);
	END
	IF
		(@ESTADO IS NOT NULL) AND
		(@ESTADO NOT IN (''ABIERTO'', ''EN PROCESO'', ''EN ESPERA'', ''DEVUELTO'', ''RECHAZADO'', ''SOLUCIONADO'', ''CERRADO'',''ASIGNADO'', ''ANULADO''))
	BEGIN
		RETURN (241);
	END
	IF
		(@FECHA_REGINI IS NOT NULL) AND
		(@FECHA_REGFIN IS NOT NULL) AND
		(@FECHA_REGFIN < @FECHA_REGINI )
	BEGIN
		RETURN (236);
	END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SELECT DISTINCT
	       	A.CODIGO_TICKET, L.CODIGO_CLIENTE, L.RAZON_SOCIAL, I.CODIGO_USUARIO_CLIENTE, I.ALIAS_USUARIO_CLIENTE, I.NOMBRE_USUARIO_CLIENTE,
		A.DESCRIPCION_CORTA_TICKET, A.DESCRIPCION_TICKET, A.TIPO_REGISTRO_TICKET, A.TIPO_ATENCION_TICKET, A.FECHA_REGISTRO_TICKET, 
		A.FECHA_EXPIRACION_TICKET, A.PRIORIDAD_TICKET, A.ESTADO_TICKET, A.CODIGO_EQUIPO,A.SOLUCION_TICKET,A.CODIGO_PROYECTO,A.CODIGO_SERVICIO, A.CODIGO_SEDE, 
	        K.URGENCIA_DETALLE_SLA, K.IMPACTO_DETALLE_SLA, K.COMPLEJIDAD_DETALLE_SLA, K.TIEMPO_RESPUESTA_DETALLE_SLA, K.TIEMPO_CIERRE_DETALLE_SLA,
	        B.NIVEL_INTEGRANTE as Nivel_Propietario, E.CODIGO_EMPLEADO as CodEmp_Propietario,
	        M.NOMBRE_PERSONA + '' '' + M.APELLIDO_PATERNO + '' '' + M.APELLIDO_MATERNO AS Empleado_Propietario,
	        C.NIVEL_INTEGRANTE as Nivel_Asignado,    F.CODIGO_EMPLEADO as CodEmp_Asignado,
 		N.NOMBRE_PERSONA + '' '' + N.APELLIDO_PATERNO + '' '' + N.APELLIDO_MATERNO AS Empleado_Asignado,
                D.NIVEL_INTEGRANTE as Nivel_Ult_Modif,   G.CODIGO_EMPLEADO as CodEmp_UltModif,
		O.NOMBRE_PERSONA + '' '' + O.APELLIDO_PATERNO + '' '' + O.APELLIDO_MATERNO AS Empleado_Ult_Modif,
	        H.NOMBRE_SERVICIO,ULTIMA_SECUENCIA_SEGUIMIENTO_TICKET,ULTIMA_SECUENCIA_ADICIONAL_TICKET 
               FROM [dbo].[TICKET] AS A
                INNER JOIN [dbo].[INTEGRANTE] AS B ON A.CODIGO_EQUIPO = B.CODIGO_EQUIPO AND A.CREADO_POR_CODIGO_INTEGRANTE = B.CODIGO_INTEGRANTE
                INNER JOIN [dbo].[INTEGRANTE] AS C ON A.CODIGO_EQUIPO = C.CODIGO_EQUIPO AND A.ASIGNADO_A_CODIGO_INTEGRANTE = C.CODIGO_INTEGRANTE
                INNER JOIN [dbo].[INTEGRANTE] AS D ON A.CODIGO_EQUIPO = D.CODIGO_EQUIPO AND A.ULTIMO_CAMBIO_CODIGO_INTEGRANTE = D.CODIGO_INTEGRANTE
                INNER JOIN [dbo].[EMPLEADO]  AS E ON B.CODIGO_EMPLEADO = E.CODIGO_EMPLEADO
                INNER JOIN [dbo].[EMPLEADO]  AS F ON C.CODIGO_EMPLEADO = F.CODIGO_EMPLEADO
                INNER JOIN [dbo].[EMPLEADO]  AS G ON D.CODIGO_EMPLEADO = G.CODIGO_EMPLEADO
                INNER JOIN [dbo].[SERVICIO]   AS H ON A.CODIGO_SERVICIO = H.CODIGO_SERVICIO
		INNER JOIN [dbo].[USUARIO_CLIENTE] AS I ON A.CODIGO_CLIENTE = I.CODIGO_CLIENTE AND A.CODIGO_USUARIO_CLIENTE = I.CODIGO_USUARIO_CLIENTE
		INNER JOIN [dbo].[PROYECTO_SERVICIO_SEDE] AS J ON A.CODIGO_PROYECTO = J.CODIGO_PROYECTO AND A.CODIGO_SERVICIO = J.CODIGO_SERVICIO AND A.CODIGO_SEDE = J.CODIGO_SEDE
		INNER JOIN [dbo].[DETALLE_SLA] AS K ON J.CODIGO_SLA = K.CODIGO_SLA AND J.CODIGO_DETALLE_SLA = K.CODIGO_DETALLE_SLA
		INNER JOIN [dbo].[CLIENTE] AS L ON A.CODIGO_CLIENTE = L.CODIGO_CLIENTE
		INNER JOIN [dbo].[PERSONA] AS M ON E.CODIGO_EMPLEADO = M.CODIGO_PERSONA
		INNER JOIN [dbo].[PERSONA] AS N ON F.CODIGO_EMPLEADO = N.CODIGO_PERSONA
		INNER JOIN [dbo].[PERSONA] AS O ON G.CODIGO_EMPLEADO = O.CODIGO_PERSONA
	WHERE ((A.CREADO_POR_CODIGO_INTEGRANTE = @INTEGRANTE) OR (A.ASIGNADO_A_CODIGO_INTEGRANTE = @INTEGRANTE) OR (A.ULTIMO_CAMBIO_CODIGO_INTEGRANTE = @INTEGRANTE)) AND
	      (@TIPO_TICKET  IS NULL OR A.TIPO_ATENCION_TICKET = @TIPO_TICKET   ) AND
	      (@ESTADO       IS NULL OR A.ESTADO_TICKET = @ESTADO               ) AND
	      (@FECHA_REGINI IS NULL OR A.FECHA_REGISTRO_TICKET >= @FECHA_REGINI) AND
	      (@FECHA_REGFIN IS NULL OR A.FECHA_REGISTRO_TICKET <= @FECHA_REGFIN)
	ORDER BY A.CODIGO_TICKET;
	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_ListaTicketsEstado]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_ListaTicketsEstado]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Ticket_ListaTicketsEstado]
	@PROYECTO	bigint,
	@TIPO_TICKET	varchar(20) = NULL,
	@ESTADO		varchar(15) = NULL,
	@FECHA_REGINI	datetime = NULL,
	@FECHA_REGFIN	datetime = NULL
AS
	DECLARE @RETCODE_PROCESO int;
	IF
		@PROYECTO	IS NULL
	BEGIN
		RETURN (255);
	END
	IF
		(@TIPO_TICKET IS NOT NULL) AND
		(@TIPO_TICKET NOT IN (''INCIDENTE'', ''CONSULTA'', ''REQUERIMIENTO'', ''PROBLEMA''))
	BEGIN
		RETURN (248);
	END
	IF
		(@ESTADO IS NOT NULL) AND
		(@ESTADO NOT IN (''ABIERTO'', ''EN PROCESO'', ''EN ESPERA'', ''DEVUELTO'', ''RECHAZADO'', ''SOLUCIONADO'', ''CERRADO'', ''ANULADO''))
	BEGIN
		RETURN (241);
	END
	IF
		(@FECHA_REGINI IS NOT NULL) AND
		(@FECHA_REGFIN IS NOT NULL) AND
		(@FECHA_REGFIN < @FECHA_REGINI )
	BEGIN
		RETURN (236);
	END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SELECT A.CODIGO_TICKET, L.CODIGO_CLIENTE, L.RAZON_SOCIAL, I.CODIGO_USUARIO_CLIENTE, I.ALIAS_USUARIO_CLIENTE, I.NOMBRE_USUARIO_CLIENTE,
	       A.DESCRIPCION_CORTA_TICKET, A.DESCRIPCION_TICKET, A.TIPO_REGISTRO_TICKET, A.TIPO_ATENCION_TICKET, A.FECHA_REGISTRO_TICKET,
	       A.FECHA_EXPIRACION_TICKET, A.PRIORIDAD_TICKET, A.ESTADO_TICKET, A.SOLUCION_TICKET,A.CODIGO_PROYECTO,A.CODIGO_SEDE, 
	       K.URGENCIA_DETALLE_SLA, K.IMPACTO_DETALLE_SLA, K.COMPLEJIDAD_DETALLE_SLA, K.TIEMPO_RESPUESTA_DETALLE_SLA, K.TIEMPO_CIERRE_DETALLE_SLA,
	       B.NIVEL_INTEGRANTE as Nivel_Propietario, E.CODIGO_EMPLEADO as CodEmp_Propietario,
	       M.NOMBRE_PERSONA + '' '' + M.APELLIDO_PATERNO + '' '' + M.APELLIDO_MATERNO AS Empleado_Propietario,
	       C.NIVEL_INTEGRANTE as Nivel_Asignado,    F.CODIGO_EMPLEADO as CodEmp_Asignado,
	       N.NOMBRE_PERSONA + '' '' + N.APELLIDO_PATERNO + '' '' + N.APELLIDO_MATERNO AS Empleado_Asignado,
               D.NIVEL_INTEGRANTE as Nivel_Ult_Modif,   G.CODIGO_EMPLEADO as CodEmp_UltModif,
	       O.NOMBRE_PERSONA + '' '' + O.APELLIDO_PATERNO + '' '' + O.APELLIDO_MATERNO AS Empleado_Ult_Modif,
	       H.NOMBRE_SERVICIO,ULTIMA_SECUENCIA_SEGUIMIENTO_TICKET,ULTIMA_SECUENCIA_ADICIONAL_TICKET 
               FROM [dbo].[TICKET] AS A
                INNER JOIN [dbo].[INTEGRANTE] AS B ON A.CODIGO_EQUIPO = B.CODIGO_EQUIPO AND A.CREADO_POR_CODIGO_INTEGRANTE = B.CODIGO_INTEGRANTE
                INNER JOIN [dbo].[INTEGRANTE] AS C ON A.CODIGO_EQUIPO = C.CODIGO_EQUIPO AND A.ASIGNADO_A_CODIGO_INTEGRANTE = C.CODIGO_INTEGRANTE
                INNER JOIN [dbo].[INTEGRANTE] AS D ON A.CODIGO_EQUIPO = D.CODIGO_EQUIPO AND A.ULTIMO_CAMBIO_CODIGO_INTEGRANTE = D.CODIGO_INTEGRANTE
                INNER JOIN [dbo].[EMPLEADO]  AS E ON B.CODIGO_EMPLEADO = E.CODIGO_EMPLEADO
                INNER JOIN [dbo].[EMPLEADO]  AS F ON C.CODIGO_EMPLEADO = F.CODIGO_EMPLEADO
                INNER JOIN [dbo].[EMPLEADO]  AS G ON D.CODIGO_EMPLEADO = G.CODIGO_EMPLEADO
                INNER JOIN [dbo].[SERVICIO]   AS H ON A.CODIGO_SERVICIO = H.CODIGO_SERVICIO
		INNER JOIN [dbo].[USUARIO_CLIENTE] AS I ON A.CODIGO_CLIENTE = I.CODIGO_CLIENTE AND A.CODIGO_USUARIO_CLIENTE = I.CODIGO_USUARIO_CLIENTE
		INNER JOIN [dbo].[PROYECTO_SERVICIO_SEDE] AS J ON A.CODIGO_PROYECTO = J.CODIGO_PROYECTO AND A.CODIGO_SERVICIO = J.CODIGO_SERVICIO AND A.CODIGO_SEDE = J.CODIGO_SEDE
		INNER JOIN [dbo].[DETALLE_SLA] AS K ON J.CODIGO_SLA = K.CODIGO_SLA AND J.CODIGO_DETALLE_SLA = K.CODIGO_DETALLE_SLA
		INNER JOIN [dbo].[CLIENTE] AS L ON A.CODIGO_CLIENTE = L.CODIGO_CLIENTE
		INNER JOIN [dbo].[PERSONA] AS M ON E.CODIGO_EMPLEADO = M.CODIGO_PERSONA
		INNER JOIN [dbo].[PERSONA] AS N ON F.CODIGO_EMPLEADO = N.CODIGO_PERSONA
		INNER JOIN [dbo].[PERSONA] AS O ON G.CODIGO_EMPLEADO = O.CODIGO_PERSONA
	WHERE A.CODIGO_PROYECTO = @PROYECTO AND
	      (@TIPO_TICKET  IS NULL OR A.TIPO_ATENCION_TICKET = @TIPO_TICKET   ) AND
	      (@ESTADO       IS NULL OR A.ESTADO_TICKET = @ESTADO               ) AND
	      (@FECHA_REGINI IS NULL OR A.FECHA_REGISTRO_TICKET >= @FECHA_REGINI) AND
	      (@FECHA_REGFIN IS NULL OR A.FECHA_REGISTRO_TICKET <= @FECHA_REGFIN)
	ORDER BY A.CODIGO_TICKET;
	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_RegistrarSolucion]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_RegistrarSolucion]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Ticket_RegistrarSolucion]
	@TICKET			bigint,
	@SOLUCION		varchar(1000),
	@EQUIPO			bigint,
	@INTEGRANTE		bigint
AS
	DECLARE @RETCODE_PROCESO int, @ESTADO_ACTUAL varchar(15), @EQUIPO_ACTUAL bigint;
	IF
		@TICKET		IS NULL OR
		@SOLUCION	IS NULL OR
		@EQUIPO		IS NULL OR
		@INTEGRANTE	IS NULL
	BEGIN
		RETURN (255);
	END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	--SET @ESTADO_ACTUAL = (SELECT ESTADO_TICKET FROM [dbo].[TICKET] WHERE CODIGO_TICKET = @TICKET);
	--SET @RETCODE_PROCESO = @@ERROR;
	--IF (@RETCODE_PROCESO <> 0)
	--BEGIN
	--	RETURN @RETCODE_PROCESO;
	--END
	--IF (@ESTADO_ACTUAL IS NULL)
	--BEGIN
	--	RETURN (240);
	--END
	
	--IF
	--	@ESTADO_ACTUAL NOT IN (''EN PROCESO'', ''EN ESPERA'', ''SOLUCIONADO'')
	--BEGIN
	--	RETURN (239);
	--END

/* EXISTEN OTROS ESTADOS NO ACEPTADOS: ''ABIERTO'', ''DEVUELTO'', ''RECHAZADO'', ''CERRADO'', ''ANULADO'' */  

	--SET @EQUIPO_ACTUAL = (SELECT CODIGO_EQUIPO FROM [dbo].[TICKET] WHERE CODIGO_TICKET = @TICKET);
	--SET @RETCODE_PROCESO = @@ERROR;
	--IF (@RETCODE_PROCESO <> 0)
	--BEGIN
	--	RETURN @RETCODE_PROCESO;
	--END
	--IF (@EQUIPO_ACTUAL IS NULL)
	--BEGIN
	--	RETURN (238);
	--END
	--IF (@EQUIPO_ACTUAL <> @EQUIPO)
	--BEGIN
	--	RETURN (237);
	--END

	UPDATE [dbo].[TICKET]
	SET
		ESTADO_TICKET = ''SOLUCIONADO'',
		FECHA_SOLUCION_TICKET = GETDATE(),
		SOLUCION_TICKET = @SOLUCION,
		ULTIMO_CAMBIO_CODIGO_INTEGRANTE = @INTEGRANTE
	WHERE CODIGO_TICKET = @TICKET;
	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_ModificarTicket]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_ModificarTicket]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Ticket_ModificarTicket]
	@TICKET			bigint,
	@TIPO_REGISTRO		varchar(20),
	@TIPO_ATENCION		varchar(20),
	@FECHA_EXPIRACION	datetime,
	@DESCRIPCION_CORTA	varchar(50),
	@DESCRIPCION_LARGA	varchar(1000),
	@TIEMPO_RESOLUCION	int,
	@PRIORIDAD		int,
	@CLIENTE		bigint,
	@USUARIO		bigint,
	@SERVICIO		bigint,
	@PROYECTO		bigint,
	@EQUIPO_ESPE		bigint,
	@ESPECIALISTA		bigint,
	@EQUIPO_ACTUA		bigint,
	@ACTUALIZADOR		bigint
AS
	DECLARE @RETCODE_PROCESO int, @SEDE bigint, @ESTADO_ACTUAL varchar(15), @EQUIPO_ACTUAL bigint;
	IF
		@TICKET 		IS NULL OR
		(@CLIENTE		IS NULL AND
		 @USUARIO		IS NOT NULL) OR
		(@CLIENTE		IS NOT NULL AND
		 @USUARIO		IS NULL) OR
		(@EQUIPO_ESPE		IS NULL AND
		 @ESPECIALISTA		IS NOT NULL) OR
		@EQUIPO_ACTUA		IS NULL OR
		@ACTUALIZADOR		IS NULL
	BEGIN
		RETURN (255);
	END
	IF
		@FECHA_EXPIRACION	IS NULL AND
		@DESCRIPCION_CORTA	IS NULL AND
		@DESCRIPCION_LARGA	IS NULL AND
		@TIEMPO_RESOLUCION	IS NULL AND
		@PRIORIDAD		IS NULL AND
		@USUARIO		IS NULL AND
		@SERVICIO		IS NULL AND
		@PROYECTO		IS NULL AND
		@ESPECIALISTA		IS NULL
	BEGIN
		RETURN (233);
	END
	IF
		@TIPO_REGISTRO		NOT IN (''CORREO'', ''TELEFONO'', ''CARTA'', ''INTERNET'')
	BEGIN
		RETURN (249);
	END
	IF
		@TIPO_ATENCION		NOT IN (''INCIDENTE'', ''CONSULTA'', ''REQUERIMIENTO'', ''PROBLEMA'')
	BEGIN
		RETURN (248);
	END
	--IF
	--	@FECHA_EXPIRACION < GETDATE()
	--BEGIN
	--	RETURN (247);
	--END
	--IF
	--	LEN(@DESCRIPCION_CORTA) < 5
	--BEGIN
	--	RETURN (246);
	--END
	--IF
	--	LEN(@DESCRIPCION_LARGA) < 15
	--BEGIN
	--	RETURN (245);
	--END
	--IF
	--	@TIEMPO_RESOLUCION < 5
	--BEGIN
	--	RETURN (244);
	--END
	--IF
	--	@PRIORIDAD <1 OR @PRIORIDAD > 50
	--BEGIN
	--	RETURN (243);
	--END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	IF @USUARIO IS NOT NULL
		SET @SEDE = (SELECT CODIGO_SEDE FROM [dbo].[USUARIO_CLIENTE]
				 WHERE CODIGO_CLIENTE = @CLIENTE AND CODIGO_USUARIO_CLIENTE = @USUARIO);
	SET @RETCODE_PROCESO = @@ERROR;
	IF (@RETCODE_PROCESO <> 0)
	BEGIN
		RETURN @RETCODE_PROCESO;
	END
	IF (@SEDE IS NULL)
	BEGIN
		RETURN (242);
	END

	SET @ESTADO_ACTUAL = (SELECT ESTADO_TICKET FROM [dbo].[TICKET] WHERE CODIGO_TICKET = @TICKET);
	SET @RETCODE_PROCESO = @@ERROR;
	IF (@RETCODE_PROCESO <> 0)
	BEGIN
		RETURN @RETCODE_PROCESO;
	END
	IF (@ESTADO_ACTUAL IS NULL)
	BEGIN
		RETURN (240);
	END
	
	IF
		@ESTADO_ACTUAL IN (''SOLUCIONADO'', ''CERRADO'', ''ANULADO'')

	BEGIN
		RETURN (232);
	END

	SET @EQUIPO_ACTUAL = (SELECT CODIGO_EQUIPO FROM [dbo].[TICKET] WHERE CODIGO_TICKET = @TICKET);
	SET @RETCODE_PROCESO = @@ERROR;
	IF (@RETCODE_PROCESO <> 0)
	BEGIN
		RETURN @RETCODE_PROCESO;
	END
	IF (@EQUIPO_ACTUAL IS NULL)
	BEGIN
		RETURN (238);
	END
	
	IF
		@EQUIPO_ESPE IS NOT NULL AND
		@EQUIPO_ESPE <> @EQUIPO_ACTUAL
	BEGIN
		RETURN (231);
	END

	IF
		@EQUIPO_ACTUA <> @EQUIPO_ACTUAL
	BEGIN
		RETURN (237);
	END

	UPDATE [dbo].[TICKET]
	SET 
		TIPO_REGISTRO_TICKET  = CASE 
					    WHEN @TIPO_REGISTRO IS NOT NULL
		                            THEN @TIPO_REGISTRO
		                            ELSE TIPO_REGISTRO_TICKET
		                        END,
		TIPO_ATENCION_TICKET  = CASE 
					    WHEN @TIPO_ATENCION IS NOT NULL
		                            THEN @TIPO_ATENCION
		                            ELSE TIPO_ATENCION_TICKET
		                        END,
		FECHA_EXPIRACION_TICKET  = CASE 
					    WHEN @FECHA_EXPIRACION IS NOT NULL
		                            THEN @FECHA_EXPIRACION
		                            ELSE FECHA_EXPIRACION_TICKET
		                        END,
		DESCRIPCION_CORTA_TICKET  = CASE 
					    WHEN @DESCRIPCION_CORTA IS NOT NULL
		                            THEN @DESCRIPCION_CORTA
		                            ELSE DESCRIPCION_CORTA_TICKET
		                        END,
		DESCRIPCION_TICKET  = CASE 
					    WHEN @DESCRIPCION_LARGA IS NOT NULL
		                            THEN @DESCRIPCION_LARGA
		                            ELSE DESCRIPCION_TICKET
		                        END,
		TIEMPO_RESOLUCION_TICKET  = CASE 
					    WHEN @TIEMPO_RESOLUCION IS NOT NULL
		                            THEN @TIEMPO_RESOLUCION
		                            ELSE TIEMPO_RESOLUCION_TICKET
		                        END,
		PRIORIDAD_TICKET  = CASE 
					    WHEN @PRIORIDAD IS NOT NULL
		                            THEN @PRIORIDAD
		                            ELSE PRIORIDAD_TICKET
		                        END,
		CODIGO_CLIENTE  = CASE 
					    WHEN @CLIENTE IS NOT NULL
		                            THEN @CLIENTE
		                            ELSE CODIGO_CLIENTE
		                        END,
		CODIGO_USUARIO_CLIENTE  = CASE 
					    WHEN @USUARIO IS NOT NULL
		                            THEN @USUARIO
		                            ELSE CODIGO_USUARIO_CLIENTE
		                        END,
		CODIGO_SERVICIO  = CASE 
					    WHEN @SERVICIO IS NOT NULL
		                            THEN @SERVICIO
		                            ELSE CODIGO_SERVICIO
		                        END,
		CODIGO_SEDE  = CASE 
					    WHEN @SEDE IS NOT NULL
		                            THEN @SEDE
		                            ELSE CODIGO_SEDE
		                        END,
		CODIGO_PROYECTO  = CASE 
					    WHEN @PROYECTO IS NOT NULL
		                            THEN @PROYECTO
		                            ELSE CODIGO_PROYECTO
		                        END,
		ASIGNADO_A_CODIGO_INTEGRANTE  = CASE 
					    WHEN @ESPECIALISTA IS NOT NULL
		                            THEN @ESPECIALISTA
		                            ELSE ASIGNADO_A_CODIGO_INTEGRANTE
		                        END,
		ULTIMO_CAMBIO_CODIGO_INTEGRANTE  = @ACTUALIZADOR
	WHERE CODIGO_TICKET = @TICKET;
	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_ModificarLeccionAprendida]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_ModificarLeccionAprendida]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Ticket_ModificarLeccionAprendida]
	@TICKET		bigint,
	@LECCION_ANTIG	bigint,
	@LECCION_NUEVA	bigint
AS
	DECLARE @RETCODE_PROCESO int, @ESTADO varchar(15);
	IF
		@TICKET 	IS NULL
	BEGIN
		RETURN (255);
	END
	IF
		@LECCION_ANTIG	IS NULL AND
		@LECCION_NUEVA	IS NULL
	BEGIN
		RETURN (233);
	END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SET @ESTADO = (SELECT ESTADO_TICKET FROM [dbo].[TICKET] WHERE CODIGO_TICKET = @TICKET);
	SET @RETCODE_PROCESO = @@ERROR;
	IF (@RETCODE_PROCESO <> 0)
	BEGIN
		RETURN @RETCODE_PROCESO;
	END
	IF (@ESTADO IS NULL)
	BEGIN
		RETURN (235);
	END
	IF @ESTADO IN (''SOLUCIONADO'', ''CERRADO'', ''ANULADO'')
	BEGIN
		RETURN (232);
	END

	IF 
		@LECCION_ANTIG IS NOT NULL
	BEGIN
		DELETE [dbo].[TICKET_LECCION_APRENDIDA]
		WHERE CODIGO_TICKET =@TICKET AND CODIGO_LECCION_APRENDIDA = @LECCION_ANTIG;
		SET @RETCODE_PROCESO = @@ERROR;
		IF (@RETCODE_PROCESO <> 0)
		BEGIN
			RETURN @RETCODE_PROCESO;
		END
	END


	IF 
		@LECCION_NUEVA IS NOT NULL
	BEGIN
		INSERT INTO [dbo].[TICKET_LECCION_APRENDIDA] (CODIGO_TICKET, CODIGO_LECCION_APRENDIDA)
		VALUES (@TICKET, @LECCION_NUEVA);
		SET @RETCODE_PROCESO = @@ERROR;
		IF (@RETCODE_PROCESO <> 0)
		BEGIN
			RETURN @RETCODE_PROCESO;
		END
	END
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_ModificarCMDB]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_ModificarCMDB]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Ticket_ModificarCMDB]
	@TICKET		bigint,
	@CMDB_ANTIG	bigint,
	@CMDB_NUEVO	bigint
AS
	DECLARE @RETCODE_PROCESO int, @ESTADO varchar(15);
	IF
		@TICKET 	IS NULL
	BEGIN
		RETURN (255);
	END
	IF
		(@CMDB_ANTIG	IS NULL AND
		 @CMDB_NUEVO	IS NULL)
	BEGIN
		RETURN (233);
	END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SET @ESTADO = (SELECT ESTADO_TICKET FROM [dbo].[TICKET] WHERE CODIGO_TICKET = @TICKET);
	SET @RETCODE_PROCESO = @@ERROR;
	IF (@RETCODE_PROCESO <> 0)
	BEGIN
		RETURN @RETCODE_PROCESO;
	END
	IF (@ESTADO IS NULL)
	BEGIN
		RETURN (235);
	END
	IF @ESTADO IN (''SOLUCIONADO'', ''CERRADO'', ''ANULADO'')
	BEGIN
		RETURN (232);
	END
	
	IF
		@CMDB_ANTIG IS NOT NULL
	BEGIN
		DELETE [dbo].[TICKET_CMDB]
		WHERE CODIGO_CMDB = @CMDB_ANTIG AND CODIGO_TICKET = @TICKET;
		SET @RETCODE_PROCESO = @@ERROR;
		IF (@RETCODE_PROCESO <> 0)
		BEGIN
			RETURN @RETCODE_PROCESO;
		END
	END
	IF
		@CMDB_NUEVO IS NOT NULL
	BEGIN
		INSERT INTO [dbo].[TICKET_CMDB] (CODIGO_CMDB, CODIGO_TICKET)
		VALUES (@CMDB_NUEVO, @TICKET);
		IF (@RETCODE_PROCESO <> 0)
		BEGIN
			RETURN @RETCODE_PROCESO;
		END
	END
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_ListaCMDB]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_ListaCMDB]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Ticket_ListaCMDB]
	@TICKET		bigint
AS
	DECLARE @RETCODE_PROCESO int;
	IF
		@TICKET 	IS NULL
	BEGIN
		RETURN (255);
	END
	

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SELECT T.CODIGO_TICKET,T.CODIGO_CMDB, C.NOMBRE_CMDB,C.DESCRIPCION_CMDB
	   FROM [dbo].[TICKET_CMDB] T
	   INNER JOIN SD.CMDB C ON C.CODIGO_CMDB = T.CODIGO_CMDB
		WHERE CODIGO_TICKET = @TICKET;
		SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_AgregarLeccionAprendida]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_AgregarLeccionAprendida]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Ticket_AgregarLeccionAprendida]
	@TICKET		bigint,
	@LECCION	bigint
AS
	DECLARE @RETCODE_PROCESO int, @ESTADO varchar(15);
	IF
		@TICKET 	IS NULL OR
		@LECCION	IS NULL
	BEGIN
		RETURN (255);
	END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SET @ESTADO = (SELECT ESTADO_TICKET FROM [dbo].[TICKET] WHERE CODIGO_TICKET = @TICKET);
	SET @RETCODE_PROCESO = @@ERROR;
	IF (@RETCODE_PROCESO <> 0)
	BEGIN
		RETURN @RETCODE_PROCESO;
	END
	IF (@ESTADO IS NULL)
	BEGIN
		RETURN (235);
	END
	IF @ESTADO IN (''SOLUCIONADO'', ''CERRADO'', ''ANULADO'')
	BEGIN
		RETURN (234);
	END

	INSERT INTO [dbo].[TICKET_LECCION_APRENDIDA] (CODIGO_TICKET, CODIGO_LECCION_APRENDIDA)
	VALUES (@TICKET, @LECCION);
	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Ticket_AgregarCMDB]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Ticket_AgregarCMDB]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_Ticket_AgregarCMDB]
	@TICKET		bigint,
	@CMDB		bigint
AS
	DECLARE @RETCODE_PROCESO int, @ESTADO varchar(15);
	IF
		@TICKET 	IS NULL OR
		@CMDB		IS NULL
	BEGIN
		RETURN (255);
	END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SET @ESTADO = (SELECT ESTADO_TICKET FROM [dbo].[TICKET] WHERE CODIGO_TICKET = @TICKET);
	SET @RETCODE_PROCESO = @@ERROR;
	IF (@RETCODE_PROCESO <> 0)
	BEGIN
		RETURN @RETCODE_PROCESO;
	END
	IF (@ESTADO IS NULL)
	BEGIN
		RETURN (235);
	END
	IF @ESTADO IN (''SOLUCIONADO'', ''CERRADO'', ''ANULADO'')
	BEGIN
		RETURN (234);
	END

	INSERT INTO [dbo].[TICKET_CMDB] (CODIGO_CMDB, CODIGO_TICKET)
	VALUES (@CMDB, @TICKET);
	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_SOLICITUD_CAMBIO_UPD_ARCHIVO]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_SOLICITUD_CAMBIO_UPD_ARCHIVO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE  PROCEDURE [dbo].[USP_SOLICITUD_CAMBIO_UPD_ARCHIVO]
@CODIGO INT,
@NOMBRE_ARCHIVO VARCHAR(50),
@EXTENSION CHAR(3),
@RUTA_ARCHIVO VARCHAR(MAX) OUTPUT,
@TRANSACTION_CONTEXT VARBINARY(MAX) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;	
	
	UPDATE 
		dbo.SOLICITUD_CAMBIO
	SET 
		NOMBRE_ARCHIVO = @NOMBRE_ARCHIVO,
		EXTENSION = @EXTENSION,
		DATA = CAST('''' AS VARBINARY(MAX))
	WHERE
		CODIGO = @CODIGO;
		
	SELECT 
		@RUTA_ARCHIVO = DATA.PathName(),
		@TRANSACTION_CONTEXT = GET_FILESTREAM_TRANSACTION_CONTEXT()
	FROM 
		dbo.SOLICITUD_CAMBIO
	WHERE 
		CODIGO = @CODIGO;

	SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_SOLICITUD_CAMBIO_SEL_PROYECTO_LINEABASE]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_SOLICITUD_CAMBIO_SEL_PROYECTO_LINEABASE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_SOLICITUD_CAMBIO_SEL_PROYECTO_LINEABASE]
@CODIGO_PROYECTO INT,
@CODIGO_LINEABASE INT,
@ESTADO VARCHAR(2),
@PRIORIDAD INT
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
		SC.CODIGO_PROYECTO = @CODIGO_PROYECTO
		AND (@CODIGO_LINEABASE = 0 OR SC.CODIGO_LINEA_BASE = @CODIGO_LINEABASE)
		AND (@ESTADO = ''0'' OR SC.ESTADO = @ESTADO)
		AND (@PRIORIDAD = 0 OR SC.PRIORIDAD = @PRIORIDAD);
		
	SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_SOLICITUD_CAMBIO_SEL_CODIGO]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_SOLICITUD_CAMBIO_SEL_CODIGO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_SOLICITUD_CAMBIO_SEL_CODIGO]
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_SOLICITUD_CAMBIO_SEL_ARCHIVO]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_SOLICITUD_CAMBIO_SEL_ARCHIVO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_SOLICITUD_CAMBIO_SEL_ARCHIVO]
@CODIGO INT
AS
BEGIN
	SET NOCOUNT ON;	
	
	SELECT
		NOMBRE_ARCHIVO,
		DATA.PathName() AS RUTA_ARCHIVO,
		GET_FILESTREAM_TRANSACTION_CONTEXT() AS TRANSACTION_CONTEXT
	FROM 
		dbo.SOLICITUD_CAMBIO
	WHERE 
		CODIGO = @CODIGO;

	SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_SOLICITUD_CAMBIO_MOTIVO_UPD]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_SOLICITUD_CAMBIO_MOTIVO_UPD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[USP_SOLICITUD_CAMBIO_MOTIVO_UPD]
@CODIGO INT,
@MOTIVO VARCHAR(200)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE 
		[dbo].SOLICITUD_CAMBIO
	SET
		MOTIVO = @MOTIVO
	WHERE
	CODIGO = @CODIGO;

	SET NOCOUNT OFF;

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_SOLICITUD_CAMBIO_INS]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_SOLICITUD_CAMBIO_INS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_SOLICITUD_CAMBIO_INS]
@CODIGO INT OUTPUT,
@NOMBRE VARCHAR(50),
@CODIGO_PROYECTO INT,
@CODIGO_LINEABASE INT,
@CODIGO_USUARIO INT,
@FECHA_REGISTRO DATE,
@ESTADO VARCHAR(2),
@CODIGO_ECS INT,
@PRIORIDAD INT
AS
BEGIN
	SET NOCOUNT ON;	
	
	INSERT INTO dbo.SOLICITUD_CAMBIO(
		NOMBRE, 
		CODIGO_PROYECTO, 
		CODIGO_LINEA_BASE, 
		CODIGO_USUARIO, 
		FECHA_REGISTRO, 
		ESTADO, 
		CODIGO_ECS, 
		PRIORIDAD)
	VALUES(
		@NOMBRE,
		@CODIGO_PROYECTO,
		@CODIGO_LINEABASE,
		@CODIGO_USUARIO,
		@FECHA_REGISTRO,
		@ESTADO,
		@CODIGO_ECS,
		@PRIORIDAD
	);
	
	SET @CODIGO = SCOPE_IDENTITY();
	
	SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_SOLICITUD_CAMBIO_ESTADO_UPD]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_SOLICITUD_CAMBIO_ESTADO_UPD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[USP_SOLICITUD_CAMBIO_ESTADO_UPD]
@CODIGO INT,
@ESTADO INT
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE 
		[dbo].SOLICITUD_CAMBIO
	SET
		ESTADO = @ESTADO
	WHERE
	CODIGO = @CODIGO;

	SET NOCOUNT OFF;

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_SOLICITUD_CAMBIO_APROBAR_UPD]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_SOLICITUD_CAMBIO_APROBAR_UPD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_SOLICITUD_CAMBIO_APROBAR_UPD]
@CODIGO INT,
@MOTIVO VARCHAR(200),
@ESTADO VARCHAR(2)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE 
		[dbo].SOLICITUD_CAMBIO
	SET
		MOTIVO = @MOTIVO,
		ESTADO = @ESTADO,
		FECHA_APROBACION = GETDATE()
	WHERE
	CODIGO = @CODIGO;

	SET NOCOUNT OFF;

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LISTA_SOLICITUD_PROYECTO_BASE]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LISTA_SOLICITUD_PROYECTO_BASE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[USP_LISTA_SOLICITUD_PROYECTO_BASE]
@CODIGO_PROYECTO int,
@CODIGO_LINEABASE int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT  
		SC.CODIGO, SC.CODIGO_ECS, SC.CODIGO_LINEA_BASE, SC.CODIGO_PROYECTO, SC.CODIGO_USUARIO, SC.ESTADO, SC.FECHA_REGISTRO, SC.NOMBRE
	FROM [dbo].SOLICITUD_CAMBIO AS SC 
			WHERE SC.CODIGO_PROYECTO = @CODIGO_PROYECTO AND SC.CODIGO_LINEA_BASE = @CODIGO_LINEABASE;

	SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_InformacionSeguimiento_ModificarSeguimiento]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_InformacionSeguimiento_ModificarSeguimiento]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_InformacionSeguimiento_ModificarSeguimiento]
	@TICKET		bigint,
	@NUM_SEGUI	bigint,
	@EQUIPO		bigint,
	@INTEGRANTE	bigint,
	@SEGUIMIENTO    varchar(1000)
AS
	DECLARE @RETCODE_PROCESO int, @CODIGO_EQUIPO_TICKET bigint, @CONTADOR bigint;
	IF
		@TICKET		IS NULL OR
		@NUM_SEGUI      IS NULL OR
		@EQUIPO		IS NULL OR
		@INTEGRANTE	IS NULL OR
		@SEGUIMIENTO	IS NULL
	BEGIN
		RETURN (255)
	END
	IF
		LEN(@SEGUIMIENTO) < 15
	BEGIN
		RETURN (254)
	END

	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SET @CODIGO_EQUIPO_TICKET = (SELECT CODIGO_EQUIPO FROM [dbo].[TICKET] WHERE CODIGO_TICKET = @TICKET);
	SET @RETCODE_PROCESO = @@ERROR;
	IF (@RETCODE_PROCESO <> 0)
	BEGIN
		RETURN @RETCODE_PROCESO;
	END
	IF (@CODIGO_EQUIPO_TICKET IS NULL)
	BEGIN
		RETURN (253);
	END
	IF (@CODIGO_EQUIPO_TICKET <> @EQUIPO)
	BEGIN
		RETURN (252);
	END

	SET @CONTADOR = (SELECT COUNT(*)
				     FROM [dbo].[INFORMACION_SEGUIMIENTO]
				     WHERE CODIGO_TICKET = @TICKET AND CODIGO_SEGUIMIENTO = @NUM_SEGUI);
	SET @RETCODE_PROCESO = @@ERROR;
	IF (@RETCODE_PROCESO <> 0)
	BEGIN
		RETURN @RETCODE_PROCESO;
	END
	IF (@CONTADOR = 0)
	BEGIN
		RETURN (251);
	END

	UPDATE [dbo].[INFORMACION_SEGUIMIENTO]
	SET
		FECHA_REGISTRO_INFORMACION_SEGUIMIENTO = GETDATE(),
		DESCRIPCION_INFORMACION_SEGUIMIENTO = @SEGUIMIENTO,
		CODIGO_EQUIPO = @EQUIPO,
		CODIGO_INTEGRANTE = @INTEGRANTE
	WHERE CODIGO_TICKET = @TICKET AND CODIGO_SEGUIMIENTO = @NUM_SEGUI;
	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_InformacionSeguimiento_AgregarSeguimiento]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_InformacionSeguimiento_AgregarSeguimiento]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_InformacionSeguimiento_AgregarSeguimiento]
	@TICKET		bigint,
	@EQUIPO		bigint,
	@INTEGRANTE	bigint,
	@SEGUIMIENTO    varchar(1000)
AS
	DECLARE @RETCODE_PROCESO int, @CODIGO_EQUIPO_TICKET bigint, @ULTSEC bigint;
	IF
		@TICKET			IS NULL OR
		@EQUIPO			IS NULL OR
		@INTEGRANTE		IS NULL OR
		@SEGUIMIENTO	IS NULL
	BEGIN
		RETURN (255)
	END
	IF
		LEN(@SEGUIMIENTO) < 15
	BEGIN
		RETURN (254)
	END
	SET NOCOUNT ON;
	SET @RETCODE_PROCESO = 0;

	SET @CODIGO_EQUIPO_TICKET = (SELECT CODIGO_EQUIPO FROM [dbo].[TICKET] WHERE CODIGO_TICKET = @TICKET);
	SET @RETCODE_PROCESO = @@ERROR;
	IF (@RETCODE_PROCESO <> 0)
	BEGIN
		RETURN @RETCODE_PROCESO;
	END
	IF (@CODIGO_EQUIPO_TICKET IS NULL)
	BEGIN
		RETURN (253);
	END
	IF (@CODIGO_EQUIPO_TICKET <> @EQUIPO)
	BEGIN
		RETURN (252);
	END

	SET @ULTSEC = (SELECT A.ULTIMA_SECUENCIA_SEGUIMIENTO_TICKET
		       FROM [dbo].[TICKET] AS A
		       WHERE A.CODIGO_TICKET = @TICKET) + 1;
	SET @RETCODE_PROCESO = @@ERROR;
	IF (@RETCODE_PROCESO <> 0)
	BEGIN
		RETURN @RETCODE_PROCESO;
	END

	IF
		@ULTSEC IS NULL
	BEGIN
		RETURN (253)
	END	           
		           
	UPDATE [dbo].[TICKET]
	SET ULTIMA_SECUENCIA_SEGUIMIENTO_TICKET = @ULTSEC
	WHERE CODIGO_TICKET = @TICKET;
	SET @RETCODE_PROCESO = @@ERROR;
	IF (@RETCODE_PROCESO <> 0)
	BEGIN
		RETURN @RETCODE_PROCESO;
	END

	INSERT INTO [dbo].[INFORMACION_SEGUIMIENTO] (CODIGO_TICKET, CODIGO_SEGUIMIENTO, FECHA_REGISTRO_INFORMACION_SEGUIMIENTO,
                	                            DESCRIPCION_INFORMACION_SEGUIMIENTO, CODIGO_EQUIPO, CODIGO_INTEGRANTE)
	VALUES (@TICKET, @ULTSEC, GETDATE(), @SEGUIMIENTO, @EQUIPO, @INTEGRANTE);
	SET @RETCODE_PROCESO = @@ERROR;
	RETURN @RETCODE_PROCESO;
' 
END
GO
/****** Object:  Table [dbo].[INFORME_CAMBIO]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INFORME_CAMBIO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[INFORME_CAMBIO](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NULL,
	[CODIGO_SOLICITUD] [int] NULL,
	[CODIGO_USUARIO] [varchar](8) NULL,
	[FECHA_REGISTRO] [date] NULL,
	[FECHA_APROBACION] [date] NULL,
	[ESTADO] [int] NULL,
	[ESTIMACION_COSTO] [varchar](200) NULL,
	[ESTIMACION_ESFUERZO] [varchar](200) NULL,
	[RECURSOS] [varchar](200) NULL,
	[MOTIVO] [varchar](200) NULL,
	[ROWGUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF__INFORME_C__ROWGU__48CFD27E]  DEFAULT (newid()),
	[NOMBRE_ARCHIVO] [varchar](50) NULL,
	[EXTENSION] [char](3) NULL,
	[DATA] [varbinary](max) FILESTREAM  NULL,
 CONSTRAINT [PK__INFORME___CC87E1271BFD2C07] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] FILESTREAM_ON [TMD_fg_filestream],
 CONSTRAINT [UQ__INFORME___D7A3AA553C69FB99] UNIQUE NONCLUSTERED 
(
	[ROWGUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] FILESTREAM_ON [TMD_fg_filestream]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[INFORME_CAMBIO] ON
INSERT [dbo].[INFORME_CAMBIO] ([CODIGO], [NOMBRE], [CODIGO_SOLICITUD], [CODIGO_USUARIO], [FECHA_REGISTRO], [FECHA_APROBACION], [ESTADO], [ESTIMACION_COSTO], [ESTIMACION_ESFUERZO], [RECURSOS], [MOTIVO], [ROWGUID], [NOMBRE_ARCHIVO], [EXTENSION], [DATA]) VALUES (1, N'Informe 1', 1, N'3', CAST(0xDF360B00 AS Date), CAST(0xE0360B00 AS Date), 2, N'Costo', N'Esfuerzo', N'Esfuerzo', N'Aprobado', N'5911338c-96bf-4237-8d80-5652cd3a55b9', N'Informe 1.rtf', N'rtf', 0x7B5C727466317D)
SET IDENTITY_INSERT [dbo].[INFORME_CAMBIO] OFF
/****** Object:  Table [dbo].[ORDEN_CAMBIO]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ORDEN_CAMBIO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ORDEN_CAMBIO](
	[CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_INFORME] [int] NULL,
	[CODIGO_USUARIO_REG] [int] NULL,
	[FECHA_REGISTRO] [date] NULL,
	[CODIGO_USUARIO_ASIGNADO] [int] NULL,
	[ROWGUID] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF__ORDEN_CAM__ROWGU__74AE54BC]  DEFAULT (newid()),
	[NOMBRE_ARCHIVO] [varchar](50) NULL,
	[EXTENSION] [char](3) NULL,
	[NOMBRE] [varchar](50) NULL,
	[PRIORIDAD] [int] NULL,
	[DATA] [varbinary](max) FILESTREAM  NULL,
 CONSTRAINT [PK__ORDEN_CA__CC87E1271FCDBCEB] PRIMARY KEY CLUSTERED 
(
	[CODIGO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] FILESTREAM_ON [TMD_fg_filestream],
 CONSTRAINT [UQ__ORDEN_CA__D7A3AA5576969D2E] UNIQUE NONCLUSTERED 
(
	[ROWGUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] FILESTREAM_ON [TMD_fg_filestream]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[USP_INFORME_CAMBIO_UPD_ARCHIVO]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_INFORME_CAMBIO_UPD_ARCHIVO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE  PROCEDURE [dbo].[USP_INFORME_CAMBIO_UPD_ARCHIVO]
@CODIGO INT,
@NOMBRE_ARCHIVO VARCHAR(50),
@EXTENSION CHAR(3),
@RUTA_ARCHIVO VARCHAR(MAX) OUTPUT,
@TRANSACTION_CONTEXT VARBINARY(MAX) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;	
	
	UPDATE 
		dbo.INFORME_CAMBIO
	SET 
		NOMBRE_ARCHIVO = @NOMBRE_ARCHIVO,
		EXTENSION = @EXTENSION,
		DATA = CAST('''' AS VARBINARY(MAX))
	WHERE
		CODIGO = @CODIGO;
		
	SELECT 
		@RUTA_ARCHIVO = DATA.PathName(),
		@TRANSACTION_CONTEXT = GET_FILESTREAM_TRANSACTION_CONTEXT()
	FROM 
		dbo.INFORME_CAMBIO
	WHERE 
		CODIGO = @CODIGO;

	SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INFORME_CAMBIO_SEL_PROYECTO_LINEABASE_NONULL]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_INFORME_CAMBIO_SEL_PROYECTO_LINEABASE_NONULL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[USP_INFORME_CAMBIO_SEL_PROYECTO_LINEABASE_NONULL]
@CODIGO_PROYECTO INT,
@CODIGO_LINEABASE INT
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT 
		SOL.CODIGO AS CODIGO_SOLICITUD,
		SOL.NOMBRE AS NOMBRE_SOLICITUD
	FROM 
		dbo.SOLICITUD_CAMBIO AS SOL
	WHERE 
		SOL.CODIGO_LINEA_BASE = @CODIGO_LINEABASE AND SOL.CODIGO_PROYECTO = @CODIGO_PROYECTO AND SOL.ESTADO <> 3 
			AND (
					SELECT COUNT(CODIGO) 
						FROM dbo.INFORME_CAMBIO AS INF
							WHERE INF.CODIGO_SOLICITUD = SOL.CODIGO AND (INF.ESTADO = 1 OR INF.ESTADO = 2)) = 0
		
	SET NOCOUNT OFF;
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INFORME_CAMBIO_SEL_PROYECTO_LINEABASE]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_INFORME_CAMBIO_SEL_PROYECTO_LINEABASE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[USP_INFORME_CAMBIO_SEL_PROYECTO_LINEABASE]
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
		A.ESTADO = 2 AND A.CODIGO_PROYECTO = @CODIGO_PROYECTO AND A.CODIGO_LINEA_BASE = @CODIGO_LINEABASE
		
	SET NOCOUNT OFF;
END


' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INFORME_CAMBIO_SEL_CODIGO]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_INFORME_CAMBIO_SEL_CODIGO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[USP_INFORME_CAMBIO_SEL_CODIGO]
@CODIGO_INFORME INT
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		A.CODIGO AS CODIGO_SOLICITUD,
		A.CODIGO_PROYECTO,
		A.CODIGO_LINEA_BASE,
		B.NOMBRE AS NOMBRE_INFORME,
		B.ESTIMACION_COSTO,
		B.ESTIMACION_ESFUERZO,
		B.RECURSOS
	FROM 
		dbo.SOLICITUD_CAMBIO AS A LEFT JOIN dbo.INFORME_CAMBIO AS B
	ON 
		B.CODIGO_SOLICITUD = A.CODIGO 
	WHERE 
		B.CODIGO = @CODIGO_INFORME
		
	SET NOCOUNT OFF;
END


' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INFORME_CAMBIO_SEL_ARCHIVO]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_INFORME_CAMBIO_SEL_ARCHIVO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INFORME_CAMBIO_INS]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_INFORME_CAMBIO_INS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_INFORME_CAMBIO_INS]
@CODIGO INT OUTPUT,
@NOMBRE VARCHAR(50),
@CODIGO_SOLICITUD INT,
@CODIGO_USUARIO INT,
@FECHA_REGISTRO DATETIME,
@ESTADO INT,
@ESTIMACION_COSTO VARCHAR(200),
@ESTIMACION_ESFUERZO VARCHAR(200),
@RECURSOS VARCHAR(200)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [dbo].[INFORME_CAMBIO] (
		CODIGO_SOLICITUD, 
		CODIGO_USUARIO,
		NOMBRE,
		FECHA_REGISTRO, 
		ESTADO,
		ESTIMACION_COSTO,
		ESTIMACION_ESFUERZO,
		RECURSOS
		)
	VALUES
		(@CODIGO_SOLICITUD, 
		@CODIGO_USUARIO, 
		@NOMBRE,
		@FECHA_REGISTRO, 
		@ESTADO,
		@ESTIMACION_COSTO,
		@ESTIMACION_ESFUERZO,
		@RECURSOS
		);

	SET @CODIGO = SCOPE_IDENTITY();

	SET NOCOUNT OFF;

END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INFORME_CAMBIO_APROBAR_UPD]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_INFORME_CAMBIO_APROBAR_UPD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE  PROCEDURE [dbo].[USP_INFORME_CAMBIO_APROBAR_UPD]
@CODIGO INT,
@ESTADO INT,
@MOTIVO VARCHAR(200)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE 
		[dbo].INFORME_CAMBIO
	SET
		ESTADO = @ESTADO,
		MOTIVO = @MOTIVO,
		FECHA_APROBACION = GETDATE()
	WHERE
		CODIGO = @CODIGO;

	SET NOCOUNT OFF;

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LISTA_INFORME_POR_SOLICITUD]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_LISTA_INFORME_POR_SOLICITUD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[USP_LISTA_INFORME_POR_SOLICITUD]
@CODIGO_PROYECTO int,
@CODIGO_LINEABASE int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT  
		A.CODIGO,
		A.CODIGO_ECS,
		A.CODIGO_LINEA_BASE,
		A.CODIGO_PROYECTO,
		A.CODIGO_USUARIO,
		A.ESTADO,
		A.FECHA_REGISTRO,
		A.NOMBRE,
		A.PRIORIDAD,
		A.MOTIVO,
		B.CODIGO AS CODIGO_INFORME
	FROM [dbo].SOLICITUD_CAMBIO AS A LEFT OUTER JOIN [dbo].INFORME_CAMBIO AS B 
			ON A.CODIGO = B.CODIGO_SOLICITUD WHERE A.CODIGO_PROYECTO = @CODIGO_PROYECTO AND A.CODIGO_LINEA_BASE = @CODIGO_LINEABASE AND A.ESTADO = ''A'';

	SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_ORDEN_CAMBIO_UPD_ARCHIVO]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ORDEN_CAMBIO_UPD_ARCHIVO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE  PROCEDURE [dbo].[USP_ORDEN_CAMBIO_UPD_ARCHIVO]
@CODIGO INT,
@NOMBRE_ARCHIVO VARCHAR(50),
@EXTENSION CHAR(3),
@RUTA_ARCHIVO VARCHAR(MAX) OUTPUT,
@TRANSACTION_CONTEXT VARBINARY(MAX) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;	
	
	UPDATE 
		dbo.ORDEN_CAMBIO
	SET 
		NOMBRE_ARCHIVO = @NOMBRE_ARCHIVO,
		EXTENSION = @EXTENSION,
		DATA = CAST('''' AS VARBINARY(MAX))
	WHERE
		CODIGO = @CODIGO;
		
	SELECT 
		@RUTA_ARCHIVO = DATA.PathName(),
		@TRANSACTION_CONTEXT = GET_FILESTREAM_TRANSACTION_CONTEXT()
	FROM 
		dbo.ORDEN_CAMBIO
	WHERE 
		CODIGO = @CODIGO;

	SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_ORDEN_CAMBIO_SEL_PROYECTO_LINEABASE]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ORDEN_CAMBIO_SEL_PROYECTO_LINEABASE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_ORDEN_CAMBIO_SEL_PROYECTO_LINEABASE]
@CODIGO_PROYECTO INT,
@CODIGO_LINEABASE INT
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
		INNER JOIN dbo.SOLICITUD_CAMBIO AS S
		ON S.CODIGO = IC.CODIGO_SOLICITUD
	WHERE
		S.CODIGO_PROYECTO = @CODIGO_PROYECTO
		AND (@CODIGO_LINEABASE = 0 OR S.CODIGO_LINEA_BASE = @CODIGO_LINEABASE)
	SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_ORDEN_CAMBIO_SEL_INFORME]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ORDEN_CAMBIO_SEL_INFORME]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_ORDEN_CAMBIO_SEL_INFORME]
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_ORDEN_CAMBIO_SEL_CODIGO]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ORDEN_CAMBIO_SEL_CODIGO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_ORDEN_CAMBIO_SEL_CODIGO]
@CODIGO INT 
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT  
		OC.CODIGO, OC.NOMBRE AS NOMBRE_ORDEN, OC.CODIGO_INFORME, IC.NOMBRE, 
		OC.CODIGO_USUARIO_REG, OC.FECHA_REGISTRO, OC.PRIORIDAD, 
		OC.CODIGO_USUARIO_ASIGNADO, U.NOMBRE AS NOMBRE_USUARIO, OC.NOMBRE_ARCHIVO,
		P.CODIGO_PROYECTO, P.NOMBRE AS NOMBRE_PROYECTO,
		LB.CODIGO AS CODIGO_LINEA, LB.NOMBRE AS NOMBRE_LINEA
	FROM
		dbo.ORDEN_CAMBIO AS OC
		INNER JOIN dbo.INFORME_CAMBIO AS IC
		ON IC.CODIGO = OC.CODIGO_INFORME
		INNER JOIN dbo.SOLICITUD_CAMBIO AS S
		ON S.CODIGO = IC.CODIGO_SOLICITUD
		INNER JOIN dbo.PROYECTO AS P
		ON P.CODIGO_PROYECTO = S.CODIGO_PROYECTO
		INNER JOIN dbo.LINEA_BASE AS LB
		ON LB.CODIGO = S.CODIGO_LINEA_BASE
		INNER JOIN dbo.USUARIO AS U
		ON U.CODIGO_USUARIO = OC.CODIGO_USUARIO_ASIGNADO
	WHERE
		OC.CODIGO = @CODIGO
		
	SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_ORDEN_CAMBIO_SEL_ARCHIVO]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ORDEN_CAMBIO_SEL_ARCHIVO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_ORDEN_CAMBIO_SEL_ARCHIVO]
@CODIGO INT
AS
BEGIN
	SET NOCOUNT ON;	
	
	SELECT
		NOMBRE_ARCHIVO,
		DATA.PathName() AS RUTA_ARCHIVO,
		GET_FILESTREAM_TRANSACTION_CONTEXT() AS TRANSACTION_CONTEXT
	FROM 
		dbo.ORDEN_CAMBIO
	WHERE 
		CODIGO = @CODIGO;

	SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_ORDEN_CAMBIO_INS]    Script Date: 03/23/2013 16:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_ORDEN_CAMBIO_INS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[USP_ORDEN_CAMBIO_INS]
@CODIGO INT OUTPUT,
@NOMBRE VARCHAR(50),
@CODIGO_INFORME INT,
@CODIGO_USUARIO_REG INT,
@FECHA_REGISTRO DATE,
@CODIGO_USUARIO_ASIGNADO INT,
@PRIORIDAD INT
AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO dbo.ORDEN_CAMBIO(
		NOMBRE,
		CODIGO_INFORME,
		CODIGO_USUARIO_REG,
		FECHA_REGISTRO,
		CODIGO_USUARIO_ASIGNADO,
		PRIORIDAD)
	VALUES(
		@NOMBRE,
		@CODIGO_INFORME,
		@CODIGO_USUARIO_REG,
		@FECHA_REGISTRO,
		@CODIGO_USUARIO_ASIGNADO,
		@PRIORIDAD
	);
	
	SET @CODIGO = SCOPE_IDENTITY();
	
	SET NOCOUNT OFF;
END
' 
END
GO

/****** Object:  Table [dbo].[PLAN_MANTENIMIENTO_CABECERA]    Script Date: 04/03/2013 12:26:46 Gestion Mantenimiento ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PLAN_MANTENIMIENTO_CABECERA](
	[ID_PLAN] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_PLAN] [varchar](50) NOT NULL,
	[NOMBRE_PLAN] [varchar](250) NOT NULL,
	[ESTADO_PLAN] [int] NULL,
 CONSTRAINT [PK_PLAN_MANTENIMIENTO_CABECERA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PLAN] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INFORME_DETALLE]    Script Date: 04/03/2013 12:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INFORME_DETALLE](
	[NUMERO_INFORME] [int] NOT NULL,
	[ITEM_INFORME] [int] NOT NULL,
	[NUMERO_ORDEN] [varchar](50) NULL,
	[ITEM_ORDEN] [int] NULL,
	[RESULTADO_ATENCION] [varchar](250) NULL,
	[OBSERVACION_ATENCION] [varchar](250) NULL,
 CONSTRAINT [PK_INFORME_DETALLE] PRIMARY KEY CLUSTERED 
(
	[NUMERO_INFORME] ASC,
	[ITEM_INFORME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FRECUENCIA]    Script Date: 04/03/2013 12:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FRECUENCIA](
	[CODIGO_FRECUENCIA] [int] NOT NULL,
	[DESCRIPCION_FRECUENCIA] [varchar](250) NOT NULL,
	[DIAS_FRECUENCIA] [int] NOT NULL,
 CONSTRAINT [PK_FRECUENCIA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_FRECUENCIA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[FRECUENCIA] ([CODIGO_FRECUENCIA], [DESCRIPCION_FRECUENCIA], [DIAS_FRECUENCIA]) VALUES (1, N'Diario', 1)
INSERT [dbo].[FRECUENCIA] ([CODIGO_FRECUENCIA], [DESCRIPCION_FRECUENCIA], [DIAS_FRECUENCIA]) VALUES (2, N'Semanal', 7)
INSERT [dbo].[FRECUENCIA] ([CODIGO_FRECUENCIA], [DESCRIPCION_FRECUENCIA], [DIAS_FRECUENCIA]) VALUES (3, N'Quincenal', 15)
INSERT [dbo].[FRECUENCIA] ([CODIGO_FRECUENCIA], [DESCRIPCION_FRECUENCIA], [DIAS_FRECUENCIA]) VALUES (4, N'Mensual', 30)
INSERT [dbo].[FRECUENCIA] ([CODIGO_FRECUENCIA], [DESCRIPCION_FRECUENCIA], [DIAS_FRECUENCIA]) VALUES (5, N'Trimestral', 90)
INSERT [dbo].[FRECUENCIA] ([CODIGO_FRECUENCIA], [DESCRIPCION_FRECUENCIA], [DIAS_FRECUENCIA]) VALUES (6, N'Semestral', 180)
INSERT [dbo].[FRECUENCIA] ([CODIGO_FRECUENCIA], [DESCRIPCION_FRECUENCIA], [DIAS_FRECUENCIA]) VALUES (7, N'Anual', 360)
/****** Object:  Table [dbo].[EQUIPO_TIPO]    Script Date: 04/03/2013 12:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EQUIPO_TIPO](
	[CODIGO_TIPO_EQUIPO] [int] NOT NULL,
	[DESCRIPCION_TIPO_EQUIPO] [varchar](250) NOT NULL,
 CONSTRAINT [PK_EQUIPO_TIPO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_TIPO_EQUIPO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[EQUIPO_TIPO] ([CODIGO_TIPO_EQUIPO], [DESCRIPCION_TIPO_EQUIPO]) VALUES (1, N'DESKTOP')
INSERT [dbo].[EQUIPO_TIPO] ([CODIGO_TIPO_EQUIPO], [DESCRIPCION_TIPO_EQUIPO]) VALUES (2, N'PORTATIL')
INSERT [dbo].[EQUIPO_TIPO] ([CODIGO_TIPO_EQUIPO], [DESCRIPCION_TIPO_EQUIPO]) VALUES (3, N'IMPRESORA')
INSERT [dbo].[EQUIPO_TIPO] ([CODIGO_TIPO_EQUIPO], [DESCRIPCION_TIPO_EQUIPO]) VALUES (4, N'MONITOR')
INSERT [dbo].[EQUIPO_TIPO] ([CODIGO_TIPO_EQUIPO], [DESCRIPCION_TIPO_EQUIPO]) VALUES (5, N'SERVIDOR')
/****** Object:  Table [dbo].[CALENDARIO_LABORABLE]    Script Date: 04/03/2013 12:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CALENDARIO_LABORABLE](
	[FECHA_LABORABLE] [datetime] NOT NULL,
	[HORAS_LABORABLES] [int] NOT NULL,
 CONSTRAINT [PK_LABORABLE] PRIMARY KEY CLUSTERED 
(
	[FECHA_LABORABLE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CALENDARIO_LABORABLE] ([FECHA_LABORABLE], [HORAS_LABORABLES]) VALUES (CAST(0x0000A19300000000 AS DateTime), 8)
/****** Object:  Table [dbo].[ACTIVIDAD_TIPO]    Script Date: 04/03/2013 12:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACTIVIDAD_TIPO](
	[CODIGO_TIPO_ACTIVIDAD] [int] NOT NULL,
	[DESCRIPCION_TIPO_ACTIVIDAD] [varchar](250) NOT NULL,
 CONSTRAINT [PK_ACTIVIDAD_TIPO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_TIPO_ACTIVIDAD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ACTIVIDAD_TIPO] ([CODIGO_TIPO_ACTIVIDAD], [DESCRIPCION_TIPO_ACTIVIDAD]) VALUES (1, N'LIMPIEZA')
INSERT [dbo].[ACTIVIDAD_TIPO] ([CODIGO_TIPO_ACTIVIDAD], [DESCRIPCION_TIPO_ACTIVIDAD]) VALUES (2, N'PROGRAMA')
INSERT [dbo].[ACTIVIDAD_TIPO] ([CODIGO_TIPO_ACTIVIDAD], [DESCRIPCION_TIPO_ACTIVIDAD]) VALUES (3, N'INSTALACION FISICA')
INSERT [dbo].[ACTIVIDAD_TIPO] ([CODIGO_TIPO_ACTIVIDAD], [DESCRIPCION_TIPO_ACTIVIDAD]) VALUES (4, N'REPARACION')
INSERT [dbo].[ACTIVIDAD_TIPO] ([CODIGO_TIPO_ACTIVIDAD], [DESCRIPCION_TIPO_ACTIVIDAD]) VALUES (5, N'CAPACITACION')
INSERT [dbo].[ACTIVIDAD_TIPO] ([CODIGO_TIPO_ACTIVIDAD], [DESCRIPCION_TIPO_ACTIVIDAD]) VALUES (6, N'LUBRICACION')
/****** Object:  Table [dbo].[UNIDAD_TIEMPO]    Script Date: 04/03/2013 12:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UNIDAD_TIEMPO](
	[CODIGO_TIEMPO] [int] NOT NULL,
	[DESCRIPCION_TIEMPO] [varchar](250) NOT NULL,
 CONSTRAINT [PK_UNIDAD_TIEMPO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_TIEMPO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[UNIDAD_TIEMPO] ([CODIGO_TIEMPO], [DESCRIPCION_TIEMPO]) VALUES (1, N'días')
INSERT [dbo].[UNIDAD_TIEMPO] ([CODIGO_TIEMPO], [DESCRIPCION_TIEMPO]) VALUES (2, N'horas')
INSERT [dbo].[UNIDAD_TIEMPO] ([CODIGO_TIEMPO], [DESCRIPCION_TIEMPO]) VALUES (3, N'minutos')
/****** Object:  Table [dbo].[SOLICITUD_TIPO]    Script Date: 04/03/2013 12:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SOLICITUD_TIPO](
	[CODIGO_TIPO_SOLICITUD] [int] NOT NULL,
	[DESCRIPCION_TIPO_SOLICITUD] [varchar](250) NOT NULL,
 CONSTRAINT [PK_SOLICITUD_TIPO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_TIPO_SOLICITUD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[SOLICITUD_TIPO] ([CODIGO_TIPO_SOLICITUD], [DESCRIPCION_TIPO_SOLICITUD]) VALUES (1, N'Preventivo')
INSERT [dbo].[SOLICITUD_TIPO] ([CODIGO_TIPO_SOLICITUD], [DESCRIPCION_TIPO_SOLICITUD]) VALUES (2, N'Correctivo')
INSERT [dbo].[SOLICITUD_TIPO] ([CODIGO_TIPO_SOLICITUD], [DESCRIPCION_TIPO_SOLICITUD]) VALUES (3, N'Predictivo')
/****** Object:  Table [dbo].[SOLICITUD_ESTADO]    Script Date: 04/03/2013 12:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SOLICITUD_ESTADO](
	[CODIGO_ESTADO_SOLICITUD] [int] NOT NULL,
	[DESCRIPCION_ESTADO_SOLICITUD] [varchar](250) NOT NULL,
 CONSTRAINT [PK_SOLICITUD_ESTADO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_ESTADO_SOLICITUD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[SOLICITUD_ESTADO] ([CODIGO_ESTADO_SOLICITUD], [DESCRIPCION_ESTADO_SOLICITUD]) VALUES (1, N'Aperturado')
INSERT [dbo].[SOLICITUD_ESTADO] ([CODIGO_ESTADO_SOLICITUD], [DESCRIPCION_ESTADO_SOLICITUD]) VALUES (2, N'Programado')
INSERT [dbo].[SOLICITUD_ESTADO] ([CODIGO_ESTADO_SOLICITUD], [DESCRIPCION_ESTADO_SOLICITUD]) VALUES (3, N'Completado')
INSERT [dbo].[SOLICITUD_ESTADO] ([CODIGO_ESTADO_SOLICITUD], [DESCRIPCION_ESTADO_SOLICITUD]) VALUES (4, N'Anulado')
/****** Object:  Table [dbo].[ORDEN_TRABAJO_ESTADO]    Script Date: 04/03/2013 12:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ORDEN_TRABAJO_ESTADO](
	[CODIGO_ESTADO_OT] [int] NOT NULL,
	[DESCRIPCION_ESTADO_OT] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ORDEN_TRABAJO_ESTADO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_ESTADO_OT] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ORDEN_TRABAJO_ESTADO] ([CODIGO_ESTADO_OT], [DESCRIPCION_ESTADO_OT]) VALUES (1, N'Abierta')
INSERT [dbo].[ORDEN_TRABAJO_ESTADO] ([CODIGO_ESTADO_OT], [DESCRIPCION_ESTADO_OT]) VALUES (2, N'Cerrada')
INSERT [dbo].[ORDEN_TRABAJO_ESTADO] ([CODIGO_ESTADO_OT], [DESCRIPCION_ESTADO_OT]) VALUES (3, N'Anulada')
/****** Object:  Table [dbo].[PROCEDENCIA]    Script Date: 04/03/2013 12:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PROCEDENCIA](
	[CODIGO_PROCEDENCIA] [int] NOT NULL,
	[DESCRIPCION_PROCEDENCIA] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PROCEDENCIA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PROCEDENCIA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[PROCEDENCIA] ([CODIGO_PROCEDENCIA], [DESCRIPCION_PROCEDENCIA]) VALUES (1, N'Propio')
INSERT [dbo].[PROCEDENCIA] ([CODIGO_PROCEDENCIA], [DESCRIPCION_PROCEDENCIA]) VALUES (2, N'Externo')
/****** Object:  Table [dbo].[PLAN_MANTENIMIENTO_DETALLE]    Script Date: 04/03/2013 12:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PLAN_MANTENIMIENTO_DETALLE](
	[ID_ACTIVIDAD] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_PLAN] [varchar](50) NOT NULL,
	[ITEM_ACTIVIDAD] [int] NOT NULL,
	[CODIGO_TIPO_ACTIVIDAD] [int] NULL,
	[DESCRIPCION_ACTIVIDAD] [varchar](250) NULL,
	[PRIORIDAD_ACTIVIDAD] [int] NULL,
	[CODIGO_FRECUENCIA] [int] NULL,
	[PERSONAL_REQUERIDO] [int] NULL,
	[CODIGO_TIEMPO] [int] NULL,
	[TIEMPO_ACTIVIDAD] [int] NULL,
	[PROCEDIMIENTOS_PLAN] [varchar](250) NULL,
	[OBSERVACIONES_PLAN] [varchar](250) NULL,
 CONSTRAINT [PK_PLAN_MANTENIMIENTO_DETALLE] PRIMARY KEY CLUSTERED 
(
	[ID_ACTIVIDAD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EQUIPO_COMPUTO]    Script Date: 04/03/2013 12:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EQUIPO_COMPUTO](
	[CODIGO_EQUIPO] [varchar](10) NOT NULL,
	[NOMBRE_EQUIPO] [varchar](250) NOT NULL,
	[SERIE_EQUIPO] [varchar](50) NULL,
	[MARCA_EQUIPO] [varchar](50) NULL,
	[MODELO_EQUIPO] [varchar](50) NULL,
	[CARACTERISTICAS_EQUIPO] [varchar](250) NULL,
	[FECHA_COMPRA] [datetime] NULL,
	[FECHA_EXPIRACION_GARANTIA] [datetime] NULL,
	[FECHA_ULTIMO_MANTENIMIENTO_EQUIPO] [datetime] NULL,
	[CODIGO_AREA] [int] NULL,
	[CODIGO_TIPO_EQUIPO] [int] NULL,
	[CODIGO_PLAN] [varchar](50) NULL,
	[PROCEDENCIA_EQUIPO] [int] NOT NULL,
	[ESTADO_EQUIPO] [int] NULL,
 CONSTRAINT [PK_EQUIPO_COMPUTO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_EQUIPO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORDEN_TRABAJO_CABECERA]    Script Date: 04/03/2013 12:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ORDEN_TRABAJO_CABECERA](
	[NUMERO_ORDEN] [varchar](50) NOT NULL,
	[FECHA_EMISION_ORDEN] [datetime] NULL,
	[FECHA_INICIO_ORDEN] [datetime] NULL,
	[FECHA_FIN_ORDEN] [datetime] NULL,
	[HORAS_TRABAJO_ORDEN] [decimal](18, 2) NOT NULL,
	[OBSERVACIONES_ORDEN] [varchar](250) NULL,
	[CODIGO_EMPLEADO] [int] NULL,
	[NUMERO_SOLICITUD] [varchar](50) NULL,
	[ESTADO_ORDEN] [int] NOT NULL,
 CONSTRAINT [PK_ORDEN_TRABAJO_CABECERA] PRIMARY KEY CLUSTERED 
(
	[NUMERO_ORDEN] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPLEADO_ACTIVIDAD]    Script Date: 04/03/2013 12:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLEADO_ACTIVIDAD](
	[CODIGO_EMPLEADO] [int] NOT NULL,
	[CODIGO_TIPO_ACTIVIDAD] [int] NOT NULL,
	[ESPECIALIDAD] [int] NULL,
 CONSTRAINT [PK_EMPLEADO_ACTIVIDAD] PRIMARY KEY CLUSTERED 
(
	[CODIGO_EMPLEADO] ASC,
	[CODIGO_TIPO_ACTIVIDAD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SOLICITUD_CABECERA]    Script Date: 04/03/2013 12:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SOLICITUD_CABECERA](
	[NUMERO_SOLICITUD] [varchar](50) NOT NULL,
	[FECHA_SOLICITUD] [datetime] NULL,
	[TIPO_SOLICITUD] [int] NULL,
	[DOCUMENTO_REFERENCIA] [varchar](50) NULL,
	[FECHA_INICIO_SOLICITUD] [datetime] NULL,
	[FECHA_FIN_SOLICITUD] [datetime] NULL,
	[ESTADO_SOLICITUD] [int] NULL,
	[CODIGO_EQUIPO] [varchar](10) NULL,
	[CODIGO_PLAN] [varchar](50) NULL,
 CONSTRAINT [PK_SOLICITUD_CABECERA] PRIMARY KEY CLUSTERED 
(
	[NUMERO_SOLICITUD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORDEN_TRABAJO_DETALLE]    Script Date: 04/03/2013 12:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ORDEN_TRABAJO_DETALLE](
	[ID_ACTIVIDAD] [int] IDENTITY(1,1) NOT NULL,
	[NUMERO_ORDEN] [varchar](50) NOT NULL,
	[ITEM_ORDEN] [int] NOT NULL,
	[NUMERO_SOLICITUD] [varchar](50) NULL,
	[FECHA_INICIO_ACTIVIDAD] [datetime] NULL,
	[ITEM_SOLICITUD] [int] NULL,
	[FECHA_FIN_ACTIVIDAD] [datetime] NULL,
	[FECHA_PROGRAMADA] [datetime] NULL,
	[RESULTADO_ATENCION] [varchar](250) NULL,
 CONSTRAINT [PK_ORDEN_TRABAJO_DETALLE] PRIMARY KEY CLUSTERED 
(
	[ID_ACTIVIDAD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SOLICITUD_DETALLE]    Script Date: 04/03/2013 12:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SOLICITUD_DETALLE](
	[ID_ACTIVIDAD] [int] IDENTITY(1,1) NOT NULL,
	[NUMERO_SOLICITUD] [varchar](50) NOT NULL,
	[ITEM_SOLICITUD] [int] NOT NULL,
	[DESCRIPCION_ACTIVIDAD] [varchar](250) NULL,
	[CODIGO_TIPO_ACTIVIDAD] [int] NULL,
	[PRIORIDAD_ACTIVIDAD] [int] NULL,
	[CODIGO_FRECUENCIA] [int] NULL,
	[PERSONAL_REQUERIDO] [int] NULL,
	[CODIGO_TIEMPO] [int] NULL,
	[TIEMPO_ACTIVIDAD] [int] NULL,
	[FECHA_PROGRAMACION] [datetime] NULL,
	[ORDEN_TRABAJO] [varchar](50) NULL,
 CONSTRAINT [PK_SOLICITUD_DETALLE] PRIMARY KEY CLUSTERED 
(
	[ID_ACTIVIDAD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  StoredProcedure [dbo].[SET_INFORME_NUEVO]    Script Date: 04/03/2013 12:26:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SET_INFORME_NUEVO]
@FECHA_INFORME DATE,
@CODIGO_EMPLEADO INT,
@OBSERVACION_EMPLEADO VARCHAR(250),
@NUMERO INT OUT
AS
BEGIN
	DECLARE @NUMERO_INFORME INT
	
	SELECT @NUMERO_INFORME = COUNT(NUMERO_INFORME)+1 FROM [dbo].[INFORME_CABECERA];
	SET @NUMERO = @NUMERO_INFORME;
	
	INSERT INTO [dbo].[INFORME_CABECERA] 
	(NUMERO_INFORME, FECHA_INFORME, CODIGO_EMPLEADO, OBSERVACION_EMPLEADO)
	VALUES(@NUMERO_INFORME, @FECHA_INFORME, @CODIGO_EMPLEADO, @OBSERVACION_EMPLEADO);	
END
GO
/****** Object:  StoredProcedure [dbo].[SET_INFORME_DETALLE_ELIMINAR]    Script Date: 04/03/2013 12:26:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SET_INFORME_DETALLE_ELIMINAR]
@NUMERO_INFORME INT
AS
BEGIN
DELETE FROM [dbo].[INFORME_DETALLE]
WHERE NUMERO_INFORME = @NUMERO_INFORME;

END
GO
/****** Object:  StoredProcedure [dbo].[SET_INFORME_DETALLE]    Script Date: 04/03/2013 12:26:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SET_INFORME_DETALLE]
@NUMERO_INFORME INT, 
@ITEM_INFORME INT, 
@NUMERO_ORDEN VARCHAR(50), 
@ITEM_ORDEN INT, 
@RESULTADO_ATENCION VARCHAR(250)
AS
BEGIN
INSERT INTO [dbo].[INFORME_DETALLE]
(NUMERO_INFORME, ITEM_INFORME, NUMERO_ORDEN, ITEM_ORDEN, RESULTADO_ATENCION)
VALUES(@NUMERO_INFORME, @ITEM_INFORME, @NUMERO_ORDEN, @ITEM_ORDEN, @RESULTADO_ATENCION);

/*UPDATE [dbo].[ORDEN_TRABAJO_DETALLE]
SET RESULTADO_ATENCION = @RESULTADO_ATENCION
WHERE NUMERO_ORDEN = @NUMERO_ORDEN AND ITEM_ORDEN = @ITEM_ORDEN;
*/
END
GO
/****** Object:  StoredProcedure [dbo].[SET_INFORME_ACTUALIZAR]    Script Date: 04/03/2013 12:26:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SET_INFORME_ACTUALIZAR]
@NUMERO_INFORME INT,
@FECHA_INFORME DATE,
@CODIGO_EMPLEADO INT,
@OBSERVACION_EMPLEADO VARCHAR(250)
AS
BEGIN
	
	UPDATE [dbo].[INFORME_CABECERA] 
	SET FECHA_INFORME = @FECHA_INFORME, CODIGO_EMPLEADO=@CODIGO_EMPLEADO, OBSERVACION_EMPLEADO=@OBSERVACION_EMPLEADO
	WHERE NUMERO_INFORME = @NUMERO_INFORME;	
END
GO
/****** Object:  StoredProcedure [dbo].[GET_ACTIVIDAD_TIPO]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_ACTIVIDAD_TIPO]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CODIGO_TIPO_ACTIVIDAD CODIGO,
	DESCRIPCION_TIPO_ACTIVIDAD DESCRIPCION FROM ACTIVIDAD_TIPO
END
GO
/****** Object:  StoredProcedure [dbo].[GET_ESPECIALIDAD]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_ESPECIALIDAD]
AS
BEGIN
	SET NOCOUNT ON;


SELECT [CODIGO_TIPO_ACTIVIDAD]
      ,[DESCRIPCION_TIPO_ACTIVIDAD]
  FROM [dbo].[ACTIVIDAD_TIPO];

END
GO
/****** Object:  StoredProcedure [dbo].[GET_TIEMPO_UNIDAD]    Script Date: 04/03/2013 12:26:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_TIEMPO_UNIDAD]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CODIGO_TIEMPO CODIGO,
	DESCRIPCION_TIEMPO DESCRIPCION FROM UNIDAD_TIEMPO
END
GO
/****** Object:  StoredProcedure [dbo].[GET_FRECUENCIA]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_FRECUENCIA]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CODIGO_FRECUENCIA CODIGO,
	DESCRIPCION_FRECUENCIA DESCRIPCION FROM FRECUENCIA
END
GO
/****** Object:  StoredProcedure [dbo].[GET_SOLICITUD_ESTADO]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_SOLICITUD_ESTADO]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CODIGO_ESTADO_SOLICITUD,DESCRIPCION_ESTADO_SOLICITUD FROM SOLICITUD_ESTADO
END
GO
/****** Object:  StoredProcedure [dbo].[GET_PRIORIDAD]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_PRIORIDAD]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT  CODIGO,
	 NOMBRE DESCRIPCION FROM PRIORIDAD
END
GO
/****** Object:  StoredProcedure [dbo].[GET_PLAN_NUEVO]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_PLAN_NUEVO]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CONVERT(VARCHAR(4),DATEPART(YEAR, GETDATE()))+
	RIGHT('000000' +  CONVERT(VARCHAR, COUNT( CODIGO_PLAN) + 1),4)  NUMERO_PLAN
	FROM PLAN_MANTENIMIENTO_CABECERA
	WHERE CODIGO_PLAN LIKE CONVERT(VARCHAR(4),DATEPART(YEAR, GETDATE())) + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[GET_PLAN_MANTENIMIENTO_TODOS]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_PLAN_MANTENIMIENTO_TODOS]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CODIGO_PLAN,NOMBRE_PLAN,ESTADO_PLAN FROM PLAN_MANTENIMIENTO_CABECERA
END
GO
/****** Object:  StoredProcedure [dbo].[GET_PLAN_MANTENIMIENTO]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_PLAN_MANTENIMIENTO]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CODIGO_PLAN,NOMBRE_PLAN FROM PLAN_MANTENIMIENTO_CABECERA
	WHERE ESTADO_PLAN = 1
END
GO
/****** Object:  StoredProcedure [dbo].[GET_SOLICITUD_TIPO]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_SOLICITUD_TIPO]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CODIGO_TIPO_SOLICITUD,DESCRIPCION_TIPO_SOLICITUD FROM SOLICITUD_TIPO
END
GO
/****** Object:  StoredProcedure [dbo].[GET_ORDEN_TRABAJO_INFORME]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_ORDEN_TRABAJO_INFORME]
@CODIGO_EMPLEADO INT
AS
BEGIN
	SET NOCOUNT ON;

SELECT ot.NUMERO_ORDEN
    ,ot.OBSERVACIONES_ORDEN
    ,CONVERT(VARCHAR(10), ot.FECHA_EMISION_ORDEN, 103) AS FECHA_EMISION_ORDEN
    ,CONVERT(VARCHAR(10), ot.FECHA_INICIO_ORDEN, 103) AS FECHA_INICIO_ORDEN
    ,CONVERT(VARCHAR(10), ot.FECHA_FIN_ORDEN, 103) AS FECHA_FIN_ORDEN
    ,ot.HORAS_TRABAJO_ORDEN
  FROM [dbo].[ORDEN_TRABAJO_CABECERA] ot
  WHERE ot.ESTADO_ORDEN = 1
  AND ot.CODIGO_EMPLEADO = @CODIGO_EMPLEADO;

END
GO
/****** Object:  StoredProcedure [dbo].[GET_ORDENTRABAJO_NUEVA]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_ORDENTRABAJO_NUEVA]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CONVERT(VARCHAR(4),DATEPART(YEAR, GETDATE()))+ '-' +
	RIGHT('000000' +  CONVERT(VARCHAR, COUNT( NUMERO_ORDEN) + 1),6)  NUMERO_ORDEN
	
	
	FROM ORDEN_TRABAJO_CABECERA
	WHERE DATEPART(YEAR, FECHA_INICIO_ORDEN )=   DATEPART(YEAR, GETDATE())
END
GO

/****** Object:  StoredProcedure [dbo].[SET_EMPLEADO_ACTIVIDAD_ESPECIALIDAD]    Script Date: 04/03/2013 12:26:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SET_EMPLEADO_ACTIVIDAD_ESPECIALIDAD]
@CODIGO_EMPLEADO INT,
@CODIGO_TIPO_ACTIVIDAD INT,
@ESPECIALIDAD INT
AS
BEGIN

	UPDATE [dbo].[EMPLEADO_ACTIVIDAD] SET ESPECIALIDAD = @ESPECIALIDAD
	WHERE CODIGO_EMPLEADO = @CODIGO_EMPLEADO AND CODIGO_TIPO_ACTIVIDAD = @CODIGO_TIPO_ACTIVIDAD
		
END
GO
/****** Object:  StoredProcedure [dbo].[SET_EMPLEADO_ACTIVIDAD_ELIMINAR]    Script Date: 04/03/2013 12:26:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SET_EMPLEADO_ACTIVIDAD_ELIMINAR]
@CODIGO_EMPLEADO INT,
@CODIGO_TIPO_ACTIVIDAD INT
AS
BEGIN

	DELETE FROM [dbo].[EMPLEADO_ACTIVIDAD] 
	WHERE CODIGO_EMPLEADO = @CODIGO_EMPLEADO AND CODIGO_TIPO_ACTIVIDAD = @CODIGO_TIPO_ACTIVIDAD
		
END
GO
/****** Object:  StoredProcedure [dbo].[SET_EMPLEADO_ACTIVIDAD]    Script Date: 04/03/2013 12:26:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SET_EMPLEADO_ACTIVIDAD]
@CODIGO_EMPLEADO INT,
@CODIGO_TIPO_ACTIVIDAD INT,
@EXISTE INT OUTPUT
AS
BEGIN

	SET @EXISTE = 0;
	SELECT @EXISTE=COUNT(CODIGO_EMPLEADO) FROM [dbo].[EMPLEADO_ACTIVIDAD]
	WHERE CODIGO_EMPLEADO=@CODIGO_EMPLEADO AND CODIGO_TIPO_ACTIVIDAD=@CODIGO_TIPO_ACTIVIDAD
	
	IF @EXISTE = 0 
	BEGIN
	
	INSERT INTO [dbo].[EMPLEADO_ACTIVIDAD] (CODIGO_EMPLEADO, CODIGO_TIPO_ACTIVIDAD, ESPECIALIDAD)
	VALUES (@CODIGO_EMPLEADO, @CODIGO_TIPO_ACTIVIDAD, 1)
	
	END
	
END
GO
/****** Object:  StoredProcedure [dbo].[GET_EMPLEADOS]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_EMPLEADOS]
@NOMBRES VARCHAR(200)
AS
BEGIN
	SET NOCOUNT ON;

Select per.NOMBRE_PERSONA NOMBRES, per.APELLIDO_PATERNO, per.APELLIDO_MATERNO, per.NRO_DOCUMENTO DNI_PERSONA, 
emp.CODIGO_EMPLEADO, emp.CODIGO_AREA, emp.CODIGO_PUESTO, area.DESCRIPCION AS DESCRIPCION_AREA, 
puesto.DESCRIPCION DESCRIPCION_PUESTO, per.APELLIDO_PATERNO+' '+per.APELLIDO_MATERNO+', '+per.NOMBRE_PERSONA as NOMBRE_COMPLETO
from dbo.EMPLEADO emp
INNER JOIN dbo.PERSONA per on emp.CODIGO_EMPLEADO = per.CODIGO_PERSONA
INNER JOIN dbo.AREA area on area.CODIGO_AREA = emp.CODIGO_AREA
INNER JOIN dbo.PUESTO puesto on puesto.CODIGO_PUESTO = emp.CODIGO_PUESTO
WHERE per.APELLIDO_PATERNO LIKE '%'+@NOMBRES+'%' OR
per.APELLIDO_MATERNO LIKE '%'+@NOMBRES+'%' OR
per.NOMBRE_PERSONA LIKE '%'+@NOMBRES+'%';

END
GO
/****** Object:  StoredProcedure [dbo].[GET_SOLICITUDES]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_SOLICITUDES]
@NUMERO_SOLICITUD VARCHAR(50), 
@FECHA_INICIO_SOLICITUD DATETIME, 
@FECHA_FIN_SOLICITUD DATETIME,
@ESTADO_SOLICITUD INT, 
@TIPO_SOLICITUD INT, 
@DOCUMENTO_REFERENCIA VARCHAR(50), 
@CODIGO_EQUIPO INT , 
@CODIGO_PLAN VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT S.NUMERO_SOLICITUD,S.FECHA_SOLICITUD,S.TIPO_SOLICITUD,ST.DESCRIPCION_TIPO_SOLICITUD,
	S.DOCUMENTO_REFERENCIA,S.FECHA_INICIO_SOLICITUD,S.FECHA_FIN_SOLICITUD,
	S.ESTADO_SOLICITUD,SE.DESCRIPCION_ESTADO_SOLICITUD ,S.CODIGO_EQUIPO,E.NOMBRE_EQUIPO,
	S.CODIGO_PLAN,P.NOMBRE_PLAN,A.DESCRIPCION DESCRIPCION_AREA
	FROM SOLICITUD_CABECERA S
	INNER JOIN SOLICITUD_TIPO ST ON S.TIPO_SOLICITUD = ST.CODIGO_TIPO_SOLICITUD
	INNER JOIN SOLICITUD_ESTADO SE ON S.ESTADO_SOLICITUD = SE.CODIGO_ESTADO_SOLICITUD
	INNER JOIN EQUIPO_COMPUTO E ON S.CODIGO_EQUIPO = E.CODIGO_EQUIPO
	INNER JOIN PLAN_MANTENIMIENTO_CABECERA P ON S.CODIGO_PLAN = P.CODIGO_PLAN
	INNER JOIN AREA A ON E.CODIGO_AREA = A.CODIGO_AREA
	WHERE (S.NUMERO_SOLICITUD LIKE '%'+@NUMERO_SOLICITUD +'%' OR @NUMERO_SOLICITUD = '')
	AND ((NOT @FECHA_INICIO_SOLICITUD IS NULL AND S.FECHA_INICIO_SOLICITUD >= @FECHA_INICIO_SOLICITUD) OR (@FECHA_INICIO_SOLICITUD IS NULL))
	AND ((NOT @FECHA_FIN_SOLICITUD IS NULL AND S.FECHA_FIN_SOLICITUD <= @FECHA_FIN_SOLICITUD) OR (@FECHA_FIN_SOLICITUD IS NULL))
	AND ( @ESTADO_SOLICITUD = S.ESTADO_SOLICITUD OR @ESTADO_SOLICITUD = 0 )
	AND ( @TIPO_SOLICITUD = S.TIPO_SOLICITUD OR @TIPO_SOLICITUD = 0 )
	AND (S.DOCUMENTO_REFERENCIA LIKE '%' + @DOCUMENTO_REFERENCIA+'%' OR @DOCUMENTO_REFERENCIA = '')
	AND ( @CODIGO_EQUIPO = S.CODIGO_EQUIPO OR @CODIGO_EQUIPO = 0 )
	AND ( @CODIGO_PLAN = S.CODIGO_PLAN OR @CODIGO_PLAN = '' )
	
	--WHERE DATEPART(YEAR, FECHA_SOLICITUD )=   DATEPART(YEAR, GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[GET_ORDEN_TRABAJO]    Script Date: 04/07/2013 18:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_ORDEN_TRABAJO] 
	@NUMERO_OT VARCHAR(50), 
	@NUMERO_SOLICITUD VARCHAR(50), 
	@FECHA_INI DATETIME, 
	@FECHA_FIN DATETIME,
	@ESTADO_OT INT, 
	@CODIGO_RESPONSABLE INT
AS
BEGIN

	SET NOCOUNT ON;
	SELECT OT.NUMERO_ORDEN,
		   OT.FECHA_EMISION_ORDEN,
		   P.NOMBRE_PERSONA  + ' ' + P.APELLIDO_PATERNO + ' ' + P.APELLIDO_MATERNO NOMBRE_RESPONSABLE,
		   OT.HORAS_TRABAJO_ORDEN,
		   OT.NUMERO_SOLICITUD, 
		   EO.DESCRIPCION_ESTADO_OT,
		   OT.ESTADO_ORDEN
	  FROM ORDEN_TRABAJO_CABECERA OT 
		   INNER JOIN SOLICITUD_CABECERA S ON OT.NUMERO_SOLICITUD = S.NUMERO_SOLICITUD 
		   INNER JOIN EMPLEADO E ON OT.CODIGO_EMPLEADO = E.CODIGO_EMPLEADO
		   INNER JOIN PERSONA P ON E.CODIGO_EMPLEADO = P.CODIGO_PERSONA
		   INNER JOIN ORDEN_TRABAJO_ESTADO EO ON OT.ESTADO_ORDEN =EO.CODIGO_ESTADO_OT
	 WHERE  (OT.NUMERO_ORDEN = @NUMERO_OT OR @NUMERO_OT = '' )
	 AND (S.NUMERO_SOLICITUD = @NUMERO_SOLICITUD OR @NUMERO_SOLICITUD = '')
	 AND (OT.CODIGO_EMPLEADO = @CODIGO_RESPONSABLE OR @CODIGO_RESPONSABLE = 0)
	 AND S.ESTADO_SOLICITUD IN ('2')
	 AND (OT.ESTADO_ORDEN = @ESTADO_OT OR @ESTADO_OT = 0)
	 AND OT.FECHA_EMISION_ORDEN BETWEEN @FECHA_INI AND @FECHA_FIN
   
END;
--
GO
/****** Object:  StoredProcedure [dbo].[GET_INFORMES]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_INFORMES]
@NUMERO INT
,@CODIGO_EMPLEADO INT
,@OBSERVACION VARCHAR(200)
,@FECHA DATE
AS
BEGIN

SELECT inf.NUMERO_INFORME
      ,inf.FECHA_INFORME
      ,inf.CODIGO_EMPLEADO
      ,inf.OBSERVACION_EMPLEADO
      ,per.APELLIDO_PATERNO+' '+per.APELLIDO_MATERNO+', '+per.NOMBRE_PERSONA as NOMBRES
      ,CONVERT(VARCHAR(10), inf.FECHA_INFORME, 103) AS FECHA
  FROM [dbo].[INFORME_CABECERA] inf
  inner join [dbo].[EMPLEADO] emp on inf.CODIGO_EMPLEADO = emp.CODIGO_EMPLEADO
  inner join [dbo].[PERSONA] per on emp.CODIGO_EMPLEADO = per.CODIGO_PERSONA
  WHERE inf.NUMERO_INFORME = CASE WHEN @NUMERO = 0 THEN inf.NUMERO_INFORME ELSE @NUMERO END
  AND inf.CODIGO_EMPLEADO = CASE WHEN @CODIGO_EMPLEADO = 0 THEN inf.CODIGO_EMPLEADO ELSE @CODIGO_EMPLEADO END
  AND inf.OBSERVACION_EMPLEADO LIKE '%'+@OBSERVACION+'%'
  AND CONVERT(DATE, inf.FECHA_INFORME) = CASE WHEN YEAR(@FECHA) = 1 THEN CONVERT(DATE, inf.FECHA_INFORME) ELSE @FECHA END;

END
GO
/****** Object:  StoredProcedure [dbo].[GET_ESPECIALIDAD_EMP]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_ESPECIALIDAD_EMP]
@CODIGO_EMPLEADO int
AS
BEGIN
	SET NOCOUNT ON;


Select act.CODIGO_TIPO_ACTIVIDAD, act.DESCRIPCION_TIPO_ACTIVIDAD, cast(empact.ESPECIALIDAD as bit) as ESPECIALIDAD
from dbo.ACTIVIDAD_TIPO act
inner join dbo.EMPLEADO_ACTIVIDAD empact on act.CODIGO_TIPO_ACTIVIDAD = empact.CODIGO_TIPO_ACTIVIDAD
where empact.CODIGO_EMPLEADO = @CODIGO_EMPLEADO;

END
GO
/****** Object:  StoredProcedure [dbo].[GET_SOLICITUD_NUEVA]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_SOLICITUD_NUEVA]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CONVERT(VARCHAR(4),DATEPART(YEAR, GETDATE()))+
	RIGHT('000000' +  CONVERT(VARCHAR, COUNT( CODIGO_PLAN) + 1),6)  NUMERO_SOLICITUD
	
	
	FROM SOLICITUD_CABECERA
	WHERE DATEPART(YEAR, FECHA_SOLICITUD )=   DATEPART(YEAR, GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[GET_ORDEN_TRABAJO_DETALLE]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_ORDEN_TRABAJO_DETALLE]
@NUMERO_ORDEN VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

  SELECT 
    CONVERT(VARCHAR(10), od.FECHA_PROGRAMADA, 103) AS FECHA_PROGRAMADA
    ,od.ITEM_ORDEN
    ,sd.DESCRIPCION_ACTIVIDAD
    ,od.RESULTADO_ATENCION
  FROM 
  [dbo].[ORDEN_TRABAJO_DETALLE] od 
  inner join [dbo].[SOLICITUD_DETALLE] sd on od.NUMERO_SOLICITUD = sd.NUMERO_SOLICITUD and od.ITEM_SOLICITUD = sd.ITEM_SOLICITUD
  WHERE od.NUMERO_ORDEN = @NUMERO_ORDEN;

END
GO
/****** Object:  StoredProcedure [dbo].[GET_ORDEN_TRABAJO_INFORME_DETALLE]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_ORDEN_TRABAJO_INFORME_DETALLE]
@NUMERO_ORDEN VARCHAR(50),
@NUMERO_INFORME INT
AS
BEGIN
	SET NOCOUNT ON;

  SELECT 
    CONVERT(VARCHAR(10), od.FECHA_PROGRAMADA, 103) AS FECHA_PROGRAMADA
    ,od.ITEM_ORDEN
    ,sd.DESCRIPCION_ACTIVIDAD
    ,id.RESULTADO_ATENCION
  FROM 
  [dbo].[ORDEN_TRABAJO_DETALLE] od 
  inner join [dbo].[SOLICITUD_DETALLE] sd on od.NUMERO_SOLICITUD = sd.NUMERO_SOLICITUD and od.ITEM_SOLICITUD = sd.ITEM_SOLICITUD
  INNER JOIN [dbo].[INFORME_DETALLE] id on od.NUMERO_ORDEN = id.NUMERO_ORDEN and od.ITEM_ORDEN = id.ITEM_ORDEN 
    and od.ITEM_ORDEN = id.ITEM_INFORME
  WHERE od.NUMERO_ORDEN = @NUMERO_ORDEN and id.NUMERO_INFORME = @NUMERO_INFORME;

END
GO
/****** Object:  StoredProcedure [dbo].[GET_EQUIPOS_PENDIENTES_OT]    Script Date: 04/03/2013 12:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_EQUIPOS_PENDIENTES_OT] 
	@FECHA_INI DATETIME, 
	@FECHA_FIN DATETIME
AS
BEGIN

	SET NOCOUNT ON;
	SELECT DISTINCT E.CODIGO_EQUIPO,
		   E.NOMBRE_EQUIPO,
		   ET.DESCRIPCION_TIPO_EQUIPO,
		   PM.NOMBRE_PLAN,
		   S.NUMERO_SOLICITUD
	  FROM EQUIPO_COMPUTO E 
	  INNER JOIN EQUIPO_TIPO ET ON E.CODIGO_TIPO_EQUIPO = ET.CODIGO_TIPO_EQUIPO
	  INNER JOIN PLAN_MANTENIMIENTO_CABECERA PM ON E.CODIGO_PLAN = PM.CODIGO_PLAN
	  INNER JOIN SOLICITUD_CABECERA S ON E.CODIGO_EQUIPO = S.CODIGO_EQUIPO AND PM.CODIGO_PLAN = S.CODIGO_PLAN
	  INNER JOIN SOLICITUD_DETALLE SD ON S.NUMERO_SOLICITUD = SD.NUMERO_SOLICITUD
	  LEFT JOIN ORDEN_TRABAJO_CABECERA OT ON S.NUMERO_SOLICITUD = OT.NUMERO_SOLICITUD AND OT.ESTADO_ORDEN = 3
	 WHERE  
	 SD.FECHA_PROGRAMACION BETWEEN @FECHA_INI AND @FECHA_FIN
	 AND S.ESTADO_SOLICITUD IN ('2')
   
END;
--
GO
/****** Object:  StoredProcedure [dbo].[GET_ACTIVIDADES_PENDIENTES_OT]    Script Date: 04/07/2013 18:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_ACTIVIDADES_PENDIENTES_OT] 
	@CODIGO_EQUIPO VARCHAR(10)
AS
BEGIN

	SET NOCOUNT ON;
	SELECT DISTINCT 
			SD.ID_ACTIVIDAD,
			SD.ITEM_SOLICITUD ITEM_ORDEN,
		   SD.DESCRIPCION_ACTIVIDAD,
		   AT.DESCRIPCION_TIPO_ACTIVIDAD,
		   NULL FECHA_CRONOGRAMA,
		   SD.FECHA_PROGRAMACION,
		   SD.TIEMPO_ACTIVIDAD,
		   UT.DESCRIPCION_TIEMPO,
		   SD.CODIGO_TIEMPO
	  FROM EQUIPO_COMPUTO E 
	  INNER JOIN EQUIPO_TIPO ET ON E.CODIGO_TIPO_EQUIPO = ET.CODIGO_TIPO_EQUIPO
	  INNER JOIN PLAN_MANTENIMIENTO_CABECERA PM ON E.CODIGO_PLAN = PM.CODIGO_PLAN
	  INNER JOIN SOLICITUD_CABECERA S ON E.CODIGO_EQUIPO = S.CODIGO_EQUIPO AND PM.CODIGO_PLAN = S.CODIGO_PLAN
	  INNER JOIN SOLICITUD_DETALLE SD ON S.NUMERO_SOLICITUD = SD.NUMERO_SOLICITUD
	  INNER JOIN ACTIVIDAD_TIPO AT ON SD.CODIGO_TIPO_ACTIVIDAD =AT.CODIGO_TIPO_ACTIVIDAD
	  INNER JOIN UNIDAD_TIEMPO UT ON SD.CODIGO_TIEMPO = UT.CODIGO_TIEMPO
	  LEFT JOIN ORDEN_TRABAJO_CABECERA OT ON S.NUMERO_SOLICITUD = OT.NUMERO_SOLICITUD AND OT.ESTADO_ORDEN = 3
	 WHERE  
	 --SD.FECHA_PROGRAMACION BETWEEN @FECHA_INI AND @FECHA_FIN
	 S.ESTADO_SOLICITUD IN ('2')--SOLO LAS PROGRAMADAS
	 AND E.CODIGO_EQUIPO = @CODIGO_EQUIPO
   
END;
--
GO
/****** Object:  StoredProcedure [dbo].[GET_DISPONIBILIDAD_RESPONSABLE]    Script Date: 04/07/2013 18:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_DISPONIBILIDAD_RESPONSABLE] 
	@CODIGO_EMPLEADO INT
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT COUNT(OT.NUMERO_ORDEN) CANTIDAD_OT, SUM(OT.HORAS_TRABAJO_ORDEN) HORAS_OT FROM ORDEN_TRABAJO_CABECERA OT 
	WHERE OT.CODIGO_EMPLEADO = @CODIGO_EMPLEADO
	AND OT.ESTADO_ORDEN = 1 -- OT Abiertas
	
   
END;
GO
/****** Object:  Table [dbo].[AREA]    Script Date: 04/03/2013 12:26:46 ******/
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[AREA] ([CODIGO_AREA], [DESCRIPCION], [VISION], [MISION], [CODIGO_ORGANIZACION]) VALUES (1, N'CONTABILIDAD', NULL, NULL, 1)
INSERT [dbo].[AREA] ([CODIGO_AREA], [DESCRIPCION], [VISION], [MISION], [CODIGO_ORGANIZACION]) VALUES (2, N'COBRANZAS', NULL, NULL, 1)
INSERT [dbo].[AREA] ([CODIGO_AREA], [DESCRIPCION], [VISION], [MISION], [CODIGO_ORGANIZACION]) VALUES (3, N'SISTEMAS', NULL, NULL, 1)
INSERT [dbo].[AREA] ([CODIGO_AREA], [DESCRIPCION], [VISION], [MISION], [CODIGO_ORGANIZACION]) VALUES (4, N'RECEPCION', NULL, NULL, 1)
INSERT [dbo].[AREA] ([CODIGO_AREA], [DESCRIPCION], [VISION], [MISION], [CODIGO_ORGANIZACION]) VALUES (5, N'ADMINISTRACION', NULL, NULL, 1)
INSERT [dbo].[AREA] ([CODIGO_AREA], [DESCRIPCION], [VISION], [MISION], [CODIGO_ORGANIZACION]) VALUES (6, N'FINANZAS', NULL, NULL, 1)
INSERT [dbo].[AREA] ([CODIGO_AREA], [DESCRIPCION], [VISION], [MISION], [CODIGO_ORGANIZACION]) VALUES (7, N'AUDITORIA', NULL, NULL, 1)
INSERT [dbo].[AREA] ([CODIGO_AREA], [DESCRIPCION], [VISION], [MISION], [CODIGO_ORGANIZACION]) VALUES (8, N'EMPAQUE', NULL, NULL, 1)
INSERT [dbo].[AREA] ([CODIGO_AREA], [DESCRIPCION], [VISION], [MISION], [CODIGO_ORGANIZACION]) VALUES (9, N'GERENCIA', NULL, NULL, 1)
INSERT [dbo].[AREA] ([CODIGO_AREA], [DESCRIPCION], [VISION], [MISION], [CODIGO_ORGANIZACION]) VALUES (10, N'VENTAS', NULL, NULL, 1)
/****** Object:  Table [dbo].[PUESTO]    Script Date: 04/03/2013 12:26:46 ******/
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[PUESTO] ([CODIGO_PUESTO], [DESCRIPCION]) VALUES (1, N'ASISTENTE CONTABLE')
INSERT [dbo].[PUESTO] ([CODIGO_PUESTO], [DESCRIPCION]) VALUES (2, N'ASISTENTE ADMINISTRATIVO')
INSERT [dbo].[PUESTO] ([CODIGO_PUESTO], [DESCRIPCION]) VALUES (3, N'CAJERO')
INSERT [dbo].[PUESTO] ([CODIGO_PUESTO], [DESCRIPCION]) VALUES (4, N'DIGITADOR')
INSERT [dbo].[PUESTO] ([CODIGO_PUESTO], [DESCRIPCION]) VALUES (5, N'CONTADOR')
INSERT [dbo].[PUESTO] ([CODIGO_PUESTO], [DESCRIPCION]) VALUES (6, N'AUDITOR')
INSERT [dbo].[PUESTO] ([CODIGO_PUESTO], [DESCRIPCION]) VALUES (7, N'GERENTE GENERAL')
INSERT [dbo].[PUESTO] ([CODIGO_PUESTO], [DESCRIPCION]) VALUES (8, N'RECEPCIONISTA')
INSERT [dbo].[PUESTO] ([CODIGO_PUESTO], [DESCRIPCION]) VALUES (9, N'GERENTE FINANZAS')
INSERT [dbo].[PUESTO] ([CODIGO_PUESTO], [DESCRIPCION]) VALUES (10, N'JEFE DE SISTEMAS')
INSERT [dbo].[PUESTO] ([CODIGO_PUESTO], [DESCRIPCION]) VALUES (11, N'TECNICO')
GO
/****** Object:  Check [CK_CLIENTE_TIPO_CLIENTE]    Script Date: 03/23/2013 16:50:46 ******/
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_CLIENTE_TIPO_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[dbo].[CLIENTE]'))
ALTER TABLE [dbo].[CLIENTE]  WITH CHECK ADD  CONSTRAINT [CK_CLIENTE_TIPO_CLIENTE] CHECK  (([TIPO_CLIENTE]='R' OR [TIPO_CLIENTE]='P'))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_CLIENTE_TIPO_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[dbo].[CLIENTE]'))
ALTER TABLE [dbo].[CLIENTE] CHECK CONSTRAINT [CK_CLIENTE_TIPO_CLIENTE]
GO
/****** Object:  ForeignKey [Relacion_05]    Script Date: 03/23/2013 16:50:47 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_05]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO_CLIENTE]'))
ALTER TABLE [dbo].[USUARIO_CLIENTE]  WITH CHECK ADD  CONSTRAINT [Relacion_05] FOREIGN KEY([CODIGO_CLIENTE])
REFERENCES [dbo].[CLIENTE] ([CODIGO_CLIENTE])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_05]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO_CLIENTE]'))
ALTER TABLE [dbo].[USUARIO_CLIENTE] CHECK CONSTRAINT [Relacion_05]
GO
/****** Object:  ForeignKey [Relacion_08]    Script Date: 03/23/2013 16:50:47 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_08]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO_CLIENTE]'))
ALTER TABLE [dbo].[USUARIO_CLIENTE]  WITH CHECK ADD  CONSTRAINT [Relacion_08] FOREIGN KEY([CODIGO_SEDE])
REFERENCES [dbo].[SEDE] ([CODIGO_SEDE])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_08]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO_CLIENTE]'))
ALTER TABLE [dbo].[USUARIO_CLIENTE] CHECK CONSTRAINT [Relacion_08]
GO
/****** Object:  ForeignKey [FK_USUARIO_PERFIL_USUARIO]    Script Date: 03/23/2013 16:50:47 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_USUARIO_PERFIL_USUARIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO]'))
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_PERFIL_USUARIO] FOREIGN KEY([CODIGO_PERFIL_USUARIO])
REFERENCES [dbo].[PERFIL_USUARIO] ([CODIGO_PERFIL_USUARIO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_USUARIO_PERFIL_USUARIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO]'))
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [FK_USUARIO_PERFIL_USUARIO]
GO
/****** Object:  ForeignKey [Relacion_30]    Script Date: 03/23/2013 16:50:48 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_30]') AND parent_object_id = OBJECT_ID(N'[dbo].[SOFTWARE]'))
ALTER TABLE [dbo].[SOFTWARE]  WITH CHECK ADD  CONSTRAINT [Relacion_30] FOREIGN KEY([CODIGO_CMDB])
REFERENCES [dbo].[CMDB] ([CODIGO_CMDB])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_30]') AND parent_object_id = OBJECT_ID(N'[dbo].[SOFTWARE]'))
ALTER TABLE [dbo].[SOFTWARE] CHECK CONSTRAINT [Relacion_30]
GO
/****** Object:  ForeignKey [FK_LECCION_APRENDIDA_PROCESO (MP)_LECCIONES_APRENDIDAS_PROCESO]    Script Date: 03/23/2013 16:50:48 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LECCION_APRENDIDA_PROCESO (MP)_LECCIONES_APRENDIDAS_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[LECCION_APRENDIDA_PROCESO]'))
ALTER TABLE [dbo].[LECCION_APRENDIDA_PROCESO]  WITH CHECK ADD  CONSTRAINT [FK_LECCION_APRENDIDA_PROCESO (MP)_LECCIONES_APRENDIDAS_PROCESO] FOREIGN KEY([CODIGO_LECCION_APRENDIDA])
REFERENCES [dbo].[LECCIONES_APRENDIDAS_PROCESO] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LECCION_APRENDIDA_PROCESO (MP)_LECCIONES_APRENDIDAS_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[LECCION_APRENDIDA_PROCESO]'))
ALTER TABLE [dbo].[LECCION_APRENDIDA_PROCESO] CHECK CONSTRAINT [FK_LECCION_APRENDIDA_PROCESO (MP)_LECCIONES_APRENDIDAS_PROCESO]
GO
/****** Object:  ForeignKey [FK_LECCION_APRENDIDA_PROCESO (MP)_PROCESO]    Script Date: 03/23/2013 16:50:48 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LECCION_APRENDIDA_PROCESO (MP)_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[LECCION_APRENDIDA_PROCESO]'))
ALTER TABLE [dbo].[LECCION_APRENDIDA_PROCESO]  WITH CHECK ADD  CONSTRAINT [FK_LECCION_APRENDIDA_PROCESO (MP)_PROCESO] FOREIGN KEY([CODIGO_LECCION_APRENDIDA])
REFERENCES [dbo].[PROCESO] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LECCION_APRENDIDA_PROCESO (MP)_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[LECCION_APRENDIDA_PROCESO]'))
ALTER TABLE [dbo].[LECCION_APRENDIDA_PROCESO] CHECK CONSTRAINT [FK_LECCION_APRENDIDA_PROCESO (MP)_PROCESO]
GO
/****** Object:  ForeignKey [Relacion_01]    Script Date: 03/23/2013 16:50:48 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_01]') AND parent_object_id = OBJECT_ID(N'[dbo].[PREGUNTA_ENCUESTA]'))
ALTER TABLE [dbo].[PREGUNTA_ENCUESTA]  WITH CHECK ADD  CONSTRAINT [Relacion_01] FOREIGN KEY([CODIGO_BANCO_PREGUNTAS])
REFERENCES [dbo].[BANCO_PREGUNTAS] ([CODIGO_BANCO_PREGUNTAS])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_01]') AND parent_object_id = OBJECT_ID(N'[dbo].[PREGUNTA_ENCUESTA]'))
ALTER TABLE [dbo].[PREGUNTA_ENCUESTA] CHECK CONSTRAINT [Relacion_01]
GO
/****** Object:  ForeignKey [Relacion_02]    Script Date: 03/23/2013 16:50:48 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_02]') AND parent_object_id = OBJECT_ID(N'[dbo].[PREGUNTA_ENCUESTA]'))
ALTER TABLE [dbo].[PREGUNTA_ENCUESTA]  WITH CHECK ADD  CONSTRAINT [Relacion_02] FOREIGN KEY([CODIGO_CUESTIONARIO_ENCUESTA])
REFERENCES [dbo].[CUESTIONARIO_ENCUESTA] ([CODIGO_CUESTIONARIO_ENCUESTA])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_02]') AND parent_object_id = OBJECT_ID(N'[dbo].[PREGUNTA_ENCUESTA]'))
ALTER TABLE [dbo].[PREGUNTA_ENCUESTA] CHECK CONSTRAINT [Relacion_02]
GO
/****** Object:  ForeignKey [FK_AC_CAPITULO_AC_NORMA]    Script Date: 03/23/2013 16:50:48 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_CAPITULO_AC_NORMA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_CAPITULO]'))
ALTER TABLE [dbo].[AC_CAPITULO]  WITH CHECK ADD  CONSTRAINT [FK_AC_CAPITULO_AC_NORMA] FOREIGN KEY([idNorma])
REFERENCES [dbo].[AC_NORMA] ([idNorma])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_CAPITULO_AC_NORMA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_CAPITULO]'))
ALTER TABLE [dbo].[AC_CAPITULO] CHECK CONSTRAINT [FK_AC_CAPITULO_AC_NORMA]
GO
/****** Object:  ForeignKey [FK_AC_ENTIDAD_AUDITADA_AC_AREA]    Script Date: 03/23/2013 16:50:48 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_ENTIDAD_AUDITADA_AC_AREA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_ENTIDAD_AUDITADA]'))
ALTER TABLE [dbo].[AC_ENTIDAD_AUDITADA]  WITH CHECK ADD  CONSTRAINT [FK_AC_ENTIDAD_AUDITADA_AC_AREA] FOREIGN KEY([idArea])
REFERENCES [dbo].[AREA] ([CODIGO_AREA])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_ENTIDAD_AUDITADA_AC_AREA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_ENTIDAD_AUDITADA]'))
ALTER TABLE [dbo].[AC_ENTIDAD_AUDITADA] CHECK CONSTRAINT [FK_AC_ENTIDAD_AUDITADA_AC_AREA]
GO
/****** Object:  ForeignKey [FK_INDICADOR_INDICADOR]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_INDICADOR_INDICADOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[INDICADOR]'))
ALTER TABLE [dbo].[INDICADOR]  WITH CHECK ADD  CONSTRAINT [FK_INDICADOR_INDICADOR] FOREIGN KEY([CODIGO])
REFERENCES [dbo].[INDICADOR] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_INDICADOR_INDICADOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[INDICADOR]'))
ALTER TABLE [dbo].[INDICADOR] CHECK CONSTRAINT [FK_INDICADOR_INDICADOR]
GO
/****** Object:  ForeignKey [FK_INDICADOR_PROCESO]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_INDICADOR_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[INDICADOR]'))
ALTER TABLE [dbo].[INDICADOR]  WITH CHECK ADD  CONSTRAINT [FK_INDICADOR_PROCESO] FOREIGN KEY([CODIGO_PROCESO])
REFERENCES [dbo].[PROCESO] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_INDICADOR_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[INDICADOR]'))
ALTER TABLE [dbo].[INDICADOR] CHECK CONSTRAINT [FK_INDICADOR_PROCESO]
GO
/****** Object:  ForeignKey [Relacion_29]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_29]') AND parent_object_id = OBJECT_ID(N'[dbo].[HARDWARE]'))
ALTER TABLE [dbo].[HARDWARE]  WITH CHECK ADD  CONSTRAINT [Relacion_29] FOREIGN KEY([CODIGO_CMDB])
REFERENCES [dbo].[CMDB] ([CODIGO_CMDB])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_29]') AND parent_object_id = OBJECT_ID(N'[dbo].[HARDWARE]'))
ALTER TABLE [dbo].[HARDWARE] CHECK CONSTRAINT [Relacion_29]
GO
/****** Object:  ForeignKey [FK_EMPLEADO_AC_AREA]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EMPLEADO_AC_AREA]') AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLEADO]'))
ALTER TABLE [dbo].[EMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADO_AC_AREA] FOREIGN KEY([CODIGO_AREA])
REFERENCES [dbo].[AREA] ([CODIGO_AREA])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EMPLEADO_AC_AREA]') AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLEADO]'))
ALTER TABLE [dbo].[EMPLEADO] CHECK CONSTRAINT [FK_EMPLEADO_AC_AREA]
GO
/****** Object:  ForeignKey [FK_EMPLEADO_AREA]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EMPLEADO_AREA]') AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLEADO]'))
ALTER TABLE [dbo].[EMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADO_AREA] FOREIGN KEY([CODIGO_AREA])
REFERENCES [dbo].[AREA] ([CODIGO_AREA])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EMPLEADO_AREA]') AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLEADO]'))
ALTER TABLE [dbo].[EMPLEADO] CHECK CONSTRAINT [FK_EMPLEADO_AREA]
GO
/****** Object:  ForeignKey [FK_EMPLEADO_EMPLEADO]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EMPLEADO_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLEADO]'))
ALTER TABLE [dbo].[EMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADO_EMPLEADO] FOREIGN KEY([CODIGO_JEFE])
REFERENCES [dbo].[EMPLEADO] ([CODIGO_EMPLEADO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EMPLEADO_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLEADO]'))
ALTER TABLE [dbo].[EMPLEADO] CHECK CONSTRAINT [FK_EMPLEADO_EMPLEADO]
GO
/****** Object:  ForeignKey [FK_EMPLEADO_PUESTO]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EMPLEADO_PUESTO]') AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLEADO]'))
ALTER TABLE [dbo].[EMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADO_PUESTO] FOREIGN KEY([CODIGO_PUESTO])
REFERENCES [dbo].[PUESTO] ([CODIGO_PUESTO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EMPLEADO_PUESTO]') AND parent_object_id = OBJECT_ID(N'[dbo].[EMPLEADO]'))
ALTER TABLE [dbo].[EMPLEADO] CHECK CONSTRAINT [FK_EMPLEADO_PUESTO]
GO
/****** Object:  ForeignKey [FK_ELEMENTO_CONFIGURACION_FASE]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ELEMENTO_CONFIGURACION_FASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[ELEMENTO_CONFIGURACION]'))
ALTER TABLE [dbo].[ELEMENTO_CONFIGURACION]  WITH CHECK ADD  CONSTRAINT [FK_ELEMENTO_CONFIGURACION_FASE] FOREIGN KEY([CODIGO_FASE])
REFERENCES [dbo].[FASE] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ELEMENTO_CONFIGURACION_FASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[ELEMENTO_CONFIGURACION]'))
ALTER TABLE [dbo].[ELEMENTO_CONFIGURACION] CHECK CONSTRAINT [FK_ELEMENTO_CONFIGURACION_FASE]
GO
/****** Object:  ForeignKey [Relacion_31]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_31]') AND parent_object_id = OBJECT_ID(N'[dbo].[DOCUMENTO]'))
ALTER TABLE [dbo].[DOCUMENTO]  WITH CHECK ADD  CONSTRAINT [Relacion_31] FOREIGN KEY([CODIGO_CMDB])
REFERENCES [dbo].[CMDB] ([CODIGO_CMDB])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_31]') AND parent_object_id = OBJECT_ID(N'[dbo].[DOCUMENTO]'))
ALTER TABLE [dbo].[DOCUMENTO] CHECK CONSTRAINT [Relacion_31]
GO
/****** Object:  ForeignKey [Relacion_13]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_13]') AND parent_object_id = OBJECT_ID(N'[dbo].[DETALLE_SLA]'))
ALTER TABLE [dbo].[DETALLE_SLA]  WITH CHECK ADD  CONSTRAINT [Relacion_13] FOREIGN KEY([CODIGO_SLA])
REFERENCES [dbo].[SLA] ([CODIGO_SLA])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_13]') AND parent_object_id = OBJECT_ID(N'[dbo].[DETALLE_SLA]'))
ALTER TABLE [dbo].[DETALLE_SLA] CHECK CONSTRAINT [Relacion_13]
GO
/****** Object:  ForeignKey [FK_ARTEFACTO_PROCESO_PROCESO]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ARTEFACTO_PROCESO_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ARTEFACTO_PROCESO]'))
ALTER TABLE [dbo].[ARTEFACTO_PROCESO]  WITH CHECK ADD  CONSTRAINT [FK_ARTEFACTO_PROCESO_PROCESO] FOREIGN KEY([CODIGO_PROCESO])
REFERENCES [dbo].[PROCESO] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ARTEFACTO_PROCESO_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ARTEFACTO_PROCESO]'))
ALTER TABLE [dbo].[ARTEFACTO_PROCESO] CHECK CONSTRAINT [FK_ARTEFACTO_PROCESO_PROCESO]
GO
/****** Object:  ForeignKey [Relacion_25]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_25]') AND parent_object_id = OBJECT_ID(N'[dbo].[INTEGRANTE]'))
ALTER TABLE [dbo].[INTEGRANTE]  WITH CHECK ADD  CONSTRAINT [Relacion_25] FOREIGN KEY([CODIGO_EMPLEADO])
REFERENCES [dbo].[EMPLEADO] ([CODIGO_EMPLEADO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_25]') AND parent_object_id = OBJECT_ID(N'[dbo].[INTEGRANTE]'))
ALTER TABLE [dbo].[INTEGRANTE] CHECK CONSTRAINT [Relacion_25]
GO
/****** Object:  ForeignKey [Relacion_27]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_27]') AND parent_object_id = OBJECT_ID(N'[dbo].[INTEGRANTE]'))
ALTER TABLE [dbo].[INTEGRANTE]  WITH CHECK ADD  CONSTRAINT [Relacion_27] FOREIGN KEY([CODIGO_EQUIPO])
REFERENCES [dbo].[EQUIPO] ([CODIGO_EQUIPO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_27]') AND parent_object_id = OBJECT_ID(N'[dbo].[INTEGRANTE]'))
ALTER TABLE [dbo].[INTEGRANTE] CHECK CONSTRAINT [Relacion_27]
GO
/****** Object:  ForeignKey [FK_ESCALA_CUANTITATIVO_INDICADOR]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESCALA_CUANTITATIVO_INDICADOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESCALA_CUANTITATIVO]'))
ALTER TABLE [dbo].[ESCALA_CUANTITATIVO]  WITH CHECK ADD  CONSTRAINT [FK_ESCALA_CUANTITATIVO_INDICADOR] FOREIGN KEY([CODIGO_INDICADOR])
REFERENCES [dbo].[INDICADOR] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESCALA_CUANTITATIVO_INDICADOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESCALA_CUANTITATIVO]'))
ALTER TABLE [dbo].[ESCALA_CUANTITATIVO] CHECK CONSTRAINT [FK_ESCALA_CUANTITATIVO_INDICADOR]
GO
/****** Object:  ForeignKey [FK_ESCALA_CUALITATIVO_INDICADOR]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESCALA_CUALITATIVO_INDICADOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESCALA_CUALITATIVO]'))
ALTER TABLE [dbo].[ESCALA_CUALITATIVO]  WITH CHECK ADD  CONSTRAINT [FK_ESCALA_CUALITATIVO_INDICADOR] FOREIGN KEY([CODIGO_INDICADOR])
REFERENCES [dbo].[INDICADOR] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESCALA_CUALITATIVO_INDICADOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESCALA_CUALITATIVO]'))
ALTER TABLE [dbo].[ESCALA_CUALITATIVO] CHECK CONSTRAINT [FK_ESCALA_CUALITATIVO_INDICADOR]
GO
/****** Object:  ForeignKey [FK_PILOTO_EMPLEADO]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PILOTO_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PILOTO]'))
ALTER TABLE [dbo].[PILOTO]  WITH CHECK ADD  CONSTRAINT [FK_PILOTO_EMPLEADO] FOREIGN KEY([CODIGO_EMPLEADO])
REFERENCES [dbo].[EMPLEADO] ([CODIGO_EMPLEADO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PILOTO_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PILOTO]'))
ALTER TABLE [dbo].[PILOTO] CHECK CONSTRAINT [FK_PILOTO_EMPLEADO]
GO
/****** Object:  ForeignKey [FK_PERSONA_CLIENTE]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PERSONA_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[dbo].[PERSONA]'))
ALTER TABLE [dbo].[PERSONA]  WITH CHECK ADD  CONSTRAINT [FK_PERSONA_CLIENTE] FOREIGN KEY([CODIGO_PERSONA])
REFERENCES [dbo].[CLIENTE] ([CODIGO_CLIENTE])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PERSONA_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[dbo].[PERSONA]'))
ALTER TABLE [dbo].[PERSONA] CHECK CONSTRAINT [FK_PERSONA_CLIENTE]
GO
/****** Object:  ForeignKey [FK_PERSONA_CLIENTE1]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PERSONA_CLIENTE1]') AND parent_object_id = OBJECT_ID(N'[dbo].[PERSONA]'))
ALTER TABLE [dbo].[PERSONA]  WITH CHECK ADD  CONSTRAINT [FK_PERSONA_CLIENTE1] FOREIGN KEY([CODIGO_PERSONA])
REFERENCES [dbo].[CLIENTE] ([CODIGO_CLIENTE])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PERSONA_CLIENTE1]') AND parent_object_id = OBJECT_ID(N'[dbo].[PERSONA]'))
ALTER TABLE [dbo].[PERSONA] CHECK CONSTRAINT [FK_PERSONA_CLIENTE1]
GO
/****** Object:  ForeignKey [FK_PERSONA_EMPLEADO]    Script Date: 03/23/2013 16:50:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PERSONA_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PERSONA]'))
ALTER TABLE [dbo].[PERSONA]  WITH CHECK ADD  CONSTRAINT [FK_PERSONA_EMPLEADO] FOREIGN KEY([CODIGO_PERSONA])
REFERENCES [dbo].[EMPLEADO] ([CODIGO_EMPLEADO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PERSONA_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PERSONA]'))
ALTER TABLE [dbo].[PERSONA] CHECK CONSTRAINT [FK_PERSONA_EMPLEADO]
GO
/****** Object:  ForeignKey [FK_Proyecto_CLIENTE]    Script Date: 03/23/2013 16:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Proyecto_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO]'))
ALTER TABLE [dbo].[PROYECTO]  WITH CHECK ADD  CONSTRAINT [FK_Proyecto_CLIENTE] FOREIGN KEY([CODIGO_CLIENTE])
REFERENCES [dbo].[CLIENTE] ([CODIGO_CLIENTE])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Proyecto_CLIENTE]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO]'))
ALTER TABLE [dbo].[PROYECTO] CHECK CONSTRAINT [FK_Proyecto_CLIENTE]
GO
/****** Object:  ForeignKey [FK_Proyecto_USUARIO]    Script Date: 03/23/2013 16:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Proyecto_USUARIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO]'))
ALTER TABLE [dbo].[PROYECTO]  WITH CHECK ADD  CONSTRAINT [FK_Proyecto_USUARIO] FOREIGN KEY([CODIGO_JEFE_PROYECTO])
REFERENCES [dbo].[USUARIO] ([CODIGO_USUARIO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Proyecto_USUARIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO]'))
ALTER TABLE [dbo].[PROYECTO] CHECK CONSTRAINT [FK_Proyecto_USUARIO]
GO
/****** Object:  ForeignKey [Relacion_10]    Script Date: 03/23/2013 16:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_10]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO]'))
ALTER TABLE [dbo].[PROYECTO]  WITH CHECK ADD  CONSTRAINT [Relacion_10] FOREIGN KEY([CODIGO_CLIENTE])
REFERENCES [dbo].[CLIENTE] ([CODIGO_CLIENTE])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_10]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO]'))
ALTER TABLE [dbo].[PROYECTO] CHECK CONSTRAINT [Relacion_10]
GO
/****** Object:  ForeignKey [FK_PROPUESTAMEJORA_EMPLEADO]    Script Date: 03/23/2013 16:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTAMEJORA_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTAMEJORA]'))
ALTER TABLE [dbo].[PROPUESTAMEJORA]  WITH CHECK ADD  CONSTRAINT [FK_PROPUESTAMEJORA_EMPLEADO] FOREIGN KEY([CODIGO_EMPLEADO])
REFERENCES [dbo].[EMPLEADO] ([CODIGO_EMPLEADO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTAMEJORA_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTAMEJORA]'))
ALTER TABLE [dbo].[PROPUESTAMEJORA] CHECK CONSTRAINT [FK_PROPUESTAMEJORA_EMPLEADO]
GO
/****** Object:  ForeignKey [FK_PROPUESTAMEJORA_PROCESO]    Script Date: 03/23/2013 16:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTAMEJORA_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTAMEJORA]'))
ALTER TABLE [dbo].[PROPUESTAMEJORA]  WITH NOCHECK ADD  CONSTRAINT [FK_PROPUESTAMEJORA_PROCESO] FOREIGN KEY([CODIGO_PROCESO])
REFERENCES [dbo].[PROCESO] ([CODIGO])
NOT FOR REPLICATION
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTAMEJORA_PROCESO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTAMEJORA]'))
ALTER TABLE [dbo].[PROPUESTAMEJORA] NOCHECK CONSTRAINT [FK_PROPUESTAMEJORA_PROCESO]
GO
/****** Object:  ForeignKey [FK_AC_AUDITADOS_EMPLEADO]    Script Date: 03/23/2013 16:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_AUDITADOS_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_AUDITADOS]'))
ALTER TABLE [dbo].[AC_AUDITADOS]  WITH CHECK ADD  CONSTRAINT [FK_AC_AUDITADOS_EMPLEADO] FOREIGN KEY([idAuditado])
REFERENCES [dbo].[EMPLEADO] ([CODIGO_EMPLEADO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_AUDITADOS_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_AUDITADOS]'))
ALTER TABLE [dbo].[AC_AUDITADOS] CHECK CONSTRAINT [FK_AC_AUDITADOS_EMPLEADO]
GO
/****** Object:  ForeignKey [FK_AC_DET_PREGUNTA_BASE_AC_CAPITULO]    Script Date: 03/23/2013 16:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_DET_PREGUNTA_BASE_AC_CAPITULO]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_DET_PREGUNTA_BASE]'))
ALTER TABLE [dbo].[AC_DET_PREGUNTA_BASE]  WITH CHECK ADD  CONSTRAINT [FK_AC_DET_PREGUNTA_BASE_AC_CAPITULO] FOREIGN KEY([idNorma], [idCapitulo])
REFERENCES [dbo].[AC_CAPITULO] ([idNorma], [idCapitulo])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_DET_PREGUNTA_BASE_AC_CAPITULO]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_DET_PREGUNTA_BASE]'))
ALTER TABLE [dbo].[AC_DET_PREGUNTA_BASE] CHECK CONSTRAINT [FK_AC_DET_PREGUNTA_BASE_AC_CAPITULO]
GO
/****** Object:  ForeignKey [FK_AC_DET_PREGUNTA_BASE_AC_PREGUNTA_BASE]    Script Date: 03/23/2013 16:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_DET_PREGUNTA_BASE_AC_PREGUNTA_BASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_DET_PREGUNTA_BASE]'))
ALTER TABLE [dbo].[AC_DET_PREGUNTA_BASE]  WITH CHECK ADD  CONSTRAINT [FK_AC_DET_PREGUNTA_BASE_AC_PREGUNTA_BASE] FOREIGN KEY([idPreguntaBase])
REFERENCES [dbo].[AC_PREGUNTA_BASE] ([idPreguntaBase])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_DET_PREGUNTA_BASE_AC_PREGUNTA_BASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_DET_PREGUNTA_BASE]'))
ALTER TABLE [dbo].[AC_DET_PREGUNTA_BASE] CHECK CONSTRAINT [FK_AC_DET_PREGUNTA_BASE_AC_PREGUNTA_BASE]
GO

/****** Object:  ForeignKey [FK_AC_AUDITORIA_AC_ENTIDAD_AUDITADA]    Script Date: 03/23/2013 16:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_AUDITORIA_AC_ENTIDAD_AUDITADA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AUDITORIA]'))
ALTER TABLE [dbo].[AUDITORIA]  WITH CHECK ADD  CONSTRAINT [FK_AC_AUDITORIA_AC_ENTIDAD_AUDITADA] FOREIGN KEY([CODIGO_ENTIDAD_AUDITADA])
REFERENCES [dbo].[AC_ENTIDAD_AUDITADA] ([idEntidadAuditada])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_AUDITORIA_AC_ENTIDAD_AUDITADA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AUDITORIA]'))
ALTER TABLE [dbo].[AUDITORIA] CHECK CONSTRAINT [FK_AC_AUDITORIA_AC_ENTIDAD_AUDITADA]
GO
/****** Object:  ForeignKey [FK_AC_AUDITORIA_AC_PROGRAMA_AUDITORIA]    Script Date: 03/23/2013 16:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_AUDITORIA_AC_PROGRAMA_AUDITORIA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AUDITORIA]'))
ALTER TABLE [dbo].[AUDITORIA]  WITH CHECK ADD  CONSTRAINT [FK_AC_AUDITORIA_AC_PROGRAMA_AUDITORIA] FOREIGN KEY([CODIGO_PROGRAMA])
REFERENCES [dbo].[AC_PROGRAMA_AUDITORIA] ([idPrograma])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_AUDITORIA_AC_PROGRAMA_AUDITORIA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AUDITORIA]'))
ALTER TABLE [dbo].[AUDITORIA] CHECK CONSTRAINT [FK_AC_AUDITORIA_AC_PROGRAMA_AUDITORIA]
GO
/****** Object:  ForeignKey [Relacion_04]    Script Date: 03/23/2013 16:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_04]') AND parent_object_id = OBJECT_ID(N'[dbo].[RESPUESTA_ENCUESTA]'))
ALTER TABLE [dbo].[RESPUESTA_ENCUESTA]  WITH CHECK ADD  CONSTRAINT [Relacion_04] FOREIGN KEY([CODIGO_USUARIO_CLIENTE], [CODIGO_CLIENTE])
REFERENCES [dbo].[USUARIO_CLIENTE] ([CODIGO_USUARIO_CLIENTE], [CODIGO_CLIENTE])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_04]') AND parent_object_id = OBJECT_ID(N'[dbo].[RESPUESTA_ENCUESTA]'))
ALTER TABLE [dbo].[RESPUESTA_ENCUESTA] CHECK CONSTRAINT [Relacion_04]
GO
/****** Object:  ForeignKey [Relacion_42]    Script Date: 03/23/2013 16:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_42]') AND parent_object_id = OBJECT_ID(N'[dbo].[RESPUESTA_ENCUESTA]'))
ALTER TABLE [dbo].[RESPUESTA_ENCUESTA]  WITH CHECK ADD  CONSTRAINT [Relacion_42] FOREIGN KEY([ORDEN_PREGUNTA_ENCUESTA], [CODIGO_CUESTIONARIO_ENCUESTA])
REFERENCES [dbo].[PREGUNTA_ENCUESTA] ([ORDEN_PREGUNTA_ENCUESTA], [CODIGO_CUESTIONARIO_ENCUESTA])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_42]') AND parent_object_id = OBJECT_ID(N'[dbo].[RESPUESTA_ENCUESTA]'))
ALTER TABLE [dbo].[RESPUESTA_ENCUESTA] CHECK CONSTRAINT [Relacion_42]
GO
/****** Object:  ForeignKey [FK_USUARIO_PROYECTO_Proyecto]    Script Date: 03/23/2013 16:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_USUARIO_PROYECTO_Proyecto]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO_PROYECTO]'))
ALTER TABLE [dbo].[USUARIO_PROYECTO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_PROYECTO_Proyecto] FOREIGN KEY([CODIGO_PROYECTO])
REFERENCES [dbo].[PROYECTO] ([CODIGO_PROYECTO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_USUARIO_PROYECTO_Proyecto]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO_PROYECTO]'))
ALTER TABLE [dbo].[USUARIO_PROYECTO] CHECK CONSTRAINT [FK_USUARIO_PROYECTO_Proyecto]
GO
/****** Object:  ForeignKey [FK_USUARIO_PROYECTO_USUARIO]    Script Date: 03/23/2013 16:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_USUARIO_PROYECTO_USUARIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO_PROYECTO]'))
ALTER TABLE [dbo].[USUARIO_PROYECTO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_PROYECTO_USUARIO] FOREIGN KEY([CODIGO_USUARIO])
REFERENCES [dbo].[USUARIO] ([CODIGO_USUARIO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_USUARIO_PROYECTO_USUARIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[USUARIO_PROYECTO]'))
ALTER TABLE [dbo].[USUARIO_PROYECTO] CHECK CONSTRAINT [FK_USUARIO_PROYECTO_USUARIO]
GO
/****** Object:  ForeignKey [FK_SOLUCION_MEJORA_EMPLEADO]    Script Date: 03/23/2013 16:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SOLUCION_MEJORA_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[SOLUCION_MEJORA]'))
ALTER TABLE [dbo].[SOLUCION_MEJORA]  WITH CHECK ADD  CONSTRAINT [FK_SOLUCION_MEJORA_EMPLEADO] FOREIGN KEY([CODIGO_EMPLEADO])
REFERENCES [dbo].[EMPLEADO] ([CODIGO_EMPLEADO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SOLUCION_MEJORA_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[SOLUCION_MEJORA]'))
ALTER TABLE [dbo].[SOLUCION_MEJORA] CHECK CONSTRAINT [FK_SOLUCION_MEJORA_EMPLEADO]
GO
/****** Object:  ForeignKey [FK_SOLUCION_MEJORA_PROPUESTAMEJORA]    Script Date: 03/23/2013 16:50:50 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SOLUCION_MEJORA_PROPUESTAMEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[SOLUCION_MEJORA]'))
ALTER TABLE [dbo].[SOLUCION_MEJORA]  WITH CHECK ADD  CONSTRAINT [FK_SOLUCION_MEJORA_PROPUESTAMEJORA] FOREIGN KEY([CODIGO_PROPUESTA])
REFERENCES [dbo].[PROPUESTAMEJORA] ([CODIGO_PROPUESTA])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SOLUCION_MEJORA_PROPUESTAMEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[SOLUCION_MEJORA]'))
ALTER TABLE [dbo].[SOLUCION_MEJORA] CHECK CONSTRAINT [FK_SOLUCION_MEJORA_PROPUESTAMEJORA]
GO
/****** Object:  ForeignKey [Relacion_09]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_09]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE]  WITH CHECK ADD  CONSTRAINT [Relacion_09] FOREIGN KEY([CODIGO_SEDE])
REFERENCES [dbo].[SEDE] ([CODIGO_SEDE])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_09]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE] CHECK CONSTRAINT [Relacion_09]
GO
/****** Object:  ForeignKey [Relacion_11]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_11]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE]  WITH CHECK ADD  CONSTRAINT [Relacion_11] FOREIGN KEY([CODIGO_SERVICIO])
REFERENCES [dbo].[SERVICIO] ([CODIGO_SERVICIO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_11]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE] CHECK CONSTRAINT [Relacion_11]
GO
/****** Object:  ForeignKey [Relacion_18]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_18]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE]  WITH CHECK ADD  CONSTRAINT [Relacion_18] FOREIGN KEY([CODIGO_PROYECTO])
REFERENCES [dbo].[PROYECTO] ([CODIGO_PROYECTO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_18]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE] CHECK CONSTRAINT [Relacion_18]
GO
/****** Object:  ForeignKey [Relacion_36]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_36]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE]  WITH CHECK ADD  CONSTRAINT [Relacion_36] FOREIGN KEY([CODIGO_DETALLE_SLA], [CODIGO_SLA])
REFERENCES [dbo].[DETALLE_SLA] ([CODIGO_DETALLE_SLA], [CODIGO_SLA])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_36]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE] CHECK CONSTRAINT [Relacion_36]
GO
/****** Object:  ForeignKey [FK_PROYECTO_FASE_FASE]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROYECTO_FASE_FASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_FASE]'))
ALTER TABLE [dbo].[PROYECTO_FASE]  WITH CHECK ADD  CONSTRAINT [FK_PROYECTO_FASE_FASE] FOREIGN KEY([CODIGO_FASE])
REFERENCES [dbo].[FASE] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROYECTO_FASE_FASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_FASE]'))
ALTER TABLE [dbo].[PROYECTO_FASE] CHECK CONSTRAINT [FK_PROYECTO_FASE_FASE]
GO
/****** Object:  ForeignKey [FK_PROYECTO_FASE_Proyecto1]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROYECTO_FASE_Proyecto1]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_FASE]'))
ALTER TABLE [dbo].[PROYECTO_FASE]  WITH CHECK ADD  CONSTRAINT [FK_PROYECTO_FASE_Proyecto1] FOREIGN KEY([CODIGO_PROYECTO])
REFERENCES [dbo].[PROYECTO] ([CODIGO_PROYECTO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROYECTO_FASE_Proyecto1]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_FASE]'))
ALTER TABLE [dbo].[PROYECTO_FASE] CHECK CONSTRAINT [FK_PROYECTO_FASE_Proyecto1]
GO
/****** Object:  ForeignKey [Relacion_34]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_34]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_CMDB]'))
ALTER TABLE [dbo].[PROYECTO_CMDB]  WITH CHECK ADD  CONSTRAINT [Relacion_34] FOREIGN KEY([CODIGO_CMDB])
REFERENCES [dbo].[CMDB] ([CODIGO_CMDB])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_34]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_CMDB]'))
ALTER TABLE [dbo].[PROYECTO_CMDB] CHECK CONSTRAINT [Relacion_34]
GO
/****** Object:  ForeignKey [Relacion_35]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_35]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_CMDB]'))
ALTER TABLE [dbo].[PROYECTO_CMDB]  WITH CHECK ADD  CONSTRAINT [Relacion_35] FOREIGN KEY([CODIGO_PROYECTO])
REFERENCES [dbo].[PROYECTO] ([CODIGO_PROYECTO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_35]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_CMDB]'))
ALTER TABLE [dbo].[PROYECTO_CMDB] CHECK CONSTRAINT [Relacion_35]
GO
/****** Object:  ForeignKey [Relacion_06]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_06]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_USUARIO_CLIENTE]'))
ALTER TABLE [dbo].[PROYECTO_USUARIO_CLIENTE]  WITH CHECK ADD  CONSTRAINT [Relacion_06] FOREIGN KEY([CODIGO_USUARIO_CLIENTE], [CODIGO_CLIENTE])
REFERENCES [dbo].[USUARIO_CLIENTE] ([CODIGO_USUARIO_CLIENTE], [CODIGO_CLIENTE])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_06]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_USUARIO_CLIENTE]'))
ALTER TABLE [dbo].[PROYECTO_USUARIO_CLIENTE] CHECK CONSTRAINT [Relacion_06]
GO
/****** Object:  ForeignKey [Relacion_07]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_07]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_USUARIO_CLIENTE]'))
ALTER TABLE [dbo].[PROYECTO_USUARIO_CLIENTE]  WITH CHECK ADD  CONSTRAINT [Relacion_07] FOREIGN KEY([CODIGO_PROYECTO])
REFERENCES [dbo].[PROYECTO] ([CODIGO_PROYECTO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_07]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_USUARIO_CLIENTE]'))
ALTER TABLE [dbo].[PROYECTO_USUARIO_CLIENTE] CHECK CONSTRAINT [Relacion_07]
GO
/****** Object:  ForeignKey [FK_AC_PREGUNTA_VERIFICACION_AC_AUDITORIA]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_PREGUNTA_VERIFICACION_AC_AUDITORIA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_PREGUNTA_VERIFICACION]'))
ALTER TABLE [dbo].[AC_PREGUNTA_VERIFICACION]  WITH CHECK ADD  CONSTRAINT [FK_AC_PREGUNTA_VERIFICACION_AC_AUDITORIA] FOREIGN KEY([idAuditoria])
REFERENCES [dbo].[AUDITORIA] ([CODIGO_AUDITORIA])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_PREGUNTA_VERIFICACION_AC_AUDITORIA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_PREGUNTA_VERIFICACION]'))
ALTER TABLE [dbo].[AC_PREGUNTA_VERIFICACION] CHECK CONSTRAINT [FK_AC_PREGUNTA_VERIFICACION_AC_AUDITORIA]
GO
/****** Object:  ForeignKey [FK_AC_ACTIVIDAD_AC_AUDITORIA]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_ACTIVIDAD_AC_AUDITORIA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_ACTIVIDAD]'))
ALTER TABLE [dbo].[AC_ACTIVIDAD]  WITH CHECK ADD  CONSTRAINT [FK_AC_ACTIVIDAD_AC_AUDITORIA] FOREIGN KEY([idAuditoria])
REFERENCES [dbo].[AUDITORIA] ([CODIGO_AUDITORIA])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_ACTIVIDAD_AC_AUDITORIA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_ACTIVIDAD]'))
ALTER TABLE [dbo].[AC_ACTIVIDAD] CHECK CONSTRAINT [FK_AC_ACTIVIDAD_AC_AUDITORIA]
GO
/****** Object:  ForeignKey [FK_AC_AUDITOR_AC_AUDITORIA]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_AUDITOR_AC_AUDITORIA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_AUDITOR]'))
ALTER TABLE [dbo].[AC_AUDITOR]  WITH CHECK ADD  CONSTRAINT [FK_AC_AUDITOR_AC_AUDITORIA] FOREIGN KEY([idAuditoria])
REFERENCES [dbo].[AUDITORIA] ([CODIGO_AUDITORIA])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_AUDITOR_AC_AUDITORIA]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_AUDITOR]'))
ALTER TABLE [dbo].[AC_AUDITOR] CHECK CONSTRAINT [FK_AC_AUDITOR_AC_AUDITORIA]
GO
/****** Object:  ForeignKey [FK_PROPUESTA_INDICADOR_INDICADOR]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_INDICADOR_INDICADOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_INDICADOR]'))
ALTER TABLE [dbo].[PROPUESTA_INDICADOR]  WITH CHECK ADD  CONSTRAINT [FK_PROPUESTA_INDICADOR_INDICADOR] FOREIGN KEY([CODIGO_INDICADOR])
REFERENCES [dbo].[INDICADOR] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_INDICADOR_INDICADOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_INDICADOR]'))
ALTER TABLE [dbo].[PROPUESTA_INDICADOR] CHECK CONSTRAINT [FK_PROPUESTA_INDICADOR_INDICADOR]
GO
/****** Object:  ForeignKey [FK_PROPUESTA_INDICADOR_PROPUESTAMEJORA]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_INDICADOR_PROPUESTAMEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_INDICADOR]'))
ALTER TABLE [dbo].[PROPUESTA_INDICADOR]  WITH CHECK ADD  CONSTRAINT [FK_PROPUESTA_INDICADOR_PROPUESTAMEJORA] FOREIGN KEY([CODIGO_PROPUESTA])
REFERENCES [dbo].[PROPUESTAMEJORA] ([CODIGO_PROPUESTA])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_INDICADOR_PROPUESTAMEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_INDICADOR]'))
ALTER TABLE [dbo].[PROPUESTA_INDICADOR] CHECK CONSTRAINT [FK_PROPUESTA_INDICADOR_PROPUESTAMEJORA]
GO
/****** Object:  ForeignKey [FK_PROPUESTA_ESTADO_EMPLEADO]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_ESTADO_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_ESTADO]'))
ALTER TABLE [dbo].[PROPUESTA_ESTADO]  WITH CHECK ADD  CONSTRAINT [FK_PROPUESTA_ESTADO_EMPLEADO] FOREIGN KEY([CODIGO_EMPLEADO])
REFERENCES [dbo].[EMPLEADO] ([CODIGO_EMPLEADO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_ESTADO_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_ESTADO]'))
ALTER TABLE [dbo].[PROPUESTA_ESTADO] CHECK CONSTRAINT [FK_PROPUESTA_ESTADO_EMPLEADO]
GO
/****** Object:  ForeignKey [FK_PROPUESTA_ESTADO_ESTADO]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_ESTADO_ESTADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_ESTADO]'))
ALTER TABLE [dbo].[PROPUESTA_ESTADO]  WITH CHECK ADD  CONSTRAINT [FK_PROPUESTA_ESTADO_ESTADO] FOREIGN KEY([CODIGO_ESTADO])
REFERENCES [dbo].[ESTADO] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_ESTADO_ESTADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_ESTADO]'))
ALTER TABLE [dbo].[PROPUESTA_ESTADO] CHECK CONSTRAINT [FK_PROPUESTA_ESTADO_ESTADO]
GO
/****** Object:  ForeignKey [FK_PROPUESTA_ESTADO_PROPUESTAMEJORA]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_ESTADO_PROPUESTAMEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_ESTADO]'))
ALTER TABLE [dbo].[PROPUESTA_ESTADO]  WITH CHECK ADD  CONSTRAINT [FK_PROPUESTA_ESTADO_PROPUESTAMEJORA] FOREIGN KEY([CODIGO_PROPUESTA])
REFERENCES [dbo].[PROPUESTAMEJORA] ([CODIGO_PROPUESTA])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PROPUESTA_ESTADO_PROPUESTAMEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROPUESTA_ESTADO]'))
ALTER TABLE [dbo].[PROPUESTA_ESTADO] CHECK CONSTRAINT [FK_PROPUESTA_ESTADO_PROPUESTAMEJORA]
GO
/****** Object:  ForeignKey [FK_OBSERVACIONES_PILOTO_PILOTO]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OBSERVACIONES_PILOTO_PILOTO]') AND parent_object_id = OBJECT_ID(N'[dbo].[OBSERVACIONES_PILOTO]'))
ALTER TABLE [dbo].[OBSERVACIONES_PILOTO]  WITH CHECK ADD  CONSTRAINT [FK_OBSERVACIONES_PILOTO_PILOTO] FOREIGN KEY([CODIGO_PILOTO])
REFERENCES [dbo].[PILOTO] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OBSERVACIONES_PILOTO_PILOTO]') AND parent_object_id = OBJECT_ID(N'[dbo].[OBSERVACIONES_PILOTO]'))
ALTER TABLE [dbo].[OBSERVACIONES_PILOTO] CHECK CONSTRAINT [FK_OBSERVACIONES_PILOTO_PILOTO]
GO
/****** Object:  ForeignKey [FK_ESTADO_PILOTO_ESTADO]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESTADO_PILOTO_ESTADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESTADO_PILOTO]'))
ALTER TABLE [dbo].[ESTADO_PILOTO]  WITH CHECK ADD  CONSTRAINT [FK_ESTADO_PILOTO_ESTADO] FOREIGN KEY([CODIGO_ESTADO])
REFERENCES [dbo].[ESTADO] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESTADO_PILOTO_ESTADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESTADO_PILOTO]'))
ALTER TABLE [dbo].[ESTADO_PILOTO] CHECK CONSTRAINT [FK_ESTADO_PILOTO_ESTADO]
GO
/****** Object:  ForeignKey [FK_ESTADO_PILOTO_PILOTO]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESTADO_PILOTO_PILOTO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESTADO_PILOTO]'))
ALTER TABLE [dbo].[ESTADO_PILOTO]  WITH CHECK ADD  CONSTRAINT [FK_ESTADO_PILOTO_PILOTO] FOREIGN KEY([CODIGO_PILOTO])
REFERENCES [dbo].[PILOTO] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESTADO_PILOTO_PILOTO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESTADO_PILOTO]'))
ALTER TABLE [dbo].[ESTADO_PILOTO] CHECK CONSTRAINT [FK_ESTADO_PILOTO_PILOTO]
GO
/****** Object:  ForeignKey [FK_AC_EVALUACION_AUDITORIA_AC_AUDITADOS]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_EVALUACION_AUDITORIA_AC_AUDITADOS]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_EVALUACION_AUDITORIA]'))
ALTER TABLE [dbo].[AC_EVALUACION_AUDITORIA]  WITH CHECK ADD  CONSTRAINT [FK_AC_EVALUACION_AUDITORIA_AC_AUDITADOS] FOREIGN KEY([idAuditoria], [idAuditado])
REFERENCES [dbo].[AC_AUDITADOS] ([idAuditoria], [idAuditado])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_EVALUACION_AUDITORIA_AC_AUDITADOS]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_EVALUACION_AUDITORIA]'))
ALTER TABLE [dbo].[AC_EVALUACION_AUDITORIA] CHECK CONSTRAINT [FK_AC_EVALUACION_AUDITORIA_AC_AUDITADOS]
GO
/****** Object:  ForeignKey [FK_AC_EVALUACION_AUDITORIA_AC_PREGUNTA_EVALUACION]    Script Date: 03/23/2013 16:50:51 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_EVALUACION_AUDITORIA_AC_PREGUNTA_EVALUACION]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_EVALUACION_AUDITORIA]'))
ALTER TABLE [dbo].[AC_EVALUACION_AUDITORIA]  WITH CHECK ADD  CONSTRAINT [FK_AC_EVALUACION_AUDITORIA_AC_PREGUNTA_EVALUACION] FOREIGN KEY([idPreguntaEvaluacion])
REFERENCES [dbo].[AC_PREGUNTA_EVALUACION] ([idPreguntaEvaluacion])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_EVALUACION_AUDITORIA_AC_PREGUNTA_EVALUACION]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_EVALUACION_AUDITORIA]'))
ALTER TABLE [dbo].[AC_EVALUACION_AUDITORIA] CHECK CONSTRAINT [FK_AC_EVALUACION_AUDITORIA_AC_PREGUNTA_EVALUACION]
GO
/****** Object:  ForeignKey [FK_ESTADO_SOLUCION_ESTADO]    Script Date: 03/23/2013 16:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESTADO_SOLUCION_ESTADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESTADO_SOLUCION]'))
ALTER TABLE [dbo].[ESTADO_SOLUCION]  WITH CHECK ADD  CONSTRAINT [FK_ESTADO_SOLUCION_ESTADO] FOREIGN KEY([CODIGO_ESTADO])
REFERENCES [dbo].[ESTADO] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESTADO_SOLUCION_ESTADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESTADO_SOLUCION]'))
ALTER TABLE [dbo].[ESTADO_SOLUCION] CHECK CONSTRAINT [FK_ESTADO_SOLUCION_ESTADO]
GO
/****** Object:  ForeignKey [FK_ESTADO_SOLUCION_SOLUCION_MEJORA]    Script Date: 03/23/2013 16:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESTADO_SOLUCION_SOLUCION_MEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESTADO_SOLUCION]'))
ALTER TABLE [dbo].[ESTADO_SOLUCION]  WITH CHECK ADD  CONSTRAINT [FK_ESTADO_SOLUCION_SOLUCION_MEJORA] FOREIGN KEY([CODIGO_SOLUCION])
REFERENCES [dbo].[SOLUCION_MEJORA] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ESTADO_SOLUCION_SOLUCION_MEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[ESTADO_SOLUCION]'))
ALTER TABLE [dbo].[ESTADO_SOLUCION] CHECK CONSTRAINT [FK_ESTADO_SOLUCION_SOLUCION_MEJORA]
GO
/****** Object:  ForeignKey [FK_LINEA_BASE_PROYECTO_FASE]    Script Date: 03/23/2013 16:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LINEA_BASE_PROYECTO_FASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[LINEA_BASE]'))
ALTER TABLE [dbo].[LINEA_BASE]  WITH CHECK ADD  CONSTRAINT [FK_LINEA_BASE_PROYECTO_FASE] FOREIGN KEY([CODIGO_PROYECTO_FASE])
REFERENCES [dbo].[PROYECTO_FASE] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LINEA_BASE_PROYECTO_FASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[LINEA_BASE]'))
ALTER TABLE [dbo].[LINEA_BASE] CHECK CONSTRAINT [FK_LINEA_BASE_PROYECTO_FASE]
GO
/****** Object:  ForeignKey [FK_AC_HALLAZGO_AC_PREGUNTA_VERIFICACION]    Script Date: 03/23/2013 16:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_HALLAZGO_AC_PREGUNTA_VERIFICACION]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_HALLAZGO]'))
ALTER TABLE [dbo].[AC_HALLAZGO]  WITH CHECK ADD  CONSTRAINT [FK_AC_HALLAZGO_AC_PREGUNTA_VERIFICACION] FOREIGN KEY([idAuditoria], [idPreguntaVerificacion])
REFERENCES [dbo].[AC_PREGUNTA_VERIFICACION] ([idAuditoria], [idPreguntaVerificacion])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_HALLAZGO_AC_PREGUNTA_VERIFICACION]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_HALLAZGO]'))
ALTER TABLE [dbo].[AC_HALLAZGO] CHECK CONSTRAINT [FK_AC_HALLAZGO_AC_PREGUNTA_VERIFICACION]
GO
/****** Object:  ForeignKey [FK_AC_CALIFICACION_AUDITOR_AC_AUDITOR]    Script Date: 03/23/2013 16:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_CALIFICACION_AUDITOR_AC_AUDITOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_CALIFICACION_AUDITOR]'))
ALTER TABLE [dbo].[AC_CALIFICACION_AUDITOR]  WITH CHECK ADD  CONSTRAINT [FK_AC_CALIFICACION_AUDITOR_AC_AUDITOR] FOREIGN KEY([idAuditoria], [idAuditor])
REFERENCES [dbo].[AC_AUDITOR] ([idAuditoria], [idAuditor])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_CALIFICACION_AUDITOR_AC_AUDITOR]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_CALIFICACION_AUDITOR]'))
ALTER TABLE [dbo].[AC_CALIFICACION_AUDITOR] CHECK CONSTRAINT [FK_AC_CALIFICACION_AUDITOR_AC_AUDITOR]
GO
/****** Object:  ForeignKey [FK_AC_CALIFICACION_AUDITOR_AC_PREGUNTA_CALIFICACION]    Script Date: 03/23/2013 16:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_CALIFICACION_AUDITOR_AC_PREGUNTA_CALIFICACION]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_CALIFICACION_AUDITOR]'))
ALTER TABLE [dbo].[AC_CALIFICACION_AUDITOR]  WITH CHECK ADD  CONSTRAINT [FK_AC_CALIFICACION_AUDITOR_AC_PREGUNTA_CALIFICACION] FOREIGN KEY([idPreguntaCalificacion])
REFERENCES [dbo].[AC_PREGUNTA_CALIFICACION] ([idPreguntaCalificacion])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AC_CALIFICACION_AUDITOR_AC_PREGUNTA_CALIFICACION]') AND parent_object_id = OBJECT_ID(N'[dbo].[AC_CALIFICACION_AUDITOR]'))
ALTER TABLE [dbo].[AC_CALIFICACION_AUDITOR] CHECK CONSTRAINT [FK_AC_CALIFICACION_AUDITOR_AC_PREGUNTA_CALIFICACION]
GO
/****** Object:  ForeignKey [FK_ACCIONES_SOLUCION_SOLUCION_MEJORA]    Script Date: 03/23/2013 16:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ACCIONES_SOLUCION_SOLUCION_MEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[ACCIONES_SOLUCION]'))
ALTER TABLE [dbo].[ACCIONES_SOLUCION]  WITH CHECK ADD  CONSTRAINT [FK_ACCIONES_SOLUCION_SOLUCION_MEJORA] FOREIGN KEY([CODIGO_SOLUCION])
REFERENCES [dbo].[SOLUCION_MEJORA] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ACCIONES_SOLUCION_SOLUCION_MEJORA]') AND parent_object_id = OBJECT_ID(N'[dbo].[ACCIONES_SOLUCION]'))
ALTER TABLE [dbo].[ACCIONES_SOLUCION] CHECK CONSTRAINT [FK_ACCIONES_SOLUCION_SOLUCION_MEJORA]
GO
/****** Object:  ForeignKey [Relacion_16]    Script Date: 03/23/2013 16:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_16]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO]  WITH CHECK ADD  CONSTRAINT [Relacion_16] FOREIGN KEY([CODIGO_SERVICIO], [CODIGO_SEDE], [CODIGO_PROYECTO])
REFERENCES [dbo].[PROYECTO_SERVICIO_SEDE] ([CODIGO_SERVICIO], [CODIGO_SEDE], [CODIGO_PROYECTO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_16]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO] CHECK CONSTRAINT [Relacion_16]
GO
/****** Object:  ForeignKey [Relacion_17]    Script Date: 03/23/2013 16:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_17]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO]  WITH CHECK ADD  CONSTRAINT [Relacion_17] FOREIGN KEY([CODIGO_EQUIPO])
REFERENCES [dbo].[EQUIPO] ([CODIGO_EQUIPO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_17]') AND parent_object_id = OBJECT_ID(N'[dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO]'))
ALTER TABLE [dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO] CHECK CONSTRAINT [Relacion_17]
GO
/****** Object:  ForeignKey [FK_PLAN_DESPLIEGUE_EMPLEADO]    Script Date: 03/23/2013 16:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PLAN_DESPLIEGUE_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PLAN_DESPLIEGUE]'))
ALTER TABLE [dbo].[PLAN_DESPLIEGUE]  WITH CHECK ADD  CONSTRAINT [FK_PLAN_DESPLIEGUE_EMPLEADO] FOREIGN KEY([CODIGO_EMPLEADO])
REFERENCES [dbo].[EMPLEADO] ([CODIGO_EMPLEADO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PLAN_DESPLIEGUE_EMPLEADO]') AND parent_object_id = OBJECT_ID(N'[dbo].[PLAN_DESPLIEGUE]'))
ALTER TABLE [dbo].[PLAN_DESPLIEGUE] CHECK CONSTRAINT [FK_PLAN_DESPLIEGUE_EMPLEADO]
GO
/****** Object:  ForeignKey [FK_PLAN_DESPLIEGUE_SOLUCION_MEJORA1]    Script Date: 03/23/2013 16:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PLAN_DESPLIEGUE_SOLUCION_MEJORA1]') AND parent_object_id = OBJECT_ID(N'[dbo].[PLAN_DESPLIEGUE]'))
ALTER TABLE [dbo].[PLAN_DESPLIEGUE]  WITH CHECK ADD  CONSTRAINT [FK_PLAN_DESPLIEGUE_SOLUCION_MEJORA1] FOREIGN KEY([CODIGO_SOLUCION])
REFERENCES [dbo].[SOLUCION_MEJORA] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PLAN_DESPLIEGUE_SOLUCION_MEJORA1]') AND parent_object_id = OBJECT_ID(N'[dbo].[PLAN_DESPLIEGUE]'))
ALTER TABLE [dbo].[PLAN_DESPLIEGUE] CHECK CONSTRAINT [FK_PLAN_DESPLIEGUE_SOLUCION_MEJORA1]
GO
/****** Object:  ForeignKey [Relacion_12]    Script Date: 03/23/2013 16:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_12]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET]  WITH CHECK ADD  CONSTRAINT [Relacion_12] FOREIGN KEY([CODIGO_EQUIPO], [CODIGO_SERVICIO], [CODIGO_SEDE], [CODIGO_PROYECTO])
REFERENCES [dbo].[PROYECTO_SERVICIO_SEDE_EQUIPO] ([CODIGO_EQUIPO], [CODIGO_SERVICIO], [CODIGO_SEDE], [CODIGO_PROYECTO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_12]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET] CHECK CONSTRAINT [Relacion_12]
GO
/****** Object:  ForeignKey [Relacion_40]    Script Date: 03/23/2013 16:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_40]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET]  WITH CHECK ADD  CONSTRAINT [Relacion_40] FOREIGN KEY([CODIGO_USUARIO_CLIENTE], [CODIGO_CLIENTE])
REFERENCES [dbo].[USUARIO_CLIENTE] ([CODIGO_USUARIO_CLIENTE], [CODIGO_CLIENTE])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_40]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET] CHECK CONSTRAINT [Relacion_40]
GO
/****** Object:  ForeignKey [Relacion_41]    Script Date: 03/23/2013 16:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_41]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET]  WITH CHECK ADD  CONSTRAINT [Relacion_41] FOREIGN KEY([CREADO_POR_CODIGO_INTEGRANTE], [CODIGO_EQUIPO])
REFERENCES [dbo].[INTEGRANTE] ([CODIGO_INTEGRANTE], [CODIGO_EQUIPO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_41]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET] CHECK CONSTRAINT [Relacion_41]
GO
/****** Object:  ForeignKey [Relacion_43]    Script Date: 03/23/2013 16:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_43]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET]  WITH CHECK ADD  CONSTRAINT [Relacion_43] FOREIGN KEY([ASIGNADO_A_CODIGO_INTEGRANTE], [CODIGO_EQUIPO])
REFERENCES [dbo].[INTEGRANTE] ([CODIGO_INTEGRANTE], [CODIGO_EQUIPO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_43]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET] CHECK CONSTRAINT [Relacion_43]
GO
/****** Object:  ForeignKey [Relacion_44]    Script Date: 03/23/2013 16:50:52 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_44]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET]  WITH CHECK ADD  CONSTRAINT [Relacion_44] FOREIGN KEY([ULTIMO_CAMBIO_CODIGO_INTEGRANTE], [CODIGO_EQUIPO])
REFERENCES [dbo].[INTEGRANTE] ([CODIGO_INTEGRANTE], [CODIGO_EQUIPO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_44]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET]'))
ALTER TABLE [dbo].[TICKET] CHECK CONSTRAINT [Relacion_44]
GO
/****** Object:  ForeignKey [FK_LINEA_BASE_DETALLE_ELEMENTO_CONFIGURACION]    Script Date: 03/23/2013 16:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LINEA_BASE_DETALLE_ELEMENTO_CONFIGURACION]') AND parent_object_id = OBJECT_ID(N'[dbo].[LINEA_BASE_DETALLE]'))
ALTER TABLE [dbo].[LINEA_BASE_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_LINEA_BASE_DETALLE_ELEMENTO_CONFIGURACION] FOREIGN KEY([CODIGO_ECS])
REFERENCES [dbo].[ELEMENTO_CONFIGURACION] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LINEA_BASE_DETALLE_ELEMENTO_CONFIGURACION]') AND parent_object_id = OBJECT_ID(N'[dbo].[LINEA_BASE_DETALLE]'))
ALTER TABLE [dbo].[LINEA_BASE_DETALLE] CHECK CONSTRAINT [FK_LINEA_BASE_DETALLE_ELEMENTO_CONFIGURACION]
GO
/****** Object:  ForeignKey [FK_LINEA_BASE_DETALLE_LINEA_BASE]    Script Date: 03/23/2013 16:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LINEA_BASE_DETALLE_LINEA_BASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[LINEA_BASE_DETALLE]'))
ALTER TABLE [dbo].[LINEA_BASE_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_LINEA_BASE_DETALLE_LINEA_BASE] FOREIGN KEY([CODIGO_LINEA_BASE])
REFERENCES [dbo].[LINEA_BASE] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LINEA_BASE_DETALLE_LINEA_BASE]') AND parent_object_id = OBJECT_ID(N'[dbo].[LINEA_BASE_DETALLE]'))
ALTER TABLE [dbo].[LINEA_BASE_DETALLE] CHECK CONSTRAINT [FK_LINEA_BASE_DETALLE_LINEA_BASE]
GO
/****** Object:  ForeignKey [Relacion_21]    Script Date: 03/23/2013 16:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_21]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORMACION_SEGUIMIENTO]'))
ALTER TABLE [dbo].[INFORMACION_SEGUIMIENTO]  WITH CHECK ADD  CONSTRAINT [Relacion_21] FOREIGN KEY([CODIGO_TICKET])
REFERENCES [dbo].[TICKET] ([CODIGO_TICKET])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_21]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORMACION_SEGUIMIENTO]'))
ALTER TABLE [dbo].[INFORMACION_SEGUIMIENTO] CHECK CONSTRAINT [Relacion_21]
GO
/****** Object:  ForeignKey [Relacion_37]    Script Date: 03/23/2013 16:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_37]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORMACION_SEGUIMIENTO]'))
ALTER TABLE [dbo].[INFORMACION_SEGUIMIENTO]  WITH CHECK ADD  CONSTRAINT [Relacion_37] FOREIGN KEY([CODIGO_INTEGRANTE], [CODIGO_EQUIPO])
REFERENCES [dbo].[INTEGRANTE] ([CODIGO_INTEGRANTE], [CODIGO_EQUIPO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_37]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORMACION_SEGUIMIENTO]'))
ALTER TABLE [dbo].[INFORMACION_SEGUIMIENTO] CHECK CONSTRAINT [Relacion_37]
GO
/****** Object:  ForeignKey [Relacion_20]    Script Date: 03/23/2013 16:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_20]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORMACION_ADICIONAL]'))
ALTER TABLE [dbo].[INFORMACION_ADICIONAL]  WITH CHECK ADD  CONSTRAINT [Relacion_20] FOREIGN KEY([CODIGO_TICKET])
REFERENCES [dbo].[TICKET] ([CODIGO_TICKET])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_20]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORMACION_ADICIONAL]'))
ALTER TABLE [dbo].[INFORMACION_ADICIONAL] CHECK CONSTRAINT [Relacion_20]
GO
/****** Object:  ForeignKey [Relacion_39]    Script Date: 03/23/2013 16:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_39]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORMACION_ADICIONAL]'))
ALTER TABLE [dbo].[INFORMACION_ADICIONAL]  WITH CHECK ADD  CONSTRAINT [Relacion_39] FOREIGN KEY([CODIGO_INTEGRANTE], [CODIGO_EQUIPO])
REFERENCES [dbo].[INTEGRANTE] ([CODIGO_INTEGRANTE], [CODIGO_EQUIPO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_39]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORMACION_ADICIONAL]'))
ALTER TABLE [dbo].[INFORMACION_ADICIONAL] CHECK CONSTRAINT [Relacion_39]
GO
/****** Object:  ForeignKey [FK_SOLICITUD_CAMBIO_LINEA_BASE_DETALLE]    Script Date: 03/23/2013 16:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SOLICITUD_CAMBIO_LINEA_BASE_DETALLE]') AND parent_object_id = OBJECT_ID(N'[dbo].[SOLICITUD_CAMBIO]'))
ALTER TABLE [dbo].[SOLICITUD_CAMBIO]  WITH CHECK ADD  CONSTRAINT [FK_SOLICITUD_CAMBIO_LINEA_BASE_DETALLE] FOREIGN KEY([CODIGO_LINEA_BASE])
REFERENCES [dbo].[LINEA_BASE_DETALLE] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SOLICITUD_CAMBIO_LINEA_BASE_DETALLE]') AND parent_object_id = OBJECT_ID(N'[dbo].[SOLICITUD_CAMBIO]'))
ALTER TABLE [dbo].[SOLICITUD_CAMBIO] CHECK CONSTRAINT [FK_SOLICITUD_CAMBIO_LINEA_BASE_DETALLE]
GO
/****** Object:  ForeignKey [Relacion_19]    Script Date: 03/23/2013 16:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_19]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET_LECCION_APRENDIDA]'))
ALTER TABLE [dbo].[TICKET_LECCION_APRENDIDA]  WITH CHECK ADD  CONSTRAINT [Relacion_19] FOREIGN KEY([CODIGO_LECCION_APRENDIDA])
REFERENCES [dbo].[LECCION_APRENDIDA] ([CODIGO_LECCION_APRENDIDA])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_19]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET_LECCION_APRENDIDA]'))
ALTER TABLE [dbo].[TICKET_LECCION_APRENDIDA] CHECK CONSTRAINT [Relacion_19]
GO
/****** Object:  ForeignKey [Relacion_28]    Script Date: 03/23/2013 16:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_28]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET_LECCION_APRENDIDA]'))
ALTER TABLE [dbo].[TICKET_LECCION_APRENDIDA]  WITH CHECK ADD  CONSTRAINT [Relacion_28] FOREIGN KEY([CODIGO_TICKET])
REFERENCES [dbo].[TICKET] ([CODIGO_TICKET])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_28]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET_LECCION_APRENDIDA]'))
ALTER TABLE [dbo].[TICKET_LECCION_APRENDIDA] CHECK CONSTRAINT [Relacion_28]
GO
/****** Object:  ForeignKey [Relacion_15]    Script Date: 03/23/2013 16:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_15]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET_CMDB]'))
ALTER TABLE [dbo].[TICKET_CMDB]  WITH CHECK ADD  CONSTRAINT [Relacion_15] FOREIGN KEY([CODIGO_TICKET])
REFERENCES [dbo].[TICKET] ([CODIGO_TICKET])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_15]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET_CMDB]'))
ALTER TABLE [dbo].[TICKET_CMDB] CHECK CONSTRAINT [Relacion_15]
GO
/****** Object:  ForeignKey [Relacion_32]    Script Date: 03/23/2013 16:50:53 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_32]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET_CMDB]'))
ALTER TABLE [dbo].[TICKET_CMDB]  WITH CHECK ADD  CONSTRAINT [Relacion_32] FOREIGN KEY([CODIGO_CMDB])
REFERENCES [dbo].[CMDB] ([CODIGO_CMDB])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[Relacion_32]') AND parent_object_id = OBJECT_ID(N'[dbo].[TICKET_CMDB]'))
ALTER TABLE [dbo].[TICKET_CMDB] CHECK CONSTRAINT [Relacion_32]
GO
/****** Object:  ForeignKey [FK_INFORME_CAMBIO_SOLICITUD_CAMBIO]    Script Date: 03/23/2013 16:50:54 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_INFORME_CAMBIO_SOLICITUD_CAMBIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORME_CAMBIO]'))
ALTER TABLE [dbo].[INFORME_CAMBIO]  WITH CHECK ADD  CONSTRAINT [FK_INFORME_CAMBIO_SOLICITUD_CAMBIO] FOREIGN KEY([CODIGO_SOLICITUD])
REFERENCES [dbo].[SOLICITUD_CAMBIO] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_INFORME_CAMBIO_SOLICITUD_CAMBIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[INFORME_CAMBIO]'))
ALTER TABLE [dbo].[INFORME_CAMBIO] CHECK CONSTRAINT [FK_INFORME_CAMBIO_SOLICITUD_CAMBIO]
GO
/****** Object:  ForeignKey [FK_ORDEN_CAMBIO_INFORME_CAMBIO]    Script Date: 03/23/2013 16:50:54 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ORDEN_CAMBIO_INFORME_CAMBIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ORDEN_CAMBIO]'))
ALTER TABLE [dbo].[ORDEN_CAMBIO]  WITH CHECK ADD  CONSTRAINT [FK_ORDEN_CAMBIO_INFORME_CAMBIO] FOREIGN KEY([CODIGO_INFORME])
REFERENCES [dbo].[INFORME_CAMBIO] ([CODIGO])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ORDEN_CAMBIO_INFORME_CAMBIO]') AND parent_object_id = OBJECT_ID(N'[dbo].[ORDEN_CAMBIO]'))
ALTER TABLE [dbo].[ORDEN_CAMBIO] CHECK CONSTRAINT [FK_ORDEN_CAMBIO_INFORME_CAMBIO]
GO

/****** Object:  ForeignKey [FK_EMPLEADO_ACTIVIDAD_ACTIVIDAD_TIPO]    Script Date: 04/03/2013 12:26:46 Gestion Mantenimiento******/
ALTER TABLE [dbo].[EMPLEADO_ACTIVIDAD]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADO_ACTIVIDAD_ACTIVIDAD_TIPO] FOREIGN KEY([CODIGO_TIPO_ACTIVIDAD])
REFERENCES [dbo].[ACTIVIDAD_TIPO] ([CODIGO_TIPO_ACTIVIDAD])
GO
ALTER TABLE [dbo].[EMPLEADO_ACTIVIDAD] CHECK CONSTRAINT [FK_EMPLEADO_ACTIVIDAD_ACTIVIDAD_TIPO]
GO
/****** Object:  ForeignKey [FK_EMPLEADO_ACTIVIDAD_EMPLEADO]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[EMPLEADO_ACTIVIDAD]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADO_ACTIVIDAD_EMPLEADO] FOREIGN KEY([CODIGO_EMPLEADO])
REFERENCES [dbo].[EMPLEADO] ([CODIGO_EMPLEADO])
GO
ALTER TABLE [dbo].[EMPLEADO_ACTIVIDAD] CHECK CONSTRAINT [FK_EMPLEADO_ACTIVIDAD_EMPLEADO]
GO
/****** Object:  ForeignKey [FK_EQUIPO_COMPUTO_AREA]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[EQUIPO_COMPUTO]  WITH CHECK ADD  CONSTRAINT [FK_EQUIPO_COMPUTO_AREA] FOREIGN KEY([CODIGO_AREA])
REFERENCES [dbo].[AREA] ([CODIGO_AREA])
GO
ALTER TABLE [dbo].[EQUIPO_COMPUTO] CHECK CONSTRAINT [FK_EQUIPO_COMPUTO_AREA]
GO
/****** Object:  ForeignKey [FK_EQUIPO_COMPUTO_EQUIPO_TIPO]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[EQUIPO_COMPUTO]  WITH CHECK ADD  CONSTRAINT [FK_EQUIPO_COMPUTO_EQUIPO_TIPO] FOREIGN KEY([CODIGO_TIPO_EQUIPO])
REFERENCES [dbo].[EQUIPO_TIPO] ([CODIGO_TIPO_EQUIPO])
GO
ALTER TABLE [dbo].[EQUIPO_COMPUTO] CHECK CONSTRAINT [FK_EQUIPO_COMPUTO_EQUIPO_TIPO]
GO
/****** Object:  ForeignKey [FK_EQUIPO_COMPUTO_PLAN_MANTENIMIENTO_CABECERA]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[EQUIPO_COMPUTO]  WITH CHECK ADD  CONSTRAINT [FK_EQUIPO_COMPUTO_PLAN_MANTENIMIENTO_CABECERA] FOREIGN KEY([CODIGO_PLAN])
REFERENCES [dbo].[PLAN_MANTENIMIENTO_CABECERA] ([CODIGO_PLAN])
GO
ALTER TABLE [dbo].[EQUIPO_COMPUTO] CHECK CONSTRAINT [FK_EQUIPO_COMPUTO_PLAN_MANTENIMIENTO_CABECERA]
GO
/****** Object:  ForeignKey [FK_EQUIPO_COMPUTO_PROCEDENCIA]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[EQUIPO_COMPUTO]  WITH CHECK ADD  CONSTRAINT [FK_EQUIPO_COMPUTO_PROCEDENCIA] FOREIGN KEY([PROCEDENCIA_EQUIPO])
REFERENCES [dbo].[PROCEDENCIA] ([CODIGO_PROCEDENCIA])
GO
ALTER TABLE [dbo].[EQUIPO_COMPUTO] CHECK CONSTRAINT [FK_EQUIPO_COMPUTO_PROCEDENCIA]
GO
/****** Object:  ForeignKey [FK_ORDEN_TRABAJO_CABECERA_ORDEN_TRABAJO_ESTADO]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[ORDEN_TRABAJO_CABECERA]  WITH CHECK ADD  CONSTRAINT [FK_ORDEN_TRABAJO_CABECERA_ORDEN_TRABAJO_ESTADO] FOREIGN KEY([ESTADO_ORDEN])
REFERENCES [dbo].[ORDEN_TRABAJO_ESTADO] ([CODIGO_ESTADO_OT])
GO
ALTER TABLE [dbo].[ORDEN_TRABAJO_CABECERA] CHECK CONSTRAINT [FK_ORDEN_TRABAJO_CABECERA_ORDEN_TRABAJO_ESTADO]
GO
/****** Object:  ForeignKey [FK_ORDEN_TRABAJO_DETALLE_ORDEN_TRABAJO_CABECERA]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[ORDEN_TRABAJO_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_ORDEN_TRABAJO_DETALLE_ORDEN_TRABAJO_CABECERA] FOREIGN KEY([NUMERO_ORDEN])
REFERENCES [dbo].[ORDEN_TRABAJO_CABECERA] ([NUMERO_ORDEN])
GO
ALTER TABLE [dbo].[ORDEN_TRABAJO_DETALLE] CHECK CONSTRAINT [FK_ORDEN_TRABAJO_DETALLE_ORDEN_TRABAJO_CABECERA]
GO
/****** Object:  ForeignKey [FK_PLAN_MANTENIMIENTO_DETALLE_ACTIVIDAD_TIPO]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[PLAN_MANTENIMIENTO_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_PLAN_MANTENIMIENTO_DETALLE_ACTIVIDAD_TIPO] FOREIGN KEY([CODIGO_TIPO_ACTIVIDAD])
REFERENCES [dbo].[ACTIVIDAD_TIPO] ([CODIGO_TIPO_ACTIVIDAD])
GO
ALTER TABLE [dbo].[PLAN_MANTENIMIENTO_DETALLE] CHECK CONSTRAINT [FK_PLAN_MANTENIMIENTO_DETALLE_ACTIVIDAD_TIPO]
GO
/****** Object:  ForeignKey [FK_PLAN_MANTENIMIENTO_DETALLE_FRECUENCIA]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[PLAN_MANTENIMIENTO_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_PLAN_MANTENIMIENTO_DETALLE_FRECUENCIA] FOREIGN KEY([CODIGO_FRECUENCIA])
REFERENCES [dbo].[FRECUENCIA] ([CODIGO_FRECUENCIA])
GO
ALTER TABLE [dbo].[PLAN_MANTENIMIENTO_DETALLE] CHECK CONSTRAINT [FK_PLAN_MANTENIMIENTO_DETALLE_FRECUENCIA]
GO
/****** Object:  ForeignKey [FK_PLAN_MANTENIMIENTO_DETALLE_PLAN_MANTENIMIENTO_CABECERA]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[PLAN_MANTENIMIENTO_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_PLAN_MANTENIMIENTO_DETALLE_PLAN_MANTENIMIENTO_CABECERA] FOREIGN KEY([CODIGO_PLAN])
REFERENCES [dbo].[PLAN_MANTENIMIENTO_CABECERA] ([CODIGO_PLAN])
GO
ALTER TABLE [dbo].[PLAN_MANTENIMIENTO_DETALLE] CHECK CONSTRAINT [FK_PLAN_MANTENIMIENTO_DETALLE_PLAN_MANTENIMIENTO_CABECERA]
GO
/****** Object:  ForeignKey [FK_PLAN_MANTENIMIENTO_DETALLE_PRIORIDAD]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[PLAN_MANTENIMIENTO_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_PLAN_MANTENIMIENTO_DETALLE_PRIORIDAD] FOREIGN KEY([PRIORIDAD_ACTIVIDAD])
REFERENCES [dbo].[PRIORIDAD] ([CODIGO])
GO
ALTER TABLE [dbo].[PLAN_MANTENIMIENTO_DETALLE] CHECK CONSTRAINT [FK_PLAN_MANTENIMIENTO_DETALLE_PRIORIDAD]
GO
/****** Object:  ForeignKey [FK_PLAN_MANTENIMIENTO_DETALLE_UNIDAD_TIEMPO]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[PLAN_MANTENIMIENTO_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_PLAN_MANTENIMIENTO_DETALLE_UNIDAD_TIEMPO] FOREIGN KEY([CODIGO_TIEMPO])
REFERENCES [dbo].[UNIDAD_TIEMPO] ([CODIGO_TIEMPO])
GO
ALTER TABLE [dbo].[PLAN_MANTENIMIENTO_DETALLE] CHECK CONSTRAINT [FK_PLAN_MANTENIMIENTO_DETALLE_UNIDAD_TIEMPO]
GO
/****** Object:  ForeignKey [FK_SOLICITUD_CABECERA_EQUIPO_COMPUTO]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[SOLICITUD_CABECERA]  WITH CHECK ADD  CONSTRAINT [FK_SOLICITUD_CABECERA_EQUIPO_COMPUTO] FOREIGN KEY([CODIGO_EQUIPO])
REFERENCES [dbo].[EQUIPO_COMPUTO] ([CODIGO_EQUIPO])
GO
ALTER TABLE [dbo].[SOLICITUD_CABECERA] CHECK CONSTRAINT [FK_SOLICITUD_CABECERA_EQUIPO_COMPUTO]
GO
/****** Object:  ForeignKey [FK_SOLICITUD_CABECERA_PLAN_MANTENIMIENTO_CABECERA]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[SOLICITUD_CABECERA]  WITH CHECK ADD  CONSTRAINT [FK_SOLICITUD_CABECERA_PLAN_MANTENIMIENTO_CABECERA] FOREIGN KEY([CODIGO_PLAN])
REFERENCES [dbo].[PLAN_MANTENIMIENTO_CABECERA] ([CODIGO_PLAN])
GO
ALTER TABLE [dbo].[SOLICITUD_CABECERA] CHECK CONSTRAINT [FK_SOLICITUD_CABECERA_PLAN_MANTENIMIENTO_CABECERA]
GO
/****** Object:  ForeignKey [FK_SOLICITUD_CABECERA_SOLICITUD_ESTADO]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[SOLICITUD_CABECERA]  WITH CHECK ADD  CONSTRAINT [FK_SOLICITUD_CABECERA_SOLICITUD_ESTADO] FOREIGN KEY([ESTADO_SOLICITUD])
REFERENCES [dbo].[SOLICITUD_ESTADO] ([CODIGO_ESTADO_SOLICITUD])
GO
ALTER TABLE [dbo].[SOLICITUD_CABECERA] CHECK CONSTRAINT [FK_SOLICITUD_CABECERA_SOLICITUD_ESTADO]
GO
/****** Object:  ForeignKey [FK_SOLICITUD_CABECERA_SOLICITUD_TIPO]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[SOLICITUD_CABECERA]  WITH CHECK ADD  CONSTRAINT [FK_SOLICITUD_CABECERA_SOLICITUD_TIPO] FOREIGN KEY([TIPO_SOLICITUD])
REFERENCES [dbo].[SOLICITUD_TIPO] ([CODIGO_TIPO_SOLICITUD])
GO
ALTER TABLE [dbo].[SOLICITUD_CABECERA] CHECK CONSTRAINT [FK_SOLICITUD_CABECERA_SOLICITUD_TIPO]
GO
/****** Object:  ForeignKey [FK_SOLICITUD_DETALLE_ACTIVIDAD_TIPO]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[SOLICITUD_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_SOLICITUD_DETALLE_ACTIVIDAD_TIPO] FOREIGN KEY([CODIGO_TIPO_ACTIVIDAD])
REFERENCES [dbo].[ACTIVIDAD_TIPO] ([CODIGO_TIPO_ACTIVIDAD])
GO
ALTER TABLE [dbo].[SOLICITUD_DETALLE] CHECK CONSTRAINT [FK_SOLICITUD_DETALLE_ACTIVIDAD_TIPO]
GO
/****** Object:  ForeignKey [FK_SOLICITUD_DETALLE_FRECUENCIA]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[SOLICITUD_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_SOLICITUD_DETALLE_FRECUENCIA] FOREIGN KEY([CODIGO_FRECUENCIA])
REFERENCES [dbo].[FRECUENCIA] ([CODIGO_FRECUENCIA])
GO
ALTER TABLE [dbo].[SOLICITUD_DETALLE] CHECK CONSTRAINT [FK_SOLICITUD_DETALLE_FRECUENCIA]
GO
/****** Object:  ForeignKey [FK_SOLICITUD_DETALLE_PRIORIDAD]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[SOLICITUD_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_SOLICITUD_DETALLE_PRIORIDAD] FOREIGN KEY([PRIORIDAD_ACTIVIDAD])
REFERENCES [dbo].[PRIORIDAD] ([CODIGO])
GO
ALTER TABLE [dbo].[SOLICITUD_DETALLE] CHECK CONSTRAINT [FK_SOLICITUD_DETALLE_PRIORIDAD]
GO
/****** Object:  ForeignKey [FK_SOLICITUD_DETALLE_SOLICITUD_CABECERA]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[SOLICITUD_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_SOLICITUD_DETALLE_SOLICITUD_CABECERA] FOREIGN KEY([NUMERO_SOLICITUD])
REFERENCES [dbo].[SOLICITUD_CABECERA] ([NUMERO_SOLICITUD])
GO
ALTER TABLE [dbo].[SOLICITUD_DETALLE] CHECK CONSTRAINT [FK_SOLICITUD_DETALLE_SOLICITUD_CABECERA]
GO
/****** Object:  ForeignKey [FK_SOLICITUD_DETALLE_UNIDAD_TIEMPO]    Script Date: 04/03/2013 12:26:46 ******/
ALTER TABLE [dbo].[SOLICITUD_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_SOLICITUD_DETALLE_UNIDAD_TIEMPO] FOREIGN KEY([CODIGO_TIEMPO])
REFERENCES [dbo].[UNIDAD_TIEMPO] ([CODIGO_TIEMPO])
GO
ALTER TABLE [dbo].[SOLICITUD_DETALLE] CHECK CONSTRAINT [FK_SOLICITUD_DETALLE_UNIDAD_TIEMPO]
GO