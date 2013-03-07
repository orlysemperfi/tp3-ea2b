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
        PropuestaMejoraEntidad ObtenerPropuestaMejoraPorCodigo(int codigo);

        #endregion

        #region "Insert"

        void InsertarPropuestaMejora(PropuestaMejoraEntidad entidad);

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
