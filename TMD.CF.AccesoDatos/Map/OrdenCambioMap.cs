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
        public static OrdenCambio Select(IDataReader reader)
        {
            return new OrdenCambio
            {
                Id = reader.GetInt("CODIGO"),
                InformeCambio = new InformeCambio { Id = reader.GetInt("CODIGO_INFORME") },
                UsuarioReg = new Usuario { Id = reader.GetInt("CODIGO_USUARIO_REG")},
                FechaRegistro = reader.GetDateTime("FECHA_REGISTRO"),
                FechaAprobacion = reader.GetDateTime("FECHA_APROBACION"),
                CodigoPrioridad = reader.GetInt("CODIGO_PRIORIDAD"),
                UsuarioAsignado = new Usuario { Id = reader.GetInt("CODIGO_USUARIO_ASIGNADO")},
                Estado = reader.GetInt("ESTADO"),
            };
        }
    }
}