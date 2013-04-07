using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using TMD.DBO.AccesoDatos_Atencion.Util;
using TMD.Entidades;


namespace TMD.DBO.AccesoDatos_Atencion.Map
{
    static class EquipoDataMap
    {
        public static Equipo Select(IDataReader reader)
        {
            return new Equipo
            {
                Codigo_Equipo = reader.GetInt("CODIGO_EQUIPO"),
                Nombre_Equipo = reader.GetString("NOMBRE_EQUIPO")

            };
        }
    }
}
