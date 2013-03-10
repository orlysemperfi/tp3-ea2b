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

namespace TMD.MP.Site.Privado
{
    public partial class IndicadoresFormulario : System.Web.UI.Page
    {
        int action = Constantes.ACTION_INSERT; //0:Insertar 1:Actualizar
        int idIndicador = 0; //0:Insertar 1:Actualizar
        
        
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarProceso();
                action = Convert.ToInt32(Request.QueryString["Action"]);
                if (action == Constantes.ACTION_INSERT)
                {
                    NuevoIndicador();
                }
                else if (action == Constantes.ACTION_UPDATE)
                {
                    CargarIndicador();
                }
                List<EscalaCualitativoEntidad> escalaCualitativoListado = Sesiones.IndicadorSeleccionado.lstEscalaCualitativo;
                gwEscalasCuali.DataBind();

                List<EscalaCuantitativoEntidad> escalaCuantitativoListado = Sesiones.IndicadorSeleccionado.lstEscalaCuantitativo;
                gwEscalasCuali.DataBind();
            }
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
            tbxNombre.Text = indicador.nombre;
            tbxFrecuenciaMed.Text = indicador.frecuencia_Medicion;
            tbxFuenteMed.Text = indicador.fuente_Medicion;
            tbxExpresionMat.Text = indicador.expresion_Matematica;
            tbxPlaxo.Text = indicador.plazo;
            
            CargarListadoEscalas();
        }

        protected void lbtnGuardar_Click(object sender, EventArgs e)
        {
            IIndicadorLogica oIndicadorLogica = IndicadorLogica.getInstance();
            IndicadorEntidad oNewIndicador = Sesiones.IndicadorSeleccionado;
            oNewIndicador.nombre = tbxNombre.Text;
            oNewIndicador.frecuencia_Medicion = tbxFrecuenciaMed.Text;
            oNewIndicador.fuente_Medicion = tbxFuenteMed.Text;
            oNewIndicador.expresion_Matematica = tbxExpresionMat.Text;
            oNewIndicador.plazo = tbxPlaxo.Text;
            oNewIndicador.codigo_Proceso = Convert.ToInt32(ddlProceso.SelectedValue);
            oNewIndicador.tipo = Constantes.TIPO_INDICADOR_CUALITATIVO;
            oNewIndicador.estado = Convert.ToInt32(Constantes.ESTADO_INDICADOR.ACTIVO);
    
            if (oNewIndicador.codigo != null)
                oIndicadorLogica.ActualizarIndicador(oNewIndicador);
            else
                oIndicadorLogica.InsertarIndicador(oNewIndicador);

            Response.Redirect(Paginas.TMD_MP_IndicadorListado);
        }

        protected void lbtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Paginas.TMD_MP_IndicadorListado, true);
        }

        protected void CargarListadoEscalas(){
            IIndicadorLogica oIndicadorLogica = IndicadorLogica.getInstance();
            int codigo_indicador = Convert.ToInt32(Sesiones.IndicadorSeleccionado.codigo.ToString());

            List<EscalaCualitativoEntidad> oEscalaCualitativoColeccion = new List<EscalaCualitativoEntidad>();
            if (Sesiones.IndicadorSeleccionado.lstEscalaCualitativo == null)
            {
                Sesiones.IndicadorSeleccionado.lstEscalaCualitativo = oIndicadorLogica.ObtenerListaEscalaCualitativoPorIndicador(codigo_indicador);
            }
            gwEscalasCuali.DataBind();

            List<EscalaCuantitativoEntidad> oEscalaCuantitativoColeccion = new List<EscalaCuantitativoEntidad>();
            if (Sesiones.IndicadorSeleccionado.lstEscalaCuantitativo == null)
            {
                Sesiones.IndicadorSeleccionado.lstEscalaCuantitativo = oIndicadorLogica.ObtenerListaEscalaCuantitativoPorIndicador(codigo_indicador);
            }
            gwEscalasCuali.DataBind();
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

        protected void lbtnBuscar_Click(object sender, EventArgs e)
        { 
        
        }

        protected void lbtnAgregarICuanti_Click(object sender, EventArgs e)
        {

        }

        protected void lbtnAgregarICuali_Click(object sender, EventArgs e)
        {
            Response.Redirect(Paginas.TMD_MP_EscalaCualitativoFormulario + "?Action=" + Constantes.ACTION_INSERT, true);
        }

        protected void CargarProceso()
        {
            IProcesoLogica oProcesoLogica = ProcesoLogica.getInstance();
            List<ProcesoEntidad> oProcesoColeccion = oProcesoLogica.ObtenerListaProcesoTodas();
            ddlProceso.DataSource = oProcesoColeccion;
            ddlProceso.DataTextField = "NOMBRE";
            ddlProceso.DataValueField = "CODIGO";
            ddlProceso.DataBind();
            ddlProceso.Items.Insert(0, new ListItem("[Todos]", "0"));
        }


        protected void CargarEscalaCualitativo()
        {
            IIndicadorLogica oIndicadorLogica = IndicadorLogica.getInstance();
            IndicadorEntidad oIndicadorFiltro = new IndicadorEntidad();
            if (Sesiones.IndicadorSeleccionado != null) {
                int codigoIndicador = Convert.ToInt32(Sesiones.IndicadorSeleccionado.codigo);
                Sesiones.IndicadorSeleccionado.lstEscalaCualitativo = oIndicadorLogica.ObtenerListaEscalaCualitativoPorIndicador(codigoIndicador);

                
            }

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
    }
}