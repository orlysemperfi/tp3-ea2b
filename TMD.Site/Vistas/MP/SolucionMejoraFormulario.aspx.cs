
using System.Web.Script.Services;
using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.Entidades;
using TMD.MP.Comun;
using TMD.MP.LogicaNegocios.Contrato;
using TMD.MP.LogicaNegocios.Implementacion;

namespace TMD.MP.Site.Privado
{
    public partial class SolucionMejoraFormulario : System.Web.UI.Page
    {
        int action = Constantes.ACTION_INSERT; //0:Insertar 1:Actualizar

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                action = Convert.ToInt32(Request.QueryString["Action"]);

                CargarEmpleado();
                CargarPropuesta();

                if (action == Constantes.ACTION_INSERT)
                {
                    NuevaSolucionMejora();
                }
                else if (action==Constantes.ACTION_UPDATE || action==Constantes.ACTION_VIEW) {
                    CargarSolucionMejora();
                }
                
            }
            
        }

        protected void NuevaSolucionMejora()
        {
            if (Sesiones.SolucionMejoraSeleccionada == null)
            {
                Sesiones.SolucionMejoraSeleccionada = new SolucionMejoraEntidad();
            }
        }

        protected void CargarSolucionMejora()
        {
            SolucionMejoraEntidad SolucionMejora = Sesiones.SolucionMejoraSeleccionada;
            tbxCodigo.Text = String.Format("{0:000}", SolucionMejora.codigo_Solucion);
            ddlPropuesta.SelectedValue = SolucionMejora.propuesta;
            CargarListadoAcciones();

            if (action == Constantes.ACTION_VIEW)
                CargarModoView();
            else
                CargarModoEdit();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Validate(btnGuardar.ValidationGroup);

            if(IsValid == true){

                SolucionMejoraEntidad oSolucionMejora = Sesiones.SolucionMejoraSeleccionada;
                ISolucionMejoraLogica oSolucionMejoraLogica = SolucionMejoraLogica.getInstance();

                oSolucionMejora.codigo_Propuesta = Convert.ToInt32(ddlPropuesta.SelectedItem.Value);
                oSolucionMejora.codigo_Empleado = Convert.ToInt32(ddlEmpleado.SelectedItem.Value);
                oSolucionMejora.descripcion = tbxDescripcion.Text;

                if (oSolucionMejora.codigo_Solucion != null)
                    oSolucionMejoraLogica.ActualizarSolucionMejora(oSolucionMejora);
                else
                {
                    oSolucionMejora.codigo_Estado = Convert.ToInt32(Constantes.ESTADO_SOLUCION.GENERADA);
                    oSolucionMejoraLogica.InsertarSolucionMejora(oSolucionMejora);
                }

                string currentURL = Request.Url.ToString();
                string newURL = currentURL.Substring(0, currentURL.LastIndexOf("/"));

                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                "alert('Solucion Registrada'); window.location='" +
                newURL + "/SolucionMejoraListado.aspx';", true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Paginas.TMD_MP_SolucionMejoraListado, true);
        }

        protected void CargarListadoAcciones()
        {
            ISolucionMejoraLogica oSolucionMejoraLogica = SolucionMejoraLogica.getInstance();
            String codigo_solucion = Sesiones.SolucionMejoraSeleccionada.codigo_Solucion.ToString();

            if (codigo_solucion != null)
            {
                List<AccionesSolucionEntidad> oAccionesSolucionColeccion = new List<AccionesSolucionEntidad>();
                if (Sesiones.SolucionMejoraSeleccionada.lstAcciones == null)
                {
                    Sesiones.SolucionMejoraSeleccionada.lstAcciones = oSolucionMejoraLogica.ObtenerListaAccionesSolucionPorSolucion(Convert.ToInt32(codigo_solucion));
                }
                gwAcciones.DataBind();
            }



        }

        protected void CargarModoView() {
            ddlPropuesta.Enabled = false;
            ddlEmpleado.Enabled = false;
            btnGuardar.Visible = false;
            btnCancelar.Text = "Salir";
        }

        protected void CargarModoEdit()
        {
            ddlPropuesta.Enabled = false;
        }

        protected void CargarEmpleado()
        {
            IUsuarioLogica oAreaLogica = UsuarioLogica.getInstance();
            List<UsuarioEntidad> oUsuarioColeccion = oAreaLogica.ObtenerListaEmpleadosTodas();
            ddlEmpleado.DataSource = oUsuarioColeccion;
            ddlEmpleado.DataTextField = "NOMBRE_COMPLETO";
            ddlEmpleado.DataValueField = "CODIGO_PERSONA";
            ddlEmpleado.DataBind();
            ddlEmpleado.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }


        protected void CargarPropuesta()
        {
            IPropuestaMejoraLogica oPropuestaMejoraLogica = PropuestaMejoraLogica.getInstance();
            List<PropuestaMejoraEntidad> oPropuestaMejoraColeccion = oPropuestaMejoraLogica.ObtenerPropuestaMejoraListadoParaSolucion();
            ddlPropuesta.DataSource = oPropuestaMejoraColeccion;
            ddlPropuesta.DataTextField = "DESCRIPCION";
            ddlPropuesta.DataValueField = "CODIGO_PROPUESTA";
            ddlPropuesta.DataBind();
            ddlPropuesta.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        private void AddNewRowToGrid()
        {
            AccionesSolucionEntidad oAccion = new AccionesSolucionEntidad();

            Sesiones.SolucionMejoraSeleccionada.lstAcciones.Add(oAccion);
            gwAcciones.EditIndex = Sesiones.SolucionMejoraSeleccionada.lstAcciones.Count - 1;
            gwAcciones.DataBind();
        }


        protected void CargarAccionesSolucion()
        {
            ISolucionMejoraLogica oSolucionMejoraLogica = SolucionMejoraLogica.getInstance();
            SolucionMejoraEntidad oSolucionMejoraFiltro = new SolucionMejoraEntidad();
            if (Sesiones.SolucionMejoraSeleccionada.codigo_Solucion != null)
            {
                int codigoSolucion = Convert.ToInt32(Sesiones.SolucionMejoraSeleccionada.codigo_Solucion);
                Sesiones.SolucionMejoraSeleccionada.lstAcciones = oSolucionMejoraLogica.ObtenerListaAccionesSolucionPorSolucion(codigoSolucion);


            }
            gwAcciones.DataBind();

        }
        
        protected List<AccionesSolucionEntidad> ObtenerAccionesListado()
        {

            List<AccionesSolucionEntidad> eAccionesListado = Sesiones.SolucionMejoraSeleccionada.lstAcciones;

            if (eAccionesListado == null)
            {
                eAccionesListado = new List<AccionesSolucionEntidad>();
                return null;
            }
            else
            {
                if (eAccionesListado.Count == 0)
                {
                    return null;
                }
                else
                {
                    return eAccionesListado;
                }
            }
        }

        protected void gwAcciones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gwAcciones.EditIndex = e.NewEditIndex;
            gwAcciones.DataBind();

        }

        protected void gwAcciones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)gwAcciones.Rows[e.RowIndex];
            Label lblCodigo = (Label)row.FindControl("lblCodigo");
            TextBox tbxAccion = (TextBox)row.FindControl("tbxAccion");

            gwAcciones.EditIndex = -1;

            foreach (AccionesSolucionEntidad obj in Sesiones.SolucionMejoraSeleccionada.lstAcciones)
            {
                if (obj.codigo == Convert.ToInt32(lblCodigo.Text))
                {
                    obj.descripcion = tbxAccion.Text;
                }
            }

            gwAcciones.DataBind();

        }

        protected void gwAcciones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gwAcciones.EditIndex = -1;
            gwAcciones.DataBind();
        }

        protected void gwAcciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gwAcciones.Rows[e.RowIndex];
            Label lblCodigo = (Label)row.FindControl("lblCodigo");
            AccionesSolucionEntidad oAcciones = null;
            foreach (AccionesSolucionEntidad obj in Sesiones.SolucionMejoraSeleccionada.lstAcciones)
            {
                if (obj.codigo == Convert.ToInt32(lblCodigo.Text))
                {
                    oAcciones = obj;
                    break;
                }
            }


            Sesiones.SolucionMejoraSeleccionada.lstAcciones.Remove(oAcciones);

            gwAcciones.DataBind();
        }

    }
}