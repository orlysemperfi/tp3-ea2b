using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.MP.AccesoDatos.Interfaces
{
    public interface IAreaData
    {
        #region "Select"

        List<AreaEntidad> ObtenerListaAreaTodas();

        #endregion
    }
}
