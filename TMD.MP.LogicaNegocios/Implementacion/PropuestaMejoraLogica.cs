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
    public class PropuestaMejoraLogica : IPropuestaMejoraLogica
    {
        public IPropuestaMejoraData iPropuestaMejora;
        public IIndicadorData iIndicador;
        public IEscalaCualitativoData iEscalaCualitativo;
        public IEscalaCuantitativoData iEscalaCuantitativo;
        private static IPropuestaMejoraLogica instance;
        private PropuestaMejoraLogica() { }
        public static IPropuestaMejoraLogica getInstance()
        {
            if (instance == null) {
                instance = new PropuestaMejoraLogica();
            }
            return instance;
        }

        #region "Select"

        public List <PropuestaMejoraEntidad> ObtenerPropuestaMejoraListadoPorFiltros(PropuestaMejoraEntidad oPropuestaMejoraFiltro)
        {
            iPropuestaMejora = new PropuestaMejoraDataSql();
            
            List <PropuestaMejoraEntidad> oPropuestaMejoraColeccion = new List <PropuestaMejoraEntidad>();
            try
            {
                oPropuestaMejoraColeccion = iPropuestaMejora.ObtenerPropuestaMejoraListadoPorFiltros(oPropuestaMejoraFiltro);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oPropuestaMejoraColeccion;
        }

        public List<PropuestaMejoraEntidad> ObtenerPropuestaMejoraAsignadasListadoPorFiltros(PropuestaMejoraEntidad oPropuestaMejoraFiltro)
        {
            iPropuestaMejora = new PropuestaMejoraDataSql();

            List<PropuestaMejoraEntidad> oPropuestaMejoraColeccion = new List<PropuestaMejoraEntidad>();
            try
            {
                oPropuestaMejoraColeccion = iPropuestaMejora.ObtenerPropuestaMejoraAsignadasListadoPorFiltros(oPropuestaMejoraFiltro);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oPropuestaMejoraColeccion;
        }


        public PropuestaMejoraEntidad ObtenerPropuestaMejoraPorCodigo(int codigo)
        {
            iPropuestaMejora = new PropuestaMejoraDataSql();
            PropuestaMejoraEntidad oPropuestaMejora = new PropuestaMejoraEntidad();
            try
            {
                oPropuestaMejora = iPropuestaMejora.ObtenerPropuestaMejoraPorCodigo(codigo);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oPropuestaMejora;
        }

        public List<PropuestaMejoraEntidad> ObtenerPropuestaMejoraListadoParaSolucion()
        {
            iPropuestaMejora = new PropuestaMejoraDataSql();

            List<PropuestaMejoraEntidad> oPropuestaMejoraColeccion = new List<PropuestaMejoraEntidad>();
            try
            {

                oPropuestaMejoraColeccion = iPropuestaMejora.ObtenerPropuestaMejoraListadoPorEstado(Constantes.ESTADO_PROPUESTA_DESARROLLO);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oPropuestaMejoraColeccion;
        }

        #endregion

         #region "Insert"
         public void InsertarPropuestaMejora(PropuestaMejoraEntidad oPropuestaMejora)
         {
             iPropuestaMejora = new PropuestaMejoraDataSql();
             iIndicador = new IndicadorDataSql();
             PropuestaEstadoEntidad oPropuestaEstado = new PropuestaEstadoEntidad();
             
             oPropuestaMejora = iPropuestaMejora.InsertarPropuestaMejora(oPropuestaMejora);
             oPropuestaEstado.codigo_empleado = oPropuestaMejora.codigo_Responsable;
             oPropuestaEstado.codigo_propuesta = oPropuestaMejora.codigo_Propuesta;
             oPropuestaEstado.codigo_estado = oPropuestaMejora.codigo_Estado;
             oPropuestaEstado.observaciones = oPropuestaMejora.observaciones;

             iPropuestaMejora.InsertarPropuestaMejoraEstado(oPropuestaEstado);

             if (oPropuestaMejora.lstIndicadores != null)
             {
                 foreach (IndicadorEntidad oIndicador in oPropuestaMejora.lstIndicadores)
                 {
                     oIndicador.codigo_Propuesta = Convert.ToInt32(oPropuestaMejora.codigo_Propuesta);
                     iIndicador.InsertarPropuestaIndicador(oIndicador);
                 }
             }

         }
         #endregion

        #region "Update"

         public void ActualizarEstadoPropuestaMejora(PropuestaMejoraEntidad oPropuestaMejora)
         {
             iPropuestaMejora = new PropuestaMejoraDataSql();

             try
             {
                 iPropuestaMejora.ActualizarEstadoPropuestaMejora(oPropuestaMejora);
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }


         public void ActualizarPropuestaMejora(PropuestaMejoraEntidad oPropuestaMejora)
         {
             iPropuestaMejora = new PropuestaMejoraDataSql();
             iIndicador = new IndicadorDataSql();

             try
             {
                 iPropuestaMejora.ActualizarPropuestaMejora(oPropuestaMejora);

                 if (oPropuestaMejora.lstIndicadores != null)
                 {
                     iIndicador.EliminarIndicadorPorPropuesta(Convert.ToInt32(oPropuestaMejora.codigo_Propuesta));
                     foreach (IndicadorEntidad oIndicador in oPropuestaMejora.lstIndicadores)
                     {
                         oIndicador.codigo_Propuesta = Convert.ToInt32(oPropuestaMejora.codigo_Propuesta);
                         iIndicador.InsertarPropuestaIndicador(oIndicador);
                     }
                 }
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }


         public void BorrarPropuestaMejora(PropuestaMejoraEntidad oPropuestaMejora) 
         {
             iPropuestaMejora = new PropuestaMejoraDataSql();
             PropuestaEstadoEntidad oPropuestaEstado = new PropuestaEstadoEntidad();

             if (oPropuestaMejora.codigo_Estado == Convert.ToInt32(Constantes.ESTADO_PROPUESTA.REGISTRADA))
             {
                 oPropuestaMejora.codigo_Estado = Convert.ToInt32(Constantes.ESTADO_PROPUESTA.ELIMINADA);
                 ActualizarEstadoPropuestaMejora(oPropuestaMejora);
                 oPropuestaEstado.codigo_empleado = oPropuestaMejora.codigo_Responsable;
                 oPropuestaEstado.codigo_propuesta = oPropuestaMejora.codigo_Propuesta;
                 oPropuestaEstado.codigo_estado = oPropuestaMejora.codigo_Estado;
                 oPropuestaEstado.observaciones = oPropuestaMejora.observaciones;

                 iPropuestaMejora.InsertarPropuestaMejoraEstado(oPropuestaEstado);
             }
             else
             {
                 throw new BRuleException(Mensajes.Mensaje_No_Borrar_Propuesta_Mejora);
             }
         }

        #endregion

        
    }
}
