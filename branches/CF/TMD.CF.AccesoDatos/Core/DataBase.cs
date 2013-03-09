using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace TMD.CF.AccesoDatos.Core
{
    public class DataBase
    {
        protected static SqlDatabase _dataBase;
        private static object syncLock = new object();
        
        public DataBase(String connectionString)
        {
            if (_dataBase == null)
            {
                lock (syncLock)
                {
                    if (_dataBase == null)
                    {
                        _dataBase = 
                            DatabaseFactory.CreateDatabase(connectionString) as SqlDatabase;
                    }
                }
            }
        }

        public static SqlDatabase DB
        {
            get { return _dataBase; }
        }
    }
}
