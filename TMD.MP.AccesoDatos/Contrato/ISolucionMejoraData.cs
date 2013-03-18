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
        SolucionMejoraEntidad ObtenerSolucionMejoraPorCodigo(int codigo);

        List<SolucionMejoraEntidad> ObtenerSolucionMejoraListadoPorEstado(String estado);
        #endregion

        #region "Insert"

        SolucionMejoraEntidad InsertarSolucionMejora(SolucionMejoraEntidad entidad);
        SolucionMejoraEntidad InsertarSolucionMejoraEstado(SolucionEstadoEntidad entidad);

        #endregion

        #region "Update"

        void ActualizarSolucionMejora(SolucionMejoraEntidad oSolucionMejora);

        void ActualizarEstadoSolucionMejora(SolucionMejoraEntidad oSolucionMejora);

        #endregion

        #region "Delete"

        void EliminarSolucionMejoraPorCodigo(int codigo);

        #endregion
    }
}
