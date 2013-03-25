using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;
using TMD.MP.AccesoDatos.Contrato;
using TMD.MP.AccesoDatos.Implementacion;
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
            strSQL.Append("SELECT S.CODIGO, P.CODIGO_PROPUESTA, S.DESCRIPCION, P.DESCRIPCION, E.NOMBRE, E.CODIGO AS CODIGO_ESTADO ");
            strSQL.Append("FROM SOLUCION_MEJORA S ");
            strSQL.Append("INNER JOIN PROPUESTAMEJORA P ON S.CODIGO_PROPUESTA = P.CODIGO_PROPUESTA ");
            strSQL.Append("INNER JOIN ESTADO E ON S.CODIGO_ESTADO = E.CODIGO ");
            strSQL.Append("WHERE E.NOMBRE <> '" + Constantes.ESTADO_SOLUCION_ELIMINADA + "' ");
            if (oSolucionMejoraFiltro != null)
            {
                if (oSolucionMejoraFiltro.codigo_Propuesta != null && oSolucionMejoraFiltro.codigo_Propuesta != 0)
                    strSQL.Append("AND S.CODIGO = @CODIGO_SOLUCION ");
                if (oSolucionMejoraFiltro.propuesta != null && oSolucionMejoraFiltro.propuesta != String.Empty)
                    strSQL.Append("AND P.DESCRIPCION = @PROPUESTA ");
                if (oSolucionMejoraFiltro.fecha_Registro_Inicio != null)
                    strSQL.Append("AND DATEDIFF(DAY, S.FECHA_APROBACION, @FECHA_REGISTRO_INICIO) <= 0 ");
                if (oSolucionMejoraFiltro.fecha_Registro_Inicio != null)
                    strSQL.Append("AND DATEDIFF(DAY, S.FECHA_APROBACION, @FECHA_REGISTRO_FIN) >= 0  ");
            }

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;

            if (oSolucionMejoraFiltro != null)
            {
                if (oSolucionMejoraFiltro.codigo_Propuesta != null && oSolucionMejoraFiltro.codigo_Propuesta != 0)
                    sqlCmd.Parameters.Add("@CODIGO_SOLUCION", SqlDbType.Int).Value = oSolucionMejoraFiltro.codigo_Propuesta;
                if (oSolucionMejoraFiltro.propuesta != null && oSolucionMejoraFiltro.propuesta != String.Empty)
                    sqlCmd.Parameters.Add("@PROPUESTA", SqlDbType.VarChar).Value = oSolucionMejoraFiltro.propuesta;
                if (oSolucionMejoraFiltro.fecha_Registro_Inicio != null)
                    sqlCmd.Parameters.Add("@FECHA_REGISTRO_INICIO", SqlDbType.DateTime).Value = oSolucionMejoraFiltro.fecha_Registro_Inicio;
                if (oSolucionMejoraFiltro.fecha_Registro_Inicio != null)
                    sqlCmd.Parameters.Add("@FECHA_REGISTRO_FIN", SqlDbType.DateTime).Value = oSolucionMejoraFiltro.fecha_Registro_Fin;
            }

            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    oSolucionMejora = new SolucionMejoraEntidad();
                    oSolucionMejora.codigo_Solucion = Utilitario.getDefaultOrIntDBValue(dr["CODIGO"]);
                    oSolucionMejora.solucion = Utilitario.getDefaultOrStringDBValue(dr["DESCRIPCION"]);
                    oSolucionMejora.codigo_Propuesta = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_PROPUESTA"]);
                    oSolucionMejora.propuesta = Utilitario.getDefaultOrStringDBValue(dr["DESCRIPCION"]);
                    oSolucionMejora.nombre_Estado = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE"]);
                    oSolucionMejora.codigo_Estado = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_ESTADO"]);
                    oSolucionMejoraColeccion.Add(oSolucionMejora);
                }
                dr.Close();
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

        public SolucionMejoraEntidad ObtenerSolucionMejoraPorCodigo(int codigo)
        {
            SolucionMejoraEntidad oSolucionMejora = new SolucionMejoraEntidad();
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT S.CODIGO, P.CODIGO_PROPUESTA, S.DESCRIPCION, P.DESCRIPCION, E.NOMBRE, E.CODIGO AS CODIGO_ESTADO, S.CODIGO_EMPLEADO ");
            strSQL.Append("FROM SOLUCION_MEJORA S ");
            strSQL.Append("INNER JOIN PROPUESTAMEJORA P ON S.CODIGO_PROPUESTA = P.CODIGO_PROPUESTA ");
            strSQL.Append("INNER JOIN ESTADO E ON S.CODIGO_ESTADO = E.CODIGO ");
            strSQL.Append("WHERE S.CODIGO = @CODIGO_SOLUCION ");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO_SOLUCION", SqlDbType.Int).Value = codigo;

            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();

                if (dr.Read())
                {
                    oSolucionMejora = new SolucionMejoraEntidad();
                    oSolucionMejora.codigo_Solucion = Utilitario.getDefaultOrIntDBValue(dr["CODIGO"]);
                    oSolucionMejora.solucion = Utilitario.getDefaultOrStringDBValue(dr["DESCRIPCION"]);
                    oSolucionMejora.codigo_Propuesta = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_PROPUESTA"]);
                    oSolucionMejora.codigo_Empleado = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_EMPLEADO"]);
                    oSolucionMejora.propuesta = Utilitario.getDefaultOrStringDBValue(dr["DESCRIPCION"]);
                    oSolucionMejora.nombre_Estado = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE"]);
                    oSolucionMejora.codigo_Estado = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_ESTADO"]);
                    
                }
                dr.Close();
                return oSolucionMejora;
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

        public List<SolucionMejoraEntidad> ObtenerSolucionMejoraListadoPorEstado(String estado)
        {
            List<SolucionMejoraEntidad> oSolucionMejoraColeccion = new List<SolucionMejoraEntidad>();
            SolucionMejoraEntidad oSolucionMejora = null;
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT S.CODIGO, S.DESCRIPCION ");
            strSQL.Append("FROM SOLUCION_MEJORA S ");
            strSQL.Append("INNER JOIN ESTADO E ON E.CODIGO = S.CODIGO_ESTADO ");
            strSQL.Append("WHERE E.NOMBRE = '" + estado + "' ");
            strSQL.Append("AND S.TIENEPILOTO=1 ");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;

            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    oSolucionMejora = new SolucionMejoraEntidad();
                    oSolucionMejora.codigo_Solucion = Utilitario.getDefaultOrIntDBValue(dr["CODIGO"]);
                    oSolucionMejora.descripcion = Utilitario.getDefaultOrStringDBValue(dr["DESCRIPCION"]);
                    oSolucionMejoraColeccion.Add(oSolucionMejora);
                }
                dr.Close();
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

        #region "Insert"
        public SolucionMejoraEntidad InsertarSolucionMejora(SolucionMejoraEntidad oSolucionMejora)
        {

            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("INSERT INTO [SOLUCION_MEJORA]");
            strSQL.Append("(CODIGO_EMPLEADO,CODIGO_PROPUESTA,DESCRIPCION,FECHA_APROBACION,CODIGO_ESTADO) ");
            strSQL.Append("VALUES(@CODIGO_EMPLEADO,@CODIGO_PROPUESTA,@DESCRIPCION,GETDATE(),@CODIGO_ESTADO)");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;
            int affectedRows = 0;
            try
            {
                sqlCmd.Parameters.Add("@CODIGO_EMPLEADO", SqlDbType.Int).Value = oSolucionMejora.codigo_Empleado;
                sqlCmd.Parameters.Add("@CODIGO_PROPUESTA", SqlDbType.Int).Value = oSolucionMejora.codigo_Propuesta;
                sqlCmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = oSolucionMejora.descripcion;
                sqlCmd.Parameters.Add("@CODIGO_ESTADO", SqlDbType.Int).Value = oSolucionMejora.codigo_Estado;
                sqlConn.Open();

                affectedRows = sqlCmd.ExecuteNonQuery();

                if (affectedRows == 0)
                {
                    throw new System.Exception("No hay registros ingresados a la tabla Solucion_Mejora");
                }
                else
                {
                    oSolucionMejora.codigo_Solucion = ObtenerKeyInsertada(Constantes.TABLA_SOLUCION_MEJORA);
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

            return oSolucionMejora;
        }

        public SolucionMejoraEntidad InsertarSolucionMejoraEstado(SolucionEstadoEntidad oSolucionEstado)
        {

            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("INSERT INTO ESTADO_SOLUCION ");
            strSQL.Append("(CODIGO_SOLUCION,CODIGO_ESTADO,FECHA) ");
            strSQL.Append("VALUES(@CODIGO_SOLUCION,@CODIGO_ESTADO,GETDATE())");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;
            int affectedRows = 0;
            try
            {
                sqlCmd.Parameters.Add("@CODIGO_SOLUCION", SqlDbType.Int).Value = oSolucionEstado.codigo_solucion;
                sqlCmd.Parameters.Add("@CODIGO_ESTADO", SqlDbType.Int).Value = oSolucionEstado.codigo_estado;
                sqlConn.Open();

                affectedRows = sqlCmd.ExecuteNonQuery();

                if (affectedRows == 0)
                {
                    throw new System.Exception("No hay registros ingresados a la tabla Solucion Estado");
                }
                else
                {
                    oSolucionEstado.codigo = ObtenerKeyInsertada(Constantes.TABLA_SOLUCION_ESTADO);
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
            return null;
        }


        #endregion

        #region "Update"

        public void ActualizarSolucionMejora(SolucionMejoraEntidad oSolucionMejora)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("UPDATE SOLUCION_MEJORA SET ");
            strSQL.Append("CODIGO_EMPLEADO=@CODIGO_EMPLEADO, CODIGO_PROPUESTA=@CODIGO_PROPUESTA,DESCRIPCION=@DESCRIPCION, ");
            strSQL.Append("CODIGO_ESTADO=@CODIGO_ESTADO ");
            strSQL.Append("WHERE CODIGO = @CODIGO_SOLUCION");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO_SOLUCION", SqlDbType.Int).Value = oSolucionMejora.codigo_Solucion;
            sqlCmd.Parameters.Add("@CODIGO_EMPLEADO", SqlDbType.Int).Value = oSolucionMejora.codigo_Empleado;
            sqlCmd.Parameters.Add("@CODIGO_PROPUESTA", SqlDbType.Int).Value = oSolucionMejora.codigo_Propuesta;
            sqlCmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = oSolucionMejora.descripcion;
            sqlCmd.Parameters.Add("@CODIGO_ESTADO", SqlDbType.Int).Value = oSolucionMejora.codigo_Estado;

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

        public void ActualizarEstadoSolucionMejora(SolucionMejoraEntidad oSolucionMejora)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("UPDATE SOLUCION_MEJORA SET CODIGO_ESTADO = @CODIGO_ESTADO WHERE CODIGO = @CODIGO");
            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO", SqlDbType.Int).Value = oSolucionMejora.codigo_Solucion;
            sqlCmd.Parameters.Add("@CODIGO_ESTADO", SqlDbType.Int).Value = oSolucionMejora.codigo_Estado;

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

        #region "Delete"
        public void EliminarSolucionMejoraPorCodigo(int codigo)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
