using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.GM.Entidades;
using TMD.GM.LogicaNegocios.Contrato;
using TMD.GM.LogicaNegocios.Implementacion;

namespace Web.MantEmpleado
{
    public partial class frmMantEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            IEmpleadosBL emp = new EmpleadosBL();
            gvEmpleados.DataSource= emp.ObtenerEmpleados(txtNombres.Text.Trim());
            gvEmpleados.DataBind();

        }

        protected void btnNuevo0_Click(object sender, EventArgs e)
        {
            if(gvEmpleados.SelectedIndex>=0){
                Response.Redirect("frmEmpEspecialidad.aspx");
            }
        }

        protected void gvEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataKey dk = gvEmpleados.DataKeys[gvEmpleados.SelectedIndex];
            string codigo = dk["CODIGO_EMPLEADO"].ToString();            
            Session["codigo_empleado"] = codigo;

            string nombres = dk["NOMBRES"].ToString();
            string apepaterno = dk["APELLIDO_PATERNO"].ToString();
            string apematerno = dk["APELLIDO_MATERNO"].ToString();
            string nombre_empleado = apepaterno + " " + apematerno + ", " + nombres;
            Session["nombre_empleado"] = nombre_empleado;
        }
    }
}