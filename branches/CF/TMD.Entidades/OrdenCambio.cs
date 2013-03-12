using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    public class OrdenCambio
    {
        public int Id { get; set; }
        public InformeCambio InformeCambio { get; set; }
        public Usuario UsuarioReg { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public int CodigoPrioridad { get; set; }
        public Usuario UsuarioAsignado { get; set; }
        public int Estado { get; set; }
        public Guid IdentificadorUnico { get; set; }
        public Byte[] Data { get; set; }
    }
}
