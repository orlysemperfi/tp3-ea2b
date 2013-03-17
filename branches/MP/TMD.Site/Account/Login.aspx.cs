using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using TMD.Entidades;
using TMD.MP.Comun;
using TMD.MP.LogicaNegocios.Contrato;
using TMD.MP.LogicaNegocios.Implementacion;
using TMD.CF.Site.Util;

namespace TMD.MP.Site.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            //IUsuarioLogica oUsuarioLogica = UsuarioLogica.getInstance();
            //UsuarioEntidad oUsuario = oUsuarioLogica.ObtenerUsuario(LoginUser.UserName, LoginUser.Password);
            //Sesiones.UsuarioLogueadoRemover();
            //Sesiones.UsuarioLogueado = oUsuario;
            //Response.Redirect(Paginas.TMD_MP_PropuestaMejoraListado, true);
        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            e.Authenticated = FormsAuthentication.Authenticate(LoginUser.UserName, LoginUser.Password);
            SesionFachada.Usuario = new Usuario { Id = 1, Nombre = LoginUser.UserName };
        }
    }
}
