using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class Rutina
    {
        public int CodigoRutina { get; set; }
        public String Descripcion { get; set; }
        public int Periodicidad { get; set; }
        public int DuracionDias { get; set; }
        public int DuracionHoras { get; set; }
        public int DuracionMinutos { get; set; }
    }
}
