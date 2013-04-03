using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using TMD.CF.Site.Util;
using TMD.Entidades;
using TMD.CF.Site.FachadaNegocio.CF;
using Microsoft.Practices.Unity;

namespace TMD.CF.Site.Account
{
    public partial class Login : System.Web.UI.Page
    {

        protected SeguridadFachada seguridadFachada;

        protected void Page_Load(object sender, EventArgs e)
        {
            var accessor = HttpContext.Current.ApplicationInstance as IContainerAccessor;
            var container = accessor.Container;
            seguridadFachada = container.Resolve<SeguridadFachada>();
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            e.Authenticated = FormsAuthentication.Authenticate(LoginUser.UserName, LoginUser.Password);

            if (e.Authenticated)
            {
                Usuario usuario = seguridadFachada.ObtenerUsuario(LoginUser.UserName);
                if (usuario != null)
                {
                    SesionFachada.Usuario = usuario;
                }
                else
                {
                    e.Authenticated = false;
                }
            }
        }
    }
}
