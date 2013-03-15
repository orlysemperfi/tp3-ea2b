using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Contrato
{
    /// <summary>
    /// Contrato  de la Logica de Negocios de la entidad Proyecto Fase.
    /// </summary>
    public interface IProyectoFaseLogica
    {
        /// <summary>
        /// Obtiene una face proyecto por el id
        /// </summary>
        /// <param name="proyectoFase">Objeto Proyecto Fase</param>
        /// <returns>ProyectoFase</returns>
        ProyectoFase ObtenerPorFaseProyecto(ProyectoFase proyectoFase);
    }
}
