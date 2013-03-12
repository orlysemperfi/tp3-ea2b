using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class SolucionMejoraEntidad
    {
        public int? codigo_Solucion { get; set; }
        public int? codigo_Propuesta { get; set; }
        public DateTime fecha_Envio { get; set; }
        public DateTime? fecha_Registro_Inicio { get; set; }
        public DateTime? fecha_Registro_Fin { get; set; }
        public String? propuesta { get; set; }

    }
}
