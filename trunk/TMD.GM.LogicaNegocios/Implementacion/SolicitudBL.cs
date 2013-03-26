using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.AccesoDatos.Implementacion;
using TMD.GM.Entidades;
using TMD.GM.LogicaNegocios.Contrato;
using TMD.GM.AccesoDatos.Contrato;

namespace TMD.GM.LogicaNegocios.Implementacion
{
    public class SolicitudBL:ISolicitudBL
    {
        #region Constructor
        private readonly ISolicitudDA instanciaDA;
        public SolicitudBL()
        {
            instanciaDA = new SolicitudDA();
        }
        #endregion

        public SolicitudBE ObtenerSolicitudNueva()
        {
            return instanciaDA.ObtenerSolicitudNueva();
        }

        public List<SolicitudBE> ObtenerSolicitudes(SolicitudFiltroBE filtro)
        {
            return instanciaDA.ObtenerSolicitudes( filtro);
        }

        public void RegistrarSolicitud(SolicitudBE solicitudBE)
        {
            instanciaDA.RegistrarSolicitud(solicitudBE);
        }
        public void EliminarSolicitud(SolicitudBE solicitudBE)
        {
            instanciaDA.EliminarSolicitud(solicitudBE);
        }
        public void ActualizarSolicitud(SolicitudBE solicitudBE)
        {
            instanciaDA.ActualizarSolicitud(solicitudBE);
        }
        public SolicitudBE VisualizarSolicitud(SolicitudBE solicitudBE)
        {
            return instanciaDA.VisualizarSolicitud(solicitudBE);
        }
        public List<SolicitudDetalleBE> GenerarCronograma(SolicitudBE solicitudBE)
        {
            return instanciaDA.GenerarCronograma(solicitudBE);
        }
        public CronogramaBE ActividadesCronograma(DateTime fecha)
        {
            return instanciaDA.ActividadesCronograma(fecha);
        }
    }
}
