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
using TMD.MP.AccesoDatos.Interfaces;

namespace TMD.MP.AccesoDatos.Implementacion
{
    public class ProcesoDataSql : IProcesoData
    {
        #region "Select"
        public List<ProcesoEntidad> ObtenerListaProcesoTodas()
        {
            List<ProcesoEntidad> lstProceso = new List<ProcesoEntidad>();
            ProcesoEntidad oProceso = null;
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT CODIGO,CODIGO_AREA,NOMBRE,OBJETIVO,ALCANCE ");
            strSQL.Append("FROM TMD.MP.PROCESO");

            SqlCommand sqlCmd = new SqlCommand(strSQL.ToString(), sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.Text;

            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    oProceso = new ProcesoEntidad();
                    oProceso.codigo = Utilitario.getDefaultOrIntDBValue(dr["CODIGO"]);
                    oProceso.codigo_Area = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_AREA"]);
                    oProceso.nombre = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE"]);
                    oProceso.objetivo = Utilitario.getDefaultOrStringDBValue(dr["OBJETIVO"]);
                    oProceso.alcance = Utilitario.getDefaultOrStringDBValue(dr["ALCANCE"]);
                    lstProceso.Add(oProceso);
                }

                dr.Close();
                return lstProceso;
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

        public List<ProcesoEntidad> ObtenerProcesoPorArea1(int codigoArea)
        {
            List<ProcesoEntidad> lstProceso = new List<ProcesoEntidad>();
            ProcesoEntidad oProceso = null;
            String strConn = ConfigurationManager.ConnectionStrings[Constantes.TMD_MP_DATABASE].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            SqlCommand sqlCmd = new SqlCommand("MP.USP_PROCESO_SEL_AREA", sqlConn);
            SqlDataReader dr = null;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add("@CODIGO_AREA", SqlDbType.Int).Value = codigoArea;
            try
            {
                sqlConn.Open();
                dr = sqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    oProceso = new ProcesoEntidad();
                    oProceso.codigo = Utilitario.getDefaultOrIntDBValue(dr["CODIGO"]);
                    oProceso.codigo_Area = Utilitario.getDefaultOrIntDBValue(dr["CODIGO_AREA"]);
                    oProceso.nombre = Utilitario.getDefaultOrStringDBValue(dr["NOMBRE"]);
                    oProceso.objetivo = Utilitario.getDefaultOrStringDBValue(dr["OBJETIVO"]);
                    oProceso.alcance = Utilitario.getDefaultOrStringDBValue(dr["ALCANCE"]);
                    lstProceso.Add(oProceso);
                }

                dr.Close();
                return lstProceso;
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
