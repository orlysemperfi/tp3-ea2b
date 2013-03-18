using System;
using TMD.Entidades;
using TMD.Core.Extension;
using TMD.CF.Site.Util;
using TMD.CF.Site.FachadaNegocio.CF;
using TMD.Core;
using Microsoft.Practices.Unity;
using System.Web;
using System.Web.UI;

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

        protected InformeCambioFachada informeFachada;
        protected LineaBaseFachada lineaBaseFachada;

        protected void Page_Load(object sender, EventArgs e)
        {
            var accessor = HttpContext.Current.ApplicationInstance as IContainerAccessor;
            var container = accessor.Container;
            informeFachada = container.Resolve<InformeCambioFachada>();
            lineaBaseFachada = container.Resolve<LineaBaseFachada>();

            if (!Page.IsPostBack)
            {
                CargarInformeNuevo();                
            }
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLineaBase.EnlazarDatos(lineaBaseFachada.LineaBaseListarPorProyectoCombo(ddlProyecto.SelectedValue.ToInt()), "Nombre", "Id");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "_idBtnNuevo_", "mostrarDiv('divRegistroInforme');", true);
        }

        protected void ddlLineaBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSolicitud.EnlazarDatos(informeFachada.ListarPorProyectoLineaBase(ddlProyecto.SelectedValue.ToInt(), ddlLineaBase.SelectedValue.ToInt(),1,0), "NombreSolicitud", "IdSolicitud");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "_idBtnNuevo_", "mostrarDiv('divRegistroInforme');", true);
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            InformeCambio informeCambio = CrearInforme();

            informeFachada.Agregar(informeCambio);

            OnEventoGraboInforme();

            pnlInformeCambio.Enabled = false;
        }

        public void CargarInformeExistente(int idInformeCambio)
        {
            InformeCambio informe = new InformeCambioFachada().ObtenerPorId(idInformeCambio);

            if (informe != null)
            {
                txtNombre.Text = informe.Nombre;
                int idProyecto = informe.Solicitud.ProyectoFase.Proyecto.Id;
                ddlProyecto.EnlazarDatos(new LineaBaseFachada().ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id", -1, idProyecto);
                int lineaBaseId = informe.Solicitud.LineaBase.Id;
                ddlLineaBase.EnlazarDatos(new LineaBaseFachada().LineaBaseListarPorProyectoCombo(idProyecto), "Nombre", "Id", -1, lineaBaseId);
                ddlSolicitud.EnlazarDatos(informeFachada.ListarPorProyectoLineaBase(idProyecto, lineaBaseId, 1, 0), "NombreSolicitud", "IdSolicitud");
                TxtCosto.Text = informe.EstimacionCosto;
                TxtEsfuerzo.Text = informe.EstimacionEsfuerzo;
                TxtRecurso.Text = informe.Recursos;
                btnGrabar.Visible = false;
            }
        }

        public void Limpiar()
        {
            txtNombre.Text = "";
            ddlProyecto.Items.Clear();
            ddlLineaBase.Items.Clear();
            ddlSolicitud.Items.Clear();
            TxtCosto.Text = "";
            TxtRecurso.Text = "";
            TxtEsfuerzo.Text = "";
        }

        private InformeCambio CrearInforme()
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
            OnEventoCanceloInforme();
        }

        public void CargarInformeNuevo()
        {
            ddlProyecto.EnlazarDatos(lineaBaseFachada.ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id");
            ddlLineaBase.EnlazarValorDefecto();
            ddlSolicitud.EnlazarValorDefecto();
        }
    }
}