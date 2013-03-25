using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using TMD.ACP.LogicaNegocios.Implementacion;

namespace TMD.ACP.Site.Reportes
{
    public partial class RptPlanAuditoriaView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strIdAuditoria = Request.QueryString["idAuditoria"];
            int nIdAuditoria = 0;

            int.TryParse(strIdAuditoria, out nIdAuditoria);

            if (nIdAuditoria > 0)
            {
                rptPlanAuditoria rptDoc = new rptPlanAuditoria();
                rptDoc.SetDataSource((new ReporteLogica()).ObtenerRepPlanAuditoria(nIdAuditoria));
                CrystalReportViewer1.HasToggleGroupTreeButton = false;
                CrystalReportViewer1.ReportSource = rptDoc;                      
            }
        }
    }
}