using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TMD.ACP.Site
{
    public partial class PlanMantenimientoNuevo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void CargaEquipos()
        {
           
        }


        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        

        protected void imbBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargaEquipos();
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtPlan.Text == "" )
            //    {
            //        Util.Util.AlternarMensaje(false, "Debe ingresar el nombre del plan. Por favor verifique.", divError, divExito, lblMensajeError, lblMensajeExito);
            //        return;
            //    }

            //    if (!Util.Util.EsFechaValida(txtFechaInicio.Text))
            //    {
            //        Util.Util.AlternarMensaje(false, "La fecha de inicio ingresada no tiene el formato adecuado. dd/MM/aaaa", divError, divExito, lblMensajeError, lblMensajeExito);
            //        return;
            //    }
            //    if (!Util.Util.EsFechaValida(txtFechaFin.Text))
            //    {
            //        Util.Util.AlternarMensaje(false, "La fecha de fin ingresada no tiene el formato adecuado. dd/MM/aaaa", divError, divExito, lblMensajeError, lblMensajeExito);
            //        return;
            //    }


            //}
            //catch (Exception ex)
            //{
            //    Util.Util.AlternarMensaje(false, "Ocurrió el siguiente error: " + ex.Message, divError, divExito, lblMensajeError, lblMensajeExito);
            //}
        }

        protected void imbBuscaEquipo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imbNuevoEquipo_Click(object sender, ImageClickEventArgs e)
        {

        }

    }
}