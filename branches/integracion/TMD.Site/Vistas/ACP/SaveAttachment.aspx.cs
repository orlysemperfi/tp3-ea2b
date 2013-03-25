using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace TMD.CF.Site.Vistas.ACP
{
    public partial class SaveAttachment : System.Web.UI.Page
    {
        
    private string ErrorMessage = "";
	private string ImageName = "";

	private bool existImage = false;

	protected void Page_Load(object sender, System.EventArgs e)
	{
        __FromSave.Text = Request["__FromSave"];
		if (Request.Files.Count != 0) {
			try {
				HttpPostedFile postedFile = FileUpload.PostedFile;

				if (postedFile == null)
					return;
				string fileName = System.IO.Path.GetFileName(postedFile.FileName);

				if (postedFile.ContentLength == 0) {
					__Message.Text = "File doesn't exist. Please check and try again.";
					__File.Text = fileName;
					return;
				}

				if (!CheckFile(fileName))
					return;
				if (!ValidateSizeFile(Request.Files[0].InputStream))
					return;
				if ((ExistsImageSave(fileName)))
					return;

				ImageName = fileName;
				
				string mOriginalFileName = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf("\\") + 1);
				string mFileName = null;
				string mExtension = "";
				if (mOriginalFileName.IndexOf(".") != 0) {
					mExtension = mOriginalFileName.Substring(mOriginalFileName.LastIndexOf(".") + 1);
				}
				string mNewGuiID = Guid.NewGuid().ToString();
				mFileName = mNewGuiID + "." + mExtension;
				__FileName.Text = mFileName;
				__File.Text = mOriginalFileName;
				__Extension.Text = mExtension;
                __Size.Text = Convert.ToString(postedFile.ContentLength);

                string mRutaParametro = System.Configuration.ConfigurationManager.AppSettings["parameters.files.location"];
                string mPath = mRutaParametro + mFileName;

                postedFile.SaveAs(mPath);
		
			} catch (Exception ex) {
                ErrorMessage = ex.Message;				
			}
		}
	}

	private bool ValidateSizeFile(System.IO.Stream Stream)
	{
		Int64 mLength = Stream.Length;
		if (mLength > 5242880) {
            ErrorMessage = "Archivo no puede exceder de 5242880";
			return false;
		}
		return true;
	}

	private bool ExistsImageSave(string FileName)
	{
		bool exist = false;
        string Path = "D:\\UPC\\2013-00\\Taller de Proyecto 3\\" + FileName;
		if (ExistsImage(Path)) {
			exist = true;
		}
		existImage = exist;
		return exist;
	}

	private bool CheckFile(string FileName)
	{
		bool IsImage = true;
		string[] arr = FileName.Split('.');
		string FileExtension = arr[arr.Length - 1];
		if (!(FileExtension.ToLower().Contains("pdf") || FileExtension.ToLower().Contains("doc") || FileExtension.ToLower().Contains("docx") || FileExtension.ToLower().Contains("xls") || FileExtension.ToLower().Contains("xlsx") || FileExtension.ToLower().Contains("ppt") || FileExtension.ToLower().Contains("pptx"))) {
			ErrorMessage = "Formato No valido";
			IsImage = false;
		}
		return IsImage;
	}

	private bool ExistsImage(string Path)
	{
		return System.IO.File.Exists(Path);
	}

	public string GetResponse()
	{
		string Response = "";
		if (!string.IsNullOrEmpty(ErrorMessage)) {
			Response = string.Format("alert('{0}');", ErrorMessage);
		}

		if (existImage) {
			//Response = String.Format("existImage('{1}','{0}{1}')", BL.Application.ApplicationInfo.AppWebImageLibrary, ImageName)
		}

		if (string.IsNullOrEmpty(ErrorMessage) && !existImage && !string.IsNullOrEmpty(ImageName)) {
			//Response = String.Format("parent.setLogo('{1}','{0}{1}');", BL.Application.ApplicationInfo.AppWebImageLibrary, ImageName)
		}

		return Response;
	}


    //public static bool SaveFile(string ArchiveName, System.Web.HttpPostedFile fil)
    //{
    //    string storageLocation = BL.Application.ApplicationInfo.AppImgLibrary + ArchiveName;
    //    fil.SaveAs(storageLocation);
    //    return true;
    //}




    }
}