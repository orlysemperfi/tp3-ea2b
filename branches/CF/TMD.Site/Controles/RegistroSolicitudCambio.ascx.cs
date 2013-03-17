using System;
using TMD.Entidades;
using TMD.Core.Extension;
using TMD.CF.Site.Util;
using TMD.CF.Site.FachadaNegocio.CF;
using TMD.Core;
using Microsoft.Practices.Unity;
using System.Web;

namespace TMD.CF.Site.Controles
{
    public partial class RegistroSolicitudCambio : System.Web.UI.UserControl
    {

        protected SolicitudCambioFachada solicitudFachada;
        protected LineaBaseFachada lineaBaseFachada;

        public delegate void GraboSolicitudHandler();
        public event GraboSolicitudHandler EventoGraboSolicitud;

        public delegate void CancelarSolicitudHandler();
        public event CancelarSolicitudHandler EventoCanceloSolicitud;

        protected virtual void OnEventoGraboSolicitud()
        {
            GraboSolicitudHandler handler = EventoGraboSolicitud;
            if (handler != null) handler();
        }

        protected virtual void OnEventoCanceloSolicitud()
        {
            CancelarSolicitudHandler handler = EventoCanceloSolicitud;
            if (handler != null) handler();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var accessor = HttpContext.Current.ApplicationInstance as IContainerAccessor;
            var container = accessor.Container;
            solicitudFachada = container.Resolve<SolicitudCambioFachada>();
            lineaBaseFachada = container.Resolve<LineaBaseFachada>();

            if (!Page.IsPostBack)
            {
                CargarsolicitudNueva();
            }
        }

        public void CargarSolicitudExistente(int idSolicitudCambio)
        {
            SolicitudCambio solicitud = solicitudFachada.ObtenerPorId(idSolicitudCambio);

            if (solicitud != null)
            {
                txtNombre.Text = solicitud.Nombre;

                int idProyecto = solicitud.ProyectoFase.Proyecto.Id;
                ddlProyecto.EnlazarDatos(lineaBaseFachada.ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id", -1, idProyecto);
                int lineaBaseId = solicitud.LineaBase.Id;
                ddlLineaBase.EnlazarDatos(lineaBaseFachada.LineaBaseListarPorProyectoCombo(idProyecto), "Nombre", "Id", -1, lineaBaseId);
                ddlElementoConfiguracion.EnlazarDatos(lineaBaseFachada.ElementoConfiguracionListarPorLineaBase(lineaBaseId), "NombreEcs", "Id", -1, solicitud.ElementoConfiguracion.Id);
                ddlEstado.EnlazarDatos(solicitudFachada.ListarEstado(), "Nombre", "Id", -1, solicitud.Estado);
                ddlPrioridad.EnlazarDatos(solicitudFachada.ListarPrioridad(), "Nombre", "Id", -1, solicitud.Prioridad);

                pnlSolicitudCambio.Enabled = false;
            }
        }

        public void Limpiar()
        {
            txtNombre.Text = "";
            ddlProyecto.Items.Clear();
            ddlLineaBase.Items.Clear();
            ddlElementoConfiguracion.Items.Clear();
            ddlEstado.Items.Clear();
            ddlPrioridad.Items.Clear();
        }

        public void CargarsolicitudNueva()
        {
            ddlProyecto.EnlazarDatos(lineaBaseFachada.ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id");
            ddlLineaBase.EnlazarValorDefecto();
            ddlElementoConfiguracion.EnlazarValorDefecto();
            ddlEstado.EnlazarDatos(solicitudFachada.ListarEstado(), "Nombre", "Id", -1, Constantes.EstadoPendiente);
            ddlPrioridad.EnlazarDatos(solicitudFachada.ListarPrioridad(), "Nombre", "Id");
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLineaBase.EnlazarDatos(lineaBaseFachada.LineaBaseListarPorProyectoCombo(ddlProyecto.SelectedValue.ToInt()), "Nombre", "Id");
        }

        protected void ddlLineaBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlElementoConfiguracion.EnlazarDatos(lineaBaseFachada.ElementoConfiguracionListarPorLineaBase(ddlLineaBase.SelectedValue.ToInt()), "NombreEcs", "Id");
        }
        
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            SolicitudCambio solicitudCambio = CrearSolicitud();

            solicitudFachada.Agregar(solicitudCambio);

            OnEventoGraboSolicitud();

            pnlSolicitudCambio.Enabled = false;
        }

        private SolicitudCambio CrearSolicitud()
        {
            return new SolicitudCambio
                {
                    Nombre = txtNombre.Text,
                    ProyectoFase = new ProyectoFase { Proyecto = new Proyecto { Id = ddlProyecto.SelectedValue.ToInt() } },
                    LineaBase = new LineaBase{ Id = ddlLineaBase.SelectedValue.ToInt()},
                    ElementoConfiguracion = new LineaBaseElementoConfiguracion{ Id = ddlElementoConfiguracion.SelectedValue.ToInt()},
                    Estado = ddlEstado.SelectedValue.ToInt(),
                    Prioridad = ddlPrioridad.SelectedValue.ToInt(),
                    Usuario = SesionFachada.Usuario
                };
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            OnEventoCanceloSolicitud();
        }
    }
}