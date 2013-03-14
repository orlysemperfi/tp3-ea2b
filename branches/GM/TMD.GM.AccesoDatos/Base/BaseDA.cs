using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace TMD.GM.AccesoDatos
{
    public sealed class BaseDA
    {
        private  BaseDA(){}

        #region Constantes
        private static string DataSource = @"TESIS051\MSQL2008R2";
        private static string InitialCatalog = "BDManten";
        private static string UserID = "sa";
        private static string Password = "Pass@word1";
        private static bool IntegratedSecurity = false;
        private static bool MultipleActiveResultSets = true;
        private static string Provider = "System.Data.SqlClient";
        private static string Metadata = @"res://*/ModelCERTCALI.csdl|res://*/ModelCERTCALI.ssdl|res://*/ModelCERTCALI.msl";
        #endregion

        private static SqlDatabase getSqlDatabase = null;

        public static SqlDatabase GetSqlDatabase
        {
            get
            {
                if (getSqlDatabase == null)
                {
                    getSqlDatabase = new SqlDatabase(GetSQLConnectionStringCustom());
                }
                return getSqlDatabase;
            }
        }

        private static string GetSQLConnectionStringCustom()
        {
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

            sqlBuilder.DataSource = DataSource;
            sqlBuilder.InitialCatalog = InitialCatalog;
            sqlBuilder.IntegratedSecurity = IntegratedSecurity;
            sqlBuilder.UserID = UserID;
            sqlBuilder.Password = Password;
            sqlBuilder.MultipleActiveResultSets = MultipleActiveResultSets;

            return sqlBuilder.ToString();
        }

    }
}
