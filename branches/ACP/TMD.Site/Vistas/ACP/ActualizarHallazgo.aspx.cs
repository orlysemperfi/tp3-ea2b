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
    public partial class ActualizarHallazgo : BasePage
    {

        private int idAuditoria;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblAuditoria.Text = Helper.Right("00000" + Convert.ToString(Request.QueryString[0]), 5);
            idAuditoria = Convert.ToInt32(Request.QueryString[0]);
            __IdAuditoria.Value = idAuditoria.ToString();

            if (IsCallback | Page.IsPostBack)
            {
                return;
            }

            CargarDatos();
            ListarNormas();
            ListarCapitulos(__IdAuditoria.Value, cboNorma.SelectedValue);
            ListarPreguntas(__IdAuditoria.Value, cboNorma.SelectedValue, cboCapitulo.SelectedValue);
        }

        private void CargarDatos()
        {
            try
            {
                Auditoria oFiltroAuditoria = new Auditoria();
                oFiltroAuditoria.AnhoAuditoria = DateTime.Now.Year;
                oFiltroAuditoria.Estado = null;
                oFiltroAuditoria.IdAuditoria = Convert.ToInt32(lblAuditoria.Text);
                oFiltroAuditoria.IndCheckListEstablecido = true;
                List<Auditoria> lstAuditorias = TMD.Site.Controladora.ACP.AuditoriaControladora.ObtenerPlanAuditoriaPorID(oFiltroAuditoria);

                if (lstAuditorias.Count >= 1)
                {
                    lblDescrip.Text = lstAuditorias[0].ObjEntidadAuditada.NombreEntidadAuditada;
                    lblArea.Text = lstAuditorias[0].ObjEntidadAuditada.ObjArea.descripcion;
                    lblResponsable.Text = lstAuditorias[0].ObjEntidadAuditada.Responsable;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void ListarNormas()
        {
            try
            {
                List<Norma> lstNormas = TMD.Site.Controladora.ACP.PreguntaVerificacionControladora.ObtenerNorma(null);
                cboNorma.DataSource = lstNormas;
                cboNorma.DataTextField = "descripcionNorma";
                cboNorma.DataValueField = "idNorma";
                cboNorma.DataBind();

                cboNorma.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void ListarCapitulos(string codAuditoria, string codNorma)
        {
            try
            {
                int idAuditoria = Convert.ToInt32(codAuditoria);
                int idNorma = Convert.ToInt32(codNorma);
                int idCapitulo = 0;
                List<Capitulo> lstCapitulos = TMD.Site.Controladora.ACP.PreguntaVerificacionControladora.ObtenerCapitulo(idNorma, null);

                cboCapitulo.DataSource = lstCapitulos;
                cboCapitulo.DataTextField = "descripcionCapitulo";
                cboCapitulo.DataValueField = "idCapitulo";
                cboCapitulo.DataBind();

                if (lstCapitulos.Count() > 0)
                {
                    idCapitulo = Convert.ToInt32(lstCapitulos[0].IdCapitulo);
                }

                List<PreguntaVerificacion> lstPreguntas = TMD.Site.Controladora.ACP.PreguntaVerificacionControladora.ObtenerPreguntaVerificacion(idAuditoria, idNorma, idCapitulo);
                rptPreguntas.DataSource = lstPreguntas;
                rptPreguntas.DataBind();

                Hallazgo oHallazgo = new Hallazgo();
                oHallazgo.IdAuditoria = Convert.ToInt32(codAuditoria);
                oHallazgo.IdPreguntaVerificacion = 0;
                oHallazgo.IdHallazgo = null;
                oHallazgo.TipoHallazgo = "";

                List<Hallazgo> lstHallazgo = TMD.Site.Controladora.ACP.HallazgoControladora.ObtenerHallazgo(oHallazgo);

                rptHallazgos.DataSource = lstHallazgo;
                rptHallazgos.DataBind();

                AddCallbackValue("1");
                AddCallbackControl(cboCapitulo);
                AddCallbackControl(rptPreguntas);
                AddCallbackControl(rptHallazgos);

            }
            catch (Exception ex)
            {
                AddCallbackValue("0");
                return;
            }
        }

        public void ListarPreguntas(string codAuditoria, string codNorma, string codCapitulo)
        {
            try
            {
                int idAuditoria = Convert.ToInt32(codAuditoria);
                int idNorma = Convert.ToInt32(codNorma);
                int idCapitulo = Convert.ToInt32(codCapitulo);
                
                int idPregunta = 0;
                
                List<PreguntaVerificacion> lstPreguntas = TMD.Site.Controladora.ACP.PreguntaVerificacionControladora.ObtenerPreguntaVerificacion(idAuditoria, idNorma, idCapitulo);
                rptPreguntas.DataSource = lstPreguntas;
                rptPreguntas.DataBind();
            
                Hallazgo oHallazgo = new Hallazgo();
                oHallazgo.IdAuditoria = Convert.ToInt32(codAuditoria);
                oHallazgo.IdPreguntaVerificacion = idPregunta;
                oHallazgo.IdHallazgo = null;
                oHallazgo.TipoHallazgo = "";

                List<Hallazgo> lstHallazgo = TMD.Site.Controladora.ACP.HallazgoControladora.ObtenerHallazgo(oHallazgo);

                rptHallazgos.DataSource = lstHallazgo;
                rptHallazgos.DataBind();

                AddCallbackValue("1");
                AddCallbackControl(rptPreguntas);
                AddCallbackControl(rptHallazgos);                
            }
            catch (Exception ex)
            {

                return;
            }
        }

        public void ListarHallazgos(string codAuditoria, string codPregunta)
        {
            try
            {
                Hallazgo oHallazgo = new Hallazgo();
                oHallazgo.IdAuditoria = Convert.ToInt32(codAuditoria);
                oHallazgo.IdPreguntaVerificacion = Convert.ToInt32(codPregunta);
                oHallazgo.IdHallazgo = null;
                oHallazgo.TipoHallazgo = "";

                List<Hallazgo> lstHallazgo = TMD.Site.Controladora.ACP.HallazgoControladora.ObtenerHallazgo(oHallazgo);

                rptHallazgos.DataSource = lstHallazgo;
                rptHallazgos.DataBind();

                AddCallbackValue("1");
                AddCallbackControl(rptHallazgos);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void GrabarPregunta()
        {
            int idAuditoria = Convert.ToInt32(Request["ctl00$MainContent$__IdAuditoria"]);
            int idPregunta = Convert.ToInt32(Request["ctl00$MainContent$__TmpIdPregunta"]);
            string respuesta = Convert.ToString(Request["ctl00$MainContent$__TmpChkRpta"]);
            string sustento = Convert.ToString(Request["ctl00$MainContent$__TmpSustento"]);
            int porcentaje = Convert.ToInt32(Request["ctl00$MainContent$__TmpPorcentaje"]);

            int idNorma = Convert.ToInt32(Request["ctl00$MainContent$cboNorma"]);
            int idCapitulo = Convert.ToInt32(Request["ctl00$MainContent$cboCapitulo"]);

            PreguntaVerificacion oPregunta = new PreguntaVerificacion();
            oPregunta.ObjAuditoria.IdAuditoria = idAuditoria;
            oPregunta.idPreguntaVerificacion = idPregunta;
            oPregunta.Respuesta = false;
            oPregunta.Sustento = sustento;
            oPregunta.Porcentaje = porcentaje;

            TMD.Site.Controladora.ACP.PreguntaVerificacionControladora.ModificarPreguntaVerificacion(oPregunta);

            List<PreguntaVerificacion> lstPreguntas = TMD.Site.Controladora.ACP.PreguntaVerificacionControladora.ObtenerPreguntaVerificacion(idAuditoria, idNorma, idCapitulo);
            rptPreguntas.DataSource = lstPreguntas;
            rptPreguntas.DataBind();

            AddCallbackValue("1");
            AddCallbackControl(rptPreguntas);

        }

        public void GrabarHallazgo()
        {
            int idAuditoria = Convert.ToInt32(Request["ctl00$MainContent$__IdAuditoria"]);
            int idHallazgo = Convert.ToInt32(Request["ctl00$MainContent$__TmpIdHallazgo"]);            
            string desHallazgo = Convert.ToString(Request["ctl00$MainContent$__TmpDesHallazgo"]);
            int idPregunta = Convert.ToInt32(Request["ctl00$MainContent$__TmpIdPregunta"]);
            string tipoHallazgo = Convert.ToString(Request["ctl00$MainContent$__TmpTipoHallazgo"]);
          
            Hallazgo oHallazgo = new Hallazgo();

            oHallazgo.IdAuditoria = idAuditoria;
            oHallazgo.IdHallazgo = idHallazgo;
            oHallazgo.Descripcion = desHallazgo;
            oHallazgo.IdPreguntaVerificacion = idPregunta;
            oHallazgo.TipoHallazgo = tipoHallazgo;
            oHallazgo.Estado = EstadoAuditoria.Creado;

            string sRpta = TMD.Site.Controladora.ACP.HallazgoControladora.ModificarrHallazgo(oHallazgo);

            oHallazgo = new Hallazgo();
            oHallazgo.IdAuditoria = idAuditoria;
            oHallazgo.IdPreguntaVerificacion = idPregunta;
            oHallazgo.IdHallazgo = null;
            oHallazgo.TipoHallazgo = "";

            List<Hallazgo> lstHallazgo = TMD.Site.Controladora.ACP.HallazgoControladora.ObtenerHallazgo(oHallazgo);

            rptHallazgos.DataSource = lstHallazgo;
            rptHallazgos.DataBind();

            AddCallbackValue("1");
            AddCallbackControl(rptHallazgos);

        }

        public void AgregarHallazgo()
        {
            int idAuditoria = Convert.ToInt32(Request["ctl00$MainContent$__IdAuditoria"]);
            int idHallazgo = 0;
            string desHallazgo = Convert.ToString(Request["ctl00$MainContent$__TmpDesHallazgo"]);
            int idPregunta = Convert.ToInt32(Request["ctl00$MainContent$__TmpIdPregunta"]);
            string tipoHallazgo = Convert.ToString(Request["ctl00$MainContent$__TmpTipoHallazgo"]);

            Hallazgo oHallazgo = new Hallazgo();

            oHallazgo.IdAuditoria = idAuditoria;
            oHallazgo.IdHallazgo = idHallazgo;
            oHallazgo.Descripcion = desHallazgo;
            oHallazgo.IdPreguntaVerificacion = idPregunta;
            oHallazgo.TipoHallazgo = tipoHallazgo;
            oHallazgo.Estado = EstadoAuditoria.Creado;

            int nIdOri = TMD.Site.Controladora.ACP.HallazgoControladora.AgregarHallazgo(oHallazgo);

            oHallazgo = new Hallazgo();
            oHallazgo.IdAuditoria = idAuditoria;
            oHallazgo.IdPreguntaVerificacion = idPregunta;
            oHallazgo.IdHallazgo = null;
            oHallazgo.TipoHallazgo = "";

            List<Hallazgo> lstHallazgo = TMD.Site.Controladora.ACP.HallazgoControladora.ObtenerHallazgo(oHallazgo);

            rptHallazgos.DataSource = lstHallazgo;
            rptHallazgos.DataBind();

            AddCallbackValue("1");
            AddCallbackControl(rptHallazgos);

        }
            

        protected void rptPreguntas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.Item)
            {
                PreguntaVerificacion ePreguntaVerificacion = (PreguntaVerificacion)e.Item.DataItem;

                //Modo Vista

                Literal litRpta = (Literal)e.Item.FindControl("litRpta");
                if (ePreguntaVerificacion.Respuesta.HasValue) { litRpta.Text = (ePreguntaVerificacion.Respuesta.Value ? "SI" : "NO"); } else litRpta.Text = "";

                //Modo Editable

                CheckBox chkRpta = (CheckBox)e.Item.FindControl("chkRpta");
                if (ePreguntaVerificacion.Respuesta.HasValue) chkRpta.Checked = ePreguntaVerificacion.Respuesta.Value;

                HtmlAnchor lnkListarHallazgos = (HtmlAnchor)e.Item.FindControl("lnkListarHallazgos");
                lnkListarHallazgos.HRef = string.Format("javascript:fListarHallazgos({0});", ePreguntaVerificacion.idPreguntaVerificacion);

                if (!ePreguntaVerificacion.Respuesta.HasValue) lnkListarHallazgos.Style.Add("display", "none");
            }
        }

        protected void rptHallazgos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.Item)
            {
                Hallazgo eHallazgo = (Hallazgo)e.Item.DataItem;

                DropDownList ddlTipoHallazgo = (DropDownList)e.Item.FindControl("ddlTipoHallazgo");
                ddlTipoHallazgo.SelectedValue = eHallazgo.TipoHallazgo;

                Literal litTipoHallazgo = (Literal)e.Item.FindControl("litTipoHallazgo");

                if (eHallazgo.TipoHallazgo == "NOCONFORMIDAD")
                    litTipoHallazgo.Text = "NO CONFORMIDAD";
                else
                    litTipoHallazgo.Text = eHallazgo.TipoHallazgo;
                

                //Modo Vista              
            }
        }
    }
}