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
    public partial class PropuestaMejoraLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                CargarTipoPropuesta();
                CargarPropuestaMejoraListado();
            }
        }

        protected void CargarTipoPropuesta() {
            ddlTipo.Items.Add(new ListItem("[Todos]", ""));
            ddlTipo.Items.Add(new ListItem("Problema", "Problema"));
            ddlTipo.Items.Add(new ListItem("Mejora", "Mejora"));
            ddlTipo.SelectedIndex = 0;
        }

        protected void CargarPropuestaMejoraListado() {
            IPropuestaMejoraLogica oPropuestaMejoraLogica = PropuestaMejoraLogica.getInstance(); 
            PropuestaMejoraEntidad oPropuestaMejoraFiltro = new PropuestaMejoraEntidad();

            if (tbxCodigo.Text != null && tbxCodigo.Text != string.Empty)
                oPropuestaMejoraFiltro.codigo_Propuesta = Convert.ToInt32(tbxCodigo.Text.ToString());            
            if (tbxFechaInicio.Text != null && tbxFechaInicio.Text != string.Empty)
                 oPropuestaMejoraFiltro.fecha_Registro_Inicio = Convert.ToDateTime(tbxFechaInicio.Text.ToString());
            if (tbxFechaFin.Text != null && tbxFechaFin.Text != string.Empty)
                oPropuestaMejoraFiltro.fecha_Registro_Fin = Convert.ToDateTime(tbxFechaFin.Text.ToString());
            
            oPropuestaMejoraFiltro.tipo_Propuesta = ddlTipo.SelectedItem.Value;
            List<PropuestaMejoraEntidad> oPropuestaMejoraColeccion = oPropuestaMejoraLogica.ObtenerPropuestaMejoraListadoPorFiltros(oPropuestaMejoraFiltro);
            Sesiones.PropuestaMejoraListadoRemover();
            Sesiones.PropuestaMejoraListado = oPropuestaMejoraColeccion;
            PageIndexChanging();
            lblMensajeError.Text = "";
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
                else {
                    return propuestaMejoraListado;
                }                
            }
        }

        protected void lbtnBuscar_Click(object sender, EventArgs e)
        {
            CargarPropuestaMejoraListado();
        }

        protected void ibtnIzquierdaTodo_Click(object sender, EventArgs e)
        {
            gvwPropuestaMejoraListado.PageIndex = 0;
            PageIndexChanging();
        }

        protected void ibtnIzquierda_Click(object sender, EventArgs e)
        {
            if (gvwPropuestaMejoraListado.PageIndex > 0)
                gvwPropuestaMejoraListado.PageIndex = gvwPropuestaMejoraListado.PageIndex - 1;
            else
                gvwPropuestaMejoraListado.PageIndex = 0;
            PageIndexChanging();
        }

        protected void ibtnDerecha_Click(object sender, EventArgs e)
        {
            if (gvwPropuestaMejoraListado.PageIndex < gvwPropuestaMejoraListado.PageCount - 1)
                gvwPropuestaMejoraListado.PageIndex = gvwPropuestaMejoraListado.PageIndex + 1;
            else
                gvwPropuestaMejoraListado.PageIndex = gvwPropuestaMejoraListado.PageCount - 1;
            PageIndexChanging();
        }

        protected void ibtnDerechaTodo_Click(object sender, EventArgs e)
        {
            gvwPropuestaMejoraListado.PageIndex = gvwPropuestaMejoraListado.PageCount - 1;
            PageIndexChanging();
        }

        protected void tbxPaginaActual_TextChanged(object sender, EventArgs e)
        {
            gvwPropuestaMejoraListado.PageIndex = Convert.ToInt32(tbxPaginaActual.Text) - 1;
            PageIndexChanging();
        }

        protected void PageIndexChanging() {
            gvwPropuestaMejoraListado.DataBind();
            List<PropuestaMejoraEntidad> oPropuestaMejoraColeccion = Sesiones.PropuestaMejoraListado;

            if (oPropuestaMejoraColeccion.Count > 0)
            {
                divMensaje.Visible = false;
                lblMensaje.Text = "";
                tblPropuestaMejoraListado.Visible = true;
                divLinea.Visible = true;
                tblPaginacion.Visible = true;

                tbxPaginaActual.Text = Convert.ToString(gvwPropuestaMejoraListado.PageIndex + 1);
                lblNumeroPaginas.Text = Convert.ToString(gvwPropuestaMejoraListado.PageCount);
                if (gvwPropuestaMejoraListado.PageIndex == gvwPropuestaMejoraListado.PageCount - 1)
                {
                    if (oPropuestaMejoraColeccion.Count % gvwPropuestaMejoraListado.PageCount == 0)
                    {
                        if (gvwPropuestaMejoraListado.PageSize > oPropuestaMejoraColeccion.Count)
                        {
                            lblNumeroRegistros.Text = (gvwPropuestaMejoraListado.PageSize - oPropuestaMejoraColeccion.Count) + " - " + oPropuestaMejoraColeccion.Count + " de " + oPropuestaMejoraColeccion.Count + " registros";
                        }
                        else
                        {
                            lblNumeroRegistros.Text = (oPropuestaMejoraColeccion.Count - gvwPropuestaMejoraListado.PageSize + 1) + " - " + oPropuestaMejoraColeccion.Count + " de " + oPropuestaMejoraColeccion.Count + " registros";
                        }
                    }
                    else
                    {
                        lblNumeroRegistros.Text = (oPropuestaMejoraColeccion.Count - (oPropuestaMejoraColeccion.Count % gvwPropuestaMejoraListado.PageCount) + 1) + " - " + oPropuestaMejoraColeccion.Count + " de " + oPropuestaMejoraColeccion.Count + " registros";
                    }
                }
                else
                {
                    lblNumeroRegistros.Text = ((gvwPropuestaMejoraListado.PageSize * (gvwPropuestaMejoraListado.PageIndex)) + 1) + " - " + (gvwPropuestaMejoraListado.PageSize * (gvwPropuestaMejoraListado.PageIndex + 1)) + " de " + oPropuestaMejoraColeccion.Count + " registros";
                }
            }
            else
            {
                divMensaje.Visible = true;
                lblMensaje.Text = "No se encontró propuestas de mejora";
                tblPropuestaMejoraListado.Visible = false;
                divLinea.Visible = false;
                tblPaginacion.Visible = false;
            }
        }

        protected void gvwPropuestaMejoraListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            IPropuestaMejoraLogica oPropuestaMejoraLogica = PropuestaMejoraLogica.getInstance();
            if (e.CommandName == "EditarPropuesta") {
                PropuestaMejoraEntidad oPropuestaMejora = oPropuestaMejoraLogica.ObtenerPropuestaMejoraPorCodigo(Convert.ToInt32(e.CommandArgument));
                Sesiones.PropuestaMejoraSeleccionada = oPropuestaMejora;
                Response.Redirect(Paginas.TMD_MP_PropuestaMejoraFormulario+"?Action="+Constantes.ACTION_UPDATE,true);
            }else if(e.CommandName == "EliminarPropuesta"){
                PropuestaMejoraEntidad oPropuestaMejora = oPropuestaMejoraLogica.ObtenerPropuestaMejoraPorCodigo(Convert.ToInt32(e.CommandArgument));
                String strMensaje = oPropuestaMejoraLogica.BorrarPropuestaMejora(oPropuestaMejora);
                if (strMensaje != null)
                {
                    lblMensajeError.Text = strMensaje;
                }

            }
        }

        protected void BorrarPropuestaMejora(PropuestaMejoraEntidad oPropuestaMejora)
        {
            IPropuestaMejoraLogica oPropuestaMejoraLogica = PropuestaMejoraLogica.getInstance();
            oPropuestaMejora.codigo_Estado = 4;
            oPropuestaMejoraLogica.ActualizarEstadoPropuestaMejora(oPropuestaMejora);
            Response.Redirect(Paginas.TMD_MP_PropuestaMejoraListado, true);
        }

        protected void ibtnAgregarPropuesta_Click(object sender, EventArgs e)
        {
            Sesiones.PropuestaMejoraSeleccionadaRemover();
            Response.Redirect(Paginas.TMD_MP_PropuestaMejoraFormulario + "?Action=" + Constantes.ACTION_INSERT, true);
        }

        protected void ibtnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect(Paginas.TMD_MP_Inicio, true);
        }
    }
}