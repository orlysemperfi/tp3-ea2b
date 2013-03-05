using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.Entidades;
using TMD.ACP.LogicaNegocios.Contrato;
using TMD.ACP.LogicaNegocios.Implementacion;
using TMD.Core;

namespace TMD.ACP.Site
{
    public partial class ListaPlanAuditoria : System.Web.UI.Page
    {
        private IAuditoriaLogica _auditoriaLogica;

        protected void Page_Load(object sender, EventArgs e)
        {
            _auditoriaLogica = new AuditoriaLogica();

            CargarControles();
        }

        private void CargarControles()
        {
            List<Auditoria> lstAuditorias = _auditoriaLogica.ListarPlanAuditorias(DateTime.Today.Year,EstadoAuditoria.Autorizado,EstadoAuditoria.Planificado);
            try
            {                
                gvAuditoria.DataSource = lstAuditorias;
                gvAuditoria.DataBind();
            }
            catch (Exception)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error al Realizar la Transacción";
                return;
            }
        }

        protected void gvAuditoria_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Auditoria oAudi = (Auditoria)e.Row.DataItem;
                    Literal l;
                    l = (Literal)e.Row.FindControl("ltrlIdaudi");
                    if (l != null) l.Text = Helper.Right("00000" + oAudi.IdAuditoria.ToString(), 5);

                    l = (Literal)e.Row.FindControl("ltrlEntAudi");
                    if (l != null) l.Text = oAudi.ObjEntidadAuditada.NombreEntidadAuditada;

                    l = (Literal)e.Row.FindControl("ltrlNomArea");
                    //if (l != null) l.Text = oAudi.ObjEntidadAuditada.ObjArea.NombreArea;
                    if (l != null) l.Text = oAudi.ObjEntidadAuditada.ObjArea.descripcion;

                    l = (Literal)e.Row.FindControl("ltrlFecIni");
                    if (l != null) l.Text = oAudi.FechaInicio.ToString("dd/MM/yyyy");

                    l = (Literal)e.Row.FindControl("ltrlFecFin");
                    if (l != null) l.Text = oAudi.FechaFin.ToString("dd/MM/yyyy");

                    l = (Literal)e.Row.FindControl("ltrlEst");
                    if (l != null) l.Text = oAudi.Estado;
                }
            }
            catch (Exception)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error al Realizar la Transacción";
                return;
            }
        }

        protected void gvAuditoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Seleccionar")
                {
                    gvAuditoria.SelectedIndex = gvAuditoria.Rows[Convert.ToInt32(e.CommandArgument)].RowIndex;
                }
                string sIdAuditoria = gvAuditoria.SelectedDataKey["idAuditoria"].ToString();                
                Response.Redirect("PlanAuditoria.aspx?idAuditoria=" + sIdAuditoria);
            }
            catch (Exception)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error al Realizar la Transacción";
                return;
            }
        }
    }
}