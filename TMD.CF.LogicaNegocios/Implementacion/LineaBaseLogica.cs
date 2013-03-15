using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.AccesoDatos.Contrato;
using TMD.Entidades;
using System.Transactions;
using TMD.CF.LogicaNegocios.Error;
using TMD.Core;

namespace TMD.CF.LogicaNegocios.Implementacion
{
    /// <summary>
    /// Implementa  la Logica de Negocios de la entidad Linea Base.
    /// </summary>
    public class LineaBaseLogica : ILineaBaseLogica
    {
        private readonly ILineaBaseData _lineaBaseData;
        private readonly ILineaBaseElementoConfiguracionData _lineaBaseECSData;
        private readonly IUsuarioProyectoData _usuarioProyectoData;
        private readonly IProyectoFaseData _proyectoFaseData;

        public LineaBaseLogica(ILineaBaseData lineaBaseData, ILineaBaseElementoConfiguracionData lineaBaseECSData,
            IUsuarioProyectoData usuarioProyectoData, IProyectoFaseData proyectoFaseData)
        {
            _lineaBaseData = lineaBaseData;
            _lineaBaseECSData = lineaBaseECSData;
            _usuarioProyectoData = usuarioProyectoData;
            _proyectoFaseData = proyectoFaseData;
        }

        /// <summary>
        /// Agrega un registro a la tabla LineaBase.
        /// </summary>
        /// <param name="lineaBase">LineaBase</param>
        public void Agregar(LineaBase lineaBase, UsuarioProyecto usuarioProyecto)
        {
            ProyectoFase proyectoFase = _proyectoFaseData.ObtenerPorFaseProyecto(lineaBase.ProyectoFase);

            if (lineaBase.LineaBaseECS == null || lineaBase.LineaBaseECS.Count() == 0)
            {
                //TODO: La Linea base debe tener asociado por lo menos un elemento de configuracion.
                throw new ReglaNegocioException("La Linea base debe tener asociado por lo menos un elemento de configuracion.");
            }
            else if (proyectoFase == null)
            {
                //TODO: El codigo del proyecto y/o fase deben existir.
                throw new ReglaNegocioException("El codigo del proyecto y/o fase deben existir.");

            }
            else if (proyectoFase.Proyecto.FechaFin < DateTime.Now)
            {
                //TODO: Solo se puede crear una linea base para un proyecto que no haya finalizado.
                throw new ReglaNegocioException("Solo se puede crear una linea base para un proyecto que no haya finalizado.");
            }
            else if (proyectoFase.FechaFin < DateTime.Now)
            {
                //TODO: Solo se puede crear una linea base para una fase que no haya finalizado.
                throw new ReglaNegocioException("Solo se puede crear una linea base para una fase que no haya finalizado.");

            }
            else if (_lineaBaseData.ObtenerPorProyectoFase(lineaBase.ProyectoFase) != null)
            {
                //TODO: Solo se peude crear una linea base para una fase de un proyecto.
                throw new ReglaNegocioException("Solo se peude crear una linea base para una fase de un proyecto.");
            }
            else if (lineaBase.LineaBaseECS.Where(x => x.Responsable.Id == 0).Count() > 0)
            {
                //TODO: Todos los elementos de configuracion deben tener asignado a un responsable.
                throw new ReglaNegocioException(
                    "Todos los elementos de configuracion deben tener asignado a un responsable.");
            }
            using (var scope = new TransactionScope())
            {
                List<UsuarioProyecto> listaUsuarioProyecto = new List<UsuarioProyecto>();
                _lineaBaseData.Agregar(lineaBase, usuarioProyecto);
                lineaBase.LineaBaseECS.ForEach(ecs => _lineaBaseECSData.Agregar(ecs));

                scope.Complete();
            }            
        }

        /// <summary>
        /// Lista las lineas base de una fase de un proyecto.
        /// </summary>
        /// <param name="proyectoFase">ProyectoFase</param>
        /// <returns>Lista LineaBase</returns>
        public List<LineaBase> ListarPorProyecto(Proyecto proyecto, Usuario usuario = null)
        {
            return _lineaBaseData.ListarPorProyecto(proyecto, usuario);
        }

