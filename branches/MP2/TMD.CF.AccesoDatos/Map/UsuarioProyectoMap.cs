using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;
using System.Data;
using TMD.CF.AccesoDatos.Util;

namespace TMD.CF.AccesoDatos.Map
{
    static class UsuarioProyectoMap
    {
        public static UsuarioProyecto Select(IDataReader reader)
        {
            return new UsuarioProyecto
            {
                Id = reader.GetInt("CODIGO"),
                Acceso = reader.GetString("TIPO_ACCESO")
            };
        }
    }
}
