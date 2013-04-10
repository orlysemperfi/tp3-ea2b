using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TMD.DBO.LogicaNegocio_Atencion.Contrato;
using TMD.Entidades;
using TMD.DBO.AccesoDatos_Atencion.Contrato;

namespace TMD.DBO.LogicaNegocio_Atencion.Contrato
{
    public interface ITicketLogica
    {
        Int32 agregarTicket(Ticket ticket);
        void modificarTicket(Ticket ticket);
        void agregarTicketCMDB(int numeroTicket, int codigoCMDB);
        /// <summary>
        /// Lista todos los tickets de un integrante.
        /// </summary>
        /// <param name="codigoProyecto">Codigo del Proyecto</param>
        /// <returns>Lista Analista</returns>
        /// 
        List<Ticket> listaTicketsIntegrante( int CodigoIntegrante,
                                                  string TipoTicket, String EstadoTicket, DateTime FechaRegIni, DateTime FechaRegFin);

        Ticket datosTicket(int numeroTicket);
        TicketCMDB datosTicketCMDB(int numeroTicket);
        void registrarSolucion(int numeroTicket, String solucion, int codigoEquipo, int codigoEspecialista);
        void registrarSeguimiento(SeguimientoTicket seguimientoTicket);
        List<SeguimientoTicket> listaSeguimientos(int numeroTicket,String TipoSeguimiento);
        void escalarTicketEspecialista(Ticket ticket);
        void registrarDocumentoTicket(DocumentoTicket documentoTicket);
        void cambiarEstadoTicket(Ticket ticket);
        List<DocumentoTicket> listaDocumentosTickets(int numeroTicket);

        // Reglas de negocio
        Boolean EsPosibleRegistrarSolucion(int numeroTicket);

    }
}
