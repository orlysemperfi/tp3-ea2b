using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.GM.Entidades;
using TMD.GM.LogicaNegocios.Contrato;
using TMD.GM.LogicaNegocios.Implementacion;

namespace Web.MantInforme
{
    public partial class frmMantInforme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IEmpleadosBL emp = new EmpleadosBL();
                ddlEmpleado.DataSource = emp.ObtenerEmpleados("");
                ddlEmpleado.DataValueField = "CODIGO_EMPLEADO";
                ddlEmpleado.DataTextField = "NOMBRE_COMPLETO";
                ddlEmpleado.DataBind();
                ddlEmpleado.Items.Insert(0, "-- TODOS --");
                ddlEmpleado.Items[0].Value = "0";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            IInformesBL inf = new InformesBL();
            int numero = txtNumero.Text.Trim() == "" ? 0 : Convert.ToInt32(txtNumero.Text.Trim());
            gvInformes.DataSource = inf.ObtenerInformes(numero, Convert.ToInt32(ddlEmpleado.SelectedValue), txtObservacion.Text.Trim(), txtFecha.Date);
            gvInformes.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Session["InformeAccion"] = "I";
            Response.Redirect("frmDetInforme.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (gvInformes.SelectedIndex >= 0)
            {
                Session["InformeAccion"] = "U";
                Response.Redirect("frmDetInforme.aspx");
            }
        }

        protected void gvInformes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataKey dk = gvInformes.DataKeys[gvInformes.SelectedIndex];
            string numero = dk["NUMERO_INFORME"].ToString();
            string codigo = dk["CODIGO_EMPLEADO"].ToString();
            string observacion = dk["OBSERVACION_EMPLEADO"].ToString();
            string fecha = dk["FECHA"].ToString();

            Session["NUMERO_INFORME"] = numero;
            Session["CODIGO_EMPLEADO"] = codigo;
            Session["OBSERVACION_EMPLEADO"] = observacion;
            Session["FECHA"] = fecha;

        }
    }
}