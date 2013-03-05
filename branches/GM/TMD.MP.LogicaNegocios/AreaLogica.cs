using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.MP.AccesoDatos.Interfaces;
using TMD.MP.AccesoDatos.Metodos;
using TMD.Entidades;

namespace TMD.MP.LogicaNegocios
{
    public class AreaLogica
    {
        public IAreaData iArea;

        #region "Select"

        public List<AreaEntidad> ObtenerListaAreaTodas()
        {
            iArea = new AreaDataSql();
            return iArea.ObtenerListaAreaTodas();
        }

        #endregion
    }
}
