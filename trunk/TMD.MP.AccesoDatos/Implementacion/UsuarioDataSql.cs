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
    public class UsuarioDataSql : IUsuarioData
    {
        #region "Select"

        public UsuarioEntidad ObtenerUsuario(String nombreUsuario, String contraseniaUsuario)
        {
            UsuarioEntidad oUsuario = new UsuarioEntidad();
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT CODIGO_PERSONA, CODIGO_USUARIO, CONTRASENIA, ESTADO, CODIGO_PERFIL_USUARIO ");
            strSQL.Append("FROM Usuario ");
            strSQL.Append("WHERE CODIGO_USUARIO = @NOMBREUSUARIO AND CONTRASENIA = @CONTRASENIAUSUARIO");
            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn); 
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.Add("@NOMBREUSUARIO", SqlDbType.VarChar).Value = nombreUsuario;
            sqlCmd.Parameters.Add("@CONTRASENIAUSUARIO", SqlDbType.VarChar).Value = contraseniaUsuario;
            try
            {
                sqlConn.Open(); 
                dr = sqlCmd.ExecuteReader();

                if (dr.Read())
                {
                    oUsuario.codigo_Persona = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_PERSONA"]);
                    oUsuario.codigo_Usuario = Utilitario.getDefaultOrStringDBValue(dr["CODIGO_USUARIO"]);
                    oUsuario.contrasenia = Utilitario.getDefaultOrStringDBValue(dr["CONTRASENIA"]);
                    oUsuario.estado = Utilitario.getDefaultOrStringDBValue(dr["ESTADO"]);
                    oUsuario.codigo_Perfil_Usuario = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_PERFIL_USUARIO"]);                
                }
                dr.Close();
                return oUsuario;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally { 
                sqlConn.Close();
            }
        }

        public List<UsuarioEntidad> ObtenerListaEmpleadosTodas()
        {
            UsuarioEntidad oUsuario = null;
            List<UsuarioEntidad> oUsuarioColeccion = new List<UsuarioEntidad>();
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT E.CODIGO_EMPLEADO, E.APEPAT +' '+ E.APEMAT +', '+ E.NOMBRES AS NOMBRE_COMPLETO ");
            strSQL.Append("FROM EMPLEADO E");
            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;
    
            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    oUsuario = new UsuarioEntidad();
                    oUsuario.codigo_Usuario = Utilitario.getDefaultOrStringDBValue(dr["CODIGO_EMPLEADO"]);
                    oUsuario.nombre_completo = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE_COMPLETO"]);
                    oUsuarioColeccion.Add(oUsuario);
                }
                dr.Close();
                return oUsuarioColeccion;
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
