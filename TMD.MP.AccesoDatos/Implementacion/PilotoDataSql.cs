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
            
            try
            {
                
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

        public List<PilotoEntidad> ObtenerPilotoAsignadasListadoPorFiltros(PilotoEntidad oPilotoFiltro)
        {
            List<PilotoEntidad> oPilotoColeccion = new List<PilotoEntidad>();
            PilotoEntidad oPiloto = null;
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            
            try
            {
                
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

        public PilotoEntidad ObtenerPilotoPorCodigo(int codigo) {
            PilotoEntidad oPiloto = new PilotoEntidad();
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            

            try
            {
               
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
            strSQL.Append("INSERT INTO [MP].[PILOTO]");
            strSQL.Append("(CODIGO_EMPLEADO,CODIGO_SOLUCION,FECHA_INICIO_IMPL,FECHA_FIN_IMPL,DESCRIPCION,CODIGO_ESTADO) ");
            strSQL.Append("VALUES(@CODIGO_EMPLEADO,@CODIGO_SOLUCION,@FECHA_INICIO_IMPL,@FECHA_FIN_IMPL,@DESCRIPCION,@CODIGO_ESTADO)");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            sqlCmd.CommandType = CommandType.Text;
            int affectedRows = 0;
            try
            {
                sqlCmd.Parameters.Add("@CODIGO_EMPLEADO", SqlDbType.Int).Value = oPiloto.codigo_Empleado;
                sqlCmd.Parameters.Add("@CODIGO_SOLUCION", SqlDbType.Int).Value = oPiloto.codigo_Solucion;
                sqlCmd.Parameters.Add("@FECHA_INICIO_IMPL", SqlDbType.Int).Value = oPiloto.fecha_Inicio;
                sqlCmd.Parameters.Add("@FECHA_FIN_IMPL", SqlDbType.Int).Value = oPiloto.fecha_Fin;
                sqlCmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = oPiloto.descripcion;
                sqlCmd.Parameters.Add("@CODIGO_ESTADO", SqlDbType.Int).Value = oPiloto.codigo_Estado;
                sqlConn.Open();

                affectedRows = sqlCmd.ExecuteNonQuery();

                if (affectedRows == 0)
                {
                    throw new System.Exception("No hay registros ingresados a la tabla Solucion_Mejora");
                }
                else
                {
                    oPiloto.codigo_Solucion = ObtenerKeyInsertada(Constantes.TABLA_SOLUCION_MEJORA);
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
            strSQL.Append("INSERT INTO MP.ESTADO_PILOTO");
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

        public void ActualizarEstadoPiloto(PilotoEntidad oPiloto)
        {
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("UPDATE MP.PILOTO SET CODIGO_ESTADO = @CODIGO_ESTADO WHERE CODIGO = @CODIGO");
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
