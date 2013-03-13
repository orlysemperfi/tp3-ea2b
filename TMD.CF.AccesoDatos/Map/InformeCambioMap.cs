﻿using System;
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
                Solicitud = new SolicitudCambio {  Id = reader.GetInt("CODIGO_SOLICITUD"), Nombre = reader.GetString("NOMBRE_SOLICITUD") } ,
            };
        }
    }
}
