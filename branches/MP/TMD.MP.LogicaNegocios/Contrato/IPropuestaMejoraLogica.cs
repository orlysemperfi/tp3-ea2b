using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.MP.LogicaNegocios.Contrato
{
    public interface IPropuestaMejoraLogica
    {
        #region "Select"

        List<PropuestaMejoraEntidad> ObtenerPropuestaMejoraListadoPorFiltros(PropuestaMejoraEntidad oPropuestaMejoraFiltro);

        List<PropuestaMejoraEntidad> ObtenerPropuestaMejoraAsignadasListadoPorFiltros(PropuestaMejoraEntidad oPropuestaMejoraFiltro);

        PropuestaMejoraEntidad ObtenerPropuestaMejoraPorCodigo(int codigo);
        
        #endregion

        #region "Update"

        void ActualizarEstadoPropuestaMejora(PropuestaMejoraEntidad oPropuestaMejora);


        void ActualizarPropuestaMejora(PropuestaMejoraEntidad oPropuestaMejora);


        String BorrarPropuestaMejora(PropuestaMejoraEntidad oPropuestaMejora);

        #endregion

        #region "Insert"
        void InsertarPropuestaMejora(PropuestaMejoraEntidad entidad);
        #endregion
    }
}
