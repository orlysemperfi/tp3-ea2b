using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.Entidades;
using System.Data;
using System.Data.SqlClient;
using TMD.GM.Util;
using TMD.GM.AccesoDatos.Contrato;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace TMD.GM.AccesoDatos.Implementacion
{
    public class EspecialidadDA : IEspecialidadDA
    {
        public List<EspecialidadBE> ObtenerEspecialidades()
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                List<EspecialidadBE> result = new List<EspecialidadBE>();

                using (IDataReader oReader = SQLHelper.ExecuteReader(BaseDA.GetSQLConnectionString(), CommandType.Text, "GET_ESPECIALIDAD"))
                {
                    while (oReader.Read())
                    {
                        result.Add(new EspecialidadBE()
                        {
                            CODIGO_TIPO_ACTIVIDAD = DataUT.ObjectToInt32(oReader["CODIGO_TIPO_ACTIVIDAD"]),
                            DESCRIPCION_TIPO_ACTIVIDAD = DataUT.ObjectToString(oReader["DESCRIPCION_TIPO_ACTIVIDAD"]),
                        });
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EspecialidadBE> ObtenerEspecialidadesxEmp(int codEmpleado)
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                List<EspecialidadBE> result = new List<EspecialidadBE>();

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CODIGO_EMPLEADO", SqlDbType.Int);
                param[0].Value = codEmpleado;

                using (IDataReader oReader = SQLHelper.ExecuteReader(BaseDA.GetSQLConnectionString(), CommandType.StoredProcedure, "GET_ESPECIALIDAD_EMP", param))
                {
                    while (oReader.Read())
                    {
                        result.Add(new EspecialidadBE()
                        {
                            CODIGO_TIPO_ACTIVIDAD = DataUT.ObjectToInt32(oReader["CODIGO_TIPO_ACTIVIDAD"]),
                            DESCRIPCION_TIPO_ACTIVIDAD = DataUT.ObjectToString(oReader["DESCRIPCION_TIPO_ACTIVIDAD"]),
                            ESPECIALIDAD = DataUT.ObjectToBoolean(oReader["ESPECIALIDAD"]),
                        });
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
