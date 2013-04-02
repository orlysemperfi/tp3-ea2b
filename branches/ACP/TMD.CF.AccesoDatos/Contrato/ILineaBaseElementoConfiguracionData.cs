using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.AccesoDatos.Contrato
{
    /// <summary>
    /// Contrato  del Acceso a datos de la entidad Linea Base .
    /// </summary>
    public interface ILineaBaseElementoConfiguracionData
    {
        /// <summary>
        /// Agrega un registro a la tabla Elemento de Configuracion Linea Base.
        /// </summary>
        /// <param name="elemento">ElementoConfiguracion</param>
        void Agregar(LineaBaseElementoConfiguracion elemento);

        /// <summary>
        /// Recupera la lista de detalle de una linea base
        /// </summary>
        /// <param name="lineaBase">Objeto Linea Base</param>
        /// <returns>List LineaBaseElementoConfiguracion</returns>
        List<LineaBaseElementoConfiguracion> ListaPorLineaBase(LineaBase lineaBase, Usuario usuario = null);

        /// <summary>
        /// Elimina el detalle de una Linea Base
        /// </summary>
        /// <param name="lineaBase">Objeto Linea Base</param>
        void Eliminar(LineaBase lineaBase);

        /// <summary>
        /// Actualiza el archivo de un Elemento de Configuracion
        /// </summary>
        /// <param name="elemento">Objeto LineaBaseElementoConfiguracion</param>
        void ActualizarArchivo(LineaBaseElementoConfiguracion elemento);

        /// <summary>
        /// Recupera un archivo de un Elemento de Configuracion
        /// </summary>
        /// <param name="id">Id del elemento de configuracion</param>
        /// <returns>LineaBaseElementoConfiguracion</returns>
        LineaBaseElementoConfiguracion ObtenerArchivo(int id);

        /// <summary>
        /// Recupera un Elemento de Configuracion
        /// </summary>
        /// <param name="id">Id del elemento de configuracion</param>
        /// <returns>LineaBaseElementoConfiguracion</returns>
        LineaBaseElementoConfiguracion ObtenerPorId(int id);
    }
}
