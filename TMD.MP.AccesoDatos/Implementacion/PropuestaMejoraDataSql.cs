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
    public class PropuestaMejoraDataSql : BaseDataSql, IPropuestaMejoraData
    {
        #region "Select"
        public List<PropuestaMejoraEntidad> ObtenerPropuestaMejoraListadoPorFiltros(PropuestaMejoraEntidad oPropuestaMejoraFiltro)
        {
            List<PropuestaMejoraEntidad> oPropuestaMejoraColeccion = new List<PropuestaMejoraEntidad>();
            PropuestaMejoraEntidad oPropuestaMejora = null;
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT P.CODIGO_PROPUESTA, P.CODIGO_AREA, A.DESCRIPCION AS NOMBRE_AREA, P.TIPO_PROPUESTA, P.CODIGO_RESPONSABLE, ");
            strSQL.Append("P.FECHA_ENVIO, P.CODIGO_PROCESO, P.FECHA_REGISTRO, P.DESCRIPCION, P.CAUSA, P.BENEFICIOS, ");
            strSQL.Append("P.OBSERVACIONES, P.CODIGO_ESTADO, E.NOMBRE AS NOMBRE_ESTADO, ");
            strSQL.Append("R.APELLIDO_PATERNO +' '+R.APELLIDO_MATERNO+', '+R.NOMBRE_PERSONA AS NOMBRE_COMPLETO ");
            strSQL.Append("FROM PROPUESTAMEJORA P ");
            strSQL.Append("INNER JOIN AREA A ON A.CODIGO_AREA = P.CODIGO_AREA ");
            strSQL.Append("INNER JOIN ESTADO E ON E.CODIGO = P.CODIGO_ESTADO ");
            strSQL.Append("INNER JOIN PERSONA R ON R.CODIGO_PERSONA = P.CODIGO_RESPONSABLE ");
            strSQL.Append("WHERE E.NOMBRE <> '" + Constantes.ESTADO_PROPUESTA_ELIMINADA + "' ");
            if (oPropuestaMejoraFiltro != null)
            {
                if (oPropuestaMejoraFiltro.codigo_Propuesta != null && oPropuestaMejoraFiltro.codigo_Propuesta != 0)
                    strSQL.Append("AND P.CODIGO_PROPUESTA = @CODIGO_PROPUESTA ");
                if (oPropuestaMejoraFiltro.tipo_Propuesta != String.Empty)
                    strSQL.Append("AND P.TIPO_PROPUESTA = @TIPO_PROPUESTA ");
                if(oPropuestaMejoraFiltro.fecha_Registro_Inicio != null)
                    strSQL.Append("AND DATEDIFF(DAY, P.FECHA_REGISTRO, @FECHA_REGISTRO_INICIO) <= 0 ");
                if(oPropuestaMejoraFiltro.fecha_Registro_Inicio != null)
                    strSQL.Append("AND DATEDIFF(DAY, P.FECHA_REGISTRO, @FECHA_REGISTRO_FIN) >= 0  ");
            }

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;

            if (oPropuestaMejoraFiltro != null) 
            {
                if (oPropuestaMejoraFiltro.codigo_Propuesta != null && oPropuestaMejoraFiltro.codigo_Propuesta != 0)
                    sqlCmd.Parameters.Add("@CODIGO_PROPUESTA", SqlDbType.Int).Value = oPropuestaMejoraFiltro.codigo_Propuesta;
                if (oPropuestaMejoraFiltro.tipo_Propuesta != String.Empty)
                    sqlCmd.Parameters.Add("@TIPO_PROPUESTA", SqlDbType.VarChar).Value = oPropuestaMejoraFiltro.tipo_Propuesta;
                if (oPropuestaMejoraFiltro.fecha_Registro_Inicio != null)
                    sqlCmd.Parameters.Add("@FECHA_REGISTRO_INICIO", SqlDbType.DateTime).Value = oPropuestaMejoraFiltro.fecha_Registro_Inicio;
                if (oPropuestaMejoraFiltro.fecha_Registro_Inicio != null)
                    sqlCmd.Parameters.Add("@FECHA_REGISTRO_FIN", SqlDbType.DateTime).Value = oPropuestaMejoraFiltro.fecha_Registro_Fin;
            }
            
            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    oPropuestaMejora = new PropuestaMejoraEntidad();                    
                    oPropuestaMejora.codigo_Propuesta = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_PROPUESTA"]);
                    oPropuestaMejora.codigo_Area = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_AREA"]);
                    oPropuestaMejora.nombre_Area = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE_AREA"]);
                    oPropuestaMejora.tipo_Propuesta = Utilitario.getDefaultOrStringDBValue(dr["TIPO_PROPUESTA"]);
                    oPropuestaMejora.codigo_Responsable = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_RESPONSABLE"]);
                    oPropuestaMejora.fecha_Envio = Utilitario.getDefaultOrDatetimeDBValue(dr["FECHA_ENVIO"]);
                    oPropuestaMejora.codigo_Proceso = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_PROCESO"]);
                    oPropuestaMejora.fecha_Registro = Utilitario.getDefaultOrDatetimeDBValue(dr["FECHA_REGISTRO"]);
                    oPropuestaMejora.descripcion = Utilitario.getDefaultOrStringDBValue(dr["DESCRIPCION"]);
                    oPropuestaMejora.causa = Utilitario.getDefaultOrStringDBValue(dr["CAUSA"]);
                    oPropuestaMejora.beneficios = Utilitario.getDefaultOrStringDBValue(dr["BENEFICIOS"]);
                    oPropuestaMejora.observaciones = Utilitario.getDefaultOrStringDBValue(dr["OBSERVACIONES"]);
                    oPropuestaMejora.codigo_Estado = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_ESTADO"]);
                    oPropuestaMejora.nombre_Estado = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE_ESTADO"]);
                    oPropuestaMejora.nombre_Responsable = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE_COMPLETO"]);
                    oPropuestaMejoraColeccion.Add(oPropuestaMejora);
                }
                dr.Close();
                return oPropuestaMejoraColeccion;
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

        public List<PropuestaMejoraEntidad> ObtenerPropuestaMejoraAsignadasListadoPorFiltros(PropuestaMejoraEntidad oPropuestaMejoraFiltro)
        {
            List<PropuestaMejoraEntidad> oPropuestaMejoraColeccion = new List<PropuestaMejoraEntidad>();
            PropuestaMejoraEntidad oPropuestaMejora = null;
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT P.CODIGO_PROPUESTA, P.CODIGO_AREA, A.DESCRIPCION AS NOMBRE_AREA, P.TIPO_PROPUESTA, P.CODIGO_RESPONSABLE, ");
            strSQL.Append("P.FECHA_ENVIO, P.CODIGO_PROCESO, P.FECHA_REGISTRO, P.DESCRIPCION, P.CAUSA, P.BENEFICIOS, ");
            strSQL.Append("P.OBSERVACIONES, P.CODIGO_ESTADO, E.NOMBRE AS NOMBRE_ESTADO, ");
            strSQL.Append("R.APELLIDO_PATERNO +' '+R.APELLIDO_MATERNO+', '+R.NOMBRE_PERSONA AS NOMBRE_COMPLETO ");
            strSQL.Append("FROM PROPUESTAMEJORA P ");
            strSQL.Append("INNER JOIN AREA A ON A.CODIGO_AREA = P.CODIGO_AREA ");
            strSQL.Append("INNER JOIN ESTADO E ON E.CODIGO = P.CODIGO_ESTADO ");
            strSQL.Append("INNER JOIN PERSONA R ON R.CODIGO_PERSONA = P.CODIGO_RESPONSABLE ");
            strSQL.Append("WHERE E.NOMBRE = '" + Constantes.ESTADO_PROPUESTA_ASIGNADA + "' ");
            if (oPropuestaMejoraFiltro != null)
            {
                if (oPropuestaMejoraFiltro.codigo_Propuesta != null && oPropuestaMejoraFiltro.codigo_Propuesta != 0)
                    strSQL.Append("AND P.CODIGO_PROPUESTA = @CODIGO_PROPUESTA ");
                if (oPropuestaMejoraFiltro.tipo_Propuesta != String.Empty)
                    strSQL.Append("AND P.TIPO_PROPUESTA = @TIPO_PROPUESTA ");
                if (oPropuestaMejoraFiltro.fecha_Registro_Inicio != null)
                    strSQL.Append("AND DATEDIFF(DAY, P.FECHA_REGISTRO, @FECHA_REGISTRO_INICIO) <= 0 ");
                if (oPropuestaMejoraFiltro.fecha_Registro_Fin != null)
                    strSQL.Append("AND DATEDIFF(DAY, P.FECHA_REGISTRO, @FECHA_REGISTRO_FIN) >= 0  ");
            }

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;

            if (oPropuestaMejoraFiltro != null)
            {
                if (oPropuestaMejoraFiltro.codigo_Propuesta != null && oPropuestaMejoraFiltro.codigo_Propuesta != 0)
                    sqlCmd.Parameters.Add("@CODIGO_PROPUESTA", SqlDbType.Int).Value = oPropuestaMejoraFiltro.codigo_Propuesta;
                if (oPropuestaMejoraFiltro.tipo_Propuesta != String.Empty)
                    sqlCmd.Parameters.Add("@TIPO_PROPUESTA", SqlDbType.VarChar).Value = oPropuestaMejoraFiltro.tipo_Propuesta;
                if (oPropuestaMejoraFiltro.fecha_Registro_Inicio != null)
                    sqlCmd.Parameters.Add("@FECHA_REGISTRO_INICIO", SqlDbType.DateTime).Value = oPropuestaMejoraFiltro.fecha_Registro_Inicio;
                if (oPropuestaMejoraFiltro.fecha_Registro_Inicio != null)
                    sqlCmd.Parameters.Add("@FECHA_REGISTRO_FIN", SqlDbType.DateTime).Value = oPropuestaMejoraFiltro.fecha_Registro_Fin;
            }

            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    oPropuestaMejora = new PropuestaMejoraEntidad();
                    oPropuestaMejora.codigo_Propuesta = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_PROPUESTA"]);
                    oPropuestaMejora.codigo_Area = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_AREA"]);
                    oPropuestaMejora.nombre_Area = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE_AREA"]);
                    oPropuestaMejora.tipo_Propuesta = Utilitario.getDefaultOrStringDBValue(dr["TIPO_PROPUESTA"]);
                    oPropuestaMejora.codigo_Responsable = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_RESPONSABLE"]);
                    oPropuestaMejora.fecha_Envio = Utilitario.getDefaultOrDatetimeDBValue(dr["FECHA_ENVIO"]);
                    oPropuestaMejora.codigo_Proceso = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_PROCESO"]);
                    oPropuestaMejora.fecha_Registro = Utilitario.getDefaultOrDatetimeDBValue(dr["FECHA_REGISTRO"]);
                    oPropuestaMejora.descripcion = Utilitario.getDefaultOrStringDBValue(dr["DESCRIPCION"]);
                    oPropuestaMejora.causa = Utilitario.getDefaultOrStringDBValue(dr["CAUSA"]);
                    oPropuestaMejora.beneficios = Utilitario.getDefaultOrStringDBValue(dr["BENEFICIOS"]);
                    oPropuestaMejora.observaciones = Utilitario.getDefaultOrStringDBValue(dr["OBSERVACIONES"]);
                    oPropuestaMejora.codigo_Estado = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_ESTADO"]);
                    oPropuestaMejora.nombre_Estado = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE_ESTADO"]);
                    oPropuestaMejora.nombre_Responsable = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE_COMPLETO"]);
                    oPropuestaMejoraColeccion.Add(oPropuestaMejora);
                }
                dr.Close();
                return oPropuestaMejoraColeccion;
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

        public PropuestaMejoraEntidad ObtenerPropuestaMejoraPorCodigo(int codigo) {
            PropuestaMejoraEntidad oPropuestaMejora = new PropuestaMejoraEntidad();
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT P.CODIGO_PROPUESTA, P.CODIGO_AREA, P.TIPO_PROPUESTA, P.CODIGO_RESPONSABLE, P.FECHA_ENVIO, P.CODIGO_PROCESO, P.FECHA_REGISTRO, P.DESCRIPCION, P.CAUSA, P.BENEFICIOS, P.OBSERVACIONES, P.CODIGO_ESTADO, E.NOMBRE AS NOMBRE_ESTADO ");
            strSQL.Append("FROM PROPUESTAMEJORA P ");
            strSQL.Append("INNER JOIN ESTADO E ON E.CODIGO = P.CODIGO_ESTADO ");
            strSQL.Append("WHERE P.CODIGO_PROPUESTA = @CODIGO_PROPUESTA");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO_PROPUESTA", SqlDbType.Int).Value = codigo;

            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();

                if (dr.Read())
                {
                    oPropuestaMejora.codigo_Propuesta = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_PROPUESTA"]);
                    oPropuestaMejora.codigo_Area = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_AREA"]);
                    oPropuestaMejora.tipo_Propuesta = Utilitario.getDefaultOrStringDBValue(dr["TIPO_PROPUESTA"]);
                    oPropuestaMejora.codigo_Responsable = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_RESPONSABLE"]);
                    oPropuestaMejora.fecha_Envio = Utilitario.getDefaultOrDatetimeDBValue(dr["FECHA_ENVIO"]);
                    oPropuestaMejora.codigo_Proceso = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_PROCESO"]);
                    oPropuestaMejora.fecha_Registro = Utilitario.getDefaultOrDatetimeDBValue(dr["FECHA_REGISTRO"]);
                    oPropuestaMejora.descripcion = Utilitario.getDefaultOrStringDBValue(dr["DESCRIPCION"]);
                    oPropuestaMejora.causa = Utilitario.getDefaultOrStringDBValue(dr["CAUSA"]);
                    oPropuestaMejora.beneficios = Utilitario.getDefaultOrStringDBValue(dr["BENEFICIOS"]);
                    oPropuestaMejora.observaciones = Utilitario.getDefaultOrStringDBValue(dr["OBSERVACIONES"]);
                    oPropuestaMejora.codigo_Estado = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_ESTADO"]);
                    oPropuestaMejora.nombre_Estado = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE_ESTADO"]);
                }
                dr.Close();
                return oPropuestaMejora;
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

        public List<PropuestaMejoraEntidad> ObtenerPropuestaMejoraListadoPorEstado(String estado)
        {
            List<PropuestaMejoraEntidad> oPropuestaMejoraColeccion = new List<PropuestaMejoraEntidad>();
            PropuestaMejoraEntidad oPropuestaMejora = null;
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT P.CODIGO_PROPUESTA, P.DESCRIPCION ");
            strSQL.Append("FROM PROPUESTAMEJORA P ");
            strSQL.Append("INNER JOIN ESTADO E ON E.CODIGO = P.CODIGO_ESTADO ");
            strSQL.Append("WHERE E.NOMBRE = '" + estado + "' ");
            
            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;

            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    oPropuestaMejora = new PropuestaMejoraEntidad();
                    oPropuestaMejora.codigo_Propuesta = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_PROPUESTA"]);
                    oPropuestaMejora.descripcion = Utilitario.getDefaultOrStringDBValue(dr["DESCRIPCION"]);
                    oPropuestaMejoraColeccion.Add(oPropuestaMejora);
                }
                dr.Close();
                return oPropuestaMejoraColeccion;
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
        public PropuestaMejoraEntidad InsertarPropuestaMejora(PropuestaMejoraEntidad oPropuestaMejora)
        {
            
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("INSERT INTO [MP].[PROPUESTAMEJORA]");
            strSQL.Append("(CODIGO_AREA,TIPO_PROPUESTA,CODIGO_RESPONSABLE,FECHA_ENVIO,CODIGO_PROCESO,FECHA_REGISTRO,DESCRIPCION,CAUSA,BENEFICIOS,OBSERVACIONES,CODIGO_ESTADO) ");
            strSQL.Append("VALUES(@CODIGO_AREA,@TIPO_PROPUESTA,@CODIGO_RESPONSABLE,@FECHA_ENVIO,@CODIGO_PROCESO,GETDATE(),@DESCRIPCION,@CAUSA,@BENEFICIOS,@OBSERVACIONES,@CODIGO_ESTADO)");
			
            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;
            int affectedRows = 0;
            try
            {
            sqlCmd.Parameters.Add("@CODIGO_AREA", SqlDbType.Int).Value = oPropuestaMejora.codigo_Area;
            sqlCmd.Parameters.Add("@TIPO_PROPUESTA", SqlDbType.VarChar).Value = oPropuestaMejora.tipo_Propuesta;
            sqlCmd.Parameters.Add("@CODIGO_RESPONSABLE", SqlDbType.Int).Value = oPropuestaMejora.codigo_Responsable;
            sqlCmd.Parameters.Add("@FECHA_ENVIO", SqlDbType.DateTime).Value = oPropuestaMejora.fecha_Envio;
            sqlCmd.Parameters.Add("@CODIGO_PROCESO", SqlDbType.Int).Value = oPropuestaMejora.codigo_Proceso;
            sqlCmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = oPropuestaMejora.descripcion;
            sqlCmd.Parameters.Add("@CAUSA", SqlDbType.VarChar).Value = oPropuestaMejora.causa;
            sqlCmd.Parameters.Add("@BENEFICIOS", SqlDbType.VarChar).Value = oPropuestaMejora.beneficios;
            sqlCmd.Parameters.Add("@OBSERVACIONES", SqlDbType.VarChar).Value = oPropuestaMejora.observaciones;
            sqlCmd.Parameters.Add("@CODIGO_ESTADO", SqlDbType.Int).Value = oPropuestaMejora.codigo_Estado;
            //sqlCmd.Parameters.Add("@CODIGO_PROPUESTA", SqlDbType.Int).Value = oPropuestaMejora.codigo_Area;
            //sqlCmd.Parameters["@CODIGO_PROPUESTA"].Direction = ParameterDirection.Output;
            sqlConn.Open();

            affectedRows = sqlCmd.ExecuteNonQuery();

            if (affectedRows == 0)
            {
                throw new System.Exception("No hay registros ingresados a la tabla Propuesta_Mejora");
            }
            else 
            {
                oPropuestaMejora.codigo_Propuesta = ObtenerKeyInsertada(Constantes.TABLA_PROPUESTAMEJORA);
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

            return oPropuestaMejora;
        }

        public PropuestaMejoraEntidad InsertarPropuestaMejoraEstado(PropuestaEstadoEntidad oPropuestaEstado)
        {

            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("INSERT INTO [MP].[PROPUESTA_ESTADO]");
            strSQL.Append("(CODIGO_EMPLEADO,CODIGO_PROPUESTA,CODIGO_ESTADO,FECHA,OBSERVACIONES) ");
            //strSQL.Append("VALUES(@CODIGO_EMPLEADO,@CODIGO_PROPUESTA,@CODIGO_ESTADO,@FECHA,@OBSERVACIONES)");
            strSQL.Append("VALUES(@CODIGO_EMPLEADO,@CODIGO_PROPUESTA,@CODIGO_ESTADO,GETDATE(),@OBSERVACIONES)");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;
            int affectedRows = 0;
            try
            {
                sqlCmd.Parameters.Add("@CODIGO_EMPLEADO", SqlDbType.Int).Value = oPropuestaEstado.codigo_empleado;
                sqlCmd.Parameters.Add("@CODIGO_PROPUESTA", SqlDbType.Int).Value = oPropuestaEstado.codigo_propuesta;
                sqlCmd.Parameters.Add("@CODIGO_ESTADO", SqlDbType.Int).Value = oPropuestaEstado.codigo_estado;
                //sqlCmd.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = oPropuestaEstado.fecha;
                sqlCmd.Parameters.Add("@OBSERVACIONES", SqlDbType.VarChar).Value = oPropuestaEstado.observaciones;
                sqlConn.Open();

                affectedRows = sqlCmd.ExecuteNonQuery();

                if (affectedRows == 0)
                {
                    throw new System.Exception("No hay registros ingresados a la tabla PropuestaEstado");
                }
                else
                {
                    oPropuestaEstado.codigo = ObtenerKeyInsertada(Constantes.TABLA_PROPUESTA_ESTADO);
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
        public void ActualizarEstadoPropuestaMejora(PropuestaMejoraEntidad oPropuestaMejora)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("UPDATE PROPUESTAMEJORA SET CODIGO_ESTADO = @CODIGO_ESTADO WHERE CODIGO_PROPUESTA = @CODIGO_PROPUESTA");
            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO_PROPUESTA", SqlDbType.Int).Value = oPropuestaMejora.codigo_Propuesta;
            sqlCmd.Parameters.Add("@CODIGO_ESTADO", SqlDbType.Int).Value = oPropuestaMejora.codigo_Estado;
            
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

        public void ActualizarPropuestaMejora(PropuestaMejoraEntidad oPropuestaMejora)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("UPDATE PROPUESTAMEJORA SET ");
            strSQL.Append("CODIGO_AREA=@CODIGO_AREA, TIPO_PROPUESTA=@TIPO_PROPUESTA,CODIGO_RESPONSABLE=@CODIGO_RESPONSABLE,");
            strSQL.Append("FECHA_ENVIO=@FECHA_ENVIO,CODIGO_PROCESO=@CODIGO_PROCESO,DESCRIPCION=@DESCRIPCION,CAUSA=@CAUSA,");
            strSQL.Append("BENEFICIOS=@BENEFICIOS,OBSERVACIONES=@OBSERVACIONES,CODIGO_ESTADO=@CODIGO_ESTADO ");
            strSQL.Append("WHERE CODIGO_PROPUESTA = @CODIGO_PROPUESTA");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO_PROPUESTA", SqlDbType.Int).Value = oPropuestaMejora.codigo_Propuesta;
            sqlCmd.Parameters.Add("@CODIGO_AREA", SqlDbType.Int).Value = oPropuestaMejora.codigo_Area;
            sqlCmd.Parameters.Add("@TIPO_PROPUESTA", SqlDbType.VarChar).Value = oPropuestaMejora.tipo_Propuesta;
            sqlCmd.Parameters.Add("@CODIGO_RESPONSABLE", SqlDbType.Int).Value = oPropuestaMejora.codigo_Responsable;
            sqlCmd.Parameters.Add("@FECHA_ENVIO", SqlDbType.DateTime).Value = oPropuestaMejora.fecha_Envio;
            sqlCmd.Parameters.Add("@CODIGO_PROCESO", SqlDbType.Int).Value = oPropuestaMejora.codigo_Proceso;
            sqlCmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = oPropuestaMejora.descripcion;
            sqlCmd.Parameters.Add("@CAUSA", SqlDbType.VarChar).Value = oPropuestaMejora.causa;
            sqlCmd.Parameters.Add("@BENEFICIOS", SqlDbType.VarChar).Value = oPropuestaMejora.beneficios;
            sqlCmd.Parameters.Add("@OBSERVACIONES", SqlDbType.VarChar).Value = oPropuestaMejora.observaciones;
            sqlCmd.Parameters.Add("@CODIGO_ESTADO", SqlDbType.Int).Value = oPropuestaMejora.codigo_Estado;

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
        public void EliminarPropuestaMejroaPorCodigo(int codigo)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
