using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class Empleado
    {
        public int CodigoEmpleado { get; set; }
        public String Descripcion { get; set; }
        public DateTime HoraIngreso { get; set; }
        public DateTime HoraSalida { get; set; }
        public Persona Persona { get; set; }
        public Area Area { get; set; }
        public PerfilRRHH Perfil { get; set; }
    }
}
