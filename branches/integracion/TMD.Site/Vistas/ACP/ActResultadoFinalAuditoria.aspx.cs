using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using TMD.Entidades;
using TMD.ACP.LogicaNegocios.Contrato;
using TMD.ACP.LogicaNegocios.Implementacion;
using TMD.Core;

namespace TMD.ACP.Site.Vistas.ACP
{
    public partial class ActResultadoFinalAuditoria : BasePage 
    {
        int idAuditoria = 0;

        protected void Page_Load(object sender, EventArgs e)
        {           
            this.
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
                Auditoria eAuditoria = TMD.Site.Controladora.ACP.AuditoriaControladora.ObtenerInformeFinalPorAuditoria(idAuditoria);

                if (eAuditoria != null)
                {                      
                    lblAuditoria.Text = Helper.Right("00000" + Convert.ToString(eAuditoria.IdAuditoria), 5);
                    lblDescrip.Text = eAuditoria.ObjEntidadAuditada.NombreEntidadAuditada;                
                    lblArea.Text = eAuditoria.ObjEntidadAuditada.ObjArea.descripcion;
                    lblResponsable.Text = eAuditoria.ObjEntidadAuditada.Responsable;
                    txtRecomendaciones.Text = eAuditoria.recomendacion;
                    txtResultados.Text = eAuditoria.resultado;
                    txtConclusiones.Text = eAuditoria.conclusion;
                    if (eAuditoria.Estado.Equals(EstadoAuditoria.Realizado)){
                        __IsView.Value = "1";
                        txtDuracion.Enabled = false;
                        txtRecomendaciones.Enabled = false;
                        txtResultados.Enabled = false;
                        txtConclusiones.Enabled = false;
                    }                     
                }                  
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void GrabarInformeFinal()
        {
            int idAuditoria = Convert.ToInt32(Request["ctl00$MainContent$__IdAuditoria"]); 
            int duracion = 0; 
            string resultado = Convert.ToString(Request["ctl00$MainContent$txtResultados"]); 
            string conclusion = Convert.ToString(Request["ctl00$MainContent$txtConclusiones"]); 
            string recomendacion = Convert.ToString(Request["ctl00$MainContent$txtRecomendaciones"]);

            Auditoria eAuditoria = new Auditoria();
            eAuditoria.IdAuditoria = idAuditoria;
            eAuditoria.duracion = duracion;
            eAuditoria.resultado = resultado;
            eAuditoria.conclusion = conclusion;
            eAuditoria.recomendacion = recomendacion;

            string msjError = TMD.Site.Controladora.ACP.AuditoriaControladora.GrabarInformeFinalAuditoria(eAuditoria);

            if (msjError.Equals(""))
                AddCallbackValue("1");
            else
                AddCallbackValue("-1");
            AddCallbackValue(msjError);
        }
    }
}