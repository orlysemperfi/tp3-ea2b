using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;
using System.Data;
using TMD.CF.AccesoDatos.Util;

namespace TMD.CF.AccesoDatos.Map
{
    static class LineaBaseElementoConfiguracionMap
    {
        /// <summary>
        /// Clase encargada de mapear los datos de la Entidad LineaBase - Detalle.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static LineaBaseElementoConfiguracion Select(IDataReader reader)
        {
            return new LineaBaseElementoConfiguracion
            {
                Id = reader.GetInt("CODIGO"),
                Nombre = reader.GetString("NOMBRE"),
                Extension = reader.GetString("EXTENSION"),
                ElementoConfiguracion = new ElementoConfiguracion
                {
                    Id = reader.GetInt("CODIGO_ECS"),
                    Nombre = reader.GetString("ECS_NOMBRE"),
                    Tipo = "DC".Equals(reader.GetString("TIPO")) ? TipoElementoConfiguracion.Documento : TipoElementoConfiguracion.Release
                },
                NombreEcs = reader.GetString("ECS_NOMBRE"),
                Responsable = new Usuario
                {
                    Id = reader.GetInt("CODIGO_RESPONSABLE")
                },
                Version = new TMD.Entidades.Version
                {
                    Mayor = reader.GetInt("VERSION_MAYOR"),
                    Menor = reader.GetInt("VERSION_MENOR")
                },
                LineaBase = new LineaBase
                {
                    Id = reader.GetInt("CODIGO_LINEA_BASE"),
                    ProyectoFase = new ProyectoFase { FechaFin = reader.GetDateTime("FECHA_FIN") }
                }
            };
        }
    }
}
