using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;
using System.Data;
using TMD.CF.AccesoDatos.Util;
using TMD.Core.Extension;

namespace TMD.CF.AccesoDatos.Map
{
    static class SolicitudCambioMap
    {
        /// <summary>
        /// Mapea un IDataReader a una entidad Solicitud de Cambio
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static SolicitudCambio Select(IDataReader reader)
        {
            return new SolicitudCambio
            {
                Id = reader.GetInt("CODIGO"),
                Nombre = reader.GetString("NOMBRE"),
                FechaAprobacion = reader.GetDateTime("FECHA_APROBACION"),
                FechaRegistro = reader.GetDateTime("FECHA_REGISTRO"),
                Estado = reader.GetInt("ESTADO"),
                Prioridad = reader.GetInt("PRIORIDAD"),
                Motivo = reader.GetString("MOTIVO")
            };
        }

        public static SolicitudCambio Obtener(IDataReader reader)
        {
            return new SolicitudCambio
                {
                    Id = reader.GetInt("CODIGO"),
                    Nombre = reader.GetString("NOMBRE"),
                    FechaAprobacion = reader.GetDateTime("FECHA_APROBACION"),
                    FechaRegistro = reader.GetDateTime("FECHA_REGISTRO"),
                    Estado = reader.GetString("ESTADO").ToInt(),
                    Prioridad = reader.GetInt("PRIORIDAD"),
                    Motivo = reader.GetString("MOTIVO"),
                    ProyectoFase = new ProyectoFase { Proyecto = new Proyecto { Id = reader.GetInt("CODIGO_PROYECTO"), Nombre = reader.GetString("PROYECTO")} },
                    LineaBase = new LineaBase { Id = reader.GetInt("CODIGO_LINEA_BASE"), Nombre = reader.GetString("LINEA_BASE") },
                    ElementoConfiguracion = new LineaBaseElementoConfiguracion { Id = reader.GetInt("CODIGO_ECS"), Nombre = reader.GetString("ELEMENTO") },
                    NombreArchivo = reader.GetString("NOMBRE_ARCHIVO")
                };
        }
    }
}
