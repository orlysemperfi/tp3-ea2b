using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Contrato
{
    /// <summary>
    /// Contrato  de la Logica de Negocios de la entidad Fase.
    /// </summary>
    public interface IFaseLogica
    {
        /// <summary>
        /// Lista las fases de un proyecto.
        /// </summary>
        /// <param name="proyecto">Proyecto</param>
        /// <returns>Lista ProyectoFase</returns>
        List<Fase> ListarPorProyecto(Proyecto proyecto);
    }
}
