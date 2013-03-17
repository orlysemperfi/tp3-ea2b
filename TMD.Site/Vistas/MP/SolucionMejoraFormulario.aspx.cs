
using System.Web.Script.Services;
using AjaxControlToolkit;
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
    public partial class SolucionMejoraFormulario : System.Web.UI.Page
    {
        int action = Constantes.ACTION_INSERT; //0:Insertar 1:Actualizar

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                action = Convert.ToInt32(Request.QueryString["Action"]);
                
                if (action == Constantes.ACTION_INSERT)
                {
                    NuevaSolucionMejora();
                }
                else if (action==Constantes.ACTION_UPDATE || action==Constantes.ACTION_VIEW) {
                    CargarSolucionMejora();
                }
                
            }
            
        }

        protected void NuevaSolucionMejora()
        {
            if (Sesiones.SolucionMejoraSeleccionada == null)
            {
                Sesiones.SolucionMejoraSeleccionada = new SolucionMejoraEntidad();
            }
        }

        protected void CargarSolucionMejora()
        {
            SolucionMejoraEntidad SolucionMejora = Sesiones.SolucionMejoraSeleccionada;
            tbxCodigo.Text = String.Format("{0:000}", SolucionMejora.codigo_Solucion);
            tbxPropuesta.Text = SolucionMejora.propuesta;

            if (action == Constantes.ACTION_VIEW)
                CargarModoView();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Validate(btnGuardar.ValidationGroup);

            if(IsValid == true){

                SolucionMejoraEntidad oSolucionMejora = Sesiones.SolucionMejoraSeleccionada; //new SolucionMejoraEntidad();
                ISolucionMejoraLogica oSolucionMejoraLogica = SolucionMejoraLogica.getInstance();

                oSolucionMejora.propuesta = tbxPropuesta.Text;
                

                if (oSolucionMejora.codigo_Solucion != null)
                    oSolucionMejoraLogica.ActualizarSolucionMejora(oSolucionMejora);
                else
                {
                    oSolucionMejora.codigo_Estado = Convert.ToInt32(Constantes.ESTADO_SOLUCION.GENERADA);
                    oSolucionMejoraLogica.InsertarSolucionMejora(oSolucionMejora);
                }

                string currentURL = Request.Url.ToString();
                string newURL = currentURL.Substring(0, currentURL.LastIndexOf("/"));

                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                "alert('Solucion Registrada'); window.location='" +
                newURL + "/SolucionMejoraListado.aspx';", true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Paginas.TMD_MP_SolucionMejoraListado, true);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
           
        }

        protected void CargarModoView() {
            tbxPropuesta.Enabled = false;
            btnGuardar.Visible = false;
            btnCancelar.Text = "Salir";
        }
    }
}