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


         public String BorrarPropuestaMejora(PropuestaMejoraEntidad oPropuestaMejora)
         {
             iPropuestaMejora = new PropuestaMejoraDataSql();

             if (oPropuestaMejora.nombre_Estado == Constantes.ESTADO_PROPUESTA_REGISTRADA)
             {
                 oPropuestaMejora.nombre_Estado = Constantes.ESTADO_PROPUESTA_ELIMINADA;
                 ActualizarEstadoPropuestaMejora(oPropuestaMejora);
                 return null;
             }
             else
             {
                 return Mensajes.Mensaje_No_Borrar_Propuesta_Mejora;
             }
         }

        #endregion

        #region "Insert"
        public void InsertarPropuestaMejora(PropuestaMejoraEntidad oPropuestaMejora) {
             iPropuestaMejora = new PropuestaMejoraDataSql();
             iIndicador = new IndicadorDataSql();
             iEscalaCuantitativo = new EscalaCuantitativoDataSql();
             iEscalaCualitativo = new EscalaCualitativoDataSql();
             iPropuestaMejora.InsertarPropuestaMejora(oPropuestaMejora);

             if (oPropuestaMejora.lstIndicadores != null)
             {

                 foreach (IndicadorEntidad oIndicador in oPropuestaMejora.lstIndicadores)
                 {
                     iIndicador.InsertarPropuestaIndicador(oIndicador);
                     //Cualitativo
                     //if (indicador.tipo == 0)
                     //{
                     //    if (indicador.lstEscalaCualitativo != null)
                     //    {
                     //        foreach (EscalaCualitativoEntidad escalaCualitativo in indicador.lstEscalaCualitativo)
                     //        {
                     //            iEscalaCualitativo.InsertarEscalaCualitativo(escalaCualitativo);
                     //        }
                     //    }
                     //}
                     ////Cuantitativo
                     //if (indicador.tipo == 1)
                     //{
                     //    if (indicador.lstEscalaCuantitativo != null)
                     //    {
                     //        foreach (EscalaCuantitativoEntidad escalaCuantitativo in indicador.lstEscalaCuantitativo)
                     //        {
                     //            iEscalaCuantitativo.InsertarEscalaCuantitativo(escalaCuantitativo);
                     //        }
                     //    }

                     //}
                 }
             }
             
        }
        #endregion

        #region "Actualizar"
        //void ActualizarPropuestaMejora(PropuestaMejoraEntidad entidad) {
        //    iPropuestaMejora = new PropuestaMejoraDataSql();
        //    iIndicador = new IndicadorDataSql();
        //    iEscalaCuantitativo = new EscalaCuantitativoDataSql();
        //    iEscalaCualitativo = new EscalaCualitativoDataSql();
        //    iPropuestaMejora.ActualizarPropuestaMejora(entidad);
        //    foreach (IndicadorEntidad indicador in entidad.lstIndicadores)
        //    {
        //        //0:Insertar , 1 :Actualizar
                
        //        if (indicador.action == 0)
        //        {
        //            iIndicador.InsertarIndicador(indicador);
        //        }

        //        if (indicador.action == 1)
        //        {
        //            iIndicador.ActualizarIndicador(indicador);
        //        }
                
        //        //Cualitativo
        //        if (indicador.tipo == 0)
        //        {
        //            foreach (EscalaCualitativoEntidad escalaCualitativo in indicador.lstEscalaCualitativo)
        //            {
        //                if (escalaCualitativo.action == 0)
        //                {
        //                    iEscalaCualitativo.InsertarEscalaCualitativo(escalaCualitativo);
        //                }
        //                if (escalaCualitativo.action == 1)
        //                {
        //                    iEscalaCualitativo.ActualizarEscalaCualitativo(escalaCualitativo);
        //                }                        
        //            }
        //        }
        //        //Cuantitativo
        //        if (indicador.tipo == 1)
        //        {
        //            foreach (EscalaCuantitativoEntidad escalaCuantitativo in indicador.lstEscalaCuantitativo)
        //            {
        //                if (escalaCuantitativo.action==0)
        //                {
        //                    iEscalaCuantitativo.InsertarEscalaCuantitativo(escalaCuantitativo);
        //                }

        //                if (escalaCuantitativo.action == 1)
        //                {
        //                    iEscalaCuantitativo.ActualizarEscalaCuantitativo(escalaCuantitativo);
        //                }
        //            }
        //        }
        //    }        
        //}
        #endregion
    }
}
