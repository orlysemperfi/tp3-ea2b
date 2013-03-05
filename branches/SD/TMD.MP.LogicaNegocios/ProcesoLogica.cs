using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.MP.AccesoDatos.Interfaces;
using TMD.MP.AccesoDatos.Metodos;
using TMD.Entidades;

namespace TMD.MP.LogicaNegocios
{
    public class ProcesoLogica
    {
        public IProcesoData iProceso;

        #region "Select"

        public List<ProcesoEntidad> ObtenerListaProcesoTodas()
        {
            iProceso = new ProcesoDataSql();
            return iProceso.ObtenerListaProcesoTodas();
        }

        #endregion
    }
}
