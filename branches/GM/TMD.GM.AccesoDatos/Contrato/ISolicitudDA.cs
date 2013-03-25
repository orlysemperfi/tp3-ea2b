using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.Entidades;

namespace TMD.GM.AccesoDatos.Contrato
{
    public interface ISolicitudDA
    {
        SolicitudBE ObtenerSolicitudNueva();
        List<SolicitudBE> ObtenerSolicitudes(SolicitudFiltroBE filtro);
        void RegistrarSolicitud(SolicitudBE planBE);
        void ActualizarSolicitud(SolicitudBE planBE);
        void EliminarSolicitud(SolicitudBE solicitudBE);
        SolicitudBE VisualizarSolicitud(SolicitudBE planBE);
        List<SolicitudDetalleBE> GenerarCronograma(SolicitudBE solicitudBE);
        CronogramaBE ActividadesCronograma(DateTime fecha);
    }
}
