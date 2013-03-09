using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;
using TMD.CF.LogicaNegocios.Contrato;

namespace TMD.CF.LogicaNegocios.Implementacion
{
    public class SolicitudCambioLogica: ISolicitudCambioLogica
    {

        private readonly ISolicitudCambioLogica _solicitudCambioData;
        
        public SolicitudCambioLogica(ISolicitudCambioLogica solicitudCambioData)
        {
            _solicitudCambioData = solicitudCambioData;
        }

        public void Agregar(SolicitudCambio solicitudCambio)
        {
            throw new NotImplementedException();
        }

        public void Aprobar(SolicitudCambio solicitudCambio)
        {
            throw new NotImplementedException();
        }

        public List<SolicitudCambio> ListarPorProyectoLineaBase(SolicitudCambio solicitudCambio)
        {
            throw new NotImplementedException();
        }

        public SolicitudCambio ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
