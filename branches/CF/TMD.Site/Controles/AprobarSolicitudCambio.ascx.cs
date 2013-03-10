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

        protected virtual void OnEventoGraboSolicitud()
        {
            AproboSolicitudHandler handler = EventoAproboSolicitud;
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

        public int IdEstado {
            get { return hidIdEstado.Value.ToInt(); }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            SolicitudCambioControladora.Aprobar(IdSolicitudCambio,IdEstado,txtMotivo.Text);

            OnEventoGraboSolicitud();
        }

    }
}