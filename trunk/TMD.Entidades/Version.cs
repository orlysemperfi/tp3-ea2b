using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class Version
    {
        public String Prefijo { get; set; }
        public int Mayor { get; set; }
        public int Menor { get; set; }

        public override string ToString()
        {
            return String.Format("V.{0}.{1}",Mayor,Menor);
        }
    }
}
