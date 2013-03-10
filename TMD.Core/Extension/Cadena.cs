using System;

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
