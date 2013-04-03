using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class Actividad
    {
        private Auditoria objAuditoria = new Auditoria();
        public Auditoria ObjAuditoria
        {
            get { return objAuditoria; }
            set { objAuditoria = value; }
        }
        public int IdActividad { get; set; }
        public string DescripcionActividad { get; set; }
        public int IdAuditor { get; set; }
        public string Lugar { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }        
    }
}
