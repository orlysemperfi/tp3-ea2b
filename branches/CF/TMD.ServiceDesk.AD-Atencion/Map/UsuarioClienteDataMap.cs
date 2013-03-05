using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using TMD.SD.AccesoDatos_Atencion.Util;
using TMD.Entidades;


namespace TMD.SD.AccesoDatos_Atencion.Map
{
  
    static class UsuarioClienteDataMap
    {
        public static UsuarioCliente Select(IDataReader reader)
        {
            return new UsuarioCliente
            {
                Codigo_Usuario = reader.GetInt("CODIGO_USUARIO_CLIENTE"),
                Alias_Usuario = reader.GetString("ALIAS_USUARIO_CLIENTE"),
                Nombre_Usuario = reader.GetString("NOMBRE_USUARIO_CLIENTE"),
                Codigo_Cliente = reader.GetInt("CODIGO_CLIENTE"),
                Nombre_Cliente = reader.GetString("RAZON_SOCIAL"),
                Codigo_Sede = reader.GetInt("CODIGO_SEDE"),
                Nombre_Sede = reader.GetString("NOMBRE_SEDE")
            };
        }


    }

}
