using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.MP.LogicaNegocios;
using TMD.Entidades;
namespace TMD.MP.Controlador
{
    public class IndicadorControlador
    {
        public IndicadorLogica indicadorLogica = new IndicadorLogica();

        #region "Select"

        public List<IndicadorEntidad> ObtenerListaIndicadorPorPropuesta(int codigo_Propuesta)
        {
            return indicadorLogica.ObtenerListaIndicadorPorPropuesta(codigo_Propuesta);
        }

        public List<IndicadorEntidad> ObtenerIndicadorListadoPorFiltros(IndicadorEntidad oIndicadorFiltro)
        {
            return indicadorLogica.ObtenerIndicadorListadoPorFiltros(oIndicadorFiltro);
        }

        #endregion
        public List<IndicadorEntidad> ObtenerIndicadorPorProceso(int codigo_Proceso)
        {
            return indicadorLogica.ObtenerIndicadorPorProceso(codigo_Proceso);
        }

        #region "Insert"

        public void InsertarIndicador(IndicadorEntidad entidad)
        {
            indicadorLogica.InsertarIndicador(entidad);

        }

        #endregion

        #region "Update"

        public void ActualizarIndicador(IndicadorEntidad entidad)
        {
            indicadorLogica.ActualizarIndicador(entidad);
        }
            
        #endregion

        #region "Delete"

        public void EliminarIndicadorPorCodigo(int codigo)
        {
            indicadorLogica.EliminarIndicadorPorCodigo(codigo);
        }

        #endregion

        //Escala Cualitativo
        public List<EscalaCualitativoEntidad> ObtenerListaEscalaCualitativoPorIndicador(int codigo_Indicador)
        {
            
            return indicadorLogica.ObtenerListaEscalaCualitativoPorIndicador(codigo_Indicador);
        }

        //Escala Cuantitativo
        public List<EscalaCuantitativoEntidad> ObtenerListaEscalaCuantitativoPorIndicador(int codigo_Indicador)
        {          
            return indicadorLogica.ObtenerListaEscalaCuantitativoPorIndicador(codigo_Indicador);
        }
    }
}
