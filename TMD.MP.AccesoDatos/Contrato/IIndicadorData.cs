using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.MP.AccesoDatos.Contrato
{
    public interface IIndicadorData
    {
        #region "Select"

        List<IndicadorEntidad> ObtenerListaIndicadorPorPropuesta(int codigo_Propuesta);
        List<IndicadorEntidad> ObtenerIndicadorListadoPorFiltros(IndicadorEntidad oIndicadorFiltro);
        List<IndicadorEntidad> ObtenerIndicadorPorProceso(int codigo_Proceso);

        #endregion

        #region "Insert"

        void InsertarIndicador(IndicadorEntidad entidad);
        void InsertarPropuestaIndicador(IndicadorEntidad entidad);

        #endregion

        #region "Update"

        void ActualizarIndicador(IndicadorEntidad entidad);

        #endregion

        #region "Delete"

        void EliminarIndicadorPorPropuesta(int codigo_Propuesta);

        #endregion
    }
}