        /// <summary>
        /// Obtiene una Linea Base por el Codigo Proyecto Fase
        /// </summary>
        /// <param name="proyectoFase">Objeto ProyectoFase</param>
        /// <returns>Objeto LineaBase</returns>
        public LineaBase ObtenerPorProyectoFase(ProyectoFase proyectoFase, Usuario usuario = null)
        {
            LineaBase lineaBase = _lineaBaseData.ObtenerPorProyectoFase(proyectoFase);
            lineaBase.LineaBaseECS = _lineaBaseECSData.ListaPorLineaBase(lineaBase,usuario);

            return lineaBase;
        }

        /// <summary>
        /// Actualiza una Linea Base
        /// </summary>
        /// <param name="lineaBase">Objeto LineaBase</param>
        public void Actualizar(LineaBase lineaBase)
        {
            LineaBase lineaBaseCreada = _lineaBaseData.ObtenerPorid(lineaBase.Id);
            if (lineaBaseCreada == null)
            {
                //TODO: Solo se peuden actualizar lineas base que existan en BD.
                throw new ReglaNegocioException("Solo se peude actualizar lineas base que existan en BD.");
            }
            else if (!lineaBaseCreada.Estado.Equals(Constantes.EstadoLineaBaseAbierta.ToString()))
            {
                //TODO: Solo se peude actualizar cuando la linea base se encuentra en estado abierta.
                throw new ReglaNegocioException("Solo se peude actualizar cuando la linea base se encuentra en estado abierta.");
            }
            else if (lineaBase.LineaBaseECS == null || lineaBase.LineaBaseECS.Count() == 0)
            {
                //TODO: La Linea base debe tener asociado por lo menos un elemento de configuracion.
                throw new ReglaNegocioException(
                    "La Linea base debe tener asociado por lo menos un elemento de configuracion.");
            }
            else if (lineaBase.LineaBaseECS.Where(x => x.Responsable.Id == 0).Count() > 0)
            {
                //TODO: Todos los elementos de configuracion deben tener asignado a un responsable.
                throw new ReglaNegocioException(
                    "Todos los elementos de configuracion deben tener asignado a un responsable.");
            }

            using (var scope = new TransactionScope())
            {
                _lineaBaseData.Actualizar(lineaBase);

                _lineaBaseECSData.Eliminar(lineaBase);
                lineaBase.LineaBaseECS.ForEach(ecs => _lineaBaseECSData.Agregar(ecs));

                scope.Complete();
            }   
        }

        /// <summary>
        /// Actualiza el archivo de un Elemento de Configuracion
        /// </summary>
        /// <param name="elemento">Objeto LineaBaseElementoConfiguracion</param>
        public void ActualizarArchivo(LineaBaseElementoConfiguracion elemento)
        {
            LineaBaseElementoConfiguracion elementoCreado = _lineaBaseECSData.ObtenerPorId(elemento.Id);
            if (elementoCreado.LineaBase.ProyectoFase.FechaFin < DateTime.Now)
            {
                //TODO: Solo se puede modificar el archivo de una linea base para un proyecto que no haya finalizado.
                throw new ReglaNegocioException("Solo se puede modificar el archivo de una linea base para un proyecto que no haya finalizado.");
            }

            using (var scope=new TransactionScope())
            {
                _lineaBaseECSData.ActualizarArchivo(elemento);

                scope.Complete();
            }
        }

        /// <summary>
        /// Recupera un archivo de un Elemento de Configuracion
        /// </summary>
        /// <param name="id">Id del elemento de configuracion</param>
        /// <returns>byte[]</returns>
        public LineaBaseElementoConfiguracion ObtenerArchivo(int id)
        {
            LineaBaseElementoConfiguracion elementoConfiguracion = null;

            using (var scope = new TransactionScope())
            {
                elementoConfiguracion = _lineaBaseECSData.ObtenerArchivo(id);
                scope.Complete();
                
            }

            return elementoConfiguracion;
        }
    }
}
