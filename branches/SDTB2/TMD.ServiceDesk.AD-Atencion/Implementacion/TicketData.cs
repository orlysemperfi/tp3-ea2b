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

                using (DbCommand command = DB.GetStoredProcCommand("DBO.usp_Ticket_AgregarTicket"))
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
               

                using (DbCommand command = DB.GetStoredProcCommand("DBO.usp_Ticket_ModificarTicket"))
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
                using (DbCommand command = DB.GetStoredProcCommand("DBO.usp_Ticket_DatosTicket"))
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
                using (DbCommand command = DB.GetStoredProcCommand("DBO.usp_Ticket_ListaCMDB"))
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
        public List<Ticket> listaTicketsIntegrante(int codigoIntegrante,
                                                  string tipoTicket, String estadoTicket, DateTime  fechaRegIni,DateTime fechaRegFin)
        {
            List<Ticket> listaTickets = new List<Ticket>();
            //try
            //{
            using (DbCommand command = DB.GetStoredProcCommand("DBO.usp_Ticket_ListaTicketsIntegrante"))
                {
                    DB.AddInParameter(command, "@Integrante", DbType.Int32, codigoIntegrante);
                    DB.AddInParameter(command, "@Tipo_Ticket", DbType.String, tipoTicket);
                    DB.AddInParameter(command, "@Estado", DbType.String, estadoTicket );
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
                using (DbCommand command = DB.GetStoredProcCommand("DBO.usp_Ticket_AgregarCMDB"))
                {
                    DB.AddInParameter(command, "@Ticket", DbType.Int32, numeroTicket);
                    DB.AddInParameter(command, "@CMDB", DbType.Int32, codigoCMDB);

                    DB.ExecuteNonQuery(command);      
                }
            
            }

        public void registrarSolucion(int numeroTicket, String solucion, int codigoEquipo, int codigoEspecialista)
        {
            using (DbCommand command = DB.GetStoredProcCommand("DBO.usp_Ticket_RegistrarSolucion"))
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

            sSQL = "Insert into DBO.INFORMACION_SEGUIMIENTO (CODIGO_TICKET,CODIGO_SEGUIMIENTO,FECHA_REGISTRO_INFORMACION_SEGUIMIENTO," +
                   "DESCRIPCION_INFORMACION_SEGUIMIENTO,CODIGO_EQUIPO,CODIGO_INTEGRANTE,TIPO_SEGUIMIENTO) Values ( @CODIGO_TICKET,@CODIGO_SEGUIMIENTO,@FECHA_REGISTRO_INFORMACION_SEGUIMIENTO," +
                   "@DESCRIPCION_INFORMACION_SEGUIMIENTO,@CODIGO_EQUIPO,@CODIGO_INTEGRANTE,@TIPO_SEGUIMIENTO )";
            using (DbCommand command = DB.GetSqlStringCommand (sSQL))
            {
                DB.AddInParameter(command, "@CODIGO_TICKET", DbType.Int32, seguimientoTicket.Codigo_Ticket );
                DB.AddInParameter(command, "@CODIGO_SEGUIMIENTO", DbType.Int32, seguimientoTicket.Codigo_Seguimiento );
                DB.AddInParameter(command, "@FECHA_REGISTRO_INFORMACION_SEGUIMIENTO", DbType.DateTime, DateTime.Now);
                DB.AddInParameter(command, "@TIPO_SEGUIMIENTO", DbType.String, seguimientoTicket.Tipo_Seguimiento);
                DB.AddInParameter(command, "@DESCRIPCION_INFORMACION_SEGUIMIENTO", DbType.String, seguimientoTicket.Descripcion_Seguimiento);
                DB.AddInParameter(command, "@CODIGO_EQUIPO", DbType.Int32, seguimientoTicket.Codigo_Equipo);
                DB.AddInParameter(command, "@CODIGO_INTEGRANTE", DbType.Int32, seguimientoTicket.Codigo_Integrante);

                DB.ExecuteNonQuery(command);
            }

        }

        public List<SeguimientoTicket> listaSeguimientos(int numeroTicket, String tipoSeguimiento)
        {
            List<SeguimientoTicket> listaSeguimientos = new List<SeguimientoTicket>();
            string sSQL;

            try
            {


            sSQL = "Select S.CODIGO_TICKET,S.CODIGO_SEGUIMIENTO,S.FECHA_REGISTRO_INFORMACION_SEGUIMIENTO, " + 
                   "S.DESCRIPCION_INFORMACION_SEGUIMIENTO,S.CODIGO_EQUIPO,S.CODIGO_INTEGRANTE, " +
                   "S.TIPO_SEGUIMIENTO,O.NOMBRE_PERSONA + ' ' + O.APELLIDO_PATERNO + ' ' + O.APELLIDO_MATERNO AS Nombre_Integrante " +
                   "from  DBO.INFORMACION_SEGUIMIENTO S " + 
                   "Left Join DBO.INTEGRANTE I On I.CODIGO_EQUIPO = S.CODIGO_EQUIPO And I.CODIGO_INTEGRANTE = S.CODIGO_INTEGRANTE "+
                   "Left Join DBO.EMPLEADO E On E.CODIGO_EMPLEADO = I.CODIGO_EMPLEADO "+
                   "Left Join DBO.PERSONA O ON O.CODIGO_PERSONA= E.CODIGO_EMPLEADO " + 
                   "Where CODIGO_TICKET=" + numeroTicket;

            if (tipoSeguimiento != "TODOS") sSQL = sSQL + "  And S.TIPO_SEGUIMIENTO='" + tipoSeguimiento + "'";

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

        public void registrarDocumentoTicket(DocumentoTicket documentoTicket)
        {
            string sSQL;

            sSQL = "Insert into DBO.INFORMACION_ADICIONAL (CODIGO_TICKET,CODIGO_INFORMACION_ADICIONAL,FECHA_REGISTRO_INFORMACION_ADICIONAL," +
                   "DESCRIPCION_INFORMACION_ADICIONAL,NOMBRE_ARCHIVO_INFORMACION_ADICIONAL,RUTA_INFORMACION_ADICIONAL,CODIGO_EQUIPO,CODIGO_INTEGRANTE) Values ( @CODIGO_TICKET,@CODIGO_INFORMACION_ADICIONAL,@FECHA_REGISTRO_INFORMACION_ADICIONAL," +
                   "@DESCRIPCION_INFORMACION_ADICIONAL,@NOMBRE_ARCHIVO_INFORMACION_ADICIONAL,@RUTA_INFORMACION_ADICIONAL,@CODIGO_EQUIPO,@CODIGO_INTEGRANTE )";
            using (DbCommand command = DB.GetSqlStringCommand(sSQL))
            {
                DB.AddInParameter(command, "@CODIGO_TICKET", DbType.Int32, documentoTicket.Codigo_Ticket);
                DB.AddInParameter(command, "@CODIGO_INFORMACION_ADICIONAL", DbType.Int32, documentoTicket.Codigo_DocumentoTicket);
                DB.AddInParameter(command, "@FECHA_REGISTRO_INFORMACION_ADICIONAL", DbType.DateTime, DateTime.Now);
                DB.AddInParameter(command, "@DESCRIPCION_INFORMACION_ADICIONAL", DbType.String, documentoTicket.Descripcion_DocumentoTicket);
                DB.AddInParameter(command, "@NOMBRE_ARCHIVO_INFORMACION_ADICIONAL", DbType.String, documentoTicket.Nombre_DocumentoTicket);
                DB.AddInParameter(command, "@RUTA_INFORMACION_ADICIONAL", DbType.String, documentoTicket.Ruta_DocumentoTicket);
                DB.AddInParameter(command, "@CODIGO_EQUIPO", DbType.Int32, documentoTicket.Codigo_Equipo);
                DB.AddInParameter(command, "@CODIGO_INTEGRANTE", DbType.Int32, documentoTicket.Codigo_Integrante);

                DB.ExecuteNonQuery(command);
            }

        }



        public void escalarTicketEspecialista(Ticket ticket)
        {
            string sSQL;

            int numeroTicket = ticket.Codigo_Ticket;
            int codigoIntegrante = ticket.Codigo_Integrante;

            sSQL = "Update DBO.TICKET SET ASIGNADO_A_CODIGO_INTEGRANTE=@CODIGO_INTEGRANTE, ULTIMA_SECUENCIA_SEGUIMIENTO_TICKET=@ULTIMO_SEGUIMIENTO " +
                    "Where CODIGO_TICKET=" + numeroTicket ;
            using (DbCommand command = DB.GetSqlStringCommand(sSQL))
            {
                DB.AddInParameter(command, "@CODIGO_INTEGRANTE", DbType.Int64, ticket.Codigo_Integrante);
                DB.AddInParameter(command, "@ULTIMO_SEGUIMIENTO", DbType.Int64, ticket.Ultimo_Seguimiento );
                DB.ExecuteNonQuery(command);
            }

        }

        public void cambiarEstadoTicket(Ticket ticket)
        {
            string sSQL;

            int numeroTicket = ticket.Codigo_Ticket;
           
            sSQL = "Update DBO.TICKET SET ESTADO_TICKET=@ESTADO_TICKET " +
                    "Where CODIGO_TICKET=" + numeroTicket;
            using (DbCommand command = DB.GetSqlStringCommand(sSQL))
            {
                DB.AddInParameter(command, "@ESTADO_TICKET", DbType.String , ticket.Estado_Ticket);
                DB.ExecuteNonQuery(command);
            }

        }


        public List<DocumentoTicket> listaDocumentosTickets(int numeroTicket)
        {
            List<DocumentoTicket> listaDocumentoTicket = new List<DocumentoTicket>();
            string sSQL;

            //try
            //{
            sSQL = "Select CODIGO_TICKET,CODIGO_INFORMACION_ADICIONAL,FECHA_REGISTRO_INFORMACION_ADICIONAL," +
                   "DESCRIPCION_INFORMACION_ADICIONAL,NOMBRE_ARCHIVO_INFORMACION_ADICIONAL,RUTA_INFORMACION_ADICIONAL,CODIGO_EQUIPO,CODIGO_INTEGRANTE " +
                   "From DBO.INFORMACION_ADICIONAL " +
                   "Where CODIGO_TICKET=" + numeroTicket;

            using (DbCommand command = DB.GetSqlStringCommand(sSQL))
            {

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        listaDocumentoTicket.Add(TicketDocumentoDataMap.Select(reader));

                    }
                }
            }

            //}
            //catch
            //{
            //    return new List<DocumentoTicket>();
            //}
            return listaDocumentoTicket;
        }

    }
}
