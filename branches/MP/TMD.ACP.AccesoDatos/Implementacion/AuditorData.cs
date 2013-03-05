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
    public class AuditorData : DataBase, IAuditorData
    {
        public AuditorData(String connectionString)
            : base(connectionString)
        {
        }

        public List<Auditor> ListarAuditoresPorAuditoria(int idAuditoria)
        {
            List<Auditor> lista = new List<Auditor>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_LISTAR_AUDITORES_POR_AUDITORIA"))
            {
                DB.AddInParameter(command, "@idAuditoria", DbType.Int32, idAuditoria);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lista.Add(AuditorDataMap.SelectListaAuditores(reader));
                    }
                }
            }

            return lista;
        }

        public void GrabarAuditor(Auditor auditor)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_INSERTAR_AUDITOR"))
            {
                DB.AddInParameter(command, "@idAuditoria", DbType.Int32, auditor.IdAuditoria);
                DB.AddInParameter(command, "@idAuditor", DbType.Int32, auditor.IdAuditor);                
                DB.ExecuteNonQuery(command);                
            }
        }

        public void EliminarAuditoresPorAuditoria(int idAuditoria)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_ELIMINAR_AUDITORES_X_AUDITORIA"))
            {
                DB.AddInParameter(command, "@idAuditoria", DbType.Int32, idAuditoria);                
                DB.ExecuteNonQuery(command);
            }
        }
    }
}
