using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.CF.AccesoDatos.Contrato;
using TMD.CF.AccesoDatos.Core;
using TMD.Entidades;
using System.Data.Common;
using System.Data;
using TMD.CF.AccesoDatos.Map;
using System.Data.SqlTypes;
using System.IO;
using TMD.CF.AccesoDatos.Util;

namespace TMD.CF.AccesoDatos.Implementacion
{
    public class LineaBaseElementoConfiguracionData : DataBase, ILineaBaseElementoConfiguracionData
    {
        public LineaBaseElementoConfiguracionData(String connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Agrega un registro a la tabla Elemento de Configuracion Linea Base.
        /// </summary>
        /// <param name="elemento">ElementoConfiguracion</param>
        public void Agregar(LineaBaseElementoConfiguracion elemento)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_LINEA_BASE_DETALLE_INS"))
            {
                DB.AddInParameter(command, "@VERSION_MAYOR", DbType.Int32, elemento.Version.Mayor);
                DB.AddInParameter(command, "@VERSION_MENOR", DbType.Int32, elemento.Version.Menor);
                DB.AddInParameter(command, "@CODIGO_LINEA_BASE", DbType.Int32, elemento.LineaBase.Id);
                DB.AddInParameter(command, "@CODIGO_ECS", DbType.Int32, elemento.ElementoConfiguracion.Id);
                DB.AddInParameter(command, "@CODIGO_RESPONSABLE", DbType.Int32, elemento.Responsable.Id);

                DB.AddOutParameter(command, "@CODIGO", DbType.Int32, 4);

                DB.ExecuteNonQuery(command);

                elemento.Id = Convert.ToInt32(DB.GetParameterValue(command, "@CODIGO"));
            }
        }

        /// <summary>
        /// Recupera la lista de detalle de una linea base
        /// </summary>
        /// <param name="lineaBase">Objeto Linea Base</param>
        /// <returns>List LineaBaseElementoConfiguracion</returns>
        public List<LineaBaseElementoConfiguracion> ListaPorLineaBase(LineaBase lineaBase,Usuario usuario = null)
        {
            List<LineaBaseElementoConfiguracion> listaLineaBaseECS = new List<LineaBaseElementoConfiguracion>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_LINEA_BASE_DET_SEL_CODIGO_LINEA_BASE"))
            {
                DB.AddInParameter(command, "@CODIGO_LINEA_BASE", DbType.Int32, lineaBase.Id);


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
                        listaLineaBaseECS.Add(LineaBaseElementoConfiguracionMap.Select(reader));
                    }
                }
            }

            return listaLineaBaseECS;
        }

        /// <summary>
        /// Elimina el detalle de una Linea Base
        /// </summary>
        /// <param name="lineaBase">Objeto Linea Base</param>
        public void Eliminar(LineaBase lineaBase)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_LINEA_BASE_DET_DEL_CODIGO_LINEA_BASE"))
            {
                DB.AddInParameter(command, "@CODIGO_LINEA_BASE", DbType.Int32, lineaBase.Id);

                DB.ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Actualiza el archivo de un Elemento de Configuracion
        /// </summary>
        /// <param name="elemento">Objeto LineaBaseElementoConfiguracion</param>
        public void ActualizarArchivo(LineaBaseElementoConfiguracion elemento)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_LINEA_BASE_DETALLE_UPD_ARCHIVO"))
            {
                DB.AddInParameter(command, "@CODIGO", DbType.Int32, elemento.Id);
                DB.AddInParameter(command, "@NOMBRE", DbType.String, elemento.Nombre);
                DB.AddInParameter(command, "@EXTENSION", DbType.String, elemento.Extension);

                DB.AddOutParameter(command, "@RUTA_ARCHIVO", DbType.String, 8000);
                DB.AddOutParameter(command, "@TRANSACTION_CONTEXT", DbType.Binary, 8000);

                DB.ExecuteNonQuery(command);

                String ruta = DB.GetParameterValue(command, "@RUTA_ARCHIVO").ToString();
                byte[] context = (Byte[])DB.GetParameterValue(command, "@TRANSACTION_CONTEXT");

                using (var sqlFileStream = new SqlFileStream(ruta, context, FileAccess.Write))
                {
                    sqlFileStream.Write(elemento.Data, 0, elemento.Data.Length);
                    sqlFileStream.Close();
                }
            }
        }

        /// <summary>
        /// Recupera un archivo de un Elemento de Configuracion
        /// </summary>
        /// <param name="id">Id del elemento de configuracion</param>
        /// <returns>byte[]</returns>
        public LineaBaseElementoConfiguracion ObtenerArchivo(int id)
        {
            LineaBaseElementoConfiguracion elemento = null;

            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_LINEA_BASE_DETALLE_SEL_ARCHIVO"))
            {
                DB.AddInParameter(command, "@CODIGO", DbType.Int32, id);

                String ruta = null;
                byte[] context = null;

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    if (reader.Read())
                    {
                        elemento = new LineaBaseElementoConfiguracion
                        {
                            Nombre = reader.GetString("NOMBRE")
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
    }
}
