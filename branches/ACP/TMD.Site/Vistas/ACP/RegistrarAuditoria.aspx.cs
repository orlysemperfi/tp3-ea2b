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


namespace TMD.ACP.Site
{
    public partial class RegistrarAuditoria : BasePage 
    {
        private static List<Auditoria> lstAuditoria = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsCallback | Page.IsPostBack)
            {
                return;
            }

            //Obtener las auditorias que se muestran en el grid
            lstAuditoria = (List<Auditoria>)HttpContext.Current.Session[string.Format("PROGRAMAANUAL-AUDITORIA-{0}", 0)];

            //Obtener empleados
            CargarEmpleados(-1);
        }

        private void CargarEmpleados(int intArea)
        {           
            try
            {
                List<EmpleadoEntidad> lstEmpleados = TMD.Site.Controladora.ACP.AuditoriaControladora.ListarEmpleadosPorArea(intArea);
                ddlResponsable.DataSource = lstEmpleados;
                ddlResponsable.DataValueField = "codigo";
                ddlResponsable.DataTextField = "nombre";
                ddlResponsable.DataBind();
            }
            catch (Exception ex)
            {
                AddCallbackValue("0");
                AddCallbackValue(ex.Message);
            }
        }

        public void RefrescarDatosEntidadAuditada(string id)
        {
            try
            {
                EntidadAuditada eEntidadAuditada = TMD.Site.Controladora.ACP.AuditoriaControladora.ObtenerEntidadAuditada(Convert.ToInt32(id));
                CargarEmpleados(Convert.ToInt32(eEntidadAuditada.ObjArea.codigo));
                AddCallbackValue("1");
                AddCallbackValue(Convert.ToString(eEntidadAuditada.IdEntidadAuditada));
                AddCallbackValue(Convert.ToString(eEntidadAuditada.ObjArea.codigo));
                AddCallbackValue(eEntidadAuditada.NombreEntidadAuditada);
                AddCallbackValue(eEntidadAuditada.ObjArea.descripcion);
                AddCallbackControl(ddlResponsable);
            }
            catch (Exception ex)
            {
                AddCallbackValue("0");
                AddCallbackValue(ex.Message);
            }
        }

        /// <summary>
        /// Validar auditorias
        /// </summary>
        public void ValidarAuditoria()
        {
            try
            {
                string strMensaje = "";

                if (Convert.ToDateTime(Request["txtFechaInicio"]) < DateTime.Today)
                {
                    strMensaje = "La fecha de inicio ingresada debe ser mayor a la fecha actual";
                }
                else if (Convert.ToDateTime(Request["txtFechaFin"]) < DateTime.Today)
                {
                    strMensaje = "La fecha de fin ingresada debe ser mayor a la fecha actual";
                }
                else if (!TMD.Site.Controladora.ACP.AuditoriaControladora.ValidarAuditoria(Convert.ToInt32(Request["__tempIdEntidadAuditada"])))
                {
                    strMensaje = "El proceso/proyecto ya se audito el año pasado, debe seleccionar otra auditoria";
                }
                else
                {
                    if (lstAuditoria != null)
                    {
                        foreach (Auditoria eAuditoria in lstAuditoria)
                        {
                            if (eAuditoria.IdAuditoria != Convert.ToInt32(Request["txtAuditoria"]) &&
                                eAuditoria.ObjEntidadAuditada.IdEntidadAuditada == Convert.ToInt32(Request["__tempIdEntidadAuditada"]))
                            {
                                strMensaje = strMensaje + "El proceso/proyecto ya se encuentra en la lista";
                                break;
                            }
                            if (eAuditoria.IdAuditoria != Convert.ToInt32(Request["txtAuditoria"]) &&
                                Convert.ToDateTime(Request["txtFechaInicio"]) < eAuditoria.FechaFin)
                            {
                                strMensaje = strMensaje + "Ya existe una auditoria para el periodo de tiempo ingresado";
                                break;
                            }
                        }
                    }
                }

                AddCallbackValue("1");
                AddCallbackValue(strMensaje);
            }
            catch (Exception ex)
            {
                AddCallbackValue("0");
                AddCallbackValue(ex.Message);
            }
        }
    }
}