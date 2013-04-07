using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class Usuario : Base
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Alias { get; set; }
        public String Rol { get; set; }
        public String Login { get; set; }
    }
}
