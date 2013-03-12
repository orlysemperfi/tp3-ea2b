using System;
using System.Web.UI.WebControls;
using TMD.CF.Site.Controladora.CF;
using TMD.CF.Site.Util;

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

            btnNuevo.Visible = esCarga == 0;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grvLineaBase.DataSource = new LineaBaseControladora().LineaBaseListarPorProyecto(Convert.ToInt32(ddlProyecto.SelectedValue));
            grvLineaBase.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("ActualizarLineaBase.aspx?idProyecto={0}&idFase=0&lectura=0",ddlProyecto.SelectedValue));
        }

        protected void grvLineaBase_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ruta = (esCarga == 0) ? "ActualizarLineaBase" : "ActualizarECS";
            
            switch (e.CommandName)
            {
                case "Actualizar":
                    Response.Redirect(String.Format("{2}.aspx?idProyecto={0}&idFase={1}&lectura=0", ddlProyecto.SelectedValue,e.CommandArgument,ruta));
                    break;
                case "Ver":
                    Response.Redirect(String.Format("ActualizarLineaBase.aspx?idProyecto={0}&idFase={1}&lectura=1", ddlProyecto.SelectedValue, e.CommandArgument));
                    break;
                default:
                    break;
            }
        }

        protected void grvLineaBase_DataBound(object sender, EventArgs e)
        {
            grvLineaBase.Columns[1].Visible = esCarga == 0;
        }
    }
}