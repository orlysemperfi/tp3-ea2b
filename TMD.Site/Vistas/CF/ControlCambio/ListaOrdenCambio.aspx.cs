using System;
using System.Linq;
using TMD.CF.Site.FachadaNegocio.CF;
using TMD.CF.Site.Util;
using TMD.Core.Extension;
using TMD.Entidades;
using TMD.Core;
using TMD.Strings;

namespace TMD.CF.Site.Vistas.CF.ControlCambio
{
    public partial class ListaOrdenCambio : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                CargarControles();
            }

            ucRegistroOrdenCambio.EventoGraboOrden +=
                new Controles.CF.ControlCambio.RegistroOrdenCambio.GraboOrdenHandler(ucRegistroOrdenCambio_EventoGraboOrden);
            ucRegistroOrdenCambio.EventoCanceloOrden +=
                new Controles.CF.ControlCambio.RegistroOrdenCambio.CancelarOrdenHandler(ucRegistroOrdenCambio_EventoCanceloOrden);
			
            btnNuevo.Visible = SesionFachada.Usuario.Rol == Roles.ResponsableElemento;
            /*
            if (SesionFachada.Usuario.Rol != Roles.ResponsableElemento && SesionFachada.Usuario.Rol != Roles.GestorCambio)
            {
                Response.Redirect(Pagina.NoPermitido);
            }
            */
        }

        private void MostrarControles(bool visibleRegistro, bool visibleBusqueda, bool visibleAprobar, bool visibleSubir, bool visibleLista)
        {
            ucRegistroOrdenCambio.Visible = visibleRegistro;
            pnlBusqueda.Visible = visibleBusqueda;
            pnlSubir.Visible = visibleSubir;
            grvOrdenCambio.Visible = visibleLista;
            upnlSubir.Update();
        }
		
		void ucRegistroOrdenCambio_EventoCanceloOrden()
        {
            MostrarControles(false, true, false, false, true);
            ucRegistroOrdenCambio.Limpiar();
        }

        void ucRegistroOrdenCambio_EventoGraboOrden()
        {
            MostrarControles(false, true, false, false, true);
            ucRegistroOrdenCambio.Limpiar();
            btnBuscar_Click(null, null);
        }

        private void CargarControles()
        {
            ddlProyecto.EnlazarDatos(new LineaBaseFachada().ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id");
            ddlLineaBase.EnlazarValorDefecto();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grvOrdenCambio.DataSource =
                new OrdenCambioControladora().ListarPorProyectoLBase(ddlProyecto.SelectedValue.ToInt(), ddlLineaBase.SelectedValue.ToInt());
            grvOrdenCambio.DataBind();
        }

        public String RecuperarEstadoNombre(int idEstado)
        {
            var estado = new SolicitudCambioFachada().ListarEstado().FirstOrDefault(x => x.Id == idEstado);
            if (estado != null)
            {
                return estado.Nombre;
            }
            return null;
        }

        public String RecuperarEstadoImagen(int idEstado)
        {
            return String.Format(Imagenes.ForamtoEstado, idEstado);
        }

        public String RecuperarPrioridadNombre(int idPrioridad)
        {
            var prioridad = new SolicitudCambioFachada().ListarPrioridad().FirstOrDefault(x => x.Id == idPrioridad);
            if (prioridad != null)
            {
                return prioridad.Nombre;
            }
            return null;
        }

        public String RecuperarPrioridadImagen(int idPrioridad)
        {
            return String.Format(Imagenes.FormatoPrioridad, idPrioridad);
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            grvOrdenCambio.DataSource =
                new OrdenCambioControladora().ListarPorProyectoLBase(ddlProyecto.SelectedValue.ToInt(), ddlLineaBase.SelectedValue.ToInt());
            grvOrdenCambio.DataBind();

            ddlLineaBase.EnlazarDatos(new LineaBaseFachada().LineaBaseListarPorProyectoCombo(ddlProyecto.SelectedValue.ToInt()), "Nombre", "Id");
        }

        protected void grvOrdenCambio_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            ucRegistroOrdenCambio.CargarordenNueva();
            MostrarControles(true, false, false, false, false);
        }

        protected void btnDescarga_Click(object sender, EventArgs e)
        {
        }

        protected void btnGrabarArchcivo_Click(object sender, EventArgs e)
        {
        }

        protected void btnCancelarArchcivo_Click(object sender, EventArgs e)
        {
            MostrarControles(false, true, false, false, true);
        }

        protected void grvOrdenCambio_DataBound(object sender, EventArgs e)
        {
        }

    }
}