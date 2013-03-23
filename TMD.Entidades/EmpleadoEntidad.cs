using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class EmpleadoEntidad
    {
        public int? codigo { get; set; }
        public String nombre { get; set; }
        public String apellidopaterno { get; set; }
        public String apellidomaterno { get; set; }
        private AreaEntidad objArea = new AreaEntidad();
        public AreaEntidad ObjArea
        {
            get { return objArea; }
            set { objArea = value; }
        }
    }
}
