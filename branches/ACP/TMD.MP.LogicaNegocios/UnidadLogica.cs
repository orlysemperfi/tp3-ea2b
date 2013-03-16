using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.MP.AccesoDatos.Interfaces;
using TMD.MP.AccesoDatos.Metodos;
using TMD.Entidades;

namespace TMD.MP.LogicaNegocios
{
    public class UnidadLogica
    {
        public IUnidadData iUnidad;

        #region "Select"

        public List<UnidadEntidad> SeleccionarUnidadTodas() {
            iUnidad = new UnidadDataSql();
            return iUnidad.ObtenerListaUnidadTodas();
        }

        #endregion
    }
}
