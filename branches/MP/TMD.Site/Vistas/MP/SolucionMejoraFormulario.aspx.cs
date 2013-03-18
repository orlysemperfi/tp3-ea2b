
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
    public partial class SolucionMejoraFormulario : System.Web.UI.Page
    {
        int action = Constantes.ACTION_INSERT; //0:Insertar 1:Actualizar

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                action = Convert.ToInt32(Request.QueryString["Action"]);

                CargarEmpleado();
                CargarPropuesta();

                if (action == Constantes.ACTION_INSERT)
                {
                    NuevaSolucionMejora();
                }
                else if (action==Constantes.ACTION_UPDATE || action==Constantes.ACTION_VIEW) {
                    CargarSolucionMejora();
                }
                
            }
            
        }

        protected void NuevaSolucionMejora()
        {
            if (Sesiones.SolucionMejoraSeleccionada == null)
            {
                Sesiones.SolucionMejoraSeleccionada = new SolucionMejoraEntidad();
            }
        }

        protected void CargarSolucionMejora()
        {
            SolucionMejoraEntidad SolucionMejora = Sesiones.SolucionMejoraSeleccionada;
            tbxCodigo.Text = String.Format("{0:000}", SolucionMejora.codigo_Solucion);
            ddlPropuesta.SelectedValue = SolucionMejora.propuesta;

            if (action == Constantes.ACTION_VIEW)
                CargarModoView();
            else
                CargarModoEdit();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Validate(btnGuardar.ValidationGroup);

            if(IsValid == true){

                SolucionMejoraEntidad oSolucionMejora = Sesiones.SolucionMejoraSeleccionada;
                ISolucionMejoraLogica oSolucionMejoraLogica = SolucionMejoraLogica.getInstance();

                oSolucionMejora.codigo_Propuesta = Convert.ToInt32(ddlPropuesta.SelectedItem.Value);
                oSolucionMejora.codigo_Empleado = Convert.ToInt32(ddlEmpleado.SelectedItem.Value);
                oSolucionMejora.descripcion = tbxDescripcion.Text;

                if (oSolucionMejora.codigo_Solucion != null)
                    oSolucionMejoraLogica.ActualizarSolucionMejora(oSolucionMejora);
                else
                {
                    oSolucionMejora.codigo_Estado = Convert.ToInt32(Constantes.ESTADO_SOLUCION.GENERADA);
                    oSolucionMejoraLogica.InsertarSolucionMejora(oSolucionMejora);
                }

                string currentURL = Request.Url.ToString();
                string newURL = currentURL.Substring(0, currentURL.LastIndexOf("/"));

                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                "alert('Solucion Registrada'); window.location='" +
                newURL + "/SolucionMejoraListado.aspx';", true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Paginas.TMD_MP_SolucionMejoraListado, true);
        }

        protected void CargarModoView() {
            ddlPropuesta.Enabled = false;
            ddlEmpleado.Enabled = false;
            btnGuardar.Visible = false;
            btnCancelar.Text = "Salir";
        }

        protected void CargarModoEdit()
        {
            ddlPropuesta.Enabled = false;
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


        protected void CargarPropuesta()
        {
            IPropuestaMejoraLogica oPropuestaMejoraLogica = PropuestaMejoraLogica.getInstance();
            List<PropuestaMejoraEntidad> oPropuestaMejoraColeccion = oPropuestaMejoraLogica.ObtenerPropuestaMejoraListadoParaSolucion();
            ddlPropuesta.DataSource = oPropuestaMejoraColeccion;
            ddlPropuesta.DataTextField = "DESCRIPCION";
            ddlPropuesta.DataValueField = "CODIGO_PROPUESTA";
            ddlPropuesta.DataBind();
            ddlPropuesta.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }

    }
}