using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class EscalaCuantitativoEntidad
    {
        public int? codigo { get; set; }
        public int? codigo_Indicador { get; set; }
        public String signo { get; set; }
        public double valor { get; set; }
        public int? codigo_Unidad { get; set; }
        public int action { get; set; }
        public String descripcion_unidad { get; set; }
    }
}
