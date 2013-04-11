using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TMD.SD.LogicaNegocio_Atencion.Contrato;
using TMD.Entidades;
using TMD.SD.AccesoDatos_Atencion.Contrato;

namespace TMD.SD.LogicaNegocio_Atencion.Implementacion
{
    public class TicketLogica : ITicketLogica
    {

        private readonly ITicketData _ticketData;
        public TicketLogica(ITicketData ticketData)
        {
            _ticketData = ticketData;
        }

        public Int32 agregarTicket(Ticket ticket)
        {
            return _ticketData.agregarTicket(ticket);
        }

        public void agregarTicketCMDB(int numeroTicket, int codigoCMDB)
        {
            _ticketData.agregarTicketCMDB(numeroTicket, codigoCMDB);
        }

        public void modificarTicket(Ticket ticket)
        {
            _ticketData.modificarTicket(ticket);
        }
        /// <summary>
        /// Lista todos los analistas de un proyecto.
        /// </summary>
        /// <param name="codigoProyecto">Codigo del Proyecto</param>
        /// <returns>Lista Tickets</returns>
        public List<Ticket> listaTicketsIntegrante(int CodigoIntegrante,
                                                  string TipoTicket, String EstadoTicket, DateTime FechaRegIni, DateTime FechaRegFin)
        {
            return _ticketData.listaTicketsIntegrante( CodigoIntegrante,
                                                   TipoTicket, EstadoTicket, FechaRegIni, FechaRegFin);

        }

        public Ticket datosTicket(int numeroTicket)
        {
            return _ticketData.datosTicket(numeroTicket);
        }

        public TicketCMDB datosTicketCMDB(int numeroTicket)
        {
            return _ticketData.datosTicketCMDB(numeroTicket);
        }

        public void registrarSolucion(int numeroTicket, String solucion, int codigoEquipo, int codigoEspecialista)
        {
            _ticketData.registrarSolucion(numeroTicket, solucion, codigoEquipo, codigoEspecialista);
        }
        public void registrarSeguimiento(SeguimientoTicket seguimientoTicket)
        {
            _ticketData.registrarSeguimiento (seguimientoTicket);
        }

        public List<SeguimientoTicket> listaSeguimientos(int numeroTicket, String tipoSeguimiento)
        {
            return _ticketData.listaSeguimientos(numeroTicket,  tipoSeguimiento);
        }

        public void escalarTicketEspecialista(Ticket ticket)
        {
            _ticketData.escalarTicketEspecialista(ticket);
        }

        public void registrarDocumentoTicket(DocumentoTicket documentoTicket)
        {
            _ticketData.registrarDocumentoTicket(documentoTicket);
        }

        public void cambiarEstadoTicket(Ticket ticket)
        {
            _ticketData.cambiarEstadoTicket(ticket);
        }

        public List<DocumentoTicket> listaDocumentosTickets(int numeroTicket)
        {
            return _ticketData.listaDocumentosTickets(numeroTicket);
        }

        public int EsPosibleRegistrarSolucion(int numeroTicket)
        {
            Ticket ticket = datosTicket(numeroTicket);
            int resultado=-1;

            if (ticket.Estado_Ticket == "SOLUCIONADO") return 1;
            if (ticket.Estado_Ticket != "EN PROCESO") return 2; 
            if (ticket.Estado_Ticket =="EN PROCESO") return 0;

            return resultado;
        }





    }
}
