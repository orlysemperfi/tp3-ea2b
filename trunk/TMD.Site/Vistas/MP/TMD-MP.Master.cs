using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.MP.Comun;
using TMD.Entidades;

namespace TMD.MP.Site.Privado
{
    public partial class TMD_MP : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { 
                UsuarioEntidad oUsuario = Sesiones.UsuarioLogueado;
                if(oUsuario!=null)
                    lblUsuario.Text = "Bienvenido: " + oUsuario.codigo_Usuario;
                CargarMenu();
            }
        }

        protected void CargarMenu() {
            string currentURL = Request.Url.ToString();

            if (!(currentURL.Contains(Paginas.TMD_MP_PropuestaMejoraListado.Replace("~", "")) || currentURL.Contains(Paginas.TMD_MP_PropuestaMejoraFormulario.Replace("~", "")) || currentURL.Contains(Paginas.TMD_MP_PropuestaMejoraAprobar.Replace("~", ""))))
            {
                lnkPropuestas.Attributes.Remove("class");
            }
            else
            {
                lnkPropuestas.Attributes.Remove("class");
                lnkPropuestas.Attributes.Add("class", "current");
            }

            if (!(currentURL.Contains(Paginas.TMD_MP_IndicadorListado.Replace("~", "")) || currentURL.Contains(Paginas.TMD_MP_IndicadorFormularioCuali.Replace("~", "")) || currentURL.Contains(Paginas.TMD_MP_IndicadorFormularioCuanti.Replace("~", ""))))
            {
                lnkIndicadores.Attributes.Remove("class");
            }
            else
            {
                lnkIndicadores.Attributes.Remove("class");
                lnkIndicadores.Attributes.Add("class", "current");
            }
        }

        protected void lbtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect(Paginas.TMD_MP_Login, true);
        }
    }
}