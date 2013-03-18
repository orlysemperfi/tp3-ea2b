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
    public class SolucionMejoraLogica : ISolucionMejoraLogica
    {
        public ISolucionMejoraData iSolucionMejora;
        
        private static ISolucionMejoraLogica instance;
        private SolucionMejoraLogica() { }
        public static ISolucionMejoraLogica getInstance()
        {
            if (instance == null) {
                instance = new SolucionMejoraLogica();
            }
            return instance;
        }

        #region "Select"

        public List<SolucionMejoraEntidad> ObtenerSolucionMejoraListadoPorFiltros(SolucionMejoraEntidad oSolucionMejoraFiltro)
        {
            iSolucionMejora = new SolucionMejoraDataSql();

            List<SolucionMejoraEntidad> oSolucionMejoraColeccion = new List<SolucionMejoraEntidad>();
            try
            {
                oSolucionMejoraColeccion = iSolucionMejora.ObtenerSolucionMejoraListadoPorFiltros(oSolucionMejoraFiltro);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oSolucionMejoraColeccion;
        }

        public SolucionMejoraEntidad ObtenerSolucionMejoraPorCodigo(int codigo)
        {
            iSolucionMejora = new SolucionMejoraDataSql();
            SolucionMejoraEntidad oSolucionMejora = new SolucionMejoraEntidad();
            try
            {
                oSolucionMejora = iSolucionMejora.ObtenerSolucionMejoraPorCodigo(codigo);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oSolucionMejora;
        }

        #endregion


        #region "Insert"
        public void InsertarSolucionMejora(SolucionMejoraEntidad oSolucionMejora)
        {
            iSolucionMejora = new SolucionMejoraDataSql();
            SolucionEstadoEntidad oSolucionEstado = new SolucionEstadoEntidad();

            oSolucionMejora = iSolucionMejora.InsertarSolucionMejora(oSolucionMejora);
            oSolucionEstado.codigo_solucion = oSolucionMejora.codigo_Solucion;
            oSolucionEstado.codigo_estado = oSolucionMejora.codigo_Estado;

            iSolucionMejora.InsertarSolucionMejoraEstado(oSolucionEstado);


        }
        #endregion

        #region "Update"


        public void ActualizarSolucionMejora(SolucionMejoraEntidad oSolucionMejora)
        {
            iSolucionMejora = new SolucionMejoraDataSql();

            try
            {
                iSolucionMejora.ActualizarSolucionMejora(oSolucionMejora);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ActualizarEstadoSolucionMejora(SolucionMejoraEntidad oSolucionMejora)
        {
            iSolucionMejora = new SolucionMejoraDataSql();

            try
            {
                iSolucionMejora.ActualizarEstadoSolucionMejora(oSolucionMejora);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String BorrarSolucionMejora(SolucionMejoraEntidad oSolucionMejora)
        {
            iSolucionMejora = new SolucionMejoraDataSql();
            SolucionEstadoEntidad oSolucionEstado = new SolucionEstadoEntidad();

            if (oSolucionMejora.codigo_Estado == Convert.ToInt32(Constantes.ESTADO_SOLUCION.GENERADA))
            {
                oSolucionMejora.codigo_Estado = Convert.ToInt32(Constantes.ESTADO_SOLUCION.ELIMINADA);
                ActualizarEstadoSolucionMejora(oSolucionMejora);
                oSolucionEstado.codigo_solucion = oSolucionMejora.codigo_Solucion;
                oSolucionEstado.codigo_estado = oSolucionMejora.codigo_Estado;

                iSolucionMejora.InsertarSolucionMejoraEstado(oSolucionEstado);

                return null;
            }
            else
            {
                return Mensajes.Mensaje_No_Borrar_Solucion_Mejora;
            }
        }

        #endregion

    }
}
