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

namespace TMD.CF.Site.Controles
{
    public partial class RegistroSolicitudCambio : System.Web.UI.UserControl
    {
        LineaBaseControladora _lineaBaseControladora = new LineaBaseControladora();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void CargarControles()
        {
            ddlProyecto.DataSource = null;
            ddlLineaBase.DataSource = null;
            ddlElementoConfiguracion.DataSource = null;
            ddlEstado.DataSource = null;
            ddlPrioridad.DataSource = null;
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlLineaBase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            SolicitudCambio solicitudCambio = CrearSolicitud();
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