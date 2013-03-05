using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class ElementoConfiguracion
    {
        public int Id { get; set; }
        public Fase Fase { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public TipoElementoConfiguracion Tipo { get; set; }
        public Boolean Seleccionado { get; set; }
    }
}
