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
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;


namespace TMD.ACP.Site
{
    public partial class _MantenerHallazgo : System.Web.UI.Page
    {
        static int nIdPregunta;
        static int nOpc = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAuditoria.Text = Helper.Right("00000" + Convert.ToString(Request.QueryString[0]), 5);

            CargarDatos();
            if (!IsPostBack)
            {                
                ListarNormas();
                ListarCapitulos();
                ListarPreguntas();
            }
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
                    //lblArea.Text = lstAuditorias[0].ObjEntidadAuditada.ObjArea.NombreArea;
                    lblArea.Text = lstAuditorias[0].ObjEntidadAuditada.ObjArea.descripcion;
                    lblResponsable.Text = lstAuditorias[0].ObjEntidadAuditada.Responsable;
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "WebSiteExceptionPolicy");
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error al Realizar la Transacción";
                return;
            } 
        }

        private void ListarNormas()
        {
            try
            {
                lblError.Text = "";
                List<Norma> lstNormas = TMD.Site.Controladora.ACP.PreguntaVerificacionControladora.ObtenerNorma(null);
                cboNorma.DataSource = lstNormas;
                cboNorma.DataTextField = "descripcionNorma";
                cboNorma.DataValueField = "idNorma";
                cboNorma.DataBind();

                cboNorma.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "WebSiteExceptionPolicy");
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error al Realizar la Transacción";
                return;
            } 
        }

        private void ListarCapitulos()
        {
            try
            {
                lblError.Text = "";
                Int32 nIdNorma = (cboNorma.SelectedValue.Equals("") == true ? 0 : Convert.ToInt32(cboNorma.SelectedValue));
                List<Capitulo> lstCapitulos = TMD.Site.Controladora.ACP.PreguntaVerificacionControladora.ObtenerCapitulo(nIdNorma, null);
                cboCapitulo.DataSource = lstCapitulos;
                cboCapitulo.DataTextField = "descripcionCapitulo";
                cboCapitulo.DataValueField = "idCapitulo";
                cboCapitulo.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "WebSiteExceptionPolicy");
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error al Realizar la Transacción";
                return;
            }
        }

        private void ListarPreguntas()        
        {
            try
            {
                lblError.Text = "";
                Int32 nIdNorma = (cboNorma.SelectedValue.Equals("") == true ? 0 : Convert.ToInt32(cboNorma.SelectedValue));
                Int32 nIdCapitulo = (cboCapitulo.SelectedValue.Equals("") == true ? 0 : Convert.ToInt32(cboCapitulo.SelectedValue));
                List<PreguntaVerificacion> lstPreguntas = TMD.Site.Controladora.ACP.PreguntaVerificacionControladora.ObtenerPreguntaVerificacion(Convert.ToInt32(lblAuditoria.Text), nIdNorma, nIdCapitulo);
                gvPreguntaVerif.DataSource = lstPreguntas;
                gvPreguntaVerif.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "WebSiteExceptionPolicy");
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error al Realizar la Transacción";
                return;
            }
        }

        private void ListarHallazgos(Int32 nIdPreguntaVerif)
        {
            try
            {
                lblError.Text = "";
                Hallazgo oHallazgo = new Hallazgo();
                oHallazgo.IdAuditoria = Convert.ToInt32(lblAuditoria.Text);
                oHallazgo.IdPreguntaVerificacion = nIdPreguntaVerif;
                oHallazgo.IdHallazgo = null;
                oHallazgo.TipoHallazgo = "";
                List<Hallazgo> lstHallazgo = TMD.Site.Controladora.ACP.HallazgoControladora.ObtenerHallazgo(oHallazgo);

                if (lstHallazgo.Count > 0)
                {
                    gvHallazgo.DataSource = lstHallazgo;
                    gvHallazgo.DataBind();
                }
                else 
                {
                    lstHallazgo.Add(oHallazgo);
                    gvHallazgo.DataSource = lstHallazgo;
                    gvHallazgo.DataBind();
                    gvHallazgo.Rows[0].Cells.Clear();
                    gvHallazgo.Rows[0].Cells.Add(new TableCell());
                    gvHallazgo.Rows[0].Cells[0].ColumnSpan = gvHallazgo.Columns.Count;

                    ////You can set the styles here
                    //gvHallazgo.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    //gvHallazgo.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    //gvHallazgo.Rows[0].Cells[0].Font.Bold = true;
                    ////set No Results found to the new added cell
                    //gvHallazgo.Rows[0].Cells[0].Text = "NO RESULT FOUND!";
                }
                
                gvHallazgo.Caption = "Datos de Hallazgos de la Pregunta: " + Helper.Right("000" + nIdPreguntaVerif.ToString(), 3);
                
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "WebSiteExceptionPolicy");
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error al Realizar la Transacción";
                return;
            }
        }

        protected void cboNorma_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCapitulos();
            ListarPreguntas();
            gvHallazgo.DataSource = null;
            gvHallazgo.DataBind();
        }

        protected void cboCapitulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarPreguntas();
            gvHallazgo.DataSource = null;
            gvHallazgo.DataBind();
        }

        protected void gvPreguntaVerif_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    PreguntaVerificacion oPreguntaVerif = (PreguntaVerificacion)e.Row.DataItem;
                    Literal l; CheckBox c; TextBox t; DropDownList d; Label lb; LinkButton lk;
                    l = (Literal)e.Row.FindControl("ltrlIdPreg");
                    if (l != null) l.Text = Helper.Right("000" + oPreguntaVerif.idPreguntaVerificacion.ToString(), 3);

                    l = (Literal)e.Row.FindControl("ltrlDesPreg");
                    if (l != null) l.Text = oPreguntaVerif.DescripcionPregunta;

                    l = (Literal)e.Row.FindControl("ltrlRpta");
                    if (l != null) l.Text =
                        oPreguntaVerif.Respuesta.Equals(null) == true ? "" :
                        (Convert.ToBoolean(oPreguntaVerif.Respuesta) == true ? "Si" : "No");

                    c = (CheckBox)e.Row.FindControl("chkRpta");
                    if (c != null)
                    {
                        c.Checked = Convert.ToBoolean(oPreguntaVerif.Respuesta);
                        c.Attributes.Add("onclick", "javascript:CheckSatus(" + e.Row.RowIndex.ToString() + ")");
                    }

                    l = (Literal)e.Row.FindControl("ltrlSustento");
                    if (l != null) l.Text = oPreguntaVerif.Sustento;

                    t = (TextBox)e.Row.FindControl("txtSustento");
                    if (t != null) t.Text = oPreguntaVerif.Sustento;

                    lb = (Label)e.Row.FindControl("lblPorc");
                    if (lb != null) lb.Text = (Convert.ToInt32(oPreguntaVerif.Porcentaje)).ToString() + "%";

                    d = (DropDownList)e.Row.FindControl("cboPorc");
                    
                    if (c != null && Convert.ToBoolean(oPreguntaVerif.Respuesta)) if (d != null) d.Enabled = true;
                    if (d != null) d.SelectedValue = Convert.ToInt32(oPreguntaVerif.Porcentaje).ToString();

                    lk = (LinkButton)e.Row.FindControl("lnkEdit");
                    if (lk != null)
                    {
                        lk.Visible = oPreguntaVerif.CantidadPlanif > 0 ? false : true;
                    }

                    lk = (LinkButton)e.Row.FindControl("lnkHallazgo");
                    if (lk != null)
                    {
                        lk.Visible = oPreguntaVerif.Respuesta == null ? false : true;
                    }

                    lk = (LinkButton)e.Row.FindControl("lnkUpdate");
                    if (lk != null)
                    {
                        lk.OnClientClick = "return validarPreguntas(" + e.Row.RowIndex.ToString() + ");";
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "WebSiteExceptionPolicy");
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error al Realizar la Transacción";
                return;
            }
        }

        protected void gvPreguntaVerif_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                gvHallazgo.ShowFooter = true;
                if (e.CommandName == "Hallazgo")
                {
                    //gvPreguntaVerif.SelectedIndex = gvPreguntaVerif.Rows[Convert.ToInt32(e.CommandArgument)].RowIndex;
                    //nIdPregunta = Convert.ToInt32(gvPreguntaVerif.SelectedDataKey["idPreguntaVerificacion"].ToString());
                    //ListarHallazgos(nIdPregunta);
                    nIdPregunta = Convert.ToInt32(e.CommandArgument);
                    ListarHallazgos(nIdPregunta);
                }
                if (e.CommandName == "Edit")
                {
                    gvPreguntaVerif.Columns[6].Visible = false;
                    gvHallazgo.DataSource = null;
                    gvHallazgo.DataBind();
                }
                if (e.CommandName == "Cancel" || e.CommandName == "Update")
                {
                    gvPreguntaVerif.Columns[6].Visible = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "WebSiteExceptionPolicy");
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error al Realizar la Transacción";
                return;
            }
        }

        protected void gvPreguntaVerif_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPreguntaVerif.EditIndex = -1;
            ListarPreguntas();
        }

        protected void gvPreguntaVerif_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                lblError.Text = "";
                PreguntaVerificacion oPregunta = new PreguntaVerificacion();
                bool bRpta = false;
                Literal lItem = (Literal)gvPreguntaVerif.Rows[e.RowIndex].FindControl("ltrlIdPreg");
                Literal lDesPreg = (Literal)gvPreguntaVerif.Rows[e.RowIndex].FindControl("ltrlDesPreg");
                CheckBox cRpta = (CheckBox)gvPreguntaVerif.Rows[e.RowIndex].FindControl("chkRpta");
                TextBox tSustento = (TextBox)gvPreguntaVerif.Rows[e.RowIndex].FindControl("txtSustento");
                DropDownList dPorcentaje = (DropDownList)gvPreguntaVerif.Rows[e.RowIndex].FindControl("cboPorc");

                if (cRpta.Checked) bRpta = true; else bRpta = false;

                oPregunta.ObjAuditoria.IdAuditoria = Convert.ToInt32(lblAuditoria.Text);
                oPregunta.idPreguntaVerificacion = Convert.ToInt32(lItem.Text);
                oPregunta.Respuesta = bRpta;
                oPregunta.Sustento = tSustento.Text;
                oPregunta.Porcentaje = Convert.ToDecimal(dPorcentaje.SelectedValue);

                TMD.Site.Controladora.ACP.PreguntaVerificacionControladora.ModificarPreguntaVerificacion(oPregunta);

                gvPreguntaVerif.EditIndex = -1;

                ListarPreguntas();
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "WebSiteExceptionPolicy");
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error al Realizar la Transacción";
                return;
            }
        }

        protected void gvPreguntaVerif_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPreguntaVerif.EditIndex = e.NewEditIndex;
            ListarPreguntas();
        }

        protected void gvHallazgo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                lblError.Text = "";
                Hallazgo oHallazgo = (Hallazgo)e.Row.DataItem;
                Literal l; DropDownList c; TextBox t; LinkButton lk; 
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    l = (Literal)e.Row.FindControl("lblId");
                    if (l != null) l.Text = Helper.Right("000" + oHallazgo.IdHallazgo.ToString(), 3);

                    t = (TextBox)e.Row.FindControl("txtDesHallazgo");
                    if (t != null) t.Text = oHallazgo.Descripcion;

                    l = (Literal)e.Row.FindControl("lblDesHallazgo");
                    if (l != null) l.Text = oHallazgo.Descripcion;

                    c = (DropDownList)e.Row.FindControl("cbotipo");
                    if (c != null) c.SelectedValue = oHallazgo.TipoHallazgo;

                    l = (Literal)e.Row.FindControl("lblTipo");
                    if (l != null) l.Text = oHallazgo.TipoHallazgo;

                    l = (Literal)e.Row.FindControl("lblCantDoc");
                    if (l != null) l.Text = oHallazgo.nDoc.ToString();

                    l = (Literal)e.Row.FindControl("lblEstado");
                    if (l != null) l.Text = oHallazgo.Estado;

                    lk = (LinkButton)e.Row.FindControl("lnkUpdate");
                    if (lk != null)
                    {
                        lk.OnClientClick = "return validarHallazgos(2," + e.Row.RowIndex.ToString() + ");";
                    }

                    lk = (LinkButton)e.Row.FindControl("lnkEdit");
                    if (lk != null)
                    {
                        lk.Visible = (oHallazgo.Estado == "PLANIFICADO") ? false : true;
                    }

                    lk = (LinkButton)e.Row.Cells[7].Controls[0];
                    if (lk != null)
                    {
                        lk.OnClientClick = "return confirm('¿Esta seguro de eliminar el Hallazgo?')";
                        lk.Visible = (oHallazgo.Estado == "PLANIFICADO") ? false : true;
                    }                    
                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    lk = (LinkButton)e.Row.FindControl("lnkAdd");
                    if (lk != null)
                    {
                        lk.OnClientClick = "return toogle();";
                    }
                }
            }
            catch (Exception ex)
            {
                //lblError.ForeColor = System.Drawing.Color.Red;
                //lblError.Text = "Error al Realizar la Transacción";
                ExceptionPolicy.HandleException(ex, "WebSiteExceptionPolicy");
                return;
            }
        }

        protected void gvHallazgo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                lblError.Text = ""; nOpc = 2;
                Hallazgo oHallazgo = new Hallazgo();

                Literal lId = (Literal)gvHallazgo.Rows[e.RowIndex].FindControl("lblId");
                TextBox tDesHallazgo = (TextBox)gvHallazgo.Rows[e.RowIndex].FindControl("txtDesHallazgo");
                DropDownList cbTipo = (DropDownList)gvHallazgo.Rows[e.RowIndex].FindControl("cboTipo");

                oHallazgo.IdAuditoria = Convert.ToInt32(lblAuditoria.Text);
                oHallazgo.IdHallazgo = Convert.ToInt32(lId.Text);
                oHallazgo.Descripcion = tDesHallazgo.Text;
                oHallazgo.IdPreguntaVerificacion = nIdPregunta;
                oHallazgo.TipoHallazgo = cbTipo.SelectedValue.ToString();
                oHallazgo.Estado = EstadoAuditoria.Creado;

                string sRpta = TMD.Site.Controladora.ACP.HallazgoControladora.ModificarrHallazgo(oHallazgo);
                var oFile = new ArchivoLogica();
                for (int i = 0; i < UploadFile.lArchivos.Count; i++)
                {
                    int nIdArc = Convert.ToInt32(UploadFile.lArchivos[i]);
                    int nIdOri = Convert.ToInt32(lId.Text);
                    oFile.ModificarArchivo(nIdArc, nIdOri, "H");
                }

                gvHallazgo.EditIndex = -1;

                ListarHallazgos(nIdPregunta);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "WebSiteExceptionPolicy");
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error al Realizar la Transacción";
                return;
            }
        }

        protected void gvHallazgo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvHallazgo.EditIndex = -1;         

            var oFile = new ArchivoLogica();
            for (int i = 0; i < UploadFile.lArchivos.Count; i++)
            {
                int nIdArc = Convert.ToInt32(UploadFile.lArchivos[i]);
                oFile.EliminarArchivo(nIdArc);
            }

            ListarHallazgos(nIdPregunta);
        }

        protected void gvHallazgo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            nOpc = 2;
            gvHallazgo.EditIndex = e.NewEditIndex;
            ListarHallazgos(nIdPregunta);
        }

        protected void gvHallazgo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Literal lId = (Literal)gvHallazgo.Rows[e.RowIndex].FindControl("lblId");
            int id = Convert.ToInt32(lId.Text);
            TMD.Site.Controladora.ACP.HallazgoControladora.EliminarHallazgo(id);
            ListarHallazgos(nIdPregunta);
            var oFile = new ArchivoLogica();
            oFile.EliminarGrupoArchivos(id, "H");
        }

        protected void gvHallazgo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                Hallazgo oHallazgo = new Hallazgo();
                LinkButton lk; System.Web.UI.HtmlControls.HtmlAnchor hlk;
                if (e.CommandName == "Agregar")
                {
                    nOpc = 3;
                    lk = (LinkButton)gvHallazgo.FooterRow.FindControl("lnkAdd");
                    if (lk != null)
                    {
                        lk.Visible = false;
                    }

                    lk = (LinkButton)gvHallazgo.FooterRow.FindControl("lnkGrabar");
                    if (lk != null)
                    {
                        lk.Visible = true;
                        lk.OnClientClick = "return validarHallazgos(3,0);";
                    }

                    lk = (LinkButton)gvHallazgo.FooterRow.FindControl("lnkCancel");
                    if (lk != null) lk.Visible = true;
                    
                    TextBox tNewDesHallazgo = (TextBox)gvHallazgo.FooterRow.FindControl("txtNewDesHallazgo");
                    if (tNewDesHallazgo != null) tNewDesHallazgo.Visible = true;

                    DropDownList cbNewTipo = (DropDownList)gvHallazgo.FooterRow.FindControl("cboNewTipo");
                    if (cbNewTipo != null) cbNewTipo.Visible = true;

                    gvHallazgo.Rows[0].Visible = false;

                    //hlk = (HyperLink)((GridView)sender).FooterRow.FindControl("lnkAdjuntar");
                    hlk = (System.Web.UI.HtmlControls.HtmlAnchor)gvHallazgo.FooterRow.FindControl("lnkAdjuntar");
                    if (hlk != null)
                    {
                        hlk.Style["display"] = "block";
                        hlk.HRef = "javascript:openPopup('UploadFile.aspx?idOrigen=0&tipoOrigen=H&nIdAuditoria=0&nOpcion=3');";
                    }
                }
                if (e.CommandName.Equals("Insert"))
                {                    
                    TextBox tDesHallazgo = (TextBox)gvHallazgo.FooterRow.FindControl("txtNewDesHallazgo");
                    DropDownList cbTipo = (DropDownList)gvHallazgo.FooterRow.FindControl("cboNewTipo");
                    
                    oHallazgo.IdAuditoria = Convert.ToInt32(lblAuditoria.Text);
                    oHallazgo.IdHallazgo = 0;
                    oHallazgo.Descripcion = tDesHallazgo.Text;
                    oHallazgo.IdPreguntaVerificacion = nIdPregunta;
                    oHallazgo.TipoHallazgo = cbTipo.SelectedValue.ToString();

                    int nIdOri = TMD.Site.Controladora.ACP.HallazgoControladora.AgregarHallazgo(oHallazgo);

                    var oFile = new ArchivoLogica();
                    for (int i = 0; i < UploadFile.lArchivos.Count; i++)
                    {
                        int nIdArc = Convert.ToInt32(UploadFile.lArchivos[i]);
                        oFile.ModificarArchivo(nIdArc, nIdOri, "H");
                    }
                    ListarHallazgos(nIdPregunta);

                    lk = (LinkButton)gvHallazgo.FooterRow.FindControl("lnkAdd");
                    if (lk != null) lk.Visible = true;

                    lk = (LinkButton)gvHallazgo.FooterRow.FindControl("lnkGrabar");
                    if (lk != null) lk.Visible = false;

                    lk = (LinkButton)gvHallazgo.FooterRow.FindControl("lnkCancel");
                    if (lk != null) lk.Visible = false;
                }
                if (e.CommandName == "Edit")
                {
                    nOpc = 2;
                    gvHallazgo.ShowFooter = false;
                    gvHallazgo.Columns[3].Visible = false;
                    
                }
                if (e.CommandName == "Cancel" || e.CommandName == "Update")
                {
                    nOpc = 0;
                    gvHallazgo.ShowFooter = true;
                    gvHallazgo.Columns[3].Visible = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "WebSiteExceptionPolicy");
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error al Realizar la Transacción";
                return;
            }
        }

    }
}
