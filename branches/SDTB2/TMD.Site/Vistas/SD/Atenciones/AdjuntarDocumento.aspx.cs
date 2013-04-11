using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;


using System.IO;
using TMD.Entidades;
using TMD.SD.LogicaNegocio_Atencion.Contrato;
using TMD.SD.LogicaNegocio_Atencion.Implementacion;
using TMD.SD.AccesoDatos_Atencion.Implementacion;

using TMD.CF.Site.Util;

using AppLimit.CloudComputing.SharpBox;
using AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox;


namespace TMD.CF.Site.Vistas.DBO.Atenciones
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
            grdDocumentoTicket.DataSource = ticket.listaDocumentosTickets(datosTicket.Codigo_Ticket);
            grdDocumentoTicket.DataBind(); 

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

            SubirArchivo(txtRutaArchivo.Text, txtNombreArchivo.Text);

            numeroTicket = Convert.ToInt32(txtNroTicket.Text);
            ITicketLogica ticket = new TicketLogica(new TicketData("TMD"));
            Ticket datosTicket = ticket.datosTicket(numeroTicket);
            DocumentoTicket documentoTicket;
            SeguimientoTicket seguimientoTicket;
            int codigoDocumento;
            int codigoEspecialista = SesionFachada.Usuario.Id;

            codigoDocumento = Convert.ToInt16(datosTicket.Ultimo_Adicional  + 1);
            datosTicket.Ultimo_Adicional = codigoDocumento;

            ticket.cambiarEstadoTicket(datosTicket);

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

            seguimientoTicket = new SeguimientoTicket
            {
                Codigo_Ticket = numeroTicket,
                Descripcion_Seguimiento = txtDescripcionDocumento.Text,
                Codigo_Seguimiento = codigoDocumento + 20, //cambiar codigo debe ser autogenerado en la capa de datos
                Codigo_Equipo = datosTicket.Codigo_Equipo,
                Codigo_Integrante = codigoEspecialista,
                Tipo_Seguimiento = "DOCUMENTO",
                Fecha_Registro = DateTime.Now
            };
            ticket.registrarDocumentoTicket(documentoTicket);
            ticket.registrarSeguimiento(seguimientoTicket);
            Response.Redirect("~/Vistas/SD/Atenciones/Atenciones.aspx");
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 20;
        }

        protected void SubirArchivo(String ruta, String nombre)
        {
            // Creating the cloudstorage object
            CloudStorage dropBoxStorage = new CloudStorage();
            // get the configuration for dropbox
            var dropBoxConfig =
            CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox);
            // declare an access token
            ICloudStorageAccessToken accessToken = null;
            // load a valid security token from file 
            using (FileStream fs = File.Open("C:\\apps\\DropBox\\token.txt",
            FileMode.Open, FileAccess.Read,
            FileShare.None))
            {
                accessToken = dropBoxStorage.DeserializeSecurityToken(fs);
            }
            var storageToken = dropBoxStorage.Open(dropBoxConfig, accessToken);

            var srcFile = System.Environment.ExpandEnvironmentVariables(ruta + nombre);
            var folder = dropBoxStorage.GetFolder("/Public");

            dropBoxStorage.UploadFile(srcFile, folder);
            dropBoxStorage.Close();

        }

        protected void BajarArchivo(String nombre)
        {
            // Creating the cloudstorage object
            CloudStorage dropBoxStorage = new CloudStorage();
            // get the configuration for dropbox
            var dropBoxConfig =
            CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox);
            // declare an access token
            ICloudStorageAccessToken accessToken = null;
            // load a valid security token from file 
            using (FileStream fs = File.Open("C:\\apps\\DropBox\\token.txt",
            FileMode.Open, FileAccess.Read,
            FileShare.None))
            {
                accessToken = dropBoxStorage.DeserializeSecurityToken(fs);
            }
            var storageToken = dropBoxStorage.Open(dropBoxConfig, accessToken);

            var folder = dropBoxStorage.GetFolder("/Public");

            dropBoxStorage.DownloadFile(folder, nombre, Environment.ExpandEnvironmentVariables("%temp%"));
            dropBoxStorage.Close();

        }

        

        protected void grdDocumentoTicket_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridViewRow rowGrd = grdDocumentoTicket.SelectedRow;
            String nombre = rowGrd.Cells[3].Text;
            BajarArchivo(nombre);
 
        }
    }
}