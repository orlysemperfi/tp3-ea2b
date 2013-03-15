using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
       public class Ticket
    {
        public int Codigo_Ticket { get; set; }
        public int Codigo_Cliente { get; set; }
        public int Codigo_Usuario { get; set; }
        public String Tipo_Atencion_Ticket { get; set; }
        public String Tipo_Registro_Ticket { get; set; }

        public String Nombre_UsuarioCliente { get; set; }

        public int Codigo_Propietario { get; set; }
        public int Codigo_Asignado { get; set; }
        public int Codigo_Ult_Modif { get; set; } 
            
        public String Empleado_Propietario { get; set; }
        public String Empleado_Asignado { get; set; }
        public String Empleado_Ult_Modif { get; set; } 

        public String Descripcion_Corta { get; set; }
        public String Descripcion_Larga { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public DateTime Fecha_Expiracion { get; set; }
           
        public String Estado_Ticket { get; set; }
        public int Codigo_Servicio { get; set; }
        public String Nombre_Servicio { get; set; }

        public int Tiempo_Resolucion { get; set; }
        public int Prioridad_Ticket { get; set; }
        public int Codigo_Proyecto { get; set; }
        public int Codigo_Equipo { get; set; }
        public int Codigo_Integrante { get; set; }
        public int Codigo_Sede { get; set; }
        public String Solucion_Ticket { get; set; }



    }

    
}
