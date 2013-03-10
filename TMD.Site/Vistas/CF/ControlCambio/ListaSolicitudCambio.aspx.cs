using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.CF.Site.Controladora.CF;
using TMD.CF.Site.Controladora;
using TMD.CF.Site.Util;
using TMD.Core.Extension;
using TMD.Entidades;

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
        }

        private void CargarControles()
        {
            ddlProyecto.EnlazarDatos(LineaBaseControladora.ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id");
            ddlLineaBase.EnlazarValorDefecto();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grvSolicitudCambio.DataSource = SolicitudCambioControladora.ListarPorProyectoLineaBase(ddlProyecto.SelectedValue.ToInt(), ddlLineaBase.SelectedValue.ToInt());
            grvSolicitudCambio.DataBind();
        }

        public String RecueprarEstadoNombre(int idEstado)
        {
            var estado = SolicitudCambioControladora.ListarEstado().FirstOrDefault(x => x.Id == idEstado);
            if (estado != null)
            {
                return estado.Nombre;
            }
            return null;
        }

        public String RecueprarEstadoImagen(int idEstado)
        {
            return String.Format("~/Imagenes/Estado/{0}.jpg", idEstado);
        }

        public String RecueprarPrioridadNombre(int idPrioridad)
        {
            var prioridad = SolicitudCambioControladora.ListarPrioridad().FirstOrDefault(x => x.Id == idPrioridad);
            if (prioridad != null)
            {
                return prioridad.Nombre;
            }
            return null;
        }

        public String RecueprarPrioridadImagen(int idPrioridad)
        {
            return String.Format("~/Imagenes/Prioridad/{0}.jpg", idPrioridad);
        }
    }
}