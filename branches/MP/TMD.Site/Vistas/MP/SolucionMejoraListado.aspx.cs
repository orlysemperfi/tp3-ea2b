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
            PageIndexChanging();
            lblMensajeError.Text = "";

        }

        protected List<SolucionMejoraEntidad> ObtenerSolucionMejoraListado()
        {
            
                return null;
        }

        protected void lbtnBuscar_Click(object sender, EventArgs e)
        {
            CargarSolucionMejoraListado();
        }

        protected void gvwSolucionMejoraListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarSolucion") {
               
            }else if(e.CommandName == "EliminarSolucion"){
               
            }
        }

        protected void BorrarSolucionMejora(SolucionMejoraEntidad oSolucionMejora)
        {
            
        }

        protected void ibtnAgregarSolucion_Click(object sender, EventArgs e)
        {
            
        }

        protected void ibtnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect(Paginas.TMD_MP_Inicio, true);
        }

        protected void PageIndexChanging()
        {
            
        }

    }
}