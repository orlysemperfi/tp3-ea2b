using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.MP.AccesoDatos.Contrato;
using TMD.MP.AccesoDatos.Implementacion;
using TMD.Entidades;
using TMD.MP.LogicaNegocios.Contrato;

namespace TMD.MP.LogicaNegocios.Implementacion
{
    public class ProcesoLogica: IProcesoLogica
    {
        private IProcesoData iProceso;
        private static IProcesoLogica instance;
        private ProcesoLogica() { }
        public static IProcesoLogica getInstance()
        {
            if (instance == null) {
                instance = new ProcesoLogica();
            }
            return instance;
        }

        #region "Select"

        public List<ProcesoEntidad> ObtenerListaProcesoTodas()
        {
            iProceso = new ProcesoDataSql();
            return iProceso.ObtenerListaProcesoTodas();
        }

        #endregion
    }
}
