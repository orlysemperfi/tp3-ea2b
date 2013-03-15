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

        public List<PilotoEntidad> ObtenerPilotoAsignadasListadoPorFiltros(PilotoEntidad oPilotoFiltro)
        {
            iPiloto = new PilotoDataSql();

            List<PilotoEntidad> oPilotoColeccion = new List<PilotoEntidad>();
            try
            {
                oPilotoColeccion = iPiloto.ObtenerPilotoAsignadasListadoPorFiltros(oPilotoFiltro);

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

    }
}
