using System;
using System.Linq;
using TMD.CF.Site.FachadaNegocio.CF;
using TMD.CF.Site.Util;
using TMD.Core.Extension;
using TMD.Entidades;
using TMD.Core;
using TMD.Strings;
using Microsoft.Practices.Unity;
using System.Web;
using System.Web.UI;

namespace TMD.CF.Site.Vistas.CF.ControlCambio
{
    public partial class ListaInformeCambio : System.Web.UI.Page
    {

        protected SolicitudCambioFachada solicitudFachada;
        protected LineaBaseFachada lineaBaseFachada;
        protected InformeCambioFachada informeFachada;

        protected void Page_Load(object sender, EventArgs e)
        {
            var accessor = HttpContext.Current.ApplicationInstance as IContainerAccessor;
            var container = accessor.Container;
            solicitudFachada = container.Resolve<SolicitudCambioFachada>();
            lineaBaseFachada = container.Resolve<LineaBaseFachada>();
            informeFachada = container.Resolve<InformeCambioFachada>();

            if (!Page.IsPostBack)
            {
                CargarControles();
            }

            ucRegistroInformeCambio.EventoGraboInforme +=
                new Controles.RegistroInformeCambio.GraboInformeHandler(ucRegistroInformeCambio_EventoGraboInforme);
            ucRegistroInformeCambio.EventoCanceloInforme +=
                new Controles.RegistroInformeCambio.CancelarInformeHandler(ucRegistroInformeCambio_EventoCanceloInforme);

            ucAprobarInformeCambio.EventoAproboInforme +=
                new Controles.AprobarInformeCambio.AproboInformeHandler(ucAprobarInformeCambio_EventoAproboInforme);
            ucAprobarInformeCambio.EventoCanceloInforme +=
                new Controles.AprobarInformeCambio.CancelarInformeHandler(ucAprobarInformeCambio_EventoCanceloInforme);
            
            if (SesionFachada.Usuario.Rol != Roles.JefeProyecto && SesionFachada.Usuario.Rol != Roles.GestorCambio)
            {
                Response.Redirect(Pagina.NoPermitido);
            }

            btnNuevo.Visible = SesionFachada.Usuario.Rol == Roles.JefeProyecto;
        }

        private void MostrarControles(bool visibleRegistro, bool visibleBusqueda, bool visibleAprobar, bool visibleSubir, bool visibleLista)
        {
            ucRegistroInformeCambio.Visible = visibleRegistro;
            pnlBusqueda.Visible = visibleBusqueda;
            ucAprobarInformeCambio.Visible = visibleAprobar;
            pnlSubir.Visible = visibleSubir;
            grvInformeCambio.Visible = visibleLista;
            upnlSubir.Update();
        }


        void ucAprobarInformeCambio_EventoCanceloInforme()
        {
            MostrarControles(false, true, false, false, true);
            ucAprobarInformeCambio.Limpiar();
        }

        void ucAprobarInformeCambio_EventoAproboInforme()
        {
            MostrarControles(false, true, false, false, true);
            ucAprobarInformeCambio.Limpiar();
            btnBuscar_Click(null, null);
        }

        void ucRegistroInformeCambio_EventoCanceloInforme()
        {
            MostrarControles(false, true, false, false, true);
            ucRegistroInformeCambio.Limpiar();
        }

        void ucRegistroInformeCambio_EventoGraboInforme()
        {
            MostrarControles(false, true, false, false, true);
            ucRegistroInformeCambio.Limpiar();
            btnBuscar_Click(null, null);
        }

        private void CargarControles()
        {
            ddlProyecto.EnlazarDatos(lineaBaseFachada.ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id");
            ddlLineaBase.EnlazarValorDefecto();
            ddlEstado.EnlazarDatos(solicitudFachada.ListarEstado(), "Nombre", "Id");
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLineaBase.EnlazarDatos(lineaBaseFachada.LineaBaseListarPorProyectoCombo(ddlProyecto.SelectedValue.ToInt()), "Nombre", "Id");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grvInformeCambio.DataSource =
                informeFachada.ListarPorProyectoLineaBase(ddlProyecto.SelectedValue.ToInt(), ddlLineaBase.SelectedValue.ToInt(), ddlEstado.SelectedValue.ToInt());
            grvInformeCambio.DataBind();

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            ucRegistroInformeCambio.CargarInformeNuevo();
            MostrarControles(true, true, false, false, false);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "_idBtnNuevo_", "mostrarDiv('divRegistroInforme');", true);
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
            return String.Format("~/Imagenes/Estado/{0}.png", idEstado);
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
            return String.Format("~/Imagenes/Prioridad/{0}.ico", idPrioridad);
        }

        protected void grvInformeCambio_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Ver":
                    ucRegistroInformeCambio.CargarInformeExistente(Convert.ToInt32(e.CommandArgument));
                    MostrarControles(true, true, false, false, false);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "_idBtnVer_", "mostrarDiv('divRegistroInforme');", true);
                    break;
                case "Cargar":
                    hidIdInforme.Value = e.CommandArgument.ToString();
                    MostrarControles(false, true, false, true, true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "_idBtnCargar_", "mostrarDiv('divSubirInforme');", true);
                    break;
                case "Aprobar":
                    ucAprobarInformeCambio.IdInformeCambio = Convert.ToInt32(e.CommandArgument);
                    ucAprobarInformeCambio.ApruebaInforme = true;
                    MostrarControles(false,true,true,false,true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "_idBtnAprobar_", "mostrarDiv('divAprobarInforme');", true);
                    break;
                case "Rechazar":
                    ucAprobarInformeCambio.IdInformeCambio = Convert.ToInt32(e.CommandArgument);
                    ucAprobarInformeCambio.ApruebaInforme = false;
                    MostrarControles(false, true, true, false, true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "_idBtnRechazar_", "mostrarDiv('divAprobarInforme');", true);
                    break;
            }

        }

        protected void btnDescarga_Click(object sender, EventArgs e)
        {
            int idInforme = Convert.ToInt32(hidIdInforme.Value);

            InformeCambio informe = informeFachada.ObtenerArchivo(idInforme);

            if (informe != null && informe.Data != null)
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", informe.NombreArchivo));
                Response.Flush();
                Response.Buffer = true;
                Response.BinaryWrite(informe.Data);
            }
        }

        protected void btnGrabarArchcivo_Click(object sender, EventArgs e)
        {
            if (fileUpArchivo.HasFile)
            {
                byte[] archivo = fileUpArchivo.FileBytes;
                String nombre = System.IO.Path.GetFileName(fileUpArchivo.FileName);
                informeFachada.ActualizarArchivo(Convert.ToInt32(hidIdInforme.Value), nombre, archivo);

                MostrarControles(false, true, false, false, true);
                btnBuscar_Click(null, null);
            }
        }

        protected void btnCancelarArchcivo_Click(object sender, EventArgs e)
        {
            MostrarControles(false, true, false, false, true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "_idBtnCancel_", "ocultarDiv('divRegistroInforme');", true);
        }

        protected void grvInformeCambio_DataBound(object sender, EventArgs e)
        {
            grvInformeCambio.Columns[10].Visible = SesionFachada.Usuario.Rol == Roles.GestorCambio;
            grvInformeCambio.Columns[9].Visible = SesionFachada.Usuario.Rol == Roles.GestorCambio;

            grvInformeCambio.Columns[7].Visible = SesionFachada.Usuario.Rol == Roles.JefeProyecto;
            grvInformeCambio.Columns[8].Visible = SesionFachada.Usuario.Rol == Roles.JefeProyecto;
        }

    }
}