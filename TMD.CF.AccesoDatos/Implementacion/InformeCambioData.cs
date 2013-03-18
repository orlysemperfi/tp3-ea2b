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
        /// <param name="solicitudCambio"></param>
        public void Aprobar(InformeCambio informeCambio)
        {
            using (DbCommand command = DB.GetStoredProcCommand("USP_INFORME_CAMBIO_APROBAR_UPD"))
            {
                DB.AddInParameter(command, "@CODIGO", DbType.Int32, informeCambio.Id);
                DB.AddInParameter(command, "@MOTIVO", DbType.String, informeCambio.Motivo);
                DB.AddInParameter(command, "@ESTADO", DbType.Int32, informeCambio.Estado);
                DB.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solicitudCambio"></param>
        public void ActualizarArchivo(InformeCambio informeCambio)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_INFORME_CAMBIO_UPD_ARCHIVO"))
            {
                DB.AddInParameter(command, "@CODIGO", DbType.Int32, informeCambio.Id);
                DB.AddInParameter(command, "@NOMBRE_ARCHIVO", DbType.String, informeCambio.NombreArchivo);
                DB.AddInParameter(command, "@EXTENSION", DbType.String, informeCambio.Extension);

                DB.AddOutParameter(command, "@RUTA_ARCHIVO", DbType.String, 8000);
                DB.AddOutParameter(command, "@TRANSACTION_CONTEXT", DbType.Binary, 8000);

                DB.ExecuteNonQuery(command);

                String ruta = DB.GetParameterValue(command, "@RUTA_ARCHIVO").ToString();
                byte[] context = (Byte[])DB.GetParameterValue(command, "@TRANSACTION_CONTEXT");

                using (var sqlFileStream = new SqlFileStream(ruta, context, FileAccess.Write))
                {
                    sqlFileStream.Write(informeCambio.Data, 0, informeCambio.Data.Length);
                    sqlFileStream.Close();
                }
            }
        }

        /// <summary>
        /// Obtiene el archivo de un informe de cambio
        /// </summary>
        /// <param name="id">Id del informe</param>
        /// <returns>Archivo del informe</returns>
        public InformeCambio ObtenerArchivo(int id)
        {
            InformeCambio elemento = null;

            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_INFORME_CAMBIO_SEL_ARCHIVO"))
            {
                DB.AddInParameter(command, "@CODIGO", DbType.Int32, id);

                String ruta = null;
                byte[] context = null;

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    if (reader.Read())
                    {
                        elemento = new InformeCambio
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
            }
        }

        /// <summary>
        /// Lista los informes de una linea base
        /// </summary>
        /// <param name="informeCambio">Linea Base</param>
        /// <returns>Lista informes de cambio</returns>
        public List<InformeCambio> ListarPorProyectoLineaBase(InformeCambio informeCambio, int conNull)
        {
            List<InformeCambio> informesCambio = new List<InformeCambio>();

            if(conNull == 1)
            {
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
        } else {
               using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_INFORME_CAMBIO_SEL_PROYECTO_LINEABASE_NONULL"))
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

