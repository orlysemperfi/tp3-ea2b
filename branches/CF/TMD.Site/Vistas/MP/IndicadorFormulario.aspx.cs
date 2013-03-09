﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.MP.Comun;
using TMD.Entidades;
using TMD.MP.Controlador;
namespace TMD.MP.Site.Privado
{
    public partial class IndicadoresFormulario : System.Web.UI.Page
    {
        int action = Constantes.ACTION_INSERT; //0:Insertar 1:Actualizar
        int idIndicador = 0; //0:Insertar 1:Actualizar
        
        public IndicadorControlador indicadorControlador = new IndicadorControlador();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
                gwEscalasCuanti.DataBind();
            }
        }

        protected void NuevoIndicador()

        {
            if (Sesiones.IndicadorSeleccionado == null)
            {
                Sesiones.IndicadorSeleccionado = new IndicadorEntidad();
            }
            gwEscalasCuali.DataBind();
            gwEscalasCuanti.DataBind();
        }


        protected void CargarIndicador()
        {
            IndicadorEntidad indicador = Sesiones.IndicadorSeleccionado;
            tbxNombre.Text = indicador.nombre;
            tbxFrecuenciaMed.Text = indicador.frecuencia_Medicion;
            tbxFuenteMed.Text = indicador.fuente_Medicion;
            tbxExpresionMat.Text = indicador.expresion_Matematica;
            tbxPlaxo.Text = indicador.plazo;
            ddlTipo.SelectedValue = indicador.tipo.ToString();

            CargarListadoEscalas();
        }

        protected void lbtnGuardar_Click(object sender, EventArgs e)
        {
            IndicadorEntidad oNewIndicador = Sesiones.IndicadorSeleccionado;
            oNewIndicador.nombre = tbxNombre.Text;
            oNewIndicador.frecuencia_Medicion = tbxFrecuenciaMed.Text;
            oNewIndicador.fuente_Medicion = tbxFuenteMed.Text;
            oNewIndicador.expresion_Matematica = tbxExpresionMat.Text;
            oNewIndicador.plazo = tbxPlaxo.Text;
            oNewIndicador.tipo = Convert.ToInt32(ddlTipo.SelectedItem.Value);

            if (oNewIndicador.codigo != null)
                indicadorControlador.ActualizarIndicador(oNewIndicador);
            else
                indicadorControlador.InsertarIndicador(oNewIndicador);

            Response.Redirect(Paginas.TMD_MP_IndicadorListado);
        }

        protected void lbtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Paginas.TMD_MP_IndicadorListado, true);
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipo.SelectedIndex == 0)
            {
                pnlIndicadorCualitativo.Visible = true;
                pnlIndicadorCuantitativo.Visible = false;
            }
            else {
                pnlIndicadorCualitativo.Visible = false;
                pnlIndicadorCuantitativo.Visible = true;
            }

        }

        protected void CargarListadoEscalas(){
            int codigo_indicador = Convert.ToInt32(Sesiones.IndicadorSeleccionado.codigo.ToString());

            List<EscalaCualitativoEntidad> oEscalaCualitativoColeccion = new List<EscalaCualitativoEntidad>();
            if (Sesiones.IndicadorSeleccionado.lstEscalaCualitativo == null)
            {
                Sesiones.IndicadorSeleccionado.lstEscalaCualitativo = indicadorControlador.ObtenerListaEscalaCualitativoPorIndicador(codigo_indicador);
            }
            gwEscalasCuali.DataBind();

            List<EscalaCuantitativoEntidad> oEscalaCuantitativoColeccion = new List<EscalaCuantitativoEntidad>();
            if (Sesiones.IndicadorSeleccionado.lstEscalaCuantitativo == null)
            {
                Sesiones.IndicadorSeleccionado.lstEscalaCuantitativo = indicadorControlador.ObtenerListaEscalaCuantitativoPorIndicador(codigo_indicador);
            }
            gwEscalasCuanti.DataBind();
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
    }
}