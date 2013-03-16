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
        
        #endregion

        #region "Insert"

        SolucionMejoraEntidad InsertarSolucionMejora(SolucionMejoraEntidad entidad);

        #endregion

        #region "Update"

        void ActualizarSolucionMejora(SolucionMejoraEntidad oSolucionMejora);

        #endregion

        #region "Delete"

        void EliminarSolucionMejoraPorCodigo(int codigo);

        #endregion
    }
}
