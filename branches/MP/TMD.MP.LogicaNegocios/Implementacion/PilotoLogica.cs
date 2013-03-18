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
    public class PilotoLogica : IPilotoLogica
    {
        public IPilotoData iPiloto;
        private static IPilotoLogica instance;
        private PilotoLogica() { }
        public static IPilotoLogica getInstance()
        {
            if (instance == null) {
                instance = new PilotoLogica();
            }
            return instance;
        }

        #region "Select"

        public List <PilotoEntidad> ObtenerPilotoListadoPorFiltros(PilotoEntidad oPilotoFiltro)
        {
            iPiloto = new PilotoDataSql();
            
            List <PilotoEntidad> oPilotoColeccion = new List <PilotoEntidad>();
            try
            {
                oPilotoColeccion = iPiloto.ObtenerPilotoListadoPorFiltros(oPilotoFiltro);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oPilotoColeccion;
        }

        public PilotoEntidad ObtenerPilotoPorCodigo(int codigo)
        {
            iPiloto = new PilotoDataSql();
            PilotoEntidad oPiloto = new PilotoEntidad();
            try
            {
                oPiloto = iPiloto.ObtenerPilotoPorCodigo(codigo);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oPiloto;
        }

        #endregion

        #region "Insert"
        public void InsertarPiloto(PilotoEntidad oPiloto)
        {
            iPiloto = new PilotoDataSql();
            PilotoEstadoEntidad oPilotoEstado = new PilotoEstadoEntidad();

            oPiloto = iPiloto.InsertarPiloto(oPiloto);
            oPilotoEstado.codigo_piloto = oPiloto.codigo;
            oPilotoEstado.codigo_estado = oPiloto.codigo_Estado;

            iPiloto.InsertarPilotoEstado(oPilotoEstado);


        }
        #endregion

        #region "Update"


        public void ActualizarPiloto(PilotoEntidad oPiloto)
        {
            iPiloto = new PilotoDataSql();

            try
            {
                iPiloto.ActualizarPiloto(oPiloto);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ActualizarEstadoPiloto(PilotoEntidad oPiloto)
        {
            iPiloto = new PilotoDataSql();

            try
            {
                iPiloto.ActualizarEstadoPiloto(oPiloto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String BorrarPiloto(PilotoEntidad oPiloto)
        {
            iPiloto = new PilotoDataSql();
            PilotoEstadoEntidad oPilotoEstado = new PilotoEstadoEntidad();

            if (oPiloto.codigo_Estado == Convert.ToInt32(Constantes.ESTADO_SOLUCION.GENERADA))
            {
                oPiloto.codigo_Estado = Convert.ToInt32(Constantes.ESTADO_SOLUCION.ELIMINADA);
                ActualizarEstadoPiloto(oPiloto);
                oPilotoEstado.codigo_piloto = oPiloto.codigo;
                oPilotoEstado.codigo_estado = oPiloto.codigo_Estado;

                iPiloto.InsertarPilotoEstado(oPilotoEstado);

                return null;
            }
            else
            {
                return Mensajes.Mensaje_No_Borrar_Piloto;
            }
        }

        #endregion
    }
}
