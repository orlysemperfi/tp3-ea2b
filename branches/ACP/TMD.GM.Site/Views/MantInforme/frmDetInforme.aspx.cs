using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.GM.Entidades;
using TMD.GM.LogicaNegocios.Contrato;
using TMD.GM.LogicaNegocios.Implementacion;
using System.Data;

namespace Web.MantInforme
{
    public partial class frmDetInforme : System.Web.UI.Page
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
                ddlEmpleado.Items.Insert(0, "-- SELECCIONE --");
                ddlEmpleado.Items[0].Value = "0";

                if (Session["InformeAccion"].ToString() == "U")
                {
                    txtNumero.Text = Session["NUMERO_INFORME"].ToString();
                    ddlEmpleado.SelectedValue = Session["CODIGO_EMPLEADO"].ToString();
                    txtObservacion.Text = Session["OBSERVACION_EMPLEADO"].ToString();
                    txtFecha.DateString = Session["FECHA"].ToString();

                    IInformesBL inf = new InformesBL();
                    DataTable oDT = inf.ObtenerInformes_Orden(Convert.ToInt32(Session["CODIGO_EMPLEADO"].ToString()));
                    gvInformes.DataSource = oDT;
                    gvInformes.DataBind();

                    ddlEmpleado.Enabled = false;
                }
                else
                {
                    txtNumero.Text = "";
                    ddlEmpleado.SelectedValue = "0";
                    txtObservacion.Text = "";
                    txtFecha.DateString = "";
                }
                
            }
        }

        protected void ddlEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            IInformesBL inf = new InformesBL();
            DataTable oDT = inf.ObtenerInformes_Orden(Convert.ToInt32(ddlEmpleado.SelectedValue));
            gvInformes.DataSource = oDT; 
            gvInformes.DataBind();

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmMantInforme.aspx");
        }

        protected void gvInformes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = (GridView)e.Row.FindControl("gvInformesDet");
                DataKey dk = gvInformes.DataKeys[e.Row.RowIndex];
                string orden = Convert.ToString(dk["NUMERO_ORDEN"]);
                
                IInformesBL inf = new InformesBL();
                DataTable oDT=null;
                if (Session["InformeAccion"].ToString() == "I")
                {
                    oDT = inf.Obtener_OrdenDetalle(orden);
                }
                else
                {
                    oDT = inf.ObtenerInformes_OrdenDetalle(orden, Convert.ToInt32(Session["NUMERO_INFORME"].ToString()));
                }
                gv.DataSource = oDT;
                gv.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Session["InformeAccion"].ToString() == "I")
            {
                IInformesBL inf = new InformesBL();
                int numero = inf.Informes_Orden_Insertar(txtFecha.Date, Convert.ToInt32(ddlEmpleado.SelectedValue), txtObservacion.Text.Trim());
                txtNumero.Text = numero.ToString();

                for (int i = 0; i < gvInformes.Rows.Count; i++)
                {
                    DataKey dkOrd = gvInformes.DataKeys[i];
                    string orden = Convert.ToString(dkOrd["NUMERO_ORDEN"]);

                    GridView gvInformesDet = (GridView)gvInformes.Rows[i].FindControl("gvInformesDet");
                    for (int j = 0; j < gvInformesDet.Rows.Count; j++)
                    {
                        TextBox txtResultado = (TextBox)gvInformesDet.Rows[j].FindControl("txtResultado");
                        DataKey dk = gvInformesDet.DataKeys[j];
                        inf.Informes_Orden_Insertar_Detalle(numero, j + 1, orden, Convert.ToInt32(dk["ITEM_ORDEN"]), txtResultado.Text.Trim());
                    }
                }
                Session["NUMERO_INFORME"] = numero;
                Session["InformeAccion"] = "U";
            }
            else
            {
                IInformesBL inf = new InformesBL();
                int numero = Convert.ToInt32(Session["NUMERO_INFORME"].ToString());
                inf.Informes_Orden_Actualizar(numero, txtFecha.Date, Convert.ToInt32(ddlEmpleado.SelectedValue), txtObservacion.Text.Trim());
                
                inf.Informes_Orden_Eliminar_Detalle(numero);

                for (int i = 0; i < gvInformes.Rows.Count; i++)
                {
                    DataKey dkOrd = gvInformes.DataKeys[i];
                    string orden = Convert.ToString(dkOrd["NUMERO_ORDEN"]);

                    GridView gvInformesDet = (GridView)gvInformes.Rows[i].FindControl("gvInformesDet");
                    for (int j = 0; j < gvInformesDet.Rows.Count; j++)
                    {
                        TextBox txtResultado = (TextBox)gvInformesDet.Rows[j].FindControl("txtResultado");
                        DataKey dk = gvInformesDet.DataKeys[j];
                        inf.Informes_Orden_Insertar_Detalle(numero, j + 1, orden, Convert.ToInt32(dk["ITEM_ORDEN"]), txtResultado.Text.Trim());
                    }
                }
            }
            
            // eliminar el detalle
            //insertar detalle
            //modificar la observacion en det ordenes trabajo


        }
    }
}