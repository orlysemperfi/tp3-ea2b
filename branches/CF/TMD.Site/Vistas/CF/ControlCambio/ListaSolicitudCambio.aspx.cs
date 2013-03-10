using System;
using System.Linq;
using TMD.CF.Site.Controladora.CF;
using TMD.CF.Site.Util;
using TMD.Core.Extension;

namespace TMD.CF.Site.Vistas.CF.ControlCambio
{
    public partial class ListaSolicitudCambio : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarControles();
            }

            ucRegistroSolicitudCambio.EventoGraboSolicitud +=
                new Controles.RegistroSolicitudCambio.GraboSolicitudHandler(ucRegistroSolicitudCambio_EventoGraboSolicitud);
        }

        void ucRegistroSolicitudCambio_EventoGraboSolicitud()
        {
            ucRegistroSolicitudCambio.Visible = false;
            pnlBusqueda.Visible = true;
        }

        private void CargarControles()
        {
            ddlProyecto.EnlazarDatos(LineaBaseControladora.ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id");
            ddlLineaBase.EnlazarValorDefecto();
            ddlEstado.EnlazarDatos(SolicitudCambioControladora.ListarEstado(), "Nombre", "Id");
            ddlPrioridad.EnlazarDatos(SolicitudCambioControladora.ListarPrioridad(), "Nombre", "Id");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grvSolicitudCambio.DataSource = 
                SolicitudCambioControladora.ListarPorProyectoLineaBase(ddlProyecto.SelectedValue.ToInt(), ddlLineaBase.SelectedValue.ToInt(),ddlEstado.SelectedValue.ToInt(), ddlPrioridad.SelectedValue.ToInt());
            grvSolicitudCambio.DataBind();
        }

        public String RecuperarEstadoNombre(int idEstado)
        {
            var estado = SolicitudCambioControladora.ListarEstado().FirstOrDefault(x => x.Id == idEstado);
            if (estado != null)
            {
                return estado.Nombre;
            }
            return null;
        }

        public String RecuperarEstadoImagen(int idEstado)
        {
            return String.Format("~/Imagenes/Estado/{0}.ico", idEstado);
        }

        public String RecuperarPrioridadNombre(int idPrioridad)
        {
            var prioridad = SolicitudCambioControladora.ListarPrioridad().FirstOrDefault(x => x.Id == idPrioridad);
            if (prioridad != null)
            {
                return prioridad.Nombre;
            }
            return null;
        }

        public String RecuperarPrioridadImagen(int idPrioridad)
        {
            return String.Format("~/Imagenes/Prioridad/{0}.ico", idPrioridad);
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLineaBase.EnlazarDatos(LineaBaseControladora.LineaBaseListarPorProyectoCombo(ddlProyecto.SelectedValue.ToInt()), "Nombre", "Id");
        }

        protected void grvSolicitudCambio_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Ver":
                    ucRegistroSolicitudCambio.CargarSolicitudExistente(Convert.ToInt32(e.CommandArgument));
                    ucRegistroSolicitudCambio.Visible = true;
                    pnlBusqueda.Visible = false;
                    break;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            ucRegistroSolicitudCambio.CargarsolicitudNueva();
            ucRegistroSolicitudCambio.Visible = true;
            pnlBusqueda.Visible = false;
        }
    }
}