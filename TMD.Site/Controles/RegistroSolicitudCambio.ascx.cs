﻿using System;
using TMD.Entidades;
using TMD.Core.Extension;
using TMD.CF.Site.Util;
using TMD.CF.Site.Controladora.CF;
using TMD.Core;

namespace TMD.CF.Site.Controles
{
    public partial class RegistroSolicitudCambio : System.Web.UI.UserControl
    {
        public delegate void GraboSolicitudHandler();
        public event GraboSolicitudHandler EventoGraboSolicitud;

        protected virtual void OnEventoGraboSolicitud()
        {
            GraboSolicitudHandler handler = EventoGraboSolicitud;
            if (handler != null) handler();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarsolicitudNueva();
            }
        }

        public void CargarSolicitudExistente(int idSolicitudCambio)
        {
            SolicitudCambio solicitud = SolicitudCambioControladora.ObtenerPorId(idSolicitudCambio);

            if (solicitud != null)
            {
                lblCodigo.Text = solicitud.Id.ToString();
                txtNombre.Text = solicitud.Nombre;

                int idProyecto = solicitud.ProyectoFase.Proyecto.Id;
                ddlProyecto.EnlazarDatos(LineaBaseControladora.ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id", -1, idProyecto);
                int lineaBaseId = solicitud.LineaBase.Id;
                ddlLineaBase.EnlazarDatos(LineaBaseControladora.LineaBaseListarPorProyectoCombo(idProyecto), "Nombre", "Id", -1, lineaBaseId);
                ddlElementoConfiguracion.EnlazarDatos(LineaBaseControladora.ElementoConfiguracionListarPorLineaBase(lineaBaseId), "NombreEcs", "Id",-1,solicitud.ElementoConfiguracion.Id);
                ddlEstado.EnlazarDatos(SolicitudCambioControladora.ListarEstado(), "Nombre", "Id", -1, solicitud.Estado);
                ddlPrioridad.EnlazarDatos(SolicitudCambioControladora.ListarPrioridad(), "Nombre", "Id",-1,solicitud.Prioridad);

                pnlSolicitudCambio.Enabled = false;
            }
        }

        public void Limpiar()
        {
            lblCodigo.Text = "";
            txtNombre.Text = "";
            ddlProyecto.Items.Clear();
            ddlLineaBase.Items.Clear();
            ddlElementoConfiguracion.Items.Clear();
            ddlEstado.Items.Clear();
            ddlPrioridad.Items.Clear();
        }

        public void CargarsolicitudNueva()
        {
            ddlProyecto.EnlazarDatos(LineaBaseControladora.ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id");
            ddlLineaBase.EnlazarValorDefecto();
            ddlElementoConfiguracion.EnlazarValorDefecto();
            ddlEstado.EnlazarDatos(SolicitudCambioControladora.ListarEstado(),"Nombre","Id",-1,Constantes.EstadoPendiente);
            ddlPrioridad.EnlazarDatos(SolicitudCambioControladora.ListarPrioridad(),"Nombre","Id");
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLineaBase.EnlazarDatos(LineaBaseControladora.LineaBaseListarPorProyectoCombo(ddlProyecto.SelectedValue.ToInt()), "Nombre", "Id");
        }

        protected void ddlLineaBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlElementoConfiguracion.EnlazarDatos(LineaBaseControladora.ElementoConfiguracionListarPorLineaBase(ddlLineaBase.SelectedValue.ToInt()), "NombreEcs", "Id");
        }
        
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            SolicitudCambio solicitudCambio = CrearSolicitud();

            SolicitudCambioControladora.Agregar(solicitudCambio);

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
    }
}