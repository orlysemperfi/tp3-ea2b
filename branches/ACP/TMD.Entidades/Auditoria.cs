using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class Auditoria
    {
        public int? IdAuditoria { get; set; }
        public int AnhoAuditoria { get; set; }
        private EntidadAuditada objEntidadAuditada = new EntidadAuditada();
        public EntidadAuditada ObjEntidadAuditada
        {
            get { return objEntidadAuditada; }
            set { objEntidadAuditada = value; }
        }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
        public string Alcance { get; set; }
        public string Objetivo { get; set; }
        public bool? IndCheckListEstablecido { get; set; }
        public int idPrograma { get; set; }
        public string nombreArchivoL { get; set; }
        public string nombreArchivoF { get; set; }
        public int duracion { get; set; }
        public string resultado { get; set; }
        public string conclusion { get; set; }
        public string recomendacion { get; set; }
    }

}
