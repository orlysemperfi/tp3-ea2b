using System.Collections.Generic;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Contrato
{
    /// <summary>
    /// Contrato  de la logica de negocios de la entidad solicitud de cambio.
    /// </summary>
    public interface ISolicitudCambioLogica
    {
        /// <summary>
        /// Agrega una solicitud de cambio
        /// </summary>
        /// <param name="informeCambio">Objeto Solicitud a agregar</param>
        void Agregar(SolicitudCambio solicitudCambio);

        /// <summary>
        /// Aprueba una solicitud de cambio
        /// </summary>
        /// <param name="informeCambio">Objeto Solicitud a aprobar</param>
        void Aprobar(SolicitudCambio solicitudCambio);

        /// <summary>
        /// Lista las solicitudes por proyecto
        /// </summary>
        /// <param name="solicitudCambio">Objeto solicitud de cambio</param>
        /// <returns>Lista de solicitudes</returns>
        List<SolicitudCambio> ListarPorProyectoLineaBase(SolicitudCambio solicitudCambio);

        /// <summary>
        /// Obtiene una solicitud por el Id
        /// </summary>
        /// <param name="id">Id de la solicitud</param>
        /// <returns>Objetp Solicitud de cambio</returns>
        SolicitudCambio ObtenerPorId(int id);

        /// <summary>
        /// Obtiene el archivo de la solicitud de cambio
        /// </summary>
        /// <param name="id">Id de la solicitud</param>
        /// <returns>Archivo de la solicitud</returns>
        SolicitudCambio ObtenerArchivo(int id);

        /// <summary>
        /// Actualiza el archivo de una solicitud
        /// </summary>
        /// <param name="solicitudCambio">Objeto solicutd a actualziar</param>
        void ActualizarArchivo(SolicitudCambio solicitudCambio);
    }
}
