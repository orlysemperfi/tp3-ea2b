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

namespace TMD.CF.Site.Vistas.SD.Atenciones
{
    public partial class EscalarTicket : System.Web.UI.Page
    {
        
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

            Session["CodigoCliente"] = 0;
            Session["CodigoServicio"] = 0;
            Session["CodigoProyecto"] = 0;
            Session["CodigoSede"] = 0;

            //Cargar la info del ticket
            numeroTicket = Convert.ToInt32(Request.QueryString["nroticket"]);
            onCargarTicket(numeroTicket);

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["CodigoCliente"] = 0;
            Session["CodigoServicio"] = 0;
            Session["CodigoProyecto"] = 0;
            Session["CodigoSede"] = 0;

            Response.Redirect("~/Vistas/SD/Atenciones/Atenciones.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            if (Page.IsValid == false)
            {
                return;
            }

            ITicketLogica ticket = new TicketLogica(new TicketData("TMD"));
            Ticket datosTicket = ticket.datosTicket(numeroTicket);

            int codigoEspecialistaCambio = SesionFachada.Usuario.Id;
            int codigoEspecialistaNuevo = Convert.ToInt32(cmbEspecialista.SelectedValue); 

               datosTicket.Codigo_Integrante = codigoEspecialistaNuevo;
               datosTicket.Ultimo_Seguimiento =  datosTicket.Ultimo_Seguimiento + 1;
               ticket.escalarTicketEspecialista (datosTicket );

               //Registrar Seguimiento

               SeguimientoTicket seguimientoTicket;
                seguimientoTicket = new SeguimientoTicket { Codigo_Ticket = numeroTicket, Descripcion_Seguimiento = txtComentario.Text   , 
                             Codigo_Seguimiento =datosTicket.Ultimo_Seguimiento, Codigo_Equipo = datosTicket.Codigo_Equipo , Codigo_Integrante = codigoEspecialistaCambio, Fecha_Registro = DateTime.Now,Tipo_Seguimiento="ESCALAMIENTO" };
                ticket.registrarSeguimiento (seguimientoTicket);
            

                Response.Redirect("~/Vistas/SD/Atenciones/Atenciones.aspx");
       
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
            Session["CodigoCliente"] = datosTicket.Codigo_Cliente;
            Session["CodigoProyecto"] = datosTicket.Codigo_Proyecto;
            Session["CodigoServicio"] = datosTicket.Codigo_Servicio ;
            Session["CodigoSede"] = datosTicket.Codigo_Sede;
 
            onCargarEspecialistas();

          

        }


        private void onCargarEspecialistas()
        {
            //Obtener proyectos del usario-cliente - Servicio
            IIntegranteLogica integrante = new IntegranteLogica(new IntegranteData("TMD"));
            int codigoSede = Convert.ToInt32(Session["CodigoSede"]);
            int codigoProyecto = Convert.ToInt32(Session["CodigoProyecto"]);
            int codigoServicio = Convert.ToInt32(Session["CodigoServicio"]);
            ProyectoServicioSede datosServicioSLA = new ProyectoServicioSede();

            cmbEspecialista.DataSource = integrante.listaEspecialistaProyectoServicioSedeCarga(codigoProyecto, codigoServicio, codigoSede);
            cmbEspecialista.DataTextField = "NOMBRE_NIVEL_CARGA";
            cmbEspecialista.DataValueField = "CODIGO_INTEGRANTE";
            cmbEspecialista.DataBind();
            
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 20;
        }

    }
}