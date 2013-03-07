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
    public partial class SolucionMejoraLista : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                CargarPropuesta();
                CargarSolucionMejoraListado();
            }
        }

        protected void CargarPropuesta() {
            
        }

        protected void CargarSolucionMejoraListado() {
            SolucionMejoraEntidad oSolucionMejoraFiltro = new SolucionMejoraEntidad();

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
               
            }else if(e.CommandName == "EliminarPropuesta"){
               
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
    }
}