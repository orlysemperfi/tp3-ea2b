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
    ///  Clase encargada de mapear los datos de la Entidad LineaBase.
    /// </summary>
    static class LineaBaseMap
    {
        /// <summary>
        ///  Mapea un IDataReader a una entidad Linea Base.
        /// </summary>
        /// <param name="reader">Interfas IDataReader</param>
        /// <returns>LineaBase</returns>
        public static LineaBase Select(IDataReader reader)
        {
            return new LineaBase
            {
                Id = reader.GetInt("CODIGO"),
                Nombre = reader.GetString("NOMBRE"),
                Descripcion = reader.GetString("DESCRIPCION"),
                ProyectoFase = new ProyectoFase 
                { 
                    Id = reader.GetInt("CODIGO_PROYECTO_FASE"), 
                    Fase = new Fase 
                    { 
                        Id = reader.GetInt("CODIGO_FASE"),
                        Nombre = reader.GetString("NOMBRE_FASE")                        
                    },
                    FechaInicio = reader.GetDateTime("FECHA_INICIO"),
                    FechaFin = reader.GetDateTime("FECHA_FIN"),
                },
                Estado = reader.GetString("ESTADO"),
                FechaLiberacion = reader.GetDateTime("FECHA_LIBERACION")
            };
        }
    }
}
