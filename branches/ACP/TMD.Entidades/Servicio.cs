using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    
    public class Servicio
    {
        public int Codigo_Servicio { get; set; }
        public String Nombre_Servicio { get; set; }
        public String Descripcion_Servicio { get; set; }

        public int Codigo_SLA { get; set; }
        public int Codigo_DetalleSLA { get; set; }
        
      
    }
}
