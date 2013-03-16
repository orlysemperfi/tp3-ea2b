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

namespace TMD.ACP.Site
{
    public partial class ListaSeguimientoHallazgo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsCallback | Page.IsPostBack)
            {
                return;
            }

            ListarAuditorias();
            ListarHallazgos("0","");
            litPeriodo.Text = Convert.ToString(DateTime.Today.Year);
        }

        public void ListarAuditorias()
        {
            try
            {
             
                List<Auditoria> lstAuditorias = TMD.Site.Controladora.ACP.HallazgoControladora.ObtenerAuditoriasSeguimiento(DateTime.Today.Year);

                rptAuditorias.DataSource = lstAuditorias;
                rptAuditorias.DataBind();

                AddCallbackValue("1");
                AddCallbackControl(rptAuditorias);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void ListarHallazgos(string idAuditoria,string estado)
        {
            try
            {

                List<Hallazgo> lstHallazgos = TMD.Site.Controladora.ACP.HallazgoControladora.ObtenerHallazgosSeguimiento(Convert.ToInt32(idAuditoria),0,estado);

                rptHallazgos.DataSource = lstHallazgos;
                rptHallazgos.DataBind();
                
                AddCallbackValue("1");
                AddCallbackControl(rptHallazgos);
                AddCallbackValue(Helper.Right("00000" + idAuditoria, 5).ToString());
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void QuitarAsignacion(string auditoriaid, string hallazgoid)
        {
            int idAuditoria = Convert.ToInt32(auditoriaid);
            int idHallazgo = Convert.ToInt32(hallazgoid);
            Hallazgo hallazgo = new Hallazgo();
            hallazgo.IdHallazgo = idHallazgo;
            hallazgo.FechaSeguimiento = null;
            hallazgo.IdAuditorSeguimiento = null;
            hallazgo.Estado = EstadoHallazgo.Planificado;
            TMD.Site.Controladora.ACP.HallazgoControladora.GrabarHallazgoSeguimiento(hallazgo);

            List<Hallazgo> lstHallazgos = TMD.Site.Controladora.ACP.HallazgoControladora.ObtenerHallazgosSeguimiento(Convert.ToInt32(idAuditoria), 0, "");

            rptHallazgos.DataSource = lstHallazgos;
            rptHallazgos.DataBind();

            AddCallbackValue("1");
            AddCallbackControl(rptHallazgos);
        }
        

        protected void rptAuditorias_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.Item)
            {
                Auditoria eAuditoria = (Auditoria)e.Item.DataItem;

                Literal litIdAuditoria = (Literal)e.Item.FindControl("litIdAuditoria");
                Literal litDesAuditorias = (Literal)e.Item.FindControl("litDesAuditorias");
                Literal litArea = (Literal)e.Item.FindControl("litArea");
                Literal litFechaInicio = (Literal)e.Item.FindControl("litFechaInicio");
                Literal litFechaFin = (Literal)e.Item.FindControl("litFechaFin");

                litIdAuditoria.Text = Helper.Right("00000" + Convert.ToString(eAuditoria.IdAuditoria), 5);
                litDesAuditorias.Text = eAuditoria.ObjEntidadAuditada.NombreEntidadAuditada;
                litArea.Text = eAuditoria.ObjEntidadAuditada.ObjArea.descripcion;
                litFechaInicio.Text = eAuditoria.FechaInicio.ToShortDateString();
                litFechaFin.Text = eAuditoria.FechaFin.ToShortDateString();
              
            }
        }

        protected void rptHallazgos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.Item)
            {
                Hallazgo eHallazgo = (Hallazgo)e.Item.DataItem;

                Literal litIdHallazgo = (Literal)e.Item.FindControl("litIdHallazgo");
                Literal litDescripcion = (Literal)e.Item.FindControl("litDescripcion");
                Literal litTipoHallazgo = (Literal)e.Item.FindControl("litTipoHallazgo");
                Literal litFechaCompromiso = (Literal)e.Item.FindControl("litFechaCompromiso");
                Literal litResponsable = (Literal)e.Item.FindControl("litResponsable");
                Literal litFechaSeguimiento = (Literal)e.Item.FindControl("litFechaSeguimiento");
                Literal litEstado = (Literal)e.Item.FindControl("litEstado");

                litIdHallazgo.Text = Convert.ToString(eHallazgo.IdHallazgo);
                litDescripcion.Text = eHallazgo.Descripcion;
                if (eHallazgo.TipoHallazgo == "NOCONFORMIDAD")
                    litTipoHallazgo.Text = "NO CONFORMIDAD";
                else
                    litTipoHallazgo.Text = eHallazgo.TipoHallazgo;
                if (eHallazgo.FechaCompromiso.HasValue)
                    litFechaCompromiso.Text = eHallazgo.FechaCompromiso.Value.ToShortDateString();                

                if (eHallazgo.Estado.Equals(EstadoHallazgo.Asignado)){
                    if (eHallazgo.FechaSeguimiento.HasValue)
                        litFechaSeguimiento.Text = eHallazgo.FechaSeguimiento.Value.ToShortDateString();
                }
                litResponsable.Text = eHallazgo.ResponsableSeguimiento;                
                litEstado.Text = eHallazgo.Estado;
            }
        }

    }
}