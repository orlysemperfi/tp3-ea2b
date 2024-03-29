﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class Hallazgo
    {
        public int? IdHallazgo { get; set; }
        public string TipoHallazgo { get; set; }
        public string Descripcion { get; set; }
        public int? IdAuditoria { get; set; }
        public int? IdPreguntaVerificacion { get; set; }
        public string DescripcionPregunta { get; set; }
        public string Estado { get; set; }
        public int? nDoc { get; set; }
        public DateTime? FechaCompromiso { get; set; }
        public DateTime? FechaSeguimiento { get; set; }
        public String ComentarioSeguimiento { get; set; }
        public int? IdAuditorSeguimiento { get; set; }
        public string ResponsableSeguimiento { get; set; }

        public string Causa { get; set; }
        public string AccionCorrectiva { get; set; }
        public string AccionPreventiva { get; set; }
    }
}
