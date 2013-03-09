﻿
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
                else if (action==Constantes.ACTION_UPDATE || action==Constantes.ACTION_VIEW) {
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

            CargarIndicadorListado();

            if (action == Constantes.ACTION_VIEW)
                CargarModoView();
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
            PropuestaMejoraEntidad oPropuestaMejora = Sesiones.PropuestaMejoraSeleccionada; //new PropuestaMejoraEntidad();
            IPropuestaMejoraLogica oPropuestaMejoraLogica = PropuestaMejoraLogica.getInstance();
            if (validarCampos()) {
                oPropuestaMejora.codigo_Area = Convert.ToInt32(ddlArea.SelectedItem.Value);
                oPropuestaMejora.tipo_Propuesta = ddlTipoPropuesta.SelectedItem.Text;
                oPropuestaMejora.codigo_Responsable = Convert.ToInt32(ddlResponsable.SelectedItem.Value);
                oPropuestaMejora.codigo_Proceso = Convert.ToInt32(ddlProceso.SelectedItem.Value);
                oPropuestaMejora.descripcion = tbxDescripcion.Text;
                oPropuestaMejora.fecha_Envio = Convert.ToDateTime(tbxFechaEnvio.Text);
                oPropuestaMejora.causa = tbxCausa.Text;
                oPropuestaMejora.beneficios = tbxBeneficios.Text;
                oPropuestaMejora.observaciones = tbxObservaciones.Text;
                oPropuestaMejora.lstIndicadores = new List<IndicadorEntidad>();

                IndicadorEntidad oIndicador = null;
                
                foreach (GridViewRow row in gvwIndicadores.Rows)
                {
                    CheckBox check = row.FindControl("chkIndicadorSel") as CheckBox;

                    if (check.Checked)
                    {
                        
                        oIndicador = new IndicadorEntidad();
                        String llbl = ((Label)row.Cells[0].FindControl("lblCodigo")).Text;

                        oIndicador.codigo = Convert.ToInt32(llbl);
                        oPropuestaMejora.lstIndicadores.Add(oIndicador);
                        
                    }
                }

                if (oPropuestaMejora.codigo_Propuesta != null)
                    oPropuestaMejoraLogica.ActualizarPropuestaMejora(oPropuestaMejora);
                else
                {
                    oPropuestaMejora.codigo_Estado = Convert.ToInt32(Constantes.ESTADO_PROPUESTA.REGISTRADA);
                    oPropuestaMejoraLogica.InsertarPropuestaMejora(oPropuestaMejora);
                }
                
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

        protected void CargarModoView() {
            ddlArea.Enabled = false;
            ddlProceso.Enabled = false;
            ddlTipoPropuesta.Enabled = false;
            ddlResponsable.Enabled = false;
            tbxFechaEnvio.Enabled = false;
            tbxObservaciones.Enabled = false;
            tbxDescripcion.Enabled = false;
            tbxCausa.Enabled = false;
            tbxBeneficios.Enabled = false;
            lbtnGuardar.Visible = false;
            lbtnCancelar.Text = "Salir";
        }
    }
}