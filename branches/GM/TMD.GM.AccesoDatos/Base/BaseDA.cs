using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.EntityClient;
using System.Data.Common;

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
        private static string Metadata = @"res://*/ModelGM.csdl|res://*/ModelGM.ssdl|res://*/ModelGM.msl";
        #endregion

        private static SqlDatabase getSqlDatabase = null;
        private static BDMantenEntities getEntityDatabase = null;

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
        public static BDMantenEntities GetEntityDatabase
        {
            get
            {
                if (getEntityDatabase == null)
                {
                    getEntityDatabase = new BDMantenEntities(GetEntityConnectionCustom());
                    getEntityDatabase.ContextOptions.UseLegacyPreserveChangesBehavior = false;
                }
                else
                {
                    try
                    {
                        DbConnection conn = getEntityDatabase.Connection;
                    }
                    catch(Exception ex)
                    {
                        getEntityDatabase.Dispose();
                        getEntityDatabase = new BDMantenEntities(GetEntityConnectionCustom());
                    }

                }
                return getEntityDatabase;
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

        public static EntityConnection GetEntityConnectionCustom()
        {
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

            sqlBuilder.DataSource = DataSource;
            sqlBuilder.InitialCatalog = InitialCatalog;
            sqlBuilder.IntegratedSecurity = IntegratedSecurity;
            sqlBuilder.UserID = UserID;
            sqlBuilder.Password = Password;
            sqlBuilder.MultipleActiveResultSets = true;

            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.Provider = Provider;
            entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
            entityBuilder.Metadata = Metadata;

            EntityConnection conn = new EntityConnection(entityBuilder.ToString());
            return conn;

        }


        public static string GetSQLConnectionString()
        {
            //Data Source=PEDRO-HP;Initial Catalog=BDManten;Persist Security Info=False;User ID=sa;Password=root

            return "Data Source=" + DataSource + ";Initial Catalog=" + InitialCatalog + ";Persist Security Info=False;User ID=" + UserID + ";Password=" + Password;

        }

    }
}
