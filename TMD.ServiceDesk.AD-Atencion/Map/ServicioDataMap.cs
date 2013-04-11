using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using TMD.SD.AccesoDatos_Atencion.Util;
using TMD.Entidades;

namespace TMD.SD.AccesoDatos_Atencion.Map
{
    static class ServicioDataMap
    {
        public static Servicio Select(IDataReader reader)
        {
            return new Servicio
            {
                Codigo_Servicio = reader.GetInt("CODIGO_SERVICIO"),
                Nombre_Servicio = reader.GetString("NOMBRE_SERVICIO"),
                Descripcion_Servicio = reader.GetString("DESCRIPCION_SERVICIO")

            };
        }


    }
}
