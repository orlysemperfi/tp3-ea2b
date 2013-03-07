using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class PropuestaMejoraEntidad
    {
        public int? codigo_Propuesta { get; set; }
        public int? codigo_Area { get; set; }  
        public String tipo_Propuesta { get; set; }
        public int? codigo_Responsable { get; set; } 
        public DateTime fecha_Envio { get; set; }
        public int? codigo_Proceso { get; set; } 
        public DateTime fecha_Registro { get; set; }
        public String descripcion { get; set; }
        public String causa { get; set; }
        public String beneficios { get; set; }
        public String observaciones { get; set; }
        public int? codigo_Estado { get; set; }
        public List<IndicadorEntidad> lstIndicadores { get; set; }
        public DateTime? fecha_Registro_Inicio { get; set; }
        public DateTime? fecha_Registro_Fin { get; set; }
        public int action { get; set; }
        public String nombre_Area { get; set; }

    }
}
