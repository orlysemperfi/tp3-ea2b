﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.MP.Comun;
using TMD.Entidades;
using TMD.MP.LogicaNegocios.Contrato;
using TMD.MP.LogicaNegocios.Implementacion;

namespace TMD.CF.Site.Vistas.MP
{
    public partial class IndicadorFormularioCuanti : System.Web.UI.Page
    {
        int action = Constantes.ACTION_INSERT; //0:Insertar 1:Actualizar
        



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarProceso();
                action = Convert.ToInt32(Request.QueryString["Action"]);
                CargarIndicador();
                /*if (action == Constantes.ACTION_INSERT)
                {
                    NuevoIndicador();
                }
                else if (action == Constantes.ACTION_UPDATE)
                {
                    CargarIndicador();
                }
                */

                List<EscalaCuantitativoEntidad> escalaCuantitativoListado = Sesiones.IndicadorSeleccionado.lstEscalaCuantitativo;
                gwEscalasCuanti.DataBind();
            }
        }

        protected void NuevoIndicador()
        {
            if (Sesiones.IndicadorSeleccionado == null)
            {
                Sesiones.IndicadorSeleccionado = new IndicadorEntidad();
            }
   
            gwEscalasCuanti.DataBind();
        }


        protected void CargarIndicador()
        {
            IndicadorEntidad indicador = Sesiones.IndicadorSeleccionado;
            ddlProceso.SelectedValue = indicador.codigo_Proceso.ToString();
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
            oNewIndicador.tipo = Constantes.TIPO_INDICADOR_CUANTITATIVO;
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


        protected void CargarListadoEscalas()
        {
            IIndicadorLogica oIndicadorLogica = IndicadorLogica.getInstance();
            String codigo_indicador = Sesiones.IndicadorSeleccionado.codigo.ToString();

            if (codigo_indicador != null)
            {
                List<EscalaCuantitativoEntidad> oEscalaCuantitativoColeccion = new List<EscalaCuantitativoEntidad>();
                if (Sesiones.IndicadorSeleccionado.lstEscalaCualitativo == null)
                {
                    Sesiones.IndicadorSeleccionado.lstEscalaCuantitativo = oIndicadorLogica.ObtenerListaEscalaCuantitativoPorIndicador(Convert.ToInt32(codigo_indicador));
                }
                gwEscalasCuanti.DataBind();
            }

        }

        protected List<EscalaCuantitativoEntidad> ObtenerEscalaCuantitativoListado()
        {

            List<EscalaCuantitativoEntidad> eCuantitativoListado = Sesiones.IndicadorSeleccionado.lstEscalaCuantitativo;

            if (eCuantitativoListado == null)
            {
                eCuantitativoListado = new List<EscalaCuantitativoEntidad>();
                return null;
            }
            else
            {
                if (eCuantitativoListado.Count == 0)
                {
                    return null;
                }
                else
                {
                    return eCuantitativoListado;
                }
            }
        }


        protected void lbtnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void lbtnAgregarICuanti_Click(object sender, EventArgs e)
        {
            Response.Redirect(Paginas.TMD_MP_EscalaCuantitativoFormulario + "?Action=" + Constantes.ACTION_INSERT, true);
        }

        protected void CargarEscalaCuantitativo()
        {
            IIndicadorLogica oIndicadorLogica = IndicadorLogica.getInstance();
            IndicadorEntidad oIndicadorFiltro = new IndicadorEntidad();
            if (Sesiones.IndicadorSeleccionado.codigo != null)
            {
                int codigoIndicador = Convert.ToInt32(Sesiones.IndicadorSeleccionado.codigo);
                Sesiones.IndicadorSeleccionado.lstEscalaCuantitativo = oIndicadorLogica.ObtenerListaEscalaCuantitativoPorIndicador(codigoIndicador);


            }
            gwEscalasCuanti.DataBind();

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
        protected void gwEscalasCuanti_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            IIndicadorLogica oIndicadorLogica = IndicadorLogica.getInstance();
            if (e.CommandName == "Eliminar")
            {

                RemoverEscalaCuantiSesion(Convert.ToInt32(e.CommandArgument));

            }
            if (e.CommandName == "Editar")
            {
                Response.Redirect(Paginas.TMD_MP_EscalaCuantitativoFormulario + "?Action=" + Constantes.ACTION_UPDATE + "&Codigo=" + Convert.ToInt32(e.CommandArgument), true);
            }
        }
        protected void RemoverEscalaCuantiSesion(int codigo)
        {
            EscalaCuantitativoEntidad oEscalaCuantitativo = null;
            foreach (EscalaCuantitativoEntidad obj in Sesiones.IndicadorSeleccionado.lstEscalaCuantitativo)
            {
                if (obj.codigo == codigo)
                {
                    oEscalaCuantitativo = obj;
                }
            }
            if (oEscalaCuantitativo != null)
                Sesiones.IndicadorSeleccionado.lstEscalaCuantitativo.Remove(oEscalaCuantitativo);
            else
                lblMensajeError.Text = "La escala cuantitativa no puede ser borrada.";
            CargarEscalaCuantitativo();
            
        }
    }
}