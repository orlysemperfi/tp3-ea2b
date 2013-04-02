using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Util;

namespace TMD.ACP.AccesoDatos.Map
{
    static class CapituloDataMap
    {
        public static Capitulo Select(IDataReader reader)
        {
            return new Capitulo
            {
                IdCapitulo = reader.GetInt("idCapitulo"),
                DescripcionCapitulo = reader.GetString("descripcionCapitulo")
            };
        }
    }
}
