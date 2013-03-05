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
        //Agregado por Service Desk
        public String Alias { get; set; }
    }
}
