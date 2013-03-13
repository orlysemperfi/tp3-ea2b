using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Contrato
{
    /// <summary>
    /// Contrato  de la logica d enegocios de la entidad orden de cambio.
    /// </summary>
    public interface IOrdenCambioLogica
    {
        /// <summary>
        /// Lista las ordenes de un proyecto
        /// </summary>
        /// <param name="codigoProyecto">Codigo proyecto</param>
        /// <param name="codigoLineaBase">Codigo linea Base</param>
        /// <returns>Lista Orden de cambio</returns>
        List<OrdenCambio> ListarPorProyectoLBase(int codigoProyecto, int codigoLineaBase);
    }
}
