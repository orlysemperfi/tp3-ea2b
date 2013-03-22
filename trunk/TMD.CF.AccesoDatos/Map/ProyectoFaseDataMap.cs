using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;
using System.Data;
using TMD.CF.AccesoDatos.Util;

namespace TMD.CF.AccesoDatos.Map
{
    static class ProyectoFaseDataMap
    {
        /// <summary>
        /// Mapea un IDataReader a una entidad Proyecto - Fase
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static ProyectoFase Select(IDataReader reader)
        {
            return new ProyectoFase
            {
                Id = reader.GetInt("CODIGO"),
                Proyecto = new Proyecto { Id = reader.GetInt("CODIGO_PROYECTO"), FechaFin = reader.GetDateTime("FECHA_FIN_PROYECTO") },
                Fase = new Fase { Id = reader.GetInt("CODIGO_FASE") },
                FechaInicio = reader.GetDateTime("FECHA_INICIO"),
                FechaFin = reader.GetDateTime("FECHA_FIN")
            };
        }
    }
}
