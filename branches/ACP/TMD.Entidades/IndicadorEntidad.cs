using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class IndicadorEntidad
    {
        public int? codigo { get; set; }
        public String nombre { get; set; }
        public String frecuencia_Medicion { get; set; }
        public String fuente_Medicion { get; set; }
        public String expresion_Matematica { get; set; }
        public String plazo { get; set; }
        public int tipo { get; set; }
        public int action { get; set; }
        public int codigo_Area { get; set; }
        public int codigo_Proceso { get; set; }
        public int reemplaza_Indicador { get; set; }
        public int estado { get; set; }
        public List<EscalaCualitativoEntidad> lstEscalaCualitativo { get; set; }
        public List<EscalaCuantitativoEntidad> lstEscalaCuantitativo { get; set; }
        public int codigo_Propuesta { get; set; }
        public String marcado{ get; set; }
    }
}
