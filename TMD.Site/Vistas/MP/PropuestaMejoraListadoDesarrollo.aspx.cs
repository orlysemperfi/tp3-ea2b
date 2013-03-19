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
    public partial class PropuestaMejoraListadoDesarrollo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
            Sesiones.PropuestaMejoraDesarrolloListadoRemover();
            Sesiones.PropuestaMejoraDesarrolloListado = oPropuestaMejoraColeccion;
            //PageIndexChanging();
            gvwPropuestaMejoraListado.DataBind();
            lblMensajeError.Text = "";
        }

        protected List<PropuestaMejoraEntidad> ObtenerPropuestaMejoraListado()
        {
            List<PropuestaMejoraEntidad> propuestaMejoraListado = Sesiones.PropuestaMejoraDesarrolloListado;
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

        //protected void ibtnIzquierdaTodo_Click(object sender, EventArgs e)
        //{
        //    gvwPropuestaMejoraListado.PageIndex = 0;
        //    PageIndexChanging();
        //}

        //protected void ibtnIzquierda_Click(object sender, EventArgs e)
        //{
        //    if (gvwPropuestaMejoraListado.PageIndex > 0)
        //        gvwPropuestaMejoraListado.PageIndex = gvwPropuestaMejoraListado.PageIndex - 1;
        //    else
        //        gvwPropuestaMejoraListado.PageIndex = 0;
        //    PageIndexChanging();
        //}

        //protected void ibtnDerecha_Click(object sender, EventArgs e)
        //{
        //    if (gvwPropuestaMejoraListado.PageIndex < gvwPropuestaMejoraListado.PageCount - 1)
        //        gvwPropuestaMejoraListado.PageIndex = gvwPropuestaMejoraListado.PageIndex + 1;
        //    else
        //        gvwPropuestaMejoraListado.PageIndex = gvwPropuestaMejoraListado.PageCount - 1;
        //    PageIndexChanging();
        //}

        //protected void ibtnDerechaTodo_Click(object sender, EventArgs e)
        //{
        //    gvwPropuestaMejoraListado.PageIndex = gvwPropuestaMejoraListado.PageCount - 1;
        //    PageIndexChanging();
        //}

        //protected void tbxPaginaActual_TextChanged(object sender, EventArgs e)
        //{
        //    gvwPropuestaMejoraListado.PageIndex = Convert.ToInt32(tbxPaginaActual.Text) - 1;
        //    PageIndexChanging();
        //}

        //protected void PageIndexChanging() {
        //    gvwPropuestaMejoraListado.DataBind();
        //    List<PropuestaMejoraEntidad> oPropuestaMejoraColeccion = Sesiones.PropuestaMejoraListado;

        //    if (oPropuestaMejoraColeccion.Count > 0)
        //    {
        //        divMensaje.Visible = false;
        //        lblMensaje.Text = "";
        //        tblPropuestaMejoraListado.Visible = true;
        //        divLinea.Visible = true;
        //        tblPaginacion.Visible = true;

        //        tbxPaginaActual.Text = Convert.ToString(gvwPropuestaMejoraListado.PageIndex + 1);
        //        lblNumeroPaginas.Text = Convert.ToString(gvwPropuestaMejoraListado.PageCount);
        //        if (gvwPropuestaMejoraListado.PageIndex == gvwPropuestaMejoraListado.PageCount - 1)
        //        {
        //            if (oPropuestaMejoraColeccion.Count % gvwPropuestaMejoraListado.PageCount == 0)
        //            {
        //                if (gvwPropuestaMejoraListado.PageSize > oPropuestaMejoraColeccion.Count)
        //                {
        //                    lblNumeroRegistros.Text = (gvwPropuestaMejoraListado.PageSize - oPropuestaMejoraColeccion.Count) + " - " + oPropuestaMejoraColeccion.Count + " de " + oPropuestaMejoraColeccion.Count + " registros";
        //                }
        //                else
        //                {
        //                    lblNumeroRegistros.Text = (oPropuestaMejoraColeccion.Count - gvwPropuestaMejoraListado.PageSize + 1) + " - " + oPropuestaMejoraColeccion.Count + " de " + oPropuestaMejoraColeccion.Count + " registros";
        //                }
        //            }
        //            else
        //            {
        //                lblNumeroRegistros.Text = (oPropuestaMejoraColeccion.Count - (oPropuestaMejoraColeccion.Count % gvwPropuestaMejoraListado.PageCount) + 1) + " - " + oPropuestaMejoraColeccion.Count + " de " + oPropuestaMejoraColeccion.Count + " registros";
        //            }
        //        }
        //        else
        //        {
        //            lblNumeroRegistros.Text = ((gvwPropuestaMejoraListado.PageSize * (gvwPropuestaMejoraListado.PageIndex)) + 1) + " - " + (gvwPropuestaMejoraListado.PageSize * (gvwPropuestaMejoraListado.PageIndex + 1)) + " de " + oPropuestaMejoraColeccion.Count + " registros";
        //        }
        //    }
        //    else
        //    {
        //        divMensaje.Visible = true;
        //        lblMensaje.Text = Mensajes.Mensaje_No_Propuesta_Mejora;
        //        tblPropuestaMejoraListado.Visible = false;
        //        divLinea.Visible = false;
        //        tblPaginacion.Visible = false;
        //    }
        //}

        protected void gvwPropuestaMejoraListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            IPropuestaMejoraLogica oPropuestaMejoraLogica = PropuestaMejoraLogica.getInstance();
            if (e.CommandName == "VerPropuesta")
            {
                PropuestaMejoraEntidad oPropuestaMejora = oPropuestaMejoraLogica.ObtenerPropuestaMejoraPorCodigo(Convert.ToInt32(e.CommandArgument));
                oPropuestaMejora.enDesarrollo = true;
                Sesiones.PropuestaMejoraSeleccionadaRemover();
                Sesiones.PropuestaMejoraSeleccionada = oPropuestaMejora;
                Response.Redirect(Paginas.TMD_MP_PropuestaMejoraFormulario + "?Action=" + Constantes.ACTION_VIEW, true);
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

            if (count == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                      "err_msg",
                      "alert('Seleccione al menos un Proceso');",
                      true);
                return;
            }
            else
            {
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