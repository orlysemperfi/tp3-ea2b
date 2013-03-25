using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class DetalleOrden
    {
        public int LineaDetalleOrden { get; set; }
        public OrdenTrabajo OrdenTrabajo { get; set; }
        public DetalleSolicitud DetalleSolicitud { get; set; }
        public DetallePlanMantenimiento DetallePlan { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Estado { get; set; }
    }
}
