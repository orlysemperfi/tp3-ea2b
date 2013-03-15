using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using TMD.SD.AccesoDatos_Atencion.Contrato;
using TMD.SD.AccesoDatos_Atencion.Core;
using TMD.SD.AccesoDatos_Atencion.Map;
using TMD.Entidades;


namespace TMD.SD.AccesoDatos_Atencion.Implementacion
{
    //usp_Ticket_AgregarTicket
    
    /// <summary>
    ///  Implementa el Acceso a datos a Integrantes.
    /// </summary>
    public class TicketData: DataBase, ITicketData
    {
            public TicketData(String connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Agregar Ticket.
        /// </summary>
        /// <param name="id">Codigo del proyecto</param>
        /// <returns>Fase</returns>
            public Int32 agregarTicket(Ticket ticket)
            {
                Int32 numeroTicket = 0;

                using (DbCommand command = DB.GetStoredProcCommand("SD.usp_Ticket_AgregarTicket"))
                {
                    DB.AddInParameter(command, "@Fecha_Registro", DbType.DateTime, ticket.Fecha_Registro);
                    DB.AddInParameter(command, "@Tipo_Registro", DbType.String, ticket.Tipo_Registro_Ticket);
                    DB.AddInParameter(command, "@Tipo_Atencion", DbType.String, ticket.Tipo_Atencion_Ticket );
                    DB.AddInParameter(command, "@Fecha_Expiracion", DbType.DateTime, ticket.Fecha_Expiracion);
                    DB.AddInParameter(command, "@Descripcion_Corta", DbType.String, ticket.Descripcion_Corta );
                    DB.AddInParameter(command, "@Descripcion_Larga", DbType.String, ticket.Descripcion_Larga);
                    DB.AddInParameter(command, "@Tiempo_Resolucion", DbType.Int32, ticket.Tiempo_Resolucion );
                    DB.AddInParameter(command, "@Prioridad", DbType.Int32, ticket.Prioridad_Ticket  );
                    DB.AddInParameter(command, "@Cliente", DbType.Int32, ticket.Codigo_Cliente );
                    DB.AddInParameter(command, "@Usuario", DbType.Int32, ticket.Codigo_Usuario );
                    DB.AddInParameter(command, "@Servicio", DbType.Int32, ticket.Codigo_Servicio );
                    DB.AddInParameter(command, "@Proyecto", DbType.Int32, ticket.Codigo_Proyecto );
                    DB.AddInParameter(command, "@Equipo", DbType.Int32, ticket.Codigo_Equipo );
                    DB.AddInParameter(command, "@Integrante", DbType.Int32, ticket.Codigo_Propietario );
                    DB.AddOutParameter(command, "@CODIGOTICKET", DbType.Int32,0);

                    
                    DbParameter returnValue;
                    returnValue = command.CreateParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(returnValue);
                    
                    DB.ExecuteNonQuery(command);

                    numeroTicket = (Int32)DB.GetParameterValue(command, "@CODIGOTICKET"); 

                    int resultado = Convert.ToInt32(returnValue.Value); 



                   
                }

                return numeroTicket;


            }

            public void modificarTicket(Ticket ticket)
            {
               

                using (DbCommand command = DB.GetStoredProcCommand("SD.usp_Ticket_ModificarTicket"))
                {
                    DB.AddInParameter(command, "@Ticket", DbType.String, ticket.Codigo_Ticket);
                    DB.AddInParameter(command, "@Tipo_Registro", DbType.String, ticket.Tipo_Registro_Ticket);
                    DB.AddInParameter(command, "@Tipo_Atencion", DbType.String, ticket.Tipo_Atencion_Ticket);
                    DB.AddInParameter(command, "@Fecha_Expiracion", DbType.DateTime, ticket.Fecha_Expiracion);
                    DB.AddInParameter(command, "@Descripcion_Corta", DbType.String, ticket.Descripcion_Corta);
                    DB.AddInParameter(command, "@Descripcion_Larga", DbType.String, ticket.Descripcion_Larga);
                    DB.AddInParameter(command, "@Tiempo_Resolucion", DbType.Int32, ticket.Tiempo_Resolucion);
                    DB.AddInParameter(command, "@Prioridad", DbType.Int32, ticket.Prioridad_Ticket);
                    DB.AddInParameter(command, "@Cliente", DbType.Int32, ticket.Codigo_Cliente);
                    DB.AddInParameter(command, "@Usuario", DbType.Int32, ticket.Codigo_Usuario);
                    DB.AddInParameter(command, "@Servicio", DbType.Int32, ticket.Codigo_Servicio);
                    DB.AddInParameter(command, "@Proyecto", DbType.Int32, ticket.Codigo_Proyecto);
                    DB.AddInParameter(command, "@Equipo_Espe", DbType.Int32, ticket.Codigo_Equipo);
                    DB.AddInParameter(command, "@ESPECIALISTA", DbType.Int32, ticket.Codigo_Asignado);
                    DB.AddInParameter(command, "@Equipo_ACTUA", DbType.Int32, ticket.Codigo_Equipo);
                    DB.AddInParameter(command, "@Actualizador", DbType.Int32, ticket.Codigo_Ult_Modif);
             
                    DbParameter returnValue;
                    returnValue = command.CreateParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(returnValue);

                    DB.ExecuteNonQuery(command);
                                 
                    int resultado = Convert.ToInt32(returnValue.Value);

                }

             


            }



            public Ticket datosTicket(int numeroTicket)
            {
                Ticket _datosTicket = new Ticket();
                using (DbCommand command = DB.GetStoredProcCommand("SD.usp_Ticket_DatosTicket"))
                {
                    DB.AddInParameter(command, "@Ticket", DbType.Int32, numeroTicket);

                    using (IDataReader reader = DB.ExecuteReader(command))
                    {
                        if (reader.Read())
                        {
                           _datosTicket = TicketDataMap.Select(reader);
                        }
                    }            
                }
                return _datosTicket;

            }

        public TicketCMDB datosTicketCMDB(int numeroTicket)
            {
                TicketCMDB _datosCMDB = new TicketCMDB();
                using (DbCommand command = DB.GetStoredProcCommand("SD.usp_Ticket_ListaCMDB"))
                {
                    DB.AddInParameter(command, "@Ticket", DbType.Int32, numeroTicket);
        
                    using (IDataReader reader = DB.ExecuteReader(command))
                    {
                        if (reader.Read())
                        {
                            _datosCMDB = TicketCMDBDataMap.Select(reader);
                        }
                    }            
                }
                return _datosCMDB;

            }
        /// <summary>
        /// Obtiene una lista de analistas.
        /// </summary>
        /// <param name="id">Codigo del proyecto</param>
        /// <returns>Fase</returns>
        public List<Ticket> listaTicketsIntegrante(int CodigoIntegrante,
                                                  string TipoTicket, String EstadoTicket, DateTime  FechaRegIni,DateTime FechaRegFin)
        {
            List<Ticket> listaTickets = new List<Ticket>();
            //try
            //{
            using (DbCommand command = DB.GetStoredProcCommand("SD.usp_Ticket_ListaTicketsIntegrante"))
                {
                    DB.AddInParameter(command, "@Integrante", DbType.Int32, CodigoIntegrante);
                    DB.AddInParameter(command, "@Tipo_Ticket", DbType.String, TipoTicket);
                    DB.AddInParameter(command, "@Estado", DbType.String, EstadoTicket );
                    DB.AddInParameter(command, "@Fecha_RegIni", DbType.DateTime , null); //String.Format("{0:yyyyMMdd}", FechaRegIni));
                    DB.AddInParameter(command, "@Fecha_RegFin", DbType.DateTime, null); //String.Format("{0:yyyyMMdd}", FechaRegFin));

                    using (IDataReader reader = DB.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            listaTickets.Add(TicketDataMap.Select(reader));
                        }
                    }
                }

            //}
            //catch
            //{

            //}
            return listaTickets;

        }

        
        
