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
    public class NormaData : DataBase, INormaData
    {
        public NormaData(String connectionString)
            : base(connectionString)
        {
        }

        public List<Norma> Obtener(int? idNorma)
        {
            List<Norma> lista = new List<Norma>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_OBTENER_NORMA"))
            {
                DB.AddInParameter(command, "@idNorma", DbType.Int32, idNorma);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while(reader.Read())
                    {
                        lista.Add(NormaDataMap.Select(reader));
                    }
                }
            }

            return lista;
        }
    }
}
