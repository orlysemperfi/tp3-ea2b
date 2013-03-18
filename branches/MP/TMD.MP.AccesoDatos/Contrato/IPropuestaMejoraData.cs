using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.MP.AccesoDatos.Contrato
{
    public interface IPropuestaMejoraData
    {
        #region "Select"

        List<PropuestaMejoraEntidad> ObtenerPropuestaMejoraListadoPorFiltros(PropuestaMejoraEntidad oPropuestaMejoraFiltro);
        List<PropuestaMejoraEntidad> ObtenerPropuestaMejoraAsignadasListadoPorFiltros(PropuestaMejoraEntidad oPropuestaMejoraFiltro);
        PropuestaMejoraEntidad ObtenerPropuestaMejoraPorCodigo(int codigo);

        List<PropuestaMejoraEntidad> ObtenerPropuestaMejoraListadoPorEstado(String estado);
        #endregion

        #region "Insert"

        PropuestaMejoraEntidad InsertarPropuestaMejora(PropuestaMejoraEntidad entidad);
        PropuestaMejoraEntidad InsertarPropuestaMejoraEstado(PropuestaEstadoEntidad entidad);

        #endregion

        #region "Update"

        void ActualizarEstadoPropuestaMejora(PropuestaMejoraEntidad oPropuestaMejora);

        void ActualizarPropuestaMejora(PropuestaMejoraEntidad oPropuestaMejora);

        #endregion

        #region "Delete"

        void EliminarPropuestaMejroaPorCodigo(int codigo);

        #endregion
    }
}
