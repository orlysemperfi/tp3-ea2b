using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class Informe
    {
        public int CodigoInforme{ get; set; }
        public TipoInforme TipoInforme { get; set; }
        public DetalleOrden DetalleOrden { get; set; }
        public String DetalleProblema { get; set; }
        public String DetalleAcciones { get; set; }
        public int CalificacionUsuario { get; set; }
        public String ComentarioUsuario { get; set; }
    }
}
