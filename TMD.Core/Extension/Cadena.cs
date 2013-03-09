using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Core.Extension
{
    public static class Cadena
    {
        public static int ToInt(this string valor)
        {
            int numero = 0;
            Int32.TryParse(valor, out numero);
            return numero;
        }
    }
}
