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
    public partial class frmEmpEspecialidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IEspecialidadBL esp = new EspecialidadBL();
                ddlEspecialidad.DataSource = esp.ObtenerEspecialidades();
                ddlEspecialidad.DataValueField = "CODIGO_TIPO_ACTIVIDAD";
                ddlEspecialidad.DataTextField = "DESCRIPCION_TIPO_ACTIVIDAD";
                ddlEspecialidad.DataBind();

                int codigo_empleado = Convert.ToInt32(Session["codigo_empleado"].ToString());
                string nombre_empleado = Session["nombre_empleado"].ToString();

                lblEmpleado.Text = nombre_empleado;

                IEspecialidadBL espemp = new EspecialidadBL();
                List<EspecialidadBE> lista = espemp.ObtenerEspecialidadesxEmp(codigo_empleado);
                gvEspecialidades.DataSource = lista;
                gvEspecialidades.DataBind();

            }
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            int codigo_actividad = Convert.ToInt32(ddlEspecialidad.SelectedValue);
            int codigo_empleado = Convert.ToInt32(Session["codigo_empleado"].ToString());

            IEmpleadosBL emp = new EmpleadosBL();
            string mensaje ="";
            bool registrado = false;
            List<EspecialidadBE> lista = emp.RegistrarActividad(codigo_empleado, codigo_actividad, ref mensaje, ref registrado);

            if (registrado)
            {
                gvEspecialidades.DataSource = lista;
                gvEspecialidades.DataBind();

            }

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmMantEmpleado.aspx");
        }

        protected void gvEspecialidades_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int codigo_actividad = Convert.ToInt32(e.Keys["CODIGO_TIPO_ACTIVIDAD"].ToString());
            int codigo_empleado = Convert.ToInt32(Session["codigo_empleado"].ToString());

            IEmpleadosBL emp = new EmpleadosBL();
            emp.Eliminar_Actividad_Empleado(codigo_empleado, codigo_actividad);

            IEspecialidadBL espemp = new EspecialidadBL();
            List<EspecialidadBE> lista = espemp.ObtenerEspecialidadesxEmp(codigo_empleado);
            gvEspecialidades.DataSource = lista;
            gvEspecialidades.DataBind();
        }

        protected void gvEspecialidades_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox check = (CheckBox)e.Row.FindControl("CheckBox1");
                DataKey dk = gvEspecialidades.DataKeys[e.Row.RowIndex];
                bool especialidad = Convert.ToBoolean( dk["ESPECIALIDAD"]);
                check.Checked = especialidad;
            }
        }

        protected void CheckBox1_OnCheckedChanged(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((Control)sender).NamingContainer;
            DataKey dk = gvEspecialidades.DataKeys[row.RowIndex];
            IEmpleadosBL emp = new EmpleadosBL();

            int codigo_actividad = Convert.ToInt32(dk["CODIGO_TIPO_ACTIVIDAD"].ToString());
            int codigo_empleado = Convert.ToInt32(Session["codigo_empleado"].ToString());
            bool especialidad = ((CheckBox)sender).Checked;
            emp.Especialidad_Actividad_Empleado(codigo_empleado, codigo_actividad, especialidad);

        }

    }
}