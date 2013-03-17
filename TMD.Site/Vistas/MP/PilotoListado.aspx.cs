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
    public partial class PilotoListado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                CargarPilotoListado();
            }
        }

        protected void CargarPilotoListado() {
            IPilotoLogica oPilotoLogica = PilotoLogica.getInstance(); 
            PilotoEntidad oPilotoFiltro = new PilotoEntidad();

            if (tbxCodigo.Text != null && tbxCodigo.Text != string.Empty)
                oPilotoFiltro.codigo = Convert.ToInt32(tbxCodigo.Text.ToString());            
            if (tbxFechaInicio.Text != null && tbxFechaInicio.Text != string.Empty)
                 oPilotoFiltro.fecha_Inicio = Convert.ToDateTime(tbxFechaInicio.Text.ToString());
            if (tbxFechaFin.Text != null && tbxFechaFin.Text != string.Empty)
                oPilotoFiltro.fecha_Fin = Convert.ToDateTime(tbxFechaFin.Text.ToString());
            
            List<PilotoEntidad> oPilotoColeccion = oPilotoLogica.ObtenerPilotoListadoPorFiltros(oPilotoFiltro);
            Sesiones.PilotoListadoRemover();
            Sesiones.PilotoListado = oPilotoColeccion;
            //PageIndexChanging();
            gvwPilotoListado.DataBind();
            lblMensajeError.Text = "";
        }

        protected List<PilotoEntidad> ObtenerPilotoListado()
        {
            List<PilotoEntidad> PilotoListado = Sesiones.PilotoListado;
            if (PilotoListado == null)
            {
                return null;
            }
            else
            {
                if (PilotoListado.Count == 0)
                {
                    return null;
                }
                else {
                    return PilotoListado;
                }                
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarPilotoListado();
        }

        //protected void ibtnIzquierdaTodo_Click(object sender, EventArgs e)
        //{
        //    gvwPilotoListado.PageIndex = 0;
        //    PageIndexChanging();
        //}

        //protected void ibtnIzquierda_Click(object sender, EventArgs e)
        //{
        //    if (gvwPilotoListado.PageIndex > 0)
        //        gvwPilotoListado.PageIndex = gvwPilotoListado.PageIndex - 1;
        //    else
        //        gvwPilotoListado.PageIndex = 0;
        //    PageIndexChanging();
        //}

        //protected void ibtnDerecha_Click(object sender, EventArgs e)
        //{
        //    if (gvwPilotoListado.PageIndex < gvwPilotoListado.PageCount - 1)
        //        gvwPilotoListado.PageIndex = gvwPilotoListado.PageIndex + 1;
        //    else
        //        gvwPilotoListado.PageIndex = gvwPilotoListado.PageCount - 1;
        //    PageIndexChanging();
        //}

        //protected void ibtnDerechaTodo_Click(object sender, EventArgs e)
        //{
        //    gvwPilotoListado.PageIndex = gvwPilotoListado.PageCount - 1;
        //    PageIndexChanging();
        //}

        //protected void tbxPaginaActual_TextChanged(object sender, EventArgs e)
        //{
        //    gvwPilotoListado.PageIndex = Convert.ToInt32(tbxPaginaActual.Text) - 1;
        //    PageIndexChanging();
        //}

        //protected void PageIndexChanging() {
        //    gvwPilotoListado.DataBind();
        //    List<PilotoEntidad> oPilotoColeccion = Sesiones.PilotoListado;

        //    if (oPilotoColeccion.Count > 0)
        //    {
        //        divMensaje.Visible = false;
        //        lblMensaje.Text = "";
        //        tblPilotoListado.Visible = true;
        //        divLinea.Visible = true;
        //        tblPaginacion.Visible = true;

        //        tbxPaginaActual.Text = Convert.ToString(gvwPilotoListado.PageIndex + 1);
        //        lblNumeroPaginas.Text = Convert.ToString(gvwPilotoListado.PageCount);
        //        if (gvwPilotoListado.PageIndex == gvwPilotoListado.PageCount - 1)
        //        {
        //            if (oPilotoColeccion.Count % gvwPilotoListado.PageCount == 0)
        //            {
        //                if (gvwPilotoListado.PageSize > oPilotoColeccion.Count)
        //                {
        //                    lblNumeroRegistros.Text = (gvwPilotoListado.PageSize - oPilotoColeccion.Count) + " - " + oPilotoColeccion.Count + " de " + oPilotoColeccion.Count + " registros";
        //                }
        //                else
        //                {
        //                    lblNumeroRegistros.Text = (oPilotoColeccion.Count - gvwPilotoListado.PageSize + 1) + " - " + oPilotoColeccion.Count + " de " + oPilotoColeccion.Count + " registros";
        //                }
        //            }
        //            else
        //            {
        //                lblNumeroRegistros.Text = (oPilotoColeccion.Count - (oPilotoColeccion.Count % gvwPilotoListado.PageCount) + 1) + " - " + oPilotoColeccion.Count + " de " + oPilotoColeccion.Count + " registros";
        //            }
        //        }
        //        else
        //        {
        //            lblNumeroRegistros.Text = ((gvwPilotoListado.PageSize * (gvwPilotoListado.PageIndex)) + 1) + " - " + (gvwPilotoListado.PageSize * (gvwPilotoListado.PageIndex + 1)) + " de " + oPilotoColeccion.Count + " registros";
        //        }
        //    }
        //    else
        //    {
        //        divMensaje.Visible = true;
        //        lblMensaje.Text = Mensajes.Mensaje_No_Propuesta_Mejora;
        //        tblPilotoListado.Visible = false;
        //        divLinea.Visible = false;
        //        tblPaginacion.Visible = false;
        //    }
        //}

        protected void gvwPilotoListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            IPilotoLogica oPilotoLogica = PilotoLogica.getInstance();
            if (e.CommandName == "EditarPropuesta") {
                PilotoEntidad oPiloto = oPilotoLogica.ObtenerPilotoPorCodigo(Convert.ToInt32(e.CommandArgument));
                Sesiones.PilotoSeleccionada = oPiloto;
                //if(oPiloto.codigo_Estado == Convert.ToInt32( Constantes.ESTADO_PROPUESTA.REGISTRADA))
                //    Response.Redirect(Paginas.TMD_MP_PilotoFormulario+"?Action="+Constantes.ACTION_UPDATE,true);
                //else
                //    Response.Redirect(Paginas.TMD_MP_PilotoFormulario + "?Action=" + Constantes.ACTION_VIEW, true);
            }else if(e.CommandName == "EliminarPropuesta"){
                PilotoEntidad oPiloto = oPilotoLogica.ObtenerPilotoPorCodigo(Convert.ToInt32(e.CommandArgument));
                String strMensaje = "";//oPilotoLogica.BorrarPiloto(oPiloto);
                if (strMensaje != null){
                    lblMensajeError.Text = strMensaje;
                }
                else {
                    CargarPilotoListado();                
                }                    
            }
        }

        protected void btnAgregarPiloto_Click(object sender, EventArgs e)
        {
            Sesiones.PilotoSeleccionadaRemover();
            Response.Redirect(Paginas.TMD_MP_PilotoFormulario + "?Action=" + Constantes.ACTION_INSERT, true);
        }

        //protected void ibtnSalir_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect(Paginas.TMD_MP_Inicio, true);
        //}
    }
}