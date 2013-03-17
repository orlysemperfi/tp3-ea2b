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
    public partial class AdjuntarDocumento : System.Web.UI.Page
    {

        string accionRegistro;
        int numeroTicket;
        int codigoEquipo;

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
            txtAnalista.Text = datosTicket.Empleado_Propietario;
            txtEspecialista.Text = datosTicket.Empleado_Asignado;
            txtUsuario.Text = datosTicket.Nombre_UsuarioCliente;
            txtServicio.Text = datosTicket.Nombre_Servicio;
            codigoEquipo = datosTicket.Codigo_Equipo;

            //Llenar la grilla
            //grdSeguimiento.DataSource = ticket.listaSeguimientos(datosTicket.Codigo_Ticket);
            //grdSeguimiento.DataBind(); 

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vistas/SD/Atenciones/Atenciones.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == false)
            {
                return;
            }

            numeroTicket = Convert.ToInt32(txtNroTicket.Text);
            ITicketLogica ticket = new TicketLogica(new TicketData("TMD"));
            Ticket datosTicket = ticket.datosTicket(numeroTicket);
            DocumentoTicket documentoTicket;
            int codigoDocumento = 1;

            int codigoEspecialista = SesionFachada.Usuario.Id;
            //codigoDocumento = grdDocumentos.Rows.Count + 1;

            documentoTicket = new DocumentoTicket
            {
                Codigo_Ticket = numeroTicket,
                Descripcion_DocumentoTicket = txtDescripcionDocumento.Text,
                Codigo_DocumentoTicket = codigoDocumento,
                Nombre_DocumentoTicket = txtNombreArchivo.Text,
                Ruta_DocumentoTicket = txtRutaArchivo.Text,
                Codigo_Equipo = datosTicket.Codigo_Equipo,
                Codigo_Integrante = codigoEspecialista,
                Fecha_Registro = DateTime.Now
            };
            ticket.registrarDocumentoTicket(documentoTicket);
            Response.Redirect("~/Vistas/SD/Atenciones/Atenciones.aspx");
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 20;
        }
    }
}