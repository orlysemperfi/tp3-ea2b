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

namespace TMD.CF.Site.Vistas.ACP
{
    public partial class _ActualizarPlanAuditoria : BasePage 
    {

        private int idAuditoria;

        protected void Page_Load(object sender, EventArgs e)
        {
            idAuditoria = Convert.ToInt32(Request.QueryString[0]);
            __IdAuditoria.Value = idAuditoria.ToString();
           
            if (IsCallback | Page.IsPostBack)
            {
                return;
            }
                                              
            DataAuditores = new DataAuditores(idAuditoria);
            HttpContext.Current.Session[string.Format("PLANAUDITORIA-AUDITORES-{0}", idAuditoria)] = null;
            CargarAuditores();

            DataActividades = new DataActividades(idAuditoria);
            HttpContext.Current.Session[string.Format("PLANAUDITORIA-ACTIVIDADES-{0}", idAuditoria)] = null;
            CargarActividadesAuditoria();

            CargarDatos();
        }

        private void CargarDatos()
        {
            
            Auditoria eAuditoria = new Auditoria();
            eAuditoria = TMD.Site.Controladora.ACP.AuditoriaControladora.ObtenerPlanAuditoriaPorID(idAuditoria);
            
            if (eAuditoria.IdAuditoria > 0)
            {
                lblAuditoria.Text = Convert.ToString(idAuditoria);
                lblDescrip.Text = eAuditoria.ObjEntidadAuditada.NombreEntidadAuditada;                
                lblArea.Text = eAuditoria.ObjEntidadAuditada.ObjArea.descripcion;
                lblResponsable.Text = eAuditoria.ObjEntidadAuditada.Responsable;
                txtAlcance.Text = eAuditoria.Alcance;
                txtObjetivo.Text = eAuditoria.Objetivo;
                lblFile.Text = eAuditoria.nombreArchivoL;
                            
                List<Auditor> lstAuditores = TMD.Site.Controladora.ACP.AuditorControladora.ListarAuditoresPorAuditoria(idAuditoria);
                foreach (Auditor eAuditor in lstAuditores)
                {
                    EmpleadoEntidad eEmpleado = TMD.Site.Controladora.ACP.HallazgoControladora.ObtenerEmpleado(eAuditor.IdAuditor.Value);
                    DataAuditores.Auditores.Add(eEmpleado);
                }
                CargarAuditores();

                List<Actividad> lstActividades = TMD.Site.Controladora.ACP.AuditoriaControladora.ListarActividadesPorAuditoria(idAuditoria);
                foreach (Actividad eActividad in lstActividades)
                {
                    DataActividades.Actividades.Add(eActividad);
                }
                CargarActividadesAuditoria();

                __IsView.Value = (lstAuditores.Count == 0) ? "0" : "1";
            }
        }

        public static DataAuditores DataAuditores { get; set; }
        
        public void CargarAuditores()
        {
            rptEquipoAuditor.DataSource = DataAuditores.Auditores;
            rptEquipoAuditor.DataBind();
        }

