using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Util;

namespace TMD.ACP.AccesoDatos.Map
{
    static class HallazgoDataMap
    {
        public static Hallazgo Select(IDataReader reader)
        {
            return new Hallazgo
            {
                IdHallazgo = reader.GetInt("idHallazgo"),
                Descripcion = reader.GetString("descripcion"),
                TipoHallazgo = reader.GetString("tipoHallazgo"),
                IdAuditoria = reader.GetInt("idAuditoria"),
                IdPreguntaVerificacion = reader.GetInt("idPreguntaVerificacion"),
                Estado = reader.GetString("estado"),
                nDoc = reader.GetInt("ndoc")
            };
        }
    }
}
