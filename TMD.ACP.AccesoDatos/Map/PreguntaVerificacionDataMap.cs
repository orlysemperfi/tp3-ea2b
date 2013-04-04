using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Util;

namespace TMD.ACP.AccesoDatos.Map
{
    static class PreguntaVerificacionDataMap
    {
        public static PreguntaVerificacion Select(IDataReader reader)
        {
            return new PreguntaVerificacion
            {
                idPreguntaVerificacion = reader.GetInt("idPreguntaVerificacion"),
                DescripcionPregunta = reader.GetString("descripcionPregunta"),
                Respuesta = reader.GetBoolNull("respuesta"),
                Sustento = reader.GetString("sustento"),
                Porcentaje = reader.GetDecimalNul("porcentaje"),
                CantidadPlanif=reader.GetInt("nCantPlan")
            };
        }

        public static PreguntaVerificacion SelectPreguntaVerificacionPorAuditoria(IDataReader reader)
        {
            return new PreguntaVerificacion
            {               
                idPreguntaVerificacion = reader.GetInt("idPreguntaVerificacion"),
                DescripcionPregunta = reader.GetString("descripcionPregunta"),
                IdNorma = reader.GetInt("idNorma"),
                IdCapitulo = reader.GetInt("idCapitulo"),
                Respuesta = reader.GetBoolNull("respuesta"),
                Sustento = reader.GetString("sustento"),
                Porcentaje = reader.GetDecimalNul("porcentaje")                
            };
        }
    }
}
