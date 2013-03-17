using System;
using TMD.Entidades;
using TMD.Core.Extension;
using TMD.CF.Site.Util;
using TMD.CF.Site.FachadaNegocio.CF;
using TMD.Core;

namespace TMD.CF.Site.Controles.CF.ControlCambio
{
    public partial class RegistroOrdenCambio : System.Web.UI.UserControl
    {
        public delegate void GraboOrdenHandler();
        public event GraboOrdenHandler EventoGraboOrden;

        public delegate void CancelarOrdenHandler();
        public event CancelarOrdenHandler EventoCanceloOrden;

        protected virtual void OnEventoGraboOrden()
        {
            GraboOrdenHandler handler = EventoGraboOrden;
            if (handler != null) handler();
        }
        
        protected virtual void OnEventoCanceloOrden()
        {
            CancelarOrdenHandler handler = EventoCanceloOrden;
            if (handler != null) handler();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarordenNueva();
            }
        }

        public void CargarOrdenExistente(int idSolicitudCambio)
        {
        }

        public void Limpiar()
        {
            txtNombre.Text = "";
            ddlProyecto.Items.Clear();
            ddlLineaBase.Items.Clear();
            ddlInforme.Items.Clear();
            ddlUsuario.Items.Clear();
            ddlPrioridad.Items.Clear();
        }
        
        public void CargarordenNueva()
        {
            ddlProyecto.EnlazarDatos(new LineaBaseFachada().ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id");
            ddlLineaBase.EnlazarValorDefecto();
            ddlInforme.EnlazarValorDefecto();
            ddlPrioridad.EnlazarDatos(new SolicitudCambioControladora().ListarPrioridad(), "Nombre", "Id");
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLineaBase.EnlazarDatos(new LineaBaseFachada().LineaBaseListarPorProyectoCombo(ddlProyecto.SelectedValue.ToInt()), "Nombre", "Id");
        }

        protected void ddlLineaBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlInforme.EnlazarDatos(new InformeCambioFachada().ListarPorProyectoLineaBase(ddlProyecto.SelectedValue.ToInt(), ddlLineaBase.SelectedValue.ToInt(),1), "Nombre", "Id");
        }

        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            OrdenCambio ordenCambio = CrearOrden();

            new OrdenCambioControladora().Agregar(ordenCambio);

            OnEventoGraboOrden();

            pnlOrdenCambio.Enabled = false;
        }

        private OrdenCambio CrearOrden()
        {
            return new OrdenCambio
                {
                    Nombre = txtNombre.Text,
                    InformeCambio = new InformeCambio { Id = ddlInforme.SelectedValue.ToInt() },
                    UsuarioReg = SesionFachada.Usuario,
                    UsuarioAsignado = new Usuario{ Id = ddlUsuario.SelectedValue.ToInt()},
                    Prioridad = ddlPrioridad.SelectedValue.ToInt()
                };
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            OnEventoCanceloOrden();
        }
    }
}