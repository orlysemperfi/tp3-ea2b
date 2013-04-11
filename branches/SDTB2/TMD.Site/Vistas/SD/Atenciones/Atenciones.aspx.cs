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
            else
            {
                Onactualizarpagina();
            }

        }

        private void OnInitPage()
        {

            if (Session["Mensaje"] == null) Session["Mensaje"] = "";
                
            lblMensaje.Text = Session["Mensaje"].ToString() ;

            //Habilitar opciones 
            if (Request.QueryString["accion"] != "" && Request.QueryString["accion"]!=null) accion = Request.QueryString["accion"];

            if (accion == "n")
            {
                lnkNuevoTicket.Visible = true;


                
                cmbActividad.Items.Add(new ListItem { Text = "Seleccione una actividad", Value = "Seleccionar" });
                cmbActividad.Items.Add(new ListItem { Text = "Solucionar Ticket", Value = "Solucion" });
                cmbActividad.Items.Add(new ListItem { Text = "Cambio de Estado",Value ="Estado" });
                cmbActividad.Items.Add(new ListItem { Text = "Seguimiento del Ticket", Value = "Seguimiento" });
                cmbActividad.Items.Add(new ListItem { Text = "Adjuntar Documento",Value ="Documento" });
                cmbActividad.Items.Add(new ListItem { Text = "Editar Ticket", Value = "Editar" });
                cmbActividad.Items.Add(new ListItem { Text = "Escalar Ticket otro Nivel Atención", Value = "Escalar" });


            }
            else
            {
                lnkNuevoTicket.Visible = false;
                
                cmbActividad.Items.Add(new ListItem { Text = "Seleccione una actividad", Value = "Seleccionar" });
                cmbActividad.Items.Add(new ListItem { Text = "Solucionar Ticket", Value = "Solucion" });
                cmbActividad.Items.Add(new ListItem { Text = "Cambio de Estado", Value = "Estado" });
                cmbActividad.Items.Add(new ListItem { Text = "Seguimiento del Ticket", Value = "Seguimiento" });
                cmbActividad.Items.Add(new ListItem { Text = "Adjuntar Documento", Value = "Documento" });
            }


            onCargarAnalistas();
            onCargarEspecialistas();
            onCargarEstados();
            onCargarTipoTicket();
            onCargarTickets();
        }

        private void Onactualizarpagina()
        {

            //lblMensaje.Text = Session["Mensaje"].ToString();

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

            if (cmbAnalistas.SelectedValue != "")
            {
                lblMensajefiltro.Text = "Se encontró conincidencias";
                int codigoAnalista = Convert.ToInt32(cmbAnalistas.SelectedValue);
                grdTickets.DataSource = ticket.listaTicketsIntegrante(codigoAnalista,
                                                                      LstTipoTicket.SelectedValue.ToUpper(),
                                                                      cmbEstado.Text.ToUpper(), FechaRegIni, FechaRegFin);
                //grdTickets.DataSource = ticket.listaTicketsIntegrante(1, 1, 1, "INCIDENTE", "ABIERTO", DateTime.Now, DateTime.Now) ; //"1900-01-01", "2035-12-31");
                grdTickets.DataBind();
            }
            else
            {
                lblMensajefiltro.Text = "Se encontró conincidencias";
            }
        
            



        }

        

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            onCargarTickets();
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            Response.Redirect("~/Inicio.aspx");
        }

                  

        protected void onEditarTicket()
        {
            string numeroTicket = "0";

            GridViewRow rowGrd = grdTickets.SelectedRow;

            if (rowGrd == null)
            {
                lblMensaje.Text = "Seleccione un ticket de atención";
            }
            else
            {
                numeroTicket = rowGrd.Cells[1].Text;
                //if (EsPosibleRegistrarSolucion(numeroTicket ))
                //    lblMensaje.Text = "";
                //else
                //{
                    Response.Redirect("~/Vistas/SD/Atenciones/NuevaAtencion.aspx?registro=M&nroticket=" + numeroTicket.ToString()); 
                //}
                
            }
        }

        protected void onSolucionTicket()
        {
            string numeroTicket = "0";
            ITicketLogica ticket = new TicketLogica(new TicketData("TMD"));

            GridViewRow rowGrd = grdTickets.SelectedRow;

            if (rowGrd == null)
            {
                lblMensaje.Text = "Seleccione un ticket de atención";
            }
            else
            {
                numeroTicket = rowGrd.Cells[1].Text;
                if (ticket.EsPosibleRegistrarSolucion(Convert.ToInt16( numeroTicket))==2)
                {
                    lblMensaje.Text = "El estado del ticket debe ser EN PROCESO";
                    return;
                }


                Response.Redirect("~/Vistas/SD/Atenciones/IngresarSolucion.aspx?nroticket=" + numeroTicket.ToString());
            }
        }

        protected void onSeguimientoTicket()
        {
            string numeroTicket = "0";

            GridViewRow rowGrd = grdTickets.SelectedRow;

            if (rowGrd == null)
            {
                lblMensaje.Text = "Seleccione un ticket de atención";
            }
            else
            {
                numeroTicket = rowGrd.Cells[1].Text;

                Response.Redirect("~/Vistas/SD/Atenciones/IngresarSeguimiento.aspx?nroticket=" + numeroTicket.ToString());
            }
        }

        protected void onAdjuntarDocumento()
        {
            string numeroTicket = "0";

            GridViewRow rowGrd = grdTickets.SelectedRow;

            if (rowGrd == null)
            {

                lblMensaje.Text = "Seleccione un ticket de atención";
            }
            else
            {
                numeroTicket = rowGrd.Cells[1].Text;

                Response.Redirect("~/Vistas/SD/Atenciones/AdjuntarDocumento.aspx?nroticket=" + numeroTicket.ToString());
                

            }
        }

        protected void onCambioEstado()
        {
            string numeroTicket = "0";

            GridViewRow rowGrd = grdTickets.SelectedRow;

            if (rowGrd == null)
            {

                lblMensaje.Text = "Seleccione un ticket de atención";
            }
            else
            {
                numeroTicket = rowGrd.Cells[1].Text;

                Response.Redirect("~/Vistas/SD/Atenciones/CambiarEstado.aspx?nroticket=" + numeroTicket.ToString());
                
            }
        }

        protected void onEscalarTicket()
        {
            string numeroTicket = "0";

            GridViewRow rowGrd = grdTickets.SelectedRow;

            if (rowGrd == null)
            {

                lblMensaje.Text = "Seleccione un ticket de atención";
            }
            else
            {
                numeroTicket = rowGrd.Cells[1].Text;

                Response.Redirect("~/Vistas/SD/Atenciones/EscalarTicket.aspx?nroticket=" + numeroTicket.ToString());

            }
        }

        protected void btnInfoSeguimiento_Click(object sender, EventArgs e)
        {
            string actividadSeleccionada=  cmbActividad.SelectedItem.Value ;
            Session["Mensaje"] = "";
            lblMensaje.Text = "";
            switch (actividadSeleccionada)
            {
                case "Solucion":
                    {
                        onSolucionTicket();
                        break;
                    }
                case "Seguimiento":
                    {
                        onSeguimientoTicket();
                        break;
                    }
                case "Documento":
                    {
                        onAdjuntarDocumento();
                        break;
                    }
                case "Estado":
                    {
                        onCambioEstado();
                        break;
                    }
                case "Editar":
                    {
                        onEditarTicket();
                        break;
                    }

                case "Escalar":
                    {
                        onEscalarTicket();
                        break;
                    }

                default:
                    {
                     lblMensaje.Text= "Seleccione una actividad"; 
                     break;
                    }
            }

        }



    }
}