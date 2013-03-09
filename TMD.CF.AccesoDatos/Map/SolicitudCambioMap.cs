using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;
using System.Data;
using TMD.CF.AccesoDatos.Util;

namespace TMD.CF.AccesoDatos.Map
{
    static class SolicitudCambioMap
    {
        public static SolicitudCambio Select(IDataReader reader)
        {
            return new SolicitudCambio
            {
                codigo = reader.GetInt("CODIGO"),
                Nombre = reader.GetString("NOMBRE"),
                FechaAprobacion = reader.GetDateTime("FECHA_APROBACION"),
                FechaRegistro = reader.GetDateTime("FECHA_REGISTRO"),
                Estado = reader.GetInt("ESTADO"),
                Prioridad = reader.GetInt("PRIORIDAD"),
                Motivo = reader.GetString("MOTIVO")
            };
        }
    }
}
