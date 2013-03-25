using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    /// <summary>
    /// Clase que representa la entidad usuario asignado a un proyecto
    /// </summary>
    public class UsuarioProyecto : Base
    {
        public int Id { get; set; }
        public String Acceso { get; set; }
    }
}