﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using TMD.CF.Site.Util;
using TMD.Entidades;

namespace TMD.CF.Site.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            e.Authenticated = FormsAuthentication.Authenticate(LoginUser.UserName, LoginUser.Password);
            SesionFachada.Usuario = new Usuario { Id = 1, Nombre = LoginUser.UserName };
        }
    }
}
