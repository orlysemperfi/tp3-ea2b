using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
 

    public class ProyectoServicioSede
    {
        public int Codigo_Proyecto { get; set; }
        public String Nombre_Proyecto { get; set; }
        public int Codigo_Sede { get; set; }
        public String Nombre_Sede { get; set; }

        public int Codigo_Servicio { get; set; }
        public String Nombre_Servicio { get; set; }
        public String Descripcion_Servicio { get; set; }
       
        public int Codigo_SLA { get; set; }
        public String Nombre_SLA { get; set; }

        public int Codigo_Detalle_SLA { get; set; }
        public int Urgencia { get; set; }
        public int Impacto { get; set; }
        public int Prioridad { get; set; }
        public int Complejidad { get; set; }
        public int Tiempo_Respuesta { get; set; }
        public int Tiempo_Cierre { get; set; }
        

    }

}
