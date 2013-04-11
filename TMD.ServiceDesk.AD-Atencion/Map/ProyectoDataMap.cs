using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using TMD.SD.AccesoDatos_Atencion.Util;
using TMD.Entidades;



namespace TMD.SD.AccesoDatos_Atencion.Map
{
 
 static class ProyectoDataMap
    {
        public static Proyecto Select(IDataReader reader)
        {
            return new Proyecto
            {
                Codigo_Proyecto = reader.GetInt("CODIGO_PROYECTO"),
                Nombre_Proyecto = reader.GetString("NOMBRE_PROYECTO"),
                Codigo_Cliente = reader.GetInt("CODIGO_CLIENTE"),
                Nombre_Cliente = reader.GetString("RAZON_SOCIAL"),
         
            };
        }


    }

}
