using System;
using TMD.CF.Site.FachadaNegocio.CF;
using TMD.Core.Extension;
using TMD.Entidades;
using TMD.Core;
using System.Web;
using Microsoft.Practices.Unity;

namespace TMD.CF.Site.Controles
{
    public partial class AprobarInformeCambio : System.Web.UI.UserControl
    {

        public delegate void AproboInformeHandler();
        public event AproboInformeHandler EventoAproboInforme;

        public delegate void CancelarInformeHandler();
        public event CancelarInformeHandler EventoCanceloInforme;

        protected virtual void OnEventoGraboInforme()
        {
            AproboInformeHandler handler = EventoAproboInforme;
            if (handler != null) handler();
        }

        protected virtual void OnEventoCanceloInforme()
        {
            CancelarInformeHandler handler = EventoCanceloInforme;
            if (handler != null) handler();
        }

        public bool ApruebaInforme
        {
            set
            {
                lblTitulo.Text = value ? "Aprobar Informe" : "Rechazar Informe";
                hidIdEstado.Value = value ? Constantes.EstadoAprobado.ToString() : Constantes.EstadoDesaprobado.ToString();
            }
        }

        public int IdInformeCambio
        {
            get { return hidIdInforme.Value.ToInt(); }
            set { hidIdInforme.Value = value.ToString(); }
        }

        public int IdEstado
        {
            get { return hidIdEstado.Value.ToInt(); }
        }


        protected InformeCambioFachada informeFachada;

        protected void Page_Load(object sender, EventArgs e)
        {

            var accessor = HttpContext.Current.ApplicationInstance as IContainerAccessor;
            var container = accessor.Container;
            informeFachada = container.Resolve<InformeCambioFachada>();
        }

        public void Limpiar()
        {
            hidIdEstado.Value = "";
            hidIdInforme.Value = "";
            txtMotivo.Text = "";
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            informeFachada.Aprobar(IdInformeCambio, IdEstado, txtMotivo.Text);

            OnEventoGraboInforme();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            OnEventoCanceloInforme();
        }

    }
}