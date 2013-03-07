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
    
    public class AreaLogica: IAreaLogica
    {
        public IAreaData iArea;
        private static IAreaLogica instance;
        private AreaLogica() { }
        public static IAreaLogica getInstance(){
            if (instance == null) {
                instance = new AreaLogica();
            }
            return instance;
        }

        

        #region "Select"

        public List<AreaEntidad> ObtenerListaAreaTodas()
        {
            iArea = new AreaDataSql();
            return iArea.ObtenerListaAreaTodas();
        }

        #endregion
    }
}
