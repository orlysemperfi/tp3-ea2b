using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using TMD.SD.AccesoDatos_Atencion.Util;
using TMD.Entidades;

namespace TMD.SD.AccesoDatos_Atencion.Map
{
    static class TicketDocumentoDataMap
    {

        public static DocumentoTicket  Select(IDataReader reader)
        {

            return new DocumentoTicket
            {
                Codigo_Ticket = reader.GetInt("CODIGO_TICKET"),
                Codigo_DocumentoTicket = Convert.ToInt32(reader.GetBigInt("CODIGO_INFORMACION_ADICIONAL")),
                Fecha_Registro = reader.GetDateTime("FECHA_REGISTRO_INFORMACION_ADICIONAL"),
                Descripcion_DocumentoTicket = reader.GetString("DESCRIPCION_INFORMACION_ADICIONAL"),
                Nombre_DocumentoTicket = reader.GetString("NOMBRE_ARCHIVO_INFORMACION_ADICIONAL"),
                Ruta_DocumentoTicket = reader.GetString("RUTA_INFORMACION_ADICIONAL"),
                Codigo_Equipo = reader.GetInt("CODIGO_EQUIPO"),
                Codigo_Integrante  = reader.GetInt("CODIGO_INTEGRANTE")
            };
        }

    }
}
