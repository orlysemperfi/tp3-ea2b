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
    public partial class PilotoListado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String sucess = "false";
            if (!Page.IsPostBack) {
                sucess = Request.QueryString["sucess"];
                if (sucess == "true")
                    lblMensajeConfirmacion.Text = "Piloto Registrado";
                else
                    lblMensajeConfirmacion.Text = "";
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
            lblMensajeConfirmacion.Text = "";
            CargarPilotoListado();
        }

        protected void gvwPilotoListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            IPilotoLogica oPilotoLogica = PilotoLogica.getInstance();
            if (e.CommandName == "EditarPiloto")
            {
                PilotoEntidad oPiloto = oPilotoLogica.ObtenerPilotoPorCodigo(Convert.ToInt32(e.CommandArgument));
                Sesiones.PilotoSeleccionada = oPiloto;
                if (oPiloto.codigo_Estado == Convert.ToInt32(Constantes.ESTADO_PILOTO.GENERADO))
                    Response.Redirect(Paginas.TMD_MP_PilotoFormulario + "?Action=" + Constantes.ACTION_UPDATE, true);
                else
                    Response.Redirect(Paginas.TMD_MP_PilotoFormulario + "?Action=" + Constantes.ACTION_VIEW, true);
            }else if(e.CommandName == "EliminarPiloto"){
                PilotoEntidad oPiloto = oPilotoLogica.ObtenerPilotoPorCodigo(Convert.ToInt32(e.CommandArgument));
                try
                {
                    oPilotoLogica.BorrarPiloto(oPiloto);
                    CargarPilotoListado();
                }
                catch (BRuleException ex)
                {
                    lblMensajeError.Text = ex.Message;
                    lblMensajeError.DataBind();
                }
            }
        }

        protected void btnAgregarPiloto_Click(object sender, EventArgs e)
        {
            Sesiones.PilotoSeleccionadaRemover();
            Response.Redirect(Paginas.TMD_MP_PilotoFormulario + "?Action=" + Constantes.ACTION_INSERT, true);
        }

        protected void gvwPilotoListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwPilotoListado.PageIndex = e.NewPageIndex;
            gvwPilotoListado.DataBind();
        }
    }
}