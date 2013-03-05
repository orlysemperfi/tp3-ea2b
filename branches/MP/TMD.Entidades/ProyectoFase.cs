using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class ProyectoFase
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public Proyecto Proyecto { get; set; }
        public Fase Fase { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public LineaBase LineaBase { get; set; }
    }
}
