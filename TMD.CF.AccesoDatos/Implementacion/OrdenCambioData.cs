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
    /// Implementacion  del Acceso a datos de la entidad orden de cambio.
    /// </summary>
    public class OrdenCambioData : DataBase, IOrdenCambioData
    {
        public OrdenCambioData(String connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Agrega una solicitud de cambio
        /// </summary>
        /// <param name="informeCambio">Objeto Solicitud a agregar</param>
        public void Agregar(OrdenCambio ordenCambio)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_ORDEN_CAMBIO_INS"))
            {
                DB.AddInParameter(command, "@NOMBRE", DbType.String, ordenCambio.Nombre);
                DB.AddInParameter(command, "@CODIGO_INFORME", DbType.Int32, ordenCambio.InformeCambio.Id);
                DB.AddInParameter(command, "@CODIGO_USUARIO_REG", DbType.Int32, ordenCambio.UsuarioReg.Id);
                DB.AddInParameter(command, "@FECHA_REGISTRO", DbType.DateTime, DateTime.Now);
                DB.AddInParameter(command, "@PRIORIDAD", DbType.Int32, ordenCambio.Prioridad);
                DB.AddInParameter(command, "@CODIGO_USUARIO_ASIGNADO", DbType.Int32, ordenCambio.UsuarioAsignado.Id);

                DB.AddOutParameter(command, "@CODIGO", DbType.Int32, 4);

                DB.ExecuteNonQuery(command);

                ordenCambio.Id = Convert.ToInt32(DB.GetParameterValue(command, "@CODIGO"));
            }
        }

        /// <summary>
        /// Lista las ordenes de un proyecto
        /// </summary>
        /// <param name="codigoProyecto">Codigo proyecto</param>
        /// <param name="codigoLineaBase">Codigo linea Base</param>
        /// <returns>Lista Orden de cambio</returns>
        public List<OrdenCambio> ListarPorProyectoLBase(int codigoProyecto, int codigoLineaBase)
        {
            List<OrdenCambio> listaOrdenCambio = new List<OrdenCambio>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_ORDEN_CAMBIO_SEL_PROYECTO_LINEABASE"))
            {
                DB.AddInParameter(command, "@CODIGO_PROYECTO", DbType.Int32, codigoProyecto);
                DB.AddInParameter(command, "@CODIGO_LINEABASE", DbType.Int32, codigoLineaBase);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        listaOrdenCambio.Add(OrdenCambioMap.Select(reader));
                    }
                }
            }

            return listaOrdenCambio;
        }
    }
}
