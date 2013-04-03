using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Util;

namespace TMD.ACP.AccesoDatos.Map
{
    static class AuditoriaDataMap
    {
        public static Auditoria Select(IDataReader reader)
        {
            Auditoria objAuditoria = new Auditoria();

            objAuditoria.IdAuditoria = reader.GetInt("CODIGO_AUDITORIA");
            objAuditoria.ObjEntidadAuditada.IdEntidadAuditada = reader.GetInt("idEntidadAuditada");
            objAuditoria.ObjEntidadAuditada.NombreEntidadAuditada = reader.GetString("nombreEntidad");
            //objAuditoria.ObjEntidadAuditada.ObjArea.IdArea = reader.GetInt("idArea");
            //objAuditoria.ObjEntidadAuditada.ObjArea.NombreArea = reader.GetString("nombreArea");

            objAuditoria.ObjEntidadAuditada.ObjArea.codigo = reader.GetInt("CODIGO_AREA");
            objAuditoria.ObjEntidadAuditada.ObjArea.descripcion = reader.GetString("nombreArea");

            objAuditoria.FechaInicio = reader.GetDateTime("FECHA_INICIO");
            objAuditoria.FechaFin = reader.GetDateTime("FECHA_FIN");
            objAuditoria.Estado = reader.GetString("estado");
            objAuditoria.ObjEntidadAuditada.Responsable = reader.GetString("responsableProyecto");

            return objAuditoria;
        }

        public static Auditoria SelectListaPlanAuditoria(IDataReader reader)
        {
            Auditoria objAuditoria = new Auditoria();

            objAuditoria.IdAuditoria = reader.GetInt("CODIGO_AUDITORIA");
            objAuditoria.ObjEntidadAuditada.IdEntidadAuditada = reader.GetInt("idEntidadAuditada");
            objAuditoria.ObjEntidadAuditada.NombreEntidadAuditada = reader.GetString("nombreEntidad");
            //objAuditoria.ObjEntidadAuditada.ObjArea.IdArea = reader.GetInt("idArea");
            //objAuditoria.ObjEntidadAuditada.ObjArea.NombreArea = reader.GetString("nombreArea");

            objAuditoria.ObjEntidadAuditada.ObjArea.codigo = reader.GetInt("CODIGO_AREA");
            objAuditoria.ObjEntidadAuditada.ObjArea.descripcion = reader.GetString("nombreArea");

            objAuditoria.FechaInicio = reader.GetDateTime("FECHA_INICIO");
            objAuditoria.FechaFin = reader.GetDateTime("FECHA_FIN");
            objAuditoria.Estado = reader.GetString("ESTADO");
            return objAuditoria;
        }

        public static Auditoria SelectPlanAuditoria(IDataReader reader)
        {
            Auditoria objAuditoria = new Auditoria();

            objAuditoria.IdAuditoria = reader.GetInt("CODIGO_AUDITORIA");
            objAuditoria.ObjEntidadAuditada.IdEntidadAuditada = reader.GetInt("idEntidadAuditada");
            objAuditoria.ObjEntidadAuditada.NombreEntidadAuditada = reader.GetString("nombreEntidad");

            objAuditoria.ObjEntidadAuditada.ObjArea.codigo = reader.GetInt("CODIGO_AREA");
            objAuditoria.ObjEntidadAuditada.ObjArea.descripcion = reader.GetString("nombreArea");

            objAuditoria.FechaInicio = reader.GetDateTime("FECHA_INICIO");
            objAuditoria.FechaFin = reader.GetDateTime("FECHA_FIN");
            objAuditoria.Objetivo = reader.GetString("objetivo");
            objAuditoria.Alcance = reader.GetString("alcance");
            objAuditoria.ObjEntidadAuditada.Responsable = reader.GetString("responsableProyecto");
            objAuditoria.nombreArchivoL = reader.GetString("NOMBRE_ARCHIVO_L");
            objAuditoria.nombreArchivoF = reader.GetString("NOMBRE_ARCHIVO_F");

            return objAuditoria;
        }

