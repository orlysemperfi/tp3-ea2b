using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using TMD.Entidades;
using TMD.ACP.LogicaNegocios.Contrato;
using TMD.ACP.LogicaNegocios.Implementacion;
using TMD.Core;

namespace TMD.ACP.Site
{
    public partial class ListaPlanAccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarControles();
        }

        private void CargarControles()
        {
            List<Hallazgo> lstHallazgos = TMD.Site.Controladora.ACP.HallazgoControladora.ListarPlanAccion(DateTime.Today.Year);
            try
            {
                litPeriodo.Text = Convert.ToString(DateTime.Today.Year);
                gvHallazgo.DataSource = lstHallazgos;
                gvHallazgo.DataBind();
            }
            catch (Exception)
            {
                //lblError.ForeColor = System.Drawing.Color.Red;
                //lblError.Text = "Error al Realizar la Transacción";
                //return;
            }
        }

        protected void gvHallazgo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Seleccionar")
                {
                    gvHallazgo.SelectedIndex = gvHallazgo.Rows[Convert.ToInt32(e.CommandArgument)].RowIndex;
                }
                string sIdHallazgo = gvHallazgo.SelectedDataKey["idHallazgo"].ToString();
                Response.Redirect("ActualizarPlanAccion.aspx?idHallazgo=" + sIdHallazgo);
            }
            catch (Exception)
            {
                //lblError.ForeColor = System.Drawing.Color.Red;
                //lblError.Text = "Error al Realizar la Transacción";
                //return;
            }
        }

        protected void gvHallazgo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Hallazgo oHallazgo = (Hallazgo)e.Row.DataItem;
                    Literal l;

                    l = (Literal)e.Row.FindControl("ltrlIdHallazgo");
                    if (l != null) l.Text = oHallazgo.IdHallazgo.ToString();

                    l = (Literal)e.Row.FindControl("ltrlIdaudi");
                    if (l != null) l.Text = oHallazgo.IdAuditoria.ToString();

                    l = (Literal)e.Row.FindControl("ltrlPregunta");
                    if (l != null) l.Text = oHallazgo.DescripcionPregunta;

                    l = (Literal)e.Row.FindControl("ltrlHallazgo");
                    if (l != null) l.Text = oHallazgo.Descripcion;

                    l = (Literal)e.Row.FindControl("ltrlDocumentos");
                    if (l != null) l.Text = oHallazgo.nDoc.ToString();
                    
                    l = (Literal)e.Row.FindControl("ltrlTipo");
                    if (l != null) l.Text = oHallazgo.TipoHallazgo;

                    l = (Literal)e.Row.FindControl("ltrlEst");
                    if (l != null) l.Text = oHallazgo.Estado;
                }
            }
            catch (Exception)
            {
                //lblError.ForeColor = System.Drawing.Color.Red;
                //lblError.Text = "Error al Realizar la Transacción";
                //return;
            }

        }        
    }
}