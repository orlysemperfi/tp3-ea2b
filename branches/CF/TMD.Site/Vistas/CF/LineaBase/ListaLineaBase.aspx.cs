using System;
using System.Web.UI.WebControls;
using TMD.CF.Site.Controladora.CF;
using TMD.CF.Site.Util;
using TMD.Strings;

namespace TMD.CF.Site.Vistas.CF.LineaBase
{
    public partial class ListaLineaBase : System.Web.UI.Page
    {

        protected int esCarga;

        protected void Page_Load(object sender, EventArgs e)
        {

            string carga = Request.QueryString["carga"];
            int.TryParse(carga, out esCarga);            

            if (!Page.IsPostBack)
            {
                ddlProyecto.DataSource = new LineaBaseControladora().ListarProyectoPorUsuario(SesionFachada.Usuario.Id);
                ddlProyecto.DataValueField = "Id";
                ddlProyecto.DataTextField = "Nombre";
                ddlProyecto.DataBind();
            }
            
            btnNuevo.Visible = SesionFachada.Usuario.Rol == Roles.GestorConfiguracion;

            if (SesionFachada.Usuario.Rol != Roles.GestorConfiguracion && !String.IsNullOrEmpty(carga) && carga.Equals("0"))
            {
                Response.Redirect(Pagina.NoPermitido);
            }
            else if (SesionFachada.Usuario.Rol != Roles.ResponsableElemento && !String.IsNullOrEmpty(carga) && carga.Equals("1"))
            {
                Response.Redirect(Pagina.NoPermitido);
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format(Pagina.ActLineaBaseEscritura, ddlProyecto.SelectedValue));
        }

        protected void grvLineaBase_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ruta = (esCarga == 0) ? "ActualizarLineaBase" : "ActualizarECS";
            
            switch (e.CommandName)
            {
                case "Actualizar":
                    Response.Redirect(String.Format(Pagina.ActualizarPagina, ddlProyecto.SelectedValue,e.CommandArgument,ruta));
                    break;
                case "Ver":
                    Response.Redirect(String.Format(Pagina.ActLineaBaseLectura, ddlProyecto.SelectedValue, e.CommandArgument));
                    break;
                default:
                    break;
            }
        }

        protected void grvLineaBase_DataBound(object sender, EventArgs e)
        {
            grvLineaBase.Columns[1].Visible = esCarga == 0;
            grvLineaBase.Columns[0].Visible = 
                esCarga == 0 ? (SesionFachada.Usuario.Rol == Roles.GestorConfiguracion ? true : false) : (SesionFachada.Usuario.Rol == Roles.ResponsableElemento ? true : false);
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            grvLineaBase.DataSource = new LineaBaseControladora().LineaBaseListarPorProyecto(Convert.ToInt32(ddlProyecto.SelectedValue));
            grvLineaBase.DataBind();
        }
    }
}