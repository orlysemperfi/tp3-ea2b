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
    ///  Clase encargada de mapear los datos de la Entidad Fase.
    /// </summary>
    static class UsuarioDataMap
    {
        /// <summary>
        ///  Mapea un IDataReader a una entidad Usuario.
        /// </summary>
        /// <param name="reader">Interfas IDataReader</param>
        /// <returns>Usuario</returns>
        public static Usuario Select(IDataReader reader)
        {
            return new Usuario
            {
                Id = reader.GetInt("CODIGO"),
                Nombre = reader.GetString("NOMBRE")
            };
        }
    }
}
