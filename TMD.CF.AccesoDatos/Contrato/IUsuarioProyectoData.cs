using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.AccesoDatos.Contrato
{
    /// <summary>
    /// Contrato de acceso a datos de la entidad UsuarioProyecto
    /// </summary>
    public interface IUsuarioProyectoData
    {
        /// <summary>
        /// Lista un usuario de un proyecto mediante su código
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        List<UsuarioProyecto> ListaUsuarioProyecto(int idUsuario);
    }
}
