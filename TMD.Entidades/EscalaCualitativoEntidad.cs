﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class EscalaCualitativoEntidad
    {
        public int? codigo { get; set; }
        public int? codigo_Indicador { get; set; }
        public String limite_inferior { get; set; }
        public String limite_superior { get; set; }
        public String calificacion   { get; set; }
        public int action { get; set; }
        public int principal { get; set; }
    }
}
