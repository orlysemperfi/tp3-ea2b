﻿using System;
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
    public partial class IngresarSeguimiento : System.Web.UI.Page
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

        protected void btnGrabar_Click(object sender, EventArgs e)
        {

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

        }

    }
}