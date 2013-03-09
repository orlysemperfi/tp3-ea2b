using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.CF.Site.Controladora;
using TMD.Entidades;
using TMD.Core.Extension;
using TMD.CF.Site.Util;
using TMD.CF.Site.Controladora.CF;

namespace TMD.CF.Site.Controles
{
    public partial class RegistroSolicitudCambio : System.Web.UI.UserControl
    {
        public delegate void GraboHandler();
        public event GraboHandler EventoGrabo;

        protected virtual void OnEventoGrabo()
        {
            GraboHandler handler = EventoGrabo;
            if (handler != null) handler();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarControles();
        }

        private void CargarControles()
        {
            ddlProyecto.DataSource = LineaBaseControladora.ListarProyectoPorUsuario(1);
            ddlProyecto.DataTextField = "Nombre";
            ddlProyecto.DataValueField = "Id";
            ddlProyecto.DataBind();
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLineaBase.DataSource = LineaBaseControladora.LineaBaseListarPorProyecto(ddlProyecto.SelectedValue.ToInt());
            ddlLineaBase.DataTextField = "Nombre";
            ddlLineaBase.DataValueField = "Id";
            ddlLineaBase.DataBind();
        }

        protected void ddlLineaBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddlElementoConfiguracion.DataSource = LineaBaseControladora.ElementoConfiguracionListarPorFase()
            //ddlEstado.DataSource = null;
            //ddlPrioridad.DataSource = null;
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            SolicitudCambio solicitudCambio = CrearSolicitud();

            SolicitudCambioControladora.Agregar(solicitudCambio);

            OnEventoGrabo();
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