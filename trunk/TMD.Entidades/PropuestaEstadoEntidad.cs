using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class PropuestaEstadoEntidad
    {
        public int? codigo { get; set; }
        public int? codigo_empleado { get; set; }
        public int? codigo_propuesta { get; set; }
        public int? codigo_estado { get; set; }
        public DateTime? fecha { get; set; }
        public String observaciones { get; set; }

    }
}
