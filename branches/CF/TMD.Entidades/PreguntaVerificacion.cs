using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class PreguntaVerificacion
    {
        private Auditoria objAuditoria = new Auditoria();

        public Auditoria ObjAuditoria
        {
            get { return objAuditoria; }
            set { objAuditoria = value; }
        }
        public int idPreguntaVerificacion { get; set; }
        public string DescripcionPregunta { get; set; }
        public bool? Respuesta { get; set; }
        public string Sustento { get; set; }
        public decimal? Porcentaje { get; set; }
        public int CantidadPlanif { get; set; }

    }
}
