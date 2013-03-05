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
    /// Contrato  del Acceso a datos de la entidad Linea Base.
    /// </summary>
    public class LineaBaseData : DataBase, ILineaBaseData
    {
        public LineaBaseData(String connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Agrega un registro a la tabla LineaBase.
        /// </summary>
        /// <param name="lineaBase">LineaBase</param>
        public void Agregar(LineaBase lineaBase)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_LINEA_BASE_INS"))
            {
                DB.AddInParameter(command, "@NOMBRE", DbType.String, lineaBase.Nombre);
                DB.AddInParameter(command, "@CODIGO_PROYECTO_FASE", DbType.Int32, lineaBase.ProyectoFase.Id);
                DB.AddInParameter(command, "@DESCRIPCION", DbType.String, lineaBase.Descripcion);

                DB.AddOutParameter(command, "@CODIGO", DbType.Int32, 4);

                DB.ExecuteNonQuery(command);

                lineaBase.Id = Convert.ToInt32(DB.GetParameterValue(command, "@CODIGO"));
            }
        }

        /// <summary>
        /// Lista las lineas base de una fase de un proyecto.
        /// </summary>
        /// <param name="proyecto">Objeto Proyecto</param>
        /// <returns>List LineaBase</returns>
        public List<LineaBase> ListarPorProyecto(Proyecto proyecto,Usuario usuario = null)
        {
            List<LineaBase> listaLineaBase = new List<LineaBase>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_LINEA_BASE_SEL_CODIGO_PROYECTO"))
            {
                DB.AddInParameter(command, "@CODIGO_PROYECTO", DbType.Int32, proyecto.Id);

                int idUsuario = 0;
                if (usuario != null)
                {
                    idUsuario = usuario.Id;
                }

                DB.AddInParameter(command, "@CODIGO_USUARIO", DbType.Int32, idUsuario);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        listaLineaBase.Add(LineaBaseMap.Select(reader));
                    }
                }
            }

            return listaLineaBase;
        }

        /// <summary>
        /// Obtiene una Linea Base por el Codigo Proyecto Fase
        /// </summary>
        /// <param name="proyectoFase">Objeto ProyectoFase</param>
        /// <returns>Objeto LineaBase</returns>
        public LineaBase ObtenerPorProyectoFase(ProyectoFase proyectoFase)
        {
            LineaBase lineaBase = null;

            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_LINEA_BASE_SEL_CODIGO_PROYECTO_FASE"))
            {
                DB.AddInParameter(command, "@CODIGO_PROYECTO", DbType.Int32, proyectoFase.Proyecto.Id);
                DB.AddInParameter(command, "@CODIGO_FASE", DbType.Int32, proyectoFase.Fase.Id);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    if (reader.Read())
                    {
                        lineaBase = LineaBaseMap.Select(reader);
                    }
                }
            }

            return lineaBase;
        }

        /// <summary>
        /// Actauliza un registro de la Tabla Linea Base
        /// </summary>
        /// <param name="lineaBase">LineaBase</param>
        public void Actualizar(LineaBase lineaBase)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_LINEA_BASE_UPD"))
            {
                DB.AddInParameter(command, "@NOMBRE", DbType.String, lineaBase.Nombre);
                DB.AddInParameter(command, "@DESCRIPCION", DbType.String, lineaBase.Descripcion);
                DB.AddInParameter(command, "@CODIGO", DbType.Int32, lineaBase.Id);

                DB.ExecuteNonQuery(command);
            }
        }
    }
}
