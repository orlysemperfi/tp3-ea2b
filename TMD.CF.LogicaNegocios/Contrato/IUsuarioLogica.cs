using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Contrato
{
    /// <summary>
    /// Contrato  de la Logica de Negocios de la entidad Usuario.
    /// </summary>
    public interface IUsuarioLogica
    {
        /// <summary>
        /// Lista los usuario de un proyecto.
        /// </summary>
        /// <param name="proyecto">Proyecto</param>
        /// <returns>Lista Usuario</returns>
        List<Usuario> ListaPorProyecto(Proyecto proyecto);

        /// <summary>
        /// Lista los usuarios por rol
        /// </summary>
        /// <param name="rol">rol</param>
        /// <returns>Lista los usuarios por rol</returns>
        List<Usuario> ListaPorRol(String rol);

        /// <summary>
        /// Obtiene un usuario por el login
        /// </summary>
        /// <param name="proyecto">Login usuario</param>
        /// <returns>Usuario</returns>
        Usuario ObtenerUsuario(string login);
    }
}
