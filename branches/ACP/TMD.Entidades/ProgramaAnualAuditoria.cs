using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class ProgramaAnualAuditoria
    {
        public int IdProgramaAnual { get; set; }

        public int AnhoPrograma { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? IdUsuarioCreacion { get; set; }

        public string UsuarioCreacion { get; set; }

        public DateTime FechaAprobacion { get; set; }

        public string UsuarioAprobacion { get; set; }

        public int? IdUsuarioAprobacion { get; set; }

        public string Estado { get; set; }

        private List<Auditoria> objAuditorias = new List<Auditoria>();
        public List<Auditoria> ObjAuditorias
        {
            get { return objAuditorias; }
            set { objAuditorias = value; }
        }
    }
}
