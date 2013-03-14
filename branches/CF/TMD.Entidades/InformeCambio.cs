using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class InformeCambio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public SolicitudCambio Solicitud { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public string EstimacionCosto { get; set; }
        public string EstimacionEsfuerzo { get; set; }
        public string Recursos { get; set; }
        public int Estado { get; set; }
        public string Motivo { get; set; }
        public Guid IdentificadorUnico { get; set; }
        public Byte[] Data { get; set; }
        public String NombreArchivo { get; set; }
        public String Extension { get; set; }
        public int IdSolicitud { get; set; }
        public String NombreSolicitud { get; set; }
    }
}
