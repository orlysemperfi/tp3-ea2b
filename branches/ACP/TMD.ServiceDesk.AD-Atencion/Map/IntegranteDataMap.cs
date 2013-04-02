using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using TMD.DBO.AccesoDatos_Atencion.Util;
using TMD.Entidades;


namespace TMD.DBO.AccesoDatos_Atencion.Map
{

    /// <summary>
    /// Clase encargada de mapear los datos de la entidad Integrante.
    /// </summary>
    static class IntegranteDataMap
    {
        public static Integrante Select(IDataReader reader)
        {
            return new Integrante
            {
                Codigo_Empleado  = reader.GetInt("CODIGO_EMPLEADO"),
                Codigo_Integrante =reader.GetInt("CODIGO_INTEGRANTE"),
                Alias_Empleado=reader.GetString("ALIAS_EMPLEADO"),
                Correo_Empleado =reader.GetString("CORREO_EMPLEADO"),
                Nombre_Empleado=reader.GetString("NOMBRE_EMPLEADO"),
                Nombre_Empleado_Proyecto=reader.GetString("NOMBRE_EMPLEADO_PROYECTO"),
                Nombre_Nivel_Carga = reader.GetString("NOMBRE_NIVEL_CARGA")
                
            };
        }


    }
}
