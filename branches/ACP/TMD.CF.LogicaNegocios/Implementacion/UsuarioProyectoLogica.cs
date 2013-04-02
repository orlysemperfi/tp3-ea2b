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
    /// Implementa la Logica de Negocios de la entidad UsuarioProyecto
    /// </summary>
    public class UsuarioProyectoLogica : IUsuarioProyectoLogica
    {
        private readonly IUsuarioProyectoData _usuarioProyectoData;

        public UsuarioProyectoLogica(IUsuarioProyectoData usuarioProyectoData)
        {
            _usuarioProyectoData = usuarioProyectoData;
        }

        /// <summary>
        /// Lista las fases de un proyecto.
        /// </summary>
        /// <param name="proyecto">Proyecto</param>
        /// <returns>Lista ProyectoFase</returns>

        public List<UsuarioProyecto> ListaUsuarioProyecto(int idUsuario)
        {
            return _usuarioProyectoData.ListaUsuarioProyecto(idUsuario);
        }
    }
}
