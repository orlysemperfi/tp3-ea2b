using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.SD.AccesoDatos_Atencion.Contrato
{
    /// <summary>
    /// Contrato  del Acceso a datos de la entidad Integrante.
    /// </summary>
    public interface ITicketData
    {
        Int32 agregarTicket(Ticket ticket);
        void modificarTicket(Ticket ticket);
        void agregarTicketCMDB(int numeroTicket, int codigoCMDB);
        /// <summary>
        /// Lista los ticket de un integrante
        /// </summary>
        /// /// <param name="CodigoProyecto">Codigo del Proyecto</param>
        /// <returns>Lista Integrante</returns>
        List<Ticket> listaTicketsIntegrante(int CodigoIntegrante,
                                                  string TipoTicket, String EstadoTicket, DateTime FechaRegIni, DateTime FechaRegFin);
        Ticket datosTicket(int numeroTicket);
        TicketCMDB datosTicketCMDB(int numeroTicket);
        void registrarSolucion(int numeroTicket, String solucion, int codigoEquipo, int codigoEspecialista);
        void registrarSeguimiento(SeguimientoTicket seguimientoTicket);
        List<SeguimientoTicket> listaSeguimientos(int numeroTicket);
    }
}
