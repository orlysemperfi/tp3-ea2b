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
    }
}
