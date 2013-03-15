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

    }
}
