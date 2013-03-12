using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;
using TMD.MP.AccesoDatos.Contrato;
using TMD.MP.Comun;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TMD.MP.AccesoDatos.Implementacion
{
    public class SolucionMejoraDataSql : BaseDataSql, ISolucionMejoraData
    {
        #region "Select"
        public List<SolucionMejoraEntidad> ObtenerSolucionMejoraListadoPorFiltros(SolucionMejoraEntidad oSolucionMejoraFiltro)
        {
            List<SolucionMejoraEntidad> oSolucionMejoraColeccion = new List<SolucionMejoraEntidad>();
            SolucionMejoraEntidad oSolucionMejora = null;
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            
            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;

            try
            {

                return oSolucionMejoraColeccion;
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
