using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using TMD.ACP.AccesoDatos.Core;
using TMD.Entidades;
using System.Data.Common;
using System.Data;
using TMD.ACP.AccesoDatos.Map;
using System.Data.SqlClient;

namespace TMD.ACP.AccesoDatos.Implementacion
{
    public class ReporteData : DataBase
    {
        public ReporteData(String connectionString)
            : base(connectionString)
        {
        }

        public DataSet ObtenerRepPlanAuditoria(int idAuditoria)
        {
            DataSet dsData = new DataSet();
            SqlDataAdapter da;
            SqlCommand sqlCommand;

            using (SqlConnection conn = new SqlConnection(DB.ConnectionString))
            {
                sqlCommand = new SqlCommand("dbo.ACP_SP_REP_PLAN_AUDITORIA_SEC1", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@idAuditoria", SqlDbType.Int);
                sqlCommand.Parameters["@idAuditoria"].Value = idAuditoria;
                da = new SqlDataAdapter(sqlCommand);
                da.Fill(dsData, "ACP_SP_REP_PLAN_AUDITORIA_SEC1");

                sqlCommand = new SqlCommand("dbo.ACP_SP_REP_PLAN_AUDITORIA_SEC2", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@idAuditoria", SqlDbType.Int);
                sqlCommand.Parameters["@idAuditoria"].Value = idAuditoria;
                da = new SqlDataAdapter(sqlCommand);                
                da.Fill(dsData, "ACP_SP_REP_PLAN_AUDITORIA_SEC2");

                sqlCommand = new SqlCommand("dbo.ACP_SP_REP_PLAN_AUDITORIA_SEC3", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@idAuditoria", SqlDbType.Int);
                sqlCommand.Parameters["@idAuditoria"].Value = idAuditoria;
                da = new SqlDataAdapter(sqlCommand);
                da.Fill(dsData, "ACP_SP_REP_PLAN_AUDITORIA_SEC3");
            }

            return dsData;
        }
    }
}
