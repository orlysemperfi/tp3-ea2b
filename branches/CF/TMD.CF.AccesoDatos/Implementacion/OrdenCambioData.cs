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
using System.Data.SqlTypes;
using System.IO;

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
        /// Obtiene una orden por el Id
        /// </summary>
        /// <param name="id">Id de la orden</param>
        /// <returns>Objeto orden de cambio</returns>
        public OrdenCambio ObtenerPorId(int id)
        {
            OrdenCambio ordenCambio = null;

            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_ORDEN_CAMBIO_SEL_CODIGO"))
            {
                DB.AddInParameter(command, "@CODIGO", DbType.Int32, id);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    if (reader.Read())
                    {
                        ordenCambio = OrdenCambioMap.Obtener(reader);
                    }
                }
            }

            return ordenCambio;
        }

        /// <summary>
        /// Actualiza el archivo de una oden
        /// </summary>
        /// <param name="ordenCambio">Objeto orden a actualziar</param>
        public void ActualizarArchivo(OrdenCambio ordenCambio)
        {/*
            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_SOLICITUD_CAMBIO_UPD_ARCHIVO"))
            {
                DB.AddInParameter(command, "@CODIGO", DbType.Int32, solicitudCambio.Id);
                DB.AddInParameter(command, "@NOMBRE_ARCHIVO", DbType.String, solicitudCambio.NombreArchivo);
                DB.AddInParameter(command, "@EXTENSION", DbType.String, solicitudCambio.Extension);

                DB.AddOutParameter(command, "@RUTA_ARCHIVO", DbType.String, 8000);
                DB.AddOutParameter(command, "@TRANSACTION_CONTEXT", DbType.Binary, 8000);

                DB.ExecuteNonQuery(command);

                String ruta = DB.GetParameterValue(command, "@RUTA_ARCHIVO").ToString();
                byte[] context = (Byte[])DB.GetParameterValue(command, "@TRANSACTION_CONTEXT");

                using (var sqlFileStream = new SqlFileStream(ruta, context, FileAccess.Write))
                {
                    sqlFileStream.Write(solicitudCambio.Data, 0, solicitudCambio.Data.Length);
                    sqlFileStream.Close();
                }
            }*/
        }

        /// <summary>
        /// Obtiene el archivo de la orden de cambio
        /// </summary>
        /// <param name="id">Id de la orden</param>
        /// <returns>Archivo de la orden</returns>
        public OrdenCambio ObtenerArchivo(int id)
        {
            OrdenCambio elemento = null;
            /*
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
                        context = (byte[])reader[reader.GetOrdinal("TRANSACTION_CONTEXT")];
                    }
                }

                if (!String.IsNullOrEmpty(ruta))
                {
                    using (var sqlFileStream = new SqlFileStream(ruta, context, FileAccess.Read))
                    {
                        byte[] buffer = new byte[(int)sqlFileStream.Length];

                        sqlFileStream.Read(buffer, 0, buffer.Length);
                        sqlFileStream.Close();

                        elemento.Data = buffer;
                    }
                }
            
                return elemento;
            }*/
            return elemento;
        }
    }
}
