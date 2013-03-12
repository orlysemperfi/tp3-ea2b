using System;
using System.Linq;
using TMD.CF.Site.Controladora.CF;
using TMD.CF.Site.Util;
using TMD.Core.Extension;
using TMD.Entidades;
using TMD.Core;

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
        }

        private void CargarControles()
        {
            ddlProyecto.EnlazarDatos(LineaBaseControladora.ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id");
            ddlLineaBase.EnlazarValorDefecto();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grvOrdenCambio.DataSource =
                OrdenCambioControladora.ListarPorProyectoLBase(ddlProyecto.SelectedValue.ToInt(), ddlLineaBase.SelectedValue.ToInt());
            grvOrdenCambio.DataBind();
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLineaBase.EnlazarDatos(LineaBaseControladora.LineaBaseListarPorProyectoCombo(ddlProyecto.SelectedValue.ToInt()), "Nombre", "Id");
        }
    }
}