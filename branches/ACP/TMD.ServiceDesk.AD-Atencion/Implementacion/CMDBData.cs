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

    public class CMDBData : DataBase, ICMDBData
    {


        public CMDBData(String connectionString)
            : base(connectionString)
        {


        }


        public List<CMDB> listaCMDBProyecto(int codigoProyecto)
        {
            List<CMDB> _listaCMDB = new List<CMDB>();
            //try
            //{

            using (DbCommand command = DB.GetStoredProcCommand("SD.usp_CMDB_ListaCompleta"))
            {
                DB.AddInParameter(command, "@PROYECTO", DbType.Int32, codigoProyecto);
                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        _listaCMDB.Add(CMDBDataMap.Select(reader));
                    }
                }
            }

            //}
            //catch
            //{

            //}
            return _listaCMDB;

        }



    }
}
