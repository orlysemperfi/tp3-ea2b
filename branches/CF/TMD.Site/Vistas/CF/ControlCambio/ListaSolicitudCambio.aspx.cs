using System;
using System.Linq;
using TMD.CF.Site.FachadaNegocio.CF;
using TMD.CF.Site.Util;
using TMD.Core.Extension;
using TMD.Entidades;
using TMD.Core;
using TMD.Strings;
using System.Web;
using Microsoft.Practices.Unity;

namespace TMD.CF.Site.Vistas.CF.ControlCambio
{
    public partial class ListaSolicitudCambio : System.Web.UI.Page
    {

        protected SolicitudCambioFachada solicitudFachada;
        protected LineaBaseFachada lineaBaseFachada;

        protected void Page_Load(object sender, EventArgs e)
        {
            var accessor = HttpContext.Current.ApplicationInstance as IContainerAccessor;
            var container = accessor.Container;
            solicitudFachada = container.Resolve<SolicitudCambioFachada>();
            lineaBaseFachada = container.Resolve<LineaBaseFachada>();

            if (!Page.IsPostBack)
            {
                CargarControles();
            }

            ucRegistroSolicitudCambio.EventoGraboSolicitud +=
                new Controles.RegistroSolicitudCambio.GraboSolicitudHandler(ucRegistroSolicitudCambio_EventoGraboSolicitud);
            ucRegistroSolicitudCambio.EventoCanceloSolicitud += 
                new Controles.RegistroSolicitudCambio.CancelarSolicitudHandler(ucRegistroSolicitudCambio_EventoCanceloSolicitud);

            ucAprobarSolicitudCambio.EventoAproboSolicitud += 
                new Controles.AprobarSolicitudCambio.AproboSolicitudHandler(ucAprobarSolicitudCambio_EventoAproboSolicitud);
            ucAprobarSolicitudCambio.EventoCanceloSolicitud += 
                new Controles.AprobarSolicitudCambio.CancelarSolicitudHandler(ucAprobarSolicitudCambio_EventoCanceloSolicitud);

            btnNuevo.Visible = SesionFachada.Usuario.Rol == Roles.ResponsableElemento;

            if (SesionFachada.Usuario.Rol != Roles.ResponsableElemento && SesionFachada.Usuario.Rol != Roles.GestorCambio)
            {
                Response.Redirect(Pagina.NoPermitido);
            }

        }

        private void MostrarControles(bool visibleRegistro, bool visibleBusqueda, bool visibleAprobar, bool visibleSubir, bool visibleLista)
        {
            ucRegistroSolicitudCambio.Visible = visibleRegistro;
            pnlBusqueda.Visible = visibleBusqueda;
            ucAprobarSolicitudCambio.Visible = visibleAprobar;
            pnlSubir.Visible = visibleSubir;
            grvSolicitudCambio.Visible = visibleLista;
            upnlSubir.Update();
        }

        void ucAprobarSolicitudCambio_EventoCanceloSolicitud()
        {
            MostrarControles(false, true, false, false, true);
            ucAprobarSolicitudCambio.Limpiar();
        }

        void ucAprobarSolicitudCambio_EventoAproboSolicitud()
        {
            MostrarControles(false, true, false, false, true);
            ucAprobarSolicitudCambio.Limpiar();
            btnBuscar_Click(null, null);
        }

        void ucRegistroSolicitudCambio_EventoCanceloSolicitud()
        {
            MostrarControles(false, true, false, false, true);
            ucRegistroSolicitudCambio.Limpiar();
        }

        void ucRegistroSolicitudCambio_EventoGraboSolicitud()
        {
            MostrarControles(false, true, false, false, true);
            ucRegistroSolicitudCambio.Limpiar();
            btnBuscar_Click(null, null);
        }

