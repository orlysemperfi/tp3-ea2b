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
    public class CapituloData : DataBase, ICapituloData
    {
        public CapituloData(String connectionString)
            : base(connectionString)
        {
        }

        public List<Capitulo> Obtener(int idNorma, int? idCapitulo)
        {
            List<Capitulo> lista = new List<Capitulo>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_OBTENER_CAPITULO"))
            {
                DB.AddInParameter(command, "@idNorma", DbType.Int32, idNorma);
                DB.AddInParameter(command, "@idCapitulo", DbType.Int32, idCapitulo);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lista.Add(CapituloDataMap.Select(reader));
                    }
                }
            }

            return lista;
        }
    }
}
