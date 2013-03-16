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
    public partial class ListaActSeguimientoHallazgo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsCallback | Page.IsPostBack)
            {
                return;
            }
            ListarHallazgos();
            litPeriodo.Text = Convert.ToString(DateTime.Today.Year);
        }

        public void ListarHallazgos()
        {
            try
            {

                List<Hallazgo> lstHallazgos = TMD.Site.Controladora.ACP.HallazgoControladora.ObtenerHallazgosSeguimientoAsignadoPorPeriodo(DateTime.Today.Year, 0);

                rptHallazgos.DataSource = lstHallazgos;
                rptHallazgos.DataBind();               
            }
            catch (Exception ex)
            {
                return;
            }
        }

        protected void rptHallazgos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.Item)
            {
                Hallazgo eHallazgo = (Hallazgo)e.Item.DataItem;
                Literal litIdHallazgo = (Literal)e.Item.FindControl("litIdHallazgo");
                Literal litIdAuditoria = (Literal)e.Item.FindControl("litIdAuditoria");
                Literal litDescripcionPregunta = (Literal)e.Item.FindControl("litDescripcionPregunta");                
                Literal litDescripcion = (Literal)e.Item.FindControl("litDescripcion");
                Literal litTipoHallazgo = (Literal)e.Item.FindControl("litTipoHallazgo");             
                Literal litResponsable = (Literal)e.Item.FindControl("litResponsable");
                Literal litFechaSeguimiento = (Literal)e.Item.FindControl("litFechaSeguimiento");
                Literal litEstado = (Literal)e.Item.FindControl("litEstado");
                litIdHallazgo.Text = Convert.ToString(eHallazgo.IdHallazgo);
                litIdAuditoria.Text = Helper.Right("00000" + Convert.ToString(eHallazgo.IdAuditoria), 5);
                litDescripcionPregunta.Text = eHallazgo.DescripcionPregunta;
                litDescripcion.Text = eHallazgo.Descripcion;
                if (eHallazgo.TipoHallazgo == "NOCONFORMIDAD")
                    litTipoHallazgo.Text = "NO CONFORMIDAD";
                else
                    litTipoHallazgo.Text = eHallazgo.TipoHallazgo;
                if (eHallazgo.FechaSeguimiento.HasValue)
                    litFechaSeguimiento.Text = eHallazgo.FechaSeguimiento.Value.ToShortDateString();
                litResponsable.Text = eHallazgo.ResponsableSeguimiento;
                litEstado.Text = eHallazgo.Estado;
            }
        }


    }


}