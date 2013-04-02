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
    public partial class ConsultarEntidadAuditada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ids = Request.QueryString[0];
            CargarEntidadAuditada();
        }

        private void CargarEntidadAuditada()
        {            
            try
            {
                List<EntidadAuditada> lstEntidadAuditada = TMD.Site.Controladora.ACP.AuditoriaControladora.ListarEntidadesAuditadas();
                rptEntidadAuditada.DataSource = lstEntidadAuditada;
                rptEntidadAuditada.DataBind();
            }
            catch (Exception)
            {                
                return;
            }
        }

        protected void rptEntidadAuditada_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.Item) {

                EntidadAuditada eEntidadAuditada = (EntidadAuditada)e.Item.DataItem;

                Label lblNroEntAud = (Label)e.Item.FindControl("lblNroEntAud");
                Label lblEntiAud = (Label)e.Item.FindControl("lblEntiAud");
                Label lblArea = (Label)e.Item.FindControl("lblArea");
                Label lblCriticidad = (Label)e.Item.FindControl("lblCriticidad");
                Label lblRiesgo = (Label)e.Item.FindControl("lblRiesgo");
                Label lbllblAlcanceArea = (Label)e.Item.FindControl("lblAlcance");
                Label lblNroSeguimiento = (Label)e.Item.FindControl("lblNroSeguimiento");
                Label lblNroAuditorias = (Label)e.Item.FindControl("lblNroAuditorias");
                Label lblPuntaje = (Label)e.Item.FindControl("lblPuntaje");

                lblNroEntAud.Text = eEntidadAuditada.IdEntidadAuditada.ToString();
                lblEntiAud.Text = eEntidadAuditada.NombreEntidadAuditada;
                lblArea.Text = eEntidadAuditada.ObjArea.descripcion;
                lblCriticidad.Text = eEntidadAuditada.criticidad.ToString();
                lblRiesgo.Text = eEntidadAuditada.riesgo.ToString();
                lbllblAlcanceArea.Text = eEntidadAuditada.alcance.ToString();
                lblNroSeguimiento.Text = eEntidadAuditada.nroseguimiento.ToString();
                lblNroAuditorias.Text = eEntidadAuditada.nroauditorias.ToString();
                lblPuntaje.Text = eEntidadAuditada.puntaje.ToString();
            }
        }
    }
}