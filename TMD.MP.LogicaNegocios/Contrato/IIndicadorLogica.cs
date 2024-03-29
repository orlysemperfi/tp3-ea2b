﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.MP.LogicaNegocios.Contrato
{
    public interface IIndicadorLogica
    {
        #region "Select"

        List<IndicadorEntidad> ObtenerListaIndicadorPorPropuesta(int codigo_Propuesta);

        List<IndicadorEntidad> ObtenerIndicadorListadoPorFiltros(IndicadorEntidad oIndicadorFiltro);
        List<IndicadorEntidad> ObtenerIndicadorPorProceso(int codigo_Proceso);

        IndicadorEntidad ObtenerIndicadorPorCodigo(int codigo);

        //Escala Cualitativo
        List<EscalaCualitativoEntidad> ObtenerListaEscalaCualitativoPorIndicador(int codigo_Indicador);        
        //Escala Cuantitativo
        List<EscalaCuantitativoEntidad> ObtenerListaEscalaCuantitativoPorIndicador(int codigo_Indicador);

        #endregion

        #region "Insert"

        void InsertarIndicador(IndicadorEntidad entidad);
        #endregion

        #region "Update"

        void ActualizarIndicador(IndicadorEntidad entidad);
        #endregion

        #region "Delete"
        
        void InactivarIndicador(IndicadorEntidad entidad); 
        
        #endregion
    }
}
