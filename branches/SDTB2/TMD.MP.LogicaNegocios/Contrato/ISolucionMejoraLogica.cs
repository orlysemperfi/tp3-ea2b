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

        List<SolucionMejoraEntidad> ObtenerSolucionMejoraListadoParaPiloto();

        //Acciones
        List<AccionesSolucionEntidad> ObtenerListaAccionesSolucionPorSolucion(int codigo_Solucion);       

        #endregion

        #region "Update"

        void ActualizarSolucionMejora(SolucionMejoraEntidad oSolucionMejora);

        String BorrarSolucionMejora(SolucionMejoraEntidad oSolucionMejora);

        #endregion

        #region "Insert"
        void InsertarSolucionMejora(SolucionMejoraEntidad entidad);
        #endregion
    }
}
