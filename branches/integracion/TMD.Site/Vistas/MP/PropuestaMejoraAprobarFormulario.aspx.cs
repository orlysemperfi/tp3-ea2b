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
    public partial class PropuestaMejoraAprobarFormulario : System.Web.UI.Page
    {
        int action = Constantes.ACTION_UPDATE; //0:Insertar 1:Actualizar

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                action = Convert.ToInt32(Request.QueryString["Action"]);
                //lblMensajeError.Text = "NO ES POSTBACK" + action;
                CargarTipoPropuesta();
                CargarArea();
                CargarResponsable();
                CargarProceso();
                if (action == Constantes.ACTION_INSERT)
                {
                    NuevaPropuestaMejora();
                }
                else if (action == Constantes.ACTION_UPDATE || action == Constantes.ACTION_VIEW)
                {
                    CargarPropuestaMejora();
                }
                List<IndicadorEntidad> indicadorListado = Sesiones.PropuestaMejoraSeleccionada.lstIndicadores;
                gvwIndicadores.DataBind();

            }

        }

        protected void NuevaPropuestaMejora()
        {
            if (Sesiones.PropuestaMejoraSeleccionada == null)
            {
                Sesiones.PropuestaMejoraSeleccionada = new PropuestaMejoraEntidad();
            }
            gvwIndicadores.DataBind();
        }

        protected void CargarPropuestaMejora()
        {
            /*if (Sesiones.PropuestaMejoraSeleccionada == null) {
                Sesiones.PropuestaMejoraSeleccionada = new PropuestaMejoraEntidad();
            }*/
            PropuestaMejoraEntidad propuestaMejora = Sesiones.PropuestaMejoraSeleccionada;
            tbxCodigo.Text = String.Format("{0:000}", propuestaMejora.codigo_Propuesta);
            ddlArea.SelectedValue = propuestaMejora.codigo_Area.ToString();
            ddlTipoPropuesta.SelectedValue = propuestaMejora.tipo_Propuesta;
            ddlResponsable.SelectedValue = propuestaMejora.codigo_Responsable.ToString();
            ddlProceso.SelectedValue = propuestaMejora.codigo_Proceso.ToString();
            tbxFechaEnvio.Text = propuestaMejora.fecha_Envio.ToShortDateString();
            tbxEstado.Text = propuestaMejora.nombre_Estado;
            tbxObservaciones.Text = propuestaMejora.observaciones;
            tbxDescripcion.Text = propuestaMejora.descripcion;
            tbxCausa.Text = propuestaMejora.causa;
            tbxBeneficios.Text = propuestaMejora.beneficios;
            tbxObservaciones.Text = propuestaMejora.observaciones;

            CargarIndicadoresProceso();

            if (action == Constantes.ACTION_VIEW)
                CargarModoView();
        }

        
        protected List<IndicadorEntidad> ObtenerIndicadorListado()
        {
            List<IndicadorEntidad> indicadorListado = Sesiones.PropuestaMejoraSeleccionada.lstIndicadores;
            if (indicadorListado == null)
            {
                indicadorListado = new List<IndicadorEntidad>();
                return null;
            }
            else
            {
                if (indicadorListado.Count == 0)
                {
                    return null;
                }
                else
                {
                    return indicadorListado;
                }
            }
        }

        protected void CargarTipoPropuesta()
        {
            ddlTipoPropuesta.Items.Add(new ListItem("[Seleccionar]", "0"));
            ddlTipoPropuesta.Items.Add(new ListItem(Constantes.TIPO_PROPUESTA_PROBLEMA, Constantes.TIPO_PROPUESTA_PROBLEMA));
            ddlTipoPropuesta.Items.Add(new ListItem(Constantes.TIPO_PROPUESTA_MEJORA, Constantes.TIPO_PROPUESTA_MEJORA));
            ddlTipoPropuesta.SelectedIndex = 0;
        }

        protected void CargarArea()
        {
            IAreaLogica oAreaLogica = AreaLogica.getInstance();
            ddlArea.DataSource = oAreaLogica.ObtenerListaAreaTodas();
            ddlArea.DataTextField = "DESCRIPCION";
            ddlArea.DataValueField = "CODIGO";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }

        protected void CargarResponsable()
        {
            IUsuarioLogica oAreaLogica = UsuarioLogica.getInstance();
            List<UsuarioEntidad> oUsuarioColeccion = oAreaLogica.ObtenerListaEmpleadosTodas();
            ddlResponsable.DataSource = oUsuarioColeccion;
            ddlResponsable.DataTextField = "NOMBRE_COMPLETO";
            ddlResponsable.DataValueField = "CODIGO_PERSONA";
            ddlResponsable.DataBind();
            ddlResponsable.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }

        protected void CargarProceso()
        {
            IProcesoLogica oProcesoLogica = ProcesoLogica.getInstance();
            List<ProcesoEntidad> oProcesoColeccion = oProcesoLogica.ObtenerListaProcesoTodas();
            ddlProceso.DataSource = oProcesoColeccion;
            ddlProceso.DataTextField = "NOMBRE";
            ddlProceso.DataValueField = "CODIGO";
            ddlProceso.DataBind();
            ddlProceso.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }

   
        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            Validate(btnAprobar.ValidationGroup);

            if (IsValid == true)
            {

                
                //IPropuestaMejoraLogica oPropuestaMejoraLogica = PropuestaMejoraLogica.getInstance();

                //oPropuestaMejoraLogica.InsertarPropuestaMejora(oPropuestaMejora);
              
                //string currentURL = Request.Url.ToString();
                //string newURL = currentURL.Substring(0, currentURL.LastIndexOf("/"));

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                //"alert('Propuesta Aprobada'); window.location='" +
                //newURL + "/PropuestaMejoraListado.aspx';", true);
            }
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            Validate(btnAprobar.ValidationGroup);

            if (IsValid == true)
            {


                //IPropuestaMejoraLogica oPropuestaMejoraLogica = PropuestaMejoraLogica.getInstance();

                ////oPropuestaMejoraLogica.InsertarPropuestaMejora(oPropuestaMejora);

                //string currentURL = Request.Url.ToString();
                //string newURL = currentURL.Substring(0, currentURL.LastIndexOf("/"));

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                //"alert('Propuesta Registrada'); window.location='" +
                //newURL + "/PropuestaMejoraListado.aspx';", true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Paginas.TMD_MP_PropuestaMejoraListado, true);
        }

        protected void gvwIndicadores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("SeleccionarIndicador"))
            {
                CheckBox check = (CheckBox)sender;
                lblMensajeError.Text = "hola :" + e.CommandArgument;
                lblMensajeError.Text = lblMensajeError.Text + " chau :" + check.Checked;
            }
        }
        public CascadingDropDownNameValue[] ObtenerProcesosPorArea(string knownCategoryValues, string category)
        {
            return null;
        }

        public void CargarIndicadoresProceso()
        {
            IIndicadorLogica oIndicadorLogica = IndicadorLogica.getInstance();
            int procesoSelected = Convert.ToInt32(ddlProceso.SelectedValue);
            Sesiones.PropuestaMejoraSeleccionada.lstIndicadores = oIndicadorLogica.ObtenerIndicadorPorProceso(procesoSelected);

            if (action != Constantes.ACTION_INSERT)
            {
                List<IndicadorEntidad> oIndicadorColeccion = new List<IndicadorEntidad>();
                int codigo_Propuesta = Convert.ToInt32(Sesiones.PropuestaMejoraSeleccionada.codigo_Propuesta.ToString());
                oIndicadorColeccion = oIndicadorLogica.ObtenerListaIndicadorPorPropuesta(codigo_Propuesta);

                foreach (IndicadorEntidad oIndicador in Sesiones.PropuestaMejoraSeleccionada.lstIndicadores)
                {
                    foreach (IndicadorEntidad oTempIndicador in oIndicadorColeccion)
                    {
                        if (oIndicador.codigo == oTempIndicador.codigo)
                            oIndicador.marcado = oTempIndicador.marcado;
                    }
                }

            }

            gvwIndicadores.DataBind();
        }

        protected void ddlProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarIndicadoresProceso();
        }

        protected void CargarModoView()
        {
            ddlArea.Enabled = false;
            ddlProceso.Enabled = false;
            ddlTipoPropuesta.Enabled = false;
            ddlResponsable.Enabled = false;
            tbxFechaEnvio.Enabled = false;
            tbxObservaciones.Enabled = false;
            tbxDescripcion.Enabled = false;
            tbxCausa.Enabled = false;
            tbxBeneficios.Enabled = false;
            btnAprobar.Visible = false;
            btnRechazar.Visible = false;
            btnCancelar.Text = "Salir";
            gvwIndicadores.Enabled = false;

        }

      

    }
}