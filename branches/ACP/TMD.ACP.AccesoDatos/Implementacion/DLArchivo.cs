using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using TMD.ACP.AccesoDatos.Core;
using TMD.Entidades;
using System.Data.Common;
using System.Data;
using TMD.ACP.AccesoDatos.Map;

namespace TMD.ACP.AccesoDatos.Implementacion
{
    public class DLArchivo: DataBase
    {
        private int numeroRegistros;

        public DLArchivo(String connectionString)
            : base(connectionString)
        {
        }
        
        public List<Archivo> SelectAll(int idOrigen, char tipoOrigen)
        {
            List<Archivo> lstArchivos = new List<Archivo>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_OBTENER_ARCHIVOS"))
            {
                DB.AddInParameter(command, "@idOrigen", DbType.Int32, idOrigen);
                DB.AddInParameter(command, "@tipoOrigen", DbType.String, tipoOrigen);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lstArchivos.Add(ArchivoDataMap.Select(reader));
                    }
                }
            }

            return lstArchivos;
        }

        public Archivo ObtenerArchivo(int idArchivo)
        {
            Archivo oArchivo = null;

            var context = new DAArchivoDataContext(DB.ConnectionString);
            var x = (from a in context.AC_ARCHIVOs
                     where a.idArchivo == idArchivo
                     select a).SingleOrDefault();

            if (x != null)
            {
                oArchivo = new Archivo()
                {
                     idArchivo = x.idArchivo,
                     dataBinaria = x.dataBinaria.ToArray(),
                     nombreArchivo = x.nombreArchivo,
                     mimeType = x.mimeType,
                     fechaCarga = x.fechaCarga,
                     idOrigen = x.idOrigen,
                     tipoOrigen = x.tipoOrigen.HasValue?x.tipoOrigen.Value.ToString():string.Empty
                };
 
            }

            return oArchivo;
        }

        public int InsertarArchivo(Archivo oArchivo)
        {
            var context = new DAArchivoDataContext(DB.ConnectionString);
            Binary linqByteArray = new Binary(oArchivo.dataBinaria);
            char? ctipoOrigen = null;

            if (!String.IsNullOrEmpty(oArchivo.tipoOrigen)) ctipoOrigen = char.Parse(oArchivo.tipoOrigen);

            var archivedFile = new AC_ARCHIVO()
            {
                dataBinaria = linqByteArray,
                mimeType = oArchivo.mimeType,
                nombreArchivo = oArchivo.nombreArchivo,
                fechaCarga = DateTime.Now,
                idOrigen = oArchivo.idOrigen,
                tipoOrigen = ctipoOrigen
            };
            context.AC_ARCHIVOs.InsertOnSubmit(archivedFile);
            context.SubmitChanges();
            return archivedFile.idArchivo;
        }

        public void ModificarArchivo(int idArchivo, int idOrigen, string tipoOrigen)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_MODIFICAR_ARCHIVO"))
            {
                DB.AddInParameter(command, "@idArchivo", DbType.Int32, idArchivo);
                DB.AddInParameter(command, "@idOrigen", DbType.Int32, idOrigen);
                DB.AddInParameter(command, "@tipoOrigen", DbType.String, tipoOrigen);

                DB.ExecuteNonQuery(command);
            }   
        }

        public void EliminarArchivo(int idArchivo)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_ELIMINAR_ARCHIVO"))
            {
                DB.AddInParameter(command, "@idArchivo", DbType.Int32, idArchivo);

                DB.ExecuteNonQuery(command);
            }    
        }

        public void EliminarGrupoArchivos(int idOrigen, string tipoOrigen)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_ELIMINAR_GRUPO_ARCHIVOS"))
            {
                DB.AddInParameter(command, "@idOrigen", DbType.Int32, idOrigen);
                DB.AddInParameter(command, "@tipoOrigen", DbType.String, tipoOrigen);

                DB.ExecuteNonQuery(command);
            }
        }
                
    }
}
