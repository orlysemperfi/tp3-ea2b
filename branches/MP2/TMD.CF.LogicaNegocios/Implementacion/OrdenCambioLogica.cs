using System;
using System.Collections.Generic;
using System.Transactions;
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

        /// <summary>
        /// Agrega una orden de cambio
        /// </summary>
        /// <param name="ordenCambio">Objeto Orden a agregar</param>
        public void Agregar(OrdenCambio ordenCambio)
        {
            _ordenCambioData.Agregar(ordenCambio);
        }

        /// <summary>
        /// Obtiene una orden por el Id
        /// </summary>
        /// <param name="id">Id de la orden</param>
        /// <returns>Objeto orden de cambio</returns>
        public OrdenCambio ObtenerPorId(int id)
        {
            return _ordenCambioData.ObtenerPorId(id);
        }

        /// <summary>
        /// Obtiene una orden por informe
        /// </summary>
        /// <param name="id">Id de informe</param>
        /// <returns>Objeto orden de cambio</returns>
        public OrdenCambio ObtenerPorInforme(int id)
        {
            return _ordenCambioData.ObtenerPorInforme(id);
        }

        /// <summary>
        /// Obtiene el archivo de la orden de cambio
        /// </summary>
        /// <param name="id">Id de la orden</param>
        /// <returns>Archivo de la orden</returns>
        public OrdenCambio ObtenerArchivo(int id)
        {
            OrdenCambio ordenCambio = null;

            using (var scope = new TransactionScope())
            {
                ordenCambio = _ordenCambioData.ObtenerArchivo(id);
                scope.Complete();
            }

            return ordenCambio;
        }

        /// <summary>
        /// Actualiza el archivo de una orden
        /// </summary>
        /// <param name="ordenCambio">Objeto orden a actualziar</param>
        public void ActualizarArchivo(OrdenCambio ordenCambio)
        {
            using (var scope = new TransactionScope())
            {
                _ordenCambioData.ActualizarArchivo(ordenCambio);
                scope.Complete();
            }
        }
    }
}