        protected void rptEquipoAuditor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.Item)
            {
                EmpleadoEntidad eEmpleado = (EmpleadoEntidad)e.Item.DataItem;

                Label lblNombres = (Label)e.Item.FindControl("lblNombres");
                Label lblArea = (Label)e.Item.FindControl("lblArea");

                lblNombres.Text = eEmpleado.nombre + " " + eEmpleado.apellidopaterno;
                lblArea.Text = eEmpleado.ObjArea.descripcion;

            }
        }

        public void AgregarAuditores(string ids)
        {           

            List<EmpleadoEntidad> lstAuditores = new List<EmpleadoEntidad>();
            try
            {
                
                DataAuditores = new DataAuditores(idAuditoria);
                HttpContext.Current.Session[string.Format("PLANAUDITORIA-AUDITORES-{0}", idAuditoria)] = null;
                         
                foreach (string id in ids.Split(','))
                {
                    int idEmpleado = Convert.ToInt32(id);

                    EmpleadoEntidad e = TMD.Site.Controladora.ACP.HallazgoControladora.ObtenerEmpleado(idEmpleado);
                    lstAuditores.Add(e);
                    DataAuditores.Auditores.Add(e);
                }
                
                rptEquipoAuditor.DataSource = lstAuditores;
                rptEquipoAuditor.DataBind();
             
                AddCallbackValue("1");
                AddCallbackControl(rptEquipoAuditor);                
            }
            catch (Exception)
            {
                AddCallbackValue("-1");
                return;
            }

        }

        public void ObtenerAuditoresIds()
        {
            string strIds = "";
            foreach (EmpleadoEntidad eEmpleado in DataAuditores.Auditores)
            {
                strIds += eEmpleado.codigo + ",";
            }

            if (strIds.Length > 0) strIds = strIds.Substring(0, strIds.Length - 1);

            AddCallbackValue("1");
            AddCallbackValue(strIds);            
        }

        public void QuitarAuditor(string id)
        {
            int idCodigo = Convert.ToInt32(id);
            EmpleadoEntidad eEmpleado = DataAuditores.Auditores.Single(e => e.codigo == idCodigo);
            DataAuditores.Auditores.Remove(eEmpleado);

            rptEquipoAuditor.DataSource = DataAuditores.Auditores;
            rptEquipoAuditor.DataBind();

            AddCallbackValue("1");
            AddCallbackControl(rptEquipoAuditor);
            AddCallbackValue(DataAuditores.Auditores.Count.ToString());
        }

        public static DataActividades DataActividades { get; set; }

        public void CargarActividadesAuditoria()
        {
            rptActividadesAuditoria.DataSource = DataActividades.Actividades;
            rptActividadesAuditoria.DataBind();
            AddCallbackValue("1");
            AddCallbackControl(rptActividadesAuditoria);
        }
        
        protected void rptActividadesAuditoria_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {                     
            if (e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.Item)
            {
               Actividad eActividad = (Actividad)e.Item.DataItem;
               EmpleadoEntidad eEmpleado = TMD.Site.Controladora.ACP.HallazgoControladora.ObtenerEmpleado(eActividad.IdAuditor);
               
                //Modo Vista

               Literal litAuditor = (Literal)e.Item.FindControl("litAuditor");
                litAuditor.Text = eEmpleado.nombre + ' ' + eEmpleado.apellidopaterno;

               Literal litFechaInicio = (Literal)e.Item.FindControl("litFechaInicio");
               litFechaInicio.Text = eActividad.FechaInicio.ToShortDateString();

               Literal litFechaFin = (Literal)e.Item.FindControl("litFechaFin");
               litFechaFin.Text = eActividad.FechaFin.ToShortDateString();
                    
               //Modo Editable

               DropDownList ddlAuditor = (DropDownList)e.Item.FindControl("ddlAuditor");
               ddlAuditor.DataSource = DataAuditores.Auditores;
               ddlAuditor.DataValueField = "codigo";
               ddlAuditor.DataTextField = "nombre";
               ddlAuditor.SelectedValue = eActividad.IdAuditor.ToString();
               ddlAuditor.DataBind();

               TextBox txtNuevoFechaInicio = (TextBox)e.Item.FindControl("txtFechaInicio");
               txtNuevoFechaInicio.Text = eActividad.FechaInicio.ToShortDateString();

               TextBox txtNuevoFechaFin = (TextBox)e.Item.FindControl("txtFechaFin");
               txtNuevoFechaFin.Text = eActividad.FechaFin.ToShortDateString();

            }

            if (e.Item.ItemType == ListItemType.Footer)
            {
                TextBox txtNuevoActividad = (TextBox)e.Item.FindControl("txtNuevoActividad");   
                DropDownList ddlNuevoAuditor = (DropDownList)e.Item.FindControl("ddlNuevoAuditor");                
                TextBox txtNuevoFechaInicio = (TextBox)e.Item.FindControl("txtNuevoFechaInicio");
                TextBox txtNuevoFechaFin = (TextBox)e.Item.FindControl("txtNuevoFechaFin");           
                
                txtNuevoActividad.Text =  Convert.ToString(DataActividades.NextId);
                txtNuevoFechaInicio.Text = DateTime.Today.ToShortDateString();
                txtNuevoFechaFin.Text = DateTime.Today.ToShortDateString();
                
                ddlNuevoAuditor.DataSource = DataAuditores.Auditores;
                ddlNuevoAuditor.DataValueField = "codigo";
                ddlNuevoAuditor.DataTextField = "nombre"; 
                ddlNuevoAuditor.DataBind();
            }
        }

        public void AgregarActividadAuditoria()
        {            

            int idActividad = Convert.ToInt32(Request["ctl00$MainContent$__TmpIdActividad"]);
            int idAuditor = Convert.ToInt32(Request["ctl00$MainContent$__TmpResponsable"]);
            string descripcion = Convert.ToString(Request["ctl00$MainContent$__TmpDescripcionActividad"]);
            string lugar = Convert.ToString(Request["ctl00$MainContent$__TmpLugar"]);
            DateTime fechaInicio = Convert.ToDateTime(Request["ctl00$MainContent$__TmpFechaInicio"]);
            DateTime fechaFin = Convert.ToDateTime(Request["ctl00$MainContent$__TmpFechaFin"]);

            DataActividades.Actividades.Add(new Actividad() { IdActividad = idActividad, IdAuditor = idAuditor, DescripcionActividad = descripcion, Lugar = lugar, FechaInicio = fechaInicio, FechaFin = fechaFin });
            CargarActividadesAuditoria();           
        }

        public void GrabarActividadAuditoria()
        {            
            int idActividad = Convert.ToInt32(Request["ctl00$MainContent$__TmpIdActividad"]);
            int idAuditor = Convert.ToInt32(Request["ctl00$MainContent$__TmpResponsable"]);
            string descripcion = Convert.ToString(Request["ctl00$MainContent$__TmpDescripcionActividad"]);
            string lugar = Convert.ToString(Request["ctl00$MainContent$__TmpLugar"]);
            DateTime fechaInicio = Convert.ToDateTime(Request["ctl00$MainContent$__TmpFechaInicio"]);
            DateTime fechaFin = Convert.ToDateTime(Request["ctl00$MainContent$__TmpFechaFin"]);


            Actividad actividad = DataActividades.Actividades.Single(e => e.IdActividad == idActividad);
            actividad.IdAuditor = idAuditor;
            actividad.DescripcionActividad = descripcion;
            actividad.Lugar = lugar;
            actividad.FechaInicio = fechaInicio;
            actividad.FechaFin = fechaFin;
          
            CargarActividadesAuditoria();
        }

        public void QuitarActividadAuditoria(string id)
        {
            int idActividad = Convert.ToInt32(id);
            Actividad actividad = DataActividades.Actividades.Single(e => e.IdActividad == idActividad);
            DataActividades.Actividades.Remove(actividad);
            CargarActividadesAuditoria();
        }

        public void GrabarPlanAuditoria()
        {
            string fileName = Convert.ToString(Request["ctl00$MainContent$__FileName"]);
            string file = Convert.ToString(Request["ctl00$MainContent$__File"]);
            
            Auditoria eAuditoria = new Auditoria();
            eAuditoria.IdAuditoria = Convert.ToInt32(idAuditoria);
            eAuditoria.nombreArchivoF = fileName;
            eAuditoria.nombreArchivoL = file;

            TMD.Site.Controladora.ACP.AuditoriaControladora.GrabarPlanAuditoria(eAuditoria);
            
            TMD.Site.Controladora.ACP.AuditorControladora.EliminarAuditoresPorAuditoria(idAuditoria);
            foreach (EmpleadoEntidad eEmpleado in DataAuditores.Auditores)
            {
                Auditor auditor = new Auditor() { IdAuditoria = idAuditoria, IdAuditor = eEmpleado.codigo };                
                TMD.Site.Controladora.ACP.AuditorControladora.GrabarAuditor(auditor);
            }

            TMD.Site.Controladora.ACP.AuditoriaControladora.EliminarActividadesPorAuditoria(idAuditoria);
            foreach (Actividad eActividad in DataActividades.Actividades)
            {
                eActividad.ObjAuditoria.IdAuditoria = idAuditoria;
                TMD.Site.Controladora.ACP.AuditoriaControladora.GrabarActividad(eActividad);
            }
            AddCallbackValue("1");                           
        }

        public void ValidarPlanAuditoria()
        {            
            Auditoria eAuditoria = new Auditoria();
            eAuditoria.IdAuditoria = Convert.ToInt32(idAuditoria);

            if (DataAuditores.Auditores.Count == 0)
            {
                AddCallbackValue("2");
            }
            else if (DataActividades.Actividades.Count == 0)
            {
                AddCallbackValue("3");
            }
            else
            {
                AddCallbackValue("1");                
            }
        }

        public void RefreshFileUpload()
        {	        
	        bool mResultValue = true;
            if (!string.IsNullOrEmpty(Request["ctl00$MainContent$__Message"]))
            {		        
	        }

	        if (!mResultValue) {		      
		        AddCallbackValue("-1");		        
		        return;
	        }

            //if (!string.IsNullOrEmpty(__FileActual.Value))
            //    BL.Globals.RemoveFile(__FileActual.Value);
	        if (mResultValue) {
		        AddCallbackValue("1");
		        AddCallbackValue(__File.Text);
		        AddCallbackValue(__FileName.Text);
	        }

        }
    }
}