using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.Core.Extension;
using TMD.CF.Site.Controladora.CF;

namespace TMD.CF.Site.Controles
{
    public partial class SubirArchivoSolicitudCambio : System.Web.UI.UserControl
    {
        public delegate void SubirArchivoSolicitudHandler();

        public event SubirArchivoSolicitudHandler EventoSubirArchivoSolicitud;

        public int IdSolicitudCambio
        {
            get { return hidIdSolicitud.Value.ToInt(); }
            set { hidIdSolicitud.Value = value.ToString(); }
        }

        protected virtual void OnEventoSubirArchivoSolicitud()
        {
            SubirArchivoSolicitudHandler handler = EventoSubirArchivoSolicitud;
            if (handler != null) handler();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            byte[] archivo = fileUpArchivo.FileBytes;
            String nombre = System.IO.Path.GetFileName(fileUpArchivo.FileName);
            SolicitudCambioControladora.ActualizarArchivo(IdSolicitudCambio, nombre, archivo);

            OnEventoSubirArchivoSolicitud();
        }
    }
}