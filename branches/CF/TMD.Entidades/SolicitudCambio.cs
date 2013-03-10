using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class SolicitudCambio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ProyectoFase ProyectoFase { get; set; }
        public LineaBase LineaBase { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public LineaBaseElementoConfiguracion ElementoConfiguracion { get; set; }
        public int Estado { get; set; }
        public int Prioridad { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public Guid IdentificadorUnico { get; set; }
        public Byte[] Data { get; set; }
        public String NombreArchivo { get; set; }
    }
}
