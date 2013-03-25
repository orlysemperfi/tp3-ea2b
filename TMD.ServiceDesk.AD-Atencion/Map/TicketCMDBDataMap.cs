using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using TMD.DBO.AccesoDatos_Atencion.Util;
using TMD.Entidades;

namespace TMD.DBO.AccesoDatos_Atencion.Map
{
  
    static class TicketCMDBDataMap
    {
        public static TicketCMDB Select(IDataReader reader)
        {
            return new TicketCMDB
            {
                Codigo_Ticket = reader.GetInt("CODIGO_TICKET"),
                Codigo_CMDB = reader.GetInt("CODIGO_CMDB"),
                Nombre_CMDB = reader.GetString("NOMBRE_CMDB"),
                Descripcion_CMDB = reader.GetString("DESCRIPCION_CMDB")

            };
        }
    }
}
