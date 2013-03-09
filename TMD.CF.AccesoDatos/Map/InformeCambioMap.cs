using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;
using System.Data;
using TMD.CF.AccesoDatos.Util;

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
                Estado = reader.GetInt("ESTADO"),
                Motivo = reader.GetString("MOTIVO")
            };
        }
    }
}
