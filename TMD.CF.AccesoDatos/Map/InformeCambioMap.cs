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
    static class InformeCambioMap
    {
        /// <summary>
        /// Clase encargada de mapear los datos de la Entidad Informe de Cambio
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static InformeCambio Select(IDataReader reader)
        {
            return new InformeCambio
            {
                Id = reader.GetInt("CODIGO"),
                Nombre = reader.GetString("NOMBRE"),
                FechaAprobacion = reader.GetDateTime("FECHA_APROBACION"),
                FechaRegistro = reader.GetDateTime("FECHA_REGISTRO"),
                EstimacionCosto = reader.GetString("ESTIMACION_COSTO"),
                EstimacionEsfuerzo = reader.GetString("ESTIMACION_ESFUERZO"),
                Recursos = reader.GetString("RECURSOS"),
                Estado = reader.GetInt("ESTADO"),
                Motivo = reader.GetString("MOTIVO")
            };
        }

        public static InformeCambio ListaSolicitudInforme(IDataReader reader)
        {
            return new InformeCambio
            {
                Id = reader.GetInt("CODIGO"),
                Nombre = reader.GetString("NOMBRE"),
                FechaAprobacion = reader.GetDateTime("FECHA_APROBACION"),
                FechaRegistro = reader.GetDateTime("FECHA_REGISTRO"),
                Estado = reader.GetInt("ESTADO"),
                Motivo = reader.GetString("MOTIVO"),
                Solicitud = new SolicitudCambio {  Id = reader.GetInt("CODIGO_SOLICITUD"), Nombre = reader.GetString("NOMBRE_SOLICITUD"), FechaAprobacion = reader.GetDateTime("SOLICITUD_FECHA_APROBACION") }, 
                IdSolicitud = reader.GetInt("CODIGO_SOLICITUD"),
                NombreSolicitud = reader.GetString("NOMBRE_SOLICITUD"),
                NombreArchivo = reader.GetString("NOMBRE_ARCHIVO")
            };
        }

        public static InformeCambio Obtener(IDataReader reader)
        {
            return new InformeCambio
            {
                Nombre = reader.GetString("NOMBRE_INFORME"),
                EstimacionCosto = reader.GetString("ESTIMACION_COSTO"),
                EstimacionEsfuerzo = reader.GetString("ESTIMACION_ESFUERZO"),
                Recursos = reader.GetString("RECURSOS"),
                Solicitud = new SolicitudCambio { Id = reader.GetInt("CODIGO_SOLICITUD"), Nombre = reader.GetString("NOMBRE_SOLICITUD"), LineaBase = new LineaBase { Id = reader.GetInt("CODIGO_LINEA_BASE") }, ProyectoFase = new ProyectoFase { Id = reader.GetInt("CODIGO_PROYECTO")} },
            };
        }
    }
}
