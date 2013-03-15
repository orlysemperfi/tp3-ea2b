using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class Fase : Base
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }

        public LineaBase LineaBase { get; set; }
    }
}
