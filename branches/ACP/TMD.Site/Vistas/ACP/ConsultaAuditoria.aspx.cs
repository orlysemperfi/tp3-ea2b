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
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarControles();
        }

        private void CargarControles()
        {
            litPeriodo.Text = Convert.ToString(DateTime.Today.Year);
            Auditoria oFiltroAuditoria = new Auditoria();
            oFiltroAuditoria.AnhoAuditoria = DateTime.Today.Year;
            oFiltroAuditoria.Estado = EstadoAuditoria.Planificado;
            oFiltroAuditoria.IdAuditoria = null;
            oFiltroAuditoria.IndCheckListEstablecido = true;
            List<Auditoria> lstAuditorias = TMD.Site.Controladora.ACP.AuditoriaControladora.ObtenerPlanAuditoriaPorID(oFiltroAuditoria);

            try
            {
                //TODO: CARGAR GRILLA de AUDITORIAS: La lista de audorias ya está cargada hasta este punto
                gvAuditoria.DataSource = lstAuditorias;
                gvAuditoria.DataBind();
            }
            catch (Exception ex)
            {            
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
                    if (l != null) l.Text = oAudi.IdAuditoria.ToString();

                    l = (Literal)e.Row.FindControl("ltrlEntAudi");
                    if (l != null) l.Text = oAudi.ObjEntidadAuditada.NombreEntidadAuditada;

                    l = (Literal)e.Row.FindControl("ltrlNomArea");
                    if (l != null) l.Text = oAudi.ObjEntidadAuditada.ObjArea.descripcion;

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
                Response.Redirect("ActualizarHallazgo.aspx?idAuditoria=" +
                    sIdAuditoria);

            }
            catch (Exception ex)
            {               
                return;
            }
        }

    }
}
