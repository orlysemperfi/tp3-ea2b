using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.AccesoDatos.Contrato;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Implementacion
{
    /// <summary>
    /// Implementa la Logica de Negocios de la entidad Usuario
    /// </summary>
    public class UsuarioLogica : IUsuarioLogica
    {
        private readonly IUsuarioData _usuarioData;

        public UsuarioLogica(IUsuarioData usuarioData)
        {
            _usuarioData = usuarioData;
        }

        /// <summary>
        /// Lista las fases de un proyecto.
        /// </summary>
        /// <param name="proyecto">Proyecto</param>
        /// <returns>Lista ProyectoFase</returns>
        public List<Usuario> ListaPorProyecto(Proyecto proyecto)
        {
            return _usuarioData.ListaPorProyecto(proyecto);
        }

        /// <summary>
        /// Lista los usuarios por rol
        /// </summary>
        /// <param name="rol">rol</param>
        /// <returns>Lista los usuarios por rol</returns>
        public List<Usuario> ListaPorRol(String rol)
        {
            return _usuarioData.ListaPorRol(rol);
        }

        public Usuario ObtenerUsuario(string login)
        {
            return _usuarioData.ObtenerUsuario(login);
        }
    }
}
