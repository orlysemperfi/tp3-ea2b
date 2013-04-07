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
    public partial class PropuestaMejoraLista : System.Web.UI.Page
    {
        String sucess = "false";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                sucess = Request.QueryString["sucess"];

                if (sucess == "true")
                    lblMensajeConfirmacion.Text = "Propuesta Registrada";
                else
                    lblMensajeConfirmacion.Text = "";
                CargarTipoPropuesta();
                CargarPropuestaMejoraListado();
            }
        }

        protected void CargarTipoPropuesta() {
            ddlTipo.Items.Add(new ListItem("[Todos]", ""));
            ddlTipo.Items.Add(new ListItem(Constantes.TIPO_PROPUESTA_PROBLEMA, Constantes.TIPO_PROPUESTA_PROBLEMA));
            ddlTipo.Items.Add(new ListItem(Constantes.TIPO_PROPUESTA_MEJORA, Constantes.TIPO_PROPUESTA_MEJORA));
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
            //PageIndexChanging();
            gvwPropuestaMejoraListado.DataBind();
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarPropuestaMejoraListado();
            lblMensajeConfirmacion.Text = "";
            
        }

        protected void gvwPropuestaMejoraListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            IPropuestaMejoraLogica oPropuestaMejoraLogica = PropuestaMejoraLogica.getInstance();
            if (e.CommandName == "EditarPropuesta") {
                PropuestaMejoraEntidad oPropuestaMejora = oPropuestaMejoraLogica.ObtenerPropuestaMejoraPorCodigo(Convert.ToInt32(e.CommandArgument));
                Sesiones.PropuestaMejoraSeleccionada = oPropuestaMejora;
                if(oPropuestaMejora.codigo_Estado == Convert.ToInt32( Constantes.ESTADO_PROPUESTA.REGISTRADA))
                    Response.Redirect(Paginas.TMD_MP_PropuestaMejoraFormulario+"?Action="+Constantes.ACTION_UPDATE,true);
                else
                    Response.Redirect(Paginas.TMD_MP_PropuestaMejoraFormulario + "?Action=" + Constantes.ACTION_VIEW, true);
            }else if(e.CommandName == "EliminarPropuesta"){
                PropuestaMejoraEntidad oPropuestaMejora = oPropuestaMejoraLogica.ObtenerPropuestaMejoraPorCodigo(Convert.ToInt32(e.CommandArgument));
                try
                {
                    oPropuestaMejoraLogica.BorrarPropuestaMejora(oPropuestaMejora);
                    CargarPropuestaMejoraListado();
                }
                catch (BRuleException ex)
                {
                    lblMensajeError.Text = ex.Message;
                    lblMensajeError.DataBind();
                }
                
                             
            }
        }

        protected void btnAgregarPropuesta_Click(object sender, EventArgs e)
        {
            Sesiones.PropuestaMejoraSeleccionadaRemover();
            Response.Redirect(Paginas.TMD_MP_PropuestaMejoraFormulario + "?Action=" + Constantes.ACTION_INSERT, true);
        }

        protected void gvwPropuestaMejoraListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwPropuestaMejoraListado.PageIndex = e.NewPageIndex;
            gvwPropuestaMejoraListado.DataBind();
        }
    }
}