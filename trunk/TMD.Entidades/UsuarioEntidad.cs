using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class UsuarioEntidad
    {
        public int? codigo_Persona { get; set; }
        public String codigo_Usuario { get; set; }
        public String contrasenia { get; set; }
        public String estado { get; set; }
        public int? codigo_Perfil_Usuario { get; set; }
        public String nombre_completo { get; set; }

    }
}
