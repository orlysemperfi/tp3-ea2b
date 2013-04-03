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
    public class AccionesSolucionDataSql: IAccionesSolucionData
    {
        #region "Select"
        public List<AccionesSolucionEntidad> ObtenerListaAccionesPorSolucion(int codigo)
        {
            List<AccionesSolucionEntidad> lstAcciones = new List<AccionesSolucionEntidad>();
            AccionesSolucionEntidad oAccionesSolucion = null;
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT [CODIGO], [DESCRIPCION] ");
            strSQL.Append("FROM [ACCIONES_SOLUCION] ");
            strSQL.Append("WHERE [CODIGO_SOLUCION]=@CODIGO_SOLUCION ");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO_SOLUCION", SqlDbType.Int).Value = codigo;

            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    oAccionesSolucion = new AccionesSolucionEntidad();
                    oAccionesSolucion.codigo = Utilitario.getDefaultOrIntDBValue(dr["CODIGO"]);
                    oAccionesSolucion.descripcion = Utilitario.getDefaultOrStringDBValue(dr["DESCRIPCION"]);
                    lstAcciones.Add(oAccionesSolucion);
                }
                dr.Close();
                return lstAcciones;
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
        public void InsertarAccionesSolucion(AccionesSolucionEntidad entidad)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("INSERT INTO [ACCIONES_SOLUCION] ([CODIGO_SOLUCION],[DESCRIPCION]) ");
            strSQL.Append("VALUES (@CODIGO_SOLUCION,@DESCRIPCION) ");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO_SOLUCION", SqlDbType.Int).Value = entidad.codigo_solucion;
            sqlCmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = entidad.descripcion;

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
        public void ActualizarAccionesSolucion(AccionesSolucionEntidad entidad)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("UPDATE [ACCIONES_SOLUCION] SET [CODIGO_SOLUCION] = @CODIGO_SOLUCION,[DESCRIPCION] =@DESCRIPCION ");
            strSQL.Append("WHERE [CODIGO] = @CODIGO ");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO", SqlDbType.Int).Value = entidad.codigo;
            sqlCmd.Parameters.Add("@CODIGO_SOLUCION", SqlDbType.Int).Value = entidad.codigo_solucion;
            sqlCmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = entidad.descripcion;

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
        public void EliminarAccionesSolucionPorSolucion(int codigo_solucion)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("DELETE FROM [ACCIONES_SOLUCION] ");
            strSQL.Append("WHERE [CODIGO_SOLUCION] = @CODIGO_SOLUCION ");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO_SOLUCION", SqlDbType.Int).Value = codigo_solucion;

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
