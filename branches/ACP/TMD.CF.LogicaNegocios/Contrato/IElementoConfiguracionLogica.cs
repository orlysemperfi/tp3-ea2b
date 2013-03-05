using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Contrato
{
    /// <summary>
    /// Contrato de la Logica de Negocio de la entidad Elemento de Configuracion.
    /// </summary>
    public interface IElementoConfiguracionLogica
    {
        /// <summary>
        /// Lista los Elementos de configuracion por Fase.
        /// </summary>
        /// <param name="fase">Fase</param>
        /// <returns>Lista ElementoConfiguracion</returns>
        List<ElementoConfiguracion> ListarPorFase(Fase fase);
    }
}
