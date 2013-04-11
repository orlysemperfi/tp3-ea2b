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
    public class PilotoDataSql : BaseDataSql, IPilotoData
    {
        #region "Select"
        public List<PilotoEntidad> ObtenerPilotoListadoPorFiltros(PilotoEntidad oPilotoFiltro)
        {
            List<PilotoEntidad> oPilotoColeccion = new List<PilotoEntidad>();
            PilotoEntidad oPiloto = null;
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT P.CODIGO, S.CODIGO AS CODIGO_SOLUCION, S.DESCRIPCION DESCR_SOLUCION, P.DESCRIPCION, E.NOMBRE, ");
            strSQL.Append("E.CODIGO AS CODIGO_ESTADO, P.FECHA_INICIO_IMPL, P.FECHA_FIN_IMPL, P.CODIGO_EMPLEADO ");
            strSQL.Append("FROM PILOTO P ");
            strSQL.Append("INNER JOIN SOLUCION_MEJORA S ON S.CODIGO = P.CODIGO_SOLUCION ");
            strSQL.Append("INNER JOIN ESTADO E ON P.CODIGO_ESTADO = E.CODIGO ");
            strSQL.Append("WHERE E.NOMBRE <> '" + Constantes.ESTADO_PILOTO_ELIMINADO + "' ");
            if (oPilotoFiltro != null)
            {
                if (oPilotoFiltro.codigo != null && oPilotoFiltro.codigo != 0)
                    strSQL.Append("AND P.CODIGO = @CODIGO_PILOTO ");
                if (oPilotoFiltro.fecha_Inicio != null)
                    strSQL.Append("AND DATEDIFF(DAY, P.FECHA_INICIO_IMPL, @FECHA_INICIO) <= 0 ");
                if (oPilotoFiltro.fecha_Inicio != null)
                    strSQL.Append("AND DATEDIFF(DAY, P.FECHA_INICIO_IMPL, @FECHA_FIN) >= 0  ");
            }

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;

            if (oPilotoFiltro != null)
            {
                if (oPilotoFiltro.codigo != null && oPilotoFiltro.codigo != 0)
                    sqlCmd.Parameters.Add("@CODIGO_PILOTO", SqlDbType.Int).Value = oPilotoFiltro.codigo;
                if (oPilotoFiltro.fecha_Inicio != null)
                    sqlCmd.Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime).Value = oPilotoFiltro.fecha_Inicio;
                if (oPilotoFiltro.fecha_Inicio != null)
                    sqlCmd.Parameters.Add("@FECHA_FIN", SqlDbType.DateTime).Value = oPilotoFiltro.fecha_Fin;
            }

            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    oPiloto = new PilotoEntidad();
                    oPiloto.codigo = Utilitario.getDefaultOrIntDBValue(dr["CODIGO"]);
                    oPiloto.codigo_Solucion = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_SOLUCION"]);
                    oPiloto.codigo_Estado = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_ESTADO"]);
                    oPiloto.solucion = Utilitario.getDefaultOrStringDBValue(dr["DESCR_SOLUCION"]);
                    oPiloto.descripcion = Utilitario.getDefaultOrStringDBValue(dr["DESCRIPCION"]);
                    oPiloto.fecha_Inicio = Utilitario.getDefaultOrDatetimeDBValue(dr["FECHA_INICIO_IMPL"]);
                    oPiloto.fecha_Fin = Utilitario.getDefaultOrDatetimeDBValue(dr["FECHA_FIN_IMPL"]);
                    oPiloto.nombre_Estado = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE"]);
                    oPiloto.codigo_Empleado = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_EMPLEADO"]);
                    oPilotoColeccion.Add(oPiloto);
                }
                dr.Close();
                return oPilotoColeccion;
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

        //public PilotoEntidad ObtenerPilotoPorCodigo(int codigo) {
        //    PilotoEntidad oPiloto = new PilotoEntidad();
        //    String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
        //    SqlConnection sqlConn = new SqlConnection(strConn);
        //    StringBuilder strSQL = new StringBuilder();
            

        //    try
        //    {
               
        //        return oPiloto;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        sqlConn.Close();
        //    }
        //}

        public PilotoEntidad ObtenerPilotoPorCodigo(int codigo)
        {
            PilotoEntidad oPiloto = new PilotoEntidad();
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT P.CODIGO, S.CODIGO AS CODIGO_SOLUCION, S.DESCRIPCION DESCR_SOLUCION, P.DESCRIPCION, E.NOMBRE, ");
            strSQL.Append("E.CODIGO AS CODIGO_ESTADO, P.FECHA_INICIO_IMPL, P.FECHA_FIN_IMPL, P.CODIGO_EMPLEADO ");
            strSQL.Append("FROM PILOTO P ");
            strSQL.Append("INNER JOIN SOLUCION_MEJORA S ON S.CODIGO = P.CODIGO_SOLUCION ");
            strSQL.Append("INNER JOIN ESTADO E ON P.CODIGO_ESTADO = E.CODIGO ");
            strSQL.Append("WHERE P.CODIGO = @CODIGO_PILOTO ");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO_PILOTO", SqlDbType.Int).Value = codigo;

            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();

                if (dr.Read())
                {
                    oPiloto = new PilotoEntidad();
                    oPiloto.codigo = Utilitario.getDefaultOrIntDBValue(dr["CODIGO"]);
                    oPiloto.codigo_Solucion = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_SOLUCION"]);
                    oPiloto.codigo_Estado = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_ESTADO"]);
                    oPiloto.solucion = Utilitario.getDefaultOrStringDBValue(dr["DESCR_SOLUCION"]);
                    oPiloto.descripcion = Utilitario.getDefaultOrStringDBValue(dr["DESCRIPCION"]);
                    oPiloto.nombre_Estado = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE"]);
                    oPiloto.fecha_Inicio = Utilitario.getDefaultOrDatetimeDBValue(dr["FECHA_INICIO_IMPL"]);
                    oPiloto.fecha_Fin = Utilitario.getDefaultOrDatetimeDBValue(dr["FECHA_FIN_IMPL"]);
                    oPiloto.codigo_Empleado = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_EMPLEADO"]);

                }
                dr.Close();
                return oPiloto;
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
        public PilotoEntidad InsertarPiloto(PilotoEntidad oPiloto)
        {

            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("INSERT INTO [PILOTO]");
            strSQL.Append("(CODIGO_EMPLEADO,CODIGO_SOLUCION,FECHA_INICIO_IMPL,FECHA_FIN_IMPL,DESCRIPCION,CODIGO_ESTADO) ");
            strSQL.Append("VALUES(@CODIGO_EMPLEADO,@CODIGO_SOLUCION,@FECHA_INICIO_IMPL,@FECHA_FIN_IMPL,@DESCRIPCION,@CODIGO_ESTADO)");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;
            int affectedRows = 0;
            try
            {
                sqlCmd.Parameters.Add("@CODIGO_EMPLEADO", SqlDbType.Int).Value = oPiloto.codigo_Empleado;
                sqlCmd.Parameters.Add("@CODIGO_SOLUCION", SqlDbType.Int).Value = oPiloto.codigo_Solucion;
                sqlCmd.Parameters.Add("@FECHA_INICIO_IMPL", SqlDbType.DateTime).Value = oPiloto.fecha_Inicio;
                sqlCmd.Parameters.Add("@FECHA_FIN_IMPL", SqlDbType.DateTime).Value = oPiloto.fecha_Fin;
                sqlCmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = oPiloto.descripcion;
                sqlCmd.Parameters.Add("@CODIGO_ESTADO", SqlDbType.Int).Value = oPiloto.codigo_Estado;
                sqlConn.Open();

                affectedRows = sqlCmd.ExecuteNonQuery();

                if (affectedRows == 0)
                {
                    throw new System.Exception("No hay registros ingresados a la tabla Piloto");
                }
                else
                {
                    oPiloto.codigo = ObtenerKeyInsertada(Constantes.TABLA_PILOTO);
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

            return oPiloto;
        }

        public PilotoEntidad InsertarPilotoEstado(PilotoEstadoEntidad oPilotoEstado)
        {

            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("INSERT INTO ESTADO_PILOTO");
            strSQL.Append("(CODIGO_PILOTO,CODIGO_ESTADO,FECHA) ");
            strSQL.Append("VALUES(@CODIGO_PILOTO,@CODIGO_ESTADO,GETDATE())");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;
            int affectedRows = 0;
            try
            {
                sqlCmd.Parameters.Add("@CODIGO_PILOTO", SqlDbType.Int).Value = oPilotoEstado.codigo_piloto;
                sqlCmd.Parameters.Add("@CODIGO_ESTADO", SqlDbType.Int).Value = oPilotoEstado.codigo_estado;
                sqlConn.Open();

                affectedRows = sqlCmd.ExecuteNonQuery();

                if (affectedRows == 0)
                {
                    throw new System.Exception("No hay registros ingresados a la tabla Piloto Estado");
                }
                else
                {
                    oPilotoEstado.codigo = ObtenerKeyInsertada(Constantes.TABLA_PILOTO_ESTADO);
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

        public void ActualizarPiloto(PilotoEntidad oPiloto)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("UPDATE PILOTO SET CODIGO_ESTADO = @CODIGO_ESTADO WHERE CODIGO = @CODIGO_PILOTO");
            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO_PILOTO", SqlDbType.Int).Value = oPiloto.codigo;
            sqlCmd.Parameters.Add("@CODIGO_ESTADO", SqlDbType.Int).Value = oPiloto.codigo_Estado;

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

        public void ActualizarEstadoPiloto(PilotoEntidad oPiloto)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("UPDATE PILOTO SET CODIGO_ESTADO = @CODIGO_ESTADO WHERE CODIGO = @CODIGO");
            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO", SqlDbType.Int).Value = oPiloto.codigo;
            sqlCmd.Parameters.Add("@CODIGO_ESTADO", SqlDbType.Int).Value = oPiloto.codigo_Estado;

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
        public void EliminarPilotoPorCodigo(int codigo)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
