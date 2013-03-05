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
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace TMD.ACP.Site
{
    public partial class _ConsultaAuditoria : System.Web.UI.Page
    {
        private IAuditoriaLogica _auditoriaLogica;

        protected void Page_Load(object sender, EventArgs e)
        {
            _auditoriaLogica = new AuditoriaLogica();

            CargarControles();
        }

        private void CargarControles()
        {
            Auditoria oFiltroAuditoria = new Auditoria();
            oFiltroAuditoria.AnhoAuditoria = DateTime.Today.Year;
            oFiltroAuditoria.Estado = EstadoAuditoria.Planificado;
            oFiltroAuditoria.IdAuditoria = null;
            oFiltroAuditoria.IndCheckListEstablecido = true;
            List<Auditoria> lstAuditorias = _auditoriaLogica.Obtener(oFiltroAuditoria);

            try
            {
                //TODO: CARGAR GRILLA de AUDITORIAS: La lista de audorias ya está cargada hasta este punto
                gvAuditoria.DataSource = lstAuditorias;
                gvAuditoria.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "WebSiteExceptionPolicy");
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
                    if (l != null) l.Text = "AREA";

                    l = (Literal)e.Row.FindControl("ltrlFecIni");
                    if (l != null) l.Text = oAudi.FechaInicio.ToString("dd/MM/yyyy");

                    l = (Literal)e.Row.FindControl("ltrlFecFin");
                    if (l != null) l.Text = oAudi.FechaFin.ToString("dd/MM/yyyy");

                    l = (Literal)e.Row.FindControl("ltrlEst");
                    if (l != null) l.Text = oAudi.Estado;
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "WebSiteExceptionPolicy");
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error al Realizar la Transacción"; 
                return;
            }
        }

        protected void gvAuditoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Hallazgo")
                {
                    gvAuditoria.SelectedIndex = gvAuditoria.Rows[Convert.ToInt32(e.CommandArgument)].RowIndex;
                }
                string sIdAuditoria = gvAuditoria.SelectedDataKey["idAuditoria"].ToString();
                Response.Redirect("MantenerHallazgo.aspx?idAuditoria=" +
                    sIdAuditoria);

            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "WebSiteExceptionPolicy");
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error al Realizar la Transacción"; 
                return;
            }
        }

    }
}
