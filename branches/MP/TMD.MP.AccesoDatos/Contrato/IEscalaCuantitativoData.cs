using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.MP.AccesoDatos.Contrato
{
    public interface IEscalaCuantitativoData
    {
        #region "Select"

        List<EscalaCuantitativoEntidad> ObtenerListaEscalaCuantitativoPorIndicador(int codigo_Indicador);

        #endregion

        #region "Insert"

        void InsertarEscalaCuantitativo(EscalaCuantitativoEntidad entidad);

        #endregion

        #region "Update"

        void ActualizarEscalaCuantitativo(EscalaCuantitativoEntidad entidad);

        #endregion

        #region "Delete"

        void EliminarEscalaCuantitativoPorIndicador(int codigo_indicador);

        #endregion
    }
}
