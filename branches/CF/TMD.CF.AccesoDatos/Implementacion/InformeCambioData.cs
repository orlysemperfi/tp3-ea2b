using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using TMD.CF.AccesoDatos.Core;
using TMD.CF.AccesoDatos.Contrato;
using TMD.CF.AccesoDatos.Map;
using TMD.CF.AccesoDatos.Util;
using TMD.Entidades;
using System.Data.Common;
using System.Data;

namespace TMD.CF.AccesoDatos.Implementacion
{
    /// <summary>
    /// Implmentacion  del Acceso a datos de la entidad informe de cambio.
    /// </summary>
    public class InformeCambioData : DataBase, IInformeCambioData
    {
        public InformeCambioData(String connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Agrega un informe de cambio
        /// </summary>
        /// <param name="informeCambio">Objeto informe a agregar</param>
        public void Agregar(InformeCambio informeCambio)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_INFORME_CAMBIO_INS"))
            {
                DB.AddInParameter(command, "@NOMBRE", DbType.String, informeCambio.Nombre);
                DB.AddInParameter(command, "@CODIGO_SOLICITUD", DbType.Int32, informeCambio.Solicitud.Id);
                DB.AddInParameter(command, "@CODIGO_USUARIO", DbType.Int32, informeCambio.Usuario.Id);
                DB.AddInParameter(command, "@FECHA_REGISTRO", DbType.DateTime, DateTime.Now);
                DB.AddInParameter(command, "@ESTADO", DbType.Int32, 1);
                DB.AddInParameter(command, "@ESTIMACION_COSTO", DbType.String, informeCambio.EstimacionCosto);
                DB.AddInParameter(command, "@ESTIMACION_ESFUERZO", DbType.String, informeCambio.EstimacionEsfuerzo);
                DB.AddInParameter(command, "@RECURSOS", DbType.String, informeCambio.Recursos);

                DB.AddOutParameter(command, "@CODIGO", DbType.Int32, 4);

                DB.ExecuteNonQuery(command);

                informeCambio.Id = Convert.ToInt32(DB.GetParameterValue(command, "@CODIGO"));
            }
        }

        /// <summary>
        /// Aprueba un informe de cambio
        /// </summary>
        /// <param name="informeCambio">Objeto informe a aprobar</param>
        public void Aprobar(InformeCambio informeCambio)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lista los informes de una linea base
        /// </summary>
        /// <param name="informeCambio">Linea Base</param>
        /// <returns>Lista informes de cambio</returns>
        public List<InformeCambio> ListarPorProyectoLineaBase(InformeCambio informeCambio)
        {
            List<InformeCambio> informesCambio = new List<InformeCambio>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_INFORME_CAMBIO_SEL_PROYECTO_LINEABASE"))
            {
                DB.AddInParameter(command, "@CODIGO_PROYECTO", DbType.Int32, informeCambio.Solicitud.ProyectoFase.Proyecto.Id);
                DB.AddInParameter(command, "@CODIGO_LINEABASE", DbType.Int32, informeCambio.Solicitud.LineaBase.Id);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        informesCambio.Add(InformeCambioMap.ListaSolicitudInforme(reader));
                    }
                }
            }

            return informesCambio;
        }

        /// <summary>
        /// Obtiene un informe de cambio por el id
        /// </summary>
        /// <param name="id">Id informe</param>
        /// <returns>Informe de cambio</returns>
        public InformeCambio ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

