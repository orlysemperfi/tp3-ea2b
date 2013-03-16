using System;
using TMD.CF.Site.Controladora.CF;
using TMD.Core.Extension;
using TMD.Entidades;
using TMD.Core;

namespace TMD.CF.Site.Controles
{
    public partial class AprobarSolicitudCambio : System.Web.UI.UserControl
    {

        public delegate void AproboSolicitudHandler();
        public event AproboSolicitudHandler EventoAproboSolicitud;

        public delegate void CancelarSolicitudHandler();
        public event CancelarSolicitudHandler EventoCanceloSolicitud;

        protected virtual void OnEventoGraboSolicitud()
        {
            AproboSolicitudHandler handler = EventoAproboSolicitud;
            if (handler != null) handler();
        }

        protected virtual void OnEventoCanceloSolicitud()
        {
            CancelarSolicitudHandler handler = EventoCanceloSolicitud;
            if (handler != null) handler();
        }

        public bool ApruebaSolicitud
        {
            set
            {
                lblTitulo.Text = value ? "Aprobar Solicitud" : "Rechazar Solicitud";
                hidIdEstado.Value = value ? Constantes.EstadoAprobado.ToString() : Constantes.EstadoDesaprobado.ToString();
            }
        }

        public int IdSolicitudCambio
        {
            get { return hidIdSolicitud.Value.ToInt(); }
            set { hidIdSolicitud.Value = value.ToString(); }
        }

        public int IdEstado
        {
            get { return hidIdEstado.Value.ToInt(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Limpiar()
        {
            hidIdEstado.Value = "";
            hidIdSolicitud.Value = "";
            txtMotivo.Text = "";
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            new SolicitudCambioControladora().Aprobar(IdSolicitudCambio, IdEstado, txtMotivo.Text);

            OnEventoGraboSolicitud();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            OnEventoCanceloSolicitud();
        }

    }
}