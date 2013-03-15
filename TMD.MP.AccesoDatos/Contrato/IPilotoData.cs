using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.MP.AccesoDatos.Contrato
{
    public interface IPilotoData
    {
        #region "Select"

        List<PilotoEntidad> ObtenerPilotoListadoPorFiltros(PilotoEntidad oPilotoFiltro);
        List<PilotoEntidad> ObtenerPilotoAsignadasListadoPorFiltros(PilotoEntidad oPilotoFiltro);
        PilotoEntidad ObtenerPilotoPorCodigo(int codigo);
        
        #endregion

    }
}
