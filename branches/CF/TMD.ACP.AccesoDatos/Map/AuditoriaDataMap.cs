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

            objAuditoria.IdAuditoria = reader.GetInt("idAuditoria");
            objAuditoria.ObjEntidadAuditada.IdEntidadAuditada = reader.GetInt("idEntidadAuditada");
            objAuditoria.ObjEntidadAuditada.NombreEntidadAuditada = reader.GetString("nombreEntidad");
            //objAuditoria.ObjEntidadAuditada.ObjArea.IdArea = reader.GetInt("idArea");
            //objAuditoria.ObjEntidadAuditada.ObjArea.NombreArea = reader.GetString("nombreArea");

            objAuditoria.ObjEntidadAuditada.ObjArea.codigo = reader.GetInt("idArea");
            objAuditoria.ObjEntidadAuditada.ObjArea.descripcion = reader.GetString("nombreArea");

            objAuditoria.FechaInicio = reader.GetDateTime("fechaInicio");
            objAuditoria.FechaFin = reader.GetDateTime("fechaFin");
            objAuditoria.Estado = reader.GetString("estado");
            objAuditoria.ObjEntidadAuditada.Responsable = reader.GetString("responsableProyecto");

            return objAuditoria;
        }

        public static Auditoria SelectListaPlanAuditoria(IDataReader reader)
        {
            Auditoria objAuditoria = new Auditoria();

            objAuditoria.IdAuditoria = reader.GetInt("idAuditoria");
            objAuditoria.ObjEntidadAuditada.IdEntidadAuditada = reader.GetInt("idEntidadAuditada");
            objAuditoria.ObjEntidadAuditada.NombreEntidadAuditada = reader.GetString("nombreEntidad");
            //objAuditoria.ObjEntidadAuditada.ObjArea.IdArea = reader.GetInt("idArea");
            //objAuditoria.ObjEntidadAuditada.ObjArea.NombreArea = reader.GetString("nombreArea");

            objAuditoria.ObjEntidadAuditada.ObjArea.codigo = reader.GetInt("idArea");
            objAuditoria.ObjEntidadAuditada.ObjArea.descripcion = reader.GetString("nombreArea");

            objAuditoria.FechaInicio = reader.GetDateTime("fechaInicio");
            objAuditoria.FechaFin = reader.GetDateTime("fechaFin");
            objAuditoria.Estado = reader.GetString("estado");
            return objAuditoria;
        }

        public static Auditoria SelectPlanAuditoria(IDataReader reader)
        {
            Auditoria objAuditoria = new Auditoria();

            objAuditoria.IdAuditoria = reader.GetInt("idAuditoria");
            objAuditoria.ObjEntidadAuditada.IdEntidadAuditada = reader.GetInt("idEntidadAuditada");
            objAuditoria.ObjEntidadAuditada.NombreEntidadAuditada = reader.GetString("nombreEntidad");
            //objAuditoria.ObjEntidadAuditada.ObjArea.IdArea = reader.GetInt("idArea");
            //objAuditoria.ObjEntidadAuditada.ObjArea.NombreArea = reader.GetString("nombreArea");

            objAuditoria.ObjEntidadAuditada.ObjArea.codigo = reader.GetInt("idArea");
            objAuditoria.ObjEntidadAuditada.ObjArea.descripcion = reader.GetString("nombreArea");

            objAuditoria.FechaInicio = reader.GetDateTime("fechaInicio");
            objAuditoria.FechaFin = reader.GetDateTime("fechaFin");
            objAuditoria.Objetivo = reader.GetString("objetivo");
            objAuditoria.Alcance = reader.GetString("alcance");
            objAuditoria.ObjEntidadAuditada.Responsable = reader.GetString("responsableProyecto");

            return objAuditoria;
        }

    }
}
