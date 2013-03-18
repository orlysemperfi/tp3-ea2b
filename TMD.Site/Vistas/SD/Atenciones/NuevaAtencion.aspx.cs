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
    public partial class NuevaAtencion : System.Web.UI.Page
    {
        static string accionRegistro;
        static string aliasIntegrante;
        static int tiempoRespuesta;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                OnInitPage();
            }
        }

        private void OnInitPage()
        {
            int numeroTicket;
            accionRegistro = Request.QueryString["registro"];

                Session["CodigoCliente"] = 0;
                Session["CodigoSede"] = 0;
            

            //pageAnterior = Request.ServerVariables["HTTP_REFERER"].ToLower();

            //Usuarios Proyectos asignados al integrante

            onCargarUsuarioClientes();

            if (accionRegistro == "N")
            {
                txtNroTicket.Visible = false;
                txtFechaRegistro.Text = DateTime.Now.ToString();
            }
            else
            {
                //Cargar la info del ticket
                numeroTicket =Convert.ToInt32( Request.QueryString["nroticket"]);
                onCargarTicket(numeroTicket);
            }
            

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Vistas/SD/Atenciones/Atenciones.aspx");
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            string script;

            if (Page.IsValid ==false )
            {
                return; 
            }
            ITicketLogica ticket = new TicketLogica(new TicketData("TMD"));
            Ticket Datosticket = new Ticket();

            int codigoCliente = Convert.ToInt32(Session["CodigoCliente"]);
            int codigoSede = Convert.ToInt32(Session["CodigoSede"]);
            
            Datosticket.Fecha_Registro = Convert.ToDateTime(txtFechaRegistro.Text);
            Datosticket.Tipo_Registro_Ticket = cmbTipoRegistro.SelectedValue.ToUpper();
            Datosticket.Tipo_Atencion_Ticket = cmbTipoAtencion.SelectedValue.ToUpper();
            Datosticket.Fecha_Expiracion = Convert.ToDateTime(txtFechaExpiracion.Text);
            Datosticket.Descripcion_Corta = txtDescripcionBreve.Text;
            Datosticket.Descripcion_Larga = txtDescripcionDetallada.Text;
            Datosticket.Tiempo_Resolucion = tiempoRespuesta;
            Datosticket.Prioridad_Ticket = Convert.ToInt32(txtPrioridad.Text);
            Datosticket.Codigo_Cliente = codigoCliente;
            Datosticket.Codigo_Usuario = Convert.ToInt32(cmbUsuarioCliente.SelectedValue);
            Datosticket.Codigo_Servicio = Convert.ToInt32(cmbServicio.SelectedValue);
            Datosticket.Codigo_Proyecto = Convert.ToInt32(cmbProyecto.SelectedValue);
            Datosticket.Codigo_Equipo = Convert.ToInt32(cmbEquipo.SelectedValue);
            Datosticket.Codigo_Sede = codigoSede;

            if (accionRegistro == "N")
            {
                Datosticket.Codigo_Propietario = SesionFachada.Usuario.Id;
                Datosticket.Codigo_Asignado = Convert.ToInt32(cmbEspecialista.SelectedValue);
                Datosticket.Codigo_Ult_Modif = 0;

                Int32 numeroTicket = ticket.agregarTicket(Datosticket);
                ticket.agregarTicketCMDB(numeroTicket,Convert.ToInt32(cmbCMDB.SelectedValue));
                
                script = "alert(Se generó el ticket No '{0}');";
                script = string.Format(script, numeroTicket);

            }
            else
            {
                Datosticket.Codigo_Ticket = Convert.ToInt32(txtNroTicket.Text);
                Datosticket.Codigo_Asignado = Convert.ToInt32(cmbEspecialista.SelectedValue);
                Datosticket.Codigo_Ult_Modif = SesionFachada.Usuario.Id;
                ticket.modificarTicket(Datosticket);

                script = "alert(Se actualizó el ticket No '{0}');";
                script = string.Format(script, Datosticket.Codigo_Ticket);
            }


            ScriptManager.RegisterStartupScript(this, typeof(Page), "Mensaje", script, false);

            Response.Redirect("~/Vistas/SD/Atenciones/Atenciones.aspx");
        }

      
        protected void cmbUsuarioCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            onCargarDatosUsuario();

        }

        protected void cmbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            onCargarProyectos();
        }

        protected void cmbProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            onCargarSLA();
            onCargarCMDB();
        }

        protected void cmbEspecialista_SelectedIndexChanged(object sender, EventArgs e)
        {
            onCargarEquipo();
        }

        private void onCargarUsuarioClientes()
        {

            IUsuarioClienteLogica usuarioCliente = new UsuarioClienteLogica(new UsuarioClienteData("TMD"));
            aliasIntegrante = SesionFachada.Usuario.Alias.ToString();


            cmbUsuarioCliente.DataSource = usuarioCliente.listaUsuarioCliente(aliasIntegrante);
            cmbUsuarioCliente.DataTextField = "Nombre_Usuario";
            cmbUsuarioCliente.DataValueField = "Codigo_Usuario";
            cmbUsuarioCliente.DataBind();
        }

        private void onCargarDatosUsuario()
        {
            IUsuarioClienteLogica usuarioCliente = new UsuarioClienteLogica(new UsuarioClienteData("TMD"));
            UsuarioCliente datosusuarioCliente = usuarioCliente.datosUsuarioCliente(Convert.ToInt32(cmbUsuarioCliente.SelectedValue));
            txtSede.Text = datosusuarioCliente.Nombre_Sede;
            txtCliente.Text = datosusuarioCliente.Nombre_Cliente;
            lblcodcliente.Text = datosusuarioCliente.Codigo_Cliente.ToString();
            Session["CodigoCliente"] = datosusuarioCliente.Codigo_Cliente;
            Session["CodigoSede"] = datosusuarioCliente.Codigo_Sede;
            //Obtener los posibles servicios de io cliente - Usuario
            onCargarServicios();

        }

        private void onCargarServicios()
        {
            //Obtener lista de servicios
            IServicioLogica servicios = new ServicioLogica(new ServiciosData("TMD"));
            cmbServicio.DataSource = servicios.listaServiciosUsuarioCliente(Convert.ToInt32(lblcodcliente.Text), Convert.ToInt32(cmbUsuarioCliente.SelectedValue));
            cmbServicio.DataTextField = "Nombre_Servicio";
            cmbServicio.DataValueField = "Codigo_Servicio";
            cmbServicio.DataBind();
            onCargarProyectos();
        }

        private void onCargarProyectos()
        {
            //Obtener proyectos del usario-cliente - Servicio
            IProyectoLogica proyecto = new ProyectoLogica(new ProyectoData("TMD"));
            cmbProyecto.DataSource = proyecto.listaProyectosUsuarioClienteServicio(Convert.ToInt32(lblcodcliente.Text),Convert.ToInt32(cmbUsuarioCliente.SelectedValue),Convert.ToInt32(cmbServicio.SelectedValue)  );
            cmbProyecto.DataTextField = "Nombre_Proyecto";
            cmbProyecto.DataValueField = "Codigo_Proyecto";
            cmbProyecto.DataBind();
            onCargarSLA();
            onCargarEspecialistas();
            onCargarCMDB();
        }


        private void onCargarSLA()
        {
            //Obtener proyectos del usario-cliente - Servicio
            IServicioLogica servicios = new ServicioLogica(new ServiciosData("TMD"));
            int codigoSede=Convert.ToInt32(Session["CodigoSede"]);
            ProyectoServicioSede datosServicioSLA = new ProyectoServicioSede();
            
            datosServicioSLA = servicios.datosServicioSLA(new ProyectoServicioSede {Codigo_Proyecto =Convert.ToInt32(cmbProyecto.SelectedValue),Codigo_Servicio =Convert.ToInt32(cmbServicio.SelectedValue),Codigo_Sede =codigoSede});
            txtSLA.Text = datosServicioSLA.Nombre_SLA;
            if (txtPrioridad.Text == "")  txtPrioridad.Text = datosServicioSLA.Prioridad.ToString();
            
            txtFechaExpiracion.Text = servicios.obtenerFechaExpiración(Convert.ToDateTime(txtFechaRegistro.Text), datosServicioSLA).ToString();
            tiempoRespuesta = datosServicioSLA.Tiempo_Respuesta;

        }

        private void onCargarEspecialistas()
        {
            //Obtener proyectos del usario-cliente - Servicio
            IIntegranteLogica integrante = new IntegranteLogica(new IntegranteData("TMD"));
            int codigoSede = Convert.ToInt32(Session["CodigoSede"]);
            ProyectoServicioSede datosServicioSLA = new ProyectoServicioSede();

            cmbEspecialista .DataSource= integrante.listaEspecialistaProyectoServicioSede(Convert.ToInt32(cmbProyecto.SelectedValue), Convert.ToInt32(cmbServicio.SelectedValue), codigoSede);
            cmbEspecialista.DataTextField = "NOMBRE_EMPLEADO";
            cmbEspecialista.DataValueField = "CODIGO_INTEGRANTE";
            cmbEspecialista.DataBind();
            onCargarEquipo();
 

        }

        private void onCargarEquipo()
        {

            //Obtener proyectos del usario-cliente - Servicio
            IIntegranteLogica integrante = new IntegranteLogica(new IntegranteData("TMD"));
            int codigoSede = Convert.ToInt32(Session["CodigoSede"]);
            ProyectoServicioSede datosServicioSLA = new ProyectoServicioSede();

            cmbEquipo.DataSource = integrante.listaEquiposEspecialista(Convert.ToInt32(cmbProyecto.SelectedValue), Convert.ToInt32(cmbServicio.SelectedValue), codigoSede,Convert.ToInt32(cmbEspecialista.SelectedValue));
            cmbEquipo.DataTextField = "NOMBRE_EQUIPO";
            cmbEquipo.DataValueField = "CODIGO_EQUIPO";
            cmbEquipo.DataBind();
        }

        private void onCargarCMDB()
        {

            //Obtener proyectos del usario-cliente - Servicio
            ICMDBLogica cMDB = new CMDBLogica(new CMDBData("TMD"));
            
            ProyectoServicioSede datosServicioSLA = new ProyectoServicioSede();

            cmbCMDB.DataSource = cMDB.listaCMDBProyecto(Convert.ToInt32(cmbProyecto.SelectedValue));
            cmbCMDB.DataTextField = "NOMBRE_CMDB";
            cmbCMDB.DataValueField = "CODIGO_CMDB";
            cmbCMDB.DataBind();
        }

        private void onCargarTicket(int numeroTicket)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            
            ITicketLogica ticket = new TicketLogica(new TicketData("TMD"));
            Ticket datosTicket = ticket.datosTicket(numeroTicket);

            txtNroTicket.Text = datosTicket.Codigo_Ticket.ToString();
            txtFechaRegistro.Text = datosTicket.Fecha_Registro.ToString();
            txtFechaExpiracion.Text = datosTicket.Fecha_Expiracion.ToString();
            txtDescripcionBreve.Text = datosTicket.Descripcion_Corta;
            txtDescripcionDetallada.Text = datosTicket.Descripcion_Larga;
            cmbTipoAtencion.Text = myTI.ToTitleCase(datosTicket.Tipo_Atencion_Ticket.ToLower());
            cmbTipoRegistro.Text = myTI.ToTitleCase(datosTicket.Tipo_Registro_Ticket.ToLower());
            txtPrioridad.Text = datosTicket.Prioridad_Ticket.ToString();

            onCargarUsuarioClientes();
            cmbUsuarioCliente.SelectedValue =datosTicket.Codigo_Usuario.ToString();
            onCargarDatosUsuario();
            cmbServicio.SelectedValue = datosTicket.Codigo_Servicio.ToString();
            cmbProyecto.SelectedValue = datosTicket.Codigo_Proyecto.ToString();
            cmbEspecialista.SelectedValue = datosTicket.Codigo_Asignado.ToString();
            cmbEquipo.SelectedValue = datosTicket.Codigo_Equipo.ToString();
            
    
            string codigoCMDB=ticket.datosTicketCMDB(numeroTicket).Codigo_CMDB.ToString();
            if (codigoCMDB == "0") cmbCMDB.SelectedIndex = -1;

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 15;
        }

        protected void CVDescripcionDetallada_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 20;
        }

    }
}