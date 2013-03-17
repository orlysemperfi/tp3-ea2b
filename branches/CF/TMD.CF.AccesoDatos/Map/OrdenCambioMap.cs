using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;
using System.Data;
using TMD.CF.AccesoDatos.Util;

namespace TMD.CF.AccesoDatos.Map
{
    class OrdenCambioMap
    {
        /// <summary>
        /// Clase encargada de mapear los datos de la Entidad Orden de cambio.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static OrdenCambio Select(IDataReader reader)
        {
            return new OrdenCambio
            {
                Id = reader.GetInt("CODIGO"),
                Nombre = reader.GetString("NOMBRE_ORDEN"),
                InformeCambio = new InformeCambio { Id = reader.GetInt("CODIGO_INFORME"), Nombre = reader.GetString("NOMBRE") },
                UsuarioReg = new Usuario { Id = reader.GetInt("CODIGO_USUARIO_REG")},
                FechaRegistro = reader.GetDateTime("FECHA_REGISTRO"),
                Prioridad = reader.GetInt("PRIORIDAD"),
                UsuarioAsignado = new Usuario { Id = reader.GetInt("CODIGO_USUARIO_ASIGNADO")}
            };
        }
    }
}