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
    public class SolicitudCambioData : DataBase, ISolicitudCambioData
    {

        public SolicitudCambioData(String connectionString)
            : base(connectionString)
        {
        }

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

        public List<SolicitudCambio> ListarPorProyectoLineaBase(SolicitudCambio solicitudCambio)
        {
            List<SolicitudCambio> solicitudesCambio = new List<SolicitudCambio>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_SOLICITUD_CAMBIO_SEL_CODIGO"))
            {
                DB.AddInParameter(command, "@CODIGO_PROYECTO", DbType.Int32, solicitudCambio.ProyectoFase.Proyecto.Id);
                DB.AddInParameter(command, "@CODIGO_LINEABASE", DbType.Int32, solicitudCambio.LineaBase.Id);


                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    if (reader.Read())
                    {
                        solicitudesCambio.Add(SolicitudCambioMap.Obtener(reader));
                    }
                }
            }

            return solicitudesCambio;
        }


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

        public void ActualizarArchivo(SolicitudCambio solicitudCambio)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_SOLICITUD_CAMBIO_UPD_ARCHIVO"))
            {
                DB.AddInParameter(command, "@CODIGO", DbType.Int32, solicitudCambio.Id);
                DB.AddInParameter(command, "@NOMBRE", DbType.String, solicitudCambio.Nombre);

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
                                Nombre = reader.GetString("NOMBRE")
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
