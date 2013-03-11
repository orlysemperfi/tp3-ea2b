using System.Collections.Generic;
using System.Transactions;
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
            SolicitudCambio solicitudCambio = null;

            using (var scope = new TransactionScope())
            {
                solicitudCambio = _solicitudCambioData.ObtenerArchivo(id);
                scope.Complete();
            }

            return solicitudCambio;
        }

        public void ActualizarArchivo(SolicitudCambio solicitudCambio)
        {
            using (var scope = new TransactionScope())
            {
                _solicitudCambioData.ActualizarArchivo(solicitudCambio);
                scope.Complete();
            }
        }
    }
}
