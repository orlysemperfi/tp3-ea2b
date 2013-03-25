using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class OrdenTrabajo
    {
        public int CodigoOrden { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Empleado Empleado { get; set; }
        public String Observacion { get; set; }
        public int Estado { get; set; }
    }
}
