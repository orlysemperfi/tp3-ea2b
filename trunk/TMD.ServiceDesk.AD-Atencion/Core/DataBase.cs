using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace TMD.DBO.AccesoDatos_Atencion.Core
{
    public class DataBase
    {
        protected SqlDatabase DB;
        private static object syncLock = new object();

        public DataBase(String connectionString)
        {
            if (DB == null)
            {
                lock (syncLock)
                {
                    if (DB == null)
                    {
                        DB = DatabaseFactory.CreateDatabase(connectionString) as SqlDatabase;
                    }
                }
            }
        }
    }
}
