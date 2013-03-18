using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TMD.SD.LogicaNegocio_Atencion.Contrato;
using TMD.Entidades;
using TMD.SD.AccesoDatos_Atencion.Contrato;

namespace TMD.SD.LogicaNegocio_Atencion.Contrato
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
        List<SeguimientoTicket> listaSeguimientos(int numeroTicket);

        //void registrarDocumentoTicket(DocumentoTicket documentoTicket);
        
    }
}
