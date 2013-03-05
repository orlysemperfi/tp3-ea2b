using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.CF.Site.Util;
using System.Web.Security;

namespace TMD.CF.Site
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void HeadLoginView_LoggedOut(Object sender, System.EventArgs e)
        {
            SesionFachada.Usuario = null;
            FormsAuthentication.SignOut();
        }
    }
}
