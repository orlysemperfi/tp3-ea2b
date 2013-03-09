using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.CF.Site.Controladora.CF;
using TMD.CF.Site.Controladora;
using TMD.CF.Site.Util;
using TMD.Entidades;

namespace TMD.CF.Site.Vistas.CF.ControlCambio
{
    public partial class ListaSolicitudCambio : System.Web.UI.Page
    {

        protected int esCarga; 

        protected void Page_Load(object sender, EventArgs e)
        {

            string carga = Request.QueryString["carga"];
            int.TryParse(carga, out esCarga);

            if (!Page.IsPostBack)
            {
                ddlProyecto.DataSource = LineaBaseControladora.ListarProyectoPorUsuario(SesionFachada.Usuario.Id);
                ddlProyecto.DataValueField = "Id";
                ddlProyecto.DataTextField = "Nombre";
                ddlProyecto.DataBind();
            }

            //btnNuevo.Visible = esCarga == 0;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grvSolicitudCambio.DataSource = SolicitudCambioControladora.ListarPorProyectoLineaBase(new SolicitudCambio { });
            grvSolicitudCambio.DataBind();
        }
    }
}