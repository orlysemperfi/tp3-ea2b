using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{   
    /// <summary>
    /// Clase que representa la entidad Fase que se asigna a la linea base
    /// </summary>

    public class Fase : Base
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public List<ElementoConfiguracion> ElementosConfiguracion { get; set; }
        public LineaBase LineaBase { get; set; }
    }
}
