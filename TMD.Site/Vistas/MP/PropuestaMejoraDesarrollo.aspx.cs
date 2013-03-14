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
        
        protected void lbtnBuscar_Click(object sender, EventArgs e)
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

        protected void ibtnCambiarEstadoEnDesarrollo_Click(object sender, EventArgs e)
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