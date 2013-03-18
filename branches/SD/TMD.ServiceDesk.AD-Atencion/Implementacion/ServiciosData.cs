using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Common;
using System.Data;

using TMD.SD.AccesoDatos_Atencion.Contrato;
using TMD.SD.AccesoDatos_Atencion.Core;
using TMD.SD.AccesoDatos_Atencion.Map;
using TMD.Entidades;


namespace TMD.SD.AccesoDatos_Atencion.Implementacion
{
   
    public class ServiciosData : DataBase, IServicioData
    {

        public ServiciosData(String connectionString)  : base(connectionString)
        {


        }


        public ProyectoServicioSede datosServicioSLA(ProyectoServicioSede datosServicioSLA)
        {
            ProyectoServicioSede _datosServicioSLA = new ProyectoServicioSede();
            int codigoProyecto, codigoServicio, codigoSede;

            //try
            //{

            codigoProyecto = datosServicioSLA.Codigo_Proyecto;
            codigoServicio = datosServicioSLA.Codigo_Servicio ;
            codigoSede = datosServicioSLA.Codigo_Sede ;
 
            using (DbCommand command = DB.GetStoredProcCommand("SD.usp_Proyecto_Servicio_Sede"))
            {
                DB.AddInParameter(command, "@PROYECTO", DbType.Int32, codigoProyecto);
                DB.AddInParameter(command, "@SERVICIO", DbType.Int32, codigoServicio);
                DB.AddInParameter(command, "@SEDE", DbType.Int32, codigoSede);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    if (reader.Read())
                    {
                        _datosServicioSLA = ProyectoServicioSedeDataMap.Select(reader);
                    }
                }
            }

            //}
            //catch
            //{

            //}
            return _datosServicioSLA;

        }


        public List<Servicio> listaServiciosUsuarioCliente(int codigoCliente, int codigoUsuarioCliente)
        {
            List<Servicio> _ListaServiciosUsuarioCliente = new List<Servicio>();
            //try
            //{
            
            using (DbCommand command = DB.GetStoredProcCommand("SD.usp_Servicio_ListaServiciosUsuarioCliente"))
            {
                DB.AddInParameter(command, "@USUARIO", DbType.Int32, codigoUsuarioCliente);
                DB.AddInParameter(command, "@CLIENTE", DbType.Int32, codigoCliente);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        _ListaServiciosUsuarioCliente.Add(ServicioDataMap.Select(reader));
                    }
                }
            }

            //}
            //catch
            //{

            //}
            return _ListaServiciosUsuarioCliente;

        }



    }

   
    

}
