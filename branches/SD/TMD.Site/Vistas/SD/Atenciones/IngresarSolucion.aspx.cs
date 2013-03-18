using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

using TMD.Entidades;
using TMD.SD.LogicaNegocio_Atencion.Contrato;
using TMD.SD.LogicaNegocio_Atencion.Implementacion;
using TMD.SD.AccesoDatos_Atencion.Implementacion;

using TMD.CF.Site.Util;

namespace TMD.ServiceDesk.Site.Atenciones
{
    public partial class IngresarSolucion : System.Web.UI.Page
    {
        static string accionRegistro;

        static int numeroTicket;
        static int codigoEquipo;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                OnInitPage();
            }
        }

        private void OnInitPage()
        {

            lblMensaje.Text = "";     

            //Cargar la info del ticket
            numeroTicket = Convert.ToInt32(Request.QueryString["nroticket"]);
            onCargarTicket(numeroTicket);
            


        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vistas/SD/Atenciones/Atenciones.aspx");
        }

        protected void btnDocumentacion_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "RegisterStartupScript", "<script>serverCall('Invocara a la opción adjuntar documentos')</script>");
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            
            if (Page.IsValid == false)
            {
                return;
            }


            ITicketLogica ticket = new TicketLogica(new TicketData("TMD"));
            Ticket datosTicket = ticket.datosTicket(numeroTicket);

            int codigoEspecialista = SesionFachada.Usuario.Id;
            if (datosTicket.Estado_Ticket  == "SOLUCIONADO") 
            {
                lblMensaje.Text = "El ticket se encuentra con el estado solucionado";     
            }
            else if (datosTicket.Estado_Ticket != "EN PROCESO")
            {
                lblMensaje.Text = "El estado actual del ticket no permite registrar la solución";
            }
            else
            {
                lblMensaje.Text = "";
                ticket.registrarSolucion(numeroTicket, txtSolucion.Text, codigoEquipo, codigoEspecialista);
                Response.Redirect("~/Vistas/SD/Atenciones/Atenciones.aspx");
            }
        }

        private void onCargarTicket(int numeroTicket)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            
            ITicketLogica ticket = new TicketLogica(new TicketData("TMD"));
            Ticket datosTicket = ticket.datosTicket(numeroTicket);

            txtNroTicket.Text = datosTicket.Codigo_Ticket.ToString();
            txtFechaRegistro.Text = datosTicket.Fecha_Expiracion.ToString();
            txtDescripcionBreve.Text = datosTicket.Descripcion_Corta;
            txtTipoTicket.Text = myTI.ToTitleCase(datosTicket.Tipo_Atencion_Ticket.ToLower());
            txtAnalista.Text = datosTicket.Empleado_Propietario;
            txtEspecialista.Text = datosTicket.Empleado_Asignado;
            txtUsuario.Text = datosTicket.Nombre_UsuarioCliente;
            txtServicio.Text = datosTicket.Nombre_Servicio;
            codigoEquipo = datosTicket.Codigo_Equipo;

            if (datosTicket.Estado_Ticket=="SOLUCIONADO" ) 
            {
                txtSolucion.Text = datosTicket.Solucion_Ticket;
                txtSolucion.ReadOnly = true;
                btnGrabar.Enabled = false; 
 
            }
            
        }

        protected void btnBDC_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "RegisterStartupScript", "<script>serverCall('Invocara a la consulta de Base del Conocimiento')</script>");
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 20;
        }

    }
}