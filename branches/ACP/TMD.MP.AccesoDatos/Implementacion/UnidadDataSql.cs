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
    public class UnidadDataSql :IUnidadData
    {
        #region "Select"
        public List<UnidadEntidad> ObtenerListaUnidadTodas()
        {
            //insertar();
          List<UnidadEntidad> lstUnidad = new List<UnidadEntidad>();
          UnidadEntidad oUnidad = null;
          String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
          SqlConnection sqlConn = new SqlConnection(strConn);
          StringBuilder strSQL = new StringBuilder();
          strSQL.Append("SELECT CODIGO,MEDIDA,DESCRIPCION FROM UNIDAD");
          SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
          SqlDataReader dr = null;
          sqlCmd.CommandType = CommandType.Text;

          try
          {
              sqlConn.Open();
              dr = sqlCmd.ExecuteReader();

              while (dr.Read())
              {
                  oUnidad = new UnidadEntidad();
                  oUnidad.codigo = Utilitario.getDefaultOrIntDBValue(dr["CODIGO"]);
                  oUnidad.descripcion = Utilitario.getDefaultOrStringDBValue(dr["DESCRIPCION"]);
                  oUnidad.medida = Utilitario.getDefaultOrStringDBValue(dr["MEDIDA"]);
                  lstUnidad.Add(oUnidad);
              }

              dr.Close();
              return lstUnidad;
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

        public void insertar()
        {
            //Metodo dummy de prueba, sera borrado
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_UNIDAD_INS", conn);
            double valor = 10.451d;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DESCRIPCION",SqlDbType.VarChar).Value = "segundos";
            cmd.Parameters.Add("@MEDIDA", SqlDbType.VarChar).Value = "s";
            cmd.Parameters.Add("@VALOR", SqlDbType.Float).Value = valor;

            foreach (SqlParameter s in cmd.Parameters)
            {
                System.Diagnostics.Debug.WriteLine(s.ParameterName);
            }
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        /* Ejemplo dummy de lectura
            UnidadLogica unidadLogica = new UnidadLogica();
            List<UnidadEntidad> lista = unidadLogica.SeleccionarUnidadTodas();
            foreach (UnidadEntidad o in lista)
            {
                System.Diagnostics.Debug.WriteLine(o.valor);
            }
         */
        #endregion

    }



}
