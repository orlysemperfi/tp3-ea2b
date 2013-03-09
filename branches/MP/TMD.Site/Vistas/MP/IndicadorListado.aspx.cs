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
    public partial class IndicadoresListado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarTipoIndicador();                
                CargarArea();
                CargarProceso();
                CargarIndicadorListado();
            }
        }

        protected void CargarTipoIndicador()
        {
            ddlTipo.Items.Add(new ListItem("[Todos]", "-1"));
            ddlTipo.Items.Add(new ListItem(ObtenerDescTipoIndicador("0"), "0"));
            ddlTipo.Items.Add(new ListItem(ObtenerDescTipoIndicador("1"), "1"));
            ddlTipo.SelectedIndex = 0;
        }

        protected void CargarArea()
        {
            IAreaLogica oAreaLogica = AreaLogica.getInstance();
            ddlArea.DataSource = oAreaLogica.ObtenerListaAreaTodas();
            ddlArea.DataTextField = "DESCRIPCION";
            ddlArea.DataValueField = "CODIGO";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("[Todos]", "0"));
        }

        protected void CargarProceso()
        {
            IProcesoLogica oProcesoLogica = ProcesoLogica.getInstance();
            List<ProcesoEntidad> oProcesoColeccion = oProcesoLogica.ObtenerListaProcesoTodas();
            ddlProceso.DataSource = oProcesoColeccion;
            ddlProceso.DataTextField = "NOMBRE";
            ddlProceso.DataValueField = "CODIGO";
            ddlProceso.DataBind();
            ddlArea.Items.Insert(0, new ListItem("[Todos]", "0"));
        }

        protected void CargarIndicadorListado()
        {
            IIndicadorLogica oIndicadorLogica = IndicadorLogica.getInstance();
            IndicadorEntidad oIndicadorFiltro = new IndicadorEntidad();

            if (tbxNombre.Text != null && tbxNombre.Text != string.Empty)
                oIndicadorFiltro.nombre = tbxNombre.Text.ToString();
                oIndicadorFiltro.tipo = Convert.ToInt32(ddlTipo.SelectedItem.Value);          
            if (ddlArea.SelectedIndex != 0)
                oIndicadorFiltro.codigo_Area = Convert.ToInt32(ddlArea.SelectedItem.Value);
            if (ddlProceso.SelectedIndex != 0)
                oIndicadorFiltro.codigo_Proceso = Convert.ToInt32(ddlProceso.SelectedItem.Value);

            List<IndicadorEntidad> oIndicadorColeccion = oIndicadorLogica.ObtenerIndicadorListadoPorFiltros(oIndicadorFiltro);
            Sesiones.IndicadorListadoRemover();
            Sesiones.IndicadorListado = oIndicadorColeccion;
            PageIndexChanging();
            lblMensajeError.Text = "";
        }

        protected List<IndicadorEntidad> ObtenerIndicadorListado()
        {
            List<IndicadorEntidad> indicadorListado = Sesiones.IndicadorListado;
            if (indicadorListado == null)
            {
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

        protected void lbtnBuscar_Click(object sender, EventArgs e)
        {
            CargarIndicadorListado();
        }

        protected void ibtnIzquierdaTodo_Click(object sender, EventArgs e)
        {
            gvwIndicadorListado.PageIndex = 0;
            PageIndexChanging();
        }

        protected void ibtnIzquierda_Click(object sender, EventArgs e)
        {
            if (gvwIndicadorListado.PageIndex > 0)
                gvwIndicadorListado.PageIndex = gvwIndicadorListado.PageIndex - 1;
            else
                gvwIndicadorListado.PageIndex = 0;
            PageIndexChanging();
        }

        protected void ibtnDerecha_Click(object sender, EventArgs e)
        {
            if (gvwIndicadorListado.PageIndex < gvwIndicadorListado.PageCount - 1)
                gvwIndicadorListado.PageIndex = gvwIndicadorListado.PageIndex + 1;
            else
                gvwIndicadorListado.PageIndex = gvwIndicadorListado.PageCount - 1;
            PageIndexChanging();
        }

        protected void ibtnDerechaTodo_Click(object sender, EventArgs e)
        {
            gvwIndicadorListado.PageIndex = gvwIndicadorListado.PageCount - 1;
            PageIndexChanging();
        }

        protected void tbxPaginaActual_TextChanged(object sender, EventArgs e)
        {
            gvwIndicadorListado.PageIndex = Convert.ToInt32(tbxPaginaActual.Text) - 1;
            PageIndexChanging();
        }

        protected void PageIndexChanging()
        {
            gvwIndicadorListado.DataBind();
            List<IndicadorEntidad> oIndicadorColeccion = Sesiones.IndicadorListado;

            if (oIndicadorColeccion.Count > 0)
            {
                divMensaje.Visible = false;
                lblMensaje.Text = "";
                tblIndicadorListado.Visible = true;
                divLinea.Visible = true;
                tblPaginacion.Visible = true;

                tbxPaginaActual.Text = Convert.ToString(gvwIndicadorListado.PageIndex + 1);
                lblNumeroPaginas.Text = Convert.ToString(gvwIndicadorListado.PageCount);
                if (gvwIndicadorListado.PageIndex == gvwIndicadorListado.PageCount - 1)
                {
                    if (oIndicadorColeccion.Count % gvwIndicadorListado.PageCount == 0)
                    {
                        if (gvwIndicadorListado.PageSize > oIndicadorColeccion.Count)
                        {
                            lblNumeroRegistros.Text = (gvwIndicadorListado.PageSize - oIndicadorColeccion.Count) + " - " + oIndicadorColeccion.Count + " de " + oIndicadorColeccion.Count + " registros";
                        }
                        else
                        {
                            lblNumeroRegistros.Text = (oIndicadorColeccion.Count - gvwIndicadorListado.PageSize + 1) + " - " + oIndicadorColeccion.Count + " de " + oIndicadorColeccion.Count + " registros";
                        }
                    }
                    else
                    {
                        lblNumeroRegistros.Text = (oIndicadorColeccion.Count - (oIndicadorColeccion.Count % gvwIndicadorListado.PageCount) + 1) + " - " + oIndicadorColeccion.Count + " de " + oIndicadorColeccion.Count + " registros";
                    }
                }
                else
                {
                    lblNumeroRegistros.Text = ((gvwIndicadorListado.PageSize * (gvwIndicadorListado.PageIndex)) + 1) + " - " + (gvwIndicadorListado.PageSize * (gvwIndicadorListado.PageIndex + 1)) + " de " + oIndicadorColeccion.Count + " registros";
                }
            }
            else
            {
                divMensaje.Visible = true;
                lblMensaje.Text = "No se encontró indicadores";
                tblIndicadorListado.Visible = false;
                divLinea.Visible = false;
                tblPaginacion.Visible = false;
            }
        }

        protected void gvwIndicadorListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            IIndicadorLogica oIndicadorLogica = IndicadorLogica.getInstance();
            if (e.CommandName == "InactivarIndicador")
            {

                IndicadorEntidad oIndicador = oIndicadorLogica.ObtenerIndicadorPorCodigo(Convert.ToInt32(e.CommandArgument));

                if (oIndicador.codigo !=null)
                {
                    oIndicadorLogica.InactivarIndicador(oIndicador);
                }
                else
                {
                    lblMensajeError.Text = "El indicador no puede ser borrado.";
                }
            }
        }

        protected void BorrarIndicador(IndicadorEntidad oIndicador)
        {
            oIndicador.codigo = 4;
            //indicadorControlador.ActualizarEstadoPropuestaMejora(oIndicador);
            Response.Redirect(Paginas.TMD_MP_IndicadorListado, true);
        }

        protected void ibtnAgregarIndicador_Click(object sender, EventArgs e)
        {
            Sesiones.IndicadorSeleccionadoRemover();
            Response.Redirect(Paginas.TMD_MP_IndicadorFormulario + "?Action=" + Constantes.ACTION_INSERT, true);
        }

        protected void ibtnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect(Paginas.TMD_MP_Inicio, true);
        }
        public String ObtenerDescTipoIndicador(String tipo) {
            return Utilitario.ObtenerDescTipoIndicador(tipo);
        }

    }
}