        private void CargarControles()
        {
            ddlProyecto.EnlazarDatos(lineaBaseFachada.ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id");
            ddlLineaBase.EnlazarValorDefecto();
            ddlEstado.EnlazarDatos(solicitudFachada.ListarEstado(), "Nombre", "Id");
            ddlPrioridad.EnlazarDatos(solicitudFachada.ListarPrioridad(), "Nombre", "Id");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grvSolicitudCambio.DataSource =
                solicitudFachada.ListarPorProyectoLineaBase(ddlProyecto.SelectedValue.ToInt(), ddlLineaBase.SelectedValue.ToInt(), ddlEstado.SelectedValue.ToInt(), ddlPrioridad.SelectedValue.ToInt());
            grvSolicitudCambio.DataBind();
        }

        public String RecuperarEstadoNombre(int idEstado)
        {
            var estado = solicitudFachada.ListarEstado().FirstOrDefault(x => x.Id == idEstado);
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
            var prioridad = solicitudFachada.ListarPrioridad().FirstOrDefault(x => x.Id == idPrioridad);
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
            ddlLineaBase.EnlazarDatos(lineaBaseFachada.LineaBaseListarPorProyectoCombo(ddlProyecto.SelectedValue.ToInt()), "Nombre", "Id");
        }

        protected void grvSolicitudCambio_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Ver":
                    ucRegistroSolicitudCambio.CargarSolicitudExistente(Convert.ToInt32(e.CommandArgument));
                    MostrarControles(true, false, false, false, false);
                    break;
                case "Cargar":
                    hidIdSolicitud.Value = e.CommandArgument.ToString();
                    MostrarControles(false, false, false, true, false);
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "carga", "MostrarCarga(1);", true);
                    break;
                case "Aprobar":
                    ucAprobarSolicitudCambio.IdSolicitudCambio = Convert.ToInt32(e.CommandArgument);
                    ucAprobarSolicitudCambio.ApruebaSolicitud = true;
                    MostrarControles(false,false,true,false,false);
                    break;
                case "Rechazar":
                    ucAprobarSolicitudCambio.IdSolicitudCambio = Convert.ToInt32(e.CommandArgument);
                    ucAprobarSolicitudCambio.ApruebaSolicitud = false;
                    MostrarControles(false, false, true, false, false);
                    break;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            ucRegistroSolicitudCambio.CargarsolicitudNueva();
            MostrarControles(true, false, false, false, false);
        }

        protected void btnDescarga_Click(object sender, EventArgs e)
        {
            int idSolicitud = Convert.ToInt32(hidIdSolicitud.Value);

            SolicitudCambio solicitud = solicitudFachada.ObtenerArchivo(idSolicitud);

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

        protected void btnGrabarArchcivo_Click(object sender, EventArgs e)
        {
            if (fileUpArchivo.HasFile)
            {
                byte[] archivo = fileUpArchivo.FileBytes;
                String nombre = System.IO.Path.GetFileName(fileUpArchivo.FileName);
                solicitudFachada.ActualizarArchivo(Convert.ToInt32(hidIdSolicitud.Value), nombre, archivo);

                MostrarControles(false, true, false, false, true);
                btnBuscar_Click(null, null);
            }
        }

        protected void btnCancelarArchcivo_Click(object sender, EventArgs e)
        {
            MostrarControles(false, true, false, false, true);
        }

        protected void grvSolicitudCambio_DataBound(object sender, EventArgs e)
        {
            grvSolicitudCambio.Columns[10].Visible = SesionFachada.Usuario.Rol == Roles.GestorCambio;
            grvSolicitudCambio.Columns[11].Visible = SesionFachada.Usuario.Rol == Roles.GestorCambio;

            grvSolicitudCambio.Columns[9].Visible = SesionFachada.Usuario.Rol == Roles.ResponsableElemento;
            grvSolicitudCambio.Columns[8].Visible = SesionFachada.Usuario.Rol == Roles.ResponsableElemento;
        }

    }
}