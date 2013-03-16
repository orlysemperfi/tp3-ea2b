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
            strSQL.Append("SELECT S.CODIGO, S.DESCRIPCION, P.DESCRIPCION, E.NOMBRE ");
            strSQL.Append("FROM MP.SOLUCION_MEJORA S ");
            strSQL.Append("INNER JOIN MP.PROPUESTAMEJORA P ON S.CODIGO_PROPUESTA = P.CODIGO_PROPUESTA ");
            strSQL.Append("INNER JOIN MP.ESTADO E ON S.CODIGO_ESTADO = E.CODIGO ");
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
                    oSolucionMejora.propuesta = Utilitario.getDefaultOrStringDBValue(dr["DESCRIPCION"]);
                    oSolucionMejora.nombre_Estado = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE"]);
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
            
            try
            {
                
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
        #endregion

        #region "Insert"
        public SolucionMejoraEntidad InsertarSolucionMejora(SolucionMejoraEntidad oSolucionMejora)
        {

            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            
            try
            {
                

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

        #endregion

        #region "Update"
        
        public void ActualizarSolucionMejora(SolucionMejoraEntidad oSolucionMejora)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            
            try
            {
                
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
