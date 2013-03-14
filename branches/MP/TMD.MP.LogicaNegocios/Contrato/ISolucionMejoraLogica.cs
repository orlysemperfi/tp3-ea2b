using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.MP.LogicaNegocios.Contrato
{
    public interface ISolucionMejoraLogica
    {
        #region "Select"

        List<SolucionMejoraEntidad> ObtenerSolucionMejoraListadoPorFiltros(SolucionMejoraEntidad oSolucionMejoraFiltro);

        SolucionMejoraEntidad ObtenerSolucionMejoraPorCodigo(int codigo);
        
        #endregion

        #region "Update"

        String BorrarSolucionMejora(SolucionMejoraEntidad oSolucionMejora);

        #endregion
    }
}
