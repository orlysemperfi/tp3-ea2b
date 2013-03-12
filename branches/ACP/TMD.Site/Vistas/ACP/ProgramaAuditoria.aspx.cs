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
    public partial class ProgramaAuditoria : BasePage
    {
        /// <summary>
        /// Variable global de listado de auditorias en sesion
        /// </summary>
        public static DataAuditorias DataAuditorias { get; set; }

        /// <summary>
        /// Al cargar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsCallback | Page.IsPostBack)
            {
                return;
            }

            //Referenciar lista de auditorias en sesion
            DataAuditorias = new DataAuditorias(0);
            HttpContext.Current.Session[string.Format("PROGRAMAANUAL-AUDITORIA-{0}", 0)] = null;

            //Verificar si existe un programa anual de auditoria vigente
            ProgramaAnualAuditoria oProgramaAnual = TMD.Site.Controladora.ACP.AuditoriaControladora.ObtenerProgramaAnualAuditorias();
            
            //Si existe un programa anual obtengo datos y grid de auditorias en solo lectura, de lo contrario muestra informacion por defecto
            if (oProgramaAnual != null)
            {
                lblPeriodo.Text = oProgramaAnual.AnhoPrograma.ToString();
                lblElaboradoPor.Text = oProgramaAnual.UsuarioCreacion;
                lblAprobadoPor.Text = oProgramaAnual.UsuarioAprobacion;
                lblEstado.Text = oProgramaAnual.Estado;
                lblIdPrograma.Text = oProgramaAnual.IdProgramaAnual.ToString();

                List<Auditoria> lstAuditoriar = TMD.Site.Controladora.ACP.AuditoriaControladora.ListarAuditoriasPorAnio(oProgramaAnual.AnhoPrograma);
                foreach (Auditoria eAuditoria in lstAuditoriar)
                {
                    DataAuditorias.Auditoria.Add(eAuditoria);
                }
                
                __IsView.Value = "1";
            }
            else
            {
                __IsView.Value = "0";
                lblPeriodo.Text = DateTime.Today.Year.ToString();
                lblElaboradoPor.Text = "Carla Mier";
                lblAprobadoPor.Text = "";
                lblEstado.Text = EstadoProgramaAnual.Creado;
                lblIdPrograma.Text = "";
            }

            //Refrescar auditorias
            CargarAuditorias();            
        }

        /// <summary>
        /// Pintar grid con los datos de auditoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptProgramaAnual_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.Item)
            {
                Auditoria eAuditoria = (Auditoria)e.Item.DataItem;

                Label lblNroAuditoria = (Label)e.Item.FindControl("lblNroAuditoria");
                Label lblEntAudi = (Label)e.Item.FindControl("lblEntAudi");
                Label lblArea = (Label)e.Item.FindControl("lblArea");
                Label lblResponsable = (Label)e.Item.FindControl("lblResponsable");
                Label lblAlcance = (Label)e.Item.FindControl("lblAlcance");
                Label lblObjetivo = (Label)e.Item.FindControl("lblObjetivo");
                Label lblFechaInicio = (Label)e.Item.FindControl("lblFechaInicio");
                Label lblFechaFin = (Label)e.Item.FindControl("lblFechaFin");
                Label lblEstado = (Label)e.Item.FindControl("lblEstado");

                lblNroAuditoria.Text = Convert.ToString(eAuditoria.IdAuditoria.Value);
                lblEntAudi.Text = eAuditoria.ObjEntidadAuditada.NombreEntidadAuditada;
                lblArea.Text = eAuditoria.ObjEntidadAuditada.ObjArea.descripcion;
                lblResponsable.Text = eAuditoria.ObjEntidadAuditada.Responsable;
                lblAlcance.Text = eAuditoria.Alcance;
                lblObjetivo.Text = eAuditoria.Objetivo;
                lblFechaInicio.Text = eAuditoria.FechaInicio.ToShortDateString();
                lblFechaFin.Text = eAuditoria.FechaFin.ToShortDateString();
                lblEstado.Text = eAuditoria.Estado;
            }
        }

        /// <summary>
        /// Permite cargar las auditorias al grid
        /// </summary>
        public void CargarAuditorias()
        {
            try
            {
                __tempNroAuditoria.Value = Convert.ToString(DataAuditorias.NextId);
                rptProgramaAnual.DataSource = DataAuditorias.Auditoria;
                rptProgramaAnual.DataBind();
                AddCallbackValue("1");
                AddCallbackControl(rptProgramaAnual);
                AddCallbackValue(__tempNroAuditoria.Value);
            }
            catch (Exception ex)
            {
                AddCallbackValue("0");
                AddCallbackValue(ex.Message);
            }
        }

        /// <summary>
        /// Permite actualizar el grid de la auditoria ingresada o modificada
        /// </summary>
        public void GrabarAuditoria()
        {
            try
            {
                //Buscar por id la auditoria para saber si existe o no en el grid
                int idAuditoria = Convert.ToInt32(Request["ctl00$MainContent$__tempNroAuditoria"]);
                Auditoria auditoria = DataAuditorias.Auditoria.Find(e => e.IdAuditoria == idAuditoria);
                //Si no existe se agrega en el grid, de lo contrario, se actualiza
                if (auditoria == null)
                {
                    Auditoria eAuditoria = new Auditoria();
                    eAuditoria.IdAuditoria = Convert.ToInt32(Request["ctl00$MainContent$__tempNroAuditoria"]);
                    eAuditoria.ObjEntidadAuditada.IdEntidadAuditada = Convert.ToInt32(Request["ctl00$MainContent$__tempIdEntAudi"]);
                    eAuditoria.ObjEntidadAuditada.NombreEntidadAuditada = Convert.ToString(Request["ctl00$MainContent$__tempEntAudi"]);
                    eAuditoria.ObjEntidadAuditada.ObjArea.descripcion = Convert.ToString(Request["ctl00$MainContent$__tempArea"]);
                    eAuditoria.ObjEntidadAuditada.ObjArea.codigo = Convert.ToInt32(Request["ctl00$MainContent$__tempIdArea"]);
                    eAuditoria.ObjEntidadAuditada.IdResponsable = Convert.ToInt32(Request["ctl00$MainContent$__tempIdResponsable"]);
                    eAuditoria.ObjEntidadAuditada.Responsable = Convert.ToString(Request["ctl00$MainContent$__tempResponsable"]);
                    eAuditoria.Alcance = Convert.ToString(Request["ctl00$MainContent$__tempAlcance"]);
                    eAuditoria.Objetivo = Convert.ToString(Request["ctl00$MainContent$__tempObjetivo"]);
                    eAuditoria.FechaInicio = Convert.ToDateTime(Request["ctl00$MainContent$__tempFechaInicio"]);
                    eAuditoria.FechaFin = Convert.ToDateTime(Request["ctl00$MainContent$__tempFechaFin"]);
                    eAuditoria.Estado = EstadoAuditoria.Creado;
                    DataAuditorias.Auditoria.Add(eAuditoria);
                }
                else
                {
                    Auditoria eAuditoria = DataAuditorias.Auditoria.Single(e => e.IdAuditoria == idAuditoria);
                    eAuditoria.IdAuditoria = Convert.ToInt32(Request["ctl00$MainContent$__tempNroAuditoria"]);
                    eAuditoria.ObjEntidadAuditada.NombreEntidadAuditada = Convert.ToString(Request["ctl00$MainContent$__tempEntAudi"]);
                    eAuditoria.ObjEntidadAuditada.ObjArea.descripcion = Convert.ToString(Request["ctl00$MainContent$__tempArea"]);
                    eAuditoria.ObjEntidadAuditada.ObjArea.codigo = Convert.ToInt32(Request["ctl00$MainContent$__tempIdArea"]);
                    eAuditoria.ObjEntidadAuditada.Responsable = Convert.ToString(Request["ctl00$MainContent$__tempResponsable"]);
                    eAuditoria.ObjEntidadAuditada.IdResponsable = Convert.ToInt32(Request["ctl00$MainContent$__tempIdResponsable"]);
                    eAuditoria.Alcance = Convert.ToString(Request["ctl00$MainContent$__tempAlcance"]);
                    eAuditoria.Objetivo = Convert.ToString(Request["ctl00$MainContent$__tempObjetivo"]);
                    eAuditoria.FechaInicio = Convert.ToDateTime(Request["ctl00$MainContent$__tempFechaInicio"]);
                    eAuditoria.FechaFin = Convert.ToDateTime(Request["ctl00$MainContent$__tempFechaFin"]);
                    eAuditoria.Estado = EstadoAuditoria.Creado;
                }
                //Refrescar grid
                CargarAuditorias();
            }
            catch (Exception ex)
            {
                AddCallbackValue("0");
                AddCallbackValue(ex.Message);
            }
        }

        /// <summary>
        /// Permite eliminar la auditoria seleccionada en el grid
        /// </summary>
        /// <param name="id">Identificador de auditoria</param>
        public void QuitarAuditoria(string id)
        {
            try
            {
                //Buscar por id la auditoria a eliminar
                int idAuditoria = Convert.ToInt32(id);
                Auditoria auditoria = DataAuditorias.Auditoria.Single(e => e.IdAuditoria == idAuditoria);
                //Eliminar auditoria
                DataAuditorias.Auditoria.Remove(auditoria);
                //Refrescar grid
                CargarAuditorias();
            }
            catch (Exception ex)
            {
                AddCallbackValue("0");
                AddCallbackValue(ex.Message);
            }
        }

        /// <summary>
        /// Permite devolver los datos de la auditoria a modificar en el popup
        /// </summary>
        /// <param name="id">Identificado de auditoria</param>
        public void EditarAuditoria(string id)
        {
            try
            {
                //Buscar por id la auditoria a modificar
                int idAuditoria = Convert.ToInt32(id);
                Auditoria eAuditoria = DataAuditorias.Auditoria.Single(e => e.IdAuditoria == idAuditoria);
                //Devolver los datos de la auditoria a modificar               
                AddCallbackValue("1");
                AddCallbackValue(Convert.ToString(eAuditoria.IdAuditoria.Value));
                AddCallbackValue(Convert.ToString(eAuditoria.ObjEntidadAuditada.IdEntidadAuditada));
                AddCallbackValue(eAuditoria.ObjEntidadAuditada.NombreEntidadAuditada);
                AddCallbackValue(eAuditoria.ObjEntidadAuditada.ObjArea.descripcion);
                AddCallbackValue(Convert.ToString(eAuditoria.ObjEntidadAuditada.ObjArea.codigo.Value));
                AddCallbackValue(Convert.ToString(eAuditoria.ObjEntidadAuditada.IdResponsable));
                AddCallbackValue(eAuditoria.ObjEntidadAuditada.Responsable);
                AddCallbackValue(eAuditoria.Alcance);
                AddCallbackValue(eAuditoria.Objetivo);
                AddCallbackValue(eAuditoria.FechaInicio.ToShortDateString());
                AddCallbackValue(eAuditoria.FechaFin.ToShortDateString());
            }
            catch (Exception ex)
            {
                AddCallbackValue("0");
                AddCallbackValue(ex.Message);
            }
        }

        /// <summary>
        /// Guardar programa anual de auditoria con estado creado
        /// tambien, la lista de auditorias que estan en el grid con estado creado
        /// </summary>
        public void GrabarProgramaAnualAuditoria()
        {
            try
            {
                int idPrograma = 0;
                string strMensaje = "";
                //Validar auditoria
                if (DataAuditorias.Auditoria == null || DataAuditorias.Auditoria.Count() == 0 || DataAuditorias.Auditoria.Count() > 3)
                {
                    strMensaje = "Ingresar auditorias necesarias";
                }
                else
                {
                    //Obtener datos
                    ProgramaAnualAuditoria eProgramaAnual = new ProgramaAnualAuditoria();
                    eProgramaAnual.AnhoPrograma = DateTime.Today.Year;
                    eProgramaAnual.IdUsuarioCreacion = 1; //TODO: Actualizar con usuario en sesion
                    eProgramaAnual.ObjAuditorias = DataAuditorias.Auditoria;
                    //Grabar la programa anual de auditoria
                    idPrograma = TMD.Site.Controladora.ACP.AuditoriaControladora.GrabarProgramaAnualAuditoria(eProgramaAnual);
                    //refrescar grid auditorias
                    DataAuditorias.Auditoria.Clear();
                    List<Auditoria> lstAuditoriar = TMD.Site.Controladora.ACP.AuditoriaControladora.ListarAuditoriasPorAnio(eProgramaAnual.AnhoPrograma);
                    foreach (Auditoria eAuditoria in lstAuditoriar)
                    {
                        DataAuditorias.Auditoria.Add(eAuditoria);
                    }
                    rptProgramaAnual.DataSource = DataAuditorias.Auditoria;
                    rptProgramaAnual.DataBind();              
                }
                //Colocar 1 para mostrar mensaje de confirmacion
                AddCallbackValue("1");
                lblIdPrograma.Text = idPrograma.ToString();
                AddCallbackValue(strMensaje);
                AddCallbackControl(lblIdPrograma);
                AddCallbackControl(rptProgramaAnual);
            }
            catch (Exception ex)
            {
                AddCallbackValue("0");
                AddCallbackValue(ex.Message);
            }
        }
    }
}