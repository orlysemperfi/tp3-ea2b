using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace TMD.GM.Util
{
    public static class ConstantesUT
    {
        [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
        public struct ESTADO_SOLICITUD
        {
            public const int Aperturado = 1;
        }

        [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
        public struct ESTADO_GENERICO
        {
            public const int Activo = 1;
            public const int Inactivo = 0;
        }

        [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
        public struct MENSAJES_ERROR
        {
            public const string NoExiste = "No existe el registro";
            public const string YaExisteCodigo = "Código ya existente";
            public const string YaExisteNombre = "Nombre ya existente";
        }
    }
}
