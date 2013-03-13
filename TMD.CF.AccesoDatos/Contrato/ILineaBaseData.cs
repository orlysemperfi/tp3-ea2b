using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.AccesoDatos.Contrato
{
    /// <summary>
    /// Contrato  del Acceso a datos de la entidad Linea Base.
    /// </summary>
    public interface ILineaBaseData
    {
        /// <summary>
        /// Agrega un registro a la tabla LineaBase.
        /// </summary>
        /// <param name="lineaBase">LineaBase</param>
        void Agregar(LineaBase lineaBase, UsuarioProyecto usuarioProyecto);

        /// <summary>
        /// Actauliza un registro de la Tabla Linea Base
        /// </summary>
        /// <param name="lineaBase">LineaBase</param>
        void Actualizar(LineaBase lineaBase);

        /// <summary>
        /// Lista las lineas base de una fase de un proyecto.
        /// </summary>
        /// <param name="proyecto">Objeto Proyecto</param>
        /// <returns>List LineaBase</returns>
        List<LineaBase> ListarPorProyecto(Proyecto proyecto, Usuario usuario = null);

        /// <summary>
        /// Obtiene una Linea Base por el Codigo Proyecto Fase
        /// </summary>
        /// <param name="proyectoFase">Objeto ProyectoFase</param>
        /// <returns>Objeto LineaBase</returns>
        LineaBase ObtenerPorProyectoFase(ProyectoFase proyectoFase);


        /// <summary>
        /// Obtiene una linea base por el Id
        /// </summary>
        /// <param name="id">Id Linea base</param>
        /// <returns>Objeto Linea Base</returns>
        LineaBase ObtenerPorid(int id);
    }
}
