using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.MP.AccesoDatos.Interfaces
{
    public interface IUnidadData
    {
        #region "Select"

        List<UnidadEntidad> ObtenerListaUnidadTodas();

        #endregion
    }
}
