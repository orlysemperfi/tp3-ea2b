using System;
using System.Linq;
using TMD.CF.Site.Controladora.CF;
using TMD.CF.Site.Util;
using TMD.Core.Extension;
using TMD.Entidades;
using TMD.Core;

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
            ucRegistroSolicitudCambio.EventoCanceloSolicitud += 
                new Controles.RegistroSolicitudCambio.CancelarSolicitudHandler(ucRegistroSolicitudCambio_EventoCanceloSolicitud);

            ucAprobarSolicitudCambio.EventoAproboSolicitud += 
                new Controles.AprobarSolicitudCambio.AproboSolicitudHandler(ucAprobarSolicitudCambio_EventoAproboSolicitud);
            ucAprobarSolicitudCambio.EventoCanceloSolicitud += 
                new Controles.AprobarSolicitudCambio.CancelarSolicitudHandler(ucAprobarSolicitudCambio_EventoCanceloSolicitud);

            ucSubirArchivoSolicitudCambio.EventoSubioArchivoSolicitud += 
                new Controles.SubirArchivoSolicitudCambio.SubioArchivoSolicitudHandler(ucSubirArchivoSolicitudCambio_EventoSubioArchivoSolicitud);
            ucSubirArchivoSolicitudCambio.EventoCanceloArchivoSolicitud += 
                new Controles.SubirArchivoSolicitudCambio.CancelarArchivoSolicitudHandler(ucSubirArchivoSolicitudCambio_EventoCanceloArchivoSolicitud);
        }

        private void MostrarControles(bool visibleRegistro, bool visibleBusqueda, bool visibleAprobar, bool visibleSubir, bool visibleLista)
        {
            ucRegistroSolicitudCambio.Visible = visibleRegistro;
            pnlBusqueda.Visible = visibleBusqueda;
            ucAprobarSolicitudCambio.Visible = visibleAprobar;
            ucSubirArchivoSolicitudCambio.Visible = visibleSubir;
            grvSolicitudCambio.Visible = visibleLista;
        }

        void ucSubirArchivoSolicitudCambio_EventoCanceloArchivoSolicitud()
        {
            MostrarControles(false, true, false, false,true);
            ucSubirArchivoSolicitudCambio.Limpiar();
        }

        void ucSubirArchivoSolicitudCambio_EventoSubioArchivoSolicitud()
        {
            MostrarControles(false, true, false, false, true);
            ucSubirArchivoSolicitudCambio.Limpiar();
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
                    //pnlBusqueda.Visible = false;
                    break;
                case "Cargar":
                    ucSubirArchivoSolicitudCambio.IdSolicitudCambio = Convert.ToInt32(e.CommandArgument);
                    ucRegistroSolicitudCambio.Visible = false;
                    //pnlBusqueda.Visible = false;
                    ucAprobarSolicitudCambio.Visible = false;
                    ucSubirArchivoSolicitudCambio.Visible = true;
                    break;
                case "Aprobar":
                    ucAprobarSolicitudCambio.IdSolicitudCambio = Convert.ToInt32(e.CommandArgument);
                    ucAprobarSolicitudCambio.ApruebaSolicitud = true;
                    ucRegistroSolicitudCambio.Visible = false;
                    //pnlBusqueda.Visible = false;
                    ucAprobarSolicitudCambio.Visible = true;
                    ucSubirArchivoSolicitudCambio.Visible = false;
                    break;
                case "Rechazar":
                    ucAprobarSolicitudCambio.IdSolicitudCambio = Convert.ToInt32(e.CommandArgument);
                    ucAprobarSolicitudCambio.ApruebaSolicitud = false;
                    ucRegistroSolicitudCambio.Visible = false;
                    //pnlBusqueda.Visible = false;
                    ucAprobarSolicitudCambio.Visible = true;
                    ucSubirArchivoSolicitudCambio.Visible = false;
                    break;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            ucRegistroSolicitudCambio.CargarsolicitudNueva();
            ucRegistroSolicitudCambio.Visible = true;
            pnlBusqueda.Visible = false;
        }

        protected void btnDescarga_Click(object sender, EventArgs e)
        {
            int idSolicitud = Convert.ToInt32(hidIdSolicitud.Value);

            SolicitudCambio solicitud = SolicitudCambioControladora.ObtenerArchivo(idSolicitud);

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