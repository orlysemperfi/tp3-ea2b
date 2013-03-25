using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.MP.AccesoDatos.Contrato;
using TMD.MP.Comun;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TMD.Entidades;

namespace TMD.MP.AccesoDatos.Implementacion
{
    public class AreaDataSql : IAreaData
    {
        #region "Select"
        public List<AreaEntidad> ObtenerListaAreaTodas()
        {
            List<AreaEntidad> lstArea = new List<AreaEntidad>();
            AreaEntidad oArea = null;
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT CODIGO_AREA, DESCRIPCION ");
            strSQL.Append("FROM AREA ");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;

            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    oArea = new AreaEntidad();
                    oArea.codigo = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_AREA"]);
                    oArea.descripcion = Utilitario.getDefaultOrStringDBValue(dr["DESCRIPCION"]);
                    lstArea.Add(oArea);
                }

                dr.Close();
                return lstArea;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        #endregion
    }
}
