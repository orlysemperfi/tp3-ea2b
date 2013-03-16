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
        public delegate void GraboInformeHandler();
        public event GraboInformeHandler EventoGraboInforme;

        public delegate void CancelarInformeHandler();
        public event CancelarInformeHandler EventoCanceloInforme;

        protected virtual void OnEventoGraboInforme()
        {
            GraboInformeHandler handler = EventoGraboInforme;
            if (handler != null) handler();
        }

        protected virtual void OnEventoCanceloInforme()
        {
            CancelarInformeHandler handler = EventoCanceloInforme;
            if (handler != null) handler();
        }        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarsolicitudNueva();
            }
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
            InformeCambio informeCambio = CrearSolicitud();

            new InformeCambioFachada().Agregar(informeCambio);

            OnEventoGraboInforme();

            pnlInformeCambio.Enabled = false;
        }

        public void Limpiar()
        {
            lblCodigo.Text = "";
            txtNombre.Text = "";
            ddlProyecto.Items.Clear();
            ddlLineaBase.Items.Clear();
            ddlSolicitud.Items.Clear();
            TxtCosto.Text = "";
            TxtRecurso.Text = "";
            TxtEsfuerzo.Text = "";
        }

        private InformeCambio CrearSolicitud()
        {
            return new InformeCambio
            {
                Nombre = txtNombre.Text,
                Solicitud = new SolicitudCambio { Id = ddlSolicitud.SelectedValue.ToInt() },
                Usuario = SesionFachada.Usuario,
                EstimacionCosto = TxtCosto.Text,
                EstimacionEsfuerzo = TxtEsfuerzo.Text,
                Recursos = TxtEsfuerzo.Text
            };
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