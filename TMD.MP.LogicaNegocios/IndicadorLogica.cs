using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.MP.AccesoDatos.Interfaces;
using TMD.MP.AccesoDatos.Metodos;
using TMD.Entidades;

namespace TMD.MP.LogicaNegocios
{
    public class IndicadorLogica
    {
        public IIndicadorData iIndicador;
        public IEscalaCualitativoData iEscalaCualitativo;
        public IEscalaCuantitativoData iEscalaCuantitativo;
        #region "Select"

        public List<IndicadorEntidad> ObtenerListaIndicadorPorPropuesta(int codigo_Propuesta) 
        {
            iIndicador = new IndicadorDataSql();
            return iIndicador.ObtenerListaIndicadorPorPropuesta(codigo_Propuesta);
        }

        public List<IndicadorEntidad> ObtenerIndicadorListadoPorFiltros(IndicadorEntidad oIndicadorFiltro)
        {
            iIndicador = new IndicadorDataSql();
            return iIndicador.ObtenerIndicadorListadoPorFiltros(oIndicadorFiltro);
        }
        public List<IndicadorEntidad> ObtenerIndicadorPorProceso(int codigo_Proceso)
        {
            iIndicador = new IndicadorDataSql();
            return iIndicador.ObtenerIndicadorPorProceso(codigo_Proceso);
        }
        #endregion

        #region "Insert"

        public void InsertarIndicador(IndicadorEntidad entidad)
        {
            iIndicador = new IndicadorDataSql();
            iIndicador.InsertarIndicador(entidad);
        }

        #endregion

        #region "Update"

        public void ActualizarIndicador(IndicadorEntidad entidad) 
        { }

        #endregion

        #region "Delete"

        public void EliminarIndicadorPorCodigo(int codigo) 
        { }

        #endregion

        //Escala Cualitativo
        public List<EscalaCualitativoEntidad> ObtenerListaEscalaCualitativoPorIndicador(int codigo_Indicador)
        {
            iEscalaCualitativo = new EscalaCualitativoDataSql();
            return iEscalaCualitativo.ObtenerListaEscalaCualitativoPorIndicador(codigo_Indicador);
        }

        //Escala Cuantitativo
        public List<EscalaCuantitativoEntidad> ObtenerListaEscalaCuantitativoPorIndicador(int codigo_Indicador)
        {
            iEscalaCuantitativo = new EscalaCuantitativoDataSql();
            return iEscalaCuantitativo.ObtenerListaEscalaCuantitativoPorIndicador(codigo_Indicador);
        }
    }
}
