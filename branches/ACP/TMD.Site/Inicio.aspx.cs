using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TMD.CF.Site.Util;
using TMD.Entidades;


namespace ServiceDesk
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                OnInitPage();
            }
            
            
        }

        private void OnInitPage()
        {
            SesionFachada.Usuario = new Usuario { Id = 1, Nombre = "Jaime Suarez", Alias = "jsuarez"  };

        }
    }
}