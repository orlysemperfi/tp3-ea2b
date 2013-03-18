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
        PilotoEntidad ObtenerPilotoPorCodigo(int codigo);
        
        #endregion

        #region "Insert"

        PilotoEntidad InsertarPiloto(PilotoEntidad entidad);
        PilotoEntidad InsertarPilotoEstado(PilotoEstadoEntidad entidad);

        #endregion

        #region "Update"

        void ActualizarPiloto(PilotoEntidad oPiloto);

        void ActualizarEstadoPiloto(PilotoEntidad oPiloto);

        #endregion

        #region "Delete"

        void EliminarPilotoPorCodigo(int codigo);

        #endregion
    }
}
