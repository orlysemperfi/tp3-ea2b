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
        /// /// <param name="codigoIntegrante">Codigo del Integrante</param>
        /// /// <param name="tipoTicket">Codigo del Integrante</param>
        /// /// <param name="estadoTicket">Codigo del Integrante</param>
        /// /// <param name="fechaRegIni">Codigo del Integrante</param>
        /// /// <param name="fechaRegFin">Codigo del Integrante</param>
        /// 
        /// <returns>Lista Integrante</returns>
        List<Ticket> listaTicketsIntegrante(int codigoIntegrante,
                                                  string tipoTicket, String estadoTicket, DateTime fechaRegIni, DateTime fechaRegFin);
        Ticket datosTicket(int numeroTicket);
        TicketCMDB datosTicketCMDB(int numeroTicket);
        void registrarSolucion(int numeroTicket, String solucion, int codigoEquipo, int codigoEspecialista);
        void registrarSeguimiento(SeguimientoTicket seguimientoTicket);
        List<SeguimientoTicket> listaSeguimientos(int numeroTicket,String tipoSeguimiento);
        List<DocumentoTicket> listaDocumentosTickets(int numeroTicket);
        void escalarTicketEspecialista(Ticket ticket);
        void registrarDocumentoTicket(DocumentoTicket documentoTicket);
        void cambiarEstadoTicket(Ticket ticket);
    }
}
