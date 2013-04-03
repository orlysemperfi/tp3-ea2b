using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class DetallePreguntaBase
    {
        public int IdNorma { get; set; }
        public string DescripcionNorma { get; set; }
        public int IdCapitulo { get; set; }
        public string DescripcionCapitulo { get; set; }
        public int IdPreguntaBase { get; set; }
        public string DescripcionPregunta { get; set; }
    }
}
