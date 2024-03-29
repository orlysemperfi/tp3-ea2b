﻿using System;
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
    /// Implementacion  del Acceso a datos de la entidad solicitud de cambio.
    /// </summary>
    public class SolicitudCambioData : DataBase, ISolicitudCambioData
    {

        public SolicitudCambioData(String connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Agrega una solicitud de cambio
        /// </summary>
        /// <param name="informeCambio">Objeto Solicitud a agregar</param>
        public void Agregar(SolicitudCambio solicitudCambio)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_SOLICITUD_CAMBIO_INS"))
            {
                DB.AddInParameter(command, "@NOMBRE", DbType.String, solicitudCambio.Nombre);
                DB.AddInParameter(command, "@CODIGO_PROYECTO", DbType.Int32, solicitudCambio.ProyectoFase.Proyecto.Id);
                DB.AddInParameter(command, "@CODIGO_LINEABASE", DbType.Int32, solicitudCambio.LineaBase.Id);
                DB.AddInParameter(command, "@CODIGO_USUARIO", DbType.Int32, solicitudCambio.Usuario.Id);
                DB.AddInParameter(command, "@FECHA_REGISTRO", DbType.DateTime, DateTime.Now);
                DB.AddInParameter(command, "@ESTADO", DbType.Int32, solicitudCambio.Estado);
                DB.AddInParameter(command, "@CODIGO_ECS", DbType.Int32, solicitudCambio.ElementoConfiguracion.Id);
                DB.AddInParameter(command, "@PRIORIDAD", DbType.Int32, solicitudCambio.Prioridad);

                DB.AddOutParameter(command, "@CODIGO", DbType.Int32, 4);

                DB.ExecuteNonQuery(command);

                solicitudCambio.Id = Convert.ToInt32(DB.GetParameterValue(command, "@CODIGO"));
            }
        }

        /// <summary>
        /// Aprueba una solicitud de cambio
        /// </summary>
        /// <param name="informeCambio">Objeto Solicitud a aprobar</param>
        public void Aprobar(SolicitudCambio solicitudCambio)
        {
            using (DbCommand command = DB.GetStoredProcCommand("USP_SOLICITUD_CAMBIO_APROBAR_UPD"))
            {
                DB.AddInParameter(command, "@CODIGO", DbType.Int32, solicitudCambio.Id);
                DB.AddInParameter(command, "@MOTIVO", DbType.String, solicitudCambio.Motivo);
                DB.AddInParameter(command, "@ESTADO", DbType.Int32, solicitudCambio.Estado);
                DB.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Lista las solicitudes por proyecto
        /// </summary>
        /// <param name="solicitudCambio">Objeto solicitud de cambio</param>
        /// <returns>Lista de solicitudes</returns>
        public List<SolicitudCambio> ListarPorProyectoLineaBase(SolicitudCambio solicitudCambio)
        {
            List<SolicitudCambio> solicitudesCambio = new List<SolicitudCambio>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_SOLICITUD_CAMBIO_SEL_PROYECTO_LINEABASE"))
            {
                DB.AddInParameter(command, "@CODIGO_PROYECTO", DbType.Int32, solicitudCambio.ProyectoFase.Proyecto.Id);
                DB.AddInParameter(command, "@CODIGO_LINEABASE", DbType.Int32, solicitudCambio.LineaBase.Id);
                DB.AddInParameter(command, "@ESTADO", DbType.String, solicitudCambio.Estado);
                DB.AddInParameter(command, "@PRIORIDAD", DbType.Int32, solicitudCambio.Prioridad);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        solicitudesCambio.Add(SolicitudCambioMap.Obtener(reader));
                    }
                }
            }

            return solicitudesCambio;
        }
        /// <summary>
        /// Obtiene una solicitud por el Id
        /// </summary>
        /// <param name="id">Id de la solicitud</param>
        /// <returns>Objetp Solicitud de cambio</returns>
        public SolicitudCambio ObtenerPorId(int id)
        {
            SolicitudCambio solicitudCambio = null;

            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_SOLICITUD_CAMBIO_SEL_CODIGO"))
            {
                DB.AddInParameter(command, "@CODIGO", DbType.Int32, id);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    if (reader.Read())
                    {
                        solicitudCambio = SolicitudCambioMap.Obtener(reader);
                    }
                }
            }

            return solicitudCambio;
        }

        /// <summary>
        /// Actualiza el archivo de una solicitud
        /// </summary>
        /// <param name="solicitudCambio">Objeto solicutd a actualziar</param>
        public void ActualizarArchivo(SolicitudCambio solicitudCambio)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_SOLICITUD_CAMBIO_UPD_ARCHIVO"))
            {
                DB.AddInParameter(command, "@CODIGO", DbType.Int32, solicitudCambio.Id);
                DB.AddInParameter(command, "@NOMBRE_ARCHIVO", DbType.String, solicitudCambio.NombreArchivo);
                DB.AddInParameter(command, "@EXTENSION", DbType.String, solicitudCambio.Extension);

                DB.AddOutParameter(command, "@RUTA_ARCHIVO", DbType.String, 8000);
                DB.AddOutParameter(command, "@TRANSACTION_CONTEXT", DbType.Binary, 8000);

                DB.ExecuteNonQuery(command);

                String ruta = DB.GetParameterValue(command, "@RUTA_ARCHIVO").ToString();
                byte[] context = (Byte[]) DB.GetParameterValue(command, "@TRANSACTION_CONTEXT");

                using (var sqlFileStream = new SqlFileStream(ruta, context, FileAccess.Write))
                {
                    sqlFileStream.Write(solicitudCambio.Data, 0, solicitudCambio.Data.Length);
                    sqlFileStream.Close();
                }
            }
        }

        /// <summary>
        /// Obtiene el archivo de la solicitud de cambio
        /// </summary>
        /// <param name="id">Id de la solicitud</param>
        /// <returns>Archivo de la solicitud</returns>
        public SolicitudCambio ObtenerArchivo(int id)
        {
            SolicitudCambio elemento = null;

            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_SOLICITUD_CAMBIO_SEL_ARCHIVO"))
            {
                DB.AddInParameter(command, "@CODIGO", DbType.Int32, id);

                String ruta = null;
                byte[] context = null;

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    if (reader.Read())
                    {
                        elemento = new SolicitudCambio
                            {
                                NombreArchivo = reader.GetString("NOMBRE_ARCHIVO")
                            };
                        ruta = reader.GetString("RUTA_ARCHIVO");
                        context = (byte[]) reader[reader.GetOrdinal("TRANSACTION_CONTEXT")];
                    }
                }

                if (!String.IsNullOrEmpty(ruta))
                {
                    using (var sqlFileStream = new SqlFileStream(ruta, context, FileAccess.Read))
                    {
                        byte[] buffer = new byte[(int) sqlFileStream.Length];

                        sqlFileStream.Read(buffer, 0, buffer.Length);
                        sqlFileStream.Close();

                        elemento.Data = buffer;
                    }
                }

                return elemento;
            }
        }
    }
}
