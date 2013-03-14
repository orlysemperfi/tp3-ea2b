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

        public static Auditoria SelectAuditoriasSeguimientoHallazgo(IDataReader reader)
        {
   
            Auditoria objAuditoria = new Auditoria();

            objAuditoria.IdAuditoria = reader.GetInt("CODIGO_AUDITORIA");            
            objAuditoria.ObjEntidadAuditada.NombreEntidadAuditada = reader.GetString("AUDITORIA");           
            objAuditoria.ObjEntidadAuditada.ObjArea.codigo = reader.GetInt("CODIGO_AREA");
            objAuditoria.ObjEntidadAuditada.ObjArea.descripcion = reader.GetString("AREA");
            objAuditoria.FechaInicio = reader.GetDateTime("FECHA_INICIO");
            objAuditoria.FechaFin = reader.GetDateTime("FECHA_FIN");
            objAuditoria.Estado = reader.GetString("ESTADO");            

            return objAuditoria;

        }

        public static Hallazgo ObtenerHallazgosSeguimiento(IDataReader reader)
        {

            Hallazgo objHallazgo = new Hallazgo();
            
            objHallazgo.IdHallazgo = reader.GetInt("idHallazgo");
            objHallazgo.IdAuditoria = reader.GetInt("idAuditoria");
            objHallazgo.IdPreguntaVerificacion = reader.GetInt("idPreguntaVerificacion");
            objHallazgo.Descripcion = reader.GetString("descripcion");
            objHallazgo.TipoHallazgo = reader.GetString("tipoHallazgo");
            objHallazgo.FechaCompromiso = reader["fechaCompromiso"]!=DBNull.Value?(DateTime?)reader.GetDateTime("fechaCompromiso"):null;
            objHallazgo.FechaSeguimiento = reader["fechaSeguimiento"] != DBNull.Value ? (DateTime?)reader.GetDateTime("fechaSeguimiento") : null;            
            objHallazgo.ComentarioSeguimiento = reader.GetString("comentarioSeguimiento");
            objHallazgo.IdAuditorSeguimiento = reader["idAuditorSeguimiento"] != DBNull.Value ? (int?)reader.GetInt("idAuditorSeguimiento") : null;            
            objHallazgo.ResponsableSeguimiento = reader.GetString("responsableSeguimiento");
            objHallazgo.Estado = reader.GetString("estado");

            return objHallazgo;

        }

        
    }
}
