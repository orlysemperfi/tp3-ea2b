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
    public class UnidadLogica: IUnidadLogica
    {
        public IUnidadData iUnidad;
        private static IUnidadLogica instance;
        private UnidadLogica() { }
        public static IUnidadLogica getInstance()
        {
            if (instance == null) {
                instance = new UnidadLogica();
            }
            return instance;
        }

        #region "Select"

        public List<UnidadEntidad> ObtenerListaUnidadTodas() {
            iUnidad = new UnidadDataSql();
            return iUnidad.ObtenerListaUnidadTodas();
        }

        #endregion
    }
}
