
using System.Web.Script.Services;
using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.Entidades;
using TMD.MP.Comun;
using TMD.MP.LogicaNegocios.Contrato;
using TMD.MP.LogicaNegocios.Implementacion;

namespace TMD.MP.Site.Privado
{
    public partial class PilotoFormulario : System.Web.UI.Page
    {
        int action = Constantes.ACTION_INSERT; //0:Insertar 1:Actualizar

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                action = Convert.ToInt32(Request.QueryString["Action"]);

                CargarEmpleado();
                CargarSolucion();

                if (action == Constantes.ACTION_INSERT)
                {
                    NuevoPiloto();
                }
                else if (action==Constantes.ACTION_UPDATE || action==Constantes.ACTION_VIEW) {
                    CargarPiloto();
                }
                
            }
            
        }

        protected void NuevoPiloto()
        {
            if (Sesiones.PilotoSeleccionada == null)
            {
                Sesiones.PilotoSeleccionada = new PilotoEntidad();
            }
        }

        protected void CargarPiloto()
        {
            PilotoEntidad Piloto = Sesiones.PilotoSeleccionada;
            tbxCodigo.Text = String.Format("{0:000}", Piloto.codigo);
            ddlSolucion.SelectedValue = Piloto.solucion;

            if (action == Constantes.ACTION_VIEW)
                CargarModoView();
            else
                CargarModoEdit();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Validate(btnGuardar.ValidationGroup);

            if(IsValid == true){

                PilotoEntidad oPiloto = Sesiones.PilotoSeleccionada;
                IPilotoLogica oPilotoLogica = PilotoLogica.getInstance();

                oPiloto.codigo_Solucion = Convert.ToInt32(ddlSolucion.SelectedItem.Value);
                oPiloto.codigo_Empleado = Convert.ToInt32(ddlEmpleado.SelectedItem.Value);
                oPiloto.fecha_Inicio = Convert.ToDateTime(tbxFechaInicio.Text);
                oPiloto.fecha_Fin = Convert.ToDateTime(tbxFechaFin.Text);
                oPiloto.descripcion = tbxDescripcion.Text;

                if (oPiloto.codigo != null)
                    oPilotoLogica.ActualizarPiloto(oPiloto);
                else
                {
                    oPiloto.codigo_Estado = Convert.ToInt32(Constantes.ESTADO_PILOTO.GENERADO);
                    oPilotoLogica.InsertarPiloto(oPiloto);
                }

                string currentURL = Request.Url.ToString();
                string newURL = currentURL.Substring(0, currentURL.LastIndexOf("/"));

                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                "alert('Piloto Registrado'); window.location='" +
                newURL + "/PilotoListado.aspx';", true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Paginas.TMD_MP_PilotoListado, true);
        }

        protected void CargarModoView() {
            ddlSolucion.Enabled = false;
            ddlEmpleado.Enabled = false;
            btnGuardar.Visible = false;
            btnCancelar.Text = "Salir";
        }

        protected void CargarModoEdit()
        {
            ddlSolucion.Enabled = false;
        }

        protected void CargarEmpleado()
        {
            IUsuarioLogica oAreaLogica = UsuarioLogica.getInstance();
            List<UsuarioEntidad> oUsuarioColeccion = oAreaLogica.ObtenerListaEmpleadosTodas();
            ddlEmpleado.DataSource = oUsuarioColeccion;
            ddlEmpleado.DataTextField = "NOMBRE_COMPLETO";
            ddlEmpleado.DataValueField = "CODIGO_PERSONA";
            ddlEmpleado.DataBind();
            ddlEmpleado.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }


        protected void CargarSolucion()
        {
            ISolucionMejoraLogica oSolucionMejoraLogica = SolucionMejoraLogica.getInstance();
            List<SolucionMejoraEntidad> oSolucionMejoraColeccion = oSolucionMejoraLogica.ObtenerSolucionMejoraListadoParaPiloto();
            ddlSolucion.DataSource = oSolucionMejoraColeccion;
            ddlSolucion.DataTextField = "DESCRIPCION";
            ddlSolucion.DataValueField = "CODIGO_SOLUCION";
            ddlSolucion.DataBind();
            ddlSolucion.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }

    }
}