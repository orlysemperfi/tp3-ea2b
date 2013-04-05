using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class Archivo
    {
        public int idArchivo { get; set; }

        public byte[] dataBinaria { get; set; }

        public string nombreArchivo { get; set; }

        public string mimeType { get; set; }

        public System.DateTime fechaCarga { get; set; }

        public int? idOrigen { get; set; }

        public string tipoOrigen { get; set; }
    }
}
