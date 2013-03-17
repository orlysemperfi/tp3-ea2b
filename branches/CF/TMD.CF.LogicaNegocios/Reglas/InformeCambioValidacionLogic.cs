using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.AccesoDatos.Contrato;
using TMD.Entidades;
using TMD.CF.LogicaNegocios.Error;
using TMD.Core;

namespace TMD.CF.LogicaNegocios.Implementacion
{
    //PATRON: DECORADOR
    public class InformeCambioValidacionLogica : IInformeCambioLogica
    {
        private readonly IInformeCambioLogica _informeLogicaCambio;
        private readonly IInformeCambioData _informeCambioData;
        private readonly ISolicitudCambioData _solicitudCambioData;

        public InformeCambioValidacionLogica(IInformeCambioLogica informeLogicaCambio, IInformeCambioData informeCambioData,
            ISolicitudCambioData solicitudCambioData)
        {
            _informeLogicaCambio = informeLogicaCambio;
            _informeCambioData = informeCambioData;
            _solicitudCambioData = solicitudCambioData;
        }

        public void Agregar(Entidades.InformeCambio informeCambio)
        {
            SolicitudCambio solicitudCambio = _solicitudCambioData.ObtenerPorId(informeCambio.Solicitud.Id);
            if (solicitudCambio == null)
            {
                //REGLA: La solicitud de cambio a aprobar/desaprobar debe existir.
                throw new ReglaNegocioException("Para crear una solicitud la solicitud de cambio debe existir.");
            }
            else if (solicitudCambio.Estado != Constantes.EstadoAprobado)
            {
                //REGLA: Solo se aprueban/desaprueban solicitudes en estado pendiente.
                throw new ReglaNegocioException("Solo se crean informes de cambio sobre solicitudes en estado aprobado.");
            }

            _informeLogicaCambio.Agregar(informeCambio);
        }

        public void Aprobar(Entidades.InformeCambio informeCambio)
        {
            _informeLogicaCambio.Aprobar(informeCambio);
        }

        public List<Entidades.InformeCambio> ListarPorProyectoLineaBase(Entidades.InformeCambio informeCambio)
        {
            return _informeLogicaCambio.ListarPorProyectoLineaBase(informeCambio);
        }

        public Entidades.InformeCambio ObtenerPorId(int id)
        {
            return _informeLogicaCambio.ObtenerPorId(id);
        }

        public Entidades.InformeCambio ObtenerArchivo(int id)
        {
            return _informeLogicaCambio.ObtenerArchivo(id);
        }

        public void ActualizarArchivo(Entidades.InformeCambio informeCambio)
        {
            _informeLogicaCambio.ActualizarArchivo(informeCambio);
        }
    }
}
