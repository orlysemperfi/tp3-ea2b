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
    public partial class ActualizarPlanAccion : BasePage 
    {
        int idHallazgo=0;

        protected void Page_Load(object sender, EventArgs e)
        {           
            this.
            idHallazgo = Convert.ToInt32(Request.QueryString[0]);
            __IdHallazgo.Value = idHallazgo.ToString();

            if (IsCallback | Page.IsPostBack)
            {
                return;
            }
            //CargarControles();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                List<Hallazgo> lstHallazgos = TMD.Site.Controladora.ACP.HallazgoControladora.ObtenerHallazgosSeguimientoAsignadoPorPeriodo(DateTime.Today.Year, idHallazgo);                
                if (lstHallazgos.Count >= 1)
                {                 
                    Auditoria eAuditoria = TMD.Site.Controladora.ACP.AuditoriaControladora.ObtenerPlanAuditoriaPorID(lstHallazgos[0].IdAuditoria.Value);

                    if (eAuditoria != null)
                    {                      
                        lblAuditoria.Text = Helper.Right("00000" + Convert.ToString(eAuditoria.IdAuditoria), 5);
                        lblDescrip.Text = eAuditoria.ObjEntidadAuditada.NombreEntidadAuditada;                
                        lblArea.Text = eAuditoria.ObjEntidadAuditada.ObjArea.descripcion;
                        lblResponsable.Text = eAuditoria.ObjEntidadAuditada.Responsable;
                    }

                    lblIdHallazgo.Text = Convert.ToString(lstHallazgos[0].IdHallazgo);
                    lblDescripcion.Text = lstHallazgos[0].Descripcion;                  
                    if(lstHallazgos[0].TipoHallazgo == "NOCONFORMIDAD")
                        lblTipo.Text = "NO CONFORMIDAD";
                    else
                        lblTipo.Text = lstHallazgos[0].TipoHallazgo;
                    lblEstado.Text = lstHallazgos[0].Estado;

                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void GrabarHallazgo()
        {
            int idHallazgo = Convert.ToInt32(Request["ctl00$MainContent$__IdHallazgo"]);
            List<Hallazgo> lstHallazgos = TMD.Site.Controladora.ACP.HallazgoControladora.ObtenerHallazgosSeguimiento_PlanAccion(idHallazgo);                
            if (lstHallazgos.Count >= 1)
            {
                Hallazgo hallazgo = lstHallazgos[0];
                hallazgo.AccionCorrectiva = Convert.ToString(Request["ctl00$MainContent$txtAccionCorrectiva"]);
                hallazgo.AccionPreventiva = Convert.ToString(Request["ctl00$MainContent$txttxtAccionPreventiva"]);
                hallazgo.FechaCompromiso = Convert.ToDateTime(Request["ctl00$MainContent$txtFechaCompromiso"]);
                
                TMD.Site.Controladora.ACP.HallazgoControladora.ModificarHallazgoSeguimiento(hallazgo);
                AddCallbackValue("1");
            }
            
            
        }
    }
}