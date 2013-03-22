using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;
using TMD.MP.AccesoDatos.Contrato;
using TMD.MP.Comun;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TMD.MP.AccesoDatos.Implementacion
{
    public class EscalaCualitativoDataSql: IEscalaCualitativoData
    {
        #region "Select"
        public List<EscalaCualitativoEntidad> ObtenerListaEscalaCualitativoPorIndicador(int codigo_Indicador)
        {
            List<EscalaCualitativoEntidad> lstEscalaCualitativo = new List<EscalaCualitativoEntidad>();
            EscalaCualitativoEntidad oEscalaCualitativo = null;
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT [CODIGO], [CODIGO_INDICADOR], [LIMITE_INFERIOR], [LIMITE_SUPERIOR], [CALIFICACION],[PRINCIPAL] ");
            strSQL.Append("FROM [TMD].[MP].[ESCALA_CUALITATIVO] ");
            strSQL.Append("WHERE [CODIGO_INDICADOR]=@CODIGO_INDICADOR ");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO_INDICADOR", SqlDbType.Int).Value = codigo_Indicador;

            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    oEscalaCualitativo = new EscalaCualitativoEntidad();                        
                    oEscalaCualitativo.codigo = Utilitario.getDefaultOrIntDBValue(dr["CODIGO"]);
                    oEscalaCualitativo.codigo_Indicador = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_INDICADOR"]);
                    oEscalaCualitativo.limite_inferior = Utilitario.getDefaultOrStringDBValue(dr["LIMITE_INFERIOR"]);
                    oEscalaCualitativo.limite_superior = Utilitario.getDefaultOrStringDBValue(dr["LIMITE_SUPERIOR"]);
                    oEscalaCualitativo.calificacion = Utilitario.getDefaultOrStringDBValue(dr["CALIFICACION"]);
                    oEscalaCualitativo.principal = Utilitario.getDefaultOrIntDBValue(dr["PRINCIPAL"]);
                    lstEscalaCualitativo.Add(oEscalaCualitativo);
                }
                dr.Close();
                return lstEscalaCualitativo;
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

        #region "Insert"
        public void InsertarEscalaCualitativo(EscalaCualitativoEntidad entidad)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("INSERT INTO [TMD].[MP].[ESCALA_CUALITATIVO] ([CODIGO_INDICADOR],[LIMITE_INFERIOR],[LIMITE_SUPERIOR],[CALIFICACION],[PRINCIPAL]) ");
            strSQL.Append("VALUES (@CODIGO_INDICADOR,@LIMITE_INFERIOR,@LIMITE_SUPERIOR,@CALIFICACION,@PRINCIPAL) ");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO_INDICADOR", SqlDbType.Int).Value = entidad.codigo_Indicador;
            sqlCmd.Parameters.Add("@LIMITE_INFERIOR", SqlDbType.Float).Value = entidad.limite_inferior;
            sqlCmd.Parameters.Add("@LIMITE_SUPERIOR", SqlDbType.Float).Value = entidad.limite_superior;
            sqlCmd.Parameters.Add("@CALIFICACION", SqlDbType.VarChar).Value = entidad.calificacion;
            sqlCmd.Parameters.Add("@PRINCIPAL", SqlDbType.Bit).Value = entidad.principal;

            try
            {
                sqlConn.Open();
                sqlCmd.ExecuteNonQuery();
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

        #region "Update"
        public void ActualizarEscalaCualitativo(EscalaCualitativoEntidad entidad)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("UPDATE [TMD].[MP].[ESCALA_CUALITATIVO] SET [CODIGO_INDICADOR] = @CODIGO_INDICADOR,[LIMITE_INFERIOR] =@LIMITE_INFERIOR,[LIMITE_SUPERIOR] = @LIMITE_SUPERIOR,[CALIFICACION] = @CALIFICACION ");
            strSQL.Append("WHERE [CODIGO] = @CODIGO ");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO", SqlDbType.Int).Value = entidad.codigo;
            sqlCmd.Parameters.Add("@CODIGO_INDICADOR", SqlDbType.Int).Value = entidad.codigo_Indicador;
            sqlCmd.Parameters.Add("@LIMITE_INFERIOR", SqlDbType.Float).Value = entidad.limite_inferior;
            sqlCmd.Parameters.Add("@LIMITE_SUPERIOR", SqlDbType.Float).Value = entidad.limite_superior;
            sqlCmd.Parameters.Add("@CALIFICACION", SqlDbType.VarChar).Value = entidad.calificacion;

            try
            {
                sqlConn.Open();
                sqlCmd.ExecuteNonQuery();
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
        
        #region "Eliminar"
        public void EliminarEscalaCualitativoPorIndicador(int codigo_indicador)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("DELETE FROM [TMD].[MP].[ESCALA_CUALITATIVO] ");
            strSQL.Append("WHERE [CODIGO_INDICADOR] = @CODIGO_INDICADOR ");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO_INDICADOR", SqlDbType.Int).Value = codigo_indicador;

            try
            {
                sqlConn.Open();
                sqlCmd.ExecuteNonQuery();
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
