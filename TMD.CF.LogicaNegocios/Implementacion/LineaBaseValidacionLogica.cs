using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.Entidades;
using TMD.CF.LogicaNegocios.Error;
using TMD.Core;
using TMD.CF.AccesoDatos.Contrato;

namespace TMD.CF.LogicaNegocios.Implementacion
{
    public class LineaBaseValidacionLogica : ILineaBaseLogica
    {
        private readonly ILineaBaseLogica _lineaBaseLogica;
        private readonly ILineaBaseData _lineaBaseData;
        private readonly ILineaBaseElementoConfiguracionData _lineaBaseECSData;
        private readonly IProyectoFaseData _proyectoFaseData;

        public LineaBaseValidacionLogica(ILineaBaseLogica lineaBaseLogica, ILineaBaseData lineaBaseData,
            ILineaBaseElementoConfiguracionData lineaBaseECSData, IProyectoFaseData proyectoFaseData)
        {
            _lineaBaseLogica = lineaBaseLogica;
            _lineaBaseData = lineaBaseData;
            _lineaBaseECSData = lineaBaseECSData;
            _proyectoFaseData = proyectoFaseData;
        }

        public void Agregar(Entidades.LineaBase lineaBase, Entidades.UsuarioProyecto usuarioProyecto)
        {
            ProyectoFase proyectoFase = _proyectoFaseData.ObtenerPorFaseProyecto(lineaBase.ProyectoFase);

            if (lineaBase.LineaBaseECS == null || lineaBase.LineaBaseECS.Count() == 0)
            {
                //REGLA: La Linea base debe tener asociado por lo menos un elemento de configuracion.
                throw new ReglaNegocioException("La Linea base debe tener asociado por lo menos un elemento de configuracion.");
            }
            else if (proyectoFase == null)
            {
                //REGLA: El codigo del proyecto y/o fase deben existir.
                throw new ReglaNegocioException("El codigo del proyecto y/o fase deben existir.");

            }
            else if (proyectoFase.Proyecto.FechaFin < DateTime.Now)
            {
                //REGLA: Solo se puede crear una linea base para un proyecto que no haya finalizado.
                throw new ReglaNegocioException("Solo se puede crear una linea base para un proyecto que no haya finalizado.");
            }
            else if (proyectoFase.FechaFin < DateTime.Now)
            {
                //REGLA: Solo se puede crear una linea base para una fase que no haya finalizado.
                throw new ReglaNegocioException("Solo se puede crear una linea base para una fase que no haya finalizado.");
            }
            else if (_lineaBaseData.ObtenerPorProyectoFase(lineaBase.ProyectoFase) != null)
            {
                //REGLA: Solo se peude crear una linea base para una fase de un proyecto.
                throw new ReglaNegocioException("Solo se peude crear una linea base para una fase de un proyecto.");
            }
            else if (lineaBase.LineaBaseECS.Where(x => x.Responsable.Id == 0).Count() > 0)
            {
                //REGLA: Todos los elementos de configuracion deben tener asignado a un responsable.
                throw new ReglaNegocioException(
                    "REGLAs los elementos de configuracion deben tener asignado a un responsable.");
            }

            _lineaBaseLogica.Agregar(lineaBase, usuarioProyecto);
        }

        public List<Entidades.LineaBase> ListarPorProyecto(Entidades.Proyecto proyecto, Entidades.Usuario usuario = null)
        {
            return _lineaBaseLogica.ListarPorProyecto(proyecto, usuario);
        }

        public Entidades.LineaBase ObtenerPorProyectoFase(Entidades.ProyectoFase proyectoFase, Entidades.Usuario usuario = null)
        {
            return _lineaBaseLogica.ObtenerPorProyectoFase(proyectoFase, usuario);
        }

        public void Actualizar(Entidades.LineaBase lineaBase)
        {
            LineaBase lineaBaseCreada = _lineaBaseData.ObtenerPorid(lineaBase.Id);
            if (lineaBaseCreada == null)
            {
                //REGLA: Solo se peuden actualizar lineas base que existan en BD.
                throw new ReglaNegocioException("Solo se peude actualizar lineas base que existan en BD.");
            }
            else if (!lineaBaseCreada.Estado.Equals(Constantes.EstadoLineaBaseAbierta.ToString()))
            {
                //REGLA: Solo se peude actualizar cuando la linea base se encuentra en estado abierta.
                throw new ReglaNegocioException("Solo se peude actualizar cuando la linea base se encuentra en estado abierta.");
            }
            else if (lineaBase.LineaBaseECS == null || lineaBase.LineaBaseECS.Count() == 0)
            {
                //REGLA: La Linea base debe tener asociado por lo menos un elemento de configuracion.
                throw new ReglaNegocioException(
                    "La Linea base debe tener asociado por lo menos un elemento de configuracion.");
            }
            else if (lineaBase.LineaBaseECS.Where(x => x.Responsable.Id == 0).Count() > 0)
            {
                //REGLA: Todos los elementos de configuracion deben tener asignado a un responsable.
                throw new ReglaNegocioException(
                    "REGLAs los elementos de configuracion deben tener asignado a un responsable.");
            }

            _lineaBaseLogica.Actualizar(lineaBase);
        }

        public void ActualizarArchivo(Entidades.LineaBaseElementoConfiguracion elemento)
        {
            LineaBaseElementoConfiguracion elementoCreado = _lineaBaseECSData.ObtenerPorId(elemento.Id);
            if (elementoCreado.LineaBase.ProyectoFase.FechaFin < DateTime.Now)
            {
                //REGLA: Solo se puede modificar el archivo de una linea base para un proyecto que no haya finalizado.
                throw new ReglaNegocioException("Solo se puede modificar el archivo de una linea base para un proyecto que no haya finalizado.");
            }

            _lineaBaseLogica.ActualizarArchivo(elemento);
        }

        public Entidades.LineaBaseElementoConfiguracion ObtenerArchivo(int id)
        {
            return ObtenerArchivo(id);
        }
    }
}
