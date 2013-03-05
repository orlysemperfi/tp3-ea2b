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
    /// Implementa la Logica de Negocios de la entidad Fase
    /// </summary>
    public class FaseLogica : IFaseLogica
    {
        private readonly IFaseData _faseData;
                
        public FaseLogica(IFaseData faseData)
        {
            _faseData = faseData;
        }      

        /// <summary>
        /// Lista las fases de un proyecto.
        /// </summary>
        /// <param name="proyecto">Proyecto</param>
        /// <returns>Lista ProyectoFase</returns>
        public List<Fase> ListarPorProyecto(Proyecto proyecto)
        {
            return _faseData.ListarPorProyecto(proyecto);
        }
    }
}
