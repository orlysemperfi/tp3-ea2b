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
    public partial class SolucionMejoraListado : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                CargarSolucionMejoraListado();
            }
        }


        protected void CargarSolucionMejoraListado() {

            ISolucionMejoraLogica oSolucionMejoraLogica = SolucionMejoraLogica.getInstance();
            SolucionMejoraEntidad oSolucionMejoraFiltro = new SolucionMejoraEntidad();

            if (tbxCodigo.Text != null && tbxCodigo.Text != string.Empty)
                oSolucionMejoraFiltro.codigo_Solucion = Convert.ToInt32(tbxCodigo.Text.ToString());
            if (tbxPropuesta.Text != null && tbxPropuesta.Text != string.Empty)
                oSolucionMejoraFiltro.propuesta = tbxPropuesta.Text.ToString();
            if (tbxFechaInicio.Text != null && tbxFechaInicio.Text != string.Empty)
                oSolucionMejoraFiltro.fecha_Registro_Inicio = Convert.ToDateTime(tbxFechaInicio.Text.ToString());
            if (tbxFechaFin.Text != null && tbxFechaFin.Text != string.Empty)
                oSolucionMejoraFiltro.fecha_Registro_Fin = Convert.ToDateTime(tbxFechaFin.Text.ToString());

            List<SolucionMejoraEntidad> oSolucionMejoraColeccion = oSolucionMejoraLogica.ObtenerSolucionMejoraListadoPorFiltros(oSolucionMejoraFiltro);
            Sesiones.SolucionMejoraListadoRemover();
            Sesiones.SolucionMejoraListado = oSolucionMejoraColeccion;
            //PageIndexChanging();
            gvwSolucionMejoraListado.DataBind();
            lblMensajeError.Text = "";

        }

        protected List<SolucionMejoraEntidad> ObtenerSolucionMejoraListado()
        {
            List<SolucionMejoraEntidad> solucionMejoraListado = Sesiones.SolucionMejoraListado;
            if (solucionMejoraListado == null)
            {
                return null;
            }
            else
            {
                if (solucionMejoraListado.Count == 0)
                {
                    return null;
                }
                else
                {
                    return solucionMejoraListado;
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarSolucionMejoraListado();
        }

        //protected void ibtnIzquierdaTodo_Click(object sender, EventArgs e)
        //{
        //    gvwSolucionMejoraListado.PageIndex = 0;
        //    PageIndexChanging();
        //}

        //protected void ibtnIzquierda_Click(object sender, EventArgs e)
        //{
        //    if (gvwSolucionMejoraListado.PageIndex > 0)
        //        gvwSolucionMejoraListado.PageIndex = gvwSolucionMejoraListado.PageIndex - 1;
        //    else
        //        gvwSolucionMejoraListado.PageIndex = 0;
        //    PageIndexChanging();
        //}

        //protected void ibtnDerecha_Click(object sender, EventArgs e)
        //{
        //    if (gvwSolucionMejoraListado.PageIndex < gvwSolucionMejoraListado.PageCount - 1)
        //        gvwSolucionMejoraListado.PageIndex = gvwSolucionMejoraListado.PageIndex + 1;
        //    else
        //        gvwSolucionMejoraListado.PageIndex = gvwSolucionMejoraListado.PageCount - 1;
        //    PageIndexChanging();
        //}

        //protected void ibtnDerechaTodo_Click(object sender, EventArgs e)
        //{
        //    gvwSolucionMejoraListado.PageIndex = gvwSolucionMejoraListado.PageCount - 1;
        //    PageIndexChanging();
        //}

        //protected void tbxPaginaActual_TextChanged(object sender, EventArgs e)
        //{
        //    gvwSolucionMejoraListado.PageIndex = Convert.ToInt32(tbxPaginaActual.Text) - 1;
        //    PageIndexChanging();
        //}

        //protected void PageIndexChanging()
        //{
        //    gvwSolucionMejoraListado.DataBind();
        //    List<SolucionMejoraEntidad> oSolucionMejoraColeccion = Sesiones.SolucionMejoraListado;

        //    if (oSolucionMejoraColeccion.Count > 0)
        //    {
        //        divMensaje.Visible = false;
        //        lblMensaje.Text = "";
        //        tblSolucionMejoraListado.Visible = true;
        //        divLinea.Visible = true;
        //        tblPaginacion.Visible = true;

        //        tbxPaginaActual.Text = Convert.ToString(gvwSolucionMejoraListado.PageIndex + 1);
        //        lblNumeroPaginas.Text = Convert.ToString(gvwSolucionMejoraListado.PageCount);
        //        if (gvwSolucionMejoraListado.PageIndex == gvwSolucionMejoraListado.PageCount - 1)
        //        {
        //            if (oSolucionMejoraColeccion.Count % gvwSolucionMejoraListado.PageCount == 0)
        //            {
        //                if (gvwSolucionMejoraListado.PageSize > oSolucionMejoraColeccion.Count)
        //                {
        //                    lblNumeroRegistros.Text = (gvwSolucionMejoraListado.PageSize - oSolucionMejoraColeccion.Count) + " - " + oSolucionMejoraColeccion.Count + " de " + oSolucionMejoraColeccion.Count + " registros";
        //                }
        //                else
        //                {
        //                    lblNumeroRegistros.Text = (oSolucionMejoraColeccion.Count - gvwSolucionMejoraListado.PageSize + 1) + " - " + oSolucionMejoraColeccion.Count + " de " + oSolucionMejoraColeccion.Count + " registros";
        //                }
        //            }
        //            else
        //            {
        //                lblNumeroRegistros.Text = (oSolucionMejoraColeccion.Count - (oSolucionMejoraColeccion.Count % gvwSolucionMejoraListado.PageCount) + 1) + " - " + oSolucionMejoraColeccion.Count + " de " + oSolucionMejoraColeccion.Count + " registros";
        //            }
        //        }
        //        else
        //        {
        //            lblNumeroRegistros.Text = ((gvwSolucionMejoraListado.PageSize * (gvwSolucionMejoraListado.PageIndex)) + 1) + " - " + (gvwSolucionMejoraListado.PageSize * (gvwSolucionMejoraListado.PageIndex + 1)) + " de " + oSolucionMejoraColeccion.Count + " registros";
        //        }
        //    }
        //    else
        //    {
        //        divMensaje.Visible = true;
        //        lblMensaje.Text = Mensajes.Mensaje_No_Solucion;
        //        tblSolucionMejoraListado.Visible = false;
        //        divLinea.Visible = false;
        //        tblPaginacion.Visible = false;
        //    }
        //}

        protected void gvwSolucionMejoraListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            ISolucionMejoraLogica oSolucionMejoraLogica = SolucionMejoraLogica.getInstance();
            if (e.CommandName == "EditarSolucion")
            {
                SolucionMejoraEntidad oSolucionMejora = oSolucionMejoraLogica.ObtenerSolucionMejoraPorCodigo(Convert.ToInt32(e.CommandArgument));
                Sesiones.SolucionMejoraSeleccionada = oSolucionMejora;
                if (oSolucionMejora.codigo_Estado == Convert.ToInt32(Constantes.ESTADO_SOLUCION.GENERADA))
                    Response.Redirect(Paginas.TMD_MP_SolucionMejoraFormulario + "?Action=" + Constantes.ACTION_UPDATE, true);
                else
                    Response.Redirect(Paginas.TMD_MP_SolucionMejoraFormulario + "?Action=" + Constantes.ACTION_VIEW, true);
            }
            else if (e.CommandName == "EliminarSolucion")
            {
                SolucionMejoraEntidad oSolucionMejora = oSolucionMejoraLogica.ObtenerSolucionMejoraPorCodigo(Convert.ToInt32(e.CommandArgument));
                String strMensaje = oSolucionMejoraLogica.BorrarSolucionMejora(oSolucionMejora);
                if (strMensaje != null)
                {
                    lblMensajeError.Text = strMensaje;
                }
                else
                {
                    CargarSolucionMejoraListado();
                }
            }
        }

        protected void btnAgregarSolucion_Click(object sender, EventArgs e)
        {
            Sesiones.SolucionMejoraSeleccionadaRemover();

            Sesiones.SolucionMejoraSeleccionada = new SolucionMejoraEntidad();
            Sesiones.SolucionMejoraSeleccionada.lstAcciones = new List<AccionesSolucionEntidad>();
            Response.Redirect(Paginas.TMD_MP_SolucionMejoraFormulario + "?Action=" + Constantes.ACTION_INSERT, true);
        }

        //protected void ibtnSalir_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect(Paginas.TMD_MP_Inicio, true);
        //}

        protected void gvwSolucionMejoraListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwSolucionMejoraListado.PageIndex = e.NewPageIndex;
            gvwSolucionMejoraListado.DataBind();
        }

    }
}