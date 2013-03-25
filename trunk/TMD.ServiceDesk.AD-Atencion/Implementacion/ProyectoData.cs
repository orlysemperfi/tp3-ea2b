using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Common;
using System.Data;

using TMD.DBO.AccesoDatos_Atencion.Contrato;
using TMD.DBO.AccesoDatos_Atencion.Core;
using TMD.DBO.AccesoDatos_Atencion.Map;
using TMD.Entidades;


namespace TMD.DBO.AccesoDatos_Atencion.Implementacion
{
  

    public class ProyectoData : DataBase, IProyectoData
    {

        public ProyectoData(String connectionString)
            : base(connectionString)
        {


        }




        public List<Proyecto> listaProyectosUsuarioCliente(int codigoUsuarioCliente)
        {
            List<Proyecto> _listaProyectos = new List<Proyecto>();
            //try
            //{
            using (DbCommand command = DB.GetStoredProcCommand("DBO.usp_UsuarioCliente_ListaProyectos"))
            {
                DB.AddInParameter(command, "@USUARIO", DbType.Int32, codigoUsuarioCliente);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        _listaProyectos.Add(ProyectoDataMap.Select(reader));
                    }
                }
            }

            //}
            //catch
            //{

            //}
            return _listaProyectos;

        }


        public List<Proyecto> listaProyectosUsuarioClienteServicio(int codigoCliente, int codigoUsuarioCliente, int codigoServicio)
        {
            List<Proyecto> _listaProyectos = new List<Proyecto>();
            //try
            //{
            using (DbCommand command = DB.GetStoredProcCommand("DBO.usp_Proyecto_ListaProyectosUsuarioClienteServicio"))
            {
                DB.AddInParameter(command, "@CLIENTE", DbType.Int32, codigoCliente);
                DB.AddInParameter(command, "@USUARIO", DbType.Int32, codigoUsuarioCliente);
                DB.AddInParameter(command, "@SERVICIO", DbType.Int32, codigoServicio);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        _listaProyectos.Add(ProyectoDataMap.Select(reader));
                    }
                }
            }

            //}
            //catch
            //{

            //}
            return _listaProyectos;

        }


    }
}
