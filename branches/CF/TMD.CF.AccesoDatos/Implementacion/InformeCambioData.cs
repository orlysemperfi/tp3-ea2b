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
            throw new NotImplementedException();
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

