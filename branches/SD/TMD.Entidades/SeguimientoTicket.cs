using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class SeguimientoTicket
    {
        public int Codigo_Ticket { get; set; }
        public int Codigo_Seguimiento { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public String Descripcion_Seguimiento { get; set; }
        public int Codigo_Equipo { get; set; }
        public int Codigo_Integrante { get; set; }
        public String Tipo_Seguimiento { get; set; }


    }
}
