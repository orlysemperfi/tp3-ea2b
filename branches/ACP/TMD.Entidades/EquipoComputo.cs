using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class EquipoComputo
    {
        public int CodigoEquipoComputo { get; set; }
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Serie { get; set; }
        public TipoEquipo TipoEquipo { get; set; }
        public Area Area { get; set; }
        public Empleado Empleado { get; set; }
    }
}
