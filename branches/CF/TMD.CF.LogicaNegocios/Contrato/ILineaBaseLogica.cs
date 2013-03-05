using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Contrato
{
    /// <summary>
    /// Contrato  de la Logica de Negocios de la entidad Linea Base.
    /// </summary>
    public interface ILineaBaseLogica
    {
        /// <summary>
        /// Agrega un registro a la tabla LineaBase.
        /// </summary>
        /// <param name="lineaBase">LineaBase</param>
        void Agregar(LineaBase lineaBase);

        /// <summary>
        /// Lista las lineas base de una fase de un proyecto.
        /// </summary>
        /// <param name="proyectoFase">ProyectoFase</param>
        /// <returns>Lista LineaBase</returns>
        List<LineaBase> ListarPorProyecto(Proyecto proyecto, Usuario usuario = null);

        /// <summary>
        /// Obtiene una Linea Base por el Codigo Proyecto Fase
        /// </summary>
        /// <param name="proyectoFase">Objeto ProyectoFase</param>
        /// <returns>Objeto LineaBase</returns>
        LineaBase ObtenerPorProyectoFase(ProyectoFase proyectoFase, Usuario usuario = null);

        /// <summary>
        /// Actualiza una Linea Base
        /// </summary>
        /// <param name="lineaBase">Objeto LineaBase</param>
        void Actualizar(LineaBase lineaBase);

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
    }
}
