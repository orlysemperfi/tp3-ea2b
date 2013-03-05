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
        IEmpleadoLogica _empleadoLogica;

        protected void Page_Load(object sender, EventArgs e)
        {
            _empleadoLogica = new EmpleadoLogica();
            CargarEmpleados();

        }

        private void CargarEmpleados()
        {                        
            List<EmpleadoEntidad> lstEmpleados = _empleadoLogica.ListarEmpleados();
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

                //lblNombres.Text = eEmpleado.nombres;
                //lblApePaterno.Text = eEmpleado.apepat;
                //lblApeMaterno.Text = eEmpleado.apemat;
                //lblArea.Text = eEmpleado.ObjArea.NombreArea;

                lblNombres.Text = eEmpleado.nombre;
                lblApePaterno.Text = eEmpleado.apellidopaterno;
                lblApeMaterno.Text = eEmpleado.apellidomaterno;
                lblArea.Text = "AREA";
            }
        }

    }
}