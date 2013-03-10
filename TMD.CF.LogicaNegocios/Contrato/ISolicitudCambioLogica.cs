using System.Collections.Generic;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Contrato
{
    public interface ISolicitudCambioLogica
    {
        void Agregar(SolicitudCambio solicitudCambio);
        void Aprobar(SolicitudCambio solicitudCambio);
        List<SolicitudCambio> ListarPorProyectoLineaBase(SolicitudCambio solicitudCambio);
        SolicitudCambio ObtenerPorId(int id);
        SolicitudCambio ObtenerArchivo(int id);
        void ActualizarArchivo(SolicitudCambio solicitudCambio);
    }
}
