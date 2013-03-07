using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Util;


namespace TMD.ACP.AccesoDatos.Map
{
    static class ActividadDataMap
    {
        public static Actividad SelectListaActividades(IDataReader reader)
        {
            Actividad objActividad = new Actividad();

            objActividad.ObjAuditoria.IdAuditoria = reader.GetInt("idAuditoria");
            objActividad.IdActividad = reader.GetInt("idActividad");
            objActividad.IdAuditor = reader.GetInt("idAuditor");
            objActividad.DescripcionActividad = reader.GetString("descripcionActividad");
            objActividad.Lugar = reader.GetString("lugar");
            objActividad.FechaInicio = reader.GetDateTime("fechaInicio");
            objActividad.FechaFin = reader.GetDateTime("fechaFin");
            objActividad.Estado = reader.GetString("estado");
            return objActividad;
        }
    }
}
