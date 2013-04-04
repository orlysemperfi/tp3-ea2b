using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.MP.LogicaNegocios.Contrato
{
    public interface IPilotoLogica
    {
        #region "Select"

        List<PilotoEntidad> ObtenerPilotoListadoPorFiltros(PilotoEntidad oPilotoFiltro);

        PilotoEntidad ObtenerPilotoPorCodigo(int codigo);
        
        #endregion

        #region "Update"

        void ActualizarPiloto(PilotoEntidad oPiloto);

        String BorrarPiloto(PilotoEntidad oPiloto);

        #endregion

        #region "Insert"
        void InsertarPiloto(PilotoEntidad entidad);
        #endregion
    }
}
