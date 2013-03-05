using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class EntidadAuditada
    {
        public int IdEntidadAuditada { get; set; }
        public string NombreEntidadAuditada { get; set; }
        public string Responsable { get; set; }

        private AreaEntidad objArea = new AreaEntidad();
        public AreaEntidad ObjArea
        {
            get { return objArea; }
            set { objArea = value; }
        }
    }
}
