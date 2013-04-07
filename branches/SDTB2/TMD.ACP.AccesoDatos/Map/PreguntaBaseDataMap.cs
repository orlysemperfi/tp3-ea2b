using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Util;

namespace TMD.ACP.AccesoDatos.Map
{
    static class PreguntaBaseDataMap
    {
        public static DetallePreguntaBase Select(IDataReader reader)
        {
            return new DetallePreguntaBase
            {
                IdPreguntaBase = reader.GetInt("idPreguntaBase"),
                DescripcionPregunta = reader.GetString("descripcionPregunta"),
                IdNorma = reader.GetInt("idNorma"),
                DescripcionNorma = reader.GetString("descripcionNorma"),
                IdCapitulo = reader.GetInt("idCapitulo"),
                DescripcionCapitulo = reader.GetString("descripcionCapitulo")
            };
        }
    }
}
