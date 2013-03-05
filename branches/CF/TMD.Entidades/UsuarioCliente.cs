using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class UsuarioCliente
    {

        public int Codigo_Usuario { get; set; }
        public String Alias_Usuario { get; set; }
        public String Nombre_Usuario { get; set; }
        public int Codigo_Cliente { get; set; }
        public String Nombre_Cliente { get; set; }
        public int Codigo_Sede { get; set; }
        public String Nombre_Sede { get; set; }


    }
}
