using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using TMD.SD.AccesoDatos_Atencion.Util;
using TMD.Entidades;

namespace TMD.SD.AccesoDatos_Atencion.Map
{
    static class TicketSeguimientoDataMap
    {

        public static SeguimientoTicket  Select(IDataReader reader)
        {

            return new SeguimientoTicket
            {
                Codigo_Ticket = reader.GetInt("CODIGO_TICKET"),
                Codigo_Seguimiento  = reader.GetBigInt("CODIGO_SEGUIMIENTO"),
                Fecha_Registro = reader.GetDateTime("FECHA_REGISTRO_INFORMACION_SEGUIMIENTO"),
                Descripcion_Seguimiento  = reader.GetString("DESCRIPCION_INFORMACION_SEGUIMIENTO"),
                Codigo_Equipo = reader.GetInt("CODIGO_EQUIPO"),
                Codigo_Integrante  = reader.GetInt("CODIGO_INTEGRANTE"),
                Tipo_Seguimiento=reader.GetString("TIPO_SEGUIMIENTO"),
                Nombre_Integrante =reader.GetString("NOMBRE_INTEGRANTE")
                
            };
        }

    }
}
