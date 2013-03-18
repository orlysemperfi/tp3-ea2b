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

    /// <summary>
    ///  Implementa el Acceso a datos a Integrantes.
    /// </summary>
    public class IntegranteData : DataBase, IIntegranteData
    {

        public IntegranteData(String connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Obtiene una lista de analistas.
        /// </summary>
        /// <param name="id">Codigo del proyecto</param>
        /// <returns>Fase</returns>
        public List<Integrante> listaAnalistas(int CodigoProyecto)
        {
            List<Integrante> listaIntegrante = new List<Integrante>();
            //try
            //{
                using (DbCommand command = DB.GetStoredProcCommand("SD.usp_Integrante_Lista"))
                {
                    DB.AddInParameter(command, "@Proyecto", DbType.Int32, CodigoProyecto);
                    DB.AddInParameter(command, "@Nivel", DbType.String, "ANALISTA");

                    using (IDataReader reader = DB.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            listaIntegrante.Add(IntegranteDataMap.Select(reader));
                        }
                    }
                }

            //}
            //catch
            //{

            //}
            return listaIntegrante;

        }

        public List<Integrante> listaIntegrantesCompleta(string nivel)
        {
            List<Integrante> listaIntegrante = new List<Integrante>();
            //try
            //{
            using (DbCommand command = DB.GetStoredProcCommand("SD.usp_Integrante_ListaCompleta"))
            {
                DB.AddInParameter(command, "@Nivel", DbType.String, nivel);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        listaIntegrante.Add(IntegranteDataMap.Select(reader));
                    }
                }
            }

            //}
            //catch
            //{

            //}
            return listaIntegrante;

        }

        public List<Integrante> listaEspecialistaProyectoServicioSede(int CodigoProyecto,int CodigoServicio,int CodigoSede)
        {
            List<Integrante> listaIntegrante = new List<Integrante>();
            //try
            //{
            using (DbCommand command = DB.GetStoredProcCommand("SD.usp_Integrante_Lista"))
            {
                DB.AddInParameter(command, "@Proyecto", DbType.Int32, CodigoProyecto);
                DB.AddInParameter(command, "@Servicio", DbType.Int32, CodigoServicio);
                DB.AddInParameter(command, "@Sede", DbType.Int32, CodigoSede);
                DB.AddInParameter(command, "@Nivel", DbType.String, "ESPECIALISTA");

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        listaIntegrante.Add(IntegranteDataMap.Select(reader));
                    }
                }
            }

            //}
            //catch
            //{

            //}
            return listaIntegrante;

        }

        public List<Integrante> listaEspecialistaProyectoServicioSedeCarga(int CodigoProyecto, int CodigoServicio, int CodigoSede)
        {
            List<Integrante> listaIntegrante = new List<Integrante>();
            //try
            //{
            using (DbCommand command = DB.GetStoredProcCommand("SD.usp_Integrante_Lista_Carga"))
            {
                DB.AddInParameter(command, "@Proyecto", DbType.Int32, CodigoProyecto);
                DB.AddInParameter(command, "@Servicio", DbType.Int32, CodigoServicio);
                DB.AddInParameter(command, "@Sede", DbType.Int32, CodigoSede);
                DB.AddInParameter(command, "@Nivel", DbType.String, "ESPECIALISTA");

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        listaIntegrante.Add(IntegranteDataMap.Select(reader));
                    }
                }
            }

            //}
            //catch
            //{

            //}
            return listaIntegrante;

        }

        public List<Equipo> listaEquiposEspecialista(int CodigoProyecto, int CodigoServicio, int CodigoSede, int CodigoEmpleado)
        {
            List<Equipo> listaEquipos = new List<Equipo>();
            //try
            //{
            using (DbCommand command = DB.GetStoredProcCommand("SD.usp_Equipo_ListaEquiposPSSNivelEmpleado"))
            {
                DB.AddInParameter(command, "@Proyecto", DbType.Int32, CodigoProyecto);
                DB.AddInParameter(command, "@Servicio", DbType.Int32, CodigoServicio);
                DB.AddInParameter(command, "@Sede", DbType.Int32, CodigoSede);
                DB.AddInParameter(command, "@Nivel", DbType.String, "ESPECIALISTA");
                DB.AddInParameter(command, "@Empleado", DbType.Int32, CodigoEmpleado);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        listaEquipos.Add(EquipoDataMap.Select(reader));
                    }
                }
            }

            //}
            //catch
            //{

            //}
            return listaEquipos;

        }

    }
}
