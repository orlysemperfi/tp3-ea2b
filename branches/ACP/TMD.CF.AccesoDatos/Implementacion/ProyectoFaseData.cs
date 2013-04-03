using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.CF.AccesoDatos.Core;
using TMD.CF.AccesoDatos.Contrato;
using TMD.Entidades;
using System.Data.Common;
using System.Data;
using TMD.CF.AccesoDatos.Map;

namespace TMD.CF.AccesoDatos.Implementacion
{
    /// <summary>
    /// Implementacion  del Acceso a datos de la entidad Fase.
    /// </summary>
    public class ProyectoFaseData: DataBase, IProyectoFaseData
    {
        public ProyectoFaseData(String connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Obtiene una face proyecto por el id
        /// </summary>
        /// <param name="proyectoFase">Objeto Proyecto Fase</param>
        /// <returns>ProyectoFase</returns>
        public ProyectoFase ObtenerPorFaseProyecto(ProyectoFase proyectoFase)
        {
            ProyectoFase proyectoFaseSel = null;

            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_PROYECO_FASE_COD_PROYECTO_FASE"))
            {
                DB.AddInParameter(command, "@CODIGO_PROYECTO", DbType.Int32, proyectoFase.Proyecto.Id);
                DB.AddInParameter(command, "@CODIGO_FASE", DbType.Int32, proyectoFase.Fase.Id);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    if (reader.Read())
                    {
                        proyectoFaseSel = ProyectoFaseDataMap.Select(reader);
                    }
                }
            }

            return proyectoFaseSel;
        }
    }
}
