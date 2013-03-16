using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.AccesoDatos.Contrato;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Implementacion
{
    /// <summary>
    /// Implementacion  de la logica de negocios de la entidad orden de cambio.
    /// </summary>
    public class OrdenCambioLogica : IOrdenCambioLogica
    {
        private readonly IOrdenCambioData _ordenCambioData;

        public OrdenCambioLogica(IOrdenCambioData ordenCambioData)
        {
            _ordenCambioData = ordenCambioData;
        }

        /// <summary>
        /// Lista las ordenes de un proyecto
        /// </summary>
        /// <param name="codigoProyecto">Codigo proyecto</param>
        /// <param name="codigoLineaBase">Codigo linea Base</param>
        /// <returns>Lista Orden de cambio</returns>
        public List<OrdenCambio> ListarPorProyectoLBase(int codigoProyecto, int codigoLineaBase)
        {
            return _ordenCambioData.ListarPorProyectoLBase(codigoProyecto, codigoLineaBase);
        }
    }
}
