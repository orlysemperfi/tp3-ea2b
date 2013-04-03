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

namespace TMD.ACP.Site
{
    public partial class ActListaVerificacion : BasePage 
    {

        private int idAuditoria = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            idAuditoria = Convert.ToInt32(Request.QueryString[0]);
            __IdAuditoria.Value = idAuditoria.ToString();

            if (IsCallback | Page.IsPostBack)
            {
                return;
            }

            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                Auditoria eAuditoria = new Auditoria();
                eAuditoria = TMD.Site.Controladora.ACP.AuditoriaControladora.ObtenerPlanAuditoriaPorID(idAuditoria);
                if (eAuditoria.IdAuditoria > 0)
                {
                    lblAuditoria.Text = Convert.ToString(idAuditoria);
                    lblDescrip.Text = eAuditoria.ObjEntidadAuditada.NombreEntidadAuditada;
                    lblArea.Text = eAuditoria.ObjEntidadAuditada.ObjArea.descripcion;
                    lblResponsable.Text = eAuditoria.ObjEntidadAuditada.Responsable;

                    List<PreguntaVerificacion> lstPreguntaVerificacion  = TMD.Site.Controladora.ACP.PreguntaVerificacionControladora.ObtenerListaPreguntaVerificacionPorAuditoria(idAuditoria);

                    if(lstPreguntaVerificacion.Count > 0){
                        __IsView.Value = "1";                   
                    }
                    
                    List<DetallePreguntaBase> lstDetallePreguntaBase = TMD.Site.Controladora.ACP.PreguntaVerificacionControladora.ListarDetallePreguntasBase();
                    rptPreguntas.DataSource = lstDetallePreguntaBase;
                    rptPreguntas.DataBind();                    

                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void GrabarListaVerificacion()
        {
            int idAuditoria = Convert.ToInt32(Request["ctl00$MainContent$__IdAuditoria"]);
            List<DetallePreguntaBase> lstDetallePreguntaBase = TMD.Site.Controladora.ACP.PreguntaVerificacionControladora.ListarDetallePreguntasBase();
            TMD.Site.Controladora.ACP.PreguntaVerificacionControladora.GrabarPreguntaVerificacion(idAuditoria, lstDetallePreguntaBase);
            AddCallbackValue("1");            
        }

    }
}