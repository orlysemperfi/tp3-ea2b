using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.Entidades;
using TMD.CF.AccesoDatos.Contrato;

namespace TMD.CF.LogicaNegocios.Implementacion
{
    /// <summary>
    /// Implementa la Logica de Negocios de la entidad Proyecto Fase
    /// </summary>
    public class ProyectoFaseLogica : IProyectoFaseLogica
    {
        private readonly IProyectoFaseData _proyectoFaseData;

        public ProyectoFaseLogica(IProyectoFaseData proyectoFaseData)
        {
            _proyectoFaseData = proyectoFaseData;
        }

        /// <summary>
        /// Obtiene una face proyecto por el id
        /// </summary>
        /// <param name="proyectoFase">Objeto Proyecto Fase</param>
        /// <returns>ProyectoFase</returns>
        public ProyectoFase ObtenerPorFaseProyecto(ProyectoFase proyectoFase)
        {
            return _proyectoFaseData.ObtenerPorFaseProyecto(proyectoFase);
        }
    }
}
