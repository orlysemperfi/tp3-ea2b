using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.AccesoDatos.Contrato
{
    /// <summary>
    /// Contrato  del Acceso a datos de la entidad informe de cambio.
    /// </summary>
    public interface IInformeCambioData
    {
        /// <summary>
        /// Agrega un informe de cambio
        /// </summary>
        /// <param name="informeCambio">Objeto informe a agregar</param>
        void Agregar(InformeCambio informeCambio);

        /// <summary>
        /// Aprueba un informe de cambio
        /// </summary>
        /// <param name="informeCambio">Objeto informe a aprobar</param>
        void Aprobar(InformeCambio informeCambio);

        /// <summary>
        /// Lista los informes de una linea base
        /// </summary>
        /// <param name="informeCambio">Linea Base</param>
        /// <returns>Lista informes de cambio</returns>
        List<InformeCambio> ListarPorProyectoLineaBase(InformeCambio informeCambio);

        /// <summary>
        /// Obtiene un informe de cambio por el id
        /// </summary>
        /// <param name="id">Id informe</param>
        /// <returns>Informe de cambio</returns>
        InformeCambio ObtenerPorId(int id);
    }
}
