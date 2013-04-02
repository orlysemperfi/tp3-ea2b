using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TMD.CF.Site.Util;
using TMD.Entidades;
using System.Web.Security;


namespace ServiceDesk
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SesionFachada.Usuario == null)
            {
                FormsAuthentication.SignOut();
                Response.Redirect("~/Account/Login.aspx");
            }           
            
        }

        private void OnInitPage()
        {
        }
    }
}