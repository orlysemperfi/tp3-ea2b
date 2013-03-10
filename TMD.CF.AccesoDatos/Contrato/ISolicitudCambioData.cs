using System.Collections.Generic;
using TMD.Entidades;

namespace TMD.CF.AccesoDatos.Contrato
{
    public interface ISolicitudCambioData
    {
        void Agregar(SolicitudCambio solicitudCambio);
        void Aprobar(SolicitudCambio solicitudCambio);
        List<SolicitudCambio> ListarPorProyectoLineaBase(SolicitudCambio solicitudCambio);
        SolicitudCambio ObtenerPorId(int id);
        SolicitudCambio ObtenerArchivo(int id);
        void ActualizarArchivo(SolicitudCambio solicitudCambio);
    }
}
