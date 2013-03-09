using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Contrato
{
    public interface ISolicitudCambioLogica
    {
        void Agregar(SolicitudCambio solicitudCambio);
        void Aprobar(SolicitudCambio solicitudCambio);
        List<SolicitudCambio> ListarPorProyectoLineaBase(SolicitudCambio solicitudCambio);
        SolicitudCambio ObtenerPorId(int id);
    }
}
