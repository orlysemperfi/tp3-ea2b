﻿using System;
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
            /*
            btnNuevo.Visible = SesionFachada.Usuario.Rol == Roles.ResponsableElemento;
            
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
            ddlProyecto.EnlazarDatos(new OrdenCambioControladora().ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id");
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
            var estado = new OrdenCambioControladora().ListarEstado().FirstOrDefault(x => x.Id == idEstado);
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
            var prioridad = new OrdenCambioControladora().ListarPrioridad().FirstOrDefault(x => x.Id == idPrioridad);
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

            ddlLineaBase.EnlazarDatos(new OrdenCambioControladora().LineaBaseListarPorProyectoCombo(ddlProyecto.SelectedValue.ToInt()), "Nombre", "Id");
        }

        protected void grvOrdenCambio_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Ver":
                    ucRegistroOrdenCambio.CargarOrdenExistente(Convert.ToInt32(e.CommandArgument));
                    MostrarControles(true, false, false, false, false);
                    break;
                case "Cargar":
                    hidIdOrden.Value = e.CommandArgument.ToString();
                    MostrarControles(false, false, false, true, false);
                    System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "carga", "MostrarCarga(1);", true);
                    break;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            ucRegistroOrdenCambio.CargarordenNueva();
            MostrarControles(true, false, false, false, false);
        }

        protected void btnDescarga_Click(object sender, EventArgs e)
        {
            int idOrden = Convert.ToInt32(hidIdOrden.Value);
            
            OrdenCambio orden = new OrdenCambioControladora().ObtenerArchivo(idOrden);

            if (orden != null && orden.Data != null)
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", orden.NombreArchivo));
                Response.Flush();
                Response.Buffer = true;
                Response.BinaryWrite(orden.Data);
            }
        }

        protected void btnGrabarArchcivo_Click(object sender, EventArgs e)
        {
            if (fileUpArchivo.HasFile)
            {
                byte[] archivo = fileUpArchivo.FileBytes;
                String nombre = System.IO.Path.GetFileName(fileUpArchivo.FileName);
                new OrdenCambioControladora().ActualizarArchivo(Convert.ToInt32(hidIdOrden.Value), nombre, archivo);

                MostrarControles(false, true, false, false, true);
                btnBuscar_Click(null, null);
            }
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