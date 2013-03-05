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

using Ediable_Repeater;
using System.Web.Services;

namespace TMD.ACP.Site
{
    //public partial class PlanAuditoria : System.Web.UI.Page
    public partial class PlanAuditoria : BasePage 

    {
        private IAuditoriaLogica _auditoriaLogica;
        private IEmpleadoLogica _empleadoLogica;
        private IAuditorLogica _auditorLogica;
        private IActividadLogica _actividadLogica;
        private int idAuditoria;

        protected void Page_Load(object sender, EventArgs e)
        {
                       
            _auditoriaLogica = new AuditoriaLogica();
            _empleadoLogica = new EmpleadoLogica();
            _auditorLogica = new AuditorLogica();
            _actividadLogica = new ActividadLogica();
            idAuditoria = Convert.ToInt32(Request.QueryString[0]);
            __IdAuditoria.Value = idAuditoria.ToString();
            if (IsCallback | Page.IsPostBack) {		        
		        return;
            }

            Data = new Data();
            HttpContext.Current.Session["actividades"] = null;
            CargarDatos();
            CargarActividades();
        }
       
        private void CargarDatos()
        {
            Auditoria eAuditoria = new Auditoria();
            eAuditoria = _auditoriaLogica.ObtenerPlanAuditoriaPorID(idAuditoria);
            string idAuditores = "";
            if (eAuditoria.IdAuditoria > 0){                
                lblAuditoria.Text = Helper.Right("00000" + Convert.ToString(idAuditoria), 5);
                lblDescrip.Text = eAuditoria.ObjEntidadAuditada.NombreEntidadAuditada;
                //lblArea.Text = eAuditoria.ObjEntidadAuditada.ObjArea.NombreArea;
                lblArea.Text = eAuditoria.ObjEntidadAuditada.ObjArea.descripcion;
                lblResponsable.Text = eAuditoria.ObjEntidadAuditada.Responsable;
                txtAlcance.Text = eAuditoria.Alcance;
                txtObjetivo.Text = eAuditoria.Objetivo;

                List<Auditor> lstAuditores =  _auditorLogica.ListarAuditoresPorAuditoria(idAuditoria);
                foreach (Auditor eActividad in lstAuditores)
                {
                    idAuditores += (idAuditores.Length == 0) ? eActividad.IdAuditor.ToString() : "," + eActividad.IdAuditor.ToString();
                }                
                __IsView.Value = (idAuditores.Length == 0) ? "0" : "1";
                __ListAuditoresIDs.Value = idAuditores;
                ListarAuditores(idAuditores);

                List<Actividad> lstActividades = _actividadLogica.ListarActividadesPorAuditoria(idAuditoria);
                foreach (Actividad eActividad in lstActividades)
                {
                    Data.Actividades.Add(eActividad);
                }
                CargarActividades();
            }
            
        }

        public void ListarAuditores(string ids)
        {            
            List<EmpleadoEntidad> lstAuditores = new List<EmpleadoEntidad>();
            try
            {
                foreach (string id in ids.Split(','))
                {
                    int idEmpleado = Convert.ToInt32(id);

                    EmpleadoEntidad e = _empleadoLogica.ObtenerEmpleado(idEmpleado);                    
                    lstAuditores.Add(e);
                }
                rptEmpleados.DataSource = lstAuditores;
                rptEmpleados.DataBind();

                AddCallbackValue("1");
                AddCallbackControl(rptEmpleados);  

            }
            catch (Exception)
            {
                return;
            }
        }
        
