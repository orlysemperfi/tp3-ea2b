using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using TMD.Entidades;
using TMD.MP.Comun;
using System.Web.UI.WebControls;
using TMD.MP.LogicaNegocios.Contrato;
using TMD.MP.LogicaNegocios.Implementacion;

namespace TMD.CF.Site.Vistas.MP
{
    public partial class PropuestaMejoraDesarrollo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack){
                CargarTipoPropuesta();
                CargarPropuestaMejoraListado();                
            }

        }

        protected void CargarTipoPropuesta()
        {
            ddlTipo.Items.Add(new ListItem("[Todos]", ""));
            ddlTipo.Items.Add(new ListItem(Constantes.TIPO_PROPUESTA_PROBLEMA, Constantes.TIPO_PROPUESTA_PROBLEMA));
            ddlTipo.Items.Add(new ListItem(Constantes.TIPO_PROPUESTA_MEJORA, Constantes.TIPO_PROPUESTA_MEJORA));
            ddlTipo.SelectedIndex = 0;
        }


        protected void CargarPropuestaMejoraListado()
        {
            IPropuestaMejoraLogica oPropuestaMejoraLogica = PropuestaMejoraLogica.getInstance();
            PropuestaMejoraEntidad oPropuestaMejoraFiltro = new PropuestaMejoraEntidad();

            if (tbxCodigo.Text != null && tbxCodigo.Text != string.Empty)
                oPropuestaMejoraFiltro.codigo_Propuesta = Convert.ToInt32(tbxCodigo.Text.ToString());
            if (tbxFechaInicio.Text != null && tbxFechaInicio.Text != string.Empty)
                oPropuestaMejoraFiltro.fecha_Registro_Inicio = Convert.ToDateTime(tbxFechaInicio.Text.ToString());
            if (tbxFechaFin.Text != null && tbxFechaFin.Text != string.Empty)
                oPropuestaMejoraFiltro.fecha_Registro_Fin = Convert.ToDateTime(tbxFechaFin.Text.ToString());

            oPropuestaMejoraFiltro.tipo_Propuesta = ddlTipo.SelectedItem.Value;
            List<PropuestaMejoraEntidad> oPropuestaMejoraColeccion = oPropuestaMejoraLogica.ObtenerPropuestaMejoraAsignadasListadoPorFiltros(oPropuestaMejoraFiltro);
            Sesiones.PropuestaMejoraListadoRemover();
            Sesiones.PropuestaMejoraListado = oPropuestaMejoraColeccion;
            gvwPropuestaMejoraListado.DataBind();
            //PageIndexChanging();
            //lblMensajeError.Text = "";
        }

        protected List<PropuestaMejoraEntidad> ObtenerPropuestaMejoraListado()
        {
            List<PropuestaMejoraEntidad> propuestaMejoraListado = Sesiones.PropuestaMejoraListado;
            if (propuestaMejoraListado == null)
            {
                return null;
            }
            else
            {
                if (propuestaMejoraListado.Count == 0)
                {
                    return null;
                }
                else
                {
                    return propuestaMejoraListado;
                }
            }
        }
        
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarPropuestaMejoraListado();
        }


        protected void gvwPropuestaMejoraDesarrollo_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            IPropuestaMejoraLogica oPropuestaMejoraLogica = PropuestaMejoraLogica.getInstance();
            if (e.CommandName == "EditarPropuesta")
            {
                PropuestaMejoraEntidad oPropuestaMejora = oPropuestaMejoraLogica.ObtenerPropuestaMejoraPorCodigo(Convert.ToInt32(e.CommandArgument));
                Sesiones.PropuestaMejoraSeleccionada = oPropuestaMejora;
                if (oPropuestaMejora.codigo_Estado == Convert.ToInt32(Constantes.ESTADO_PROPUESTA.REGISTRADA))
                    Response.Redirect(Paginas.TMD_MP_PropuestaMejoraFormulario + "?Action=" + Constantes.ACTION_UPDATE, true);
                else
                    Response.Redirect(Paginas.TMD_MP_PropuestaMejoraFormulario + "?Action=" + Constantes.ACTION_VIEW, true);
            }
            else if (e.CommandName == "EliminarPropuesta")
            {
                PropuestaMejoraEntidad oPropuestaMejora = oPropuestaMejoraLogica.ObtenerPropuestaMejoraPorCodigo(Convert.ToInt32(e.CommandArgument));
                String strMensaje = oPropuestaMejoraLogica.BorrarPropuestaMejora(oPropuestaMejora);
                if (strMensaje != null)
                {
                    lblMensajeError.Text = strMensaje;
                }
                else
                {
                    CargarPropuestaMejoraListado();
                }
            }
        }

        protected void btnCambiarEstadoEnDesarrollo_Click(object sender, EventArgs e)
        {

            int count = 0;

            foreach (GridViewRow row in gvwPropuestaMejoraListado.Rows)
            {
                CheckBox check = row.FindControl("chkPropuestaSel") as CheckBox;
                if (check.Checked)
                    count++;
            }

            if (count == 0){
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                      "err_msg",
                      "alert('Seleccione al menos un Proceso');",
                      true);
                return;
            }else{
                PropuestaMejoraEntidad oPropuestaMejoraEntidad = null;
                IPropuestaMejoraLogica oPropuestaMejoraLogica = PropuestaMejoraLogica.getInstance();
                foreach (GridViewRow row in gvwPropuestaMejoraListado.Rows)
                {
                    CheckBox check = row.FindControl("chkPropuestaSel") as CheckBox;
                    oPropuestaMejoraEntidad = new PropuestaMejoraEntidad();
                    String llbl = ((Label)row.Cells[0].FindControl("lblCodigo")).Text;
                    oPropuestaMejoraEntidad.codigo_Propuesta = Convert.ToInt32(llbl);
                    oPropuestaMejoraEntidad.codigo_Estado = Convert.ToInt32(Constantes.ESTADO_PROPUESTA.DESARROLLO);


                    if (check.Checked)
                    {
                        oPropuestaMejoraLogica.ActualizarEstadoPropuestaMejora(oPropuestaMejoraEntidad);
                    }
                }
            }

            string currentURL = Request.Url.ToString();
            string newURL = currentURL.Substring(0, currentURL.LastIndexOf("/"));

            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
            "alert('Se actualizaron las Propuestas Seleccionadas al estado En Desarrollo'); window.location='" +
            newURL + "/PropuestaMejoraDesarrollo.aspx';", true);

        }

        //protected void ibtnSalir_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect(Paginas.TMD_MP_Inicio, true);
        //}

        protected void gvwPropuestaMejoraListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwPropuestaMejoraListado.PageIndex = e.NewPageIndex;
            gvwPropuestaMejoraListado.DataBind();
        }
    }


}