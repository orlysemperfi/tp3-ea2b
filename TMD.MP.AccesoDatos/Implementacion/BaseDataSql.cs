using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using TMD.MP.Comun;
using System.Configuration;
using System.Data;

namespace TMD.MP.AccesoDatos.Implementacion
{
    public class BaseDataSql
    {
        protected int ObtenerKeyInsertada(String tableName)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();

            int key = 0;

            strSQL.Append("SELECT IDENT_CURRENT('" + tableName + "') AS ID");
            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;

            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();
                if (dr.Read())
                {
                    key = Utilitario.getDefaultOrIntDBValue(dr["ID"]);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }

            return key;
        }
    }
}
