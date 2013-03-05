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
    /// Implementa la Logica de Negocio de la entidad Elemento de Configuracion.
    /// </summary>
    public class ElementoConfiguracionLogica : IElementoConfiguracionLogica
    {
        private readonly IElementoConfiguracionData _elementoConfData;

        public ElementoConfiguracionLogica(IElementoConfiguracionData elementoConfData)
        {
            _elementoConfData = elementoConfData;
        }

        /// <summary>
        /// Lista los Elementos de configuracion por Fase.
        /// </summary>
        /// <param name="fase">Fase</param>
        /// <returns>Lista ElementoConfiguracion</returns>
        public List<ElementoConfiguracion> ListarPorFase(Fase fase)
        {
            return _elementoConfData.ListarPorFase(fase);
        }
    }
}