        public void agregarTicketCMDB(int numeroTicket, int codigoCMDB)
            {
                using (DbCommand command = DB.GetStoredProcCommand("SD.usp_Ticket_AgregarCMDB"))
                {
                    DB.AddInParameter(command, "@Ticket", DbType.Int32, numeroTicket);
                    DB.AddInParameter(command, "@CMDB", DbType.Int32, codigoCMDB);

                    DB.ExecuteNonQuery(command);      
                }
            
            }

        public void registrarSolucion(int numeroTicket, String solucion, int codigoEquipo, int codigoEspecialista)
        {
            using (DbCommand command = DB.GetStoredProcCommand("SD.usp_Ticket_RegistrarSolucion"))
            {
                DB.AddInParameter(command, "@Ticket", DbType.Int32, numeroTicket);
                DB.AddInParameter(command, "@Solucion", DbType.String, solucion);
                DB.AddInParameter(command, "@Equipo", DbType.Int32,codigoEquipo);
                DB.AddInParameter(command, "@Integrante", DbType.Int32, codigoEspecialista);

                DB.ExecuteNonQuery(command);
            }

        }


        public void registrarSeguimiento(SeguimientoTicket seguimientoTicket)
        {
            string sSQL;

            sSQL = "Insert into SD.INFORMACION_SEGUIMIENTO (CODIGO_TICKET,CODIGO_SEGUIMIENTO,FECHA_REGISTRO_INFORMACION_SEGUIMIENTO," +
                   "DESCRIPCION_INFORMACION_SEGUIMIENTO,CODIGO_EQUIPO,CODIGO_INTEGRANTE) Values ( @CODIGO_TICKET,@CODIGO_SEGUIMIENTO,@FECHA_REGISTRO_INFORMACION_SEGUIMIENTO," +
                   "@DESCRIPCION_INFORMACION_SEGUIMIENTO,@CODIGO_EQUIPO,@CODIGO_INTEGRANTE )";
            using (DbCommand command = DB.GetSqlStringCommand (sSQL))
            {
                DB.AddInParameter(command, "@CODIGO_TICKET", DbType.Int32, seguimientoTicket.Codigo_Ticket );
                DB.AddInParameter(command, "@CODIGO_SEGUIMIENTO", DbType.Int32, seguimientoTicket.Codigo_Seguimiento );
                DB.AddInParameter(command, "@FECHA_REGISTRO_INFORMACION_SEGUIMIENTO", DbType.DateTime, DateTime.Now);
                DB.AddInParameter(command, "@DESCRIPCION_INFORMACION_SEGUIMIENTO", DbType.String, seguimientoTicket.Descripcion_Seguimiento);
                DB.AddInParameter(command, "@CODIGO_EQUIPO", DbType.Int32, seguimientoTicket.Codigo_Equipo);
                DB.AddInParameter(command, "@CODIGO_INTEGRANTE", DbType.Int32, seguimientoTicket.Codigo_Integrante);

                DB.ExecuteNonQuery(command);
            }

        }

        public List<SeguimientoTicket> listaSeguimientos(int numeroTicket)
        {
            List<SeguimientoTicket> listaSeguimientos = new List<SeguimientoTicket>();
            string sSQL;

            try
            {


            sSQL = "Select CODIGO_TICKET,CODIGO_SEGUIMIENTO,FECHA_REGISTRO_INFORMACION_SEGUIMIENTO," +
                   "DESCRIPCION_INFORMACION_SEGUIMIENTO,CODIGO_EQUIPO,CODIGO_INTEGRANTE From SD.INFORMACION_SEGUIMIENTO " +
                   "Where CODIGO_TICKET=" + numeroTicket;

            using (DbCommand command = DB.GetSqlStringCommand(sSQL))
            {
               
                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        listaSeguimientos.Add(TicketSeguimientoDataMap.Select(reader));

                    }
                }
            }

            }
            catch
            {

            }
            return listaSeguimientos;

        }

    }
}
