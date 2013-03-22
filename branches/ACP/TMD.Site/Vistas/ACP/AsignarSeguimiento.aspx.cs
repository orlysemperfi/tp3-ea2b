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
    public partial class AsignarSeguimiento :BasePage 
    {
        int idAuditoria = 0;
        int idHallazgo = 0;
        static DateTime dFecCompromiso;
        protected void Page_Load(object sender, EventArgs e)
        {

            idAuditoria = Convert.ToInt32(Request.QueryString[0]);
            __IdAuditoria.Value = idAuditoria.ToString();
            idHallazgo = Convert.ToInt32(Request.QueryString[1]);
            __IdHallazgo.Value = idHallazgo.ToString();

            if (IsCallback | Page.IsPostBack)
            {
                return;
            }
            CargarControles();
            CargarDatos();
        }

        private void CargarControles()
        {
            ddlResponsable.DataSource = TMD.Site.Controladora.ACP.HallazgoControladora.ListarEmpleadosAuditores(); ;
            ddlResponsable.DataValueField = "codigo";
            ddlResponsable.DataTextField = "nombre";         
            ddlResponsable.DataBind();
        }

        private void CargarDatos()
        {
            try
            {
                List<Hallazgo> lstHallazgos = TMD.Site.Controladora.ACP.HallazgoControladora.ObtenerHallazgosSeguimiento(idAuditoria, idHallazgo, "");

                if (lstHallazgos.Count >= 1)
                {
                    litDescripcionHallazgo.Text = lstHallazgos[0].Descripcion;                                       
                    if (lstHallazgos[0].TipoHallazgo == "NOCONFORMIDAD")                        
                        litTipo.Text = "NO CONFORMIDAD";
                    else
                        litTipo.Text = lstHallazgos[0].TipoHallazgo;
                    if (lstHallazgos[0].FechaCompromiso.HasValue)
                    litFechaCompromiso.Text = lstHallazgos[0].FechaCompromiso.Value.ToShortDateString();
                    if (lstHallazgos[0].FechaSeguimiento.HasValue)
                        txtFechaSeguimiento.Text = lstHallazgos[0].FechaSeguimiento.Value.ToShortDateString();
                    if (lstHallazgos[0].IdAuditorSeguimiento.HasValue)
                        ddlResponsable.SelectedValue = lstHallazgos[0].IdAuditorSeguimiento.Value.ToString();

                    dFecCompromiso = Convert.ToDateTime(litFechaCompromiso.Text);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void GrabarHallazgo(){

            string strMensaje = "";
            int idHallazgo = Convert.ToInt32(Request["__IdHallazgo"]);
            Hallazgo hallazgo = new Hallazgo();
            hallazgo.IdHallazgo = Convert.ToInt32(Request["__IdHallazgo"]);
            hallazgo.FechaSeguimiento = Convert.ToDateTime(Request["txtFechaSeguimiento"]);
            hallazgo.IdAuditorSeguimiento = Convert.ToInt32(Request["ddlResponsable"]);
            hallazgo.Estado = EstadoHallazgo.Asignado;

            if (GetMonthSpan(hallazgo.FechaSeguimiento.Value, dFecCompromiso) > 3)
            {
                strMensaje = "La fecha de compromiso no puede ser mayor de 3 meses pasada la auditoria.";
            }
            else
            {
                TMD.Site.Controladora.ACP.HallazgoControladora.GrabarHallazgoSeguimiento(hallazgo);
            }
            AddCallbackValue("1");
            AddCallbackValue(strMensaje);
       }

        public int GetMonthSpan(DateTime newdt, DateTime olddt)
        {
            Int32 anios;
            Int32 meses;
            Int32 dias;

            anios = (newdt.Year - olddt.Year);
            meses = (newdt.Month - olddt.Month);
            dias = (newdt.Day - olddt.Day);

            if (meses < 0)
            {
                anios -= 1;
                meses += 12;
            }

            return meses;
        }
    }
}