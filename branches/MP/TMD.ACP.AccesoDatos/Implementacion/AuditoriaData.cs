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
    public class AuditoriaData : DataBase, IAuditoriaData
    {
        public AuditoriaData(String connectionString)
            : base(connectionString)
        {
        }

        public List<Auditoria> Obtener(Auditoria filtro)
        {
            List<Auditoria> lista = new List<Auditoria>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_OBTENER_AUDITORIA"))
            {
                DB.AddInParameter(command, "@anhoAuditoria", DbType.Int32, filtro.AnhoAuditoria);
                DB.AddInParameter(command, "@idAuditoria", DbType.Int32, filtro.IdAuditoria);                
                DB.AddInParameter(command, "@estado", DbType.String, filtro.Estado);
                DB.AddInParameter(command, "@indChecklistEstablecido", DbType.Boolean, filtro.IndCheckListEstablecido);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lista.Add(AuditoriaDataMap.Select(reader));
                    }
                }
            }

            return lista;
        }

        public List<Auditoria> ListarPlanAuditorias(int anhoAuditoria, string estAutorizado, string estPlanificado)
        {
            List<Auditoria> lista = new List<Auditoria>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_LISTAR_PLAN_AUDITORIAS"))
            {
                DB.AddInParameter(command, "@anhoAuditoria", DbType.Int32, anhoAuditoria);
                DB.AddInParameter(command, "@estado1", DbType.String, estAutorizado);
                DB.AddInParameter(command, "@estado2", DbType.String, estPlanificado);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lista.Add(AuditoriaDataMap.SelectListaPlanAuditoria(reader));
                    }
                }
            }

            return lista;
        }

        public Auditoria ObtenerPlanAuditoriaPorID(int idAuditoria)
        {
            List<Auditoria> lista = new List<Auditoria>();
            Auditoria eAuditoria = new Auditoria();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_OBTENER_PLAN_AUDITORIA_POR_ID"))
            {
                DB.AddInParameter(command, "@idAuditoria", DbType.Int32, idAuditoria);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        eAuditoria = AuditoriaDataMap.SelectPlanAuditoria(reader);
                        return eAuditoria;
                    }
                }

            }
            return eAuditoria;
        }

        public void GrabarPlanAuditoria(Auditoria eAuditoria)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_INSERTAR_PLAN_AUDITORIA"))
            {
                DB.AddInParameter(command, "@idAuditoria", DbType.Int32, eAuditoria.IdAuditoria);
                DB.AddInParameter(command, "@estado", DbType.String, eAuditoria.Estado);
                DB.ExecuteNonQuery(command);
            }
        }
    }
}
