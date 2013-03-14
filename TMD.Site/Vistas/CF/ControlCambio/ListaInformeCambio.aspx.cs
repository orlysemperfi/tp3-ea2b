using System;
using System.Linq;
using TMD.CF.Site.Controladora.CF;
using TMD.CF.Site.Util;
using TMD.Core.Extension;
using TMD.Entidades;
using TMD.Core;

namespace TMD.CF.Site.Vistas.CF.ControlCambio
{
    public partial class ListaInformeCambio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarControles();
            }
        }

        private void CargarControles()
        {
            ddlProyecto.EnlazarDatos(new LineaBaseControladora().ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id");
            ddlLineaBase.EnlazarValorDefecto();
            ddlEstado.EnlazarDatos(new SolicitudCambioControladora().ListarEstado(), "Nombre", "Id");
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLineaBase.EnlazarDatos(new LineaBaseControladora().LineaBaseListarPorProyectoCombo(ddlProyecto.SelectedValue.ToInt()), "Nombre", "Id");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grvInformeCambio.DataSource =
                new InformeCambioFachada().ListarPorProyectoLineaBase(ddlProyecto.SelectedValue.ToInt(), ddlLineaBase.SelectedValue.ToInt(), ddlEstado.SelectedValue.ToInt());
            grvInformeCambio.DataBind();

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            ucRegistroInformeCambio.CargarsolicitudNueva();
            ucRegistroInformeCambio.Visible = true;
            pnlBusqueda.Visible = false;
        }

        public String RecuperarEstadoNombre(int idEstado)
        {
            var estado = new SolicitudCambioControladora().ListarEstado().FirstOrDefault(x => x.Id == idEstado);
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
            var prioridad = new SolicitudCambioControladora().ListarPrioridad().FirstOrDefault(x => x.Id == idPrioridad);
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

        protected void grvInformeCambio_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

        }

        protected void btnDescarga_Click(object sender, EventArgs e)
        {
            int idSolicitud = Convert.ToInt32(hidIdSolicitud.Value);

            SolicitudCambio solicitud = new SolicitudCambioControladora().ObtenerArchivo(idSolicitud);

            if (solicitud != null && solicitud.Data != null)
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", solicitud.NombreArchivo));
                Response.Flush();
                Response.Buffer = true;
                Response.BinaryWrite(solicitud.Data);
            }
        }
    }
}