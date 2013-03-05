using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Contrato
{
    /// <summary>
    /// Contrato  de la Logica de Negocios de la entidad Proyecto.
    /// </summary>
    public interface IProyectoLogica
    {
        /// <summary>
        /// Lista los proyectos de un Usuario.
        /// </summary>
        /// <param name="usuario">Objeto Usuario</param>
        /// <returns>List Proyecto</returns>
        List<Proyecto> ListarPorUsuario(Usuario usuario);

        /// <summary>
        /// Recupera un proyecto por su Id
        /// </summary>
        /// <param name="id">Id del proyecto</param>
        /// <returns>Objeto Proyecto</returns>
        Proyecto ObtenerPorId(int id);

    }
}
