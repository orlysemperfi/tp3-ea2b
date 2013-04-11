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
    public class UsuarioClienteData : DataBase, IUsuarioClienteData
    {

        public UsuarioClienteData(String connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Obtiene una lista de usuarios del cliente por integrante
        /// </summary>
        /// <param name="AliasIntegrante">Alias del Integrante</param>
        /// <returns>Lista Usuario Cliente</returns>
        public List<UsuarioCliente> listaUsuarioCliente(string AliasIntegrante)
        {
            List<UsuarioCliente> _listaUsuarioCliente = new List<UsuarioCliente>();
            //try
            //{
            using (DbCommand command = DB.GetStoredProcCommand("DBO.usp_Integrante_Usuario_Cliente"))
            {
                DB.AddInParameter(command, "@ALIAS_EMPLEADO", DbType.String, AliasIntegrante);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        _listaUsuarioCliente.Add(UsuarioClienteDataMap.Select(reader));
                    }
                }
            }

            //}
            //catch
            //{

            //}
            return _listaUsuarioCliente;

        }


        public UsuarioCliente datosUsuarioCliente(int codigoUsuarioCliente)
        {
            UsuarioCliente  _datosUsuarioCliente = new UsuarioCliente();

            //try
            //{
            using (DbCommand command = DB.GetStoredProcCommand("DBO.usp_UsuarioCliente_Datos"))
            {
                DB.AddInParameter(command, "@USUARIO", DbType.Int32, codigoUsuarioCliente);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    if (reader.Read())
                    {
                        _datosUsuarioCliente = UsuarioClienteDataMap.Select(reader);
                    }
                }
            }

            //}
            //catch
            //{

            //}
            return _datosUsuarioCliente;

        }

       

    }
}
