using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMD.GM.Site.Models
{
    public class ErrorModel
    {
        public string Boton { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }

        public bool btnSi_Visible { get; set; }
        public bool btnNo_Visible { get; set; }
        public bool btnAceptar_Visible { get; set; }

        public bool btnImpedTurno_Visible { get; set; }
        public bool btnImpedConcluir_Visible { get; set; }
        public string btnImpedConcluir_Text { get; set; }
        public bool btnImpedCancelar_Visible { get; set; }
        public string btnImpedCancelar_Text { get; set; }

        public bool btnContinuar_Visible { get; set; }
        public bool btnCancelar_Visible { get; set; }

        public bool btnAceptarNoHorario_Visible { get; set; }

        public bool btnAceptarAlert_Visible { get; set; }

        public bool btnAceptarTerminoGrabar_Visible { get; set; }

        public bool btnAceptarCursoHabil_Visible { get; set; }
        public bool btnContinuarCursoHabil_Visible { get; set; }
        public bool btnCancelarCursoHabil_Visible { get; set; }
    }
}