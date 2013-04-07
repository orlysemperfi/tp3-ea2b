using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;
using System.Data;
using TMD.CF.AccesoDatos.Util;

namespace TMD.CF.AccesoDatos.Map
{
    /// <summary>
    /// Clase encargada de mapear los datos de la Entidad Proyecto.
    /// </summary>
    static class ProyectoDataMap
    {
        /// <summary>
        /// Mapea un IDataReader a una entidad Proyecto.
        /// </summary>
        /// <param name="reader">Interfas IDataReader</param>
        /// <returns>Proyecto</returns>
        public static Proyecto Select(IDataReader reader)
        {
            

            return new Proyecto
            {
                Id = reader.GetInt("CODIGO_PROYECTO"),
                Nombre = reader.GetString("NOMBRE"),
                Descripcion = reader.GetString("DESCRIPCION"),
                FechaInicio = reader.GetDateTime("FECHA_INICIO"),
                FechaFin = reader.GetDateTime("FECHA_FIN"),
                JefeProyecto = new Usuario
                {
                     Id = reader.GetInt("CODIGO_JEFE_PROYECTO")
                },
                Estado = reader.GetString("ESTADO")
            };
        }
    }
}
