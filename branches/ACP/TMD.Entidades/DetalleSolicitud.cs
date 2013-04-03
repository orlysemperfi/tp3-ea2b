using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class DetalleSolicitud
    {
        public int LineaDetalleSolicitud{ get; set; }
        public SolicitudMantenimiento Solicitud { get; set; }
        public String Descripcion { get; set; }
    }
}
