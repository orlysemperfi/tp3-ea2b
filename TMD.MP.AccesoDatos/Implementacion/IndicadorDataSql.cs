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
    public class IndicadorDataSql:IIndicadorData
    {
        #region "Select"
        public List<IndicadorEntidad> ObtenerListaIndicadorPorPropuesta(int codigo_Propuesta)
        {
            List<IndicadorEntidad> lstIndicador = new List<IndicadorEntidad>();
            IndicadorEntidad oIndicador = null;
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT CODIGO,NOMBRE,EXPRESION_MATEMATICA,FRECUENCIA_MEDICION,FUENTE_MEDICION,PLAZO,TIPO ");
            strSQL.Append("FROM MP.INDICADOR I,MP.PROPUESTA_INDICADOR PRI ");
            strSQL.Append("WHERE I.CODIGO = PRI.CODIGO_INDICADOR AND PRI.CODIGO_PROPUESTA=@CODIGO_PROPUESTA ");
            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.Add("@CODIGO_PROPUESTA", SqlDbType.Int).Value = codigo_Propuesta;
            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    oIndicador = new IndicadorEntidad();
                    oIndicador.codigo = Utilitario.getDefaultOrIntDBValue(dr["CODIGO"]);
                   // oIndicador.codigo_Propuesta = codigo_Propuesta;
                    oIndicador.nombre = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE"]);
                    oIndicador.frecuencia_Medicion = Utilitario.getDefaultOrStringDBValue(dr["FRECUENCIA_MEDICION"]);
                    oIndicador.fuente_Medicion = Utilitario.getDefaultOrStringDBValue(dr["FUENTE_MEDICION"]);
                    oIndicador.expresion_Matematica = Utilitario.getDefaultOrStringDBValue(dr["EXPRESION_MATEMATICA"]);
                    oIndicador.plazo = Utilitario.getDefaultOrStringDBValue(dr["PLAZO"]);
                    oIndicador.tipo = Utilitario.getDefaultOrIntDBValue(dr["TIPO"]);
                    lstIndicador.Add(oIndicador);
                }
                dr.Close();
                return lstIndicador;
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

        public List<IndicadorEntidad> ObtenerIndicadorListadoPorFiltros(IndicadorEntidad oIndicadorFiltro)
        {
            List<IndicadorEntidad> oIndicadorColeccion = new List<IndicadorEntidad>();
            IndicadorEntidad oIndicador = null;
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);

            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT I.CODIGO AS CODIGO_INDICADOR, I.NOMBRE, I.EXPRESION_MATEMATICA, I.FRECUENCIA_MEDICION, I.FUENTE_MEDICION, I.PLAZO, I.TIPO FROM MP.INDICADOR I INNER JOIN MP.PROCESO P ON P.CODIGO = I.CODIGO_PROCESO WHERE 1=1 ");

            if (oIndicadorFiltro != null)
            {

                if (oIndicadorFiltro.nombre != null)
                    strSQL.Append("AND I.NOMBRE LIKE '%' + @NOMBRE + '%' ");
                if (oIndicadorFiltro.tipo != -1)
                    strSQL.Append("AND I.TIPO = @TIPO ");
                if (oIndicadorFiltro.codigo_Area != 0)
                    strSQL.Append("AND P.CODIGO_AREA = @AREA ");
                if (oIndicadorFiltro.codigo_Proceso != 0)
                    strSQL.Append("AND P.CODIGO = @PROCESO ");
                
            }

            strSQL.Append("ORDER BY I.NOMBRE ");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;

            if (oIndicadorFiltro != null)
            {
                if (oIndicadorFiltro.nombre != null)
                    sqlCmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = oIndicadorFiltro.nombre;
                if (oIndicadorFiltro.tipo != -1)
                    sqlCmd.Parameters.Add("@TIPO", SqlDbType.Int).Value = oIndicadorFiltro.tipo;
                if (oIndicadorFiltro.codigo_Area != 0)
                    sqlCmd.Parameters.Add("@AREA", SqlDbType.Int).Value = oIndicadorFiltro.codigo_Area;
                if (oIndicadorFiltro.codigo_Proceso != 0)
                    sqlCmd.Parameters.Add("@PROCESO", SqlDbType.Int).Value = oIndicadorFiltro.codigo_Proceso;
            }

            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    oIndicador = new IndicadorEntidad();
                    oIndicador.codigo = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_INDICADOR"]);
                    oIndicador.nombre = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE"]);
                    oIndicador.expresion_Matematica = Utilitario.getDefaultOrStringDBValue(dr["EXPRESION_MATEMATICA"]);
                    oIndicador.frecuencia_Medicion = Utilitario.getDefaultOrStringDBValue(dr["FRECUENCIA_MEDICION"]);
                    oIndicador.fuente_Medicion = Utilitario.getDefaultOrStringDBValue(dr["FUENTE_MEDICION"]);
                    oIndicador.plazo = Utilitario.getDefaultOrStringDBValue(dr["PLAZO"]);
                    oIndicador.tipo = Utilitario.getDefaultOrIntDBValue(dr["TIPO"]);
                    oIndicadorColeccion.Add(oIndicador);
                }
                dr.Close();
                return oIndicadorColeccion;
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
        

        public List<IndicadorEntidad> ObtenerIndicadorPorProceso(int codigo_Proceso)
        {
            List<IndicadorEntidad> oIndicadorColeccion = new List<IndicadorEntidad>();
            IndicadorEntidad oIndicador = null;
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT CODIGO,NOMBRE,EXPRESION_MATEMATICA,FRECUENCIA_MEDICION,FUENTE_MEDICION,PLAZO,TIPO,CODIGO_PROCESO,REEMPLAZA_INDICADOR,ESTADO ");
            strSQL.Append("FROM MP.INDICADOR ");
            strSQL.Append("WHERE CODIGO_PROCESO = @CODIGO_PROCESO");
            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO_PROCESO", SqlDbType.Int).Value = codigo_Proceso;
            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    oIndicador = new IndicadorEntidad();
                    oIndicador.codigo = Utilitario.getDefaultOrIntDBValue(dr["CODIGO"]);
                    oIndicador.nombre = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE"]);
                    oIndicador.expresion_Matematica = Utilitario.getDefaultOrStringDBValue(dr["EXPRESION_MATEMATICA"]);
                    oIndicador.frecuencia_Medicion = Utilitario.getDefaultOrStringDBValue(dr["FRECUENCIA_MEDICION"]);
                    oIndicador.fuente_Medicion = Utilitario.getDefaultOrStringDBValue(dr["FUENTE_MEDICION"]);
                    oIndicador.plazo = Utilitario.getDefaultOrStringDBValue(dr["PLAZO"]);
                    oIndicador.tipo = Utilitario.getDefaultOrIntDBValue(dr["TIPO"]);
                    oIndicador.codigo_Proceso = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_PROCESO"]);
                    oIndicador.reemplaza_Indicador = Utilitario.getDefaultOrIntDBValue(dr["REEMPLAZA_INDICADOR"]);
                    oIndicador.estado = Utilitario.getDefaultOrIntDBValue(dr["ESTADO"]);
                    oIndicadorColeccion.Add(oIndicador);
                }
                dr.Close();
                return oIndicadorColeccion;
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

        public IndicadorEntidad ObtenerIndicadorPorCodigo(int codigo) { 
                    
            IndicadorEntidad oIndicador = new IndicadorEntidad();
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT CODIGO,NOMBRE,EXPRESION_MATEMATICA,FRECUENCIA_MEDICION,FUENTE_MEDICION,");
            strSQL.Append("PLAZO,TIPO,CODIGO_PROCESO,REEMPLAZA_INDICADOR,ESTADO ");
            strSQL.Append("FROM TMD.MP.INDICADOR ");
            strSQL.Append("WHERE CODIGO=@CODIGO_INDICADOR");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO_INDICADOR", SqlDbType.Int).Value = codigo;                

            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();

                if (dr.Read())
                {
                    oIndicador.codigo = Utilitario.getDefaultOrIntDBValue(dr["CODIGO"]);
                    oIndicador.nombre = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE"]);
                    oIndicador.expresion_Matematica = Utilitario.getDefaultOrStringDBValue(dr["EXPRESION_MATEMATICA"]);
                    oIndicador.frecuencia_Medicion = Utilitario.getDefaultOrStringDBValue(dr["FRECUENCIA_MEDICION"]);
                    oIndicador.fuente_Medicion = Utilitario.getDefaultOrStringDBValue(dr["FUENTE_MEDICION"]);
                    oIndicador.plazo = Utilitario.getDefaultOrStringDBValue(dr["PLAZO"]);
                    oIndicador.tipo = Utilitario.getDefaultOrIntDBValue(dr["TIPO"]);
                    oIndicador.codigo_Proceso = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_PROCESO"]);
                    oIndicador.reemplaza_Indicador = Utilitario.getDefaultOrIntDBValue(dr["REEMPLAZA_INDICADOR"]);
                    oIndicador.estado = Utilitario.getDefaultOrIntDBValue(dr["ESTADO"]);
                    
                }
                dr.Close();
                return oIndicador;
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
        public void InsertarIndicador(IndicadorEntidad entidad)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            StringBuilder strSQLId = new StringBuilder();
            StringBuilder strSQLDet = new StringBuilder();
            SqlDataReader sqlDr = null;
            int iCodigo_Indicador = 0;
            strSQL.Append("INSERT INTO MP.INDICADOR ");
            strSQL.Append("(NOMBRE,EXPRESION_MATEMATICA,FRECUENCIA_MEDICION,FUENTE_MEDICION,PLAZO,TIPO) ");
            strSQL.Append("VALUES(@NOMBRE,@EXPRESION_MATEMATICA,@FRECUENCIA_MEDICION,@FUENTE_MEDICION,@PLAZO,@TIPO)");
            strSQL.Append("INSERT INTO MP.INDICADOR");

            strSQLId.Append("SELECT IDENT_CURRENT('MP.INDICADOR') AS CODIGO");

            strSQLDet.Append("INSERT INTO MP.PROPUESTA_INDICADOR(CODIGO_PROPUESTA,CODIGO_INDICADOR) ");
            strSQLDet.Append("VALUES(@CODIGO_PROPUESTA,@CODIGO_INDICADOR)");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlCommand sqlCmdId = new SqlCommand(strSQLId.ToString(), sqlConn);
            SqlCommand sqlCmdDet = new SqlCommand(strSQLDet.ToString(), sqlConn);

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = entidad.nombre;
            sqlCmd.Parameters.Add("@FRECUENCIA_MEDICION", SqlDbType.VarChar).Value = entidad.frecuencia_Medicion;
            sqlCmd.Parameters.Add("@FUENTE_MEDICION", SqlDbType.VarChar).Value = entidad.fuente_Medicion;
            sqlCmd.Parameters.Add("@EXPRESION_MATEMATICA", SqlDbType.VarChar).Value = entidad.expresion_Matematica;
            sqlCmd.Parameters.Add("@PLAZO", SqlDbType.VarChar).Value = entidad.plazo;
            sqlCmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = entidad.tipo;

            sqlCmdId.CommandType = CommandType.Text;
            sqlCmdDet.CommandType = CommandType.Text;
            try
            {

                sqlConn.Open();
                sqlCmd.ExecuteNonQuery();
                //Obteniendo el siguiente ID

                sqlDr = sqlCmdId.ExecuteReader();
                if (sqlDr.Read())
                    iCodigo_Indicador = Convert.ToInt32(sqlDr["CODIGO"].ToString());

                sqlCmdDet.Parameters.Add("@CODIGO_PROPUESTA",SqlDbType.Int).Value = entidad.codigo_Propuesta;
                sqlCmdDet.Parameters.Add("@CODIGO_INDICADOR", SqlDbType.Int).Value = iCodigo_Indicador;
                sqlCmdDet.ExecuteNonQuery();

                
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
        public void InsertarPropuestaIndicador(IndicadorEntidad entidad)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();

            strSQL.Append("INSERT INTO [TMD].[MP].[PROPUESTA_INDICADOR] ([CODIGO_PROPUESTA],[CODIGO_INDICADOR]) ");
            strSQL.Append("VALUES (@CODIGO_PROPUESTA,@CODIGO_INDICADOR) ");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;

            sqlCmd.Parameters.Add("@CODIGO_PROPUESTA", SqlDbType.Int).Value = entidad.codigo_Propuesta;
            sqlCmd.Parameters.Add("@CODIGO_INDICADOR", SqlDbType.Int).Value = entidad.codigo;

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
        public void ActualizarIndicador(IndicadorEntidad entidad)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("UPDATE MP.INDICADOR ");
            strSQL.Append("SET NOMBRE = @NOMBRE,EXPRESION_MATEMATICA= @EXPRESION_MATEMATICA,FRECUENCIA_MEDICION = @FRECUENCIA_MEDICION, ");
            strSQL.Append("FUENTE_MEDICION=@FUENTE_MEDICION,PLAZO=@PLAZO,TIPO=@TIPO, CODIGO_PROCESO=@CODIGO_PROCESO ");
            strSQL.Append("REEMPLAZA_INDICADOR=@REEMPLAZA_INDICADOR, ESTADO=@ESTADO ");
            strSQL.Append("WHERE CODIGO=@CODIGO ");
            
            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = entidad.codigo;
            sqlCmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = entidad.nombre;
            sqlCmd.Parameters.Add("@FRECUENCIA_MEDICION", SqlDbType.VarChar).Value = entidad.frecuencia_Medicion;
            sqlCmd.Parameters.Add("@FUENTE_MEDICION", SqlDbType.VarChar).Value = entidad.fuente_Medicion;
            sqlCmd.Parameters.Add("@EXPRESION_MATEMATICA", SqlDbType.VarChar).Value = entidad.expresion_Matematica;
            sqlCmd.Parameters.Add("@PLAZO", SqlDbType.VarChar).Value = entidad.plazo;
            sqlCmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = entidad.tipo;
            sqlCmd.Parameters.Add("@CODIGO_PROCESO", SqlDbType.VarChar).Value = entidad.codigo_Proceso;
            sqlCmd.Parameters.Add("@REEMPLAZA_INDICADOR", SqlDbType.VarChar).Value = entidad.reemplaza_Indicador;
            sqlCmd.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = entidad.estado;

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
        public void EliminarIndicadorPorPropuesta(int codigo_Propuesta)
        {
             //FALTA IMPLEMENTAR
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("DELETE FROM MP.PROPUESTA_INDICADOR ");
            strSQL.Append("WHERE CODIGO_PROPUESTA = @CODIGO_PROPUESTA");
            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.Add("@CODIGO_PROPUESTA", SqlDbType.Int).Value = codigo_Propuesta;
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
