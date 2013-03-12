using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.CF.AccesoDatos.Core;
using TMD.CF.AccesoDatos.Contrato;
using TMD.Entidades;
using System.Data.Common;
using System.Data;
using TMD.CF.AccesoDatos.Map;

namespace TMD.CF.AccesoDatos.Implementacion
{
    public class OrdenCambioData : DataBase, IOrdenCambioData
    {
        public OrdenCambioData(String connectionString)
            : base(connectionString)
        {
        }

        public List<OrdenCambio> ListarPorProyectoLBase(int codigoProyecto, int codigoLineaBase)
        {
            List<OrdenCambio> listaOrdenCambio = new List<OrdenCambio>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_LISTA_ORDEN_PROYECTO_BASE"))
            {
                DB.AddInParameter(command, "@FECHA_ENTREGA", DbType.Date, null);
                DB.AddInParameter(command, "@CODIGO_PRIORIDAD", DbType.Int32, null);
                DB.AddInParameter(command, "@CODIGO_INFORME", DbType.Int32, null);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        listaOrdenCambio.Add(OrdenCambioMap.Select(reader));
                    }
                }
            }

            return listaOrdenCambio;
        }
    }
}
