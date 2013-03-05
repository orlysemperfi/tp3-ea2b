using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class Proyecto : Base
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Usuario JefeProyecto { get; set; }
        public Cliente Cliente { get; set; }
        public String Estado { get; set; }
        public List<ProyectoFase> Fases { get; set; }

        //Atributos de Service Desk - Falta Integrar con el grupo dueño de esta entidad.
        public int Codigo_Proyecto { get; set; }
        public String Nombre_Proyecto { get; set; }
        public int Codigo_Cliente { get; set; }
        public String Nombre_Cliente { get; set; }
        public int Codigo_Sede { get; set; }
        public String Nombre_Sede { get; set; }
        public int Codigo_Equipo { get; set; }
        public String Nombre_Equipo { get; set; }
    }
}
