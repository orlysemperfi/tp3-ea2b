using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class DocumentoTicket
    {
        public int Codigo_Ticket { get; set; }
        public int Codigo_DocumentoTicket { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public String Descripcion_DocumentoTicket { get; set; }
        public String Nombre_DocumentoTicket { get; set; }
        public String Ruta_DocumentoTicket { get; set; }
        public int Codigo_Equipo { get; set; }
        public int Codigo_Integrante { get; set; }

    }
}
