using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.AccesoDatos.Contrato
{
    /// <summary>
    /// Contrato  del Acceso a datos de la entidad orden de cambio.
    /// </summary>
    public interface IOrdenCambioData
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
