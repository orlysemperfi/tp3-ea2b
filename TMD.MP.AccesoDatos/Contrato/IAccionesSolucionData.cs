using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.MP.AccesoDatos.Contrato
{
    public interface IAccionesSolucionData
    {
        #region "Select"

        List<AccionesSolucionEntidad> ObtenerListaAccionesPorSolucion(int codigo);

        #endregion

        #region "Insert"

        void InsertarAccionesSolucion(AccionesSolucionEntidad entidad);

        #endregion

        #region "Update"

        void ActualizarAccionesSolucion(AccionesSolucionEntidad entidad);

        #endregion

        #region "Delete"

        void EliminarAccionesSolucionPorSolucion(int codigo_solucion);

        #endregion
    }
}
