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
    public class PreguntaBaseData : DataBase, IPreguntaBaseData
    {

        public PreguntaBaseData(String connectionString)
            : base(connectionString)
        {
        }

        public List<DetallePreguntaBase> ListarDetallePreguntasBase()
        {
            List<DetallePreguntaBase> lista = new List<DetallePreguntaBase>();

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT ");
            sb.Append("D.idNorma,N.descripcion AS descripcionNorma,D.idCapitulo,C.descripcion as descripcionCapitulo,D.idPreguntaBase,D.descripcionPregunta ");
            sb.Append("FROM AC_DET_PREGUNTA_BASE D ");
            sb.Append("INNER JOIN AC_CAPITULO C ON D.idCapitulo = C.idCapitulo ");
            sb.Append("INNER JOIN AC_NORMA N ON D.idNorma = N.idNorma ");
            sb.Append("INNER JOIN AC_PREGUNTA_BASE P ON D.idPreguntaBase = P.idPreguntaBase ");

            using (DbCommand command = DB.GetSqlStringCommand(sb.ToString()))
            {          
                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while(reader.Read())
                    {
                        lista.Add(PreguntaBaseDataMap.Select(reader));
                    }
                }
            }

            return lista;
        }
    }
}
