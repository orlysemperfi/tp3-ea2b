﻿using System;
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