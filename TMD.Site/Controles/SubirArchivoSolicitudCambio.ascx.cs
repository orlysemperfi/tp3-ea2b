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
        public delegate void SubioArchivoSolicitudHandler();
        public event SubioArchivoSolicitudHandler EventoSubioArchivoSolicitud;

        public delegate void CancelarArchivoSolicitudHandler();
        public event CancelarArchivoSolicitudHandler EventoCanceloArchivoSolicitud;

        protected virtual void OnEventoSubioArchivoSolicitud()
        {
            SubioArchivoSolicitudHandler handler = EventoSubioArchivoSolicitud;
            if (handler != null) handler();
        }

        protected virtual void OnEventoCanceloArchivoSolicitud()
        {
            CancelarArchivoSolicitudHandler handler = EventoCanceloArchivoSolicitud;
            if (handler != null) handler();
        }

        public int IdSolicitudCambio
        {
            get { return hidIdSolicitud.Value.ToInt(); }
            set { hidIdSolicitud.Value = value.ToString(); }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            byte[] archivo = fileUpArchivo.FileBytes;
            String nombre = System.IO.Path.GetFileName(fileUpArchivo.FileName);
            SolicitudCambioControladora.ActualizarArchivo(IdSolicitudCambio, nombre, archivo);

            OnEventoSubioArchivoSolicitud();
        }

        public void Limpiar()
        {
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            OnEventoCanceloArchivoSolicitud();
        }
    }
}