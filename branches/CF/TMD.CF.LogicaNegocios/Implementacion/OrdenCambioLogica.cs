using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.AccesoDatos.Contrato;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Implementacion
{
    public class OrdenCambioLogica : IOrdenCambioLogica
    {
        private readonly IOrdenCambioData _ordenCambioData;

        public OrdenCambioLogica(IOrdenCambioData ordenCambioData)
        {
            _ordenCambioData = ordenCambioData;
        }

        public List<OrdenCambio> ListarPorProyectoLBase(int codigoProyecto, int codigoLineaBase)
        {
            return _ordenCambioData.ListarPorProyectoLBase(codigoProyecto, codigoLineaBase);
        }
    }
}
