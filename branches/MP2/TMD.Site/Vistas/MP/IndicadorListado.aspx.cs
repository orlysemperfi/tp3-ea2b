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
using TMD.MP.LogicaNegocios.Excepcion;

namespace TMD.MP.Site.Privado
{
    public partial class IndicadoresListado : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
            String sucess = "false";
            if (!Page.IsPostBack)
            {
                sucess = Request.QueryString["sucess"];
                if (sucess == "true")
                    lblMensajeConfirmacion.Text = "Indicador Registrado";
                else
                    lblMensajeConfirmacion.Text = "";
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
            ddlProceso.Items.Insert(0, new ListItem("[Todos]", "0"));
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
            //PageIndexChanging();
            gvwIndicadorListado.DataBind();
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblMensajeConfirmacion.Text = "";
            CargarIndicadorListado();
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
                    CargarIndicadorListado();
                }
                else
                {
                    lblMensajeError.Text = "El indicador no puede ser borrado.";
                }
            }
            if (e.CommandName == "EditarIndicador")
            {
                IndicadorEntidad oIndicador = oIndicadorLogica.ObtenerIndicadorPorCodigo(Convert.ToInt32(e.CommandArgument));
                
                if (oIndicador.tipo == Constantes.TIPO_INDICADOR_CUALITATIVO) {
                    Sesiones.IndicadorSeleccionado = oIndicador;
                    Response.Redirect(Paginas.TMD_MP_IndicadorFormularioCuali + "?Action=" + Constantes.ACTION_UPDATE,true);
                    
                }

                if (oIndicador.tipo == Constantes.TIPO_INDICADOR_CUANTITATIVO) {
                    Sesiones.IndicadorSeleccionado = oIndicador;
                    Response.Redirect(Paginas.TMD_MP_IndicadorFormularioCuanti + "?Action=" + Constantes.ACTION_UPDATE,true);
                }

            }
        }

        protected void btnAgregarIndicadorCuali_Click(object sender, EventArgs e)
        {
            Sesiones.IndicadorSeleccionadoRemover();
            Sesiones.IndicadorSeleccionado = new IndicadorEntidad();
            Sesiones.IndicadorSeleccionado.lstEscalaCualitativo = new List<EscalaCualitativoEntidad>();
            Response.Redirect(Paginas.TMD_MP_IndicadorFormularioCuali + "?Action=" + Constantes.ACTION_INSERT, true);
        }

        protected void btnAgregarIndicadorCuanti_Click(object sender, EventArgs e)
        {
            Sesiones.IndicadorSeleccionadoRemover();
            Sesiones.IndicadorSeleccionado = new IndicadorEntidad();
            Sesiones.IndicadorSeleccionado.lstEscalaCuantitativo = new List<EscalaCuantitativoEntidad>();
            Response.Redirect(Paginas.TMD_MP_IndicadorFormularioCuanti + "?Action=" + Constantes.ACTION_INSERT, true);
        }

        public String ObtenerDescTipoIndicador(String tipo) {
            return Utilitario.ObtenerDescTipoIndicador(tipo);
        }

        protected void gvwIndicadorListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwIndicadorListado.PageIndex = e.NewPageIndex;
            gvwIndicadorListado.DataBind();
        }

    }
}