using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TMD.Entidades;
using TMD.SD.LogicaNegocio_Atencion.Contrato;
using TMD.SD.LogicaNegocio_Atencion.Implementacion;
using TMD.SD.AccesoDatos_Atencion.Implementacion;  


namespace ServiceDesk.Atenciones
{
    public partial class Atenciones : System.Web.UI.Page
    {
        static string accion;
        protected void Page_Load(object sender, EventArgs e)
        {
  
            if (!Page.IsPostBack)
            {
                OnInitPage();
            }
        }

        private void OnInitPage()
        {
            //Habilitar opciones 
            if (Request.QueryString["accion"] != "" && Request.QueryString["accion"]!=null) accion = Request.QueryString["accion"];


            if (accion == "n")
            {
                lnkNuevoTicket.Visible = true;
                btnCambioEstado.Visible = false;
                btnAdjuntarDocumentacion.Visible = true;
                btnEditar.Visible = true;
            }
            else
            {
                lnkNuevoTicket.Visible = false;
                btnCambioEstado.Visible = true;
                btnAdjuntarDocumentacion.Visible = false;
                btnEditar.Visible = false;
            }

            onCargarAnalistas();
            onCargarEspecialistas();
            onCargarEstados();
            onCargarTipoTicket();
            onCargarTickets();
        }

        private void onCargarEstados()
        {
            cmbEstado.Items.Add("Abierto");
            cmbEstado.Items.Add("Asignado");
            cmbEstado.Items.Add("En Proceso");
            cmbEstado.Items.Add("Solucionado");

        }

        private void onCargarTipoTicket()
        {
            LstTipoTicket.Items.Add("Incidente");
            LstTipoTicket.Items.Add("Problema");
            LstTipoTicket.Items.Add("Requerimiento");

        }

        protected void btnBuscarAnalista_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Vistas/SD/Selecciones/SeleccionarIntegrante.aspx");
           
        }

        protected void onCargarAnalistas()
        {
            IIntegranteLogica integrante = new IntegranteLogica(new IntegranteData("TMD"));

            cmbAnalistas.DataSource = integrante.listaIntegrantesCompleta("ANALISTA");
            cmbAnalistas.DataTextField = "NOMBRE_EMPLEADO_PROYECTO";
            cmbAnalistas.DataValueField = "Codigo_Integrante";
            cmbAnalistas.DataBind();
        }

        protected void onCargarEspecialistas()
        {
            IIntegranteLogica integrante = new IntegranteLogica(new IntegranteData("TMD"));

            


            cmbEspecialistas.DataSource = integrante.listaIntegrantesCompleta("ESPECIALISTA");
            cmbEspecialistas.DataTextField = "NOMBRE_EMPLEADO_PROYECTO";
            cmbEspecialistas.DataValueField = "Codigo_Integrante";
            cmbEspecialistas.DataBind();
            cmbEspecialistas.SelectedIndex = -1;
        }
        private void onCargarTickets()
        {

            ITicketLogica ticket = new TicketLogica(new TicketData("TMD"));
            DateTime FechaRegIni = new DateTime(2008, 3, 9, 16, 5, 7, 123);
            DateTime FechaRegFin = new DateTime(2016, 3, 9, 16, 5, 7, 123);

            int codigoAnalista = Convert.ToInt32( cmbAnalistas.SelectedValue);
            grdTickets.DataSource = ticket.listaTicketsIntegrante(codigoAnalista, LstTipoTicket.SelectedValue.ToUpper(),cmbEstado.Text.ToUpper()  , FechaRegIni, FechaRegFin); 
            //grdTickets.DataSource = ticket.listaTicketsIntegrante(1, 1, 1, "INCIDENTE", "ABIERTO", DateTime.Now, DateTime.Now) ; //"1900-01-01", "2035-12-31");
            grdTickets.DataBind(); 
            



        }

        

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
           // Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
           //"RegisterClientScriptBlockMethod", "<script>serverCall('hola')</script>");

            
            //Page.Literal1.Text = "<script>serverCall('Added at middle')</script>";
            
            onCargarTickets();
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string numeroTicket = "0";

            GridViewRow rowGrd = grdTickets.SelectedRow;

            if (rowGrd == null)
            {

                //Response.Write("<script type='text/javascript'> alert('Faltan prioridad') </script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "RegisterStartupScript", "<script>serverCall('Seleccione un registro')</script>");

            }
            else
            {
                numeroTicket = rowGrd.Cells[1].Text;
                Response.Redirect("~/Vistas/SD/Atenciones/NuevaAtencion.aspx?registro=M&nroticket=" + numeroTicket.ToString());
            }
        }

        protected void bntIngresarSolucion_Click(object sender, EventArgs e)
        {
            string numeroTicket = "0";

            GridViewRow rowGrd = grdTickets.SelectedRow;

            if (rowGrd == null)
            {
                
                //Response.Write("<script type='text/javascript'> alert('Faltan prioridad') </script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(),"RegisterStartupScript", "<script>serverCall('Seleccione un registro')</script>");             
            
            }
            else
            {
                numeroTicket = rowGrd.Cells[1].Text;
                Response.Redirect("~/Vistas/SD/Atenciones/IngresarSolucion.aspx?nroticket=" + numeroTicket.ToString());
            }
        }

        protected void btnAdjuntarDocumentacion_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "RegisterStartupScript", "<script>serverCall('Invocara a la opción adjuntar documentos')</script>");
        }

        protected void btnCambioEstado_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "RegisterStartupScript", "<script>serverCall('Invocara al cambio de estado')</script>");
        }

        protected void btnInfoSeguimiento_Click(object sender, EventArgs e)
        {

            string numeroTicket = "0";

            GridViewRow rowGrd = grdTickets.SelectedRow;

            if (rowGrd == null)
            {
                              
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Mensaje", "alert('Seleccione un ticket de atención');", true);
            }
            else
            {
                numeroTicket = rowGrd.Cells[1].Text;
                
                Response.Redirect("~/Vistas/SD/Atenciones/IngresarSeguimiento.aspx?nroticket=" + numeroTicket.ToString());
                //Response.Redirect("~/Vistas/SD/Atenciones/IngresarSeguimientos.aspx?nroticket=" + numeroTicket.ToString());
                
            }
        }

      

        



    }
}