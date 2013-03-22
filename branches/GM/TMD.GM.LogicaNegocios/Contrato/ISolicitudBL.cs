using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.Entidades;

namespace TMD.GM.LogicaNegocios.Contrato
{
    public interface ISolicitudBL
    {
        SolicitudBE ObtenerSolicitudNueva();
        List<SolicitudBE> ObtenerSolicitudes(SolicitudFiltroBE filtro);

        void RegistrarSolicitud(SolicitudBE itemBE);
        void ActualizarSolicitud(SolicitudBE itemBE);
        void EliminarSolicitud(SolicitudBE itemBE);
        SolicitudBE VisualizarSolicitud(SolicitudBE itemBE);

        List<SolicitudDetalleBE> GenerarCronograma(SolicitudBE solicitudBE);
    }
}
