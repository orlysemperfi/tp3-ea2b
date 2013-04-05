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
    public class EntidadAuditadaData : DataBase, IEntidadAuditadaData
    {
        public EntidadAuditadaData(String connectionString)
            : base(connectionString)
        {
        }

        public List<EntidadAuditada> ListarEntidadesAuditadas()
        {
            List<EntidadAuditada> lista = new List<EntidadAuditada>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_LISTAR_MATRIZ_ENTIDAD_AUDITADA"))
            {
                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lista.Add(EntidadAuditadaDataMap.SelectEntidadAuditada(reader));
                    }
                }
            }

            return lista;
        }

        public EntidadAuditada ObtenerEntidadAuditada(int idEntidadAuditada)
        {
            EntidadAuditada eEntidadAuditada = new EntidadAuditada();
            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_OBTENER_ENTIDAD_AUDITADA"))
            {
                DB.AddInParameter(command, "@idEntidadAuditada", DbType.Int32, idEntidadAuditada);
                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        eEntidadAuditada = EntidadAuditadaDataMap.SelectEntidadAuditada(reader);
                        return eEntidadAuditada;
                    }
                }
            }
            return eEntidadAuditada;
        }
    }
}
