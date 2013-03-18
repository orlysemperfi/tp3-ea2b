using System;
using TMD.Entidades;
using TMD.Core.Extension;
using TMD.CF.Site.Util;
using TMD.CF.Site.FachadaNegocio.CF;
using TMD.Core;
using System.Web;
using Microsoft.Practices.Unity;

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

        protected OrdenCambioFachada ordenFachada;

        protected void Page_Load(object sender, EventArgs e)
        {
            var accessor = HttpContext.Current.ApplicationInstance as IContainerAccessor;
            var container = accessor.Container;
            ordenFachada = container.Resolve<OrdenCambioFachada>();

            if (!Page.IsPostBack)
            {
                CargarordenNueva();
            }
        }

        public void CargarOrdenExistente(int idOrdenCambio)
        {
            OrdenCambio orden = ordenFachada.ObtenerPorId(idOrdenCambio);

            if (orden != null)
            {
                txtNombre.Text = orden.Nombre;

                int idProyecto = orden.ProyectoFase.Proyecto.Id;
                ddlProyecto.EnlazarDatos(ordenFachada.ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id", -1, idProyecto);
                int lineaBaseId = orden.LineaBase.Id;
                ddlLineaBase.EnlazarDatos(ordenFachada.LineaBaseListarPorProyectoCombo(idProyecto), "Nombre", "Id", -1, lineaBaseId);
                int idInforme = orden.InformeCambio.Id;
                ddlInforme.EnlazarDatos(ordenFachada.ListarInformePorProyectoLineaBase(idProyecto, lineaBaseId, 2), "Nombre", "Id", -1, idInforme);
                int idUsuario = orden.UsuarioAsignado.Id;
                ddlUsuario.EnlazarDatos(ordenFachada.ListaPorRol(""), "Nombre", "Id", -1, idUsuario);
                ddlPrioridad.EnlazarDatos(ordenFachada.ListarPrioridad(), "Nombre", "Id", -1, orden.Prioridad);
                pnlOrdenCambio.Enabled = false;
            }
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
            ddlProyecto.EnlazarDatos(ordenFachada.ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id");
            ddlLineaBase.EnlazarValorDefecto();
            ddlInforme.EnlazarValorDefecto();
            ddlPrioridad.EnlazarDatos(ordenFachada.ListarPrioridad(), "Nombre", "Id");
            ddlUsuario.EnlazarDatos(ordenFachada.ListaPorRol(""), "Nombre", "Id");
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLineaBase.EnlazarDatos(ordenFachada.LineaBaseListarPorProyectoCombo(ddlProyecto.SelectedValue.ToInt()), "Nombre", "Id");
        }

        protected void ddlLineaBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlInforme.EnlazarDatos(ordenFachada.ListarInformePorProyectoLineaBase(ddlProyecto.SelectedValue.ToInt(), ddlLineaBase.SelectedValue.ToInt(), 1), "Nombre", "Id");
        }
        
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
            if (validar())
            {
                OrdenCambio ordenCambio = CrearOrden();

                try 
                {
                    ordenFachada.Agregar(ordenCambio);
                    OnEventoGraboOrden();
                    pnlOrdenCambio.Enabled = false;
                }catch (Exception ex)
                {
                    lblErrorMessage.Text = ex.Message;
                }
            }
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

        private Boolean validar()
        {
            bool registro = true;
            if (txtNombre.Text == "" || ddlProyecto.SelectedIndex == 0 || ddlLineaBase.SelectedIndex == 0 ||
                ddlInforme.SelectedIndex == 0 || ddlUsuario.SelectedIndex == 0 || ddlPrioridad.SelectedIndex == 0)
            {
                registro = false;
            }
            return registro;
        }
    }
}