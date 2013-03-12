using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.CF.AccesoDatos.Contrato;
using TMD.CF.AccesoDatos.Core;
using System.Data.Common;
using System.Data;
using TMD.Entidades;
using TMD.CF.AccesoDatos.Map;

namespace TMD.CF.AccesoDatos.Implementacion
{
    /// <summary>
    ///  Implementa el Acceso a datos de la entidad Fase.
    /// </summary>
    public class FaseData : DataBase, IFaseData
    {

        public FaseData(String connectionString)
            : base(connectionString)
        {
        }
        
        /// <summary>
        /// Lista las fases de un proyecto.
        /// </summary>
        /// <param name="proyecto">Proyecto</param>
        public List<Fase> ListarPorProyecto(Proyecto proyecto)
        {
            List<Fase> listaFase = new List<Fase>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_FASE_PROYECTO_SEL_CODIGO_PROYECTO"))
            {
                DB.AddInParameter(command, "@CODIGO_PROYECTO", DbType.Int32, proyecto.Id);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        listaFase.Add(FaseDataMap.Select(reader));
                    }
                }
            }

            return listaFase;
        }
    }
}
