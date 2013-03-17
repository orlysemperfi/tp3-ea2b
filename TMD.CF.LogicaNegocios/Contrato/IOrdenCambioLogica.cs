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

        /// <summary>
        /// Agrega una orden de cambio
        /// </summary>
        /// <param name="ordenCambio">Objeto Orden a agregar</param>
        void Agregar(OrdenCambio ordenCambio);

        /// <summary>
        /// Obtiene una orden por el Id
        /// </summary>
        /// <param name="id">Id de la orden</param>
        /// <returns>Objeto orden de cambio</returns>
        OrdenCambio ObtenerPorId(int id);
        
        /// <summary>
        /// Obtiene una orden por Informe
        /// </summary>
        /// <param name="id">Id del informe</param>
        /// <returns>Objeto orden de cambio</returns>
        OrdenCambio ObtenerPorInforme(int id);

        /// <summary>
        /// Obtiene el archivo de la orden de cambio
        /// </summary>
        /// <param name="id">Id de la orden</param>
        /// <returns>Archivo de la orden</returns>
        OrdenCambio ObtenerArchivo(int id);

        /// <summary>
        /// Actualiza el archivo de una orden
        /// </summary>
        /// <param name="solicitudCambio">Objeto orden a actualziar</param>
        void ActualizarArchivo(OrdenCambio ordenCambio);
    }
}
