using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class PlanMantenimiento
    {
        public int CodigoPlan { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaInicio{ get; set; }
        public DateTime FechaFin { get; set; }
        public int Estado { get; set; }
        public String Observacion { get; set; }
        public Rutina Rutina { get; set; }
        public Empleado Empleado { get; set; }
    }
}
