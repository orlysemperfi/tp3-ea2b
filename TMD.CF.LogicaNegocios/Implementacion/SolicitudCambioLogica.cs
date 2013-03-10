using System.Collections.Generic;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.AccesoDatos.Contrato;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Implementacion
{
    public class SolicitudCambioLogica: ISolicitudCambioLogica
    {

        private readonly ISolicitudCambioData _solicitudCambioData;

        public SolicitudCambioLogica(ISolicitudCambioData solicitudCambioData)
        {
            _solicitudCambioData = solicitudCambioData;
        }

        public void Agregar(SolicitudCambio solicitudCambio)
        {
            _solicitudCambioData.Agregar(solicitudCambio);
        }

        public void Aprobar(SolicitudCambio solicitudCambio)
        {
            _solicitudCambioData.Aprobar(solicitudCambio);
        }

        public List<SolicitudCambio> ListarPorProyectoLineaBase(SolicitudCambio solicitudCambio)
        {
            return _solicitudCambioData.ListarPorProyectoLineaBase(solicitudCambio);
        }

        public SolicitudCambio ObtenerPorId(int id)
        {
            return _solicitudCambioData.ObtenerPorId(id);
        }

        public SolicitudCambio ObtenerArchivo(int id)
        {
            return _solicitudCambioData.ObtenerArchivo(id);
        }

        public void ActualizarArchivo(SolicitudCambio solicitudCambio)
        {
            _solicitudCambioData.ActualizarArchivo(solicitudCambio );
        }
    }
}
