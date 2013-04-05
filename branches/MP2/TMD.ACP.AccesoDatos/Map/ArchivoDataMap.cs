using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Util;

namespace TMD.ACP.AccesoDatos.Map
{
    static class ArchivoDataMap
    {
        public static Archivo Select(IDataReader reader)
        {
            return new Archivo
            {
                idArchivo = reader.GetInt("idArchivo"),                
                fechaCarga = reader.GetDateTime("fechaCarga"),
                mimeType = reader.GetString("mimeType"),
                nombreArchivo = reader.GetString("nombreArchivo"),
                idOrigen = reader.GetIntNull("idOrigen"),
                tipoOrigen = reader.GetString("tipoOrigen")
            };
        }
    }
}
