using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using TMD.SD.AccesoDatos_Atencion.Util;
using TMD.Entidades;

namespace TMD.SD.AccesoDatos_Atencion.Map
{
 
    static class CMDBDataMap
    {
        public static CMDB Select(IDataReader reader)
        {
            return new CMDB
            {
                Codigo_CMDB = reader.GetInt("CODIGO_CMDB"),
                Nombre_CMDB = reader.GetString("NOMBRE_CMDB"),
                Descripcion_CMDB = reader.GetString("DESCRIPCION_CMDB")

            };
        }
    }
}