        public static ProgramaAnualAuditoria SelectProgramaAnualAuditoria(IDataReader reader)
        {
            ProgramaAnualAuditoria oProgramaAnualAuditoria = new ProgramaAnualAuditoria();
            oProgramaAnualAuditoria.IdProgramaAnual = reader.GetInt("idPrograma");
            oProgramaAnualAuditoria.AnhoPrograma = reader.GetInt("anio");
            oProgramaAnualAuditoria.FechaCreacion = reader.GetDateTime("fechaElaboracion");
            oProgramaAnualAuditoria.IdUsuarioCreacion = reader.GetIntNull("elaboradoPor");
            oProgramaAnualAuditoria.UsuarioCreacion = reader.GetString("nombre1");
            oProgramaAnualAuditoria.FechaAprobacion = reader.GetDateTime("fechaAprobacion");
            oProgramaAnualAuditoria.IdUsuarioAprobacion = reader.GetIntNull("aprobadoPor");
            oProgramaAnualAuditoria.UsuarioAprobacion = reader.GetString("nombre2");
            oProgramaAnualAuditoria.Estado = reader.GetString("estado");
            return oProgramaAnualAuditoria;
        }

        public static Auditoria SelectAuditoriasPorAnio(IDataReader reader)
        {
            Auditoria objAuditoria = new Auditoria();
            objAuditoria.IdAuditoria = (int?) reader.GetInt("CODIGO_AUDITORIA");
            objAuditoria.ObjEntidadAuditada.IdEntidadAuditada = reader.GetInt("idEntidadAuditada");
            objAuditoria.ObjEntidadAuditada.NombreEntidadAuditada = reader.GetString("nombreEntidad");
            objAuditoria.ObjEntidadAuditada.ObjArea.codigo = reader.GetInt("CODIGO_AREA");
            objAuditoria.ObjEntidadAuditada.ObjArea.descripcion = reader.GetString("nombreArea");
            objAuditoria.Alcance = reader.GetString("alcance");
            objAuditoria.Objetivo = reader.GetString("objetivo");
            objAuditoria.FechaInicio = reader.GetDateTime("FECHA_INICIO");
            objAuditoria.FechaFin = reader.GetDateTime("FECHA_FIN");
            objAuditoria.Estado = reader.GetString("ESTADO");
            objAuditoria.ObjEntidadAuditada.IdResponsable = reader.GetInt("CODIGO_EMPLEADO");
            objAuditoria.ObjEntidadAuditada.Responsable = reader.GetString("NOMBREEMPLEADO");
            return objAuditoria;
        }

        public static Auditoria SelectInformeFinalAuditoria(IDataReader reader)
        {
            Auditoria objAuditoria = new Auditoria();

            objAuditoria.IdAuditoria = reader.GetInt("CODIGO_AUDITORIA");
            objAuditoria.ObjEntidadAuditada.IdEntidadAuditada = reader.GetInt("idEntidadAuditada");
            objAuditoria.ObjEntidadAuditada.NombreEntidadAuditada = reader.GetString("nombreEntidad");

            objAuditoria.ObjEntidadAuditada.ObjArea.codigo = reader.GetInt("CODIGO_AREA");
            objAuditoria.ObjEntidadAuditada.ObjArea.descripcion = reader.GetString("nombreArea");

            objAuditoria.FechaInicio = reader.GetDateTime("FECHA_INICIO");
            objAuditoria.FechaFin = reader.GetDateTime("FECHA_FIN");
            objAuditoria.Objetivo = reader.GetString("objetivo");
            objAuditoria.Alcance = reader.GetString("alcance");
            objAuditoria.ObjEntidadAuditada.Responsable = reader.GetString("responsableProyecto");
            objAuditoria.nombreArchivoL = reader.GetString("NOMBRE_ARCHIVO_L");
            objAuditoria.nombreArchivoF = reader.GetString("NOMBRE_ARCHIVO_F");
            objAuditoria.resultado = reader.GetString("RESULTADO");            
            objAuditoria.conclusion = reader.GetString("CONCLUSION");
            objAuditoria.recomendacion = reader.GetString("RECOMENDACION");
            objAuditoria.Estado = reader.GetString("ESTADO");
                        
            return objAuditoria;
        }
    }
}
