using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TMD.CF.Site
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ucRegistroSolicitudCambio.EventoGraboSolicitud += 
                new Controles.RegistroSolicitudCambio.GraboSolicitudHandler(ucRegistroSolicitudCambio_EventoGrabo);

            if (String.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                ucRegistroSolicitudCambio.CargarsolicitudNueva();
            }
            else
            {
                ucRegistroSolicitudCambio.CargarSolicitudExistente(Convert.ToInt32(Request.QueryString["ID"]));   
            }
        }

        void ucRegistroSolicitudCambio_EventoGrabo()
        {

        }
    }
}
