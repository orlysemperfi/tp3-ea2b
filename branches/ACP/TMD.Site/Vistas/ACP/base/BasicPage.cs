using System;
using System.Web;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace TMD.ACP.Site
{
    public class BasicPage : System.Web.UI.Page
    {
        protected override void OnLoad(System.EventArgs e)
        {
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = 0;
            Response.Cache.SetNoStore();
            Response.AppendHeader("Pragma", "no-cache");

            base.OnLoad(e);
        }

        private void Page_Unload(object sender, System.EventArgs e)
        {
            //BL.Utils.NHibernateHelper.CloseSession();
        }
        public BasicPage()
        {
            Unload += Page_Unload;
        }

    }
}