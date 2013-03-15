using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.AccesoDatos.Contrato
{
    /// <summary>
    /// Contrato  del Acceso a datos de la entidad Proyetco Fase.
    /// </summary>
    public interface IProyectoFaseData
    {
        /// <summary>
        /// Obtiene una face proyecto por el id
        /// </summary>
        /// <param name="proyectoFase">Objeto Proyecto Fase</param>
        /// <returns>ProyectoFase</returns>
        ProyectoFase ObtenerPorFaseProyecto(ProyectoFase proyectoFase); 
    }
}
