using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Contrato
{
    public interface IInformeCambioLogica
    {
        /// <summary>
        /// Contrato  de la Logica de Negocios de la entidad Informe de Cambio.
        /// </summary>
        /// <param name="informeCambio"></param>
        void Agregar(InformeCambio informeCambio);
        void Aprobar(InformeCambio informeCambio);
        List<InformeCambio> ListarPorProyectoLineaBase(InformeCambio informeCambio);
        InformeCambio ObtenerPorId(int id);

        /// <summary>
        /// Obtiene el archivo de un informe de cambio
        /// </summary>
        /// <param name="id">Id de la solicitud</param>
        /// <returns>Archivo de la solicitud</returns>
        InformeCambio ObtenerArchivo(int id);

        /// <summary>
        /// Actualiza el archivo de un informe de cambio
        /// </summary>
        /// <param name="solicitudCambio">Objeto solicutd a actualziar</param>
        void ActualizarArchivo(InformeCambio informeCambio);
    }
}
