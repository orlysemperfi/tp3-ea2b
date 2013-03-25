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
    public class UsuarioProyectoData : DataBase, IUsuarioProyectoData
    {
        public UsuarioProyectoData(String connectionString)
            : base(connectionString)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public List<UsuarioProyecto> ListaUsuarioProyecto(int idUsuario)
        {
            List<UsuarioProyecto> listaUsuarioProyecto = new List<UsuarioProyecto>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.[USP_USUARIO_PROYECTO"))
            {
                DB.AddInParameter(command, "@CODIGO_USUARIO", DbType.Int32, idUsuario);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        listaUsuarioProyecto.Add(UsuarioProyectoMap.Select(reader));
                    }
                }
            }

            return listaUsuarioProyecto;
        }
    }
}