        protected void rptEmpleados_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.Item)
            {
                EmpleadoEntidad eEmpleado = (EmpleadoEntidad)e.Item.DataItem;

                Label lblNombres = (Label)e.Item.FindControl("lblNombres");              
                Label lblArea = (Label)e.Item.FindControl("lblArea");

                //lblNombres.Text = eEmpleado.nombres + " " + eEmpleado.apepat + " " + eEmpleado.apemat;
                //lblArea.Text = eEmpleado.ObjArea.NombreArea;

                lblNombres.Text = eEmpleado.nombre + " " + eEmpleado.apellidopaterno + " " + eEmpleado.apellidomaterno;
                lblArea.Text = "AREA";

            }
        }

        public void ListarComboAuditores(string ids)
        {           
            string option = "";
            
            List<EmpleadoEntidad> lstAuditores = new List<EmpleadoEntidad>();
            try
            {
                foreach (string id in ids.Split(','))
                {
                    int idEmpleado = Convert.ToInt32(id);
                    EmpleadoEntidad e = _empleadoLogica.ObtenerEmpleado(idEmpleado);                    
                    lstAuditores.Add(e);
                    //option += string.Format("<OPTION VALUE='{0}'>{1}</OPTION>", e.IdEmpleado, e.nombres + ' ' + e.apepat);
                    option += string.Format("<OPTION VALUE='{0}'>{1}</OPTION>", e.codigo, e.nombre + ' ' + e.apellidopaterno);
                }
                string comboHtml = string.Format("<select id='newResponsable' name='newResponsable' style='width:120px;'>{0}</select>", option);                
                AddCallbackValue("1");
                AddCallbackValue(comboHtml);  
            }
            catch (Exception)
            {
                return;
            }
        }

        public void CargarActividades()
        {
            rptActividades.DataSource = Data.Actividades;
            rptActividades.DataBind();
        }

        public void AddActividad()
        {
            int id = Data.NextIdActividad;   
            int idActividad =  id;
            int idAuditor = Convert.ToInt32(Request["__TmpResponsable"]);
            string descripcionActividad = Convert.ToString(Request["__TmpDescripcionActividad"]);
            string lugar = Convert.ToString(Request["__TmpLugar"]);            
            DateTime fechaInicio = Convert.ToDateTime(Request["__TmpFechaInicio"]);
            DateTime fechaFin = Convert.ToDateTime(Request["__TmpFechaFin"]);

            Data.Actividades.Add(new Actividad() { IdActividad = idActividad, IdAuditor = idAuditor, DescripcionActividad = descripcionActividad, Lugar = lugar, FechaInicio = fechaInicio, FechaFin = fechaFin });

            AddCallbackValue("1");
            AddCallbackValue(id.ToString());
            AddCallbackValue((id + 1).ToString());
            AddCallbackValue(Data.Actividades.Count.ToString());
        }
        
        public void UpdateActividad()
        {          
            int idActividad = Convert.ToInt32(Request["__TmpIdActividad"]);
            int idAuditor = Convert.ToInt32(Request["__TmpResponsable"]);
            string descripcionActividad = Convert.ToString(Request["__TmpDescripcionActividad"]);
            string lugar = Convert.ToString(Request["__TmpLugar"]);
            DateTime fechaInicio = Convert.ToDateTime(Request["__TmpFechaInicio"]);
            DateTime fechaFin = Convert.ToDateTime(Request["__TmpFechaFin"]);

            Actividad actividad = Data.Actividades.Single(e => e.IdActividad == idActividad);
            actividad.IdAuditor = idAuditor;
            actividad.DescripcionActividad = descripcionActividad;
            actividad.Lugar = lugar;
            actividad.FechaInicio = fechaInicio;
            actividad.FechaFin = fechaFin;

            AddCallbackValue("1");
            AddCallbackValue(idActividad.ToString());
            AddCallbackValue(Data.Actividades.Count.ToString());
        }
                
        public void DeleteActividad()
        {
            int idActividad = Convert.ToInt32(Request["__TmpIdActividad"]);
            Actividad actividad = Data.Actividades.Single(e => e.IdActividad == idActividad);
            Data.Actividades.Remove(actividad);
            AddCallbackValue("1");
            AddCallbackValue(idActividad.ToString());
            AddCallbackValue(Data.Actividades.Count.ToString());
        }

        public void ActualizarPlanAuditoria()
        {
            int idAuditoria = Convert.ToInt32(Request["__IdAuditoria"]);
            string documento = Convert.ToString(Request["txtDocumento"]);
            string idAuditores = Convert.ToString(Request["__ListAuditoresIDs"]);

            //HttpPostedFile file = Request.Files["myFile"]; 
            //FileUpload fUpload = (FileUpload)this.FindControl(Request["fUpload"].ToString());            
            
            /*if (fUpload.HasFile)
            {
                string contentType = fUpload.PostedFile.ContentType;
                string fileName = fUpload.PostedFile.FileName;
                byte[] byteArray = fUpload.FileBytes;
                var wrapper = new ArchivoLogica();
                wrapper.InsertarArchivo(idAuditoria,'P', byteArray, fileName, contentType);
            }*/
            Auditoria eAuditoria = new Auditoria();
            eAuditoria.IdAuditoria = Convert.ToInt32(idAuditoria);          
            _auditoriaLogica.GrabarPlanAuditoria(eAuditoria);
            _auditorLogica.EliminarAuditoresPorAuditoria(idAuditoria);
            foreach (string id in idAuditores.Split(','))
            {
                int idAuditor = Convert.ToInt32(id);
                Auditor auditor = new Auditor(){ IdAuditoria = idAuditoria, IdAuditor = idAuditor };
                _auditorLogica.GrabarAuditor(auditor);
            }

            _actividadLogica.EliminarActividadesPorAuditoria(idAuditoria);
            foreach (Actividad eActividad in Data.Actividades)
            {
                eActividad.ObjAuditoria.IdAuditoria = idAuditoria;
                _actividadLogica.GrabarActividad(eActividad);
            }

            AddCallbackValue("1");            
        }

        public string ObtenerEmpleado(string id){
            EmpleadoEntidad eEmpleado = _empleadoLogica.ObtenerEmpleado(Convert.ToInt32(id));
            //return eEmpleado.nombres + ' ' + eEmpleado.apepat;
            return eEmpleado.nombre + ' ' + eEmpleado.apellidopaterno;
        }

        public static Data Data { get; set; }

    }
}