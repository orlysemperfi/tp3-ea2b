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
    /// Clase encargada de mapear los datos de la Entidad Fase.
    /// </summary>
    static class FaseDataMap
    {
        /// <summary>
        /// Mapea un IDataReader a una entidad Fase.
        /// </summary>
        /// <param name="reader">Interfas IDataReader</param>
        /// <returns>Fase</returns>
        public static Fase Select(IDataReader reader)
        {
            return new Fase
            {
                Id = reader.GetInt("CODIGO"),
                Nombre = reader.GetString("NOMBRE"),
                LineaBase = new LineaBase { Id = reader.GetInt("CODIGO_LINEA_BASE") }
            };
        }
    }
}
