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
    public class EscalaCuantitativoDataSql :IEscalaCuantitativoData
    {
        #region "Select"
        public List<EscalaCuantitativoEntidad> ObtenerListaEscalaCuantitativoPorIndicador(int codigo_Indicador)
        {
            List<EscalaCuantitativoEntidad> lstEscalaCuantitativo = new List<EscalaCuantitativoEntidad>();
            EscalaCuantitativoEntidad oEscalaCuantitativo = null;
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT EC.CODIGO, EC.CODIGO_INDICADOR, EC.SIGNO, EC.VALOR, EC.CODIGO_UNIDAD,U.DESCRIPCION ");
            strSQL.Append("FROM ESCALA_CUANTITATIVO EC , UNIDAD U ");
            strSQL.Append("WHERE EC.CODIGO_UNIDAD = U.CODIGO AND [CODIGO_INDICADOR]=@CODIGO_INDICADOR ");

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
                    oEscalaCuantitativo = new EscalaCuantitativoEntidad();
                    oEscalaCuantitativo.codigo = Utilitario.getDefaultOrIntDBValue(dr["CODIGO"]);
                    oEscalaCuantitativo.codigo_Indicador = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_INDICADOR"]);
                    oEscalaCuantitativo.signo = Utilitario.getDefaultOrStringDBValue(dr["SIGNO"]);
                    oEscalaCuantitativo.valor = Utilitario.getDefaultOrDoubleDBValue(dr["VALOR"]);
                    oEscalaCuantitativo.codigo_Unidad = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_UNIDAD"]);
                    oEscalaCuantitativo.descripcion_unidad = Utilitario.getDefaultOrStringDBValue(dr["DESCRIPCION"]);
                    lstEscalaCuantitativo.Add(oEscalaCuantitativo);
                }
                dr.Close();
                return lstEscalaCuantitativo;
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
        public void InsertarEscalaCuantitativo(EscalaCuantitativoEntidad entidad)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("INSERT INTO [ESCALA_CUANTITATIVO] ([CODIGO_INDICADOR],[SIGNO],[VALOR],[CODIGO_UNIDAD]) ");
            strSQL.Append("VALUES (@CODIGO_INDICADOR,@SIGNO,@VALOR,@CODIGO_UNIDAD) ");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO_INDICADOR", SqlDbType.Int).Value = entidad.codigo_Indicador;
            sqlCmd.Parameters.Add("@SIGNO", SqlDbType.VarChar).Value = entidad.signo;
            sqlCmd.Parameters.Add("@VALOR", SqlDbType.Float).Value = entidad.valor;
            sqlCmd.Parameters.Add("@CODIGO_UNIDAD", SqlDbType.VarChar).Value = entidad.codigo_Unidad;

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

        #region "Actualizar"
        public void ActualizarEscalaCuantitativo(EscalaCuantitativoEntidad entidad)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("UPDATE [ESCALA_CUANTITATIVO] SET [CODIGO_INDICADOR] = @CODIGO_INDICADOR,[SIGNO] = @SIGNO,[VALOR] = @VALOR,[CODIGO_UNIDAD] = @CODIGO_UNIDAD ");
            strSQL.Append("WHERE [CODIGO] = @CODIGO ");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO", SqlDbType.Int).Value = entidad.codigo;
            sqlCmd.Parameters.Add("@CODIGO_INDICADOR", SqlDbType.Int).Value = entidad.codigo_Indicador;
            sqlCmd.Parameters.Add("@SIGNO", SqlDbType.Float).Value = entidad.signo;
            sqlCmd.Parameters.Add("@VALOR", SqlDbType.Float).Value = entidad.valor;
            sqlCmd.Parameters.Add("@CODIGO_UNIDAD", SqlDbType.VarChar).Value = entidad.codigo_Unidad;

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
        public void EliminarEscalaCuantitativoPorIndicador(int codigo_indicador)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("DELETE FROM [ESCALA_CUANTITATIVO] ");
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
