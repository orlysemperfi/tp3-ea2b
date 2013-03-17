using System.Collections.Generic;
using System.Transactions;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.AccesoDatos.Contrato;
using TMD.Entidades;
using TMD.CF.LogicaNegocios.Error;
using System;
using TMD.Core;

namespace TMD.CF.LogicaNegocios.Implementacion
{
    /// <summary>
    /// Implementacion  de la logica de negocios de la entidad solicitud de cambio.
    /// </summary>
    public class SolicitudCambioLogica: ISolicitudCambioLogica
    {

        private readonly ISolicitudCambioData _solicitudCambioData;

        public SolicitudCambioLogica(ISolicitudCambioData solicitudCambioData)
        {
            _solicitudCambioData = solicitudCambioData;
        }

        /// <summary>
        /// Agrega una solicitud de cambio
        /// </summary>
        /// <param name="informeCambio">Objeto Solicitud a agregar</param>
        public void Agregar(SolicitudCambio solicitudCambio)
        {
            _solicitudCambioData.Agregar(solicitudCambio);
        }

        /// <summary>
        /// Aprueba una solicitud de cambio
        /// </summary>
        /// <param name="informeCambio">Objeto Solicitud a aprobar</param>
        public void Aprobar(SolicitudCambio solicitudCambio)
        {
            _solicitudCambioData.Aprobar(solicitudCambio);
        }

        /// <summary>
        /// Lista las solicitudes por proyecto
        /// </summary>
        /// <param name="solicitudCambio">Objeto solicitud de cambio</param>
        /// <returns>Lista de solicitudes</returns>
        public List<SolicitudCambio> ListarPorProyectoLineaBase(SolicitudCambio solicitudCambio)
        {
            return _solicitudCambioData.ListarPorProyectoLineaBase(solicitudCambio);
        }

        /// <summary>
        /// Obtiene una solicitud por el Id
        /// </summary>
        /// <param name="id">Id de la solicitud</param>
        /// <returns>Objetp Solicitud de cambio</returns>
        public SolicitudCambio ObtenerPorId(int id)
        {
            return _solicitudCambioData.ObtenerPorId(id);
        }

        /// <summary>
        /// Obtiene el archivo de la solicitud de cambio
        /// </summary>
        /// <param name="id">Id de la solicitud</param>
        /// <returns>Archivo de la solicitud</returns>
        public SolicitudCambio ObtenerArchivo(int id)
        {
            SolicitudCambio solicitudCambio = null;

            using (var scope = new TransactionScope())
            {
                solicitudCambio = _solicitudCambioData.ObtenerArchivo(id);
                scope.Complete();
            }

            return solicitudCambio;
        }

        /// <summary>
        /// Actualiza el archivo de una solicitud
        /// </summary>
        /// <param name="solicitudCambio">Objeto solicutd a actualziar</param>
        public void ActualizarArchivo(SolicitudCambio solicitudCambio)
        {
            using (var scope = new TransactionScope())
            {
                _solicitudCambioData.ActualizarArchivo(solicitudCambio);
                scope.Complete();
            }
        }
    }
}
