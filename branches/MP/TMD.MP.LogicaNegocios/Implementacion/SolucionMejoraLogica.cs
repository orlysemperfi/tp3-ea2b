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
                //oSolucionMejora = iSolucionMejora.ObtenerSolucionMejoraPorCodigo(codigo);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oSolucionMejora;
        }

        #endregion

        #region "Update"

        public String BorrarSolucionMejora(SolucionMejoraEntidad oSolucionMejora)
        {
            
                return null;
            
        }

        #endregion

    }
}
