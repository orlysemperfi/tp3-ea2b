using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.MP.AccesoDatos.Contrato
{
    public interface ISolucionMejoraData
    {
        #region "Select"

        List<SolucionMejoraEntidad> ObtenerSolucionMejoraListadoPorFiltros(SolucionMejoraEntidad oSolucionMejoraFiltro);

        #endregion

    }
}
