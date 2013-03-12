using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.LogicaNegocios.Implementacion;
using TMD.CF.AccesoDatos.Implementacion;
using TMD.Entidades;

namespace TMD.CF.Site.Controladora.CF
{
    class OrdenCambioControladora : Base
    {
        private static readonly IOrdenCambioLogica _ordenCambioLogica = new OrdenCambioLogica(new OrdenCambioData(BaseDatos));

        public static List<OrdenCambio> ListarPorProyectoLBase(int codigoProyecto, int codigoLineaBase)
        {
            return _ordenCambioLogica.ListarPorProyectoLBase(codigoProyecto,codigoLineaBase);
        }
    }
}