using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.Entidades;
using TMD.ACP.LogicaNegocios.Contrato;
using TMD.ACP.LogicaNegocios.Implementacion;
using TMD.Core;
using TMD.ACP.Site;
using Ediable_Repeater;
using System.Web.Services;
using TMD.CF.Site.Presentador.ACP;
using TMD.CF.Site.Vistas.ACP;
using TMD.CF.Site.Util;

namespace TMD.ACP.Site
{
    public partial class AprobarProgramaAuditoria : BasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && !IsCallback)
            {
                cargarProgramaAnual();
            }
        }

        private void cargarProgramaAnual()
        {
            ProgramaAnualAuditoria oProgramaAnual = TMD.Site.Controladora.ACP.AuditoriaControladora.ObtenerProgramaAnualDeAuditoria(0);
            if (oProgramaAnual !=null){
                lblIdPrograma.Text = oProgramaAnual.IdProgramaAnual.ToString();
                lblPeriodo.Text = oProgramaAnual.AnhoPrograma.ToString();
                lblElaboradoPor.Text = oProgramaAnual.UsuarioCreacion;                
                lblAprobadoPor.Text = oProgramaAnual.UsuarioAprobacion == null ? "" : oProgramaAnual.UsuarioAprobacion;
                lblEstado.Text = oProgramaAnual.Estado;
                __IsView.Value = oProgramaAnual.Estado == EstadoProgramaAnual.Creado ? "0" : "1";
                rptProgramaAnual.DataSource = oProgramaAnual.ObjAuditorias;
                rptProgramaAnual.DataBind();
            }else{
                __IsView.Value ="1";
            }
        }

        public void AprobarProgramaAnualAuditoria()
        {
            ProgramaAnualAuditoria oProgramaAnual = TMD.Site.Controladora.ACP.AuditoriaControladora.ObtenerProgramaAnualDeAuditoria(0);
            oProgramaAnual.IdUsuarioAprobacion = 0;
            TMD.Site.Controladora.ACP.AuditoriaControladora.AprobarProgramaAnual(oProgramaAnual);

            oProgramaAnual = TMD.Site.Controladora.ACP.AuditoriaControladora.ObtenerProgramaAnualDeAuditoria(0);

            rptProgramaAnual.DataSource = oProgramaAnual.ObjAuditorias;
            rptProgramaAnual.DataBind();

            AddCallbackValue("1");
            AddCallbackControl(rptProgramaAnual);
        }

        public void RechazarProgramaAnualAuditoria()
        {
            ProgramaAnualAuditoria oProgramaAnual = TMD.Site.Controladora.ACP.AuditoriaControladora.ObtenerProgramaAnualDeAuditoria(0);
            
            TMD.Site.Controladora.ACP.AuditoriaControladora.RechazarProgramaAnual(oProgramaAnual);
            
            oProgramaAnual = TMD.Site.Controladora.ACP.AuditoriaControladora.ObtenerProgramaAnualDeAuditoria(0);
            
            rptProgramaAnual.DataSource = oProgramaAnual.ObjAuditorias;
            rptProgramaAnual.DataBind();

            AddCallbackValue("1");
            AddCallbackControl(rptProgramaAnual);
        }

        protected void rptProgramaAnual_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.Item)
            {
                Auditoria eAuditoria = (Auditoria)e.Item.DataItem;

                Label lblNroAuditoria = (Label)e.Item.FindControl("lblNroAuditoria");
                Label lblEntAudi = (Label)e.Item.FindControl("lblEntAudi");
                Label lblArea = (Label)e.Item.FindControl("lblArea");
                Label lblResponsable = (Label)e.Item.FindControl("lblResponsable");
                Label lblAlcance = (Label)e.Item.FindControl("lblAlcance");
                Label lblObjetivo = (Label)e.Item.FindControl("lblObjetivo");
                Label lblFechaInicio = (Label)e.Item.FindControl("lblFechaInicio");
                Label lblFechaFin = (Label)e.Item.FindControl("lblFechaFin");
                Label lblEstado = (Label)e.Item.FindControl("lblEstado");

                lblNroAuditoria.Text = Convert.ToString(eAuditoria.IdAuditoria.Value);
                lblEntAudi.Text = eAuditoria.ObjEntidadAuditada.NombreEntidadAuditada;
                lblArea.Text = eAuditoria.ObjEntidadAuditada.ObjArea.descripcion;
                lblResponsable.Text = eAuditoria.ObjEntidadAuditada.Responsable;
                lblAlcance.Text = eAuditoria.Alcance;
                lblObjetivo.Text = eAuditoria.Objetivo;
                lblFechaInicio.Text = eAuditoria.FechaInicio.ToShortDateString();
                lblFechaFin.Text = eAuditoria.FechaFin.ToShortDateString();
                lblEstado.Text = eAuditoria.Estado;
            }
        }

    }
}