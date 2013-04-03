using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.Entidades;
using TMD.CF.AccesoDatos.Contrato;
using TMD.Core.Caching;
using log4net;

namespace TMD.CF.LogicaNegocios.Implementacion
{
    /// <summary>
    /// Implementa la Logica de Negocio de la entidad Elemento de Configuracion.
    /// </summary>
    
    public class ElementoConfiguracionLogica : IElementoConfiguracionLogica
    {
        private readonly IElementoConfiguracionData _elementoConfData;
        private readonly ICacheAdapter _cacheAdapter;
        private static readonly ILog log = LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //PATRON: INYECION DE DEPENDENCIA
        public ElementoConfiguracionLogica(IElementoConfiguracionData elementoConfData, ICacheAdapter cacheAdapter)
        {
            _elementoConfData = elementoConfData;
            _cacheAdapter = cacheAdapter;
            log.Debug("Accesorios");
        }

        /// <summary>
        /// Lista los Elementos de configuracion por Fase.
        /// </summary>
        /// <param name="fase">Fase</param>
        /// <returns>Lista ElementoConfiguracion</returns>
        public List<ElementoConfiguracion> ListarPorFase(Fase fase)
        {            
            List<ElementoConfiguracion> lista =
                _cacheAdapter.Resolve(String.Format("_LisEcFase{0}",fase.Id), fase, _elementoConfData.ListarPorFase);
            log.Debug("Nuevo");
            return lista;
        }
    }
}
