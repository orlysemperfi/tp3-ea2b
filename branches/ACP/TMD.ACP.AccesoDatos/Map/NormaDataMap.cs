using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Util;

namespace TMD.ACP.AccesoDatos.Map
{
    static class NormaDataMap
    {
        public static Norma Select(IDataReader reader)
        {
            return new Norma
            {
                IdNorma = reader.GetInt("idNorma"),
                DescripcionNorma = reader.GetString("descripcionNorma")
            };
        }
    }
}
