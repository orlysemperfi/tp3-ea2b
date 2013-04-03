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
    public partial class ConsultarAuditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string strIds = Request.QueryString["ids"];
            __Ids.Value = strIds;
            CargarEmpleados();
        }

        private void CargarEmpleados()
        {
            List<EmpleadoEntidad> lstEmpleados = TMD.Site.Controladora.ACP.HallazgoControladora.ListarEmpleadosAuditores();
            try
            {
                rptEmpleados.DataSource = lstEmpleados;
                rptEmpleados.DataBind();
            }
            catch (Exception)
            {                
                return;
            }
        }

        protected void rptEmpleados_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.Item) {
                EmpleadoEntidad eEmpleado = (EmpleadoEntidad)e.Item.DataItem;

                Label lblNombres = (Label)e.Item.FindControl("lblNombres");
                Label lblApePaterno = (Label)e.Item.FindControl("lblApePaterno");
                Label lblApeMaterno = (Label)e.Item.FindControl("lblApeMaterno");
                Label lblArea = (Label)e.Item.FindControl("lblArea");
               
                lblNombres.Text = eEmpleado.nombre;
                lblApePaterno.Text = eEmpleado.apellidopaterno;
                lblApeMaterno.Text = eEmpleado.apellidomaterno;
                lblArea.Text = eEmpleado.ObjArea.descripcion;
            }
        }

    }
}