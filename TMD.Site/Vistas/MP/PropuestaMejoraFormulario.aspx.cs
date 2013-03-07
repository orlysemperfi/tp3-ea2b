
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
    public partial class PropuestaMejoraFormulario : System.Web.UI.Page
    {
        int action = Constantes.ACTION_INSERT; //0:Insertar 1:Actualizar
        int contador = 0;
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
                else if (action==Constantes.ACTION_UPDATE) {
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
            tbxCodigo.Text = propuestaMejora.codigo_Propuesta.ToString();
            ddlArea.SelectedValue = propuestaMejora.codigo_Area.ToString();
            ddlTipoPropuesta.SelectedValue = propuestaMejora.tipo_Propuesta;
            ddlResponsable.SelectedValue = propuestaMejora.codigo_Responsable.ToString();
            ddlProceso.SelectedValue = propuestaMejora.codigo_Proceso.ToString();
            tbxFechaEnvio.Text = propuestaMejora.fecha_Envio.ToShortDateString();
            tbxEstado.Text = propuestaMejora.codigo_Estado.ToString();
            tbxObservaciones.Text = propuestaMejora.observaciones;
            tbxDescripcion.Text = propuestaMejora.descripcion;
            tbxCausa.Text = propuestaMejora.causa;
            tbxBeneficios.Text = propuestaMejora.beneficios;
            tbxObservaciones.Text = propuestaMejora.observaciones;

            CargarIndicadorListado();
        }

        public void CargarIndicadorListado()
        {
            IIndicadorLogica oIndicadorLogica = IndicadorLogica.getInstance(); 
            List<IndicadorEntidad> oIndicadorColeccion = new List<IndicadorEntidad>();
            if (Sesiones.PropuestaMejoraSeleccionada.lstIndicadores == null)
            {
                int codigo_Propuesta = Convert.ToInt32(Sesiones.PropuestaMejoraSeleccionada.codigo_Propuesta.ToString());
                Sesiones.PropuestaMejoraSeleccionada.lstIndicadores = oIndicadorLogica.ObtenerListaIndicadorPorPropuesta(codigo_Propuesta);
            }
            gvwIndicadores.DataBind();
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
            ddlTipoPropuesta.Items.Add(new ListItem("Problema", "1"));
            ddlTipoPropuesta.Items.Add(new ListItem("Mejora", "2"));
            ddlTipoPropuesta.SelectedIndex = 0;
        }

        protected void CargarArea()
        {
            IAreaLogica oAreaLogica = AreaLogica.getInstance();
            ddlArea.DataSource = oAreaLogica.ObtenerListaAreaTodas();
            ddlArea.DataTextField = "DESCRIPCION";
            ddlArea.DataValueField = "CODIGO";
            ddlArea.DataBind();
        }

        protected void CargarResponsable()
        {
            IUsuarioLogica oAreaLogica = UsuarioLogica.getInstance();
            List<UsuarioEntidad> oUsuarioColeccion = oAreaLogica.ObtenerListaEmpleadosTodas();
            ddlResponsable.DataSource = oUsuarioColeccion;
            ddlResponsable.DataTextField = "NOMBRE_COMPLETO";
            ddlResponsable.DataValueField = "CODIGO_PERSONA";
            ddlResponsable.DataBind();
        }

        protected void CargarProceso()
        {
            IProcesoLogica oProcesoLogica = ProcesoLogica.getInstance();
            List<ProcesoEntidad> oProcesoColeccion = oProcesoLogica.ObtenerListaProcesoTodas();
            ddlProceso.DataSource = oProcesoColeccion;
            ddlProceso.DataTextField = "NOMBRE";
            ddlProceso.DataValueField = "CODIGO";
            ddlProceso.DataBind();
        }
        //protected void chkStatus_OnCheckedChanged(object sender, EventArgs e)
        //{
        //    CheckBox check = (CheckBox)sender;
 

        //    lblMensajeError.Text = lblMensajeError.Text + " chau :" + check.Checked;
        //}
        protected void lbtnGuardar_Click(object sender, EventArgs e)
        {
            PropuestaMejoraEntidad oNewPropuestaMejora = Sesiones.PropuestaMejoraSeleccionada; //new PropuestaMejoraEntidad();
            IPropuestaMejoraLogica oPropuestaMejoraLogica = PropuestaMejoraLogica.getInstance();
            if (validarCampos()) {
                oNewPropuestaMejora.codigo_Area = Convert.ToInt32(ddlArea.SelectedItem.Value);
                oNewPropuestaMejora.tipo_Propuesta = ddlTipoPropuesta.SelectedItem.Text;
                oNewPropuestaMejora.codigo_Responsable = Convert.ToInt32(ddlResponsable.SelectedItem.Value);
                oNewPropuestaMejora.codigo_Proceso = Convert.ToInt32(ddlProceso.SelectedItem.Value);
                oNewPropuestaMejora.descripcion = tbxDescripcion.Text;
                oNewPropuestaMejora.fecha_Envio = Convert.ToDateTime(tbxFechaEnvio.Text);
                oNewPropuestaMejora.causa = tbxCausa.Text;
                oNewPropuestaMejora.beneficios = tbxBeneficios.Text;
                oNewPropuestaMejora.observaciones = tbxObservaciones.Text;
                oNewPropuestaMejora.codigo_Estado = 1;

                oNewPropuestaMejora.lstIndicadores = new List<IndicadorEntidad>();

                IndicadorEntidad oIndicador = null;
                
                foreach (GridViewRow row in gvwIndicadores.Rows)
                {
                    CheckBox check = row.FindControl("chkIndicadorSel") as CheckBox;

                    if (check.Checked)
                    {
                        
                        oIndicador = new IndicadorEntidad();
                        String llbl = ((Label)row.Cells[0].FindControl("lblCodigo")).Text;

                        oIndicador.codigo = Convert.ToInt32(llbl);
                        oNewPropuestaMejora.lstIndicadores.Add(oIndicador);
                        
                    }
                }

                if (oNewPropuestaMejora.codigo_Propuesta!= null)
                    oPropuestaMejoraLogica.ActualizarPropuestaMejora(oNewPropuestaMejora);
                else
                    oPropuestaMejoraLogica.InsertarPropuestaMejora(oNewPropuestaMejora);
                
                Response.Redirect(Paginas.TMD_MP_PropuestaMejoraListado);
                
            }

        }

        protected Boolean validarCampos() {
            Boolean esValido = true;

            if (tbxDescripcion.Text.Equals(""))
                esValido = false;

            return esValido;
        }

        protected void lbtnCancelar_Click(object sender, EventArgs e)
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
        public CascadingDropDownNameValue[] ObtenerProcesosPorArea(string knownCategoryValues, string category) {
            return null;
        }

        public void CargarIndicadoresProceso() {
            IIndicadorLogica oIndicadorLogica = IndicadorLogica.getInstance();
            int procesoSelected = Convert.ToInt32(ddlProceso.SelectedValue);
            //gvwIndicadores.DataSource =  indicadorControlador.ObtenerIndicadorPorProceso(procesoSelected);
            Sesiones.PropuestaMejoraSeleccionada.lstIndicadores = oIndicadorLogica.ObtenerIndicadorPorProceso(procesoSelected);
            gvwIndicadores.DataBind();

         
        }
        protected void ddlProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarIndicadoresProceso();
        }

    }
}