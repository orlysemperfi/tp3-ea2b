using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.AccesoDatos.Contrato
{
    /// <summary>
    /// Contrato  del Acceso a datos de la entidad Usuario.
    /// </summary>
    public interface IUsuarioData
    {
        /// <summary>
        /// Lista los usuario de un proyecto.
        /// </summary>
        /// <param name="proyecto">Proyecto</param>
        /// <returns>Lista Usuario</returns>
        List<Usuario> ListaPorProyecto(Proyecto proyecto);

        /// <summary>
        /// Lista los usuarios por rol.
        /// </summary>
        /// <param name="rol">rol</param>
        /// <returns>List Usuario</returns>
        List<Usuario> ListaPorRol(String rol);

        /// <summary>
        /// Obtiene un usuario de el login
        /// </summary>
        /// <param name="proyecto">Login usuario</param>
        /// <returns>Usuario</returns>
    Usuario ObtenerUsuario(string login);
    }
}
