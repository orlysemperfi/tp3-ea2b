using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class EquipoRutinas
    {
        public int LineaEquipoRutina { get; set; }
        public DateTime FechaUltimaOrdenTrabajo { get; set; }
        public int EstadoUltimaOrdenTrabajo { get; set; }
        public Rutina Rutina { get; set; }
        public EquipoComputo Equipo { get; set; }
    }
}
