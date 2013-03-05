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
    }
}
