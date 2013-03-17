using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.Entidades;
using TMD.CF.LogicaNegocios.Error;
using TMD.CF.AccesoDatos.Contrato;
using TMD.Core;

namespace TMD.CF.LogicaNegocios.Implementacion
{
    //PATRON: DECORADOR
    public class SolicitudCambioValidacionLogica : ISolicitudCambioLogica
    {
        private readonly ISolicitudCambioLogica _solicitudCambioLogica;
        private readonly ISolicitudCambioData _solicitudCambioData;
        private readonly ILineaBaseData _lineaBaseData;
        private readonly ILineaBaseElementoConfiguracionData _lineaBaseECSData;

        public SolicitudCambioValidacionLogica(ISolicitudCambioLogica solicitudCambioLogica,ISolicitudCambioData solicitudCambioData, ILineaBaseData lineaBaseData,
            ILineaBaseElementoConfiguracionData lineaBaseECSData)
        {
            _solicitudCambioLogica = solicitudCambioLogica;
            _solicitudCambioData = solicitudCambioData;
            _lineaBaseData = lineaBaseData;
            _lineaBaseECSData = lineaBaseECSData;
        }

        public void Agregar(Entidades.SolicitudCambio solicitudCambio)
        {
            LineaBase lineaBase = _lineaBaseData.ObtenerPorid(solicitudCambio.LineaBase.Id);
            if (lineaBase == null)
            {
                //REGLA: La Linea base debe tener asociado por lo menos un elemento de configuracion.
                throw new ReglaNegocioException("La Linea base debe existir.");
            }
            else if (lineaBase.ProyectoFase.FechaFin > DateTime.Now)
            {
                //REGLA: La Linea base debe tener asociado por lo menos un elemento de configuracion.
                throw new ReglaNegocioException("Solo se puede crear una Solicitud para una linea base que haya finalizado.");
            }
            else if (solicitudCambio.ElementoConfiguracion == null || _lineaBaseECSData.ObtenerPorId(solicitudCambio.ElementoConfiguracion.Id) == null)
            {
                //REGLA: La Linea base debe tener asociado por lo menos un elemento de configuracion.
                throw new ReglaNegocioException("La Solicitud debe tener asociado por un elemento de configuracion.");
            }

            _solicitudCambioLogica.Agregar(solicitudCambio);
        }

        public void Aprobar(Entidades.SolicitudCambio solicitudCambio)
        {
            SolicitudCambio solicitudOrigen = _solicitudCambioData.ObtenerPorId(solicitudCambio.Id);

            if (solicitudOrigen == null)
            {
                //REGLA: La solicitud de cambio a aprobar/desaprobar debe existir.
                throw new ReglaNegocioException("La solicitud de cambio a aprobar/desaprobar debe existir.");
            }
            else if (solicitudOrigen.Estado != Constantes.EstadoPendiente)
            {
                //REGLA: Solo se aprueban/desaprueban solicitudes en estado pendiente.
                throw new ReglaNegocioException("Solo se aprueban/desaprueban solicitudes en estado pendiente.");
            }

            _solicitudCambioLogica.Aprobar(solicitudCambio);
        }

        public List<Entidades.SolicitudCambio> ListarPorProyectoLineaBase(Entidades.SolicitudCambio solicitudCambio)
        {
            return _solicitudCambioLogica.ListarPorProyectoLineaBase(solicitudCambio);
        }

        public Entidades.SolicitudCambio ObtenerPorId(int id)
        {
            return _solicitudCambioLogica.ObtenerPorId(id);
        }

        public Entidades.SolicitudCambio ObtenerArchivo(int id)
        {
            return _solicitudCambioLogica.ObtenerArchivo(id);
        }

        public void ActualizarArchivo(Entidades.SolicitudCambio solicitudCambio)
        {
            _solicitudCambioLogica.ActualizarArchivo(solicitudCambio);
        }
    }
}
