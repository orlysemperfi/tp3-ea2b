using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Entidades
{
    /// <summary>
    /// Clase que representa la entidad Orden de cambio (sobre informes generados)
    /// </summary>
    public class OrdenCambio
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public InformeCambio InformeCambio { get; set; }
        public Usuario UsuarioReg { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Prioridad { get; set; }
        public Usuario UsuarioAsignado { get; set; }
        public Guid IdentificadorUnico { get; set; }
        public String NombreArchivo { get; set; }
        public String Extension { get; set; }
        public Byte[] Data { get; set; }
    }
}
