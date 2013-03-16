using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using TMD.ACP.AccesoDatos.Contrato;
using TMD.ACP.AccesoDatos.Core;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Map;

namespace TMD.ACP.AccesoDatos.Implementacion
{
    public class ActividadData : DataBase, IActividadData
    {
        public ActividadData(String connectionString)
            : base(connectionString)
        {
        }

        public List<Actividad> ListarActividadesPorAuditoria(int idAuditoria)
        {
            List<Actividad> lista = new List<Actividad>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_LISTAR_ACTIVIDADES_POR_AUDITORIA"))
            {
                DB.AddInParameter(command, "@idAuditoria", DbType.Int32, idAuditoria);                

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lista.Add(ActividadDataMap.SelectListaActividades(reader));
                    }
                }
            }

            return lista;
        }

        public void GrabarActividad(Actividad actividad)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_INSERTAR_ACTIVIDAD"))
            {
                DB.AddInParameter(command, "@idAuditoria", DbType.Int32, actividad.ObjAuditoria.IdAuditoria);
                DB.AddInParameter(command, "@idActividad", DbType.Int32, actividad.IdActividad);
                DB.AddInParameter(command, "@idAuditor", DbType.Int32, actividad.IdAuditor);
                DB.AddInParameter(command, "@descripcionActividad", DbType.String, actividad.DescripcionActividad);
                DB.AddInParameter(command, "@lugar", DbType.String, actividad.Lugar);
                DB.AddInParameter(command, "@fechaInicio", DbType.Date, actividad.FechaInicio);
                DB.AddInParameter(command, "@fechaFin", DbType.Date, actividad.FechaFin);
                DB.AddInParameter(command, "@estado", DbType.String, actividad.Estado);

                DB.ExecuteNonQuery(command);
            }
        }

        public void EliminarActividadesPorAuditoria(int idAuditoria)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_ELIMINAR_ACTIVIDADES_X_AUDITORIA"))
            {
                DB.AddInParameter(command, "@idAuditoria", DbType.Int32, idAuditoria);
                DB.ExecuteNonQuery(command);
            }
        }


    }
}
