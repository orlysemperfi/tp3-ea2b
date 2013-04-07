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

    /// <summary>
    /// Implementa el Acceso a datos de la entidad Usuario.
    /// </summary>
    public class UsuarioData : DataBase, IUsuarioData
    {

        public UsuarioData(String connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Lista los usuario de un proyecto.
        /// </summary>
        /// <param name="proyecto">Proyecto</param>
        /// <returns>List Usuario</returns>
        public List<Usuario> ListaPorProyecto(Proyecto proyecto)
        {
            List<Usuario> listaUsuario = new List<Usuario>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_USUARIO_SEL_CODIGO_PROYECTO"))
            {
                DB.AddInParameter(command, "@CODIGO_PROYECTO", DbType.Int32, proyecto.Id);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        listaUsuario.Add(UsuarioDataMap.Select(reader));
                    }
                }
            }

            return listaUsuario;
        }

        /// <summary>
        /// Lista los usuarios por rol.
        /// </summary>
        /// <param name="rol">rol</param>
        /// <returns>List Usuario</returns>
        public List<Usuario> ListaPorRol(String rol)
        {
            List<Usuario> listaUsuario = new List<Usuario>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_USUARIO_SEL_CODIGO_ROL"))
            {
                DB.AddInParameter(command, "@ROL", DbType.String, rol);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        listaUsuario.Add(UsuarioDataMap.Select(reader));
                    }
                }
            }

            return listaUsuario;
        }

        public Usuario ObtenerUsuario(string login)
        {
            Usuario usuario = new Usuario();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_USUARIO_SEL_LOGIN"))
            {
                DB.AddInParameter(command, "@LOGIN", DbType.String, login);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        usuario = UsuarioDataMap.ObtenerUsuarioProyecto(reader);
                    }
                }
            }

            return usuario;
        }
    }
}
