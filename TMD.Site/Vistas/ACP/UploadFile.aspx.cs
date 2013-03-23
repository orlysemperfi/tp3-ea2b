using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.ACP.LogicaNegocios.Implementacion;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;


namespace TMD.ACP.Site
{
    public partial class UploadFile : System.Web.UI.Page
    {
        private char tipoOrigen;//H: Hallazgo  o  A: Auditoria
        private int idOrigen;//Id del Hallazgo o de la Auditoria
        private int nOpc;
        public static List<int> lArchivos = new List<int>(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: Establecerlo mediante parametro, el que invoca a esta pagina debe establecerlos
            //idOrigen = 1; //querystring> IdOrigen            
            //tipoOrigen = 'H'; //querystring> TipoOrigen
                        
            this.idOrigen = Convert.ToInt32(Request.QueryString[0]);            
            this.tipoOrigen = Convert.ToChar(Request.QueryString[1]);
            lblAuditoria.Text = Convert.ToInt32(Request.QueryString[2]).ToString();
            this.nOpc = Convert.ToInt32(Request.QueryString[3].ToString());

            //lnkabc.HRef = "MantenerHallazgo.aspx?idAuditoria=" + lblAuditoria.Text;
            if (nOpc == 1)
            {
                //if (gvFiles.Rows.Count > 0)
                //{
                    fUpload.Visible = false;
                    btnUpload.Visible = false;
                //}
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (fUpload.HasFile)
                {                
                    string contentType = fUpload.PostedFile.ContentType;
                    string fileName = fUpload.PostedFile.FileName;
                    byte[] byteArray = fUpload.FileBytes;
                    var wrapper = new ArchivoLogica();
                    int nIdarchivo = wrapper.InsertarArchivo(idOrigen, tipoOrigen, byteArray, fileName, contentType);
                    gvFiles.DataBind();
                    CargarLista(nIdarchivo);
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "WebSiteExceptionPolicy");
                return;
            }            
        }

        protected void gvFiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Download")
                {
                    int archivedFileId = Convert.ToInt32(e.CommandArgument);

                    var wrapper = new ArchivoLogica();
                    var archivedFile = wrapper.ObtenerArchivo(archivedFileId);

                    Response.Clear();
                    Response.ContentType = archivedFile.mimeType;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", archivedFile.nombreArchivo));
                    Response.BinaryWrite(archivedFile.dataBinaria);
                    Response.End();
                    Response.Flush();

                }
                if (e.CommandName == "Quitar")
                {
                    int archivedFileId = Convert.ToInt32(e.CommandArgument);
                    var wrapper = new ArchivoLogica();
                    wrapper.EliminarArchivo(archivedFileId);
                    gvFiles.DataBind();
                }

            }
            catch (Exception ex)
            {             
                return;
            }
        }

        protected void gvFiles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //LinkButton lk; 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }
        }

        private void CargarLista(int nId)
        {
            lArchivos.Add(nId);
        }

    }
}
