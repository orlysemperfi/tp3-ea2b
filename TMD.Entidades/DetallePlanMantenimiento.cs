using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class DetallePlanMantenimiento
    {
        public int LineaDetallePlan { get; set; }
        public PlanMantenimiento Plan { get; set; }
        public EquipoComputo EquipoComputo { get; set; }
        public DateTime FechaProgramada { get; set; }
        public int DuracionDias { get; set; }
        public int DuracionHoras { get; set; }
        public int DuracionMinutos { get; set; }
    }
}
