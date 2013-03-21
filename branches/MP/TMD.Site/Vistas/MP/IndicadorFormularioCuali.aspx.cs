using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.MP.Comun;
using TMD.Entidades;
using TMD.MP.LogicaNegocios.Contrato;
using TMD.MP.LogicaNegocios.Implementacion;
using System.Data;

namespace TMD.MP.Site.Privado
{
    public partial class IndicadoresFormulario : System.Web.UI.Page
    {
        int action = Constantes.ACTION_INSERT; //0:Insertar 1:Actualizar
        int idIndicador = 0; //0:Insertar 1:Actualizar
        static int idCodEscala = 1000;
        
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarProceso();
                CargarEscalaCualitativo();
                action = Convert.ToInt32(Request.QueryString["Action"]);
                CargarPlazo();
                CargarFrecuencia();
                CargarIndicador();

            }
        }

        protected void CargarPlazo() 
        {
            ddlPlazo.Items.Add(new ListItem("[Seleccionar]","0"));
            ddlPlazo.Items.Add(new ListItem("3 meses", "3 meses"));
            ddlPlazo.Items.Add(new ListItem("6 meses", "6 meses"));
            ddlPlazo.Items.Add(new ListItem("1 año", "1 año"));
            ddlPlazo.Items.Add(new ListItem("2 años", "2 años"));
            ddlPlazo.Items.Add(new ListItem("3 años", "3 años"));
            ddlPlazo.DataBind();
        }

        protected void CargarFrecuencia()
        {
            ddlFrecuenciaMed.Items.Add(new ListItem("[Seleccionar]", "0"));
            ddlFrecuenciaMed.Items.Add(new ListItem("Diaria", "Diaria"));
            ddlFrecuenciaMed.Items.Add(new ListItem("Semanal", "Semanal"));
            ddlFrecuenciaMed.Items.Add(new ListItem("Mensual", "Mensual"));
            ddlFrecuenciaMed.Items.Add(new ListItem("Semestral", "Semestral"));
            ddlFrecuenciaMed.Items.Add(new ListItem("Anual", "Anual"));
            ddlFrecuenciaMed.DataBind();
        }

        protected void NuevoIndicador()

        {
            if (Sesiones.IndicadorSeleccionado == null)
            {
                Sesiones.IndicadorSeleccionado = new IndicadorEntidad();
            }
            gwEscalasCuali.DataBind();
            
        }

        protected void CargarIndicador()
        {
            IndicadorEntidad indicador = Sesiones.IndicadorSeleccionado;
            ddlProceso.SelectedValue = indicador.codigo_Proceso.ToString();
            tbxNombre.Text = indicador.nombre;
            ddlFrecuenciaMed.SelectedValue = indicador.frecuencia_Medicion;
            tbxFuenteMed.Text = indicador.fuente_Medicion;
            ddlPlazo.SelectedValue = indicador.plazo;
            CargarListadoEscalas();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Validate(btnGuardar.ValidationGroup);

            if (IsValid == true)
            {
                IIndicadorLogica oIndicadorLogica = IndicadorLogica.getInstance();
                IndicadorEntidad oNewIndicador = Sesiones.IndicadorSeleccionado;
                oNewIndicador.nombre = tbxNombre.Text;
                oNewIndicador.frecuencia_Medicion = ddlFrecuenciaMed.SelectedItem.ToString();
                oNewIndicador.fuente_Medicion = tbxFuenteMed.Text;
                oNewIndicador.plazo = ddlPlazo.SelectedItem.ToString();
                oNewIndicador.codigo_Proceso = Convert.ToInt32(ddlProceso.SelectedValue);
                oNewIndicador.tipo = Constantes.TIPO_INDICADOR_CUALITATIVO;
                oNewIndicador.estado = Convert.ToInt32(Constantes.ESTADO_INDICADOR.ACTIVO);
                try
                {
                    if (oNewIndicador.codigo != null)
                        oIndicadorLogica.ActualizarIndicador(oNewIndicador);
                    else
                        oIndicadorLogica.InsertarIndicador(oNewIndicador);

                    string currentURL = Request.Url.ToString();
                    string newURL = currentURL.Substring(0, currentURL.LastIndexOf("/"));

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                    "alert('Indicador Registrado'); window.location='" +
                    newURL + "/IndicadorListado.aspx';", true);
                }
                catch (BRuleException ex) 
                {
                    lblMensajeError.Text = ex.Message;
                    lblMensajeError.DataBind();                    
                }
               
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Paginas.TMD_MP_IndicadorListado, true);
        }

        protected void CargarListadoEscalas()
        {
            IIndicadorLogica oIndicadorLogica = IndicadorLogica.getInstance();
            String codigo_indicador = Sesiones.IndicadorSeleccionado.codigo.ToString();

            if (codigo_indicador != null) 
            {
                List<EscalaCualitativoEntidad> oEscalaCualitativoColeccion = new List<EscalaCualitativoEntidad>();
                if (Sesiones.IndicadorSeleccionado.lstEscalaCualitativo == null)
                {
                    Sesiones.IndicadorSeleccionado.lstEscalaCualitativo = oIndicadorLogica.ObtenerListaEscalaCualitativoPorIndicador(Convert.ToInt32(codigo_indicador));
                }
                gwEscalasCuali.DataBind();
            }



        }

        protected List<EscalaCualitativoEntidad> ObtenerEscalaCualitativoListado()
        {
            
            List<EscalaCualitativoEntidad> eCualitativoListado = Sesiones.IndicadorSeleccionado.lstEscalaCualitativo;

            if (eCualitativoListado == null)
            {
                eCualitativoListado = new List<EscalaCualitativoEntidad>();
                return null;
            }
            else
            {
                if (eCualitativoListado.Count == 0)
                {
                    return null;
                }
                else
                {
                    return eCualitativoListado;
                }
            }
        }
        protected List<EscalaCuantitativoEntidad> ObtenerEscalaCuantitativoListado()
        {

            List<EscalaCuantitativoEntidad> eCuantitativaListado = Sesiones.IndicadorSeleccionado.lstEscalaCuantitativo;
            if (eCuantitativaListado == null)
            {
                eCuantitativaListado = new List<EscalaCuantitativoEntidad>();
                return null;
            }
            else
            {
                if (eCuantitativaListado.Count == 0)
                {
                    return null;
                }
                else
                {
                    return eCuantitativaListado;
                }
            }
        }

        protected void CargarProceso()
        {
            IProcesoLogica oProcesoLogica = ProcesoLogica.getInstance();
            List<ProcesoEntidad> oProcesoColeccion = oProcesoLogica.ObtenerListaProcesoTodas();
            ddlProceso.DataSource = oProcesoColeccion;
            ddlProceso.DataTextField = "NOMBRE";
            ddlProceso.DataValueField = "CODIGO";
            ddlProceso.DataBind();
            ddlProceso.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }


        protected void CargarEscalaCualitativo()
        {
            IIndicadorLogica oIndicadorLogica = IndicadorLogica.getInstance();
            IndicadorEntidad oIndicadorFiltro = new IndicadorEntidad();
            if (Sesiones.IndicadorSeleccionado.codigo != null) {
                int codigoIndicador = Convert.ToInt32(Sesiones.IndicadorSeleccionado.codigo);
                Sesiones.IndicadorSeleccionado.lstEscalaCualitativo = oIndicadorLogica.ObtenerListaEscalaCualitativoPorIndicador(codigoIndicador);

                
            }
            gwEscalasCuali.DataBind();

        }

        protected List<EscalaCualitativoEntidad> ObtenerIndicadorListado()
        {
            List<EscalaCualitativoEntidad> escCualitativoListado = Sesiones.IndicadorSeleccionado.lstEscalaCualitativo;
            if (escCualitativoListado == null)
            {
                return null;
            }
            else
            {
                if (escCualitativoListado.Count == 0)
                {
                    return null;
                }
                else
                {
                    return escCualitativoListado;
                }
            }
        }


        protected void gwEscalasCuali_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gwEscalasCuali.EditIndex = e.NewEditIndex;
            gwEscalasCuali.DataBind();

        }

        protected void gwEscalasCuali_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)gwEscalasCuali.Rows[e.RowIndex];
            Label lblCodigo = (Label)row.FindControl("lblCodigo");
            TextBox tbxLimSuperior = (TextBox)row.FindControl("tbxLimSuperior");
            TextBox tbxLimInferior = (TextBox)row.FindControl("tbxLimInferior");
            TextBox tbxCalificacion = (TextBox)row.FindControl("tbxCalificacion");
            CheckBox chkPrincipal = (CheckBox)row.FindControl("chkPrincipal");

            gwEscalasCuali.EditIndex = -1;
            
            foreach (EscalaCualitativoEntidad obj in Sesiones.IndicadorSeleccionado.lstEscalaCualitativo)
            {
                if (obj.codigo == Convert.ToInt32(lblCodigo.Text))
                {
                    obj.limite_inferior = tbxLimInferior.Text;
                    obj.limite_superior = tbxLimSuperior.Text;
                    obj.calificacion = tbxCalificacion.Text;
                    obj.principal = (chkPrincipal.Checked) ? 1 : 0;
                }
            }
            
            gwEscalasCuali.DataBind();

        }

        protected void gwEscalasCuali_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gwEscalasCuali.EditIndex = -1;
            gwEscalasCuali.DataBind();
        }

        protected void gwEscalasCuali_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gwEscalasCuali.Rows[e.RowIndex];
            Label lblCodigo = (Label)row.FindControl("lblCodigo");
            EscalaCualitativoEntidad oEscalaCualitativo = null;
            foreach (EscalaCualitativoEntidad obj in Sesiones.IndicadorSeleccionado.lstEscalaCualitativo)
            {
                if (obj.codigo == Convert.ToInt32(lblCodigo.Text))
                {
                    oEscalaCualitativo = obj;
                    break;
                }
            }
            

            Sesiones.IndicadorSeleccionado.lstEscalaCualitativo.Remove(oEscalaCualitativo);

            gwEscalasCuali.DataBind();
        }

        private void AddNewRowToGrid()
        {
            EscalaCualitativoEntidad oEscalaCualitativo = new EscalaCualitativoEntidad();
            oEscalaCualitativo.codigo = idCodEscala++;
            
            Sesiones.IndicadorSeleccionado.lstEscalaCualitativo.Add(oEscalaCualitativo);
            gwEscalasCuali.EditIndex = Sesiones.IndicadorSeleccionado.lstEscalaCualitativo.Count - 1;
            gwEscalasCuali.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

    }
}