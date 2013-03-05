using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class LineaBaseElementoConfiguracion
    {
        public int Id { get; set; }
        public ElementoConfiguracion ElementoConfiguracion { get; set; }
        public LineaBase LineaBase { get; set; }
        public Usuario Responsable { get; set; }
        public Version Version { get; set; }
        public Guid IdentificadorUnico { get; set; }
        public String Nombre { get; set; }
        public String Extension { get; set; }
        public Byte[] Data { get; set; }
    }
}
