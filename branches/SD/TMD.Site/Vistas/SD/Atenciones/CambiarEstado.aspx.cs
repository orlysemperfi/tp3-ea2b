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
    public partial class CambiarEstado : System.Web.UI.Page
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

            //Cargar la info del ticket
            numeroTicket = Convert.ToInt32(Request.QueryString["nroticket"]);
            onCargarEstados();
            onCargarTicket(numeroTicket);

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
            txtUsuario.Text = datosTicket.Nombre_UsuarioCliente;
            txtEstadoActual.Text = datosTicket.Estado_Ticket;
            codigoEquipo = datosTicket.Codigo_Equipo;

            //Llenar la grilla
            grdEstados.DataSource = ticket.listaSeguimientos(datosTicket.Codigo_Ticket,"ESTADO");
            grdEstados.DataBind();


        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            ITicketLogica ticket = new TicketLogica(new TicketData("TMD"));
            Ticket datosTicket = ticket.datosTicket(numeroTicket);
            SeguimientoTicket seguimientoTicket;
            int codigoSeguimiento = 1;

            int codigoEspecialista = SesionFachada.Usuario.Id;
            if (txtMotivo.Text.Trim() == "")
            {
                lblMensaje.Text = "Debe ingresar una motivo del cambio de estado";
            }
            else if (cmbEstado.Text.Trim() == "Seleccione Estado")
            {
                lblMensaje.Text ="Debe seleccionar un estado";
            }
            else if (cmbEstado.Text.Trim() == "Cerrado" && txtEstadoActual.Text!= "SOLUCIONADO" )
            {
                lblMensaje.Text = "El ticket tiene que estar con el estado SOLUCIONADO";
            }
            else
            {
                lblMensaje.Text ="";

                //Actualizar estado del ticket


                //Grabar Seguimiento
                codigoSeguimiento = Convert.ToInt16(datosTicket.Ultimo_Seguimiento + 1);
                datosTicket.Estado_Ticket  = cmbEstado.Text.ToUpper();
                datosTicket.Ultimo_Seguimiento = codigoSeguimiento;
                ticket.cambiarEstadoTicket(datosTicket);

                seguimientoTicket = new SeguimientoTicket
                {
                    Codigo_Ticket = numeroTicket,
                    Descripcion_Seguimiento = txtMotivo.Text,
                    Codigo_Seguimiento = codigoSeguimiento,
                    Codigo_Equipo = codigoEquipo,
                    Codigo_Integrante = codigoEspecialista,
                    Fecha_Registro = DateTime.Now,
                    Tipo_Seguimiento = "ESTADO"
                };
                ticket.registrarSeguimiento(seguimientoTicket);
                Response.Redirect("~/Vistas/SD/Atenciones/Atenciones.aspx");
            }



        }

        protected void btnSalir_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Vistas/SD/Atenciones/Atenciones.aspx");
        }



        private void onCargarEstados()
        {
            cmbEstado.Items.Add("Seleccione Estado");
            cmbEstado.Items.Add("Abierto");
            cmbEstado.Items.Add("Asignado");
            cmbEstado.Items.Add("En Proceso");
            cmbEstado.Items.Add("Cerrado");
          

        }






    }
}