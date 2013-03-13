using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.MP.AccesoDatos.Contrato;
using TMD.MP.AccesoDatos.Implementacion;
using TMD.Entidades;
using TMD.MP.LogicaNegocios.Contrato;
using TMD.MP.Comun;
namespace TMD.MP.LogicaNegocios.Implementacion
{
    public class IndicadorLogica : IIndicadorLogica

    {

        public IIndicadorData iIndicador;
        public IEscalaCualitativoData iEscalaCualitativo;
        public IEscalaCuantitativoData iEscalaCuantitativo;
        private static IIndicadorLogica instance;
        private IndicadorLogica() { }
        public static IIndicadorLogica getInstance()
        {
            if (instance == null) {
                instance = new IndicadorLogica();
            }
            return instance;
        }
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
        public IndicadorEntidad ObtenerIndicadorPorCodigo(int codigo) {
            iIndicador = new IndicadorDataSql();
            return iIndicador.ObtenerIndicadorPorCodigo(codigo);
        }

        #endregion

        #region "Insert"

        public IndicadorEntidad InsertarIndicador(IndicadorEntidad entidad)
        {
            iIndicador = new IndicadorDataSql();
            IndicadorEntidad oIndicadorEntidad = iIndicador.InsertarIndicador(entidad);
            if (oIndicadorEntidad.tipo == Constantes.TIPO_INDICADOR_CUALITATIVO) {
                iEscalaCualitativo = new EscalaCualitativoDataSql();
                iEscalaCualitativo.EliminarEscalaCualitativoPorIndicador(Convert.ToInt32(oIndicadorEntidad.codigo));
                foreach (EscalaCualitativoEntidad oEscalaCualitativo in entidad.lstEscalaCualitativo) 
                {
                    oEscalaCualitativo.codigo_Indicador = oIndicadorEntidad.codigo;
                    
                    iEscalaCualitativo.InsertarEscalaCualitativo(oEscalaCualitativo);
                }
            }
            if (oIndicadorEntidad.tipo == Constantes.TIPO_INDICADOR_CUANTITATIVO)
            {
                iEscalaCuantitativo = new EscalaCuantitativoDataSql();
                iEscalaCuantitativo.EliminarEscalaCuantitativoPorIndicador(Convert.ToInt32(oIndicadorEntidad.codigo));
                foreach (EscalaCuantitativoEntidad oEscalaCuantitativo in entidad.lstEscalaCuantitativo)
                {
                    oEscalaCuantitativo.codigo_Indicador = oIndicadorEntidad.codigo;                    
                    iEscalaCuantitativo.InsertarEscalaCuantitativo(oEscalaCuantitativo);
                }
            }
            return oIndicadorEntidad;
        }

        #endregion

        #region "Update"

        public void ActualizarIndicador(IndicadorEntidad entidad) 
        {
            iIndicador = new IndicadorDataSql();
            iIndicador.ActualizarIndicador(entidad);
            if (entidad.tipo == Constantes.TIPO_INDICADOR_CUALITATIVO)
            {
                iEscalaCualitativo = new EscalaCualitativoDataSql();
                iEscalaCualitativo.EliminarEscalaCualitativoPorIndicador(Convert.ToInt32(entidad.codigo));
                foreach (EscalaCualitativoEntidad oEscalaCualitativo in entidad.lstEscalaCualitativo)
                {
                    oEscalaCualitativo.codigo_Indicador = entidad.codigo;
                    iEscalaCualitativo.InsertarEscalaCualitativo(oEscalaCualitativo);
                }
            }
            if (entidad.tipo == Constantes.TIPO_INDICADOR_CUANTITATIVO)
            {
                iEscalaCuantitativo = new EscalaCuantitativoDataSql();
                iEscalaCuantitativo.EliminarEscalaCuantitativoPorIndicador(Convert.ToInt32(entidad.codigo));
                foreach (EscalaCuantitativoEntidad oEscalaCuantitativo in entidad.lstEscalaCuantitativo)
                {
                    oEscalaCuantitativo.codigo_Indicador = entidad.codigo;
                    iEscalaCuantitativo.InsertarEscalaCuantitativo(oEscalaCuantitativo);
                }
            }
        }

        #endregion

        #region "Delete"

        public void InactivarIndicador(IndicadorEntidad entidad)
        {
            iIndicador = new IndicadorDataSql();
            entidad.estado = Convert.ToInt32(Constantes.ESTADO_INDICADOR.INACTIVO);
            iIndicador.ActualizarIndicador(entidad);
        }

        #endregion


    }
}
