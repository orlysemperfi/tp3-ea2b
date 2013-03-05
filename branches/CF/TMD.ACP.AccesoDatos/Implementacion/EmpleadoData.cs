using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using TMD.ACP.AccesoDatos.Contrato;
using TMD.ACP.AccesoDatos.Core;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Map;

namespace TMD.ACP.AccesoDatos.Implementacion
{
    public class EmpleadoData : DataBase, IEmpleadoData
    {
        public EmpleadoData(String connectionString)
            : base(connectionString)
        {
        }

        public List<EmpleadoEntidad> ListarEmpleados()
        {
            List<EmpleadoEntidad> lista = new List<EmpleadoEntidad>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_LISTAR_EMPLEADOS"))
            {             
                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lista.Add(EmpleadoDataMap.SelectEmpleado(reader));
                    }
                }
            }

            return lista;
        }

        public EmpleadoEntidad ObtenerEmpleado(int idEmpleado)
        {
            EmpleadoEntidad eEmpleado = new EmpleadoEntidad();
            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_OBTENER_EMPLEADO"))
            {
                DB.AddInParameter(command, "@idEmpleado", DbType.Int32, idEmpleado);
                using (IDataReader reader = DB.ExecuteReader(command))
                {                    
                    while (reader.Read())
                    {                                                
                        eEmpleado = EmpleadoDataMap.SelectEmpleado(reader);
                        return eEmpleado;                  
                    }
                }
            }
            return eEmpleado;
        }
    }
}
