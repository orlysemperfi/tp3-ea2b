using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class PilotoEntidad
    {
        public int? codigo { get; set; }
        public int? codigo_Empleado { get; set; }
        public int? codigo_Solucion { get; set; }  
        public DateTime? fecha_Inicio { get; set; }
        public DateTime? fecha_Fin { get; set; }
        public String descripcion { get; set; }
        public String nombre_Empleado { get; set; }
        public int? codigo_Estado { get; set; }
        public int action { get; set; }
        public String solucion { get; set; }
        public String nombre_Estado { get; set; }
    }
}
