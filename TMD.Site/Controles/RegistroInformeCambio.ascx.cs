using System;
using TMD.Entidades;
using TMD.Core.Extension;
using TMD.CF.Site.Util;
using TMD.CF.Site.Controladora.CF;
using TMD.Core;

namespace TMD.CF.Site.Controles
{
    public partial class RegistroInformeCambio : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLineaBase.EnlazarDatos(new LineaBaseControladora().LineaBaseListarPorProyectoCombo(ddlProyecto.SelectedValue.ToInt()), "Nombre", "Id");
        }

        protected void ddlLineaBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSolicitud.EnlazarDatos(new InformeCambioFachada().ListarPorProyectoLineaBase(ddlProyecto.SelectedValue.ToInt(), ddlLineaBase.SelectedValue.ToInt(),1), "NombreSolicitud", "IdSolicitud");
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        public void CargarsolicitudNueva()
        {
            ddlProyecto.EnlazarDatos(new LineaBaseControladora().ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id");
            ddlLineaBase.EnlazarValorDefecto();
            ddlSolicitud.EnlazarValorDefecto();
        }
    }
}