using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.MP.AccesoDatos.Contrato
{
    public interface IEscalaCualitativoData
    {
        #region "Select"

        List<EscalaCualitativoEntidad> ObtenerListaEscalaCualitativoPorIndicador(int codigo_Indicador);

        #endregion

        #region "Insert"

        void InsertarEscalaCualitativo(EscalaCualitativoEntidad entidad);

        #endregion

        #region "Update"

        void ActualizarEscalaCualitativo(EscalaCualitativoEntidad entidad);

        #endregion

        #region "Delete"

        void EliminarEscalaCualitativoPorIndicador(int codigo_indicador);

        #endregion
    }
}
